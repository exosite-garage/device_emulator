========================================
About device_emulator
========================================
The Exosite device_emulator is a .NET application that sends and receives data 
to/from the cloud via Exosite's Cloud Data Platform.  It "emulates" 
functionality that an simple device could implement, and allows users and 
developers to quickly try out Exosite's technologies.  It also servers as an 
example for interacting with Exosite's API using the HTTP JSON RPC interface 
(uses clronep library -> https://github.com/exosite-labs/clronep).

Uses Microsoft .NET Framework 3.5 or later.

License is BSD, Copyright 2011, Exosite LLC (see LICENSE file)

========================================
Quick Start
========================================
Tested with Visual Studio 2010 (Windows).

For more information on the API and examples, reference Exosite online 
documentation at http://exosite.com/developers/documentation.

(1) The unzipped folder contains the emulator application (exosite_emulator.exe) 
and this readme.txt file.  

IMPORTANT: The included files (.dll's, etc) much be kept within same folder 
as the exosite_emulator.exe


(2) Run the application (exosite_emulator.exe). Notice when it runs that it 
says 'Not Running'in the status box.

IMPORTANT: If you do not already have Microsoft .NET Framework 4.0, it will ask 
to install this.


(3) Get a device CIK from your Exosite account.  Go to your Exosite account in 
Portals (https://portals.exosite.com) and add a new device using the following 
information:

	Device Type: Generic
	Device Timezone: ---> Select your timezone
	Device Location: ---> Provide any descriptive location
	Device Name: ---> Any name you want to provide

For documentation on adding a new device: 
http://exosite.com/developers/documentation?cid=1009


(4) Fill in the Device CIK field on the emulator and hit the 'Start' button.  
Note: The Device CIK will be saved next time you run the emulator.


(5) Exosite Portals should see the data coming in, by default the only data 
source sent is 'CPU Usage'.


(6) To send Memory info, Power info,  or a Triangle Wave data, check the 
appropriate check box(s).


(7) To send a value of your own, fill in the 'Send a Value' box and hit 'Send'

(8) The 'Message Box' includes a drop-down menu for selecting data sources (dataports)
that exist for the client on the Platform.  The Message Box window will show the 
last value for the selected data source.

----------------------------------------
Data Sources created by this application:
----------------------------------------
CPU Usage :: CPU activity percentage (%)<br>
Memory Used :: PC RAM Memory used (MB)<br>
Memory Available :: PC RAM Memory available (MB)<br>
Tri Wave :: Triangle wave (0 - 100)<br>
Power State :: AC or Battery status (state)<br>
Battery Remaining :: Battery current charge remaining (%)<br>
Sent Value :: Values sent from User Interface control<br>

========================================
Release History
========================================
----------------------------------------
1.0.5 (8/22/2011)
----------------------------------------
--) Now using clronep helper library for JSON RPC API bindings<br>
--) Updating readme<br>

----------------------------------------
1.0.4 (5/24/2011)
----------------------------------------
--) Added dataport retention control:<br>
* Note: Defautls to 2 weeks of data point storage if sent every 10 seconds<br>
* Note: Stores data for up to a year<br>

----------------------------------------
1.0.3
----------------------------------------
--) Add "units" capability when creating new dataports<br>
--) Fixed exception due to network failure<br>

----------------------------------------
1.0.2
----------------------------------------
--) Fixed exception when creating new dataports on platform<br>
--) Added better description in info message if data source limit met/exceeded<br>

----------------------------------------
1.0.1
----------------------------------------
--) Added ability to automaticlaly add data sources to the Platform<br>
--) Added message box, triangle wave, pc power/battery data sources<br>
--) Add 'Help' tooltip<br>
--) Add Report speed control (min is 10 seconds)<br>

----------------------------------------
1.0.0
----------------------------------------
--) initial release<br>

----------------------------------------
