namespace Thetis
{
    using System.Windows.Forms;

    partial class Console
    {
        #region Windows Form Generated Code

        private System.Windows.Forms.ButtonTS btnHidden;
        public System.Windows.Forms.TextBoxTS txtVFOAFreq;
        private System.Windows.Forms.TextBoxTS txtVFOABand;
        private System.Windows.Forms.TextBoxTS txtVFOBFreq;
        public System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.GroupBoxTS grpVFOA;
        private System.Windows.Forms.GroupBoxTS grpVFOB;
        private System.Windows.Forms.TextBoxTS txtVFOBBand;
        private System.Windows.Forms.CheckBoxTS chkPower;
        private System.Windows.Forms.ComboBoxTS comboDisplayMode;
        private System.Windows.Forms.NumericUpDownTS udFilterLow;
        private System.Windows.Forms.NumericUpDownTS udFilterHigh;
        private System.Windows.Forms.RadioButtonTS radFilterVar1;
        private System.Windows.Forms.RadioButtonTS radFilterVar2;
        private System.Windows.Forms.RadioButtonTS radModeSPEC;
        private System.Windows.Forms.RadioButtonTS radModeLSB;
        private System.Windows.Forms.RadioButtonTS radModeDIGL;
        private System.Windows.Forms.RadioButtonTS radModeCWU;
        private System.Windows.Forms.RadioButtonTS radModeDSB;
        private System.Windows.Forms.RadioButtonTS radModeSAM;
        private System.Windows.Forms.RadioButtonTS radModeAM;
        private System.Windows.Forms.RadioButtonTS radModeCWL;
        private System.Windows.Forms.RadioButtonTS radModeUSB;
        private System.Windows.Forms.RadioButtonTS radModeFMN;
        private System.Windows.Forms.RadioButtonTS radModeDRM;
        private System.Windows.Forms.LabelTS lblAGC;
        private System.Windows.Forms.ComboBoxTS comboAGC;
        private System.Windows.Forms.CheckBoxTS chkNB;
        private System.Windows.Forms.CheckBoxTS chkANF;
        private System.Windows.Forms.CheckBoxTS chkNR;
        private System.Windows.Forms.CheckBoxTS chkMON;
        private System.Windows.Forms.CheckBoxTS chkTUN;
        private System.Windows.Forms.CheckBoxTS chkMOX;
        private System.Windows.Forms.NumericUpDownTS udXIT;
        private System.Windows.Forms.NumericUpDownTS udRIT;
        private System.Windows.Forms.CheckBoxTS chkXIT;
        private System.Windows.Forms.CheckBoxTS chkRIT;
        private System.Windows.Forms.LabelTS lblPWR;
        private System.Windows.Forms.LabelTS lblAF;
        private System.Windows.Forms.LabelTS lblMIC;
        private System.Windows.Forms.TextBoxTS txtWheelTune;
        private System.Windows.Forms.CheckBoxTS chkBIN;
        private System.Windows.Forms.GroupBoxTS grpMultimeter;
        private System.Windows.Forms.ButtonTS btnVFOSwap;
        private System.Windows.Forms.ButtonTS btnVFOBtoA;
        private System.Windows.Forms.ButtonTS btnVFOAtoB;
        public System.Windows.Forms.CheckBoxTS chkVFOSplit;
        private System.Windows.Forms.CheckBoxTS chkDisplayAVG;
        private System.Windows.Forms.TextBoxTS txtMultiText;
        private System.Windows.Forms.Timer timer_cpu_volts_meter;
        private System.Windows.Forms.LabelTS lblFilterHigh;
        private System.Windows.Forms.LabelTS lblFilterLow;
        private System.Windows.Forms.PictureBox picMultiMeterDigital;
        private System.Windows.Forms.CheckBoxTS chkSquelch;
        private System.Windows.Forms.Timer timer_peak_text;
        private System.Windows.Forms.TextBoxTS txtMemoryQuick;
        private System.Windows.Forms.ButtonTS btnMemoryQuickSave;
        private System.Windows.Forms.ButtonTS btnMemoryQuickRestore;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LabelTS lblFilterShift;
        private System.Windows.Forms.ButtonTS btnFilterShiftReset;
        private System.Windows.Forms.Timer timer_clock;
        private System.Windows.Forms.Panel panelVFOAHover;
        private System.Windows.Forms.Panel panelVFOBHover;
        private System.Windows.Forms.ComboBoxTS comboMeterRXMode;
        private System.Windows.Forms.ComboBoxTS comboMeterTXMode;
        private System.Windows.Forms.ButtonTS btnXITReset;
        private System.Windows.Forms.ButtonTS btnRITReset;
        private System.Windows.Forms.ComboBoxTS comboTuneMode;
        private System.Windows.Forms.ComboBoxTS comboPreamp;
        private System.Windows.Forms.LabelTS lblPreamp;
        private System.Windows.Forms.CheckBoxTS chkDSPNB2;
        private System.Windows.Forms.CheckBoxTS chkVFOLock;
        private System.Windows.Forms.LabelTS lblFilterWidth;
        private System.Windows.Forms.ButtonTS btnBandHF;
        private System.Windows.Forms.ButtonTS btnBandVHF;
        private System.Windows.Forms.ButtonTS btnIFtoVFO;
        private System.Windows.Forms.ButtonTS btnZeroBeat;
        private System.Windows.Forms.RadioButtonTS radModeDIGU;
        private System.Windows.Forms.RadioButtonTS radFilter1;
        private System.Windows.Forms.RadioButtonTS radFilter2;
        private System.Windows.Forms.RadioButtonTS radFilter3;
        private System.Windows.Forms.RadioButtonTS radFilter4;
        private System.Windows.Forms.RadioButtonTS radFilter5;
        private System.Windows.Forms.RadioButtonTS radFilter6;
        private System.Windows.Forms.RadioButtonTS radFilter7;
        private System.Windows.Forms.RadioButtonTS radFilter8;
        private System.Windows.Forms.RadioButtonTS radFilter9;
        private System.Windows.Forms.RadioButtonTS radFilter10;
        private System.Windows.Forms.LabelTS lblRF;
        private System.Windows.Forms.LabelTS lblTuneStep;
        private System.Windows.Forms.GroupBoxTS grpVFOBetween;
        private System.Windows.Forms.CheckBoxTS chkVOX;
        private System.Windows.Forms.LabelTS lblTXGain;
        private System.Windows.Forms.LabelTS lblRXGain;
        private System.Windows.Forms.PictureBox picVOX;
        private System.Windows.Forms.CheckBoxTS chkNoiseGate;
        private System.Windows.Forms.PictureBox picNoiseGate;
        private System.Windows.Forms.LabelTS lblVFOBLSD;
        private System.Windows.Forms.TextBoxTS txtVFOAMSD;
        private System.Windows.Forms.TextBoxTS txtVFOBMSD;
        private System.Windows.Forms.TextBoxTS txtVFOALSD;
        private System.Windows.Forms.TextBoxTS txtVFOBLSD;
        public CheckBoxTS chk2TONE;
        private System.Windows.Forms.ButtonTS btnTuneStepChangeSmaller;
        private System.Windows.Forms.ComboBoxTS comboTXProfile;
        private System.Windows.Forms.CheckBoxTS chkShowTXFilter;
        private System.Windows.Forms.ComboBoxTS comboVACSampleRate;
        private System.Windows.Forms.GroupBoxTS grpDIGSampleRate;
        private System.Windows.Forms.GroupBoxTS grpVACStereo;
        private System.Windows.Forms.CheckBoxTS chkVACStereo;
        private System.Windows.Forms.CheckBoxTS chkCWIambic;
        private System.Windows.Forms.LabelTS lblCWPitchFreq;
        public System.Windows.Forms.NumericUpDownTS udCWPitch;
        private System.Windows.Forms.LabelTS lblDisplayPan;
        private System.Windows.Forms.ButtonTS btnDisplayPanCenter;
        private System.Windows.Forms.LabelTS lblDisplayZoom;
        private System.Windows.Forms.LabelTS lblTransmitProfile;
        private System.Windows.Forms.CheckBoxTS chkX2TR;
        private System.Windows.Forms.CheckBoxTS chkShowTXCWFreq;
        private System.Windows.Forms.CheckBoxTS chkPanSwap;
        private System.Windows.Forms.GroupBoxTS grpSemiBreakIn;
        private System.Windows.Forms.LabelTS lblCWBreakInDelay;
        private System.Windows.Forms.NumericUpDownTS udCWBreakInDelay;
        private System.Windows.Forms.CheckBoxTS chkVAC1;
        private System.Windows.Forms.ComboBoxTS comboDigTXProfile;
        private System.Windows.Forms.LabelTS lblDigTXProfile;
        private System.Windows.Forms.CheckBoxTS chkRXEQ;
        private System.Windows.Forms.CheckBoxTS chkTXEQ;
        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.CheckBoxTS chkEnableMultiRX;
        private System.Windows.Forms.ButtonTS btnTuneStepChangeLarger;
        private System.Windows.Forms.CheckBoxTS chkSplitDisplay;
        private System.Windows.Forms.ComboBoxTS comboDisplayModeTop;
        private System.Windows.Forms.ComboBoxTS comboDisplayModeBottom;
        private System.Windows.Forms.LabelTS lblDisplayModeTop;
        private System.Windows.Forms.LabelTS lblDisplayModeBottom;
        private System.Windows.Forms.CheckBoxTS chkCPDR;
        private System.Windows.Forms.CheckBoxTS chkDX;
        private System.Windows.Forms.CheckBoxTS ckQuickPlay;
        private System.Windows.Forms.CheckBoxTS ckQuickRec;
        private System.Windows.Forms.GroupBoxTS grpDisplaySplit;
        private System.Windows.Forms.CheckBoxTS chkDisplayPeak;
        private System.Windows.Forms.CheckBoxTS chkRX2;
        private System.Windows.Forms.CheckBoxTS chkRX2SR;
        private System.Windows.Forms.Panel panelVFOASubHover;
        private System.Windows.Forms.RadioButtonTS radRX2ModeAM;
        private System.Windows.Forms.RadioButtonTS radRX2ModeSAM;
        private System.Windows.Forms.RadioButtonTS radRX2ModeDSB;
        private System.Windows.Forms.RadioButtonTS radRX2ModeCWU;
        private System.Windows.Forms.RadioButtonTS radRX2ModeDIGU;
        private System.Windows.Forms.RadioButtonTS radRX2ModeDIGL;
        private System.Windows.Forms.RadioButtonTS radRX2ModeLSB;
        private System.Windows.Forms.RadioButtonTS radRX2ModeSPEC;
        private System.Windows.Forms.RadioButtonTS radRX2ModeDRM;
        private System.Windows.Forms.RadioButtonTS radRX2ModeFMN;
        private System.Windows.Forms.RadioButtonTS radRX2ModeUSB;
        private System.Windows.Forms.RadioButtonTS radRX2ModeCWL;
        private System.Windows.Forms.CheckBoxTS chkRX2BIN;
        private System.Windows.Forms.RadioButtonTS radRX2Filter1;
        private System.Windows.Forms.RadioButtonTS radRX2Filter2;
        private System.Windows.Forms.RadioButtonTS radRX2Filter3;
        private System.Windows.Forms.RadioButtonTS radRX2Filter4;
        private System.Windows.Forms.RadioButtonTS radRX2Filter5;
        private System.Windows.Forms.RadioButtonTS radRX2Filter6;
        private System.Windows.Forms.RadioButtonTS radRX2Filter7;
        private System.Windows.Forms.RadioButtonTS radRX2FilterVar1;
        private System.Windows.Forms.RadioButtonTS radRX2FilterVar2;
        private System.Windows.Forms.GroupBoxTS grpRX2Meter;
        private System.Windows.Forms.ComboBoxTS comboRX2MeterMode;
        private System.Windows.Forms.NumericUpDownTS udRX2FilterLow;
        private System.Windows.Forms.NumericUpDownTS udRX2FilterHigh;
        private System.Windows.Forms.LabelTS lblRX2FilterLow;
        private System.Windows.Forms.LabelTS lblRX2FilterHigh;
        private System.Windows.Forms.CheckBoxTS chkRX2NB2;
        private System.Windows.Forms.CheckBoxTS chkRX2NB;
        private System.Windows.Forms.CheckBoxTS chkRX2ANF;
        private System.Windows.Forms.CheckBoxTS chkRX2NR;
        private System.Windows.Forms.PictureBox picRX2Meter;
        private System.Windows.Forms.TextBoxTS txtRX2Meter;
        public CheckBoxTS chkRX2Preamp;
        private System.Windows.Forms.LabelTS lblRX2RF;
        private System.Windows.Forms.PictureBox picSquelch;
        private System.Windows.Forms.CheckBoxTS chkRX2Squelch;
        private System.Windows.Forms.CheckBoxTS chkRX1Preamp;
        private System.Windows.Forms.CheckBoxTS chkRX2DisplayPeak;
        private System.Windows.Forms.ComboBoxTS comboRX2DisplayMode;
        private System.Windows.Forms.CheckBoxTS chkRX2DisplayAVG;
        private System.Windows.Forms.Label lblRX2Pan;
        private System.Windows.Forms.Label lblRX2Vol;
        private System.Windows.Forms.ComboBoxTS comboRX2Band;
        private System.Windows.Forms.LabelTS lblRX2Band;
        private System.Windows.Forms.ComboBoxTS comboRX2AGC;
        private System.Windows.Forms.LabelTS lblRX2AGC;
        private System.Windows.Forms.CheckBoxTS chkVFOSync;
        private System.Windows.Forms.CheckBoxTS chkVFOATX;
        private System.Windows.Forms.CheckBoxTS chkVFOBTX;
        private PanelTS panelBandHF;
        private PanelTS panelBandVHF;
        private PanelTS panelMode;
        private PanelTS panelFilter;
        private PanelTS panelDisplay;
        private PanelTS panelOptions;
        private PanelTS panelSoundControls;
        private PanelTS panelVFO;
        private PanelTS panelDSP;
        private PanelTS panelDisplay2;
        private PanelTS panelMultiRX;
        private PanelTS panelModeSpecificCW;
        private PanelTS panelModeSpecificPhone;
        private PanelTS panelModeSpecificDigital;
        private RadioButtonTS radBand160;
        private RadioButtonTS radBand80;
        private RadioButtonTS radBand60;
        private RadioButtonTS radBand40;
        private RadioButtonTS radBand30;
        private RadioButtonTS radBand20;
        private RadioButtonTS radBand17;
        private RadioButtonTS radBand15;
        private RadioButtonTS radBand12;
        private RadioButtonTS radBand10;
        private RadioButtonTS radBand6;
        private RadioButtonTS radBand2;
        private RadioButtonTS radBandWWV;
        private RadioButtonTS radBandGEN;
        private RadioButtonTS radBandVHF0;
        private RadioButtonTS radBandVHF11;
        private RadioButtonTS radBandVHF10;
        private RadioButtonTS radBandVHF9;
        private RadioButtonTS radBandVHF8;
        private RadioButtonTS radBandVHF7;
        private RadioButtonTS radBandVHF6;
        private RadioButtonTS radBandVHF5;
        private RadioButtonTS radBandVHF4;
        private RadioButtonTS radBandVHF3;
        private RadioButtonTS radBandVHF2;
        private RadioButtonTS radBandVHF1;
        private RadioButtonTS radBandVHF13;
        private RadioButtonTS radBandVHF12;
        private PanelTS panelRX2Mixer;
        private PanelTS panelRX2DSP;
        private PanelTS panelRX2Display;
        private PanelTS panelRX2Mode;
        private PanelTS panelRX2Filter;
        private PrettyTrackBar ptbDisplayPan;
        private PrettyTrackBar ptbDisplayZoom;
        private PrettyTrackBar ptbAF;
        private PrettyTrackBar ptbRF;
        private PrettyTrackBar ptbPWR;
        private PrettyTrackBar ptbSquelch;
        private PrettyTrackBar ptbMic;
        private LabelTS lblMicVal;
        private PrettyTrackBar ptbCPDR;
        private LabelTS lblCPDRVal;
        private PrettyTrackBar ptbVOX;
        private LabelTS lblVOXVal;
        private PrettyTrackBar ptbNoiseGate;
        private LabelTS lblNoiseGateVal;
        private PrettyTrackBar ptbFilterWidth;
        private PrettyTrackBar ptbFilterShift;
        private PrettyTrackBar ptbCWSpeed;
        private PrettyTrackBar ptbPanMainRX;
        private PrettyTrackBar ptbPanSubRX;
        private PrettyTrackBar ptbRX2RF;
        private PrettyTrackBar ptbRX2Squelch;
        private PrettyTrackBar ptbRX2Gain;
        private PrettyTrackBar ptbRX2Pan;
        private PrettyTrackBar ptbRX1Gain;
        private PrettyTrackBar ptbRX0Gain;
        private PrettyTrackBar ptbVACRXGain;
        private PrettyTrackBar ptbVACTXGain;
        private ContextMenuStrip contextMenuStripFilterRX1;
        private ToolStripMenuItem toolStripMenuItemRX1FilterConfigure;
        private ToolStripMenuItem toolStripMenuItemRX1FilterReset;
        private ContextMenuStrip contextMenuStripFilterRX2;
        private ToolStripMenuItem toolStripMenuItemRX2FilterConfigure;
        private ToolStripMenuItem toolStripMenuItemRX2FilterReset;
        private RadioButtonTS radDisplayZoom05;
        private RadioButtonTS radDisplayZoom4x;
        private RadioButtonTS radDisplayZoom2x;
        private RadioButtonTS radDisplayZoom1x;
        private CheckBoxTS chkFWCATUBypass;
        private CheckBoxTS chkFWCATU;
        private CheckBoxTS chkMicMute;
        private CheckBoxTS chkMUT;
        private PanelTS panelPower;
        private LabelTS lblAF2;
        private LabelTS lblRF2;
        private LabelTS lblPWR2;
        private LabelTS lblModeLabel;
        private LabelTS lblFilterLabel;
        private CheckBoxTS chkCWFWKeyer;
        private CheckBoxTS chkShowCWZero;
        private PanelTS panelModeSpecificFM;
        private LabelTS lblMicValFM;
        private RadioButtonTS radFMDeviation2kHz;
        private LabelTS labelTS7;
        private LabelTS lblFMOffset;
        private ButtonTS btnFMMemoryDown;
        private ButtonTS btnFMMemoryUp;
        private ButtonTS btnFMMemory;
        private LabelTS lblFMDeviation;
        private CheckBoxTS chkFMCTCSS;
        private ComboBoxTS comboFMCTCSS;
        private ComboBoxTS comboFMMemory;
        private CheckBoxTS chkFMTXSimplex;
        private NumericUpDownTS udFMOffset;
        private ComboBoxTS comboFMTXProfile;
        private RadioButtonTS radFMDeviation5kHz;
        private LabelTS lblFMMic;
        private CheckBoxTS chkFMTXLow;
        private CheckBoxTS chkFMTXHigh;
        private CheckBoxTS chkFMTXRev;
        private ButtonTS btnTNFAdd;
        private CheckBoxTS chkTNF;
        private ContextMenuStrip contextMenuStripNotch;
        private ToolStripMenuItem toolStripNotchDelete;
        private ToolStripMenuItem toolStripNotchRemember;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripNotchNormal;
        private ToolStripMenuItem toolStripNotchDeep;
        private ToolStripMenuItem toolStripNotchVeryDeep;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem setupToolStripMenuItem;
        private ToolStripMenuItem memoryToolStripMenuItem;
        private ToolStripMenuItem waveToolStripMenuItem;
        private ToolStripMenuItem equalizerToolStripMenuItem;
        private ToolStripMenuItem xVTRsToolStripMenuItem;
        private ToolStripMenuItem cWXToolStripMenuItem;
        private ToolStripMenuItem eSCToolStripMenuItem;
        private ToolStripMenuItem collapseToolStripMenuItem;
        private ToolStripMenuItem filterToolStripMenuItem;
        private ToolStripMenuItem dSPToolStripMenuItem;
        private ToolStripMenuItem displayControlsToolStripMenuItem;
        public ToolStripMenuItem topControlsToolStripMenuItem;
        public ToolStripMenuItem bandControlsToolStripMenuItem;
        public ToolStripMenuItem modeControlsToolStripMenuItem;
        private ToolStripMenuItem FilterToolStripMenuItem1;
        private ToolStripMenuItem FilterToolStripMenuItem2;
        private ToolStripMenuItem FilterToolStripMenuItem3;
        private ToolStripMenuItem FilterToolStripMenuItem4;
        private ToolStripMenuItem FilterToolStripMenuItem5;
        private ToolStripMenuItem FilterToolStripMenuItem6;
        private ToolStripMenuItem FilterToolStripMenuItem7;
        private ToolStripMenuItem FilterToolStripMenuItem8;
        private ToolStripMenuItem FilterToolStripMenuItem9;
        private ToolStripMenuItem FilterToolStripMenuItem10;
        private ToolStripMenuItem NRToolStripMenuItem;
        private ToolStripMenuItem ANFToolStripMenuItem;
        private ToolStripMenuItem NBToolStripMenuItem;
        private ToolStripMenuItem NB2ToolStripMenuItem;
        private ToolStripMenuItem BINToolStripMenuItem;
        private ToolStripMenuItem MultiRXToolStripMenuItem;
        public ToolStripMenuItem bandToolStripMenuItem;
        private ToolStripMenuItem bandtoolStripMenuItem1;
        private ToolStripMenuItem bandtoolStripMenuItem2;
        private ToolStripMenuItem bandtoolStripMenuItem3;
        private ToolStripMenuItem bandtoolStripMenuItem4;
        private ToolStripMenuItem bandtoolStripMenuItem5;
        private ToolStripMenuItem bandtoolStripMenuItem7;
        private ToolStripMenuItem bandtoolStripMenuItem8;
        private ToolStripMenuItem bandtoolStripMenuItem9;
        private ToolStripMenuItem bandtoolStripMenuItem10;
        private ToolStripMenuItem bandtoolStripMenuItem11;
        private ToolStripMenuItem bandtoolStripMenuItem12;
        private ToolStripMenuItem bandtoolStripMenuItem13;
        public ToolStripMenuItem modeToolStripMenuItem;
        private ToolStripMenuItem lSBToolStripMenuItem;
        private ToolStripMenuItem uSBToolStripMenuItem;
        private ToolStripMenuItem dSBToolStripMenuItem;
        private ToolStripMenuItem cWLToolStripMenuItem;
        private ToolStripMenuItem cWUToolStripMenuItem;
        private ToolStripMenuItem fMToolStripMenuItem;
        private ToolStripMenuItem aMToolStripMenuItem;
        private ToolStripMenuItem sAMToolStripMenuItem;
        private ToolStripMenuItem sPECToolStripMenuItem;
        private ToolStripMenuItem dIGLToolStripMenuItem;
        private ToolStripMenuItem dIGUToolStripMenuItem;
        private ToolStripMenuItem dRMToolStripMenuItem;
        private ToolStripMenuItem bandtoolStripMenuItem14;
        private PrettyTrackBar ptbFMMic;
        private CheckBoxTS chkCWSidetone;
        private ToolStripMenuItem rX2ToolStripMenuItem;
        private ToolStripMenuItem bandToolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripMenuItem wWVToolStripMenuItem;
        private ToolStripMenuItem gENToolStripMenuItem;
        private ToolStripMenuItem modeToolStripMenuItem1;
        private ToolStripMenuItem lSBToolStripMenuItem1;
        private ToolStripMenuItem uSBToolStripMenuItem1;
        private ToolStripMenuItem dSBToolStripMenuItem1;
        private ToolStripMenuItem cWLToolStripMenuItem1;
        private ToolStripMenuItem cWUToolStripMenuItem1;
        private ToolStripMenuItem fMToolStripMenuItem1;
        private ToolStripMenuItem filterToolStripMenuItem11;
        private ToolStripMenuItem dSPToolStripMenuItem1;
        private ToolStripMenuItem aMToolStripMenuItem1;
        private ToolStripMenuItem sAMToolStripMenuItem1;
        private ToolStripMenuItem dIGLToolStripMenuItem1;
        private ToolStripMenuItem dIGUToolStripMenuItem1;
        private ToolStripMenuItem dRMToolStripMenuItem1;
        private ToolStripMenuItem kToolStripMenuItem;
        private ToolStripMenuItem kToolStripMenuItem1;
        private ToolStripMenuItem kToolStripMenuItem2;
        private ToolStripMenuItem kToolStripMenuItem3;
        private ToolStripMenuItem kToolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripMenuItem toolStripMenuItem14;
        private ToolStripMenuItem nR2ToolStripMenuItem;
        private ToolStripMenuItem aNF2ToolStripMenuItem;
        private ToolStripMenuItem nB2ToolStripMenuItem1;
        private ToolStripMenuItem nBRX2ToolStripMenuItem;
        private ToolStripMenuItem bIN2ToolStripMenuItem;
        private LabelTS lblRX2FilterLabel;
        private LabelTS lblRX2ModeLabel;
        private Label lblRX1Vol;
        private Label lblRX1SubVol;
        private Label label2;
        private PrettyTrackBar ptbRX2AF;
        private LabelTS lblRX2AF;
        private PrettyTrackBar ptbRX1AF;
        private LabelTS lblRX1AF;
        private PictureBox picRX2Squelch;
        private PanelTS panelRX2Power;
        private PanelTS panelRX2RF;
        private RadioButtonTS radRX2Show;
        private RadioButtonTS radRX1Show;
        private LabelTS lblRX1MuteVFOA;
        private LabelTS lblRX2MuteVFOB;
        private CheckBoxTS chkRX2Mute;
        private LabelTS lblVACTXIndicator;
        private LabelTS lblVACRXIndicator;
        private CheckBoxTS chkVAC2;
        private NumericUpDownTS udRX1StepAttData;
        private CheckBoxTS chkFullDuplex;
        private ToolStripMenuItem RX1AVGToolStripMenuItem;
        private ToolStripMenuItem RX1PeakToolStripMenuItem;
        private ToolStripMenuItem RX2AVGToolStripMenuItem;
        private ToolStripMenuItem RX2PeakToolStripMenuItem;
        private ToolStripMenuItem linearityToolStripMenuItem;
        public ComboBoxTS comboRX2Preamp;
        private LabelTS lblRX2Preamp;
        private NumericUpDownTS udRX2StepAttData;
        private ToolStripMenuItem RAtoolStripMenuItem;
        private GroupBoxTS grpCWAPF;
        private PrettyTrackBar ptbCWAPFFreq;
        private PrettyTrackBar ptbCWAPFBandwidth;
        private LabelTS lblCWSpeed;
        private LabelTS lblCWAPFBandwidth;
        private LabelTS lblCWAPFTune;
        private CheckBoxTS chkCWAPFEnabled;
        private PrettyTrackBar ptbCWAPFGain;
        private LabelTS lblCWAPFGain;
        private LabelTS lblRX1APF;
        private LabelTS lblRX2APF;
        private ToolStripMenuItem wBToolStripMenuItem;
        private ToolStripMenuItem pIToolStripMenuItem;
        public ToolStripMenuItem spotterMenu;
        // G8NJJ
        private LabelTS lblVFOSyncLabel;
        private LabelTS lblNRLabel;
        private LabelTS lblNBLabel;
        private LabelTS lblSNBLabel;
        private LabelTS lblANFLabel;
        private LabelTS lblRX2NRLabel;
        private LabelTS lblRX2NBLabel;
        private LabelTS lblRX2SNBLabel;
        private LabelTS lblRX2ANFLabel;
        private PanelTS panelButtonBar;
        private ButtonTS btnAndrBar7;
        private ButtonTS btnAndrBar6;
        private ButtonTS btnAndrBar5;
        private ButtonTS btnAndrBar4;
        private ButtonTS btnAndrBar3;
        private ButtonTS btnAndrBar2;
        private ButtonTS btnAndrBar1;
        private ButtonTS btnAndrBar8;


        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Console));
            this.timer_cpu_volts_meter = new System.Windows.Forms.Timer(this.components);
            this.timer_peak_text = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblPAProfile = new System.Windows.Forms.LabelTS();
            this.btnFilterShiftReset = new System.Windows.Forms.ButtonTS();
            this.udFilterHigh = new System.Windows.Forms.NumericUpDownTS();
            this.udFilterLow = new System.Windows.Forms.NumericUpDownTS();
            this.lblRX2RF = new System.Windows.Forms.LabelTS();
            this.chkFullDuplex = new System.Windows.Forms.CheckBoxTS();
            this.chkRX2Squelch = new System.Windows.Forms.CheckBoxTS();
            this.chkRX2Mute = new System.Windows.Forms.CheckBoxTS();
            this.chkRX2NB2 = new System.Windows.Forms.CheckBoxTS();
            this.chkRX2NR = new System.Windows.Forms.CheckBoxTS();
            this.chkRX2NB = new System.Windows.Forms.CheckBoxTS();
            this.lblRX2AGC = new System.Windows.Forms.LabelTS();
            this.chkRX2ANF = new System.Windows.Forms.CheckBoxTS();
            this.comboRX2AGC = new System.Windows.Forms.ComboBoxTS();
            this.chkRX2BIN = new System.Windows.Forms.CheckBoxTS();
            this.chkExternalPA = new System.Windows.Forms.CheckBoxTS();
            this.ckQuickPlay = new System.Windows.Forms.CheckBoxTS();
            this.chkMON = new System.Windows.Forms.CheckBoxTS();
            this.ckQuickRec = new System.Windows.Forms.CheckBoxTS();
            this.chkRX2SR = new System.Windows.Forms.CheckBoxTS();
            this.chkMOX = new System.Windows.Forms.CheckBoxTS();
            this.chkTUN = new System.Windows.Forms.CheckBoxTS();
            this.chk2TONE = new System.Windows.Forms.CheckBoxTS();
            this.chkFWCATUBypass = new System.Windows.Forms.CheckBoxTS();
            this.comboTuneMode = new System.Windows.Forms.ComboBoxTS();
            this.udTXFilterLow = new System.Windows.Forms.NumericUpDownTS();
            this.udTXFilterHigh = new System.Windows.Forms.NumericUpDownTS();
            this.chkMicMute = new System.Windows.Forms.CheckBoxTS();
            this.chkShowTXFilter = new System.Windows.Forms.CheckBoxTS();
            this.chkTXEQ = new System.Windows.Forms.CheckBoxTS();
            this.chkRXEQ = new System.Windows.Forms.CheckBoxTS();
            this.chkCPDR = new System.Windows.Forms.CheckBoxTS();
            this.chkVOX = new System.Windows.Forms.CheckBoxTS();
            this.chkNoiseGate = new System.Windows.Forms.CheckBoxTS();
            this.comboTXProfile = new System.Windows.Forms.ComboBoxTS();
            this.comboAMTXProfile = new System.Windows.Forms.ComboBoxTS();
            this.chkX2TR = new System.Windows.Forms.CheckBoxTS();
            this.chkFWCATU = new System.Windows.Forms.CheckBoxTS();
            this.comboRX2Band = new System.Windows.Forms.ComboBoxTS();
            this.chkRX2Preamp = new System.Windows.Forms.CheckBoxTS();
            this.chkPower = new System.Windows.Forms.CheckBoxTS();
            this.udCWPitch = new System.Windows.Forms.NumericUpDownTS();
            this.udCWBreakInDelay = new System.Windows.Forms.NumericUpDownTS();
            this.chkShowTXCWFreq = new System.Windows.Forms.CheckBoxTS();
            this.chkCWIambic = new System.Windows.Forms.CheckBoxTS();
            this.udRX2FilterHigh = new System.Windows.Forms.NumericUpDownTS();
            this.udRX2FilterLow = new System.Windows.Forms.NumericUpDownTS();
            this.radRX2ModeAM = new System.Windows.Forms.RadioButtonTS();
            this.radRX2ModeLSB = new System.Windows.Forms.RadioButtonTS();
            this.radRX2ModeSAM = new System.Windows.Forms.RadioButtonTS();
            this.radRX2ModeCWL = new System.Windows.Forms.RadioButtonTS();
            this.radRX2ModeDSB = new System.Windows.Forms.RadioButtonTS();
            this.radRX2ModeUSB = new System.Windows.Forms.RadioButtonTS();
            this.radRX2ModeCWU = new System.Windows.Forms.RadioButtonTS();
            this.radRX2ModeFMN = new System.Windows.Forms.RadioButtonTS();
            this.radRX2ModeDIGU = new System.Windows.Forms.RadioButtonTS();
            this.radRX2ModeDRM = new System.Windows.Forms.RadioButtonTS();
            this.radRX2ModeDIGL = new System.Windows.Forms.RadioButtonTS();
            this.radRX2ModeSPEC = new System.Windows.Forms.RadioButtonTS();
            this.chkRX2DisplayPeak = new System.Windows.Forms.CheckBoxTS();
            this.comboRX2DisplayMode = new System.Windows.Forms.ComboBoxTS();
            this.chkPanSwap = new System.Windows.Forms.CheckBoxTS();
            this.chkEnableMultiRX = new System.Windows.Forms.CheckBoxTS();
            this.chkDisplayPeak = new System.Windows.Forms.CheckBoxTS();
            this.comboDisplayMode = new System.Windows.Forms.ComboBoxTS();
            this.chkDisplayAVG = new System.Windows.Forms.CheckBoxTS();
            this.chkNR = new System.Windows.Forms.CheckBoxTS();
            this.chkDSPNB2 = new System.Windows.Forms.CheckBoxTS();
            this.chkBIN = new System.Windows.Forms.CheckBoxTS();
            this.chkNB = new System.Windows.Forms.CheckBoxTS();
            this.chkANF = new System.Windows.Forms.CheckBoxTS();
            this.btnZeroBeat = new System.Windows.Forms.ButtonTS();
            this.chkVFOSplit = new System.Windows.Forms.CheckBoxTS();
            this.btnRITReset = new System.Windows.Forms.ButtonTS();
            this.btnXITReset = new System.Windows.Forms.ButtonTS();
            this.udRIT = new System.Windows.Forms.NumericUpDownTS();
            this.btnIFtoVFO = new System.Windows.Forms.ButtonTS();
            this.chkRIT = new System.Windows.Forms.CheckBoxTS();
            this.btnVFOSwap = new System.Windows.Forms.ButtonTS();
            this.chkXIT = new System.Windows.Forms.CheckBoxTS();
            this.btnVFOBtoA = new System.Windows.Forms.ButtonTS();
            this.udXIT = new System.Windows.Forms.NumericUpDownTS();
            this.btnVFOAtoB = new System.Windows.Forms.ButtonTS();
            this.chkRX1Preamp = new System.Windows.Forms.CheckBoxTS();
            this.comboAGC = new System.Windows.Forms.ComboBoxTS();
            this.lblAGC = new System.Windows.Forms.LabelTS();
            this.comboPreamp = new System.Windows.Forms.ComboBoxTS();
            this.lblRF = new System.Windows.Forms.LabelTS();
            this.chkDX = new System.Windows.Forms.CheckBoxTS();
            this.chkVAC1 = new System.Windows.Forms.CheckBoxTS();
            this.comboDigTXProfile = new System.Windows.Forms.ComboBoxTS();
            this.chkVACStereo = new System.Windows.Forms.CheckBoxTS();
            this.comboVACSampleRate = new System.Windows.Forms.ComboBoxTS();
            this.btnDisplayPanCenter = new System.Windows.Forms.ButtonTS();
            this.radModeAM = new System.Windows.Forms.RadioButtonTS();
            this.radModeLSB = new System.Windows.Forms.RadioButtonTS();
            this.radModeSAM = new System.Windows.Forms.RadioButtonTS();
            this.radModeCWL = new System.Windows.Forms.RadioButtonTS();
            this.radModeDSB = new System.Windows.Forms.RadioButtonTS();
            this.radModeUSB = new System.Windows.Forms.RadioButtonTS();
            this.radModeCWU = new System.Windows.Forms.RadioButtonTS();
            this.radModeFMN = new System.Windows.Forms.RadioButtonTS();
            this.radModeDIGU = new System.Windows.Forms.RadioButtonTS();
            this.radModeDRM = new System.Windows.Forms.RadioButtonTS();
            this.radModeDIGL = new System.Windows.Forms.RadioButtonTS();
            this.radModeSPEC = new System.Windows.Forms.RadioButtonTS();
            this.btnBandVHF = new System.Windows.Forms.ButtonTS();
            this.chkVFOATX = new System.Windows.Forms.CheckBoxTS();
            this.txtWheelTune = new System.Windows.Forms.TextBoxTS();
            this.chkVFOBTX = new System.Windows.Forms.CheckBoxTS();
            this.comboMeterTXMode = new System.Windows.Forms.ComboBoxTS();
            this.comboMeterRXMode = new System.Windows.Forms.ComboBoxTS();
            this.chkSquelch = new System.Windows.Forms.CheckBoxTS();
            this.btnMemoryQuickRestore = new System.Windows.Forms.ButtonTS();
            this.btnMemoryQuickSave = new System.Windows.Forms.ButtonTS();
            this.txtMemoryQuick = new System.Windows.Forms.TextBoxTS();
            this.chkVFOLock = new System.Windows.Forms.CheckBoxTS();
            this.chkVFOSync = new System.Windows.Forms.CheckBoxTS();
            this.btnTuneStepChangeLarger = new System.Windows.Forms.ButtonTS();
            this.btnTuneStepChangeSmaller = new System.Windows.Forms.ButtonTS();
            this.chkSplitDisplay = new System.Windows.Forms.CheckBoxTS();
            this.comboDisplayModeTop = new System.Windows.Forms.ComboBoxTS();
            this.comboDisplayModeBottom = new System.Windows.Forms.ComboBoxTS();
            this.comboRX2MeterMode = new System.Windows.Forms.ComboBoxTS();
            this.chkRX2DisplayAVG = new System.Windows.Forms.CheckBoxTS();
            this.radBand160 = new System.Windows.Forms.RadioButtonTS();
            this.radBandGEN = new System.Windows.Forms.RadioButtonTS();
            this.radBandWWV = new System.Windows.Forms.RadioButtonTS();
            this.radBand6 = new System.Windows.Forms.RadioButtonTS();
            this.radBand10 = new System.Windows.Forms.RadioButtonTS();
            this.radBand12 = new System.Windows.Forms.RadioButtonTS();
            this.radBand15 = new System.Windows.Forms.RadioButtonTS();
            this.radBand17 = new System.Windows.Forms.RadioButtonTS();
            this.radBand20 = new System.Windows.Forms.RadioButtonTS();
            this.radBand30 = new System.Windows.Forms.RadioButtonTS();
            this.radBand40 = new System.Windows.Forms.RadioButtonTS();
            this.radBand60 = new System.Windows.Forms.RadioButtonTS();
            this.radBand80 = new System.Windows.Forms.RadioButtonTS();
            this.radDisplayZoom05 = new System.Windows.Forms.RadioButtonTS();
            this.radDisplayZoom4x = new System.Windows.Forms.RadioButtonTS();
            this.radDisplayZoom2x = new System.Windows.Forms.RadioButtonTS();
            this.radDisplayZoom1x = new System.Windows.Forms.RadioButtonTS();
            this.chkMUT = new System.Windows.Forms.CheckBoxTS();
            this.chkCWFWKeyer = new System.Windows.Forms.CheckBoxTS();
            this.chkShowCWZero = new System.Windows.Forms.CheckBoxTS();
            this.radFMDeviation5kHz = new System.Windows.Forms.RadioButtonTS();
            this.comboFMTXProfile = new System.Windows.Forms.ComboBoxTS();
            this.udFMOffset = new System.Windows.Forms.NumericUpDownTS();
            this.chkFMTXSimplex = new System.Windows.Forms.CheckBoxTS();
            this.comboFMCTCSS = new System.Windows.Forms.ComboBoxTS();
            this.btnFMMemory = new System.Windows.Forms.ButtonTS();
            this.chkFMCTCSS = new System.Windows.Forms.CheckBoxTS();
            this.btnFMMemoryUp = new System.Windows.Forms.ButtonTS();
            this.btnFMMemoryDown = new System.Windows.Forms.ButtonTS();
            this.radFMDeviation2kHz = new System.Windows.Forms.RadioButtonTS();
            this.chkFMTXLow = new System.Windows.Forms.CheckBoxTS();
            this.chkFMTXHigh = new System.Windows.Forms.CheckBoxTS();
            this.chkFMTXRev = new System.Windows.Forms.CheckBoxTS();
            this.chkTNF = new System.Windows.Forms.CheckBoxTS();
            this.btnTNFAdd = new System.Windows.Forms.ButtonTS();
            this.chkVAC2 = new System.Windows.Forms.CheckBoxTS();
            this.chkCWSidetone = new System.Windows.Forms.CheckBoxTS();
            this.udRX1StepAttData = new System.Windows.Forms.NumericUpDownTS();
            this.comboRX2Preamp = new System.Windows.Forms.ComboBoxTS();
            this.udRX2StepAttData = new System.Windows.Forms.NumericUpDownTS();
            this.chkCWAPFEnabled = new System.Windows.Forms.CheckBoxTS();
            this.lblBandStack = new System.Windows.Forms.LabelTS();
            this.regBandStackCurrentEntry = new System.Windows.Forms.TextBoxTS();
            this.regBandStackTotalEntries = new System.Windows.Forms.TextBoxTS();
            this.radBandGEN13 = new System.Windows.Forms.RadioButtonTS();
            this.radBandGEN12 = new System.Windows.Forms.RadioButtonTS();
            this.radBandGEN11 = new System.Windows.Forms.RadioButtonTS();
            this.radBandGEN10 = new System.Windows.Forms.RadioButtonTS();
            this.radBandGEN9 = new System.Windows.Forms.RadioButtonTS();
            this.radBandGEN8 = new System.Windows.Forms.RadioButtonTS();
            this.radBandGEN7 = new System.Windows.Forms.RadioButtonTS();
            this.radBandGEN6 = new System.Windows.Forms.RadioButtonTS();
            this.radBandGEN5 = new System.Windows.Forms.RadioButtonTS();
            this.radBandGEN4 = new System.Windows.Forms.RadioButtonTS();
            this.radBandGEN3 = new System.Windows.Forms.RadioButtonTS();
            this.radBandGEN2 = new System.Windows.Forms.RadioButtonTS();
            this.radBandGEN1 = new System.Windows.Forms.RadioButtonTS();
            this.radBandGEN0 = new System.Windows.Forms.RadioButtonTS();
            this.chkRxAnt = new System.Windows.Forms.CheckBoxTS();
            this.chkVFOBLock = new System.Windows.Forms.CheckBoxTS();
            this.chkQSK = new System.Windows.Forms.CheckBoxTS();
            this.btnDisplayZTB = new System.Windows.Forms.ButtonTS();
            this.ptbFilterShift = new Thetis.PrettyTrackBar();
            this.ptbFilterWidth = new Thetis.PrettyTrackBar();
            this.ptbRX2RF = new Thetis.PrettyTrackBar();
            this.ptbCWSpeed = new Thetis.PrettyTrackBar();
            this.ptbDisplayZoom = new Thetis.PrettyTrackBar();
            this.ptbDisplayPan = new Thetis.PrettyTrackBar();
            this.ptbPWR = new Thetis.PrettyTrackBar();
            this.ptbRF = new Thetis.PrettyTrackBar();
            this.ptbAF = new Thetis.PrettyTrackBar();
            this.ptbPanMainRX = new Thetis.PrettyTrackBar();
            this.ptbPanSubRX = new Thetis.PrettyTrackBar();
            this.ptbRX2Gain = new Thetis.PrettyTrackBar();
            this.ptbRX2Pan = new Thetis.PrettyTrackBar();
            this.ptbRX0Gain = new Thetis.PrettyTrackBar();
            this.ptbRX1Gain = new Thetis.PrettyTrackBar();
            this.ptbVACRXGain = new Thetis.PrettyTrackBar();
            this.ptbVACTXGain = new Thetis.PrettyTrackBar();
            this.ptbRX2AF = new Thetis.PrettyTrackBar();
            this.ptbRX1AF = new Thetis.PrettyTrackBar();
            this.ptbCWAPFGain = new Thetis.PrettyTrackBar();
            this.ptbCWAPFBandwidth = new Thetis.PrettyTrackBar();
            this.ptbCWAPFFreq = new Thetis.PrettyTrackBar();
            this.ptbTune = new Thetis.PrettyTrackBar();
            this.udTXStepAttData = new System.Windows.Forms.NumericUpDownTS();
            this.pbAutoAttWarningRX1 = new System.Windows.Forms.PictureBox();
            this.pbAutoAttWarningRX2 = new System.Windows.Forms.PictureBox();
            this.radBand2 = new System.Windows.Forms.RadioButtonTS();
            this.timer_clock = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripFilterRX1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemRX1FilterConfigure = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRX1FilterReset = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripFilterRX2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemRX2FilterConfigure = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRX2FilterReset = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripNotch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripNotchDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripNotchRemember = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripNotchNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripNotchDeep = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripNotchVeryDeep = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.databaseManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xVTRsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cWXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eSCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spotterMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.displayControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bandControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.andromedaTopControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.andromedaButtonBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dSPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NR2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ANFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NB2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SNBtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MultiRXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RX1AVGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RX1PeakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bandtoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bandtoolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bandtoolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.bandtoolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.bandtoolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.bandtoolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.bandtoolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.bandtoolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.bandtoolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.bandtoolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.bandtoolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.bandtoolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.bandtoolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lSBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dSBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cWLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cWUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sPECToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dIGLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dIGUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dRMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterToolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.rX2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bandToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.wWVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gENToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lSBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uSBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dSBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cWLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cWUToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fMToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aMToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sAMToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dIGLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dIGUToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dRMToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.kToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.kToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.kToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.dSPToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nR2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NR2StripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aNF2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nB2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nBRX2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SNBtoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bIN2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RX2AVGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RX2PeakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RAtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BPFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BPF1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BPF2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton_ScreenSize = new System.Windows.Forms.ToolStripDropDownButton();
            this.includeBordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_4by3 = new System.Windows.Forms.ToolStripMenuItem();
            this.x768ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x864ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x960ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x1050ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x1200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_16by9 = new System.Windows.Forms.ToolStripMenuItem();
            this.x720ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x768ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.x900ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x1080ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x1440ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x2160ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_16by10 = new System.Windows.Forms.ToolStripMenuItem();
            this.x800ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x900ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.x1050ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.x1200ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.x1600ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x2400ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youTubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton_CPU = new System.Windows.Forms.ToolStripDropDownButton();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thetisOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel_Volts = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Amps = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_TXInhibit = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_SeqWarning = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRXAnt = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabelTXAnt = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabelAndromedaMulti = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Fill = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_N1MM = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_TCI = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_CatTCPip = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_CatSerial = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_CMstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_timer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_UTCTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Date = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_LocalTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrAutoAGC = new System.Windows.Forms.Timer(this.components);
            this.nudPwrTemp2 = new System.Windows.Forms.NumericUpDownTS();
            this.nudPwrTemp = new System.Windows.Forms.NumericUpDownTS();
            this.grpMultimeter = new System.Windows.Forms.GroupBoxTS();
            this.pnlResizeMeter = new System.Windows.Forms.PanelTS();
            this.picMultiMeterDigital = new System.Windows.Forms.PictureBox();
            this.txtMultiText = new System.Windows.Forms.TextBoxTS();
            this.panelFilter = new System.Windows.Forms.PanelTS();
            this.radFilter1 = new System.Windows.Forms.RadioButtonTS();
            this.lblFilterHigh = new System.Windows.Forms.LabelTS();
            this.lblFilterWidth = new System.Windows.Forms.LabelTS();
            this.radFilterVar2 = new System.Windows.Forms.RadioButtonTS();
            this.lblFilterLow = new System.Windows.Forms.LabelTS();
            this.radFilterVar1 = new System.Windows.Forms.RadioButtonTS();
            this.lblFilterShift = new System.Windows.Forms.LabelTS();
            this.radFilter9 = new System.Windows.Forms.RadioButtonTS();
            this.radFilter8 = new System.Windows.Forms.RadioButtonTS();
            this.radFilter2 = new System.Windows.Forms.RadioButtonTS();
            this.radFilter7 = new System.Windows.Forms.RadioButtonTS();
            this.radFilter3 = new System.Windows.Forms.RadioButtonTS();
            this.radFilter6 = new System.Windows.Forms.RadioButtonTS();
            this.radFilter4 = new System.Windows.Forms.RadioButtonTS();
            this.radFilter5 = new System.Windows.Forms.RadioButtonTS();
            this.radFilter10 = new System.Windows.Forms.RadioButtonTS();
            this.panelRX2RF = new System.Windows.Forms.PanelTS();
            this.panelRX2DSP = new System.Windows.Forms.PanelTS();
            this.btnHidden = new System.Windows.Forms.ButtonTS();
            this.panelOptions = new System.Windows.Forms.PanelTS();
            this.checkBoxTS1 = new System.Windows.Forms.CheckBoxTS();
            this.panelModeSpecificPhone = new System.Windows.Forms.PanelTS();
            this.lblTXHigh = new System.Windows.Forms.LabelTS();
            this.lblTXLow = new System.Windows.Forms.LabelTS();
            this.picNoiseGate = new System.Windows.Forms.PictureBox();
            this.lblNoiseGateVal = new System.Windows.Forms.LabelTS();
            this.ptbNoiseGate = new Thetis.PrettyTrackBar();
            this.picVOX = new System.Windows.Forms.PictureBox();
            this.ptbVOX = new Thetis.PrettyTrackBar();
            this.lblVOXVal = new System.Windows.Forms.LabelTS();
            this.ptbCPDR = new Thetis.PrettyTrackBar();
            this.lblCPDRVal = new System.Windows.Forms.LabelTS();
            this.lblMicVal = new System.Windows.Forms.LabelTS();
            this.ptbMic = new Thetis.PrettyTrackBar();
            this.lblMIC = new System.Windows.Forms.LabelTS();
            this.lblTransmitProfile = new System.Windows.Forms.LabelTS();
            this.panelButtonBar = new System.Windows.Forms.PanelTS();
            this.btnAndrBar8 = new System.Windows.Forms.ButtonTS();
            this.btnAndrBar7 = new System.Windows.Forms.ButtonTS();
            this.btnAndrBar6 = new System.Windows.Forms.ButtonTS();
            this.btnAndrBar5 = new System.Windows.Forms.ButtonTS();
            this.btnAndrBar4 = new System.Windows.Forms.ButtonTS();
            this.btnAndrBar3 = new System.Windows.Forms.ButtonTS();
            this.btnAndrBar2 = new System.Windows.Forms.ButtonTS();
            this.btnAndrBar1 = new System.Windows.Forms.ButtonTS();
            this.panelVFOLabels = new System.Windows.Forms.PanelTS();
            this.lblStepValue = new System.Windows.Forms.LabelTS();
            this.lblStep = new System.Windows.Forms.LabelTS();
            this.lblVFOSplit = new System.Windows.Forms.LabelTS();
            this.lblXITValue = new System.Windows.Forms.LabelTS();
            this.lblRITValue = new System.Windows.Forms.LabelTS();
            this.lblRITLabel = new System.Windows.Forms.LabelTS();
            this.lblXITLabel = new System.Windows.Forms.LabelTS();
            this.lblVFOSyncLabel = new System.Windows.Forms.LabelTS();
            this.panelVFOALabels = new System.Windows.Forms.PanelTS();
            this.lblLockLabel = new System.Windows.Forms.LabelTS();
            this.lblAGCLabel = new System.Windows.Forms.LabelTS();
            this.lblAttenLabel = new System.Windows.Forms.LabelTS();
            this.lblANFLabel = new System.Windows.Forms.LabelTS();
            this.lblSNBLabel = new System.Windows.Forms.LabelTS();
            this.lblNBLabel = new System.Windows.Forms.LabelTS();
            this.lblNRLabel = new System.Windows.Forms.LabelTS();
            this.lblCtunLabel = new System.Windows.Forms.LabelTS();
            this.panelVFOBLabels = new System.Windows.Forms.PanelTS();
            this.lblRX2AttenLabel = new System.Windows.Forms.LabelTS();
            this.lblRX2LockLabel = new System.Windows.Forms.LabelTS();
            this.lblRX2AGCLabel = new System.Windows.Forms.LabelTS();
            this.lblRX2CtunLabel = new System.Windows.Forms.LabelTS();
            this.lblRX2NRLabel = new System.Windows.Forms.LabelTS();
            this.lblRX2NBLabel = new System.Windows.Forms.LabelTS();
            this.lblRX2SNBLabel = new System.Windows.Forms.LabelTS();
            this.lblRX2ANFLabel = new System.Windows.Forms.LabelTS();
            this.panelRX2Power = new System.Windows.Forms.PanelTS();
            this.lblRX2Band = new System.Windows.Forms.LabelTS();
            this.lblRX2Preamp = new System.Windows.Forms.LabelTS();
            this.chkRX2 = new System.Windows.Forms.CheckBoxTS();
            this.radRX1Show = new System.Windows.Forms.RadioButtonTS();
            this.radRX2Show = new System.Windows.Forms.RadioButtonTS();
            this.lblRF2 = new System.Windows.Forms.LabelTS();
            this.panelPower = new System.Windows.Forms.PanelTS();
            this.panelModeSpecificCW = new System.Windows.Forms.PanelTS();
            this.grpCWAPF = new System.Windows.Forms.GroupBoxTS();
            this.lblCWAPFGain = new System.Windows.Forms.LabelTS();
            this.lblCWAPFBandwidth = new System.Windows.Forms.LabelTS();
            this.lblCWAPFTune = new System.Windows.Forms.LabelTS();
            this.lblCWSpeed = new System.Windows.Forms.LabelTS();
            this.grpSemiBreakIn = new System.Windows.Forms.GroupBoxTS();
            this.lblCWBreakInDelay = new System.Windows.Forms.LabelTS();
            this.lblCWPitchFreq = new System.Windows.Forms.LabelTS();
            this.panelRX2Filter = new System.Windows.Forms.PanelTS();
            this.radRX2Filter1 = new System.Windows.Forms.RadioButtonTS();
            this.lblRX2FilterHigh = new System.Windows.Forms.LabelTS();
            this.lblRX2FilterLow = new System.Windows.Forms.LabelTS();
            this.radRX2Filter2 = new System.Windows.Forms.RadioButtonTS();
            this.radRX2FilterVar2 = new System.Windows.Forms.RadioButtonTS();
            this.radRX2Filter3 = new System.Windows.Forms.RadioButtonTS();
            this.radRX2FilterVar1 = new System.Windows.Forms.RadioButtonTS();
            this.radRX2Filter4 = new System.Windows.Forms.RadioButtonTS();
            this.radRX2Filter7 = new System.Windows.Forms.RadioButtonTS();
            this.radRX2Filter5 = new System.Windows.Forms.RadioButtonTS();
            this.radRX2Filter6 = new System.Windows.Forms.RadioButtonTS();
            this.panelRX2Mode = new System.Windows.Forms.PanelTS();
            this.panelRX2Display = new System.Windows.Forms.PanelTS();
            this.panelRX2Mixer = new System.Windows.Forms.PanelTS();
            this.lblRX2Pan = new System.Windows.Forms.Label();
            this.lblRX2Vol = new System.Windows.Forms.Label();
            this.panelMultiRX = new System.Windows.Forms.PanelTS();
            this.lblRX1SubVol = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRX1Vol = new System.Windows.Forms.Label();
            this.panelDisplay2 = new System.Windows.Forms.PanelTS();
            this.panelDSP = new System.Windows.Forms.PanelTS();
            this.panelVFO = new System.Windows.Forms.PanelTS();
            this.ucVAC2UnderOver = new Thetis.ucUnderOverFlowWarningViewer();
            this.ucVAC1UnderOver = new Thetis.ucUnderOverFlowWarningViewer();
            this.panelSoundControls = new System.Windows.Forms.PanelTS();
            this.lblTune = new System.Windows.Forms.LabelTS();
            this.lblRX2AF = new System.Windows.Forms.LabelTS();
            this.lblRX1AF = new System.Windows.Forms.LabelTS();
            this.lblAF = new System.Windows.Forms.LabelTS();
            this.lblPWR = new System.Windows.Forms.LabelTS();
            this.lblPreamp = new System.Windows.Forms.LabelTS();
            this.lblAF2 = new System.Windows.Forms.LabelTS();
            this.lblPWR2 = new System.Windows.Forms.LabelTS();
            this.panelModeSpecificDigital = new System.Windows.Forms.PanelTS();
            this.lblVACTXIndicator = new System.Windows.Forms.LabelTS();
            this.lblDigTXProfile = new System.Windows.Forms.LabelTS();
            this.lblVACRXIndicator = new System.Windows.Forms.LabelTS();
            this.lblRXGain = new System.Windows.Forms.LabelTS();
            this.grpVACStereo = new System.Windows.Forms.GroupBoxTS();
            this.lblTXGain = new System.Windows.Forms.LabelTS();
            this.grpDIGSampleRate = new System.Windows.Forms.GroupBoxTS();
            this.panelDisplay = new System.Windows.Forms.PanelTS();
            this.infoBar = new Thetis.ucInfoBar();
            this.lblDisplayZoom = new System.Windows.Forms.LabelTS();
            this.lblDisplayPan = new System.Windows.Forms.LabelTS();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.panelMode = new System.Windows.Forms.PanelTS();
            this.panelBandHF = new System.Windows.Forms.PanelTS();
            this.txtVFOAFreq = new System.Windows.Forms.TextBoxTS();
            this.grpVFOA = new System.Windows.Forms.GroupBoxTS();
            this.panelVFOAHover = new System.Windows.Forms.Panel();
            this.lblModeBigLabel = new System.Windows.Forms.LabelTS();
            this.lblRX1APF = new System.Windows.Forms.LabelTS();
            this.lblRX1MuteVFOA = new System.Windows.Forms.LabelTS();
            this.lblFilterLabel = new System.Windows.Forms.LabelTS();
            this.lblModeLabel = new System.Windows.Forms.LabelTS();
            this.txtVFOALSD = new System.Windows.Forms.TextBoxTS();
            this.txtVFOAMSD = new System.Windows.Forms.TextBoxTS();
            this.panelVFOASubHover = new System.Windows.Forms.Panel();
            this.txtVFOABand = new System.Windows.Forms.TextBoxTS();
            this.grpVFOB = new System.Windows.Forms.GroupBoxTS();
            this.lblRX2ModeBigLabel = new System.Windows.Forms.LabelTS();
            this.lblRX2APF = new System.Windows.Forms.LabelTS();
            this.panelVFOBHover = new System.Windows.Forms.Panel();
            this.txtVFOBBand = new System.Windows.Forms.TextBoxTS();
            this.txtVFOBLSD = new System.Windows.Forms.TextBoxTS();
            this.lblRX2FilterLabel = new System.Windows.Forms.LabelTS();
            this.lblRX2MuteVFOB = new System.Windows.Forms.LabelTS();
            this.lblRX2ModeLabel = new System.Windows.Forms.LabelTS();
            this.txtVFOBMSD = new System.Windows.Forms.TextBoxTS();
            this.lblVFOBLSD = new System.Windows.Forms.LabelTS();
            this.txtVFOBFreq = new System.Windows.Forms.TextBoxTS();
            this.btnBandHF = new System.Windows.Forms.ButtonTS();
            this.lblTuneStep = new System.Windows.Forms.LabelTS();
            this.grpVFOBetween = new System.Windows.Forms.GroupBoxTS();
            this.ucQuickRecallPad = new Thetis.ucQuickRecall();
            this.labelTS1 = new System.Windows.Forms.LabelTS();
            this.lblDisplayModeTop = new System.Windows.Forms.LabelTS();
            this.lblDisplayModeBottom = new System.Windows.Forms.LabelTS();
            this.grpDisplaySplit = new System.Windows.Forms.GroupBoxTS();
            this.grpRX2Meter = new System.Windows.Forms.GroupBoxTS();
            this.picRX2Meter = new System.Windows.Forms.PictureBox();
            this.txtRX2Meter = new System.Windows.Forms.TextBoxTS();
            this.panelBandVHF = new System.Windows.Forms.PanelTS();
            this.radBandVHF13 = new System.Windows.Forms.RadioButtonTS();
            this.radBandVHF12 = new System.Windows.Forms.RadioButtonTS();
            this.radBandVHF11 = new System.Windows.Forms.RadioButtonTS();
            this.radBandVHF10 = new System.Windows.Forms.RadioButtonTS();
            this.radBandVHF9 = new System.Windows.Forms.RadioButtonTS();
            this.radBandVHF8 = new System.Windows.Forms.RadioButtonTS();
            this.radBandVHF7 = new System.Windows.Forms.RadioButtonTS();
            this.radBandVHF6 = new System.Windows.Forms.RadioButtonTS();
            this.radBandVHF5 = new System.Windows.Forms.RadioButtonTS();
            this.radBandVHF4 = new System.Windows.Forms.RadioButtonTS();
            this.radBandVHF3 = new System.Windows.Forms.RadioButtonTS();
            this.radBandVHF2 = new System.Windows.Forms.RadioButtonTS();
            this.radBandVHF1 = new System.Windows.Forms.RadioButtonTS();
            this.radBandVHF0 = new System.Windows.Forms.RadioButtonTS();
            this.panelModeSpecificFM = new System.Windows.Forms.PanelTS();
            this.ptbFMMic = new Thetis.PrettyTrackBar();
            this.lblMicValFM = new System.Windows.Forms.LabelTS();
            this.labelTS7 = new System.Windows.Forms.LabelTS();
            this.lblFMOffset = new System.Windows.Forms.LabelTS();
            this.lblFMDeviation = new System.Windows.Forms.LabelTS();
            this.comboFMMemory = new System.Windows.Forms.ComboBoxTS();
            this.lblFMMic = new System.Windows.Forms.LabelTS();
            this.panelBandGEN = new System.Windows.Forms.PanelTS();
            this.btnBandHF1 = new System.Windows.Forms.ButtonTS();
            this.panelMeterLabels = new System.Windows.Forms.PanelTS();
            this.lblRXMeter = new System.Windows.Forms.LabelTS();
            this.grpMultimeterMenus = new System.Windows.Forms.GroupBoxTS();
            this.panelAndromedaMisc = new System.Windows.Forms.PanelTS();
            this.tbAndromedaEncoderSlider = new System.Windows.Forms.TrackBarTS();
            this.lblAndromedaEncoderSlider = new System.Windows.Forms.LabelTS();
            this.lblATUTuneLabel = new System.Windows.Forms.LabelTS();
            this.picRX2Squelch = new System.Windows.Forms.PictureBox();
            this.ptbRX2Squelch = new Thetis.PrettyTrackBar();
            this.picSquelch = new System.Windows.Forms.PictureBox();
            this.ptbSquelch = new Thetis.PrettyTrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.udFilterHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFilterLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTXFilterLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTXFilterHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udCWPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udCWBreakInDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRX2FilterHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRX2FilterLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRIT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udXIT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFMOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRX1StepAttData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRX2StepAttData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFilterShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFilterWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX2RF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCWSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDisplayZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDisplayPan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPWR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPanMainRX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPanSubRX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX2Gain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX2Pan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX0Gain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX1Gain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbVACRXGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbVACTXGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX2AF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX1AF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCWAPFGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCWAPFBandwidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCWAPFFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTune)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTXStepAttData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAutoAttWarningRX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAutoAttWarningRX2)).BeginInit();
            this.contextMenuStripFilterRX1.SuspendLayout();
            this.contextMenuStripFilterRX2.SuspendLayout();
            this.contextMenuStripNotch.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPwrTemp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPwrTemp)).BeginInit();
            this.grpMultimeter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMultiMeterDigital)).BeginInit();
            this.panelFilter.SuspendLayout();
            this.panelRX2RF.SuspendLayout();
            this.panelRX2DSP.SuspendLayout();
            this.panelOptions.SuspendLayout();
            this.panelModeSpecificPhone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNoiseGate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbNoiseGate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVOX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbVOX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCPDR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMic)).BeginInit();
            this.panelButtonBar.SuspendLayout();
            this.panelVFOLabels.SuspendLayout();
            this.panelVFOALabels.SuspendLayout();
            this.panelVFOBLabels.SuspendLayout();
            this.panelRX2Power.SuspendLayout();
            this.panelPower.SuspendLayout();
            this.panelModeSpecificCW.SuspendLayout();
            this.grpCWAPF.SuspendLayout();
            this.grpSemiBreakIn.SuspendLayout();
            this.panelRX2Filter.SuspendLayout();
            this.panelRX2Mode.SuspendLayout();
            this.panelRX2Display.SuspendLayout();
            this.panelRX2Mixer.SuspendLayout();
            this.panelMultiRX.SuspendLayout();
            this.panelDisplay2.SuspendLayout();
            this.panelDSP.SuspendLayout();
            this.panelVFO.SuspendLayout();
            this.panelSoundControls.SuspendLayout();
            this.panelModeSpecificDigital.SuspendLayout();
            this.grpVACStereo.SuspendLayout();
            this.grpDIGSampleRate.SuspendLayout();
            this.panelDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            this.panelMode.SuspendLayout();
            this.panelBandHF.SuspendLayout();
            this.grpVFOA.SuspendLayout();
            this.grpVFOB.SuspendLayout();
            this.grpVFOBetween.SuspendLayout();
            this.grpDisplaySplit.SuspendLayout();
            this.grpRX2Meter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRX2Meter)).BeginInit();
            this.panelBandVHF.SuspendLayout();
            this.panelModeSpecificFM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFMMic)).BeginInit();
            this.panelBandGEN.SuspendLayout();
            this.panelMeterLabels.SuspendLayout();
            this.grpMultimeterMenus.SuspendLayout();
            this.panelAndromedaMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAndromedaEncoderSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRX2Squelch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX2Squelch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSquelch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSquelch)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_cpu_volts_meter
            // 
            this.timer_cpu_volts_meter.Enabled = true;
            this.timer_cpu_volts_meter.Interval = 1000;
            this.timer_cpu_volts_meter.Tick += new System.EventHandler(this.timer_cpu_volts_meter_Tick);
            // 
            // timer_peak_text
            // 
            this.timer_peak_text.Interval = 500;
            this.timer_peak_text.Tick += new System.EventHandler(this.timer_peak_text_Tick);
            // 
            // lblPAProfile
            // 
            this.lblPAProfile.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblPAProfile, "lblPAProfile");
            this.lblPAProfile.ForeColor = System.Drawing.Color.White;
            this.lblPAProfile.Name = "lblPAProfile";
            this.toolTip1.SetToolTip(this.lblPAProfile, resources.GetString("lblPAProfile.ToolTip"));
            this.lblPAProfile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblPAProfile_MouseDown);
            // 
            // btnFilterShiftReset
            // 
            this.btnFilterShiftReset.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnFilterShiftReset, "btnFilterShiftReset");
            this.btnFilterShiftReset.Name = "btnFilterShiftReset";
            this.btnFilterShiftReset.Selectable = true;
            this.btnFilterShiftReset.Tag = "Reset Filter Shift";
            this.toolTip1.SetToolTip(this.btnFilterShiftReset, resources.GetString("btnFilterShiftReset.ToolTip"));
            this.btnFilterShiftReset.Click += new System.EventHandler(this.btnFilterShiftReset_Click);
            // 
            // udFilterHigh
            // 
            this.udFilterHigh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            resources.ApplyResources(this.udFilterHigh, "udFilterHigh");
            this.udFilterHigh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.udFilterHigh.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udFilterHigh.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.udFilterHigh.Minimum = new decimal(new int[] {
            15000,
            0,
            0,
            -2147483648});
            this.udFilterHigh.Name = "udFilterHigh";
            this.udFilterHigh.TinyStep = false;
            this.toolTip1.SetToolTip(this.udFilterHigh, resources.GetString("udFilterHigh.ToolTip"));
            this.udFilterHigh.Value = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.udFilterHigh.ValueChanged += new System.EventHandler(this.udFilterHigh_ValueChanged);
            this.udFilterHigh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Console_KeyPress);
            this.udFilterHigh.LostFocus += new System.EventHandler(this.udFilterHigh_LostFocus);
            // 
            // udFilterLow
            // 
            this.udFilterLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            resources.ApplyResources(this.udFilterLow, "udFilterLow");
            this.udFilterLow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.udFilterLow.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udFilterLow.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.udFilterLow.Minimum = new decimal(new int[] {
            15000,
            0,
            0,
            -2147483648});
            this.udFilterLow.Name = "udFilterLow";
            this.udFilterLow.TinyStep = false;
            this.toolTip1.SetToolTip(this.udFilterLow, resources.GetString("udFilterLow.ToolTip"));
            this.udFilterLow.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFilterLow.ValueChanged += new System.EventHandler(this.udFilterLow_ValueChanged);
            this.udFilterLow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Console_KeyPress);
            this.udFilterLow.LostFocus += new System.EventHandler(this.udFilterLow_LostFocus);
            // 
            // lblRX2RF
            // 
            this.lblRX2RF.BackColor = System.Drawing.Color.Transparent;
            this.lblRX2RF.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.lblRX2RF, "lblRX2RF");
            this.lblRX2RF.Name = "lblRX2RF";
            this.toolTip1.SetToolTip(this.lblRX2RF, resources.GetString("lblRX2RF.ToolTip"));
            // 
            // chkFullDuplex
            // 
            resources.ApplyResources(this.chkFullDuplex, "chkFullDuplex");
            this.chkFullDuplex.BackColor = System.Drawing.Color.Transparent;
            this.chkFullDuplex.FlatAppearance.BorderSize = 0;
            this.chkFullDuplex.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkFullDuplex.Name = "chkFullDuplex";
            this.toolTip1.SetToolTip(this.chkFullDuplex, resources.GetString("chkFullDuplex.ToolTip"));
            this.chkFullDuplex.UseVisualStyleBackColor = false;
            this.chkFullDuplex.CheckedChanged += new System.EventHandler(this.chkFullDuplex_CheckedChanged);
            // 
            // chkRX2Squelch
            // 
            resources.ApplyResources(this.chkRX2Squelch, "chkRX2Squelch");
            this.chkRX2Squelch.FlatAppearance.BorderSize = 0;
            this.chkRX2Squelch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRX2Squelch.Name = "chkRX2Squelch";
            this.chkRX2Squelch.ThreeState = true;
            this.toolTip1.SetToolTip(this.chkRX2Squelch, resources.GetString("chkRX2Squelch.ToolTip"));
            this.chkRX2Squelch.CheckStateChanged += new System.EventHandler(this.chkRX2Squelch_CheckStateChanged);
            this.chkRX2Squelch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkRX2Squelch_MouseDown);
            // 
            // chkRX2Mute
            // 
            resources.ApplyResources(this.chkRX2Mute, "chkRX2Mute");
            this.chkRX2Mute.FlatAppearance.BorderSize = 0;
            this.chkRX2Mute.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRX2Mute.Name = "chkRX2Mute";
            this.toolTip1.SetToolTip(this.chkRX2Mute, resources.GetString("chkRX2Mute.ToolTip"));
            this.chkRX2Mute.CheckedChanged += new System.EventHandler(this.chkRX2Mute_CheckedChanged);
            // 
            // chkRX2NB2
            // 
            resources.ApplyResources(this.chkRX2NB2, "chkRX2NB2");
            this.chkRX2NB2.FlatAppearance.BorderSize = 0;
            this.chkRX2NB2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRX2NB2.Name = "chkRX2NB2";
            this.toolTip1.SetToolTip(this.chkRX2NB2, resources.GetString("chkRX2NB2.ToolTip"));
            this.chkRX2NB2.CheckedChanged += new System.EventHandler(this.chkRX2NB2_CheckedChanged);
            this.chkRX2NB2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkRX2NB2_MouseDown);
            // 
            // chkRX2NR
            // 
            resources.ApplyResources(this.chkRX2NR, "chkRX2NR");
            this.chkRX2NR.FlatAppearance.BorderSize = 0;
            this.chkRX2NR.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRX2NR.Name = "chkRX2NR";
            this.chkRX2NR.ThreeState = true;
            this.toolTip1.SetToolTip(this.chkRX2NR, resources.GetString("chkRX2NR.ToolTip"));
            this.chkRX2NR.CheckStateChanged += new System.EventHandler(this.chkRX2NR_CheckStateChanged);
            this.chkRX2NR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkRX2NR_MouseDown);
            // 
            // chkRX2NB
            // 
            resources.ApplyResources(this.chkRX2NB, "chkRX2NB");
            this.chkRX2NB.FlatAppearance.BorderSize = 0;
            this.chkRX2NB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRX2NB.Name = "chkRX2NB";
            this.chkRX2NB.ThreeState = true;
            this.toolTip1.SetToolTip(this.chkRX2NB, resources.GetString("chkRX2NB.ToolTip"));
            this.chkRX2NB.CheckStateChanged += new System.EventHandler(this.chkRX2NB_CheckStateChanged);
            this.chkRX2NB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkRX2NB_MouseDown);
            // 
            // lblRX2AGC
            // 
            this.lblRX2AGC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.lblRX2AGC, "lblRX2AGC");
            this.lblRX2AGC.Name = "lblRX2AGC";
            this.toolTip1.SetToolTip(this.lblRX2AGC, resources.GetString("lblRX2AGC.ToolTip"));
            // 
            // chkRX2ANF
            // 
            resources.ApplyResources(this.chkRX2ANF, "chkRX2ANF");
            this.chkRX2ANF.FlatAppearance.BorderSize = 0;
            this.chkRX2ANF.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRX2ANF.Name = "chkRX2ANF";
            this.toolTip1.SetToolTip(this.chkRX2ANF, resources.GetString("chkRX2ANF.ToolTip"));
            this.chkRX2ANF.CheckedChanged += new System.EventHandler(this.chkRX2ANF_CheckedChanged);
            // 
            // comboRX2AGC
            // 
            this.comboRX2AGC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboRX2AGC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRX2AGC.DropDownWidth = 48;
            resources.ApplyResources(this.comboRX2AGC, "comboRX2AGC");
            this.comboRX2AGC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboRX2AGC.Name = "comboRX2AGC";
            this.toolTip1.SetToolTip(this.comboRX2AGC, resources.GetString("comboRX2AGC.ToolTip"));
            this.comboRX2AGC.SelectedIndexChanged += new System.EventHandler(this.comboRX2AGC_SelectedIndexChanged);
            // 
            // chkRX2BIN
            // 
            resources.ApplyResources(this.chkRX2BIN, "chkRX2BIN");
            this.chkRX2BIN.FlatAppearance.BorderSize = 0;
            this.chkRX2BIN.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRX2BIN.Name = "chkRX2BIN";
            this.toolTip1.SetToolTip(this.chkRX2BIN, resources.GetString("chkRX2BIN.ToolTip"));
            this.chkRX2BIN.CheckedChanged += new System.EventHandler(this.chkRX2BIN_CheckedChanged);
            // 
            // chkExternalPA
            // 
            resources.ApplyResources(this.chkExternalPA, "chkExternalPA");
            this.chkExternalPA.FlatAppearance.BorderSize = 0;
            this.chkExternalPA.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkExternalPA.Name = "chkExternalPA";
            this.toolTip1.SetToolTip(this.chkExternalPA, resources.GetString("chkExternalPA.ToolTip"));
            this.chkExternalPA.CheckedChanged += new System.EventHandler(this.chkExternalPA_CheckedChanged);
            this.chkExternalPA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkExternalPA_MouseDown);
            // 
            // ckQuickPlay
            // 
            resources.ApplyResources(this.ckQuickPlay, "ckQuickPlay");
            this.ckQuickPlay.BackColor = System.Drawing.Color.Transparent;
            this.ckQuickPlay.FlatAppearance.BorderSize = 0;
            this.ckQuickPlay.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ckQuickPlay.Name = "ckQuickPlay";
            this.toolTip1.SetToolTip(this.ckQuickPlay, resources.GetString("ckQuickPlay.ToolTip"));
            this.ckQuickPlay.UseVisualStyleBackColor = false;
            this.ckQuickPlay.CheckedChanged += new System.EventHandler(this.ckQuickPlay_CheckedChanged);
            // 
            // chkMON
            // 
            resources.ApplyResources(this.chkMON, "chkMON");
            this.chkMON.FlatAppearance.BorderSize = 0;
            this.chkMON.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkMON.Name = "chkMON";
            this.toolTip1.SetToolTip(this.chkMON, resources.GetString("chkMON.ToolTip"));
            this.chkMON.CheckedChanged += new System.EventHandler(this.chkMON_CheckedChanged);
            this.chkMON.Click += new System.EventHandler(this.chkMON_Click);
            // 
            // ckQuickRec
            // 
            resources.ApplyResources(this.ckQuickRec, "ckQuickRec");
            this.ckQuickRec.BackColor = System.Drawing.Color.Transparent;
            this.ckQuickRec.FlatAppearance.BorderSize = 0;
            this.ckQuickRec.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ckQuickRec.Name = "ckQuickRec";
            this.toolTip1.SetToolTip(this.ckQuickRec, resources.GetString("ckQuickRec.ToolTip"));
            this.ckQuickRec.UseVisualStyleBackColor = false;
            this.ckQuickRec.CheckedChanged += new System.EventHandler(this.ckQuickRec_CheckedChanged);
            // 
            // chkRX2SR
            // 
            resources.ApplyResources(this.chkRX2SR, "chkRX2SR");
            this.chkRX2SR.BackColor = System.Drawing.Color.Transparent;
            this.chkRX2SR.FlatAppearance.BorderSize = 0;
            this.chkRX2SR.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRX2SR.Name = "chkRX2SR";
            this.toolTip1.SetToolTip(this.chkRX2SR, resources.GetString("chkRX2SR.ToolTip"));
            this.chkRX2SR.UseVisualStyleBackColor = false;
            this.chkRX2SR.CheckedChanged += new System.EventHandler(this.chkRX2SR_CheckedChanged);
            // 
            // chkMOX
            // 
            resources.ApplyResources(this.chkMOX, "chkMOX");
            this.chkMOX.FlatAppearance.BorderSize = 0;
            this.chkMOX.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkMOX.Name = "chkMOX";
            this.toolTip1.SetToolTip(this.chkMOX, resources.GetString("chkMOX.ToolTip"));
            this.chkMOX.CheckedChanged += new System.EventHandler(this.chkMOX_CheckedChanged2);
            this.chkMOX.Click += new System.EventHandler(this.chkMOX_Click);
            // 
            // chkTUN
            // 
            resources.ApplyResources(this.chkTUN, "chkTUN");
            this.chkTUN.FlatAppearance.BorderSize = 0;
            this.chkTUN.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkTUN.Name = "chkTUN";
            this.toolTip1.SetToolTip(this.chkTUN, resources.GetString("chkTUN.ToolTip"));
            this.chkTUN.CheckedChanged += new System.EventHandler(this.chkTUN_CheckedChanged);
            this.chkTUN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkTUN_MouseDown);
            // 
            // chk2TONE
            // 
            resources.ApplyResources(this.chk2TONE, "chk2TONE");
            this.chk2TONE.BackColor = System.Drawing.Color.Transparent;
            this.chk2TONE.FlatAppearance.BorderSize = 0;
            this.chk2TONE.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chk2TONE.Name = "chk2TONE";
            this.toolTip1.SetToolTip(this.chk2TONE, resources.GetString("chk2TONE.ToolTip"));
            this.chk2TONE.UseVisualStyleBackColor = false;
            this.chk2TONE.CheckedChanged += new System.EventHandler(this.chk2TONE_CheckedChanged);
            this.chk2TONE.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chk2TONE_MouseDown);
            // 
            // chkFWCATUBypass
            // 
            resources.ApplyResources(this.chkFWCATUBypass, "chkFWCATUBypass");
            this.chkFWCATUBypass.FlatAppearance.BorderSize = 0;
            this.chkFWCATUBypass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkFWCATUBypass.Name = "chkFWCATUBypass";
            this.toolTip1.SetToolTip(this.chkFWCATUBypass, resources.GetString("chkFWCATUBypass.ToolTip"));
            this.chkFWCATUBypass.CheckedChanged += new System.EventHandler(this.chkFWCATUBypass_CheckedChanged);
            this.chkFWCATUBypass.Click += new System.EventHandler(this.chkFWCATUBypass_Click);
            this.chkFWCATUBypass.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkFWCATUBypass_MouseDown);
            // 
            // comboTuneMode
            // 
            this.comboTuneMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboTuneMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTuneMode.DropDownWidth = 42;
            resources.ApplyResources(this.comboTuneMode, "comboTuneMode");
            this.comboTuneMode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboTuneMode.Items.AddRange(new object[] {
            resources.GetString("comboTuneMode.Items"),
            resources.GetString("comboTuneMode.Items1"),
            resources.GetString("comboTuneMode.Items2")});
            this.comboTuneMode.Name = "comboTuneMode";
            this.toolTip1.SetToolTip(this.comboTuneMode, resources.GetString("comboTuneMode.ToolTip"));
            this.comboTuneMode.SelectedIndexChanged += new System.EventHandler(this.comboTuneMode_SelectedIndexChanged);
            // 
            // udTXFilterLow
            // 
            this.udTXFilterLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            resources.ApplyResources(this.udTXFilterLow, "udTXFilterLow");
            this.udTXFilterLow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.udTXFilterLow.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udTXFilterLow.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.udTXFilterLow.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udTXFilterLow.Name = "udTXFilterLow";
            this.udTXFilterLow.TinyStep = false;
            this.toolTip1.SetToolTip(this.udTXFilterLow, resources.GetString("udTXFilterLow.ToolTip"));
            this.udTXFilterLow.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udTXFilterLow.ValueChanged += new System.EventHandler(this.udTXFilterLow_ValueChanged);
            // 
            // udTXFilterHigh
            // 
            this.udTXFilterHigh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            resources.ApplyResources(this.udTXFilterHigh, "udTXFilterHigh");
            this.udTXFilterHigh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.udTXFilterHigh.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udTXFilterHigh.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.udTXFilterHigh.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udTXFilterHigh.Name = "udTXFilterHigh";
            this.udTXFilterHigh.TinyStep = false;
            this.toolTip1.SetToolTip(this.udTXFilterHigh, resources.GetString("udTXFilterHigh.ToolTip"));
            this.udTXFilterHigh.Value = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.udTXFilterHigh.ValueChanged += new System.EventHandler(this.udTXFilterHigh_ValueChanged);
            // 
            // chkMicMute
            // 
            resources.ApplyResources(this.chkMicMute, "chkMicMute");
            this.chkMicMute.Checked = true;
            this.chkMicMute.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMicMute.FlatAppearance.BorderSize = 0;
            this.chkMicMute.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkMicMute.Name = "chkMicMute";
            this.toolTip1.SetToolTip(this.chkMicMute, resources.GetString("chkMicMute.ToolTip"));
            this.chkMicMute.CheckedChanged += new System.EventHandler(this.chkMicMute_CheckedChanged);
            this.chkMicMute.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkMicMute_MouseDown);
            // 
            // chkShowTXFilter
            // 
            resources.ApplyResources(this.chkShowTXFilter, "chkShowTXFilter");
            this.chkShowTXFilter.FlatAppearance.BorderSize = 0;
            this.chkShowTXFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkShowTXFilter.Name = "chkShowTXFilter";
            this.toolTip1.SetToolTip(this.chkShowTXFilter, resources.GetString("chkShowTXFilter.ToolTip"));
            this.chkShowTXFilter.CheckedChanged += new System.EventHandler(this.chkShowTXFilter_CheckedChanged);
            // 
            // chkTXEQ
            // 
            resources.ApplyResources(this.chkTXEQ, "chkTXEQ");
            this.chkTXEQ.FlatAppearance.BorderSize = 0;
            this.chkTXEQ.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkTXEQ.Name = "chkTXEQ";
            this.toolTip1.SetToolTip(this.chkTXEQ, resources.GetString("chkTXEQ.ToolTip"));
            this.chkTXEQ.CheckedChanged += new System.EventHandler(this.chkTXEQ_CheckedChanged);
            this.chkTXEQ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkTXEQ_MouseDown);
            // 
            // chkRXEQ
            // 
            resources.ApplyResources(this.chkRXEQ, "chkRXEQ");
            this.chkRXEQ.FlatAppearance.BorderSize = 0;
            this.chkRXEQ.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRXEQ.Name = "chkRXEQ";
            this.toolTip1.SetToolTip(this.chkRXEQ, resources.GetString("chkRXEQ.ToolTip"));
            this.chkRXEQ.CheckedChanged += new System.EventHandler(this.chkRXEQ_CheckedChanged);
            this.chkRXEQ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkRXEQ_MouseDown);
            // 
            // chkCPDR
            // 
            resources.ApplyResources(this.chkCPDR, "chkCPDR");
            this.chkCPDR.FlatAppearance.BorderSize = 0;
            this.chkCPDR.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkCPDR.Name = "chkCPDR";
            this.toolTip1.SetToolTip(this.chkCPDR, resources.GetString("chkCPDR.ToolTip"));
            this.chkCPDR.CheckedChanged += new System.EventHandler(this.chkCPDR_CheckedChanged);
            this.chkCPDR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkCPDR_MouseDown);
            // 
            // chkVOX
            // 
            resources.ApplyResources(this.chkVOX, "chkVOX");
            this.chkVOX.FlatAppearance.BorderSize = 0;
            this.chkVOX.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkVOX.Name = "chkVOX";
            this.toolTip1.SetToolTip(this.chkVOX, resources.GetString("chkVOX.ToolTip"));
            this.chkVOX.CheckedChanged += new System.EventHandler(this.chkVOX_CheckedChanged);
            this.chkVOX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkVOX_MouseDown);
            // 
            // chkNoiseGate
            // 
            resources.ApplyResources(this.chkNoiseGate, "chkNoiseGate");
            this.chkNoiseGate.FlatAppearance.BorderSize = 0;
            this.chkNoiseGate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkNoiseGate.Name = "chkNoiseGate";
            this.toolTip1.SetToolTip(this.chkNoiseGate, resources.GetString("chkNoiseGate.ToolTip"));
            this.chkNoiseGate.CheckedChanged += new System.EventHandler(this.chkNoiseGate_CheckedChanged);
            this.chkNoiseGate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkNoiseGate_MouseDown);
            // 
            // comboTXProfile
            // 
            this.comboTXProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboTXProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTXProfile.DropDownWidth = 96;
            resources.ApplyResources(this.comboTXProfile, "comboTXProfile");
            this.comboTXProfile.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboTXProfile.Name = "comboTXProfile";
            this.toolTip1.SetToolTip(this.comboTXProfile, resources.GetString("comboTXProfile.ToolTip"));
            this.comboTXProfile.SelectedIndexChanged += new System.EventHandler(this.comboTXProfile_SelectedIndexChanged);
            this.comboTXProfile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboTXProfile_MouseDown);
            // 
            // comboAMTXProfile
            // 
            this.comboAMTXProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboAMTXProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAMTXProfile.DropDownWidth = 96;
            resources.ApplyResources(this.comboAMTXProfile, "comboAMTXProfile");
            this.comboAMTXProfile.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboAMTXProfile.Name = "comboAMTXProfile";
            this.toolTip1.SetToolTip(this.comboAMTXProfile, resources.GetString("comboAMTXProfile.ToolTip"));
            this.comboAMTXProfile.SelectedIndexChanged += new System.EventHandler(this.comboAMTXProfile_SelectedIndexChanged);
            // 
            // chkX2TR
            // 
            resources.ApplyResources(this.chkX2TR, "chkX2TR");
            this.chkX2TR.FlatAppearance.BorderSize = 0;
            this.chkX2TR.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkX2TR.Name = "chkX2TR";
            this.toolTip1.SetToolTip(this.chkX2TR, resources.GetString("chkX2TR.ToolTip"));
            this.chkX2TR.CheckedChanged += new System.EventHandler(this.chkX2TR_CheckedChanged);
            this.chkX2TR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkX2TR_MouseUp);
            // 
            // chkFWCATU
            // 
            resources.ApplyResources(this.chkFWCATU, "chkFWCATU");
            this.chkFWCATU.FlatAppearance.BorderSize = 0;
            this.chkFWCATU.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkFWCATU.Name = "chkFWCATU";
            this.toolTip1.SetToolTip(this.chkFWCATU, resources.GetString("chkFWCATU.ToolTip"));
            this.chkFWCATU.CheckedChanged += new System.EventHandler(this.chkFWCATU_CheckedChanged);
            this.chkFWCATU.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkFWCATU_MouseUp);
            // 
            // comboRX2Band
            // 
            this.comboRX2Band.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboRX2Band.DisplayMember = "0";
            this.comboRX2Band.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRX2Band.DropDownWidth = 56;
            resources.ApplyResources(this.comboRX2Band, "comboRX2Band");
            this.comboRX2Band.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboRX2Band.Items.AddRange(new object[] {
            resources.GetString("comboRX2Band.Items"),
            resources.GetString("comboRX2Band.Items1"),
            resources.GetString("comboRX2Band.Items2"),
            resources.GetString("comboRX2Band.Items3"),
            resources.GetString("comboRX2Band.Items4"),
            resources.GetString("comboRX2Band.Items5"),
            resources.GetString("comboRX2Band.Items6"),
            resources.GetString("comboRX2Band.Items7"),
            resources.GetString("comboRX2Band.Items8"),
            resources.GetString("comboRX2Band.Items9"),
            resources.GetString("comboRX2Band.Items10"),
            resources.GetString("comboRX2Band.Items11"),
            resources.GetString("comboRX2Band.Items12")});
            this.comboRX2Band.Name = "comboRX2Band";
            this.toolTip1.SetToolTip(this.comboRX2Band, resources.GetString("comboRX2Band.ToolTip"));
            this.comboRX2Band.SelectedIndexChanged += new System.EventHandler(this.comboRX2Band_SelectedIndexChanged);
            // 
            // chkRX2Preamp
            // 
            resources.ApplyResources(this.chkRX2Preamp, "chkRX2Preamp");
            this.chkRX2Preamp.FlatAppearance.BorderSize = 0;
            this.chkRX2Preamp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRX2Preamp.Name = "chkRX2Preamp";
            this.toolTip1.SetToolTip(this.chkRX2Preamp, resources.GetString("chkRX2Preamp.ToolTip"));
            this.chkRX2Preamp.CheckedChanged += new System.EventHandler(this.chkRX2Preamp_CheckedChanged);
            // 
            // chkPower
            // 
            resources.ApplyResources(this.chkPower, "chkPower");
            this.chkPower.BackColor = System.Drawing.SystemColors.Control;
            this.chkPower.FlatAppearance.BorderSize = 0;
            this.chkPower.Name = "chkPower";
            this.toolTip1.SetToolTip(this.chkPower, resources.GetString("chkPower.ToolTip"));
            this.chkPower.UseVisualStyleBackColor = false;
            this.chkPower.CheckedChanged += new System.EventHandler(this.chkPower_CheckedChanged);
            // 
            // udCWPitch
            // 
            this.udCWPitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.udCWPitch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.udCWPitch.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            resources.ApplyResources(this.udCWPitch, "udCWPitch");
            this.udCWPitch.Maximum = new decimal(new int[] {
            2250,
            0,
            0,
            0});
            this.udCWPitch.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.udCWPitch.Name = "udCWPitch";
            this.udCWPitch.TinyStep = false;
            this.toolTip1.SetToolTip(this.udCWPitch, resources.GetString("udCWPitch.ToolTip"));
            this.udCWPitch.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.udCWPitch.ValueChanged += new System.EventHandler(this.udCWPitch_ValueChanged);
            // 
            // udCWBreakInDelay
            // 
            this.udCWBreakInDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.udCWBreakInDelay.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.udCWBreakInDelay.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            resources.ApplyResources(this.udCWBreakInDelay, "udCWBreakInDelay");
            this.udCWBreakInDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udCWBreakInDelay.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udCWBreakInDelay.Name = "udCWBreakInDelay";
            this.udCWBreakInDelay.TinyStep = false;
            this.toolTip1.SetToolTip(this.udCWBreakInDelay, resources.GetString("udCWBreakInDelay.ToolTip"));
            this.udCWBreakInDelay.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.udCWBreakInDelay.ValueChanged += new System.EventHandler(this.udCWBreakInDelay_ValueChanged);
            this.udCWBreakInDelay.LostFocus += new System.EventHandler(this.udCWBreakInDelay_LostFocus);
            // 
            // chkShowTXCWFreq
            // 
            this.chkShowTXCWFreq.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.chkShowTXCWFreq, "chkShowTXCWFreq");
            this.chkShowTXCWFreq.Name = "chkShowTXCWFreq";
            this.toolTip1.SetToolTip(this.chkShowTXCWFreq, resources.GetString("chkShowTXCWFreq.ToolTip"));
            this.chkShowTXCWFreq.CheckedChanged += new System.EventHandler(this.chkShowTXCWFreq_CheckedChanged);
            // 
            // chkCWIambic
            // 
            this.chkCWIambic.Checked = true;
            this.chkCWIambic.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.chkCWIambic, "chkCWIambic");
            this.chkCWIambic.ForeColor = System.Drawing.Color.White;
            this.chkCWIambic.Name = "chkCWIambic";
            this.toolTip1.SetToolTip(this.chkCWIambic, resources.GetString("chkCWIambic.ToolTip"));
            this.chkCWIambic.CheckedChanged += new System.EventHandler(this.chkCWIambic_CheckedChanged);
            // 
            // udRX2FilterHigh
            // 
            this.udRX2FilterHigh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            resources.ApplyResources(this.udRX2FilterHigh, "udRX2FilterHigh");
            this.udRX2FilterHigh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.udRX2FilterHigh.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udRX2FilterHigh.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udRX2FilterHigh.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.udRX2FilterHigh.Name = "udRX2FilterHigh";
            this.udRX2FilterHigh.TinyStep = false;
            this.toolTip1.SetToolTip(this.udRX2FilterHigh, resources.GetString("udRX2FilterHigh.ToolTip"));
            this.udRX2FilterHigh.Value = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.udRX2FilterHigh.ValueChanged += new System.EventHandler(this.udRX2FilterHigh_ValueChanged);
            // 
            // udRX2FilterLow
            // 
            this.udRX2FilterLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            resources.ApplyResources(this.udRX2FilterLow, "udRX2FilterLow");
            this.udRX2FilterLow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.udRX2FilterLow.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udRX2FilterLow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udRX2FilterLow.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.udRX2FilterLow.Name = "udRX2FilterLow";
            this.udRX2FilterLow.TinyStep = false;
            this.toolTip1.SetToolTip(this.udRX2FilterLow, resources.GetString("udRX2FilterLow.ToolTip"));
            this.udRX2FilterLow.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRX2FilterLow.ValueChanged += new System.EventHandler(this.udRX2FilterLow_ValueChanged);
            // 
            // radRX2ModeAM
            // 
            resources.ApplyResources(this.radRX2ModeAM, "radRX2ModeAM");
            this.radRX2ModeAM.FlatAppearance.BorderSize = 0;
            this.radRX2ModeAM.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2ModeAM.Name = "radRX2ModeAM";
            this.toolTip1.SetToolTip(this.radRX2ModeAM, resources.GetString("radRX2ModeAM.ToolTip"));
            this.radRX2ModeAM.CheckedChanged += new System.EventHandler(this.radRX2ModeButton_CheckedChanged);
            // 
            // radRX2ModeLSB
            // 
            resources.ApplyResources(this.radRX2ModeLSB, "radRX2ModeLSB");
            this.radRX2ModeLSB.FlatAppearance.BorderSize = 0;
            this.radRX2ModeLSB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2ModeLSB.Name = "radRX2ModeLSB";
            this.toolTip1.SetToolTip(this.radRX2ModeLSB, resources.GetString("radRX2ModeLSB.ToolTip"));
            this.radRX2ModeLSB.CheckedChanged += new System.EventHandler(this.radRX2ModeButton_CheckedChanged);
            // 
            // radRX2ModeSAM
            // 
            resources.ApplyResources(this.radRX2ModeSAM, "radRX2ModeSAM");
            this.radRX2ModeSAM.FlatAppearance.BorderSize = 0;
            this.radRX2ModeSAM.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2ModeSAM.Name = "radRX2ModeSAM";
            this.toolTip1.SetToolTip(this.radRX2ModeSAM, resources.GetString("radRX2ModeSAM.ToolTip"));
            this.radRX2ModeSAM.CheckedChanged += new System.EventHandler(this.radRX2ModeButton_CheckedChanged);
            // 
            // radRX2ModeCWL
            // 
            resources.ApplyResources(this.radRX2ModeCWL, "radRX2ModeCWL");
            this.radRX2ModeCWL.FlatAppearance.BorderSize = 0;
            this.radRX2ModeCWL.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2ModeCWL.Name = "radRX2ModeCWL";
            this.toolTip1.SetToolTip(this.radRX2ModeCWL, resources.GetString("radRX2ModeCWL.ToolTip"));
            this.radRX2ModeCWL.CheckedChanged += new System.EventHandler(this.radRX2ModeButton_CheckedChanged);
            // 
            // radRX2ModeDSB
            // 
            resources.ApplyResources(this.radRX2ModeDSB, "radRX2ModeDSB");
            this.radRX2ModeDSB.FlatAppearance.BorderSize = 0;
            this.radRX2ModeDSB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2ModeDSB.Name = "radRX2ModeDSB";
            this.toolTip1.SetToolTip(this.radRX2ModeDSB, resources.GetString("radRX2ModeDSB.ToolTip"));
            this.radRX2ModeDSB.CheckedChanged += new System.EventHandler(this.radRX2ModeButton_CheckedChanged);
            // 
            // radRX2ModeUSB
            // 
            resources.ApplyResources(this.radRX2ModeUSB, "radRX2ModeUSB");
            this.radRX2ModeUSB.BackColor = System.Drawing.Color.Transparent;
            this.radRX2ModeUSB.FlatAppearance.BorderSize = 0;
            this.radRX2ModeUSB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2ModeUSB.Name = "radRX2ModeUSB";
            this.toolTip1.SetToolTip(this.radRX2ModeUSB, resources.GetString("radRX2ModeUSB.ToolTip"));
            this.radRX2ModeUSB.UseVisualStyleBackColor = false;
            this.radRX2ModeUSB.CheckedChanged += new System.EventHandler(this.radRX2ModeButton_CheckedChanged);
            // 
            // radRX2ModeCWU
            // 
            resources.ApplyResources(this.radRX2ModeCWU, "radRX2ModeCWU");
            this.radRX2ModeCWU.FlatAppearance.BorderSize = 0;
            this.radRX2ModeCWU.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2ModeCWU.Name = "radRX2ModeCWU";
            this.toolTip1.SetToolTip(this.radRX2ModeCWU, resources.GetString("radRX2ModeCWU.ToolTip"));
            this.radRX2ModeCWU.CheckedChanged += new System.EventHandler(this.radRX2ModeButton_CheckedChanged);
            // 
            // radRX2ModeFMN
            // 
            resources.ApplyResources(this.radRX2ModeFMN, "radRX2ModeFMN");
            this.radRX2ModeFMN.FlatAppearance.BorderSize = 0;
            this.radRX2ModeFMN.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2ModeFMN.Name = "radRX2ModeFMN";
            this.toolTip1.SetToolTip(this.radRX2ModeFMN, resources.GetString("radRX2ModeFMN.ToolTip"));
            this.radRX2ModeFMN.CheckedChanged += new System.EventHandler(this.radRX2ModeButton_CheckedChanged);
            // 
            // radRX2ModeDIGU
            // 
            resources.ApplyResources(this.radRX2ModeDIGU, "radRX2ModeDIGU");
            this.radRX2ModeDIGU.FlatAppearance.BorderSize = 0;
            this.radRX2ModeDIGU.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2ModeDIGU.Name = "radRX2ModeDIGU";
            this.toolTip1.SetToolTip(this.radRX2ModeDIGU, resources.GetString("radRX2ModeDIGU.ToolTip"));
            this.radRX2ModeDIGU.CheckedChanged += new System.EventHandler(this.radRX2ModeButton_CheckedChanged);
            // 
            // radRX2ModeDRM
            // 
            resources.ApplyResources(this.radRX2ModeDRM, "radRX2ModeDRM");
            this.radRX2ModeDRM.FlatAppearance.BorderSize = 0;
            this.radRX2ModeDRM.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2ModeDRM.Name = "radRX2ModeDRM";
            this.toolTip1.SetToolTip(this.radRX2ModeDRM, resources.GetString("radRX2ModeDRM.ToolTip"));
            this.radRX2ModeDRM.CheckedChanged += new System.EventHandler(this.radRX2ModeButton_CheckedChanged);
            // 
            // radRX2ModeDIGL
            // 
            resources.ApplyResources(this.radRX2ModeDIGL, "radRX2ModeDIGL");
            this.radRX2ModeDIGL.FlatAppearance.BorderSize = 0;
            this.radRX2ModeDIGL.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2ModeDIGL.Name = "radRX2ModeDIGL";
            this.toolTip1.SetToolTip(this.radRX2ModeDIGL, resources.GetString("radRX2ModeDIGL.ToolTip"));
            this.radRX2ModeDIGL.CheckedChanged += new System.EventHandler(this.radRX2ModeButton_CheckedChanged);
            // 
            // radRX2ModeSPEC
            // 
            resources.ApplyResources(this.radRX2ModeSPEC, "radRX2ModeSPEC");
            this.radRX2ModeSPEC.FlatAppearance.BorderSize = 0;
            this.radRX2ModeSPEC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2ModeSPEC.Name = "radRX2ModeSPEC";
            this.toolTip1.SetToolTip(this.radRX2ModeSPEC, resources.GetString("radRX2ModeSPEC.ToolTip"));
            this.radRX2ModeSPEC.CheckedChanged += new System.EventHandler(this.radRX2ModeButton_CheckedChanged);
            // 
            // chkRX2DisplayPeak
            // 
            resources.ApplyResources(this.chkRX2DisplayPeak, "chkRX2DisplayPeak");
            this.chkRX2DisplayPeak.FlatAppearance.BorderSize = 0;
            this.chkRX2DisplayPeak.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRX2DisplayPeak.Name = "chkRX2DisplayPeak";
            this.toolTip1.SetToolTip(this.chkRX2DisplayPeak, resources.GetString("chkRX2DisplayPeak.ToolTip"));
            this.chkRX2DisplayPeak.CheckedChanged += new System.EventHandler(this.chkRX2DisplayPeak_CheckedChanged);
            // 
            // comboRX2DisplayMode
            // 
            this.comboRX2DisplayMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboRX2DisplayMode.DisplayMember = "0";
            this.comboRX2DisplayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRX2DisplayMode.DropDownWidth = 88;
            resources.ApplyResources(this.comboRX2DisplayMode, "comboRX2DisplayMode");
            this.comboRX2DisplayMode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboRX2DisplayMode.Items.AddRange(new object[] {
            resources.GetString("comboRX2DisplayMode.Items"),
            resources.GetString("comboRX2DisplayMode.Items1"),
            resources.GetString("comboRX2DisplayMode.Items2"),
            resources.GetString("comboRX2DisplayMode.Items3")});
            this.comboRX2DisplayMode.Name = "comboRX2DisplayMode";
            this.toolTip1.SetToolTip(this.comboRX2DisplayMode, resources.GetString("comboRX2DisplayMode.ToolTip"));
            this.comboRX2DisplayMode.SelectedIndexChanged += new System.EventHandler(this.comboRX2DisplayMode_SelectedIndexChanged);
            // 
            // chkPanSwap
            // 
            resources.ApplyResources(this.chkPanSwap, "chkPanSwap");
            this.chkPanSwap.FlatAppearance.BorderSize = 0;
            this.chkPanSwap.ForeColor = System.Drawing.Color.White;
            this.chkPanSwap.Name = "chkPanSwap";
            this.toolTip1.SetToolTip(this.chkPanSwap, resources.GetString("chkPanSwap.ToolTip"));
            this.chkPanSwap.CheckedChanged += new System.EventHandler(this.chkPanSwap_CheckedChanged);
            // 
            // chkEnableMultiRX
            // 
            resources.ApplyResources(this.chkEnableMultiRX, "chkEnableMultiRX");
            this.chkEnableMultiRX.FlatAppearance.BorderSize = 0;
            this.chkEnableMultiRX.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkEnableMultiRX.Name = "chkEnableMultiRX";
            this.toolTip1.SetToolTip(this.chkEnableMultiRX, resources.GetString("chkEnableMultiRX.ToolTip"));
            this.chkEnableMultiRX.CheckedChanged += new System.EventHandler(this.chkEnableMultiRX_CheckedChanged);
            this.chkEnableMultiRX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkEnableMultiRX_MouseDown);
            // 
            // chkDisplayPeak
            // 
            resources.ApplyResources(this.chkDisplayPeak, "chkDisplayPeak");
            this.chkDisplayPeak.FlatAppearance.BorderSize = 0;
            this.chkDisplayPeak.Name = "chkDisplayPeak";
            this.toolTip1.SetToolTip(this.chkDisplayPeak, resources.GetString("chkDisplayPeak.ToolTip"));
            this.chkDisplayPeak.CheckedChanged += new System.EventHandler(this.chkDisplayPeak_CheckedChanged);
            // 
            // comboDisplayMode
            // 
            this.comboDisplayMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboDisplayMode.DisplayMember = "0";
            this.comboDisplayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDisplayMode.DropDownWidth = 88;
            resources.ApplyResources(this.comboDisplayMode, "comboDisplayMode");
            this.comboDisplayMode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboDisplayMode.Name = "comboDisplayMode";
            this.toolTip1.SetToolTip(this.comboDisplayMode, resources.GetString("comboDisplayMode.ToolTip"));
            this.comboDisplayMode.SelectedIndexChanged += new System.EventHandler(this.comboDisplayMode_SelectedIndexChanged);
            // 
            // chkDisplayAVG
            // 
            resources.ApplyResources(this.chkDisplayAVG, "chkDisplayAVG");
            this.chkDisplayAVG.FlatAppearance.BorderSize = 0;
            this.chkDisplayAVG.Name = "chkDisplayAVG";
            this.toolTip1.SetToolTip(this.chkDisplayAVG, resources.GetString("chkDisplayAVG.ToolTip"));
            this.chkDisplayAVG.CheckedChanged += new System.EventHandler(this.chkDisplayAVG_CheckedChanged);
            // 
            // chkNR
            // 
            resources.ApplyResources(this.chkNR, "chkNR");
            this.chkNR.FlatAppearance.BorderSize = 0;
            this.chkNR.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkNR.Name = "chkNR";
            this.chkNR.ThreeState = true;
            this.toolTip1.SetToolTip(this.chkNR, resources.GetString("chkNR.ToolTip"));
            this.chkNR.CheckStateChanged += new System.EventHandler(this.chkNR_CheckStateChanged);
            this.chkNR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkNR_MouseDown);
            // 
            // chkDSPNB2
            // 
            resources.ApplyResources(this.chkDSPNB2, "chkDSPNB2");
            this.chkDSPNB2.FlatAppearance.BorderSize = 0;
            this.chkDSPNB2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkDSPNB2.Name = "chkDSPNB2";
            this.toolTip1.SetToolTip(this.chkDSPNB2, resources.GetString("chkDSPNB2.ToolTip"));
            this.chkDSPNB2.CheckedChanged += new System.EventHandler(this.chkDSPNB2_CheckedChanged);
            this.chkDSPNB2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkDSPNB2_MouseDown);
            // 
            // chkBIN
            // 
            resources.ApplyResources(this.chkBIN, "chkBIN");
            this.chkBIN.FlatAppearance.BorderSize = 0;
            this.chkBIN.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkBIN.Name = "chkBIN";
            this.toolTip1.SetToolTip(this.chkBIN, resources.GetString("chkBIN.ToolTip"));
            this.chkBIN.CheckedChanged += new System.EventHandler(this.chkBIN_CheckedChanged);
            // 
            // chkNB
            // 
            resources.ApplyResources(this.chkNB, "chkNB");
            this.chkNB.FlatAppearance.BorderSize = 0;
            this.chkNB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkNB.Name = "chkNB";
            this.chkNB.ThreeState = true;
            this.toolTip1.SetToolTip(this.chkNB, resources.GetString("chkNB.ToolTip"));
            this.chkNB.CheckStateChanged += new System.EventHandler(this.chkNB_CheckStateChanged);
            this.chkNB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkNB_MouseDown);
            // 
            // chkANF
            // 
            resources.ApplyResources(this.chkANF, "chkANF");
            this.chkANF.FlatAppearance.BorderSize = 0;
            this.chkANF.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkANF.Name = "chkANF";
            this.toolTip1.SetToolTip(this.chkANF, resources.GetString("chkANF.ToolTip"));
            this.chkANF.CheckedChanged += new System.EventHandler(this.chkANF_CheckedChanged);
            // 
            // btnZeroBeat
            // 
            this.btnZeroBeat.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnZeroBeat, "btnZeroBeat");
            this.btnZeroBeat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnZeroBeat.Name = "btnZeroBeat";
            this.btnZeroBeat.Selectable = true;
            this.toolTip1.SetToolTip(this.btnZeroBeat, resources.GetString("btnZeroBeat.ToolTip"));
            this.btnZeroBeat.Click += new System.EventHandler(this.btnZeroBeat_Click);
            // 
            // chkVFOSplit
            // 
            resources.ApplyResources(this.chkVFOSplit, "chkVFOSplit");
            this.chkVFOSplit.AutoCheck = false;
            this.chkVFOSplit.FlatAppearance.BorderSize = 0;
            this.chkVFOSplit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkVFOSplit.Name = "chkVFOSplit";
            this.toolTip1.SetToolTip(this.chkVFOSplit, resources.GetString("chkVFOSplit.ToolTip"));
            this.chkVFOSplit.CheckedChanged += new System.EventHandler(this.chkVFOSplit_CheckedChanged);
            this.chkVFOSplit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkVFOSplit_MouseClick);
            this.chkVFOSplit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkVFOSplit_MouseDown);
            // 
            // btnRITReset
            // 
            this.btnRITReset.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnRITReset, "btnRITReset");
            this.btnRITReset.Name = "btnRITReset";
            this.btnRITReset.Selectable = true;
            this.toolTip1.SetToolTip(this.btnRITReset, resources.GetString("btnRITReset.ToolTip"));
            this.btnRITReset.Click += new System.EventHandler(this.btnRITReset_Click);
            // 
            // btnXITReset
            // 
            this.btnXITReset.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnXITReset, "btnXITReset");
            this.btnXITReset.Name = "btnXITReset";
            this.btnXITReset.Selectable = true;
            this.toolTip1.SetToolTip(this.btnXITReset, resources.GetString("btnXITReset.ToolTip"));
            this.btnXITReset.Click += new System.EventHandler(this.btnXITReset_Click);
            // 
            // udRIT
            // 
            this.udRIT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            resources.ApplyResources(this.udRIT, "udRIT");
            this.udRIT.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.udRIT.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRIT.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.udRIT.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.udRIT.Name = "udRIT";
            this.udRIT.TinyStep = false;
            this.toolTip1.SetToolTip(this.udRIT, resources.GetString("udRIT.ToolTip"));
            this.udRIT.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRIT.ValueChanged += new System.EventHandler(this.udRIT_ValueChanged);
            this.udRIT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Console_KeyPress);
            this.udRIT.LostFocus += new System.EventHandler(this.udRIT_LostFocus);
            // 
            // btnIFtoVFO
            // 
            this.btnIFtoVFO.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnIFtoVFO, "btnIFtoVFO");
            this.btnIFtoVFO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnIFtoVFO.Name = "btnIFtoVFO";
            this.btnIFtoVFO.Selectable = true;
            this.toolTip1.SetToolTip(this.btnIFtoVFO, resources.GetString("btnIFtoVFO.ToolTip"));
            this.btnIFtoVFO.Click += new System.EventHandler(this.btnIFtoVFO_Click);
            // 
            // chkRIT
            // 
            resources.ApplyResources(this.chkRIT, "chkRIT");
            this.chkRIT.FlatAppearance.BorderSize = 0;
            this.chkRIT.Name = "chkRIT";
            this.toolTip1.SetToolTip(this.chkRIT, resources.GetString("chkRIT.ToolTip"));
            this.chkRIT.CheckedChanged += new System.EventHandler(this.chkRIT_CheckedChanged);
            // 
            // btnVFOSwap
            // 
            this.btnVFOSwap.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnVFOSwap, "btnVFOSwap");
            this.btnVFOSwap.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnVFOSwap.Name = "btnVFOSwap";
            this.btnVFOSwap.Selectable = true;
            this.toolTip1.SetToolTip(this.btnVFOSwap, resources.GetString("btnVFOSwap.ToolTip"));
            this.btnVFOSwap.Click += new System.EventHandler(this.btnVFOSwap_Click);
            // 
            // chkXIT
            // 
            resources.ApplyResources(this.chkXIT, "chkXIT");
            this.chkXIT.FlatAppearance.BorderSize = 0;
            this.chkXIT.Name = "chkXIT";
            this.toolTip1.SetToolTip(this.chkXIT, resources.GetString("chkXIT.ToolTip"));
            this.chkXIT.CheckedChanged += new System.EventHandler(this.chkXIT_CheckedChanged);
            // 
            // btnVFOBtoA
            // 
            this.btnVFOBtoA.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnVFOBtoA, "btnVFOBtoA");
            this.btnVFOBtoA.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnVFOBtoA.Name = "btnVFOBtoA";
            this.btnVFOBtoA.Selectable = true;
            this.toolTip1.SetToolTip(this.btnVFOBtoA, resources.GetString("btnVFOBtoA.ToolTip"));
            this.btnVFOBtoA.Click += new System.EventHandler(this.btnVFOBtoA_Click);
            // 
            // udXIT
            // 
            this.udXIT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            resources.ApplyResources(this.udXIT, "udXIT");
            this.udXIT.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.udXIT.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udXIT.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.udXIT.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.udXIT.Name = "udXIT";
            this.udXIT.TinyStep = false;
            this.toolTip1.SetToolTip(this.udXIT, resources.GetString("udXIT.ToolTip"));
            this.udXIT.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udXIT.ValueChanged += new System.EventHandler(this.udXIT_ValueChanged);
            this.udXIT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Console_KeyPress);
            this.udXIT.LostFocus += new System.EventHandler(this.udXIT_LostFocus);
            // 
            // btnVFOAtoB
            // 
            this.btnVFOAtoB.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnVFOAtoB, "btnVFOAtoB");
            this.btnVFOAtoB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnVFOAtoB.Name = "btnVFOAtoB";
            this.btnVFOAtoB.Selectable = true;
            this.toolTip1.SetToolTip(this.btnVFOAtoB, resources.GetString("btnVFOAtoB.ToolTip"));
            this.btnVFOAtoB.Click += new System.EventHandler(this.btnVFOAtoB_Click);
            // 
            // chkRX1Preamp
            // 
            resources.ApplyResources(this.chkRX1Preamp, "chkRX1Preamp");
            this.chkRX1Preamp.FlatAppearance.BorderSize = 0;
            this.chkRX1Preamp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRX1Preamp.Name = "chkRX1Preamp";
            this.toolTip1.SetToolTip(this.chkRX1Preamp, resources.GetString("chkRX1Preamp.ToolTip"));
            this.chkRX1Preamp.CheckedChanged += new System.EventHandler(this.chkRX1Preamp_CheckedChanged);
            // 
            // comboAGC
            // 
            this.comboAGC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboAGC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAGC.DropDownWidth = 48;
            resources.ApplyResources(this.comboAGC, "comboAGC");
            this.comboAGC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboAGC.Name = "comboAGC";
            this.toolTip1.SetToolTip(this.comboAGC, resources.GetString("comboAGC.ToolTip"));
            this.comboAGC.SelectedIndexChanged += new System.EventHandler(this.comboAGC_SelectedIndexChanged);
            this.comboAGC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboAGC_MouseDown);
            // 
            // lblAGC
            // 
            this.lblAGC.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblAGC, "lblAGC");
            this.lblAGC.Name = "lblAGC";
            this.toolTip1.SetToolTip(this.lblAGC, resources.GetString("lblAGC.ToolTip"));
            // 
            // comboPreamp
            // 
            this.comboPreamp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboPreamp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPreamp.DropDownWidth = 48;
            resources.ApplyResources(this.comboPreamp, "comboPreamp");
            this.comboPreamp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboPreamp.Name = "comboPreamp";
            this.toolTip1.SetToolTip(this.comboPreamp, resources.GetString("comboPreamp.ToolTip"));
            this.comboPreamp.SelectedIndexChanged += new System.EventHandler(this.comboPreamp_SelectedIndexChanged);
            // 
            // lblRF
            // 
            this.lblRF.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblRF, "lblRF");
            this.lblRF.Name = "lblRF";
            this.toolTip1.SetToolTip(this.lblRF, resources.GetString("lblRF.ToolTip"));
            this.lblRF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblRF_MouseDown);
            // 
            // chkDX
            // 
            resources.ApplyResources(this.chkDX, "chkDX");
            this.chkDX.FlatAppearance.BorderSize = 0;
            this.chkDX.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkDX.Name = "chkDX";
            this.toolTip1.SetToolTip(this.chkDX, resources.GetString("chkDX.ToolTip"));
            this.chkDX.CheckedChanged += new System.EventHandler(this.chkDX_CheckedChanged);
            // 
            // chkVAC1
            // 
            resources.ApplyResources(this.chkVAC1, "chkVAC1");
            this.chkVAC1.FlatAppearance.BorderSize = 0;
            this.chkVAC1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkVAC1.Name = "chkVAC1";
            this.toolTip1.SetToolTip(this.chkVAC1, resources.GetString("chkVAC1.ToolTip"));
            this.chkVAC1.CheckedChanged += new System.EventHandler(this.chkVAC1_CheckedChanged);
            this.chkVAC1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkVAC1_MouseDown);
            // 
            // comboDigTXProfile
            // 
            this.comboDigTXProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboDigTXProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDigTXProfile.DropDownWidth = 96;
            resources.ApplyResources(this.comboDigTXProfile, "comboDigTXProfile");
            this.comboDigTXProfile.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboDigTXProfile.Name = "comboDigTXProfile";
            this.toolTip1.SetToolTip(this.comboDigTXProfile, resources.GetString("comboDigTXProfile.ToolTip"));
            this.comboDigTXProfile.SelectedIndexChanged += new System.EventHandler(this.comboDigTXProfile_SelectedIndexChanged);
            // 
            // chkVACStereo
            // 
            this.chkVACStereo.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.chkVACStereo, "chkVACStereo");
            this.chkVACStereo.Name = "chkVACStereo";
            this.toolTip1.SetToolTip(this.chkVACStereo, resources.GetString("chkVACStereo.ToolTip"));
            this.chkVACStereo.CheckedChanged += new System.EventHandler(this.chkVACStereo_CheckedChanged);
            // 
            // comboVACSampleRate
            // 
            this.comboVACSampleRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboVACSampleRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVACSampleRate.DropDownWidth = 64;
            resources.ApplyResources(this.comboVACSampleRate, "comboVACSampleRate");
            this.comboVACSampleRate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboVACSampleRate.Items.AddRange(new object[] {
            resources.GetString("comboVACSampleRate.Items"),
            resources.GetString("comboVACSampleRate.Items1"),
            resources.GetString("comboVACSampleRate.Items2"),
            resources.GetString("comboVACSampleRate.Items3"),
            resources.GetString("comboVACSampleRate.Items4"),
            resources.GetString("comboVACSampleRate.Items5"),
            resources.GetString("comboVACSampleRate.Items6"),
            resources.GetString("comboVACSampleRate.Items7"),
            resources.GetString("comboVACSampleRate.Items8"),
            resources.GetString("comboVACSampleRate.Items9")});
            this.comboVACSampleRate.Name = "comboVACSampleRate";
            this.toolTip1.SetToolTip(this.comboVACSampleRate, resources.GetString("comboVACSampleRate.ToolTip"));
            this.comboVACSampleRate.SelectedIndexChanged += new System.EventHandler(this.comboVACSampleRate_SelectedIndexChanged);
            // 
            // btnDisplayPanCenter
            // 
            resources.ApplyResources(this.btnDisplayPanCenter, "btnDisplayPanCenter");
            this.btnDisplayPanCenter.FlatAppearance.BorderSize = 0;
            this.btnDisplayPanCenter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDisplayPanCenter.Name = "btnDisplayPanCenter";
            this.btnDisplayPanCenter.Selectable = true;
            this.btnDisplayPanCenter.Tag = "";
            this.toolTip1.SetToolTip(this.btnDisplayPanCenter, resources.GetString("btnDisplayPanCenter.ToolTip"));
            this.btnDisplayPanCenter.UseVisualStyleBackColor = false;
            this.btnDisplayPanCenter.Click += new System.EventHandler(this.btnDisplayPanCenter_Click);
            // 
            // radModeAM
            // 
            resources.ApplyResources(this.radModeAM, "radModeAM");
            this.radModeAM.FlatAppearance.BorderSize = 0;
            this.radModeAM.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radModeAM.Name = "radModeAM";
            this.toolTip1.SetToolTip(this.radModeAM, resources.GetString("radModeAM.ToolTip"));
            this.radModeAM.CheckedChanged += new System.EventHandler(this.radModeButton_CheckedChanged);
            this.radModeAM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radModeAM_MouseDown);
            // 
            // radModeLSB
            // 
            resources.ApplyResources(this.radModeLSB, "radModeLSB");
            this.radModeLSB.FlatAppearance.BorderSize = 0;
            this.radModeLSB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radModeLSB.Name = "radModeLSB";
            this.toolTip1.SetToolTip(this.radModeLSB, resources.GetString("radModeLSB.ToolTip"));
            this.radModeLSB.CheckedChanged += new System.EventHandler(this.radModeButton_CheckedChanged);
            // 
            // radModeSAM
            // 
            resources.ApplyResources(this.radModeSAM, "radModeSAM");
            this.radModeSAM.FlatAppearance.BorderSize = 0;
            this.radModeSAM.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radModeSAM.Name = "radModeSAM";
            this.toolTip1.SetToolTip(this.radModeSAM, resources.GetString("radModeSAM.ToolTip"));
            this.radModeSAM.CheckedChanged += new System.EventHandler(this.radModeButton_CheckedChanged);
            this.radModeSAM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radModeSAM_MouseDown);
            // 
            // radModeCWL
            // 
            resources.ApplyResources(this.radModeCWL, "radModeCWL");
            this.radModeCWL.FlatAppearance.BorderSize = 0;
            this.radModeCWL.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radModeCWL.Name = "radModeCWL";
            this.toolTip1.SetToolTip(this.radModeCWL, resources.GetString("radModeCWL.ToolTip"));
            this.radModeCWL.CheckedChanged += new System.EventHandler(this.radModeButton_CheckedChanged);
            this.radModeCWL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radModeCWL_MouseDown);
            // 
            // radModeDSB
            // 
            resources.ApplyResources(this.radModeDSB, "radModeDSB");
            this.radModeDSB.FlatAppearance.BorderSize = 0;
            this.radModeDSB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radModeDSB.Name = "radModeDSB";
            this.toolTip1.SetToolTip(this.radModeDSB, resources.GetString("radModeDSB.ToolTip"));
            this.radModeDSB.CheckedChanged += new System.EventHandler(this.radModeButton_CheckedChanged);
            // 
            // radModeUSB
            // 
            resources.ApplyResources(this.radModeUSB, "radModeUSB");
            this.radModeUSB.BackColor = System.Drawing.Color.Transparent;
            this.radModeUSB.FlatAppearance.BorderSize = 0;
            this.radModeUSB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radModeUSB.Name = "radModeUSB";
            this.toolTip1.SetToolTip(this.radModeUSB, resources.GetString("radModeUSB.ToolTip"));
            this.radModeUSB.UseVisualStyleBackColor = false;
            this.radModeUSB.CheckedChanged += new System.EventHandler(this.radModeButton_CheckedChanged);
            // 
            // radModeCWU
            // 
            resources.ApplyResources(this.radModeCWU, "radModeCWU");
            this.radModeCWU.FlatAppearance.BorderSize = 0;
            this.radModeCWU.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radModeCWU.Name = "radModeCWU";
            this.toolTip1.SetToolTip(this.radModeCWU, resources.GetString("radModeCWU.ToolTip"));
            this.radModeCWU.CheckedChanged += new System.EventHandler(this.radModeButton_CheckedChanged);
            this.radModeCWU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radModeCWU_MouseDown);
            // 
            // radModeFMN
            // 
            resources.ApplyResources(this.radModeFMN, "radModeFMN");
            this.radModeFMN.FlatAppearance.BorderSize = 0;
            this.radModeFMN.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radModeFMN.Name = "radModeFMN";
            this.toolTip1.SetToolTip(this.radModeFMN, resources.GetString("radModeFMN.ToolTip"));
            this.radModeFMN.CheckedChanged += new System.EventHandler(this.radModeButton_CheckedChanged);
            this.radModeFMN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radModeFMN_MouseDown);
            // 
            // radModeDIGU
            // 
            resources.ApplyResources(this.radModeDIGU, "radModeDIGU");
            this.radModeDIGU.FlatAppearance.BorderSize = 0;
            this.radModeDIGU.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radModeDIGU.Name = "radModeDIGU";
            this.toolTip1.SetToolTip(this.radModeDIGU, resources.GetString("radModeDIGU.ToolTip"));
            this.radModeDIGU.CheckedChanged += new System.EventHandler(this.radModeButton_CheckedChanged);
            // 
            // radModeDRM
            // 
            resources.ApplyResources(this.radModeDRM, "radModeDRM");
            this.radModeDRM.FlatAppearance.BorderSize = 0;
            this.radModeDRM.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radModeDRM.Name = "radModeDRM";
            this.toolTip1.SetToolTip(this.radModeDRM, resources.GetString("radModeDRM.ToolTip"));
            this.radModeDRM.CheckedChanged += new System.EventHandler(this.radModeButton_CheckedChanged);
            // 
            // radModeDIGL
            // 
            resources.ApplyResources(this.radModeDIGL, "radModeDIGL");
            this.radModeDIGL.FlatAppearance.BorderSize = 0;
            this.radModeDIGL.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radModeDIGL.Name = "radModeDIGL";
            this.toolTip1.SetToolTip(this.radModeDIGL, resources.GetString("radModeDIGL.ToolTip"));
            this.radModeDIGL.CheckedChanged += new System.EventHandler(this.radModeButton_CheckedChanged);
            // 
            // radModeSPEC
            // 
            resources.ApplyResources(this.radModeSPEC, "radModeSPEC");
            this.radModeSPEC.FlatAppearance.BorderSize = 0;
            this.radModeSPEC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radModeSPEC.Name = "radModeSPEC";
            this.toolTip1.SetToolTip(this.radModeSPEC, resources.GetString("radModeSPEC.ToolTip"));
            this.radModeSPEC.CheckedChanged += new System.EventHandler(this.radModeButton_CheckedChanged);
            // 
            // btnBandVHF
            // 
            this.btnBandVHF.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnBandVHF, "btnBandVHF");
            this.btnBandVHF.ForeColor = System.Drawing.Color.Gold;
            this.btnBandVHF.Name = "btnBandVHF";
            this.btnBandVHF.Selectable = true;
            this.toolTip1.SetToolTip(this.btnBandVHF, resources.GetString("btnBandVHF.ToolTip"));
            this.btnBandVHF.Click += new System.EventHandler(this.btnBandVHF_Click);
            // 
            // chkVFOATX
            // 
            resources.ApplyResources(this.chkVFOATX, "chkVFOATX");
            this.chkVFOATX.BackColor = System.Drawing.Color.Transparent;
            this.chkVFOATX.Checked = true;
            this.chkVFOATX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVFOATX.FlatAppearance.BorderSize = 0;
            this.chkVFOATX.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkVFOATX.Name = "chkVFOATX";
            this.toolTip1.SetToolTip(this.chkVFOATX, resources.GetString("chkVFOATX.ToolTip"));
            this.chkVFOATX.UseVisualStyleBackColor = false;
            this.chkVFOATX.CheckedChanged += new System.EventHandler(this.chkVFOATX_CheckedChanged);
            // 
            // txtWheelTune
            // 
            this.txtWheelTune.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtWheelTune.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWheelTune.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.txtWheelTune, "txtWheelTune");
            this.txtWheelTune.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtWheelTune.Name = "txtWheelTune";
            this.txtWheelTune.ReadOnly = true;
            this.toolTip1.SetToolTip(this.txtWheelTune, resources.GetString("txtWheelTune.ToolTip"));
            this.txtWheelTune.GotFocus += new System.EventHandler(this.HideFocus);
            this.txtWheelTune.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WheelTune_MouseDown);
            // 
            // chkVFOBTX
            // 
            resources.ApplyResources(this.chkVFOBTX, "chkVFOBTX");
            this.chkVFOBTX.FlatAppearance.BorderSize = 0;
            this.chkVFOBTX.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkVFOBTX.Name = "chkVFOBTX";
            this.toolTip1.SetToolTip(this.chkVFOBTX, resources.GetString("chkVFOBTX.ToolTip"));
            this.chkVFOBTX.CheckedChanged += new System.EventHandler(this.chkVFOBTX_CheckedChanged);
            // 
            // comboMeterTXMode
            // 
            this.comboMeterTXMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboMeterTXMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMeterTXMode.DropDownWidth = 72;
            resources.ApplyResources(this.comboMeterTXMode, "comboMeterTXMode");
            this.comboMeterTXMode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboMeterTXMode.Name = "comboMeterTXMode";
            this.toolTip1.SetToolTip(this.comboMeterTXMode, resources.GetString("comboMeterTXMode.ToolTip"));
            this.comboMeterTXMode.SelectedIndexChanged += new System.EventHandler(this.comboMeterTXMode_SelectedIndexChanged);
            // 
            // comboMeterRXMode
            // 
            this.comboMeterRXMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboMeterRXMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMeterRXMode.DropDownWidth = 72;
            resources.ApplyResources(this.comboMeterRXMode, "comboMeterRXMode");
            this.comboMeterRXMode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboMeterRXMode.Name = "comboMeterRXMode";
            this.toolTip1.SetToolTip(this.comboMeterRXMode, resources.GetString("comboMeterRXMode.ToolTip"));
            this.comboMeterRXMode.SelectedIndexChanged += new System.EventHandler(this.comboMeterRXMode_SelectedIndexChanged);
            // 
            // chkSquelch
            // 
            resources.ApplyResources(this.chkSquelch, "chkSquelch");
            this.chkSquelch.FlatAppearance.BorderSize = 0;
            this.chkSquelch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkSquelch.Name = "chkSquelch";
            this.chkSquelch.ThreeState = true;
            this.toolTip1.SetToolTip(this.chkSquelch, resources.GetString("chkSquelch.ToolTip"));
            this.chkSquelch.CheckStateChanged += new System.EventHandler(this.chkSquelch_CheckStateChanged);
            this.chkSquelch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkSquelch_MouseDown);
            // 
            // btnMemoryQuickRestore
            // 
            this.btnMemoryQuickRestore.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnMemoryQuickRestore, "btnMemoryQuickRestore");
            this.btnMemoryQuickRestore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMemoryQuickRestore.Name = "btnMemoryQuickRestore";
            this.btnMemoryQuickRestore.Selectable = true;
            this.toolTip1.SetToolTip(this.btnMemoryQuickRestore, resources.GetString("btnMemoryQuickRestore.ToolTip"));
            this.btnMemoryQuickRestore.Click += new System.EventHandler(this.btnMemoryQuickRestore_Click);
            // 
            // btnMemoryQuickSave
            // 
            this.btnMemoryQuickSave.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnMemoryQuickSave, "btnMemoryQuickSave");
            this.btnMemoryQuickSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMemoryQuickSave.Name = "btnMemoryQuickSave";
            this.btnMemoryQuickSave.Selectable = true;
            this.toolTip1.SetToolTip(this.btnMemoryQuickSave, resources.GetString("btnMemoryQuickSave.ToolTip"));
            this.btnMemoryQuickSave.Click += new System.EventHandler(this.btnMemoryQuickSave_Click);
            // 
            // txtMemoryQuick
            // 
            this.txtMemoryQuick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.txtMemoryQuick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMemoryQuick.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMemoryQuick.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.txtMemoryQuick, "txtMemoryQuick");
            this.txtMemoryQuick.Name = "txtMemoryQuick";
            this.txtMemoryQuick.ReadOnly = true;
            this.toolTip1.SetToolTip(this.txtMemoryQuick, resources.GetString("txtMemoryQuick.ToolTip"));
            // 
            // chkVFOLock
            // 
            resources.ApplyResources(this.chkVFOLock, "chkVFOLock");
            this.chkVFOLock.FlatAppearance.BorderSize = 0;
            this.chkVFOLock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkVFOLock.Name = "chkVFOLock";
            this.toolTip1.SetToolTip(this.chkVFOLock, resources.GetString("chkVFOLock.ToolTip"));
            this.chkVFOLock.CheckedChanged += new System.EventHandler(this.chkVFOLock_CheckedChanged);
            // 
            // chkVFOSync
            // 
            resources.ApplyResources(this.chkVFOSync, "chkVFOSync");
            this.chkVFOSync.FlatAppearance.BorderSize = 0;
            this.chkVFOSync.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkVFOSync.Name = "chkVFOSync";
            this.toolTip1.SetToolTip(this.chkVFOSync, resources.GetString("chkVFOSync.ToolTip"));
            this.chkVFOSync.CheckedChanged += new System.EventHandler(this.chkVFOSync_CheckedChanged);
            // 
            // btnTuneStepChangeLarger
            // 
            this.btnTuneStepChangeLarger.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnTuneStepChangeLarger, "btnTuneStepChangeLarger");
            this.btnTuneStepChangeLarger.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTuneStepChangeLarger.Name = "btnTuneStepChangeLarger";
            this.btnTuneStepChangeLarger.Selectable = true;
            this.toolTip1.SetToolTip(this.btnTuneStepChangeLarger, resources.GetString("btnTuneStepChangeLarger.ToolTip"));
            this.btnTuneStepChangeLarger.Click += new System.EventHandler(this.btnChangeTuneStepLarger_Click);
            // 
            // btnTuneStepChangeSmaller
            // 
            this.btnTuneStepChangeSmaller.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnTuneStepChangeSmaller, "btnTuneStepChangeSmaller");
            this.btnTuneStepChangeSmaller.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTuneStepChangeSmaller.Name = "btnTuneStepChangeSmaller";
            this.btnTuneStepChangeSmaller.Selectable = true;
            this.toolTip1.SetToolTip(this.btnTuneStepChangeSmaller, resources.GetString("btnTuneStepChangeSmaller.ToolTip"));
            this.btnTuneStepChangeSmaller.Click += new System.EventHandler(this.btnChangeTuneStepSmaller_Click);
            // 
            // chkSplitDisplay
            // 
            resources.ApplyResources(this.chkSplitDisplay, "chkSplitDisplay");
            this.chkSplitDisplay.Name = "chkSplitDisplay";
            this.toolTip1.SetToolTip(this.chkSplitDisplay, resources.GetString("chkSplitDisplay.ToolTip"));
            this.chkSplitDisplay.CheckedChanged += new System.EventHandler(this.chkSplitDisplay_CheckedChanged);
            // 
            // comboDisplayModeTop
            // 
            this.comboDisplayModeTop.BackColor = System.Drawing.SystemColors.Window;
            this.comboDisplayModeTop.DisplayMember = "0";
            this.comboDisplayModeTop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDisplayModeTop.DropDownWidth = 88;
            this.comboDisplayModeTop.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.comboDisplayModeTop, "comboDisplayModeTop");
            this.comboDisplayModeTop.Items.AddRange(new object[] {
            resources.GetString("comboDisplayModeTop.Items"),
            resources.GetString("comboDisplayModeTop.Items1"),
            resources.GetString("comboDisplayModeTop.Items2")});
            this.comboDisplayModeTop.Name = "comboDisplayModeTop";
            this.toolTip1.SetToolTip(this.comboDisplayModeTop, resources.GetString("comboDisplayModeTop.ToolTip"));
            // 
            // comboDisplayModeBottom
            // 
            this.comboDisplayModeBottom.BackColor = System.Drawing.SystemColors.Window;
            this.comboDisplayModeBottom.DisplayMember = "0";
            this.comboDisplayModeBottom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDisplayModeBottom.DropDownWidth = 88;
            this.comboDisplayModeBottom.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.comboDisplayModeBottom, "comboDisplayModeBottom");
            this.comboDisplayModeBottom.Items.AddRange(new object[] {
            resources.GetString("comboDisplayModeBottom.Items"),
            resources.GetString("comboDisplayModeBottom.Items1"),
            resources.GetString("comboDisplayModeBottom.Items2")});
            this.comboDisplayModeBottom.Name = "comboDisplayModeBottom";
            this.toolTip1.SetToolTip(this.comboDisplayModeBottom, resources.GetString("comboDisplayModeBottom.ToolTip"));
            // 
            // comboRX2MeterMode
            // 
            this.comboRX2MeterMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboRX2MeterMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRX2MeterMode.DropDownWidth = 72;
            resources.ApplyResources(this.comboRX2MeterMode, "comboRX2MeterMode");
            this.comboRX2MeterMode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboRX2MeterMode.Name = "comboRX2MeterMode";
            this.toolTip1.SetToolTip(this.comboRX2MeterMode, resources.GetString("comboRX2MeterMode.ToolTip"));
            this.comboRX2MeterMode.SelectedIndexChanged += new System.EventHandler(this.comboRX2MeterMode_SelectedIndexChanged);
            // 
            // chkRX2DisplayAVG
            // 
            resources.ApplyResources(this.chkRX2DisplayAVG, "chkRX2DisplayAVG");
            this.chkRX2DisplayAVG.FlatAppearance.BorderSize = 0;
            this.chkRX2DisplayAVG.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRX2DisplayAVG.Name = "chkRX2DisplayAVG";
            this.toolTip1.SetToolTip(this.chkRX2DisplayAVG, resources.GetString("chkRX2DisplayAVG.ToolTip"));
            this.chkRX2DisplayAVG.CheckedChanged += new System.EventHandler(this.chkRX2DisplayAVG_CheckedChanged);
            // 
            // radBand160
            // 
            resources.ApplyResources(this.radBand160, "radBand160");
            this.radBand160.FlatAppearance.BorderSize = 0;
            this.radBand160.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radBand160.Name = "radBand160";
            this.radBand160.TabStop = true;
            this.toolTip1.SetToolTip(this.radBand160, resources.GetString("radBand160.ToolTip"));
            this.radBand160.UseVisualStyleBackColor = true;
            this.radBand160.CheckedChanged += new System.EventHandler(this.radBand_CheckedChanged);
            this.radBand160.Click += new System.EventHandler(this.radBand160_Click);
            this.radBand160.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBand160_MouseDown);
            // 
            // radBandGEN
            // 
            resources.ApplyResources(this.radBandGEN, "radBandGEN");
            this.radBandGEN.FlatAppearance.BorderSize = 0;
            this.radBandGEN.ForeColor = System.Drawing.Color.Coral;
            this.radBandGEN.Name = "radBandGEN";
            this.radBandGEN.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandGEN, resources.GetString("radBandGEN.ToolTip"));
            this.radBandGEN.UseVisualStyleBackColor = true;
            this.radBandGEN.CheckedChanged += new System.EventHandler(this.radBand_CheckedChanged);
            this.radBandGEN.Click += new System.EventHandler(this.btnBandGEN_Click);
            // 
            // radBandWWV
            // 
            resources.ApplyResources(this.radBandWWV, "radBandWWV");
            this.radBandWWV.FlatAppearance.BorderSize = 0;
            this.radBandWWV.ForeColor = System.Drawing.Color.LightGreen;
            this.radBandWWV.Name = "radBandWWV";
            this.radBandWWV.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandWWV, resources.GetString("radBandWWV.ToolTip"));
            this.radBandWWV.UseVisualStyleBackColor = true;
            this.radBandWWV.CheckedChanged += new System.EventHandler(this.radBand_CheckedChanged);
            this.radBandWWV.Click += new System.EventHandler(this.radBandWWV_Click);
            // 
            // radBand6
            // 
            resources.ApplyResources(this.radBand6, "radBand6");
            this.radBand6.FlatAppearance.BorderSize = 0;
            this.radBand6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radBand6.Name = "radBand6";
            this.radBand6.TabStop = true;
            this.toolTip1.SetToolTip(this.radBand6, resources.GetString("radBand6.ToolTip"));
            this.radBand6.UseVisualStyleBackColor = true;
            this.radBand6.CheckedChanged += new System.EventHandler(this.radBand_CheckedChanged);
            this.radBand6.Click += new System.EventHandler(this.radBand6_Click);
            this.radBand6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBand6_MouseDown);
            // 
            // radBand10
            // 
            resources.ApplyResources(this.radBand10, "radBand10");
            this.radBand10.FlatAppearance.BorderSize = 0;
            this.radBand10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radBand10.Name = "radBand10";
            this.radBand10.TabStop = true;
            this.toolTip1.SetToolTip(this.radBand10, resources.GetString("radBand10.ToolTip"));
            this.radBand10.UseVisualStyleBackColor = true;
            this.radBand10.CheckedChanged += new System.EventHandler(this.radBand_CheckedChanged);
            this.radBand10.Click += new System.EventHandler(this.radBand10_Click);
            this.radBand10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBand10_MouseDown);
            // 
            // radBand12
            // 
            resources.ApplyResources(this.radBand12, "radBand12");
            this.radBand12.FlatAppearance.BorderSize = 0;
            this.radBand12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radBand12.Name = "radBand12";
            this.radBand12.TabStop = true;
            this.toolTip1.SetToolTip(this.radBand12, resources.GetString("radBand12.ToolTip"));
            this.radBand12.UseVisualStyleBackColor = true;
            this.radBand12.CheckedChanged += new System.EventHandler(this.radBand_CheckedChanged);
            this.radBand12.Click += new System.EventHandler(this.radBand12_Click);
            this.radBand12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBand12_MouseDown);
            // 
            // radBand15
            // 
            resources.ApplyResources(this.radBand15, "radBand15");
            this.radBand15.FlatAppearance.BorderSize = 0;
            this.radBand15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radBand15.Name = "radBand15";
            this.radBand15.TabStop = true;
            this.toolTip1.SetToolTip(this.radBand15, resources.GetString("radBand15.ToolTip"));
            this.radBand15.UseVisualStyleBackColor = true;
            this.radBand15.CheckedChanged += new System.EventHandler(this.radBand_CheckedChanged);
            this.radBand15.Click += new System.EventHandler(this.radBand15_Click);
            this.radBand15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBand15_MouseDown);
            // 
            // radBand17
            // 
            resources.ApplyResources(this.radBand17, "radBand17");
            this.radBand17.FlatAppearance.BorderSize = 0;
            this.radBand17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radBand17.Name = "radBand17";
            this.radBand17.TabStop = true;
            this.toolTip1.SetToolTip(this.radBand17, resources.GetString("radBand17.ToolTip"));
            this.radBand17.UseVisualStyleBackColor = true;
            this.radBand17.CheckedChanged += new System.EventHandler(this.radBand_CheckedChanged);
            this.radBand17.Click += new System.EventHandler(this.radBand17_Click);
            this.radBand17.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBand17_MouseDown);
            // 
            // radBand20
            // 
            resources.ApplyResources(this.radBand20, "radBand20");
            this.radBand20.FlatAppearance.BorderSize = 0;
            this.radBand20.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radBand20.Name = "radBand20";
            this.radBand20.TabStop = true;
            this.toolTip1.SetToolTip(this.radBand20, resources.GetString("radBand20.ToolTip"));
            this.radBand20.UseVisualStyleBackColor = true;
            this.radBand20.CheckedChanged += new System.EventHandler(this.radBand_CheckedChanged);
            this.radBand20.Click += new System.EventHandler(this.radBand20_Click);
            this.radBand20.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBand20_MouseDown);
            // 
            // radBand30
            // 
            resources.ApplyResources(this.radBand30, "radBand30");
            this.radBand30.FlatAppearance.BorderSize = 0;
            this.radBand30.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radBand30.Name = "radBand30";
            this.radBand30.TabStop = true;
            this.toolTip1.SetToolTip(this.radBand30, resources.GetString("radBand30.ToolTip"));
            this.radBand30.UseVisualStyleBackColor = true;
            this.radBand30.CheckedChanged += new System.EventHandler(this.radBand_CheckedChanged);
            this.radBand30.Click += new System.EventHandler(this.radBand30_Click);
            this.radBand30.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBand30_MouseDown);
            // 
            // radBand40
            // 
            resources.ApplyResources(this.radBand40, "radBand40");
            this.radBand40.FlatAppearance.BorderSize = 0;
            this.radBand40.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radBand40.Name = "radBand40";
            this.radBand40.TabStop = true;
            this.toolTip1.SetToolTip(this.radBand40, resources.GetString("radBand40.ToolTip"));
            this.radBand40.UseVisualStyleBackColor = true;
            this.radBand40.CheckedChanged += new System.EventHandler(this.radBand_CheckedChanged);
            this.radBand40.Click += new System.EventHandler(this.radBand40_Click);
            this.radBand40.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBand40_MouseDown);
            // 
            // radBand60
            // 
            resources.ApplyResources(this.radBand60, "radBand60");
            this.radBand60.FlatAppearance.BorderSize = 0;
            this.radBand60.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radBand60.Name = "radBand60";
            this.radBand60.TabStop = true;
            this.toolTip1.SetToolTip(this.radBand60, resources.GetString("radBand60.ToolTip"));
            this.radBand60.UseVisualStyleBackColor = true;
            this.radBand60.CheckedChanged += new System.EventHandler(this.radBand_CheckedChanged);
            this.radBand60.Click += new System.EventHandler(this.radBand60_Click);
            this.radBand60.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBand60_MouseDown);
            // 
            // radBand80
            // 
            resources.ApplyResources(this.radBand80, "radBand80");
            this.radBand80.FlatAppearance.BorderSize = 0;
            this.radBand80.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radBand80.Name = "radBand80";
            this.radBand80.TabStop = true;
            this.toolTip1.SetToolTip(this.radBand80, resources.GetString("radBand80.ToolTip"));
            this.radBand80.UseVisualStyleBackColor = true;
            this.radBand80.CheckedChanged += new System.EventHandler(this.radBand_CheckedChanged);
            this.radBand80.Click += new System.EventHandler(this.radBand80_Click);
            this.radBand80.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBand80_MouseDown);
            // 
            // radDisplayZoom05
            // 
            resources.ApplyResources(this.radDisplayZoom05, "radDisplayZoom05");
            this.radDisplayZoom05.FlatAppearance.BorderSize = 0;
            this.radDisplayZoom05.ForeColor = System.Drawing.Color.White;
            this.radDisplayZoom05.Name = "radDisplayZoom05";
            this.radDisplayZoom05.TabStop = true;
            this.toolTip1.SetToolTip(this.radDisplayZoom05, resources.GetString("radDisplayZoom05.ToolTip"));
            this.radDisplayZoom05.UseVisualStyleBackColor = true;
            this.radDisplayZoom05.CheckedChanged += new System.EventHandler(this.radDisplayZoom05_CheckedChanged);
            this.radDisplayZoom05.Click += new System.EventHandler(this.radDisplayZoom05_Click);
            // 
            // radDisplayZoom4x
            // 
            resources.ApplyResources(this.radDisplayZoom4x, "radDisplayZoom4x");
            this.radDisplayZoom4x.FlatAppearance.BorderSize = 0;
            this.radDisplayZoom4x.ForeColor = System.Drawing.Color.White;
            this.radDisplayZoom4x.Name = "radDisplayZoom4x";
            this.radDisplayZoom4x.TabStop = true;
            this.toolTip1.SetToolTip(this.radDisplayZoom4x, resources.GetString("radDisplayZoom4x.ToolTip"));
            this.radDisplayZoom4x.UseVisualStyleBackColor = true;
            this.radDisplayZoom4x.CheckedChanged += new System.EventHandler(this.radDisplayZoom4x_CheckedChanged);
            this.radDisplayZoom4x.Click += new System.EventHandler(this.radDisplayZoom4x_Click);
            // 
            // radDisplayZoom2x
            // 
            resources.ApplyResources(this.radDisplayZoom2x, "radDisplayZoom2x");
            this.radDisplayZoom2x.FlatAppearance.BorderSize = 0;
            this.radDisplayZoom2x.ForeColor = System.Drawing.Color.White;
            this.radDisplayZoom2x.Name = "radDisplayZoom2x";
            this.radDisplayZoom2x.TabStop = true;
            this.toolTip1.SetToolTip(this.radDisplayZoom2x, resources.GetString("radDisplayZoom2x.ToolTip"));
            this.radDisplayZoom2x.UseVisualStyleBackColor = true;
            this.radDisplayZoom2x.CheckedChanged += new System.EventHandler(this.radDisplayZoom2x_CheckedChanged);
            this.radDisplayZoom2x.Click += new System.EventHandler(this.radDisplayZoom2x_Click);
            // 
            // radDisplayZoom1x
            // 
            resources.ApplyResources(this.radDisplayZoom1x, "radDisplayZoom1x");
            this.radDisplayZoom1x.FlatAppearance.BorderSize = 0;
            this.radDisplayZoom1x.ForeColor = System.Drawing.Color.White;
            this.radDisplayZoom1x.Name = "radDisplayZoom1x";
            this.radDisplayZoom1x.TabStop = true;
            this.toolTip1.SetToolTip(this.radDisplayZoom1x, resources.GetString("radDisplayZoom1x.ToolTip"));
            this.radDisplayZoom1x.UseVisualStyleBackColor = true;
            this.radDisplayZoom1x.CheckedChanged += new System.EventHandler(this.radDisplayZoom1x_CheckedChanged);
            this.radDisplayZoom1x.Click += new System.EventHandler(this.radDisplayZoom1x_Click);
            // 
            // chkMUT
            // 
            resources.ApplyResources(this.chkMUT, "chkMUT");
            this.chkMUT.FlatAppearance.BorderSize = 0;
            this.chkMUT.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkMUT.Name = "chkMUT";
            this.toolTip1.SetToolTip(this.chkMUT, resources.GetString("chkMUT.ToolTip"));
            this.chkMUT.CheckedChanged += new System.EventHandler(this.chkMUT_CheckedChanged);
            // 
            // chkCWFWKeyer
            // 
            this.chkCWFWKeyer.Checked = true;
            this.chkCWFWKeyer.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.chkCWFWKeyer, "chkCWFWKeyer");
            this.chkCWFWKeyer.ForeColor = System.Drawing.Color.White;
            this.chkCWFWKeyer.Name = "chkCWFWKeyer";
            this.toolTip1.SetToolTip(this.chkCWFWKeyer, resources.GetString("chkCWFWKeyer.ToolTip"));
            this.chkCWFWKeyer.CheckedChanged += new System.EventHandler(this.chkCWFWKeyer_CheckedChanged);
            // 
            // chkShowCWZero
            // 
            resources.ApplyResources(this.chkShowCWZero, "chkShowCWZero");
            this.chkShowCWZero.ForeColor = System.Drawing.Color.White;
            this.chkShowCWZero.Name = "chkShowCWZero";
            this.toolTip1.SetToolTip(this.chkShowCWZero, resources.GetString("chkShowCWZero.ToolTip"));
            this.chkShowCWZero.CheckedChanged += new System.EventHandler(this.chkShowCWZero_CheckedChanged);
            // 
            // radFMDeviation5kHz
            // 
            resources.ApplyResources(this.radFMDeviation5kHz, "radFMDeviation5kHz");
            this.radFMDeviation5kHz.Checked = true;
            this.radFMDeviation5kHz.FlatAppearance.BorderSize = 0;
            this.radFMDeviation5kHz.ForeColor = System.Drawing.Color.White;
            this.radFMDeviation5kHz.Name = "radFMDeviation5kHz";
            this.radFMDeviation5kHz.TabStop = true;
            this.toolTip1.SetToolTip(this.radFMDeviation5kHz, resources.GetString("radFMDeviation5kHz.ToolTip"));
            this.radFMDeviation5kHz.UseVisualStyleBackColor = true;
            this.radFMDeviation5kHz.CheckedChanged += new System.EventHandler(this.radFMDeviation5kHz_CheckedChanged);
            // 
            // comboFMTXProfile
            // 
            this.comboFMTXProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboFMTXProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFMTXProfile.DropDownWidth = 96;
            resources.ApplyResources(this.comboFMTXProfile, "comboFMTXProfile");
            this.comboFMTXProfile.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboFMTXProfile.Name = "comboFMTXProfile";
            this.toolTip1.SetToolTip(this.comboFMTXProfile, resources.GetString("comboFMTXProfile.ToolTip"));
            this.comboFMTXProfile.SelectedIndexChanged += new System.EventHandler(this.comboFMTXProfile_SelectedIndexChanged);
            // 
            // udFMOffset
            // 
            this.udFMOffset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.udFMOffset.DecimalPlaces = 3;
            this.udFMOffset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.udFMOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.udFMOffset, "udFMOffset");
            this.udFMOffset.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.udFMOffset.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFMOffset.Name = "udFMOffset";
            this.udFMOffset.TinyStep = false;
            this.toolTip1.SetToolTip(this.udFMOffset, resources.GetString("udFMOffset.ToolTip"));
            this.udFMOffset.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udFMOffset.ValueChanged += new System.EventHandler(this.udFMOffset_ValueChanged);
            // 
            // chkFMTXSimplex
            // 
            resources.ApplyResources(this.chkFMTXSimplex, "chkFMTXSimplex");
            this.chkFMTXSimplex.Checked = true;
            this.chkFMTXSimplex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFMTXSimplex.FlatAppearance.BorderSize = 0;
            this.chkFMTXSimplex.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkFMTXSimplex.Name = "chkFMTXSimplex";
            this.toolTip1.SetToolTip(this.chkFMTXSimplex, resources.GetString("chkFMTXSimplex.ToolTip"));
            this.chkFMTXSimplex.CheckedChanged += new System.EventHandler(this.chkFMTXSimplex_CheckedChanged);
            this.chkFMTXSimplex.Click += new System.EventHandler(this.chkFMMode_Click);
            // 
            // comboFMCTCSS
            // 
            this.comboFMCTCSS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboFMCTCSS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFMCTCSS.DropDownWidth = 60;
            resources.ApplyResources(this.comboFMCTCSS, "comboFMCTCSS");
            this.comboFMCTCSS.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboFMCTCSS.Name = "comboFMCTCSS";
            this.toolTip1.SetToolTip(this.comboFMCTCSS, resources.GetString("comboFMCTCSS.ToolTip"));
            this.comboFMCTCSS.SelectedIndexChanged += new System.EventHandler(this.comboFMCTCSS_SelectedIndexChanged);
            // 
            // btnFMMemory
            // 
            this.btnFMMemory.BackColor = System.Drawing.Color.Transparent;
            this.btnFMMemory.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnFMMemory, "btnFMMemory");
            this.btnFMMemory.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFMMemory.Name = "btnFMMemory";
            this.btnFMMemory.Selectable = true;
            this.toolTip1.SetToolTip(this.btnFMMemory, resources.GetString("btnFMMemory.ToolTip"));
            this.btnFMMemory.UseVisualStyleBackColor = false;
            this.btnFMMemory.Click += new System.EventHandler(this.btnFMMemory_Click);
            // 
            // chkFMCTCSS
            // 
            resources.ApplyResources(this.chkFMCTCSS, "chkFMCTCSS");
            this.chkFMCTCSS.BackColor = System.Drawing.Color.Transparent;
            this.chkFMCTCSS.FlatAppearance.BorderSize = 0;
            this.chkFMCTCSS.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkFMCTCSS.Name = "chkFMCTCSS";
            this.toolTip1.SetToolTip(this.chkFMCTCSS, resources.GetString("chkFMCTCSS.ToolTip"));
            this.chkFMCTCSS.UseVisualStyleBackColor = false;
            this.chkFMCTCSS.CheckedChanged += new System.EventHandler(this.chkFMCTCSS_CheckedChanged);
            // 
            // btnFMMemoryUp
            // 
            this.btnFMMemoryUp.BackColor = System.Drawing.Color.Transparent;
            this.btnFMMemoryUp.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnFMMemoryUp, "btnFMMemoryUp");
            this.btnFMMemoryUp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFMMemoryUp.Name = "btnFMMemoryUp";
            this.btnFMMemoryUp.Selectable = true;
            this.toolTip1.SetToolTip(this.btnFMMemoryUp, resources.GetString("btnFMMemoryUp.ToolTip"));
            this.btnFMMemoryUp.UseVisualStyleBackColor = false;
            this.btnFMMemoryUp.Click += new System.EventHandler(this.btnFMMemoryUp_Click);
            // 
            // btnFMMemoryDown
            // 
            this.btnFMMemoryDown.BackColor = System.Drawing.Color.Transparent;
            this.btnFMMemoryDown.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnFMMemoryDown, "btnFMMemoryDown");
            this.btnFMMemoryDown.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFMMemoryDown.Name = "btnFMMemoryDown";
            this.btnFMMemoryDown.Selectable = true;
            this.toolTip1.SetToolTip(this.btnFMMemoryDown, resources.GetString("btnFMMemoryDown.ToolTip"));
            this.btnFMMemoryDown.UseVisualStyleBackColor = false;
            this.btnFMMemoryDown.Click += new System.EventHandler(this.btnFMMemoryDown_Click);
            // 
            // radFMDeviation2kHz
            // 
            resources.ApplyResources(this.radFMDeviation2kHz, "radFMDeviation2kHz");
            this.radFMDeviation2kHz.FlatAppearance.BorderSize = 0;
            this.radFMDeviation2kHz.ForeColor = System.Drawing.Color.White;
            this.radFMDeviation2kHz.Name = "radFMDeviation2kHz";
            this.toolTip1.SetToolTip(this.radFMDeviation2kHz, resources.GetString("radFMDeviation2kHz.ToolTip"));
            this.radFMDeviation2kHz.UseVisualStyleBackColor = true;
            this.radFMDeviation2kHz.CheckedChanged += new System.EventHandler(this.radFMDeviation2kHz_CheckedChanged);
            // 
            // chkFMTXLow
            // 
            resources.ApplyResources(this.chkFMTXLow, "chkFMTXLow");
            this.chkFMTXLow.BackColor = System.Drawing.Color.Transparent;
            this.chkFMTXLow.FlatAppearance.BorderSize = 0;
            this.chkFMTXLow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkFMTXLow.Name = "chkFMTXLow";
            this.toolTip1.SetToolTip(this.chkFMTXLow, resources.GetString("chkFMTXLow.ToolTip"));
            this.chkFMTXLow.UseVisualStyleBackColor = false;
            this.chkFMTXLow.CheckedChanged += new System.EventHandler(this.chkFMTXLow_CheckedChanged);
            this.chkFMTXLow.Click += new System.EventHandler(this.chkFMMode_Click);
            // 
            // chkFMTXHigh
            // 
            resources.ApplyResources(this.chkFMTXHigh, "chkFMTXHigh");
            this.chkFMTXHigh.BackColor = System.Drawing.Color.Transparent;
            this.chkFMTXHigh.FlatAppearance.BorderSize = 0;
            this.chkFMTXHigh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkFMTXHigh.Name = "chkFMTXHigh";
            this.toolTip1.SetToolTip(this.chkFMTXHigh, resources.GetString("chkFMTXHigh.ToolTip"));
            this.chkFMTXHigh.UseVisualStyleBackColor = false;
            this.chkFMTXHigh.CheckedChanged += new System.EventHandler(this.chkFMTXHigh_CheckedChanged);
            this.chkFMTXHigh.Click += new System.EventHandler(this.chkFMMode_Click);
            // 
            // chkFMTXRev
            // 
            resources.ApplyResources(this.chkFMTXRev, "chkFMTXRev");
            this.chkFMTXRev.BackColor = System.Drawing.Color.Transparent;
            this.chkFMTXRev.FlatAppearance.BorderSize = 0;
            this.chkFMTXRev.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkFMTXRev.Name = "chkFMTXRev";
            this.toolTip1.SetToolTip(this.chkFMTXRev, resources.GetString("chkFMTXRev.ToolTip"));
            this.chkFMTXRev.UseVisualStyleBackColor = false;
            this.chkFMTXRev.CheckedChanged += new System.EventHandler(this.chkFMTXRev_CheckedChanged);
            // 
            // chkTNF
            // 
            resources.ApplyResources(this.chkTNF, "chkTNF");
            this.chkTNF.FlatAppearance.BorderSize = 0;
            this.chkTNF.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkTNF.Name = "chkTNF";
            this.toolTip1.SetToolTip(this.chkTNF, resources.GetString("chkTNF.ToolTip"));
            this.chkTNF.CheckedChanged += new System.EventHandler(this.chkTNF_CheckedChanged);
            this.chkTNF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkTNF_MouseDown);
            // 
            // btnTNFAdd
            // 
            this.btnTNFAdd.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnTNFAdd, "btnTNFAdd");
            this.btnTNFAdd.Name = "btnTNFAdd";
            this.btnTNFAdd.Selectable = true;
            this.toolTip1.SetToolTip(this.btnTNFAdd, resources.GetString("btnTNFAdd.ToolTip"));
            this.btnTNFAdd.Click += new System.EventHandler(this.btnTNFAdd_Click);
            // 
            // chkVAC2
            // 
            resources.ApplyResources(this.chkVAC2, "chkVAC2");
            this.chkVAC2.FlatAppearance.BorderSize = 0;
            this.chkVAC2.Name = "chkVAC2";
            this.toolTip1.SetToolTip(this.chkVAC2, resources.GetString("chkVAC2.ToolTip"));
            this.chkVAC2.CheckedChanged += new System.EventHandler(this.chkVAC2_CheckedChanged);
            this.chkVAC2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkVAC2_MouseDown);
            // 
            // chkCWSidetone
            // 
            this.chkCWSidetone.Checked = true;
            this.chkCWSidetone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCWSidetone.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.chkCWSidetone, "chkCWSidetone");
            this.chkCWSidetone.Name = "chkCWSidetone";
            this.toolTip1.SetToolTip(this.chkCWSidetone, resources.GetString("chkCWSidetone.ToolTip"));
            this.chkCWSidetone.CheckedChanged += new System.EventHandler(this.chkCWSidetone_CheckedChanged);
            // 
            // udRX1StepAttData
            // 
            this.udRX1StepAttData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.udRX1StepAttData.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.udRX1StepAttData.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            resources.ApplyResources(this.udRX1StepAttData, "udRX1StepAttData");
            this.udRX1StepAttData.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.udRX1StepAttData.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRX1StepAttData.Name = "udRX1StepAttData";
            this.udRX1StepAttData.TinyStep = false;
            this.toolTip1.SetToolTip(this.udRX1StepAttData, resources.GetString("udRX1StepAttData.ToolTip"));
            this.udRX1StepAttData.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRX1StepAttData.ValueChanged += new System.EventHandler(this.udRX1StepAttData_ValueChanged);
            // 
            // comboRX2Preamp
            // 
            this.comboRX2Preamp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboRX2Preamp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRX2Preamp.DropDownWidth = 48;
            resources.ApplyResources(this.comboRX2Preamp, "comboRX2Preamp");
            this.comboRX2Preamp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboRX2Preamp.Name = "comboRX2Preamp";
            this.toolTip1.SetToolTip(this.comboRX2Preamp, resources.GetString("comboRX2Preamp.ToolTip"));
            this.comboRX2Preamp.SelectedIndexChanged += new System.EventHandler(this.comboRX2Preamp_SelectedIndexChanged);
            // 
            // udRX2StepAttData
            // 
            this.udRX2StepAttData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.udRX2StepAttData.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.udRX2StepAttData.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            resources.ApplyResources(this.udRX2StepAttData, "udRX2StepAttData");
            this.udRX2StepAttData.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.udRX2StepAttData.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRX2StepAttData.Name = "udRX2StepAttData";
            this.udRX2StepAttData.TinyStep = false;
            this.toolTip1.SetToolTip(this.udRX2StepAttData, resources.GetString("udRX2StepAttData.ToolTip"));
            this.udRX2StepAttData.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRX2StepAttData.ValueChanged += new System.EventHandler(this.udRX2StepAttData_ValueChanged);
            // 
            // chkCWAPFEnabled
            // 
            resources.ApplyResources(this.chkCWAPFEnabled, "chkCWAPFEnabled");
            this.chkCWAPFEnabled.FlatAppearance.BorderSize = 0;
            this.chkCWAPFEnabled.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkCWAPFEnabled.Name = "chkCWAPFEnabled";
            this.toolTip1.SetToolTip(this.chkCWAPFEnabled, resources.GetString("chkCWAPFEnabled.ToolTip"));
            this.chkCWAPFEnabled.CheckedChanged += new System.EventHandler(this.chkCWAPFEnabled_CheckedChanged);
            this.chkCWAPFEnabled.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chkCWAPFEnabled_MouseDown);
            // 
            // lblBandStack
            // 
            this.lblBandStack.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblBandStack, "lblBandStack");
            this.lblBandStack.Name = "lblBandStack";
            this.toolTip1.SetToolTip(this.lblBandStack, resources.GetString("lblBandStack.ToolTip"));
            this.lblBandStack.Click += new System.EventHandler(this.lblBandStack_Click);
            // 
            // regBandStackCurrentEntry
            // 
            this.regBandStackCurrentEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.regBandStackCurrentEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.regBandStackCurrentEntry.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.regBandStackCurrentEntry, "regBandStackCurrentEntry");
            this.regBandStackCurrentEntry.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.regBandStackCurrentEntry.Name = "regBandStackCurrentEntry";
            this.regBandStackCurrentEntry.ReadOnly = true;
            this.regBandStackCurrentEntry.TabStop = false;
            this.toolTip1.SetToolTip(this.regBandStackCurrentEntry, resources.GetString("regBandStackCurrentEntry.ToolTip"));
            this.regBandStackCurrentEntry.Click += new System.EventHandler(this.regBox1_Click);
            // 
            // regBandStackTotalEntries
            // 
            this.regBandStackTotalEntries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.regBandStackTotalEntries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.regBandStackTotalEntries.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.regBandStackTotalEntries, "regBandStackTotalEntries");
            this.regBandStackTotalEntries.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.regBandStackTotalEntries.Name = "regBandStackTotalEntries";
            this.regBandStackTotalEntries.ReadOnly = true;
            this.toolTip1.SetToolTip(this.regBandStackTotalEntries, resources.GetString("regBandStackTotalEntries.ToolTip"));
            this.regBandStackTotalEntries.Click += new System.EventHandler(this.regBox_Click);
            // 
            // radBandGEN13
            // 
            resources.ApplyResources(this.radBandGEN13, "radBandGEN13");
            this.radBandGEN13.FlatAppearance.BorderSize = 0;
            this.radBandGEN13.ForeColor = System.Drawing.Color.Yellow;
            this.radBandGEN13.Name = "radBandGEN13";
            this.radBandGEN13.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandGEN13, resources.GetString("radBandGEN13.ToolTip"));
            this.radBandGEN13.UseVisualStyleBackColor = true;
            this.radBandGEN13.Click += new System.EventHandler(this.radBandGEN13_Click);
            this.radBandGEN13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandGEN13_MouseDown);
            // 
            // radBandGEN12
            // 
            resources.ApplyResources(this.radBandGEN12, "radBandGEN12");
            this.radBandGEN12.FlatAppearance.BorderSize = 0;
            this.radBandGEN12.ForeColor = System.Drawing.Color.Yellow;
            this.radBandGEN12.Name = "radBandGEN12";
            this.radBandGEN12.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandGEN12, resources.GetString("radBandGEN12.ToolTip"));
            this.radBandGEN12.UseVisualStyleBackColor = false;
            this.radBandGEN12.Click += new System.EventHandler(this.radBandGEN12_Click);
            this.radBandGEN12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandGEN12_MouseDown);
            // 
            // radBandGEN11
            // 
            resources.ApplyResources(this.radBandGEN11, "radBandGEN11");
            this.radBandGEN11.FlatAppearance.BorderSize = 0;
            this.radBandGEN11.ForeColor = System.Drawing.Color.Yellow;
            this.radBandGEN11.Name = "radBandGEN11";
            this.radBandGEN11.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandGEN11, resources.GetString("radBandGEN11.ToolTip"));
            this.radBandGEN11.UseVisualStyleBackColor = true;
            this.radBandGEN11.Click += new System.EventHandler(this.radBandGEN11_Click);
            this.radBandGEN11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandGEN11_MouseDown);
            // 
            // radBandGEN10
            // 
            resources.ApplyResources(this.radBandGEN10, "radBandGEN10");
            this.radBandGEN10.FlatAppearance.BorderSize = 0;
            this.radBandGEN10.ForeColor = System.Drawing.Color.Yellow;
            this.radBandGEN10.Name = "radBandGEN10";
            this.radBandGEN10.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandGEN10, resources.GetString("radBandGEN10.ToolTip"));
            this.radBandGEN10.UseVisualStyleBackColor = true;
            this.radBandGEN10.Click += new System.EventHandler(this.radBandGEN10_Click);
            this.radBandGEN10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandGEN10_MouseDown);
            // 
            // radBandGEN9
            // 
            resources.ApplyResources(this.radBandGEN9, "radBandGEN9");
            this.radBandGEN9.FlatAppearance.BorderSize = 0;
            this.radBandGEN9.ForeColor = System.Drawing.Color.Yellow;
            this.radBandGEN9.Name = "radBandGEN9";
            this.radBandGEN9.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandGEN9, resources.GetString("radBandGEN9.ToolTip"));
            this.radBandGEN9.UseVisualStyleBackColor = true;
            this.radBandGEN9.Click += new System.EventHandler(this.radBandGEN9_Click);
            this.radBandGEN9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandGEN9_MouseDown);
            // 
            // radBandGEN8
            // 
            resources.ApplyResources(this.radBandGEN8, "radBandGEN8");
            this.radBandGEN8.FlatAppearance.BorderSize = 0;
            this.radBandGEN8.ForeColor = System.Drawing.Color.Yellow;
            this.radBandGEN8.Name = "radBandGEN8";
            this.radBandGEN8.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandGEN8, resources.GetString("radBandGEN8.ToolTip"));
            this.radBandGEN8.UseVisualStyleBackColor = true;
            this.radBandGEN8.Click += new System.EventHandler(this.radBandGEN8_Click);
            this.radBandGEN8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandGEN8_MouseDown);
            // 
            // radBandGEN7
            // 
            resources.ApplyResources(this.radBandGEN7, "radBandGEN7");
            this.radBandGEN7.FlatAppearance.BorderSize = 0;
            this.radBandGEN7.ForeColor = System.Drawing.Color.Yellow;
            this.radBandGEN7.Name = "radBandGEN7";
            this.radBandGEN7.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandGEN7, resources.GetString("radBandGEN7.ToolTip"));
            this.radBandGEN7.UseVisualStyleBackColor = true;
            this.radBandGEN7.Click += new System.EventHandler(this.radBandGEN7_Click);
            this.radBandGEN7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandGEN7_MouseDown);
            // 
            // radBandGEN6
            // 
            resources.ApplyResources(this.radBandGEN6, "radBandGEN6");
            this.radBandGEN6.FlatAppearance.BorderSize = 0;
            this.radBandGEN6.ForeColor = System.Drawing.Color.Yellow;
            this.radBandGEN6.Name = "radBandGEN6";
            this.radBandGEN6.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandGEN6, resources.GetString("radBandGEN6.ToolTip"));
            this.radBandGEN6.UseVisualStyleBackColor = true;
            this.radBandGEN6.Click += new System.EventHandler(this.radBandGEN6_Click);
            this.radBandGEN6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandGEN6_MouseDown);
            // 
            // radBandGEN5
            // 
            resources.ApplyResources(this.radBandGEN5, "radBandGEN5");
            this.radBandGEN5.FlatAppearance.BorderSize = 0;
            this.radBandGEN5.ForeColor = System.Drawing.Color.Yellow;
            this.radBandGEN5.Name = "radBandGEN5";
            this.radBandGEN5.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandGEN5, resources.GetString("radBandGEN5.ToolTip"));
            this.radBandGEN5.UseVisualStyleBackColor = true;
            this.radBandGEN5.Click += new System.EventHandler(this.radBandGEN5_Click);
            this.radBandGEN5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandGEN5_MouseDown);
            // 
            // radBandGEN4
            // 
            resources.ApplyResources(this.radBandGEN4, "radBandGEN4");
            this.radBandGEN4.FlatAppearance.BorderSize = 0;
            this.radBandGEN4.ForeColor = System.Drawing.Color.Yellow;
            this.radBandGEN4.Name = "radBandGEN4";
            this.radBandGEN4.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandGEN4, resources.GetString("radBandGEN4.ToolTip"));
            this.radBandGEN4.UseVisualStyleBackColor = true;
            this.radBandGEN4.Click += new System.EventHandler(this.radBandGEN4_Click);
            this.radBandGEN4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandGEN4_MouseDown);
            // 
            // radBandGEN3
            // 
            resources.ApplyResources(this.radBandGEN3, "radBandGEN3");
            this.radBandGEN3.FlatAppearance.BorderSize = 0;
            this.radBandGEN3.ForeColor = System.Drawing.Color.Yellow;
            this.radBandGEN3.Name = "radBandGEN3";
            this.radBandGEN3.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandGEN3, resources.GetString("radBandGEN3.ToolTip"));
            this.radBandGEN3.UseVisualStyleBackColor = true;
            this.radBandGEN3.Click += new System.EventHandler(this.radBandGEN3_Click);
            this.radBandGEN3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandGEN3_MouseDown);
            // 
            // radBandGEN2
            // 
            resources.ApplyResources(this.radBandGEN2, "radBandGEN2");
            this.radBandGEN2.FlatAppearance.BorderSize = 0;
            this.radBandGEN2.ForeColor = System.Drawing.Color.Yellow;
            this.radBandGEN2.Name = "radBandGEN2";
            this.radBandGEN2.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandGEN2, resources.GetString("radBandGEN2.ToolTip"));
            this.radBandGEN2.UseVisualStyleBackColor = true;
            this.radBandGEN2.Click += new System.EventHandler(this.radBandGEN2_Click);
            this.radBandGEN2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandGEN2_MouseDown);
            // 
            // radBandGEN1
            // 
            resources.ApplyResources(this.radBandGEN1, "radBandGEN1");
            this.radBandGEN1.FlatAppearance.BorderSize = 0;
            this.radBandGEN1.ForeColor = System.Drawing.Color.Yellow;
            this.radBandGEN1.Name = "radBandGEN1";
            this.radBandGEN1.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandGEN1, resources.GetString("radBandGEN1.ToolTip"));
            this.radBandGEN1.UseVisualStyleBackColor = true;
            this.radBandGEN1.Click += new System.EventHandler(this.radBandGEN1_Click);
            this.radBandGEN1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandGEN1_MouseDown);
            // 
            // radBandGEN0
            // 
            resources.ApplyResources(this.radBandGEN0, "radBandGEN0");
            this.radBandGEN0.FlatAppearance.BorderSize = 0;
            this.radBandGEN0.ForeColor = System.Drawing.Color.Yellow;
            this.radBandGEN0.Name = "radBandGEN0";
            this.radBandGEN0.TabStop = true;
            this.toolTip1.SetToolTip(this.radBandGEN0, resources.GetString("radBandGEN0.ToolTip"));
            this.radBandGEN0.UseVisualStyleBackColor = true;
            this.radBandGEN0.Click += new System.EventHandler(this.radBandGEN0_Click);
            this.radBandGEN0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandGEN0_MouseDown);
            // 
            // chkRxAnt
            // 
            resources.ApplyResources(this.chkRxAnt, "chkRxAnt");
            this.chkRxAnt.FlatAppearance.BorderSize = 0;
            this.chkRxAnt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRxAnt.Name = "chkRxAnt";
            this.toolTip1.SetToolTip(this.chkRxAnt, resources.GetString("chkRxAnt.ToolTip"));
            this.chkRxAnt.CheckedChanged += new System.EventHandler(this.chkRxAnt_CheckedChanged);
            // 
            // chkVFOBLock
            // 
            resources.ApplyResources(this.chkVFOBLock, "chkVFOBLock");
            this.chkVFOBLock.FlatAppearance.BorderSize = 0;
            this.chkVFOBLock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkVFOBLock.Name = "chkVFOBLock";
            this.toolTip1.SetToolTip(this.chkVFOBLock, resources.GetString("chkVFOBLock.ToolTip"));
            this.chkVFOBLock.CheckedChanged += new System.EventHandler(this.chkVFOBLock_CheckedChanged);
            // 
            // chkQSK
            // 
            resources.ApplyResources(this.chkQSK, "chkQSK");
            this.chkQSK.Checked = true;
            this.chkQSK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkQSK.FlatAppearance.BorderSize = 0;
            this.chkQSK.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkQSK.Name = "chkQSK";
            this.chkQSK.ThreeState = true;
            this.toolTip1.SetToolTip(this.chkQSK, resources.GetString("chkQSK.ToolTip"));
            this.chkQSK.CheckStateChanged += new System.EventHandler(this.chkQSK_CheckStateChanged);
            // 
            // btnDisplayZTB
            // 
            resources.ApplyResources(this.btnDisplayZTB, "btnDisplayZTB");
            this.btnDisplayZTB.FlatAppearance.BorderSize = 0;
            this.btnDisplayZTB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDisplayZTB.Name = "btnDisplayZTB";
            this.btnDisplayZTB.Selectable = true;
            this.btnDisplayZTB.Tag = "Zoom to band";
            this.toolTip1.SetToolTip(this.btnDisplayZTB, resources.GetString("btnDisplayZTB.ToolTip"));
            this.btnDisplayZTB.Click += new System.EventHandler(this.btnDisplayZTB_Click);
            this.btnDisplayZTB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDisplayZTB_MouseUp);
            // 
            // ptbFilterShift
            // 
            resources.ApplyResources(this.ptbFilterShift, "ptbFilterShift");
            this.ptbFilterShift.GreenThumb = false;
            this.ptbFilterShift.HeadImage = null;
            this.ptbFilterShift.LargeChange = 1;
            this.ptbFilterShift.LimitBarColor = System.Drawing.Color.Red;
            this.ptbFilterShift.LimitEnabled = false;
            this.ptbFilterShift.LimitValue = 0;
            this.ptbFilterShift.Maximum = 1000;
            this.ptbFilterShift.Minimum = -1000;
            this.ptbFilterShift.Name = "ptbFilterShift";
            this.ptbFilterShift.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbFilterShift.SmallChange = 1;
            this.ptbFilterShift.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbFilterShift, resources.GetString("ptbFilterShift.ToolTip"));
            this.ptbFilterShift.Value = 0;
            this.ptbFilterShift.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbFilterShift_Scroll);
            // 
            // ptbFilterWidth
            // 
            resources.ApplyResources(this.ptbFilterWidth, "ptbFilterWidth");
            this.ptbFilterWidth.GreenThumb = false;
            this.ptbFilterWidth.HeadImage = null;
            this.ptbFilterWidth.LargeChange = 1;
            this.ptbFilterWidth.LimitBarColor = System.Drawing.Color.Red;
            this.ptbFilterWidth.LimitEnabled = false;
            this.ptbFilterWidth.LimitValue = 0;
            this.ptbFilterWidth.Maximum = 15000;
            this.ptbFilterWidth.Minimum = 0;
            this.ptbFilterWidth.Name = "ptbFilterWidth";
            this.ptbFilterWidth.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbFilterWidth.SmallChange = 1;
            this.ptbFilterWidth.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbFilterWidth, resources.GetString("ptbFilterWidth.ToolTip"));
            this.ptbFilterWidth.Value = 10;
            this.ptbFilterWidth.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbFilterWidth_Scroll);
            // 
            // ptbRX2RF
            // 
            resources.ApplyResources(this.ptbRX2RF, "ptbRX2RF");
            this.ptbRX2RF.GreenThumb = false;
            this.ptbRX2RF.HeadImage = null;
            this.ptbRX2RF.LargeChange = 1;
            this.ptbRX2RF.LimitBarColor = System.Drawing.Color.Red;
            this.ptbRX2RF.LimitEnabled = false;
            this.ptbRX2RF.LimitValue = 0;
            this.ptbRX2RF.Maximum = 120;
            this.ptbRX2RF.Minimum = -20;
            this.ptbRX2RF.Name = "ptbRX2RF";
            this.ptbRX2RF.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbRX2RF.SmallChange = 1;
            this.ptbRX2RF.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbRX2RF, resources.GetString("ptbRX2RF.ToolTip"));
            this.ptbRX2RF.Value = 90;
            this.ptbRX2RF.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbRX2RF_Scroll);
            this.ptbRX2RF.Click += new System.EventHandler(this.ptbRX2RF_Click);
            this.ptbRX2RF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptbRX2RF_MouseDown);
            // 
            // ptbCWSpeed
            // 
            resources.ApplyResources(this.ptbCWSpeed, "ptbCWSpeed");
            this.ptbCWSpeed.GreenThumb = false;
            this.ptbCWSpeed.HeadImage = null;
            this.ptbCWSpeed.LargeChange = 1;
            this.ptbCWSpeed.LimitBarColor = System.Drawing.Color.Red;
            this.ptbCWSpeed.LimitEnabled = false;
            this.ptbCWSpeed.LimitValue = 1;
            this.ptbCWSpeed.Maximum = 60;
            this.ptbCWSpeed.Minimum = 1;
            this.ptbCWSpeed.Name = "ptbCWSpeed";
            this.ptbCWSpeed.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbCWSpeed.SmallChange = 1;
            this.ptbCWSpeed.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbCWSpeed, resources.GetString("ptbCWSpeed.ToolTip"));
            this.ptbCWSpeed.Value = 25;
            this.ptbCWSpeed.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbCWSpeed_Scroll);
            // 
            // ptbDisplayZoom
            // 
            resources.ApplyResources(this.ptbDisplayZoom, "ptbDisplayZoom");
            this.ptbDisplayZoom.GreenThumb = false;
            this.ptbDisplayZoom.HeadImage = null;
            this.ptbDisplayZoom.LargeChange = 1;
            this.ptbDisplayZoom.LimitBarColor = System.Drawing.Color.Red;
            this.ptbDisplayZoom.LimitEnabled = false;
            this.ptbDisplayZoom.LimitValue = 10;
            this.ptbDisplayZoom.Maximum = 240;
            this.ptbDisplayZoom.Minimum = 10;
            this.ptbDisplayZoom.Name = "ptbDisplayZoom";
            this.ptbDisplayZoom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbDisplayZoom.SmallChange = 1;
            this.ptbDisplayZoom.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbDisplayZoom, resources.GetString("ptbDisplayZoom.ToolTip"));
            this.ptbDisplayZoom.Value = 150;
            this.ptbDisplayZoom.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbDisplayZoom_Scroll);
            // 
            // ptbDisplayPan
            // 
            resources.ApplyResources(this.ptbDisplayPan, "ptbDisplayPan");
            this.ptbDisplayPan.GreenThumb = false;
            this.ptbDisplayPan.HeadImage = null;
            this.ptbDisplayPan.LargeChange = 1;
            this.ptbDisplayPan.LimitBarColor = System.Drawing.Color.Red;
            this.ptbDisplayPan.LimitEnabled = false;
            this.ptbDisplayPan.LimitValue = 0;
            this.ptbDisplayPan.Maximum = 1000;
            this.ptbDisplayPan.Minimum = 0;
            this.ptbDisplayPan.Name = "ptbDisplayPan";
            this.ptbDisplayPan.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbDisplayPan.SmallChange = 1;
            this.ptbDisplayPan.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbDisplayPan, resources.GetString("ptbDisplayPan.ToolTip"));
            this.ptbDisplayPan.Value = 500;
            this.ptbDisplayPan.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbDisplayPan_Scroll);
            // 
            // ptbPWR
            // 
            resources.ApplyResources(this.ptbPWR, "ptbPWR");
            this.ptbPWR.GreenThumb = false;
            this.ptbPWR.HeadImage = null;
            this.ptbPWR.LargeChange = 1;
            this.ptbPWR.LimitBarColor = System.Drawing.Color.Red;
            this.ptbPWR.LimitEnabled = true;
            this.ptbPWR.LimitValue = 50;
            this.ptbPWR.Maximum = 100;
            this.ptbPWR.Minimum = 0;
            this.ptbPWR.Name = "ptbPWR";
            this.ptbPWR.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbPWR.SmallChange = 1;
            this.ptbPWR.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbPWR, resources.GetString("ptbPWR.ToolTip"));
            this.ptbPWR.Value = 50;
            this.ptbPWR.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbPWR_Scroll);
            this.ptbPWR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ptbPWR_MouseUp);
            // 
            // ptbRF
            // 
            resources.ApplyResources(this.ptbRF, "ptbRF");
            this.ptbRF.GreenThumb = false;
            this.ptbRF.HeadImage = null;
            this.ptbRF.LargeChange = 1;
            this.ptbRF.LimitBarColor = System.Drawing.Color.Red;
            this.ptbRF.LimitEnabled = false;
            this.ptbRF.LimitValue = 0;
            this.ptbRF.Maximum = 120;
            this.ptbRF.Minimum = -20;
            this.ptbRF.Name = "ptbRF";
            this.ptbRF.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbRF.SmallChange = 1;
            this.ptbRF.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbRF, resources.GetString("ptbRF.ToolTip"));
            this.ptbRF.Value = 90;
            this.ptbRF.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbRF_Scroll);
            this.ptbRF.Click += new System.EventHandler(this.ptbRF_Click);
            this.ptbRF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptbRF_MouseDown);
            // 
            // ptbAF
            // 
            resources.ApplyResources(this.ptbAF, "ptbAF");
            this.ptbAF.GreenThumb = false;
            this.ptbAF.HeadImage = null;
            this.ptbAF.LargeChange = 1;
            this.ptbAF.LimitBarColor = System.Drawing.Color.Red;
            this.ptbAF.LimitEnabled = false;
            this.ptbAF.LimitValue = 0;
            this.ptbAF.Maximum = 100;
            this.ptbAF.Minimum = 0;
            this.ptbAF.Name = "ptbAF";
            this.ptbAF.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbAF.SmallChange = 1;
            this.ptbAF.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbAF, resources.GetString("ptbAF.ToolTip"));
            this.ptbAF.Value = 30;
            this.ptbAF.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbAF_Scroll);
            this.ptbAF.DoubleClick += new System.EventHandler(this.ptbAF_DoubleClick);
            // 
            // ptbPanMainRX
            // 
            resources.ApplyResources(this.ptbPanMainRX, "ptbPanMainRX");
            this.ptbPanMainRX.GreenThumb = false;
            this.ptbPanMainRX.HeadImage = null;
            this.ptbPanMainRX.LargeChange = 1;
            this.ptbPanMainRX.LimitBarColor = System.Drawing.Color.Red;
            this.ptbPanMainRX.LimitEnabled = false;
            this.ptbPanMainRX.LimitValue = 0;
            this.ptbPanMainRX.Maximum = 100;
            this.ptbPanMainRX.Minimum = 0;
            this.ptbPanMainRX.Name = "ptbPanMainRX";
            this.ptbPanMainRX.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbPanMainRX.SmallChange = 1;
            this.ptbPanMainRX.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbPanMainRX, resources.GetString("ptbPanMainRX.ToolTip"));
            this.ptbPanMainRX.Value = 50;
            this.ptbPanMainRX.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbPanMainRX_Scroll);
            this.ptbPanMainRX.DoubleClick += new System.EventHandler(this.ptbPanMainRX_DoubleClick);
            // 
            // ptbPanSubRX
            // 
            resources.ApplyResources(this.ptbPanSubRX, "ptbPanSubRX");
            this.ptbPanSubRX.GreenThumb = false;
            this.ptbPanSubRX.HeadImage = null;
            this.ptbPanSubRX.LargeChange = 1;
            this.ptbPanSubRX.LimitBarColor = System.Drawing.Color.Red;
            this.ptbPanSubRX.LimitEnabled = false;
            this.ptbPanSubRX.LimitValue = 0;
            this.ptbPanSubRX.Maximum = 100;
            this.ptbPanSubRX.Minimum = 0;
            this.ptbPanSubRX.Name = "ptbPanSubRX";
            this.ptbPanSubRX.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbPanSubRX.SmallChange = 1;
            this.ptbPanSubRX.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbPanSubRX, resources.GetString("ptbPanSubRX.ToolTip"));
            this.ptbPanSubRX.Value = 50;
            this.ptbPanSubRX.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbPanSubRX_Scroll);
            this.ptbPanSubRX.DoubleClick += new System.EventHandler(this.ptbPanSubRX_DoubleClick);
            // 
            // ptbRX2Gain
            // 
            resources.ApplyResources(this.ptbRX2Gain, "ptbRX2Gain");
            this.ptbRX2Gain.GreenThumb = false;
            this.ptbRX2Gain.HeadImage = null;
            this.ptbRX2Gain.LargeChange = 1;
            this.ptbRX2Gain.LimitBarColor = System.Drawing.Color.Red;
            this.ptbRX2Gain.LimitEnabled = false;
            this.ptbRX2Gain.LimitValue = 0;
            this.ptbRX2Gain.Maximum = 100;
            this.ptbRX2Gain.Minimum = 0;
            this.ptbRX2Gain.Name = "ptbRX2Gain";
            this.ptbRX2Gain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ptbRX2Gain.SmallChange = 1;
            this.ptbRX2Gain.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbRX2Gain, resources.GetString("ptbRX2Gain.ToolTip"));
            this.ptbRX2Gain.Value = 0;
            this.ptbRX2Gain.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbRX2Gain_Scroll);
            // 
            // ptbRX2Pan
            // 
            resources.ApplyResources(this.ptbRX2Pan, "ptbRX2Pan");
            this.ptbRX2Pan.GreenThumb = false;
            this.ptbRX2Pan.HeadImage = null;
            this.ptbRX2Pan.LargeChange = 1;
            this.ptbRX2Pan.LimitBarColor = System.Drawing.Color.Red;
            this.ptbRX2Pan.LimitEnabled = false;
            this.ptbRX2Pan.LimitValue = 0;
            this.ptbRX2Pan.Maximum = 100;
            this.ptbRX2Pan.Minimum = 0;
            this.ptbRX2Pan.Name = "ptbRX2Pan";
            this.ptbRX2Pan.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbRX2Pan.SmallChange = 1;
            this.ptbRX2Pan.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbRX2Pan, resources.GetString("ptbRX2Pan.ToolTip"));
            this.ptbRX2Pan.Value = 50;
            this.ptbRX2Pan.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbRX2Pan_Scroll);
            this.ptbRX2Pan.DoubleClick += new System.EventHandler(this.ptbRX2Pan_DoubleClick);
            // 
            // ptbRX0Gain
            // 
            resources.ApplyResources(this.ptbRX0Gain, "ptbRX0Gain");
            this.ptbRX0Gain.GreenThumb = false;
            this.ptbRX0Gain.HeadImage = null;
            this.ptbRX0Gain.LargeChange = 1;
            this.ptbRX0Gain.LimitBarColor = System.Drawing.Color.Red;
            this.ptbRX0Gain.LimitEnabled = false;
            this.ptbRX0Gain.LimitValue = 0;
            this.ptbRX0Gain.Maximum = 100;
            this.ptbRX0Gain.Minimum = 0;
            this.ptbRX0Gain.Name = "ptbRX0Gain";
            this.ptbRX0Gain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ptbRX0Gain.SmallChange = 1;
            this.ptbRX0Gain.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbRX0Gain, resources.GetString("ptbRX0Gain.ToolTip"));
            this.ptbRX0Gain.Value = 20;
            this.ptbRX0Gain.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbRX0Gain_Scroll);
            // 
            // ptbRX1Gain
            // 
            resources.ApplyResources(this.ptbRX1Gain, "ptbRX1Gain");
            this.ptbRX1Gain.GreenThumb = false;
            this.ptbRX1Gain.HeadImage = null;
            this.ptbRX1Gain.LargeChange = 1;
            this.ptbRX1Gain.LimitBarColor = System.Drawing.Color.Red;
            this.ptbRX1Gain.LimitEnabled = false;
            this.ptbRX1Gain.LimitValue = 0;
            this.ptbRX1Gain.Maximum = 100;
            this.ptbRX1Gain.Minimum = 0;
            this.ptbRX1Gain.Name = "ptbRX1Gain";
            this.ptbRX1Gain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ptbRX1Gain.SmallChange = 1;
            this.ptbRX1Gain.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbRX1Gain, resources.GetString("ptbRX1Gain.ToolTip"));
            this.ptbRX1Gain.Value = 100;
            this.ptbRX1Gain.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbRX1Gain_Scroll);
            // 
            // ptbVACRXGain
            // 
            resources.ApplyResources(this.ptbVACRXGain, "ptbVACRXGain");
            this.ptbVACRXGain.GreenThumb = false;
            this.ptbVACRXGain.HeadImage = null;
            this.ptbVACRXGain.LargeChange = 1;
            this.ptbVACRXGain.LimitBarColor = System.Drawing.Color.Red;
            this.ptbVACRXGain.LimitEnabled = false;
            this.ptbVACRXGain.LimitValue = 0;
            this.ptbVACRXGain.Maximum = 40;
            this.ptbVACRXGain.Minimum = -40;
            this.ptbVACRXGain.Name = "ptbVACRXGain";
            this.ptbVACRXGain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbVACRXGain.SmallChange = 1;
            this.ptbVACRXGain.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbVACRXGain, resources.GetString("ptbVACRXGain.ToolTip"));
            this.ptbVACRXGain.Value = 0;
            this.ptbVACRXGain.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbVACRXGain_Scroll);
            // 
            // ptbVACTXGain
            // 
            resources.ApplyResources(this.ptbVACTXGain, "ptbVACTXGain");
            this.ptbVACTXGain.GreenThumb = false;
            this.ptbVACTXGain.HeadImage = null;
            this.ptbVACTXGain.LargeChange = 1;
            this.ptbVACTXGain.LimitBarColor = System.Drawing.Color.Red;
            this.ptbVACTXGain.LimitEnabled = false;
            this.ptbVACTXGain.LimitValue = 0;
            this.ptbVACTXGain.Maximum = 40;
            this.ptbVACTXGain.Minimum = -40;
            this.ptbVACTXGain.Name = "ptbVACTXGain";
            this.ptbVACTXGain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbVACTXGain.SmallChange = 1;
            this.ptbVACTXGain.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbVACTXGain, resources.GetString("ptbVACTXGain.ToolTip"));
            this.ptbVACTXGain.Value = 0;
            this.ptbVACTXGain.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbVACTXGain_Scroll);
            // 
            // ptbRX2AF
            // 
            resources.ApplyResources(this.ptbRX2AF, "ptbRX2AF");
            this.ptbRX2AF.GreenThumb = false;
            this.ptbRX2AF.HeadImage = null;
            this.ptbRX2AF.LargeChange = 1;
            this.ptbRX2AF.LimitBarColor = System.Drawing.Color.Red;
            this.ptbRX2AF.LimitEnabled = false;
            this.ptbRX2AF.LimitValue = 0;
            this.ptbRX2AF.Maximum = 100;
            this.ptbRX2AF.Minimum = 0;
            this.ptbRX2AF.Name = "ptbRX2AF";
            this.ptbRX2AF.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbRX2AF.SmallChange = 1;
            this.ptbRX2AF.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbRX2AF, resources.GetString("ptbRX2AF.ToolTip"));
            this.ptbRX2AF.Value = 0;
            this.ptbRX2AF.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbRX2AF_Scroll);
            this.ptbRX2AF.DoubleClick += new System.EventHandler(this.ptbRX2AF_DoubleClick);
            // 
            // ptbRX1AF
            // 
            resources.ApplyResources(this.ptbRX1AF, "ptbRX1AF");
            this.ptbRX1AF.GreenThumb = false;
            this.ptbRX1AF.HeadImage = null;
            this.ptbRX1AF.LargeChange = 1;
            this.ptbRX1AF.LimitBarColor = System.Drawing.Color.Red;
            this.ptbRX1AF.LimitEnabled = false;
            this.ptbRX1AF.LimitValue = 0;
            this.ptbRX1AF.Maximum = 100;
            this.ptbRX1AF.Minimum = 0;
            this.ptbRX1AF.Name = "ptbRX1AF";
            this.ptbRX1AF.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbRX1AF.SmallChange = 1;
            this.ptbRX1AF.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbRX1AF, resources.GetString("ptbRX1AF.ToolTip"));
            this.ptbRX1AF.Value = 20;
            this.ptbRX1AF.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbRX1AF_Scroll);
            this.ptbRX1AF.DoubleClick += new System.EventHandler(this.ptbRX1AF_DoubleClick);
            // 
            // ptbCWAPFGain
            // 
            resources.ApplyResources(this.ptbCWAPFGain, "ptbCWAPFGain");
            this.ptbCWAPFGain.GreenThumb = false;
            this.ptbCWAPFGain.HeadImage = null;
            this.ptbCWAPFGain.LargeChange = 1;
            this.ptbCWAPFGain.LimitBarColor = System.Drawing.Color.Red;
            this.ptbCWAPFGain.LimitEnabled = false;
            this.ptbCWAPFGain.LimitValue = 0;
            this.ptbCWAPFGain.Maximum = 100;
            this.ptbCWAPFGain.Minimum = 0;
            this.ptbCWAPFGain.Name = "ptbCWAPFGain";
            this.ptbCWAPFGain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbCWAPFGain.SmallChange = 1;
            this.ptbCWAPFGain.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbCWAPFGain, resources.GetString("ptbCWAPFGain.ToolTip"));
            this.ptbCWAPFGain.Value = 0;
            this.ptbCWAPFGain.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbCWAPFGain_Scroll);
            // 
            // ptbCWAPFBandwidth
            // 
            resources.ApplyResources(this.ptbCWAPFBandwidth, "ptbCWAPFBandwidth");
            this.ptbCWAPFBandwidth.GreenThumb = false;
            this.ptbCWAPFBandwidth.HeadImage = null;
            this.ptbCWAPFBandwidth.LargeChange = 1;
            this.ptbCWAPFBandwidth.LimitBarColor = System.Drawing.Color.Red;
            this.ptbCWAPFBandwidth.LimitEnabled = false;
            this.ptbCWAPFBandwidth.LimitValue = 10;
            this.ptbCWAPFBandwidth.Maximum = 150;
            this.ptbCWAPFBandwidth.Minimum = 10;
            this.ptbCWAPFBandwidth.Name = "ptbCWAPFBandwidth";
            this.ptbCWAPFBandwidth.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbCWAPFBandwidth.SmallChange = 1;
            this.ptbCWAPFBandwidth.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbCWAPFBandwidth, resources.GetString("ptbCWAPFBandwidth.ToolTip"));
            this.ptbCWAPFBandwidth.Value = 150;
            this.ptbCWAPFBandwidth.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbCWAPFBandwidth_Scroll);
            // 
            // ptbCWAPFFreq
            // 
            resources.ApplyResources(this.ptbCWAPFFreq, "ptbCWAPFFreq");
            this.ptbCWAPFFreq.GreenThumb = false;
            this.ptbCWAPFFreq.HeadImage = null;
            this.ptbCWAPFFreq.LargeChange = 1;
            this.ptbCWAPFFreq.LimitBarColor = System.Drawing.Color.Red;
            this.ptbCWAPFFreq.LimitEnabled = false;
            this.ptbCWAPFFreq.LimitValue = 0;
            this.ptbCWAPFFreq.Maximum = 250;
            this.ptbCWAPFFreq.Minimum = -250;
            this.ptbCWAPFFreq.Name = "ptbCWAPFFreq";
            this.ptbCWAPFFreq.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbCWAPFFreq.SmallChange = 1;
            this.ptbCWAPFFreq.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbCWAPFFreq, resources.GetString("ptbCWAPFFreq.ToolTip"));
            this.ptbCWAPFFreq.Value = 0;
            this.ptbCWAPFFreq.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbCWAPFFreq_Scroll);
            // 
            // ptbTune
            // 
            resources.ApplyResources(this.ptbTune, "ptbTune");
            this.ptbTune.GreenThumb = false;
            this.ptbTune.HeadImage = null;
            this.ptbTune.LargeChange = 1;
            this.ptbTune.LimitBarColor = System.Drawing.Color.Red;
            this.ptbTune.LimitEnabled = true;
            this.ptbTune.LimitValue = 50;
            this.ptbTune.Maximum = 100;
            this.ptbTune.Minimum = 0;
            this.ptbTune.Name = "ptbTune";
            this.ptbTune.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbTune.SmallChange = 1;
            this.ptbTune.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbTune, resources.GetString("ptbTune.ToolTip"));
            this.ptbTune.Value = 50;
            this.ptbTune.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbTune_Scroll);
            this.ptbTune.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ptbTune_MouseUp);
            // 
            // udTXStepAttData
            // 
            this.udTXStepAttData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.udTXStepAttData.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.udTXStepAttData.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            resources.ApplyResources(this.udTXStepAttData, "udTXStepAttData");
            this.udTXStepAttData.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.udTXStepAttData.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udTXStepAttData.Name = "udTXStepAttData";
            this.udTXStepAttData.TinyStep = false;
            this.toolTip1.SetToolTip(this.udTXStepAttData, resources.GetString("udTXStepAttData.ToolTip"));
            this.udTXStepAttData.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udTXStepAttData.ValueChanged += new System.EventHandler(this.udTXStepAttData_ValueChanged);
            // 
            // pbAutoAttWarningRX1
            // 
            resources.ApplyResources(this.pbAutoAttWarningRX1, "pbAutoAttWarningRX1");
            this.pbAutoAttWarningRX1.Name = "pbAutoAttWarningRX1";
            this.pbAutoAttWarningRX1.TabStop = false;
            this.toolTip1.SetToolTip(this.pbAutoAttWarningRX1, resources.GetString("pbAutoAttWarningRX1.ToolTip"));
            // 
            // pbAutoAttWarningRX2
            // 
            resources.ApplyResources(this.pbAutoAttWarningRX2, "pbAutoAttWarningRX2");
            this.pbAutoAttWarningRX2.Name = "pbAutoAttWarningRX2";
            this.pbAutoAttWarningRX2.TabStop = false;
            this.toolTip1.SetToolTip(this.pbAutoAttWarningRX2, resources.GetString("pbAutoAttWarningRX2.ToolTip"));
            // 
            // radBand2
            // 
            resources.ApplyResources(this.radBand2, "radBand2");
            this.radBand2.FlatAppearance.BorderSize = 0;
            this.radBand2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radBand2.Name = "radBand2";
            this.radBand2.TabStop = true;
            this.radBand2.UseVisualStyleBackColor = true;
            // 
            // timer_clock
            // 
            this.timer_clock.Enabled = true;
            this.timer_clock.Interval = 1000;
            this.timer_clock.Tick += new System.EventHandler(this.timer_clock_Tick);
            // 
            // contextMenuStripFilterRX1
            // 
            this.contextMenuStripFilterRX1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripFilterRX1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemRX1FilterConfigure,
            this.toolStripMenuItemRX1FilterReset});
            this.contextMenuStripFilterRX1.Name = "contextMenuStripFilterRX1";
            resources.ApplyResources(this.contextMenuStripFilterRX1, "contextMenuStripFilterRX1");
            // 
            // toolStripMenuItemRX1FilterConfigure
            // 
            this.toolStripMenuItemRX1FilterConfigure.Name = "toolStripMenuItemRX1FilterConfigure";
            resources.ApplyResources(this.toolStripMenuItemRX1FilterConfigure, "toolStripMenuItemRX1FilterConfigure");
            this.toolStripMenuItemRX1FilterConfigure.Click += new System.EventHandler(this.toolStripMenuItemRX1FilterConfigure_Click);
            // 
            // toolStripMenuItemRX1FilterReset
            // 
            this.toolStripMenuItemRX1FilterReset.Name = "toolStripMenuItemRX1FilterReset";
            resources.ApplyResources(this.toolStripMenuItemRX1FilterReset, "toolStripMenuItemRX1FilterReset");
            this.toolStripMenuItemRX1FilterReset.Click += new System.EventHandler(this.toolStripMenuItemRX1FilterReset_Click);
            // 
            // contextMenuStripFilterRX2
            // 
            this.contextMenuStripFilterRX2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripFilterRX2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemRX2FilterConfigure,
            this.toolStripMenuItemRX2FilterReset});
            this.contextMenuStripFilterRX2.Name = "contextMenuStripFilterRX2";
            resources.ApplyResources(this.contextMenuStripFilterRX2, "contextMenuStripFilterRX2");
            // 
            // toolStripMenuItemRX2FilterConfigure
            // 
            this.toolStripMenuItemRX2FilterConfigure.Name = "toolStripMenuItemRX2FilterConfigure";
            resources.ApplyResources(this.toolStripMenuItemRX2FilterConfigure, "toolStripMenuItemRX2FilterConfigure");
            this.toolStripMenuItemRX2FilterConfigure.Click += new System.EventHandler(this.toolStripMenuItemRX2FilterConfigure_Click);
            // 
            // toolStripMenuItemRX2FilterReset
            // 
            this.toolStripMenuItemRX2FilterReset.Name = "toolStripMenuItemRX2FilterReset";
            resources.ApplyResources(this.toolStripMenuItemRX2FilterReset, "toolStripMenuItemRX2FilterReset");
            this.toolStripMenuItemRX2FilterReset.Click += new System.EventHandler(this.toolStripMenuItemRX2FilterReset_Click);
            // 
            // contextMenuStripNotch
            // 
            this.contextMenuStripNotch.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripNotch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNotchDelete,
            this.toolStripNotchRemember,
            this.toolStripSeparator1,
            this.toolStripNotchNormal,
            this.toolStripNotchDeep,
            this.toolStripNotchVeryDeep});
            this.contextMenuStripNotch.Name = "contextMenuStripNotch";
            resources.ApplyResources(this.contextMenuStripNotch, "contextMenuStripNotch");
            // 
            // toolStripNotchDelete
            // 
            this.toolStripNotchDelete.Name = "toolStripNotchDelete";
            resources.ApplyResources(this.toolStripNotchDelete, "toolStripNotchDelete");
            this.toolStripNotchDelete.Click += new System.EventHandler(this.toolStripNotchDelete_Click);
            // 
            // toolStripNotchRemember
            // 
            this.toolStripNotchRemember.Name = "toolStripNotchRemember";
            resources.ApplyResources(this.toolStripNotchRemember, "toolStripNotchRemember");
            this.toolStripNotchRemember.Click += new System.EventHandler(this.toolStripNotchRemember_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripNotchNormal
            // 
            this.toolStripNotchNormal.Name = "toolStripNotchNormal";
            resources.ApplyResources(this.toolStripNotchNormal, "toolStripNotchNormal");
            this.toolStripNotchNormal.Click += new System.EventHandler(this.toolStripNotchNormal_Click);
            // 
            // toolStripNotchDeep
            // 
            this.toolStripNotchDeep.Name = "toolStripNotchDeep";
            resources.ApplyResources(this.toolStripNotchDeep, "toolStripNotchDeep");
            this.toolStripNotchDeep.Click += new System.EventHandler(this.toolStripNotchDeep_Click);
            // 
            // toolStripNotchVeryDeep
            // 
            this.toolStripNotchVeryDeep.Name = "toolStripNotchVeryDeep";
            resources.ApplyResources(this.toolStripNotchVeryDeep, "toolStripNotchVeryDeep");
            this.toolStripNotchVeryDeep.Click += new System.EventHandler(this.toolStripNotchVeryDeep_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem,
            this.memoryToolStripMenuItem,
            this.waveToolStripMenuItem,
            this.equalizerToolStripMenuItem,
            this.xVTRsToolStripMenuItem,
            this.cWXToolStripMenuItem,
            this.eSCToolStripMenuItem,
            this.collapseToolStripMenuItem,
            this.spotterMenu,
            this.displayControlsToolStripMenuItem,
            this.dSPToolStripMenuItem,
            this.bandToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.rX2ToolStripMenuItem,
            this.linearityToolStripMenuItem,
            this.RAtoolStripMenuItem,
            this.wBToolStripMenuItem,
            this.pIToolStripMenuItem,
            this.BPFToolStripMenuItem,
            this.finderMenuItem,
            this.miAbout});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.databaseManagerToolStripMenuItem});
            this.setupToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            resources.ApplyResources(this.setupToolStripMenuItem, "setupToolStripMenuItem");
            this.setupToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.setupToolStripMenuItem_MouseUp);
            // 
            // setupToolStripMenuItem1
            // 
            this.setupToolStripMenuItem1.Name = "setupToolStripMenuItem1";
            resources.ApplyResources(this.setupToolStripMenuItem1, "setupToolStripMenuItem1");
            this.setupToolStripMenuItem1.Click += new System.EventHandler(this.setupToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // databaseManagerToolStripMenuItem
            // 
            this.databaseManagerToolStripMenuItem.Name = "databaseManagerToolStripMenuItem";
            resources.ApplyResources(this.databaseManagerToolStripMenuItem, "databaseManagerToolStripMenuItem");
            this.databaseManagerToolStripMenuItem.Click += new System.EventHandler(this.databaseManagerToolStripMenuItem_Click);
            // 
            // memoryToolStripMenuItem
            // 
            this.memoryToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.memoryToolStripMenuItem.Name = "memoryToolStripMenuItem";
            resources.ApplyResources(this.memoryToolStripMenuItem, "memoryToolStripMenuItem");
            this.memoryToolStripMenuItem.Click += new System.EventHandler(this.memoryToolStripMenuItem_Click);
            // 
            // waveToolStripMenuItem
            // 
            this.waveToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.waveToolStripMenuItem.Name = "waveToolStripMenuItem";
            resources.ApplyResources(this.waveToolStripMenuItem, "waveToolStripMenuItem");
            this.waveToolStripMenuItem.Click += new System.EventHandler(this.waveToolStripMenuItem_Click);
            // 
            // equalizerToolStripMenuItem
            // 
            this.equalizerToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.equalizerToolStripMenuItem.Name = "equalizerToolStripMenuItem";
            resources.ApplyResources(this.equalizerToolStripMenuItem, "equalizerToolStripMenuItem");
            this.equalizerToolStripMenuItem.Click += new System.EventHandler(this.equalizerToolStripMenuItem_Click);
            // 
            // xVTRsToolStripMenuItem
            // 
            this.xVTRsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.xVTRsToolStripMenuItem.Name = "xVTRsToolStripMenuItem";
            resources.ApplyResources(this.xVTRsToolStripMenuItem, "xVTRsToolStripMenuItem");
            this.xVTRsToolStripMenuItem.Click += new System.EventHandler(this.xVTRsToolStripMenuItem_Click);
            // 
            // cWXToolStripMenuItem
            // 
            this.cWXToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cWXToolStripMenuItem.Name = "cWXToolStripMenuItem";
            resources.ApplyResources(this.cWXToolStripMenuItem, "cWXToolStripMenuItem");
            this.cWXToolStripMenuItem.Click += new System.EventHandler(this.cWXToolStripMenuItem_Click);
            // 
            // eSCToolStripMenuItem
            // 
            this.eSCToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.eSCToolStripMenuItem.Name = "eSCToolStripMenuItem";
            resources.ApplyResources(this.eSCToolStripMenuItem, "eSCToolStripMenuItem");
            this.eSCToolStripMenuItem.Click += new System.EventHandler(this.eSCToolStripMenuItem_Click);
            // 
            // collapseToolStripMenuItem
            // 
            this.collapseToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.collapseToolStripMenuItem.Name = "collapseToolStripMenuItem";
            resources.ApplyResources(this.collapseToolStripMenuItem, "collapseToolStripMenuItem");
            this.collapseToolStripMenuItem.Click += new System.EventHandler(this.CollapseToolStripMenuItem_Click);
            // 
            // spotterMenu
            // 
            this.spotterMenu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.spotterMenu.Name = "spotterMenu";
            resources.ApplyResources(this.spotterMenu, "spotterMenu");
            this.spotterMenu.Click += new System.EventHandler(this.spotterMenu_Click);
            // 
            // displayControlsToolStripMenuItem
            // 
            this.displayControlsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topControlsToolStripMenuItem,
            this.bandControlsToolStripMenuItem,
            this.modeControlsToolStripMenuItem,
            this.andromedaTopControlsToolStripMenuItem,
            this.andromedaButtonBarToolStripMenuItem});
            this.displayControlsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.displayControlsToolStripMenuItem.Name = "displayControlsToolStripMenuItem";
            resources.ApplyResources(this.displayControlsToolStripMenuItem, "displayControlsToolStripMenuItem");
            this.displayControlsToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.displayControlsToolStripMenuItem_MouseUp);
            // 
            // topControlsToolStripMenuItem
            // 
            this.topControlsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.topControlsToolStripMenuItem.Name = "topControlsToolStripMenuItem";
            resources.ApplyResources(this.topControlsToolStripMenuItem, "topControlsToolStripMenuItem");
            this.topControlsToolStripMenuItem.Click += new System.EventHandler(this.mnuShowTopControls_Click);
            // 
            // bandControlsToolStripMenuItem
            // 
            this.bandControlsToolStripMenuItem.Name = "bandControlsToolStripMenuItem";
            resources.ApplyResources(this.bandControlsToolStripMenuItem, "bandControlsToolStripMenuItem");
            this.bandControlsToolStripMenuItem.Click += new System.EventHandler(this.mnuShowBandControls_Click);
            // 
            // modeControlsToolStripMenuItem
            // 
            this.modeControlsToolStripMenuItem.Name = "modeControlsToolStripMenuItem";
            resources.ApplyResources(this.modeControlsToolStripMenuItem, "modeControlsToolStripMenuItem");
            this.modeControlsToolStripMenuItem.Click += new System.EventHandler(this.mnuShowModeControls_Click);
            // 
            // andromedaTopControlsToolStripMenuItem
            // 
            this.andromedaTopControlsToolStripMenuItem.Name = "andromedaTopControlsToolStripMenuItem";
            resources.ApplyResources(this.andromedaTopControlsToolStripMenuItem, "andromedaTopControlsToolStripMenuItem");
            this.andromedaTopControlsToolStripMenuItem.Click += new System.EventHandler(this.AndromedaTopControlsToolStripMenuItem_Click);
            // 
            // andromedaButtonBarToolStripMenuItem
            // 
            this.andromedaButtonBarToolStripMenuItem.Name = "andromedaButtonBarToolStripMenuItem";
            resources.ApplyResources(this.andromedaButtonBarToolStripMenuItem, "andromedaButtonBarToolStripMenuItem");
            this.andromedaButtonBarToolStripMenuItem.Click += new System.EventHandler(this.AndromedaButtonBarToolStripMenuItem_Click);
            // 
            // dSPToolStripMenuItem
            // 
            this.dSPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NRToolStripMenuItem,
            this.NR2ToolStripMenuItem1,
            this.ANFToolStripMenuItem,
            this.NBToolStripMenuItem,
            this.NB2ToolStripMenuItem,
            this.SNBtoolStripMenuItem,
            this.BINToolStripMenuItem,
            this.MultiRXToolStripMenuItem,
            this.RX1AVGToolStripMenuItem,
            this.RX1PeakToolStripMenuItem});
            this.dSPToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dSPToolStripMenuItem.Name = "dSPToolStripMenuItem";
            resources.ApplyResources(this.dSPToolStripMenuItem, "dSPToolStripMenuItem");
            this.dSPToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dSPToolStripMenuItem_MouseUp);
            // 
            // NRToolStripMenuItem
            // 
            this.NRToolStripMenuItem.Name = "NRToolStripMenuItem";
            resources.ApplyResources(this.NRToolStripMenuItem, "NRToolStripMenuItem");
            this.NRToolStripMenuItem.Click += new System.EventHandler(this.mnuDSP_Click);
            // 
            // NR2ToolStripMenuItem1
            // 
            this.NR2ToolStripMenuItem1.Name = "NR2ToolStripMenuItem1";
            resources.ApplyResources(this.NR2ToolStripMenuItem1, "NR2ToolStripMenuItem1");
            this.NR2ToolStripMenuItem1.Click += new System.EventHandler(this.mnuDSP_Click);
            // 
            // ANFToolStripMenuItem
            // 
            this.ANFToolStripMenuItem.Name = "ANFToolStripMenuItem";
            resources.ApplyResources(this.ANFToolStripMenuItem, "ANFToolStripMenuItem");
            this.ANFToolStripMenuItem.Click += new System.EventHandler(this.mnuDSP_Click);
            // 
            // NBToolStripMenuItem
            // 
            this.NBToolStripMenuItem.Name = "NBToolStripMenuItem";
            resources.ApplyResources(this.NBToolStripMenuItem, "NBToolStripMenuItem");
            this.NBToolStripMenuItem.Click += new System.EventHandler(this.mnuDSP_Click);
            // 
            // NB2ToolStripMenuItem
            // 
            this.NB2ToolStripMenuItem.Name = "NB2ToolStripMenuItem";
            resources.ApplyResources(this.NB2ToolStripMenuItem, "NB2ToolStripMenuItem");
            this.NB2ToolStripMenuItem.Click += new System.EventHandler(this.mnuDSP_Click);
            // 
            // SNBtoolStripMenuItem
            // 
            this.SNBtoolStripMenuItem.Name = "SNBtoolStripMenuItem";
            resources.ApplyResources(this.SNBtoolStripMenuItem, "SNBtoolStripMenuItem");
            this.SNBtoolStripMenuItem.Click += new System.EventHandler(this.mnuDSP_Click);
            // 
            // BINToolStripMenuItem
            // 
            this.BINToolStripMenuItem.Name = "BINToolStripMenuItem";
            resources.ApplyResources(this.BINToolStripMenuItem, "BINToolStripMenuItem");
            this.BINToolStripMenuItem.Click += new System.EventHandler(this.mnuDSP_Click);
            // 
            // MultiRXToolStripMenuItem
            // 
            this.MultiRXToolStripMenuItem.Name = "MultiRXToolStripMenuItem";
            resources.ApplyResources(this.MultiRXToolStripMenuItem, "MultiRXToolStripMenuItem");
            this.MultiRXToolStripMenuItem.Click += new System.EventHandler(this.mnuDSP_Click);
            // 
            // RX1AVGToolStripMenuItem
            // 
            this.RX1AVGToolStripMenuItem.Name = "RX1AVGToolStripMenuItem";
            resources.ApplyResources(this.RX1AVGToolStripMenuItem, "RX1AVGToolStripMenuItem");
            this.RX1AVGToolStripMenuItem.Click += new System.EventHandler(this.mnuDSP_Click);
            // 
            // RX1PeakToolStripMenuItem
            // 
            this.RX1PeakToolStripMenuItem.Name = "RX1PeakToolStripMenuItem";
            resources.ApplyResources(this.RX1PeakToolStripMenuItem, "RX1PeakToolStripMenuItem");
            this.RX1PeakToolStripMenuItem.Click += new System.EventHandler(this.mnuDSP_Click);
            // 
            // bandToolStripMenuItem
            // 
            this.bandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bandtoolStripMenuItem1,
            this.bandtoolStripMenuItem2,
            this.bandtoolStripMenuItem3,
            this.bandtoolStripMenuItem4,
            this.bandtoolStripMenuItem5,
            this.bandtoolStripMenuItem14,
            this.bandtoolStripMenuItem7,
            this.bandtoolStripMenuItem8,
            this.bandtoolStripMenuItem9,
            this.bandtoolStripMenuItem10,
            this.bandtoolStripMenuItem11,
            this.bandtoolStripMenuItem12,
            this.bandtoolStripMenuItem13});
            this.bandToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bandToolStripMenuItem.Name = "bandToolStripMenuItem";
            resources.ApplyResources(this.bandToolStripMenuItem, "bandToolStripMenuItem");
            this.bandToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bandToolStripMenuItem_MouseUp);
            // 
            // bandtoolStripMenuItem1
            // 
            this.bandtoolStripMenuItem1.Name = "bandtoolStripMenuItem1";
            resources.ApplyResources(this.bandtoolStripMenuItem1, "bandtoolStripMenuItem1");
            this.bandtoolStripMenuItem1.Click += new System.EventHandler(this.mnuBand_Click);
            // 
            // bandtoolStripMenuItem2
            // 
            this.bandtoolStripMenuItem2.Name = "bandtoolStripMenuItem2";
            resources.ApplyResources(this.bandtoolStripMenuItem2, "bandtoolStripMenuItem2");
            this.bandtoolStripMenuItem2.Click += new System.EventHandler(this.mnuBand_Click);
            // 
            // bandtoolStripMenuItem3
            // 
            this.bandtoolStripMenuItem3.Name = "bandtoolStripMenuItem3";
            resources.ApplyResources(this.bandtoolStripMenuItem3, "bandtoolStripMenuItem3");
            this.bandtoolStripMenuItem3.Click += new System.EventHandler(this.mnuBand_Click);
            // 
            // bandtoolStripMenuItem4
            // 
            this.bandtoolStripMenuItem4.Name = "bandtoolStripMenuItem4";
            resources.ApplyResources(this.bandtoolStripMenuItem4, "bandtoolStripMenuItem4");
            this.bandtoolStripMenuItem4.Click += new System.EventHandler(this.mnuBand_Click);
            // 
            // bandtoolStripMenuItem5
            // 
            this.bandtoolStripMenuItem5.Name = "bandtoolStripMenuItem5";
            resources.ApplyResources(this.bandtoolStripMenuItem5, "bandtoolStripMenuItem5");
            this.bandtoolStripMenuItem5.Click += new System.EventHandler(this.mnuBand_Click);
            // 
            // bandtoolStripMenuItem14
            // 
            this.bandtoolStripMenuItem14.Name = "bandtoolStripMenuItem14";
            resources.ApplyResources(this.bandtoolStripMenuItem14, "bandtoolStripMenuItem14");
            this.bandtoolStripMenuItem14.Click += new System.EventHandler(this.mnuBand_Click);
            // 
            // bandtoolStripMenuItem7
            // 
            this.bandtoolStripMenuItem7.Name = "bandtoolStripMenuItem7";
            resources.ApplyResources(this.bandtoolStripMenuItem7, "bandtoolStripMenuItem7");
            this.bandtoolStripMenuItem7.Click += new System.EventHandler(this.mnuBand_Click);
            // 
            // bandtoolStripMenuItem8
            // 
            this.bandtoolStripMenuItem8.Name = "bandtoolStripMenuItem8";
            resources.ApplyResources(this.bandtoolStripMenuItem8, "bandtoolStripMenuItem8");
            this.bandtoolStripMenuItem8.Click += new System.EventHandler(this.mnuBand_Click);
            // 
            // bandtoolStripMenuItem9
            // 
            this.bandtoolStripMenuItem9.Name = "bandtoolStripMenuItem9";
            resources.ApplyResources(this.bandtoolStripMenuItem9, "bandtoolStripMenuItem9");
            this.bandtoolStripMenuItem9.Click += new System.EventHandler(this.mnuBand_Click);
            // 
            // bandtoolStripMenuItem10
            // 
            this.bandtoolStripMenuItem10.Name = "bandtoolStripMenuItem10";
            resources.ApplyResources(this.bandtoolStripMenuItem10, "bandtoolStripMenuItem10");
            this.bandtoolStripMenuItem10.Click += new System.EventHandler(this.mnuBand_Click);
            // 
            // bandtoolStripMenuItem11
            // 
            this.bandtoolStripMenuItem11.Name = "bandtoolStripMenuItem11";
            resources.ApplyResources(this.bandtoolStripMenuItem11, "bandtoolStripMenuItem11");
            this.bandtoolStripMenuItem11.Click += new System.EventHandler(this.mnuBand_Click);
            // 
            // bandtoolStripMenuItem12
            // 
            this.bandtoolStripMenuItem12.Name = "bandtoolStripMenuItem12";
            resources.ApplyResources(this.bandtoolStripMenuItem12, "bandtoolStripMenuItem12");
            this.bandtoolStripMenuItem12.Click += new System.EventHandler(this.mnuBand_Click);
            // 
            // bandtoolStripMenuItem13
            // 
            this.bandtoolStripMenuItem13.Name = "bandtoolStripMenuItem13";
            resources.ApplyResources(this.bandtoolStripMenuItem13, "bandtoolStripMenuItem13");
            this.bandtoolStripMenuItem13.Click += new System.EventHandler(this.mnuBand_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lSBToolStripMenuItem,
            this.uSBToolStripMenuItem,
            this.dSBToolStripMenuItem,
            this.cWLToolStripMenuItem,
            this.cWUToolStripMenuItem,
            this.fMToolStripMenuItem,
            this.aMToolStripMenuItem,
            this.sAMToolStripMenuItem,
            this.sPECToolStripMenuItem,
            this.dIGLToolStripMenuItem,
            this.dIGUToolStripMenuItem,
            this.dRMToolStripMenuItem});
            this.modeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            resources.ApplyResources(this.modeToolStripMenuItem, "modeToolStripMenuItem");
            this.modeToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.modeToolStripMenuItem_MouseUp);
            // 
            // lSBToolStripMenuItem
            // 
            this.lSBToolStripMenuItem.Name = "lSBToolStripMenuItem";
            resources.ApplyResources(this.lSBToolStripMenuItem, "lSBToolStripMenuItem");
            this.lSBToolStripMenuItem.Click += new System.EventHandler(this.mnuMode_Click);
            // 
            // uSBToolStripMenuItem
            // 
            this.uSBToolStripMenuItem.Name = "uSBToolStripMenuItem";
            resources.ApplyResources(this.uSBToolStripMenuItem, "uSBToolStripMenuItem");
            this.uSBToolStripMenuItem.Click += new System.EventHandler(this.mnuMode_Click);
            // 
            // dSBToolStripMenuItem
            // 
            this.dSBToolStripMenuItem.Name = "dSBToolStripMenuItem";
            resources.ApplyResources(this.dSBToolStripMenuItem, "dSBToolStripMenuItem");
            this.dSBToolStripMenuItem.Click += new System.EventHandler(this.mnuMode_Click);
            // 
            // cWLToolStripMenuItem
            // 
            this.cWLToolStripMenuItem.Name = "cWLToolStripMenuItem";
            resources.ApplyResources(this.cWLToolStripMenuItem, "cWLToolStripMenuItem");
            this.cWLToolStripMenuItem.Click += new System.EventHandler(this.mnuMode_Click);
            // 
            // cWUToolStripMenuItem
            // 
            this.cWUToolStripMenuItem.Name = "cWUToolStripMenuItem";
            resources.ApplyResources(this.cWUToolStripMenuItem, "cWUToolStripMenuItem");
            this.cWUToolStripMenuItem.Click += new System.EventHandler(this.mnuMode_Click);
            // 
            // fMToolStripMenuItem
            // 
            this.fMToolStripMenuItem.Name = "fMToolStripMenuItem";
            resources.ApplyResources(this.fMToolStripMenuItem, "fMToolStripMenuItem");
            this.fMToolStripMenuItem.Click += new System.EventHandler(this.mnuMode_Click);
            // 
            // aMToolStripMenuItem
            // 
            this.aMToolStripMenuItem.Name = "aMToolStripMenuItem";
            resources.ApplyResources(this.aMToolStripMenuItem, "aMToolStripMenuItem");
            this.aMToolStripMenuItem.Click += new System.EventHandler(this.mnuMode_Click);
            // 
            // sAMToolStripMenuItem
            // 
            this.sAMToolStripMenuItem.Name = "sAMToolStripMenuItem";
            resources.ApplyResources(this.sAMToolStripMenuItem, "sAMToolStripMenuItem");
            this.sAMToolStripMenuItem.Click += new System.EventHandler(this.mnuMode_Click);
            // 
            // sPECToolStripMenuItem
            // 
            this.sPECToolStripMenuItem.Name = "sPECToolStripMenuItem";
            resources.ApplyResources(this.sPECToolStripMenuItem, "sPECToolStripMenuItem");
            this.sPECToolStripMenuItem.Click += new System.EventHandler(this.mnuMode_Click);
            // 
            // dIGLToolStripMenuItem
            // 
            this.dIGLToolStripMenuItem.Name = "dIGLToolStripMenuItem";
            resources.ApplyResources(this.dIGLToolStripMenuItem, "dIGLToolStripMenuItem");
            this.dIGLToolStripMenuItem.Click += new System.EventHandler(this.mnuMode_Click);
            // 
            // dIGUToolStripMenuItem
            // 
            this.dIGUToolStripMenuItem.Name = "dIGUToolStripMenuItem";
            resources.ApplyResources(this.dIGUToolStripMenuItem, "dIGUToolStripMenuItem");
            this.dIGUToolStripMenuItem.Click += new System.EventHandler(this.mnuMode_Click);
            // 
            // dRMToolStripMenuItem
            // 
            this.dRMToolStripMenuItem.Name = "dRMToolStripMenuItem";
            resources.ApplyResources(this.dRMToolStripMenuItem, "dRMToolStripMenuItem");
            this.dRMToolStripMenuItem.Click += new System.EventHandler(this.mnuMode_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterToolStripMenuItem1,
            this.FilterToolStripMenuItem2,
            this.FilterToolStripMenuItem3,
            this.FilterToolStripMenuItem4,
            this.FilterToolStripMenuItem5,
            this.FilterToolStripMenuItem6,
            this.FilterToolStripMenuItem7,
            this.FilterToolStripMenuItem8,
            this.FilterToolStripMenuItem9,
            this.FilterToolStripMenuItem10});
            this.filterToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            resources.ApplyResources(this.filterToolStripMenuItem, "filterToolStripMenuItem");
            this.filterToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.filterToolStripMenuItem_MouseUp);
            // 
            // FilterToolStripMenuItem1
            // 
            this.FilterToolStripMenuItem1.Name = "FilterToolStripMenuItem1";
            resources.ApplyResources(this.FilterToolStripMenuItem1, "FilterToolStripMenuItem1");
            this.FilterToolStripMenuItem1.Click += new System.EventHandler(this.mnuFilter_Click);
            // 
            // FilterToolStripMenuItem2
            // 
            this.FilterToolStripMenuItem2.Name = "FilterToolStripMenuItem2";
            resources.ApplyResources(this.FilterToolStripMenuItem2, "FilterToolStripMenuItem2");
            this.FilterToolStripMenuItem2.Click += new System.EventHandler(this.mnuFilter_Click);
            // 
            // FilterToolStripMenuItem3
            // 
            this.FilterToolStripMenuItem3.Name = "FilterToolStripMenuItem3";
            resources.ApplyResources(this.FilterToolStripMenuItem3, "FilterToolStripMenuItem3");
            this.FilterToolStripMenuItem3.Click += new System.EventHandler(this.mnuFilter_Click);
            // 
            // FilterToolStripMenuItem4
            // 
            this.FilterToolStripMenuItem4.Name = "FilterToolStripMenuItem4";
            resources.ApplyResources(this.FilterToolStripMenuItem4, "FilterToolStripMenuItem4");
            this.FilterToolStripMenuItem4.Click += new System.EventHandler(this.mnuFilter_Click);
            // 
            // FilterToolStripMenuItem5
            // 
            this.FilterToolStripMenuItem5.Name = "FilterToolStripMenuItem5";
            resources.ApplyResources(this.FilterToolStripMenuItem5, "FilterToolStripMenuItem5");
            this.FilterToolStripMenuItem5.Click += new System.EventHandler(this.mnuFilter_Click);
            // 
            // FilterToolStripMenuItem6
            // 
            this.FilterToolStripMenuItem6.Name = "FilterToolStripMenuItem6";
            resources.ApplyResources(this.FilterToolStripMenuItem6, "FilterToolStripMenuItem6");
            this.FilterToolStripMenuItem6.Click += new System.EventHandler(this.mnuFilter_Click);
            // 
            // FilterToolStripMenuItem7
            // 
            this.FilterToolStripMenuItem7.Name = "FilterToolStripMenuItem7";
            resources.ApplyResources(this.FilterToolStripMenuItem7, "FilterToolStripMenuItem7");
            this.FilterToolStripMenuItem7.Click += new System.EventHandler(this.mnuFilter_Click);
            // 
            // FilterToolStripMenuItem8
            // 
            this.FilterToolStripMenuItem8.Name = "FilterToolStripMenuItem8";
            resources.ApplyResources(this.FilterToolStripMenuItem8, "FilterToolStripMenuItem8");
            this.FilterToolStripMenuItem8.Click += new System.EventHandler(this.mnuFilter_Click);
            // 
            // FilterToolStripMenuItem9
            // 
            this.FilterToolStripMenuItem9.Name = "FilterToolStripMenuItem9";
            resources.ApplyResources(this.FilterToolStripMenuItem9, "FilterToolStripMenuItem9");
            this.FilterToolStripMenuItem9.Click += new System.EventHandler(this.mnuFilter_Click);
            // 
            // FilterToolStripMenuItem10
            // 
            this.FilterToolStripMenuItem10.Name = "FilterToolStripMenuItem10";
            resources.ApplyResources(this.FilterToolStripMenuItem10, "FilterToolStripMenuItem10");
            this.FilterToolStripMenuItem10.Click += new System.EventHandler(this.mnuFilter_Click);
            // 
            // rX2ToolStripMenuItem
            // 
            this.rX2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bandToolStripMenuItem6,
            this.modeToolStripMenuItem1,
            this.filterToolStripMenuItem11,
            this.dSPToolStripMenuItem1});
            this.rX2ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rX2ToolStripMenuItem.Name = "rX2ToolStripMenuItem";
            resources.ApplyResources(this.rX2ToolStripMenuItem, "rX2ToolStripMenuItem");
            this.rX2ToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rX2ToolStripMenuItem_MouseUp);
            // 
            // bandToolStripMenuItem6
            // 
            this.bandToolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12,
            this.wWVToolStripMenuItem,
            this.gENToolStripMenuItem});
            this.bandToolStripMenuItem6.Name = "bandToolStripMenuItem6";
            resources.ApplyResources(this.bandToolStripMenuItem6, "bandToolStripMenuItem6");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Click += new System.EventHandler(this.mnuBandRX2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Click += new System.EventHandler(this.mnuBandRX2_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            this.toolStripMenuItem4.Click += new System.EventHandler(this.mnuBandRX2_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            this.toolStripMenuItem5.Click += new System.EventHandler(this.mnuBandRX2_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            this.toolStripMenuItem6.Click += new System.EventHandler(this.mnuBandRX2_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            this.toolStripMenuItem7.Click += new System.EventHandler(this.mnuBandRX2_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            resources.ApplyResources(this.toolStripMenuItem8, "toolStripMenuItem8");
            this.toolStripMenuItem8.Click += new System.EventHandler(this.mnuBandRX2_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            this.toolStripMenuItem9.Click += new System.EventHandler(this.mnuBandRX2_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            resources.ApplyResources(this.toolStripMenuItem10, "toolStripMenuItem10");
            this.toolStripMenuItem10.Click += new System.EventHandler(this.mnuBandRX2_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            resources.ApplyResources(this.toolStripMenuItem11, "toolStripMenuItem11");
            this.toolStripMenuItem11.Click += new System.EventHandler(this.mnuBandRX2_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            resources.ApplyResources(this.toolStripMenuItem12, "toolStripMenuItem12");
            this.toolStripMenuItem12.Click += new System.EventHandler(this.mnuBandRX2_Click);
            // 
            // wWVToolStripMenuItem
            // 
            this.wWVToolStripMenuItem.Name = "wWVToolStripMenuItem";
            resources.ApplyResources(this.wWVToolStripMenuItem, "wWVToolStripMenuItem");
            this.wWVToolStripMenuItem.Click += new System.EventHandler(this.mnuBandRX2_Click);
            // 
            // gENToolStripMenuItem
            // 
            this.gENToolStripMenuItem.Name = "gENToolStripMenuItem";
            resources.ApplyResources(this.gENToolStripMenuItem, "gENToolStripMenuItem");
            this.gENToolStripMenuItem.Click += new System.EventHandler(this.mnuBandRX2_Click);
            // 
            // modeToolStripMenuItem1
            // 
            this.modeToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lSBToolStripMenuItem1,
            this.uSBToolStripMenuItem1,
            this.dSBToolStripMenuItem1,
            this.cWLToolStripMenuItem1,
            this.cWUToolStripMenuItem1,
            this.fMToolStripMenuItem1,
            this.aMToolStripMenuItem1,
            this.sAMToolStripMenuItem1,
            this.dIGLToolStripMenuItem1,
            this.dIGUToolStripMenuItem1,
            this.dRMToolStripMenuItem1});
            this.modeToolStripMenuItem1.Name = "modeToolStripMenuItem1";
            resources.ApplyResources(this.modeToolStripMenuItem1, "modeToolStripMenuItem1");
            // 
            // lSBToolStripMenuItem1
            // 
            this.lSBToolStripMenuItem1.Name = "lSBToolStripMenuItem1";
            resources.ApplyResources(this.lSBToolStripMenuItem1, "lSBToolStripMenuItem1");
            this.lSBToolStripMenuItem1.Click += new System.EventHandler(this.mnuModeRX2_Click);
            // 
            // uSBToolStripMenuItem1
            // 
            this.uSBToolStripMenuItem1.Name = "uSBToolStripMenuItem1";
            resources.ApplyResources(this.uSBToolStripMenuItem1, "uSBToolStripMenuItem1");
            this.uSBToolStripMenuItem1.Click += new System.EventHandler(this.mnuModeRX2_Click);
            // 
            // dSBToolStripMenuItem1
            // 
            this.dSBToolStripMenuItem1.Name = "dSBToolStripMenuItem1";
            resources.ApplyResources(this.dSBToolStripMenuItem1, "dSBToolStripMenuItem1");
            this.dSBToolStripMenuItem1.Click += new System.EventHandler(this.mnuModeRX2_Click);
            // 
            // cWLToolStripMenuItem1
            // 
            this.cWLToolStripMenuItem1.Name = "cWLToolStripMenuItem1";
            resources.ApplyResources(this.cWLToolStripMenuItem1, "cWLToolStripMenuItem1");
            this.cWLToolStripMenuItem1.Click += new System.EventHandler(this.mnuModeRX2_Click);
            // 
            // cWUToolStripMenuItem1
            // 
            this.cWUToolStripMenuItem1.Name = "cWUToolStripMenuItem1";
            resources.ApplyResources(this.cWUToolStripMenuItem1, "cWUToolStripMenuItem1");
            this.cWUToolStripMenuItem1.Click += new System.EventHandler(this.mnuModeRX2_Click);
            // 
            // fMToolStripMenuItem1
            // 
            this.fMToolStripMenuItem1.Name = "fMToolStripMenuItem1";
            resources.ApplyResources(this.fMToolStripMenuItem1, "fMToolStripMenuItem1");
            this.fMToolStripMenuItem1.Click += new System.EventHandler(this.mnuModeRX2_Click);
            // 
            // aMToolStripMenuItem1
            // 
            this.aMToolStripMenuItem1.Name = "aMToolStripMenuItem1";
            resources.ApplyResources(this.aMToolStripMenuItem1, "aMToolStripMenuItem1");
            this.aMToolStripMenuItem1.Click += new System.EventHandler(this.mnuModeRX2_Click);
            // 
            // sAMToolStripMenuItem1
            // 
            this.sAMToolStripMenuItem1.Name = "sAMToolStripMenuItem1";
            resources.ApplyResources(this.sAMToolStripMenuItem1, "sAMToolStripMenuItem1");
            this.sAMToolStripMenuItem1.Click += new System.EventHandler(this.mnuModeRX2_Click);
            // 
            // dIGLToolStripMenuItem1
            // 
            this.dIGLToolStripMenuItem1.Name = "dIGLToolStripMenuItem1";
            resources.ApplyResources(this.dIGLToolStripMenuItem1, "dIGLToolStripMenuItem1");
            this.dIGLToolStripMenuItem1.Click += new System.EventHandler(this.mnuModeRX2_Click);
            // 
            // dIGUToolStripMenuItem1
            // 
            this.dIGUToolStripMenuItem1.Name = "dIGUToolStripMenuItem1";
            resources.ApplyResources(this.dIGUToolStripMenuItem1, "dIGUToolStripMenuItem1");
            this.dIGUToolStripMenuItem1.Click += new System.EventHandler(this.mnuModeRX2_Click);
            // 
            // dRMToolStripMenuItem1
            // 
            this.dRMToolStripMenuItem1.Name = "dRMToolStripMenuItem1";
            resources.ApplyResources(this.dRMToolStripMenuItem1, "dRMToolStripMenuItem1");
            this.dRMToolStripMenuItem1.Click += new System.EventHandler(this.mnuModeRX2_Click);
            // 
            // filterToolStripMenuItem11
            // 
            this.filterToolStripMenuItem11.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kToolStripMenuItem,
            this.kToolStripMenuItem1,
            this.kToolStripMenuItem2,
            this.kToolStripMenuItem3,
            this.kToolStripMenuItem4,
            this.toolStripMenuItem13,
            this.toolStripMenuItem14});
            this.filterToolStripMenuItem11.Name = "filterToolStripMenuItem11";
            resources.ApplyResources(this.filterToolStripMenuItem11, "filterToolStripMenuItem11");
            // 
            // kToolStripMenuItem
            // 
            this.kToolStripMenuItem.Name = "kToolStripMenuItem";
            resources.ApplyResources(this.kToolStripMenuItem, "kToolStripMenuItem");
            this.kToolStripMenuItem.Click += new System.EventHandler(this.mnuFilterRX2_Click);
            // 
            // kToolStripMenuItem1
            // 
            this.kToolStripMenuItem1.Name = "kToolStripMenuItem1";
            resources.ApplyResources(this.kToolStripMenuItem1, "kToolStripMenuItem1");
            this.kToolStripMenuItem1.Click += new System.EventHandler(this.mnuFilterRX2_Click);
            // 
            // kToolStripMenuItem2
            // 
            this.kToolStripMenuItem2.Name = "kToolStripMenuItem2";
            resources.ApplyResources(this.kToolStripMenuItem2, "kToolStripMenuItem2");
            this.kToolStripMenuItem2.Click += new System.EventHandler(this.mnuFilterRX2_Click);
            // 
            // kToolStripMenuItem3
            // 
            this.kToolStripMenuItem3.Name = "kToolStripMenuItem3";
            resources.ApplyResources(this.kToolStripMenuItem3, "kToolStripMenuItem3");
            this.kToolStripMenuItem3.Click += new System.EventHandler(this.mnuFilterRX2_Click);
            // 
            // kToolStripMenuItem4
            // 
            this.kToolStripMenuItem4.Name = "kToolStripMenuItem4";
            resources.ApplyResources(this.kToolStripMenuItem4, "kToolStripMenuItem4");
            this.kToolStripMenuItem4.Click += new System.EventHandler(this.mnuFilterRX2_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            resources.ApplyResources(this.toolStripMenuItem13, "toolStripMenuItem13");
            this.toolStripMenuItem13.Click += new System.EventHandler(this.mnuFilterRX2_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            resources.ApplyResources(this.toolStripMenuItem14, "toolStripMenuItem14");
            this.toolStripMenuItem14.Click += new System.EventHandler(this.mnuFilterRX2_Click);
            // 
            // dSPToolStripMenuItem1
            // 
            this.dSPToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nR2ToolStripMenuItem,
            this.NR2StripMenuItem2,
            this.aNF2ToolStripMenuItem,
            this.nB2ToolStripMenuItem1,
            this.nBRX2ToolStripMenuItem,
            this.SNBtoolStripMenuItem1,
            this.bIN2ToolStripMenuItem,
            this.RX2AVGToolStripMenuItem,
            this.RX2PeakToolStripMenuItem});
            this.dSPToolStripMenuItem1.Name = "dSPToolStripMenuItem1";
            resources.ApplyResources(this.dSPToolStripMenuItem1, "dSPToolStripMenuItem1");
            // 
            // nR2ToolStripMenuItem
            // 
            this.nR2ToolStripMenuItem.Name = "nR2ToolStripMenuItem";
            resources.ApplyResources(this.nR2ToolStripMenuItem, "nR2ToolStripMenuItem");
            this.nR2ToolStripMenuItem.Click += new System.EventHandler(this.mnuDSPRX2_Click);
            // 
            // NR2StripMenuItem2
            // 
            this.NR2StripMenuItem2.Name = "NR2StripMenuItem2";
            resources.ApplyResources(this.NR2StripMenuItem2, "NR2StripMenuItem2");
            this.NR2StripMenuItem2.Click += new System.EventHandler(this.mnuDSPRX2_Click);
            // 
            // aNF2ToolStripMenuItem
            // 
            this.aNF2ToolStripMenuItem.Name = "aNF2ToolStripMenuItem";
            resources.ApplyResources(this.aNF2ToolStripMenuItem, "aNF2ToolStripMenuItem");
            this.aNF2ToolStripMenuItem.Click += new System.EventHandler(this.mnuDSPRX2_Click);
            // 
            // nB2ToolStripMenuItem1
            // 
            this.nB2ToolStripMenuItem1.Name = "nB2ToolStripMenuItem1";
            resources.ApplyResources(this.nB2ToolStripMenuItem1, "nB2ToolStripMenuItem1");
            this.nB2ToolStripMenuItem1.Click += new System.EventHandler(this.mnuDSPRX2_Click);
            // 
            // nBRX2ToolStripMenuItem
            // 
            this.nBRX2ToolStripMenuItem.Name = "nBRX2ToolStripMenuItem";
            resources.ApplyResources(this.nBRX2ToolStripMenuItem, "nBRX2ToolStripMenuItem");
            this.nBRX2ToolStripMenuItem.Click += new System.EventHandler(this.mnuDSPRX2_Click);
            // 
            // SNBtoolStripMenuItem1
            // 
            this.SNBtoolStripMenuItem1.Name = "SNBtoolStripMenuItem1";
            resources.ApplyResources(this.SNBtoolStripMenuItem1, "SNBtoolStripMenuItem1");
            this.SNBtoolStripMenuItem1.Click += new System.EventHandler(this.mnuDSPRX2_Click);
            // 
            // bIN2ToolStripMenuItem
            // 
            this.bIN2ToolStripMenuItem.Name = "bIN2ToolStripMenuItem";
            resources.ApplyResources(this.bIN2ToolStripMenuItem, "bIN2ToolStripMenuItem");
            this.bIN2ToolStripMenuItem.Click += new System.EventHandler(this.mnuDSPRX2_Click);
            // 
            // RX2AVGToolStripMenuItem
            // 
            this.RX2AVGToolStripMenuItem.Name = "RX2AVGToolStripMenuItem";
            resources.ApplyResources(this.RX2AVGToolStripMenuItem, "RX2AVGToolStripMenuItem");
            this.RX2AVGToolStripMenuItem.Click += new System.EventHandler(this.mnuDSPRX2_Click);
            // 
            // RX2PeakToolStripMenuItem
            // 
            this.RX2PeakToolStripMenuItem.Name = "RX2PeakToolStripMenuItem";
            resources.ApplyResources(this.RX2PeakToolStripMenuItem, "RX2PeakToolStripMenuItem");
            this.RX2PeakToolStripMenuItem.Click += new System.EventHandler(this.mnuDSPRX2_Click);
            // 
            // linearityToolStripMenuItem
            // 
            this.linearityToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.linearityToolStripMenuItem.Name = "linearityToolStripMenuItem";
            resources.ApplyResources(this.linearityToolStripMenuItem, "linearityToolStripMenuItem");
            this.linearityToolStripMenuItem.Click += new System.EventHandler(this.linearityToolStripMenuItem_Click);
            // 
            // RAtoolStripMenuItem
            // 
            this.RAtoolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RAtoolStripMenuItem.Name = "RAtoolStripMenuItem";
            resources.ApplyResources(this.RAtoolStripMenuItem, "RAtoolStripMenuItem");
            this.RAtoolStripMenuItem.Click += new System.EventHandler(this.RAtoolStripMenuItem_Click);
            // 
            // wBToolStripMenuItem
            // 
            this.wBToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.wBToolStripMenuItem.Name = "wBToolStripMenuItem";
            resources.ApplyResources(this.wBToolStripMenuItem, "wBToolStripMenuItem");
            this.wBToolStripMenuItem.Click += new System.EventHandler(this.wBToolStripMenuItem_Click);
            // 
            // pIToolStripMenuItem
            // 
            this.pIToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pIToolStripMenuItem.Name = "pIToolStripMenuItem";
            resources.ApplyResources(this.pIToolStripMenuItem, "pIToolStripMenuItem");
            this.pIToolStripMenuItem.Click += new System.EventHandler(this.pIToolStripMenuItem_Click);
            // 
            // BPFToolStripMenuItem
            // 
            this.BPFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BPF1ToolStripMenuItem,
            this.BPF2ToolStripMenuItem});
            this.BPFToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BPFToolStripMenuItem.Name = "BPFToolStripMenuItem";
            resources.ApplyResources(this.BPFToolStripMenuItem, "BPFToolStripMenuItem");
            this.BPFToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BPFToolStripMenuItem_MouseUp);
            // 
            // BPF1ToolStripMenuItem
            // 
            this.BPF1ToolStripMenuItem.Name = "BPF1ToolStripMenuItem";
            resources.ApplyResources(this.BPF1ToolStripMenuItem, "BPF1ToolStripMenuItem");
            this.BPF1ToolStripMenuItem.Click += new System.EventHandler(this.BPF1ToolStripMenuItem_Click);
            // 
            // BPF2ToolStripMenuItem
            // 
            this.BPF2ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BPF2ToolStripMenuItem.Name = "BPF2ToolStripMenuItem";
            resources.ApplyResources(this.BPF2ToolStripMenuItem, "BPF2ToolStripMenuItem");
            this.BPF2ToolStripMenuItem.Click += new System.EventHandler(this.BPF2ToolStripMenuItem_Click);
            // 
            // finderMenuItem
            // 
            this.finderMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.finderMenuItem.Name = "finderMenuItem";
            resources.ApplyResources(this.finderMenuItem, "finderMenuItem");
            this.finderMenuItem.Click += new System.EventHandler(this.finderMenuItem_Click);
            // 
            // miAbout
            // 
            this.miAbout.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.miAbout.Name = "miAbout";
            resources.ApplyResources(this.miAbout, "miAbout");
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // statusStripMain
            // 
            resources.ApplyResources(this.statusStripMain, "statusStripMain");
            this.statusStripMain.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_ScreenSize,
            this.toolStripStatusLabel1,
            this.toolStripDropDownButton_CPU,
            this.toolStripStatusLabel_Volts,
            this.toolStripStatusLabel_Amps,
            this.toolStripStatusLabel_TXInhibit,
            this.toolStripStatusLabel_SeqWarning,
            this.toolStripStatusLabelRXAnt,
            this.toolStripStatusLabelTXAnt,
            this.toolStripStatusLabelAndromedaMulti,
            this.toolStripStatusLabel_Fill,
            this.toolStripStatusLabel_N1MM,
            this.toolStripStatusLabel_TCI,
            this.toolStripStatusLabel_CatTCPip,
            this.toolStripStatusLabel_CatSerial,
            this.toolStripStatusLabel_CMstatus,
            this.toolStripStatusLabel_timer,
            this.toolStripStatusLabel_UTCTime,
            this.toolStripStatusLabel_Date,
            this.toolStripStatusLabel_LocalTime});
            this.statusStripMain.Name = "statusStripMain";
            // 
            // toolStripDropDownButton_ScreenSize
            // 
            resources.ApplyResources(this.toolStripDropDownButton_ScreenSize, "toolStripDropDownButton_ScreenSize");
            this.toolStripDropDownButton_ScreenSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.includeBordersToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem_4by3,
            this.toolStripMenuItem_16by9,
            this.toolStripMenuItem_16by10,
            this.youTubeToolStripMenuItem});
            this.toolStripDropDownButton_ScreenSize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripDropDownButton_ScreenSize.Image = global::Thetis.Properties.Resources.screen4;
            this.toolStripDropDownButton_ScreenSize.Name = "toolStripDropDownButton_ScreenSize";
            this.toolStripDropDownButton_ScreenSize.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // includeBordersToolStripMenuItem
            // 
            this.includeBordersToolStripMenuItem.Name = "includeBordersToolStripMenuItem";
            resources.ApplyResources(this.includeBordersToolStripMenuItem, "includeBordersToolStripMenuItem");
            this.includeBordersToolStripMenuItem.Click += new System.EventHandler(this.includeBordersToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripMenuItem_4by3
            // 
            this.toolStripMenuItem_4by3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x768ToolStripMenuItem,
            this.x864ToolStripMenuItem,
            this.x960ToolStripMenuItem,
            this.x1050ToolStripMenuItem,
            this.x1200ToolStripMenuItem});
            this.toolStripMenuItem_4by3.Name = "toolStripMenuItem_4by3";
            resources.ApplyResources(this.toolStripMenuItem_4by3, "toolStripMenuItem_4by3");
            this.toolStripMenuItem_4by3.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMenuItem_4by3_DropDownItemClicked);
            // 
            // x768ToolStripMenuItem
            // 
            this.x768ToolStripMenuItem.Name = "x768ToolStripMenuItem";
            resources.ApplyResources(this.x768ToolStripMenuItem, "x768ToolStripMenuItem");
            // 
            // x864ToolStripMenuItem
            // 
            this.x864ToolStripMenuItem.Name = "x864ToolStripMenuItem";
            resources.ApplyResources(this.x864ToolStripMenuItem, "x864ToolStripMenuItem");
            // 
            // x960ToolStripMenuItem
            // 
            this.x960ToolStripMenuItem.Name = "x960ToolStripMenuItem";
            resources.ApplyResources(this.x960ToolStripMenuItem, "x960ToolStripMenuItem");
            // 
            // x1050ToolStripMenuItem
            // 
            this.x1050ToolStripMenuItem.Name = "x1050ToolStripMenuItem";
            resources.ApplyResources(this.x1050ToolStripMenuItem, "x1050ToolStripMenuItem");
            // 
            // x1200ToolStripMenuItem
            // 
            this.x1200ToolStripMenuItem.Name = "x1200ToolStripMenuItem";
            resources.ApplyResources(this.x1200ToolStripMenuItem, "x1200ToolStripMenuItem");
            // 
            // toolStripMenuItem_16by9
            // 
            this.toolStripMenuItem_16by9.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x720ToolStripMenuItem,
            this.x768ToolStripMenuItem1,
            this.x900ToolStripMenuItem,
            this.x1080ToolStripMenuItem,
            this.x1440ToolStripMenuItem,
            this.x2160ToolStripMenuItem});
            this.toolStripMenuItem_16by9.Name = "toolStripMenuItem_16by9";
            resources.ApplyResources(this.toolStripMenuItem_16by9, "toolStripMenuItem_16by9");
            this.toolStripMenuItem_16by9.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMenuItem_16by9_DropDownItemClicked);
            // 
            // x720ToolStripMenuItem
            // 
            this.x720ToolStripMenuItem.Name = "x720ToolStripMenuItem";
            resources.ApplyResources(this.x720ToolStripMenuItem, "x720ToolStripMenuItem");
            // 
            // x768ToolStripMenuItem1
            // 
            this.x768ToolStripMenuItem1.Name = "x768ToolStripMenuItem1";
            resources.ApplyResources(this.x768ToolStripMenuItem1, "x768ToolStripMenuItem1");
            // 
            // x900ToolStripMenuItem
            // 
            this.x900ToolStripMenuItem.Name = "x900ToolStripMenuItem";
            resources.ApplyResources(this.x900ToolStripMenuItem, "x900ToolStripMenuItem");
            // 
            // x1080ToolStripMenuItem
            // 
            this.x1080ToolStripMenuItem.Name = "x1080ToolStripMenuItem";
            resources.ApplyResources(this.x1080ToolStripMenuItem, "x1080ToolStripMenuItem");
            // 
            // x1440ToolStripMenuItem
            // 
            this.x1440ToolStripMenuItem.Name = "x1440ToolStripMenuItem";
            resources.ApplyResources(this.x1440ToolStripMenuItem, "x1440ToolStripMenuItem");
            // 
            // x2160ToolStripMenuItem
            // 
            this.x2160ToolStripMenuItem.Name = "x2160ToolStripMenuItem";
            resources.ApplyResources(this.x2160ToolStripMenuItem, "x2160ToolStripMenuItem");
            // 
            // toolStripMenuItem_16by10
            // 
            this.toolStripMenuItem_16by10.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x800ToolStripMenuItem,
            this.x900ToolStripMenuItem1,
            this.x1050ToolStripMenuItem1,
            this.x1200ToolStripMenuItem1,
            this.x1600ToolStripMenuItem,
            this.x2400ToolStripMenuItem});
            this.toolStripMenuItem_16by10.Name = "toolStripMenuItem_16by10";
            resources.ApplyResources(this.toolStripMenuItem_16by10, "toolStripMenuItem_16by10");
            this.toolStripMenuItem_16by10.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMenuItem_16by10_DropDownItemClicked);
            // 
            // x800ToolStripMenuItem
            // 
            this.x800ToolStripMenuItem.Name = "x800ToolStripMenuItem";
            resources.ApplyResources(this.x800ToolStripMenuItem, "x800ToolStripMenuItem");
            // 
            // x900ToolStripMenuItem1
            // 
            this.x900ToolStripMenuItem1.Name = "x900ToolStripMenuItem1";
            resources.ApplyResources(this.x900ToolStripMenuItem1, "x900ToolStripMenuItem1");
            // 
            // x1050ToolStripMenuItem1
            // 
            this.x1050ToolStripMenuItem1.Name = "x1050ToolStripMenuItem1";
            resources.ApplyResources(this.x1050ToolStripMenuItem1, "x1050ToolStripMenuItem1");
            // 
            // x1200ToolStripMenuItem1
            // 
            this.x1200ToolStripMenuItem1.Name = "x1200ToolStripMenuItem1";
            resources.ApplyResources(this.x1200ToolStripMenuItem1, "x1200ToolStripMenuItem1");
            // 
            // x1600ToolStripMenuItem
            // 
            this.x1600ToolStripMenuItem.Name = "x1600ToolStripMenuItem";
            resources.ApplyResources(this.x1600ToolStripMenuItem, "x1600ToolStripMenuItem");
            // 
            // x2400ToolStripMenuItem
            // 
            this.x2400ToolStripMenuItem.Name = "x2400ToolStripMenuItem";
            resources.ApplyResources(this.x2400ToolStripMenuItem, "x2400ToolStripMenuItem");
            // 
            // youTubeToolStripMenuItem
            // 
            this.youTubeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pToolStripMenuItem,
            this.pToolStripMenuItem1,
            this.pToolStripMenuItem2,
            this.pToolStripMenuItem3});
            this.youTubeToolStripMenuItem.Name = "youTubeToolStripMenuItem";
            resources.ApplyResources(this.youTubeToolStripMenuItem, "youTubeToolStripMenuItem");
            this.youTubeToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.youTubeToolStripMenuItem_DropDownItemClicked);
            // 
            // pToolStripMenuItem
            // 
            this.pToolStripMenuItem.Name = "pToolStripMenuItem";
            resources.ApplyResources(this.pToolStripMenuItem, "pToolStripMenuItem");
            // 
            // pToolStripMenuItem1
            // 
            this.pToolStripMenuItem1.Name = "pToolStripMenuItem1";
            resources.ApplyResources(this.pToolStripMenuItem1, "pToolStripMenuItem1");
            // 
            // pToolStripMenuItem2
            // 
            this.pToolStripMenuItem2.Name = "pToolStripMenuItem2";
            resources.ApplyResources(this.pToolStripMenuItem2, "pToolStripMenuItem2");
            // 
            // pToolStripMenuItem3
            // 
            this.pToolStripMenuItem3.Name = "pToolStripMenuItem3";
            resources.ApplyResources(this.pToolStripMenuItem3, "pToolStripMenuItem3");
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // toolStripDropDownButton_CPU
            // 
            resources.ApplyResources(this.toolStripDropDownButton_CPU, "toolStripDropDownButton_CPU");
            this.toolStripDropDownButton_CPU.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.thetisOnlyToolStripMenuItem});
            this.toolStripDropDownButton_CPU.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripDropDownButton_CPU.Image = global::Thetis.Properties.Resources.cpu;
            this.toolStripDropDownButton_CPU.Name = "toolStripDropDownButton_CPU";
            this.toolStripDropDownButton_CPU.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            resources.ApplyResources(this.systemToolStripMenuItem, "systemToolStripMenuItem");
            this.systemToolStripMenuItem.Click += new System.EventHandler(this.systemToolStripMenuItem_Click);
            // 
            // thetisOnlyToolStripMenuItem
            // 
            this.thetisOnlyToolStripMenuItem.Name = "thetisOnlyToolStripMenuItem";
            resources.ApplyResources(this.thetisOnlyToolStripMenuItem, "thetisOnlyToolStripMenuItem");
            this.thetisOnlyToolStripMenuItem.Click += new System.EventHandler(this.thetisOnlyToolStripMenuItem_Click);
            // 
            // toolStripStatusLabel_Volts
            // 
            resources.ApplyResources(this.toolStripStatusLabel_Volts, "toolStripStatusLabel_Volts");
            this.toolStripStatusLabel_Volts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabel_Volts.Image = global::Thetis.Properties.Resources.zap;
            this.toolStripStatusLabel_Volts.Name = "toolStripStatusLabel_Volts";
            this.toolStripStatusLabel_Volts.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // toolStripStatusLabel_Amps
            // 
            resources.ApplyResources(this.toolStripStatusLabel_Amps, "toolStripStatusLabel_Amps");
            this.toolStripStatusLabel_Amps.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabel_Amps.Name = "toolStripStatusLabel_Amps";
            this.toolStripStatusLabel_Amps.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // toolStripStatusLabel_TXInhibit
            // 
            this.toolStripStatusLabel_TXInhibit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel_TXInhibit.Image = global::Thetis.Properties.Resources.stop;
            resources.ApplyResources(this.toolStripStatusLabel_TXInhibit, "toolStripStatusLabel_TXInhibit");
            this.toolStripStatusLabel_TXInhibit.Name = "toolStripStatusLabel_TXInhibit";
            this.toolStripStatusLabel_TXInhibit.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // toolStripStatusLabel_SeqWarning
            // 
            this.toolStripStatusLabel_SeqWarning.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel_SeqWarning.Image = global::Thetis.Properties.Resources.warning4;
            resources.ApplyResources(this.toolStripStatusLabel_SeqWarning, "toolStripStatusLabel_SeqWarning");
            this.toolStripStatusLabel_SeqWarning.Name = "toolStripStatusLabel_SeqWarning";
            this.toolStripStatusLabel_SeqWarning.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabel_SeqWarning.Click += new System.EventHandler(this.toolStripStatusLabel_SeqWarning_Click);
            // 
            // toolStripStatusLabelRXAnt
            // 
            resources.ApplyResources(this.toolStripStatusLabelRXAnt, "toolStripStatusLabelRXAnt");
            this.toolStripStatusLabelRXAnt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem20,
            this.toolStripMenuItem19,
            this.toolStripMenuItem18});
            this.toolStripStatusLabelRXAnt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabelRXAnt.Image = global::Thetis.Properties.Resources.RXAnt;
            this.toolStripStatusLabelRXAnt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolStripStatusLabelRXAnt.Name = "toolStripStatusLabelRXAnt";
            this.toolStripStatusLabelRXAnt.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            resources.ApplyResources(this.toolStripMenuItem20, "toolStripMenuItem20");
            this.toolStripMenuItem20.Click += new System.EventHandler(this.ToolStripMenuItem20_Click);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            resources.ApplyResources(this.toolStripMenuItem19, "toolStripMenuItem19");
            this.toolStripMenuItem19.Click += new System.EventHandler(this.ToolStripMenuItem19_Click);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            resources.ApplyResources(this.toolStripMenuItem18, "toolStripMenuItem18");
            this.toolStripMenuItem18.Click += new System.EventHandler(this.ToolStripMenuItem18_Click);
            // 
            // toolStripStatusLabelTXAnt
            // 
            resources.ApplyResources(this.toolStripStatusLabelTXAnt, "toolStripStatusLabelTXAnt");
            this.toolStripStatusLabelTXAnt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem16,
            this.toolStripMenuItem15,
            this.toolStripMenuItem17});
            this.toolStripStatusLabelTXAnt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabelTXAnt.Image = global::Thetis.Properties.Resources.txant;
            this.toolStripStatusLabelTXAnt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolStripStatusLabelTXAnt.Name = "toolStripStatusLabelTXAnt";
            this.toolStripStatusLabelTXAnt.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            resources.ApplyResources(this.toolStripMenuItem16, "toolStripMenuItem16");
            this.toolStripMenuItem16.Click += new System.EventHandler(this.ToolStripMenuItem16_Click);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            resources.ApplyResources(this.toolStripMenuItem15, "toolStripMenuItem15");
            this.toolStripMenuItem15.Click += new System.EventHandler(this.ToolStripMenuItem15_Click);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            resources.ApplyResources(this.toolStripMenuItem17, "toolStripMenuItem17");
            this.toolStripMenuItem17.Click += new System.EventHandler(this.ToolStripMenuItem17_Click);
            // 
            // toolStripStatusLabelAndromedaMulti
            // 
            resources.ApplyResources(this.toolStripStatusLabelAndromedaMulti, "toolStripStatusLabelAndromedaMulti");
            this.toolStripStatusLabelAndromedaMulti.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabelAndromedaMulti.Image = global::Thetis.Properties.Resources.Multifunction;
            this.toolStripStatusLabelAndromedaMulti.Name = "toolStripStatusLabelAndromedaMulti";
            this.toolStripStatusLabelAndromedaMulti.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // toolStripStatusLabel_Fill
            // 
            resources.ApplyResources(this.toolStripStatusLabel_Fill, "toolStripStatusLabel_Fill");
            this.toolStripStatusLabel_Fill.Name = "toolStripStatusLabel_Fill";
            this.toolStripStatusLabel_Fill.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabel_Fill.Spring = true;
            // 
            // toolStripStatusLabel_N1MM
            // 
            resources.ApplyResources(this.toolStripStatusLabel_N1MM, "toolStripStatusLabel_N1MM");
            this.toolStripStatusLabel_N1MM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel_N1MM.Image = global::Thetis.Properties.Resources.n1mm;
            this.toolStripStatusLabel_N1MM.Name = "toolStripStatusLabel_N1MM";
            this.toolStripStatusLabel_N1MM.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // toolStripStatusLabel_TCI
            // 
            resources.ApplyResources(this.toolStripStatusLabel_TCI, "toolStripStatusLabel_TCI");
            this.toolStripStatusLabel_TCI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel_TCI.Image = global::Thetis.Properties.Resources.tci_status;
            this.toolStripStatusLabel_TCI.Name = "toolStripStatusLabel_TCI";
            this.toolStripStatusLabel_TCI.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // toolStripStatusLabel_CatTCPip
            // 
            resources.ApplyResources(this.toolStripStatusLabel_CatTCPip, "toolStripStatusLabel_CatTCPip");
            this.toolStripStatusLabel_CatTCPip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel_CatTCPip.Image = global::Thetis.Properties.Resources.cat_tcp_status;
            this.toolStripStatusLabel_CatTCPip.Name = "toolStripStatusLabel_CatTCPip";
            this.toolStripStatusLabel_CatTCPip.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // toolStripStatusLabel_CatSerial
            // 
            resources.ApplyResources(this.toolStripStatusLabel_CatSerial, "toolStripStatusLabel_CatSerial");
            this.toolStripStatusLabel_CatSerial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel_CatSerial.Name = "toolStripStatusLabel_CatSerial";
            this.toolStripStatusLabel_CatSerial.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // toolStripStatusLabel_CMstatus
            // 
            resources.ApplyResources(this.toolStripStatusLabel_CMstatus, "toolStripStatusLabel_CMstatus");
            this.toolStripStatusLabel_CMstatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabel_CMstatus.Image = global::Thetis.Properties.Resources.cm_red;
            this.toolStripStatusLabel_CMstatus.Name = "toolStripStatusLabel_CMstatus";
            this.toolStripStatusLabel_CMstatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // toolStripStatusLabel_timer
            // 
            resources.ApplyResources(this.toolStripStatusLabel_timer, "toolStripStatusLabel_timer");
            this.toolStripStatusLabel_timer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabel_timer.Image = global::Thetis.Properties.Resources.timer_on;
            this.toolStripStatusLabel_timer.Name = "toolStripStatusLabel_timer";
            this.toolStripStatusLabel_timer.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabel_timer.Click += new System.EventHandler(this.toolStripStatusLabel_timer_Click);
            this.toolStripStatusLabel_timer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripStatusLabel_timer_MouseUp);
            // 
            // toolStripStatusLabel_UTCTime
            // 
            resources.ApplyResources(this.toolStripStatusLabel_UTCTime, "toolStripStatusLabel_UTCTime");
            this.toolStripStatusLabel_UTCTime.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabel_UTCTime.Name = "toolStripStatusLabel_UTCTime";
            this.toolStripStatusLabel_UTCTime.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // toolStripStatusLabel_Date
            // 
            resources.ApplyResources(this.toolStripStatusLabel_Date, "toolStripStatusLabel_Date");
            this.toolStripStatusLabel_Date.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabel_Date.Name = "toolStripStatusLabel_Date";
            this.toolStripStatusLabel_Date.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // toolStripStatusLabel_LocalTime
            // 
            resources.ApplyResources(this.toolStripStatusLabel_LocalTime, "toolStripStatusLabel_LocalTime");
            this.toolStripStatusLabel_LocalTime.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabel_LocalTime.Name = "toolStripStatusLabel_LocalTime";
            // 
            // tmrAutoAGC
            // 
            this.tmrAutoAGC.Enabled = true;
            this.tmrAutoAGC.Interval = 500;
            this.tmrAutoAGC.Tick += new System.EventHandler(this.tmrAutoAGC_Tick);
            // 
            // nudPwrTemp2
            // 
            this.nudPwrTemp2.DecimalPlaces = 2;
            this.nudPwrTemp2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            resources.ApplyResources(this.nudPwrTemp2, "nudPwrTemp2");
            this.nudPwrTemp2.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPwrTemp2.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPwrTemp2.Name = "nudPwrTemp2";
            this.nudPwrTemp2.TinyStep = false;
            this.nudPwrTemp2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nudPwrTemp
            // 
            this.nudPwrTemp.DecimalPlaces = 1;
            this.nudPwrTemp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.nudPwrTemp, "nudPwrTemp");
            this.nudPwrTemp.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPwrTemp.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPwrTemp.Name = "nudPwrTemp";
            this.nudPwrTemp.TinyStep = false;
            this.nudPwrTemp.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // grpMultimeter
            // 
            this.grpMultimeter.BackColor = System.Drawing.Color.Transparent;
            this.grpMultimeter.Controls.Add(this.pnlResizeMeter);
            this.grpMultimeter.Controls.Add(this.picMultiMeterDigital);
            this.grpMultimeter.Controls.Add(this.txtMultiText);
            this.grpMultimeter.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.grpMultimeter, "grpMultimeter");
            this.grpMultimeter.Name = "grpMultimeter";
            this.grpMultimeter.TabStop = false;
            // 
            // pnlResizeMeter
            // 
            resources.ApplyResources(this.pnlResizeMeter, "pnlResizeMeter");
            this.pnlResizeMeter.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pnlResizeMeter.Name = "pnlResizeMeter";
            this.pnlResizeMeter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlResizeMeter_MouseDown);
            this.pnlResizeMeter.MouseEnter += new System.EventHandler(this.pnlResizeMeter_MouseEnter);
            this.pnlResizeMeter.MouseLeave += new System.EventHandler(this.pnlResizeMeter_MouseLeave);
            this.pnlResizeMeter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlResizeMeter_MouseMove);
            this.pnlResizeMeter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlResizeMeter_MouseUp);
            // 
            // picMultiMeterDigital
            // 
            this.picMultiMeterDigital.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.picMultiMeterDigital, "picMultiMeterDigital");
            this.picMultiMeterDigital.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picMultiMeterDigital.Name = "picMultiMeterDigital";
            this.picMultiMeterDigital.TabStop = false;
            this.picMultiMeterDigital.Click += new System.EventHandler(this.picMultiMeterDigital_Click);
            this.picMultiMeterDigital.Paint += new System.Windows.Forms.PaintEventHandler(this.picMultiMeterDigital_Paint);
            // 
            // txtMultiText
            // 
            this.txtMultiText.BackColor = System.Drawing.Color.Black;
            this.txtMultiText.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.txtMultiText, "txtMultiText");
            this.txtMultiText.ForeColor = System.Drawing.Color.Yellow;
            this.txtMultiText.Name = "txtMultiText";
            this.txtMultiText.ReadOnly = true;
            this.txtMultiText.Click += new System.EventHandler(this.txtMultiText_Click);
            this.txtMultiText.GotFocus += new System.EventHandler(this.HideFocus);
            // 
            // panelFilter
            // 
            resources.ApplyResources(this.panelFilter, "panelFilter");
            this.panelFilter.BackColor = System.Drawing.Color.Transparent;
            this.panelFilter.ContextMenuStrip = this.contextMenuStripFilterRX1;
            this.panelFilter.Controls.Add(this.radFilter1);
            this.panelFilter.Controls.Add(this.ptbFilterShift);
            this.panelFilter.Controls.Add(this.ptbFilterWidth);
            this.panelFilter.Controls.Add(this.btnFilterShiftReset);
            this.panelFilter.Controls.Add(this.udFilterHigh);
            this.panelFilter.Controls.Add(this.udFilterLow);
            this.panelFilter.Controls.Add(this.lblFilterHigh);
            this.panelFilter.Controls.Add(this.lblFilterWidth);
            this.panelFilter.Controls.Add(this.radFilterVar2);
            this.panelFilter.Controls.Add(this.lblFilterLow);
            this.panelFilter.Controls.Add(this.radFilterVar1);
            this.panelFilter.Controls.Add(this.lblFilterShift);
            this.panelFilter.Controls.Add(this.radFilter9);
            this.panelFilter.Controls.Add(this.radFilter8);
            this.panelFilter.Controls.Add(this.radFilter2);
            this.panelFilter.Controls.Add(this.radFilter7);
            this.panelFilter.Controls.Add(this.radFilter3);
            this.panelFilter.Controls.Add(this.radFilter6);
            this.panelFilter.Controls.Add(this.radFilter4);
            this.panelFilter.Controls.Add(this.radFilter5);
            this.panelFilter.Controls.Add(this.radFilter10);
            this.panelFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelFilter.Name = "panelFilter";
            // 
            // radFilter1
            // 
            resources.ApplyResources(this.radFilter1, "radFilter1");
            this.radFilter1.FlatAppearance.BorderSize = 0;
            this.radFilter1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radFilter1.Name = "radFilter1";
            this.radFilter1.CheckedChanged += new System.EventHandler(this.radFilter_CheckedChanged);
            // 
            // lblFilterHigh
            // 
            resources.ApplyResources(this.lblFilterHigh, "lblFilterHigh");
            this.lblFilterHigh.ForeColor = System.Drawing.Color.White;
            this.lblFilterHigh.Name = "lblFilterHigh";
            // 
            // lblFilterWidth
            // 
            resources.ApplyResources(this.lblFilterWidth, "lblFilterWidth");
            this.lblFilterWidth.ForeColor = System.Drawing.Color.White;
            this.lblFilterWidth.Name = "lblFilterWidth";
            // 
            // radFilterVar2
            // 
            resources.ApplyResources(this.radFilterVar2, "radFilterVar2");
            this.radFilterVar2.FlatAppearance.BorderSize = 0;
            this.radFilterVar2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radFilterVar2.Name = "radFilterVar2";
            this.radFilterVar2.CheckedChanged += new System.EventHandler(this.radFilter_CheckedChanged);
            // 
            // lblFilterLow
            // 
            resources.ApplyResources(this.lblFilterLow, "lblFilterLow");
            this.lblFilterLow.ForeColor = System.Drawing.Color.White;
            this.lblFilterLow.Name = "lblFilterLow";
            // 
            // radFilterVar1
            // 
            resources.ApplyResources(this.radFilterVar1, "radFilterVar1");
            this.radFilterVar1.FlatAppearance.BorderSize = 0;
            this.radFilterVar1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radFilterVar1.Name = "radFilterVar1";
            this.radFilterVar1.CheckedChanged += new System.EventHandler(this.radFilter_CheckedChanged);
            // 
            // lblFilterShift
            // 
            resources.ApplyResources(this.lblFilterShift, "lblFilterShift");
            this.lblFilterShift.ForeColor = System.Drawing.Color.White;
            this.lblFilterShift.Name = "lblFilterShift";
            // 
            // radFilter9
            // 
            resources.ApplyResources(this.radFilter9, "radFilter9");
            this.radFilter9.FlatAppearance.BorderSize = 0;
            this.radFilter9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radFilter9.Name = "radFilter9";
            this.radFilter9.CheckedChanged += new System.EventHandler(this.radFilter_CheckedChanged);
            // 
            // radFilter8
            // 
            resources.ApplyResources(this.radFilter8, "radFilter8");
            this.radFilter8.FlatAppearance.BorderSize = 0;
            this.radFilter8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radFilter8.Name = "radFilter8";
            this.radFilter8.CheckedChanged += new System.EventHandler(this.radFilter_CheckedChanged);
            // 
            // radFilter2
            // 
            resources.ApplyResources(this.radFilter2, "radFilter2");
            this.radFilter2.FlatAppearance.BorderSize = 0;
            this.radFilter2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radFilter2.Name = "radFilter2";
            this.radFilter2.CheckedChanged += new System.EventHandler(this.radFilter_CheckedChanged);
            // 
            // radFilter7
            // 
            resources.ApplyResources(this.radFilter7, "radFilter7");
            this.radFilter7.FlatAppearance.BorderSize = 0;
            this.radFilter7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radFilter7.Name = "radFilter7";
            this.radFilter7.CheckedChanged += new System.EventHandler(this.radFilter_CheckedChanged);
            // 
            // radFilter3
            // 
            resources.ApplyResources(this.radFilter3, "radFilter3");
            this.radFilter3.FlatAppearance.BorderSize = 0;
            this.radFilter3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radFilter3.Name = "radFilter3";
            this.radFilter3.CheckedChanged += new System.EventHandler(this.radFilter_CheckedChanged);
            // 
            // radFilter6
            // 
            resources.ApplyResources(this.radFilter6, "radFilter6");
            this.radFilter6.FlatAppearance.BorderSize = 0;
            this.radFilter6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radFilter6.Name = "radFilter6";
            this.radFilter6.CheckedChanged += new System.EventHandler(this.radFilter_CheckedChanged);
            // 
            // radFilter4
            // 
            resources.ApplyResources(this.radFilter4, "radFilter4");
            this.radFilter4.FlatAppearance.BorderSize = 0;
            this.radFilter4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radFilter4.Name = "radFilter4";
            this.radFilter4.CheckedChanged += new System.EventHandler(this.radFilter_CheckedChanged);
            // 
            // radFilter5
            // 
            resources.ApplyResources(this.radFilter5, "radFilter5");
            this.radFilter5.FlatAppearance.BorderSize = 0;
            this.radFilter5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radFilter5.Name = "radFilter5";
            this.radFilter5.CheckedChanged += new System.EventHandler(this.radFilter_CheckedChanged);
            // 
            // radFilter10
            // 
            resources.ApplyResources(this.radFilter10, "radFilter10");
            this.radFilter10.FlatAppearance.BorderSize = 0;
            this.radFilter10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radFilter10.Name = "radFilter10";
            this.radFilter10.CheckedChanged += new System.EventHandler(this.radFilter_CheckedChanged);
            // 
            // panelRX2RF
            // 
            resources.ApplyResources(this.panelRX2RF, "panelRX2RF");
            this.panelRX2RF.BackColor = System.Drawing.Color.Transparent;
            this.panelRX2RF.Controls.Add(this.ptbRX2RF);
            this.panelRX2RF.Controls.Add(this.lblRX2RF);
            this.panelRX2RF.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelRX2RF.Name = "panelRX2RF";
            // 
            // panelRX2DSP
            // 
            resources.ApplyResources(this.panelRX2DSP, "panelRX2DSP");
            this.panelRX2DSP.BackColor = System.Drawing.Color.Transparent;
            this.panelRX2DSP.Controls.Add(this.chkRX2Mute);
            this.panelRX2DSP.Controls.Add(this.chkRX2NB2);
            this.panelRX2DSP.Controls.Add(this.chkRX2NR);
            this.panelRX2DSP.Controls.Add(this.chkRX2NB);
            this.panelRX2DSP.Controls.Add(this.lblRX2AGC);
            this.panelRX2DSP.Controls.Add(this.chkRX2ANF);
            this.panelRX2DSP.Controls.Add(this.comboRX2AGC);
            this.panelRX2DSP.Controls.Add(this.chkRX2BIN);
            this.panelRX2DSP.Name = "panelRX2DSP";
            // 
            // btnHidden
            // 
            this.btnHidden.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnHidden, "btnHidden");
            this.btnHidden.Name = "btnHidden";
            this.btnHidden.Selectable = true;
            // 
            // panelOptions
            // 
            resources.ApplyResources(this.panelOptions, "panelOptions");
            this.panelOptions.BackColor = System.Drawing.Color.Transparent;
            this.panelOptions.Controls.Add(this.checkBoxTS1);
            this.panelOptions.Controls.Add(this.chkExternalPA);
            this.panelOptions.Controls.Add(this.ckQuickPlay);
            this.panelOptions.Controls.Add(this.chkMON);
            this.panelOptions.Controls.Add(this.ckQuickRec);
            this.panelOptions.Controls.Add(this.chkRX2SR);
            this.panelOptions.Controls.Add(this.chkMOX);
            this.panelOptions.Controls.Add(this.chkTUN);
            this.panelOptions.Controls.Add(this.chk2TONE);
            this.panelOptions.Controls.Add(this.chkFWCATUBypass);
            this.panelOptions.Controls.Add(this.comboTuneMode);
            this.panelOptions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelOptions.Name = "panelOptions";
            // 
            // checkBoxTS1
            // 
            resources.ApplyResources(this.checkBoxTS1, "checkBoxTS1");
            this.checkBoxTS1.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxTS1.FlatAppearance.BorderSize = 0;
            this.checkBoxTS1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxTS1.Name = "checkBoxTS1";
            this.checkBoxTS1.UseVisualStyleBackColor = false;
            // 
            // panelModeSpecificPhone
            // 
            resources.ApplyResources(this.panelModeSpecificPhone, "panelModeSpecificPhone");
            this.panelModeSpecificPhone.BackColor = System.Drawing.Color.Transparent;
            this.panelModeSpecificPhone.Controls.Add(this.lblTXHigh);
            this.panelModeSpecificPhone.Controls.Add(this.lblTXLow);
            this.panelModeSpecificPhone.Controls.Add(this.udTXFilterLow);
            this.panelModeSpecificPhone.Controls.Add(this.udTXFilterHigh);
            this.panelModeSpecificPhone.Controls.Add(this.chkMicMute);
            this.panelModeSpecificPhone.Controls.Add(this.picNoiseGate);
            this.panelModeSpecificPhone.Controls.Add(this.lblNoiseGateVal);
            this.panelModeSpecificPhone.Controls.Add(this.ptbNoiseGate);
            this.panelModeSpecificPhone.Controls.Add(this.picVOX);
            this.panelModeSpecificPhone.Controls.Add(this.ptbVOX);
            this.panelModeSpecificPhone.Controls.Add(this.lblVOXVal);
            this.panelModeSpecificPhone.Controls.Add(this.ptbCPDR);
            this.panelModeSpecificPhone.Controls.Add(this.lblCPDRVal);
            this.panelModeSpecificPhone.Controls.Add(this.lblMicVal);
            this.panelModeSpecificPhone.Controls.Add(this.ptbMic);
            this.panelModeSpecificPhone.Controls.Add(this.lblMIC);
            this.panelModeSpecificPhone.Controls.Add(this.chkShowTXFilter);
            this.panelModeSpecificPhone.Controls.Add(this.lblTransmitProfile);
            this.panelModeSpecificPhone.Controls.Add(this.chkTXEQ);
            this.panelModeSpecificPhone.Controls.Add(this.chkRXEQ);
            this.panelModeSpecificPhone.Controls.Add(this.chkCPDR);
            this.panelModeSpecificPhone.Controls.Add(this.chkVOX);
            this.panelModeSpecificPhone.Controls.Add(this.chkNoiseGate);
            this.panelModeSpecificPhone.Controls.Add(this.comboTXProfile);
            this.panelModeSpecificPhone.Controls.Add(this.comboAMTXProfile);
            this.panelModeSpecificPhone.Name = "panelModeSpecificPhone";
            // 
            // lblTXHigh
            // 
            resources.ApplyResources(this.lblTXHigh, "lblTXHigh");
            this.lblTXHigh.ForeColor = System.Drawing.Color.White;
            this.lblTXHigh.Name = "lblTXHigh";
            // 
            // lblTXLow
            // 
            resources.ApplyResources(this.lblTXLow, "lblTXLow");
            this.lblTXLow.ForeColor = System.Drawing.Color.White;
            this.lblTXLow.Name = "lblTXLow";
            // 
            // picNoiseGate
            // 
            this.picNoiseGate.BackColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.picNoiseGate, "picNoiseGate");
            this.picNoiseGate.Name = "picNoiseGate";
            this.picNoiseGate.TabStop = false;
            this.picNoiseGate.Paint += new System.Windows.Forms.PaintEventHandler(this.picNoiseGate_Paint);
            // 
            // lblNoiseGateVal
            // 
            resources.ApplyResources(this.lblNoiseGateVal, "lblNoiseGateVal");
            this.lblNoiseGateVal.ForeColor = System.Drawing.Color.White;
            this.lblNoiseGateVal.Name = "lblNoiseGateVal";
            // 
            // ptbNoiseGate
            // 
            resources.ApplyResources(this.ptbNoiseGate, "ptbNoiseGate");
            this.ptbNoiseGate.GreenThumb = false;
            this.ptbNoiseGate.HeadImage = null;
            this.ptbNoiseGate.LargeChange = 1;
            this.ptbNoiseGate.LimitBarColor = System.Drawing.Color.Red;
            this.ptbNoiseGate.LimitEnabled = false;
            this.ptbNoiseGate.LimitValue = 0;
            this.ptbNoiseGate.Maximum = 0;
            this.ptbNoiseGate.Minimum = -160;
            this.ptbNoiseGate.Name = "ptbNoiseGate";
            this.ptbNoiseGate.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbNoiseGate.SmallChange = 1;
            this.ptbNoiseGate.TabStop = false;
            this.ptbNoiseGate.Value = -40;
            this.ptbNoiseGate.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbNoiseGate_Scroll);
            // 
            // picVOX
            // 
            this.picVOX.BackColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.picVOX, "picVOX");
            this.picVOX.Name = "picVOX";
            this.picVOX.TabStop = false;
            this.picVOX.Paint += new System.Windows.Forms.PaintEventHandler(this.picVOX_Paint);
            // 
            // ptbVOX
            // 
            resources.ApplyResources(this.ptbVOX, "ptbVOX");
            this.ptbVOX.GreenThumb = false;
            this.ptbVOX.HeadImage = null;
            this.ptbVOX.LargeChange = 1;
            this.ptbVOX.LimitBarColor = System.Drawing.Color.Red;
            this.ptbVOX.LimitEnabled = false;
            this.ptbVOX.LimitValue = 0;
            this.ptbVOX.Maximum = 0;
            this.ptbVOX.Minimum = -80;
            this.ptbVOX.Name = "ptbVOX";
            this.ptbVOX.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbVOX.SmallChange = 1;
            this.ptbVOX.TabStop = false;
            this.ptbVOX.Value = -20;
            this.ptbVOX.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbVOX_Scroll);
            // 
            // lblVOXVal
            // 
            resources.ApplyResources(this.lblVOXVal, "lblVOXVal");
            this.lblVOXVal.ForeColor = System.Drawing.Color.White;
            this.lblVOXVal.Name = "lblVOXVal";
            // 
            // ptbCPDR
            // 
            resources.ApplyResources(this.ptbCPDR, "ptbCPDR");
            this.ptbCPDR.GreenThumb = false;
            this.ptbCPDR.HeadImage = null;
            this.ptbCPDR.LargeChange = 1;
            this.ptbCPDR.LimitBarColor = System.Drawing.Color.Red;
            this.ptbCPDR.LimitEnabled = false;
            this.ptbCPDR.LimitValue = 0;
            this.ptbCPDR.Maximum = 20;
            this.ptbCPDR.Minimum = 0;
            this.ptbCPDR.Name = "ptbCPDR";
            this.ptbCPDR.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbCPDR.SmallChange = 1;
            this.ptbCPDR.TabStop = false;
            this.ptbCPDR.Value = 1;
            this.ptbCPDR.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbCPDR_Scroll);
            // 
            // lblCPDRVal
            // 
            resources.ApplyResources(this.lblCPDRVal, "lblCPDRVal");
            this.lblCPDRVal.ForeColor = System.Drawing.Color.White;
            this.lblCPDRVal.Name = "lblCPDRVal";
            // 
            // lblMicVal
            // 
            resources.ApplyResources(this.lblMicVal, "lblMicVal");
            this.lblMicVal.ForeColor = System.Drawing.Color.White;
            this.lblMicVal.Name = "lblMicVal";
            // 
            // ptbMic
            // 
            resources.ApplyResources(this.ptbMic, "ptbMic");
            this.ptbMic.GreenThumb = false;
            this.ptbMic.HeadImage = null;
            this.ptbMic.LargeChange = 1;
            this.ptbMic.LimitBarColor = System.Drawing.Color.Red;
            this.ptbMic.LimitEnabled = false;
            this.ptbMic.LimitValue = 0;
            this.ptbMic.Maximum = 70;
            this.ptbMic.Minimum = -96;
            this.ptbMic.Name = "ptbMic";
            this.ptbMic.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbMic.SmallChange = 1;
            this.ptbMic.TabStop = false;
            this.ptbMic.Value = 6;
            this.ptbMic.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbMic_Scroll);
            // 
            // lblMIC
            // 
            resources.ApplyResources(this.lblMIC, "lblMIC");
            this.lblMIC.ForeColor = System.Drawing.Color.White;
            this.lblMIC.Name = "lblMIC";
            // 
            // lblTransmitProfile
            // 
            resources.ApplyResources(this.lblTransmitProfile, "lblTransmitProfile");
            this.lblTransmitProfile.ForeColor = System.Drawing.Color.White;
            this.lblTransmitProfile.Name = "lblTransmitProfile";
            // 
            // panelButtonBar
            // 
            resources.ApplyResources(this.panelButtonBar, "panelButtonBar");
            this.panelButtonBar.Controls.Add(this.btnAndrBar8);
            this.panelButtonBar.Controls.Add(this.btnAndrBar7);
            this.panelButtonBar.Controls.Add(this.btnAndrBar6);
            this.panelButtonBar.Controls.Add(this.btnAndrBar5);
            this.panelButtonBar.Controls.Add(this.btnAndrBar4);
            this.panelButtonBar.Controls.Add(this.btnAndrBar3);
            this.panelButtonBar.Controls.Add(this.btnAndrBar2);
            this.panelButtonBar.Controls.Add(this.btnAndrBar1);
            this.panelButtonBar.Name = "panelButtonBar";
            this.panelButtonBar.Layout += new System.Windows.Forms.LayoutEventHandler(this.panelButtonBar_Layout);
            // 
            // btnAndrBar8
            // 
            this.btnAndrBar8.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.btnAndrBar8, "btnAndrBar8");
            this.btnAndrBar8.Name = "btnAndrBar8";
            this.btnAndrBar8.Selectable = true;
            this.btnAndrBar8.UseVisualStyleBackColor = false;
            this.btnAndrBar8.Click += new System.EventHandler(this.btnAndrBar8_Click);
            // 
            // btnAndrBar7
            // 
            this.btnAndrBar7.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.btnAndrBar7, "btnAndrBar7");
            this.btnAndrBar7.Name = "btnAndrBar7";
            this.btnAndrBar7.Selectable = true;
            this.btnAndrBar7.UseVisualStyleBackColor = false;
            this.btnAndrBar7.Click += new System.EventHandler(this.btnAndrBar7_Click);
            // 
            // btnAndrBar6
            // 
            this.btnAndrBar6.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.btnAndrBar6, "btnAndrBar6");
            this.btnAndrBar6.Name = "btnAndrBar6";
            this.btnAndrBar6.Selectable = true;
            this.btnAndrBar6.UseVisualStyleBackColor = false;
            this.btnAndrBar6.Click += new System.EventHandler(this.btnAndrBar6_Click);
            // 
            // btnAndrBar5
            // 
            this.btnAndrBar5.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.btnAndrBar5, "btnAndrBar5");
            this.btnAndrBar5.Name = "btnAndrBar5";
            this.btnAndrBar5.Selectable = true;
            this.btnAndrBar5.UseVisualStyleBackColor = false;
            this.btnAndrBar5.Click += new System.EventHandler(this.btnAndrBar5_Click);
            // 
            // btnAndrBar4
            // 
            this.btnAndrBar4.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.btnAndrBar4, "btnAndrBar4");
            this.btnAndrBar4.Name = "btnAndrBar4";
            this.btnAndrBar4.Selectable = true;
            this.btnAndrBar4.UseVisualStyleBackColor = false;
            this.btnAndrBar4.Click += new System.EventHandler(this.btnAndrBar4_Click);
            // 
            // btnAndrBar3
            // 
            this.btnAndrBar3.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.btnAndrBar3, "btnAndrBar3");
            this.btnAndrBar3.Name = "btnAndrBar3";
            this.btnAndrBar3.Selectable = true;
            this.btnAndrBar3.UseVisualStyleBackColor = false;
            this.btnAndrBar3.Click += new System.EventHandler(this.btnAndrBar3_Click);
            // 
            // btnAndrBar2
            // 
            this.btnAndrBar2.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.btnAndrBar2, "btnAndrBar2");
            this.btnAndrBar2.Name = "btnAndrBar2";
            this.btnAndrBar2.Selectable = true;
            this.btnAndrBar2.UseVisualStyleBackColor = false;
            this.btnAndrBar2.Click += new System.EventHandler(this.btnAndrBar2_Click);
            // 
            // btnAndrBar1
            // 
            this.btnAndrBar1.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.btnAndrBar1, "btnAndrBar1");
            this.btnAndrBar1.Name = "btnAndrBar1";
            this.btnAndrBar1.Selectable = true;
            this.btnAndrBar1.UseVisualStyleBackColor = false;
            this.btnAndrBar1.Click += new System.EventHandler(this.btnAndrBar1_Click);
            // 
            // panelVFOLabels
            // 
            resources.ApplyResources(this.panelVFOLabels, "panelVFOLabels");
            this.panelVFOLabels.BackColor = System.Drawing.Color.Transparent;
            this.panelVFOLabels.Controls.Add(this.lblStepValue);
            this.panelVFOLabels.Controls.Add(this.lblStep);
            this.panelVFOLabels.Controls.Add(this.lblVFOSplit);
            this.panelVFOLabels.Controls.Add(this.lblXITValue);
            this.panelVFOLabels.Controls.Add(this.lblRITValue);
            this.panelVFOLabels.Controls.Add(this.lblRITLabel);
            this.panelVFOLabels.Controls.Add(this.lblXITLabel);
            this.panelVFOLabels.Controls.Add(this.lblVFOSyncLabel);
            this.panelVFOLabels.Name = "panelVFOLabels";
            // 
            // lblStepValue
            // 
            this.lblStepValue.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblStepValue, "lblStepValue");
            this.lblStepValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblStepValue.Name = "lblStepValue";
            // 
            // lblStep
            // 
            this.lblStep.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblStep, "lblStep");
            this.lblStep.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblStep.Name = "lblStep";
            // 
            // lblVFOSplit
            // 
            this.lblVFOSplit.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblVFOSplit, "lblVFOSplit");
            this.lblVFOSplit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblVFOSplit.Name = "lblVFOSplit";
            // 
            // lblXITValue
            // 
            this.lblXITValue.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblXITValue, "lblXITValue");
            this.lblXITValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblXITValue.Name = "lblXITValue";
            // 
            // lblRITValue
            // 
            this.lblRITValue.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblRITValue, "lblRITValue");
            this.lblRITValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRITValue.Name = "lblRITValue";
            // 
            // lblRITLabel
            // 
            resources.ApplyResources(this.lblRITLabel, "lblRITLabel");
            this.lblRITLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRITLabel.Name = "lblRITLabel";
            // 
            // lblXITLabel
            // 
            resources.ApplyResources(this.lblXITLabel, "lblXITLabel");
            this.lblXITLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblXITLabel.Name = "lblXITLabel";
            // 
            // lblVFOSyncLabel
            // 
            this.lblVFOSyncLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblVFOSyncLabel, "lblVFOSyncLabel");
            this.lblVFOSyncLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblVFOSyncLabel.Name = "lblVFOSyncLabel";
            // 
            // panelVFOALabels
            // 
            resources.ApplyResources(this.panelVFOALabels, "panelVFOALabels");
            this.panelVFOALabels.BackColor = System.Drawing.Color.Transparent;
            this.panelVFOALabels.Controls.Add(this.lblLockLabel);
            this.panelVFOALabels.Controls.Add(this.lblAGCLabel);
            this.panelVFOALabels.Controls.Add(this.lblAttenLabel);
            this.panelVFOALabels.Controls.Add(this.lblANFLabel);
            this.panelVFOALabels.Controls.Add(this.lblSNBLabel);
            this.panelVFOALabels.Controls.Add(this.lblNBLabel);
            this.panelVFOALabels.Controls.Add(this.lblNRLabel);
            this.panelVFOALabels.Controls.Add(this.lblCtunLabel);
            this.panelVFOALabels.Name = "panelVFOALabels";
            // 
            // lblLockLabel
            // 
            resources.ApplyResources(this.lblLockLabel, "lblLockLabel");
            this.lblLockLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLockLabel.Name = "lblLockLabel";
            // 
            // lblAGCLabel
            // 
            resources.ApplyResources(this.lblAGCLabel, "lblAGCLabel");
            this.lblAGCLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblAGCLabel.Name = "lblAGCLabel";
            // 
            // lblAttenLabel
            // 
            resources.ApplyResources(this.lblAttenLabel, "lblAttenLabel");
            this.lblAttenLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblAttenLabel.Name = "lblAttenLabel";
            // 
            // lblANFLabel
            // 
            this.lblANFLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblANFLabel, "lblANFLabel");
            this.lblANFLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblANFLabel.Name = "lblANFLabel";
            // 
            // lblSNBLabel
            // 
            this.lblSNBLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblSNBLabel, "lblSNBLabel");
            this.lblSNBLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblSNBLabel.Name = "lblSNBLabel";
            // 
            // lblNBLabel
            // 
            this.lblNBLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblNBLabel, "lblNBLabel");
            this.lblNBLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblNBLabel.Name = "lblNBLabel";
            // 
            // lblNRLabel
            // 
            this.lblNRLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblNRLabel, "lblNRLabel");
            this.lblNRLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblNRLabel.Name = "lblNRLabel";
            // 
            // lblCtunLabel
            // 
            resources.ApplyResources(this.lblCtunLabel, "lblCtunLabel");
            this.lblCtunLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCtunLabel.Name = "lblCtunLabel";
            // 
            // panelVFOBLabels
            // 
            resources.ApplyResources(this.panelVFOBLabels, "panelVFOBLabels");
            this.panelVFOBLabels.BackColor = System.Drawing.Color.Transparent;
            this.panelVFOBLabels.Controls.Add(this.lblRX2AttenLabel);
            this.panelVFOBLabels.Controls.Add(this.lblRX2LockLabel);
            this.panelVFOBLabels.Controls.Add(this.lblRX2AGCLabel);
            this.panelVFOBLabels.Controls.Add(this.lblRX2CtunLabel);
            this.panelVFOBLabels.Controls.Add(this.lblRX2NRLabel);
            this.panelVFOBLabels.Controls.Add(this.lblRX2NBLabel);
            this.panelVFOBLabels.Controls.Add(this.lblRX2SNBLabel);
            this.panelVFOBLabels.Controls.Add(this.lblRX2ANFLabel);
            this.panelVFOBLabels.Name = "panelVFOBLabels";
            // 
            // lblRX2AttenLabel
            // 
            resources.ApplyResources(this.lblRX2AttenLabel, "lblRX2AttenLabel");
            this.lblRX2AttenLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblRX2AttenLabel.Name = "lblRX2AttenLabel";
            // 
            // lblRX2LockLabel
            // 
            resources.ApplyResources(this.lblRX2LockLabel, "lblRX2LockLabel");
            this.lblRX2LockLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRX2LockLabel.Name = "lblRX2LockLabel";
            // 
            // lblRX2AGCLabel
            // 
            resources.ApplyResources(this.lblRX2AGCLabel, "lblRX2AGCLabel");
            this.lblRX2AGCLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblRX2AGCLabel.Name = "lblRX2AGCLabel";
            // 
            // lblRX2CtunLabel
            // 
            resources.ApplyResources(this.lblRX2CtunLabel, "lblRX2CtunLabel");
            this.lblRX2CtunLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRX2CtunLabel.Name = "lblRX2CtunLabel";
            // 
            // lblRX2NRLabel
            // 
            this.lblRX2NRLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblRX2NRLabel, "lblRX2NRLabel");
            this.lblRX2NRLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblRX2NRLabel.Name = "lblRX2NRLabel";
            // 
            // lblRX2NBLabel
            // 
            this.lblRX2NBLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblRX2NBLabel, "lblRX2NBLabel");
            this.lblRX2NBLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblRX2NBLabel.Name = "lblRX2NBLabel";
            // 
            // lblRX2SNBLabel
            // 
            this.lblRX2SNBLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblRX2SNBLabel, "lblRX2SNBLabel");
            this.lblRX2SNBLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblRX2SNBLabel.Name = "lblRX2SNBLabel";
            // 
            // lblRX2ANFLabel
            // 
            this.lblRX2ANFLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblRX2ANFLabel, "lblRX2ANFLabel");
            this.lblRX2ANFLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblRX2ANFLabel.Name = "lblRX2ANFLabel";
            // 
            // panelRX2Power
            // 
            resources.ApplyResources(this.panelRX2Power, "panelRX2Power");
            this.panelRX2Power.BackColor = System.Drawing.Color.Transparent;
            this.panelRX2Power.Controls.Add(this.pbAutoAttWarningRX2);
            this.panelRX2Power.Controls.Add(this.lblRX2Band);
            this.panelRX2Power.Controls.Add(this.comboRX2Band);
            this.panelRX2Power.Controls.Add(this.lblRX2Preamp);
            this.panelRX2Power.Controls.Add(this.comboRX2Preamp);
            this.panelRX2Power.Controls.Add(this.udRX2StepAttData);
            this.panelRX2Power.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelRX2Power.Name = "panelRX2Power";
            // 
            // lblRX2Band
            // 
            this.lblRX2Band.BackColor = System.Drawing.Color.Transparent;
            this.lblRX2Band.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.lblRX2Band, "lblRX2Band");
            this.lblRX2Band.Name = "lblRX2Band";
            // 
            // lblRX2Preamp
            // 
            this.lblRX2Preamp.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblRX2Preamp, "lblRX2Preamp");
            this.lblRX2Preamp.Name = "lblRX2Preamp";
            this.lblRX2Preamp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblRX2Preamp_MouseDoubleClick);
            // 
            // chkRX2
            // 
            resources.ApplyResources(this.chkRX2, "chkRX2");
            this.chkRX2.FlatAppearance.BorderSize = 0;
            this.chkRX2.Name = "chkRX2";
            this.chkRX2.CheckedChanged += new System.EventHandler(this.chkRX2_CheckedChanged);
            // 
            // radRX1Show
            // 
            this.radRX1Show.BackColor = System.Drawing.Color.Transparent;
            this.radRX1Show.Checked = true;
            this.radRX1Show.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.radRX1Show, "radRX1Show");
            this.radRX1Show.Name = "radRX1Show";
            this.radRX1Show.TabStop = true;
            this.radRX1Show.UseVisualStyleBackColor = false;
            this.radRX1Show.CheckedChanged += new System.EventHandler(this.radRX1Show_CheckedChanged);
            // 
            // radRX2Show
            // 
            resources.ApplyResources(this.radRX2Show, "radRX2Show");
            this.radRX2Show.BackColor = System.Drawing.Color.Transparent;
            this.radRX2Show.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2Show.Name = "radRX2Show";
            this.radRX2Show.UseVisualStyleBackColor = false;
            this.radRX2Show.CheckedChanged += new System.EventHandler(this.radRX2Show_CheckedChanged);
            // 
            // lblRF2
            // 
            this.lblRF2.BackColor = System.Drawing.Color.Transparent;
            this.lblRF2.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblRF2, "lblRF2");
            this.lblRF2.Name = "lblRF2";
            // 
            // panelPower
            // 
            resources.ApplyResources(this.panelPower, "panelPower");
            this.panelPower.BackColor = System.Drawing.Color.Transparent;
            this.panelPower.Controls.Add(this.chkRX2);
            this.panelPower.Controls.Add(this.chkPower);
            this.panelPower.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelPower.Name = "panelPower";
            // 
            // panelModeSpecificCW
            // 
            resources.ApplyResources(this.panelModeSpecificCW, "panelModeSpecificCW");
            this.panelModeSpecificCW.BackColor = System.Drawing.Color.Transparent;
            this.panelModeSpecificCW.Controls.Add(this.grpCWAPF);
            this.panelModeSpecificCW.Controls.Add(this.chkShowCWZero);
            this.panelModeSpecificCW.Controls.Add(this.ptbCWSpeed);
            this.panelModeSpecificCW.Controls.Add(this.udCWPitch);
            this.panelModeSpecificCW.Controls.Add(this.lblCWSpeed);
            this.panelModeSpecificCW.Controls.Add(this.grpSemiBreakIn);
            this.panelModeSpecificCW.Controls.Add(this.lblCWPitchFreq);
            this.panelModeSpecificCW.Controls.Add(this.chkShowTXCWFreq);
            this.panelModeSpecificCW.Controls.Add(this.chkCWIambic);
            this.panelModeSpecificCW.Controls.Add(this.chkCWSidetone);
            this.panelModeSpecificCW.Controls.Add(this.chkCWFWKeyer);
            this.panelModeSpecificCW.Name = "panelModeSpecificCW";
            // 
            // grpCWAPF
            // 
            this.grpCWAPF.BackColor = System.Drawing.Color.Transparent;
            this.grpCWAPF.Controls.Add(this.ptbCWAPFGain);
            this.grpCWAPF.Controls.Add(this.lblCWAPFGain);
            this.grpCWAPF.Controls.Add(this.ptbCWAPFBandwidth);
            this.grpCWAPF.Controls.Add(this.ptbCWAPFFreq);
            this.grpCWAPF.Controls.Add(this.lblCWAPFBandwidth);
            this.grpCWAPF.Controls.Add(this.lblCWAPFTune);
            this.grpCWAPF.Controls.Add(this.chkCWAPFEnabled);
            this.grpCWAPF.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.grpCWAPF, "grpCWAPF");
            this.grpCWAPF.Name = "grpCWAPF";
            this.grpCWAPF.TabStop = false;
            // 
            // lblCWAPFGain
            // 
            resources.ApplyResources(this.lblCWAPFGain, "lblCWAPFGain");
            this.lblCWAPFGain.Name = "lblCWAPFGain";
            // 
            // lblCWAPFBandwidth
            // 
            resources.ApplyResources(this.lblCWAPFBandwidth, "lblCWAPFBandwidth");
            this.lblCWAPFBandwidth.Name = "lblCWAPFBandwidth";
            // 
            // lblCWAPFTune
            // 
            resources.ApplyResources(this.lblCWAPFTune, "lblCWAPFTune");
            this.lblCWAPFTune.Name = "lblCWAPFTune";
            // 
            // lblCWSpeed
            // 
            this.lblCWSpeed.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblCWSpeed, "lblCWSpeed");
            this.lblCWSpeed.Name = "lblCWSpeed";
            // 
            // grpSemiBreakIn
            // 
            this.grpSemiBreakIn.Controls.Add(this.chkQSK);
            this.grpSemiBreakIn.Controls.Add(this.udCWBreakInDelay);
            this.grpSemiBreakIn.Controls.Add(this.lblCWBreakInDelay);
            this.grpSemiBreakIn.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.grpSemiBreakIn, "grpSemiBreakIn");
            this.grpSemiBreakIn.Name = "grpSemiBreakIn";
            this.grpSemiBreakIn.TabStop = false;
            // 
            // lblCWBreakInDelay
            // 
            resources.ApplyResources(this.lblCWBreakInDelay, "lblCWBreakInDelay");
            this.lblCWBreakInDelay.ForeColor = System.Drawing.Color.White;
            this.lblCWBreakInDelay.Name = "lblCWBreakInDelay";
            // 
            // lblCWPitchFreq
            // 
            resources.ApplyResources(this.lblCWPitchFreq, "lblCWPitchFreq");
            this.lblCWPitchFreq.ForeColor = System.Drawing.Color.White;
            this.lblCWPitchFreq.Name = "lblCWPitchFreq";
            // 
            // panelRX2Filter
            // 
            resources.ApplyResources(this.panelRX2Filter, "panelRX2Filter");
            this.panelRX2Filter.BackColor = System.Drawing.Color.Transparent;
            this.panelRX2Filter.ContextMenuStrip = this.contextMenuStripFilterRX2;
            this.panelRX2Filter.Controls.Add(this.udRX2FilterHigh);
            this.panelRX2Filter.Controls.Add(this.radRX2Filter1);
            this.panelRX2Filter.Controls.Add(this.udRX2FilterLow);
            this.panelRX2Filter.Controls.Add(this.lblRX2FilterHigh);
            this.panelRX2Filter.Controls.Add(this.lblRX2FilterLow);
            this.panelRX2Filter.Controls.Add(this.radRX2Filter2);
            this.panelRX2Filter.Controls.Add(this.radRX2FilterVar2);
            this.panelRX2Filter.Controls.Add(this.radRX2Filter3);
            this.panelRX2Filter.Controls.Add(this.radRX2FilterVar1);
            this.panelRX2Filter.Controls.Add(this.radRX2Filter4);
            this.panelRX2Filter.Controls.Add(this.radRX2Filter7);
            this.panelRX2Filter.Controls.Add(this.radRX2Filter5);
            this.panelRX2Filter.Controls.Add(this.radRX2Filter6);
            this.panelRX2Filter.Name = "panelRX2Filter";
            // 
            // radRX2Filter1
            // 
            resources.ApplyResources(this.radRX2Filter1, "radRX2Filter1");
            this.radRX2Filter1.FlatAppearance.BorderSize = 0;
            this.radRX2Filter1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2Filter1.Name = "radRX2Filter1";
            this.radRX2Filter1.CheckedChanged += new System.EventHandler(this.radRX2Filter_CheckedChanged);
            // 
            // lblRX2FilterHigh
            // 
            this.lblRX2FilterHigh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.lblRX2FilterHigh, "lblRX2FilterHigh");
            this.lblRX2FilterHigh.Name = "lblRX2FilterHigh";
            // 
            // lblRX2FilterLow
            // 
            this.lblRX2FilterLow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.lblRX2FilterLow, "lblRX2FilterLow");
            this.lblRX2FilterLow.Name = "lblRX2FilterLow";
            // 
            // radRX2Filter2
            // 
            resources.ApplyResources(this.radRX2Filter2, "radRX2Filter2");
            this.radRX2Filter2.FlatAppearance.BorderSize = 0;
            this.radRX2Filter2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2Filter2.Name = "radRX2Filter2";
            this.radRX2Filter2.CheckedChanged += new System.EventHandler(this.radRX2Filter_CheckedChanged);
            // 
            // radRX2FilterVar2
            // 
            resources.ApplyResources(this.radRX2FilterVar2, "radRX2FilterVar2");
            this.radRX2FilterVar2.FlatAppearance.BorderSize = 0;
            this.radRX2FilterVar2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2FilterVar2.Name = "radRX2FilterVar2";
            this.radRX2FilterVar2.CheckedChanged += new System.EventHandler(this.radRX2Filter_CheckedChanged);
            // 
            // radRX2Filter3
            // 
            resources.ApplyResources(this.radRX2Filter3, "radRX2Filter3");
            this.radRX2Filter3.FlatAppearance.BorderSize = 0;
            this.radRX2Filter3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2Filter3.Name = "radRX2Filter3";
            this.radRX2Filter3.CheckedChanged += new System.EventHandler(this.radRX2Filter_CheckedChanged);
            // 
            // radRX2FilterVar1
            // 
            resources.ApplyResources(this.radRX2FilterVar1, "radRX2FilterVar1");
            this.radRX2FilterVar1.FlatAppearance.BorderSize = 0;
            this.radRX2FilterVar1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2FilterVar1.Name = "radRX2FilterVar1";
            this.radRX2FilterVar1.CheckedChanged += new System.EventHandler(this.radRX2Filter_CheckedChanged);
            // 
            // radRX2Filter4
            // 
            resources.ApplyResources(this.radRX2Filter4, "radRX2Filter4");
            this.radRX2Filter4.FlatAppearance.BorderSize = 0;
            this.radRX2Filter4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2Filter4.Name = "radRX2Filter4";
            this.radRX2Filter4.CheckedChanged += new System.EventHandler(this.radRX2Filter_CheckedChanged);
            // 
            // radRX2Filter7
            // 
            resources.ApplyResources(this.radRX2Filter7, "radRX2Filter7");
            this.radRX2Filter7.FlatAppearance.BorderSize = 0;
            this.radRX2Filter7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2Filter7.Name = "radRX2Filter7";
            this.radRX2Filter7.CheckedChanged += new System.EventHandler(this.radRX2Filter_CheckedChanged);
            // 
            // radRX2Filter5
            // 
            resources.ApplyResources(this.radRX2Filter5, "radRX2Filter5");
            this.radRX2Filter5.FlatAppearance.BorderSize = 0;
            this.radRX2Filter5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2Filter5.Name = "radRX2Filter5";
            this.radRX2Filter5.CheckedChanged += new System.EventHandler(this.radRX2Filter_CheckedChanged);
            // 
            // radRX2Filter6
            // 
            resources.ApplyResources(this.radRX2Filter6, "radRX2Filter6");
            this.radRX2Filter6.FlatAppearance.BorderSize = 0;
            this.radRX2Filter6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radRX2Filter6.Name = "radRX2Filter6";
            this.radRX2Filter6.CheckedChanged += new System.EventHandler(this.radRX2Filter_CheckedChanged);
            // 
            // panelRX2Mode
            // 
            resources.ApplyResources(this.panelRX2Mode, "panelRX2Mode");
            this.panelRX2Mode.BackColor = System.Drawing.Color.Transparent;
            this.panelRX2Mode.Controls.Add(this.radRX2ModeAM);
            this.panelRX2Mode.Controls.Add(this.radRX2ModeLSB);
            this.panelRX2Mode.Controls.Add(this.radRX2ModeSAM);
            this.panelRX2Mode.Controls.Add(this.radRX2ModeCWL);
            this.panelRX2Mode.Controls.Add(this.radRX2ModeDSB);
            this.panelRX2Mode.Controls.Add(this.radRX2ModeUSB);
            this.panelRX2Mode.Controls.Add(this.radRX2ModeCWU);
            this.panelRX2Mode.Controls.Add(this.radRX2ModeFMN);
            this.panelRX2Mode.Controls.Add(this.radRX2ModeDIGU);
            this.panelRX2Mode.Controls.Add(this.radRX2ModeDRM);
            this.panelRX2Mode.Controls.Add(this.radRX2ModeDIGL);
            this.panelRX2Mode.Controls.Add(this.radRX2ModeSPEC);
            this.panelRX2Mode.Name = "panelRX2Mode";
            // 
            // panelRX2Display
            // 
            resources.ApplyResources(this.panelRX2Display, "panelRX2Display");
            this.panelRX2Display.BackColor = System.Drawing.Color.Transparent;
            this.panelRX2Display.Controls.Add(this.chkRX2DisplayPeak);
            this.panelRX2Display.Controls.Add(this.comboRX2DisplayMode);
            this.panelRX2Display.Controls.Add(this.chkRX2DisplayAVG);
            this.panelRX2Display.Controls.Add(this.chkX2TR);
            this.panelRX2Display.Controls.Add(this.chkDX);
            this.panelRX2Display.Controls.Add(this.chkRX1Preamp);
            this.panelRX2Display.Controls.Add(this.chkRX2Preamp);
            this.panelRX2Display.Name = "panelRX2Display";
            // 
            // panelRX2Mixer
            // 
            resources.ApplyResources(this.panelRX2Mixer, "panelRX2Mixer");
            this.panelRX2Mixer.BackColor = System.Drawing.Color.Transparent;
            this.panelRX2Mixer.Controls.Add(this.ptbRX2Pan);
            this.panelRX2Mixer.Controls.Add(this.ptbRX2Gain);
            this.panelRX2Mixer.Controls.Add(this.lblRX2Pan);
            this.panelRX2Mixer.Controls.Add(this.lblRX2Vol);
            this.panelRX2Mixer.Name = "panelRX2Mixer";
            // 
            // lblRX2Pan
            // 
            resources.ApplyResources(this.lblRX2Pan, "lblRX2Pan");
            this.lblRX2Pan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRX2Pan.Name = "lblRX2Pan";
            // 
            // lblRX2Vol
            // 
            resources.ApplyResources(this.lblRX2Vol, "lblRX2Vol");
            this.lblRX2Vol.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRX2Vol.Name = "lblRX2Vol";
            // 
            // panelMultiRX
            // 
            resources.ApplyResources(this.panelMultiRX, "panelMultiRX");
            this.panelMultiRX.BackColor = System.Drawing.Color.Transparent;
            this.panelMultiRX.Controls.Add(this.lblRX1SubVol);
            this.panelMultiRX.Controls.Add(this.label2);
            this.panelMultiRX.Controls.Add(this.lblRX1Vol);
            this.panelMultiRX.Controls.Add(this.ptbRX1Gain);
            this.panelMultiRX.Controls.Add(this.ptbPanSubRX);
            this.panelMultiRX.Controls.Add(this.ptbRX0Gain);
            this.panelMultiRX.Controls.Add(this.ptbPanMainRX);
            this.panelMultiRX.Controls.Add(this.chkPanSwap);
            this.panelMultiRX.Controls.Add(this.chkEnableMultiRX);
            this.panelMultiRX.Name = "panelMultiRX";
            // 
            // lblRX1SubVol
            // 
            resources.ApplyResources(this.lblRX1SubVol, "lblRX1SubVol");
            this.lblRX1SubVol.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRX1SubVol.Name = "lblRX1SubVol";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Name = "label2";
            // 
            // lblRX1Vol
            // 
            resources.ApplyResources(this.lblRX1Vol, "lblRX1Vol");
            this.lblRX1Vol.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRX1Vol.Name = "lblRX1Vol";
            // 
            // panelDisplay2
            // 
            resources.ApplyResources(this.panelDisplay2, "panelDisplay2");
            this.panelDisplay2.BackColor = System.Drawing.Color.Transparent;
            this.panelDisplay2.Controls.Add(this.chkDisplayPeak);
            this.panelDisplay2.Controls.Add(this.comboDisplayMode);
            this.panelDisplay2.Controls.Add(this.chkDisplayAVG);
            this.panelDisplay2.Controls.Add(this.chkFWCATU);
            this.panelDisplay2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelDisplay2.Name = "panelDisplay2";
            // 
            // panelDSP
            // 
            resources.ApplyResources(this.panelDSP, "panelDSP");
            this.panelDSP.BackColor = System.Drawing.Color.Transparent;
            this.panelDSP.Controls.Add(this.btnTNFAdd);
            this.panelDSP.Controls.Add(this.chkMUT);
            this.panelDSP.Controls.Add(this.chkNR);
            this.panelDSP.Controls.Add(this.chkDSPNB2);
            this.panelDSP.Controls.Add(this.chkBIN);
            this.panelDSP.Controls.Add(this.chkNB);
            this.panelDSP.Controls.Add(this.chkANF);
            this.panelDSP.Controls.Add(this.chkTNF);
            this.panelDSP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelDSP.Name = "panelDSP";
            // 
            // panelVFO
            // 
            resources.ApplyResources(this.panelVFO, "panelVFO");
            this.panelVFO.BackColor = System.Drawing.Color.Transparent;
            this.panelVFO.Controls.Add(this.ucVAC2UnderOver);
            this.panelVFO.Controls.Add(this.ucVAC1UnderOver);
            this.panelVFO.Controls.Add(this.chkVAC2);
            this.panelVFO.Controls.Add(this.btnZeroBeat);
            this.panelVFO.Controls.Add(this.chkVFOSplit);
            this.panelVFO.Controls.Add(this.btnRITReset);
            this.panelVFO.Controls.Add(this.btnXITReset);
            this.panelVFO.Controls.Add(this.udRIT);
            this.panelVFO.Controls.Add(this.btnIFtoVFO);
            this.panelVFO.Controls.Add(this.chkRIT);
            this.panelVFO.Controls.Add(this.btnVFOSwap);
            this.panelVFO.Controls.Add(this.btnVFOBtoA);
            this.panelVFO.Controls.Add(this.btnVFOAtoB);
            this.panelVFO.Controls.Add(this.chkXIT);
            this.panelVFO.Controls.Add(this.chkVAC1);
            this.panelVFO.Controls.Add(this.udXIT);
            this.panelVFO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelVFO.Name = "panelVFO";
            // 
            // ucVAC2UnderOver
            // 
            this.ucVAC2UnderOver.BackColor = System.Drawing.Color.Transparent;
            this.ucVAC2UnderOver.ForeColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.ucVAC2UnderOver, "ucVAC2UnderOver");
            this.ucVAC2UnderOver.Name = "ucVAC2UnderOver";
            this.ucVAC2UnderOver.NoFade = false;
            this.ucVAC2UnderOver.ClearIssuesClick += new System.EventHandler(this.ucVAC2UnderOver_ClearIssuesClick);
            // 
            // ucVAC1UnderOver
            // 
            this.ucVAC1UnderOver.BackColor = System.Drawing.Color.Transparent;
            this.ucVAC1UnderOver.ForeColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.ucVAC1UnderOver, "ucVAC1UnderOver");
            this.ucVAC1UnderOver.Name = "ucVAC1UnderOver";
            this.ucVAC1UnderOver.NoFade = false;
            this.ucVAC1UnderOver.ClearIssuesClick += new System.EventHandler(this.ucVAC1UnderOver_ClearIssuesClick);
            // 
            // panelSoundControls
            // 
            resources.ApplyResources(this.panelSoundControls, "panelSoundControls");
            this.panelSoundControls.BackColor = System.Drawing.Color.Transparent;
            this.panelSoundControls.Controls.Add(this.pbAutoAttWarningRX1);
            this.panelSoundControls.Controls.Add(this.ptbTune);
            this.panelSoundControls.Controls.Add(this.lblTune);
            this.panelSoundControls.Controls.Add(this.ptbRX2AF);
            this.panelSoundControls.Controls.Add(this.udTXStepAttData);
            this.panelSoundControls.Controls.Add(this.lblRX2AF);
            this.panelSoundControls.Controls.Add(this.ptbRX1AF);
            this.panelSoundControls.Controls.Add(this.lblRX1AF);
            this.panelSoundControls.Controls.Add(this.comboAGC);
            this.panelSoundControls.Controls.Add(this.ptbPWR);
            this.panelSoundControls.Controls.Add(this.ptbRF);
            this.panelSoundControls.Controls.Add(this.ptbAF);
            this.panelSoundControls.Controls.Add(this.lblAF);
            this.panelSoundControls.Controls.Add(this.lblAGC);
            this.panelSoundControls.Controls.Add(this.lblRF);
            this.panelSoundControls.Controls.Add(this.lblPWR);
            this.panelSoundControls.Controls.Add(this.lblPreamp);
            this.panelSoundControls.Controls.Add(this.comboPreamp);
            this.panelSoundControls.Controls.Add(this.udRX1StepAttData);
            this.panelSoundControls.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelSoundControls.Name = "panelSoundControls";
            // 
            // lblTune
            // 
            this.lblTune.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblTune, "lblTune");
            this.lblTune.Name = "lblTune";
            // 
            // lblRX2AF
            // 
            this.lblRX2AF.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblRX2AF, "lblRX2AF");
            this.lblRX2AF.Name = "lblRX2AF";
            // 
            // lblRX1AF
            // 
            this.lblRX1AF.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblRX1AF, "lblRX1AF");
            this.lblRX1AF.Name = "lblRX1AF";
            // 
            // lblAF
            // 
            this.lblAF.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblAF, "lblAF");
            this.lblAF.Name = "lblAF";
            // 
            // lblPWR
            // 
            this.lblPWR.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblPWR, "lblPWR");
            this.lblPWR.Name = "lblPWR";
            // 
            // lblPreamp
            // 
            this.lblPreamp.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblPreamp, "lblPreamp");
            this.lblPreamp.Name = "lblPreamp";
            this.lblPreamp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblPreamp_MouseDoubleClick);
            // 
            // lblAF2
            // 
            this.lblAF2.BackColor = System.Drawing.Color.Transparent;
            this.lblAF2.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblAF2, "lblAF2");
            this.lblAF2.Name = "lblAF2";
            // 
            // lblPWR2
            // 
            this.lblPWR2.BackColor = System.Drawing.Color.Transparent;
            this.lblPWR2.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblPWR2, "lblPWR2");
            this.lblPWR2.Name = "lblPWR2";
            // 
            // panelModeSpecificDigital
            // 
            resources.ApplyResources(this.panelModeSpecificDigital, "panelModeSpecificDigital");
            this.panelModeSpecificDigital.BackColor = System.Drawing.Color.Transparent;
            this.panelModeSpecificDigital.Controls.Add(this.lblVACTXIndicator);
            this.panelModeSpecificDigital.Controls.Add(this.lblDigTXProfile);
            this.panelModeSpecificDigital.Controls.Add(this.lblVACRXIndicator);
            this.panelModeSpecificDigital.Controls.Add(this.ptbVACTXGain);
            this.panelModeSpecificDigital.Controls.Add(this.comboDigTXProfile);
            this.panelModeSpecificDigital.Controls.Add(this.ptbVACRXGain);
            this.panelModeSpecificDigital.Controls.Add(this.radRX1Show);
            this.panelModeSpecificDigital.Controls.Add(this.lblRXGain);
            this.panelModeSpecificDigital.Controls.Add(this.radRX2Show);
            this.panelModeSpecificDigital.Controls.Add(this.grpVACStereo);
            this.panelModeSpecificDigital.Controls.Add(this.lblTXGain);
            this.panelModeSpecificDigital.Controls.Add(this.grpDIGSampleRate);
            this.panelModeSpecificDigital.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelModeSpecificDigital.Name = "panelModeSpecificDigital";
            // 
            // lblVACTXIndicator
            // 
            this.lblVACTXIndicator.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblVACTXIndicator, "lblVACTXIndicator");
            this.lblVACTXIndicator.Name = "lblVACTXIndicator";
            // 
            // lblDigTXProfile
            // 
            this.lblDigTXProfile.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblDigTXProfile, "lblDigTXProfile");
            this.lblDigTXProfile.Name = "lblDigTXProfile";
            // 
            // lblVACRXIndicator
            // 
            this.lblVACRXIndicator.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblVACRXIndicator, "lblVACRXIndicator");
            this.lblVACRXIndicator.Name = "lblVACRXIndicator";
            // 
            // lblRXGain
            // 
            this.lblRXGain.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblRXGain, "lblRXGain");
            this.lblRXGain.Name = "lblRXGain";
            // 
            // grpVACStereo
            // 
            this.grpVACStereo.Controls.Add(this.chkVACStereo);
            this.grpVACStereo.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.grpVACStereo, "grpVACStereo");
            this.grpVACStereo.Name = "grpVACStereo";
            this.grpVACStereo.TabStop = false;
            // 
            // lblTXGain
            // 
            this.lblTXGain.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lblTXGain, "lblTXGain");
            this.lblTXGain.Name = "lblTXGain";
            // 
            // grpDIGSampleRate
            // 
            this.grpDIGSampleRate.Controls.Add(this.comboVACSampleRate);
            this.grpDIGSampleRate.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.grpDIGSampleRate, "grpDIGSampleRate");
            this.grpDIGSampleRate.Name = "grpDIGSampleRate";
            this.grpDIGSampleRate.TabStop = false;
            // 
            // panelDisplay
            // 
            resources.ApplyResources(this.panelDisplay, "panelDisplay");
            this.panelDisplay.BackColor = System.Drawing.Color.Transparent;
            this.panelDisplay.Controls.Add(this.infoBar);
            this.panelDisplay.Controls.Add(this.btnDisplayZTB);
            this.panelDisplay.Controls.Add(this.radDisplayZoom4x);
            this.panelDisplay.Controls.Add(this.radDisplayZoom2x);
            this.panelDisplay.Controls.Add(this.radDisplayZoom1x);
            this.panelDisplay.Controls.Add(this.radDisplayZoom05);
            this.panelDisplay.Controls.Add(this.ptbDisplayZoom);
            this.panelDisplay.Controls.Add(this.ptbDisplayPan);
            this.panelDisplay.Controls.Add(this.lblDisplayZoom);
            this.panelDisplay.Controls.Add(this.btnDisplayPanCenter);
            this.panelDisplay.Controls.Add(this.lblDisplayPan);
            this.panelDisplay.Controls.Add(this.picDisplay);
            this.panelDisplay.Name = "panelDisplay";
            // 
            // infoBar
            // 
            resources.ApplyResources(this.infoBar, "infoBar");
            this.infoBar.BackColor = System.Drawing.Color.Black;
            this.infoBar.Button1Action = Thetis.ucInfoBar.ActionTypes.Blobs;
            this.infoBar.Button2Action = Thetis.ucInfoBar.ActionTypes.ActivePeaks;
            this.infoBar.CurrentFlip = 0;
            this.infoBar.HideFeedback = false;
            this.infoBar.Name = "infoBar";
            this.infoBar.SplitterRatio = 1F;
            this.infoBar.SwapRedBlue = false;
            this.infoBar.Button1Clicked += new System.EventHandler<Thetis.ucInfoBar.InfoBarAction>(this.infoBar_Button1Clicked);
            this.infoBar.Button2Clicked += new System.EventHandler<Thetis.ucInfoBar.InfoBarAction>(this.infoBar_Button2Clicked);
            this.infoBar.Button1MouseDown += new System.EventHandler<Thetis.ucInfoBar.InfoBarAction>(this.infoBar_Button1MouseDown);
            this.infoBar.Button2MouseDown += new System.EventHandler<Thetis.ucInfoBar.InfoBarAction>(this.infoBar_Button2MouseDown);
            this.infoBar.SwapRedBlueChanged += new System.EventHandler(this.infoBar_SwapRedBlueChanged);
            this.infoBar.HideFeedbackChanged += new System.EventHandler(this.infoBar_HideFeedbackChanged);
            // 
            // lblDisplayZoom
            // 
            resources.ApplyResources(this.lblDisplayZoom, "lblDisplayZoom");
            this.lblDisplayZoom.ForeColor = System.Drawing.Color.White;
            this.lblDisplayZoom.Name = "lblDisplayZoom";
            // 
            // lblDisplayPan
            // 
            resources.ApplyResources(this.lblDisplayPan, "lblDisplayPan");
            this.lblDisplayPan.ForeColor = System.Drawing.Color.White;
            this.lblDisplayPan.Name = "lblDisplayPan";
            // 
            // picDisplay
            // 
            resources.ApplyResources(this.picDisplay, "picDisplay");
            this.picDisplay.BackColor = System.Drawing.Color.Black;
            this.picDisplay.Cursor = System.Windows.Forms.Cursors.Default;
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.TabStop = false;
            this.picDisplay.DoubleClick += new System.EventHandler(this.picDisplay_DoubleClick);
            this.picDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseDown);
            this.picDisplay.MouseLeave += new System.EventHandler(this.picDisplay_MouseLeave);
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            this.picDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseUp);
            this.picDisplay.Resize += new System.EventHandler(this.picDisplay_Resize);
            // 
            // panelMode
            // 
            resources.ApplyResources(this.panelMode, "panelMode");
            this.panelMode.BackColor = System.Drawing.Color.Transparent;
            this.panelMode.Controls.Add(this.radModeAM);
            this.panelMode.Controls.Add(this.radModeLSB);
            this.panelMode.Controls.Add(this.radModeSAM);
            this.panelMode.Controls.Add(this.radModeCWL);
            this.panelMode.Controls.Add(this.radModeDSB);
            this.panelMode.Controls.Add(this.radModeUSB);
            this.panelMode.Controls.Add(this.radModeCWU);
            this.panelMode.Controls.Add(this.radModeFMN);
            this.panelMode.Controls.Add(this.radModeDIGU);
            this.panelMode.Controls.Add(this.radModeDRM);
            this.panelMode.Controls.Add(this.radModeDIGL);
            this.panelMode.Controls.Add(this.radModeSPEC);
            this.panelMode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelMode.Name = "panelMode";
            // 
            // panelBandHF
            // 
            resources.ApplyResources(this.panelBandHF, "panelBandHF");
            this.panelBandHF.BackColor = System.Drawing.Color.Transparent;
            this.panelBandHF.Controls.Add(this.radBandGEN);
            this.panelBandHF.Controls.Add(this.radBandWWV);
            this.panelBandHF.Controls.Add(this.radBand2);
            this.panelBandHF.Controls.Add(this.radBand6);
            this.panelBandHF.Controls.Add(this.radBand10);
            this.panelBandHF.Controls.Add(this.radBand12);
            this.panelBandHF.Controls.Add(this.radBand15);
            this.panelBandHF.Controls.Add(this.radBand17);
            this.panelBandHF.Controls.Add(this.radBand20);
            this.panelBandHF.Controls.Add(this.radBand30);
            this.panelBandHF.Controls.Add(this.radBand40);
            this.panelBandHF.Controls.Add(this.radBand60);
            this.panelBandHF.Controls.Add(this.radBand160);
            this.panelBandHF.Controls.Add(this.radBand80);
            this.panelBandHF.Controls.Add(this.btnBandVHF);
            this.panelBandHF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelBandHF.Name = "panelBandHF";
            // 
            // txtVFOAFreq
            // 
            this.txtVFOAFreq.BackColor = System.Drawing.Color.Black;
            this.txtVFOAFreq.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.txtVFOAFreq, "txtVFOAFreq");
            this.txtVFOAFreq.ForeColor = System.Drawing.Color.Olive;
            this.txtVFOAFreq.Name = "txtVFOAFreq";
            this.txtVFOAFreq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVFOAFreq_KeyPress);
            this.txtVFOAFreq.LostFocus += new System.EventHandler(this.txtVFOAFreq_LostFocus);
            this.txtVFOAFreq.MouseLeave += new System.EventHandler(this.txtVFOAFreq_MouseLeave);
            this.txtVFOAFreq.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtVFOAFreq_MouseMove);
            // 
            // grpVFOA
            // 
            this.grpVFOA.BackColor = System.Drawing.Color.Transparent;
            this.grpVFOA.Controls.Add(this.panelVFOAHover);
            this.grpVFOA.Controls.Add(this.lblModeBigLabel);
            this.grpVFOA.Controls.Add(this.lblRX1APF);
            this.grpVFOA.Controls.Add(this.lblRX1MuteVFOA);
            this.grpVFOA.Controls.Add(this.lblFilterLabel);
            this.grpVFOA.Controls.Add(this.lblModeLabel);
            this.grpVFOA.Controls.Add(this.txtVFOALSD);
            this.grpVFOA.Controls.Add(this.txtVFOAMSD);
            this.grpVFOA.Controls.Add(this.chkVFOATX);
            this.grpVFOA.Controls.Add(this.panelVFOASubHover);
            this.grpVFOA.Controls.Add(this.txtVFOABand);
            this.grpVFOA.Controls.Add(this.txtVFOAFreq);
            resources.ApplyResources(this.grpVFOA, "grpVFOA");
            this.grpVFOA.ForeColor = System.Drawing.Color.Red;
            this.grpVFOA.Name = "grpVFOA";
            this.grpVFOA.TabStop = false;
            // 
            // panelVFOAHover
            // 
            this.panelVFOAHover.BackColor = System.Drawing.Color.Black;
            this.panelVFOAHover.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.panelVFOAHover, "panelVFOAHover");
            this.panelVFOAHover.Name = "panelVFOAHover";
            this.panelVFOAHover.Paint += new System.Windows.Forms.PaintEventHandler(this.panelVFOAHover_Paint);
            this.panelVFOAHover.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelVFOAHover_MouseMove);
            // 
            // lblModeBigLabel
            // 
            resources.ApplyResources(this.lblModeBigLabel, "lblModeBigLabel");
            this.lblModeBigLabel.BackColor = System.Drawing.Color.Black;
            this.lblModeBigLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblModeBigLabel.Name = "lblModeBigLabel";
            // 
            // lblRX1APF
            // 
            this.lblRX1APF.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblRX1APF, "lblRX1APF");
            this.lblRX1APF.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblRX1APF.Name = "lblRX1APF";
            // 
            // lblRX1MuteVFOA
            // 
            resources.ApplyResources(this.lblRX1MuteVFOA, "lblRX1MuteVFOA");
            this.lblRX1MuteVFOA.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblRX1MuteVFOA.Name = "lblRX1MuteVFOA";
            // 
            // lblFilterLabel
            // 
            resources.ApplyResources(this.lblFilterLabel, "lblFilterLabel");
            this.lblFilterLabel.BackColor = System.Drawing.Color.Black;
            this.lblFilterLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblFilterLabel.Name = "lblFilterLabel";
            // 
            // lblModeLabel
            // 
            resources.ApplyResources(this.lblModeLabel, "lblModeLabel");
            this.lblModeLabel.BackColor = System.Drawing.Color.Black;
            this.lblModeLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblModeLabel.Name = "lblModeLabel";
            // 
            // txtVFOALSD
            // 
            this.txtVFOALSD.BackColor = System.Drawing.Color.Black;
            this.txtVFOALSD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVFOALSD.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.txtVFOALSD, "txtVFOALSD");
            this.txtVFOALSD.ForeColor = System.Drawing.Color.Olive;
            this.txtVFOALSD.Name = "txtVFOALSD";
            this.txtVFOALSD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtVFOALSD_MouseDown);
            this.txtVFOALSD.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtVFOALSD_MouseMove);
            // 
            // txtVFOAMSD
            // 
            this.txtVFOAMSD.BackColor = System.Drawing.Color.Black;
            this.txtVFOAMSD.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.txtVFOAMSD, "txtVFOAMSD");
            this.txtVFOAMSD.ForeColor = System.Drawing.Color.Olive;
            this.txtVFOAMSD.Name = "txtVFOAMSD";
            this.txtVFOAMSD.ShortcutsEnabled = false;
            this.txtVFOAMSD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtVFOAMSD_MouseDown);
            this.txtVFOAMSD.MouseLeave += new System.EventHandler(this.txtVFOAMSD_MouseLeave);
            this.txtVFOAMSD.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtVFOAMSD_MouseMove);
            // 
            // panelVFOASubHover
            // 
            this.panelVFOASubHover.BackColor = System.Drawing.Color.Black;
            this.panelVFOASubHover.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.panelVFOASubHover, "panelVFOASubHover");
            this.panelVFOASubHover.Name = "panelVFOASubHover";
            this.panelVFOASubHover.Paint += new System.Windows.Forms.PaintEventHandler(this.panelVFOASubHover_Paint);
            this.panelVFOASubHover.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelVFOASubHover_MouseMove);
            // 
            // txtVFOABand
            // 
            this.txtVFOABand.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.txtVFOABand, "txtVFOABand");
            this.txtVFOABand.ForeColor = System.Drawing.Color.Green;
            this.txtVFOABand.Name = "txtVFOABand";
            this.txtVFOABand.ReadOnly = true;
            this.txtVFOABand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVFOABand_KeyPress);
            this.txtVFOABand.LostFocus += new System.EventHandler(this.txtVFOABand_LostFocus);
            this.txtVFOABand.MouseLeave += new System.EventHandler(this.txtVFOABand_MouseLeave);
            this.txtVFOABand.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtVFOABand_MouseMove);
            // 
            // grpVFOB
            // 
            this.grpVFOB.BackColor = System.Drawing.Color.Transparent;
            this.grpVFOB.Controls.Add(this.lblRX2ModeBigLabel);
            this.grpVFOB.Controls.Add(this.lblRX2APF);
            this.grpVFOB.Controls.Add(this.chkVFOBTX);
            this.grpVFOB.Controls.Add(this.panelVFOBHover);
            this.grpVFOB.Controls.Add(this.txtVFOBBand);
            this.grpVFOB.Controls.Add(this.txtVFOBLSD);
            this.grpVFOB.Controls.Add(this.lblRX2FilterLabel);
            this.grpVFOB.Controls.Add(this.lblRX2MuteVFOB);
            this.grpVFOB.Controls.Add(this.lblRX2ModeLabel);
            this.grpVFOB.Controls.Add(this.txtVFOBMSD);
            this.grpVFOB.Controls.Add(this.lblVFOBLSD);
            this.grpVFOB.Controls.Add(this.txtVFOBFreq);
            resources.ApplyResources(this.grpVFOB, "grpVFOB");
            this.grpVFOB.ForeColor = System.Drawing.Color.White;
            this.grpVFOB.Name = "grpVFOB";
            this.grpVFOB.TabStop = false;
            // 
            // lblRX2ModeBigLabel
            // 
            resources.ApplyResources(this.lblRX2ModeBigLabel, "lblRX2ModeBigLabel");
            this.lblRX2ModeBigLabel.BackColor = System.Drawing.Color.Black;
            this.lblRX2ModeBigLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblRX2ModeBigLabel.Name = "lblRX2ModeBigLabel";
            // 
            // lblRX2APF
            // 
            resources.ApplyResources(this.lblRX2APF, "lblRX2APF");
            this.lblRX2APF.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblRX2APF.Name = "lblRX2APF";
            // 
            // panelVFOBHover
            // 
            this.panelVFOBHover.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.panelVFOBHover, "panelVFOBHover");
            this.panelVFOBHover.Name = "panelVFOBHover";
            this.panelVFOBHover.Paint += new System.Windows.Forms.PaintEventHandler(this.panelVFOBHover_Paint);
            this.panelVFOBHover.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelVFOBHover_MouseMove);
            // 
            // txtVFOBBand
            // 
            this.txtVFOBBand.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.txtVFOBBand, "txtVFOBBand");
            this.txtVFOBBand.ForeColor = System.Drawing.Color.Green;
            this.txtVFOBBand.Name = "txtVFOBBand";
            this.txtVFOBBand.ReadOnly = true;
            this.txtVFOBBand.GotFocus += new System.EventHandler(this.HideFocus);
            // 
            // txtVFOBLSD
            // 
            this.txtVFOBLSD.BackColor = System.Drawing.Color.Black;
            this.txtVFOBLSD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVFOBLSD.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.txtVFOBLSD, "txtVFOBLSD");
            this.txtVFOBLSD.ForeColor = System.Drawing.Color.Olive;
            this.txtVFOBLSD.Name = "txtVFOBLSD";
            this.txtVFOBLSD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtVFOBLSD_MouseDown);
            this.txtVFOBLSD.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtVFOBLSD_MouseMove);
            // 
            // lblRX2FilterLabel
            // 
            resources.ApplyResources(this.lblRX2FilterLabel, "lblRX2FilterLabel");
            this.lblRX2FilterLabel.BackColor = System.Drawing.Color.Black;
            this.lblRX2FilterLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblRX2FilterLabel.Name = "lblRX2FilterLabel";
            // 
            // lblRX2MuteVFOB
            // 
            resources.ApplyResources(this.lblRX2MuteVFOB, "lblRX2MuteVFOB");
            this.lblRX2MuteVFOB.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblRX2MuteVFOB.Name = "lblRX2MuteVFOB";
            // 
            // lblRX2ModeLabel
            // 
            resources.ApplyResources(this.lblRX2ModeLabel, "lblRX2ModeLabel");
            this.lblRX2ModeLabel.BackColor = System.Drawing.Color.Black;
            this.lblRX2ModeLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblRX2ModeLabel.Name = "lblRX2ModeLabel";
            // 
            // txtVFOBMSD
            // 
            this.txtVFOBMSD.BackColor = System.Drawing.Color.Black;
            this.txtVFOBMSD.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.txtVFOBMSD, "txtVFOBMSD");
            this.txtVFOBMSD.ForeColor = System.Drawing.Color.Olive;
            this.txtVFOBMSD.Name = "txtVFOBMSD";
            this.txtVFOBMSD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtVFOBMSD_MouseDown);
            this.txtVFOBMSD.MouseLeave += new System.EventHandler(this.txtVFOBMSD_MouseLeave);
            this.txtVFOBMSD.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtVFOBMSD_MouseMove);
            // 
            // lblVFOBLSD
            // 
            this.lblVFOBLSD.BackColor = System.Drawing.Color.Cyan;
            resources.ApplyResources(this.lblVFOBLSD, "lblVFOBLSD");
            this.lblVFOBLSD.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblVFOBLSD.Name = "lblVFOBLSD";
            // 
            // txtVFOBFreq
            // 
            this.txtVFOBFreq.BackColor = System.Drawing.Color.Black;
            this.txtVFOBFreq.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.txtVFOBFreq, "txtVFOBFreq");
            this.txtVFOBFreq.ForeColor = System.Drawing.Color.Olive;
            this.txtVFOBFreq.Name = "txtVFOBFreq";
            this.txtVFOBFreq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVFOBFreq_KeyPress);
            this.txtVFOBFreq.LostFocus += new System.EventHandler(this.txtVFOBFreq_LostFocus);
            this.txtVFOBFreq.MouseLeave += new System.EventHandler(this.txtVFOBFreq_MouseLeave);
            this.txtVFOBFreq.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtVFOBFreq_MouseMove);
            // 
            // btnBandHF
            // 
            this.btnBandHF.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnBandHF, "btnBandHF");
            this.btnBandHF.ForeColor = System.Drawing.Color.Yellow;
            this.btnBandHF.Name = "btnBandHF";
            this.btnBandHF.Selectable = true;
            this.btnBandHF.Click += new System.EventHandler(this.btnBandHF_Click);
            // 
            // lblTuneStep
            // 
            this.lblTuneStep.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.lblTuneStep, "lblTuneStep");
            this.lblTuneStep.Name = "lblTuneStep";
            // 
            // grpVFOBetween
            // 
            this.grpVFOBetween.BackColor = System.Drawing.Color.Transparent;
            this.grpVFOBetween.Controls.Add(this.ucQuickRecallPad);
            this.grpVFOBetween.Controls.Add(this.labelTS1);
            this.grpVFOBetween.Controls.Add(this.chkVFOBLock);
            this.grpVFOBetween.Controls.Add(this.chkRxAnt);
            this.grpVFOBetween.Controls.Add(this.btnTuneStepChangeLarger);
            this.grpVFOBetween.Controls.Add(this.btnTuneStepChangeSmaller);
            this.grpVFOBetween.Controls.Add(this.lblBandStack);
            this.grpVFOBetween.Controls.Add(this.btnMemoryQuickRestore);
            this.grpVFOBetween.Controls.Add(this.lblTuneStep);
            this.grpVFOBetween.Controls.Add(this.btnMemoryQuickSave);
            this.grpVFOBetween.Controls.Add(this.txtWheelTune);
            this.grpVFOBetween.Controls.Add(this.regBandStackCurrentEntry);
            this.grpVFOBetween.Controls.Add(this.txtMemoryQuick);
            this.grpVFOBetween.Controls.Add(this.regBandStackTotalEntries);
            this.grpVFOBetween.Controls.Add(this.chkVFOSync);
            this.grpVFOBetween.Controls.Add(this.chkVFOLock);
            resources.ApplyResources(this.grpVFOBetween, "grpVFOBetween");
            this.grpVFOBetween.Name = "grpVFOBetween";
            this.grpVFOBetween.TabStop = false;
            // 
            // ucQuickRecallPad
            // 
            this.ucQuickRecallPad.BackColor = System.Drawing.Color.Transparent;
            this.ucQuickRecallPad.console = null;
            resources.ApplyResources(this.ucQuickRecallPad, "ucQuickRecallPad");
            this.ucQuickRecallPad.Name = "ucQuickRecallPad";
            this.ucQuickRecallPad.ButtonClicked += new System.EventHandler(this.ucQuickRecallPad_ButtonClicked);
            // 
            // labelTS1
            // 
            this.labelTS1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.labelTS1, "labelTS1");
            this.labelTS1.Name = "labelTS1";
            // 
            // lblDisplayModeTop
            // 
            resources.ApplyResources(this.lblDisplayModeTop, "lblDisplayModeTop");
            this.lblDisplayModeTop.Name = "lblDisplayModeTop";
            // 
            // lblDisplayModeBottom
            // 
            resources.ApplyResources(this.lblDisplayModeBottom, "lblDisplayModeBottom");
            this.lblDisplayModeBottom.Name = "lblDisplayModeBottom";
            // 
            // grpDisplaySplit
            // 
            this.grpDisplaySplit.Controls.Add(this.chkSplitDisplay);
            this.grpDisplaySplit.Controls.Add(this.comboDisplayModeTop);
            this.grpDisplaySplit.Controls.Add(this.comboDisplayModeBottom);
            this.grpDisplaySplit.Controls.Add(this.lblDisplayModeTop);
            this.grpDisplaySplit.Controls.Add(this.lblDisplayModeBottom);
            resources.ApplyResources(this.grpDisplaySplit, "grpDisplaySplit");
            this.grpDisplaySplit.Name = "grpDisplaySplit";
            this.grpDisplaySplit.TabStop = false;
            // 
            // grpRX2Meter
            // 
            this.grpRX2Meter.BackColor = System.Drawing.Color.Transparent;
            this.grpRX2Meter.Controls.Add(this.picRX2Meter);
            this.grpRX2Meter.Controls.Add(this.comboRX2MeterMode);
            this.grpRX2Meter.Controls.Add(this.txtRX2Meter);
            this.grpRX2Meter.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.grpRX2Meter, "grpRX2Meter");
            this.grpRX2Meter.Name = "grpRX2Meter";
            this.grpRX2Meter.TabStop = false;
            // 
            // picRX2Meter
            // 
            this.picRX2Meter.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.picRX2Meter, "picRX2Meter");
            this.picRX2Meter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picRX2Meter.Name = "picRX2Meter";
            this.picRX2Meter.TabStop = false;
            this.picRX2Meter.Click += new System.EventHandler(this.picRX2Meter_Click);
            this.picRX2Meter.Paint += new System.Windows.Forms.PaintEventHandler(this.picRX2Meter_Paint);
            // 
            // txtRX2Meter
            // 
            this.txtRX2Meter.BackColor = System.Drawing.Color.Black;
            this.txtRX2Meter.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.txtRX2Meter, "txtRX2Meter");
            this.txtRX2Meter.ForeColor = System.Drawing.Color.Yellow;
            this.txtRX2Meter.Name = "txtRX2Meter";
            this.txtRX2Meter.ReadOnly = true;
            this.txtRX2Meter.Click += new System.EventHandler(this.txtRX2Meter_Click);
            // 
            // panelBandVHF
            // 
            resources.ApplyResources(this.panelBandVHF, "panelBandVHF");
            this.panelBandVHF.BackColor = System.Drawing.Color.Transparent;
            this.panelBandVHF.Controls.Add(this.radBandVHF13);
            this.panelBandVHF.Controls.Add(this.radBandVHF12);
            this.panelBandVHF.Controls.Add(this.radBandVHF11);
            this.panelBandVHF.Controls.Add(this.radBandVHF10);
            this.panelBandVHF.Controls.Add(this.radBandVHF9);
            this.panelBandVHF.Controls.Add(this.radBandVHF8);
            this.panelBandVHF.Controls.Add(this.radBandVHF7);
            this.panelBandVHF.Controls.Add(this.radBandVHF6);
            this.panelBandVHF.Controls.Add(this.radBandVHF5);
            this.panelBandVHF.Controls.Add(this.radBandVHF4);
            this.panelBandVHF.Controls.Add(this.radBandVHF3);
            this.panelBandVHF.Controls.Add(this.radBandVHF2);
            this.panelBandVHF.Controls.Add(this.radBandVHF1);
            this.panelBandVHF.Controls.Add(this.radBandVHF0);
            this.panelBandVHF.Controls.Add(this.btnBandHF);
            this.panelBandVHF.Name = "panelBandVHF";
            // 
            // radBandVHF13
            // 
            resources.ApplyResources(this.radBandVHF13, "radBandVHF13");
            this.radBandVHF13.FlatAppearance.BorderSize = 0;
            this.radBandVHF13.ForeColor = System.Drawing.Color.White;
            this.radBandVHF13.Name = "radBandVHF13";
            this.radBandVHF13.TabStop = true;
            this.radBandVHF13.UseVisualStyleBackColor = true;
            this.radBandVHF13.Click += new System.EventHandler(this.radBandVHF_Click);
            this.radBandVHF13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandVHF13_MouseDown);
            // 
            // radBandVHF12
            // 
            resources.ApplyResources(this.radBandVHF12, "radBandVHF12");
            this.radBandVHF12.FlatAppearance.BorderSize = 0;
            this.radBandVHF12.ForeColor = System.Drawing.Color.White;
            this.radBandVHF12.Name = "radBandVHF12";
            this.radBandVHF12.TabStop = true;
            this.radBandVHF12.UseVisualStyleBackColor = true;
            this.radBandVHF12.Click += new System.EventHandler(this.radBandVHF_Click);
            this.radBandVHF12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandVHF12_MouseDown);
            // 
            // radBandVHF11
            // 
            resources.ApplyResources(this.radBandVHF11, "radBandVHF11");
            this.radBandVHF11.FlatAppearance.BorderSize = 0;
            this.radBandVHF11.ForeColor = System.Drawing.Color.White;
            this.radBandVHF11.Name = "radBandVHF11";
            this.radBandVHF11.TabStop = true;
            this.radBandVHF11.UseVisualStyleBackColor = true;
            this.radBandVHF11.Click += new System.EventHandler(this.radBandVHF_Click);
            this.radBandVHF11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandVHF11_MouseDown);
            // 
            // radBandVHF10
            // 
            resources.ApplyResources(this.radBandVHF10, "radBandVHF10");
            this.radBandVHF10.FlatAppearance.BorderSize = 0;
            this.radBandVHF10.ForeColor = System.Drawing.Color.White;
            this.radBandVHF10.Name = "radBandVHF10";
            this.radBandVHF10.TabStop = true;
            this.radBandVHF10.UseVisualStyleBackColor = true;
            this.radBandVHF10.Click += new System.EventHandler(this.radBandVHF_Click);
            this.radBandVHF10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandVHF10_MouseDown);
            // 
            // radBandVHF9
            // 
            resources.ApplyResources(this.radBandVHF9, "radBandVHF9");
            this.radBandVHF9.FlatAppearance.BorderSize = 0;
            this.radBandVHF9.ForeColor = System.Drawing.Color.White;
            this.radBandVHF9.Name = "radBandVHF9";
            this.radBandVHF9.TabStop = true;
            this.radBandVHF9.UseVisualStyleBackColor = true;
            this.radBandVHF9.Click += new System.EventHandler(this.radBandVHF_Click);
            this.radBandVHF9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandVHF9_MouseDown);
            // 
            // radBandVHF8
            // 
            resources.ApplyResources(this.radBandVHF8, "radBandVHF8");
            this.radBandVHF8.FlatAppearance.BorderSize = 0;
            this.radBandVHF8.ForeColor = System.Drawing.Color.White;
            this.radBandVHF8.Name = "radBandVHF8";
            this.radBandVHF8.TabStop = true;
            this.radBandVHF8.UseVisualStyleBackColor = true;
            this.radBandVHF8.Click += new System.EventHandler(this.radBandVHF_Click);
            this.radBandVHF8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandVHF8_MouseDown);
            // 
            // radBandVHF7
            // 
            resources.ApplyResources(this.radBandVHF7, "radBandVHF7");
            this.radBandVHF7.FlatAppearance.BorderSize = 0;
            this.radBandVHF7.ForeColor = System.Drawing.Color.White;
            this.radBandVHF7.Name = "radBandVHF7";
            this.radBandVHF7.TabStop = true;
            this.radBandVHF7.UseVisualStyleBackColor = true;
            this.radBandVHF7.Click += new System.EventHandler(this.radBandVHF_Click);
            this.radBandVHF7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandVHF7_MouseDown);
            // 
            // radBandVHF6
            // 
            resources.ApplyResources(this.radBandVHF6, "radBandVHF6");
            this.radBandVHF6.FlatAppearance.BorderSize = 0;
            this.radBandVHF6.ForeColor = System.Drawing.Color.White;
            this.radBandVHF6.Name = "radBandVHF6";
            this.radBandVHF6.TabStop = true;
            this.radBandVHF6.UseVisualStyleBackColor = true;
            this.radBandVHF6.Click += new System.EventHandler(this.radBandVHF_Click);
            this.radBandVHF6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandVHF6_MouseDown);
            // 
            // radBandVHF5
            // 
            resources.ApplyResources(this.radBandVHF5, "radBandVHF5");
            this.radBandVHF5.FlatAppearance.BorderSize = 0;
            this.radBandVHF5.ForeColor = System.Drawing.Color.White;
            this.radBandVHF5.Name = "radBandVHF5";
            this.radBandVHF5.TabStop = true;
            this.radBandVHF5.UseVisualStyleBackColor = true;
            this.radBandVHF5.Click += new System.EventHandler(this.radBandVHF_Click);
            this.radBandVHF5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandVHF5_MouseDown);
            // 
            // radBandVHF4
            // 
            resources.ApplyResources(this.radBandVHF4, "radBandVHF4");
            this.radBandVHF4.FlatAppearance.BorderSize = 0;
            this.radBandVHF4.ForeColor = System.Drawing.Color.White;
            this.radBandVHF4.Name = "radBandVHF4";
            this.radBandVHF4.TabStop = true;
            this.radBandVHF4.UseVisualStyleBackColor = true;
            this.radBandVHF4.Click += new System.EventHandler(this.radBandVHF_Click);
            this.radBandVHF4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandVHF4_MouseDown);
            // 
            // radBandVHF3
            // 
            resources.ApplyResources(this.radBandVHF3, "radBandVHF3");
            this.radBandVHF3.FlatAppearance.BorderSize = 0;
            this.radBandVHF3.ForeColor = System.Drawing.Color.White;
            this.radBandVHF3.Name = "radBandVHF3";
            this.radBandVHF3.TabStop = true;
            this.radBandVHF3.UseVisualStyleBackColor = true;
            this.radBandVHF3.Click += new System.EventHandler(this.radBandVHF_Click);
            this.radBandVHF3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandVHF3_MouseDown);
            // 
            // radBandVHF2
            // 
            resources.ApplyResources(this.radBandVHF2, "radBandVHF2");
            this.radBandVHF2.FlatAppearance.BorderSize = 0;
            this.radBandVHF2.ForeColor = System.Drawing.Color.White;
            this.radBandVHF2.Name = "radBandVHF2";
            this.radBandVHF2.TabStop = true;
            this.radBandVHF2.UseVisualStyleBackColor = true;
            this.radBandVHF2.Click += new System.EventHandler(this.radBandVHF_Click);
            this.radBandVHF2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandVHF2_MouseDown);
            // 
            // radBandVHF1
            // 
            resources.ApplyResources(this.radBandVHF1, "radBandVHF1");
            this.radBandVHF1.FlatAppearance.BorderSize = 0;
            this.radBandVHF1.ForeColor = System.Drawing.Color.White;
            this.radBandVHF1.Name = "radBandVHF1";
            this.radBandVHF1.TabStop = true;
            this.radBandVHF1.UseVisualStyleBackColor = true;
            this.radBandVHF1.Click += new System.EventHandler(this.radBandVHF_Click);
            this.radBandVHF1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandVHF1_MouseDown);
            // 
            // radBandVHF0
            // 
            resources.ApplyResources(this.radBandVHF0, "radBandVHF0");
            this.radBandVHF0.FlatAppearance.BorderSize = 0;
            this.radBandVHF0.ForeColor = System.Drawing.Color.White;
            this.radBandVHF0.Name = "radBandVHF0";
            this.radBandVHF0.TabStop = true;
            this.radBandVHF0.UseVisualStyleBackColor = true;
            this.radBandVHF0.Click += new System.EventHandler(this.radBandVHF_Click);
            this.radBandVHF0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radBandVHF0_MouseDown);
            // 
            // panelModeSpecificFM
            // 
            resources.ApplyResources(this.panelModeSpecificFM, "panelModeSpecificFM");
            this.panelModeSpecificFM.BackColor = System.Drawing.Color.Transparent;
            this.panelModeSpecificFM.Controls.Add(this.ptbFMMic);
            this.panelModeSpecificFM.Controls.Add(this.chkFMTXRev);
            this.panelModeSpecificFM.Controls.Add(this.chkFMTXHigh);
            this.panelModeSpecificFM.Controls.Add(this.chkFMTXLow);
            this.panelModeSpecificFM.Controls.Add(this.lblMicValFM);
            this.panelModeSpecificFM.Controls.Add(this.radFMDeviation2kHz);
            this.panelModeSpecificFM.Controls.Add(this.labelTS7);
            this.panelModeSpecificFM.Controls.Add(this.lblFMOffset);
            this.panelModeSpecificFM.Controls.Add(this.btnFMMemoryDown);
            this.panelModeSpecificFM.Controls.Add(this.btnFMMemoryUp);
            this.panelModeSpecificFM.Controls.Add(this.btnFMMemory);
            this.panelModeSpecificFM.Controls.Add(this.lblFMDeviation);
            this.panelModeSpecificFM.Controls.Add(this.chkFMCTCSS);
            this.panelModeSpecificFM.Controls.Add(this.comboFMCTCSS);
            this.panelModeSpecificFM.Controls.Add(this.comboFMMemory);
            this.panelModeSpecificFM.Controls.Add(this.chkFMTXSimplex);
            this.panelModeSpecificFM.Controls.Add(this.udFMOffset);
            this.panelModeSpecificFM.Controls.Add(this.comboFMTXProfile);
            this.panelModeSpecificFM.Controls.Add(this.radFMDeviation5kHz);
            this.panelModeSpecificFM.Controls.Add(this.lblFMMic);
            this.panelModeSpecificFM.Name = "panelModeSpecificFM";
            // 
            // ptbFMMic
            // 
            resources.ApplyResources(this.ptbFMMic, "ptbFMMic");
            this.ptbFMMic.GreenThumb = false;
            this.ptbFMMic.HeadImage = null;
            this.ptbFMMic.LargeChange = 1;
            this.ptbFMMic.LimitBarColor = System.Drawing.Color.Red;
            this.ptbFMMic.LimitEnabled = false;
            this.ptbFMMic.LimitValue = 0;
            this.ptbFMMic.Maximum = 70;
            this.ptbFMMic.Minimum = -96;
            this.ptbFMMic.Name = "ptbFMMic";
            this.ptbFMMic.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbFMMic.SmallChange = 1;
            this.ptbFMMic.TabStop = false;
            this.ptbFMMic.Value = 6;
            this.ptbFMMic.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbFMMic_Scroll);
            // 
            // lblMicValFM
            // 
            this.lblMicValFM.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblMicValFM, "lblMicValFM");
            this.lblMicValFM.ForeColor = System.Drawing.Color.White;
            this.lblMicValFM.Name = "lblMicValFM";
            // 
            // labelTS7
            // 
            this.labelTS7.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.labelTS7, "labelTS7");
            this.labelTS7.ForeColor = System.Drawing.Color.White;
            this.labelTS7.Name = "labelTS7";
            // 
            // lblFMOffset
            // 
            resources.ApplyResources(this.lblFMOffset, "lblFMOffset");
            this.lblFMOffset.BackColor = System.Drawing.Color.Transparent;
            this.lblFMOffset.ForeColor = System.Drawing.Color.White;
            this.lblFMOffset.Name = "lblFMOffset";
            // 
            // lblFMDeviation
            // 
            this.lblFMDeviation.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblFMDeviation, "lblFMDeviation");
            this.lblFMDeviation.ForeColor = System.Drawing.Color.White;
            this.lblFMDeviation.Name = "lblFMDeviation";
            // 
            // comboFMMemory
            // 
            this.comboFMMemory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.comboFMMemory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFMMemory.DropDownWidth = 96;
            resources.ApplyResources(this.comboFMMemory, "comboFMMemory");
            this.comboFMMemory.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboFMMemory.Name = "comboFMMemory";
            this.comboFMMemory.SelectedIndexChanged += new System.EventHandler(this.comboFMMemory_SelectedIndexChanged);
            // 
            // lblFMMic
            // 
            this.lblFMMic.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblFMMic, "lblFMMic");
            this.lblFMMic.ForeColor = System.Drawing.Color.White;
            this.lblFMMic.Name = "lblFMMic";
            // 
            // panelBandGEN
            // 
            resources.ApplyResources(this.panelBandGEN, "panelBandGEN");
            this.panelBandGEN.BackColor = System.Drawing.Color.Transparent;
            this.panelBandGEN.Controls.Add(this.radBandGEN13);
            this.panelBandGEN.Controls.Add(this.radBandGEN12);
            this.panelBandGEN.Controls.Add(this.radBandGEN11);
            this.panelBandGEN.Controls.Add(this.radBandGEN10);
            this.panelBandGEN.Controls.Add(this.radBandGEN9);
            this.panelBandGEN.Controls.Add(this.radBandGEN8);
            this.panelBandGEN.Controls.Add(this.radBandGEN7);
            this.panelBandGEN.Controls.Add(this.radBandGEN6);
            this.panelBandGEN.Controls.Add(this.radBandGEN5);
            this.panelBandGEN.Controls.Add(this.radBandGEN4);
            this.panelBandGEN.Controls.Add(this.radBandGEN3);
            this.panelBandGEN.Controls.Add(this.radBandGEN2);
            this.panelBandGEN.Controls.Add(this.radBandGEN1);
            this.panelBandGEN.Controls.Add(this.radBandGEN0);
            this.panelBandGEN.Controls.Add(this.btnBandHF1);
            this.panelBandGEN.Name = "panelBandGEN";
            // 
            // btnBandHF1
            // 
            this.btnBandHF1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnBandHF1, "btnBandHF1");
            this.btnBandHF1.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnBandHF1.Name = "btnBandHF1";
            this.btnBandHF1.Selectable = true;
            this.btnBandHF1.Click += new System.EventHandler(this.btnBandHF_Click);
            // 
            // panelMeterLabels
            // 
            resources.ApplyResources(this.panelMeterLabels, "panelMeterLabels");
            this.panelMeterLabels.BackColor = System.Drawing.Color.Transparent;
            this.panelMeterLabels.Controls.Add(this.lblRXMeter);
            this.panelMeterLabels.Name = "panelMeterLabels";
            // 
            // lblRXMeter
            // 
            this.lblRXMeter.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblRXMeter, "lblRXMeter");
            this.lblRXMeter.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblRXMeter.Name = "lblRXMeter";
            // 
            // grpMultimeterMenus
            // 
            this.grpMultimeterMenus.BackColor = System.Drawing.Color.Transparent;
            this.grpMultimeterMenus.Controls.Add(this.comboMeterTXMode);
            this.grpMultimeterMenus.Controls.Add(this.comboMeterRXMode);
            resources.ApplyResources(this.grpMultimeterMenus, "grpMultimeterMenus");
            this.grpMultimeterMenus.Name = "grpMultimeterMenus";
            this.grpMultimeterMenus.TabStop = false;
            // 
            // panelAndromedaMisc
            // 
            resources.ApplyResources(this.panelAndromedaMisc, "panelAndromedaMisc");
            this.panelAndromedaMisc.BackColor = System.Drawing.Color.Transparent;
            this.panelAndromedaMisc.Controls.Add(this.tbAndromedaEncoderSlider);
            this.panelAndromedaMisc.Controls.Add(this.lblAndromedaEncoderSlider);
            this.panelAndromedaMisc.Controls.Add(this.lblATUTuneLabel);
            this.panelAndromedaMisc.Name = "panelAndromedaMisc";
            // 
            // tbAndromedaEncoderSlider
            // 
            resources.ApplyResources(this.tbAndromedaEncoderSlider, "tbAndromedaEncoderSlider");
            this.tbAndromedaEncoderSlider.BackColor = System.Drawing.Color.Black;
            this.tbAndromedaEncoderSlider.Maximum = 100;
            this.tbAndromedaEncoderSlider.Name = "tbAndromedaEncoderSlider";
            this.tbAndromedaEncoderSlider.TickFrequency = 10;
            this.tbAndromedaEncoderSlider.Value = 50;
            // 
            // lblAndromedaEncoderSlider
            // 
            resources.ApplyResources(this.lblAndromedaEncoderSlider, "lblAndromedaEncoderSlider");
            this.lblAndromedaEncoderSlider.ForeColor = System.Drawing.Color.White;
            this.lblAndromedaEncoderSlider.Name = "lblAndromedaEncoderSlider";
            // 
            // lblATUTuneLabel
            // 
            this.lblATUTuneLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblATUTuneLabel, "lblATUTuneLabel");
            this.lblATUTuneLabel.ForeColor = System.Drawing.Color.White;
            this.lblATUTuneLabel.Name = "lblATUTuneLabel";
            // 
            // picRX2Squelch
            // 
            this.picRX2Squelch.BackColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.picRX2Squelch, "picRX2Squelch");
            this.picRX2Squelch.Name = "picRX2Squelch";
            this.picRX2Squelch.TabStop = false;
            this.picRX2Squelch.Paint += new System.Windows.Forms.PaintEventHandler(this.picRX2Squelch_Paint);
            // 
            // ptbRX2Squelch
            // 
            resources.ApplyResources(this.ptbRX2Squelch, "ptbRX2Squelch");
            this.ptbRX2Squelch.GreenThumb = false;
            this.ptbRX2Squelch.HeadImage = null;
            this.ptbRX2Squelch.LargeChange = 1;
            this.ptbRX2Squelch.LimitBarColor = System.Drawing.Color.Red;
            this.ptbRX2Squelch.LimitEnabled = false;
            this.ptbRX2Squelch.LimitValue = 0;
            this.ptbRX2Squelch.Maximum = 0;
            this.ptbRX2Squelch.Minimum = -160;
            this.ptbRX2Squelch.Name = "ptbRX2Squelch";
            this.ptbRX2Squelch.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbRX2Squelch.SmallChange = 1;
            this.ptbRX2Squelch.TabStop = false;
            this.ptbRX2Squelch.Value = 0;
            this.ptbRX2Squelch.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbRX2Squelch_Scroll);
            // 
            // picSquelch
            // 
            this.picSquelch.BackColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.picSquelch, "picSquelch");
            this.picSquelch.Name = "picSquelch";
            this.picSquelch.TabStop = false;
            this.picSquelch.Paint += new System.Windows.Forms.PaintEventHandler(this.picSquelch_Paint);
            // 
            // ptbSquelch
            // 
            resources.ApplyResources(this.ptbSquelch, "ptbSquelch");
            this.ptbSquelch.GreenThumb = false;
            this.ptbSquelch.HeadImage = null;
            this.ptbSquelch.LargeChange = 1;
            this.ptbSquelch.LimitBarColor = System.Drawing.Color.Red;
            this.ptbSquelch.LimitEnabled = false;
            this.ptbSquelch.LimitValue = 0;
            this.ptbSquelch.Maximum = 0;
            this.ptbSquelch.Minimum = -160;
            this.ptbSquelch.Name = "ptbSquelch";
            this.ptbSquelch.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ptbSquelch.SmallChange = 1;
            this.ptbSquelch.TabStop = false;
            this.ptbSquelch.Value = 0;
            this.ptbSquelch.Scroll += new Thetis.PrettyTrackBar.ScrollHandler(this.ptbSquelch_Scroll);
            // 
            // Console
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.panelDisplay);
            this.Controls.Add(this.lblPAProfile);
            this.Controls.Add(this.nudPwrTemp2);
            this.Controls.Add(this.nudPwrTemp);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.grpMultimeter);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelRX2RF);
            this.Controls.Add(this.chkFullDuplex);
            this.Controls.Add(this.picRX2Squelch);
            this.Controls.Add(this.ptbRX2Squelch);
            this.Controls.Add(this.chkRX2Squelch);
            this.Controls.Add(this.panelRX2DSP);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnHidden);
            this.Controls.Add(this.panelOptions);
            this.Controls.Add(this.panelRX2Filter);
            this.Controls.Add(this.panelRX2Mode);
            this.Controls.Add(this.panelRX2Display);
            this.Controls.Add(this.panelRX2Mixer);
            this.Controls.Add(this.panelMultiRX);
            this.Controls.Add(this.lblAF2);
            this.Controls.Add(this.lblPWR2);
            this.Controls.Add(this.panelDisplay2);
            this.Controls.Add(this.panelDSP);
            this.Controls.Add(this.panelVFO);
            this.Controls.Add(this.panelSoundControls);
            this.Controls.Add(this.grpRX2Meter);
            this.Controls.Add(this.grpDisplaySplit);
            this.Controls.Add(this.grpVFOBetween);
            this.Controls.Add(this.grpVFOA);
            this.Controls.Add(this.picSquelch);
            this.Controls.Add(this.grpVFOB);
            this.Controls.Add(this.chkSquelch);
            this.Controls.Add(this.panelPower);
            this.Controls.Add(this.panelMode);
            this.Controls.Add(this.ptbSquelch);
            this.Controls.Add(this.panelRX2Power);
            this.Controls.Add(this.lblRF2);
            this.Controls.Add(this.panelBandHF);
            this.Controls.Add(this.panelBandVHF);
            this.Controls.Add(this.panelBandGEN);
            this.Controls.Add(this.panelMeterLabels);
            this.Controls.Add(this.panelButtonBar);
            this.Controls.Add(this.panelVFOBLabels);
            this.Controls.Add(this.grpMultimeterMenus);
            this.Controls.Add(this.panelVFOALabels);
            this.Controls.Add(this.panelVFOLabels);
            this.Controls.Add(this.panelAndromedaMisc);
            this.Controls.Add(this.panelModeSpecificPhone);
            this.Controls.Add(this.panelModeSpecificFM);
            this.Controls.Add(this.panelModeSpecificDigital);
            this.Controls.Add(this.panelModeSpecificCW);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Console";
            this.Opacity = 0D;
            this.Activated += new System.EventHandler(this.Console_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Console_Closing);
            this.Deactivate += new System.EventHandler(this.Console_Deactivate);
            this.Shown += new System.EventHandler(this.Console_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Console_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Console_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Console_KeyUp);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Console_MouseWheel);
            this.Resize += new System.EventHandler(this.Console_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.udFilterHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFilterLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTXFilterLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTXFilterHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udCWPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udCWBreakInDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRX2FilterHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRX2FilterLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRIT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udXIT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFMOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRX1StepAttData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRX2StepAttData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFilterShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFilterWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX2RF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCWSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDisplayZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDisplayPan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPWR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPanMainRX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPanSubRX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX2Gain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX2Pan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX0Gain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX1Gain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbVACRXGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbVACTXGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX2AF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX1AF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCWAPFGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCWAPFBandwidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCWAPFFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTune)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTXStepAttData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAutoAttWarningRX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAutoAttWarningRX2)).EndInit();
            this.contextMenuStripFilterRX1.ResumeLayout(false);
            this.contextMenuStripFilterRX2.ResumeLayout(false);
            this.contextMenuStripNotch.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPwrTemp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPwrTemp)).EndInit();
            this.grpMultimeter.ResumeLayout(false);
            this.grpMultimeter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMultiMeterDigital)).EndInit();
            this.panelFilter.ResumeLayout(false);
            this.panelRX2RF.ResumeLayout(false);
            this.panelRX2DSP.ResumeLayout(false);
            this.panelOptions.ResumeLayout(false);
            this.panelModeSpecificPhone.ResumeLayout(false);
            this.panelModeSpecificPhone.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNoiseGate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbNoiseGate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVOX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbVOX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCPDR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMic)).EndInit();
            this.panelButtonBar.ResumeLayout(false);
            this.panelVFOLabels.ResumeLayout(false);
            this.panelVFOALabels.ResumeLayout(false);
            this.panelVFOALabels.PerformLayout();
            this.panelVFOBLabels.ResumeLayout(false);
            this.panelVFOBLabels.PerformLayout();
            this.panelRX2Power.ResumeLayout(false);
            this.panelPower.ResumeLayout(false);
            this.panelModeSpecificCW.ResumeLayout(false);
            this.panelModeSpecificCW.PerformLayout();
            this.grpCWAPF.ResumeLayout(false);
            this.grpSemiBreakIn.ResumeLayout(false);
            this.grpSemiBreakIn.PerformLayout();
            this.panelRX2Filter.ResumeLayout(false);
            this.panelRX2Mode.ResumeLayout(false);
            this.panelRX2Display.ResumeLayout(false);
            this.panelRX2Mixer.ResumeLayout(false);
            this.panelMultiRX.ResumeLayout(false);
            this.panelDisplay2.ResumeLayout(false);
            this.panelDSP.ResumeLayout(false);
            this.panelVFO.ResumeLayout(false);
            this.panelSoundControls.ResumeLayout(false);
            this.panelModeSpecificDigital.ResumeLayout(false);
            this.panelModeSpecificDigital.PerformLayout();
            this.grpVACStereo.ResumeLayout(false);
            this.grpDIGSampleRate.ResumeLayout(false);
            this.panelDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            this.panelMode.ResumeLayout(false);
            this.panelBandHF.ResumeLayout(false);
            this.grpVFOA.ResumeLayout(false);
            this.grpVFOA.PerformLayout();
            this.grpVFOB.ResumeLayout(false);
            this.grpVFOB.PerformLayout();
            this.grpVFOBetween.ResumeLayout(false);
            this.grpVFOBetween.PerformLayout();
            this.grpDisplaySplit.ResumeLayout(false);
            this.grpRX2Meter.ResumeLayout(false);
            this.grpRX2Meter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRX2Meter)).EndInit();
            this.panelBandVHF.ResumeLayout(false);
            this.panelModeSpecificFM.ResumeLayout(false);
            this.panelModeSpecificFM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFMMic)).EndInit();
            this.panelBandGEN.ResumeLayout(false);
            this.panelMeterLabels.ResumeLayout(false);
            this.grpMultimeterMenus.ResumeLayout(false);
            this.panelAndromedaMisc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbAndromedaEncoderSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRX2Squelch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbRX2Squelch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSquelch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSquelch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private ToolStripMenuItem NR2ToolStripMenuItem1;
        private ToolStripMenuItem SNBtoolStripMenuItem;
        private ToolStripMenuItem NR2StripMenuItem2;
        private ToolStripMenuItem SNBtoolStripMenuItem1;
        private LabelTS lblBandStack;
        public TextBoxTS regBandStackCurrentEntry;
        public TextBoxTS regBandStackTotalEntries;
        private PanelTS panelBandGEN;
        private RadioButtonTS radBandGEN13;
        private RadioButtonTS radBandGEN12;
        private RadioButtonTS radBandGEN11;
        private RadioButtonTS radBandGEN10;
        private RadioButtonTS radBandGEN9;
        private RadioButtonTS radBandGEN8;
        private RadioButtonTS radBandGEN7;
        private RadioButtonTS radBandGEN6;
        private RadioButtonTS radBandGEN5;
        private RadioButtonTS radBandGEN4;
        private RadioButtonTS radBandGEN3;
        private RadioButtonTS radBandGEN2;
        private RadioButtonTS radBandGEN1;
        private RadioButtonTS radBandGEN0;
        private ButtonTS btnBandHF1;
        private LabelTS lblTXHigh;
        private LabelTS lblTXLow;
        public NumericUpDownTS udTXFilterLow;
        public NumericUpDownTS udTXFilterHigh;
        private CheckBoxTS chkRxAnt;
        private LabelTS labelTS1;
        private CheckBoxTS chkVFOBLock;
        private CheckBoxTS chkQSK;
        private PanelTS panelVFOALabels;
        private PanelTS panelVFOBLabels;
        private PanelTS panelVFOLabels;
        private LabelTS lblRITLabel;
        private LabelTS lblXITLabel;
        private LabelTS lblAGCLabel;
        private LabelTS lblAttenLabel;
        private LabelTS lblCtunLabel;
        private LabelTS lblRX2AttenLabel;
        private LabelTS lblRX2AGCLabel;
        private LabelTS lblRX2CtunLabel;
        private LabelTS lblModeBigLabel;
        private LabelTS lblRX2ModeBigLabel;
        private LabelTS lblRX2LockLabel;
        private LabelTS lblLockLabel;
        private LabelTS lblXITValue;
        private LabelTS lblRITValue;
        private LabelTS lblVFOSplit;
        private LabelTS lblStepValue;
        private LabelTS lblStep;
        private PanelTS panelMeterLabels;
        private LabelTS lblRXMeter;
        public ToolStripMenuItem andromedaTopControlsToolStripMenuItem;
        public ToolStripMenuItem andromedaButtonBarToolStripMenuItem;
        private GroupBoxTS grpMultimeterMenus;
        private ToolStripMenuItem BPFToolStripMenuItem;
        private ToolStripMenuItem BPF1ToolStripMenuItem;
        private ToolStripMenuItem BPF2ToolStripMenuItem;
        private ComboBoxTS comboAMTXProfile;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel toolStripStatusLabel_Amps;
        private ToolStripStatusLabel toolStripStatusLabel_Volts;
        private ToolStripStatusLabel toolStripStatusLabel_Fill;
        private ToolStripStatusLabel toolStripStatusLabel_UTCTime;
        private ToolStripStatusLabel toolStripStatusLabel_Date;
        private ToolStripStatusLabel toolStripStatusLabel_LocalTime;
        private ToolStripStatusLabel toolStripStatusLabel_SeqWarning;
        private ToolStripDropDownButton toolStripDropDownButton_ScreenSize;
        private ToolStripMenuItem toolStripMenuItem_4by3;
        private ToolStripMenuItem toolStripMenuItem_16by9;
        private ToolStripMenuItem toolStripMenuItem_16by10;
        private ToolStripMenuItem x768ToolStripMenuItem;
        private ToolStripMenuItem x864ToolStripMenuItem;
        private ToolStripMenuItem x960ToolStripMenuItem;
        private ToolStripMenuItem x1050ToolStripMenuItem;
        private ToolStripMenuItem x1200ToolStripMenuItem;
        private ToolStripMenuItem x720ToolStripMenuItem;
        private ToolStripMenuItem x768ToolStripMenuItem1;
        private ToolStripMenuItem x900ToolStripMenuItem;
        private ToolStripMenuItem x1080ToolStripMenuItem;
        private ToolStripMenuItem x800ToolStripMenuItem;
        private ToolStripMenuItem x900ToolStripMenuItem1;
        private ToolStripMenuItem x1050ToolStripMenuItem1;
        private ToolStripMenuItem x1200ToolStripMenuItem1;
        private ToolStripMenuItem youTubeToolStripMenuItem;
        private ToolStripMenuItem pToolStripMenuItem;
        private ToolStripMenuItem pToolStripMenuItem1;
        private ToolStripMenuItem pToolStripMenuItem2;
        private ToolStripMenuItem pToolStripMenuItem3;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem includeBordersToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem x1440ToolStripMenuItem;
        private ToolStripMenuItem x2160ToolStripMenuItem;
        private ToolStripMenuItem x1600ToolStripMenuItem;
        private ToolStripMenuItem x2400ToolStripMenuItem;
        private PanelTS pnlResizeMeter;
        private ToolStripDropDownButton toolStripDropDownButton_CPU;
        private ToolStripMenuItem systemToolStripMenuItem;
        private ToolStripMenuItem thetisOnlyToolStripMenuItem;
        private PanelTS panelAndromedaMisc;
        private LabelTS lblATUTuneLabel;
        private LabelTS lblAndromedaEncoderSlider;
        private TrackBarTS tbAndromedaEncoderSlider;
        private ToolStripStatusLabel toolStripStatusLabel_timer;
        private ToolStripDropDownButton toolStripStatusLabelTXAnt;
        private ToolStripMenuItem toolStripMenuItem16;
        private ToolStripMenuItem toolStripMenuItem15;
        private ToolStripMenuItem toolStripMenuItem17;
        private ToolStripDropDownButton toolStripStatusLabelRXAnt;
        private ToolStripMenuItem toolStripMenuItem20;
        private ToolStripMenuItem toolStripMenuItem19;
        private ToolStripMenuItem toolStripMenuItem18;
        private ToolStripStatusLabel toolStripStatusLabelAndromedaMulti;
        private ucQuickRecall ucQuickRecallPad;
        private CheckBoxTS checkBoxTS1;
        private CheckBoxTS chkExternalPA;
        private Timer tmrAutoAGC;
        private ButtonTS btnDisplayZTB;
        private ucInfoBar infoBar;
        private ucUnderOverFlowWarningViewer ucVAC2UnderOver;
        private ucUnderOverFlowWarningViewer ucVAC1UnderOver;
        private PrettyTrackBar ptbTune;
        private LabelTS lblTune;
        private LabelTS lblPAProfile;
        private NumericUpDownTS nudPwrTemp;
        private NumericUpDownTS nudPwrTemp2;
        private ToolStripStatusLabel toolStripStatusLabel_TXInhibit;
        private ToolStripMenuItem finderMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel_CMstatus;
        private ToolStripStatusLabel toolStripStatusLabel_CatSerial;
        private ToolStripStatusLabel toolStripStatusLabel_N1MM;
        private ToolStripStatusLabel toolStripStatusLabel_CatTCPip;
        private ToolStripStatusLabel toolStripStatusLabel_TCI;
        private NumericUpDownTS udTXStepAttData;
        private ToolStripMenuItem databaseManagerToolStripMenuItem;
        private ToolStripMenuItem setupToolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem miAbout;
        private PictureBox pbAutoAttWarningRX1;
        private PictureBox pbAutoAttWarningRX2;
    }
}
