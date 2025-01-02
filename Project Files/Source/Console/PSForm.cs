/*  PSForm.cs

This file is part of a program that implements a Software-Defined Radio.

This code/file can be found on GitHub : https://github.com/ramdor/Thetis

Copyright (C) 2020-2024 Richard Samphire MW0LGE

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

The author can be reached by email at

mw0lge@grange-lane.co.uk
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Thetis
{
    public partial class PSForm : Form
    {
        #region constructor

        private Console console;

        public PSForm(Console c)
        {
            InitializeComponent();
            Common.DoubleBufferAll(this, true);

            txtPSpeak.Text = "";

            console = c;    // MW0LGE moved above restore, so that we actaully have console when control events fire because of restore form
            
            Common.RestoreForm(this, "PureSignal", false); // will also restore txtPSpeak //MW0LGE_21k9rc5

            _advancedON = chkAdvancedViewHidden.Checked; //MW0LGE_[2.9.0.6]

            startPSThread(); // MW0LGE_21k8 removed the winform timers, now using dedicated thread
        }

        #endregion

        #region variables

        private int _gcolor = (0xFF << 24) | (0xFF << 8);
        private static bool _autoON = false;
        private static bool _singlecalON = false;
        private static bool _restoreON = false;
        private static bool _OFF = true;
        //private int oldCalCount = 0;
        //private int red, green, blue;
        private eAAState _autoAttenuateState = eAAState.Monitor;
        private static double _PShwpeak;
        private static double _GetPSpeakval;

        public static AmpView ampv = null;
        public static Thread ampvThread = null;

        //private int oldCalCount2 = 0;
        private int _save_autoON = 0;
        private int _save_singlecalON = 0;
        private int _deltadB = 0;

        private enum eCMDState
        {
            OFF = 0,
            TurnOnAutoCalibrate = 1,
            AutoCalibrate = 2,
            TurnOnSingleCalibrate = 3,
            SingleCalibrate = 4,
            StayON = 5,
            TurnOFF = 6,
            IntiateRestoredCorrection = 7
        }
        private enum eAAState
        {
            Monitor = 0,
            SetNewValues = 1,
            RestoreOperation = 2
        }

        private static eCMDState _cmdstate = eCMDState.OFF;
        private static bool _topmost = false;
        
        private Thread _ps_thread = null;
        #endregion

        #region properties

        private void startPSThread()
        {
            if (_ps_thread == null || !_ps_thread.IsAlive)
            {
                _ps_thread = new Thread(new ThreadStart(PSLoop))
                {
                    Name = "PureSignal Thread",
                    Priority = ThreadPriority.AboveNormal,
                    IsBackground = true
                };
                _ps_thread.Start();
            }
        }

        private bool m_bQuckAttenuate = false;
        public bool QuickAttenuate
        {
            get { return m_bQuckAttenuate; }
            set { m_bQuckAttenuate = value; }
        }

        public void StopPSThread()
        {
            _bPSRunning = false;
            if (_ps_thread != null && _ps_thread.IsAlive) _ps_thread.Join(300);
        }

        private bool _bPSRunning = false;
        private void PSLoop()
        {
            int nCount = 0;

            _bPSRunning = true;
            while (_bPSRunning)
            {
                if (console.PowerOn)
                {
                    timer1code();
                    if (nCount == 0) timer2code();

                    nCount++;
                    if (m_bQuckAttenuate) 
                        nCount = 0;
                    else if(nCount == 10) nCount = 0;

                    Thread.Sleep(10);
                }
                else
                {
                    nCount = 0;
                    Thread.Sleep(100);
                }
            }
        }

        private bool _dismissAmpv = false;
        public bool DismissAmpv
        {
            get { return _dismissAmpv; }
            set
            {
                _dismissAmpv = value;
            }
        }

        private static bool _psenabled = false;
        public bool PSEnabled
        {
            get { return _psenabled; }
            set
            {
                _psenabled = value;

                if (_psenabled)
                {
                    // Set the system to supply feedback.
                    console.UpdateDDCs(console.RX2Enabled);
                    NetworkIO.SetPureSignal(1);
                    NetworkIO.SendHighPriority(1); // send the HP packet
                    //console.UpdateRXADCCtrl();
                    console.UpdateAAudioMixerStates();
                    unsafe { cmaster.LoadRouterControlBit((void*)0, 0, 0, 1); }
                    console.radio.GetDSPTX(0).PSRunCal = true;
                }
                else
                {
                    // Set the system to turn-off feedback.
                    console.UpdateDDCs(console.RX2Enabled);
                    NetworkIO.SetPureSignal(0);
                    NetworkIO.SendHighPriority(1); // send the HP packet
                    //console.UpdateRXADCCtrl();
                    console.UpdateAAudioMixerStates();
                    unsafe { cmaster.LoadRouterControlBit((void*)0, 0, 0, 0); }
                    console.radio.GetDSPTX(0).PSRunCal = false;
                }
                                               
                // console.EnableDup();
                if (console.path_Illustrator != null)
                    console.path_Illustrator.pi_Changed();                
            }
        }

        private static bool _autocal_enabled = false;
        public bool AutoCalEnabled
        {
            get { return _autocal_enabled; }
            set
            {
                _autocal_enabled = value;
                if (_autocal_enabled)
                {
                    _autoON = true;
                    console.PSState = true;
                }
                else
                {
                    _OFF = true;
                    console.PSState = false;
                }
            }
        }

        private static bool _autoattenuate = true;
        public bool AutoAttenuate
        {
            get { return _autoattenuate; }
            set
            {
                _autoattenuate = value;
                if (_autoattenuate)
                {
                    console.ATTOnTX = _autoattenuate;
                }
                else
                {
                    // restore setting direct from setupform
                    if (!console.IsSetupFormNull)
                    {
                        console.ATTOnTX = console.SetupForm.ATTOnTXChecked;
                    }
                    else
                    {
                        console.ATTOnTX = _autoattenuate;
                    }
                }
            }
        }

        private static bool _ttgenON = false;
        public bool TTgenON
        {
            get { return _ttgenON; }
            set
            {
                _ttgenON = value;
                if (_ttgenON)
                    btnPSTwoToneGen.BackColor = Color.FromArgb(_gcolor);
                else
                    btnPSTwoToneGen.BackColor = SystemColors.Control;
            }
        }

        private static int _txachannel = WDSP.id(1, 0);
        public int TXAchannel
        {
            get { return _txachannel; }
            set { _txachannel = value; }
        }

        private readonly Object _objLocker = new Object();

        private static bool _mox = false;
        public bool Mox
        {
            get { return _mox; }
            set
            {
                _mox = value;
                puresignal.SetPSMox(_txachannel, value);
            }
        }

        private int _ints = 16;
        public int Ints
        {
            get { return _ints; }
            set
            {
                _ints = value;
            }
        }

        private int _spi = 256;
        public int Spi
        {
            get { return _spi; }
            set
            {
                _spi = value;
            }
        }

        public void PSdefpeak(double value)
        {
            // note : PSpeak_TextChanged will fire if db recovers value into text box
            string sVal = value.ToString();
            if(txtPSpeak.Text != sVal)
                txtPSpeak.Text = value.ToString(); // causes text change event
            else
                PSpeak_TextChanged(this, EventArgs.Empty); // there would be no event as text the same, so fire it here
        }

        #endregion

        #region event handlers
        private void PSForm_Load(object sender, EventArgs e)
        {
            SetupForm();// e); // all moved into function that can be used outside as we now do not dispose the form each time   //MW0LGE_[2.9.0.7]

            //if (ttgenON == true)
            //    btnPSTwoToneGen.BackColor = Color.FromArgb(gcolor);

            //MW0LGE_21k9d5 (rc3)
            //unsafe
            //{
            //    fixed (double* ptr = &PShwpeak)
            //        puresignal.GetPSHWPeak(txachannel, ptr);
            //}
            //
            //PSpeak.Text = PShwpeak.ToString();


            //btnPSAdvanced_Click(this, e);
        }

        public void SetupForm()//EventArgs e)  //MW0LGE_[2.9.0.7]
        {
            if (_ttgenON == true)
                btnPSTwoToneGen.BackColor = Color.FromArgb(_gcolor);

            unsafe
            {
                fixed (double* ptr = &_PShwpeak)
                    puresignal.GetPSHWPeak(_txachannel, ptr);
            }

            txtPSpeak.Text = _PShwpeak.ToString();

            setAdvancedView();  //MW0LGE_[2.9.0.7]
        }

        private void PSForm_Closing(object sender, FormClosingEventArgs e)
        {
            //[2.10.3.4]]MW0LGE leave it there until thetis closes
            //if (ampv != null)
            //{
            //    _dismissAmpv = true;
            //    ampvThread.Join();
            //    ampv.Close();
            //    ampv = null;
            //}
            //_advancedON = true;//MW0LGE_[2.9.0.7]
            //btnPSAdvanced_Click(this, e); //MW0LGE_[2.9.0.7]
            this.Hide();
            e.Cancel = true;
            Common.SaveForm(this, "PureSignal");
        }
        public void CloseAmpView()
        {
            if (ampv != null)
            {
                _dismissAmpv = true;
                ampvThread.Join();
                ampv.Close();
                ampv = null;
            }
        }
        public void RunAmpv()
        {
            ampv = new AmpView(this);
            ampv.Opacity = 0;
            Application.Run(ampv);            
        }

        private void btnPSAmpView_Click(object sender, EventArgs e)
        {
            if (ampv == null || (ampv != null && ampv.IsDisposed))
            {
                _dismissAmpv = false;
                ampvThread = new Thread(RunAmpv);
                ampvThread.SetApartmentState(ApartmentState.STA);
                ampvThread.Name = "Ampv Thread";
                ampvThread.Start();
            }
        }

        private void btnPSCalibrate_Click(object sender, EventArgs e)
        {
            if (_singlecalON)
            {
                // need this incase single cal is unable to complete do to bad feedback level
                // state machine will drop out if this is the case
                _singlecalON = false;
                return;
            }
            console.ForcePureSignalAutoCalDisable();
            _singlecalON = true;
            console.PSState = false;
        }

        //-W2PA Adds capability for CAT control via console
        public void SingleCalrun()
        {
            btnPSCalibrate_Click(this, EventArgs.Empty); 
        }

        private void btnPSReset_Click(object sender, EventArgs e)
        {
            console.ForcePureSignalAutoCalDisable();
            if (!_OFF) _OFF = true;
            console.PSState = false;
        }

        private void udPSMoxDelay_ValueChanged(object sender, EventArgs e)
        {
            puresignal.SetPSMoxDelay(_txachannel, (double)udPSMoxDelay.Value);
        }

        private void udPSCalWait_ValueChanged(object sender, EventArgs e)
        {
            puresignal.SetPSLoopDelay(_txachannel, (double)udPSCalWait.Value);
        }

        private void udPSPhnum_ValueChanged(object sender, EventArgs e)
        {
            double actual_delay = puresignal.SetPSTXDelay(_txachannel, (double)udPSPhnum.Value * 1.0e-09);
        }

        private void btnPSTwoToneGen_Click(object sender, EventArgs e)
        {
            if (_ttgenON == false)
            {
                btnPSTwoToneGen.BackColor = Color.FromArgb(_gcolor);
                _ttgenON = true;
                console.SetupForm.TTgenrun = true;
            }
            else
            {
                btnPSTwoToneGen.BackColor = SystemColors.Control;
                _ttgenON = false;
                console.SetupForm.TTgenrun = false;
            }
        }

        private void btnPSSave_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(console.AppDataPath + "PureSignal\\");
            SaveFileDialog savefile1 = new SaveFileDialog();
            savefile1.InitialDirectory = console.AppDataPath + "PureSignal\\";
            savefile1.RestoreDirectory = true;
            if (savefile1.ShowDialog() == DialogResult.OK)
                puresignal.PSSaveCorr(_txachannel, savefile1.FileName);
        }

        private void btnPSRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile1 = new OpenFileDialog();
            openfile1.InitialDirectory = console.AppDataPath + "PureSignal\\";
            openfile1.RestoreDirectory = true;
            if (openfile1.ShowDialog() == DialogResult.OK)
            {
                console.ForcePureSignalAutoCalDisable();
                _OFF = false;
                puresignal.PSRestoreCorr(_txachannel, openfile1.FileName);
                _restoreON = true;
            }
        }
        public double GetDefaultPeak()
        {
            if (NetworkIO.CurrentRadioProtocol == RadioProtocol.USB)
            {
                // MI0BOT: HL2 has a different PSdefpeak 
                //protocol 1
                if (console.CurrentHPSDRHardware == HPSDRHW.HermesLite)
                    return 0.233;
                else
                    return 0.4072;
            }
            else
            {
                //protocol 2
                if (console.CurrentHPSDRHardware == HPSDRHW.Saturn)
                    return 0.6121;
                else
                    return 0.2899;
            }
        }
        public void SetDefaultPeaks()
        {
            PSdefpeak(GetDefaultPeak());
        }
        #region PSLoops

        private bool _performing_single_cal = false;
        private int _performing_single_cal_retries = 0;
        private void timer1code()
        {
            if (!_bPSRunning) return;

            puresignal.GetInfo(_txachannel);

            if (puresignal.HasInfoChanged)
            {
                lblPSInfo0.Text = puresignal.Info[0].ToString();
                lblPSInfo1.Text = puresignal.Info[1].ToString();
                lblPSInfo2.Text = puresignal.Info[2].ToString();
                lblPSInfo3.Text = puresignal.Info[3].ToString();
                lblPSfb2.Text = puresignal.Info[4].ToString();
                lblPSInfo5.Text = puresignal.Info[5].ToString();
                lblPSInfo6.Text = puresignal.Info[6].ToString();
                lblPSInfo13.Text = puresignal.Info[13].ToString();
                lblPSInfo15.Text = puresignal.Info[15].ToString();
            }

            if (puresignal.CorrectionsBeingApplied)
            {
                btnPSSave.Enabled = true;
                if (puresignal.Correcting)
                {
                    if (lblPSInfoCO.BackColor != Color.Lime)
                        lblPSInfoCO.BackColor = Color.Lime;
                }
                else
                {
                    if (lblPSInfoCO.BackColor != Color.Yellow)
                        lblPSInfoCO.BackColor = Color.Yellow;
                }
            }
            else
            {
                btnPSSave.Enabled = false;
                if (lblPSInfoCO.BackColor != Color.Black)
                    lblPSInfoCO.BackColor = Color.Black;
            }

            if (puresignal.CalibrationAttemptsChanged)
            {
                if (lblPSInfoFB.BackColor != puresignal.FeedbackColourLevel)
                    lblPSInfoFB.BackColor = puresignal.FeedbackColourLevel;
            }
            else
            {
                if (lblPSInfoFB.BackColor.R > 0 || lblPSInfoFB.BackColor.G > 0 || lblPSInfoFB.BackColor.B > 0) //MW0LGE_21k8
                {
                    //fade away
                    int r = Math.Max(0, lblPSInfoFB.BackColor.R - 5);
                    int g = Math.Max(0, lblPSInfoFB.BackColor.G - 5);
                    int b = Math.Max(0, lblPSInfoFB.BackColor.B - 5);
                    Color c = Color.FromArgb(r, g, b);
                    if (lblPSInfoFB.BackColor != c)
                        lblPSInfoFB.BackColor = c;
                }
            }

            // MW0LGE_21k9
            if (_autocal_enabled)
            {
                if (puresignal.HasInfoChanged)
                    console.InfoBarFeedbackLevel(puresignal.FeedbackLevel, puresignal.IsFeedbackLevelOK, puresignal.CorrectionsBeingApplied, puresignal.CalibrationAttemptsChanged, puresignal.FeedbackColourLevel);
            }
            //
            unsafe
            {
                fixed (double* ptr = &_GetPSpeakval)
                    puresignal.GetPSMaxTX(_txachannel, ptr);
            }
            string s = _GetPSpeakval.ToString();
            if(txtGetPSpeak.Text != s) txtGetPSpeak.Text = s;

            // Command State-Machine
            switch (_cmdstate)
            {
                case eCMDState.OFF://0:     // OFF
                    puresignal.SetPSControl(_txachannel, 1, 0, 0, 0);
                    if (PSEnabled) PSEnabled = false;
                    btnPSCalibrate.BackColor = SystemColors.Control;
                    if (_restoreON)
                        _cmdstate = eCMDState.IntiateRestoredCorrection;// 7;
                    else if (_autoON)
                        _cmdstate = eCMDState.TurnOnAutoCalibrate;// 1;
                    else if (_singlecalON)
                        _cmdstate = eCMDState.TurnOnSingleCalibrate;// 3;
                    _OFF = false;
                    break;
                case eCMDState.TurnOnAutoCalibrate://1:     // Turn-ON Auto-Calibrate Mode
                    puresignal.SetPSControl(_txachannel, 1, 0, 1, 0);
                    if (!PSEnabled) PSEnabled = true;
                    btnPSCalibrate.BackColor = SystemColors.Control;
                    _cmdstate = eCMDState.AutoCalibrate;// 2;
                    break;
                case eCMDState.AutoCalibrate://2:     // Auto-Calibrate Mode
                    if (_OFF)
                        _cmdstate = eCMDState.TurnOFF;// 6;
                    else if (_restoreON)
                        _cmdstate = eCMDState.IntiateRestoredCorrection;// 7;
                    else if (_singlecalON)
                        _cmdstate = eCMDState.TurnOnSingleCalibrate;// 3;
                    break;
                case eCMDState.TurnOnSingleCalibrate://3:     // Turn-ON Single-Calibrate Mode
                    _autoON = false;
                    _performing_single_cal = true;
                    puresignal.SetPSControl(_txachannel, 1, 1, 0, 0);
                    if (!PSEnabled) PSEnabled = true;
                    btnPSCalibrate.BackColor = Color.FromArgb(_gcolor);
                    _cmdstate = eCMDState.SingleCalibrate;// 4;
                    break;
                case eCMDState.SingleCalibrate://4:     // Single-Calibrate Mode
                    _singlecalON = false;
                    if (_OFF)
                        _cmdstate = eCMDState.TurnOFF;// 6;
                    else if (_restoreON)
                        _cmdstate = eCMDState.IntiateRestoredCorrection;// 7;
                    else if (_autoON)
                        _cmdstate = eCMDState.TurnOnAutoCalibrate;// 1;
                    else if (puresignal.CorrectionsBeingApplied)
                        _cmdstate = eCMDState.StayON;// 5;
                    break;
                case eCMDState.StayON://5:     // Stay-ON
                    if (PSEnabled) PSEnabled = false;
                    btnPSCalibrate.BackColor = SystemColors.Control;
                    if (_OFF)
                        _cmdstate = eCMDState.TurnOFF;// 6;
                    else if (_restoreON)
                        _cmdstate = eCMDState.IntiateRestoredCorrection;// 7;
                    else if (_autoON)
                        _cmdstate = eCMDState.TurnOnAutoCalibrate;// 1;
                    else if (_singlecalON)
                        _cmdstate = eCMDState.TurnOnSingleCalibrate;// 3;
                    else if (_performing_single_cal)
                    {
                        // fix for when we were performing a single cal, but needed to change attenuation
                        _performing_single_cal = false;
                        if (!puresignal.IsFeedbackLevelOKRange && _performing_single_cal_retries < 5)
                        {
                            _performing_single_cal_retries++;
                            _singlecalON = true;
                        }
                        else
                            _performing_single_cal_retries = 0;
                    }
                    break;
                case eCMDState.TurnOFF://6:     // Turn-OFF
                    //_autoON = false;
                    if(!_autocal_enabled) _autoON = false; // only want to turn this off if autocal is off MW0LGE_21k9rc4
                    puresignal.SetPSControl(_txachannel, 1, 0, 0, 0);
                    if (!PSEnabled) PSEnabled = true;
                    btnPSCalibrate.BackColor = SystemColors.Control;
                    _OFF = false;
                    if (_restoreON)
                        _cmdstate = eCMDState.IntiateRestoredCorrection;// 7;
                    else if (_autoON)
                        _cmdstate = eCMDState.TurnOnAutoCalibrate;// 1;
                    else if (_singlecalON)
                        _cmdstate = eCMDState.TurnOnSingleCalibrate;// 3;
                    else if (!puresignal.CorrectionsBeingApplied && puresignal.State == puresignal.EngineState.LRESET)
                        _cmdstate = eCMDState.OFF;// 0;
                    break;
                case eCMDState.IntiateRestoredCorrection://7:     // Initiate Restored Correction
                    _autoON = false;
                    puresignal.SetPSControl(_txachannel, 0, 0, 0, 1);
                    if (!PSEnabled) PSEnabled = true;
                    btnPSCalibrate.BackColor = SystemColors.Control;
                    _restoreON = false;
                    if (puresignal.State == puresignal.EngineState.LSTAYON)
                        _cmdstate = eCMDState.StayON;//5;
                    break;
            }
        }
        private void timer2code()
        {
            if (!_bPSRunning) return;

            switch (_autoAttenuateState)
            {
                case eAAState.Monitor:// 0: // monitor
                    if (_autoattenuate &&
                        puresignal.CalibrationAttemptsChanged &&
                        ((HPSDRModel.HERMESLITE != console.CurrentHPSDRModel && puresignal.NeedToRecalibrate(console.SetupForm.ATTOnTX)) ||
                        (HPSDRModel.HERMESLITE == console.CurrentHPSDRModel && puresignal.NeedToRecalibrate_HL2(console.SetupForm.ATTOnTX))))
                    {
                        if (!console.ATTOnTX) AutoAttenuate = true; //MW0LGE

                        _autoAttenuateState = eAAState.SetNewValues;//1;

                        double ddB;
                        if (puresignal.IsFeedbackLevelOK)
                        {
                            ddB = 20.0 * Math.Log10((double)puresignal.FeedbackLevel / 152.293);


                            if (HPSDRModel.HERMESLITE != console.CurrentHPSDRModel)
                            {
                                if (Double.IsNaN(ddB)) ddB = 31.1;
                                if (ddB < -100.0) ddB = -100.0;
                                if (ddB > +100.0) ddB = +100.0;
                            }
                            else
                            {
                                if (Double.IsNaN(ddB)) ddB = 10.0;  // MI0BOT: Handle the Not A Number situation
                                if (ddB < -100.0) ddB = -10.0;      // MI0BOT: Handle - infinity 
                                if (ddB > +100.0) ddB = 10.0;       // MI0BOT: Handle + infinity 
                            }
                        }
                        else
                        {
                            if (HPSDRModel.HERMESLITE == console.CurrentHPSDRModel)
                                ddB = 10.0;
                            else
                                ddB = 31.1;
                        }

                        _deltadB = Convert.ToInt32(ddB);

                        _save_autoON = (_cmdstate == eCMDState.AutoCalibrate) ? 1 : 0; // (2)
                        _save_singlecalON = (_cmdstate == eCMDState.SingleCalibrate) ? 1 : 0; // (4)

                        // everything off and reset
                        puresignal.SetPSControl(_txachannel, 1, 0, 0, 0);
                    }
                    break;
                case eAAState.SetNewValues:// 1: // set new values
                    _autoAttenuateState = eAAState.RestoreOperation;//2;
                    int newAtten;
                    int oldAtten = console.SetupForm.ATTOnTX;

                    if (HPSDRModel.HERMESLITE == console.CurrentHPSDRModel)
                    {
                        newAtten = oldAtten + _deltadB;     //MI0BOT: HL2 can handle negative up to -28, just let it be handled in ATTOnTx section
                    }
                    else
                    {
                        if ((oldAtten + _deltadB) > 0)
                            newAtten = oldAtten + _deltadB;
                        else
                            newAtten = 0;
                    }

                    if (console.SetupForm.ATTOnTX != newAtten)
                    {
                        console.SetupForm.ATTOnTX = newAtten;

                        // give some additional time for the network msg to get to the radio before switching back on MW0LGE_21k9d5
                        if (m_bQuckAttenuate) Thread.Sleep(100);
                    }
                    break;
                case eAAState.RestoreOperation:// 2: // restore operation
                    _autoAttenuateState = eAAState.Monitor;//0;
                    puresignal.SetPSControl(_txachannel, 0, _save_singlecalON, _save_autoON, 0);
                    break;
            }
        }
        #endregion

        private void PSpeak_TextChanged(object sender, EventArgs e)
        {
            bool bOk = double.TryParse(txtPSpeak.Text, out double tmp);

            if (bOk)
            {
                _PShwpeak = tmp;
                puresignal.SetPSHWPeak(_txachannel, _PShwpeak);

                double set_pk = GetDefaultPeak();
                pbWarningSetPk.Visible = _PShwpeak != set_pk; //[2.10.3.7]MW0LGE show a warning if the setpk is different to what we expect for this hardware
            }                       
        }

        private void chkPSRelaxPtol_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPSRelaxPtol.Checked)
                puresignal.SetPSPtol(_txachannel, 0.400);
            else
                puresignal.SetPSPtol(_txachannel, 0.800);
        }

        private void chkPSAutoAttenuate_CheckedChanged(object sender, EventArgs e)
        {
            AutoAttenuate = chkPSAutoAttenuate.Checked; //MW0LGE use property
        }

        private void checkLoopback_CheckedChanged(object sender, EventArgs e)
        {
            if(checkLoopback.Checked && (console.SampleRateRX1 != 192000 || console.SampleRateRX2 != 192000))
            {
                DialogResult dr = MessageBox.Show("This feature can only be used with sample rates set to 192KHz.",
                    "Sample Rate Issue",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, Common.MB_TOPMOST);

                checkLoopback.Checked = false;
                return;
            }
            cmaster.PSLoopback = checkLoopback.Checked;
        }

        private void chkPSPin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPSPin.Checked)
                puresignal.SetPSPinMode(_txachannel, 1);
            else
                puresignal.SetPSPinMode(_txachannel, 0);
        }

        private void chkPSMap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPSMap.Checked)
                puresignal.SetPSMapMode(_txachannel, 1);
            else
                puresignal.SetPSMapMode(_txachannel, 0);
        }

        private void chkPSStbl_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPSStbl.Checked)
                puresignal.SetPSStabilize(_txachannel, 1);
            else
                puresignal.SetPSStabilize(_txachannel, 0);
        }

        private void comboPSTint_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboPSTint.SelectedIndex)
            {
                case 0:
                    puresignal.SetPSIntsAndSpi(_txachannel, 16, 256);
                    _ints = 16;
                    _spi = 256;
                    btnPSSave.Enabled = btnPSRestore.Enabled = true;
                    break;
                case 1:
                    puresignal.SetPSIntsAndSpi(_txachannel, 8, 512);
                    _ints = 8;
                    _spi = 512;
                    btnPSSave.Enabled = btnPSRestore.Enabled = false;
                    break;
                case 2:
                    puresignal.SetPSIntsAndSpi(_txachannel, 4, 1024);
                    _ints = 4;
                    _spi = 1024;
                    btnPSSave.Enabled = btnPSRestore.Enabled = false;
                    break;
                default:
                    puresignal.SetPSIntsAndSpi(_txachannel, 16, 256);
                    _ints = 16;
                    _spi = 256;
                    btnPSSave.Enabled = btnPSRestore.Enabled = true;
                    break;
            }
        }

        private bool _advancedON = false; //MW0LGE_[2.9.0.7]
        private void btnPSAdvanced_Click(object sender, EventArgs e)
        {
            _advancedON = !_advancedON;
            setAdvancedView();
        }
        private void setAdvancedView()
        {
            if (_advancedON)
                console.psform.ClientSize = new System.Drawing.Size(560, 60);
            else
                console.psform.ClientSize = new System.Drawing.Size(560, 300);

            chkAdvancedViewHidden.Checked = _advancedON;
        }
        private void chkPSOnTop_CheckedChanged(object sender, EventArgs e)
        {
            _topmost = chkPSOnTop.Checked;

            this.TopMost = _topmost; //MW0LGE
        }
        public void ShowAtStartup_LinearityForm()
        {
            this.Opacity = 0f;
            this.SetupForm();
            this.Show();
            Common.FadeIn(this);
        }
        public void ShowAtStartup_AmpViewForm()
        {
            btnPSAmpView_Click(this, EventArgs.Empty);
        }
        #endregion

        #region methods

        public void ForcePS()
        {
            EventArgs e = EventArgs.Empty;
            if (!_autoON)
            {
                puresignal.SetPSControl(_txachannel, 1, 0, 0, 0);
            }
            else
            {
                puresignal.SetPSControl(_txachannel, 0, 0, 1, 0);
            }
            if (!_ttgenON)
                WDSP.SetTXAPostGenRun(_txachannel, 0);
            else
            {
                WDSP.SetTXAPostGenMode(_txachannel, 1);
                WDSP.SetTXAPostGenRun(_txachannel, 1);
            }
            udPSCalWait_ValueChanged(this, e);
            udPSPhnum_ValueChanged(this, e);
            udPSMoxDelay_ValueChanged(this, e);
            chkPSRelaxPtol_CheckedChanged(this, e);
            chkPSAutoAttenuate_CheckedChanged(this, e);
            chkPSPin_CheckedChanged(this, e);
            chkPSMap_CheckedChanged(this, e);
            chkPSStbl_CheckedChanged(this, e);
            comboPSTint_SelectedIndexChanged(this, e);
            chkPSOnTop_CheckedChanged(this, e);
            chkQuickAttenuate_CheckedChanged(this, e);
        }

        #endregion

        private void chkQuickAttenuate_CheckedChanged(object sender, EventArgs e)
        {
            QuickAttenuate = chkQuickAttenuate.Checked;
        }

        private void btnDefaultPeaks_Click(object sender, EventArgs e)
        {
            SetDefaultPeaks();
        }
    }

    unsafe static class puresignal
    {
        #region DllImport - Main

        [DllImport("wdsp.dll", EntryPoint = "SetPSRunCal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSRunCal(int channel, bool run);

        [DllImport("wdsp.dll", EntryPoint = "SetPSMox", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSMox(int channel, bool mox);

        [DllImport("wdsp.dll", EntryPoint = "GetPSInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetPSInfo(int channel, int* info);

        [DllImport("wdsp.dll", EntryPoint = "SetPSReset", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSReset(int channel, int reset);

        [DllImport("wdsp.dll", EntryPoint = "SetPSMancal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSMancal(int channel, int mancal);

        [DllImport("wdsp.dll", EntryPoint = "SetPSAutomode", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSAutomode(int channel, int automode);

        [DllImport("wdsp.dll", EntryPoint = "SetPSTurnon", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSTurnon(int channel, int turnon);

        [DllImport("wdsp.dll", EntryPoint = "SetPSControl", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSControl(int channel, int reset, int mancal, int automode, int turnon);

        [DllImport("wdsp.dll", EntryPoint = "SetPSLoopDelay", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSLoopDelay(int channel, double delay);

        [DllImport("wdsp.dll", EntryPoint = "SetPSMoxDelay", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSMoxDelay(int channel, double delay);

        [DllImport("wdsp.dll", EntryPoint = "SetPSTXDelay", CallingConvention = CallingConvention.Cdecl)]
        public static extern double SetPSTXDelay(int channel, double delay);

        [DllImport("wdsp.dll", EntryPoint = "psccF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void psccF(int channel, int size, float* Itxbuff, float* Qtxbuff, float* Irxbuff, float* Qrxbuff, bool mox, bool solidmox);

        [DllImport("wdsp.dll", EntryPoint = "PSSaveCorr", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PSSaveCorr(int channel, string filename);

        [DllImport("wdsp.dll", EntryPoint = "PSRestoreCorr", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PSRestoreCorr(int channel, string filename);

        [DllImport("wdsp.dll", EntryPoint = "SetPSHWPeak", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSHWPeak(int channel, double peak);

        [DllImport("wdsp.dll", EntryPoint = "GetPSHWPeak", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetPSHWPeak(int channel, double* peak);

        [DllImport("wdsp.dll", EntryPoint = "GetPSMaxTX", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetPSMaxTX(int channel, double* maxtx);

        [DllImport("wdsp.dll", EntryPoint = "SetPSPtol", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSPtol(int channel, double ptol);

        [DllImport("wdsp.dll", EntryPoint = "GetPSDisp", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetPSDisp(int channel, IntPtr x, IntPtr ym, IntPtr yc, IntPtr ys, IntPtr cm, IntPtr cc, IntPtr cs);

        [DllImport("wdsp.dll", EntryPoint = "SetPSFeedbackRate", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSFeedbackRate(int channel, int rate);

        [DllImport("wdsp.dll", EntryPoint = "SetPSPinMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSPinMode(int channel, int pin);

        [DllImport("wdsp.dll", EntryPoint = "SetPSMapMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSMapMode(int channel, int map);

        [DllImport("wdsp.dll", EntryPoint = "SetPSStabilize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSStabilize(int channel, int stbl);

        [DllImport("wdsp.dll", EntryPoint = "SetPSIntsAndSpi", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSIntsAndSpi(int channel, int ints, int spi);

        #endregion

        #region public methods
        public static int[] Info = new int[16];
        private static int[] oldInfo = new int[16];
        private static bool _bInvertRedBlue = false;
        private static bool _validGetInfo = false;
        static puresignal()
        {
            for(int i = 0; i < 16; i++)
            {
                Info[i] = 0;
                oldInfo[i] = Info[i];
            }
        }
        public static void GetInfo(int txachannel)
        {
            //make copy of old, used in HasInfoChanged & CalibrationAttemptsChanged MW0LGE
            fixed (void* dest = &oldInfo[0])
            fixed (void* src = &Info[0])
                Win32.memcpy(dest, src, 16 * sizeof(int));

            fixed (int* ptr = &(Info[0]))
                GetPSInfo(txachannel, ptr);

            _validGetInfo = true;
        }       
        public static bool HasInfoChanged 
        {
            get {
                for (int n = 0; n < 16; n++)
                {
                    if (Info[n] != oldInfo[n])
                        return true;
                }
                return false;
            }
        }
        public static bool CalibrationAttemptsChanged {
            get { return Info[5] != oldInfo[5]; }
        }
        public static bool CorrectionsBeingApplied {
            get { return Info[14] == 1; }
        }
        public static int CalibrationCount {
            get { return Info[5]; }
        }
        public static bool Correcting {
            get { return FeedbackLevel > 90; }
        }
        public static bool NeedToRecalibrate(int nCurrentATTonTX) {
            //note: for reference (puresignal.Info[4] > 181 || (puresignal.Info[4] <= 128 && console.SetupForm.ATTOnTX > 0))
             return (FeedbackLevel > 181 || (FeedbackLevel <= 128 && nCurrentATTonTX > 0));            
        }
        
        public static bool NeedToRecalibrate_HL2(int nCurrentATTonTX) {
            //note: for reference (puresignal.Info[4] > 181 || (puresignal.Info[4] <= 128 && console.SetupForm.ATTOnTX > 0))
            return (FeedbackLevel > 181 || (FeedbackLevel <= 128 && nCurrentATTonTX > -28));    // MI0BOT: Needed seperate function for HL2 as           
        }                                                                                       //         great range in attenuation           
        public static bool IsFeedbackLevelOK {
            get { return FeedbackLevel <= 256; }
        }
        public static bool IsFeedbackLevelOKRange
        {
            get { return FeedbackLevel > 128 && FeedbackLevel <= 181; }
        }
        public static int FeedbackLevel {
            get { return Info[4]; }
        }
        public static Color FeedbackColourLevel {
            get {
                if (FeedbackLevel > 181)
                {
                    if (_bInvertRedBlue) return Color.Red;
                    return Color.DodgerBlue;
                }
                else if (FeedbackLevel > 128) return Color.Lime;
                else if (FeedbackLevel > 90) return Color.Yellow;
                else
                {
                    if (_bInvertRedBlue) return Color.DodgerBlue;
                    return Color.Red;
                }
            }
        }
        // info[15] is engine state (from calcc.c)
        public enum EngineState
        {
            LRESET = 0,
            LWAIT,
            LMOXDELAY,
            LSETUP,
            LCOLLECT,
            MOXCHECK,
            LCALC,
            LDELAY,
            LSTAYON,
            LTURNON
        };
        public static EngineState State {
            get { return (EngineState)Info[15]; }
        }
        public static bool InvertRedBlue
        {
            get { return _bInvertRedBlue; }
            set { _bInvertRedBlue = value; }
        }
        //--
        #endregion
    }
}
