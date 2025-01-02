/*  Midi2Cat

Description: A subsystem that facilitates mapping Windows MIDI devices to CAT commands.
 
Copyright (C) 2016 Andrew Mansfield, M0YGG

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

The author can be reached by email at:  midi2cat@cametrix.com

Modifications to support the Behringer CMD PL-1 controller
by Chris Codella, W2PA, Feb 2017.  Indicated by //-W2PA comment lines.

*/

using Midi2Cat.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thetis; 

namespace Midi2Cat.Data
{
    public static class CatCmdDb
    {
        public static CatCommandAttribute Get(CatCmd Id)
        {
            var type = typeof(CatCmd);
            var memInfo = type.GetMember(Id.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(CatCommandAttribute), false);
            var CatCommand = ((CatCommandAttribute)attributes[0]);
            CatCommand.CatCommandId = Id;
            return CatCommand;
        }       
    }
    
    public enum CatCmd
    {        
        [CatCommandAttribute("Not Mapped", ControlType.Unknown)]
        None = 0,
        [CatCommandAttribute("VfoA To B", ControlType.Button)]
        VfoAtoB = 01,
        [CatCommandAttribute("VfoB To A", ControlType.Button)]
        VfoBtoA = 02,
        [CatCommandAttribute("Vfo Swap", ControlType.Button)]
        VfoSwap = 03,
        [CatCommandAttribute("Split On Off", ControlType.Button,true)]  
        SplitOnOff = 04,
        [CatCommandAttribute("Zero Beat", ControlType.Button)]
        ZeroBeatPress = 05,
        [CatCommandAttribute("Rit On Off", ControlType.Button, true)]  
        RitOnOff = 06,
        [CatCommandAttribute("Xit On Off", ControlType.Button, true)]  
        XitOnOff = 07,
        [CatCommandAttribute("RIT Clear", ControlType.Button)]
        RIT_clear = 08,
        [CatCommandAttribute("XIT Clear", ControlType.Button)]
        XIT_clear = 09,
        [CatCommandAttribute("Multi Rx On Off", ControlType.Button, true)]  
        MultiRxOnOff = 10,
        [CatCommandAttribute("Vfo Sync On Off", ControlType.Button, true)]  
        VfoSyncOnOff = 11,
        [CatCommandAttribute("Toggle VFO Lock - A,both,off", ControlType.Button, true)]
        LockVFOOnOff = 12,
        [CatCommandAttribute("MOX On Off", ControlType.Button, true)]
        MOXOnOff = 13,
        [CatCommandAttribute("VOX On Off", ControlType.Button, true)]  
        VOXOnOff = 14,
        [CatCommandAttribute("Mute On Off", ControlType.Button, true)]  
        MuteOnOff = 15,
        [CatCommandAttribute("Rx1 Noise Blanker1 On Off", ControlType.Button, true)]  
        Rx1NoiseBlanker1OnOff = 16,
        [CatCommandAttribute("Rx1 Noise Blanker2 On Off", ControlType.Button, true)]  
        Rx1Noiseblanker2OnOff = 17,
        [CatCommandAttribute("Auto Notch On Off", ControlType.Button, true)]  
        AutoNotchOnOff = 18,
        [CatCommandAttribute("Noise Reduction 1 On Off", ControlType.Button, true)]  
        NoiseReductionOnOff = 19,
        [CatCommandAttribute("Noise Reduction 2 On Off", ControlType.Button, true)]  
        NoiseReduction2OnOff = 20,  //-W2PA Renamed function to reflect actual meaning
        [CatCommandAttribute("Binaural On Off", ControlType.Button, true)]  
        BinauralOnOff = 21,
        [CatCommandAttribute("Rx1 Filter Wider", ControlType.Button)]
        Rx1FilterWider = 22,
        [CatCommandAttribute("Rx1 Filter Narrower", ControlType.Button)]
        Rx1FilterNarrower = 23,
        [CatCommandAttribute("Rx1 Mode Next", ControlType.Button)]
        Rx1ModeNext = 24,
        [CatCommandAttribute("Rx1 Mode Prev", ControlType.Button)]
        Rx1ModePrev = 25,
        [CatCommandAttribute("Tuning Step Up", ControlType.Button)]
        TuningStepUp = 26,
        [CatCommandAttribute("Tuning Step Down", ControlType.Button)]
        TuningStepDown = 27,
        [CatCommandAttribute("Band Up", ControlType.Button)]
        BandUp = 28,
        [CatCommandAttribute("Band Down", ControlType.Button)]
        BandDown = 29,
        [CatCommandAttribute("Start On Off", ControlType.Button, true)]  
        StartOnOff = 30,
        [CatCommandAttribute("Tuner On Off", ControlType.Button, true)]  
        TunerOnOff = 31,
        [CatCommandAttribute("Compander On Off", ControlType.Button, true)]  
        CompanderOnOff = 32,
        [CatCommandAttribute("Stereo Diversity On Off", ControlType.Button, true)]
        StereoDiversityOnOff = 33,
        [CatCommandAttribute("DEXP On Off", ControlType.Button, true)]  
        DEXPOnOff = 34,
        [CatCommandAttribute("RX2 On Off", ControlType.Button, true)]  
        RX2OnOff = 35,
        [CatCommandAttribute("Rx2 Pre Amp On Off", ControlType.Button, true)]  
        Rx2PreAmpOnOff = 36,
        [CatCommandAttribute("Rx2 Noise Blanker1 On Off", ControlType.Button, true)]  
        Rx2NoiseBlanker1OnOff = 37,
        [CatCommandAttribute("Rx2 Noise Blanker2 On Off", ControlType.Button, true)]
        Rx2Noiseblanker2OnOff = 38,
        [CatCommandAttribute("Rx2 Band Up", ControlType.Button)]
        Rx2BandUp = 39,
        [CatCommandAttribute("Rx2 Band Down", ControlType.Button)]
        Rx2BandDown = 40,
        [CatCommandAttribute("RX EQ On Off", ControlType.Button, true)]  
        RXEQOnOff = 41,
        [CatCommandAttribute("TX EQ On Off", ControlType.Button, true)]  
        TXEQOnOff = 42,
        [CatCommandAttribute("Squelch On Off", ControlType.Button, true)]
        SquelchOnOff = 43,
        [CatCommandAttribute("Spectral Noise Blanker On Off", ControlType.Button, true)]
        SpectralNoiseBlankerOnOff = 44,
        [CatCommandAttribute("AGC Mode Up", ControlType.Button)]
        AGCModeUp = 45,
        [CatCommandAttribute("AGC Mode Down", ControlType.Button)]
        AGCModeDown = 46,
        [CatCommandAttribute("Rx2 Spectral Noise Blanker On Off", ControlType.Button, true)]  
        SpectralNoiseBlankerRx2OnOff = 47,
        [CatCommandAttribute("Display Average", ControlType.Button)]
        DisplayAverage = 48,
        [CatCommandAttribute("Display Peak", ControlType.Button)]
        DisplayPeak = 49,
        [CatCommandAttribute("Display Tx Filter", ControlType.Button)]
        DisplayTxFilter = 50,
        [CatCommandAttribute("Display Mode Next", ControlType.Button)]
        DisplayModeNext = 51,
        [CatCommandAttribute("Display Mode Prev", ControlType.Button)]
        DisplayModePrev = 52,
        [CatCommandAttribute("Zoom Inc", ControlType.Button)]
        ZoomInc = 53,
        [CatCommandAttribute("Zoom Dec", ControlType.Button)]
        ZoomDec = 54,
        [CatCommandAttribute("Quick Mode Save", ControlType.Button)]
        QuickModeSave = 55,
        [CatCommandAttribute("Quick Mode Restore", ControlType.Button)]
        QuickModeRestore = 56,
        [CatCommandAttribute("CW XMacro 1", ControlType.Button)]
        CWXMacro1 = 57,
        [CatCommandAttribute("CWX Macro 2", ControlType.Button)]
        CWXMacro2 = 58,
        [CatCommandAttribute("CWX Macro 3", ControlType.Button)]
        CWXMacro3 = 59,
        [CatCommandAttribute("CWX Macro 4", ControlType.Button)]
        CWXMacro4 = 60,
        [CatCommandAttribute("CWX Macro 5", ControlType.Button)]
        CWXMacro5 = 61,
        [CatCommandAttribute("CWX Macro 6", ControlType.Button)]
        CWXMacro6 = 62,
        [CatCommandAttribute("CWX Macro 7", ControlType.Button)]
        CWXMacro7 = 63,
        [CatCommandAttribute("CWX Macro 8", ControlType.Button)]
        CWXMacro8 = 64,
        [CatCommandAttribute("CWX Macro 9", ControlType.Button)]
        CWXMacro9 = 65,
        [CatCommandAttribute("CWX Stop", ControlType.Button)]
        CWXStop = 66,
        [CatCommandAttribute("MON On Off", ControlType.Button, true)]  
        MONOnOff = 67,
        [CatCommandAttribute("Pan Center", ControlType.Button)]
        PanCenter = 68,
        [CatCommandAttribute("VAC On Off", ControlType.Button, true)]  
        VACOnOff = 69,
        [CatCommandAttribute("Rx1 IQ To VAC", ControlType.Button)]
        IQtoVAC = 70,
        [CatCommandAttribute("Rx2 IQ to VAC", ControlType.Button)]
        IQtoVACRX2 = 71,
        [CatCommandAttribute("VAC 2 On Off", ControlType.Button,true)]
        VAC2OnOff = 72,
        [CatCommandAttribute("Click Tune On Off", ControlType.Button, true)]
        CTunOnOff = 73,
        [CatCommandAttribute("ESC Form On Off", ControlType.Button, true)]  
        ESCFormOnOff = 74,
        [CatCommandAttribute("RX2 Mute On Off", ControlType.Button, true)]  
        MuteRX2OnOff = 75,
        [CatCommandAttribute("Tune On Off", ControlType.Button,true)] 
        TunOnOff = 76,
        [CatCommandAttribute("Tuner Bypass", ControlType.Button, true)]
        TunerBypassOnOff = 77,
        [CatCommandAttribute("Band 160m", ControlType.Button)]
        Band160m = 78,
        [CatCommandAttribute("Band 80m", ControlType.Button)]
        Band80m = 79,
        [CatCommandAttribute("Band 60m", ControlType.Button)]
        Band60m = 80,
        [CatCommandAttribute("Band 40m", ControlType.Button)]
        Band40m = 81,
        [CatCommandAttribute("Band 30m", ControlType.Button)]
        Band30m = 82,
        [CatCommandAttribute("Band 20m", ControlType.Button)]
        Band20m = 83,
        [CatCommandAttribute("Band 17m", ControlType.Button)]
        Band17m = 84,
        [CatCommandAttribute("Band 15m", ControlType.Button)]
        Band15m = 85,
        [CatCommandAttribute("Band 12m", ControlType.Button)]
        Band12m = 86,
        [CatCommandAttribute("Band 10m", ControlType.Button)]
        Band10m = 87,
        [CatCommandAttribute("Band 6m", ControlType.Button)]
        Band6m = 88,
        [CatCommandAttribute("Band 2m", ControlType.Button)]
        Band2m = 89,
        [CatCommandAttribute("RX2 Band 160m", ControlType.Button)]
        Band160mRX2 = 90,
        [CatCommandAttribute("RX2 Band 80m", ControlType.Button)]
        Band80mRX2 = 91,
        [CatCommandAttribute("RX2 Band 60m", ControlType.Button)]
        Band60mRX2 = 92,
        [CatCommandAttribute("RX2 Band 40m", ControlType.Button)]
        Band40mRX2 = 93,
        [CatCommandAttribute("RX2 Band 30m", ControlType.Button)]
        Band30mRX2 = 94,
        [CatCommandAttribute("RX2 Band 20m", ControlType.Button)]
        Band20mRX2 = 95,
        [CatCommandAttribute("RX2 Band 17m", ControlType.Button)]
        Band17mRX2 = 96,
        [CatCommandAttribute("RX2 Band 15m", ControlType.Button)]
        Band15mRX2 = 97,
        [CatCommandAttribute("RX2 Band 12m", ControlType.Button)]
        Band12mRX2 = 98,
        [CatCommandAttribute("RX2 Band 10m", ControlType.Button)]
        Band10mRX2 = 99,
        [CatCommandAttribute("RX2 Band 6m", ControlType.Button)]
        Band6mRX2 = 500,
        [CatCommandAttribute("Band2mRX2", ControlType.Button)]
        Band2mRX2 = 501,
        [CatCommandAttribute("Mode SSB", ControlType.Button)]
        ModeSSB = 502,
        [CatCommandAttribute("Mode LSB", ControlType.Button)]
        ModeLSB = 503,
        [CatCommandAttribute("Mode USB", ControlType.Button)]
        ModeUSB = 504,
        [CatCommandAttribute("Mode DSB", ControlType.Button)]
        ModeDSB = 505,
        [CatCommandAttribute("Mode CW", ControlType.Button)]
        ModeCW = 506,
        [CatCommandAttribute("Mode CWL", ControlType.Button)]
        ModeCWL = 507,
        [CatCommandAttribute("Mode CWU", ControlType.Button)]
        ModeCWU = 508,
        [CatCommandAttribute("Mode FM", ControlType.Button)]
        ModeFM = 509,
        [CatCommandAttribute("Mode AM", ControlType.Button)]
        ModeAM = 510,
        [CatCommandAttribute("Mode DIGU", ControlType.Button)]
        ModeDIGU = 511,
        [CatCommandAttribute("Mode SPEC", ControlType.Button)]
        ModeSPEC = 512,
        [CatCommandAttribute("Mode DIGL", ControlType.Button)]
        ModeDIGL = 513,
        [CatCommandAttribute("Mode SAM", ControlType.Button)]
        ModeSAM = 514,
        [CatCommandAttribute("Mode DRM", ControlType.Button)]
        ModeDRM = 515,
        [CatCommandAttribute("Move VFOA Down 100Khz", ControlType.Button)]
        MoveVFOADown100Khz = 520,
        [CatCommandAttribute("Move VFOA Up 100Khz", ControlType.Button)]
        MoveVFOAUp100Khz = 521,
        [CatCommandAttribute("Change Freq Vfo A", ControlType.Wheel)]
        ChangeFreqVfoA = 101,
        [CatCommandAttribute("Change Freq Vfo B", ControlType.Wheel)]
        ChangeFreqVfoB = 102,
        [CatCommandAttribute("FilterBandwidth", ControlType.Wheel)]
        FilterBandwidth = 103,
        [CatCommandAttribute("RIT", ControlType.Wheel)]
        RIT_inc = 104,
        [CatCommandAttribute("XIT", ControlType.Wheel)]
        XIT_inc = 105,
        [CatCommandAttribute("Zoom", ControlType.Wheel)]
        ZoomSliderInc = 106,
        [CatCommandAttribute("Filter High", ControlType.Wheel)]
        FilterHigh = 107,
        [CatCommandAttribute("Filter Low", ControlType.Wheel)]
        FilterLow = 108,
        [CatCommandAttribute("Pan", ControlType.Wheel)]
        PanSliderInc = 109,
        [CatCommandAttribute("Multi Step Vfo A", ControlType.Wheel)]
        MultiStepVfoA = 110,
        [CatCommandAttribute("RIT", ControlType.Knob_or_Slider)]
        RIT = 201,       
        [CatCommandAttribute("Manual or Semi Break-In", ControlType.Button, true)]
        CWBreakIn = 111,
        [CatCommandAttribute("Semi or QSK Break-In", ControlType.Button, true)]
        CWQSK = 112,
        [CatCommandAttribute("XIT", ControlType.Knob_or_Slider)]
        XIT = 202,
        [CatCommandAttribute("Filter Shift", ControlType.Knob_or_Slider)]
        FilterShift = 203,
        [CatCommandAttribute("Volume VfoA", ControlType.Knob_or_Slider)]
        VolumeVfoA = 204,
        [CatCommandAttribute("Volume VfoB", ControlType.Knob_or_Slider)]
        VolumeVfoB = 205,
        [CatCommandAttribute("Ratio Main Sub Rx", ControlType.Knob_or_Slider)]
        RatioMainSubRx = 206,
        [CatCommandAttribute("PreAmp Setting", ControlType.Knob_or_Slider)]
        PreAmpSettingsKnob = 207,
        [CatCommandAttribute("CW Speed", ControlType.Knob_or_Slider)]
        CWSpeed = 208,
        [CatCommandAttribute("AF Gain", ControlType.Knob_or_Slider)]
        SetAFGain = 209,
        [CatCommandAttribute("RX1 AGC Level", ControlType.Knob_or_Slider)]
        AGCLevel = 210,
        [CatCommandAttribute("DriveLevel", ControlType.Knob_or_Slider)]
        DriveLevel = 211,
        [CatCommandAttribute("MicGain", ControlType.Knob_or_Slider)]
        MicGain = 212,
        [CatCommandAttribute("DXLevel", ControlType.Knob_or_Slider)]
        DXLevel = 213,
        [CatCommandAttribute("CPDRLevel", ControlType.Knob_or_Slider)]
        CPDRLevel = 214,
        [CatCommandAttribute("VOXGain", ControlType.Knob_or_Slider)]
        VOXGain = 215,
        [CatCommandAttribute("DEXP Threshold", ControlType.Knob_or_Slider)]
        DEXPThreshold = 216,
        [CatCommandAttribute("Squelch", ControlType.Knob_or_Slider)]
        SquelchControl = 217,
        [CatCommandAttribute("RX2 AGC Level", ControlType.Knob_or_Slider)]
        RX2AGCLevel = 218,
        [CatCommandAttribute("TX AF Monitor", ControlType.Knob_or_Slider)]
        TXAFMonitor = 219,
        [CatCommandAttribute("AGC Mode", ControlType.Knob_or_Slider)]
        AGCModeKnob = 220,
        [CatCommandAttribute("Zoom", ControlType.Knob_or_Slider)]
        ZoomSliderFix = 221,
        [CatCommandAttribute("RX2 Volume", ControlType.Knob_or_Slider)]
        RX2Volume = 222,
        [CatCommandAttribute("Pan", ControlType.Knob_or_Slider)]
        PanSlider = 223,
        [CatCommandAttribute("VAC Gain RX", ControlType.Knob_or_Slider)]
        VACGainRX = 224,
        [CatCommandAttribute("VAC Gain TX", ControlType.Knob_or_Slider)]
        VACGainTX = 225,
        [CatCommandAttribute("VAC2 Gain RX", ControlType.Knob_or_Slider)]
        VAC2GainRX = 226,
        [CatCommandAttribute("VAC2 Gain TX", ControlType.Knob_or_Slider)]
        VAC2GainTX = 227,
        [CatCommandAttribute("Waterfall Low Limit", ControlType.Knob_or_Slider)]
        WaterfallLowLimit = 228,
        [CatCommandAttribute("Waterfall High Limit", ControlType.Knob_or_Slider)]
        WaterfallHighLimit = 229,
        [CatCommandAttribute("Stereo Balance RX2 (PAN) ", ControlType.Knob_or_Slider)]
        RX2Pan = 230,
        [CatCommandAttribute("Volume VfoA Incr", ControlType.Wheel)]  //-W2PA Added Wheel versions for Behrihger CMD PL-1 and others
        VolumeVfoA_inc = 241,
        [CatCommandAttribute("Volume VfoB Incr", ControlType.Wheel)]
        VolumeVfoB_inc = 242,
        [CatCommandAttribute("RX1 AGC Level Incr", ControlType.Wheel)] 
        AGCLevel_inc = 243,
        [CatCommandAttribute("RX2 AGC Level Incr", ControlType.Wheel)]
        RX2AGCLevel_inc = 244,
        [CatCommandAttribute("CW Speed Incr", ControlType.Wheel)]
        CWSpeed_inc = 245,
        [CatCommandAttribute("Audio Peak Filter On Off", ControlType.Button, true)]
        APF_OnOff = 246,
        [CatCommandAttribute("Audio Peak Filter Tune", ControlType.Knob_or_Slider)]
        APFFreq = 247,
        [CatCommandAttribute("Audio Peak Filter Bandwidth", ControlType.Knob_or_Slider)]
        APFBandwidth = 248,
        [CatCommandAttribute("Audio Peak Filter Gain", ControlType.Knob_or_Slider)]
        APFGain = 249,
        [CatCommandAttribute("Rx2 Noise Reduction1 On Off", ControlType.Button, true)]
        Rx2NoiseReductionOnOff = 250,
        [CatCommandAttribute("Rx2 Noise Reduction2 On Off", ControlType.Button, true)]
        Rx2NoiseReduction2OnOff = 251,
        [CatCommandAttribute("Increase wheel rotation per VFO tune step", ControlType.Button)] 
        MidiMessagesPerTuneStepUp = 252,
        [CatCommandAttribute("Decrease wheel rotation per VFO tune step", ControlType.Button)]
        MidiMessagesPerTuneStepDown = 253,
        [CatCommandAttribute("VFO Wheel Sensitivity High/Low Toggle", ControlType.Button, true)]
        MidiMessagesPerTuneStepToggle = 254,
        [CatCommandAttribute("Drive Level Increment", ControlType.Wheel)]
        DriveLevel_inc = 255,
        [CatCommandAttribute("Lock VFO A", ControlType.Button, true)]
        LockVFOAOnOff = 256,
        [CatCommandAttribute("Lock VFO B", ControlType.Button, true)]
        LockVFOBOnOff = 257,
        [CatCommandAttribute("Diversity Form Open", ControlType.Button, true)]
        DiversityFormOpen = 258,
        [CatCommandAttribute("Diversity Enable", ControlType.Button, true)]
        DiversityEnable = 259,
        [CatCommandAttribute("Diversity Phase", ControlType.Wheel)]
        DiversityPhase= 260,
        [CatCommandAttribute("Diversity Gain", ControlType.Wheel)]
        DiversityGain = 261,
        [CatCommandAttribute("Diversity RX Reference", ControlType.Button, true)]
        DiversityReference = 262,
        [CatCommandAttribute("Diversity RX Source", ControlType.Button, true)]
        DiversitySource = 263,
        [CatCommandAttribute("2Tone On Off", ControlType.Button, true)]  //MW0LGE_21g
        TwoToneOnOff = 264,
        [CatCommandAttribute("PS-A On Off", ControlType.Button, true)] // DH1KLM_21g
        PSOnOff = 265,
        [CatCommandAttribute("Move VFOB Down 100Khz", ControlType.Button)] // DH1KLM_21g
        MoveVFOBDown100Khz = 266,
        [CatCommandAttribute("Move VFOB Up 100Khz", ControlType.Button)] // DH1KLM_21g
        MoveVFOBUp100Khz = 267,
        [CatCommandAttribute("RX2 Auto Notch On Off", ControlType.Button, true)] // DH1KLM_21g
        RX2AutoNotchOnOff = 268,
        [CatCommandAttribute("RX2 Mode Next", ControlType.Button)] // DH1KLM_21g
        Rx2ModeNext = 269,
        [CatCommandAttribute("RX2 Mode Prev", ControlType.Button)] // DH1KLM_21g
        Rx2ModePrev = 270,
        [CatCommandAttribute("RX2 Filter Wider", ControlType.Button)] // DH1KLM_21g
        Rx2FilterWider = 271,
        [CatCommandAttribute("RX2 Filter Narrower", ControlType.Button)] // DH1KLM_21g
        Rx2FilterNarrower = 272,
        [CatCommandAttribute("RX2 AGC Mode Up", ControlType.Button)] // DH1KLM_21g
        RX2AGCModeUp = 273,
        [CatCommandAttribute("RX2 AGC Mode Down", ControlType.Button)] // DH1KLM_21g
        RX2AGCModeDown = 274,
        [CatCommandAttribute("RX2 CTUN On Off", ControlType.Button, true)] // DH1KLM_21g
        RX2CTunOnOff = 275,
        [CatCommandAttribute("RX2 Mode SSB", ControlType.Button)] // DH1KLM_21g 
        RX2ModeSSB = 276,
        [CatCommandAttribute("RX2 Mode LSB", ControlType.Button)] // DH1KLM_21g
        RX2ModeLSB = 277,
        [CatCommandAttribute("RX2 Mode USB", ControlType.Button)] // DH1KLM_21g
        RX2ModeUSB = 278,
        [CatCommandAttribute("RX2 Mode DSB", ControlType.Button)] // DH1KLM_21g
        RX2ModeDSB = 279,
        [CatCommandAttribute("RX2 Mode CW", ControlType.Button)] // DH1KLM_21g
        RX2ModeCW = 280,
        [CatCommandAttribute("RX2 Mode CWL", ControlType.Button)] // DH1KLM_21g
        RX2ModeCWL = 281,
        [CatCommandAttribute("RX2 Mode CWU", ControlType.Button)] // DH1KLM_21g
        RX2ModeCWU = 282,
        [CatCommandAttribute("RX2 Mode FM", ControlType.Button)] // DH1KLM_21g
        RX2ModeFM = 283,
        [CatCommandAttribute("RX2 Mode AM", ControlType.Button)] // DH1KLM_21g
        RX2ModeAM = 284,
        [CatCommandAttribute("RX2 Mode DIGU", ControlType.Button)] // DH1KLM_21g
        RX2ModeDIGU = 285,
        [CatCommandAttribute("RX2 Mode SPEC", ControlType.Button)] // DH1KLM_21g
        RX2ModeSPEC = 286,
        [CatCommandAttribute("RX2 Mode DIGL", ControlType.Button)] // DH1KLM_21g
        RX2ModeDIGL = 287,
        [CatCommandAttribute("RX2 Mode SAM", ControlType.Button)] // DH1KLM_21g
        RX2ModeSAM = 288,
        [CatCommandAttribute("RX2 Mode DRM", ControlType.Button)] // DH1KLM_21g
        RX2ModeDRM = 289,
        [CatCommandAttribute("Close Thetis", ControlType.Button)] // DH1KLM_21g 
        CloseConsole = 290,
        [CatCommandAttribute("Toggle TX VFOA VFOB", ControlType.Button, true)] // DH1KLM_21g
        ToggleTX = 291,
        [CatCommandAttribute("RX2 AGC Mode", ControlType.Knob_or_Slider)] //DH1KLM_21g
        RX2AGCModeKnob = 292,
        [CatCommandAttribute("TUN Power Level", ControlType.Knob_or_Slider)] //DH1KLM_21g
        TUNPowerLevel = 293,
        [CatCommandAttribute("RX2 Squelch On Off", ControlType.Button, true)] // DH1KLM_21g     
        RX2SquelchOnOff = 294,
        [CatCommandAttribute("RX2 Squelch Level", ControlType.Knob_or_Slider)] // DH1KLM_21g
        RX2SquelchControl = 295,
        [CatCommandAttribute("TX Filter high", ControlType.Wheel)] // DH1KLM_21h
        TXFilterHigh = 296,
        [CatCommandAttribute("TX Filter low", ControlType.Wheel)] // DH1KLM_21h
        TXFilterLow = 297,
        [CatCommandAttribute("External PA On Off", ControlType.Button, true)] // MW0LGE_21j
        ExternalPAOnOff = 298,
        [CatCommandAttribute("Zoom To Band Recall", ControlType.Button)] // MW0LGE_21k9
        ZoomToBandRecall = 299,
        [CatCommandAttribute("Zoom To Band Store", ControlType.Button)] // MW0LGE_21k9
        ZoomToBandStore = 300,
        [CatCommandAttribute("RX1 Auto AGC compensation", ControlType.Button, true)] // MW0LGE_21k9
        RX1AutoAGC = 301,
        [CatCommandAttribute("RX2 Auto AGC compensation", ControlType.Button, true)] // MW0LGE_21k9
        RX2AutoAGC = 302,
        [CatCommandAttribute("Swap VFO Wheels", ControlType.Button, true)] // MW0LGE [2.9.0.7]
        SwapVFOWheels = 303,
        [CatCommandAttribute("Quick Split On Off", ControlType.Button, true)]
        QuickSplitOnOff = 304,
        [CatCommandAttribute("Quick Split + VFO Split On Off", ControlType.Button, true)]
        QuickSplitOnOffandSplitOnOff = 305,
        [CatCommandAttribute("Quick Play Wave File",ControlType.Button, true)] // DH1KLM 
        QuickPlayOnOff = 306,
        [CatCommandAttribute("Quick Rec Wave File", ControlType.Button, true)] // DH1KLM
        QuickRecOnOff = 307,
        [CatCommandAttribute("Audio Amp On Off", ControlType.Button, true)] // [2.10.3.6]MW0LGE 
        AudioAmpOnOff = 308,
        [CatCommandAttribute("Toggle Wheel to VFOA/VFOB ", ControlType.Button)]  //-W2PA Added a toggle between A/B for main wheel 
        ToggleVFOWheel = 700,
        [CatCommandAttribute("CWX Key ", ControlType.Button)]  //MI0BOT: Added ability to key via MIDI
        CWXKey = 800,
        [CatCommandAttribute("CWX PTT ", ControlType.Button)]  //MI0BOT: Added ability to PTT via MIDI
        CWXPTT = 801
    }
}// namespace
