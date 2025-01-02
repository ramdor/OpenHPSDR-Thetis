/*
*
* Copyright (C) 2006 Bill Tracey, KD5TFD, bill@ewjt.com 
* Copyright (C) 2010-2020  Doug Wigley
* 
* This program is free software; you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation; either version 2 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program; if not, write to the Free Software
* Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/

namespace Thetis
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Net.NetworkInformation;
    using SharpDX.Direct2D1;
    using System.Diagnostics;
    using System.Reflection;
    using System.Windows.Forms;

    partial class NetworkIO
    {
        public NetworkIO()
        {
        }


        public static bool isFirmwareLoaded = false;

        private static float swr_protect = 1.0f;
        public static float SWRProtect
        {
            get { return swr_protect; }
            set { swr_protect = value; }
        }

        public static void SetOutputPower(float f)
        {
            if (f < 0.0)
            {
                f = 0.0F;
            }
            if (f >= 1.0)
            {
                f = 1.0F;
            }

            int i = (int)(255 * f * swr_protect);
            //System.Console.WriteLine("output power i: " + i); 
            SetOutputPowerFactor(i);
        }

         // get the name of this PC and, using it, the IP address of the first adapter
        //static string strHostName = Dns.GetHostName();
        // public static IPAddress[] addr = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
        // get a socket to send and receive on
        static Socket socket; // = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        // set an endpoint
        static IPEndPoint iep;
        static byte[] data = new byte[1444];
        public static int DiscoveryPort { get; set; } = 1024;   // MI0BOT: Allows the discover port to be changed
        const int LocalPort = 0;
        public static bool enableStaticIP { get; set; } = false;
        public static bool enableLimitSubnet { get; set; } = true; // MI0BOT Flag to control limiting to subnet for discovery 
        public static uint static_host_network { get; set; } = 0;
        public static bool FastConnect { get; set; } = false;
        public static HPSDRHW BoardID { get; set; } = HPSDRHW.Hermes;
        public static byte FWCodeVersion { get; set; } = 0;
  		public static byte FWCodeVersionMinor { get; set; } = 0; // MI0BOT: Minor revision for Hermes Lite
        public static byte BetaVersion { get; set; } = 0;
        public static byte ProtocolSupported { get; set; } = 0;        
        public static string EthernetHostIPAddress { get; set; } = "";
        public static int EthernetHostPort { get; set; } = 0;
        public static int EthernetRemotePort { get; set; } = 0; // MI0BOT: Remote port for WAN access to allow for several HL2s
        public static string HpSdrHwIpAddress { get; set; } = "";
        public static string HpSdrHwMacAddress { get; set; } = "";
        public static byte NumRxs { get; set; } = 0;
        public static RadioProtocol CurrentRadioProtocol { get; set; } = RadioProtocol.ETH;
        public static RadioProtocol RadioProtocolSelected { get; set; } = RadioProtocol.ETH;

        private const int IP_SUCCESS = 0;
        private const short VERSION = 0x202;//2;  //MW0LGE_22b
        public static int initRadio()
        {
            int rc;
           // System.Console.WriteLine("Static IP: " + Console.getConsole().HPSDRNetworkIPAddr);
            int adapterIndex = adapterSelected - 1;
            IPAddress[] addr = null;
            bool cleanup = false;

            try
            {
                addr = Dns.GetHostAddresses(Dns.GetHostName());
            }
            catch (SocketException e)
            {
                Win32.WSAData data = new Win32.WSAData();
                int result = 0;

                result = Win32.WSAStartup(VERSION, out data);
                if (result != IP_SUCCESS)
                {
                    System.Console.WriteLine(data.description);
                    Win32.WSACleanup();
                }

                addr = Dns.GetHostAddresses(Dns.GetHostName());
                cleanup = true;
                // System.Console.WriteLine("SocketException caught!!!");
                // System.Console.WriteLine("Source : " + e.Source);
                // System.Console.WriteLine("Message : " + e.Message);           
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Exception caught!!!");
                System.Console.WriteLine("Source : " + e.Source);
                System.Console.WriteLine("Message : " + e.Message);
            }

            GetNetworkInterfaces();

            List<IPAddress> addrList = new List<IPAddress>();

            // make a list of all the adapters that we found in Dns.GetHostEntry(strHostName).AddressList
            foreach (IPAddress a in addr)
            {
                // make sure to get only IPV4 addresses!
                // test added because Erik Anderson noted an issue on Windows 7.  May have been in the socket
                // construction or binding below.
                if (a.AddressFamily == AddressFamily.InterNetwork)
                {
                    addrList.Add(a);
                }
            }

            bool foundRadio = false;
            List<HPSDRDevice> hpsdrd = new List<HPSDRDevice>();

            if (enableStaticIP)
            {
                HpSdrHwIpAddress = Console.getConsole().HPSDRNetworkIPAddr;

                IPAddress[] remoteIp = null;

                // MI0BOT: Using call to get IP address which will work with dot addresses and URLs
                // MI0BOT: Needed message box to report unknown host

                try
                {
                    remoteIp = Dns.GetHostAddresses(HpSdrHwIpAddress);
                }
                catch (Exception)
                {
                    DialogResult dr = MessageBox.Show("Unknown host: " + HpSdrHwIpAddress,
                        "IP Address error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Common.MB_TOPMOST);

                    return -1;
                }

                HpSdrHwIpAddress = remoteIp[0].ToString();

                IPEndPoint remoteEndPoint = new IPEndPoint(remoteIp[0], 0);
                Socket sock = new Socket(
                                      AddressFamily.InterNetwork,
                                      SocketType.Dgram,
                                      ProtocolType.Udp);
                IPEndPoint localEndPoint = QueryRoutingInterface(sock, remoteEndPoint);
                if (localEndPoint != null) //[2.10.3.7]MW0LGE null check added, and changed to tryparse
                {
                    if (IPAddress.TryParse(localEndPoint.Address.ToString(), out IPAddress ep_ip))
                    {
                        EthernetHostIPAddress = ep_ip.ToString();
                    }
                }

                sock.Close();
                sock = null;

                // if success set foundRadio to true, and fill in ONE hpsdrd entry.
                IPAddress targetIP;
                IPAddress hostIP;
                if (IPAddress.TryParse(EthernetHostIPAddress, out hostIP) && IPAddress.TryParse(HpSdrHwIpAddress, out targetIP))
                {
                    System.Console.WriteLine(String.Format("Attempting connect to host adapter {0}, Static IP {1}", EthernetHostIPAddress, HpSdrHwIpAddress));

                    if (DiscoverRadioOnPort(ref hpsdrd, hostIP, targetIP))
                    {
                        foundRadio = true;

                        // make sure that there is only one entry in the list!
                        if (hpsdrd.Count > 0)
                        {
                            // remove the extra ones that don't match!
                            HPSDRDevice m2 = null;
                            foreach (var m in hpsdrd)
                            {
                                if (m.IPAddress.CompareTo(HpSdrHwIpAddress) == 0)
                                {
                                    m2 = m;
                                }
                            }

                            // clear the list and put our single element in it, if we found it.
                            hpsdrd.Clear();
                            if (m2 != null)
                            {
                                hpsdrd.Add(m2);
                            }
                            else
                            {
                                foundRadio = false;
                            }
                        }
                    }
                }
            }

            if (FastConnect && (EthernetHostIPAddress.Length > 0) && (HpSdrHwIpAddress.Length > 0))
            {
                // if success set foundRadio to true, and fill in ONE hpsdrd entry.
                IPAddress targetIP;
                IPAddress hostIP;
                if (IPAddress.TryParse(EthernetHostIPAddress, out hostIP) && IPAddress.TryParse(HpSdrHwIpAddress, out targetIP))
                {
                    System.Console.WriteLine(String.Format("Attempting fast re-connect to host adapter {0}, IP {1}", EthernetHostIPAddress, HpSdrHwIpAddress));

                    if (DiscoverRadioOnPort(ref hpsdrd, hostIP, targetIP))
                    {
                        foundRadio = true;

                        // make sure that there is only one entry in the list!
                        if (hpsdrd.Count > 0)
                        {
                            // remove the extra ones that don't match!
                            HPSDRDevice m2 = null;
                            foreach (var m in hpsdrd)
                            {
                                if (m.IPAddress.CompareTo(HpSdrHwIpAddress) == 0)
                                {
                                    m2 = m;
                                }
                            }

                            // clear the list and put our single element in it, if we found it.
                            hpsdrd.Clear();
                            if (m2 != null)
                            {
                                hpsdrd.Add(m2);
                            }
                            else
                            {
                                foundRadio = false;
                            }
                        }
                    }
                }
            }

            if (!foundRadio)
            {
                foreach (IPAddress ipa in addrList)
                {
                    if (DiscoverRadioOnPort(ref hpsdrd, ipa, null))
                    {
                        foundRadio = true;
                    }
                }
            }

            if (!foundRadio)
            {
                if (cleanup)
                    Win32.WSACleanup();
                return -1;
            }

            int chosenDevice = 0;
            BoardID = hpsdrd[chosenDevice].deviceType;
            FWCodeVersion = hpsdrd[chosenDevice].codeVersion;
            FWCodeVersionMinor = hpsdrd[chosenDevice].codeVersionMinor; //MI0BOT: Minor revision for Hermes Lite
            BetaVersion = hpsdrd[chosenDevice].betaVersion;
            ProtocolSupported = hpsdrd[chosenDevice].protocolSupported;
            HpSdrHwIpAddress = hpsdrd[chosenDevice].IPAddress;
            HpSdrHwMacAddress = hpsdrd[chosenDevice].MACAddress;
            EthernetHostIPAddress = hpsdrd[chosenDevice].hostPortIPAddress.ToString();
            EthernetHostPort = hpsdrd[chosenDevice].localPort;
            EthernetRemotePort = hpsdrd[chosenDevice].remotePort;
            NumRxs = hpsdrd[chosenDevice].numRxs;

            if (BoardID == HPSDRHW.HermesII)
            {
                if (FWCodeVersion < 103)
                {
                    fwVersionMsg = "Invalid Firmware!\nRequires 10.3 or greater. ";
                    return -101;                                                                                       
                }
            }

            rc = nativeInitMetis(HpSdrHwIpAddress, EthernetHostIPAddress, EthernetHostPort, (int)CurrentRadioProtocol, EthernetRemotePort);
            return -rc;
        }

        public static bool fwVersionsChecked = false;
        private static string fwVersionMsg = null;

        public static string getFWVersionErrorMsg()
        {
            return fwVersionMsg;
        }

        public static bool forceFWGood = false;

        private static bool legacyDotDashPTT = false;

        // checks if the firmware versions are consistent - returns false if they are not 
        // and set fwVersionmsg to point to an appropriate message
        private static bool fwVersionsGood()
        {
            return true;
        }

        // returns -101 for firmware version error 
        unsafe public static int StartAudio()
        {
            if (initRadio() != 0)
            {
                return 1;
            }

            int result = StartAudioNative();

            if (result == 0 && !fwVersionsChecked)
            {
                if (!fwVersionsGood())
                {
                    result = -101;
                }
                else
                {
                    fwVersionsChecked = true;
                }
            }

            return result;
        }

         unsafe public static int GetDotDashPTT()
        {
            int bits = nativeGetDotDashPTT();
            if (legacyDotDashPTT)  // old style dot and ptt overloaded on 0x1 bit, new style dot on 0x4, ptt on 0x1 
            {
                if ((bits & 0x1) != 0)
                {
                    bits |= 0x4;
                }
            }
            return bits;
        }

        private static double freq_correction_factor = 1.0;
        public static double FreqCorrectionFactor
        {
            get { return freq_correction_factor; }
            set
            {
                freq_correction_factor = value;
                freqCorrectionChanged();
            }
        }

        public static void freqCorrectionChanged()
        {
            if (!Console.FreqCalibrationRunning)    // we can't be applying freq correction when cal is running 
            {
                VFOfreq(0, lastVFOfreq[0][0], 0);
                VFOfreq(1, lastVFOfreq[0][1], 0);
                VFOfreq(2, lastVFOfreq[0][2], 0);
                VFOfreq(3, lastVFOfreq[0][3], 0);
                VFOfreq(0, lastVFOfreq[1][0], 1);
            }
        }

        private static double[][] lastVFOfreq = new double[2][] { new double[] { 0.0, 0.0, 0.0, 0.0 }, new double[] { 0.0 } };
        unsafe public static void VFOfreq(int id, double f, int tx)
        {
            lastVFOfreq[tx][id] = f;
            int f_freq;
            f_freq = (int)((f * 1e6) * freq_correction_factor);
            if (f_freq >= 0)
                if(CurrentRadioProtocol == RadioProtocol.USB)
                   SetVFOfreq(id, f_freq, tx);                  // sending freq Hz to firmware
                   else SetVFOfreq(id, Freq2PW(f_freq), tx);   // sending phaseword to firmware
        }

        public static int Freq2PW(int freq)                     // freq to phaseword conversion
        {
            long pw = (long)Math.Pow(2, 32) * freq / 122880000;
            return (int)pw;
        }

        private static double low_freq_offset;
        public static double LowFreqOffset
        {
            get { return low_freq_offset; }
            set
            {
                low_freq_offset = value;
            }
        }

        private static double high_freq_offset;
        public static double HighFreqOffset
        {
            get { return high_freq_offset; }
            set
            {
                high_freq_offset = value;
            }
        }
     
        // Taken from: KISS Konsole
        public static List<NetworkInterface> foundNics = new List<NetworkInterface>();
        public static List<NicProperties> nicProperties = new List<NicProperties>();
        public static string numberOfIPAdapters;
        public static string Network_interfaces = null;  // holds a list with the description of each Network Adapter
        public static int adapterSelected = 1;           // from Setup form, the number of the Network Adapter to use

        public static void GetNetworkInterfaces()
        {
            // creat a string that contains the name and speed of each Network adapter 
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            foundNics.Clear();
            nicProperties.Clear();

            Network_interfaces = "";
            int adapterNumber = 1;

            foreach (var netInterface in nics)
            {
                if ((netInterface.OperationalStatus == OperationalStatus.Up ||
                     netInterface.OperationalStatus == OperationalStatus.Unknown) &&
                    (netInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                 netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet))
                {
                    foreach (var addrInfo in netInterface.GetIPProperties().UnicastAddresses)
                    {
                        if (addrInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            NicProperties np = new NicProperties();
                            np.ipv4Address = addrInfo.Address;
                            np.ipv4Mask = addrInfo.IPv4Mask;
                            nicProperties.Add(np);
                        }
                    }
                }

                // if the length of the network adapter name is > 31 characters then trim it, if shorter then pad to 31.
                // Need to use fixed width font - Courier New
                string speed = "  " + (netInterface.Speed / 1000000).ToString() + "T";
                if (netInterface.Description.Length > 31)
                {
                    Network_interfaces += adapterNumber++.ToString() + ". " + netInterface.Description.Remove(31) + speed + "\n";
                }
                else
                {
                    Network_interfaces += adapterNumber++.ToString() + ". " + netInterface.Description.PadRight(31, ' ') + speed + "\n";
                }

                foundNics.Add(netInterface);
            }

 
            System.Console.WriteLine(Network_interfaces);

            // display number of adapters on Setup form
            numberOfIPAdapters = (adapterNumber - 1).ToString();
        }

        private static bool DiscoverRadioOnPort(ref List<HPSDRDevice> hpsdrdList, IPAddress HostIP, IPAddress targetIP)
        {
            bool result = false;

            // configure a new socket object for each Ethernet port we're scanning
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            // Listen to data on this PC's IP address. Allow the program to allocate a free port.
            iep = new IPEndPoint(HostIP, LocalPort);  // was iep = new IPEndPoint(ipa, 0);

            try
            {
                // bind to socket and Port
                socket.Bind(iep);
                //   socket.ReceiveBufferSize = 0xFFFFF;   // no lost frame counts at 192kHz with this setting
                socket.Blocking = true;

                IPEndPoint localEndPoint = (IPEndPoint)socket.LocalEndPoint;
                System.Console.WriteLine("Looking for radio using host adapter IP {0}, port {1}", localEndPoint.Address, localEndPoint.Port);

                if (Discovery(ref hpsdrdList, iep, targetIP))
                {
                    result = true;
                }

            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Caught an exception while binding a socket to endpoint {0}.  Exception was: {1} ", iep.ToString(), ex.ToString());
                result = false;
            }
            finally
            {
                socket.Close();
                socket = null;
            }

            return result;
        }


        private static bool Discovery(ref List<HPSDRDevice> hpsdrdList, IPEndPoint iep, IPAddress targetIP)
        {
            // set up HPSDR discovery packet
            string MAC;
            byte[] DiscoveryPacketP1 = new byte[63];
            Array.Clear(DiscoveryPacketP1, 0, DiscoveryPacketP1.Length);
            DiscoveryPacketP1[0] = 0xef;
            DiscoveryPacketP1[1] = 0xfe;
            DiscoveryPacketP1[2] = 0x02;
            byte[] DiscoveryPacketP2 = new byte[60];
            Array.Clear(DiscoveryPacketP2, 0, DiscoveryPacketP2.Length);
            DiscoveryPacketP2[4] = 0x02;

            bool radio_found = false;           // true when we find a radio
            int static_ip_ok = 5;               // MI0BOT: Try the static IP 5 times before going to broadcast
            int time_out = 0;

            // set socket option so that broadcast is allowed.
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);

            // need this so we can Broadcast on the socket
            IPEndPoint broadcast;// = new IPEndPoint(IPAddress.Broadcast, DiscoveryPort);
            string receivedIP;   // the IP address Metis obtains; assigned, from DHCP or APIPA (169.254.x.y)

            IPAddress hostPortIPAddress = iep.Address;
            IPAddress hostPortMask = IPAddress.Broadcast;

            // find the subnet mask that goes with this host port
            foreach (NicProperties n in nicProperties)
            {
                if (hostPortIPAddress.Equals(n.ipv4Address))
                {
                    hostPortMask = n.ipv4Mask;
                    break;
                }
            }

            // send every second until we either find a radio or exceed the number of attempts
            while (!radio_found)            // #### djm should loop for a while in case there are multiple radios
            {
                // send a broadcast to port 1024
                // try target ip address 1 time if static
                if (enableStaticIP && (static_ip_ok-- > 0))
                    broadcast = new IPEndPoint(targetIP, DiscoveryPort);
                else
                    // try directed broadcast address
                    broadcast = new IPEndPoint(IPAddressExtensions.GetBroadcastAddress(hostPortIPAddress, hostPortMask), DiscoveryPort);                

                if (RadioProtocolSelected == RadioProtocol.Auto || RadioProtocolSelected == RadioProtocol.USB)
                    socket.SendTo(DiscoveryPacketP1, broadcast);
                if (RadioProtocolSelected == RadioProtocol.Auto || RadioProtocolSelected == RadioProtocol.ETH)
                    socket.SendTo(DiscoveryPacketP2, broadcast);

                // now listen on send port for any radio
                System.Console.WriteLine("Ready to receive.... ");
                int recv;
                byte[] data = new byte[100];

                bool data_available;

                // await possibly multiple replies, if there are multiple radios on this port,
                // which MIGHT be the 'any' port, 0.0.0.0
                do
                {
                    // Poll the port to see if data is available 
                    data_available = socket.Poll(100000, SelectMode.SelectRead);  // wait 100 msec  for time out    

                    if (data_available)
                    {
                        EndPoint remoteEP = new IPEndPoint(IPAddress.None, 0);
                        recv = socket.ReceiveFrom(data, ref remoteEP);                 // recv has number of bytes we received
                        //string stringData = Encoding.ASCII.GetString(data, 0, recv); // use this to print the received data

                        System.Console.WriteLine("RAW Discovery data = " + BitConverter.ToString(data, 0, recv));
                        // see what port this came from at the remote end
                        // IPEndPoint remoteIpEndPoint = socket.RemoteEndPoint as IPEndPoint;
                        // System.Console.WriteLine(" Remote Port # = ", remoteIpEndPoint.Port);

                        string junk = Convert.ToString(remoteEP);  // see code in DataLoop
                        string[] words = junk.Split(':');
                        int remotePort = Convert.ToInt32(words[1]);
                        System.Console.Write(words[1]);

                        //[2.10.3.5]MW0LGE sigh, MAC address in P1 is NOT at data[5], but at data[3]
                        //// get MAC address from the payload
                        //byte[] mac = { 0, 0, 0, 0, 0, 0 };
                        //Array.Copy(data, 5, mac, 0, 6);
                        //MAC = BitConverter.ToString(mac);

                        byte[] mac = { 0, 0, 0, 0, 0, 0 };
                        if ((data[0] == 0xef) && // Protocol-USB (P1)
                             (data[1] == 0xfe) &&
                             ((data[2] == 0x2) || (data[2] == 0x3)))
                        {
                            Array.Copy(data, 3, mac, 0, 6);
                        }
                        else if ((data[0] == 0x0) &&  // Protocol-ETH (P2)
                             (data[1] == 0x0) &&
                             (data[2] == 0x0) &&
                             (data[3] == 0x0) &&
                             ((data[4] == 0x2) || (data[4] == 0x3)))
                        {
                            Array.Copy(data, 5, mac, 0, 6);
                        }
                        MAC = BitConverter.ToString(mac);

                        // check for HPSDR frame ID and type 2 (not currently streaming data, which also means 'not yet in use')
                        // changed to filter a proper discovery packet from the radio, even if already in use!  This prevents the need to power-cycle the radio.
                        if (((data[0] == 0xef) && // Protocol-USB (P1) Busy 
                            (data[1] == 0xfe) &&
                            (data[2] == 0x3)) ||
                        ((data[0] == 0x0) &&  // Protocol-ETH (P2) Busy
                            (data[1] == 0x0) &&
                            (data[2] == 0x0) &&
                            (data[3] == 0x0) &&
                            (data[4] == 0x3)))
                        {
                            System.Console.WriteLine("Radio Busy");
                            return false;
                        }

                        if (((data[0] == 0xef) && // Protocol-USB (P1)
                             (data[1] == 0xfe) &&
                             (data[2] == 0x2)) || 
                            ((data[0] == 0x0) &&  // Protocol-ETH (P2)
                             (data[1] == 0x0) &&
                             (data[2] == 0x0) &&
                             (data[3] == 0x0) &&
                             (data[4] == 0x2)))
                        {
                            if (data[2] == 0x2) CurrentRadioProtocol = RadioProtocol.USB;
                            else CurrentRadioProtocol = RadioProtocol.ETH;
                            freqCorrectionChanged();

                            System.Console.WriteLine("\nFound a radio on the network.  Checking whether it qualifies");

                            // get IP address from the IPEndPoint passed to ReceiveFrom.
                            IPEndPoint ripep = (IPEndPoint)remoteEP;
                            IPAddress receivedIPAddr = ripep.Address;
                            receivedIP = receivedIPAddr.ToString();
                            IPEndPoint localEndPoint = (IPEndPoint)socket.LocalEndPoint;
                            System.Console.WriteLine("Looking for radio using host adapter IP {0}, port {1}", localEndPoint.Address, localEndPoint.Port);

                            System.Console.WriteLine("IP from IP Header = " + receivedIP);
                            System.Console.WriteLine("MAC address from payload = " + MAC);

                            if ((enableLimitSubnet == true) && !SameSubnet(receivedIPAddr, hostPortIPAddress, hostPortMask))
                            {
                                // device is NOT on the subnet that this port actually services.  Do NOT add to list!
                                System.Console.WriteLine("Not on subnet of host adapter! Adapter IP {0}, Adapter mask {1}",
                                    hostPortIPAddress.ToString(), hostPortMask.ToString());
                            }
                            else if (MAC.Equals("00-00-00-00-00-00"))
                            {
                                System.Console.WriteLine("Rejected: contains bogus MAC address of all-zeroes");
                            }
                            else
                            {
                                HPSDRDevice hpsdrd = new HPSDRDevice
                                {
                                    IPAddress = receivedIP,
                                    MACAddress = MAC,
                                    remotePort = remotePort,
                                    deviceType = CurrentRadioProtocol == RadioProtocol.USB ? (HPSDRHW)data[10] : (HPSDRHW)data[11],
                                    protocolSupported = CurrentRadioProtocol == RadioProtocol.USB ? (byte)0 : data[12],
                                    codeVersion = CurrentRadioProtocol == RadioProtocol.USB ? data[9] : data[13],
                                    codeVersionMinor = CurrentRadioProtocol == RadioProtocol.USB ? data[21] : (Byte) 0,
                                    hostPortIPAddress = hostPortIPAddress,
                                    localPort = localEndPoint.Port,
                                    MercuryVersion_0 = data[14],
                                    MercuryVersion_1 = data[15],
                                    MercuryVersion_2 = data[16],
                                    MercuryVersion_3 = data[17],
                                    PennyVersion = data[18],
                                    MetisVersion = data[19],
                                    numRxs = data[20],
                                    betaVersion = CurrentRadioProtocol == RadioProtocol.USB ? (byte)0 : data[23],
                                    protocol = CurrentRadioProtocol
                                };

                                // Map P1 device types to P2
                                if (CurrentRadioProtocol == RadioProtocol.USB)
                                {
                                    switch(data[10])
                                    {
                                        case 0:
                                            hpsdrd.deviceType = HPSDRHW.Atlas;
                                            break;
                                        case 1:
                                            hpsdrd.deviceType = HPSDRHW.Hermes;
                                            break;
                                        case 2:
                                            hpsdrd.deviceType = HPSDRHW.HermesII;
                                            break;
                                        case 4:
                                            hpsdrd.deviceType = HPSDRHW.Angelia;
                                            break;
                                        case 5:
                                            hpsdrd.deviceType = HPSDRHW.Orion;
                                            break;
                                        case 6:
                                            hpsdrd.deviceType = HPSDRHW.HermesLite;
                                            SetDiscoveryBoardType((int)hpsdrd.deviceType);
                                            break;
                                        case 10:
                                            hpsdrd.deviceType = HPSDRHW.OrionMKII;
                                            break;
                                    }
                                }

                                if (targetIP != null)
                                {
                                    if (hpsdrd.IPAddress.CompareTo(targetIP.ToString()) == 0)
                                    {
                                        radio_found = true;
                                        hpsdrdList.Add(hpsdrd);
                                        return true;
                                    }
                                }
                                else
                                {
                                    radio_found = true;
                                    hpsdrdList.Add(hpsdrd);
                                }
                            }
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data from Port = ");
                        if ((++time_out) > 5)
                        {
                            System.Console.WriteLine("Time out!");
                            return false;
                        }
                    }
                } while (data_available);
            }

            return radio_found;
        }

        /// <summary>
        /// Determines whether the board and hostAdapter IPAddresses are on the same subnet,
        /// using subnetMask to make the determination.  All addresses are IPV4 addresses
        /// </summary>
        /// <param name="board">IP address of the remote device</param>
        /// <param name="hostAdapter">IP address of the ethernet adapter</param>
        /// <param name="subnetMask">subnet mask to use to determine if the above 2 IPAddresses are on the same subnet</param>
        /// <returns>true if same subnet, false otherwise</returns>
        public static bool SameSubnet(IPAddress board, IPAddress hostAdapter, IPAddress subnetMask)
        {
            byte[] boardBytes = board.GetAddressBytes();
            byte[] hostAdapterBytes = hostAdapter.GetAddressBytes();
            byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

            if (boardBytes.Length != hostAdapterBytes.Length)
            {
                return false;
            }
            if (subnetMaskBytes.Length != hostAdapterBytes.Length)
            {
                return false;
            }

            for (int i = 0; i < boardBytes.Length; ++i)
            {
                byte boardByte = (byte)(boardBytes[i] & subnetMaskBytes[i]);
                byte hostAdapterByte = (byte)(hostAdapterBytes[i] & subnetMaskBytes[i]);
                if (boardByte != hostAdapterByte)
                {
                    return false;
                }
            }
            return true;
        }

        // Taken From: https://searchcode.com/codesearch/view/7464800/
        private static IPEndPoint QueryRoutingInterface(
                  Socket socket,
                  IPEndPoint remoteEndPoint)
        {
            try
            {
                SocketAddress address = remoteEndPoint.Serialize();

                byte[] remoteAddrBytes = new byte[address.Size];
                for (int i = 0; i < address.Size; i++)
                {
                    remoteAddrBytes[i] = address[i];
                }

                byte[] outBytes = new byte[remoteAddrBytes.Length];
                socket.IOControl(
                            IOControlCode.RoutingInterfaceQuery,
                            remoteAddrBytes,
                            outBytes);
                for (int i = 0; i < address.Size; i++)
                {
                    address[i] = outBytes[i];
                }

                EndPoint ep = remoteEndPoint.Create(address);
                return (IPEndPoint)ep;
            }
            catch
            {
                return null;  //[2.10.3.7]MW0LGE added try catch
            }
        }

    }

    // Taken from: http://blogs.msdn.com/b/knom/archive/2008/12/31/ip-address-calculations-with-c-subnetmasks-networks.aspx
    public static class IPAddressExtensions
    {
        public static IPAddress GetBroadcastAddress(this IPAddress address, IPAddress subnetMask)
        {
            byte[] ipAdressBytes = address.GetAddressBytes();
            byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");

            byte[] broadcastAddress = new byte[ipAdressBytes.Length];
            for (int i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAdressBytes[i] | (subnetMaskBytes[i] ^ 255));
            }
            return new IPAddress(broadcastAddress);
        }
    }

    public class HPSDRDevice
    {
        public HPSDRHW deviceType;      // which type of device 
        public byte codeVersion;        // reported code version type
        public byte codeVersionMinor;   // MI0BOT: reported minor code version in Hermes Lite
        public string IPAddress;        // IPV4 address
        public string MACAddress;       // physical (MAC) address
        public int remotePort;          // MI0BOT: Remote port info to allow for different port access over WAN
        public IPAddress hostPortIPAddress;
        public int localPort;
        public byte MercuryVersion_0;
        public byte MercuryVersion_1;
        public byte MercuryVersion_2;
        public byte MercuryVersion_3;
        public byte PennyVersion;
        public byte MetisVersion;
        public byte numRxs;
        public RadioProtocol protocol;
        public byte betaVersion;                // byte[23] from P2 discovery packet. MW0LGE_21d
        public byte protocolSupported;          // byte[12] from P2 discovery packet. MW0LGE_21d 
    }

    public class NicProperties
    {
        public IPAddress ipv4Address;
        public IPAddress ipv4Mask;
    }


}
