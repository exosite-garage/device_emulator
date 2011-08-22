using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Timers;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Utilities;
using Newtonsoft.Json.Linq;
using System.Deployment.Application;
using System.Runtime.Serialization.Json;
using clronep;

namespace Exosite_Emulator
{
    public partial class Form1 : Form
    {
        static bool GoodConnection = true;
        static bool running = false;
        static bool platformSync = false;
        static int reportTime = 10;
        static bool getCPU = false;
        static bool getMEM = false;
        static bool getTriWave = false;
        static bool getPower = false;
        static bool getCustom = false;
        static bool getMessage = true;
        static bool triWaveUp = true;
        static int triWaveValue = 0;
        static int numBadConnections = 0;
        static String deviceCIK;
       
        static appDataPort[] appDataPorts;
        static String sendValue;
        static String TextForMessageBox;
        static String InfoMessageText = null;
        static String messageBoxRID = null;
        static String msgUnits = null;

        Thread ExositeThread;
        ExoThread ExositeThreadObject;

        static PowerStatus power = SystemInformation.PowerStatus;

        public delegate void ChangeMessageBoxText();
        public ChangeMessageBoxText messageBoxDelegate;
        public static ClientOnepV1 onepConn = null;
        public static Dictionary<string, string> AliasDict = new Dictionary<string, string>();
        public void SetMessageBox1()
        {
            if (msgUnits != null)
                MessageBox1.Text = TextForMessageBox + " " + msgUnits;
            else
                MessageBox1.Text = TextForMessageBox;
        }
        public static Dictionary<string, appDataPort> AppDataportsDict = new Dictionary<string, appDataPort>();
        public class appDataPort
        {
            public String alias { get; set; }
            public String format { get; set; }
            public String name { get; set; }
            public String units { get; set; }
            public appDataPort(String name, String alias, String format, String units)
            {
                this.alias = alias;
                this.format = format;
                this.name = name;
                this.units = units;
            }

        }

        static AutoResetEvent wakeUpEvent;
      
        public class ExoThread
        {
            protected System.Diagnostics.PerformanceCounter cpuCounter;
            protected System.Diagnostics.PerformanceCounter ramCounter;

            Form1 ParentForm;
            
            Dictionary<string, object> toBeWritten = new Dictionary<string, object>();

            public ExoThread(Form1 myForm)
            {
                ParentForm = myForm;
            }

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            private class MEMORYSTATUSEX
            {
                public uint dwLength;
                public uint dwMemoryLoad;
                public ulong ullTotalPhys;
                public ulong ullAvailPhys;
                public ulong ullTotalPageFile;
                public ulong ullAvailPageFile;
                public ulong ullTotalVirtual;
                public ulong ullAvailVirtual;
                public ulong ullAvailExtendedVirtual;
                public MEMORYSTATUSEX()
                {
                    //this.dwLength = (uint)Marshal.SizeOf(typeof(NativeMethods.MEMORYSTATUSEX));
                    this.dwLength = (uint)Marshal.SizeOf(this);
                }
            }

            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);


            private void InitCpuMonitor()
            {
                cpuCounter = new System.Diagnostics.PerformanceCounter();
                cpuCounter.CategoryName = "Processor";
                cpuCounter.CounterName = "% Processor Time";
                cpuCounter.InstanceName = "_Total";

                ramCounter = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes");

            }

            public float getCurrentCpuUsage()
            {
                return cpuCounter.NextValue();
            }

            public float getAvailableRAM()
            {
                return ramCounter.NextValue();
            }
           
            int SyncExoPlatform()
            {
                int fRet = -1;                
                try
                {
                    Form1.AliasDict = Form1.onepConn.getAllAliasesInfo();
                }
                catch (OneException)
                {
                    GoodConnection = false;
                    return fRet;
                }
                //If a dataport doesn't exist on the Platform, create it
                for (int i = 0; i < appDataPorts.Length; i++)
                {
                    if (Form1.AliasDict.ContainsKey(appDataPorts[i].alias))
                        continue;
                    DataportDescription desc = new DataportDescription(appDataPorts[i].format);
                    desc.name = appDataPorts[i].name;
                    desc.retention.count = 725760;
                    desc.retention.duration = 8736;
                    desc.visibility = "public";
                    Dictionary<string, string> unit = new Dictionary<string, string>();
                    unit.Add("unit", appDataPorts[i].units);
                    string unitstr = JsonConvert.SerializeObject(unit);
                    Result res1, res2;
                    try
                    {
                        res1 = Form1.onepConn.create(appDataPorts[i].alias, desc);
                        res2 = Form1.onepConn.comment(appDataPorts[i].alias, "public", unitstr);
                    }
                    catch (OneException)
                    {
                        GoodConnection = false;
                        return fRet;
                    }
                    if (res1.message == "limit")
                    {
                        InfoMessageText = "Warning: Data Source Limit Met \r\n\"";
                        InfoMessageText += appDataPorts[i].name;
                        InfoMessageText += "\" was not created on platform";
                    }
                    if (res1.status != Result.OK || (res2.status != Result.OK))
                    {
                        return fRet;
                    }                 
                }

                foreach (string alias in Form1.AliasDict.Keys)                
                {
                    if (alias != messageBoxRID) { continue; }
                    Dictionary<string, object> option = new Dictionary<string, object>();
                    option.Add("comments", true);
                    try
                    {
                       Result res = Form1.onepConn.info(alias, option);
                       if (res.status == Result.OK)
                       {
                           Dictionary<string, object[][]> ru = JsonConvert.DeserializeObject<Dictionary<string, object[][]>>(res.message);
                           if (ru["comments"].Length == 0)
                           {
                               break;
                           }
                           Dictionary<string, string> cu = JsonConvert.DeserializeObject<Dictionary<string, string>>(ru["comments"][0][1].ToString());
                           msgUnits = cu["unit"];
                       }
                    }
                    catch (OneException)
                    {
                        GoodConnection = false;
                        return fRet;
                    }                  
                }
                GoodConnection = true;
                platformSync = true;
                fRet = 1;
                return fRet;             
            }
            public void checkWriteCPU()
            {
                if (getCPU)
                {
                    float cpuUsage = (float)Math.Round(getCurrentCpuUsage(), 2);
                    toBeWritten.Add("cpu", cpuUsage);
                } 
            }
            public void checkWriteMEM()
            {
                ulong installedMemory;

                MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
                if (getMEM)
                {
                    float availMem = getAvailableRAM();
                    float mem_used = 0;
                    if (GlobalMemoryStatusEx(memStatus))
                    {
                        installedMemory = memStatus.ullTotalPhys;
                        float installedMemoryMB = installedMemory / 1024 / 1024;
                        mem_used = installedMemoryMB - availMem;
                    }
                    toBeWritten.Add("mem", availMem);
                    toBeWritten.Add("memused", mem_used);
                } 

            }
            public void checkWritePower()
            {
                if (getPower)
                {
                    int batteryPercent;
                    String batteryState = "";

                    int powerPercent = (int)(power.BatteryLifePercent * 100);
                    if (powerPercent <= 100) batteryPercent = powerPercent; else batteryPercent = 0;
                    switch (power.PowerLineStatus)
                    {
                        case PowerLineStatus.Online:
                            batteryState = "AC Connected";
                            break;
                        case PowerLineStatus.Offline:
                            batteryState = "Battery: ";
                            batteryState += power.BatteryChargeStatus.ToString();
                            break;
                        case PowerLineStatus.Unknown:
                            batteryState = "Unknown";
                            break;
                    }
                    toBeWritten.Add("powerstate", batteryState);
                    toBeWritten.Add("batterypct", batteryPercent);
                }
            }
            public void checkWriteTriWave()
            {
                if (getTriWave)
                {
                    if (triWaveUp)
                        triWaveValue++;
                    else
                        triWaveValue--;

                    if (triWaveValue == 0)
                        triWaveUp = true;
                    if (triWaveValue == 100)
                        triWaveUp = false;
                    toBeWritten.Add("triwave", triWaveValue);
                } 
            }

            // This method will be called when the thread is started.
            public void DoWork()
            {
                InitCpuMonitor();            
                while (runThreads)
                {
                    if (!_shouldStop)
                    {
                        List<appDataPort> appDataToSend = new List<appDataPort>();
                        // 'appDataPorts' Used to check if dataports needed for this app exist on the Platform, if not to create

                        if (getCustom)
                        {
                            appDataToSend.Add(Form1.AppDataportsDict["sendvalue"]);
                        }
                        if (getCPU)
                            appDataToSend.Add(Form1.AppDataportsDict["cpu"]);
                        if (getMEM)
                        {
                            appDataToSend.Add(Form1.AppDataportsDict["memused"]);
                            appDataToSend.Add(Form1.AppDataportsDict["mem"]);
                        }
                        if (getTriWave)
                        {
                            appDataToSend.Add(Form1.AppDataportsDict["triwave"]);
                        }
                        if (getMessage)
                        {
                            //appDataToSend.Add(new appDataPort("Message Box", "message", "string", ""));
                        }
                        if (getPower)
                        {
                            appDataToSend.Add(Form1.AppDataportsDict["batterypct"]);
                            appDataToSend.Add(Form1.AppDataportsDict["powerstate"]);
                        }
                        int numDataPorts = appDataToSend.Count;
                        appDataPorts = new appDataPort[numDataPorts];
                        appDataPorts = appDataToSend.ToArray();

                        toBeWritten.Clear();
                        if (SyncExoPlatform() == 1 && platformSync)
                        {
                            checkWriteCPU();
                            checkWriteMEM();
                            checkWritePower();
                            checkWriteTriWave();                                                        
                            try
                            {
                                Form1.onepConn.write(toBeWritten);
                            }
                            catch(OneException)
                            {                               
                            }
                        }
                        Thread.Sleep(reportTime * 1000); //milliseconds to sleep
                    }
                    else
                    {
                        Console.WriteLine("worker thread: pausing...");
                        wakeUpEvent.WaitOne();
                    }
                }
                Console.WriteLine("worker thread: terminating gracefully.");
            }

            public void RequestStop()
            {
                _shouldStop = true;
            }

            public void RequestStart()
            {
                _shouldStop = false;
            }

            // Volatile is used as hint to the compiler that this data
            // member will be accessed by multiple threads.
            private volatile bool _shouldStop = true;
            private volatile bool runThreads = true;
        }

        System.Timers.Timer MessageBoxTimer;

        public class Test
        {
            public string Name;
        }

        public Form1()
        {
            InitializeComponent();

            AppDataportsDict.Add("sendvalue",new appDataPort("Sent Value", "sendvalue", "string", ""));
            AppDataportsDict.Add("cpu",new appDataPort("CPU Usage", "cpu", "float", "%"));
            AppDataportsDict.Add("memused",new appDataPort("Memory Used", "memused", "float", "MB"));
            AppDataportsDict.Add("mem",new appDataPort("Memory Available", "mem", "float", "MB"));
            AppDataportsDict.Add("triwave",new appDataPort("Tri Wave", "triwave", "integer", ""));
            AppDataportsDict.Add("batterypct", new appDataPort("Battery Remaining", "batterypct", "integer", "%"));
            AppDataportsDict.Add("powerstate", new appDataPort("Power State", "powerstate", "string", "state"));            

            linkLabel1.Text = "Click here to log-in to your account";
            linkLabel1.Links.Add(0, 0, "http://portals.exosite.com");

            string fileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
            //string DeploymentVersion =System.Deployment.Application.ApplicationDeployment.CurrentDeployment.ToString();

            versionlabel.Text = fileVersion;

            messageBoxDelegate = new ChangeMessageBoxText(SetMessageBox1);

            cikBox.Text = Properties.Settings.Default.myCIK;
            deviceCIK = cikBox.Text;            
            reportUpDown1.Value = 10;
            reportUpDown1.Minimum = 10; //10 seconds minimum
            reportTime = (int)reportUpDown1.Value;

            if (checkBox_CPU.Checked)
                getCPU = true;
            else
                getCPU = false;

            if (checkBox_MEM.Checked)
                getMEM = true;
            else
                getMEM = false;

            if (checkBox_triwave.Checked)
                getTriWave = true;
            else
                getTriWave = false;

            bool TestOk = false;
            try
            {
                Test test = new Test();
                test.Name = "Test1";
                string output = JsonConvert.SerializeObject(test);
                TestOk = true;
                Console.WriteLine("Looks like JSON dll is available, keep loading");
            }
            catch
            {
                Console.WriteLine("Doesn't look like JSON dll is available, can't run");
                TestOk = false;
                InfoMessageText = "NECESSARY DLLs are not available. Check\r\n that entire folder was unarchived\r\nand restart the app.";
            }

            MessageBoxTimer = new System.Timers.Timer();
            MessageBoxTimer.Interval = 1000;
            MessageBoxTimer.Elapsed += new
                ElapsedEventHandler(MessageBoxTimer_Elapsed);
            MessageBoxTimer.SynchronizingObject = this;                   

            // Create the thread object. This does not start the thread.
            ExositeThreadObject = new ExoThread(this);
            ExositeThread = new Thread(ExositeThreadObject.DoWork);
            wakeUpEvent = new AutoResetEvent(false);

           if (TestOk)
           {
                // Start the worker thread.
                ExositeThread.Start();
                // Loop until worker thread activates.
                while (!ExositeThread.IsAlive) ;

                Thread.Sleep(1);

            }
            MessageBoxTimer.Start();  //can start but can't run code until we have synchronized with platform
        }

        private void cikBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.myCIK = cikBox.Text;
            deviceCIK = cikBox.Text;           
            platformSync = false;
            if (InfoMessageText != null)
            {
                if (InfoMessageText.Contains("Warning: Check CIK or Network Connection"))
                {
                    clearinfo_button.PerformClick();

                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!running)  //if not running
            {
                if (cikBox.Text.Length == 40)
                {
                   Properties.Settings.Default.Save();
                   try
                   {
                       onepConn = new ClientOnepV1("http://m2.exosite.com/api:v1/rpc/process", 3, deviceCIK);
                   }catch(OneException){
                       cikBox.Text = "invalid CIK, enter again";
                       return;
                   }
                }
                else
                {
                    cikBox.Text = "invalid CIK, enter again";                   
                    return;
                }
                //ok let's try to start running the emulator
                // Start the worker thread.

                ExositeThreadObject.RequestStart();
                wakeUpEvent.Set();
                Console.WriteLine("main thread: Starting exosite thread...");
                textBox2.Text = "Running";
                textBox2.BackColor = Color.PaleGreen;
                connectButton.Text = "Stop";
                running = true;
                cikBox.Enabled = false;
                MessageBoxTimer.Start();
                
                label7.Enabled = true;
                if (getCustom)
                {
                    label2.Enabled = true;
                    send_button.Enabled = true;
                    sendValue_Box.Enabled = true;
                }
                messageListbox.Enabled = true;
                MessageBox1.Enabled = true;

                if (InfoMessageText != null)
                {
                    if (InfoMessageText.Contains("Warning: Check CIK or Network Connection"))
                    {
                        clearinfo_button.PerformClick();

                    }
                }
            }
            else //if currently running
            {
                // Request that the worker thread stop itself:
                ExositeThreadObject.RequestStop();
                Console.WriteLine("main thread: Pausing exosite thread...");

                textBox2.Text = "Not Running";
                textBox2.BackColor = Color.Salmon;
                connectButton.Text = "Start";
                MessageBox1.Text = "";
                running = false;
                MessageBoxTimer.Stop();
                label2.Enabled = false;
                sendValue_Box.Enabled = false;
                label7.Enabled = false;
                MessageBox1.Enabled = false;
                messageListbox.Enabled = false;
                send_button.Enabled = false;
                cikBox.Enabled = true;
                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Exiting");

            Thread.Sleep(1);
            ExositeThread.Abort();

            ExositeThread.Join();
        }

        private void checkBox_CPU_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_CPU.Checked)
                getCPU = true;
            else
                getCPU = false;
        }

        private void checkBox_MEM_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_MEM.Checked)
                getMEM = true;
            else
                getMEM = false;
        }

        private void sendValue_Box_TextChanged(object sender, EventArgs e)
        {
            sendValue = sendValue_Box.Text;


        }
        private void sendValue_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                send_button.PerformClick();
            }
            //if (e.KeyCode == Keys.Tab)
            //{
            //   send_button.Focus();
            //    connectButton.Select();
            //}
        }

        private void cikBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                connectButton.PerformClick();
            }
            //if (e.KeyCode == Keys.Tab)
            //{
            //    connectButton.Focus();
            //}
        }

        private void send_button_Click(object sender, EventArgs e)
        {
            send_button.Enabled = false;
            sendValue = sendValue_Box.Text;
            if (platformSync && running)
            {
                onepConn.write("sendvalue", sendValue);                    
                sendValue_Box.Text = "";
                send_button.Enabled = true;
            }
        }

        private void reportUpDown1_ValueChanged(object sender, EventArgs e)
        {
            reportTime = (int)reportUpDown1.Value;
        }

        private void checkBox_triwave_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_triwave.Checked)
                getTriWave = true;
            else
                getTriWave = false;
        }

        private void checkBox_power_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_power.Checked)
                getPower = true;
            else
                getPower = false;
        }

        private void custom_checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (custom_checkBox1.Checked)
            {
                getCustom = true;
                if (running == true)
                {
                    label2.Enabled = true;
                    send_button.Enabled = true;
                    sendValue_Box.Enabled = true;
                }
            }
            else
            {
                getCustom = false;
                label2.Enabled = false;
                send_button.Enabled = false;
                sendValue_Box.Enabled = false;
            }

        }

        private void MessageBoxTimer_Elapsed(object sender,
            System.Timers.ElapsedEventArgs e)
        {

            if (platformSync && running)
            {
                try
                {
                    //messageListbox.Items.Clear();
                    foreach(string alias in Form1.AliasDict.Keys)                   
                    {
                        int result = messageListbox.FindStringExact(alias);
                        if (result < 0)
                        {
                           messageListbox.Items.Add(alias);
                        }
                    }
                    // Now see what items we should remove from the list from sync'd list of client data ports
                    foreach (String item in messageListbox.Items)
                    {
                        if (Form1.AliasDict.ContainsKey(item))
                            continue;
                        messageListbox.Items.Remove(item);                        
                    }
                    if (getMessage)
                    {
                        if (messageBoxRID != null)
                        {
                            try
                            {
                                Result res = onepConn.read(messageBoxRID);
                                if (res.status == Result.OK)
                                {
                                    object[][] read = JsonConvert.DeserializeObject<object[][]>(res.message);
                                    TextForMessageBox = read[0][1].ToString();                                   
                                }
                            }
                            catch (OneException)
                            {
                                TextForMessageBox = "";                                
                            }
                            finally
                            {
                                this.Invoke(this.messageBoxDelegate);
                            }                           
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Error, but should be able to keep running");

                }
            }

            if (InfoMessageText != null)
            {
                warninginfo.Text = InfoMessageText;
                warninginfo.Visible = true;
                clearinfo_button.Visible = true;
                clearinfo_button.Enabled = true;
            }

            if (!GoodConnection)
            {
                InfoMessageText = "Warning: Check CIK or Network Connection";
                textBox2.Text = "Connection Problem?";
                textBox2.BackColor = Color.LightGoldenrodYellow;
                //send_button.Enabled = false;
                numBadConnections++;
                if (numBadConnections == 10)
                {
                    connectButton.PerformClick();
                    numBadConnections = 0;
                }
            }
            else
            {
                numBadConnections = 0;
                if (running)
                {
                    textBox2.Text = "Running";
                    textBox2.BackColor = Color.PaleGreen;
                }
            }

            //MessageBox1.Text = TextForMessageBox;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void clearinfo_button_Click(object sender, EventArgs e)
        {
            warninginfo.Visible = false;
            warninginfo.Text = "";
            InfoMessageText = null;
            clearinfo_button.Visible = false;
            clearinfo_button.Enabled = false;
        }

        private void messageListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            msgUnits = "";
            messageBoxRID = (string)messageListbox.SelectedItem.ToString();
        }
    }
}