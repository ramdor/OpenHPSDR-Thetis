//=================================================================
// CATParser.cs
//=================================================================
// Copyright (C) 2012  Bob Tracy
//
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


using System;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;

namespace Thetis
{
	/// <summary>
	/// Summary description for CATParser.
	/// </summary>

	#region CATParser Class

	public class CATParser
	{

		#region Variable declarations

		private string current_cat;
		private string prefix;
		private string suffix;
		private string extension;
		private readonly char[] term = new char[1]{';'};
		public int nSet;
		public int nGet;
		public int nAns;
		public bool IsActive;
		private XmlDocument doc;
		private readonly CATCommands cmdlist;
		private readonly Console console;
		public string Error1 = "?;";
		public string Error2 = "E;";
		public string Error3 = "O;";
		private bool IsExtended;
		private readonly ASCIIEncoding AE = new ASCIIEncoding();

        private bool verbose = false;
        public bool Verbose
        {
            get { return verbose; }
            set { verbose = value;
                  cmdlist.Verbose = value;
                }
        }

       private Int32 verbose_error_code = 0;
       public Int32 Verbose_Error_Code
        {
           get { return verbose_error_code;}
           set {verbose_error_code = value;}
        }

		#endregion Variable declarations

		public CATParser(Console c)
		{
			console = c;
			cmdlist = new CATCommands(console,this);
			GetCATData();
		}

		private void GetCATData()
		{
			string file = "CATStructs.xml";
			doc = new XmlDocument();
			try
			{
				doc.Load(Application.StartupPath+"\\"+file);
			}
			catch(System.IO.FileNotFoundException e)
			{
				throw(e);
			}
		}

		// Overloaded Get method accepts either byte or string
		public string Get(byte[] pCmdString)
		{
			string rtncmd = Get(AE.GetString(pCmdString));
			return rtncmd;
		}

		public string Get(string pCmdString)
		{
			current_cat = pCmdString;
			string rtncmd = "";
            prefix = "";
            suffix = "";
            extension = "";
            verbose_error_code = 0;

			// Abort if the overall string length is less than 3 (aa;)
            if (current_cat.Length < 3)
            {
                if (Verbose)
                    verbose_error_code = 1;     //command length error
                else
                return Error1;
            }

			bool goodcmd = CheckFormat();
			if(goodcmd)
			{
				switch(prefix)
				{
					case "AC":
						break;
					case "AG":
						rtncmd = cmdlist.AG(suffix);
						break;
					case "AI":
						rtncmd = cmdlist.AI(suffix);
						break;
					case "AL":
						break;
					case "AM":
						break;
					case "AN":
						break;
					case "AR":
						break;
					case "AS":
						break;
					case "BC":
						break;
					case "BD":
						rtncmd = cmdlist.BD();
						break;
					case "BP":
						break;
					case "BU":
						rtncmd = cmdlist.BU();
						break;
					case "BY":
						break;
					case "CA":
                        break;
					case "CG":
						break;
					case "CH":
						break;
					case "CI":
						break;
					case "CM":
						break;
					case "CN":
                        rtncmd = cmdlist.CN(suffix);
						break;
					case "CT":
                        rtncmd = cmdlist.CT(suffix);
                        break;
					case "DC":
						break;
					case "DN":
						rtncmd = cmdlist.DN();
						break;
					case "DQ":
						break;
					case "EX":
						break;
					case "FA":
					    // MI0BOT: Redirect CAT to VFO B
                        if (console.CATtoVFOB && Console.getConsole().CurrentHPSDRModel == HPSDRModel.HERMESLITE)
                        {
							rtncmd = cmdlist.FB(suffix);
                        }
                        else
                        {
							rtncmd = cmdlist.FA(suffix);
                        }
						break;
					case "FB":
						rtncmd = cmdlist.FB(suffix);
						break;
					case "FC":
						break;
					case "FD":
						break;
					case "FR":
						rtncmd = cmdlist.FR(suffix);
						break;
					case "FS":
						break;
					case "FT":
						rtncmd = cmdlist.FT(suffix, true);
						break;
					case "FW":
						rtncmd = cmdlist.FW(suffix);
						break;
					case "GT":
						rtncmd = cmdlist.GT(suffix);
						break;
					case "ID":
						rtncmd = cmdlist.ID();
						break;
					case "IF":
						rtncmd = cmdlist.IF();
						break;
					case "IS":
						break;
					case "KS":
						rtncmd = cmdlist.KS(suffix);
						break;
					case "KY":
						rtncmd = cmdlist.KY(suffix);
						break;
					case "LK":
						break;
					case "LM":
						break;
					case "LT":
						break;
					case "MC":
						break;
					case "MD":
						rtncmd = cmdlist.MD(suffix);
						break;
					case "MF":
						break;
					case "MG":
						rtncmd = cmdlist.MG(suffix);
						break;
					case "ML":
						break;
					case "MO":
						rtncmd = cmdlist.MO(suffix);
						break;
					case "MR":
						break;
					case "MU":
						break;
					case "MW":
						break;
					case "NB":
						rtncmd = cmdlist.NB(suffix);
						break;
					case "NL":
						break;
					case "NR":
						break;
					case "NT":
						rtncmd = cmdlist.NT(suffix);
						break;
					case "OF":
                        rtncmd = cmdlist.OF(suffix);
						break;
					case "OI":
						break;
					case "OS":
                        rtncmd = cmdlist.OS(suffix);
						break;
					case "PA":
						break;
					case "PB":
						break;
					case "PC":
						rtncmd = cmdlist.PC(suffix);
						break;
					case "PI":
						break;
					case "PK":
						break;
					case "PL":
						break;
					case "PM":
						break;
                    case "PR":
                        rtncmd = cmdlist.PR(suffix);
                        break;
					case "PS":
						rtncmd = cmdlist.PS(suffix);
						break;
					case "QC":
						break;
					case "QI":
						rtncmd = cmdlist.QI();
						break;
					case "QR":
						break;
					case "RA":
						break;
					case "RC":
						rtncmd = cmdlist.RC();
						break;
					case "RD":
						rtncmd = cmdlist.RD(suffix);
						break;
					case "RG":
						break;
					case "RL":
						break;
					case "RM":
						break;
					case "RT":
						rtncmd = cmdlist.RT(suffix);
						break;
					case "RU":
						rtncmd = cmdlist.RU(suffix);
						break;
					case "RX":
						rtncmd = cmdlist.RX(suffix);
						break;
					case "SA":
						break;
					case "SB":
						break;
					case "SC":
						break;
					case "SD":
						break;
					case "SH":
						rtncmd = cmdlist.SH(suffix);
						break;
					case "SI":
						break;
					case "SL":
						rtncmd = cmdlist.SL(suffix);
						break;
					case "SM":
						rtncmd = cmdlist.SM(suffix);
						break;
					case "SQ":
						rtncmd = cmdlist.SQ(suffix);
						break;
					case "SR":
						break;
					case "SS":
						break;
					case "ST":
						break;
					case "SU":
						break;
					case "SV":
						break;
					case "TC":
						break;
					case "TD":
						break;
					case "TI":
						break;
					case "TN":
						break;
					case "TO":
						break;
					case "TS":
						break;
					case "TX":
						rtncmd = cmdlist.TX(suffix);
						break;
					case "TY":
						break;
					case "UL":
						break;
					case "UP":
						rtncmd = cmdlist.UP();
						break;
					case "VD":
						break;
					case "VG":
						break;
					case "VR":
						break;
					case "VX":
						break;
					case "XT":
						rtncmd = cmdlist.XT(suffix);
						break;
					case "ZZ":
						rtncmd = ParseExtended();
						break;
				}
				if(prefix != "ZZ")	// if this is a standard command
				{
					// and it's not an error
					if(!rtncmd.Contains(Error1))
					{													
						// if it has the correct length
						if(rtncmd.Length == nAns && nAns > 0)
								rtncmd = prefix+rtncmd+";";	// return the formatted CAT answer
							else if(nAns == -1 || rtncmd == "")	// no answer is required
								rtncmd = "";
							else
								rtncmd = Error3;	// processing incomplete for some reason
					}
				}
			}
			else
				rtncmd = ProcessError(Error1);	// this was a bad command

			return rtncmd;	// Read successfully executed
		}

		private bool CheckFormat()
		{
			bool goodprefix,goodsuffix;
			// If there is no terminator, or the prefix or suffix
			// is invalid, abort.

			// If the command has a leading terminator(s) (like sent by WriteLog)
			// dump it and check the rest of the command.
			if(current_cat.StartsWith(";"))
				current_cat = current_cat.TrimStart(term);

			// If there is no terminator, or the prefix
			// is invalid, abort.
            if (current_cat.IndexOfAny(term) < 2)
            {
                verbose_error_code = 1;
                return false;
            }

			// Now check to see if it's an extended command
			if(current_cat.Substring(0,2).ToUpper() == "ZZ" && current_cat.Length > 3)
				IsExtended = true;
			else
				IsExtended = false;

			// Check the prefix
			goodprefix = FindPrefix();
            if (!goodprefix)
            {
                if (verbose_error_code == 0)    // if no other errors are trapped, use this for default
                    verbose_error_code = 4;
                return false;
            }

			// Check the suffix
			goodsuffix = FindSuffix();
            if (!goodsuffix)
            {
                if (verbose_error_code == 0)    //bad suffix and but no errors trapped
                     verbose_error_code = 3;
                return false;
            }

			return true;
		}


		private bool FindPrefix()
		{
			string pfx = "";

			// Extract the prefix from the command string
			if(IsExtended)
				pfx = current_cat.Substring(0,4).ToUpper();
			else
				pfx = current_cat.Substring(0,2).ToUpper();

			try
			// Find the prefix in the xml document and get the parameter
			// values.
			{
			XmlNode struc;
			XmlElement root = doc.DocumentElement;
			string search = "descendant::catstruct[@code='"+pfx+"']";
			struc = root.SelectSingleNode(search);
            if (struc != null)
            {
                foreach (XmlNode x in struc)
                {
                    switch (x.Name)
                    {
                        case "active":
                            IsActive = Convert.ToBoolean(x.InnerXml);
                            break;
                        case "nsetparms":
                            nSet = Convert.ToInt16(x.InnerXml);
                            break;
                        case "ngetparms":
                            nGet = Convert.ToInt16(x.InnerXml);
                            break;
                        case "nansparms":
                            nAns = Convert.ToInt16(x.InnerXml);
                            break;
                    }
                }
                //					prefix = pfx;
                // If this is not an active command there is no use continuing.
                if (IsActive)
                {
                    if (IsExtended)
                    {
                        prefix = pfx.Substring(0, 2);
                        extension = pfx.Substring(2, 2);
                    }
                    else
                    {
                        prefix = pfx;
                        extension = "";
                    }
                    return true;
                }
                else
                {
                    verbose_error_code = 2;     //inactive command
                    return false;
                }
            }
            else
                verbose_error_code = 3;     //unknown command
			}
			catch(Exception e)
			{
				throw(e);
			}
			return false;
		}	

		private bool FindSuffix()
		{
			string sfx;
			int len = 3;
			int start = 2;
			int end = 2;

            if(IsExtended)
			{
				len = 5;
				start = 4;
				end = 4;
			}

			// Define the suffix as everything after the prefix and before
			// the first terminator.
			if(current_cat.Length > len)
			{
				sfx = current_cat.Substring(start,current_cat.IndexOf(";")-end);
				if(prefix != "KY" && prefix+extension != "ZZKY" && prefix+extension != "ZZMY" &&
					(prefix+extension != "ZZEA" && prefix+extension != "ZZEB") &&
					(prefix+extension != "ZZFX" && prefix+extension != "ZZFY") &&
					(prefix+extension != "ZZFV" && prefix+extension != "ZZFW"))
				{
					Regex sfxpattern = new Regex("^[+-]?[Vv0-9]*$");
                    if (!sfxpattern.IsMatch(sfx))
                    {
                        verbose_error_code = 5;     //illegal suffix format
                        return false;
                    }
				}
//modified 3/17/07 BT to correct bug in reading parameters with plus or minus sign
				// Check the suffix for illegal characters
				// [^0-9] = match any non-numeric character
				//Regex sfxpattern = new Regex("[^0-9]");
				//if(sfxpattern.IsMatch(sfx))
				//	return false;
			}
			else
			{
				sfx = "";
			}
            suffix = sfx;
			// Check the length against the struct requirements
            if (sfx.Length == nSet || sfx.Length == nGet)
            {
                //suffix = sfx;
                return true;
            }
            else
            {
                verbose_error_code = 6;     //suffix length error
                return false;
            }
		}

		private string ParseExtended()
		{
			string rtncmd = Error1;
			string extended = prefix+extension;

			switch(extended)
			{
                case "ZZAA":
                    rtncmd = cmdlist.ZZAA(suffix);
                    break;
                case "ZZAB":
                    rtncmd = cmdlist.ZZAB(suffix);
                    break;
                case "ZZAC":
                    rtncmd = cmdlist.ZZAC(suffix);
                    break;
                case "ZZAD":
                    rtncmd = cmdlist.ZZAD(suffix);
                    break;
                case "ZZAE":
                    rtncmd = cmdlist.ZZAE(suffix);
                    break;
                case "ZZAF":
                    rtncmd = cmdlist.ZZAF(suffix);
                    break;                     
				case "ZZAG":
					rtncmd = cmdlist.ZZAG(suffix);
					break;
				case "ZZAI":
					rtncmd = cmdlist.ZZAI(suffix);
					break;
                case "ZZAP":
                    rtncmd = cmdlist.ZZAP(suffix);
                    break;
				case "ZZAR":
					rtncmd = cmdlist.ZZAR(suffix);
					break;
                case "ZZAS":
                    rtncmd = cmdlist.ZZAS(suffix);
                    break;
                case "ZZAT":
                    rtncmd = cmdlist.ZZAT(suffix);
                    break;
                case "ZZAU":
                    rtncmd = cmdlist.ZZAU(suffix);
                    break;
                case "ZZBA":
                    rtncmd = cmdlist.ZZBA();
                    break;
                case "ZZBB":
                    rtncmd = cmdlist.ZZBB();
                    break;
				case "ZZBD":
					rtncmd = cmdlist.ZZBD();
                    break;
                case "ZZBE":
                    rtncmd = cmdlist.ZZBE(suffix);     
					break;
                case "ZZBF":
                    rtncmd = cmdlist.ZZBF(suffix);
                    break;
				case "ZZBI":
					rtncmd = cmdlist.ZZBI(suffix);
					break;
				case "ZZBG":
					rtncmd = cmdlist.ZZBG(suffix);
					break;
                case "ZZBM":
                    rtncmd = cmdlist.ZZBM(suffix);
                    break;
                case "ZZBP":
                    rtncmd = cmdlist.ZZBP(suffix);
                    break;
				case "ZZBR":
					rtncmd = cmdlist.ZZBR(suffix);
					break;
				case "ZZBS":
					rtncmd = cmdlist.ZZBS(suffix);
                    break;
                case "ZZBT":
                    rtncmd = cmdlist.ZZBT(suffix);
                    break;
				case "ZZBU":
					rtncmd = cmdlist.ZZBU();
					break;
                case "ZZBY":
                    rtncmd = cmdlist.ZZBY();
                    break;
				case "ZZCB":
					rtncmd = cmdlist.ZZCB(suffix);
					break;
				case "ZZCD":
					rtncmd = cmdlist.ZZCD(suffix);
					break;
				case "ZZCF":
					rtncmd = cmdlist.ZZCF(suffix);
					break;
				case "ZZCI":
					rtncmd = cmdlist.ZZCI(suffix);
					break;
				case "ZZCL":
					rtncmd = cmdlist.ZZCL(suffix);
					break;
				case "ZZCM":
					rtncmd = cmdlist.ZZCM(suffix);
					break;
                case "ZZCN":
                    rtncmd = cmdlist.ZZCN(suffix);
                    break;
                case "ZZCO":
                    rtncmd = cmdlist.ZZCO(suffix);
                    break;                                                
                case "ZZCP":
					rtncmd = cmdlist.ZZCP(suffix);
					break;
				case "ZZCS":
					rtncmd = cmdlist.ZZCS(suffix);
					break;
				case "ZZCT":
					rtncmd = cmdlist.ZZCT(suffix);
					break;
				case "ZZCU":
					rtncmd = cmdlist.ZZCU();
					break;
				case "ZZDA":
					rtncmd = cmdlist.ZZDA(suffix);
					break;
                case "ZZDB":
                    rtncmd = cmdlist.ZZDB(suffix);
                    break;
                case "ZZDC":
                    rtncmd = cmdlist.ZZDC(suffix);
                    break;
                case "ZZDD":
                    rtncmd = cmdlist.ZZDD(suffix);
                    break;
                case "ZZDE":
                    rtncmd = cmdlist.ZZDE(suffix);
                    break;
                case "ZZDF":
                    rtncmd = cmdlist.ZZDF(suffix);
                    break;
                case "ZZDG":
                    rtncmd = cmdlist.ZZDG(suffix);
                    break;
                case "ZZDH":
                    rtncmd = cmdlist.ZZDH(suffix);
                    break;
				case "ZZDM":
					rtncmd = cmdlist.ZZDM(suffix);
                    break;
                case "ZZDN":
                    rtncmd = cmdlist.ZZDN(suffix);
                    break;
                case "ZZDO":
                    rtncmd = cmdlist.ZZDO(suffix);
                    break;
                case "ZZDP":
                    rtncmd = cmdlist.ZZDP(suffix);
                    break;
                case "ZZDQ":
                    rtncmd = cmdlist.ZZDQ(suffix);
                    break;
                case "ZZDR":
                    rtncmd = cmdlist.ZZDR(suffix);
                    break;
                case "ZZDU":
                    rtncmd = cmdlist.ZZDU();
                    break;
				case "ZZDX":
					rtncmd = cmdlist.ZZDX(suffix);
					break;
				//MW0LGE_22b
                //case "ZZDY":
                //    rtncmd = cmdlist.ZZDY(suffix);
                //    break;
				case "ZZER":
					rtncmd = cmdlist.ZZER(suffix);
					break;
				case "ZZEA":
					rtncmd = cmdlist.ZZEA(suffix);
					break;
				case "ZZEB":
					rtncmd = cmdlist.ZZEB(suffix);
					break;
                case "ZZEM":
                    rtncmd = cmdlist.ZZEM(suffix);
                    break;
				case "ZZET":
					rtncmd = cmdlist.ZZET(suffix);
					break;
				case "ZZFA":
				    // MI0BOT: Redirect CAT to VFO B
                    if (console.CATtoVFOB && Console.getConsole().CurrentHPSDRModel == HPSDRModel.HERMESLITE)
                    {
                        rtncmd = cmdlist.ZZFB(suffix);
                    }
                    else
                    {
                        rtncmd = cmdlist.ZZFA(suffix);
                    }
					break;
				case "ZZFB":
					rtncmd = cmdlist.ZZFB(suffix);
					break;
                case "ZZFD":
                    rtncmd = cmdlist.ZZFD(suffix);
                    break;
                case "ZZFR":
                    rtncmd = cmdlist.ZZFR(suffix);
                    break;
                case "ZZFS":
                    rtncmd = cmdlist.ZZFS(suffix);
                    break;
				case "ZZFT":
					rtncmd = cmdlist.ZZFT(suffix);
					break;
				case "ZZFI":
					rtncmd = cmdlist.ZZFI(suffix);
					break;
                case "ZZFJ":
                    rtncmd = cmdlist.ZZFJ(suffix);
                    break;
				case "ZZFL":
				    // MI0BOT: Redirect CAT to VFO B
					if (console.CATtoVFOB && Console.getConsole().CurrentHPSDRModel == HPSDRModel.HERMESLITE)
					{
						rtncmd = cmdlist.ZZFR(suffix);
					}
					else
					{
						rtncmd = cmdlist.ZZFL(suffix);
					}
					break;
				case "ZZFH":
				    // MI0BOT: Redirect CAT to VFO B
					if (console.CATtoVFOB && Console.getConsole().CurrentHPSDRModel == HPSDRModel.HERMESLITE)
					{
						rtncmd = cmdlist.ZZFS(suffix);
					}
					else
					{
						rtncmd = cmdlist.ZZFH(suffix);
					}
					break;
				case "ZZFM":
					rtncmd = cmdlist.ZZFM();
					break;
				case "ZZFV":
					rtncmd = cmdlist.ZZFV(suffix);
					break;
				case "ZZFW":
					rtncmd = cmdlist.ZZFW(suffix);
					break;
				case "ZZFX":
					rtncmd = cmdlist.ZZFX(suffix);
					break;
				case "ZZFY":
					rtncmd = cmdlist.ZZFY(suffix);
					break;
				case "ZZGE":
					rtncmd = cmdlist.ZZGE(suffix);
					break;
				case "ZZGL":
					rtncmd = cmdlist.ZZGL(suffix);
					break;
				case "ZZGT":
					rtncmd = cmdlist.ZZGT(suffix);
					break;
                case "ZZGU":
                    rtncmd = cmdlist.ZZGU(suffix);
                    break;
				case "ZZHA":
					rtncmd = cmdlist.ZZHA(suffix);
					break;
				case "ZZHR":
					rtncmd = cmdlist.ZZHR(suffix);
					break;
				case "ZZHT":
					rtncmd = cmdlist.ZZHT(suffix);
					break;
				case "ZZHU":
					rtncmd = cmdlist.ZZHU(suffix);
					break;
				case "ZZHV":
					rtncmd = cmdlist.ZZHV(suffix);
					break;
				case "ZZHW":
					rtncmd = cmdlist.ZZHW(suffix);
					break;
				case "ZZHX":
					rtncmd = cmdlist.ZZHX(suffix);
					break;
				case "ZZID":
					rtncmd = cmdlist.ZZID();
					break;
				case "ZZIF":
					rtncmd = cmdlist.ZZIF(suffix);
					break;
                case "ZZIO":
                    rtncmd = cmdlist.ZZIO();
                    break;
				case "ZZIS":
					rtncmd = cmdlist.ZZIS(suffix);
					break;
				case "ZZIT":
					rtncmd = cmdlist.ZZIT(suffix);
					break;
				case "ZZIU":
					rtncmd = cmdlist.ZZIU();
					break;
                case "ZZKO":
                    rtncmd = cmdlist.ZZKO(suffix);
                    break;
                case "ZZKM":
                    rtncmd = cmdlist.ZZKM(suffix);
                    break;
				case "ZZKS":
					rtncmd = cmdlist.ZZKS(suffix);
					break;
				case "ZZKY":
					rtncmd = cmdlist.ZZKY(suffix);
					break;
                case "ZZLA":
                    rtncmd = cmdlist.ZZLA(suffix);
                    break;
                case "ZZLB":
                    rtncmd = cmdlist.ZZLB(suffix);
                    break;
                case "ZZLC":
                    rtncmd = cmdlist.ZZLC(suffix);
                    break;
                case "ZZLD":
                    rtncmd = cmdlist.ZZLD(suffix);
                    break;
                case "ZZLE":
                    rtncmd = cmdlist.ZZLE(suffix);
                    break;
                case "ZZLF":
                    rtncmd = cmdlist.ZZLF(suffix);
                    break;
                case "ZZLG":
                    rtncmd = cmdlist.ZZLG(suffix);
                    break;
                case "ZZLH":
                    rtncmd = cmdlist.ZZLH(suffix);
                    break;
                case "ZZLI":
                    rtncmd = cmdlist.ZZLI(suffix);
                    break;
				case "ZZMA":
					rtncmd = cmdlist.ZZMA(suffix);
					break;
                case "ZZMB":
                    rtncmd = cmdlist.ZZMB(suffix);
                    break;
				case "ZZMD":
				    // MI0BOT: Redirect CAT to VFO B
					if (console.CATtoVFOB && Console.getConsole().CurrentHPSDRModel == HPSDRModel.HERMESLITE)
					{
						rtncmd = cmdlist.ZZME(suffix);
					}
					else
					{
						rtncmd = cmdlist.ZZMD(suffix);
					}
					break;
                case "ZZME":
                    rtncmd = cmdlist.ZZME(suffix);
                    break;
                case "ZZMF":
                    rtncmd = cmdlist.ZZMF(suffix);
                    break;
				case "ZZMG":
					rtncmd = cmdlist.ZZMG(suffix);
					break;
                case "ZZML":
                    rtncmd = cmdlist.ZZML();
                    break;
				case "ZZMN":
					rtncmd = cmdlist.ZZMN(suffix);
					break;
				case "ZZMO":
					rtncmd = cmdlist.ZZMO(suffix);
					break;
				case "ZZMR":
					rtncmd = cmdlist.ZZMR(suffix);
					break;
				case "ZZMS":
					rtncmd = cmdlist.ZZMS(suffix);
					break;
				case "ZZMT":
					rtncmd = cmdlist.ZZMT(suffix);
					break;
				case "ZZMU":
					rtncmd = cmdlist.ZZMU(suffix);
					break;
                case "ZZMV":
                    rtncmd = cmdlist.ZZMV();
                    break;
                case "ZZMW":
                    rtncmd = cmdlist.ZZMW(suffix);
                    break;
                case"ZZMX":
                    rtncmd = cmdlist.ZZMX(suffix);
                    break;
                case "ZZMY":
                    rtncmd = cmdlist.ZZMY();
                    break;
                case "ZZMZ":
                    rtncmd = cmdlist.ZZMZ(suffix);
                    break;
				case "ZZNA":
					rtncmd = cmdlist.ZZNA(suffix);
					break;
				case "ZZNB":
					rtncmd = cmdlist.ZZNB(suffix);
					break;
                case "ZZNC":
                    rtncmd = cmdlist.ZZNC(suffix);
                    break;
                case "ZZND":
                    rtncmd = cmdlist.ZZND(suffix);
                    break;
				case "ZZNL":
					rtncmd = cmdlist.ZZNL(suffix);
					break;
				case "ZZNM":
					rtncmd = cmdlist.ZZNM(suffix);
					break;
                case "ZZNN":
                    rtncmd = cmdlist.ZZNN(suffix);
                    break;
                case "ZZNO":
                    rtncmd = cmdlist.ZZNO(suffix);
                    break;
                case "ZZNR":
					rtncmd = cmdlist.ZZNR(suffix);
					break;
                case "ZZNS":
                    rtncmd = cmdlist.ZZNS(suffix);
                    break;
				case "ZZNT":
					rtncmd = cmdlist.ZZNT(suffix);
					break;
                case "ZZNU":
                    rtncmd = cmdlist.ZZNU(suffix);
                    break;
                case "ZZNV":
                    rtncmd = cmdlist.ZZNV(suffix);
                    break;
                case "ZZNW":
                    rtncmd = cmdlist.ZZNW(suffix);
                    break;
                case "ZZOA":
					rtncmd = cmdlist.ZZOA(suffix);
					break;
				case "ZZOB":
					rtncmd = cmdlist.ZZOB(suffix);
					break;
				case "ZZOC":
					rtncmd = cmdlist.ZZOC(suffix);
					break;
				case "ZZOD":
					rtncmd = cmdlist.ZZOD(suffix);
					break;
				case "ZZOE":
					rtncmd = cmdlist.ZZOE(suffix);
					break;
				case "ZZOF":
					rtncmd = cmdlist.ZZOF(suffix);
					break;
				case "ZZOG":
					rtncmd = cmdlist.ZZOG(suffix);
					break;
				case "ZZOH":
					rtncmd = cmdlist.ZZOH(suffix);
					break;
				case "ZZOJ":
					rtncmd = cmdlist.ZZOJ(suffix);
					break;
                case "ZZOL":
                    rtncmd = cmdlist.ZZOL(suffix);
                    break;
                case "ZZOS":
                    rtncmd = cmdlist.ZZOS(suffix);
                    break;
                case "ZZOT":
                    rtncmd = cmdlist.ZZOT(suffix);
                    break;
                case "ZZOU":
                    rtncmd = cmdlist.ZZOU(suffix);
                    break;
                case "ZZOV":
                    rtncmd = cmdlist.ZZOV(suffix);
                    break;
                case "ZZOW":
                    rtncmd = cmdlist.ZZOW(suffix);
                    break;
                case "ZZOX":
                    rtncmd = cmdlist.ZZOX(suffix);
                    break;
                case "ZZOZ":
                    rtncmd = cmdlist.ZZOZ(suffix);
                    break;
                case "ZZPA":
					rtncmd = cmdlist.ZZPA(suffix);
					break;
                case "ZZPB":
                    rtncmd = cmdlist.ZZPB(suffix);
                    break;
				case "ZZPC":
					rtncmd = cmdlist.ZZPC(suffix);
					break;
				case "ZZPD":
					rtncmd = cmdlist.ZZPD();
					break;
                case "ZZPE":
                    rtncmd = cmdlist.ZZPE(suffix);
                    break;
//				case "ZZPK":
//					rtncmd = cmdlist.ZZPK(suffix);
//					break;
//				case "ZZPL":
//					rtncmd = cmdlist.ZZPL(suffix);
//					break;
				case "ZZPO":
					rtncmd = cmdlist.ZZPO(suffix);
					break;
				case "ZZPS":
					rtncmd = cmdlist.ZZPS(suffix);
					break;
                case "ZZPY":
                    rtncmd = cmdlist.ZZPY(suffix);
                    break;
				case "ZZPZ":
					rtncmd = cmdlist.ZZPZ(suffix);
					break;
                case "ZZQK":
                    rtncmd = cmdlist.ZZQK(suffix);
                    break;
                case "ZZQM":
					rtncmd = cmdlist.ZZQM();
					break;
				case "ZZQR":
					rtncmd = cmdlist.ZZQR();
					break;
				case "ZZQS":
					rtncmd = cmdlist.ZZQS();
					break;
				case "ZZRA":
					rtncmd = cmdlist.ZZRA(suffix);
					break;
				case "ZZRB":
					rtncmd = cmdlist.ZZRB(suffix);
					break;
				case "ZZRC":
					rtncmd = cmdlist.ZZRC();
					break;
				case "ZZRD":
					rtncmd = cmdlist.ZZRD(suffix);
					break;
				case "ZZRF":
					rtncmd = cmdlist.ZZRF(suffix);
					break;
				case "ZZRH":
					rtncmd = cmdlist.ZZRH(suffix);
					break;
				case "ZZRL":
					rtncmd = cmdlist.ZZRL(suffix);
					break;
				case "ZZRM":
					rtncmd = cmdlist.ZZRM(suffix);
					break;
				case "ZZRS":
					rtncmd = cmdlist.ZZRS(suffix);
					break;
				case "ZZRT":
					rtncmd = cmdlist.ZZRT(suffix);
					break;
				case "ZZRU":
					rtncmd = cmdlist.ZZRU(suffix);
					break;
                case "ZZRV":
                    rtncmd = cmdlist.ZZRV();
                    break;
                case "ZZRX":
                    rtncmd = cmdlist.ZZRX(suffix);
                    break;
                case "ZZRY":
                    rtncmd = cmdlist.ZZRY(suffix);
                    break;
				case "ZZSA":
					rtncmd = cmdlist.ZZSA();
					break;
				case "ZZSB":
					rtncmd = cmdlist.ZZSB();
					break;
				case "ZZSD":
					rtncmd = cmdlist.ZZSD();
					break;
				case "ZZSF": 
					rtncmd = cmdlist.ZZSF(suffix);
					break;
                case "ZZSG":
                    rtncmd = cmdlist.ZZSG();
                    break;
                case "ZZSH":
                    rtncmd = cmdlist.ZZSH();
                    break;
				case "ZZSM":
					rtncmd = cmdlist.ZZSM(suffix);
					break;
                case "ZZSN":
                    rtncmd = cmdlist.ZZSN();
                    break;
				case "ZZSO":
					rtncmd = cmdlist.ZZSO(suffix);
					break;
				case "ZZSP":
					rtncmd = cmdlist.ZZSP(suffix, true);
					break; 
				case "ZZSQ":
					rtncmd = cmdlist.ZZSQ(suffix);
					break;
				case "ZZSR":
					rtncmd = cmdlist.ZZSR(suffix);
					break;
                case "ZZSS":
                    rtncmd = cmdlist.ZZSS();
                    break;
				case "ZZST":
					rtncmd = cmdlist.ZZST();
					break;
				case "ZZSU":
					rtncmd = cmdlist.ZZSU();
					break;
                case "ZZSV":
                    rtncmd = cmdlist.ZZSV(suffix);
                    break;
                case "ZZSW":
                    rtncmd = cmdlist.ZZSW(suffix);
                    break;
                case "ZZSX":
                    rtncmd = cmdlist.ZZSX(suffix);
                    break;
                case "ZZSY":
                    rtncmd = cmdlist.ZZSY(suffix);
                    break;
                case "ZZSZ":
                    rtncmd = cmdlist.ZZSZ(suffix);
                    break;
                case "ZZTA":
                    rtncmd = cmdlist.ZZTA(suffix);
                    break;
                case "ZZTB":
                    rtncmd = cmdlist.ZZTB(suffix);
                    break;
				case "ZZTF":
					rtncmd = cmdlist.ZZTF(suffix);
					break;
				case "ZZTH":
					rtncmd = cmdlist.ZZTH(suffix);
					break;
				case "ZZTI":
					rtncmd = cmdlist.ZZTI(suffix);
					break;
				case "ZZTP":
					rtncmd = cmdlist.ZZTP(suffix);
					break;
				case "ZZTL":
					rtncmd = cmdlist.ZZTL(suffix);
					break;
                case "ZZTM":
                    rtncmd = cmdlist.ZZTM(suffix);
                    break;
				case "ZZTO":
					rtncmd = cmdlist.ZZTO(suffix);
					break;
				case "ZZTS":
					rtncmd = cmdlist.ZZTS();
					break;
				case "ZZTU":
					rtncmd = cmdlist.ZZTU(suffix);
					break;
				case "ZZTV":
                    rtncmd = cmdlist.ZZTV(suffix);
                    break;
				case "ZZTX":
					rtncmd = cmdlist.ZZTX(suffix);
					break;
				case "ZZUA":
					rtncmd = cmdlist.ZZUA();
					break;
				case "ZZUP":
					rtncmd = cmdlist.ZZUP(suffix);
					break;
				case "ZZUS":
                    rtncmd = cmdlist.ZZUS();
                    break;
                case "ZZUT":
                    rtncmd = cmdlist.ZZUT(suffix);
                    break;
                case "ZZUX":
                    rtncmd = cmdlist.ZZUX(suffix);
                    break;
                case "ZZUY":
                    rtncmd = cmdlist.ZZUY(suffix);
                    break;
				case "ZZVA":
					rtncmd = cmdlist.ZZVA(suffix);
					break;
				case "ZZVB":
					rtncmd = cmdlist.ZZVB(suffix);
					break;
				case "ZZVC":
					rtncmd = cmdlist.ZZVC(suffix);
					break;
				case "ZZVD":
					rtncmd = cmdlist.ZZVD(suffix);
					break;
				case "ZZVE":
					rtncmd = cmdlist.ZZVE(suffix);
					break;
				case "ZZVF":
					rtncmd = cmdlist.ZZVF(suffix);
					break;
				case "ZZVG":
					rtncmd = cmdlist.ZZVG(suffix);
					break;
				case "ZZVH":
					rtncmd = cmdlist.ZZVH(suffix);
					break;
                case "ZZVI":
                    rtncmd = cmdlist.ZZVI(suffix);
                    break;
                case "ZZVJ":
                    rtncmd = cmdlist.ZZVJ(suffix);
                    break;
                case "ZZVK":
                    rtncmd = cmdlist.ZZVK(suffix);
                    break;
				case "ZZVL":
					rtncmd = cmdlist.ZZVL(suffix);
					break;
                case "ZZVM":
                    rtncmd = cmdlist.ZZVM(suffix);
                    break;
				case "ZZVN":
					rtncmd = cmdlist.ZZVN();
					break;
                case "ZZVO":
                    rtncmd = cmdlist.ZZVO(suffix);
                    break;
                case "ZZVP":
                    rtncmd = cmdlist.ZZVP(suffix);
                    break;
                case "ZZVQ":
                    rtncmd = cmdlist.ZZVQ(suffix);
                    break;
                case "ZZVR":
                    rtncmd = cmdlist.ZZVR(suffix);
                    break;
				case "ZZVS":
					rtncmd = cmdlist.ZZVS(suffix);
					break;
                case "ZZVT":
                    rtncmd = cmdlist.ZZVT(suffix);
                    break;
                case "ZZVU":
                    rtncmd = cmdlist.ZZVU(suffix);
                    break;
                case "ZZVV":
                    rtncmd = cmdlist.ZZVV(suffix);
                    break;
                case "ZZVW":
                    rtncmd = cmdlist.ZZVW(suffix);
                    break;
                case "ZZVX":
                    rtncmd = cmdlist.ZZVX(suffix);
                    break;
                case "ZZVY":
                    rtncmd = cmdlist.ZZVY(suffix);
                    break;
                case "ZZVZ":
                    rtncmd = cmdlist.ZZVZ(suffix);
                    break;
				case "ZZWA":
					rtncmd = cmdlist.ZZWA(suffix);
					break;
				case "ZZWB":
					rtncmd = cmdlist.ZZWB(suffix);
					break;
				case "ZZWC":
					rtncmd = cmdlist.ZZWC(suffix);
					break;
				case "ZZWD":
					rtncmd = cmdlist.ZZWD(suffix);
					break;
				case "ZZWE":
					rtncmd = cmdlist.ZZWE(suffix);
					break;
				case "ZZWF":
					rtncmd = cmdlist.ZZWF(suffix);
					break;
				case "ZZWG":
					rtncmd = cmdlist.ZZWG(suffix);
					break;
				case "ZZWH":
					rtncmd = cmdlist.ZZWH(suffix);
					break;
				case "ZZWJ":
					rtncmd = cmdlist.ZZWJ(suffix);
					break;
				case "ZZWK":
					rtncmd = cmdlist.ZZWK(suffix);
					break;
				case "ZZWL":
					rtncmd = cmdlist.ZZWL(suffix);
					break;
				case "ZZWM":
					rtncmd = cmdlist.ZZWM(suffix);
					break;
				case "ZZWN":
					rtncmd = cmdlist.ZZWN(suffix);
					break;
				case "ZZWO":
					rtncmd = cmdlist.ZZWO(suffix);
					break;
				case "ZZWP":
					rtncmd = cmdlist.ZZWP(suffix);
					break;
				case "ZZWQ":
					rtncmd = cmdlist.ZZWQ(suffix);
					break;
				case "ZZWR":
					rtncmd = cmdlist.ZZWR(suffix);
					break;
				case "ZZWS":
					rtncmd = cmdlist.ZZWS(suffix);
					break;
                case "ZZWT":
                    rtncmd = cmdlist.ZZWT(suffix);
                    break;
                case "ZZWU":
                    rtncmd = cmdlist.ZZWU(suffix);
                    break;
                case "ZZWV":
                    rtncmd = cmdlist.ZZWV(suffix);
                    break;
                case "ZZWW":
                    rtncmd = cmdlist.ZZWW(suffix);
                    break;
				case "ZZXC":
					rtncmd = cmdlist.ZZXC();
					break;
                case "ZZXD":
                    rtncmd = cmdlist.ZZXD(suffix);
                    break;
				case "ZZXF":
					rtncmd = cmdlist.ZZXF(suffix);
					break;
                case "ZZXH":
                    rtncmd = cmdlist.ZZXH(suffix);
                    break;
                case "ZZXN":
                    rtncmd = cmdlist.ZZXN(suffix);
                    break;
                case "ZZXO":
                    rtncmd = cmdlist.ZZXO(suffix);
                    break;
				case "ZZXS":
					rtncmd = cmdlist.ZZXS(suffix);
					break;
				case "ZZXT":
					rtncmd = cmdlist.ZZXT(suffix);
					break;
                case "ZZXU":
                    rtncmd = cmdlist.ZZXU(suffix);
                    break;
                case "ZZXV":
                    rtncmd = cmdlist.ZZXV(suffix);
                    break;
                case "ZZYA":
                    rtncmd = cmdlist.ZZYA(suffix);
                    break;
                case "ZZYB":
                    rtncmd = cmdlist.ZZYB(suffix);
                    break;
                case "ZZYC":
                    rtncmd = cmdlist.ZZYC(suffix);
                    break;
                case "ZZYR":
                    rtncmd = cmdlist.ZZYR(suffix);
                    break;
                case "ZZZA":
                    rtncmd = cmdlist.ZZZA(suffix);
                    break;
                case "ZZZB":
					rtncmd = cmdlist.ZZZB();
					break;
                case "ZZZD":
                    rtncmd = cmdlist.ZZZD(suffix);
                    break;
                case "ZZZE":
                    rtncmd = cmdlist.ZZZE(suffix);
                    break;
				case "ZZZM":
					rtncmd = cmdlist.ZZZM(suffix);
					break;
				case "ZZZP":
                    rtncmd = cmdlist.ZZZP(suffix);
					break;
				case "ZZZQ":
					rtncmd = cmdlist.ZZZQ(suffix);
					break;
				case "ZZZR":
					rtncmd = cmdlist.ZZZR(suffix);
					break;
                case "ZZZS":
                    rtncmd = cmdlist.ZZZS(suffix);
                    break;
				case "ZZZT":
					rtncmd = cmdlist.ZZZT(suffix);
					break;
                case "ZZZU":
                    rtncmd = cmdlist.ZZZU(suffix);
					break;
				case "ZZZV":
					rtncmd = cmdlist.ZZZV(suffix);
					break;
				case "ZZZW":
					rtncmd = cmdlist.ZZZW(suffix);
					break;
				case "ZZZZ":
					rtncmd = cmdlist.ZZZZ();
					break;
				case "ZZZN":
					rtncmd = cmdlist.ZZZN(suffix);
					break;
                case "ZZZO":
                    rtncmd = cmdlist.ZZZO(suffix);
                    break;
                case "ZZXA":
                    rtncmd = cmdlist.ZZXA(suffix);
                    break;
            }
            if (!rtncmd.Contains(Error1))
            //rtncmd != Error1 && rtncmd != Error2 && rtncmd != Error3)
            {
                if (rtncmd.Length == nAns && nAns > 0)
                {
                    if (rtncmd.StartsWith(" ") && (extension != "ML" && extension != "MN"))  //Don't trim filter name string
                    {												                        // Fix in next generation.
                        rtncmd = rtncmd.Trim();
                    }
                    rtncmd = prefix + extension + suffix + rtncmd + ";";
                }
            }
            else rtncmd = ProcessError(rtncmd);

			return rtncmd;
		}

        private string ProcessError(string error)
        {
            string ecmd = "";
            if (Verbose)
            {
                string sep = ":";
                string cmdname = "";
                if (prefix.Length == 0 && suffix.Length == 0)
                    cmdname = current_cat;
                else
                    cmdname = prefix + extension;
                ecmd = "ZZEM" + sep + cmdname + suffix+sep;
                switch (verbose_error_code)
                {
                    case 1:
                        ecmd += "Bad Command Name;";
                        break;
                    case 2:
                        ecmd += "Inactive Command;";
                        break;
                    case 3:
                        ecmd += "Unknown Command;";
                        break;
                    case 4:
                        ecmd += "Undefined Command Error;";
                        break;
                    case 5:
                        ecmd += "Suffix Format Error;";
                        break;
                    case 6:
                        ecmd += "Suffix Length Error;";
                        break;
                    case 7:
                        ecmd += "Feature Not Available;";
                        break;
                    case 8:
                        ecmd += "Form Must Be Open;";
                        break;
                    case 9:
                        ecmd += "Value out of bounds;";
                        break;
                    case 10:
                        ecmd += "Power must be on;";
                        break;
                    default:
                        ecmd += "Undefined Error;"; ;
                        break;
                }
                return ecmd;
            }
            else
                return error;
        }
	}

	#endregion CATParser Class

}
