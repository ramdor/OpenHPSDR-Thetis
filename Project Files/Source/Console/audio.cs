//=================================================================
// audio.cs
//=================================================================
// PowerSDR is a C# implementation of a Software Defined Radio.
// Copyright (C) 2004-2009  FlexRadio Systems
// Copyright (C) 2010-2020  Doug Wigley
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
// You may contact us via email at: sales@flex-radio.com.
// Paper mail may be sent to: 
//    FlexRadio Systems
//    8900 Marybank Dr.
//    Austin, TX 78750
//    USA
//=================================================================

using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
//using ProjectCeilidh.PortAudio;
//using ProjectCeilidh.PortAudio.Native;
//using static ProjectCeilidh.PortAudio.Native.PortAudio;

namespace Thetis
{
    public class Audio
    {
        #region Thetis Specific Variables

        // ======================================================
        // Thetis Specific Variables
        // ======================================================

        public enum AudioState
        {
            DTTSP = 0,
            CW,
        }

        public enum SignalSource
        {
            RADIO,
            SINE,
            SINE_TWO_TONE,
            SINE_LEFT_ONLY,
            SINE_RIGHT_ONLY,
            NOISE,
            TRIANGLE,
            SAWTOOTH,
            PULSE,
            SILENCE,
        }

        // unsafe private static PA19.PaStreamCallback PAcallbackport = PACallbackPort;

        // public static int callback_return;

        private static bool rx2_auto_mute_tx = true;
        public static bool RX2AutoMuteTX
        {
            get { return rx2_auto_mute_tx; }
            set { rx2_auto_mute_tx = value; }
        }

        private static bool rx1_blank_display_tx = false;
        public static bool RX1BlankDisplayTX
        {
            get { return rx1_blank_display_tx; }
            set { rx1_blank_display_tx = value; }
        }

        private static bool rx2_blank_display_tx = false;
        public static bool RX2BlankDisplayTX
        {
            get { return rx2_blank_display_tx; }
            set { rx2_blank_display_tx = value; }
        }

        private static double source_scale = 1.0;
        public static double SourceScale
        {
            get { return source_scale; }
            set { source_scale = value; }
        }

        private static SignalSource tx_input_signal = SignalSource.RADIO;
        public static SignalSource TXInputSignal
        {
            get { return tx_input_signal; }
            set { tx_input_signal = value; }
        }

        private static SignalSource tx_output_signal = SignalSource.RADIO;
        public static SignalSource TXOutputSignal
        {
            get { return tx_output_signal; }
            set { tx_output_signal = value; }
        }

        private static bool record_rx_preprocessed = false;
        public static bool RecordRXPreProcessed
        {
            get { return record_rx_preprocessed; }
            set
            {
                record_rx_preprocessed = value;
                WaveThing.wrecorder[0].RxPre = value;
                WaveThing.wrecorder[1].RxPre = value;
            }
        }

        private static bool record_tx_preprocessed = true;
        public static bool RecordTXPreProcessed
        {
            get { return record_tx_preprocessed; }
            set
            {
                record_tx_preprocessed = value;
                WaveThing.wrecorder[0].TxPre = value;
                WaveThing.wrecorder[1].TxPre = value;
            }
        }

        private static short bit_depth = 32;
        public static short BitDepth
        {
            get { return bit_depth; }
            set { bit_depth = value; }
        }

        private static short format_tag = 3;
        public static short FormatTag
        {
            get { return format_tag; }
            set { format_tag = value; }
        }

        private static bool vox_enabled = false;
        public static bool VOXEnabled
        {
            get { return vox_enabled; }
            set
            {
                vox_enabled = value;
                cmaster.CMSetTXAVoxRun(0);
                if (vox_enabled && vfob_tx)
                {
                    ivac.SetIVACvox(0, 0);
                    ivac.SetIVACvox(1, 1);
                }
                if (vox_enabled && !vfob_tx)
                {
                    ivac.SetIVACvox(0, 1);
                    ivac.SetIVACvox(1, 0);
                }
                if (!vox_enabled)
                {
                    ivac.SetIVACvox(0, 0);
                    ivac.SetIVACvox(1, 0);
                }

            }
        }

        private static float vox_gain = 1.0f;
        public static float VOXGain
        {
            get { return vox_gain; }
            set
            {
                vox_gain = value;
            }
        }

        private static double high_swr_scale = 1.0;
        public static double HighSWRScale
        {
            get { return high_swr_scale; }
            set
            {
                high_swr_scale = value;
                cmaster.CMSetTXOutputLevel();
            }
        }

        private static double mic_preamp = 1.0;
        public static double MicPreamp
        {
            get { return mic_preamp; }
            set
            {
                mic_preamp = value;
                cmaster.CMSetTXAPanelGain1(WDSP.id(1, 0));
            }
        }

        private static double wave_preamp = 1.0;
        public static double WavePreamp
        {
            get { return wave_preamp; }
            set
            {
                wave_preamp = value;
                cmaster.CMSetTXAPanelGain1(WDSP.id(1, 0));
            }
        }

        private static double monitor_volume = 0.0;
        public static double MonitorVolume
        {
            get { return monitor_volume; }
            set
            {
                monitor_volume = value;
                cmaster.CMSetAudioVolume(value);

                ////MW0LGE_21k-rc2
                //if (vfob_tx)
                //{
                //    if (rx2_enabled) // need to check the vac2 split thing ?
                //    {
                //        ivac.SetIVACmonVol(1, monitor_volume);
                //    }
                //    else
                //    {
                //        ivac.SetIVACmonVol(0, monitor_volume);
                //    }
                //}
                //else
                //{
                //    ivac.SetIVACmonVol(0, monitor_volume);
                //}

                //MW0LGE [pre g2]
                ivac.SetIVACmonVol(0, monitor_volume);
            }
        }

        private static double radio_volume = 0.0;
        public static double RadioVolume
        {
            get { return radio_volume; }
            set
            {
                radio_volume = value;
                NetworkIO.SetOutputPower((float)(value * 1.02));
                cmaster.CMSetTXOutputLevel();
            }
        }

        private static AudioState current_audio_state1 = AudioState.DTTSP;
        public static AudioState CurrentAudioState1
        {
            get { return current_audio_state1; }
            set { current_audio_state1 = value; }
        }

        private static bool rx2_enabled;

        public static bool RX2Enabled
        {
            get { return rx2_enabled; }
            set { rx2_enabled = value; }
        }

        private static bool wave_playback = false;
        public static bool WavePlayback
        {
            get { return wave_playback; }
            set
            {
                wave_playback = value;
                cmaster.CMSetSRXWavePlayRun(0);
                cmaster.CMSetSRXWavePlayRun(1);
                cmaster.CMSetTXAPanelGain1(WDSP.id(1, 0));
            }
        }

        private static bool wave_record;
        public static bool WaveRecord
        {
            get { return wave_record; }
            set
            {
                wave_record = value;
                cmaster.CMSetSRXWaveRecordRun(0);
                cmaster.CMSetSRXWaveRecordRun(1);
            }
        }

        public static Console console;
        public static float[] phase_buf_l;
        public static float[] phase_buf_r;
        public static bool phase;
        public static bool scope;

        public static bool two_tone;
        public static bool high_pwr_am;
        public static bool testing;

        private static bool vac_combine_input = false;
        public static bool VACCombineInput
        {
            get { return vac_combine_input; }
            set
            {
                vac_combine_input = value;
                ivac.SetIVACcombine(0, Convert.ToInt32(value));
            }
        }

        private static bool vac2_combine_input = false;
        public static bool VAC2CombineInput
        {
            get { return vac2_combine_input; }
            set
            {
                vac2_combine_input = value;
                ivac.SetIVACcombine(1, Convert.ToInt32(value));
            }
        }

        #endregion

        #region Local Copies of External Properties

        private static bool mox = false;
        public static bool MOX
        {
            get { return mox; }
            set
            {
                mox = value;

                if (mox)
                {
                    if (rx2_enabled && vfob_tx)  //[2.10.0.4]MW0LGE fix issue with no RX2 audio when tx'ing on rx1
                    {
                        ivac.SetIVACmox(0, 0);
                        ivac.SetIVACmox(1, 1);
                    }
                    else
                    {
                        ivac.SetIVACmox(0, 1);
                        ivac.SetIVACmox(1, 0);
                    }
                }
                else
                {
                    ivac.SetIVACmox(0, 0);
                    ivac.SetIVACmox(1, 0);
                }

                // [2.10.3.5]MW0LGE
                if (WaveThing.wave_file_writer[0] != null)
                    WaveThing.wave_file_writer[0].UpdateMox();
                if (WaveThing.wave_file_writer[1] != null)
                    WaveThing.wave_file_writer[1].UpdateMox();
                //
            }
        }

        private static void setupIVACforMon()
        {
            if (mon)
            {
                ivac.SetIVACmon(0, 1);
                ivac.SetIVACmon(1, 0);
                ivac.SetIVACmonVol(0, monitor_volume);
            }
            else
            {
                ivac.SetIVACmon(0, 0);
                ivac.SetIVACmon(1, 0);
            }
        }
        private static bool mon;
        public static bool MON
        {
            set
            {
                mon = value;

                setupIVACforMon();

                unsafe
                {
                    cmaster.SetAAudioMixVol((void*)0, 0, WDSP.id(1, 0), 0.5);
                    cmaster.SetAAudioMixWhat((void*)0, 0, WDSP.id(1, 0), value);
                }
            }
            get
            {
                return mon;
            }
        }

        private static bool full_duplex = false;
        public static bool FullDuplex
        {
            set { full_duplex = value; }
        }

        private static bool vfob_tx = false;
        public static bool VFOBTX
        {
            get
            { return vfob_tx; }

            set
            {
                vfob_tx = value;
            }

        }

        private static bool antivox_source_VAC = false;
        public static bool AntiVOXSourceVAC
        {
            get { return antivox_source_VAC; }
            set
            {
                antivox_source_VAC = value;
                cmaster.CMSetAntiVoxSourceWhat();
            }
        }

        private static bool vac_enabled = false;
        public static bool VACEnabled
        {
            set
            {
                vac_enabled = value;
                cmaster.CMSetTXAPanelGain1(WDSP.id(1, 0));
                cmaster.CMSetAntiVoxSourceWhat();
                if (console.PowerOn)
                    EnableVAC1(value);
            }
            get { return vac_enabled; }
        }

        private static bool vac2_enabled = false;
        public static bool VAC2Enabled
        {
            set
            {
                vac2_enabled = value;
                cmaster.CMSetAntiVoxSourceWhat();
                if (console.PowerOn)
                    EnableVAC2(value);
            }
            get { return vac2_enabled; }
        }

        private static bool vac1_latency_manual = false;
        public static bool VAC1LatencyManual
        {
            set { vac1_latency_manual = value; }
            get { return vac1_latency_manual; }
        }

        private static bool vac1_latency_manual_out = false;
        public static bool VAC1LatencyManualOut
        {
            set { vac1_latency_manual_out = value; }
            get { return vac1_latency_manual_out; }
        }

        private static bool vac1_latency_pa_in_manual = false;
        public static bool VAC1LatencyPAInManual
        {
            set { vac1_latency_pa_in_manual = value; }
            get { return vac1_latency_pa_in_manual; }
        }

        private static bool vac1_latency_pa_out_manual = false;
        public static bool VAC1LatencyPAOutManual
        {
            set { vac1_latency_pa_out_manual = value; }
            get { return vac1_latency_pa_out_manual; }
        }

        private static bool vac2_latency_manual = false;
        public static bool VAC2LatencyManual
        {
            set { vac2_latency_manual = value; }
            get { return vac2_latency_manual; }
        }

        private static bool vac2_latency_out_manual = false;
        public static bool VAC2LatencyOutManual
        {
            set { vac2_latency_out_manual = value; }
            get { return vac2_latency_out_manual; }
        }

        private static bool vac2_latency_pa_in_manual = false;
        public static bool VAC2LatencyPAInManual
        {
            set { vac2_latency_pa_in_manual = value; }
            get { return vac2_latency_pa_in_manual; }
        }

        private static bool vac2_latency_pa_out_manual = false;
        public static bool VAC2LatencyPAOutManual
        {
            set { vac2_latency_pa_out_manual = value; }
            get { return vac2_latency_pa_out_manual; }
        }

        private static bool vac_bypass = false;
        public static bool VACBypass
        {
            get
            {
                return vac_bypass;
            }
            set
            {
                vac_bypass = value;
                cmaster.CMSetTXAPanelGain1(WDSP.id(1, 0));
                ivac.SetIVACbypass(0, Convert.ToInt32(value));
                ivac.SetIVACbypass(1, Convert.ToInt32(value));
            }
        }

        private static bool vac_rb_reset = false;
        public static bool VACRBReset
        {
            set
            {
                vac_rb_reset = value;
                ivac.SetIVACRBReset(0, Convert.ToInt32(value));
            }
            get { return vac_rb_reset; }
        }

        private static bool vac2_rb_reset = false;
        public static bool VAC2RBReset
        {
            set
            {
                vac2_rb_reset = value;
                ivac.SetIVACRBReset(1, Convert.ToInt32(value));
            }
            get { return vac2_rb_reset; }
        }

        private static double vac_preamp = 1.0;
        public static double VACPreamp
        {
            get { return vac_preamp; }
            set
            {
                vac_preamp = value;
                cmaster.CMSetTXAPanelGain1(WDSP.id(1, 0));
                ivac.SetIVACpreamp(0, value);
            }
        }

        private static double vac2_tx_scale = 1.0;
        public static double VAC2TXScale
        {
            get { return vac2_tx_scale; }
            set
            {
                vac2_tx_scale = value;
                ivac.SetIVACpreamp(1, value);
            }
        }

        private static double vac_rx_scale = 1.0;
        public static double VACRXScale
        {
            get { return vac_rx_scale; }
            set
            {
                vac_rx_scale = value;
                ivac.SetIVACrxscale(0, value);
            }
        }

        private static double vac2_rx_scale = 1.0;
        public static double VAC2RXScale
        {
            get { return vac2_rx_scale; }
            set
            {
                vac2_rx_scale = value;
                ivac.SetIVACrxscale(1, value);
            }
        }

        private static DSPMode tx_dsp_mode = DSPMode.LSB;
        public static DSPMode TXDSPMode
        {
            get { return tx_dsp_mode; }
            set
            {
                tx_dsp_mode = value;
                cmaster.CMSetTXAVoxRun(0);
                cmaster.CMSetTXAPanelGain1(WDSP.id(1, 0));
            }
        }

        private static int sample_rate1 = 48000;
        public static int SampleRate1
        {
            get { return sample_rate1; }
            set
            {
                sample_rate1 = value;
                SetOutCount();
                // set input sample rate for receivers
                cmaster.SetXcmInrate(0, value);
                // cmaster.SetXcmInrate(3, value);
                // cmaster.SetXcmInrate(4, value);
            }
        }

        private static int sample_rate_rx2 = 48000;
        public static int SampleRateRX2
        {
            get { return sample_rate_rx2; }
            set
            {
                sample_rate_rx2 = value;
                cmaster.SetXcmInrate(1, value);
                SetOutCountRX2();
            }
        }

        private static int sample_rate_tx = 48000;
        public static int SampleRateTX
        {
            get { return sample_rate_tx; }
            set
            {
                sample_rate_tx = value;
                SetOutCountTX();
            }
        }

        private static int sample_rate2 = 48000;
        public static int SampleRate2
        {
            get { return sample_rate2; }
            set
            {
                sample_rate2 = value;
                ivac.SetIVACvacRate(0, value);
            }
        }

        private static int sample_rate3 = 48000;
        public static int SampleRate3
        {
            get { return sample_rate3; }
            set
            {
                sample_rate3 = value;
                ivac.SetIVACvacRate(1, value);
            }
        }

        private static int block_size1 = 1024;
        public static int BlockSize
        {
            get { return block_size1; }
            set
            {
                block_size1 = value;
                SetOutCount();
            }
        }

        private static int block_size_rx2 = 1024;
        public static int BlockSizeRX2
        {
            get { return block_size_rx2; }
            set
            {
                block_size_rx2 = value;
                SetOutCountRX2();
            }
        }

        //[2.10.3.4]MW0LGE added
        private static int block_size_tx = 1024;
        public static int BlockSizeTX
        {
            get { return block_size_tx; }
            set
            {
                block_size_tx = value;
                SetOutCountTX();
            }
        }

        private static int block_size_vac = 1024;
        public static int BlockSizeVAC
        {
            get { return block_size_vac; }
            set
            {
                block_size_vac = value;
                ivac.SetIVACvacSize(0, value);
            }
        }

        private static int block_size_vac2 = 1024;
        public static int BlockSizeVAC2
        {
            get { return block_size_vac2; }
            set
            {
                block_size_vac2 = value;
                ivac.SetIVACvacSize(1, value);
            }
        }

        private static bool vac_stereo = false;
        public static bool VACStereo
        {
            get { return vac_stereo; }
            set
            {
                vac_stereo = value;
                ivac.SetIVACstereo(0, Convert.ToInt32(value));
            }
        }

        private static bool vac2_stereo = false;
        public static bool VAC2Stereo
        {
            set
            {
                vac2_stereo = value;
                ivac.SetIVACstereo(1, Convert.ToInt32(value));
            }
        }

        private static bool vac_output_iq = false;
        public static bool VACOutputIQ
        {
            get { return vac_output_iq; }
            set
            {
                vac_output_iq = value;
                ivac.SetIVACiqType(0, Convert.ToInt32(value));
            }
        }

        private static bool vac2_output_iq = false;
        public static bool VAC2OutputIQ
        {
            set
            {
                vac2_output_iq = value;
                ivac.SetIVACiqType(1, Convert.ToInt32(value));

            }
        }

        private static bool vac_output_rx2 = false;
        public static bool VACOutputRX2
        {
            set
            {
                vac_output_rx2 = value;
            }
        }

        private static bool vac_correct_iq = true;
        public static bool VACCorrectIQ
        {
            set { vac_correct_iq = value; }
        }

        private static bool vac2_correct_iq = true;
        public static bool VAC2CorrectIQ
        {
            set { vac2_correct_iq = value; }
        }

        private static bool vox_active = false;
        public static bool VOXActive
        {
            get { return vox_active; }
            set { vox_active = value; }
        }

        private static int host2 = 0;
        public static int Host2
        {
            get { return host2; }
            set { host2 = value; }
        }

        private static int host3 = 0;
        public static int Host3
        {
            get { return host3; }
            set { host3 = value; }
        }

        private static int input_dev2 = 0;
        public static int Input2
        {
            get { return input_dev2; }
            set { input_dev2 = value; }
        }

        private static int input_dev3 = 0;
        public static int Input3
        {
            get { return input_dev3; }
            set { input_dev3 = value; }
        }

        private static int output_dev2 = 0;
        public static int Output2
        {
            get { return output_dev2; }
            set { output_dev2 = value; }
        }

        private static int output_dev3 = 0;
        public static int Output3
        {
            get { return output_dev3; }
            set { output_dev3 = value; }
        }

        private static int latency2 = 120;
        public static int Latency2
        {
            set { latency2 = value; }
        }

        private static int latency2_out = 120;
        public static int Latency2_Out
        {
            set { latency2_out = value; }
        }

        private static int latency_pa_in = 120;
        public static int LatencyPAIn
        {
            set { latency_pa_in = value; }
        }

        private static int latency_pa_out = 120;
        public static int LatencyPAOut
        {
            set { latency_pa_out = value; }
        }

        private static int vac2_latency_out = 120;
        public static int VAC2LatencyOut
        {
            set { vac2_latency_out = value; }
        }

        private static int vac2_latency_pa_in = 120;
        public static int VAC2LatencyPAIn
        {
            set { vac2_latency_pa_in = value; }
        }

        private static int vac2_latency_pa_out = 120;
        public static int VAC2LatencyPAOut
        {
            set { vac2_latency_pa_out = value; }
        }

        private static int latency3 = 120;
        public static int Latency3
        {
            set { latency3 = value; }
        }

        //MW0LGE_21h/i/j
        private static double vac1_feedbackgainIn = 4.0e-06;
        private static double vac1_slewtimeIn = 0.003;
        private static double vac2_feedbackgainIn = 4.0e-06;
        private static double vac2_slewtimeIn = 0.003;

        private static int vac1_prop_ringminIn = 4096;
        private static int vac1_prop_ringmaxIn = 16384; // power of 2
        private static int vac2_prop_ringminIn = 4096;
        private static int vac2_prop_ringmaxIn = 16384; // power of 2
        private static int vac1_ff_ringminIn = 4096;
        private static int vac1_ff_ringmaxIn = 262144; // power of 2
        private static int vac2_ff_ringminIn = 4096;
        private static int vac2_ff_ringmaxIn = 262144; // power of 2

        private static double vac1_ff_alphaIn = 0.01;
        private static double vac2_ff_alphaIn = 0.01;

        private static double vac1_oldVarIn = 1.0;
        private static double vac2_oldVarIn = 1.0;

        private static double vac1_feedbackgainOut = 4.0e-06;
        private static double vac1_slewtimeOut = 0.003;
        private static double vac2_feedbackgainOut = 4.0e-06;
        private static double vac2_slewtimeOut = 0.003;

        private static int vac1_prop_ringminOut = 4096;
        private static int vac1_prop_ringmaxOut = 16384; // power of 2
        private static int vac2_prop_ringminOut = 4096;
        private static int vac2_prop_ringmaxOut = 16384; // power of 2
        private static int vac1_ff_ringminOut = 4096;
        private static int vac1_ff_ringmaxOut = 262144; // power of 2
        private static int vac2_ff_ringminOut = 4096;
        private static int vac2_ff_ringmaxOut = 262144; // power of 2

        private static double vac1_ff_alphaOut = 0.01;
        private static double vac2_ff_alphaOut = 0.01;

        private static double vac1_oldVarOut = 1.0;
        private static double vac2_oldVarOut = 1.0;

        private static bool isPowerOfTwo(int x)
        {
            return (x != 0) && ((x & (x - 1)) == 0);
        }

        //vac1in
        public static double VAC1FeedbackGainIn
        {
            set { 
                vac1_feedbackgainIn = value;
                ivac.SetIVACFeedbackGain(0, 1, vac1_feedbackgainIn);
            }
        }
        public static double VAC1SlewTimeIn
        {
            set { 
                vac1_slewtimeIn = value;
                ivac.SetIVACSlewTime(0, 1, vac1_slewtimeIn);
            }
        }
        public static int VAC1PropRingMinIn
        {
            get { return vac1_prop_ringminIn; }
            set
            {
                vac1_prop_ringminIn = value;
                ivac.SetIVACPropRingMin(0, 1, vac1_prop_ringminIn);
            }
        }
        public static int VAC1PropRingMaxIn
        {
            get { return vac1_prop_ringmaxIn; }
            set
            {
                if (!isPowerOfTwo(value)) return;
                vac1_prop_ringmaxIn = value;
                ivac.SetIVACPropRingMax(0, 1, vac1_prop_ringmaxIn);
            }
        }
        public static int VAC1FFRingMinIn
        {
            get { return vac1_ff_ringminIn; }
            set
            {
                vac1_ff_ringminIn = value;
                ivac.SetIVACFFRingMin(0, 1, vac1_ff_ringminIn);
            }
        }
        public static int VAC1FFRingMaxIn
        {
            get { return vac1_ff_ringmaxIn; }
            set
            {
                if (!isPowerOfTwo(value)) return;
                vac1_ff_ringmaxIn = value;
                ivac.SetIVACFFRingMax(0, 1, vac1_ff_ringmaxIn);
            }
        }
        public static double VAC1FFAlphaIn
        {
            set
            {
                vac1_ff_alphaIn = value;
                ivac.SetIVACFFAlpha(0, 1, vac1_ff_alphaIn);
            }
        }
        public static double VAC1OldVarIn
        {
            set
            {
                vac1_oldVarIn = value;
                //ivac.SetIVACvar(0, 1, vac1_oldVarIn); // used in vac enable only
            }
        }
        public static bool VAC1ControlFlagIn
        {
            get {
                int flg;
                unsafe
                {
                    ivac.GetIVACControlFlag(0, 1, &flg);
                }
                return flg == 1;
            }
        }

        //vac1out
        public static double VAC1FeedbackGainOut
        {
            set { 
                vac1_feedbackgainOut = value;
                ivac.SetIVACFeedbackGain(0, 0, vac1_feedbackgainOut);
            }
        }
        public static double VAC1SlewTimeOut
        {
            set { 
                vac1_slewtimeOut = value;
                ivac.SetIVACSlewTime(0, 0, vac1_slewtimeOut);
            }
        }
        public static int VAC1PropRingMinOut
        {
            get { return vac1_prop_ringminOut; }
            set
            {
                vac1_prop_ringminOut = value;
                ivac.SetIVACPropRingMin(0, 0, vac1_prop_ringminOut);
            }
        }
        public static int VAC1PropRingMaxOut
        {
            get { return vac1_prop_ringmaxOut; }
            set
            {
                if (!isPowerOfTwo(value)) return;
                vac1_prop_ringmaxOut = value;
                ivac.SetIVACPropRingMax(0, 0, vac1_prop_ringmaxOut);
            }
        }
        public static int VAC1FFRingMinOut
        {
            get { return vac1_ff_ringminOut; }
            set
            {
                vac1_ff_ringminOut = value;
                ivac.SetIVACFFRingMin(0, 0, vac1_ff_ringminOut);
            }
        }
        public static int VAC1FFRingMaxOut
        {
            get { return vac1_ff_ringmaxOut; }
            set
            {
                if (!isPowerOfTwo(value)) return;
                vac1_ff_ringmaxOut = value;
                ivac.SetIVACFFRingMax(0, 0, vac1_ff_ringmaxOut);
            }
        }
        public static double VAC1FFAlphaOut
        {
            set
            {
                vac1_ff_alphaOut = value;
                ivac.SetIVACFFAlpha(0, 0, vac1_ff_alphaOut);
            }
        }
        public static double VAC1OldVarOut
        {
            set
            {
                vac1_oldVarOut = value;
                //ivac.SetIVACvar(0, 0, vac1_oldVarOut);  // used in vac enable only
            }
        }
        public static bool VAC1ControlFlagOut
        {
            get
            {
                int flg;
                unsafe
                {
                    ivac.GetIVACControlFlag(0, 0, &flg);
                }
                return flg == 1;
            }
        }

        //vac2in
        public static double VAC2FeedbackGainIn
        {
            set { 
                vac2_feedbackgainIn = value;
                ivac.SetIVACFeedbackGain(1, 1, vac2_feedbackgainIn);
            }
        }
        public static double VAC2SlewTimeIn
        {
            set { 
                vac2_slewtimeIn = value;
                ivac.SetIVACSlewTime(1, 1, vac2_slewtimeIn);
            }
        }
        public static int VAC2PropRingMinIn
        {
            set
            {
                vac2_prop_ringminIn = value;
                ivac.SetIVACPropRingMin(1, 1, vac2_prop_ringminIn);
            }
        }
        public static int VAC2PropRingMaxIn
        {
            get { return vac2_prop_ringmaxIn; }
            set
            {
                if (!isPowerOfTwo(value)) return;
                vac2_prop_ringmaxIn = value;
                ivac.SetIVACPropRingMax(1, 1, vac2_prop_ringmaxIn);
            }
        }
        public static int VAC2FFRingMinIn
        {
            set
            {
                vac2_ff_ringminIn = value;
                ivac.SetIVACFFRingMin(1, 1, vac2_ff_ringminIn);
            }
        }
        public static int VAC2FFRingMaxIn
        {
            get { return vac2_ff_ringmaxIn; }
            set
            {
                if (!isPowerOfTwo(value)) return;
                vac2_ff_ringmaxIn = value;
                ivac.SetIVACFFRingMax(1, 1, vac2_ff_ringmaxIn);
            }
        }
        public static double VAC2FFAlphaIn
        {
            set
            {
                vac2_ff_alphaIn = value;
                ivac.SetIVACFFAlpha(1, 1, vac2_ff_alphaIn);
            }
        }
        public static double VAC2OldVarIn
        {
            set
            {
                vac2_oldVarIn = value;
                //ivac.SetIVACvar(1, 1, vac2_oldVarIn);  // used in vac enable only
            }
        }
        public static bool VAC2ControlFlagIn
        {
            get
            {
                int flg;
                unsafe
                {
                    ivac.GetIVACControlFlag(1, 1, &flg);
                }
                return flg == 1;
            }
        }

        //vac2out
        public static double VAC2FeedbackGainOut
        {
            set { 
                vac2_feedbackgainOut = value;
                ivac.SetIVACFeedbackGain(1, 0, vac2_feedbackgainOut);
            }
        }
        public static double VAC2SlewTimeOut
        {
            set { 
                vac2_slewtimeOut = value;
                ivac.SetIVACSlewTime(1, 0, vac2_slewtimeOut);
            }
        }
        public static int VAC2PropRingMinOut
        {
            set
            {
                vac2_prop_ringminOut = value;
                ivac.SetIVACPropRingMin(1, 0, vac2_prop_ringminOut);
            }
        }
        public static int VAC2PropRingMaxOut
        {
            get { return vac2_prop_ringmaxOut; }
            set
            {
                if (!isPowerOfTwo(value)) return;
                vac2_prop_ringmaxOut = value;
                ivac.SetIVACPropRingMax(1, 0, vac2_prop_ringmaxOut);
            }
        }
        public static int VAC2FFRingMinOut
        {
            set
            {
                vac2_ff_ringminOut = value;
                ivac.SetIVACFFRingMin(1, 0, vac2_ff_ringminOut);
            }
        }
        public static int VAC2FFRingMaxOut
        {
            get { return vac2_ff_ringmaxOut; }
            set
            {
                if (!isPowerOfTwo(value)) return;
                vac2_ff_ringmaxOut = value;
                ivac.SetIVACFFRingMax(1, 0, vac2_ff_ringmaxOut);
            }
        }
        public static double VAC2FFAlphaOut
        {
            set
            {
                vac2_ff_alphaOut = value;
                ivac.SetIVACFFAlpha(1, 0, vac2_ff_alphaOut);
            }
        }
        public static double VAC2OldVarOut
        {
            set
            {
                vac2_oldVarOut = value;
                //ivac.SetIVACvar(1, 0, vac2_oldVarOut);  // used in vac enable only
            }
        }
        public static bool VAC2ControlFlagOut
        {
            get
            {
                int flg;
                unsafe
                {
                    ivac.GetIVACControlFlag(1, 0, &flg);
                }
                return flg == 1;
            }
        }
        //

        private static bool mute_rx1 = false;
        public static bool MuteRX1
        {
            get { return mute_rx1; }
            set
            {
                mute_rx1 = value;

                setupIVACforMon(); //MW0LGE_21k9d

                unsafe
                {
                    cmaster.SetAAudioMixWhat((void*)0, 0, 0, !mute_rx1);
                    cmaster.SetAAudioMixWhat((void*)0, 0, 1, !mute_rx1);
                }
            }
        }

        private static bool mute_rx2 = false;
        public static bool MuteRX2
        {
            get { return mute_rx2; }
            set
            {
                mute_rx2 = value;

                setupIVACforMon(); //MW0LGE_21k9d

                unsafe
                {
                    cmaster.SetAAudioMixWhat((void*)0, 0, 2, !mute_rx2);
                }
            }
        }

        private static int out_rate = 48000;
        public static int OutRate
        {
            get { return out_rate; }
            set
            {
                out_rate = value;
                SetOutCount();
            }
        }

        private static int out_rate_rx2 = 48000;
        public static int OutRateRX2
        {
            get { return out_rate_rx2; }
            set
            {
                out_rate_rx2 = value;
                SetOutCountRX2();
            }
        }

        private static int out_rate_tx = 48000;
        public static int OutRateTX
        {
            get { return out_rate_tx; }
            set
            {
                out_rate_tx = value;
                SetOutCountTX();
            }
        }

        private static void SetOutCount()
        {
            if (out_rate >= sample_rate1)
                OutCount = block_size1 * (out_rate / sample_rate1);
            else
                OutCount = block_size1 / (sample_rate1 / out_rate);
        }

        private static void SetOutCountRX2()
        {
            if (out_rate_rx2 >= sample_rate_rx2)
                OutCountRX2 = block_size_rx2 * (out_rate_rx2 / sample_rate_rx2);
            else
                OutCountRX2 = block_size_rx2 / (sample_rate_rx2 / out_rate_rx2);
        }

        private static void SetOutCountTX()
        {
            //if (out_rate_tx >= sample_rate_tx)
            //    OutCountTX = block_size1 * (out_rate_tx / sample_rate_tx);
            //else
            //    OutCountTX = block_size1 / (sample_rate_tx / out_rate_tx);

            //[2.10.3.4]MW0LGE changed to use tx block size
            if (out_rate_tx >= sample_rate_tx)
                OutCountTX = block_size_tx * (out_rate_tx / sample_rate_tx);
            else
                OutCountTX = block_size_tx / (sample_rate_tx / out_rate_tx);
        }

        private static int out_count = 1024;
        public static int OutCount
        {
            get { return out_count; }
            set
            {
                out_count = value;
            }
        }

        private static int out_count_rx2 = 1024;
        public static int OutCountRX2
        {
            get { return out_count_rx2; }
            set
            {
                out_count_rx2 = value;
            }
        }

        private static int out_count_tx = 1024;
        public static int OutCountTX
        {
            get { return out_count_tx; }
            set
            {
                out_count_tx = value;
            }
        }

        private static int _swap_iq_vac1 = 0;
        public static int VAC1SwapIQ
        {
            get { return _swap_iq_vac1; }
            set
            {
                _swap_iq_vac1 = value;
                ivac.SetIVACswapIQout(0, _swap_iq_vac1);
            }
        }
        private static int _swap_iq_vac2 = 0;
        public static int VAC2SwapIQ
        {
            get { return _swap_iq_vac2; }
            set
            {
                _swap_iq_vac2 = value;
                ivac.SetIVACswapIQout(1, _swap_iq_vac2);
            }
        }
        private static int _exclusive_out_vac1 = 0;
        public static int VAC1ExclusiveOut
        {
            get { return _exclusive_out_vac1; }
            set
            {
                _exclusive_out_vac1 = value;
                ivac.SetIVACExclusiveOut(0, _exclusive_out_vac1);
            }
        }
        private static int _exclusive_out_vac2 = 0;
        public static int VAC2ExclusiveOut
        {
            get { return _exclusive_out_vac2; }
            set
            {
                _exclusive_out_vac2 = value;
                ivac.SetIVACExclusiveOut(1, _exclusive_out_vac2);
            }
        }

        private static int _exclusive_in_vac1 = 0;
        public static int VAC1ExclusiveIn
        {
            get { return _exclusive_in_vac1; }
            set
            {
                _exclusive_in_vac1 = value;
                ivac.SetIVACExclusiveIn(0, _exclusive_in_vac1);
            }
        }
        private static int _exclusive_in_vac2 = 0;
        public static int VAC2ExclusiveIn
        {
            get { return _exclusive_in_vac2; }
            set
            {
                _exclusive_in_vac2 = value;
                ivac.SetIVACExclusiveIn(1, _exclusive_in_vac2);
            }
        }
        #endregion

        #region Callback Routines

        #endregion

        #region Misc Routines

        public static ArrayList GetPAHosts() // returns a text list of driver types
        {
            var a = new ArrayList();
            for (int i = 0; i < PA19.PA_GetHostApiCount(); i++)
            {
                PA19.PaHostApiInfo info = PA19.PA_GetHostApiInfo(i);
                a.Add(info.name);
            }
            //a.Add("HPSDR (USB/UDP)"); //[2.10.3.4]MW0LGE removed
            return a;
        }

        public static ArrayList GetPAInputDevices(int hostIndex)
        {
            var a = new ArrayList();

            if (hostIndex >= PA19.PA_GetHostApiCount())
            {
                //a.Add(new PADeviceInfo("HPSDR (PCM A/D)", 0)); //[2.10.3.4]MW0LGE removed
                return a;
            }

            PA19.PaHostApiInfo hostInfo = PA19.PA_GetHostApiInfo(hostIndex);
            for (int i = 0; i < hostInfo.deviceCount; i++)
            {
                int devIndex = PA19.PA_HostApiDeviceIndexToDeviceIndex(hostIndex, i);
                PA19.PaDeviceInfo devInfo = PA19.PA_GetDeviceInfo(devIndex);
                
                if (devInfo.maxInputChannels > 0)
                {
                    string name = devInfo.name;
                    int index = name.IndexOf("- ");
                    if (index > 0)
                    {
                        char c = name[index - 1]; // make sure this is what we're looking for
                        if (c >= '0' && c <= '9') // it is... remove index
                        {
                            int x = name.IndexOf("(");
                            name = devInfo.name.Substring(0, x + 1); // grab first part of string including "("
                            name += devInfo.name.Substring(index + 2, devInfo.name.Length - index - 2); // add end of string;
                        }
                    }
                    a.Add(new PADeviceInfo(name, i)/* + " - " + devIndex*/);
                }
            }
            return a;
        }

        public static bool CheckPAInputDevices(int hostIndex, string name)
        {
            PA19.PaHostApiInfo hostInfo = PA19.PA_GetHostApiInfo(hostIndex);
            for (int i = 0; i < hostInfo.deviceCount; i++)
            {
                int devIndex = PA19.PA_HostApiDeviceIndexToDeviceIndex(hostIndex, i);
                PA19.PaDeviceInfo devInfo = PA19.PA_GetDeviceInfo(devIndex);
                if (devInfo.maxInputChannels > 0 && devInfo.name.Contains(name))
                    return true;
            }
            return false;
        }

        public static ArrayList GetPAOutputDevices(int hostIndex)
        {
            var a = new ArrayList();

            if (hostIndex >= PA19.PA_GetHostApiCount())
            {
                //a.Add(new PADeviceInfo("HPSDR (PWM D/A)", 0)); //[2.10.3.4]MW0LGE removed
                return a;
            }

            PA19.PaHostApiInfo hostInfo = PA19.PA_GetHostApiInfo(hostIndex);
            for (int i = 0; i < hostInfo.deviceCount; i++)
            {
                int devIndex = PA19.PA_HostApiDeviceIndexToDeviceIndex(hostIndex, i);
                PA19.PaDeviceInfo devInfo = PA19.PA_GetDeviceInfo(devIndex);
                if (devInfo.maxOutputChannels > 0)
                {
                    string name = devInfo.name;
                    int index = name.IndexOf("- "); // find case for things like "Microphone (2- FLEX-1500)"
                    if (index > 0)
                    {
                        char c = name[index - 1]; // make sure this is what we're looking for
                        if (c >= '0' && c <= '9') // it is... remove index
                        {
                            int x = name.IndexOf("(");
                            name = devInfo.name.Substring(0, x + 1); // grab first part of string including "("
                            name += devInfo.name.Substring(index + 2, devInfo.name.Length - index - 2); // add end of string;
                        }
                    }
                    a.Add(new PADeviceInfo(name, i)/* + " - " + devIndex*/);
                }
            }
            return a;
        }


        public static bool CheckPAOutputDevices(int hostIndex, string name)
        {
            PA19.PaHostApiInfo hostInfo = PA19.PA_GetHostApiInfo(hostIndex);
            for (int i = 0; i < hostInfo.deviceCount; i++)
            {
                int devIndex = PA19.PA_HostApiDeviceIndexToDeviceIndex(hostIndex, i);
                PA19.PaDeviceInfo devInfo = PA19.PA_GetDeviceInfo(devIndex);
                if (devInfo.maxOutputChannels > 0 && devInfo.name.Contains(name))
                    return true;
            }
            return false;
        }

        //public static ArrayList GetPAHosts() // returns a text list of driver types
        //{
        //    var a = new ArrayList();

        //    foreach (var api in PortAudioHostApi.SupportedHostApis)
        //    {
        //        a.Add(api.Name);
        //    }
        //    a.Add("HPSDR (USB/UDP)");
        //    return a;
        //}

        //public static ArrayList GetPAInputDevices(int hostIndex)
        //{
        //    var a = new ArrayList();


        //    if (hostIndex >= PortAudioHostApi.SupportedHostApis.Count())
        //    {
        //        a.Add(new PADeviceInfo("HPSDR (PCM A/D)", 0));               
        //        return a;
        //    }

        //    var hst = PortAudioHostApi.SupportedHostApis.ElementAt(hostIndex);         
        //    int idx = 0;
        //        foreach (var dev in hst.Devices)
        //        {
        //            if (dev.MaxInputChannels > 0)
        //            {
        //                string name = dev.Name;
        //                int index = name.IndexOf("- ");
        //                if (index > 0)
        //                {
        //                    char c = name[index - 1]; // make sure this is what we're looking for
        //                    if (c >= '0' && c <= '9') // it is... remove index
        //                    {
        //                        int x = name.IndexOf("(");
        //                        name = dev.Name.Substring(0, x + 1); // grab first part of string including "("
        //                        name += dev.Name.Substring(index + 2, dev.Name.Length - index - 2); // add end of string;
        //                    }
        //                }
        //                a.Add(new PADeviceInfo(name, idx));
        //            idx++;
        //            }
        //        }

        //    return a;
        //}

        //public static ArrayList GetPAOutputDevices(int hostIndex)
        //{
        //    var a = new ArrayList();

        //    if (hostIndex >= PortAudioHostApi.SupportedHostApis.Count())
        //    {
        //        a.Add(new PADeviceInfo("HPSDR (PWM D/A)", 0));
        //        return a;
        //    }

        //    var hst = PortAudioHostApi.SupportedHostApis.ElementAt(hostIndex);       
        //    int idx = 0;
        //        foreach (var dev in hst.Devices)
        //        {
        //            if (dev.MaxOutputChannels > 0)
        //            {
        //                string name = dev.Name;
        //                int index = name.IndexOf("- ");
        //                if (index > 0)
        //                {
        //                    char c = name[index - 1]; // make sure this is what we're looking for
        //                    if (c >= '0' && c <= '9') // it is... remove index
        //                    {
        //                        int x = name.IndexOf("(");
        //                        name = dev.Name.Substring(0, x + 1); // grab first part of string including "("
        //                        name += dev.Name.Substring(index + 2, dev.Name.Length - index - 2); // add end of string;
        //                    }
        //                }
        //                a.Add(new PADeviceInfo(name, idx));
        //                idx++;
        //            }
        //        }

        //    return a;
        //}

        public static void EnableVAC1(bool enable)
        {
            bool retval = false;
 
            if (enable)
                unsafe
                {
                    int num_chan = 1;
                    int sample_rate = sample_rate2;
                    int block_size = block_size_vac;
                    double in_latency = vac1_latency_manual ? latency2 / 1000.0 : PA19.PA_GetDeviceInfo(input_dev2).defaultLowInputLatency;
                    double out_latency = vac1_latency_manual_out ? latency2_out / 1000.0 : PA19.PA_GetDeviceInfo(output_dev2).defaultLowOutputLatency;
                    double pa_in_latency = vac1_latency_pa_in_manual ? latency_pa_in / 1000.0 : PA19.PA_GetDeviceInfo(input_dev2).defaultLowInputLatency;
                    double pa_out_latency = vac1_latency_pa_out_manual ? latency_pa_out / 1000.0 : PA19.PA_GetDeviceInfo(output_dev2).defaultLowOutputLatency;
                  //  double pa_out_latency = vac1_latency_pa_out_manual ? latency_pa_out / 1000.0 : outp_dev2.;

                    if (vac_output_iq)
                    {
                        num_chan = 2;
                        sample_rate = sample_rate1;
                        block_size = block_size1;
                    }
                    else if (vac_stereo) num_chan = 2;

                    VACRBReset = true;

                    ivac.SetIVAChostAPIindex(0, host2);
                    ivac.SetIVACinputDEVindex(0, input_dev2);
                    ivac.SetIVACoutputDEVindex(0, output_dev2);
                    ivac.SetIVACnumChannels(0, num_chan);
                    ivac.SetIVACInLatency(0, in_latency, 0);
                    ivac.SetIVACOutLatency(0, out_latency, 0);
                    ivac.SetIVACPAInLatency(0, pa_in_latency, 0);
                    ivac.SetIVACPAOutLatency(0, pa_out_latency, 1);

                    // MW0LGE_21h
                    ivac.SetIVACFeedbackGain(0, 0, vac1_feedbackgainOut);
                    ivac.SetIVACFeedbackGain(0, 1, vac1_feedbackgainIn);
                    ivac.SetIVACSlewTime(0, 0, vac1_slewtimeOut);
                    ivac.SetIVACSlewTime(0, 1, vac1_slewtimeIn);
                    //

                    // MW0LGE_21j
                    ivac.SetIVACPropRingMin(0, 0, vac1_prop_ringminOut);
                    ivac.SetIVACPropRingMin(0, 1, vac1_prop_ringminIn);
                    ivac.SetIVACPropRingMax(0, 0, vac1_prop_ringmaxOut);
                    ivac.SetIVACPropRingMax(0, 1, vac1_prop_ringmaxIn);
                    ivac.SetIVACFFRingMin(0, 0, vac1_ff_ringminOut);
                    ivac.SetIVACFFRingMin(0, 1, vac1_ff_ringminIn);
                    ivac.SetIVACFFRingMax(0, 0, vac1_ff_ringmaxOut);
                    ivac.SetIVACFFRingMax(0, 1, vac1_ff_ringmaxIn);
                    ivac.SetIVACFFAlpha(0, 0, vac1_ff_alphaOut);
                    ivac.SetIVACFFAlpha(0, 1, vac1_ff_alphaIn);
                    ivac.SetIVACswapIQout(0, _swap_iq_vac1);
                    //ivac.SetIVACvar(0, 0, vac1_oldVarOut);
                    //ivac.SetIVACvar(0, 1, vac1_oldVarIn);
                    ivac.SetIVACinitialVars(0, vac1_oldVarIn, vac1_oldVarOut);
                    //

                    try
                    {
                        retval = ivac.StartAudioIVAC(0) == 1;
                        if (retval && console.PowerOn)
                            ivac.SetIVACrun(0, 1);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("The program is having trouble starting the VAC audio streams.\n" +
                            "Please examine the VAC related settings on the Setup Form -> Audio Tab and try again.",
                            "VAC Audio Stream Startup Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            else
            {
                ivac.SetIVACrun(0, 0);
                ivac.StopAudioIVAC(0);
            }
            Thread.Sleep(10); // prevent ASIO exception
        }

        public static void EnableVAC2(bool enable)
        {
            bool retval = false;

            if (enable)
                unsafe
                {
                    int num_chan = 1;
                    int sample_rate = sample_rate3;
                    int block_size = block_size_vac2;

                    double in_latency = vac2_latency_manual ? latency3 / 1000.0 : PA19.PA_GetDeviceInfo(input_dev3).defaultLowInputLatency;
                    double out_latency = vac2_latency_out_manual ? vac2_latency_out / 1000.0 : PA19.PA_GetDeviceInfo(output_dev3).defaultLowOutputLatency;
                    double pa_in_latency = vac2_latency_pa_in_manual ? vac2_latency_pa_in / 1000.0 : PA19.PA_GetDeviceInfo(input_dev3).defaultLowInputLatency;
                    double pa_out_latency = vac2_latency_pa_out_manual ? vac2_latency_pa_out / 1000.0 : PA19.PA_GetDeviceInfo(output_dev3).defaultLowOutputLatency;

                    if (vac2_output_iq)
                    {
                        num_chan = 2;
                        sample_rate = sample_rate_rx2;
                        block_size = block_size_rx2;
                    }
                    else if (vac2_stereo) num_chan = 2;

                    VAC2RBReset = true;

                    ivac.SetIVAChostAPIindex(1, host3);
                    ivac.SetIVACinputDEVindex(1, input_dev3);
                    ivac.SetIVACoutputDEVindex(1, output_dev3);
                    ivac.SetIVACnumChannels(1, num_chan);
                    ivac.SetIVACInLatency(1, in_latency, 0);
                    ivac.SetIVACOutLatency(1, out_latency, 0);
                    ivac.SetIVACPAInLatency(1, pa_in_latency, 0);
                    ivac.SetIVACPAOutLatency(1, pa_out_latency, 1);

                    // MW0LGE_21h
                    ivac.SetIVACFeedbackGain(1, 0, vac2_feedbackgainOut);
                    ivac.SetIVACFeedbackGain(1, 1, vac2_feedbackgainIn);
                    ivac.SetIVACSlewTime(1, 0, vac2_slewtimeOut);
                    ivac.SetIVACSlewTime(1, 1, vac2_slewtimeIn);
                    //

                    // MW0LGE_21j
                    ivac.SetIVACPropRingMin(1, 0, vac2_prop_ringminOut);
                    ivac.SetIVACPropRingMin(1, 1, vac2_prop_ringminIn);
                    ivac.SetIVACPropRingMax(1, 0, vac2_prop_ringmaxOut);
                    ivac.SetIVACPropRingMax(1, 1, vac2_prop_ringmaxIn);
                    ivac.SetIVACFFRingMin(1, 0, vac2_ff_ringminOut);
                    ivac.SetIVACFFRingMin(1, 1, vac2_ff_ringminIn);
                    ivac.SetIVACFFRingMax(1, 0, vac2_ff_ringmaxOut);
                    ivac.SetIVACFFRingMax(1, 1, vac2_ff_ringmaxIn);
                    ivac.SetIVACFFAlpha(1, 0, vac2_ff_alphaOut);
                    ivac.SetIVACFFAlpha(1, 1, vac2_ff_alphaIn);
                    ivac.SetIVACswapIQout(1, _swap_iq_vac2);
                    //ivac.SetIVACvar(1, 0, vac2_oldVarOut);
                    //ivac.SetIVACvar(1, 1, vac2_oldVarIn);
                    ivac.SetIVACinitialVars(1, vac2_oldVarIn, vac2_oldVarOut);
                    //

                    try
                    {
                        retval = ivac.StartAudioIVAC(1) == 1;
                        if (retval && console.PowerOn)
                            ivac.SetIVACrun(1, 1);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("The program is having trouble starting the VAC audio streams.\n" +
                            "Please examine the VAC related settings on the Setup Form -> Audio Tab and try again.",
                            "VAC2 Audio Stream Startup Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            else
            {
                ivac.SetIVACrun(1, 0);
                ivac.StopAudioIVAC(1);                
            }
            Thread.Sleep(10); // prevent ASIO exception
        }

        private static RadioProtocol _lastRadioProtocol = RadioProtocol.None;
        public static RadioProtocol LastRadioProtocol
        {
            get { return _lastRadioProtocol; }
            set 
            {
                _lastRadioProtocol = value; 
            }
        }
        private static HPSDRHW _lastRadiohadware = HPSDRHW.Unknown;
        public static HPSDRHW LastRadioHardware
        {
            get { return _lastRadiohadware; }
            set
            {
                _lastRadiohadware = value;
            }
        }
        public static bool Start()
        {
            //RadioProtocol oldProto = NetworkIO.CurrentRadioProtocol;

            bool retval = false;
            int rc;
            phase_buf_l = new float[2048];
            phase_buf_r = new float[2048];
            Console c = Console.getConsole();
            rc = NetworkIO.initRadio();

            if (rc != 0)
            {
                if (rc == -101) // firmware version error; 
                {
                    string fw_err = NetworkIO.getFWVersionErrorMsg();
                    if (fw_err == null)
                    {
                        fw_err = "Bad Firmware levels";
                    }
                    MessageBox.Show(fw_err, "Firmware Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    MessageBox.Show("Error starting SDR hardware, is it connected and powered?", "Network Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }
            }

            // add setup calls that are needed to change between P1 & P2 before startup
            if (NetworkIO.CurrentRadioProtocol == RadioProtocol.USB)
            {
                console.SampleRateTX = 48000; // set tx audio sampling rate  
                WDSP.SetTXACFIRRun(cmaster.chid(cmaster.inid(1, 0), 0), false);
                //puresignal.SetPSHWPeak(cmaster.chid(cmaster.inid(1, 0), 0), 0.4072);
                //console.psform.PSdefpeak = "0.4072"; //MW0LGE_21k9rc5 moved to psform.SetDefaultPeaks(), called below
            }
            else
            {
                console.SampleRateTX = 192000;
                WDSP.SetTXACFIRRun(cmaster.chid(cmaster.inid(1, 0), 0), true);
                //if(console.CurrentHPSDRHardware == HPSDRHW.Saturn)                              // G8NJJ  // MW0LGE note, we do this below by calling SetDefaultPeaks if needed
                //    puresignal.SetPSHWPeak(cmaster.chid(cmaster.inid(1, 0), 0), 0.6121);
                //else
                //    puresignal.SetPSHWPeak(cmaster.chid(cmaster.inid(1, 0), 0), 0.2899);
                //console.psform.PSdefpeak = "0.2899"; //moved to psform.SetDefaultPeaks(), called below
            }

            //console.psform.SetDefaultPeaks(NetworkIO.CurrentRadioProtocol != oldProto); // if the procol changed, force it MW0LGE_21k9rc6
            ////MW0LGE [2.9.0.8] fix if protocol is changed at some point
            //
            //note: setdefaultpeaks will only be called if fresh DB, or if at some point the protcol changes ie user has flashed the radio with different protocol
            //we dont recover or assign here as psform stores the peak data in the form save/close. Those values can be tweaked by end user and are store/recovered
            //against the form. This is to enable the reset of peaks for a new install or new protocol
            bool bSetDefaultPeaks = false;
            if (LastRadioHardware == HPSDRHW.Unknown || (LastRadioHardware != HPSDRHW.Unknown && LastRadioHardware != NetworkIO.BoardID))
            {
                bSetDefaultPeaks = true;
                LastRadioHardware = NetworkIO.BoardID; // saved in db
            }

            if (LastRadioProtocol == RadioProtocol.None || (LastRadioProtocol != RadioProtocol.None && LastRadioProtocol != NetworkIO.CurrentRadioProtocol))
            {
                bSetDefaultPeaks = true;                
                LastRadioProtocol = NetworkIO.CurrentRadioProtocol; // saved in db
            }
            if(bSetDefaultPeaks) console.psform.SetDefaultPeaks(); // if false, will use the psform recovered values

            c.SetupForm.InitAudioTab();
            c.SetupForm.ForceAudioReset();
            cmaster.PSLoopback = cmaster.PSLoopback;

            int result = NetworkIO.StartAudioNative();
            if (result == 0) retval = true;

            return retval;
        }

        //        private static void PortAudioErrorMessageBox(PaErrorCode error)
        //       {
        //            if (error < PaErrorCode.NoError) throw PortAudioException.GetException(error);
        //             switch (error)
        //             {
        //                 case PaErrorCode.InvalidDevice:
        //                     string s = "Whoops!  Looks like something has gone wrong in the\n" +
        //                         "Audio section.  Go look in the Setup Form -> Audio Tab to\n" +
        //                         "verify the settings there.";
        //                     if (vac_enabled) s += "  Since VAC is enabled, make sure\n" +
        //                          "you look at those settings as well.";
        //                     MessageBox.Show(s, "Audio Subsystem Error: Invalid Device",
        //                         MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                     break;
        //                 default:
        //                     MessageBox.Show(PortAudio.Pa_GetErrorText(error), "PortAudio Error: " + error,
        //                         MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                     break;
        //             }
        //        }

        #endregion

        #region Scope Stuff

        private static int m_nScope_pixel_width = 0;
        private static int m_nScope_time = 10000;
        private static int m_nScope_samples_per_pixel = 10000;
        private static int m_nScope_samples_per_pixel_tx = 10000;
        private static readonly object m_objScope_width_lock = new object();
        public static int ScopePixelWidth
        {
            set 
            {
                bool bUpdate = false;
                lock (m_objScope_width_lock)
                {
                    bUpdate = value != m_nScope_pixel_width;
                    m_nScope_pixel_width = value;
                }
                if (bUpdate)
                    ScopeTime = m_nScope_time; // force update if different
            }
        }

        public static int ScopeTime //[2.10.3.5]MW0LGE resolves #338
        {
            get { return m_nScope_time; }
            set 
            {
                m_nScope_time = value;

                double fWidth = 0;
                lock (m_objScope_width_lock)
                {
                    fWidth = m_nScope_pixel_width;
                }

                //scope_samples_per_pixel = (int)((double)scope_time * Audio.OutRate / 1000000.0);
                //scope_samples_per_pixel_tx = (int)((double)scope_time * Audio.OutRateTX / 1000000.0);

                //scope_time is the time taken to cover the display width, the above does not caclulate this correctly
                //changed to ms instead of us
                double fSamples_in_one_interval = Audio.OutRate / 1000.0;// 1000000.0;
                double fSamples_needed = fSamples_in_one_interval * m_nScope_time;
                m_nScope_samples_per_pixel = (int)(fSamples_needed / fWidth);

                fSamples_in_one_interval = Audio.OutRateTX / 1000.0;// 1000000.0;
                fSamples_needed = fSamples_in_one_interval * m_nScope_time;
                m_nScope_samples_per_pixel_tx = (int)(fSamples_needed / fWidth);

                //Debug.Print($"{m_nScope_samples_per_pixel} tx = {m_nScope_samples_per_pixel_tx}");
            }
        }

        private static int scope_array_len = 0;
        private static int scope_sample_index = 0;
        private static int scope_pixel_index = 0;
        private static float scope_pixel_min = float.MaxValue;
        private static float scope_pixel_max = float.MinValue;
        private static float[] scope_min;

        private static readonly Object m_objArrayLock = new Object();        //MW0LGE_21k9 lock needed as display can change the size of these arrays, and being in a different thread will cause issues otherwise
        public static float[] ScopeMin
        {
            set {
                lock (m_objArrayLock)
                {
                    scope_min = value;
                    scope_pixel_index = 0; // MW0LGE_21k9

                    int nMin = scope_min != null ? scope_min.Length : 0;
                    int nMax = scope_max != null ? scope_max.Length : 0;

                    scope_array_len = Math.Min(nMin, nMax);
                }
            }
        }

        public static float[] scope_max;

        public static float[] ScopeMax
        {
            set {
                lock (m_objArrayLock)
                {
                    scope_max = value;
                    scope_pixel_index = 0; // MW0LGE_21k9

                    int nMin = scope_min != null ? scope_min.Length : 0;
                    int nMax = scope_max != null ? scope_max.Length : 0;

                    scope_array_len = Math.Min(nMin, nMax);
                }
            }
        }

        unsafe public static void DoScope(float* buf, int frameCount)
        {
            lock (m_objArrayLock)
            {
                //if (scope_min == null || scope_min.Length < scope_display_width)
                //{
                //    if (Display.ScopeMin == null || Display.ScopeMin.Length < scope_display_width)
                //        Display.ScopeMin = new float[scope_display_width];
                //    scope_min = Display.ScopeMin;
                //}
                //if (scope_max == null || scope_max.Length < scope_display_width)
                //{
                //    if (Display.ScopeMax == null || Display.ScopeMax.Length < scope_display_width)
                //        Display.ScopeMax = new float[scope_display_width];
                //    scope_max = Display.ScopeMax;
                //}
                if (scope_min == null || scope_max == null) return;

                int scope_samples_per_pixel_local = !mox ? m_nScope_samples_per_pixel : m_nScope_samples_per_pixel_tx; //[2.10.3.5]MW0LGE added

                for (int i = 0; i < frameCount; i++)
                {
                    if (Display.CurrentDisplayMode == DisplayMode.SCOPE || //MW0LGE added all other scope modes
                        Display.CurrentDisplayMode == DisplayMode.SCOPE2 || //MW0LGE_21g
                        Display.CurrentDisplayMode == DisplayMode.PANASCOPE ||
                        Display.CurrentDisplayMode == DisplayMode.SPECTRASCOPE)
                    {
                        if (buf[i] < scope_pixel_min)
                            scope_pixel_min = buf[i];
                        if (buf[i] > scope_pixel_max)
                            scope_pixel_max = buf[i];
                    }
                    else
                    {
                        scope_pixel_min = buf[i];
                        scope_pixel_max = buf[i];
                    }                    

                    scope_sample_index++;
                    if (scope_sample_index >= scope_samples_per_pixel_local)
                    {
                        scope_sample_index = 0;
                        scope_min[scope_pixel_index] = scope_pixel_min;
                        scope_max[scope_pixel_index] = scope_pixel_max;

                        scope_pixel_min = float.MaxValue;
                        scope_pixel_max = float.MinValue;

                        scope_pixel_index++;
                        if (scope_pixel_index >= scope_array_len)
                            scope_pixel_index = 0;
                    }
                }
            }
        }

        #endregion

        #region Scope2 Stuff

        private static int scope2_sample_index = 0;
        private static int scope2_pixel_index = 0;
        private static float scope2_pixel_min = float.MaxValue;
        private static float scope2_pixel_max = float.MinValue;
        public static float[] scope2_max;
        private static float[] scope2_min;

        public static float[] Scope2Max
        {
            set {
                lock (m_objArrayLock)
                {
                    scope2_max = value;
                    scope2_pixel_index = 0; //MW0LGE_21k9

                    int nMin = scope2_min != null ? scope2_min.Length : 0;
                    int nMax = scope2_max != null ? scope2_max.Length : 0;

                    scope_array_len = Math.Min(nMin, nMax);
                }
            }
        }
        public static float[] Scope2Min
        {
            set {
                lock (m_objArrayLock)
                {
                    scope2_min = value;
                    scope2_pixel_index = 0; //MW0LGE_21k9

                    int nMin = scope2_min != null ? scope2_min.Length : 0;
                    int nMax = scope2_max != null ? scope2_max.Length : 0;

                    scope_array_len = Math.Min(nMin, nMax);
                }
            }
        }

        unsafe public static void DoScope2(float* buf, int frameCount)
        {
            lock (m_objArrayLock)
            {
                //if (scope2_min == null || scope2_min.Length < scope_display_width)
                //{
                //    if (Display.Scope2Min == null || Display.Scope2Min.Length < scope_display_width)
                //        Display.Scope2Min = new float[scope_display_width];
                //    scope2_min = Display.Scope2Min;
                //}
                //if (scope2_max == null || scope2_max.Length < scope_display_width)
                //{
                //    if (Display.Scope2Max == null || Display.Scope2Max.Length < scope_display_width)
                //        Display.Scope2Max = new float[scope_display_width];
                //    scope2_max = Display.Scope2Max;
                //}
                if (scope2_min == null || scope2_max == null) return;

                int scope_samples_per_pixel_local = !mox ? m_nScope_samples_per_pixel : m_nScope_samples_per_pixel_tx; //[2.10.3.5]MW0LGE added

                for (int i = 0; i < frameCount; i++)
                {
                    if (Display.CurrentDisplayMode == DisplayMode.SCOPE ||
                        Display.CurrentDisplayMode == DisplayMode.SCOPE2 || //MW0LGE_21g
                        Display.CurrentDisplayMode == DisplayMode.PANASCOPE ||
                        Display.CurrentDisplayMode == DisplayMode.SPECTRASCOPE)
                    {
                        if (buf[i] < scope2_pixel_min)
                            scope2_pixel_min = buf[i];
                        if (buf[i] > scope2_pixel_max)
                            scope2_pixel_max = buf[i];
                    }
                    else
                    {
                        scope2_pixel_min = buf[i];
                        scope2_pixel_max = buf[i];
                    }

                    scope2_sample_index++;
                    if (scope2_sample_index >= scope_samples_per_pixel_local)
                    {
                        scope2_sample_index = 0;
                        scope2_min[scope2_pixel_index] = scope2_pixel_min;  //MW0LGE_21g  fix .. was scope_pixel_index
                        scope2_max[scope2_pixel_index] = scope2_pixel_max;

                        scope2_pixel_min = float.MaxValue;
                        scope2_pixel_max = float.MinValue;

                        scope2_pixel_index++;
                        if (scope2_pixel_index >= scope_array_len)
                            scope2_pixel_index = 0;
                    }
                }
            }
        }

        #endregion

    }
}