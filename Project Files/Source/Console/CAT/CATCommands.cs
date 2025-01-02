//=================================================================
// CATCommands.cs
//=================================================================
// Copyright (C) 2005  Bob Tracy
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//
// You may contact the author via email at: k5kdn@arrl.net
//=================================================================
// Continual modifications Copyright (C) 2019-2024 Richard Samphire (MW0LGE)
/*
Modifications to support the Behringer Midi controllers
by Chris Codella, W2PA, April 2017.  Indicated by //-W2PA comment lines.
Added extended CAT commands for APF funtions - May 2017.
*/
//=================================================================

using System;
using System.Diagnostics;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
using System.Windows.Forms;                           

namespace Thetis
{
	/// <summary>
	/// Summary description for CATCommands.
	/// </summary>
	public class CATCommands
	{
		#region Variable Definitions

		private readonly Console console;
		private readonly CATParser parser;
		private readonly string separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
		private Band[] BandList;
		private int LastBandIndex;
		private readonly ASCIIEncoding AE = new ASCIIEncoding();
		private string lastFR = "0";
		private string lastFT = "0";
        public bool Verbose { get; set; } = false;
		private readonly int NCATInit = 500;
        private int NCATs = 0;
        private readonly int NCATtime = 50;
        public bool firstTimeCAT = true;

		#endregion Variable Definitions

		#region Constructors

		public CATCommands()
		{
		}

		public CATCommands(Console c,CATParser p)
		{
			console = c;
			parser = p;
			MakeBandList();
		}

		#endregion Constructors

		// Commands getting this far have been checked for a valid prefix, a correct suffix length,
		// and a terminator.  All we need to do in this class is to decide what kind of command
		// (read or set) and execute it.  Only read commands generate answers.

		#region Standard CAT Methods A-F

		// Sets or reads the Audio Gain control
		public string AG(string s)
		{
			if(s.Length == parser.nSet)	// if the length of the parameter legal for setting this prefix
			{
				int raw = Convert.ToInt32(s.Substring(1));
				int af = (int) Math.Round(raw/2.55,0);	// scale 255:100 (Kenwood vs SDR)
				console.AF = af;		// Set the console control
				return "";
			}
			else if(s.Length == parser.nGet)	// if this is a read command
			{
				int af = (int) Math.Round(console.AF/0.392,0);
//				return AddLeadingZeros(console.AF);		// Get the console setting
				return AddLeadingZeros(af);
			}
			else
			{
				return parser.Error1;	// return a ?
			}
		}

		public string AI(string s)
		{
			return ZZAI(s);
			//			if(console.SetupForm.AllowFreqBroadcast)
			//			{
			//				if(s.Length == parser.nSet)
			//				{
			//					if(s == "0")
			//						console.KWAutoInformation = false;
			//					else 
			//						console.KWAutoInformation = true;
			//					return "";
			//				}
			//				else if(s.Length == parser.nGet)
			//				{
			//					if(console.KWAutoInformation)
			//						return "1";
			//					else
			//						return "0";
			//				}
			//				else
			//					return parser.Error1;
			//			}
			//			else
			//				return parser.Error1;
		}

		// Moves one band down from the currently selected band
		// write only
		public string BD()
		{
			//			BandDown();
			//			return "";
			return ZZBD();
		}

		// Moves one band up from the currently selected band
		// write only
		public string BU()
		{
			//			BandUp();
			//			return "";
			return ZZBU();
		}

        //Reads or sets the CTCSS frequency
        public string CN(string s)
        {
            return ZZTB(s);
        }

        //Reads or sets the CTCSS enable button
        public string CT(string s)
        {
            return ZZTA(s);
        }

		//Moves the VFO A frequency by the step size set on the console
		public string DN()
		{
			//			int step = console.StepSize;
			//			double[] wheel_tune_list;
			//			wheel_tune_list = new double[13];		// initialize wheel tuning list array
			//			wheel_tune_list[0]  =  0.000001;
			//			wheel_tune_list[1]  =  0.000010;
			//			wheel_tune_list[2]  =  0.000050;
			//			wheel_tune_list[3]  =  0.000100;
			//			wheel_tune_list[4]  =  0.000250;
			//			wheel_tune_list[5]  =  0.000500;
			//			wheel_tune_list[6]  =  0.001000;
			//			wheel_tune_list[7]  =  0.005000;
			//			wheel_tune_list[8]  =  0.009000;
			//			wheel_tune_list[9]  =  0.010000;
			//			wheel_tune_list[10] =  0.100000;
			//			wheel_tune_list[11] =  1.000000;
			//			wheel_tune_list[12] = 10.000000;
			//
			//			console.VFOAFreq = console.VFOAFreq - wheel_tune_list[step];
			//			return "";

			return ZZSA();
		}

		// Sets or reads the frequency of VFO A
		public string FA(string s)
		{
			//			if(s.Length == parser.nSet)
			//			{
			//				s = s.Insert(5,separator);		//reinsert the global numeric separator
			//				console.VFOAFreq = double.Parse(s);
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//				return StrVFOFreq("A");
			//			else
			//				return parser.Error1;
			return ZZFA(s);
		}

		// Sets or reads the frequency of VFO B
		public string FB(string s)
		{
			//			if(s.Length == parser.nSet)
			//			{
			//				s = s.Insert(5,separator);
			//				console.VFOBFreq = double.Parse(s);
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//				return StrVFOFreq("B");
			//			else
			//				return parser.Error1;
			return ZZFB(s);
		}

		// Sets VFO A to control rx
		// this is a dummy command to keep other software happy
		// since the SDR-1000 always uses VFO A for rx
		public string FR(string s)
		{
			if(s.Length == parser.nSet)
			{
				return "";
			}
			else if(s.Length == parser.nGet)
				return "0";
			else
				return parser.Error1;
		}

		// Sets or reads VFO B to control tx
		// another "happiness" command
		public string FT(string s, bool bFromCatDirect = false)
		{
			//			if(s.Length == parser.nSet)
			//			{
			//				if(s == "1")
			//				{
			//					console.VFOSplit = true;
			//				}
			//				else if(s == "0")
			//				{
			//					console.VFOSplit = false;
			//				}
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				return ZZSP(s);
			//			}
			//			else
			//				return parser.Error1;
			return ZZSP(s, bFromCatDirect);
		}

		// Sets or reads the DSP filter width
		//OBSOLETE
		public string FW(string s)
		{
			if(s.Length == parser.nSet)
			{
				console.RX1Filter = String2Filter(s);
				return "";
			}
			else if(s.Length == parser.nGet)
				return Filter2String(console.RX1Filter);
			else
				return parser.Error1;
		}

		#endregion Standard CAT Methods A-F

		#region Standard CAT Methods G-M

		// Sets or reads the AGC constant
		// this is a wrapper that calls ZZGT
		public string GT(string s)
		{
			if(ZZGT(s).Length > 0)
				return ZZGT(s).PadLeft(3,'0');		//Added padleft fix 4/2/2007 BT
			else
				return "";
		}

		// Reads the transceiver ID number
		// this needs changing when 3rd party folks on line.
		public string ID()
		{
			string id;
			switch(console.CATRigType)
			{
				case 900:
					id = "900";		//SDR-1000
					break;
				case 13:
					id = "013";		//TS-50S
					break;
				case 19:
					id = "019";		//TS-2000
					break;
				case 20:
					id = "020";		//TS-480
					break;
				default:
					id = "019";
					break;
			}
			return(id);
		}

		// Reads the transceiver status
		// needs work in the split area
		public string IF()
		{
            if (NCATs < NCATInit)
            {
                Thread.Sleep(NCATtime);
                NCATs++;
            }
			string rtn = "";
			string rit = "0";
			string xit = "0";
			string incr;
			string tx = "0";
			string tempmode = "";
			int ITValue = 0;
			//string temp;

			// Get the rit/xit status
			if(console.RITOn)
				rit = "1";
			else if(console.XITOn)
				xit = "1";
			// Get the incremental tuning value for whichever control is selected
			if(rit == "1")
				ITValue = console.RITValue;
			else if(xit == "1")
				ITValue = console.XITValue;
			// Format the IT value
			if(ITValue < 0)
				incr = "-"+Convert.ToString(Math.Abs(ITValue)).PadLeft(5,'0');
			else
				incr = "+"+Convert.ToString(Math.Abs(ITValue)).PadLeft(5,'0');
			// Get the rx - tx status
			if(console.MOX)
				tx = "1";
			// Get the step size
			int step = console.TuneStepIndex;
			string stepsize =  Step2String(step);
			// Get the vfo split status
			string split = "0";
			bool retval = console.VFOSplit;
			if(retval)
				split = "1";
			//Get the mode
			//			temp = Mode2KString(console.RX1DSPMode);   //possible fix for SAM problem
			//			if(temp == parser.Error1)
			//				temp = " ";

			string f = ZZFA("");
            
            // MI0BOT: Redirect CAT to VFO B
            if (console.CATtoVFOB && Console.getConsole().CurrentHPSDRModel == HPSDRModel.HERMESLITE)
                f = ZZFB("");

            if (f.Length > 11)
			{
				f = f.Substring(f.Length-11,11);
			}
			rtn += f;
//			rtn += StrVFOFreq("A");						// VFO A frequency			11 bytes
			rtn += stepsize;							// Console step frequency	 4 bytes
			rtn += incr;								// incremental tuning value	 6 bytes
			rtn += rit;									// RIT status				 1 byte
			rtn += xit;									// XIT status				 1 byte
			rtn += "000";								// dummy for memory bank	 3 bytes
			rtn += tx;                                  // tx-rx status				 1 byte
                                                        //			rtn += temp;
                                                        //			rtn += Mode2KString(console.RX1DSPMode);	// current mode			 1 bytes
            // MI0BOT: Redirect CAT to VFO B
            if (console.CATtoVFOB && Console.getConsole().CurrentHPSDRModel == HPSDRModel.HERMESLITE)
                tempmode = Mode2KString(console.RX2DSPMode);
			else
                tempmode = Mode2KString(console.RX1DSPMode);

			if(tempmode == "?;")
				rtn += "2";
			else
				rtn += tempmode;
			rtn += "0";									// dummy for FR/FT			 1 byte
			rtn += "0";									// dummy for scan status	 1 byte
			rtn += split;								// VFO Split status			 1 byte
			rtn += "0000";								// dummy for the balance	 4 bytes
			return rtn;									// total bytes				35

			//			// Initalize the command word
			//			string cmd_string = "";
			//			string temp;
			//
			//			// Get VFOA's frequency (P1 - 11 bytes)
			//			if(console.VFOSplit)
			//				cmd_string += StrVFOFreq("B");
			//			else
			//				cmd_string += StrVFOFreq("A");
			//
			//			// Get the step size index (P2 - 4 bytes)
			//			cmd_string += ZZST();
			//
			//			// Determine which incremental tuning control is active
			//			// and get the value for the active control 
			//			string rit = "0";
			//			string xit = "0";
			//			int ITValue = 0;
			//
			//			if(console.RITOn)
			//				rit = "1";
			//			else if(console.XITOn)
			//				xit = "1";
			//
			//			if(rit == "1")
			//				ITValue = console.RITValue;
			//			else if(xit == "1")
			//				ITValue = console.XITValue;
			//
			//			// Add the ITValue to the command string (P3 - 6 bytes
			//			if(ITValue < 0)
			//				cmd_string += "-"+Convert.ToString(Math.Abs(ITValue)).PadLeft(5,'0');
			//			else
			//				cmd_string += "+"+Convert.ToString(Math.Abs(ITValue)).PadLeft(5,'0');
			//
			//			// Add the RIT/XIT status bits (P4 and P5, one byte each)
			//			cmd_string += rit+xit;
			//				
			//			// Skip the memory channel stuff, the SDR1K doesn't use banks and channels per se
			//			// (P6 - 1 byte, P7 - 2 bytes)
			//			cmd_string += "000";
			//
			//			// Set the current MOX state (P8 - 1 byte)(what the heck is this for?)
			//			if(console.MOX)
			//				cmd_string += "1";
			//			else
			//				cmd_string += "0";
			//
			//			// Get the SDR mode.  (P9 - 1 byte)
			//			temp = Mode2KString(console.RX1DSPMode);
			//			if(temp.Length == 1)	// if the answer is not an error message ?;
			//				cmd_string += temp;
			//			else
			//				cmd_string += " ";	// return a blank if it's an error
			//
			//			// Set the FR/FT commands which determines the transmit and receive
			//			// VFO's. VFO A = 0, VFO B = 1. (P10 - 1 byte)
			//			if(console.VFOSplit)
			//				cmd_string += "1";
			//			else
			//				cmd_string += "0";
			//
			//
			//			// Set the Scan code to 0 
			//			// The Scan code might be implemented but the frequency range would
			//			// have to be manually entered. (P11 - 1 byte)
			//			cmd_string += "0";
			//
			//			// Set the Split operation code (P12 - 1 byte)
			//			cmd_string += ZZSP("");
			//
			//			// Set the remaining CTCSS tone and shift bits to 0 (P13 - P15, 4 bytes)
			//			cmd_string += "0000";
			//
			//			return cmd_string;
		}

		//Sets or reads the CWX CW speed
		public string KS(string s)
		{
			//			int cws = 0;
			//			// Make sure we have an instance of the form
			//			if(console.CWXForm == null || console.CWXForm.IsDisposed)
			//			{
			//				try
			//				{
			//					console.CWXForm = new CWX(console);
			//				}
			//				catch
			//				{
			//					return parser.Error1;
			//				}
			//			}
			//			if(s.Length == parser.nSet)
			//			{
			//				cws = Convert.ToInt32(s);
			//				cws = Math.Max(1, cws);
			//				cws = Math.Min(99, cws);
			//				console.CWXForm.WPM = cws;
			//				return "";
			//
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				return AddLeadingZeros(console.CWXForm.WPM);
			//			}
			//			else
			//				return parser.Error1;
			return ZZKS(s);
		}

		//Sends text data to CWX for conversion to Morse
		public string KY(string s)
		{
			// Make sure we are in a cw mode.
			switch(console.RX1DSPMode)
			{
				case DSPMode.AM:
				case DSPMode.DRM:
				case DSPMode.DSB:
				case DSPMode.FM:
				case DSPMode.SAM:
				case DSPMode.SPEC:
				case DSPMode.LSB:
				case DSPMode.USB:
					if(console.RX1Band >= Band.B160M && console.RX1Band <= Band.B40M)
						console.RX1DSPMode = DSPMode.CWL;
					else
						console.RX1DSPMode = DSPMode.CWU;
					break;
                case DSPMode.CWL:
                case DSPMode.CWU:
                    break;
				default:
					console.RX1DSPMode = DSPMode.CWU;
					break;
			}

			if(s.Length == parser.nSet)
			{

				string trms = "";
				byte[] msg;
                string x = s.Trim();

				if(x.Length == 0)
					trms = " ";
				else
					trms = s.TrimEnd();

				if(trms.Length > 1)
				{
					msg = AE.GetBytes(trms);
					return console.CWXForm.RemoteMessage(msg);
				}
				else
				{
					char ss = Convert.ToChar(trms);
					return console.CWXForm.RemoteMessage(ss);
				}
			}
			else if(s.Length == parser.nGet)
			{
				int ch = console.CWXForm.Characters2Send;

				if(ch < 72)
					return "0";
				else
					return "1";
			}
			else
				return parser.Error1;
		}


		// Sets or reads the transceiver mode
		public string MD(string s)
		{
            if (NCATs < NCATInit)
            {
                Thread.Sleep(NCATtime);
                NCATs++;
            }
			if(s.Length == parser.nSet)
			{
				if(Convert.ToInt32(s) > 0 && Convert.ToInt32(s) <= 9)
				{
					KString2Mode(s);
					return "";
				}
				else
					return parser.Error1;
			}
			else if(s.Length == parser.nGet)
			{
				// MI0BOT: Redirect CAT to VFO B
                if (console.CATtoVFOB && Console.getConsole().CurrentHPSDRModel == HPSDRModel.HERMESLITE)
                    return Mode2KString(console.RX2DSPMode);
				else
                    return Mode2KString(console.RX1DSPMode);

			}
			else
				return parser.Error1;
		}

		// Sets or reads the Mic Gain thumbwheel
		public string MG(string s)
		{
			int n;
			if(s.Length == parser.nSet)	
			{
				n = Convert.ToInt32(s);
				n = Math.Max(0, n);
				n = Math.Min(100, n);
				int mg = (int) Math.Round(n/1.43,0);	// scale 100:70 (Kenwood vs SDR)
				s = AddLeadingZeros(mg);
				return ZZMG(s);
			}
			else if(s.Length == parser.nGet)
			{
				s = ZZMG("");
				n = Convert.ToInt32(s);
				int mg = (int) Math.Round(n/.7,0);
				s = AddLeadingZeros(mg);
				return s;
			}
			else
				return parser.Error1;
		}

		// Sets or reads the Monitor status
		public string MO(string s)
		{
			//			if(s.Length == parser.nSet)
			//			{
			//				if(s == "0")
			//					console.MON = false;
			//				else if(s == "1")
			//					console.MON = true;
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				bool retval = console.MON;
			//				if(retval)
			//					return "1";
			//				else
			//					return "0";
			//			}
			//			else
			//				return parser.Error1;
			return ZZMO(s);
		}

		#endregion Standard CAT Methods G-M

		#region Standard CAT Methods N-Q

		// Sets or reads the Noise Blanker 1 status
		public string NB(string s)
		{
			//			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			//			{
			//				console.CATNB1 = Convert.ToInt32(s);
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				return console.CATNB1.ToString();
			//			}
			//			else
			//			{
			//				return parser.Error1;
			//			}
			return ZZNA(s);
		}

		// Sets or reads the Automatic Notch Filter status
		public string NT(string s)
		{
			//			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			//			{
			//				console.CATANF = Convert.ToInt32(s);
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				return console.CATANF.ToString();
			//			}
			//			else
			//			{
			//				return parser.Error1;
			//			}
			return ZZNT(s);
		}

        //Sets or reads the FM repeater offset frequency
        public string OF(string s)
        {
            return ZZOT(s);
        }

        //Sets or reads the repeater offset direction
        public string OS(string s)
        {
            return ZZOS(s);
        }


		// Sets or reads the PA output thumbwheel
		public string PC(string s)
		{
			//			int pwr = 0;
			//
			//			if(s.Length == parser.nSet)
			//			{
			//				pwr = Convert.ToInt32(s);
			//				console.PWR = pwr;
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				return AddLeadingZeros(console.PWR);
			//			}
			//			else
			//			{
			//				return parser.Error1;
			//			}
			return ZZPC(s);
		}

		// Sets or reads the Speech Compressor status
        //Reactivated 10/21/2012 for HRD compatibility BT
		public string PR(string s)
		{
            if (s.Length == parser.nGet)
			{
    			return "0";
            }
            else
            {
                return parser.Error1;
            }
		}

		// Sets or reads the console power on/off status
		public string PS(string s)
		{
			//			if(s.Length == parser.nSet)
			//			{
			//				if(s == "0")
			//					console.PowerOn = false;
			//				else if(s == "1")
			//					console.PowerOn = true;
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				bool pwr = console.PowerOn;
			//				if(pwr)
			//					return "1";
			//				else
			//					return "0";
			//			}
			//			else
			//			{
			//				return parser.Error1;
			//			}
			return ZZPS(s);
		}

		// Sets the Quick Memory with the current contents of VFO A
		public string QI()
		{
//			console.CATMemoryQS();
//			return "";
			return ZZQS();
		}

		#endregion Standard CAT Methods N-Q

		#region Standard CAT Methods R-Z

		// Clears the RIT value
		// write only
		public string RC()
		{
//			console.RITValue = 0;
//			return "";
			return ZZRC();
		}

		//Decrements RIT
		public string RD(string s)
		{
			return ZZRD(s);
		}


		// Sets or reads the RIT status (on/off)
		public string RT(string s)
		{
			//			if(s.Length == parser.nSet)
			//			{
			//				if(s == "0")
			//					console.RITOn = false;
			//				else if(s == "1") 
			//					console.RITOn = true;
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				bool rit = console.RITOn;
			//				if(rit)
			//					return "1";
			//				else
			//					return "0";
			//			}
			//			else
			//			{
			//				return parser.Error1;
			//			}
			return ZZRT(s);
		}

		//Increments RIT
		public string RU(string s)
		{
			return ZZRU(s);
		}


		// Sets or reads the transceiver receive mode status
		// write only but spec shows an answer parameter for a read???
		public string RX(string s)
		{
			console.CATPTT = false;
			return "";
			//return ZZTX("0");
		}

		// Sets or reads the variable DSP filter high side
		public string SH(string s)
		{
			if(s.Length == parser.nSet)
			{
				SetFilter(s, "SH");
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				switch(console.RX1DSPMode)
				{
					case DSPMode.AM:
					case DSPMode.CWU:
					case DSPMode.DRM:
					case DSPMode.DSB:
					case DSPMode.FM:
					case DSPMode.SAM:
					case DSPMode.USB:
						return Frequency2Code(console.RX1FilterHigh,"SH");
					case DSPMode.CWL:
					case DSPMode.LSB:
						return Frequency2Code(console.RX1FilterLow,"SH");
					default:
						return Frequency2Code(console.RX1FilterHigh,"SH");
				}
			}
			else
			{
				return parser.Error1;
			}
		}

		// Sets or reads the variable DSP filter low side
		public string SL(string s)
		{
			if(s.Length == parser.nSet)
			{
				SetFilter(s, "SL");
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				switch(console.RX1DSPMode)
				{
					case DSPMode.AM:
					case DSPMode.CWU:
					case DSPMode.DRM:
					case DSPMode.DSB:
					case DSPMode.FM:
					case DSPMode.SAM:
					case DSPMode.USB:
						return Frequency2Code(console.RX1FilterLow,"SL");
					case DSPMode.CWL:
					case DSPMode.LSB:
						return Frequency2Code(console.RX1FilterHigh,"SL");
					default:
						return Frequency2Code(console.RX1FilterLow,"SL");
				}
			}
			else
			{
				return parser.Error1;
			}
		}

        // Reads the S Meter value  //TODO modify to consider console.S9Frequency
        public string SM(string s)
		{
			int sm = 0;
			double sx = 0.0;

			if(s == "0" || s == "2")	// read the main transceiver s meter
			{
				float num = 0f;
				if(console.PowerOn)
					num = WDSP.CalculateRXMeter(0, 0,WDSP.MeterType.SIGNAL_STRENGTH);
				num = num+console.MultiMeterCalOffset+console.PreampOffset;

				num = Math.Max(-140, num);
				num = Math.Min(-10, num);

				sx = (num+127)/6;
				if(sx < 0) sx = 0;

				if(sx <= 9.0F)
				{
					sm = Math.Abs((int)(sx * 1.6667));
				}
				else
				{
					double over_s9 = num + 73;
					sm = 15 + (int) over_s9;
				}
				if(sm < 0) sm = 0;
				if(sm > 30) sm = 30;

				return sm.ToString().PadLeft(5,'0');
			}
			else
			{
				return parser.Error1;
			}
		}

		// Sets or reads the Squelch value
		public string SQ(string s)
		{
			string rx = s.Substring(0,1);
			double level = 0.0;

			//Will need code to select receiver when n Receivers enabled.
			//for now, ignore rx number.
			
			if(s.Length == parser.nSet)
				//convert to a double and add the scale factor (160 = 255)
			{
				level = Convert.ToDouble(s.Substring(1));
				level = Math.Max(0, level);			// lower bound
				level = Math.Min(255, level);		// upper bound
				//level = level*0.62745;				// scale factor
                level = -160 + level * 0.62745;		    // scale factor
				console.Squelch = Convert.ToInt32(Math.Round(level,0));
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				// return rx+AddLeadingZeros(console.Squelch).Substring(1);
                // Map -160 to 0 to 0 to 255 for TS-2000 SQ command
                int isquelch = Convert.ToInt32((1.0 - (Math.Abs(console.Squelch / 160.0))) * 255.0);
                return rx + AddLeadingZeros(isquelch).Substring(1);
			}
			else
			{
				return parser.Error1;
			}
		}

		// Sets the transmitter on, write only
		// will eventually need eiter Commander change or ZZ code
		// since it is not CAT compliant as it is
		public string TX(string s)
		{
			console.CATPTT = true;
			return "";
			//return ZZTX("1");
		}

		//Moves the VFO A frequency up by the step size set on the console
		public string UP()
		{
			//			int step = console.StepSize;
			//			double[] wheel_tune_list;
			//			wheel_tune_list = new double[13];		// initialize wheel tuning list array
			//			wheel_tune_list[0]  =  0.000001;
			//			wheel_tune_list[1]  =  0.000010;
			//			wheel_tune_list[2]  =  0.000050;
			//			wheel_tune_list[3]  =  0.000100;
			//			wheel_tune_list[4]  =  0.000250;
			//			wheel_tune_list[5]  =  0.000500;
			//			wheel_tune_list[6]  =  0.001000;
			//			wheel_tune_list[7]  =  0.005000;
			//			wheel_tune_list[8]  =  0.009000;
			//			wheel_tune_list[9]  =  0.010000;
			//			wheel_tune_list[10] =  0.100000;
			//			wheel_tune_list[11] =  1.000000;
			//			wheel_tune_list[12] = 10.000000;
			//
			//			console.VFOAFreq = console.VFOAFreq + wheel_tune_list[step];
			//			return "";

			return ZZSB();
		}


		// Sets or reads the transceiver XIT status (on/off)
		public string XT(string s)
		{
			//			if(s.Length == parser.nSet)
			//			{
			//				if(s == "0")
			//					console.XITOn = false;
			//				else
			//					if(s == "1") 
			//					console.XITOn = true;
			//				return "";
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				bool xit = console.XITOn;
			//				if(xit)
			//					return "1";
			//				else
			//					return "0";
			//			}
			//			else
			//			{
			//				return parser.Error1;
			//			}
			return ZZXS(s);

		}

		#endregion Standard CAT Methods R-Z

		#region Extended CAT Methods ZZA-ZZF


        //-W2PA Sets or reads the APF gain (A for amplitude since G is taken)
        public string ZZAA(string s)
        {
            int n = 0;
            int x = 0;
            string sign;

            if (s != "")
            {
                n = Convert.ToInt32(s);
                n = Math.Max(0, n);
                n = Math.Min(100, n);
            }

            if (s.Length == parser.nSet)
            {
                console.APFGain = n;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                x = console.APFGain;
                if (x >= 0)
                    sign = "+";
                else
                    sign = "-";
                // we have to remove the leading zero and replace it with the sign.
                return sign + AddLeadingZeros(Math.Abs(x)).Substring(1);
            }
            else
            {
                return parser.Error1;
            }

        }

        //-W2PA Sets or reads the APF bandwidth
        public string ZZAB(string s)
        {
            int n = 0;
            int x = 0;
            string sign;

            if (s != "")
            {
                n = Convert.ToInt32(s);
                n = Math.Max(10, n);
                n = Math.Min(150, n);
            }

            if (s.Length == parser.nSet)
            {
                console.APFBandwidth = n;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                x = console.APFBandwidth;
                if (x >= 0)
                    sign = "+";
                else
                    sign = "-";
                // we have to remove the leading zero and replace it with the sign.
                return sign + AddLeadingZeros(Math.Abs(x)).Substring(1);
            }
            else
            {
                return parser.Error1;
            }

        }

        //Sets or reads the console step size (also see zzst(read only)
        public string ZZAC(string s)
        {
			int step;
			if (s.Length == parser.nSet)
            {
                step = Convert.ToInt32(s);
                if (step >= 0 || step <= 25)
                {
                    console.TuneStepIndex = step;
                    return "";
                }
                else
                    return parser.Error1;
            }
            else if (s.Length == parser.nGet)
            {
                step = console.TuneStepIndex;
                return AddLeadingZeros(step);
            }
            else
                return parser.Error1;
        }

        //Sets VFO A down nn Tune Steps
        public string ZZAD(string s)
        {
            int step;
            if (s.Length == parser.nSet)
            {
                step = Convert.ToInt32(s);
                if (step >= 0 || step <= 25)
                {
                    console.VFOAFreq = console.CATVFOA - Step2Freq(step);
                    return "";
                }
                else
                    return parser.Error1;
            }
            else
                return parser.Error1;
        }

        //Sets VFO A down nn Pre-set Tune Steps
        public string ZZAE(string s)
        {
            int step = console.TuneStepIndex;
            int numsteps = 0;
            double stepFreq;
                        
            List<TuneStep> tune_list = console.TuneStepList;
            stepFreq = tune_list[step].StepHz * 10e-7;
            if (s.Length == parser.nSet)
            {
                numsteps = Convert.ToInt32(s);
                if (numsteps >= 0 && step <= 99)
                {
                    console.VFOAFreq = console.CATVFOA - stepFreq * (double)numsteps;
                    return "";
                }
                else
                    return parser.Error1;
            }
            else
                return parser.Error1;
        }

        //Sets VFO A up nn pre-set Steps
        public string ZZAF(string s)
        {
            int step = console.TuneStepIndex;
            int numsteps = 0;
            double stepFreq;

            List<TuneStep> tune_list = console.TuneStepList;
            stepFreq = tune_list[step].StepHz * 10e-7;
            if (s.Length == parser.nSet)
            {
                numsteps = Convert.ToInt32(s);
                if (numsteps >= 0 && step <= 99)
                {
                    console.VFOAFreq = console.CATVFOA + stepFreq * (double)numsteps;
                    return "";
                }
                else
                    return parser.Error1;
            }
            else
                return parser.Error1;
        }
		// Sets or reads the SDR-1000 Audio Gain control 
		public string ZZAG(string s)
		{
			int af = 0;

			if(s.Length == parser.nSet)	// if the length of the parameter legal for setting this prefix
			{
				af = Convert.ToInt32(s);
				af = Math.Max(0, af);
				af = Math.Min(100, af);
				console.AF = af;		// Set the console control
                console.TitleBarEncoderString = "master AF Gain = " + af + "%";
				return "";
			}
			else if(s.Length == parser.nGet)	// if this is a read command
			{
				return AddLeadingZeros(console.AF);		// Get the console setting
			}
			else
			{
				return parser.Error1;	// return a ?
			}

		}

		public string ZZAI(string s)
		{
			if(console.SetupForm.AllowFreqBroadcast)
			{
				if(s.Length == parser.nSet)
				{
					if(s == "0")
						console.KWAutoInformation = false;
					else 
						console.KWAutoInformation = true;
					return "";
				}
				else if(s.Length == parser.nGet)
				{
					if(console.KWAutoInformation)
						return "1";
					else
						return "0";
				}
				else
					return parser.Error1;
			}
			else
				return parser.Error1;
		}

        //-W2PA Sets or reads the APF button on/off status
        public string ZZAP(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                if (s == "0")
                    console.CATAPF = 0;
                else if (s == "1")
                    console.CATAPF = 1;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                //return console.APFbtn;
                if (console.CATAPF == 1) return "1";
                else return "0";
            }
            else
            {
                return parser.Error1;
            }
        }

		//Sets or reads the AGC RF gain
		public string ZZAR(string s)
		{
			int n = 0;
			int x = 0;
			string sign;

			if(s != "")
			{
				n = Convert.ToInt32(s);
				n = Math.Max(-20, n);
				n = Math.Min(120, n);
			}

            if (s.Length == parser.nSet)
			{
				if (console.RF != n && console.AutoAGCRX1) console.AutoAGCRX1 = false; // turn off 'auto agc' only if different MW0LGE_21k8
				console.RF = n;
                console.TitleBarEncoderString = "RX1 AGC Threshold = " + n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				x = console.RF;
				if(x >= 0)
					sign = "+";
				else
					sign = "-";
				// we have to remove the leading zero and replace it with the sign.
                return sign + (AddLeadingZeros(Math.Abs(x))).Substring(1);
            }
			else
			{
				return parser.Error1;
			}

		}

        //Sets or reads the RX2 AGC-T
        public string ZZAS(string s)
        {
                int n = 0;
                int x = 0;
                string sign;

                if (s != "")
                {
                    n = Convert.ToInt32(s);
                    n = Math.Max(-20, n);
                    n = Math.Min(120, n);
                }

            if (s.Length == parser.nSet)
                {
					if (console.RX2RF != n && console.AutoAGCRX2) console.AutoAGCRX2 = false; // turn off 'auto agc' only if different MW0LGE_21k8
					console.RX2RF = n;
                    console.TitleBarEncoderString = "RX2 AGC Threshold = " + n;
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    x = console.RX2RF;
                    if (x >= 0)
                        sign = "+";
                    else
                        sign = "-";
                    // we have to remove the leading zero and replace it with the sign.
                    return sign + AddLeadingZeros(Math.Abs(x)).Substring(1);
                }
                else
                    return parser.Error1;
        }

        //-W2PA Sets or reads the APF tune
        public string ZZAT(string s)
        {
            int n = 0;
            int x = 0;
            string sign;

            if (s != "")
            {
                n = Convert.ToInt32(s);
                n = Math.Max(-250, n);
                n = Math.Min(250, n);
            }

            if (s.Length >= parser.nSet)
            {
                console.APFFreq = n;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                x = console.APFFreq;
                if (x >= 0)
                    sign = "+";
                else
                    sign = "-";
                // we have to remove the leading zero and replace it with the sign.
                return sign + AddLeadingZeros(Math.Abs(x)).Substring(1);
            }
            else
            {
                return parser.Error1;
            }

        }

        //Sets VFO A up nn Tune Steps
        public string ZZAU(string s)
        {
            int step = 0;
            if (s.Length == parser.nSet)
            {
                step = Convert.ToInt32(s);
                if (step >= 0 || step <= 14)
                {
                    console.VFOAFreq = console.CATVFOA + Step2Freq(step);
                    return "";
                }
                else
                    return parser.Error1;
            }
            else
                return parser.Error1;
        }

        //Moves the RX2 bandswitch down one band
        public string ZZBA()
        {
                console.CATRX2BandUpDown(-1);
                return "";
       }

        //Moves the RX2 bandswitch up one band
        public string ZZBB()
        {
               console.CATRX2BandUpDown(1);
                return "";
         }


		//Moves the RX1 bandswitch down one band
		public string ZZBD()
		{
			BandDown();
			return "";
		}

        //Sets VFO B down nn Pre-set Tune Steps
        public string ZZBE(string s)
        {
            int step = console.TuneStepIndex;
            int numsteps;
            double stepFreq;

            List<TuneStep> tune_list = console.TuneStepList;
            stepFreq = tune_list[step].StepHz * 10e-7;
            if (s.Length == parser.nSet)
            {
                numsteps = Convert.ToInt32(s);
                if (numsteps >= 0 && step <= 99)
                {
                    console.VFOBFreq = console.CATVFOB - stepFreq * (double)numsteps;
                    return "";
                }
                else
                    return parser.Error1;
            }
            else
                return parser.Error1;
        }

        //Sets VFO B up nn pre-set Steps
        public string ZZBF(string s)
        {
            int step = console.TuneStepIndex;
            int numsteps;
            double stepFreq;

            List<TuneStep> tune_list = console.TuneStepList;
            stepFreq = tune_list[step].StepHz * 10e-7;
            if (s.Length == parser.nSet)
            {
                numsteps = Convert.ToInt32(s);
                if (numsteps >= 0 && step <= 99)
                {
                    console.VFOBFreq = console.CATVFOB + stepFreq * (double)numsteps;
                    return "";
                }
                else
                    return parser.Error1;
            }
            else
                return parser.Error1;
        }
		// Sets the Band Group (HF/VHF)
		public string ZZBG(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				console.CATBandGroup = Convert.ToInt32(s);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATBandGroup.ToString();
			}
			else
			{
				return parser.Error1;
			}
		}

		// Sets or reads the BIN button status
		public string ZZBI(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				console.CATBIN = Convert.ToInt32(s);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATBIN.ToString();
			}
			else
			{
				return parser.Error1;
			}
		}

        //Sets VFO B down nn Tune Steps
        public string ZZBM(string s)
        {
            int step;
            if (s.Length == parser.nSet)
            {
                step = Convert.ToInt32(s);
                if (step >= 0 || step <= 14)
                {
                    console.VFOBFreq = console.CATVFOB - Step2Freq(step);
                    return "";
                }
                else
                    return parser.Error1;
            }
            else
                return parser.Error1;
        }

        //Sets VFO B up nn Tune Steps
        public string ZZBP(string s)
        {
            int step;
            if (s.Length == parser.nSet)
            {
                step = Convert.ToInt32(s);
                if (step >= 0 || step <= 14)
                {
                    console.VFOBFreq = console.CATVFOB + Step2Freq(step);
                    return "";
                }
                else
                    return parser.Error1;
            }
            else
                return parser.Error1;
        }

		//Sets or reads the BCI Rejection button status
		public string ZZBR(string s)
		{
			if(console.CurrentHPSDRModel == HPSDRModel.HPSDR)
			{
				int sx = 0;

				if(s != "")
					sx = Convert.ToInt32(s);

				if(s.Length == parser.nSet && (s == "0" || s == "1"))
				{
					console.CATBCIReject = sx;
					return "";
				}
				else if(s.Length == parser.nGet)
				{
					return console.CATBCIReject.ToString();
				}
				else
				{
					return parser.Error1;
				}
			}
			else
				return parser.Error1;

		}


		//Sets or reads the current band setting
		public string ZZBS(string s)
		{
			return GetBand(s);
		}

        //Sets or gets the current RX2 band setting
        public string ZZBT(string s)
        {
            if (s.Length == parser.nGet)
            {
                return Band2String(console.RX2Band);
            }
            else if (s.Length == parser.nSet)
            {
				Band b = String2Band(s);

				console.RX2Band = b;
                console.SetupRX2Band(b); // MW0LGE_21g
                return "";
            }
            else
                return parser.Error1;
         }

  
		//Moves the bandswitch up one band
		public string ZZBU()
		{
			BandUp();
			return "";
		}

        //Shuts down the console
        public string ZZBY()
        {
			if (console.InvokeRequired) //[2.10.3.6]MW0LGE Fixes #460 - needed as Midi is from another thread
			{
                console.BeginInvoke(new MethodInvoker(() =>
                {
                    console.Close();
                }));
            }
			else	
				console.Close();
            return "";
        }

		// Sets or reads the CW Break In Enabled checkbox
		public string ZZCB(string s)
		{
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                console.CATBreakIn = Convert.ToInt32(s);
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return console.CATBreakIn.ToString();
            }
            else
            {
                return parser.Error1;
            }

        }


        // Sets or reads the CW Break In Delay
        public string ZZCD(string s)
		{
			int n = 0;

			if(s != null && s != "")
				n = Convert.ToInt32(s);
			n = Math.Max(150, n);
			n = Math.Min(5000, n);

			if(s.Length == parser.nSet)
			{
				console.SetupForm.BreakInDelay = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return AddLeadingZeros((int) console.SetupForm.BreakInDelay);
			}
			else
			{
				return parser.Error1;
			}

		}

		// Sets or reads the Show CW Frequency checkbox
		public string ZZCF(string s)
		{
			switch(console.RX1DSPMode)
			{
				case DSPMode.CWL:
				case DSPMode.CWU:
					if(s.Length == parser.nSet && (s == "0" || s == "1"))
					{
						if(s == "1")
							console.ShowCWTXFreq = true;
						else
							console.ShowCWTXFreq = false;
						return "";
					}
					else if(s.Length == parser.nGet)
					{
						if(console.ShowCWTXFreq)
							return "1";
						else
							return "0";
					}
					else
					{
						return parser.Error1;
					}
				default:
					return parser.Error1;
			}
		}

		// Sets or reads the CW Iambic checkbox
		public string ZZCI(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if(s == "1")
					console.CWIambic = true;
				else
					console.CWIambic = false;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				if(console.CWIambic)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}

		}

		// Sets or reads the CW Pitch thumbwheel
		public string ZZCL(string s)
		{
			int n = 0;
			if(s != "")
				n = Convert.ToInt32(s);

			if(s.Length == parser.nSet)
			{
				console.SetupForm.CATCWPitch = n;
                console.TitleBarEncoderString = "CW Sidetone Freq = " + n + "Hz";
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return AddLeadingZeros(console.SetupForm.CATCWPitch);
			}
			else
			{
				return parser.Error1;
			}
		}

		// Sets or reads the CW Monitor Disable button status
		public string ZZCM(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if(s == "1")
					console.CWSidetone = false;
				else
					console.CWSidetone = true;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				if(console.CWSidetone)
					return "0";
				else
					return "1";
			}
			else
			{
				return parser.Error1;
			}

		}

        //Sets or reads CTUN for RX1
        public string ZZCN(string s)
        {
            if (s.Length == parser.nSet)
            {
                if (s == "1")
                {
                    console.CTuneDisplay = true;
                    return "";
                }
                else if (s == "0")
                {
                    console.CTuneDisplay = false;
                    return "";
                }
                else
                    return parser.Error1;
            }
            else if (s.Length == parser.nGet)
            {
                if (console.CTuneDisplay)
                   return "1";
                  else
                return "0";
            }
            else
                return parser.Error1;
        }

        //Sets or reads CTUN for RX2
        public string ZZCO(string s)
        {
            if (s.Length == parser.nSet)
            {
                if (s == "1")
                {
                    console.CTuneRX2Display = true;
                    return "";
                }
                else if (s == "0")
                {
                    console.CTuneRX2Display = false;
                    return "";
                }
                else
                    return parser.Error1;
            }
            else if (s.Length == parser.nGet)
            {
                if (console.CTuneRX2Display)
                    return "1";
                else
                    return "0";
            }
            else
                return parser.Error1;
        }
        // Sets or reads the compander button status
		public string ZZCP(string s)
		{
			if(s.Length == parser.nSet)
			{
				if(s == "0")
					console.CATCmpd = 0;
				else if(s == "1")
					console.CATCmpd = 1;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATCmpd.ToString();
			}
			else
			{
				return parser.Error1;
			}
		}

		// Sets or reads the CW Speed thumbwheel
		public string ZZCS(string s)
		{
			int n = 1;

			if(s != "")
				n = Convert.ToInt32(s);

			if(s.Length == parser.nSet)
			{
				console.CATCWSpeed = n;
                console.TitleBarEncoderString = "CW Speed = " + n + "WPM";
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return AddLeadingZeros(console.CATCWSpeed);
			}
			else
			{
				return parser.Error1;
			}
		}

		//Reads or sets the compander threshold
		public string ZZCT(string s)
		{
			int n = 0;

			if(s != null && s != "")
				n = Convert.ToInt32(s);
			n = Math.Max(console.CPDRMin, n); //[2.10.3.6]MW0LGE was 0
			n = Math.Min(console.CPDRMax, n); //was 20

            if (s.Length == parser.nSet)
			{
				console.CPDRLevel = n;
                console.TitleBarEncoderString = "Comp Threshold = " + n + "dB";
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return AddLeadingZeros((int) console.CPDRLevel);
			}
			else
			{
				return parser.Error1;
			}
		}

		// Reads the CPU Usage
		public string ZZCU()
		{
			//return parser.Error1;
			if (console.initializing) return "";
            return String.Format("{0:000.00}", console.total_cpu_usage.NextValue());
		}

		// Sets or reads the Display Average status
		public string ZZDA(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				console.CATDisplayAvg = Convert.ToInt32(s);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATDisplayAvg.ToString();
			}
			else
			{
				return parser.Error1;
			}

		}


        //Sets or reads the Diversity Form RX Reference radio buttons
        public string ZZDB(string s)
        {
            if (s.Length == parser.nSet)
            {
                if (s == "1")
                {
                    console.CATDiversityRXRefSource = true;
                    return "";
                }
                else if (s == "0")
                {
                    console.CATDiversityRXRefSource = false;
                    return "";
                }
                else
                    return parser.Error1;
            }
            else if (s.Length == parser.nGet)
            {
                if (console.CATDiversityRXRefSource)
                    return "1";
                else
                    return "0";
            }
            else
                return parser.Error1;
        }


        //Sets or reads the Diversity Form RX2 gain
        public string ZZDC(string s)
        {
            decimal gain;
            int n = 0;
            if (s.Length == parser.nSet)
            {
                if (s != null && s != "")
                    n = Convert.ToInt32(s);
                n = Math.Max(0, n);
                n = Math.Min(5000, n);
                gain = (decimal)n / 1000.0m;
                console.CATDiversityRX2Gain = gain;
                console.TitleBarEncoderString = "Diversity RX2 Gain = " + gain;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                gain = console.CATDiversityRX2Gain;
                n = (int)(gain * 1000.0m);
                return AddLeadingZeros(n);
            }
            else
                return parser.Error1;
        }


        //Sets or reads the Diversity Form phase
        public string ZZDD(string s)
        {
            decimal phase;
            int n = 0;
            string sign;
            if (s.Length == parser.nSet)
            {
                if (s != null && s != "")
                    n = Convert.ToInt32(s);
                n = Math.Min(18000, n);
                n = Math.Max(-18000, n);
                phase = (decimal)n / 100.0m;
                console.TitleBarEncoderString = "Diversity Phase = " + phase + "degrees";
                console.CATDiversityPhase = phase;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                phase = console.CATDiversityPhase;
                n = (int)(phase * 100.0m);
                if (n < 0)
                    sign = "-";
                else
                    sign = "+";

                return sign + AddLeadingZeros(Math.Abs(n)).Substring(1);
            }
            else
                return parser.Error1;
        }



        //Sets or reads the Diversity Form Enable Button
        public string ZZDE(string s)
        {
                if (s.Length == parser.nSet)
                {
                    if (s == "1")
                    {
                    console.CATDiversityEnable = true;
                        return "";
                    }
                    else if (s == "0")
                    {
                    console.CATDiversityEnable = false;
                        return "";
                    }
                    else
                        return parser.Error1;
                }
                else if (s.Length == parser.nGet)
                {
                if (console.CATDiversityEnable)
                    return "1";
                else
                        return "0";
                }
                else
                    return parser.Error1;            
        } 


        //Opens or closes the Diversity Form
        public string ZZDF(string s)
        {
                 if (s.Length == parser.nSet)
                {
                    if (s == "1")
                    {
                        console.CATDiversityForm = true;
                        return "";
                    }
                    else if (s == "0")
                    {
                        console.CATDiversityForm = false;
                        return "";
                    }
                    else
                        return parser.Error1;
                }
                else if (s.Length == parser.nGet)
                {
                    if (console.CATDiversityForm)
                        return "1";
                    else
                        return "0";
                }
                else
                    return parser.Error1;
        }

        //Sets or reads the Diversity Form RX gain
        public string ZZDG(string s)
        {
            decimal gain;
            int n = 0;
            if (s.Length == parser.nSet)
            {
                if (s != null && s != "")
                    n = Convert.ToInt32(s);
                n = Math.Max(0, n);
                n = Math.Min(1000, n);
                gain = (decimal)n / 1000.0m;
                console.CATDiversityGain = gain;
                console.TitleBarEncoderString = "Diversity RX Gain = " + gain;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                gain = console.CATDiversityGain;
                n = (int)(gain * 1000.0m);
                return AddLeadingZeros(n);
            }
            else
                return parser.Error1;
        }

        //Sets or reads the Diversity Form RX Source radio buttons
        public string ZZDH(string s)
        {
            if (s.Length == parser.nSet)
            {
                if (s == "2")
                {
                    console.CATDiversityRXSource = 2;
                    return "";
                }
                else if (s == "1")
                {
                    console.CATDiversityRXSource = 1;
                    return "";
                }
                else if (s == "0")
                {
                    console.CATDiversityRXSource = 0;
                    return "";
                }
                else
                    return parser.Error1;
            }
            else if (s.Length == parser.nGet)
            {
                if (console.CATDiversityRXSource == 2)
                    return "2";
                else if (console.CATDiversityRXSource == 1)
                    return "1";
                else
                    return "0";
            }
            else
                return parser.Error1;
        }


		// Sets or reads the current display mode
		public string ZZDM(string s)
		{
			int n = -1;

			if(s.Length == parser.nSet)
			{
				n = Convert.ToInt32(s);
				switch(n)
				{
					case 0:
						console.DisplayModeText = "Spectrum";
						break;
					case 1:
						console.DisplayModeText = "Panadapter";
						break;
					case 2:
						console.DisplayModeText = "Scope";
						break;
					case 3:
						console.DisplayModeText = "Phase";
						break;
					case 4:
						console.DisplayModeText = "Phase2";
						break;
					case 5:
						console.DisplayModeText = "Waterfall";
						break;
					case 6:
						console.DisplayModeText = "Histogram";
						break;
                    case 7:
                        console.DisplayModeText = "Panafall";
                        break;
                    case 8:
                        console.DisplayModeText = "Panascope";
                        break;
					case 9:
						console.DisplayModeText = "Off";
						break;

				}

				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return ((int) Display.CurrentDisplayMode).ToString();
			}
			else
			{
				return parser.Error1;
			}

		}

        //Reads or sets the setup form Waterfall Low value
        public string ZZDN(string s)
        {
            int n = 0;
            int x = 0;
            string sign;

            if (s != "")
                n = Convert.ToInt32(s);

            if (s.Length == parser.nSet)
            {
                console.SetupForm.CATWFLo = n;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                x = console.SetupForm.CATWFLo;
                if (x >= 0)
                    sign = "+";
                else
                    sign = "-";
                // we have to remove the leading zero and replace it with the sign.
                return sign + AddLeadingZeros(Math.Abs(x)).Substring(1);
            }
            else
            {
                return parser.Error1;
            }
        }

        //Reads or sets the setup form Waterfall High value
        public string ZZDO(string s)
        {
            int n = 0;
            int x = 0;
            string sign;

            if (s != "")
                n = Convert.ToInt32(s);

            if (s.Length == parser.nSet)
            {
                console.SetupForm.CATWFHi = n;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                x = console.SetupForm.CATWFHi;
                if (x >= 0)
                    sign = "+";
                else
                    sign = "-";
                // we have to remove the leading zero and replace it with the sign.
                return sign + AddLeadingZeros(Math.Abs(x)).Substring(1);
            }
            else
            {
                return parser.Error1;
            }
        }


        //Reads or sets the setup form Spectrum Grid Max Value
        public string ZZDP(string s)
        {
            int n = 0;
            int x = 0;
            string sign;

            if (s != "")
                n = Convert.ToInt32(s);

            if (s.Length == parser.nSet)
            {
                console.SetupForm.CATSGMax = n;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                x = console.SetupForm.CATSGMax;
                if (x >= 0)
                    sign = "+";
                else
                    sign = "-";
                // we have to remove the leading zero and replace it with the sign.
                return sign + AddLeadingZeros(Math.Abs(x)).Substring(1);
            }
            else
            {
                return parser.Error1;
            }
        }

        //Reads or sets the setup form Spectrum Grid Min Value
        public string ZZDQ(string s)
        {
            int n = 0;
            int x = 0;
            string sign;

            if (s != "")
                n = Convert.ToInt32(s);

            if (s.Length == parser.nSet)
            {
                console.SetupForm.CATSGMin = n;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                x = console.SetupForm.CATSGMin;
                if (x >= 0)
                    sign = "+";
                else
                    sign = "-";
                // we have to remove the leading zero and replace it with the sign.
                return sign + AddLeadingZeros(Math.Abs(x)).Substring(1);
            }
            else
            {
                return parser.Error1;
            }
        }

        // Sets or reads the Spectrum Grid Step
        public string ZZDR(string s)
        {
            if (s.Length == parser.nSet)
            {
                console.SetupForm.CATSGStep = Convert.ToInt32(s);
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return AddLeadingZeros(console.SetupForm.CATSGStep);
            }
            else
            {
                return parser.Error1;
            }

        }
     
        //Constructs the state word for DDUtil
        //read only
        public string ZZDU()
        {
            int old = parser.nAns;
            string sep = ":";
            string status = "";

            parser.nAns = 1;
            status += ZZSW("") + sep; // swap VFOA/B
            status += ZZSP("") + sep; // VFO Split status
            status += ZZTU("") + sep; // TUN button status
            status += ZZTX("") + sep; // MOX button status
           // status += ZZOA("") + sep;
           // status += ZZOB("") + sep;
           // status += ZZOC("") + sep;
            status += "0:0:0:";

            status += ZZRS("") + sep; // RX2 button status
            status += ZZRT("") + sep; // RIT button status
            status += ZZDM("") + sep; // current display mode
            status += ZZGT("") + sep; // AGC constant
            status += ZZMU("") + sep; // MultiRx status
            status += ZZXS("") + sep; // XIT status

            parser.nAns = 2;
            status += ZZAC("") + sep; // tuning step size
            status += ZZMD("") + sep; // RX1 DSP mode
            status += ZZME("") + sep; // RX2 DSP mode
            status += ZZFJ("") + sep; // RX2 DSP filter
            status += ZZFI("") + sep; // RX1 filter index

            parser.nAns = 3;
           // status += ZZOF("") + sep;
            status += "000:";
            status += ZZBT("") + sep; // RX2 band
            status += ZZPC("") + sep; // Drive level
            status += ZZBS("") + sep; // current band Rx1
            status += ZZAG("") + sep; // AF gain control
            status += ZZKS("") + sep; // CWX CW speed
            status += ZZTO("") + sep; // Tune power level
          
            parser.nAns = 4;
           // status += ZZRV() + sep;
            status += "0000:";
            status += ZZSM("0") + sep; // S meter value

            parser.nAns = 5;
            status += ZZRF("") + sep; // RIT frequency
           // status += ZZTS() + sep;
            status += "00000:";
            status += ZZXF("") + sep; // XIT frequency

            parser.nAns = 6;
            status += ZZCU() + sep; // CPU usage

            parser.nAns = 11;
            status += ZZFA("") + sep; // VFOA frequency
            status += ZZFB(""); // VFOB frequency
            parser.nAns = old;
            return status;
        } 


		/// <summary>
		/// Sets or reads the DX button status
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public string ZZDX(string s)
		{
			if(s.Length == parser.nSet)
			{
				console.CATPhoneDX = s;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATPhoneDX;
			}
			else
				return parser.Error1;
		}

		//MW0LGE_22b
		////Reads or sets the DX threshold
		//public string ZZDY(string s)
		//{
		//    int n = 0;

		//    if (s != null && s != "")
		//        n = Convert.ToInt32(s);
		//    n = Math.Max(0, n);
		//    n = Math.Min(10, n);

		//    if (s.Length == parser.nSet)
		//    {
		//        console.DXLevel = n;
		//        return "";
		//    }
		//    else if (s.Length == parser.nGet)
		//    {
		//        return AddLeadingZeros((int)console.DXLevel);
		//    }
		//    else
		//    {
		//        return parser.Error1;
		//    }

		//}

		/// <summary>
		/// Reads or sets the RX equalizer.
		/// The CAT suffix string is 36 characters constant.
		/// Each value in the string occupies exactly three characters
		/// starting with the number of bands (003 or 010) followed by
		/// the preamp setting (-12 to 015) followed by 3 or 10 three digit
		/// EQ thumbwheel positions.  If the number of bands is 3, the
		/// last seven positions (21 characters) are all set to zero.
		/// Example:  10 band ZZEA010-09009005000-04-07-09-05000005009;
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public string ZZEA(string s)
		{
			if(s.Length == parser.nSet)
			{
				int nb = Int32.Parse(s.Substring(0,3));			//Get the number of bands
				int[] ans = new	int[nb+1];						//Create the integer array
				s = s.Remove(0,3);								//Get rid of the band count

				for(int x = 0; x <= nb;x++)						//Parse the string into the array
				{
					ans[x] = Int32.Parse(s.Substring(0,3));
					s = s.Remove(0,3);							//Remove the last three used
				}
				console.EQForm.RXEQ = ans;						//Send the array to the eq form
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				int[] eqarray = console.EQForm.RXEQ;			//Get the equalizer array
				int nb = console.EQForm.NumBands;				//Get the number of bands in the array
				int val;										//Holds a temporary value
				string ans = nb.ToString().PadLeft(3,'0');		//The return string with the number of bands added

				for (int x = 0; x <= nb; x++)					//Loop thru the array
				{
					if(eqarray[x] < 0)	
					{
						val = Math.Abs(eqarray[x]);					//If the value is negative, format the answer
						ans += "-"+val.ToString().PadLeft(2,'0');
					}
					else
						ans += eqarray[x].ToString().PadLeft(3,'0');
				}
				ans = ans.PadRight(36,'0');							//Add the padding if it's a 3 band eq
				return ans;
			}
			else
				return parser.Error1;
		}

		//Sets or reads the TX EQ settings
		public string ZZEB(string s)
		{
			if(s.Length == parser.nSet)
			{
				int nb = Int32.Parse(s.Substring(0,3));			//Get the number of bands
				int[] ans = new	int[nb+1];						//Create the integer array
				s = s.Remove(0,3);								//Get rid of the band count

				for(int x = 0; x <= nb;x++)						//Parse the string into the array
				{
					ans[x] = Int32.Parse(s.Substring(0,3));
					s = s.Remove(0,3);							//Remove the last three used
				}
				console.EQForm.TXEQ = ans;						//Send the array to the eq form
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				int[] eqarray = console.EQForm.TXEQ;			//Get the equalizer array
				int nb = console.EQForm.NumBands;				//Get the number of bands in the array
				int val;										//Holds a temporary value
				string ans = nb.ToString().PadLeft(3,'0');		//The return string with the number of bands added

				for (int x = 0; x <= nb; x++)					//Loop thru the array
				{
					if(eqarray[x] < 0)	
					{
						val = Math.Abs(eqarray[x]);					//If the value is negative, format the answer
						ans += "-"+val.ToString().PadLeft(2,'0');
					}
					else
						ans += eqarray[x].ToString().PadLeft(3,'0');
				}
				ans = ans.PadRight(36,'0');							//Add the padding if it's a 3 band eq
				return ans;
			}
			else
				return parser.Error1;
		}

        //Provides verbose CAT error reporting
        public string ZZEM(string s)
        {
            if (s.Length == parser.nSet && (s == "1" || s == "0"))
            {
                if (s == "1")
                    parser.Verbose = true;
                else
                    parser.Verbose = false;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                if (parser.Verbose)
                    return "1";
                else
                    return "0";
            }
            else
                return parser.Error1;
        }


		//Sets or reads the RXEQ button statusl
		public string ZZER(string s)
		{
			if(s.Length == parser.nSet  && (s == "1" || s == "0"))
			{
				if(s == "1")
					console.CATRXEQ = "1";
				else if(s == "0")
					console.CATRXEQ = "0";
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATRXEQ;
			}
			else
				return parser.Error1;
		}

		//Sets or reads the TXEQ button status
		public string ZZET(string s)
		{
			if(s.Length == parser.nSet  && (s == "1" || s == "0"))
			{
				if(s == "1")
					console.CATTXEQ = "1";
				else if(s == "0")
					console.CATTXEQ = "0";
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATTXEQ;
			}
			else
				return parser.Error1;
		}

        public bool isMidi = false;
        public bool isMidi2 = false;
		//Sets or reads VFO A frequency
		public string ZZFA(string s)
		{
			if(s.Length == parser.nSet)
			{
				if(console.SetupForm.RttyOffsetEnabledA && 
					(console.RX1DSPMode == DSPMode.DIGU || console.RX1DSPMode == DSPMode.DIGL))
				{
					int f = int.Parse(s);
					if(console.RX1DSPMode == DSPMode.DIGU)
						f -= Convert.ToInt32(console.SetupForm.RttyOffsetHigh);
					else if(console.RX1DSPMode == DSPMode.DIGL)
						f += Convert.ToInt32(console.SetupForm.RttyOffsetLow);
					s = AddLeadingZeros(f);
					s = s.Insert(5, separator);
				}
				else
					s = s.Insert(5, separator);

                if (!isMidi && console.CATChangesCenterFreq) // MW0LGE changed to take into consideration the flag
                    console.UpdateCenterFreq = true;
				console.VFOAFreq = double.Parse(s);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				if(console.SetupForm.RttyOffsetEnabledA &&
					(console.RX1DSPMode == DSPMode.DIGU || console.RX1DSPMode == DSPMode.DIGL))
				{
                    int f = Convert.ToInt32(Math.Round(console.CATVFOA, 6) * 1e6);
					if(console.RX1DSPMode == DSPMode.DIGU)
						f += Convert.ToInt32(console.SetupForm.RttyOffsetHigh);
					else if(console.RX1DSPMode == DSPMode.DIGL)
						f -= Convert.ToInt32(console.SetupForm.RttyOffsetLow);
					return AddLeadingZeros(f);
				}
				else
					return StrVFOFreq("A");
			}
			else
				return parser.Error1;

		}

		//Sets or reads VFO B frequency
		public string ZZFB(string s)
		{
			if(s.Length == parser.nSet)
			{
				if(console.SetupForm.RttyOffsetEnabledB  && 
					(console.RX1DSPMode == DSPMode.DIGU || console.RX1DSPMode == DSPMode.DIGL))
				{
					int f = int.Parse(s);
					if(console.RX1DSPMode == DSPMode.DIGU)
						f -= Convert.ToInt32(console.SetupForm.RttyOffsetHigh);
					else if(console.RX1DSPMode == DSPMode.DIGL)
						f += Convert.ToInt32(console.SetupForm.RttyOffsetLow);
					s = AddLeadingZeros(f);
					s = s.Insert(5, separator);
				}
				else
					s = s.Insert(5, separator);

                if (!isMidi2 && console.CATChangesCenterFreq) // MW0LGE changed to take into consideration the flag
                    console.UpdateRX2CenterFreq = true;
				console.VFOBFreq = double.Parse(s);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				if(console.SetupForm.RttyOffsetEnabledB &&
					(console.RX1DSPMode == DSPMode.DIGU || console.RX1DSPMode == DSPMode.DIGL))
				{
                    int f = Convert.ToInt32(Math.Round(console.CATVFOB, 6) * 1e6);
					if(console.RX1DSPMode == DSPMode.DIGU)
						f += Convert.ToInt32(console.SetupForm.RttyOffsetHigh);
					else if(console.RX1DSPMode == DSPMode.DIGL)
						f -= Convert.ToInt32(console.SetupForm.RttyOffsetLow);
					return AddLeadingZeros(f);
				}
				else
					return StrVFOFreq("B");
			}
			else
				return parser.Error1;		
		}
		//Sets or reads TX frequency
		public string ZZFT(string s)
		{
			if (s.Length == parser.nSet)
			{
				console.TXFreq = double.Parse(s);
				return "";
			}
			else if (s.Length == parser.nGet)
			{
				int f = Convert.ToInt32(Math.Round(console.TXFreq, 6) * 1e6);
				return AddLeadingZeros(f);
			}
			else
				return parser.Error1;

		}

		//Selects or reads the FM deviation radio button
		public string ZZFD(string s)
        {
            if (s.Length == parser.nSet)
            {
                if (s == "1")
                    console.FMDeviation_Hz = 5000;
                else
                    console.FMDeviation_Hz = 2500;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                if (console.FMDeviation_Hz == 5000)
                    return "1";
                else if (console.FMDeviation_Hz == 2500)
                    return "0";
                else
                    return parser.Error1;
            }
            else
                return parser.Error1;
        }


		//Sets or reads the current filter index number
		public string ZZFI(string s)
		{
			int n = 0;

			if(s != "")
				n = Convert.ToInt32(s);

			if(s.Length == parser.nSet)
			{
				if(n < (int) Filter.LAST)
					console.RX1Filter = (Filter) n;
				else
					return parser.Error1;

				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return AddLeadingZeros((int) console.RX1Filter);
			}
			else
			{
				return parser.Error1;
			}
		}

        //Sets or reads the current RX2 DSP filter
        public string ZZFJ(string s)
        {
                int n = 0;
                if (s != "")
                    n = Convert.ToInt32(s);

                if (s.Length == parser.nSet)
                {
                    if (n < (int)Filter.LAST)
                        console.RX2Filter = (Filter)n;
                    else
                        return parser.Error1;
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    return AddLeadingZeros((int)console.RX2Filter);
                }
                else
                    return parser.Error1;
         }

		/// <summary>
		/// Reads or sets the DSP Filter Low value
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public string ZZFL(string s)
		{
			string sign;
			int n;

			if(s.Length == parser.nSet)
			{
                console.SelectRX1VarFilter();  //-W2PA Transfer focus to VAR1                                                               
				n = Convert.ToInt32(s);
				n = Math.Min(10000, n);
				n = Math.Max(-10000, n);
				console.RX1FilterLow = n;
                console.TitleBarEncoderString = "VFO A Filter low cut = " + n + "Hz";
				console.UpdateRX1Filters(n, console.RX1FilterHigh, true, false);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				n = console.RX1FilterLow;
				if(n < 0)
					sign = "-";
				else
					sign = "+";

				// we have to remove the leading zero and replace it with the sign.
				return sign+AddLeadingZeros(Math.Abs(n)).Substring(1);
//				return AddLeadingZeros((int) console.RX1FilterLow);
			}
			else
				return parser.Error1;
		}

		/// <summary>
		/// Reads or sets the DSP Filter High value
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public string ZZFH(string s)
		{
			string sign;
			int n;

			if(s.Length == parser.nSet)
				{
                    console.SelectRX1VarFilter();  //-W2PA Transfer focus to VAR1                                                             
					n = Convert.ToInt32(s);
					n = Math.Min(10000, n);
					n = Math.Max(-10000, n);
					console.RX1FilterHigh = n;
                    console.TitleBarEncoderString = "VFO A Filter high cut = " + n + "Hz";
					console.UpdateRX1Filters(console.RX1FilterLow, n, true, false);
					return "";
				}
				else if(s.Length == parser.nGet)
				{
					n = console.RX1FilterHigh;
					if(n < 0)
						sign = "-";
					else
						sign = "+";

					// we have to remove the leading zero and replace it with the sign.
					return sign+AddLeadingZeros(Math.Abs(n)).Substring(1);
				}
				else
					return parser.Error1;
		}

		public string ZZFM()
		{
			string radio = console.CurrentHPSDRModel.ToString();
            bool alex_att = console.AlexPresent;

            if (radio == "HPSDR" || radio == "HERMES")
            {
                if (alex_att) return "1";
                else return "0";
            }

            else if (radio == "ANAN10" || radio == "ANAN10E")
                return "0";

            else if (radio == "ANAN100" || radio == "ANAN100B" || radio == "ANAN100D" || radio == "ANAN200D" || radio == "ANAN7000D" || radio == "ANAN8000D" || radio == "ANVELINAPRO3" || radio == "ANAN_G2" || radio == "ANAN_G2_1K")  // DH1KLM_21a added 7000D
                return "1";
            else
                return parser.Error1;

		}

        /// <summary>
        /// Reads or sets the RX2 DSP Filter High value
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ZZFR(string s)
        {
            string sign;
            int n;

            if (s.Length == parser.nSet)
            {
                n = Convert.ToInt32(s);
                n = Math.Min(10000, n);
                n = Math.Max(-10000, n);
                console.RX2FilterHigh = n;
                console.TitleBarEncoderString = "VFO B Filter high cut = " + n + "Hz";
                console.UpdateRX2Filters(console.RX2FilterLow, n, true, false);
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                n = console.RX2FilterHigh;
                if (n < 0)
                    sign = "-";
                else
                    sign = "+";

                // we have to remove the leading zero and replace it with the sign.
                return sign + AddLeadingZeros(Math.Abs(n)).Substring(1);
            }
            else
                return parser.Error1;
        }


        /// <summary>
        /// Reads or sets the RX2 DSP Filter Low value
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ZZFS(string s)
        {
            string sign;
            int n;

            if (s.Length == parser.nSet)
            {
                n = Convert.ToInt32(s);
                n = Math.Min(10000, n);
                n = Math.Max(-10000, n);
                console.RX2FilterLow = n;
                console.TitleBarEncoderString = "VFO B Filter low cut =" + n + "Hz";
                console.UpdateRX2Filters(n, console.RX2FilterHigh, true, false);
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                n = console.RX2FilterLow;
                if (n < 0)
                    sign = "-";
                else
                    sign = "+";

                // we have to remove the leading zero and replace it with the sign.
                return sign + AddLeadingZeros(Math.Abs(n)).Substring(1);
            }
            else
                return parser.Error1;
        }

		//Reads FlexWire single byte value commands
		public string ZZFV(string s)
		{
			if(s.Length == parser.nGet)
			{
				String pattern = "^[a-fA-F0-9][a-fA-F0-9]$";
				Regex sfxpattern = new Regex(pattern);
				if(!sfxpattern.IsMatch(s))
					return parser.Error1;

				byte addr = byte.Parse(s, NumberStyles.HexNumber);
				uint val = 0;
				//FWC.FlexWire_ReadValue(addr, out val);
				string ans = String.Format("{0:X2}", (byte)val);
				return ans;
			}
			else
				return parser.Error1;
		}

		//Reds FlexWire double byte value commands
		public string ZZFW(String s)
		{
			if(s.Length == parser.nGet)
			{
				String pattern = "^[a-fA-F0-9][a-fA-F0-9]$";
				Regex sfxpattern = new Regex(pattern);
				if(!sfxpattern.IsMatch(s))
					return parser.Error1;

				byte addr = byte.Parse(s, NumberStyles.HexNumber);
				uint val = 0;
				//FWC.FlexWire_Read2Value(addr, out val);
				string ans1 = String.Format("{0:X2}", val>>8);
				string ans2 = String.Format("{0:X2}", (byte) val);
				string ans = String.Concat(ans1,ans2);
				return ans;
			
			}
			else
				return parser.Error1;
		}

		//Sends FlexWire single byte value commands
		public string ZZFX(string s)
		{
			if(s.Length == parser.nSet)
			{
				String pattern = "^[a-fA-F0-9][a-fA-F0-9][a-fA-F0-9][a-fA-F0-9]$";
				Regex sfxpattern = new Regex(pattern);
				if(!sfxpattern.IsMatch(s))
					return parser.Error1;

				byte addr = byte.Parse(s.Substring(0,2),NumberStyles.HexNumber);
				byte val = byte.Parse(s.Substring(2,2),NumberStyles.HexNumber);
				//FWC.FlexWire_WriteValue(addr, val);
				return "";
			}
			else
				return parser.Error1;
		}

		//Sends FlexWire double byte value commands
		public string ZZFY(String s)
		{
			if(s.Length == parser.nSet)
			{
				String pattern = "^[a-fA-F0-9][a-fA-F0-9][a-fA-F0-9][a-fA-F0-9][a-fA-F0-9][a-fA-F0-9]$";
				Regex sfxpattern = new Regex(pattern);
				if(!sfxpattern.IsMatch(s))
					return parser.Error1;

				byte addr = byte.Parse(s.Substring(0,2), NumberStyles.HexNumber);
				byte val1 = byte.Parse(s.Substring(2,2), NumberStyles.HexNumber);
				byte val2 = byte.Parse(s.Substring(4,2), NumberStyles.HexNumber);

				//FWC.FlexWire_Write2Value(addr, val1, val2);
				return "";
			
			}
			else
				return parser.Error1;
		}

		#endregion Extended CAT Methods ZZA-ZZF

		#region Extended CAT Methods ZZG-ZZM


		// Sets or reads the noise gate enable button status
		public string ZZGE(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if(s == "1")
					console.NoiseGateEnabled = true;
				else
					console.NoiseGateEnabled = false;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				if(console.NoiseGateEnabled)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}

		}

		//Sets or reads the noise gate level control
		public string ZZGL(string s)
		{
			int n = 0;
			int x = 0;
			string sign;

			if(s != "")
			{
				n = Convert.ToInt32(s);
				n = Math.Max(-160, n);
				n = Math.Min(0, n);
			}

			if(s.Length == parser.nSet)
			{
				console.NoiseGate = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				x = console.NoiseGate;
				if(x >= 0)
					sign = "+";
				else
					sign = "-";
				// we have to remove the leading zero and replace it with the sign.
				return sign+AddLeadingZeros(Math.Abs(x)).Substring(1);
			}
			else
			{
				return parser.Error1;
			}
		}

		// Sets or reads the AGC constant
		public string ZZGT(string s)
		{
			if(s.Length == parser.nSet)
			{
				if((Convert.ToInt32(s) > (int) AGCMode.FIRST && Convert.ToInt32(s) < (int) AGCMode.LAST))
					console.RX1AGCMode = (AGCMode) Convert.ToInt32(s);
				else
					return parser.Error1;

				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return ((int) console.RX1AGCMode).ToString();
			}
			else
			{
				return parser.Error1;
			}
		}

        // Sets or reads the RX2 AGC constant 
        public string ZZGU(string s)
        {
            if (s.Length == parser.nSet)
            {
                if ((Convert.ToInt32(s) > (int)AGCMode.FIRST && Convert.ToInt32(s) < (int)AGCMode.LAST))
                    console.RX2AGCMode = (AGCMode)Convert.ToInt32(s);
                else
                    return parser.Error1;

                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return ((int)console.RX2AGCMode).ToString();
            }
            else
            {
                return parser.Error1;
            }
        }
		// Sets or reads the Audio Buffer Size
		public string ZZHA(string s)
		{
		
			if(s.Length == parser.nSet)
			{
				console.SetupForm.AudioBufferSize = Index2Width(s);
				return "";
			}
			else if (s.Length == parser.nGet)
			{
				return Width2Index(console.SetupForm.AudioBufferSize);
			}
			else
				return parser.Error1;
		}

		//Sets or reads the DSP Phone RX Buffer Size
		public string ZZHR(string s)
		{
			if(s.Length == parser.nSet)
			{
				int width = Index2Width(s);
				console.DSPBufPhoneRX = width;
				console.SetupForm.DSPPhoneRXBuffer = width;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return Width2Index(console.DSPBufPhoneRX);
			}
			else
				return parser.Error1;
		}

		//Sets or reads the DSP Phone TX Buffer Size
		public string ZZHT(string s)
		{
			if(s.Length == parser.nSet)
			{
				int width = Index2Width(s);
				console.DSPBufPhoneTX = width;
				console.SetupForm.DSPPhoneTXBuffer = width;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return Width2Index(console.DSPBufPhoneTX);
			}
			else
				return parser.Error1;
		}

		//Sets or reads the DSP CW RX Buffer Size
		public string ZZHU(string s)
		{
			if(s.Length == parser.nSet)
			{
				int width = Index2Width(s);
				console.DSPBufCWRX = width;
				console.SetupForm.DSPCWRXBuffer = width;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return Width2Index(console.DSPBufCWRX);
			}
			else
				return parser.Error1;
		}

		//Sets or reads the DSP CW TX Buffer Size
		public string ZZHV(string s)
		{
			if(s.Length == parser.nSet)
			{
				int width = Index2Width(s);
				//console.DSPBufCWTX = width;
				//console.SetupForm.DSPCWTXBuffer = width;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return Width2Index(console.DSPBufCWRX);
			}
			else
				return parser.Error1;
		}

		//Sets or reads the DSP Digital RX Buffer Size
		public string ZZHW(string s)
		{
			if(s.Length == parser.nSet)
			{
				int width = Index2Width(s);
				console.DSPBufDigRX = width;
				console.SetupForm.DSPDigRXBuffer = width;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return Width2Index(console.DSPBufDigRX);
			}
			else
				return parser.Error1;
		}

		//Sets or reads the DSP Digital TX Buffer Size
		public string ZZHX(string s)
		{
			if(s.Length == parser.nSet)
			{
				int width = Index2Width(s);
				console.DSPBufDigTX = width;
				console.SetupForm.DSPDigTXBuffer = width;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return Width2Index(console.DSPBufDigTX);
			}
			else
				return parser.Error1;
		}

		// Sets the CAT Rig Type to SDR-1000
		//Modified 10/12/08 BT changed "SDR-1000" to "PowerSDR"
		public string ZZID()
		{
			//			if(s.Length == parser.nSet)
			//			{
			//				return CAT2RigType(s);
			//			}
			//			else if(s.Length == parser.nGet)
			//			{
			//				return RigType2CAT();
			//			}
			//			else
			//				return parser.Error1;
			console.SetupForm.CATSetRig("PowerSDR");
			return "";
		}

		// Reads the SDR-1000 transceiver status
		public string ZZIF(string s)
		{
			string rtn = "";
			string rit = "0";
			string xit = "0";
			string incr;
			string tx = "0";
			int ITValue = 0;

			// Get the rit/xit status
			if(console.RITOn)
				rit = "1";
			else if(console.XITOn)
				xit = "1";
			// Get the incremental tuning value for whichever control is selected
			if(rit == "1")
				ITValue = console.RITValue;
			else if(xit == "1")
				ITValue = console.XITValue;
			// Format the IT value
			if(ITValue < 0)
				incr = "-"+Convert.ToString(Math.Abs(ITValue)).PadLeft(5,'0');
			else
				incr = "+"+Convert.ToString(Math.Abs(ITValue)).PadLeft(5,'0');
			// Get the rx - tx status
			if(console.MOX)
				tx = "1";
			// Get the step size
            int step = console.TuneStepIndex;
			string stepsize =  Step2String(step);
			// Get the vfo split status
			string split = "0";
			bool retval = console.VFOSplit;
			if(retval)
				split = "1";

			string f = ZZFA("");
			if(f.Length > 11)
			{
				f = f.Substring(f.Length-11,11);
			}
			rtn += f;
//			rtn += StrVFOFreq("A");						// VFO A frequency			11 bytes
			rtn += stepsize;							// Console step frequency	 4 bytes
			rtn += incr;								// incremental tuning value	 6 bytes
			rtn += rit;									// RIT status				 1 byte
			rtn += xit;									// XIT status				 1 byte
			rtn += "000";								// dummy for memory bank	 3 bytes
			rtn += tx;									// tx-rx status				 1 byte
			rtn += Mode2String(console.RX1DSPMode);	// current mode				 2 bytes
			rtn += "0";									// dummy for FR/FT			 1 byte
			rtn += "0";									// dummy for scan status	 1 byte
			rtn += split;								// VFO Split status			 1 byte
			rtn += "0000";								// dummy for the balance	 4 bytes
			return rtn;
		}

        //Reads the installed options
        public string ZZIO()
        {
                return "000";
        }

		// Sets or reads the IF width
		public string ZZIS(string s)
		{
			int n = 0;

			if(s != "")
				n = Convert.ToInt32(s);

			if(s.Length == parser.nSet)
			{
				console.CATFilterWidth = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return AddLeadingZeros(console.CATFilterWidth);
			}
			else
			{
				return parser.Error1;
			}
		}

		//Sets or reads the IF Shift
		public string ZZIT(string s)
		{
			int n = 0;
			string sign = "-";

			if(s != "")
				n = Convert.ToInt32(s);

			if(s.Length == parser.nSet)
			{
				console.CATFilterShift = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				n = console.CATFilterShift;
				if(n >= 0)
				{
					sign = "+";
				}
				// we have to remove the leading zero and replace it with the sign.
				return sign+AddLeadingZeros(Math.Abs(n)).Substring(1);
			}
			else
			{
				return parser.Error1;
			}
		}

		// Resets the Filter Shift to zero.  Write only
		public string ZZIU()
		{
			console.CATFilterShiftReset = 1;	//Fixed XML entry 4/2/2007 to prevent return value.  BT
			return "";
		}

        public string ZZKO(string s)
        {
                 if (s.Length == parser.nSet)
                {
                    if (s == "1")
                    {
                        console.CATCWXForm = true;
                        return "";
                    }
                    else if (s == "0")
                    {
                        console.CATCWXForm = false;
                        return "";
                    }
                    else
                        return parser.Error1;
                }
                 else if (s.Length == parser.nGet)
                 {
                     if (console.CATCWXForm)
                         return "1";
                     else
                         return "0";
                 }
                 else
                     return parser.Error1;
            }


        //Sends a CWX macro
        public string ZZKM(string s)
        {
            int qn = 0;
            if (s != "0" && s.Length > 0)
            {
                qn = Convert.ToInt32(s);

                if (qn > 0 || qn < 10)
                {
                    console.CWXForm.StartQueue = qn;
                    return "";
                }
                else
                    return parser.Error1;
            }
            else
                return parser.Error1;
        }

		//Sets or reads the CWX CW speed
		public string ZZKS(string s)
		{
			int cws = 0;

			if(s.Length == parser.nSet)
			{
				cws = Convert.ToInt32(s);
				//cws = Math.Max(1, cws);
				//cws = Math.Min(99, cws);
				//[2.10.3.4]MW0LGE put in the property WPM where it should be
				console.CWXForm.WPM = cws;
				return "";

			}
			else if(s.Length == parser.nGet)
			{
				return AddLeadingZeros(console.CWXForm.WPM);
			}
			else
				return parser.Error1;
		}

		//Sends text to CWX for conversion to Morse
		public string ZZKY(string s)
		{
			if(s.Length == parser.nSet)
			{

			// Make sure we are in a cw mode.
			switch(console.RX1DSPMode)
			{
				case DSPMode.AM:
				case DSPMode.DRM:
				case DSPMode.DSB:
				case DSPMode.FM:
				case DSPMode.SAM:
				case DSPMode.SPEC:
				case DSPMode.LSB:
				case DSPMode.USB:
					if(console.RX1Band >= Band.B160M && console.RX1Band <= Band.B40M)
						console.RX1DSPMode = DSPMode.CWL;
					else
						console.RX1DSPMode = DSPMode.CWU;
					break;
                case DSPMode.CWL:
                case DSPMode.CWU:
                    break;
				default:
					console.RX1DSPMode = DSPMode.CWU;
					break;
			}


				string trms = "";
				byte[] msg;
                string x = s.Trim();

				if(x.Length == 0)
					trms = " ";
				else
					trms = s.TrimEnd();

				if(trms.Length > 1)
				{
					msg = AE.GetBytes(trms);
					return console.CWXForm.RemoteMessage(msg);
				}
				else
				{
					char ss = Convert.ToChar(trms);
					return console.CWXForm.RemoteMessage(ss);
				}
			}
			else if(s.Length == parser.nGet)
			{
				int ch = console.CWXForm.Characters2Send;
				if(ch > 0 && ch < 72)
					return "0";
				else if(ch >= 72)
					return "1";
				else if(ch == 0)
					return "2";
				else
					return parser.Error1;
			}
			else
				return parser.Error1;
		}

       //Sets or reads the RX0Gain level
        public string ZZLA(string s)
        {
            int n = 0;

            if (s != null && s != "")
                n = Convert.ToInt32(s);
            n = Math.Max(0, n);
            n = Math.Min(100, n);

            if (s.Length == parser.nSet)
            {
                console.RX0Gain = n;
                console.TitleBarEncoderString = "RX1 AF Gain = " + n + "%";
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return AddLeadingZeros((int)console.RX0Gain);
            }
            else
            {
                return parser.Error1;
            }
        }

        //Sets or reads the RX0 (Main RX) stereo balance
        public string ZZLB(string s)
        {
            int n = 0;

            if (s != null && s != "")
                n = Convert.ToInt32(s);
            n = Math.Max(0, n);
            n = Math.Min(100, n);

            if (s.Length == parser.nSet)
            {
                console.PanMainRX = n;
                if (n == 50)
                    console.TitleBarEncoderString = "RX1 Stereo Balance = MID";
                else if (n < 50)
                    console.TitleBarEncoderString = "RX1 Stereo Balance = left " + 2*(50-n) + "%";
                else
                    console.TitleBarEncoderString = "RX1 Stereo Balance = right " + 2 * (n - 50) + "%";
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return AddLeadingZeros((int)console.PanMainRX);
            }
            else
            {
                return parser.Error1;
            }
        }

        //Sets or reads the RX1 (SubRX) Gain level
        public string ZZLC(string s)
        {
            int n = 0;

            if (s != null && s != "")
                n = Convert.ToInt32(s);
            n = Math.Max(0, n);
            n = Math.Min(100, n);

            if (s.Length == parser.nSet)
            {
                console.RX1Gain = n;
                console.TitleBarEncoderString = "sub RX Gain = " + n + "%";
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return AddLeadingZeros((int)console.RX1Gain);
            }
            else
            {
                return parser.Error1;
            }
        }

        //Sets or reads the RX1 (Sub RX) stereo balance
        public string ZZLD(string s)
        {
            int n = 0;

            if (s != null && s != "")
                n = Convert.ToInt32(s);
            n = Math.Max(0, n);
            n = Math.Min(100, n);

            if (s.Length == parser.nSet)
            {
                console.PanSubRX = n;
                if (n == 50)
                    console.TitleBarEncoderString = "sub-RX Stereo Balance = MID";
                else if (n < 50)
                    console.TitleBarEncoderString = "sub-RX Stereo Balance = left " + 2 * (50 - n) + "%";
                else
                    console.TitleBarEncoderString = "sub-RX Stereo Balance = right " + 2 * (n - 50) + "%";
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return AddLeadingZeros((int)console.PanSubRX);
            }
            else
            {
                return parser.Error1;
            }
        }

        //Sets or reads the RX2 Gain level
        public string ZZLE(string s)
        {
                 int n = 0;

                if (s != null && s != "")
                    n = Convert.ToInt32(s);
                n = Math.Max(0, n);
                n = Math.Min(100, n);

                if (s.Length == parser.nSet)
                {
                    console.RX2Gain = n;
                    console.TitleBarEncoderString = "RX2 AF Gain =" + n + "%";
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    return AddLeadingZeros((int)console.RX2Gain);
                }
                else
                {
                    return parser.Error1;
                }
         }

        //Sets or reads the RX2 stereo balance
        public string ZZLF(string s)
        {
                 int n = 0;

                if (s != null && s != "")
                    n = Convert.ToInt32(s);
                n = Math.Max(0, n);
                n = Math.Min(100, n);

                if (s.Length == parser.nSet)
                {
                    console.RX2Pan = n;
                    if (n == 50)
                        console.TitleBarEncoderString = "RX2 Stereo Balance = MID";
                    else if (n < 50)
                        console.TitleBarEncoderString = "RX2 Stereo Balance = left " + 2 * (50 - n) + "%";
                    else
                        console.TitleBarEncoderString = "RX2 Stereo Balance = right " + 2 * (n - 50) + "%";
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    return AddLeadingZeros((int)console.RX2Pan);
                }
                else
                {
                    return parser.Error1;
                }
        }

        //Sets or reads the AutoMute RX1 on VFOB TX checkbox
        public string ZZLG(string s)
        {
                if (s.Length == parser.nSet)
                {
                    if (s == "0")
                        console.SetupForm.AutoMuteRX1onVFOBTX = false;
                    else
                        console.SetupForm.AutoMuteRX1onVFOBTX = true;
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    bool ans = console.SetupForm.AutoMuteRX1onVFOBTX;
                    if (ans)
                        return "1";
                    else
                        return "0";
                }
                else
                    return parser.Error1;          
       }

        //Sets or reads the AutoMute RX2 on VFOA TX checkbox
        public string ZZLH(string s)
        {
                if (s.Length == parser.nSet)
                {
                    if (s == "0")
                        console.SetupForm.AutoMuteRX2onVFOATX = false;
                    else
                        console.SetupForm.AutoMuteRX2onVFOATX = true;
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    bool ans = console.SetupForm.AutoMuteRX2onVFOATX;
                    if (ans)
                        return "1";
                    else
                        return "0";
                }
                else
                    return parser.Error1;
        }
        
        // Sets or reads the PS-A button on/off status
        public string ZZLI(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                if (s == "0")
                    console.PSA = false;
                else if (s == "1")
                    console.PSA = true;

                return "";
            }
            else if (s.Length == parser.nGet)
            {
                bool retval = console.PSA;
                if (retval)
                    return "1";
                else
                    return "0";
            }
            else
            {
                return parser.Error1;
            }

        }

        // Sets or reads the MUT button on/off status
		public string ZZMA(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if(s == "0")
					console.MUT = false;
				else if(s == "1")
					console.MUT = true;

				return "";
			}
			else if(s.Length == parser.nGet)
			{
				bool retval = console.MUT;
				if(retval)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}

		}

        // Sets or reads the RX2 MUT button on/off status
        public string ZZMB(string s)
        {
                if (s.Length == parser.nSet && (s == "0" || s == "1"))
                {
                    if (s == "0")
                        console.MUT2 = false;
                    else if (s == "1")
                        console.MUT2 = true;

                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    bool retval = console.MUT2;
                    if (retval)
                        return "1";
                    else
                        return "0";
                }
                else
                {
                    return parser.Error1;
                }
  
        }




		// Sets or reads the SDR-1000 DSP mode
		public string ZZMD(string s)
		{
			if(s.Length == parser.nSet)
			{
				if(Convert.ToInt32(s) >= 0 && Convert.ToInt32(s) <= 11)
				{
					String2Mode(s);
					return "";
				}
				else
					return parser.Error1;
			}
			else if(s.Length == parser.nGet)
			{
				return Mode2String(console.RX1DSPMode);
			}
			else
			{
				return parser.Error1;
			}
		}

        public string ZZME(string s)
        {
                if (s.Length == parser.nGet)
                {
                    return Mode2String(console.RX2DSPMode);
                }
                else if (s.Length == parser.nSet && s != "08")
                {
                    switch (s)
                    {
                        case "00":
                            console.RX2DSPMode = DSPMode.LSB;
                            break;
                        case "01":
                            console.RX2DSPMode = DSPMode.USB;
                            break;
                        case "02":
                            console.RX2DSPMode = DSPMode.DSB;
                            break;
                        case "03":
                            console.RX2DSPMode = DSPMode.CWL;
                            break;
                        case "04":
                            console.RX2DSPMode = DSPMode.CWU;
                            break;
                        case "05":
                            console.RX2DSPMode = DSPMode.FM;
                            break;
                        case "06":
                            console.RX2DSPMode = DSPMode.AM;
                            break;
                        case "07":
                            console.RX2DSPMode = DSPMode.DIGU;
                            break;
                        case "09":
                            console.RX2DSPMode = DSPMode.DIGL;
                            break;
                        case "10":
                            console.RX2DSPMode = DSPMode.SAM;
                            break;
                        case "11":
                            console.RX2DSPMode = DSPMode.DRM;
                            break;
                    }
                    return "";
                }
                else
                    return parser.Error1;
       }

        // ZZMFcccccccccccccccccccc;  Set multifunction encoder text 
        // cc are 15 pairs of digits 0-99 each making up an ASCII code -32 (so  'A' is 33 for example)
        public string ZZMF(string s)
        {
            if (s.Length == parser.nSet)
            {
                string msg = "";
                int code;
                int cntr;

                for (cntr=0; cntr<parser.nSet/2; cntr++)
                {
                    code = Convert.ToInt32(s.Substring(2*cntr, 2), 10);     // get ascii code
                    msg += Char.ConvertFromUtf32(code+32);
                }
                console.TitleBarMultifunctionString = "   multifunction encoder = " + msg;
                return "";
            }

            else
                return parser.Error1;
        }

        //Andromeda front panel VFO encoder down
        //write only
        public string ZZZD(string s)
        {
            if (s.Length == parser.nSet)
            {
                int Steps = Convert.ToInt32(s);
                console.HandleFrontPanelVFOEncoderStep(-Steps);
                return "";
            }
            else
                return parser.Error1;
        }

        //Andromeda front panel VFO encoder up
        //write only
        public string ZZZU(string s)
        {
            if (s.Length == parser.nSet)
            {
                int Steps = Convert.ToInt32(s);
                console.HandleFrontPanelVFOEncoderStep(Steps);
                return "";
            }
            else
                return parser.Error1;
        }

		//Andromeda front panel s/w version
		//write only
		public string ZZZS(string s)
        {
            if (s.Length == parser.nSet)
            {
                int Version = Convert.ToInt32(s);
                console.HandleAttachedHardwareID = Version;
                return "";
            }
            else
                return parser.Error1;
        }

        //Andromeda front panel encoder step
        //write only
        public string ZZZE(string s)
        {
            if (s.Length == parser.nSet)
            {
                int Encoder = Convert.ToInt32(s);
                int Step = Encoder % 10;                // bottom digit
                Encoder /= 10;                 // top 2 digits
                if ((Encoder >= 1) && (Encoder <= 20))
                console.HandleFrontPanelEncoderStep(Encoder-1, Step);
                else if ((Encoder >= 51) && (Encoder <= 70))
                    console.HandleFrontPanelEncoderStep(Encoder - 51, -Step);
                return "";
            }
            else
                return parser.Error1;
        }

        //Andromeda front panel pushbutton press
        //write only
        public string ZZZP(string s)
        {
            if (s.Length == parser.nSet)
            {
                int Button = Convert.ToInt32(s);
                bool State = false;
                bool LongPress = false;
                if ((Button % 10) == 1)
                    State = true;
                else if ((Button % 10) == 2)
                    LongPress = true;
                Button /= 10;           // 1-99
                console.HandleFrontPanelButtonPress(Button-1, State, LongPress);
                return "";
            }
            else
                return parser.Error1;
        }
        //CATHandleAriesTuneMessage
        //Ganymeda amplifier trip state
        //write only
        public string ZZZA(string s)
        {
            if (s.Length == parser.nSet)
            {
                int Version = Convert.ToInt32(s);
                console.CATHandleAmplifierTripMessage(Version);
                return "";
            }
            else
                return parser.Error1;
        }

        //
        //ARIES ATU tune state message
        //write only
        public string ZZOX(string s)
        {
            if (s.Length == parser.nSet)
            {
                bool Tuned = false;
                int Version = Convert.ToInt32(s);
                if (Version == 1)
                    Tuned = true;
                console.CATHandleAriesTuneMessage(Tuned);
                return "";
            }
            else
                return parser.Error1;
        }

        //
        //ARIES ATU erase state message
        //write only
        public string ZZOZ(string s)
        {
            if (s.Length == parser.nSet)
            {
                bool Erased = false;
                int Version = Convert.ToInt32(s);
                if (Version == 1)
                    Erased = true;
                console.CATHandleAriesEraseMessage(Erased);
                return "";
            }
            else
                return parser.Error1;
        }

        //Sets or reads the Mic gain control
        public string ZZMG(string s)
		{
			int n=0;
            string sign;

			if(s != "")
			{
				n = Convert.ToInt32(s);
				n = Math.Min(70,n);
				n = Math.Max(-50,n);
			}

			if(s.Length == parser.nSet || s.Length == parser.nSet + 1) //[2.10.3.6]MW0LGE can also have -. Could have changed catsructs but not sure on cat msg formats from other sources other than midi so left with the +1
			{
				console.CATMIC = n;
                console.TitleBarEncoderString = "Mic Gain = " + console.CATMIC + "dB";
				return "";
			}
			else if(s.Length == parser.nGet)
			{
                if (console.CATMIC >= 0)
                    sign = "+";
                else
                    sign = "-";
                // we have to remove the leading zero and replace it with the sign.
                return sign + (AddLeadingZeros(Math.Abs(console.CATMIC))).Substring(1);
			}
			else
				return parser.Error1;
		}

        //Returns a list of modes with index
        public string ZZML()
        {
            string modeList = "";
            string thisMode = "";

            try
            {
                var values = (DSPMode[])Enum.GetValues(typeof(DSPMode));
                int n = 0;
                for (n = 0; values[n] != DSPMode.LAST; n++)
                {
                    if (values[n] != DSPMode.FIRST && values[n] != DSPMode.LAST)
                    {
                        if ((int)values[n] <= 9)
                            thisMode = values[n].ToString() + "0" + (int)values[n] + ":";
                        else
                            thisMode = values[n].ToString() + (int)values[n] + ":";
                    }
                    modeList += thisMode.PadLeft(7, ' ');
                }

                return modeList.Remove(modeList.Length - 1);
            }
            catch
            {
                parser.Verbose_Error_Code = 4;
                return parser.Error1;
            }
        }

		//Reads the DSP filter presets for filter index (s)
		//Returns 180 character length word for 12 filters x 15 characters each.
		//Format is name high low: ZZMN 5.0k 5150 -160...
		public string ZZMN(string s)
		{
			if(s.Length == parser.nGet)
			{
				return console.GetFilterPresets(Int32.Parse(s));
			}
			else
				return parser.Error1;
		}

		//Sets or reads the Monitor (MON) button status
		public string ZZMO(string s)
		{
			if(s.Length == parser.nSet)
			{
				if(s == "0")
					console.MON = false;
				else if(s == "1")
					console.MON = true;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				bool retval = console.MON;
				if(retval)
					return "1";
				else
					return "0";
			}
			else
				return parser.Error1;
		}

		// Sets or reads the RX meter mode
		public string ZZMR(string s)
		{
			int m = -1;
			if(s != "")
				m = Convert.ToInt32(s);

			if(s.Length == parser.nSet && 
				(m > (int) MeterRXMode.FIRST && m < (int) MeterRXMode.LAST))
			{
				String2RXMeter(m);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return RXMeter2String();
			}
			else
			{
				return parser.Error1;
			}

		}	
		
		//Sets or reads the MultiRX Swap checkbox
		public string ZZMS(string s)
		{
			if(s.Length == parser.nSet  && (s == "1" || s == "0"))
			{
				if(s == "1")
					console.CATPanSwap = "1";
				else if(s == "0")
					console.CATPanSwap= "0";
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATPanSwap;
			}
			else
				return parser.Error1;
		}

		// Sets or reads the TX meter mode
		public string ZZMT(string s)
		{
			int m = -1;
			if(s != "")
				m = Convert.ToInt32(s);

			if(s.Length == parser.nSet &&
				(m > (int) MeterTXMode.FIRST && m < (int) MeterTXMode.LAST))
			{
				String2TXMeter(m);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return TXMeter2String().PadLeft(2,'0');		//Added padleft 4/2/2007 BT
			}
			else
			{
				return parser.Error1;
			}
		}

		//Sets or reads the MultiRX button status
		public string ZZMU(string s)
		{
			if(s.Length == parser.nSet  && (s == "1" || s == "0"))
			{
				if(s == "1")
					console.CATMultRX = "1";
				else if(s == "0")
					console.CATMultRX= "0";
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATMultRX;
			}
			else
				return parser.Error1;
		}

        //Returns the count of memory records
        //read only
        public string ZZMV()
        {
            try
            {
                return AddLeadingZeros(console.MemoryList.List.Count);
            }
            catch
            {
                parser.Verbose_Error_Code = 4;
                return parser.Error1;
            }
        }

        //Deletes a memory channel
        public string ZZMW(string s)
        {
            try
            {
                MemoryRecord rec = GetChannelRecord(s);
                if (rec.Comments.StartsWith(s)) 
                    console.MemoryList.List.Remove(rec);
                return "";
            }
            catch
            {
                parser.Verbose_Error_Code = 4;
                return parser.Error1;
            }

        }

        //Restores memory channel n
        public string ZZMX(string s)
        {
            try
            {
                int ndx = GetIndex(s);
                if (ndx >= 0)
                {
                    console.changeComboFMMemory(ndx);
                    return "";
                }
                else
                {
                    parser.Verbose_Error_Code = 9;
                    return parser.Error1;
                }
            }
            catch
            {
                parser.Verbose_Error_Code = 4;
                return parser.Error1;
            }
        }

        //Saves the current radio configuration to a new memory channel
        public string ZZMY()
        {
            try
            {
                int nextN = GetNextChannelNumber();
                int oldAns = parser.nAns;
                parser.nAns = 3;
                string newCh = AddLeadingZeros(nextN);


                console.MemoryList.List.Add(new MemoryRecord("", console.VFOAFreq, "", console.RX1DSPMode, true, console.TuneStepList[console.TuneStepIndex].Name,
 console.CurrentFMTXMode, console.FMTXOffsetMHz, console.radio.GetDSPTX(0).CTCSSFlag, console.radio.GetDSPTX(0).CTCSSFreqHz, console.PWR,
 (int)console.radio.GetDSPTX(0).TXFMDeviation, console.VFOSplit, console.TXFreq, console.RX1Filter, console.RX1FilterLow,
 console.RX1FilterHigh, newCh + ":", console.radio.GetDSPRX(0, 0).RXAGCMode, console.RF,

  DateTime.Now, false, 0, false, false, false, 0 // ke9ns add for freq scheduler

 ));

                parser.nAns = oldAns;
                return "";
            }
            catch
            {
                parser.Verbose_Error_Code = 4;
                return parser.Error1;
            }
        }

        //Saves the radio configuration to a specific channel number (edit)
        public string ZZMZ(string s)
        {
            if (GetIndex(s) >= 0)
            {
                try
                {
                    MemoryRecord oldrec = GetChannelRecord(s);
					MemoryRecord newrec = new MemoryRecord
					{
						Group = oldrec.Group,
						RXFreq = console.VFOAFreq,
						Name = oldrec.Name,
						DSPMode = console.RX1DSPMode,
						Scan = oldrec.Scan,
						TuneStep = console.TuneStepList[console.TuneStepIndex].Name,
						RPTR = console.CurrentFMTXMode,
						RPTROffset = console.FMTXOffsetMHz,
						CTCSSOn = console.radio.GetDSPTX(0).CTCSSFlag,
						CTCSSFreq = console.radio.GetDSPTX(0).CTCSSFreqHz,
						Power = console.PWR,
						Deviation = (int)console.radio.GetDSPTX(0).TXFMDeviation,
						Split = console.VFOSplit,
						TXFreq = console.TXFreq,
						RXFilter = console.RX1Filter,
						RXFilterLow = console.RX1FilterLow,
						RXFilterHigh = console.RX1FilterHigh,
						Comments = oldrec.Comments,
						AGCMode = console.radio.GetDSPRX(0, 0).RXAGCMode,
						AGCT = console.RF
					};
					console.MemoryList.List.Remove(oldrec);
                    console.MemoryList.List.Add(newrec);
                    return "";
                }
                catch
                {
                    parser.Verbose_Error_Code = 4;
                    return parser.Error1;
                }
            }
            else
            {
                parser.Verbose_Error_Code = 9;
                return parser.Error1;
            }
        }

		#endregion Extended CAT Methods ZZG-ZZM

		#region Extended CAT Methods ZZN-ZZQ

		//Sets or reads Noise Blanker 2 status
		public string ZZNA(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				console.CATNB1 = Convert.ToInt32(s);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATNB1.ToString();
			}
			else
			{
				return parser.Error1;
			}
		}

		// Sets or reads the Noise Blanker 2 status
		public string ZZNB(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				console.CATNB2 = Convert.ToInt32(s);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATNB2.ToString();
			}
			else
			{
				return parser.Error1;
			}

		}

        //Sets or reads the RX2 NB status
        public string ZZNC(string s)
        {
                if (s.Length == parser.nSet && (s == "0" || s == "1"))
                {
                    console.CATRX2NB1 = Convert.ToInt32(s);
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    return console.CATRX2NB1.ToString();
                }
                else
                {
                    return parser.Error1;
                }
  	} 

        //Sets or reads the RX2 NB2 status
        public string ZZND(string s)
        {
                if (s.Length == parser.nSet && (s == "0" || s == "1"))
                {
                    console.CATRX2NB2 = Convert.ToInt32(s);
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    return console.CATRX2NB2.ToString();
                }
                else
                {
                    return parser.Error1;
                }
 
        } 



		// Sets or reads the Noise Blanker 1 threshold
		public string ZZNL(string s)
		{
			if(s.Length == parser.nSet)
			{
				console.SetupForm.CATNB1Threshold = Convert.ToInt32(s);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return AddLeadingZeros(console.SetupForm.CATNB1Threshold);
			}
			else
			{
				return parser.Error1;
			}

		}

		// Sets or reads the Noise Blanker 2 threshold
		public string ZZNM(string s)
		{
			if(s.Length == parser.nSet)
			{
				console.SetupForm.CATNB2Threshold = Convert.ToInt32(s);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return AddLeadingZeros(console.SetupForm.CATNB2Threshold);
			}
			else
			{
				return parser.Error1;
			}

		}

        // Sets or reads the Rx1 Spectral Noise Blanker
        public string ZZNN(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                console.CATSNB = Convert.ToInt32(s);
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return console.CATSNB.ToString();
            }
            else
            {
                return parser.Error1;
            }
        }

        // Sets or reads the Rx2 Spectral Noise Blanker
        public string ZZNO(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                console.CATRX2SNB = Convert.ToInt32(s);
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return console.CATRX2SNB.ToString();
            }
            else
            {
                return parser.Error1;
            }
        }
        
        // Sets or reads the RX1 Noise Reduction status
		public string ZZNR(string s)
		{
			int sx = 0;

			if(s != "")
				sx = Convert.ToInt32(s);

			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				console.CATNR = sx;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATNR.ToString();
			}
			else
			{
				return parser.Error1;
			}
		}

        // Sets or reads the RX1 NR2 button status
        public string ZZNS(string s)
        {
            int sx = 0;

            if (s != "")
                sx = Convert.ToInt32(s);

            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                console.CATNR2 = sx;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return console.CATNR2.ToString();
            }
            else
            {
                return parser.Error1;
            }
        }
        
        //Sets or reads the ANF button status
		public string ZZNT(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				console.CATANF = Convert.ToInt32(s);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATANF.ToString();
			}
			else
			{
				return parser.Error1;
			}
		}

        //Sets or reads the RX2 ANF button status
        public string ZZNU(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                console.CATRX2ANF = Convert.ToInt32(s);
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return console.CATRX2ANF.ToString();
            }
            else
            {
                return parser.Error1;
            }
        }
        // Sets or reads the Noise Reduction status
        public string ZZNV(string s)
        {
            int sx = 0;

            if (s != "")
                sx = Convert.ToInt32(s);

            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                console.CATRX2NR = sx;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return console.CATRX2NR.ToString();
            }
            else
            {
                return parser.Error1;
            }
        }

        // Sets or reads the RX2 NR2 button status
        public string ZZNW(string s)
        {
            int sx = 0;

            if (s != "")
                sx = Convert.ToInt32(s);

            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                console.CATRX2NR2 = sx;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return console.CATRX2NR2.ToString();
            }
            else
            {
                return parser.Error1;
            }
        }

        //Sets or reads the RX1 antenna //[2.3.10.6]MW0LGE https://github.com/ramdor/Thetis/issues/385
        public string ZZOA(string s)
		{
            int n = 0;

            if (s != null && s != "")
                n = Convert.ToInt32(s);
            n = Math.Max(1, n);
            n = Math.Min(3, n);

            if (s.Length == parser.nSet)
            {
				if (console.SetupForm != null)
					console.SetupForm.SetRXAntenna(n, console.RX1Band);
                return "";
            }
            else if (s.Length == parser.nGet)
            {
				if (console.SetupForm != null)
					return console.SetupForm.GetRXAntenna(console.RX1Band).ToString();
				else
					return "";
            }
            else
            {
                return parser.Error1;
            }
        }

        //Sets or reads the RX2 antenna (if RX2 installed)
        public string ZZOB(string s)
		{
             parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

        //Sets or reads the TX antenna //[2.3.10.6]MW0LGE https://github.com/ramdor/Thetis/issues/385
        public string ZZOC(string s)
		{
            int n = 0;

            if (s != null && s != "")
                n = Convert.ToInt32(s);
            n = Math.Max(1, n);
            n = Math.Min(3, n);

            if (s.Length == parser.nSet)
            {
                if (console.SetupForm != null)
                    console.SetupForm.SetTXAntenna(n, console.TXBand);
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                if (console.SetupForm != null)
                    return console.SetupForm.GetTXAntenna(console.TXBand).ToString();
                else
                    return "";
            }
            else
            {
                return parser.Error1;
            }
        }

		//Sets or reads the current Antenna Mode
		public string ZZOD(string s)
		{
              parser.Verbose_Error_Code = 7;
                return parser.Error1;
 		}

		//Sets or reads the RX1 External Antenna checkbox
		public string ZZOE(string s)
		{
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		//Sets or reads the TX relay RCA jack
		public string ZZOF(string s)
		{
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}


		//Sets or reads the TX Relay Delay enables
		public string ZZOG(string s)
		{
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		//Sets or reads the TX Relay Delays
		public string ZZOH(string s)
		{
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		} 

		public string ZZOJ(string s)
		{
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

        // Sets or reads the DigL Click Tune Offset
        public string ZZOL(string s)
        {
            int n = 0;

            if (s != null && s != "")
                n = Convert.ToInt32(s);
            n = Math.Max(0, n);
            n = Math.Min(10000, n);

            if (s.Length == parser.nSet)
            {
                console.SetupForm.DigL_CT_Offset = n;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return AddLeadingZeros((int)console.SetupForm.DigL_CT_Offset);
            }
            else
            {
                return parser.Error1;
            }
        }

        //Sets or reads the current repeater offset direction
        public string ZZOS(string s)
        {
            if (s.Length == parser.nSet)
            {
                String2OffsetDirection(s);
                return "";
            }
            else if (s.Length == parser.nGet)
                return OffsetDirection2String();
            else
                return parser.Error1;
        }

        //Sets for reads the repeater frequency offset
        //need to resolve the negative offset question.
        public string ZZOT(string s)
        {
            if (s.Length == parser.nSet)
            {
                s = s.Insert(3, ".");
                double n = double.Parse(s);
				console.FMTXOffsetMHz = n;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                int n = Convert.ToInt32(Math.Abs(console.FMTXOffsetMHz*10e5));
                return AddLeadingZeros(n);
            }
            else
                return parser.Error1;
        }

        // Sets or reads the DigU Click Tune Offset
        public string ZZOU(string s)
        {
            int n = 0;

            if (s != null && s != "")
                n = Convert.ToInt32(s);
            n = Math.Max(0, n);
            n = Math.Min(10000, n);

            if (s.Length == parser.nSet)
            {
                console.SetupForm.DigU_CT_Offset = n;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return AddLeadingZeros((int)console.SetupForm.DigU_CT_Offset);
            }
            else
            {
                return parser.Error1;
            }

        }

        //Sets or reads the console ATU button
        public string ZZOV(string s)
        {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
        }

        //Sets or reads the console ATU Bypass button
        public string ZZOW(string s)
        {
                 parser.Verbose_Error_Code = 7;
                return parser.Error1;
        }

		// Sets or reads the Preamp thumbwheel
		public string ZZPA(string s)
		{
			int n = 0;
			if(s != "")
				n = Convert.ToInt32(s);

           // PreampMode e_mode = console.CATPreamp;

            if (s.Length == parser.nSet)
            {
                    if ((n > (int)PreampMode.FIRST && n < (int)PreampMode.LAST))
                    {
                        switch (s)
                        {
                            case "0":
                                console.CATPreamp = PreampMode.HPSDR_OFF;
                                break;
                            case "1":
                                console.CATPreamp = PreampMode.HPSDR_ON;
                                break;
                            case "2":
                                console.CATPreamp = PreampMode.HPSDR_MINUS10;
                                break;
                            case "3":
                                console.CATPreamp = PreampMode.HPSDR_MINUS20;
                                break;
                            case "4":
                                console.CATPreamp = PreampMode.HPSDR_MINUS30;
                                break;
                            case "5":
                                console.CATPreamp = PreampMode.HPSDR_MINUS40;
                                break;
                            case "6":
                                console.CATPreamp = PreampMode.HPSDR_MINUS50;
                                break;
                        }
                        return "";
                    }
                    else
                        return parser.Error1;
                }
            else if (s.Length == parser.nGet)
            {
                int mode = (int)console.CATPreamp;
                string cat_mode = "";
                cat_mode = mode.ToString();
                return cat_mode;
            }
            else
            {
                return parser.Error1;
            }
		}

        //Sets or reads the RX2 Preamp button
        public string ZZPB(string s)
        {
            int n = 0;
            if (s != "")
                n = Convert.ToInt32(s);

            if (s.Length == parser.nSet)
            {
                if ((n > (int)PreampMode.FIRST && n < (int)PreampMode.LAST))
                {
                    switch (s)
                    {
                        case "0":
                            console.RX2PreampMode = PreampMode.HPSDR_OFF;
                            break;
                        case "1":
                            console.RX2PreampMode = PreampMode.HPSDR_ON;
                            break;
                        case "2":
                            console.RX2PreampMode = PreampMode.HPSDR_MINUS10;
                            break;
                        case "3":
                            console.RX2PreampMode = PreampMode.HPSDR_MINUS20;
                            break;
                        case "4":
                            console.RX2PreampMode = PreampMode.HPSDR_MINUS30;
                            break;
                        //case "5":
                        //    console.RX2PreampMode = PreampMode.HPSDR_MINUS40;
                        //    break;
                        //case "6":
                        //    console.RX2PreampMode = PreampMode.HPSDR_MINUS50;
                        //    break;
                    }
                    return "";
                }
                else
                    return parser.Error1;
            }
            else if (s.Length == parser.nGet)
            {
                int mode = (int)console.RX2PreampMode;
                string cat_mode = "";
                cat_mode = mode.ToString();
                return cat_mode;
            }
            else
            {
                return parser.Error1;
            }

                //if (s.Length == parser.nGet)
                //{
                //    if (console.RX2PreampMode == PreampMode.HPSDR_OFF)
                //        return "0";
                //    else
                //        return "1";
                //}
                //else if (s.Length == parser.nSet)
                //{
                //    if (s == "1")
                //        console.RX2PreampMode = PreampMode.HPSDR_ON;
                //    else
                //        console.RX2PreampMode = PreampMode.HPSDR_OFF;
                //    return "";
                //}
                //else
                //    return parser.Error1;
 
        }

		//Sets or reads the Drive level
		public string ZZPC(string s)
		{
			int pwr = 0;

			if(s.Length == parser.nSet)
			{
				pwr = Convert.ToInt32(s);
				console.PWR = pwr;
                console.TitleBarEncoderString = "Drive = " + pwr;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				if(console.SendLimitedPowerLevels) //MW0LGE_22b
					return AddLeadingZeros(console.PWRConstrained);
				else
					return AddLeadingZeros(console.PWR);				
			}
			else
			{
				return parser.Error1;
			}
		}

		//Centers the Display Pan scroll
		public string ZZPD()
		{
			console.CATDispCenter = "1";
			return "";
		}

        // Sets or reads the Display Pan control
        public string ZZPE(string s)
        {
            int level = 0;

            if (s.Length == parser.nSet)
            {
                level = Convert.ToInt32(s);
                level = Math.Max(0, level);			// lower bound
                level = Math.Min(1000, level);		    // upper bound
                console.Pan = level;
                console.TitleBarEncoderString = "Display pan =" + level/10 + "%";
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return AddLeadingZeros(console.Pan);
            }
            else
            {
                return parser.Error1;
            }

        }

//		//Sets or reads the Speech Compressor button status
//		public string ZZPK(string s)
//		{
//			if(s.Length == parser.nSet)
//			{
//				if(s == "0")
//					console.COMP = false;
//				else if(s == "1")
//					console.COMP = true;
//				return "";
//			}
//			else if(s.Length == parser.nGet)
//			{
//				bool comp = console.COMP;
//				if(comp)
//					return "1";
//				else
//					return "0";
//			}
//			else
//			{
//				return "";
//			}
//		}
//
//		// Sets or reads the Speech Compressor threshold
//		public string ZZPL(string s)
//		{
//			if(s.Length == parser.nSet)
//			{
//				console.SetupForm.CATCompThreshold = Convert.ToInt32(s);
//				return "";
//			}
//			else if(s.Length == parser.nGet)
//			{
//				return AddLeadingZeros(console.SetupForm.CATCompThreshold);
//			}
//			else
//			{
//				return parser.Error1;
//			}
//
//		}

		// Sets or reads the Speech Compressor threshold
//		public string ZZPL(string s)
//		{
//			if(s.Length == parser.nSet)
//			{
//				console.SetupForm.CATCompThreshold = Convert.ToInt32(s);
//				return "";
//			}
//			else if(s.Length == parser.nGet)
//			{
//				return AddLeadingZeros(console.SetupForm.CATCompThreshold);
//			}
//			else
//			{
//				return parser.Error1;
//			}
//
//		}

		//Sets or reads the Display Peak button status
		public string ZZPO(string s)
		{
			if(s.Length == parser.nSet)
			{
				console.CATDispPeak = s;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATDispPeak;
			}
			else
				return parser.Error1;
		}

		//Sets or reads the Power button status
		public string ZZPS(string s)
		{
			if(s.Length == parser.nSet)
			{
				if(s == "0")
					console.PowerOn = false;
				else if(s == "1")
					console.PowerOn = true;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				bool pwr = console.PowerOn;
				if(pwr)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}
		}

        // Sets or reads the Display Zoom control
        public string ZZPY(string s)
        {
            int level = 0;

            if (s.Length == parser.nSet)
            {
                level = Convert.ToInt32(s);
                level = Math.Max(10, level);			// lower bound
                level = Math.Min(240, level);		    // upper bound
                console.Zoom = level;
                console.TitleBarEncoderString = "Display zoom =" + Convert.ToInt32(level/2.4) + "%";
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return AddLeadingZeros(console.Zoom);
            }
            else
            {
                return parser.Error1;
            }

        }


		//Sets the Display Zoom buttons
		public string ZZPZ(string s)
		{
			if(s.Length == parser.nSet)
			{
				console.CATDispZoom = s;

				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATDispZoom;
			}
			else
				return parser.Error1;

		}


        // Sets or reads the CW Break-In for Semi/QSK modes
        public string ZZQK(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                console.CATQSKBreakIn = Convert.ToInt32(s);
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return console.CATQSKBreakIn.ToString();
            }
            else
            {
                return parser.Error1;
            }

        }

        // Reads the Quick Memory Save value
        public string ZZQM()
		{
			return StrVFOFreq("C");
		}

		// Recalls Memory Quick Save
		public string ZZQR()
		{
			console.CATMemoryQR();
			return "";
		}

		//Saves Quick Memory value
		public string ZZQS()
		{
			console.CATMemoryQS();
			return "";
		}


		#endregion Extended CAT Methods ZZN-ZZQ

		#region Extended CAT Methods ZZR-ZZZ

		// Sets or reads the RTTY Offset Enable VFO A checkbox
		public string ZZRA(string s)
		{
			if(s.Length == parser.nSet)
			{
				if(s == "0")
					console.SetupForm.RttyOffsetEnabledA = false;
				else if(s == "1") 
					console.SetupForm.RttyOffsetEnabledA = true;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				bool ans = console.SetupForm.RttyOffsetEnabledA;
				if(ans)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}
		}

		// Sets or reads the RTTY Offset Enable VFO B checkbox
		public string ZZRB(string s)
		{
			if(s.Length == parser.nSet)
			{
				if(s == "0")
					console.SetupForm.RttyOffsetEnabledB = false;
				else if(s == "1") 
					console.SetupForm.RttyOffsetEnabledB = true;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				bool ans = console.SetupForm.RttyOffsetEnabledB;
				if(ans)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}
		}

		//Clears the RIT frequency
		public string ZZRC()
		{
			console.RITValue = 0;
			return "";
		}

		//Decrements RIT
		public string ZZRD(string s)
		{
			if(s.Length == parser.nSet)
			{
				return ZZRF(s);
			}
            else if (s.Length == parser.nGet) // && console.RITOn)  //-W2PA Want to be able to change RIT value even if it's off
			{
                //switch(console.RX1DSPMode)
                //{
                //	case DSPMode.CWL:
                //	case DSPMode.CWU:
                //		console.RITValue -= 10;
                //		break;
                //	case DSPMode.LSB:
                //	case DSPMode.USB:
                //		console.RITValue -= 50;  
                //                    break;
                //            }
                console.RITValue -= 10;  //-W2PA Changed to be same step in all modes.
				return "";
			}
			else
				return parser.Error1;
		}

		// Sets or reads the RIT frequency value
		public string ZZRF(string s)
		{
			int n = 0;
			int x = 0;
			string sign;

			if(s != "")
			{
				n = Convert.ToInt32(s);
				n = Math.Max(-99999, n);
				n = Math.Min(99999, n);
			}

			if(s.Length == parser.nSet)
			{
				console.RITValue = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				x = console.RITValue;
				if(x >= 0)
					sign = "+";
				else
					sign = "-";
				// we have to remove the leading zero and replace it with the sign.
				return sign+AddLeadingZeros(Math.Abs(x)).Substring(1);
			}
			else
			{
				return parser.Error1;
			}
		}


		//Sets or reads the RTTY DIGH offset frequency ud counter
		public string ZZRH(string s)
		{
			int n = 0;
			int x = 0;
			string sign;

			if(s != "")
			{
				n = Convert.ToInt32(s);
				n = Math.Max(-3000, n);
				n = Math.Min(3000, n);
			}

			if(s.Length == parser.nSet)
			{
				console.SetupForm.RttyOffsetHigh = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				x = console.SetupForm.RttyOffsetHigh;
				if(x >= 0)
					sign = "+";
				else
					sign = "-";
				// we have to remove the leading zero and replace it with the sign.
				return sign+AddLeadingZeros(Math.Abs(x)).Substring(1);
			}
			else
			{
				return parser.Error1;
			}

		}

		//Sets or reads the RTTY DIGL offset frequency ud counter
		public string ZZRL(string s)
		{
			int n = 0;
			int x = 0;
			string sign;

			if(s != "")
			{
				n = Convert.ToInt32(s);
				n = Math.Max(-3000, n);
				n = Math.Min(3000, n);
			}

			if(s.Length == parser.nSet)
			{
				console.SetupForm.RttyOffsetLow = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				x = console.SetupForm.RttyOffsetLow;
				if(x >= 0)
					sign = "+";
				else
					sign = "-";
				// we have to remove the leading zero and replace it with the sign.
				return sign+AddLeadingZeros(Math.Abs(x)).Substring(1);
			}
			else
			{
				return parser.Error1;
			}

		}

		// Reads the Console RX meter
		public string ZZRM(string s)
		{
			string output = parser.Error1;
			if(!console.MOX)
			{
				switch(s)
				{
					case "0":
						output = console.CATReadSigStrength().PadLeft(20);
						break;
					case "1":
						output = console.CATReadAvgStrength().PadLeft(20);
						break;
					case "2":
						output = console.CATReadADC_L().PadLeft(20);
						break;
					case "3":
						output = console.CATReadADC_R().PadLeft(20);
						break;
				}
			}
			else
			{
				switch(s)
				{
					case "4":
						output = console.CATReadALC().PadLeft(20);
						break;
					case "5":
						output = console.CATReadFwdPwr().PadLeft(20);
						break;
					case "6":
						output = parser.Error1;
						break;
					case "7":
						output = console.CATReadRevPwr().PadLeft(20);
						break;
					case "8":
						output = console.CATReadSWR().PadLeft(20);
						break;
				}
			}
			return output;
		}
		//Sets or reads the RX2 button status
        public string ZZRS(string s)
        {
                if (s.Length == parser.nSet)
                {
                    if (s == "0")
                        console.RX2Enabled = false;
                    else if (s == "1")
                        console.RX2Enabled = true;
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    if (console.RX2Enabled)
                        return "1";
                    else
                        return "0";
                }
                else
                {
                    return parser.Error1;
                }
          }


		//Sets or reads the RIT button status
		public string ZZRT(string s)
		{
			if(s.Length == parser.nSet)
			{
				if(s == "0")
					console.RITOn = false;
				else if(s == "1") 
					console.RITOn = true;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				bool rit = console.RITOn;
				if(rit)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}
		}

		//Increments RIT
		public string ZZRU(string s)
		{
			if(s.Length == parser.nSet)
			{
				return ZZRF(s);
			}
			else if(s.Length == parser.nGet) // && console.RITOn)  //-W2PA Want to be able to change RIT value even if it's off

			{
                //switch(console.RX1DSPMode)
                //{
                //	case DSPMode.CWL:
                //	case DSPMode.CWU:
                //		console.RITValue += 10;
                //		break;
                //	case DSPMode.LSB:
                //	case DSPMode.USB:
                //		console.RITValue += 50;  
                //		break;
                //            }
                console.RITValue += 10;  //-W2PA Changed to operate in all modes.
				return "";
			}
			else
				return parser.Error1;		}

        //Reads the primary input voltage
        public string ZZRV()
        {
            //MW0LGE [2.10.1.0]
            if (console.CurrentHPSDRModel == HPSDRModel.ANAN7000D || console.CurrentHPSDRModel == HPSDRModel.ANAN8000D ||
                   console.CurrentHPSDRModel == HPSDRModel.ANVELINAPRO3 || console.CurrentHPSDRModel == HPSDRModel.ANAN_G2 ||
				   console.CurrentHPSDRModel == HPSDRModel.ANAN_G2_1K)
            {
				return String.Format("{0:00.0}", console.MKIIPAVolts);
            }
            else if (console.CurrentHPSDRModel != HPSDRModel.HPSDR)
            {
				//int val = 0;
				//decimal volts = 0.0m;
				//volts = (decimal)val / 4096m * 2.5m * 11m;
				//return Decimal.Round(volts, 1).ToString();
				return "00.0";
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }
        }

        // Sets or reads the RX1 step attenuation control, 0 to 31dB
        public string ZZRX(string s)
        {
            int att = 0;

            if (s.Length == parser.nSet)    // if the length of the parameter legal for setting this prefix
            {
                att = Convert.ToInt32(s);
                att = Math.Max(0, att);
                att = Math.Min(31, att);
                console.SetupForm.ATTOnRX1 = att;        // Set the console control
                console.TitleBarEncoderString = "RX1 Step Atten = " + att + "dB";
                return "";
            }
            else if (s.Length == parser.nGet)   // if this is a read command
            {
                return AddLeadingZeros(console.SetupForm.ATTOnRX1);     // Get the console setting
            }
            else
            {
                return parser.Error1;   // return a ?
            }
        }

        // Sets or reads the RX2 step attenuation control, 0 to 31dB
        public string ZZRY(string s)
        {
            int att = 0;

            if (s.Length == parser.nSet)    // if the length of the parameter legal for setting this prefix
            {
                att = Convert.ToInt32(s);
                att = Math.Max(0, att);
                att = Math.Min(31, att);
                console.SetupForm.ATTOnRX2 = att; //RX2ATT = att;        // Set the console control // MW0LGE_21d step atten changes
				console.TitleBarEncoderString = "RX2 Step Atten = " + att + "dB";
                return "";
            }
            else if (s.Length == parser.nGet)   // if this is a read command
            {
                return AddLeadingZeros(console.SetupForm.ATTOnRX2 /*RX2ATT*/);     // Get the console setting // MW0LGE_21d step atten changes
			}
            else
            {
                return parser.Error1;   // return a ?
            }
        }

		//Moves VFO A down one Tune Step
		public string ZZSA()
		{
            try
            {
            int step = console.TuneStepIndex;
                List<TuneStep> tune_list = console.TuneStepList;
                console.VFOAFreq = console.CATVFOA - tune_list[step].StepHz * 10e-7;
			return "";
		}
            catch (Exception)
            {
                return parser.Error1;
            }
		}

		//Moves VFO A up one Tune Step
		public string ZZSB()
		{
            try
            {
            int step = console.TuneStepIndex;
                List<TuneStep> tune_list = console.TuneStepList;
                console.VFOAFreq = console.CATVFOA + tune_list[step].StepHz * 10e-7;
                return "";
            }
            catch (Exception)
            {
                return parser.Error1;
            }

		}

		//Moves the mouse wheel tuning step down
		public string ZZSD()
		{
			console.CATTuneStepDown();
			return "";
		}

		// ZZSFccccwwww  Set Filter, cccc=center freq www=width both in hz 
		public string ZZSF(string s)
		{
			int center = Convert.ToInt32(s.Substring(0,4), 10); 
			int width = Convert.ToInt32(s.Substring(4), 10); 
			SetFilterCenterAndWidth(center, width); 
			return "";
		}


        //Moves VFO B down one Tune Step
        public string ZZSG()
        {
            try
            {
            int step = console.TuneStepIndex;
                List<TuneStep> tune_list = console.TuneStepList;
                console.VFOBFreq = console.CATVFOB - tune_list[step].StepHz * 10e-7;
            return "";
        }
            catch (Exception)
            {
                return parser.Error1;
            }
		}


        //Moves VFO B up one Tune Step
        public string ZZSH()
        {
           try
            {
            int step = console.TuneStepIndex;
                List<TuneStep> tune_list = console.TuneStepList;
                console.VFOBFreq = console.CATVFOB + tune_list[step].StepHz * 10e-7;
            return "";
        }
            catch (Exception)
            {
                return parser.Error1;
            }
		}

		// Reads the S Meter value
		public string ZZSM(string s)
		{
			int sm = 0;

			if(s == "0" || s == "1")	// read the main transceiver s meter
			{
				float num = 0f;
                if (console.PowerOn)
                    if (s == "0")
                        num = WDSP.CalculateRXMeter(0, 0, WDSP.MeterType.SIGNAL_STRENGTH);
                    else
                        num = WDSP.CalculateRXMeter(2, 0, WDSP.MeterType.SIGNAL_STRENGTH);

                switch (console.CurrentHPSDRModel)
                {
                     case HPSDRModel.HPSDR:
                        num = num +
                        console.MultiMeterCalOffset +
                        Display.RX1PreampOffset +
                            //console.RX1FilterSizeCalOffset +
                        console.RX1XVTRGainOffset;
                        break;
                    default:
                        if (s == "0")
                        {
                            num = num +
                            console.MultiMeterCalOffset +
                            Display.RX1PreampOffset +
                                //console.RX1FilterSizeCalOffset +
                            console.RX1XVTRGainOffset;
                        }
                        else if (s == "1")
                        {
                            num = num +
                            console.RX2MeterCalOffset +
                            Display.RX2PreampOffset +
                                //console.RX2FilterSizeCalOffset +
                            console.RX2XVTRGainOffset;
                        }
                        break;
               }
                num = Math.Max(-140, num);
                num = Math.Min(-10, num);
                sm = ((int)num + 140) * 2;
                return sm.ToString().PadLeft(3, '0');
            }
            else
            {
                return parser.Error1;
            }
        }

        //Reads the radio serial number
        public string ZZSN()
        {
            string ret_val = console.SetupForm.SerialNumber;
                    // parser.Verbose_Error_Code = 7;
                   // ret_val = parser.Error1;

            return ret_val;
        }

		// Sets or reads the VFO Split status
		public string ZZSP(string s, bool bFromCatDirect = false)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if (bFromCatDirect && !console.IsSetupFormNull)
				{
					if (console.SetupForm.SplitFromCATorTCIcancelsQSPLIT)
					{
						if (console.SetupForm.QuickSplitEnabled)
							console.SetupForm.QuickSplitEnabled = false;
					}
				}

				if(s == "0")
					console.VFOSplit = false;
				else
					console.VFOSplit = true;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				bool retval = console.VFOSplit;
				if(!retval)
					return "0";
				else
					return "1";
			}
			else
			{
				return parser.Error1;
			}

		}

		// Sets or reads the Squelch on/off status
		public string ZZSO(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1" || s == "2")) //[2.10.3.5]MW0LGE 2 is vsql
			{
				console.CATSquelch = Convert.ToInt32(s);
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return console.CATSquelch.ToString();
			}
			else
				return parser.Error1;
		}

		// Sets or reads the SDR-1000 Squelch control
		public string ZZSQ(string s)
		{
			int level = 0;
            string OldSq;
            int ThisNset = 3;
            int TempNset = 1;

			if(s.Length == parser.nSet)
			{
				level = Convert.ToInt32(s);
				if (console.RX1DSPMode == DSPMode.FM)
				{
					level = Math.Max(0, level);         // lower bound
					level = Math.Min(100, level);       // upper bound
					level *= -1;
				}
				else
				{
                    level = Math.Max(0, level);
                    level = Math.Min(160, level);
                }
                OldSq = ZZSO("");
                if (OldSq == "0")
                {
                    parser.nSet = TempNset;
                    ZZSO("1");
                    parser.nSet = ThisNset;
                }
				console.Squelch = level * -1;
                console.TitleBarEncoderString = "RX1 Squelch = -" + level;
                parser.nSet = TempNset;
                ZZSO(OldSq);
                parser.nSet = ThisNset;
				return "";
			}
			else if(s.Length == parser.nGet)
				return AddLeadingZeros(Math.Abs(console.Squelch));
			else
				return parser.Error1;

		}
		
		//Reads or sets the Spur Reduction button status
		public string ZZSR(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				//if(s == "1")
				//	console.SpurReduction = true;
				//else
				//	console.SpurReduction = false;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				//if(console.SpurReduction)
				//	return "1";
				//else
					return "0";
			}
			else
				return parser.Error1;


		}

        public string ZZSS()
        {
            console.CWXForm.CWXStop();
            return "";
        } 

		// Reads the current console step size (read-only property)
		public string ZZST()
		{
            int step = console.TuneStepIndex;
			return Step2String(step);
		}

		// Moves the mouse wheel step tune up
		public string ZZSU()
		{
			console.CATTuneStepUp();
			return "";
		}

        // Sets or reads the RX2 Squelch button
        public string ZZSV(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1" || s == "2")) //[2.10.3.5]MW0LGE 2 is vsql
            {
				console.CATSquelch2 = Convert.ToInt32(s);
				return "";
            }
            else if (s.Length == parser.nGet)
            {
				return console.CATSquelch2.ToString();
            }
            else
				return parser.Error1;        
        }

        //Swaps VFO A/B TX buttons
        public string ZZSW(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                if (s == "0")
                    console.SwapVFOA_BTX = false;
                else if (s == "1")
                    console.SwapVFOA_BTX = true;

                return "";
            }
            else if (s.Length == parser.nGet)
            {
                bool retval = console.SwapVFOA_BTX;
                if (retval)
                    return "1";
                else
                    return "0";
            }
            else
            {
                return parser.Error1;
            }

        }

        //Sets or reads the RX2 Squelch threshold
        public string ZZSX(string s)
        {
                int level = 0;
                string OldSq;
                int ThisNset = 3;
                int TempNset = 1;

                if (s.Length == parser.nSet)
                {
                    level = Convert.ToInt32(s);
                    if (console.RX2DSPMode == DSPMode.FM)
                    {
                        level = Math.Max(0, level);			// lower bound
                        level = Math.Min(100, level);		// upper bound
                        level *= -1;
                    }
                    else
                    {
                        level = Math.Max(0, level);
                        level = Math.Min(160, level);
                    }
                    OldSq = ZZSV("");
                    if (OldSq == "0")
                    {
                        parser.nSet = TempNset;
                        ZZSV("1");
                        parser.nSet = ThisNset;
                    }
                    console.Squelch2 = level * -1;
                    console.TitleBarEncoderString = "RX2 Squelch = -" + level;
                    parser.nSet = TempNset;
                    ZZSV(OldSq);
                    parser.nSet = ThisNset;
                    return "";
                }
                else if (s.Length == parser.nGet)
                    return AddLeadingZeros(Math.Abs(console.Squelch2));
                else
                    return parser.Error1;

         }
                    


        //Reads or sets the VFO Sync button status
        public string ZZSY(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                if (s == "1")
                    console.VFOSync = true;
                else
                    console.VFOSync = false;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                if (console.VFOSync)
                    return "1";
                else
                    return "0";
            }
            else
                return parser.Error1;
        }

        //Syncs the chosen vfo to the selected tune step
        //write only
        public string ZZSZ(string s)
        {
            double oldfreq;
            double newfreq;
            int size = console.CurrentTuneStepHz;
            if (s == "0")
                oldfreq = console.VFOAFreq;
            else
                oldfreq = console.VFOBFreq;
            newfreq = console.SnapTune(oldfreq, size, 1);
            if (s == "0")
                console.VFOAFreq = newfreq;
            else
                console.VFOBFreq = newfreq;
            return "";
        }

        //Sets or reads the CTCSS enable button
        public string ZZTA(string s)
        {
            if (s.Length == parser.nSet)
            {
                if (s == "1")
                {
                    console.CTCSSOn = true;
                    return "";
                }
                else if (s == "0")
                {
                    console.CTCSSOn = false;
                    return "";
                }
                else
                    return parser.Error1;
            }
            else if (s.Length == parser.nGet)
            {
                if (console.CTCSSOn)
                    return "1";
                else
                    return "0";
            }
            else return parser.Error1;
        }

        //Sets or reads the CTCSS tone frequency
        public string ZZTB(string s)
        {
            if (s.Length == parser.nSet)
            {
                if (int.Parse(s) > 0 && int.Parse(s) <= 49)
                {
                    console.CTCSSFreq = String2CTCSSFreq(s);
                    return "";
                }
                else
                {
                    parser.Verbose_Error_Code = 9;
                    return parser.Error1;
                }
            }
            else if (s.Length == parser.nGet)
            {
                int freq = Convert.ToInt32(console.CTCSSFreq*10);
                return CTCSSFreq2String(freq);
            }
            else
                return parser.Error1;

        }

		// Sets or reads the Show TX Filter checkbox
		public string ZZTF(string s)
		{
			switch(console.RX1DSPMode)
			{
				case DSPMode.CWL:
				case DSPMode.CWU:
					return parser.Error1;
				default:
					if(s.Length == parser.nSet && (s == "0" || s == "1"))
					{
						if(s == "1")
							console.ShowTXFilter = true;
						else
							console.ShowTXFilter = false;
						return "";
					}
					else if(s.Length == parser.nGet)
					{
						if(console.ShowTXFilter)
							return "1";
						else
							return "0";
					}
					else
						return parser.Error1;
			}
		}


		// Sets or reads the TX filter high setting
		public string ZZTH(string s)
		{
			int th = 0;

			if(s.Length == parser.nSet)	// check the min/max control settings
			{
				th = Convert.ToInt32(s);
				th = Math.Max(500, th);
				th = Math.Min(20000, th);
				console.SetupForm.TXFilterHigh = th;		
				return "";
			}
			else if(s.Length == parser.nGet)	// if this is a read command
			{
				return AddLeadingZeros(console.SetupForm.TXFilterHigh);
			}
			else
			{
				return parser.Error1;	// return a ?
			}
		}

		//Inhibits power output when using external antennas, tuners, etc.
		public string ZZTI(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if(s == "0")
				{
					console.RXOnly = false;
				}
				else if(s == "1")
				{
					console.RXOnly = true;
					console.MOX = false;
				}

				return "";
			}
			else
				return parser.Error1;
		}

		// Sets or reads the TX filter low setting
		public string ZZTL(string s)
		{
			int tl = 0;

			if(s.Length == parser.nSet)	// check the min/max control settings
			{
				tl = Convert.ToInt32(s);
				tl = Math.Max(0, tl);
				tl = Math.Min(2000, tl);
				console.SetupForm.TXFilterLow = tl;		
				return "";
			}
			else if(s.Length == parser.nGet)	// if this is a read command
			{
				return AddLeadingZeros(console.SetupForm.TXFilterLow);
			}
			else
			{
				return parser.Error1;	// return a ?
			}
		}

        //Sets or reads the TX Monitor level
        public string ZZTM(string s)
        {
            int tm = 0;

            if (s.Length == parser.nSet)	// check the min/max control settings
            {
                tm = Convert.ToInt32(s);
                tm = Math.Max(0, tm);
                tm = Math.Min(100, tm);
                console.TXAF = tm;
                return "";
            }
            else if (s.Length == parser.nGet)	// if this is a read command
            {
                return AddLeadingZeros(console.TXAF);
            }
            else
            {
                return parser.Error1;	// return a ?
            }
        }


		//Sets or reads the Tune Power level
		public string ZZTO(string s)
		{
			int tl = 0;

			if(s.Length == parser.nSet)	// check the min/max control settings
			{
				tl = Convert.ToInt32(s);
				tl = Math.Max(0, tl);
				tl = Math.Min(100, tl);

                //MW0LGE_22b changed
                switch (console.TuneDrivePowerOrigin)
                {
					case DrivePowerSource.DRIVE_SLIDER:
						console.PWR = tl;
						break;
					case DrivePowerSource.TUNE_SLIDER:
						console.TunePWR = tl;
						break;
					case DrivePowerSource.FIXED:
						if(!console.IsSetupFormNull)
							console.SetupForm.FixedTunePower = tl;
						break;
                }

				//if (console.TXTunePower) console.PWR = tl; //MW0LGE_22b changed
				//else console.SetupForm.TunePower = tl;
		
				return "";
			}
			else if(s.Length == parser.nGet)	// if this is a read command
			{
				int tp = 0;
                switch (console.TuneDrivePowerOrigin)
                {
					case DrivePowerSource.DRIVE_SLIDER:
						if (console.SendLimitedPowerLevels)
							tp = console.PWRConstrained;
						else
							tp = console.PWR;
						break;
					case DrivePowerSource.TUNE_SLIDER:
						if (console.SendLimitedPowerLevels)
							tp = console.TunePWRConstrained;
						else
							tp = console.TunePWR;
						break;
					case DrivePowerSource.FIXED:
						tp = console.SetupForm.FixedTunePower;
						break;
                }
				return AddLeadingZeros(tp);

				//MW0LGE_22b changed
				//if (console.TXTunePower) return AddLeadingZeros(console.PWR);
				//else return AddLeadingZeros(console.SetupForm.TunePower);
			}
			else
			{
				return parser.Error1;	// return a ?
			}
		}


		//Sets or reads the TX Profile
		public string ZZTP(string s)
		{
			int items = console.CATTXProfileCount;
			int cnt = 0;
			if(s != "")
				cnt = Convert.ToInt32(s);

			if(s.Length == parser.nSet && cnt < items)
			{
				console.CATTXProfile = cnt;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				return AddLeadingZeros(console.CATTXProfile);
			}
			else
				return parser.Error1;
		}

		// Reads the Flex 5000 temperature sensor
        public string ZZTS()
        {
            if ((console.CurrentHPSDRModel == HPSDRModel.HERMES) ||
                (console.CurrentHPSDRModel == HPSDRModel.HERMESLITE))		// MI0BOT: HL2
            {
                int val = 0;
                float volts = 0.0f;
                double temp2 = 0.0f;

                int chan = 4;

                //FWC.ReadPAADC(chan, out val);
                volts = (float)val / 4096 * 2.5f;
                double temp = 301 - volts * 1000 / 2.2;

                if (temp >= 100f)
                    temp2 = Math.Round(temp, 1);
                else
                    temp2 = Math.Round(temp, 2);

                return temp2.ToString().PadLeft(5, '0');
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }
        }

		// Sets or reads the TUN button on/off status
		public string ZZTU(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if(s == "0")
					console.TUN = false;
				else if(s == "1")
					console.TUN = true;

				return "";
			}
			else if(s.Length == parser.nGet)
			{
				bool retval = console.TUN;
				if(retval)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}

		}
		
		//Sets or reads the transmit VFO frequency when in split with RX2 enabled
		public string ZZTV(string s)
        {
            if (ZZRS("") == "1" && (ZZSP("") == "1" || ZZMU("") == "1"))
            {
                if (s.Length == parser.nSet)
                {
                    console.VFOASubFreq = double.Parse(s) / 1e6;
                    return "";
                }
                else if (s.Length == parser.nGet)
                {
                    int f = Convert.ToInt32(Math.Round(console.VFOASubFreq, 6) * 1e6);
                    return AddLeadingZeros(f);
                }
            else
                return parser.Error1;
            }
            else
            {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
            }
          
        }

		//Sets or reads the MOX button status
		public string ZZTX(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if(s == "0")
					console.CATPTT = false;
				else if(s == "1")
					console.CATPTT = true;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				if(console.CATPTT || console.MOX)
					return "1";
				else
					return "0";
			}
			else
				return parser.Error1;

		}

		//Reads the XVTR Band Names
		public string ZZUA()
		{
			string ans = console.CATGetXVTRBandNames();
			return ans;
		}

		// Reads or sets the VAC Enable checkbox (Setup Form)
		public string ZZVA(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if(s == "1")
					console.SetupForm.VACEnable = true;
				else
					console.SetupForm.VACEnable = false;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				if(console.SetupForm.VACEnable)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}

		}
		public string ZZUP(string s)  //-MW0LGE_21j  xPA on/off
		{
			if (s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				switch (s)
				{
					case "0":
						console.CATxPA = false;
						break;
					case "1":
						console.CATxPA = true;
						break;
				}

				return "";
			}
			else if (s.Length == parser.nGet)
			{
				if (console.CATxPA)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}
		}
		
		public string ZZUS()  //-W2PA  Initiate PS Single Cal
        {
            console.CATSingleCal();
            return "";
        }

        public string ZZUT(string s)  //-W2PA  Toggle two tone test  
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                switch (s)
                {
                    case "0":
                        console.CATTTTest = 0;
                        break;
                    case "1":
                        console.CATTTTest = 1;

                        break;
                }

                return "";
            }
            else if (s.Length == parser.nGet)
            {
                if (console.CATTTTest == 1)
                    return "1";
                else
                    return "0";
            }
            else
            {
                return parser.Error1;
            }
        }


		/// <summary>
		/// Sets or reads the VAC RX Gain 
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public string ZZVB(string s)
		{
			int n = 0;
			int x = 0;
			string sign;

			if(s != "")
			{
				n = Convert.ToInt32(s);
				n = Math.Max(-40, n);
				n = Math.Min(40, n); // DH1KLM_21g Changed value from 20 to 40 like it is in VAC2 RX Gain
			}

			if(s.Length == parser.nSet)
			{
				console.VACRXGain = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				x = console.VACRXGain;
				if(x >= 0)
					sign = "+";
				else
					sign = "-";
				// we have to remove the leading zero and replace it with the sign.
				return sign+AddLeadingZeros(Math.Abs(x)).Substring(1);
			}
			else
			{
				return parser.Error1;
			}
		}

		/// <summary>
		/// Sets or reads the VAC TX Gain
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public string ZZVC(string s)
		{
			int n = 0;
			int x = 0;
			string sign;

			if(s != "")
			{
				n = Convert.ToInt32(s);
				n = Math.Max(-40, n);
				n = Math.Min(40, n); // DH1KLM_21g Changed value from 20 to 40 like it is in VAC2 TX Gain
			}

			if(s.Length == parser.nSet)
			{
				console.VACTXGain = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				x = console.VACTXGain;
				if(x >= 0)
					sign = "+";
				else
					sign = "-";
				// we have to remove the leading zero and replace it with the sign.
				return sign+AddLeadingZeros(Math.Abs(x)).Substring(1);
			}
			else
			{
				return parser.Error1;
			}
		}

		/// <summary>
		/// Sets or reads the VAC Sample Rate
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public string ZZVD(string s)
		{
			int n = -1;

			if(s.Length == parser.nSet)
			{
				n = Convert.ToInt32(s);
				switch(n)
				{
					case 0:
						console.VACSampleRate = "6000";
						break;
					case 1:
						console.VACSampleRate = "8000";
						break;
					case 2:
						console.VACSampleRate = "11025";
						break;
					case 3:
						console.VACSampleRate = "12000";
						break;
					case 4:
						console.VACSampleRate = "24000";
						break;
					case 5:
						console.VACSampleRate = "22050";
						break;
					case 6:
						console.VACSampleRate = "44100";
						break;
					case 7:
						console.VACSampleRate = "48000";
						break;
				}
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				string rate = console.VACSampleRate;
				string ans = "";

				switch(rate)
				{
					case "6000":
						ans = "0";
						break;
					case "8000":
						ans = "1";
						break;
					case "11025":
						ans = "2";
						break;
					case "12000":
						ans = "3";
						break;
					case "24000":
						ans = "4";
						break;
					case "22050":
						ans = "5";
						break;
					case "44100":
						ans = "6";
						break;
					case "48000":
						ans = "7";
						break;
                    case "96000":
                        ans = "8";
                        break;
                    case "192000":
                        ans = "9";
                        break;
					default:
						ans = parser.Error1;
						break;
				}
				return ans;
			}
			else
			{
				return parser.Error1;
			}
		}

		//Reads or sets the VOX Enable button status
		public string ZZVE(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if(s == "1")
					console.VOXEnable = true;
				else
					console.VOXEnable = false;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				if(console.VOXEnable)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}
		}
		//Reads or sets the Quick Play button status // DH1KLM
		public string ZZQA(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if(s == "1")
					console.QuickPlay = true;
				else
					console.QuickPlay = false;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				if(console.QuickPlay)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}
		}
        //Reads or sets the Quick Rec button status // DH1KLM
        public string ZZQB(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                if (s == "1")
                    console.QuickRec = true;
                else
                    console.QuickRec = false;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                if (console.QuickRec)
                    return "1";
                else
                    return "0";
            }
            else
            {
                return parser.Error1;
            }
        }
        /// <summary>
        /// Sets or reads the VAC Stereo checkbox
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ZZVF(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if(s == "1")
					console.VACStereo = true;
				else
					console.VACStereo = false;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				if(console.VACStereo)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}

		}

		//Reads or set the VOX Gain control
		public string ZZVG(string s)
		{
			int n = 0;
            double voxextent = 0.0;
            double voxmin = 0.0;
            double scale_by = 0.0;
            voxextent = (double)console.VOXSensExtent;
            voxmin = (double)console.VOXSensMin;

			if(s != null && s != "")
				n = Convert.ToInt32(s);
			n = Math.Max(0, n);
			n = Math.Min(1000, n);

			if(s.Length == parser.nSet)
			{
                scale_by = n / 1000.0;
                console.VOXSens = (int) (voxmin + voxextent*scale_by);
                console.TitleBarEncoderString = "Vox Gain = " + console.VOXSens + "dB";
				return "";
			}
			else if(s.Length == parser.nGet)
			{
                n= (int) (((double)console.VOXSens - voxmin) * 1000 / voxextent);
				return AddLeadingZeros(n);
			}
			else
			{
				return parser.Error1;
			}

		}

		// Reads or sets the I/Q to VAC checkbox on the setup form
		public string ZZVH(string s)
		{
			if(s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if(s == "0")
					console.SetupForm.IQOutToVAC = false;
				else if(s == "1")
					console.SetupForm.IQOutToVAC = true;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				bool retval = console.SetupForm.IQOutToVAC;
				if(retval)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}
		}

        // Reads or sets the VAC Input cable
        public string ZZVI(string s)
        {
            if (s.Length == parser.nSet)
            {
                console.SetupForm.VACInputCable = Convert.ToInt32(s);
                return "";
            }

            if (s.Length == parser.nGet)
            {
                return AddLeadingZeros(console.SetupForm.VACInputCable);
            }
            else
                return parser.Error1;
        } 

        //Reads or sets the Direct I/Q Use RX2 checkbox
        public string ZZVJ(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1") && console.SetupForm.IQOutToVAC)
            {
                if (s == "0")
                    console.SetupForm.VACUseRX2 = false;
                else if (s == "1")
                    console.SetupForm.VACUseRX2 = true;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                bool retval = console.SetupForm.VACUseRX2;
                if (retval)
                    return "1";
                else
                    return "0";
            }
            else
                return parser.Error1;

        } 

        // Reads or sets the VAC2 Enable checkbox (Setup Form)
        public string ZZVK(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                if (s == "1")
                    console.SetupForm.VAC2Enable = true;
                else
                    console.SetupForm.VAC2Enable = false;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                if (console.SetupForm.VAC2Enable)
                    return "1";
                else
                    return "0";
            }
            else
            {
                return parser.Error1;
            }

        }


		// Reads or sets the VFO Lock button status
		public string ZZVL(string s)
		{
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                switch (console.VFOLock)
                {
                    case CheckState.Unchecked:
                        console.CATVFOLock = true;
                        console.CATVFOBLock = false;
                        console.VFOLock = CheckState.Checked;
                        break;
                    case CheckState.Checked:
                        console.CATVFOLock = true;
                        console.CATVFOBLock = true;
                        console.VFOLock = CheckState.Indeterminate;
                        break;
                    case CheckState.Indeterminate:
                        console.CATVFOLock = false;
                        console.CATVFOBLock = false;
                        console.VFOLock = CheckState.Unchecked;
                        break;
                }
      
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                if (console.CATVFOLock || console.CATVFOBLock)
                    return "1";
                else
                    return "0";
            }
            else
            {
                return parser.Error1;
            }
        }

        //-W2PA  Out of alphabetical order a bit, but related to ZZVL above. 
        //       Added two functions to individually lock VFO A and B.

        public string ZZUX(string s)  //-W2PA  Lock VFOA  
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                switch (s)
                {
                    case "0":
                        console.VFOALock = false;
                        console.CATVFOLock = false;
                        break;
                    case "1":
                        console.VFOALock = true;
                        console.CATVFOLock = true;
                        break;
                }

                return "";
            }
            else if (s.Length == parser.nGet)
            {
                if (console.VFOLock == CheckState.Checked || console.VFOALock == true || console.CATVFOLock)
                    return "1";
                else
                    return "0";
            }
            else
            {
                return parser.Error1;
            }
        }

        public string ZZUY(string s)  //-W2PA  Lock VFOB  
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                switch (s)
                {
                    case "0":
                        console.VFOBLock = false;
                        console.CATVFOBLock = false;
                        break;
                    case "1":
                        console.VFOBLock = true;
                        console.CATVFOBLock = true;
                        break;
                }

                return "";
            }
            else if (s.Length == parser.nGet)
            {
                if (console.VFOBLock || console.VFOLock == CheckState.Indeterminate || console.CATVFOBLock)
                    return "1";
                else
                    return "0";
            }
            else
            {
                return parser.Error1;
            }
        }

        // Reads or sets the VAC Driver
        public string ZZVM(string s)
        {
            if (s.Length == parser.nSet)
            {
                console.SetupForm.VACDriver = Convert.ToInt32(s);
                return "";
            }

            if (s.Length == parser.nGet)
            {
                return AddLeadingZeros(console.SetupForm.VACDriver);
            }
            else
                return parser.Error1;
        } 


		// Returns the version number of the PowerSDR program
		public string ZZVN()
		{
			//return console.CATGetVersion().PadLeft(12,'0');
			return Common.GetFileVersion().PadLeft(12, '0');
		}

        // Reads or sets the VAC Output cable
        public string ZZVO(string s)
        {
            if (s.Length == parser.nSet)
            {
                console.SetupForm.VACOutputCable = Convert.ToInt32(s);
                return "";
            }

            if (s.Length == parser.nGet)
            {
                return AddLeadingZeros(console.SetupForm.VACOutputCable);
            }
            else
                return parser.Error1;
        }

        // Reads or sets the VAC1 IQ Calibrate checkbox on the setup form
        public string ZZVP(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                if (s == "0")
                    console.SetupForm.VAC1Calibrate = false;
                else if (s == "1")
                    console.SetupForm.VAC1Calibrate = true;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                bool retval = console.SetupForm.VAC1Calibrate;
                if (retval)
                    return "1";
                else
                    return "0";
            }
            else
            {
                return parser.Error1;
            }
        }

        // Reads or sets the VAC2 Driver
        public string ZZVQ(string s)
        {
            if (s.Length == parser.nSet)
            {
                console.SetupForm.VAC2Driver = Convert.ToInt32(s);
                return "";
            }

            if (s.Length == parser.nGet)
            {
                return AddLeadingZeros(console.SetupForm.VAC2Driver);
            }
            else
                return parser.Error1;
        }

        // Reads or sets the VAC2 Input cable
        public string ZZVR(string s)
        {
            if (s.Length == parser.nSet)
            {
                console.SetupForm.VAC2InputCable = Convert.ToInt32(s);
                return "";
            }

            if (s.Length == parser.nGet)
            {
                return AddLeadingZeros(console.SetupForm.VAC2InputCable);
            }
            else
                return parser.Error1;
        }

        // Sets the VFO swap status
		// write only
		public string ZZVS(string s)
		{
			if(s.Length == parser.nSet & Convert.ToInt32(s) <= 3)
			{
				console.CATVFOSwap(s);
				return "";
			}
			else
			{
				return parser.Error1;
			}

		}

        // Reads or sets the VAC2 Output cable
        public string ZZVT(string s)
        {
            if (s.Length == parser.nSet)
            {
                console.SetupForm.VAC2OutputCable = Convert.ToInt32(s);
                return "";
            }

            if (s.Length == parser.nGet)
            {
                return AddLeadingZeros(console.SetupForm.VAC2OutputCable);
            }
            else
                return parser.Error1;
        }

        /// <summary>
        /// Sets or reads the VAC2 Sample Rate
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ZZVU(string s)
        {
            int n = -1;

            if (s.Length == parser.nSet)
            {
                n = Convert.ToInt32(s);
                switch (n)
                {
                    case 0:
                        console.SetupForm.VAC2SampleRate = "6000";
                        break;
                    case 1:
                        console.SetupForm.VAC2SampleRate = "8000";
                        break;
                    case 2:
                        console.SetupForm.VAC2SampleRate = "11025";
                        break;
                    case 3:
                        console.SetupForm.VAC2SampleRate = "12000";
                        break;
                    case 4:
                        console.SetupForm.VAC2SampleRate = "24000";
                        break;
                    case 5:
                        console.SetupForm.VAC2SampleRate = "22050";
                        break;
                    case 6:
                        console.SetupForm.VAC2SampleRate = "44100";
                        break;
                    case 7:
                        console.SetupForm.VAC2SampleRate = "48000";
                        break;
                    case 8:
                        console.SetupForm.VAC2SampleRate = "96000";
                        break;
                    case 9:
                        console.SetupForm.VAC2SampleRate = "192000";
                        break;
                }
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                string rate = console.SetupForm.VAC2SampleRate;
                string ans = "";

                switch (rate)
                {
                    case "6000":
                        ans = "0";
                        break;
                    case "8000":
                        ans = "1";
                        break;
                    case "11025":
                        ans = "2";
                        break;
                    case "12000":
                        ans = "3";
                        break;
                    case "24000":
                        ans = "4";
                        break;
                    case "22050":
                        ans = "5";
                        break;
                    case "44100":
                        ans = "6";
                        break;
                    case "48000":
                        ans = "7";
                        break;
                    case "96000":
                        ans = "8";
                        break;
                    case "192000":
                        ans = "9";
                        break;
                    default:
                        ans = parser.Error1;
                        break;
                }
                return ans;
            }
            else
            {
                return parser.Error1;
            }
        }

        /// Sets or reads the VAC2 Stereo checkbox
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ZZVV(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                if (s == "1")
                    console.SetupForm.VAC2Stereo = true;
                else
                    console.SetupForm.VAC2Stereo = false;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                if (console.SetupForm.VAC2Stereo)
                    return "1";
                else
                    return "0";
            }
            else
            {
                return parser.Error1;
            }

        }

        public string ZZVW(string s)
        {
            int n = 0;
            int x = 0;
            string sign;

            if (s != "")
            {
                n = Convert.ToInt32(s);
                n = Math.Max(-40, n);
                n = Math.Min(40, n);
            }

            if (s.Length == parser.nSet)
            {
                console.SetupForm.VAC2RXGain = n;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                x = console.SetupForm.VAC2RXGain;
                if (x >= 0)
                    sign = "+";
                else
                    sign = "-";
                // we have to remove the leading zero and replace it with the sign.
                return sign + AddLeadingZeros(Math.Abs(x)).Substring(1);
            }
            else
            {
                return parser.Error1;
            }
        }

        /// <summary>
        /// Sets or reads the VAC2 TX Gain
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ZZVX(string s)
        {
            int n = 0;
            int x = 0;
            string sign;

            if (s != "")
            {
                n = Convert.ToInt32(s);
                n = Math.Max(-40, n);
                n = Math.Min(40, n);
            }

            if (s.Length == parser.nSet)
            {
                console.SetupForm.VAC2TXGain = n;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                x = console.SetupForm.VAC2TXGain;
                if (x >= 0)
                    sign = "+";
                else
                    sign = "-";
                // we have to remove the leading zero and replace it with the sign.
                return sign + AddLeadingZeros(Math.Abs(x)).Substring(1);
            }
            else
            {
                return parser.Error1;
            }
        }

        /// <summary>
        /// Sets or reads the VAC1 Buffer Size
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ZZVY(string s)
        {
            int n = -1;

            if (s.Length == parser.nSet)
            {
                n = Convert.ToInt32(s);
                switch (n)
                {
                    case 0:
                        console.SetupForm.VAC1BufferSize = "512";
                        break;
                    case 1:
                        console.SetupForm.VAC1BufferSize = "1024";
                        break;
                    case 2:
                        console.SetupForm.VAC1BufferSize = "2048";
                        break;
                }
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                string rate = console.SetupForm.VAC1BufferSize;
                string ans = "";

                switch (rate)
                {
                    case "512":
                        ans = "0";
                        break;
                    case "1024":
                        ans = "1";
                        break;
                    case "2048":
                        ans = "2";
                        break;
                    default:
                        ans = parser.Error1;
                        break;
                }
                return ans;
            }
            else
            {
                return parser.Error1;
            }
        }

        /// <summary>
        /// Sets or reads the VAC1 Buffer Size
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ZZVZ(string s)
        {
            int n = -1;

            if (s.Length == parser.nSet)
            {
                n = Convert.ToInt32(s);
                switch (n)
                {
                    case 0:
                        console.SetupForm.VAC2BufferSize = "512";
                        break;
                    case 1:
                        console.SetupForm.VAC2BufferSize = "1024";
                        break;
                    case 2:
                        console.SetupForm.VAC2BufferSize = "2048";
                        break;
                }
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                string rate = console.SetupForm.VAC2BufferSize;
                string ans = "";

                switch (rate)
                {
                    case "512":
                        ans = "0";
                        break;
                    case "1024":
                        ans = "1";
                        break;
                    case "2048":
                        ans = "2";
                        break;
                    default:
                        ans = parser.Error1;
                        break;
                }
                return ans;
            }
            else
            {
                return parser.Error1;
            }
        }

        //Sets or reads the F5K Mixer Mic Gain
		public string ZZWA(string s)
		{
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		//Sets or reads the F5K Line In RCA level
		public string ZZWB(string s)
		{
               parser.Verbose_Error_Code = 7;
               return parser.Error1;
		}

		//Sets or reads the F5K Line In Phono level
		public string ZZWC(string s)
		{
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		//Sets or reads the F5K Mixer Line In DB9 level
		public string ZZWD(string s)
		{               
            parser.Verbose_Error_Code = 7;
            return parser.Error1;
		}


		// Sets or reads the F1500F5K Mixer Mic Selected Checkbox
		public string ZZWE(string s)
		{
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		// Sets or reads the F5K Mixer Line In RCA Checkbox
		public string ZZWF(string s)
		{
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		// Sets or reads the F5K Mixer Line In Phono Checkbox
		public string ZZWG(string s)
		{
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		// Sets or reads the F1500/F5K Mixer Line In FlexWire/DB9 Checkbox
		public string ZZWH(string s)
		{
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		} 


		// Sets or reads the F5K Mixer Mute All Checkbox
		public string ZZWJ(string s)
		{
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		//Sets or reads the F5K Mixer Internal Speaker level
		public string ZZWK(string s)
		{
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		//Sets or reads the F5K Mixer External Speaker level
		public string ZZWL(string s)
		{
                 parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		//Sets or reads the F5K Mixer Headphone level
		public string ZZWM(string s)
		{
               parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		//Sets or reads the F5K Mixer Line Out RCA level
		public string ZZWN(string s)
		{
               parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		// Sets or reads the F5KC Mixer Internal Speaker Selected Checkbox
		public string ZZWO(string s)
		{
               parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		// Sets or reads the F5K Mixer External Speaker Selected Checkbox
		public string ZZWP(string s)
		{
                 parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		// Sets or reads the F1500F5K Mixer Headphone Selected Checkbox
		public string ZZWQ(string s)
		{
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		// Sets or reads the F1500 FlexWire Out/F5K Mixer Line Out RCA Selected Checkbox
		public string ZZWR(string s)
		{
                 parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

		// Sets or reads the F1500/F5K Mixer Output Mute All Checkbox
		public string ZZWS(string s)
		{
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}


        //Reads or sets the F1500 mixer form mic level
        public string ZZWT(string s)
        {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
		}

        //Reads or sets the F1500 Mixer Form FireWire Input Level
        public string ZZWU(string s)
        {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
        }

        //Sets ir reads the F1500 Mixer Form Phones level
        public string ZZWV(string s)
        {
               parser.Verbose_Error_Code = 7;
                return parser.Error1;
        }

        //Sets or reads the F1500 Mixer Form FlexWire Out level
        public string ZZWW(string s)
        {
                parser.Verbose_Error_Code = 7;
                return parser.Error1;
        }

		// Clears the XIT frequency
		// write only
		public string ZZXC()
		{
			console.XITValue = 0;
			return "";
		}

        //Decrements XIT
        public string ZZXD(string s)
        {
            if (s.Length == parser.nSet)
            {
                return ZZXF(s);
            }
            else if (s.Length == parser.nGet) // && console.RITOn)  //-W2PA Want to be able to change RIT value even if it's off
            {
                //switch(console.RX1DSPMode)
                //{
                //	case DSPMode.CWL:
                //	case DSPMode.CWU:
                //		console.RITValue -= 10;
                //		break;
                //	case DSPMode.LSB:
                //	case DSPMode.USB:
                //		console.RITValue -= 50;  
                //                    break;
                //            }
                console.XITValue -= 10;  //-W2PA Changed to be same step in all modes.
                return "";
            }
            else
                return parser.Error1;
        }

		// Sets or reads the XIT frequency value
		public string ZZXF(string s)
		{
			int n = 0;
			int x = 0;
			string sign;

			if(s != "")
			{
				n = Convert.ToInt32(s);
				n = Math.Max(-99999, n);
				n = Math.Min(99999, n);
			}

			if(s.Length == parser.nSet)
			{
				console.XITValue = n;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				x = console.XITValue;
				if(x >= 0)
					sign = "+";
				else
					sign = "-";
				// we have to remove the leading zero and replace it with the sign.
				return sign+AddLeadingZeros(Math.Abs(x)).Substring(1);
			}
			else
			{
				return parser.Error1;
			}
		}

        //Reads or set the VOX Delay control
        public string ZZXH(string s)
        {
            int n = 0;
            double delaytime;

            if (s != null && s != "")
                n = Convert.ToInt32(s);
            n = Math.Max(0, n);
            n = Math.Min(4000, n);
            delaytime = (double)n;
            if (s.Length == parser.nSet)
            {
                console.VOXHangTime = delaytime;
                console.TitleBarEncoderString = "Vox Delay = " + delaytime/1000 + "s";
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                n = (int)console.VOXHangTime;
                return AddLeadingZeros(n);
            }
            else
            {
                return parser.Error1;
            }

        }

        //Reads RX1 combined status
        public string ZZXN(string s)
        {
            int n = 0;
            int m_agc = 0;
            int m_att = 0;
            if (s.Length == parser.nGet)
            {
                m_agc = (int)console.RX1AGCMode;
                m_agc &= 7;                  // strip to 3 bits
                m_att = (int)console.CATPreamp;
                m_att = (m_att & 7) << 3;           // 3 bits, moved left
                n = m_agc + m_att;
                if (console.CATSquelch != 0)
                    n += (1 << 6);
                if (console.CATNB1 != 0)
                    n += (1 << 7);
                if (console.CATNB2 != 0)
                    n += (1 << 8);
                if (console.CATNR != 0)
                    n += (1 << 9);
                if (console.CATNR2 != 0)
                    n += (1 << 10);
                if (console.CATSNB != 0)
                    n += (1 << 11);
                if (console.CATANF != 0)
                    n += (1 << 12);
                return AddLeadingZeros(n);
            }
            else
            {
                return parser.Error1;
            }
        }

        //Reads RX2 combined status
        public string ZZXO(string s)
        {
            int n = 0;
            int m_agc = 0;
            int m_att = 0;
            if (s.Length == parser.nGet)
            {
                m_agc = (int)console.RX2AGCMode;
                m_agc &= 7;                  // strip to 3 bits
                m_att = (int)console.RX2PreampMode;
                m_att = (m_att & 7) << 3;           // 3 bits, moved left
                n = m_agc + m_att;
                if (console.CATSquelch2 != 0)
                    n += (1 << 6);
                if (console.CATRX2NB1 != 0)
                    n += (1 << 7);
                if (console.CATRX2NB2 != 0)
                    n += (1 << 8);
                if (console.CATRX2NR != 0)
                    n += (1 << 9);
                if (console.CATRX2NR2 != 0)
                    n += (1 << 10);
                if (console.CATRX2SNB != 0)
                    n += (1 << 11);
                if (console.CATRX2ANF != 0)
                    n += (1 << 12);
                return AddLeadingZeros(n);
            }
            else
            {
                return parser.Error1;
            }
        }

		//Sets or reads the XIT button status
		public string ZZXS(string s)
		{
			if(s.Length == parser.nSet)
			{
				if(s == "0")
					console.XITOn = false;
				else
					if(s == "1") 
					console.XITOn = true;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				bool xit = console.XITOn;
				if(xit)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}
		}

		//Sets or reads the X2TR button status
		public string ZZXT(string s)
		{
			if(s.Length == parser.nSet)
			{
				if(s == "0")
					console.X2TR = false;
				else if(s == "1")
					console.X2TR = true;
				return "";
			}
			else if(s.Length == parser.nGet)
			{
				bool x2tr = console.X2TR;
				if(x2tr)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}
		}

        //Increments XIT
        public string ZZXU(string s)
        {
            if (s.Length == parser.nSet)
            {
                return ZZXF(s);
            }
            else if (s.Length == parser.nGet) // && console.RITOn)  //-W2PA Want to be able to change RIT value even if it's off
            {
                //switch(console.RX1DSPMode)
                //{
                //	case DSPMode.CWL:
                //	case DSPMode.CWU:
                //		console.RITValue -= 10;
                //		break;
                //	case DSPMode.LSB:
                //	case DSPMode.USB:
                //		console.RITValue -= 50;  
                //                    break;
                //            }
                console.XITValue += 10;  //-W2PA Changed to be same step in all modes.
                return "";
            }
            else
                return parser.Error1;
        }

        //Reads VFO combined status
        public string ZZXV(string s)
        {
            int n = 0;
            if (s.Length == parser.nGet)
            {
                if (console.RITOn == true)
                    n += 1;
                if (console.VFOLock == CheckState.Checked || console.VFOALock == true || console.CATVFOLock)         // VFO A lock
                    n += (1 << 1);
                if (console.VFOBLock || console.VFOLock == CheckState.Indeterminate || console.CATVFOBLock)         // VFO B lock
                    n += (1 << 2);
                if (console.VFOSplit == true)
                    n += (1 << 3);
                if (console.CTuneDisplay == true)
                    n += (1 << 4);
                if (console.CTuneRX2Display == true)
                    n += (1 << 5);
                if ((console.CATPTT == true)||(console.MOX == true))
                    n += (1 << 6);
                if (console.TUN == true)
                    n += (1 << 7);
                if (console.XITOn == true)
                    n += (1 << 8);
                if (console.VFOSync == true)
                    n += (1 << 9);
                return AddLeadingZeros(n);
            }
            else
            {
                return parser.Error1;
            }
        }
        // Reads or sets the VAC2 Direct I/Q checkbox on the setup form
        public string ZZYA(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                if (s == "0")
                    console.SetupForm.VAC2DirectIQ = false;
                else if (s == "1")
                    console.SetupForm.VAC2DirectIQ = true;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                bool retval = console.SetupForm.VAC2DirectIQ;
                if (retval)
                    return "1";
                else
                    return "0";
            }
            else
            {
                return parser.Error1;
            }
        }

        // Reads or sets the VAC2 IQ Calibrate checkbox on the setup form
        public string ZZYB(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                if (s == "0")
                    console.SetupForm.VAC2Calibrate = false;
                else if (s == "1")
                    console.SetupForm.VAC2Calibrate = true;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                bool retval = console.SetupForm.VAC2Calibrate;
                if (retval)
                    return "1";
                else
                    return "0";
            }
            else
            {
                return parser.Error1;
            }
        }

        //Reads or sets the FM mic gain
        public string ZZYC(string s)
        {
            int n = 0;

            if (s != null && s != "")
                n = Convert.ToInt32(s);
            n = Math.Max(0, n);
            n = Math.Min(70, n);

            if (s.Length == parser.nSet)
            {
                console.FMMic = n;
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return AddLeadingZeros((int)console.FMMic);
            }
            else
            {
                return parser.Error1;
            }

        }
        // Sets or reads the Rx1/RX2 radio button in collapsed mode
        public string ZZYR(string s)
        {
            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                console.CATRX1RX2RadioButton = Convert.ToInt32(s);
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return console.CATRX1RX2RadioButton.ToString();
            }
            else
            {
                return parser.Error1;
            }
        }

        public string ZZZB()
		{
			if(console.CATDisplayAvg == 1)
				console.CATZB = "1";
			return "";
		}

		public string ZZZZ()
		{
			console.Siolisten.SIO.Close();
			return "";
		}

		// Zooms to band MW0LGE_21k9
		// depending on ztb mode
		// 0 will recall
		// 1 will store
		// query will return 1 if ztb is set up as store/recall 
		public string ZZZT(string s)
		{
			if (s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if (s == "0") // recall
				{
					console.ZoomToBand(false);
				}
				else if (s == "1") // store
                {
					console.ZoomToBand(true);
				}
				return "";
			}
			else if (s.Length == parser.nGet)
			{
				if (console.ZTBisRecallStore)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}
		}
		public string ZZZQ(string s)
		{
			if (s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if (s == "0")
				{
					console.AutoAGCRX1 = false;
				}
				else if (s == "1")
				{
					console.AutoAGCRX1 = true;
				}
				return "";
			}
			else if (s.Length == parser.nGet)
			{
				if (console.AutoAGCRX1)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}
		}
		public string ZZZR(string s)
		{
			if (s.Length == parser.nSet && (s == "0" || s == "1"))
			{
				if (s == "0")
				{
					console.AutoAGCRX2 = false;
				}
				else if (s == "1")
				{
					console.AutoAGCRX2 = true;
				}
				return "";
			}
			else if (s.Length == parser.nGet)
			{
				if (console.AutoAGCRX2)
					return "1";
				else
					return "0";
			}
			else
			{
				return parser.Error1;
			}
		}
		// hardware model string
		public string ZZZM(string s)
		{
			if (s.Length == parser.nGet)
			{
				// add command to the return string and terminator, because it is variable length answer
				return "ZZZM" + console.CurrentHPSDRModel.ToString() + ";";
			}
			else
				return parser.Error1;
		}
		// hardware version title string
		public string ZZZV(string s)
		{
			if (s.Length == parser.nGet)
			{
				// add command to the return string and terminator, because it is variable length answer
				return "ZZZV" + console.VersionWithoutFW.Replace(";", "") + ";";
			}
			else
				return parser.Error1;
		}
		// swap vfo wheels, vfoA becomes vfoB, B becomes A
        public string ZZZW(string s)
        {
			if (console is null || console.Midi2Cat is null) return parser.Error1;

            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
				console.Midi2Cat.SwapVFOWheelsProperty = (s == "1");
                return "";
            }
            else if (s.Length == parser.nGet)
            {
				return console.Midi2Cat.SwapVFOWheelsProperty ? "1" : "0";
            }
            else
            {
                return parser.Error1;
            }
        }
		//[2.10.1.0]MW0LGE enable/disable quick split mode
		public string ZZZN(string s)
		{
            if (console is null || console.Midi2Cat is null) return parser.Error1;

            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
				if(!console.IsSetupFormNull)
					console.SetupForm.QuickSplitEnabled = (s == "1");
                return "";
            }
            else if (s.Length == parser.nGet)
            {
				bool bRet = false;
				if (!console.IsSetupFormNull) bRet = console.SetupForm.QuickSplitEnabled;
                return bRet ? "1" : "0";
            }
            else
            {
                return parser.Error1;
            }
        }
        //[2.10.1.0]MW0LGE enable/disable quick split and turn split on/off at same time
        public string ZZZO(string s)
        {
            if (console is null || console.Midi2Cat is null) return parser.Error1;

            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                if (!console.IsSetupFormNull)
                    console.SetupForm.QuickSplitEnabled = (s == "1");

				console.VFOSplit = (s == "1");

                return "";
            }
            else if (s.Length == parser.nGet)
            {
				bool bRet = console.VFOSplit;
				if (!console.IsSetupFormNull) bRet &= console.SetupForm.QuickSplitEnabled;				
                return bRet ? "1" : "0";
            }
            else
            {
                return parser.Error1;
            }
        }

        public string ZZXA(string s)
        {
            if (console is null) return parser.Error1;

            if (s.Length == parser.nSet && (s == "0" || s == "1"))
            {
                console.EnableAudioAmplifier = (s == "1");
                return "";
            }
            else if (s.Length == parser.nGet)
            {
                return console.EnableAudioAmplifier ? "1" : "0";
            }
            else
            {
                return parser.Error1;
            }
        }
        #endregion Extended CAT Methods ZZR-ZZZ


        #region Helper methods

        #region General Helpers

        private string AddLeadingZeros(int n)
		{
			string num = n.ToString();

			while(num.Length < parser.nAns)
				num = num.Insert(0,"0");
			
			return num;
		}

        private string JustSuffix(string s)
        {
            string Sfx = "";
            Sfx = s.Substring(4);
            return Sfx.Substring(0, Sfx.Length - 1);
        }


		#endregion General Helpers

        #region Repeater Methods

        private string OffsetDirection2String()
        {
            string rtn = "";

            switch (console.CurrentFMTXMode)
            {
                case FMTXMode.Simplex:
                    rtn = "0";
                    break;
                case FMTXMode.High:
                    rtn = "1";
                    break;
                case FMTXMode.Low:
                    rtn = "2";
                    break;
                default:
                    rtn = "0";
                    break;
            }
            return rtn;
        }

        private void String2OffsetDirection(string s)
        {
            switch (s)
            {
                case "0":
                    console.CurrentFMTXMode = FMTXMode.Simplex;
                    break;
                case "1":
                    console.CurrentFMTXMode = FMTXMode.High;
                    break;
                case "2":
                    console.CurrentFMTXMode = FMTXMode.Low;
                    break;
                default:
                    console.CurrentFMTXMode = FMTXMode.Simplex;
                    break;
            }
        }

        private double String2CTCSSFreq(string s)
        {
            double freq = 00.0;
            switch (s)
            {
                case "01":
                    freq = 67.0;
                    break;
                case "02":
                    freq = 69.3;
                    break;
                case "03":
                    freq = 71.9;
                    break;
                case "04":
                    freq = 74.4;
                    break;
                case "05":
                    freq = 77.0;
                    break;
                case "06":
                    freq = 79.7;
                    break;
                case "07":
                    freq = 82.5;
                    break;
                case "08":
                    freq = 85.4;
                    break;
                case "09":
                    freq = 88.5;
                    break;
                case "10":
                    freq = 91.5;
                    break;
                case "11":
                    freq = 94.8;
                    break;
                case "12":
                    freq = 97.4;
                    break;
                case "13":
                    freq = 100.0;
                    break;
                case "14":
                    freq = 103.5;
                    break;
                case "15":
                    freq = 107.2;
                    break;
                case "16":
                    freq = 110.9;
                    break;
                case "17":
                    freq = 114.8;
                    break;
                case "18":
                    freq = 118.8;
                    break;
                case "19":
                    freq = 123.0;
                    break;
                case "20":
                    freq = 127.3;
                    break;
                case "21":
                    freq = 131.8;
                    break;
                case "22":
                    freq = 136.5;
                    break;
                case "23":
                    freq = 141.3;
                    break;
                case "24":
                    freq = 146.2;
                    break;
                case "25":
                    freq = 151.4;
                    break;
                case "26":
                    freq = 156.7;
                    break;
                case "27":
                    freq = 159.8;
                    break;
                case "28":
                    freq = 162.2;
                    break;
                case "29":
                    freq = 165.5;
                    break;
                case "30":
                    freq = 167.9;
                    break;
                case "31":
                    freq = 171.3;
                    break;
                case "32":
                    freq = 173.8;
                    break;
                case "33":
                    freq = 177.3;
                    break;
                case "34":
                    freq = 179.9;
                    break;
                case "35":
                    freq = 183.5;
                    break;
                case "36":
                    freq = 186.2;
                    break;
                case "37":
                    freq = 189.9;
                    break;
                case "38":
                    freq = 192.8;
                    break;
                case "39":
                    freq = 199.5;
                    break;
                case "40":
                    freq = 203.5;
                    break;
                case "41":
                    freq = 206.5;
                    break;
                case "42":
                    freq = 210.7;
                    break;
                case "43":
                    freq = 218.1;
                    break;
                case "44":
                    freq = 225.7;
                    break;
                case "45":
                    freq = 229.1;
                    break;
                case "46":
                    freq = 233.6;
                    break;
                case "47":
                    freq = 241.8;
                    break;
                case "48":
                    freq = 250.3;
                    break;
                case "49":
                    freq = 254.1;
                    break;
                default:
                    freq = 67.0;
                    break;
            }
            return freq;
        }

        private string CTCSSFreq2String(int freq)
        {
            string ans = "";
            switch (freq)
            {
                case 670:
                    ans = "01";
                    break;
                case 693:
                    ans = "02";
                    break;
                case 719:
                    ans = "03";
                    break;
                case 744:
                    ans = "04";
                    break;
                case 770:
                    ans = "05";
                    break;
                case 797:
                    ans = "06";
                    break;
                case 825:
                    ans = "07";
                    break;
                case 854:
                    ans = "08";
                    break;
                case 885:
                    ans = "09";
                    break;
                case 915:
                    ans = "10";
                    break;
                case 948:
                    ans = "11";
                    break;
                case 974:
                    ans = "12";
                    break;
                case 1000:
                    ans = "13";
                    break;
                case 1035:
                    ans = "14";
                    break;
                case 1072:
                    ans = "15";
                    break;
                case 1109:
                    ans = "16";
                    break;
                case 1148:
                    ans = "17";
                    break;
                case 1188:
                    ans = "18";
                    break;
                case 1230:
                    ans = "19";
                    break;
                case 1273:
                    ans = "20";
                    break;
                case 1318:
                    ans = "21";
                    break;
                case 1365:
                    ans = "22";
                    break;
                case 1413:
                    ans = "23";
                    break;
                case 1462:
                    ans = "24";
                    break;
                case 1514:
                    ans = "25";
                    break;
                case 1567:
                    ans = "26";
                    break;
                case 1598:
                    ans = "27";
                    break;
                case 1622:
                    ans = "28";
                    break;
                case 1655:
                    ans = "29";
                    break;
                case 1679:
                    ans = "30";
                    break;
                case 1713:
                    ans = "31";
                    break;
                case 1738:
                    ans = "32";
                    break;
                case 1773:
                    ans = "33";
                    break;
                case 1799:
                    ans = "34";
                    break;
                case 1835:
                    ans = "35";
                    break;
                case 1862:
                    ans = "36";
                    break;
                case 1899:
                    ans = "37";
                    break;
                case 1928:
                    ans = "38";
                    break;
                case 1995:
                    ans = "39";
                    break;
                case 2035:
                    ans = "40";
                    break;
                case 2065:
                    ans = "41";
                    break;
                case 2107:
                    ans = "42";
                    break;
                case 2181:
                    ans = "43";
                    break;
                case 2257:
                    ans = "44";
                    break;
                case 2291:
                    ans = "45";
                    break;
                case 2336:
                    ans = "46";
                    break;
                case 2418:
                    ans = "47";
                    break;
                case 2503:
                    ans = "48";
                    break;
                case  2541:
                    ans = "49";
                    break;
                default:
                    ans = "01";
                    break;
            }
            return ans;
        }

        private SortableBindingList<MemoryRecord> GetMemoryList()
        {
            try
            {
                return console.MemoryList.List;
            }
            catch
            {
                SortableBindingList<MemoryRecord> list = new SortableBindingList<MemoryRecord>();
                parser.Verbose_Error_Code = 4;
                return list;
            }
        }

        private MemoryRecord GetChannelRecord(string channel)
        {
            MemoryRecord rec = new MemoryRecord();
            try
            {
                SortableBindingList<MemoryRecord> list = GetMemoryList();
                int n = 0;
                for (n = 0; n < list.Count; n++)
                {
                    if (list[n].Comments.Substring(0, 4) == channel + ":")
                        rec = list[n];
                }
            }
            catch
            {
            }
            return rec;
        }

        private int GetIndex(string channel)
        {
            int ndx = -1;
            try
            {
                SortableBindingList<MemoryRecord> list = GetMemoryList();
                int n = 0;
                for (n = 0; n < list.Count; n++)
                {
                    if (list[n].Comments.Substring(0, 4) == channel + ":")
                        ndx = n;
                }
            }
            catch
            {
            }
            return ndx;
        }

        private int GetNextChannelNumber()
        {
            SortableBindingList<MemoryRecord> list = new SortableBindingList<MemoryRecord>();
            list = console.MemoryList.List;
            int n = 0;
            int last = 0;
            for (n = 0; n < list.Count; n++)
            {
                if (list[n].Comments.Contains(":"))
                {
                    int thisN = int.Parse(list[n].Comments.Substring(0, list[n].Comments.IndexOf(":")));
                    if (thisN > last)
                        last = thisN;
                }

            }
            return last+1;
        }

        #endregion Repeater Methods

		#region VFO Methods
		// Converts a vfo frequency to a proper CAT frequency string
		private string StrVFOFreq(string vfo)
		{
			double freq = 0;
			string cmd_string = "";

            if (vfo == "A")
                freq = Math.Round(console.CATVFOA, 6);
            else if (vfo == "B")
                freq = Math.Round(console.CATVFOB, 6);
            else if (vfo == "C")
                freq = Convert.ToDouble(console.CATQMSValue);

			
			if((int) freq < 10)
			{
				cmd_string += "0000"+freq.ToString();
			}
			else if((int) freq < 100)
			{
				cmd_string += "000"+freq.ToString();
			}
			else if((int) freq < 1000)
			{
				cmd_string += "00"+freq.ToString();
			}
			else if((int) freq < 10000)
			{
				cmd_string += "0"+freq.ToString();
			}
			else
				cmd_string = freq.ToString();

			// Get rid of the decimal separator and pad the right side with 0's 
			// Modified 05/01/05 BT for globalization
			if(cmd_string.IndexOf(separator) > 0)
				cmd_string = cmd_string.Remove(cmd_string.IndexOf(separator),1);
			cmd_string = cmd_string.PadRight(11,'0');
			return cmd_string;
		}
		#endregion VFO Methods

		#region Filter Methods

		public string Filter2String(Filter f)
		{
			string fw = f.ToString();
			string strfilt = "";
			int retval = 0;
			switch(fw)
			{
				case "F6000":
					strfilt = "6000";
					break;
				case "F4000":
					strfilt = "4000";
					break;
				case "F2600":
					strfilt = "2600";
					break;
				case "F2100":
					strfilt = "2100";
					break;
				case "F1000":
					strfilt = "1000";
					break;
				case "F500":
					strfilt = "0500";
					break;
				case "F250":
					strfilt = "0250";
					break;
				case "F100":
					strfilt = "0100";
					break;
				case "F50":
					strfilt = "0050";
					break;
				case "F25":
					strfilt = "0025";
					break;
				case "VAR1":
					retval = Math.Abs(console.RX1FilterHigh-console.RX1FilterLow);
					strfilt = AddLeadingZeros(retval);
					break;
				case "VAR2":
					retval = Math.Abs(console.RX1FilterHigh-console.RX1FilterLow);
					strfilt = AddLeadingZeros(retval);
					break;
			}
			return strfilt;
		}

		public Filter String2Filter(string f)
		{
			Filter filter = Filter.FIRST;
			switch(f)
			{
				case "6000":
					filter = Filter.F1;
					break;
				case "4000":
					filter = Filter.F2;
					break;
				case "2600":
					filter = Filter.F3;
					break;
				case "2100":
					filter = Filter.F4;
					break;
				case "1000":
					filter = Filter.F5;
					break;
				case "0500":
					filter = Filter.F6;
					break;
				case "0250":
					filter = Filter.F7;
					break;
				case "0100":
					filter = Filter.F8;
					break;
				case "0050":
					filter = Filter.F9;
					break;
				case "0025":
					filter = Filter.F10;
					break;
				case "VAR1":
					filter = Filter.VAR1;
					break;
				case "VAR2":
					filter = Filter.VAR2;
					break;
			}
			return filter;
		}

		// set variable filter 1 to indicate center and width 
		// 
		// if either center or width is zero, current value of center or width is 
		// contained 
		// fixme ... what should this thing do for am, fm, dsb ... ignore width? 
		private void SetFilterCenterAndWidth(int center, int width) 
		{ 
			int new_lo; 
			int new_hi; 

			if  ( center == 0 || width == 0 )  // need to get current values 
			{ 
				return; // not implemented yet 
			} 
			else 
			{ 
				// Debug.WriteLine("center: " + center  + " width: " + width); 
				new_lo = center - (width/2); 
				new_hi = center + (width/2); 
				if ( new_lo  < 0 ) new_lo = 0; 				
			} 						
			
			// new_lo and new_hi calculated assuming a USB mode .. do the right thing 
			// for lsb and other modes 
			// fixme -- needs more thinking 
			switch ( console.RX1DSPMode ) 
			{ 
				case DSPMode.LSB: 
					int scratch = new_hi; 
					new_hi = -new_lo; 
					new_lo = -scratch; 
					break; 

				case DSPMode.AM: 
				case DSPMode.SAM: 
					new_lo = -new_hi; 
					break; 
			} 						

			 
			// System.Console.WriteLine("zzsf: " + new_lo + " " + new_hi); 
			console.SelectRX1VarFilter();
			console.UpdateRX1Filters(new_lo, new_hi, true, false); 	

			return; 
		} 

		// Converts interger filter frequency into Kenwood SL/SH codes
		private string Frequency2Code(int f, string n)
		{
			f = Math.Abs(f);
			string code = "";
			switch(console.RX1DSPMode)
			{
				case DSPMode.CWL:
				case DSPMode.CWU:
				case DSPMode.LSB:
				case DSPMode.USB:
				switch(n)
				{
					case "SH":
						if(f >= 0 && f <= 1500)
							code = "00";
						else if(f > 1500 && f <= 1700)
							code = "01";
						else if(f > 1700 && f <= 1900)
							code = "02";
						else if(f > 1900 && f <= 2100)
							code = "03";
						else if(f > 2100 && f <= 2300)
							code = "04";
						else if(f > 2300 && f <= 2500)
							code = "05";
						else if(f > 2500 && f <= 2700)
							code = "06";
						else if(f > 2700 && f <= 2900)
							code = "07";
						else if(f > 2900 && f <= 3200)
							code = "08";
						else if(f > 3200 && f <= 3700)
							code = "09";
						else if(f > 3700 && f <= 4500)
							code = "10";
						else if(f > 4500)
							code = "11";
						break;
					case"SL":
						if(f >= 0 && f <= 25)
							code = "00";
						else if(f > 25 && f <= 75)
							code = "01";
						else if(f > 75 && f <= 150)
							code = "02";
						else if(f > 150 && f <= 250)
							code = "03";
						else if(f > 250 && f <= 350)
							code = "04";
						else if(f > 350 && f <= 450)
							code = "05";
						else if(f > 450 && f <= 550)
							code = "06";
						else if(f > 550 && f <= 650)
							code = "07";
						else if(f > 650 && f <= 750)
							code = "08";
						else if(f > 750 && f <= 850)
							code = "09";
						else if(f > 850 && f <= 950)
							code = "10";
						else if(f > 950)
							code = "11";
						break;
				}
				break;
				case DSPMode.AM:
				case DSPMode.DRM:
				case DSPMode.DSB:
				case DSPMode.FM:
				case DSPMode.SAM:
				switch(n)
				{
					case "SH":
						if(f >= 0 && f <= 2750)
							code = "00";
						else if(f > 2750 && f <= 3500)
							code = "01";
						else if(f > 3500 && f <= 4500)
							code = "02";
						else if(f > 4500)
							code = "03";
						break;
					case "SL":
						if(f >= 0 && f <= 50)
							code = "00";
						else if(f > 50 && f <= 150)
							code = "01";
						else if(f > 150 && f <= 350)
							code = "02";
						else if(f > 350)
							code = "03";
						break;
				}
				break;
			}
			return code;
		}

		// Converts a frequency code pair to frequency in hz according to
		// the Kenwood TS-2000 spec.  Receives code and calling methd as parameters
		private int Code2Frequency(string c, string n)
		{
			int freq = 0;
			string mode = "SSB";
			int fgroup = 0;

			// Get the current console mode
			switch(console.RX1DSPMode)
			{
				case DSPMode.LSB:
				case DSPMode.USB:
					break;
				case DSPMode.AM:
				case DSPMode.DSB:
				case DSPMode.DRM:
				case DSPMode.FM:
				case DSPMode.SAM:
					mode = "DSB";
					break;
			}
			// Get the frequency group(SSB/SL, SSB/SH, DSB/SL, and DSB/SH)
			switch(n)
			{
				case "SL":
					if(mode == "SSB")
						fgroup = 1;
					else
						fgroup = 3;
					break;
				case "SH":
					if(mode == "SSB")
						fgroup = 2;
					else
						fgroup = 4;
					break;
			}
			// return the frequency for the current DSP mode and calling method
			switch(fgroup)
			{
				case 1:		//SL SSB
				switch(c)
					{
					case "00":
						freq = 0;
						break;
					case "01":
						freq = 50;
						break;
					case "02":
						freq = 100;
						break;
					case "03":
						freq = 200;
						break;
					case "04":
						freq = 300;
						break;
					case "05":
						freq = 400;
						break;
					case "06":
						freq = 500;
						break;
					case "07":
						freq = 600;
						break;
					case "08":
						freq = 700;
						break;
					case "09":
						freq = 800;
						break;
					case "10":
						freq = 900;
						break;
					case "11":
						freq = 1000;
						break;
					}
				break;
				case 2:		//SH SSB
					switch(c)
					{
					case "00":
						freq = 1400;
						break;
					case "01":
						freq = 1600;
						break;
					case "02":
						freq = 1800;
						break;
					case "03":
						freq = 2000;
						break;
					case "04":
						freq = 2200;
						break;
					case "05":
						freq = 2400;
						break;
					case "06":
						freq = 2600;
						break;
					case "07":
						freq = 2800;
						break;
					case "08":
						freq = 3000;
						break;
					case "09":
						freq = 3400;
						break;
					case "10":
						freq = 4000;
						break;
					case "11":
						freq = 5000;
						break;
					}
				break;
				case 3:		//SL DSB
					switch(c)
					{
					case "00":
						freq = 0;
						break;
					case "01":
						freq = 100;
						break;
					case "02":
						freq = 200;
						break;
					case "03":
						freq = 500;
						break;
					}
				break;
				case 4:		//SH DSB
					switch(c)
					{
					case "00":
						freq = 2500;
						break;
					case "01":
						freq = 3000;
						break;
					case "02":
						freq = 4000;
						break;
					case "03":
						freq = 5000;
						break;
					}
				break;
			}
			return freq;
			#region old code

//			int freq = 0;
//			switch(console.RX1DSPMode)
//			{
//				case DSPMode.CWL:
//				case DSPMode.CWU:
//				case DSPMode.LSB:
//				case DSPMode.USB:
//				{
//					switch(c)	//c = filter code, n = SH or SL
//					{
//						case "00":
//							if(n == "SL")
//								freq = 10;
//							else
//								freq = 1400;
//							break;
//						case "01":
//							if(n == "SL")
//								freq = 50;
//							else
//								freq = 1600;
//							break;
//						case "02":
//							if(n == "SL")
//								freq = 100;
//							else
//								freq = 1800;
//							break;
//						case "03":
//							if(n == "SL")
//								freq = 200;
//							else
//								freq = 2000;
//							break;
//						case "04":
//							if(n == "SL")
//								freq = 300;
//							else
//								freq = 2200;
//							break;
//						case "05":
//							if(n == "SL")
//								freq = 400;
//							else
//								freq = 2400;
//							break;
//						case "06":
//							if(n == "SL")
//								freq = 500;
//							else
//								freq = 2600;
//							break;
//						case "07":
//							if(n == "SL")
//								freq = 600;
//							else
//								freq = 2800;
//							break;
//						case "08":
//							if(n == "SL")
//								freq = 700;
//							else
//								freq = 3000;
//							break;
//						case "09":
//							if(n == "SL")
//								freq = 800;
//							else
//								freq = 3400;
//							break;
//						case "10":
//							if(n == "SL")
//								freq = 900;
//							else
//								freq = 4000;
//							break;
//						case "11":
//							if(n == "SL")
//								freq = 1000;
//							else
//								freq = 5000;
//							break;
//						default:
//							break;
//					}
//					break;
//				}
//				case DSPMode.AM:
//				case DSPMode.DRM:
//				case DSPMode.DSB:
//				case DSPMode.FMN:
//				case DSPMode.SAM:
//				{
//					switch(c)
//					{
//						case "00":
//							if(n == "SL")
//								freq = 10;
//							else
//								freq = 2500;
//							break;
//						case "01":
//							if(n == "SL")
//								freq = 100;
//							else
//								freq = 3000;
//							break;
//						case "02":
//							if(n == "SL")
//								freq = 200;
//							else
//								freq = 4000;
//							break;
//						case "03":
//							if(n == "SL")
//								freq = 500;
//							else
//								freq = 5000;
//							break;
//					}
//				}
//				break;
//			}
//			return freq;
			#endregion old code
		}

		private void SetFilter(string c, string n)
		{
			// c = code, n = SH or SL
			console.RX1Filter = Filter.VAR1;
			int freq = 0;
			int offset = 0;
			string code;

			switch(console.RX1DSPMode)
			{
				case DSPMode.USB:
				case DSPMode.CWU:
					freq = Code2Frequency(c, n);
					if(n == "SH")
						console.RX1FilterHigh = freq;	//split the bandwidth at the center frequency
					else
						console.RX1FilterLow = freq;
					break;
				case DSPMode.LSB:
				case DSPMode.CWL:
					if(n == "SH")
					{
						freq = Code2Frequency(c, "SH");	// get the upper limit from the lower value set
						console.RX1FilterLow = -freq;	// since we need the more positive value
					}										// closest to the center freq in lsb modes
					else
					{
						freq = Code2Frequency(c, "SL");	// do the reverse here, the less positive value
						console.RX1FilterHigh = -freq; // is away from the center freq
					}
					break;
				case DSPMode.AM:
				case DSPMode.DRM:
				case DSPMode.DSB:
				case DSPMode.FM:
				case DSPMode.SAM:
					if(n == "SH")
					{
						// Set the bandwith equally across the center freq
						freq = Code2Frequency(c, "SH");	
						console.RX1FilterHigh = freq/2;
						console.RX1FilterLow = -freq/2;
					}
					else
					{
						// reset the frequency to the nominal value (in case it's been changed)
						freq = console.RX1FilterHigh*2;	
						code = Frequency2Code(freq, "SH");
						freq = Code2Frequency(code, "SH");
						console.RX1FilterHigh = freq/2;
						console.RX1FilterLow = -freq/2;
						// subtract the SL value from the lower half of the bandwidth
						offset = Code2Frequency(c, "SL");
						console.RX1FilterLow += offset;			
					}
					break;
			}
		}

		#endregion Filter Methods

		#region Mode Methods

		public void String2Mode(string pIndex)
		{
			string s = pIndex;

			switch(s)
				{
				case "00":								
					console.RX1DSPMode = DSPMode.LSB;
					break;
				case "01":
					console.RX1DSPMode = DSPMode.USB;
					break;
				case "02":
					console.RX1DSPMode = DSPMode.DSB;
					break;
				case "03":
					console.RX1DSPMode = DSPMode.CWL;
					break;
				case "04":
					console.RX1DSPMode = DSPMode.CWU;
					break;
				case "05":
					console.RX1DSPMode = DSPMode.FM;
					break;
				case "06":
					console.RX1DSPMode = DSPMode.AM;
					break;
				case "07":
					console.RX1DSPMode = DSPMode.DIGU;
					break;
				case "08":
					console.RX1DSPMode = DSPMode.SPEC;
					break;
				case "09":
					console.RX1DSPMode = DSPMode.DIGL;
					break;
				case "10":
					console.RX1DSPMode = DSPMode.SAM;
					break;
				case "11":
					console.RX1DSPMode = DSPMode.DRM;
					break;
				}
		}

		public string Mode2String(DSPMode pMode)
		{
			DSPMode s = pMode;
			string retval = "";

			switch(s)
				{
					case DSPMode.LSB:
						retval = "00";  
						break;
					case DSPMode.USB:
						retval = "01";	
						break;
					case DSPMode.DSB:
						retval = "02";	
						break;
					case DSPMode.CWL:
						retval = "03";	
						break;
					case DSPMode.CWU:
						retval = "04";	
						break;
					case DSPMode.FM:
						retval = "05";	
						break;
					case DSPMode.AM:
						retval = "06";	
						break;
					case DSPMode.DIGU:
						retval = "07";	
						break;
					case DSPMode.SPEC:
						retval = "08";	
						break;
					case DSPMode.DIGL:
						retval = "09";	
						break;
					case DSPMode.SAM:
						retval = "10";	
						break;
					case DSPMode.DRM:
						retval = "11";	
						break;
					default:
						retval = parser.Error1;
						break;
				}

			return retval;
		}

		// converts Kenwood single digit mode code to SDR mode
		public void KString2Mode(string pIndex)
		{
			// MI0BOT: Redirect CAT to VFO B
			string s = pIndex;
			DSPMode newMode;

			switch(s)
			{
				case "1":
                    if (console.SetupForm.DigUIsUSB)
                        newMode = DSPMode.DIGL;
                    else
                        newMode = DSPMode.LSB;
					break;
				case "2":
                    if (console.SetupForm.DigUIsUSB)
                        newMode = DSPMode.DIGU;
                    else
    					newMode = DSPMode.USB;
					break;
				case "3":
					newMode = DSPMode.CWU;
					break;
				case "4":
					newMode = DSPMode.FM;
					break;
				case "5":
					newMode = DSPMode.AM;
					break;
				case "6":
					newMode = DSPMode.DIGL;
					break;
				case "7":
					newMode = DSPMode.CWL;
					break;
				case "9":
					newMode = DSPMode.DIGU;
					break;
				default:
					newMode = DSPMode.USB;
					break;
			}
			
            // MI0BOT: Redirect CAT to VFO B
			if (console.CATtoVFOB && Console.getConsole().CurrentHPSDRModel == HPSDRModel.HERMESLITE)
				console.RX2DSPMode = newMode;
			else
				console.RX1DSPMode = newMode;
        }

		// converts SDR mode to Kenwood single digit mode code
		public string Mode2KString(DSPMode pMode)
		{
			DSPMode s = pMode;
			string retval = "";

			switch(s)
			{
				case DSPMode.LSB:
   					retval = "1";  
					break;
				case DSPMode.USB:
   					retval = "2";	
					break;
				case DSPMode.CWU:
					retval = "3";	
					break;
				case DSPMode.FM:
					retval = "4";	
					break;
				case DSPMode.AM:
//				case DSPMode.SAM:		//possible fix for SAM problem
					retval = "5";	
					break;
				case DSPMode.DIGL:
					if(console.SetupForm.DigUIsUSB)
						retval = "1";
					else
						retval = "6";	
					break;
				case DSPMode.CWL:
					retval = "7";	
					break;
				case DSPMode.DIGU:
					if(console.SetupForm.DigUIsUSB)
						retval = "2";
					else
						retval = "9";
					break;
				default:
					retval = parser.Error1;
					break;
			}

			return retval;
		}

		#endregion Mode Methods

		#region Band Methods

		private void MakeBandList()
		//Construct an array of the PowerSDR.Band enums.
		//If the 2m xverter is present, set the last index to B2M
		//otherwise, set it to B6M.
		{
			int ndx = 0;
			BandList = new Band[(int)Band.LAST+2];
			foreach(Band b in Enum.GetValues(typeof(Band)))
			{
				BandList.SetValue(b, ndx);
				ndx++;
			}
			if(console.XVTRPresent)
				LastBandIndex = Array.IndexOf(BandList,Band.B2M);
			else
				LastBandIndex = Array.IndexOf(BandList,Band.B6M);
		}

		private void SetBandGroup(int band)
		{
			int oldval = parser.nSet;
			parser.nSet = 1;
			if(band == 0)
				ZZBG("0");
			else
				ZZBG("1");

			parser.nSet = oldval;
		}

		private string GetBand(string b)
		{
			if(b.Length == parser.nSet)
			{
				if(b.StartsWith("V") || b.StartsWith("v"))
					SetBandGroup(1);
				else 
					SetBandGroup(0);
			}

			if(b.Length == parser.nSet)
			{
				console.SetCATBand(String2Band(b));
				return "";
			}
			else if(b.Length == parser.nGet)
			{
				return Band2String(console.RX1Band);
			}
			else
			{
				return parser.Error1;
			}


		}

		private void BandUp()
		{
			Band nextband;
			Band current = console.RX1Band;
			int currndx = Array.IndexOf(BandList,current);
			if(currndx == LastBandIndex)
				nextband = BandList[0];
			else
				nextband = BandList[currndx+1];
			console.SetCATBand(nextband);
			Debug.Print("BandUp: current=" + current.ToString() + " next=" + nextband.ToString());
		}

		private void BandDown()
		{
			Band nextband;
			Band current = console.RX1Band;
			int currndx = Array.IndexOf(BandList,current);
			if(currndx > 0)
				nextband = BandList[currndx-1];
			else
				nextband = BandList[LastBandIndex];
			Debug.Print("BandDown: current=" + current.ToString() + " next=" + nextband.ToString());
			console.SetCATBand(nextband);
		}

		private string Band2String(Band pBand)
		{
			Band band = pBand;
			string retval;

			switch(band)
			{
				case Band.GEN:
					retval = "888";
					break;
				case Band.B160M:
					retval = "160";
					break;
				case Band.B60M:
					retval = "060";
					break;
				case Band.B80M:
					retval = "080";
					break;
				case Band.B40M:
					retval = "040";
					break;
				case Band.B30M:
					retval = "030";
					break;
				case Band.B20M:
					retval = "020";
					break;
				case Band.B17M:
					retval = "017";
					break;
				case Band.B15M:
					retval = "015";
					break;
				case Band.B12M:
					retval = "012";
					break;
				case Band.B10M:
					retval = "010";
					break;
				case Band.B6M:
					retval = "006";
					break;
				case Band.B2M:
					retval = "002";
					break;
				case Band.WWV:
					retval = "999";
					break;
				case Band.VHF0:
					retval = "V00";
					break;
				case Band.VHF1:
					retval = "V01";
					break;
				case Band.VHF2:
					retval = "V02";
					break;
				case Band.VHF3:
					retval = "V03";
					break;
				case Band.VHF4:
					retval = "V04";
					break;
				case Band.VHF5:
					retval = "V05";
					break;
				case Band.VHF6:
					retval = "V06";
					break;
				case Band.VHF7:
					retval = "V07";
					break;
				case Band.VHF8:
					retval = "V08";
					break;
				case Band.VHF9:
					retval = "V09";
					break;
				case Band.VHF10:
					retval = "V10";
					break;
				case Band.VHF11:
					retval = "V11";
					break;
				case Band.VHF12:
					retval = "V12";
					break;
				case Band.VHF13:
					retval = "V13";
					break;
				default:
					retval = "888";
					break;
			}
			return retval;
		}

		private Band String2Band(string pBand)
		{
			string band = pBand.ToUpper();;
			Band retval;

			switch(band)
			{
				case "888":
					retval = Band.GEN;
					break;
				case "160":
					retval = Band.B160M;
					break;
				case "060":
					retval = Band.B60M;
					break;
				case "080":
					retval = Band.B80M;
					break;
				case "040":
					retval = Band.B40M;
					break;
				case "030":
					retval = Band.B30M;
					break;
				case "020":
					retval = Band.B20M;
					break;
				case "017":
					retval = Band.B17M;
					break;
				case "015":
					retval = Band.B15M;
					break;
				case "012":
					retval = Band.B12M;
					break;
				case "010":
					retval = Band.B10M;
					break;
				case "006":
					retval = Band.B6M;
					break;
				case "002":
					retval = Band.B2M;
					break;
				case "999":
					retval = Band.WWV;
					break;
				case "V00":
					retval = Band.VHF0;
					break;
				case "V01":
					retval = Band.VHF1;
					break;
				case "V02":
					retval = Band.VHF2;
					break;
				case "V03":
					retval = Band.VHF3;
					break;
				case "V04":
					retval = Band.VHF4;
					break;
				case "V05":
					retval = Band.VHF5;
					break;
				case "V06":
					retval = Band.VHF6;
					break;
				case "V07":
					retval = Band.VHF7;
					break;
				case "V08":
					retval = Band.VHF8;
					break;
				case "V09":
					retval = Band.VHF9;
					break;
				case "V10":
					retval = Band.VHF10;
					break;
				case "V11":
					retval = Band.VHF11;
					break;
				case "V12":
					retval = Band.VHF12;
					break;
				case "V13":
					retval = Band.VHF13;
					break;
				default:
					retval = Band.GEN;
					break;
			}
			return retval;
		}

		#endregion Band Methods

		#region Step Methods

        private double Step2Freq(int step)
        {
            double freq = 0.0;
            switch(step)
            {
                case 0:
	            freq  =  0.000001;
                    break;
                case 1:
                    freq  =  0.000010;
                    break;
                case 2:
                    freq  =  0.000025;
                    break;
                case 3:
                    freq  =  0.000050;
                    break;
                case 4:
                    freq  =  0.000100;
                    break;
                case 5:
                    freq  =  0.000250;
                    break;
                case 6:
                    freq  =  0.000500;
                    break;
                case 7:
                    freq  =  0.001000;
                    break;
                case 8:
                    freq  =  0.005000;
                    break;
                case 9:
                    freq  =  0.009000;
                    break;
                case 10:
                    freq  =  0.010000;
                    break;
                case 11:
                    freq = 0.100000;
                    break;
                case 12:
                    freq =  0.250000;
                    break;
                case 13:
                    freq =  0.500000;
                    break;
                case 14:
                    freq =  1.000000;
                    break;
                case 15:
                    freq = 10.000000;
                    break;
            }
            return freq;
        }

		private string Step2String(int pSize)
		{
			// Modified 2/25/07 to accomodate changes to console where odd step sizes added.  BT
			string stepval = "";
			int step = pSize;
			switch(step)
			{
				case 0:
					stepval = "0000";	//10e0 = 1 hz
					break;
				case 1:
					stepval = "0001";	//10e1 = 10 hz
					break;
				case 2:
					stepval = "1000";	//special default for 50 hz
					break;
				case 3:
					stepval = "0010";	//10e2 = 100 hz
					break;
				case 4:
					stepval = "1001";	//special default for 250 hz
					break;
				case 5:
					stepval = "1010";	//10e3 = 1 kHz default for 500 hz
					break;
				case 6:
					stepval = "0011";	//10e3 = 1 kHz
					break;
				case 7:
					stepval = "1011";	//special default for 5 kHz
					break;
				case 8:
					stepval = "1100";	//special default for 9 kHz
					break;
				case 9:
					stepval = "0100";	//10e4 = 10 khZ
					break;
				case 10:
					stepval = "0101";	//10e5 = 100 kHz
					break;
                case 11:
                    stepval = "1101";   //special default for 250 kHz
                    break;
                case 12:
                    stepval = "1110";   //special default for 500 kHz
                    break;
				case 13:
					stepval = "0110";	//10e6 = 1 mHz
					break;
				case 14:
					stepval = "0111";	//10e7 = 10 mHz
					break;
			}
			return stepval;
		}

		#endregion Step Methods

		#region Meter Methods

		private void String2RXMeter(int m)
		{
			console.CurrentMeterRXMode = (MeterRXMode) m;
		}

		private string RXMeter2String()
		{
			return ((int) console.CurrentMeterRXMode).ToString();
		}

		private void String2TXMeter(int m)
		{
			console.CurrentMeterTXMode = (MeterTXMode) m;
		}

		private string TXMeter2String()
		{
			return ((int) console.CurrentMeterTXMode).ToString();
		}

		#endregion Meter Methods

		#region Rig ID Methods

		private string CAT2RigType()
		{
			return "";
		}

		private string RigType2CAT()
		{
			return "";
		}

		#endregion Rig ID Methods

		#region DSP Filter Size Methods

		private string Width2Index(int txt)
		{
			string ans = "";
			switch(txt)
			{
				case 256:
					ans = "0";
					break;
				case 512:
					ans = "1";
					break;
				case 1024:
					ans = "2";
					break;
				case 2048:
					ans = "3";
					break;
				case 4096:
					ans = "4";
					break;
                case 8192:
                    ans = "5";
                    break;
                case 16384:
                    ans = "6";
                    break;
                default:
					ans = "0";
					break;
			}
			return ans;
		}

		private int Index2Width(string ndx)
		{
			int ans;
			switch(ndx)
			{
				case "0":
					ans = 256;
					break;
				case "1":
					ans = 512;
					break;
				case "2":
					ans = 1024;
					break;
				case "3":
					ans = 2048;
					break;
				case "4":
					ans = 4096;
					break;
                case "5":
                    ans = 8192;
                    break;
                case "6":
                    ans = 16384;
                    break;
                default:
					ans = 256;
					break;
			}
			return ans;
		}

		#endregion DSP Filter Size Methods

		#endregion Helper methods
	}	
}

