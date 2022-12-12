//=================================================================
// common.cs
//=================================================================
// PowerSDR is a C# implementation of a Software Defined Radio.
// Copyright (C) 2004-2012  FlexRadio Systems
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
// You may contact us via email at: gpl@flexradio.com.
// Paper mail may be sent to: 
//    FlexRadio Systems
//    4616 W. Howard Lane  Suite 1-150
//    Austin, TX 78728
//    USA
//=================================================================

using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.IO.Ports;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Net;
using System.Security.Principal;

namespace Thetis
{
	// extend contains to be able to ignore case etc MW0LGE
	public static class StringExtensions
	{
		public static bool Contains(this string source, string toCheck, StringComparison comp)
		{
			return source?.IndexOf(toCheck, comp) >= 0;
		}
	}
    //public static class Extensions
    //{
    //    private const double Epsilon = 1e-10;

    //    public static bool IsZero(this double d)
    //    {
    //        return Math.Abs(d) < Epsilon;
    //    }
    //}
    public class Common
	{
		private const bool ENABLE_VERSION_TIMEOUT = false;
		private static DateTime _versionTimeout = new DateTime(2022, 06, 01, 00, 00, 00); // june 1st 2022 00:00:00
		private static bool _bypassTimeout = false;

		public static MessageBoxOptions MB_TOPMOST = (MessageBoxOptions)0x00040000L; //MW0LGE_21g TOPMOST for MessageBox

		#region HiglightControls
		private static Dictionary<string, Color> m_backgroundColours = new Dictionary<string, Color>();
		private static Dictionary<string, Color> m_foregoundColours = new Dictionary<string, Color>();
		private static Dictionary<string, FlatStyle> m_flatStyle = new Dictionary<string, FlatStyle>();
		private static Dictionary<string, Image> m_backImage = new Dictionary<string, Image>();
		public static void HightlightControl(Control c, bool bHighlight)
		{
			if (!m_backgroundColours.ContainsKey(c.Name))
			{
				m_backgroundColours.Add(c.Name, c.BackColor);
			}
			if (!m_foregoundColours.ContainsKey(c.Name))
			{
				m_foregoundColours.Add(c.Name, c.ForeColor);
			}
			if (!m_backImage.ContainsKey(c.Name))
			{
				m_backImage.Add(c.Name, c.BackgroundImage);
			}

			if (c.GetType() == typeof(NumericUpDownTS))
			{
				c.BackColor = bHighlight ? Color.Yellow : m_backgroundColours[c.Name];
			}
			else if (c.GetType() == typeof(CheckBoxTS))
			{
				CheckBoxTS cb = c as CheckBoxTS;
				if (!m_flatStyle.ContainsKey(cb.Name)) m_flatStyle.Add(cb.Name, cb.FlatStyle);
				cb.FlatStyle = bHighlight ? FlatStyle.Flat : m_flatStyle[cb.Name];
				cb.BackColor = bHighlight ? Color.Yellow : m_backgroundColours[cb.Name];
				cb.ForeColor = bHighlight ? Color.Red : m_foregoundColours[cb.Name];
				cb.BackgroundImage = bHighlight ? null : m_backImage[cb.Name];
			}
			else if (c.GetType() == typeof(TrackBarTS))
			{
				c.BackColor = bHighlight ? Color.Yellow : m_backgroundColours[c.Name];
				c.ForeColor = bHighlight ? Color.Yellow : m_foregoundColours[c.Name];
				c.BackgroundImage = bHighlight ? null : m_backImage[c.Name];
			}
			else if (c.GetType() == typeof(PrettyTrackBar))
			{
				c.BackColor = bHighlight ? Color.Yellow : m_backgroundColours[c.Name];
				c.ForeColor = bHighlight ? Color.Yellow : m_foregoundColours[c.Name];
				c.BackgroundImage = bHighlight ? null : m_backImage[c.Name];
			}
			else if (c.GetType() == typeof(ComboBoxTS))
			{
				ComboBoxTS cb = c as ComboBoxTS;
				if (!m_flatStyle.ContainsKey(cb.Name)) m_flatStyle.Add(cb.Name, cb.FlatStyle);
				cb.FlatStyle = bHighlight ? FlatStyle.Flat : m_flatStyle[cb.Name];
				cb.BackColor = bHighlight ? Color.Yellow : m_backgroundColours[cb.Name];
				cb.ForeColor = bHighlight ? Color.Red : m_foregoundColours[cb.Name];
			}
			else if (c.GetType() == typeof(RadioButtonTS))
			{
				RadioButtonTS cb = c as RadioButtonTS;
				if (!m_flatStyle.ContainsKey(cb.Name)) m_flatStyle.Add(cb.Name, cb.FlatStyle);
				cb.FlatStyle = bHighlight ? FlatStyle.Flat : m_flatStyle[cb.Name];
				cb.BackColor = bHighlight ? Color.Yellow : m_backgroundColours[cb.Name];
				cb.ForeColor = bHighlight ? Color.Red : m_foregoundColours[cb.Name];
				cb.BackgroundImage = bHighlight ? null : m_backImage[cb.Name];
			}
			else if (c.GetType() == typeof(TextBoxTS))
			{
				c.BackColor = bHighlight ? Color.Yellow : m_backgroundColours[c.Name];
			}
			else if (c.GetType() == typeof(LabelTS))
			{
				c.BackColor = bHighlight ? Color.Yellow : m_backgroundColours[c.Name];
			}

			if (!bHighlight)
			{
				if (!m_backgroundColours.ContainsKey(c.Name)) m_backgroundColours.Remove(c.Name);
				if (!m_foregoundColours.ContainsKey(c.Name)) m_foregoundColours.Remove(c.Name);
				if (!m_flatStyle.ContainsKey(c.Name)) m_flatStyle.Remove(c.Name);
				if (!m_backImage.ContainsKey(c.Name)) m_backImage.Remove(c.Name);
			}

			c.Invalidate();
		}
		#endregion
		#region WindowDropShadow
		private const int DWMWA_EXTENDED_FRAME_BOUNDS = 9;
		[DllImport("dwmapi.dll")]
		private static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, out RECT pvAttribute, int cbAttribute);
		[StructLayout(LayoutKind.Sequential)]
		private struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}
		
		public static Size DropShadowSize(Form f)
		{
			// this only works on a visibile form
			if (!f.Visible) return new Size(0, 0);

			Size sz;
			RECT rectWithShadow;
			if (Environment.OSVersion.Version.Major < 6)
			{
				sz = new Size(0, 0);
			}
			else if (DwmGetWindowAttribute(f.Handle, DWMWA_EXTENDED_FRAME_BOUNDS, out rectWithShadow, Marshal.SizeOf(typeof(RECT))) == 0)
			{
				sz = new Size(f.Width - (rectWithShadow.right - rectWithShadow.left), f.Height - (rectWithShadow.bottom - rectWithShadow.top));
			}
			else
			{
				sz = new Size(0, 0);
			}

			return sz;
		}
		#endregion

		public static void ControlList(Control c, ref ArrayList a)
		{
			if(c.Controls.Count > 0)
			{
                foreach (Control c2 in c.Controls)
                {
                    ControlList(c2, ref a);
                }
			}

			if(c.GetType() == typeof(CheckBoxTS) || c.GetType() == typeof(CheckBoxTS) ||
				c.GetType() == typeof(ComboBoxTS) || c.GetType() == typeof(ComboBox) ||
				c.GetType() == typeof(NumericUpDownTS) || c.GetType() == typeof(NumericUpDown) ||
				c.GetType() == typeof(RadioButtonTS) || c.GetType() == typeof(RadioButton) ||
				c.GetType() == typeof(TextBoxTS) || c.GetType() == typeof(TextBox) ||
				c.GetType() == typeof(TrackBarTS) || c.GetType() == typeof(TrackBar) ||
				c.GetType() == typeof(ColorButton))
				a.Add(c);

		}
        
        public static void SaveForm(Form form, string tablename)
		{
			ArrayList a = new ArrayList();
			ArrayList temp = new ArrayList();

			ControlList(form, ref temp);

			foreach(Control c in temp)				// For each control
			{
				if(c.GetType() == typeof(CheckBoxTS))
					a.Add(c.Name+"/"+((CheckBoxTS)c).Checked.ToString());
				else if(c.GetType() == typeof(ComboBoxTS))
				{
					//if(((ComboBox)c).SelectedIndex >= 0)
					a.Add(c.Name+"/"+((ComboBoxTS)c).Text);
				}
				else if(c.GetType() == typeof(NumericUpDownTS))
					a.Add(c.Name+"/"+((NumericUpDownTS)c).Value.ToString());
				else if(c.GetType() == typeof(RadioButtonTS))
					a.Add(c.Name+"/"+((RadioButtonTS)c).Checked.ToString());
				else if(c.GetType() == typeof(TextBoxTS))
					a.Add(c.Name+"/"+((TextBoxTS)c).Text);
				else if(c.GetType() == typeof(TrackBarTS))
					a.Add(c.Name+"/"+((TrackBarTS)c).Value.ToString());
				else if(c.GetType() == typeof(ColorButton))
				{
					Color clr = ((ColorButton)c).Color;
					a.Add(c.Name+"/"+clr.R+"."+clr.G+"."+clr.B+"."+clr.A);
				}
#if(DEBUG)
				else if(c.GetType() == typeof(GroupBox) ||
					c.GetType() == typeof(CheckBoxTS) ||
					c.GetType() == typeof(ComboBox) ||
					c.GetType() == typeof(NumericUpDown) ||
					c.GetType() == typeof(RadioButton) ||
					c.GetType() == typeof(TextBox) ||
					c.GetType() == typeof(TrackBar))
					Debug.WriteLine(form.Name + " -> " + c.Name+" needs to be converted to a Thread Safe control.");
#endif
			}
			a.Add("Top/"+form.Top);
			a.Add("Left/"+form.Left);
			a.Add("Width/"+form.Width);
			a.Add("Height/"+form.Height);

			DB.SaveVars(tablename, ref a);		// save the values to the DB
		}

		public static void RestoreForm(Form form, string tablename, bool restore_size)
		{
			ArrayList temp = new ArrayList();		// list of all first level controls
			ControlList(form, ref temp);

			ArrayList checkbox_list = new ArrayList();
			ArrayList combobox_list = new ArrayList();
			ArrayList numericupdown_list = new ArrayList();
			ArrayList radiobutton_list = new ArrayList();
			ArrayList textbox_list = new ArrayList();
			ArrayList trackbar_list = new ArrayList();
			ArrayList colorbutton_list = new ArrayList();

			//ArrayList controls = new ArrayList();	// list of controls to restore
			foreach(Control c in temp)
			{
				if(c.GetType() == typeof(CheckBoxTS))			// the control is a CheckBoxTS
					checkbox_list.Add(c);
				else if(c.GetType() == typeof(ComboBoxTS))		// the control is a ComboBox
					combobox_list.Add(c);
				else if(c.GetType() == typeof(NumericUpDownTS))	// the control is a NumericUpDown
					numericupdown_list.Add(c);
				else if(c.GetType() == typeof(RadioButtonTS))	// the control is a RadioButton
					radiobutton_list.Add(c);
				else if(c.GetType() == typeof(TextBoxTS))		// the control is a TextBox
					textbox_list.Add(c);
				else if(c.GetType() == typeof(TrackBarTS))		// the control is a TrackBar (slider)
					trackbar_list.Add(c);
				else if(c.GetType() == typeof(ColorButton))
					colorbutton_list.Add(c);
			}
			temp.Clear();	// now that we have the controls we want, delete first list 

			ArrayList a = DB.GetVars(tablename);						// Get the saved list of controls
			a.Sort();
			
			// restore saved values to the controls
			foreach(string s in a)				// string is in the format "name,value"
			{
				string[] vals = s.Split('/');
				if(vals.Length > 2)
				{
					for(int i=2; i<vals.Length; i++)
						vals[1] += "/"+vals[i];
				}

				string name = vals[0];
				string val = vals[1];

				switch(name)
				{
					case "Top":
						form.StartPosition = FormStartPosition.Manual;
						int top = int.Parse(val);
						/*if(top < 0) top = 0;
						if(top > Screen.PrimaryScreen.Bounds.Height-form.Height && Screen.AllScreens.Length == 1)
							top = Screen.PrimaryScreen.Bounds.Height-form.Height;*/
						form.Top = top;
						break;
					case "Left":
						form.StartPosition = FormStartPosition.Manual;
						int left = int.Parse(val);
						/*if(left < 0) left = 0;
						if(left > Screen.PrimaryScreen.Bounds.Width-form.Width && Screen.AllScreens.Length == 1)
							left = Screen.PrimaryScreen.Bounds.Width-form.Width;*/
						form.Left = left;
						break;
					case "Width":
						if(restore_size)
						{
							int width = int.Parse(val);
							/*if(width + form.Left > Screen.PrimaryScreen.Bounds.Width && Screen.AllScreens.Length == 1)
								form.Left -= (width+form.Left-Screen.PrimaryScreen.Bounds.Width);*/
							form.Width = width;
						}
						break;
					case "Height":
						if(restore_size)
						{
							int height = int.Parse(val);
							/*if(height + form.Top > Screen.PrimaryScreen.Bounds.Height && Screen.AllScreens.Length == 1)
								form.Top -= (height+form.Top-Screen.PrimaryScreen.Bounds.Height);*/
							form.Height = height;
						}
						break;
				}

				if(s.StartsWith("chk"))			// control is a CheckBoxTS
				{
					for(int i=0; i<checkbox_list.Count; i++)
					{	// look through each control to find the matching name
						CheckBoxTS c = (CheckBoxTS)checkbox_list[i];
						if(c.Name.Equals(name))		// name found
						{
							c.Checked = bool.Parse(val);	// restore value
							i = checkbox_list.Count+1;
						}
						if(i == checkbox_list.Count)
							MessageBox.Show("Control not found: "+name);
					}
				}
				else if(s.StartsWith("combo"))	// control is a ComboBox
				{
					for(int i=0; i<combobox_list.Count; i++)
					{	// look through each control to find the matching name
						ComboBoxTS c = (ComboBoxTS)combobox_list[i];
						if(c.Name.Equals(name))		// name found
						{
							c.Text = val;	// restore value
							i = combobox_list.Count+1;
							if(c.Text != val) Debug.WriteLine("Warning: "+form.Name+"."+name+" did not set to "+val);
						}
						if(i == combobox_list.Count)
							MessageBox.Show("Control not found: "+name);
					}
				}
				else if(s.StartsWith("ud"))
				{
					for(int i=0; i<numericupdown_list.Count; i++)
					{	// look through each control to find the matching name
						NumericUpDownTS c = (NumericUpDownTS)numericupdown_list[i];
						if(c.Name.Equals(name))		// name found
						{
							decimal num = decimal.Parse(val);

							if(num > c.Maximum) num = c.Maximum;		// check endpoints
							else if(num < c.Minimum) num = c.Minimum;
							c.Value = num;			// restore value
							i = numericupdown_list.Count+1;
						}
						if(i == numericupdown_list.Count)
							MessageBox.Show("Control not found: "+name);	
					}
				}
				else if(s.StartsWith("rad"))
				{	// look through each control to find the matching name
					for(int i=0; i<radiobutton_list.Count; i++)
					{
						RadioButtonTS c = (RadioButtonTS)radiobutton_list[i];
						if(c.Name.Equals(name))		// name found
						{
							if(!val.ToLower().Equals("true") && !val.ToLower().Equals("false"))
								val = "True";
							c.Checked = bool.Parse(val);	// restore value
							i = radiobutton_list.Count+1;
						}
						if(i == radiobutton_list.Count)
							MessageBox.Show("Control not found: "+name);
					}
				}
				else if(s.StartsWith("txt"))
				{	// look through each control to find the matching name
					for(int i=0; i<textbox_list.Count; i++)
					{
						TextBoxTS c = (TextBoxTS)textbox_list[i];
						if(c.Name.Equals(name))		// name found
						{
							c.Text = val;	// restore value
							i = textbox_list.Count+1;
						}
						if(i == textbox_list.Count)
							MessageBox.Show("Control not found: "+name);
					}
				}
				else if(s.StartsWith("tb"))
				{
					// look through each control to find the matching name
					for(int i=0; i<trackbar_list.Count; i++)
					{
						TrackBarTS c = (TrackBarTS)trackbar_list[i];
						if(c.Name.Equals(name))		// name found
						{
							int num = int.Parse(val);
							if(num > c.Maximum) num = c.Maximum;
							if(num < c.Minimum) num = c.Minimum;
							c.Value = num;
							i = trackbar_list.Count+1;
						}
						if(i == trackbar_list.Count)
							MessageBox.Show("Control not found: "+name);
					}
				}
				else if(s.StartsWith("clrbtn"))
				{
					string[] colors = val.Split('.');
					if(colors.Length == 4)
					{
						int R,G,B,A;
						R = Int32.Parse(colors[0]);
						G = Int32.Parse(colors[1]);
						B = Int32.Parse(colors[2]);
						A = Int32.Parse(colors[3]);

						for(int i=0; i<colorbutton_list.Count; i++)
						{
							ColorButton c = (ColorButton)colorbutton_list[i];
							if(c.Name.Equals(name))		// name found
							{
								c.Color = Color.FromArgb(A, R, G, B);
								i = colorbutton_list.Count+1;
							}
							if(i == colorbutton_list.Count)
								MessageBox.Show("Control not found: "+name);
						}
					}
				}
			}

			ForceFormOnScreen(form);
		}

		public static void ForceFormOnScreen(Form f)
		{
            Screen[] screens = Screen.AllScreens;
			bool on_screen = false;

			int left = 0, right = 0, top = 0, bottom = 0;

			for(int i=0; i<screens.Length; i++)
			{
				if(screens[i].Bounds.Left < left)
					left = screens[i].Bounds.Left;

				if(screens[i].Bounds.Top < top)
					top = screens[i].Bounds.Top;

				if(screens[i].Bounds.Bottom > bottom)
					bottom = screens[i].Bounds.Bottom;

				if(screens[i].Bounds.Right > right)
					right = screens[i].Bounds.Right;
			}

			//MW0LGE_21d >= and <= all over
			if(f.Left >= left &&
				f.Top >= top &&
				f.Right <= right &&
				f.Bottom <= bottom)
            	on_screen = true;				

			if(!on_screen)
			{
				//f.Location = new Point(0, 0);

				if(f.Left < left)
					f.Left = left;

				if(f.Top < top)
					f.Top = top;

				if(f.Bottom > bottom)
				{
					if((f.Top - (f.Bottom-bottom)) >= top)
						f.Top -= (f.Bottom-bottom);
					else f.Top = 0;
				}

				if(f.Right > right)
				{
					if((f.Left - (f.Right-right)) >= left)
						f.Left -= (f.Right-right);
					else f.Left = 0;
				}
			}
		}

		public static void TabControlInsert(TabControl tc, TabPage tp, int index)
		{
			tc.SuspendLayout();
			// temp storage to rearrange tabs
			TabPage[] temp = new TabPage[tc.TabPages.Count+1];

			// copy pages in order and insert new page when needed
			for(int i=0; i<tc.TabPages.Count+1; i++)
			{
				if(i < index) temp[i] = tc.TabPages[i];
				else if(i == index) temp[i] = tp;
				else if(i > index) temp[i] = tc.TabPages[i-1];
			}
			
			// erase all tab pages
			while(tc.TabPages.Count > 0)
				tc.TabPages.RemoveAt(0);

			// add them back with new page inserted
			for(int i=0; i<temp.Length; i++)
				tc.TabPages.Add(temp[i]);

			tc.ResumeLayout();
		}

        public static string[] SortedComPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            Array.Sort<string>(ports, delegate(string strA, string strB)
            {
                try
                {
                    int idA = int.Parse(strA.Substring(3));
                    int idB = int.Parse(strB.Substring(3));

                    return idA.CompareTo(idB);
                }
                catch (Exception)
                {
                    return strA.CompareTo(strB);
                }
            });
            return ports;
        }

        public static string RevToString(uint rev)
        {
            return ((byte)(rev >> 24)).ToString() + "." +
                ((byte)(rev >> 16)).ToString() + "." +
                ((byte)(rev >> 8)).ToString() + "." +
                ((byte)(rev >> 0)).ToString();
        }

        private static string m_sLogPath = "";
        public static void SetLogPath(string sPath)
        {
            m_sLogPath = sPath;
        }
        public static void LogString(string entry)
        {
            // MW0LGE very simple logger
            if (m_sLogPath == "") return;
            if (entry == "") return;

            try
            {
                using (StreamWriter w = File.AppendText(m_sLogPath + "\\ErrorLog.txt"))
                {
                    //using block will auto close stream
                    w.Write("\r\nEntry : ");
                    w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                    w.WriteLine(entry);
                    w.WriteLine("-------------------------------");
                }
            }
            catch
            {

            }
        }
        public static void LogException(Exception e)
        {
            // MW0LGE very simple logger
            if (m_sLogPath == "") return;
            if (e == null) return;

            try
            {
                using (StreamWriter w = File.AppendText(m_sLogPath + "\\ErrorLog.txt"))
                {
                    //using block will auto close stream
                    w.Write("\r\nEntry : ");
                    w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                    w.WriteLine(e.Message);
                    if (e.StackTrace != "")
                    {
#if DEBUG
                        StackTrace st = new StackTrace(e, true);
                        StackFrame sf = st.GetFrames().Last();
                        w.WriteLine("File : " + sf.GetFileName() + " ... line : " + sf.GetFileLineNumber().ToString());
#endif
                        w.WriteLine("---------stacktrace------------");
                        w.WriteLine(e.StackTrace);
                    }
                    w.WriteLine("-------------------------------");
                }
            }
            catch
            {

            }
        }

		// returns the Thetis version number in "a.b.c" format
		// MW0LGE moved here from titlebar.cs, and used by console.cs and others
		private static string m_sVersionNumber = "";
		private static string m_sFileVersion = "";
		private static string m_sRevision = "";
		public static string GetVerNum()
		{
			if (m_sVersionNumber != "") return m_sVersionNumber;

			setupVersions();

			return m_sVersionNumber;
		}
		public static string GetFileVersion()
		{
			if (m_sFileVersion != "") return m_sFileVersion;

			setupVersions();

			return m_sFileVersion;
		}
		public static string GetRevision()
		{
			if (m_sRevision != "") return m_sRevision;

			setupVersions();

			return m_sRevision;
		}
		private static void setupVersions()
		{
			//MW0LGE build version number string once and return that
			// if called again. Issue reported by NJ2US where assembly.Location
			// passed into GetVersionInfo failed. Perhaps because norton or something
			// moved the file after it was accessed. The version isn't going to
			// change anyway while running, so obtaining it once is fine.
			if (m_sVersionNumber!="" && m_sFileVersion!="") return; // already setup

			Assembly assembly = Assembly.GetExecutingAssembly();
			FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
			m_sVersionNumber = fvi.FileVersion.Substring(0, fvi.FileVersion.LastIndexOf("."));
			m_sFileVersion = fvi.FileVersion;
			m_sRevision = fvi.FileVersion.Substring(fvi.FileVersion.LastIndexOf(".") + 1);
		}

		public static int DaysToTimeOut()
		{
			int days = (int)(_versionTimeout - DateTime.Now).TotalDays;
			if (days < 0) days = 0;
			return days;
		}
		public static bool IsVersionTimedOut
		{
			get
			{
				if (ENABLE_VERSION_TIMEOUT && !_bypassTimeout)
					return DaysToTimeOut() == 0;
				else
					return false;
			}
		}
		public static bool IsTimeOutEnabled
		{
			get { return ENABLE_VERSION_TIMEOUT && !_bypassTimeout; }
		}
		public static bool BypassTimeOut
        {
            set { _bypassTimeout = value; }
        }
		public static bool IsAdministrator()
		{
			using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
			{
				WindowsPrincipal principal = new WindowsPrincipal(identity);
				return principal.IsInRole(WindowsBuiltInRole.Administrator);
			}
		}

		public static bool ShiftKeyDown
		{
			get
			{
				return Keyboard.IsKeyDown(Keys.LShiftKey) || Keyboard.IsKeyDown(Keys.RShiftKey);
			}
		}
		public static bool CtrlKeyDown
		{
			get
			{
				return Keyboard.IsKeyDown(Keys.LControlKey) || Keyboard.IsKeyDown(Keys.RControlKey);
			}
		}
		public static bool Is64Bit
        {
            get
            {
				return System.IntPtr.Size == 8 ? true : false;
			}
        }
		//#Ukraine
		public static bool IsCallsignRussian(string callsign)
		{
			if (callsign == "") return false;

			bool bRet = false;
			string lowerCustomTitle = callsign.ToUpper().Trim();

			// filter out U5 - (^[U][5]{1,2}[A-Z]{1,3})
			Match matchU5 = Regex.Match(lowerCustomTitle, "(^[U][5]{1,2}[A-Z]{1,3})");

			if (!matchU5.Success)
			{
				Match match = Regex.Match(lowerCustomTitle, "(^[R][AC-DF-GJ-OPQRST-Z]{0,1}[0-9]{1,3}[A-Z]{1,3})|(^[U][A-I]{0,1}[0-9]{1,2}[A-Z]{1,3})");
				if (match.Success)
				{
					string matchString = match.ToString();
					if (!(
						matchString.StartsWith("UA2") ||
						matchString.StartsWith("RA2") ||
						matchString.StartsWith("R2") ||
						matchString.StartsWith("RK2") ||
						matchString.StartsWith("RN2") ||
						matchString.StartsWith("RY2")
						)) // best attemt to ignore Kaliningrad, this is not 100%
					{
						bRet = true;
					}
				}
			}

			return bRet;
		}

		public static void DoubleBuffered(Control c, bool bEnabled)
        {
			// MW0LGE_[2.9.0.6]
			// not all controls (such as panels) have double buffered method
			// try to use reflection, so we can keep the base panel
			try
			{
				c.GetType().InvokeMember("DoubleBuffered",
								System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
								null, c, new object[] { bEnabled });
			}
			catch 
			{ 
			}
		}
	}
}