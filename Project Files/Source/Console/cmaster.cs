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
using System.Diagnostics;

namespace Thetis
{

    unsafe class cmaster
    {

        #region cmaster method definitions

        // cmaster

        [DllImport("ChannelMaster.dll", EntryPoint = "SetRadioStructure", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRadioStructure(
            int cmSTREAM,			// total number of input streams to set up
            int cmRCVR,				// number of receivers to set up
            int cmXMTR,				// number of transmitters to set up
            int cmSubRCVR,			// number of sub-receivers per receiver to set up
            int cmNspc,				// number of TYPES of special units
            int* cmSPC,				// number of special units of each type
            int* cmMAXInbound,		// maximum number of samples in a call to Inbound()
            int cmMAXInRate,		// maximum sample rate of an input stream
            int cmMAXAudioRate,		// maximum channel audio output rate (incl. rcvr and tx monitor audio)
            int cmMAXTxOutRate		// maximum transmitter channel output sample rate
            );

        [DllImport("ChannelMaster.dll", EntryPoint = "CreateRadio", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CreateRadio();

        [DllImport("ChannelMaster.dll", EntryPoint = "DestroyRadio", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyRadio();

        [DllImport("ChannelMaster.dll", EntryPoint = "set_cmdefault_rates", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCMDefaultRates(int* xcm_inrates, int aud_outrate, int* rcvr_ch_outrates, int* xmtr_ch_outrates);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetXcmInrate", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetXcmInrate(int in_id, int rate);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetXmtrChannelOutrate", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetXmtrChannelOutrate(int xmtr_id, int rate, bool state);

        [DllImport("ChannelMaster.dll", EntryPoint = "getbuffsize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetBuffSize (int rate);

        [DllImport("ChannelMaster.dll", EntryPoint = "inid", CallingConvention = CallingConvention.Cdecl)]
        public static extern int inid(int stype, int id);

        [DllImport("ChannelMaster.dll", EntryPoint = "chid", CallingConvention = CallingConvention.Cdecl)]
        public static extern int chid (int stream, int subrx);

        [DllImport("ChannelMaster.dll", EntryPoint = "getInputRate", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetInputRate (int stype, int id);

        [DllImport("ChannelMaster.dll", EntryPoint = "getChannelOutputRate", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetChannelOutputRate(int stype, int id);

        [DllImport("ChannelMaster.dll", EntryPoint = "getCMAstate", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCMAstate();

        // router

        [DllImport("ChannelMaster.dll", EntryPoint = "LoadRouterAll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LoadRouterAll(void* ptr, int id, int ports, int calls, int varvals, 
            int* nstreams, int* function, int* callid);

        [DllImport("ChannelMaster.dll", EntryPoint = "LoadRouterControlBit", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LoadRouterControlBit(void* ptr, int id, int var_number, int bit);

        // display setup

        [DllImport("ChannelMaster.dll", EntryPoint = "SetTopPan3Run", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTopPan3Run(bool run);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetRunPanadapter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRunPanadapter(int id, bool run);

        // puresignal setup

        [DllImport("ChannelMaster.dll", EntryPoint = "SetPSTxIdx", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSTxIdx(int id, int idx);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetPSRxIdx", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPSRxIdx(int id, int idx);

        // cmaster multiple analyzers
        [DllImport("ChannelMaster.dll", EntryPoint = "alloc_analyzer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AllocAnalyzer(int stype, int id, int max_fft_size);
        [DllImport("ChannelMaster.dll", EntryPoint = "free_analyzer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FreeAnalyzer(int disp);

        [DllImport("ChannelMaster.dll", EntryPoint = "run_analyzer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RunAnalyzer(int disp, int run);

        // vox-dexp

        [DllImport("wdsp.dll", EntryPoint = "SetDEXPAttackThreshold", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTXAVoxThresh(int id, double thresh);

        [DllImport("wdsp.dll", EntryPoint = "GetDEXPPeakSignal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetDEXPPeakSignal(int id, double* peak);         // called by console.cs

        [DllImport("wdsp.dll", EntryPoint = "SetDEXPRun", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDEXPRun (int id, bool run);

        [DllImport("wdsp.dll", EntryPoint = "SetDEXPDetectorTau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDEXPDetectorTau(int id, double tau);

        [DllImport("wdsp.dll", EntryPoint = "SetDEXPAttackTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDEXPAttackTime(int id, double time);

        [DllImport("wdsp.dll", EntryPoint = "SetDEXPReleaseTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDEXPReleaseTime(int id, double time);

        [DllImport("wdsp.dll", EntryPoint = "SetDEXPHoldTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDEXPHoldTime(int id, double time);

        [DllImport("wdsp.dll", EntryPoint = "SetDEXPExpansionRatio", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDEXPExpansionRatio(int id, double ratio);

        [DllImport("wdsp.dll", EntryPoint = "SetDEXPHysteresisRatio", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDEXPHysteresisRatio(int id, double ratio);

        [DllImport("wdsp.dll", EntryPoint = "SetDEXPAttackThreshold", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDEXPAttackThreshold(int id, double thresh);

        [DllImport("wdsp.dll", EntryPoint = "SetDEXPLowCut", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDEXPLowCut(int id, double lowcut);

        [DllImport("wdsp.dll", EntryPoint = "SetDEXPHighCut", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDEXPHighCut(int id, double highcut);

        [DllImport("wdsp.dll", EntryPoint = "SetDEXPRunSideChannelFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDEXPRunSideChannelFilter(int id, bool run);

        [DllImport("wdsp.dll", EntryPoint = "SetDEXPRunVox", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDEXPRunVox(int id, bool run);

        [DllImport("wdsp.dll", EntryPoint = "SetDEXPRunAudioDelay", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDEXPRunAudioDelay(int id, bool run);

        [DllImport("wdsp.dll", EntryPoint = "SetDEXPAudioDelay", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDEXPAudioDelay(int id, double delay);

        [DllImport("wdsp.dll", EntryPoint = "SetAntiVOXRun", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAntiVOXRun(int id, bool run);

        [DllImport("wdsp.dll", EntryPoint = "SetAntiVOXGain", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAntiVOXGain(int id, double gain);

        [DllImport("wdsp.dll", EntryPoint = "SetAntiVOXDetectorTau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAntiVOXDetectorTau(int id, double tau);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetAntiVOXSourceStates", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAntiVOXSourceStates(int txid, int streams, int states);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetAntiVOXSourceWhat", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAntiVOXSourceWhat(int txid, int stream, int state);

        // siphon

        [DllImport("wdsp.dll", EntryPoint = "SetSiphonInsize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSiphonInsize (int id, int size);

        [DllImport("wdsp.dll", EntryPoint = "GetaSipF1EXT", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetaSipF1EXT (int id, float* buff, int size);     // called by console.cs

        // audio mixer

        [DllImport("ChannelMaster.dll", EntryPoint = "SetAAudioMixWhat", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAAudioMixWhat(void* ptr, int id, int stream, bool state);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetAAudioMixState", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAAudioMixState(void* ptr, int id, int stream, bool state);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetAAudioMixStates", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAAudioMixStates(void* ptr, int id, int streams, int states);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetAAudioMixVolume", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAAudioMixVolume(void* ptr, int id, double volume);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetAAudioMixVol", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAAudioMixVol(void* ptr, int id, int stream, double vol);

        // VAC transmit audio selection

        [DllImport("ChannelMaster.dll", EntryPoint = "SetTXVAC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTXVAC(int txid, int txvac);

        // Penelope output level

        [DllImport("ChannelMaster.dll", EntryPoint = "SetTXFixedGainRun", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTXFixedGainRun(int id, bool run);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetTXFixedGain", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTXFixedGain(int id, double Igain, double Qgain);

        // eer/etr

        [DllImport("ChannelMaster.dll", EntryPoint = "SetEERRun", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetEERRun(int id, bool run);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetEERAMIQ", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetEERAMIQ(int id, bool amiq);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetEERMgain", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetEERMgain(int id, double gain);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetEERPgain", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetEERPgain(int id, double gain);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetEERRunDelays", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetEERRunDelays(int id, bool run);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetEERMdelay", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetEERMdelay(int id, double delay);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetEERPdelay", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetEERPdelay(int id, double delay);

        // noise blanker - call directly from various places

        [DllImport("ChannelMaster.dll", EntryPoint = "SetRCVRANBRun", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRCVRANBRun(int stype, int id, bool run);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetRCVRANBTau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRCVRANBTau(int stype, int id, double tau);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetRCVRANBHangtime", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRCVRANBHangtime(int stype, int id, double time);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetRCVRANBAdvtime", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRCVRANBAdvtime(int stype, int id, double time);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetRCVRANBBacktau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRCVRANBBacktau(int stype, int id, double tau);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetRCVRANBThreshold", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRCVRANBThreshold(int stype, int id, double thresh);

        // noise blanker II - call directly from various places

        [DllImport("ChannelMaster.dll", EntryPoint = "SetRCVRNOBRun", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRCVRNOBRun(int stype, int id, bool run);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetRCVRNOBMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRCVRNOBMode(int stype, int id, int mode);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetRCVRNOBTau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRCVRNOBTau(int stype, int id, double tau);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetRCVRNOBHangtime", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRCVRNOBHangtime(int stype, int id, double time);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetRCVRNOBAdvtime", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRCVRNOBAdvtime(int stype, int id, double time);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetRCVRNOBBacktau", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRCVRNOBBacktau(int stype, int id, double tau);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetRCVRNOBThreshold", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRCVRNOBThreshold(int stype, int id, double thresh);

        // external amplifier protection

        [DllImport("ChannelMaster.dll", EntryPoint = "GetAndResetAmpProtect", CallingConvention = CallingConvention.Cdecl)]
        extern public static int GetAndResetAmpProtect(int txid);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetAmpProtectRun", CallingConvention = CallingConvention.Cdecl)]
        extern public static void SetAmpProtectRun(int txid, int run);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetADCSupply", CallingConvention = CallingConvention.Cdecl)]
        extern public static void SetADCSupply(int txid, int v);

        // monitoring & debugging

        [DllImport("ChannelMaster.dll", EntryPoint = "getLEDs", CallingConvention = CallingConvention.Cdecl)]
        extern public static int getLEDs();

        // version
        [DllImport("ChannelMaster.dll", EntryPoint = "GetCMVersion", CallingConvention = CallingConvention.Cdecl)]
        extern public static int GetCMVersion();

        [DllImport("cmASIO.dll", EntryPoint = "GetCMasioVersion", CallingConvention = CallingConvention.Cdecl)]
        extern public static int GetCMasioVersion();
        #endregion

        #region properties

        // set in audio.cs
        private static bool mox = false;
        public static bool Mox
        {
            get { return mox; }
            set         
            {
                mox = value;
                if (mox)
                {
                    LoadRouterControlBit((void *)0, 0, 2, 1);
                    WaveThing.wplayer[0].Condx = 1;
                    WaveThing.wplayer[1].Condx = 1;
                    WaveThing.wrecorder[0].Condx = 1;
                    WaveThing.wrecorder[1].Condx = 1;
                    Scope.dscope[0].Condx = 1;
                }
                else
                {
                    LoadRouterControlBit((void*)0, 0, 2, 0);
                    WaveThing.wplayer[0].Condx = 0;
                    WaveThing.wplayer[1].Condx = 0;
                    WaveThing.wrecorder[0].Condx = 0;
                    WaveThing.wrecorder[1].Condx = 0;
                    Scope.dscope[0].Condx = 0;
                }
                cmaster.CMSetEERRun(0);
            }
        }

        private static bool MONmixState = false;
        public static bool MONMixState
        {
            get { return MONmixState; }
            set
            {
                MONmixState = value;
            }
        }

       

        // number of software receivers
        private static int cmRCVR = 5;  
        public static int CMrcvr
        {
            get { return cmRCVR; }
        }

        // number of sub-receivers per receiver (2 = main + one_sub)
        private static int cmSubRCVR = 2;
        public static int CMsubrcvr
        {
            get { return cmSubRCVR; }
        }

        private static int ps_rate = 192000;
        public static int PSrate
        {
            get { return ps_rate; }
            set { ps_rate = value; }
        }

        public static RadioProtocol CurrentRadioProtocol { get; set; }
        #endregion

        #region logic calls

        public static void CMCreateCMaster()
        {
            // set radio structure
            int[] cmSPC = new int[1] {2};
            int[] cmInboundSize = new int[8] { 240, 240, 240, 240, 240, 720, 240, 240 };
            fixed (int* pcmSPC = cmSPC, pcmIbSize = cmInboundSize)
                cmaster.SetRadioStructure(8, cmRCVR, 1, cmSubRCVR, 1, pcmSPC, pcmIbSize, 1536000, 48000, 384000);

            // send function pointers
            cmaster.SendCallbacks();

            // set default rates
            int[] xcm_inrates = new int[8] {192000, 192000, 192000, 192000, 192000, 48000, 192000, 192000};
            int aud_outrate = 48000;
            int[] rcvr_ch_outrates = new int[5] {48000, 48000, 48000, 48000, 48000};
            int[] xmtr_ch_outrates = new int[1] { 192000 };
            fixed (int* p1 = xcm_inrates, p2 = rcvr_ch_outrates, p3 = xmtr_ch_outrates)
                cmaster.SetCMDefaultRates(p1, aud_outrate, p2, p3);

            // create receivers, transmitters, specials, and buffers
            cmaster.CreateRadio();

            // get transmitter identifiers
            int txinid = cmaster.inid(1, 0);        // stream id
            int txch = cmaster.chid(txinid, 0);     // wdsp channel

            // setup transmitter input sample rate here since it is fixed
            cmaster.SetXcmInrate(txinid, 48000);

            // setup CFIR to run; it will always be ON with new protocol firmware
            WDSP.SetTXACFIRRun(txch, true);

            // set PureSignal basic parameters
            // note:  if future models have different settings, these calls could be moved to
            //      CMLoadRouterAll() which is called each time the receiver model changes.
            SetPSRxIdx(0, 0);   // txid = 0, all current models use Stream0 for RX feedback
            SetPSTxIdx(0, 1);   // txid = 0, all current models use Stream1 for TX feedback
            puresignal.SetPSFeedbackRate(txch, ps_rate);
            puresignal.SetPSHWPeak(txch, 0.2899);

            // setup transmitter display
            WDSP.TXASetSipMode(txch, 1);            // 1=>call the appropriate 'analyzer'
            WDSP.TXASetSipDisplay(txch, txinid);    // disp = txinid = tx stream

            NetworkIO.CreateRNet();
            
            //cmaster.create_rxa();

           // create_wb();
        }

        private static bool ps_loopback = false;
        public static bool PSLoopback
        {
            get { return ps_loopback; }
            set
            {
                ps_loopback = value;
                if (Audio.console != null)
                    CMLoadRouterAll(Audio.console.CurrentHPSDRModel);
            }
        }

        public static void CMLoadRouterAll(HPSDRModel model)
        {
            int txinid = cmaster.inid(1, 0);        // stream id
            int txch = cmaster.chid(txinid, 0);     // wdsp channel

            // MI0BOT: Set correct SetPSHWPeak for HL2 and different model for reduced bandwidth

            if (model != HPSDRModel.HERMESLITE)
                puresignal.SetPSHWPeak(txch, 0.2899);

            if (model == HPSDRModel.HERMESLITE && Audio.console.ReduceEthernetBW)
            {
                model = HPSDRModel.ANAN10E;
            }

            switch (NetworkIO.CurrentRadioProtocol)
            {
                case RadioProtocol.USB:
                    if (ps_loopback)
                    {
                        switch (model)
                        {
                            case HPSDRModel.ANAN10E:
                            case HPSDRModel.ANAN100B:
                                int[] TWO_DDC_Function = new int[16]
                                    {
                                    2, 2, 2, 2, 2, 2, 2, 2,     // DDC0+DDC1, port 1035, Call 0
                                    0, 0, 0, 0, 0, 2, 0, 2      // DDC0+DDC1, port 1035, Call 1
                                    };
                                int[] TWO_DDC_Callid = new int[16]
                                    {
                                    2, 2, 2, 2, 2, 1, 2, 1,      // DDC0+DDC1, port 1035, Call 0
                                    0, 0, 0, 0, 0, 2, 0, 2       // DDC0+DDC1, port 1035, Call 1
                                    };
                                int[] TWO_DDC_nstreams = new int[1]
                                    {
                                    2                           // DDC0+DDC1, port 1035
                                    };
                                fixed (int* pstreams = &TWO_DDC_nstreams[0], pfunction = &TWO_DDC_Function[0], pcallid = &TWO_DDC_Callid[0])
                                    LoadRouterAll((void*)0, 0, 1, 2, 8, pstreams, pfunction, pcallid);
                                break;
                            case HPSDRModel.HERMES:
                            case HPSDRModel.HERMESLITE: // MI0BOT: HL2
                            case HPSDRModel.ANAN10:
                            case HPSDRModel.ANAN100:
                                int[] FOUR_DDC_Function = new int[48]
                                    {
                                    1, 1, 1, 1, 1, 0, 1, 0,     // DDC0,      port 1035, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0,     // DDC0,      port 1035, Call 1
                                    0, 0, 0, 0, 0, 2, 0, 2,     // DDC2+DDC3, port 1036, Call 0
                                    0, 0, 0, 0, 0, 2, 0, 2,     // DDC2+DDC3, port 1036, Call 1
                                    1, 1, 1, 1, 1, 0, 1, 0,     // DDC1,      port 1037, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0      // DDC1,      port 1037, Call 1
                                    };
                                int[] FOUR_DDC_Callid = new int[48]
                                    {
                                    0, 0, 0, 0, 0, 0, 0, 0,     // DDC0,      port 1035, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0,     // DDC0,      port 1035, Call 1
                                    0, 0, 0, 0, 0, 1, 0, 1,     // DDC2+DDC3, port 1036, Call 0
                                    0, 0, 0, 0, 0, 2, 0, 2,     // DDC2+DDC3, port 1036, Call 1
                                    1, 1, 1, 1, 1, 0, 1, 0,     // DDC1,      port 1037, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0      // DDC1,      port 1037, Call 1
                                    };
                                int[] FOUR_DDC_nstreams = new int[3]
                                    {
                                    1,                          // DDC0,      port 1035
                                    2,                          // DDC2+DDC3, port 1036
                                    1                           // DDC1,      port 1037
                                    };
                                fixed (int* pstreams = &FOUR_DDC_nstreams[0], pfunction = &FOUR_DDC_Function[0], pcallid = &FOUR_DDC_Callid[0])
                                    LoadRouterAll((void*)0, 0, 3, 2, 8, pstreams, pfunction, pcallid);
                                break;
                            case HPSDRModel.ANAN100D:
                            case HPSDRModel.ANAN200D:
                            case HPSDRModel.ORIONMKII:
                            case HPSDRModel.ANAN7000D:
                            case HPSDRModel.ANAN8000D:
                            case HPSDRModel.ANVELINAPRO3:
                                int[] FIVE_DDC_Function = new int[48]
                                    {
                                    2, 2, 2, 2, 2, 0, 2, 0,     // DDC0+DDC1, port 1035, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0,     // DDC0+DDC1, port 1035, Call 1
                                    0, 0, 0, 0, 0, 2, 0, 2,     // DDC3+DDC4, port 1036, Call 0
                                    0, 0, 0, 0, 0, 2, 0, 2,     // DDC3+DDC4, port 1036, Call 1
                                    1, 1, 1, 1, 1, 0, 1, 0,     // DDC2,      port 1037, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0      // DDC2,      port 1037, Call 1
                                    };
                                int[] FIVE_DDC_Callid = new int[48]
                                    {
                                    3, 3, 0, 0, 3, 0, 0, 0,     // DDC0+DDC1, port 1035, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0,     // DDC0+DDC1, port 1035, Call 1
                                    0, 0, 0, 0, 0, 1, 0, 1,     // DDC3+DDC4, port 1036, Call 0
                                    0, 0, 0, 0, 0, 2, 0, 2,     // DDC3+DDC4, port 1036, Call 1
                                    1, 1, 1, 1, 1, 0, 1, 0,     // DDC2,      port 1037, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0      // DDC2,      port 1037, Call 1
                                    };
                                int[] FIVE_DDC_nstreams = new int[3]
                                    {
                                    2,                          // DDC0+DDC1, port 1035
                                    2,                          // DDC1+DDC4, port 1036
                                    1                           // DDC2,      port 1037
                                    };
                                fixed (int* pstreams = &FIVE_DDC_nstreams[0], pfunction = &FIVE_DDC_Function[0], pcallid = &FIVE_DDC_Callid[0])
                                    LoadRouterAll((void*)0, 0, 3, 2, 8, pstreams, pfunction, pcallid);
                                break;
                        }
                    }
                    else
                    {
                        switch (model)
                        {
                            case HPSDRModel.ANAN10E:
                            case HPSDRModel.ANAN100B:
                                int[] TWO_DDC_Function = new int[16]
                                    {
                                    2, 2, 2, 2, 2, 2, 2, 2,     // DDC0+DDC1, port 1035, Call 0
                                    0, 0, 0, 0, 0, 2, 0, 2      // DDC0+DDC1, port 1035, Call 1 Sends TX_freq data to both RX //MW0LGE_21d DUP on top panadaptor (Warren provided info)
                                    };
                                int[] TWO_DDC_Callid = new int[16]
                                    {
                                    2, 2, 2, 2, 2, 1, 2, 1,      // DDC0+DDC1, port 1035, Call 0
                                    0, 0, 0, 0, 0, 2, 0, 2      // DDC0+DDC1, port 1035, Call 1 Sends TX_freq data to both RX //MW0LGE_21d DUP on top panadaptor (Warren provided info), // MW0LGE [2.9.0.8] from Warren, change 3's to 2's
                                    };
                                int[] TWO_DDC_nstreams = new int[1]
                                    {
                                    2                           // DDC0+DDC1, port 1035
                                    };
                                fixed (int* pstreams = &TWO_DDC_nstreams[0], pfunction = &TWO_DDC_Function[0], pcallid = &TWO_DDC_Callid[0])
                                    LoadRouterAll((void*)0, 0, 1, /*1*/2, 8, pstreams, pfunction, pcallid); //MW0LGE_21d DUP on top panadaptor (Warren provided info)
                                break;
                            case HPSDRModel.HERMES:
                            case HPSDRModel.HERMESLITE: // MI0BOT: HL2
                            case HPSDRModel.ANAN10:
                            case HPSDRModel.ANAN100:
                                int[] FOUR_DDC_Function = new int[24]
                                    {
                                    1, 1, 1, 1, 1, 1, 1, 1,     // DDC0,      port 1035, Call 0
                                    0, 0, 0, 0, 0, 2, 0, 2,     // DDC2+DDC3, port 1036, Call 0
                                    1, 1, 1, 1, 1, 1, 1, 1      // DDC1,      port 1037, Call 0
                                    };
                                int[] FOUR_DDC_Callid = new int[24]
                                    {
                                    0, 0, 0, 0, 0, 0, 0, 0,     // DDC0,      port 1035, Call 0
                                    0, 0, 0, 0, 0, 1, 0, 1,     // DDC2+DDC3, port 1036, Call 0
                                    1, 1, 1, 1, 1, 1, 1, 1      // DDC1,      port 1037, Call 0
                                    };
                                int[] FOUR_DDC_nstreams = new int[3]
                                    {
                                    1,                          // DDC0,      port 1035
                                    2,                          // DDC2+DDC3, port 1036
                                    1                           // DDC1,      port 1037
                                    };
                                fixed (int* pstreams = &FOUR_DDC_nstreams[0], pfunction = &FOUR_DDC_Function[0], pcallid = &FOUR_DDC_Callid[0])
                                    LoadRouterAll((void*)0, 0, 3, 1, 8, pstreams, pfunction, pcallid);
                                break;
                            case HPSDRModel.ANAN100D:
                            case HPSDRModel.ANAN200D:
                            case HPSDRModel.ORIONMKII:
                            case HPSDRModel.ANAN7000D:
                            case HPSDRModel.ANAN8000D:
                            case HPSDRModel.ANVELINAPRO3:
                                int[] FIVE_DDC_Function = new int[24]
                                    {
                                    2, 2, 2, 2, 2, 2, 2, 2,     // DDC0+DDC1, port 1035, Call 0
                                    0, 0, 0, 0, 0, 2, 0, 2,     // DDC3+DDC4, port 1036, Call 0
                                    1, 1, 1, 1, 1, 1, 1, 1      // DDC2,      port 1037, Call 0
                                    };
                                int[] FIVE_DDC_Callid = new int[24]
                                    {
                                    3, 3, 0, 0, 3, 3, 0, 0,     // DDC0+DDC1, port 1035, Call 0
                                    0, 0, 0, 0, 0, 1, 0, 1,     // DDC3+DDC4, port 1036, Call 0
                                    1, 1, 1, 1, 1, 1, 1, 1      // DDC2,      port 1037, Call 0
                                    };
                                int[] FIVE_DDC_nstreams = new int[3]
                                    {
                                    2,                          // DDC0+DDC1, port 1035
                                    2,                          // DDC3+DDC4, port 1036
                                    1                           // DDC2,      port 1037
                                    };
                                fixed (int* pstreams = &FIVE_DDC_nstreams[0], pfunction = &FIVE_DDC_Function[0], pcallid = &FIVE_DDC_Callid[0])
                                    LoadRouterAll((void*)0, 0, 3, 1, 8, pstreams, pfunction, pcallid);
                                break;
                        }
                    }
                    break;
                case RadioProtocol.ETH:
                    if (ps_loopback)    // for test purposes
                    {
                        switch (model)
                        {
                            case HPSDRModel.ANAN100D:
                            case HPSDRModel.ANAN200D:
                            case HPSDRModel.ORIONMKII:
                            case HPSDRModel.ANAN7000D:
                            case HPSDRModel.ANAN8000D:
                            case HPSDRModel.ANVELINAPRO3:
                            case HPSDRModel.ANAN_G2:
                            case HPSDRModel.ANAN_G2_1K:
                                // This ANGELIA table is for test purposes and it routes DDC0 and DDC1 to RX1 and RX2, 
                                //      respectively, (as well as to PureSignal) when transmitting with PureSignal 
                                //      Enabled in Setup.
                                // control bits are { MOX, Diversity_Enabled, PureSignal_Enabled }
                                int[] Angelia_Function_PSTest = new int[112] 
                                { 
                                    0, 0, 2, 2, 0, 2, 2, 2,     // Rx0, port 1035, Call 0
                                    0, 0, 0, 0, 0, 2, 0, 2,     // Rx0, port 1035, Call 1
                                    0, 0, 0, 0, 0, 0, 0, 0,     // Rx1, port 1036, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0,     // Rx1, port 1036, Call 1
                                    1, 1, 0, 0, 1, 0, 0, 0,     // Rx2, port 1037, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0,     // Rx2, port 1037, Call 1
                                    1, 1, 1, 1, 1, 0, 1, 0,     // Rx3, port 1038, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0,     // Rx3, port 1038, Call 1
                                    1, 1, 1, 1, 1, 1, 1, 1,     // Rx4, port 1039, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0,     // Rx4, port 1039, Call 1
                                    1, 1, 1, 1, 1, 1, 1, 1,     // Rx5, port 1040, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0,     // Rx5, port 1040, Call 1
                                    1, 1, 1, 1, 1, 1, 1, 1,     // Rx6, port 1041, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0      // Rx6, port 1041, Call 1
                                };
                                int[] Angelia_Callid_PSTest = new int[112]
                                {
                                    0, 0, 0, 0, 0, 1, 0, 1,     // Rx0, port 1035, Call 0
                                    0, 0, 0, 0, 0, 2, 0, 2,     // Rx0, port 1035, Call 1
                                    0, 0, 0, 0, 0, 0, 0, 0,     // Rx1, port 1036, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0,     // Rx1, port 1036, Call 1
                                    0, 0, 0, 0, 0, 0, 0, 0,     // Rx2, port 1037, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0,     // Rx2, port 1037, Call 1
                                    1, 1, 1, 1, 1, 1, 1, 1,     // Rx3, port 1038, Call 0
                                    1, 1, 1, 1, 1, 1, 1, 1,     // Rx3, port 1038, Call 1
                                    2, 2, 2, 2, 2, 2, 2, 2,     // Rx4, port 1039, Call 0
                                    2, 2, 2, 2, 2, 2, 2, 2,     // Rx4, port 1039, Call 1
                                    3, 3, 3, 3, 3, 3, 3, 3,     // Rx5, port 1040, Call 0
                                    3, 3, 3, 3, 3, 3, 3, 3,     // Rx5, port 1040, Call 1
                                    4, 4, 4, 4, 4, 4, 4, 4,     // Rx6, port 1041, Call 0
                                    4, 4, 4, 4, 4, 4, 4, 4      // Rx6, port 1041, Call 1
                                };
                                int[] Angelia_nstreams_PSTest = new int[7]
                                {
                                    2,                          // Rx0, port 1035
                                    1,                          // Rx1, port 1036
                                    1,                          // Rx2, port 1037
                                    1,                          // Rx3, port 1038
                                    1,                          // Rx4, port 1039
                                    1,                          // Rx5, port 1040
                                    1                           // Rx6, port 1041
                                };
                                fixed (int* pstreams = &Angelia_nstreams_PSTest[0], pfunction = &Angelia_Function_PSTest[0], pcallid = &Angelia_Callid_PSTest[0])
                                    LoadRouterAll((void*)0, 0, 7, 2, 8, pstreams, pfunction, pcallid);
                                break;

                            case HPSDRModel.HERMES:
                            case HPSDRModel.HERMESLITE: // MI0BOT: HL2
                            case HPSDRModel.ANAN10:
                            case HPSDRModel.ANAN100:
                            case HPSDRModel.ANAN10E:
                            case HPSDRModel.ANAN100B:
                                int[] HermesE_Function = new int[32]
                                {
                                    1, 1, 2, 2, 1, 2, 2, 2,     // Rx0, port 1035, Call 0
                                    0, 0, 0, 0, 0, 2, 0, 2,     // Rx0, port 1035, Call 1
                                    1, 1, 0, 0, 1, 0, 0, 0,     // Rx1, port 1036, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0      // Rx1, port 1036, Call 1
                                };
                                int[] HermesE_Callid = new int[32]
                                {
                                    0, 0, 0, 0, 0, 1, 0, 1,     // Rx0, port 1035, Call 0
                                    0, 0, 0, 0, 0, 2, 0, 2,     // Rx0, port 1035, Call 1
                                    1, 1, 1, 1, 1, 1, 1, 1,     // Rx1, port 1036, Call 0
                                    1, 1, 1, 1, 1, 1, 1, 1      // Rx1, port 1036, Call 1
                                };
                                int[] HermesE_nstreams = new int[2]
                                {
                                    2,                          // Rx0, port 1035
                                    1                           // Rx1, port 1036
                                };
                                fixed (int* pstreams = &HermesE_nstreams[0], pfunction = &HermesE_Function[0], pcallid = &HermesE_Callid[0])
                                    LoadRouterAll((void*)0, 0, 2, 2, 8, pstreams, pfunction, pcallid);
                                break;
                        }
                    }
                    else
                    {
                        switch (model)
                        {
                            case HPSDRModel.ANAN100D:
                            case HPSDRModel.ANAN200D:
                            case HPSDRModel.ORIONMKII:
                            case HPSDRModel.ANAN7000D:
                            case HPSDRModel.ANAN8000D:
                            case HPSDRModel.ANVELINAPRO3:
                            case HPSDRModel.ANAN_G2:
                            case HPSDRModel.ANAN_G2_1K:
                                // control bits are { MOX, Diversity_Enabled, PureSignal_Enabled }
                                int[] Angelia_Function = new int[56] 
                                { 
                                    0, 0, 2, 2, 0, 2, 2, 2,     // Rx0, port 1035
                                    0, 0, 0, 0, 0, 0, 0, 0,     // Rx1, port 1036
                                    1, 1, 0, 0, 1, 1, 0, 1,     // Rx2, port 1037
                                    1, 1, 1, 1, 1, 1, 1, 1,     // Rx3, port 1038
                                    1, 1, 1, 1, 1, 1, 1, 1,     // Rx4, port 1039
                                    1, 1, 1, 1, 1, 1, 1, 1,     // Rx5, port 1040
                                    1, 1, 1, 1, 1, 1, 1, 1      // Rx6, port 1041
                                };
                                int[] Angelia_Callid = new int[56]
                                {
                                    0, 0, 0, 0, 0, 1, 0, 1,     // Rx0, port 1035
                                    0, 0, 0, 0, 0, 0, 0, 0,     // Rx1, port 1036
                                    0, 0, 0, 0, 0, 0, 0, 0,     // Rx2, port 1037
                                    1, 1, 1, 1, 1, 1, 1, 1,     // Rx3, port 1038
                                    2, 2, 2, 2, 2, 2, 2, 2,     // Rx4, port 1039
                                    3, 3, 3, 3, 3, 3, 3, 3,     // Rx5, port 1040
                                    4, 4, 4, 4, 4, 4, 4, 4      // Rx6, port 1041
                                };
                                int[] Angelia_nstreams = new int[7]
                                {
                                    2,                          // Rx0, port 1035
                                    1,                          // Rx1, port 1036
                                    1,                          // Rx2, port 1037
                                    1,                          // Rx3, port 1038
                                    1,                          // Rx4, port 1039
                                    1,                          // Rx5, port 1040
                                    1                           // Rx6, port 1041
                                };
                                fixed (int* pstreams = &Angelia_nstreams[0], pfunction = &Angelia_Function[0], pcallid = &Angelia_Callid[0])
                                    LoadRouterAll((void*)0, 0, 7, 1, 8, pstreams, pfunction, pcallid);
                                break;

                            case HPSDRModel.HERMES:
                            case HPSDRModel.HERMESLITE: // MI0BOT: HL2
                            case HPSDRModel.ANAN10:
                            case HPSDRModel.ANAN100:
                            case HPSDRModel.ANAN10E:
                            case HPSDRModel.ANAN100B:
                                int[] HermesE_Function = new int[32]
                                {
                                    1, 1, 2, 2, 1, 2, 2, 2,     // Rx0, port 1035, Call 0
                                    0, 0, 0, 0, 0, 2, 0, 2,     // Rx0, port 1035, Call 1
                                    1, 1, 0, 0, 1, 0, 0, 0,     // Rx1, port 1036, Call 0
                                    0, 0, 0, 0, 0, 0, 0, 0      // Rx1, port 1036, Call 1
                                };
                                int[] HermesE_Callid = new int[32]
                                {
                                    0, 0, 0, 0, 0, 1, 0, 1,     // Rx0, port 1035, Call 0
                                    0, 0, 0, 0, 0, 3, 0, 3,     // Rx0, port 1035, Call 1
                                    1, 1, 1, 1, 1, 1, 1, 1,     // Rx1, port 1036, Call 0
                                    1, 1, 1, 1, 1, 1, 1, 1      // Rx1, port 1036, Call 1
                                };
                                int[] HermesE_nstreams = new int[2]
                                {
                                    2,                          // Rx0, port 1035
                                    1                           // Rx1, port 1036
                                };
                                fixed (int* pstreams = &HermesE_nstreams[0], pfunction = &HermesE_Function[0], pcallid = &HermesE_Callid[0])
                                    LoadRouterAll((void*)0, 0, 2, 2, 8, pstreams, pfunction, pcallid);
                                break;
                            case HPSDRModel.HPSDR:

                                break;
                        }
                    }
                    break;
            }
        }
        
        public static void CMSetAntiVoxSourceWhat()
        {
            bool VACEn = Audio.console.VACEnabled;
            bool VAC2En = Audio.console.VAC2Enabled;
            bool useVAC = Audio.AntiVOXSourceVAC;
            int RX1 = WDSP.id(0, 0);
            int RX1S = WDSP.id(0, 1);
            int RX2 = WDSP.id(2, 0);
            if (useVAC)   // use VAC audio
            {
                if (VACEn)
                {
                    cmaster.SetAntiVOXSourceWhat(0, RX1,  1);
                    cmaster.SetAntiVOXSourceWhat(0, RX1S, 1);
                }
                else
                {
                    cmaster.SetAntiVOXSourceWhat(0, RX1,  0);
                    cmaster.SetAntiVOXSourceWhat(0, RX1S, 0);
                }
                if (VAC2En)
                    cmaster.SetAntiVOXSourceWhat(0, RX2,  1);
                else
                    cmaster.SetAntiVOXSourceWhat(0, RX2,  0);
            }
            else         // use audio going to hardware minus MON
            {
                cmaster.SetAntiVOXSourceWhat(0, RX1,  1);
                cmaster.SetAntiVOXSourceWhat(0, RX1S, 1);
                cmaster.SetAntiVOXSourceWhat(0, RX2,  1);
            }
        }
        
        public static void CMSetAudioVolume(double volume)
        {
            cmaster.SetAAudioMixVolume((void*)0, 0, volume);
        }

        public static void CMSetFRXNBRun(int id)
        {
            bool run = false;
            switch (id)
            {
                case 0:
                    run = Audio.console.specRX.GetSpecRX(0).NBOn;
                    cmaster.SetRCVRANBRun (0, 0, run);
                    break;
                case 1:
                    run =  Audio.console.specRX.GetSpecRX(1).NBOn
                        && Audio.console.RX2Enabled;
                    cmaster.SetRCVRANBRun (0, 1, run);
                    break;
            }
        }

        public static void CMSetFRXNB2Run(int id)
        {
            bool run = false;
            switch (id)
            {
                case 0:
                    run = Audio.console.specRX.GetSpecRX(0).NB2On;
                    cmaster.SetRCVRNOBRun(0, 0, run);
                    break;
                case 1:
                    run =  Audio.console.specRX.GetSpecRX(1).NB2On
                        && Audio.console.RX2Enabled;
                    cmaster.SetRCVRNOBRun(0, 1, run);
                    break;
            }
        }

        public static void CMSetSRXWavePlayRun(int id)
        {
            bool run = false;
            switch (id)
            {
                case 0:
                    run =  Audio.WavePlayback
                        && WaveThing.wave_file_reader[0] != null;
                    break;
                case 1:
                    run =  Audio.WavePlayback
                        && WaveThing.wave_file_reader[1] != null
                        && Audio.console.RX2Enabled;
                    break;
            }
            WaveThing.SetWavePlayerRun(id, run ? 1 : 0); //[2.10.3.4]MW0LGE
            WaveThing.wplayer[id].Run = run;
        }

        public static void CMSetSRXWaveRecordRun(int id)
        {
            bool run = false;
            switch (id)
            {
                case 0:
                    run =  Audio.WaveRecord
                        && WaveThing.wave_file_writer[0] != null;
                    if (run) WaveThing.wave_file_writer[0].RecordGain = (float)Audio.console.radio.GetDSPRX(0, 0).RXOutputGain; //[2.10.3.5]MW0LGE
                    break;
                case 1:
                    run = Audio.WaveRecord
                        && WaveThing.wave_file_writer[1] != null
                        && Audio.console.RX2Enabled;
                    if (run) WaveThing.wave_file_writer[1].RecordGain = (float)Audio.console.radio.GetDSPRX(1, 0).RXOutputGain; //[2.10.3.5]MW0LGE
                    break;
            }
            WaveThing.SetWaveRecorderRun(id, run ? 1 : 0); //[2.10.3.4]MW0LGE
            WaveThing.wrecorder[id].Run = run;
        }

        public static void CMSetEERRun(int id)
        {
            bool run = Audio.console.radio.GetDSPTX(0).TXEERModeRun;
            if (run && mox)
            {
                cmaster.SetEERRun(id, true);
                NetworkIO.EnableEClassModulation(1);
            }
            else
            {
                cmaster.SetEERRun(id, false);
                NetworkIO.EnableEClassModulation(0);
            }
        }

        public static void CMSetTXAVoxRun(int id)
        {
            DSPMode mode = Audio.TXDSPMode;
            bool run = Audio.VOXEnabled &&
                    (mode == DSPMode.LSB ||
                    mode == DSPMode.USB ||
                    mode == DSPMode.DSB ||
                    mode == DSPMode.AM ||
                    mode == DSPMode.SAM ||
                    mode == DSPMode.FM ||
                    mode == DSPMode.DIGL ||
                    mode == DSPMode.DIGU);
            cmaster.SetDEXPRunVox(id, run);
        }

        public static void CMSetTXAVoxThresh(int id, double thresh)
        {
            //double thresh = (double)Audio.VOXThreshold;
            if (Audio.console.MicBoost) thresh *= (double)Audio.VOXGain;
            cmaster.SetDEXPAttackThreshold(id, thresh);
        }

        public static void CMSetTXAPanelGain1(int channel)
        {
            double gain = 1.0;
            DSPMode mode = Audio.TXDSPMode;
            if ((!Audio.VACEnabled &&
                 (mode == DSPMode.LSB ||
                  mode == DSPMode.USB ||
                  mode == DSPMode.DSB ||
                  mode == DSPMode.AM ||
                  mode == DSPMode.SAM ||
                  mode == DSPMode.FM ||
                  mode == DSPMode.DIGL ||
                  mode == DSPMode.DIGU)) ||
                (Audio.VACEnabled && Audio.VACBypass &&
                 (mode == DSPMode.DIGL ||
                  mode == DSPMode.DIGU ||
                  mode == DSPMode.LSB ||
                  mode == DSPMode.USB ||
                  mode == DSPMode.DSB ||
                  mode == DSPMode.AM ||
                  mode == DSPMode.SAM ||
                  mode == DSPMode.FM)))
            {
                if (Audio.WavePlayback)
                    gain = Audio.WavePreamp;
                else
                {
                    if (!Audio.VACEnabled && (mode == DSPMode.DIGL || mode == DSPMode.DIGU))
                        gain = Audio.VACPreamp;
                    else
                        gain = Audio.MicPreamp;
                }
            }
            Audio.console.radio.GetDSPTX(0).MicGain = gain;
        }

        public static void CMSetScopeRun(int id, bool run)
        {
            Scope.SetScopeRun(id, run ? 1 : 0); //[2.10.3.4]MW0LGE run on/off
            Scope.dscope[id].Run = run;
        }

        public static void CMSetTXOutputLevelRun()
        {
            bool run = false; // /* Audio.console.CurrentModel != Model.HERMES && */ !Audio.console.PennyLanePresent;
            cmaster.SetTXFixedGainRun(0, run);
        }

        public static void CMSetTXOutputLevel()
        {
            double level = Audio.RadioVolume * Audio.HighSWRScale;
            cmaster.SetTXFixedGain(0, level, level);
        }
        #endregion

        #region callbacks

        
        unsafe public static void SendCallbacks()
        {
            SendCBPushVox(0, PushVoxDel);
            WaveThing.initWaves();
            Scope.initScope();
        }

        // vox
        // declare a delegate that is of the same form as the function which it is to encapsulate
        unsafe public delegate void PushVox(int channel, int active);
        // assign the function 'VOX.PushVox' to an instance of the delegate 'PushVox'
        unsafe private static PushVox PushVoxDel = VOX.PushVox;
        // set-up a method definition to send the function pointer to the dll
        [DllImport("ChannelMaster.dll", EntryPoint = "SendCBPushVox", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void SendCBPushVox(int id, PushVox Del);

        #endregion

        #region rxa

        //private static bool EXPOSE = false; 
        private static bool EXPOSEwb = true;
        //private const int nrxa = 8;
        //private static rxa[] rxa = new rxa[nrxa];
        private static wideband[] wideband = new wideband[3];

        //private static void create_rxa()
        //{
        //    if (EXPOSE)
        //    {
        //        for (int i = 4; i < 7; i++)
        //        {
        //            rxa[i] = new rxa(i);
        //            rxa[i].Show();
        //        }
        //    }
        //}

        //public static void close_rxa()
        //{
        //    for (int i = 4; i < 7; i++)
        //    {
        //        if (rxa[i] != null)
        //            rxa[i].Close();
        //    }
        //}

        //public static rxa Getrxa(int rx)
        //{
        //    return rxa[rx];
        //}

        #endregion

        #region wideband

        private static void create_wb(int adc)
        {
            if (EXPOSEwb)
            {
                //wideband = new wideband[3];
                wideband[adc] = new wideband(adc);
               // wideband[0].Show();
            }

        }

        public static wideband Getwb(int adc)
        {
            if (wideband[adc] == null || wideband[adc].IsDisposed)
                create_wb(adc);
            wideband[adc].Show();

            if (wideband[adc].WindowState == FormWindowState.Minimized) wideband[adc].WindowState = FormWindowState.Normal; //MW0LGE

            return wideband[adc];
        }

        public static void Hidewb(int adc)
        {
            if (wideband[adc] != null)
            wideband[adc].Hide();           
        }

        public static void Closewb(int adc)
        {
            if (wideband[adc] != null)
                wideband[adc].Close();
        }

        public static void Savewb(int adc)
        {
            if (wideband[adc] != null)
                wideband[adc].SaveWideBand();
        }

        #endregion

    }

    #region VOX

    unsafe static class VOX
    {
        unsafe public static void PushVox(int id, int active)
        {
            Audio.VOXActive = (active == 1);
        }
    }
#endregion

    #region WaveThing

    unsafe static class WaveThing
    {
        #region createStuff

        // declare a delegate of the correct form for the createWavePlayer method
        unsafe public delegate void createWplay(int id);

        // assign the function to an instance of the delegate
        unsafe private static createWplay cwpDel = createWavePlayer;

        // define the method to send the createWavePlayer function pointer
        [DllImport("ChannelMaster.dll", EntryPoint = "SendCBCreateWPlay", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void SendCBCreateWPlay(createWplay del);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetWavePlayerRun", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void SetWavePlayerRun(int id, int run);

        unsafe public delegate void createWrecord(int id);
        unsafe private static createWrecord cwrDel = createWaveRecorder;

        [DllImport("ChannelMaster.dll", EntryPoint = "SendCBCreateWRecord", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void SendCBCreateWRecord(createWrecord del);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetWaveRecorderRun", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void SetWaveRecorderRun(int id, int run);

        unsafe public static void initWaves()
        {
            // send pointer to createWavePlayer function
            SendCBCreateWPlay(cwpDel);
            SendCBCreateWRecord(cwrDel);
        }

        #endregion

        #region playerStuff

        // declare a delegate of the correct form for the player method
        unsafe public delegate void WPlay(int state, double* data);

        // define the method to send the player function pointer
        [DllImport("ChannelMaster.dll", EntryPoint = "SendCBWavePlayer", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void SendCBWavePlayer(int id, WPlay del);

        // maximum number of wave players
        const int nplayers = 16;
        // initialize an array for the waveplayers
        public static PlayWave[] wplayer = new PlayWave[nplayers];
        // initialize an array for pointers to the wave player method instances
        static WPlay[] pplay = new WPlay[nplayers];
        // initialize an array for the wave_file_readers
        public static WaveFileReader1[] wave_file_reader = new WaveFileReader1[nplayers];

        unsafe public static void createWavePlayer(int id)
        {
            // create a wave player instance
            wplayer[id] = new PlayWave();
            // store the pointer to the wave player instance
            pplay[id] = new WPlay(wplayer[id].wplay);
            // send the pointer over to the C code
            SendCBWavePlayer(id, pplay[id]);
            // tell the waveplayer its ID
            wplayer[id].ID = id;
            // NOTE:  the wave_file_reader instance gets created in OpenWaveFile(filename, id)
        }

        #endregion

        #region recorderStuff

        unsafe public delegate void WRecord(int state, int pos, double* data);

        [DllImport("ChannelMaster", EntryPoint = "SendCBWaveRecorder", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void SendCBWaveRecorder(int id, WRecord del);

        const int nrecorders = 16;
        public static RecordWave[] wrecorder = new RecordWave[nrecorders];
        static WRecord[] precord = new WRecord[nrecorders];
        public static WaveFileWriter[] wave_file_writer = new WaveFileWriter[nrecorders];

        unsafe public static void createWaveRecorder(int id)
        {
            wrecorder[id] = new RecordWave();
            precord[id] = new WRecord(wrecorder[id].wrecord);
            SendCBWaveRecorder(id, precord[id]);
            wrecorder[id].ID = id;
        }
        #endregion
    }

    #region PlayWave Class

    unsafe class PlayWave
    {
        private int id = 0;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private bool run = false;
        public bool Run
        {
            get { return run; }
            set { run = value; }
        }

        private int condx = 0;
        public int Condx
        {
            get { return condx; }
            set { condx = value; }
        }

        int busy = 0;

        float[] left = new float[2048];
        float[] right = new float[2048];

        unsafe public void wplay(int state, double* data)
        {
            if (run && (condx == state))
            {
                if (System.Threading.Interlocked.Exchange(ref busy, 1) != 1)
                {
                    int size = 2048;    // could check actual size, depending upon MOX
                    fixed (float* pleft = &left[0])
                    fixed (float* pright = &right[0])
                    {
                        WaveThing.wave_file_reader[id].GetPlayBuffer(pleft, pright);
                        swizzle(size, pleft, pright, data);
                    }
                    System.Threading.Interlocked.Exchange(ref busy, 0);
                }
            }
        }

        unsafe private static void swizzle(int n, float* I, float* Q, double* C)
        {
            int i;
            for (i = 0; i < n; i++)
            {
                C[2 * i + 0] = (double)I[i];
                C[2 * i + 1] = (double)Q[i];
            }
        }
    }

    #endregion

    #region RecordWave Class

    unsafe class RecordWave
    {
        private int id = 0;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private bool run = false;
        public bool Run
        {
            get { return run; }
            set { run = value; }
        }

        private int condx = 0;
        public int Condx
        {
            get { return condx; }
            set { condx = value; }
        }

        private bool rxpre = false;
        public bool RxPre
        {
            get { return rxpre; }
            set { rxpre = value; }
        }

        private bool txpre = true;
        public bool TxPre
        {
            get { return txpre; }
            set { txpre = value; }
        }

        int busy = 0;

        float[] left = new float[2048];
        float[] right = new float[2048];
        float[] ltemp = new float[2048];
        float[] rtemp = new float[2048];
        // 'wrecord()' is called by ChannelMaster.dll
        unsafe public void wrecord(int state, int pos, double* data)
        {
            if (run && (condx == state))    // if run && (!MOX and calling with receive data, or, MOX and calling with transmit data)
            {
                if (System.Threading.Interlocked.Exchange(ref busy, 1) != 1)
                {
                    fixed (float* pleft  = &left[0], pright = &right[0], pltemp = &ltemp[0], prtemp = &rtemp[0])
                    {
                        if (pos == 0)   // calling from the "pre" location
                        {
                            if ((state == 0) && rxpre)  // getting receive data and want receive data for 'pre' position
                            {
                                int rcvr_inrate = cmaster.GetInputRate(0, id);  // could just read these from WaveThing.wave_file_writer[id]
                                int rcvr_insize = cmaster.GetBuffSize(rcvr_inrate);
                                deswizzle(rcvr_insize, data, pleft, pright);
                                if (WaveThing.wave_file_writer[id].BaseRate != rcvr_inrate)
                                {
                                    int outsamps;
                                    WDSP.xresampleFV(pleft,  pltemp, rcvr_insize, &outsamps, WaveThing.wave_file_writer[id].RcvrResampL);
                                    WDSP.xresampleFV(pright, prtemp, rcvr_insize, &outsamps, WaveThing.wave_file_writer[id].RcvrResampR);
                                    WaveThing.wave_file_writer[id].AddWriteBuffer(pltemp, prtemp, outsamps);
                                }
                                else
                                    WaveThing.wave_file_writer[id].AddWriteBuffer(pleft, pright, rcvr_insize);
                            }
                            if ((state == 1) && txpre)  // getting transmit data and want transmit data for 'pre' position
                            {
                                int xmtr_inrate = cmaster.GetInputRate(1, 0);
                                int xmtr_insize = cmaster.GetBuffSize(xmtr_inrate);
                                deswizzle(xmtr_insize, data, pleft, pright);
                                if (WaveThing.wave_file_writer[id].BaseRate != xmtr_inrate)
                                {
                                    int outsamps;
                                    WDSP.xresampleFV(pleft,  pltemp, xmtr_insize, &outsamps, WaveThing.wave_file_writer[id].XmtrResampL);
                                    WDSP.xresampleFV(pright, prtemp, xmtr_insize, &outsamps, WaveThing.wave_file_writer[id].XmtrResampR);
                                    WaveThing.wave_file_writer[id].AddWriteBuffer(pltemp, prtemp, outsamps);
                                }
                                else
                                    WaveThing.wave_file_writer[id].AddWriteBuffer(pleft, pright, xmtr_insize);
                            }
                        }
                        if (pos == 1)   // calling from "post" location
                        {
                            if ((state == 0) && !rxpre) // getting receive data and want receive data for 'post' position
                            {
                                int rcvr_outrate = cmaster.GetChannelOutputRate(0, id);
                                int rcvr_outsize = cmaster.GetBuffSize(rcvr_outrate);
                                deswizzle(rcvr_outsize, data, pleft, pright);
                                if (WaveThing.wave_file_writer[id].BaseRate != rcvr_outrate)
                                {
                                    int outsamps;
                                    WDSP.xresampleFV(pleft,  pltemp, rcvr_outsize, &outsamps, WaveThing.wave_file_writer[id].RcvrResampL);
                                    WDSP.xresampleFV(pright, prtemp, rcvr_outsize, &outsamps, WaveThing.wave_file_writer[id].RcvrResampR);
                                    WaveThing.wave_file_writer[id].AddWriteBuffer(pltemp, prtemp, outsamps);
                                }
                                else
                                    WaveThing.wave_file_writer[id].AddWriteBuffer(pleft, pright, rcvr_outsize);
                            }
                            if ((state == 1) && !txpre) // getting transmit data and want transmit data for 'post' position
                            {
                                int xmtr_outrate = cmaster.GetChannelOutputRate(1, 0);
                                int xmtr_outsize = cmaster.GetBuffSize(xmtr_outrate);
                                deswizzle(xmtr_outsize, data, pleft, pright);
                                if (WaveThing.wave_file_writer[id].BaseRate != xmtr_outrate)
                                {
                                    int outsamps;
                                    WDSP.xresampleFV(pleft,  pltemp, xmtr_outsize, &outsamps, WaveThing.wave_file_writer[id].XmtrResampL);
                                    WDSP.xresampleFV(pright, prtemp, xmtr_outsize, &outsamps, WaveThing.wave_file_writer[id].XmtrResampR);
                                    WaveThing.wave_file_writer[id].AddWriteBuffer(pltemp, prtemp, outsamps);
                                }
                                else
                                    WaveThing.wave_file_writer[id].AddWriteBuffer(pleft, pright, xmtr_outsize);
                            }
                        }
                    }
                    System.Threading.Interlocked.Exchange(ref busy, 0);
                }
            }
        }

        unsafe private static void deswizzle(int n, double* C, float* I, float* Q)
        {
            int i;
            for (i = 0; i < n; i++)
            {
                I[i] = (float)C[2 * i + 0];
                Q[i] = (float)C[2 * i + 1];
            }
        }
    }

    #endregion

    #endregion

    #region Scope

    unsafe static class Scope
    {
        unsafe public delegate void createscope(int id);
        unsafe private static createscope cscDel = createScope;

        [DllImport("ChannelMaster.dll", EntryPoint = "SendCBCreateScope", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void SendCBCreateScope(createscope del);
        
        unsafe public delegate void Xscope(int state, double* data);

        [DllImport("ChannelMaster.dll", EntryPoint = "SendCBScope", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void SendCBScope(int id, Xscope del);

        [DllImport("ChannelMaster.dll", EntryPoint = "SetScopeRun", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void SetScopeRun(int id, int run);

        const int nscopes = 16;
        public static DoScope[] dscope = new DoScope[nscopes];
        static Xscope[] pscope = new Xscope[nscopes];
        
        unsafe public static void createScope(int id)
        {
            dscope[id] = new DoScope();
            pscope[id] = new Xscope(dscope[id].xscope);
            SendCBScope(id, pscope[id]);
            // Note:  This is set up to handle multiple scopes.  However, at present
            // there is only one instance of DoScope() and DoScope2().
        }

        unsafe public static void initScope()
        {
            SendCBCreateScope(cscDel);
        }
    }

    unsafe class DoScope
    {
        float[] left = new float[2048];
        float[] right = new float[2048];
        
        int busy = 0;

        private bool run = false;
        public bool Run
        {
            get { return run; }
            set { run = value; }
        }

        private int condx = 0;
        public int Condx
        {
            get { return condx; }
            set { condx = value; }
        }

        unsafe public void xscope(int state, double* data)
        {
            if (run && (condx == state))
            {
                if (System.Threading.Interlocked.Exchange(ref busy, 1) != 1)
                {
                    int size = Audio.MOX ? Audio.OutCountTX : Audio.OutCount; //[2.10.3.4]MW0LGE use OutCountTX if moxing
                    fixed (float* pleft = &left[0])
                    fixed (float* pright = &right[0])
                    {
                        deswizzle(size, data, pleft, pright);
                        Audio.DoScope(pleft, size);
                        Audio.DoScope2(pright, size);
                    }
                    System.Threading.Interlocked.Exchange(ref busy, 0);
                }
            }
        }

        unsafe private static void deswizzle(int n, double* C, float* I, float* Q)
        {
            int i;
            for (i = 0; i < n; i++)
            {
                I[i] = (float)C[2 * i + 0];
                Q[i] = (float)C[2 * i + 1];
            }
        }
    }

#endregion

}