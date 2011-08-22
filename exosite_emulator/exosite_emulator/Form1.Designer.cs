namespace Exosite_Emulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.connectButton = new System.Windows.Forms.Button();
            this.cikBox = new System.Windows.Forms.TextBox();
            this.checkBox_CPU = new System.Windows.Forms.CheckBox();
            this.checkBox_MEM = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sendValue_Box = new System.Windows.Forms.TextBox();
            this.send_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox_triwave = new System.Windows.Forms.CheckBox();
            this.reportUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.versionlabel = new System.Windows.Forms.Label();
            this.MessageBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_power = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.warninginfo = new System.Windows.Forms.Label();
            this.clearinfo_button = new System.Windows.Forms.Button();
            this.messageListbox = new System.Windows.Forms.ComboBox();
            this.custom_checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.reportUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(197, 72);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Start";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // cikBox
            // 
            this.cikBox.BackColor = System.Drawing.Color.White;
            this.cikBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cikBox.Location = new System.Drawing.Point(16, 37);
            this.cikBox.Name = "cikBox";
            this.cikBox.Size = new System.Drawing.Size(260, 20);
            this.cikBox.TabIndex = 0;
            this.cikBox.Text = "Enter CIK Here";
            this.cikBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cikBox.WordWrap = false;
            this.cikBox.TextChanged += new System.EventHandler(this.cikBox_TextChanged);
            this.cikBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cikBox_KeyDown);
            // 
            // checkBox_CPU
            // 
            this.checkBox_CPU.AutoSize = true;
            this.checkBox_CPU.Checked = true;
            this.checkBox_CPU.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_CPU.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_CPU.Location = new System.Drawing.Point(11, 167);
            this.checkBox_CPU.Name = "checkBox_CPU";
            this.checkBox_CPU.Size = new System.Drawing.Size(84, 18);
            this.checkBox_CPU.TabIndex = 4;
            this.checkBox_CPU.Text = "CPU Activity";
            this.checkBox_CPU.UseVisualStyleBackColor = true;
            this.checkBox_CPU.CheckedChanged += new System.EventHandler(this.checkBox_CPU_CheckedChanged);
            // 
            // checkBox_MEM
            // 
            this.checkBox_MEM.AutoSize = true;
            this.checkBox_MEM.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_MEM.Location = new System.Drawing.Point(11, 191);
            this.checkBox_MEM.Name = "checkBox_MEM";
            this.checkBox_MEM.Size = new System.Drawing.Size(98, 18);
            this.checkBox_MEM.TabIndex = 5;
            this.checkBox_MEM.Text = "Memory Usage";
            this.checkBox_MEM.UseVisualStyleBackColor = true;
            this.checkBox_MEM.CheckedChanged += new System.EventHandler(this.checkBox_MEM_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data to send";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sendValue_Box
            // 
            this.sendValue_Box.BackColor = System.Drawing.Color.White;
            this.sendValue_Box.Enabled = false;
            this.sendValue_Box.Location = new System.Drawing.Point(12, 276);
            this.sendValue_Box.Name = "sendValue_Box";
            this.sendValue_Box.Size = new System.Drawing.Size(168, 20);
            this.sendValue_Box.TabIndex = 7;
            this.sendValue_Box.TextChanged += new System.EventHandler(this.sendValue_Box_TextChanged);
            this.sendValue_Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sendValue_Box_KeyDown);
            // 
            // send_button
            // 
            this.send_button.Enabled = false;
            this.send_button.Location = new System.Drawing.Point(197, 276);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(75, 23);
            this.send_button.TabIndex = 8;
            this.send_button.Text = "Send";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Send a Value";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Device Client Simulator";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LightSalmon;
            this.textBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(12, 73);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(124, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Not Running";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.WordWrap = false;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // checkBox_triwave
            // 
            this.checkBox_triwave.AutoSize = true;
            this.checkBox_triwave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_triwave.Location = new System.Drawing.Point(144, 191);
            this.checkBox_triwave.Name = "checkBox_triwave";
            this.checkBox_triwave.Size = new System.Drawing.Size(95, 18);
            this.checkBox_triwave.TabIndex = 6;
            this.checkBox_triwave.Text = "Triangle Wave";
            this.checkBox_triwave.UseVisualStyleBackColor = true;
            this.checkBox_triwave.CheckedChanged += new System.EventHandler(this.checkBox_triwave_CheckedChanged);
            // 
            // reportUpDown1
            // 
            this.reportUpDown1.Location = new System.Drawing.Point(145, 106);
            this.reportUpDown1.Name = "reportUpDown1";
            this.reportUpDown1.Size = new System.Drawing.Size(50, 20);
            this.reportUpDown1.TabIndex = 3;
            this.reportUpDown1.ValueChanged += new System.EventHandler(this.reportUpDown1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Report Speed";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "seconds";
            // 
            // versionlabel
            // 
            this.versionlabel.AutoSize = true;
            this.versionlabel.Location = new System.Drawing.Point(212, 10);
            this.versionlabel.Name = "versionlabel";
            this.versionlabel.Size = new System.Drawing.Size(41, 13);
            this.versionlabel.TabIndex = 17;
            this.versionlabel.Text = "version";
            // 
            // MessageBox1
            // 
            this.MessageBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MessageBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MessageBox1.Enabled = false;
            this.MessageBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageBox1.Location = new System.Drawing.Point(11, 367);
            this.MessageBox1.Name = "MessageBox1";
            this.MessageBox1.ReadOnly = true;
            this.MessageBox1.Size = new System.Drawing.Size(261, 26);
            this.MessageBox1.TabIndex = 18;
            this.MessageBox1.TabStop = false;
            this.MessageBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "Message Box";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 30000;
            this.toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.Help;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(93, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "info";
            this.toolTip1.SetToolTip(this.label8, "Data entered and sent in the \'Send a Value\' box will be sent to \r\nthe Exosite pla" +
                    "tform as a data source, called \"Sent Value\" (alias sendvalue).");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Cursor = System.Windows.Forms.Cursors.Help;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(93, 338);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "info";
            this.toolTip1.SetToolTip(this.label9, resources.GetString("label9.ToolTip"));
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Cursor = System.Windows.Forms.Cursors.Help;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(97, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "info";
            this.toolTip1.SetToolTip(this.label10, "This is the report period that this emulator application will \r\nsend data to the " +
                    "Exosite platform.  Minimum is 10 seconds.");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Cursor = System.Windows.Forms.Cursors.Help;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(142, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = "info";
            this.toolTip1.SetToolTip(this.label11, resources.GetString("label11.ToolTip"));
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Help;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(87, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "info";
            this.toolTip1.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // checkBox_power
            // 
            this.checkBox_power.AutoSize = true;
            this.checkBox_power.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_power.Location = new System.Drawing.Point(144, 167);
            this.checkBox_power.Name = "checkBox_power";
            this.checkBox_power.Size = new System.Drawing.Size(102, 18);
            this.checkBox_power.TabIndex = 24;
            this.checkBox_power.Text = "Battery / Power";
            this.checkBox_power.UseVisualStyleBackColor = true;
            this.checkBox_power.CheckedChanged += new System.EventHandler(this.checkBox_power_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(4, 477);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(272, 13);
            this.linkLabel1.TabIndex = 25;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "log-in";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // warninginfo
            // 
            this.warninginfo.BackColor = System.Drawing.Color.Transparent;
            this.warninginfo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warninginfo.ForeColor = System.Drawing.Color.Firebrick;
            this.warninginfo.Location = new System.Drawing.Point(33, 419);
            this.warninginfo.Name = "warninginfo";
            this.warninginfo.Size = new System.Drawing.Size(239, 49);
            this.warninginfo.TabIndex = 26;
            this.warninginfo.Text = "warning info text";
            this.warninginfo.Visible = false;
            // 
            // clearinfo_button
            // 
            this.clearinfo_button.BackColor = System.Drawing.Color.Transparent;
            this.clearinfo_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.clearinfo_button.Enabled = false;
            this.clearinfo_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.clearinfo_button.FlatAppearance.BorderSize = 0;
            this.clearinfo_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.clearinfo_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.clearinfo_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearinfo_button.ForeColor = System.Drawing.Color.Firebrick;
            this.clearinfo_button.Location = new System.Drawing.Point(12, 415);
            this.clearinfo_button.Name = "clearinfo_button";
            this.clearinfo_button.Size = new System.Drawing.Size(260, 28);
            this.clearinfo_button.TabIndex = 27;
            this.clearinfo_button.Text = "X";
            this.clearinfo_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clearinfo_button.UseVisualStyleBackColor = false;
            this.clearinfo_button.Visible = false;
            this.clearinfo_button.Click += new System.EventHandler(this.clearinfo_button_Click);
            // 
            // messageListbox
            // 
            this.messageListbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.messageListbox.Enabled = false;
            this.messageListbox.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageListbox.FormattingEnabled = true;
            this.messageListbox.Location = new System.Drawing.Point(126, 336);
            this.messageListbox.Name = "messageListbox";
            this.messageListbox.Size = new System.Drawing.Size(146, 23);
            this.messageListbox.TabIndex = 29;
            this.messageListbox.SelectedIndexChanged += new System.EventHandler(this.messageListbox_SelectedIndexChanged);
            // 
            // custom_checkBox1
            // 
            this.custom_checkBox1.AutoSize = true;
            this.custom_checkBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custom_checkBox1.Location = new System.Drawing.Point(12, 215);
            this.custom_checkBox1.Name = "custom_checkBox1";
            this.custom_checkBox1.Size = new System.Drawing.Size(136, 18);
            this.custom_checkBox1.TabIndex = 30;
            this.custom_checkBox1.Text = "Custom: \'Send a Value\'";
            this.custom_checkBox1.UseVisualStyleBackColor = true;
            this.custom_checkBox1.CheckedChanged += new System.EventHandler(this.custom_checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(284, 499);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.custom_checkBox1);
            this.Controls.Add(this.messageListbox);
            this.Controls.Add(this.warninginfo);
            this.Controls.Add(this.clearinfo_button);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.checkBox_power);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.MessageBox1);
            this.Controls.Add(this.versionlabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.reportUpDown1);
            this.Controls.Add(this.checkBox_triwave);
            this.Controls.Add(this.sendValue_Box);
            this.Controls.Add(this.cikBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.send_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_MEM);
            this.Controls.Add(this.checkBox_CPU);
            this.Controls.Add(this.connectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Exosite Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.reportUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox cikBox;
        private System.Windows.Forms.CheckBox checkBox_CPU;
        private System.Windows.Forms.CheckBox checkBox_MEM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sendValue_Box;
        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox_triwave;
        private System.Windows.Forms.NumericUpDown reportUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label versionlabel;
        private System.Windows.Forms.TextBox MessageBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox_power;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label warninginfo;
        private System.Windows.Forms.Button clearinfo_button;
        private System.Windows.Forms.ComboBox messageListbox;
        private System.Windows.Forms.CheckBox custom_checkBox1;
        private System.Windows.Forms.Label label4;

    }
}

