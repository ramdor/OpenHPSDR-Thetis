using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;

namespace Thetis
{
    public partial class Console : Form
    {
        // G8NJJ: handlers for ARIES ATU
        #region ARIES ATU functions

        private bool AriesTuneState = false;                    // ATU tune state; true if solution available
        private bool AriesEnabled = false;                      // true if ARIES ATU function enabled
        private int AriesAntenna = 0;                           // antenna that Aries has been told to tune for
        private int AriesRXAntenna = 0;                         // RX antenna that Aries has been told to set
        private int TXAntennaSent = -1;                         // antenna in use for TX
        private string RXAntennaSentString = "none";            // antenna in use for RX

        // array of ints to store TX antenna vs band
        // initialised to antenna 1; setup form sends updates when it loads for any antennas on 2 or 3
        private const int ARIESANTARRAYSIZE = 12;
        private int[] AntennaArrayByBand = new int[ARIESANTARRAYSIZE] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };       // 0 if unknown, else 1 2 or 3
        // array of ints to store RX antenna vs band
        // initialised to antenna 1; setup form sends updates when it loads for any antennas on 2 or 3
        private int[] RXAntennaArrayByBand = new int[ARIESANTARRAYSIZE] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };       // 0 if unknown, else 1 2 or 3
        private bool[] RXAuxAntennaArrayByBand = new bool[ARIESANTARRAYSIZE] { false, false, false, false, false, false, false, false, false, false, false, false };       // true if an aux antenna selected
        private string[] RXAntennaNameArrayByBand = new string[ARIESANTARRAYSIZE] { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" };       // true if an aux antenna selected


        // set the ATU display label appropriately
        private void UpdateAriesDisplayLabel()
        {
            if (!AriesEnabled)                  // ATU disabled - no display
            {
                lblATUTuneLabel.Visible = false;
            }
            else if (AriesTuneState)                 // ATU enabled and tuned
            {
                lblATUTuneLabel.Visible = true;
                lblATUTuneLabel.BackColor = System.Drawing.Color.Blue;
                lblATUTuneLabel.Text = "ATU Tuned";
            }
            else                                // ATU enabled but no tune solution
            {
                lblATUTuneLabel.Visible = true;
                lblATUTuneLabel.BackColor = System.Drawing.Color.Transparent;
                lblATUTuneLabel.Text = "ATU -----";
            }

        }


        // handle a CAT ZZOX tune status message from ATU
        public void CATHandleAriesTuneMessage(bool TuneState)
        {
            AriesTuneState = TuneState;
            UpdateAriesDisplayLabel();
        }

        // handle a CAT ZZOZ erase status message from ATU
        public void CATHandleAriesEraseMessage(bool EraseState)
        {
            string EraseString = "Erase FAIL";
            if (EraseState == true)
                EraseString = "Erase Complete";
            SetupForm.AriesEraseStatus = EraseString;
        }

        // send a CAT message to Aries asking for h/w and s/w versions
        private void MakeAriesVersionRequestMsg()
        {
            string CATMsg;

            CATMsg = "ZZZS;";
            if (AriesCATEnabled)
            {
                try
                {
                    AriesSiolisten.SIO6.put(CATMsg);
                }
                catch { }
            }
        }

        // send CAT message to Aries to set the Tune on/off state
        private void MakeAriesTuneRequestMsg(bool IsTune)
        {
            string CATMsg = "ZZTU0;";               // default no tune
            if (IsTune)
                CATMsg = "ZZTU1;";                  // message if tune is active
            if (AriesCATEnabled)
            {
                try
                {
                    AriesSiolisten.SIO6.put(CATMsg);
                }
                catch { }
            }
        }

        // send CAT message to Aries to set the TX antenna
        // set the "Aries is in this state" variable only if the message is sent
        private void MakeAriesAntennaChangeMsg(int Ant)
        {
            string CATMsg = "";
            if ((Ant >= 0) && (Ant <= 3))
            {
                CATMsg = "ZZOC" + Ant + ";";
                if (AriesCATEnabled)
                {
                    try
                    {
                        AriesSiolisten.SIO6.put(CATMsg);
                        AriesAntenna = Ant;
                    }
                    catch { }
                }
            }
        }

        // send CAT message to Aries to set the RX antenna
        // set the "Aries is in this state" variable only if the message is sent
        private void MakeAriesRXAntennaChangeMsg(int Ant)
        {
            string CATMsg = "";
            if ((Ant >= 0) && (Ant <= 3))
            {
                CATMsg = "ZZOA" + Ant + ";";
                if (AriesCATEnabled)
                {
                    try
                    {
                        AriesSiolisten.SIO6.put(CATMsg);
                        AriesRXAntenna = Ant;
                    }
                    catch { }
                }
            }
        }

        // send CAT message to Aries to set the ATU on/off state
        // set the "Aries is in this state" variable only if the message is sent
        private void MakeAriesATUEnableRequestMsg(bool IsEnabled)
        {
            string CATMsg = "ZZOV0;";               // default no tune
            if (IsEnabled)
                CATMsg = "ZZOV1;";                  // message if tune is active
            if (AriesCATEnabled)
            {
                try
                {
                    AriesSiolisten.SIO6.put(CATMsg);
                    AriesEnabled = IsEnabled;
                }
                catch { }
            }
        }

        // send CAT message to Aries to set the tune algorithm tweak
        private void MakeAriesQuickTuneRequestMsg(bool IsEnabled)
        {
            string CATMsg = "ZZOY0;";               // default no tune
            if (IsEnabled)
                CATMsg = "ZZOY1;";                  // message if tune is active
            if (AriesCATEnabled)
            {
                try
                {
                    AriesSiolisten.SIO6.put(CATMsg);
                }
                catch { }
            }
        }

        // send a CAT message to Aries to erase stored solutions for an antenna
        public void AriesErasePressed(int Channel)
        {
            string CATMsg;

            CATMsg = "ZZOZ" + Channel + ";";
            if (AriesCATEnabled)
            {
                SetupForm.AriesEraseStatus = "Erase in progress for ANT " + Channel;
                try
                {
                    AriesSiolisten.SIO6.put(CATMsg);
                }
                catch { }
            }
        }

        // 3 properties to set the state of the "ATU enabled" buttons - one for each TX antenna
        private bool aries_ant1_enabled;
        public bool AriesANT1Enabled
        {
            set
            {
                aries_ant1_enabled = value;
                CheckAriesEnabled();
                UpdateAriesDisplayLabel();
            }

            get { return aries_ant1_enabled; }
        }

        private bool aries_ant2_enabled;
        public bool AriesANT2Enabled
        {
            set
            {
                aries_ant2_enabled = value;
                CheckAriesEnabled();
                UpdateAriesDisplayLabel();
            }

            get { return aries_ant2_enabled; }
        }

        private bool aries_ant3_enabled;
        public bool AriesANT3Enabled
        {
            set
            {
                aries_ant3_enabled = value;
                CheckAriesEnabled();
                UpdateAriesDisplayLabel();
            }

            get { return aries_ant3_enabled; }
        }

        // 2 properties to set the state of Alex ant 2/3 "do not TX"
        // G8NJJ_21h
        private bool alex_ant2_rxonly;
        public bool AlexANT2RXOnly

        {

            set { alex_ant2_rxonly = value; }

            get { return alex_ant2_rxonly; }

        }
        private bool alex_ant3_rxonly;
        public bool AlexANT3RXOnly

        {

            set { alex_ant3_rxonly = value; }

            get { return alex_ant3_rxonly; }

        }

        // AriesStandalone
        private bool aries_standalone;
        public bool AriesStandalone
        {
            set
            {
                aries_standalone = value;
                if(AriesCATEnabled)
                    SetAriesAlexMode(value);
            }

            get { return aries_standalone; }
        }

        // property to set the state of the "quick tune enabled" button
        private bool aries_quicktune_enabled;
        public bool AriesQuickTuneEnabled
        {
            set
            {
                aries_quicktune_enabled = value;
                MakeAriesQuickTuneRequestMsg(value);
            }

            get { return aries_quicktune_enabled; }
        }


        private double AriesReportedFrequency_10KHz = 0.0;          // tuned freq, in 10KHz chunks
        // function to check whether a new TX frequency needs to be signaled to Aries
        // find out if frequency has moved by more than 10KHz and send mew message if so
        private void SetAriesTXFrequency(double NewFrequency)
        {
            double Frequency_10KHz = Math.Truncate(NewFrequency * 100.0);              // freq in 10KHz chunks
            string CATMsg;
            string freq;

            if (Math.Abs(Frequency_10KHz - AriesReportedFrequency_10KHz) != 0)
            {
                AriesReportedFrequency_10KHz = Frequency_10KHz;
                AriesTuneState = false;                                                 // set to "no tune solution" till Aries sends a CAT message
                Frequency_10KHz /= 100.0;
                freq = Frequency_10KHz.ToString("f6");
                CATMsg = "ZZFT" + freq.Replace(separator, "").PadLeft(11, '0') + ";";
                if (AriesCATEnabled)
                {
                    try
                    {
                        AriesSiolisten.SIO6.put(CATMsg);
                    }
                    catch { }
                }
                CheckAriesEnabled();
                UpdateAriesDisplayLabel();
            }
        }


        // function to set the TX antenna for a given band
        // this is called when an antenna control changes in setup.
        // Antenna = 1,2 or 3
        public void SetAriesTXAntenna(int Antenna, Band band)
        {
            if (Antenna == 0)
                Antenna = 1;
            int idx = (int)band - (int)Band.B160M;
            if (idx < ARIESANTARRAYSIZE)
                AntennaArrayByBand[idx] = Antenna;

            if (AriesCATEnabled)
            {
                CheckAriesEnabled();
                UpdateAriesDisplayLabel();
            }
            DisplayAriesTXAntenna();
            SendAriesRXAntennaMsg();                                // check this in case we are RXing on TX antenna
        }

        // function to set the RX antenna for a given band
        // this is called when an antenna control changes in setup.
        // Antenna = 1,2 or 3
        public void SetAriesRXAntenna(int Antenna, Band band)
        {
            if (Antenna == 0)
                Antenna = 1;
            int idx = (int)band - (int)Band.B160M;
            if (idx < ARIESANTARRAYSIZE)
                RXAntennaArrayByBand[idx] = Antenna;
            DisplayAriesRXAntenna();
        }

        // function to set the RX antenna name as a string for a given band
        // this is called when an antenna control changes in setup.
        // Antenna = a radio dependent string for check box selections Note that several can be selected!
        public void SetAriesRXAntennaName(string Antenna, Band band)
        {
            int idx = (int)band - (int)Band.B160M;
            if (idx < ARIESANTARRAYSIZE)
                RXAntennaNameArrayByBand[idx] = Antenna;

            DisplayAriesRXAntenna();
        }



        // function to set whether an aux input is selected as RX antenna for a given band
        // this is called when an antenna control changes in setup.
        // parameter true if aux input (ext1, ext2, xvtr) selected
        public void SetAriesRXAuxAntenna(bool IsAux, Band band)
        {
            int idx = (int)band - (int)Band.B160M;
            if (idx < ARIESANTARRAYSIZE)
                RXAuxAntennaArrayByBand[idx] = IsAux;
            DisplayAriesRXAntenna();
        }


        // function to tell Aries that TUNE is active 
        // at the moment, it just sends a CAT message
        private void SetAriesTuneState(bool IsTune)
        {
            MakeAriesTuneRequestMsg(IsTune);
        }



        // helper to find nearest band, if we are out of an amateur band. Same logic as Alex.
        public Band AntennaBandFromFreq(bool IsTX)
        {
            Band result;

            double freq = 0.0;

            if (RX1XVTRIndex >= 0)
                freq = XVTRForm.TranslateFreq(freq);
            else
            {
                // really should check TX freq, in case it is a split frequency
                freq = VFOAFreq;
            }

            // now find nearest "real" band
            if (freq >= 12.075)
            {
                if (freq >= 23.17)
                {
                    if (freq >= 26.465)
                    {
                        result = freq >= 39.85 ? Band.B6M : Band.B10M;
                    }
                    else /* >23.17  <26.465 */
                    {
                        result = Band.B12M;
                    }
                }
                else  /* >12.075  <23.17 */
                {
                    if (freq >= 16.209)
                    {
                        result = freq >= 19.584 ? Band.B15M : Band.B17M;
                    }
                    else
                    {
                        result = Band.B20M;
                    }
                }
            }
            else  /* < 12.075 */
            {
                if (freq >= 6.20175)
                {
                    result = freq >= 8.7 ? Band.B30M : Band.B40M;
                }
                else
                {
                    if (freq >= 4.66525)
                    {
                        result = Band.B60M;
                    }
                    else
                    {
                        result = freq >= 2.75 ? Band.B80M : Band.B160M;
                    }
                }
            }
            return result;
        }


        // show the TX antenna on the Andromeda screen
        private void DisplayAriesTXAntenna()
        {
            Band CurrentBand;
            int Antenna;

            CurrentBand = TXBand;
            // see if we are in an amateur band; if not lookup using Alex function
            if ((CurrentBand < Band.B160M) || (CurrentBand > Band.B6M))
                CurrentBand = AntennaBandFromFreq(true);

            int idx = (int)CurrentBand - (int)Band.B160M;
            if ((idx < ARIESANTARRAYSIZE) && (idx >= 0))
            {
                Antenna = AntennaArrayByBand[idx];
                if(Antenna != TXAntennaSent)
                {
                    toolStripStatusLabelTXAnt.Text = "Tx Ant " + Antenna.ToString();
                    TXAntennaSent = Antenna;
                }
            }
        }


        //
        // send an Aries RX antenna message
        // has to work out the band, and it could be TX antenna if the "RX on TX antenna" button pressed
        //
        void SendAriesRXAntennaMsg()
        {
            int Antenna;
            Band CurrentBand;

            if (chkRxAnt.Checked)                     // if RX on RX antenna, then find TX antenna
            {
                CurrentBand = TXBand;
                // see if we are in an amateur band; if not lookup using Alex function
                if ((CurrentBand < Band.B160M) || (CurrentBand > Band.B6M))
                    CurrentBand = AntennaBandFromFreq(true);

                int idx = (int)CurrentBand - (int)Band.B160M;
                if ((idx < ARIESANTARRAYSIZE) && (idx >= 0))
                {
                    Antenna = AntennaArrayByBand[idx];
                    MakeAriesRXAntennaChangeMsg(Antenna);
                }
            }
            else // find RX antenna
            {
                CurrentBand = RX1Band;

                // see if we are in an amateur band; if not lookup using Alex function
                if ((CurrentBand < Band.B160M) || (CurrentBand > Band.B6M))
                    CurrentBand = AntennaBandFromFreq(false);

                // convert to int, 160m = index value 0
                int idx = (int)CurrentBand - (int)Band.B160M;
                if ((idx < ARIESANTARRAYSIZE) && (idx >= 0))
                {
                    Antenna = RXAntennaArrayByBand[idx];
                    MakeAriesRXAntennaChangeMsg(Antenna);
                }
            }
        }


        // show the RX antenna on the Andromeda screen
        // this is now displayed as 2 characters, so existing names have to be remapped
        private void DisplayAriesRXAntenna()
        {
            int Antenna;
            Band CurrentBand;
            string AntString = "RX";
            CurrentBand = RX1Band;

            // see if we are in an amateur band; if not lookup using Alex function
            if ((CurrentBand < Band.B160M) || (CurrentBand > Band.B6M))
                CurrentBand = AntennaBandFromFreq(false);

            // convert to int, 160m = index value 0
            int idx = (int)CurrentBand - (int)Band.B160M;
            if ((idx < ARIESANTARRAYSIZE) && (idx >= 0))
            {
                Antenna = RXAntennaArrayByBand[idx];
                SendAriesRXAntennaMsg();
                if (RXAuxAntennaArrayByBand[idx])
                    switch (RXAntennaNameArrayByBand[idx])
                    {
                        case "RX1":
                            AntString = "X1";
                            break;
                        case "RX2":
                            AntString = "X2";
                            break;
                        case "XVTR":
                            AntString = "XV";
                            break;
                        case "EXT1":
                            AntString = "X1";
                            break;
                        case "EXT2":
                            AntString = "X2";
                            break;
                        case "BYPS":
                            AntString = "BP";
                            break;
                    }
                else
                    AntString = "Rx Ant " + Antenna.ToString();
                if(AntString != RXAntennaSentString)
                {
                    toolStripStatusLabelRXAnt.Text = AntString;
                    RXAntennaSentString = AntString;
                }
            }
        }

        //// antenna step
        //void TXAntennaStep()
        //{
        //    // change antenna only if TX band == RX band
        //    // step by the current TX antenna
        //    int Ant;
        //    if (TXBand == RX1Band)
        //    {
        //        int idx = (int)TXBand - (int)Band.B160M;
        //        if ((idx < ARIESANTARRAYSIZE) && (idx >= 0))
        //        {
        //            Ant = AntennaArrayByBand[idx];
        //            if (Ant == 1)
        //                Ant = 2;
        //            else if (Ant == 2)
        //                Ant = 3;
        //            else
        //                Ant = 1;
        //            if (SetupForm != null)
        //            {
        //                SetupForm.SetRXAntenna(Ant, TXBand);
        //                SetupForm.SetTXAntenna(Ant, TXBand);
        //            }
        //        }
        //    }
        //}

        // antenna step. Called by the button bar handler to step the RX and TX antennas 1-2-3-1 etc
        // G8NJJ_21h
        void TXAntennaStep()
        {
            // change antenna only if TX band == RX band
            // step by the current TX antenna
            int Ant, NewAnt;
            if (TXBand == RX1Band)
            {
                int idx = (int)TXBand - (int)Band.B160M;
                if ((idx < ARIESANTARRAYSIZE) && (idx >= 0))
                {
                    Ant = AntennaArrayByBand[idx];              // current TX antenna
                    NewAnt = Ant;
                    if (Ant == 1)
                    {
                        if (!AlexANT2RXOnly)
                            NewAnt = 2;
                        else if (!AlexANT3RXOnly)
                            NewAnt = 3;
                    }
                    else if (Ant == 2)
                    {
                        if (!AlexANT3RXOnly)
                            NewAnt = 3;
                        else
                            NewAnt = 1;
                    }
                    else        // ant is 3
                        NewAnt = 1;

                    if ((SetupForm != null) && (NewAnt != Ant))
                    {
                        SetupForm.SetRXAntenna(NewAnt, TXBand);
                        SetupForm.SetTXAntenna(NewAnt, TXBand);
                    }
                }
            }
        }

        // set TX antenna to specified antenna (1=3) called by status bar handler
        public void SetNewTXAntenna(int Ant)
        {
            if ((Ant >= 1) && (Ant <= 3))
            {
                // change antenna only if TX band == RX band
                // step by the current TX antenna
                if (SetupForm != null) 
                    SetupForm.SetTXAntenna(Ant, TXBand);
            }
            UpdateButtonBarButtons();                           // re-label buttons if needed
        }

        // set RX antenna to specified antenna (1=3) called by status bar handler
        public void SetNewRXAntenna(int Ant)
        {
            if ((Ant >= 1) && (Ant <= 3))
            {
                // change antenna only if TX band == RX band
                // step by the current TX antenna
                if (SetupForm != null) 
                    SetupForm.SetRXAntenna(Ant, RX1Band);
            }
        }



        //
        // check if Aries is enabled. Find band and antenna and see if it should be enabled.
        // find the band assigned for TX; find its antenna; and see if the ATU enabled for that antenna.
        private void CheckAriesEnabled()
        {
            int Index;                      // array index
            int Antenna = 0;
            bool RequiredAriesEnabledState = false;         // assume not enabled

            if ((TXBand <= Band.B6M) && (TXBand >= Band.B160M))
            {
                Index = (int)TXBand - (int)Band.B160M;
                Antenna = AntennaArrayByBand[Index];
                switch (Antenna)
                {
                    case 0:
                        RequiredAriesEnabledState = false;
                        break;

                    case 1:
                        RequiredAriesEnabledState = aries_ant1_enabled;
                        break;

                    case 2:
                        RequiredAriesEnabledState = aries_ant2_enabled;
                        break;

                    case 3:
                        RequiredAriesEnabledState = aries_ant3_enabled;
                        break;
                }
            }
            // now if there is a change, tell the ATU
            if (RequiredAriesEnabledState != AriesEnabled)
            {
                MakeAriesATUEnableRequestMsg(RequiredAriesEnabledState);
                AndromedaIndicatorCheck(EIndicatorActions.eINATUReady, false, AriesEnabled);            // goes by the state it is actually at
            }
            // tell Aries if the TX antenna has changed
            if (Antenna != AriesAntenna)
                MakeAriesAntennaChangeMsg(Antenna);
//finally tell Aries the RX antenna too#
            SendAriesRXAntennaMsg();
        }

        //
        // set Alex to Aries mode: 
        // if Aries is in standalone mode, TX antenna = RX antenna = 1
        // 
        void SetAriesAlexMode(bool state)
        {
            Alex.getAlex().SetAntennasTo1(state);
            // now tell Alex to update its settings
            if (rx1_xvtr_index >= 0)
            {
                Band lo_band = BandByFreq(XVTRForm.TranslateFreq(VFOAFreq), rx1_xvtr_index, current_region);
                Alex.getAlex().UpdateAlexAntSelection(lo_band, _mox, alex_ant_ctrl_enabled, true);
            }
            else
            {
                Alex.getAlex().UpdateAlexAntSelection(RX1Band, _mox, alex_ant_ctrl_enabled, false);
            }
        }


        //
        // initialise Aries
        // this is called when the CAT port is enabled
        // work out if ATU enabled for current TX antenna
        // assume setup will already have provided the antenna settings
        private void InitialiseAries()
        {
            AriesEnabled = false;
            AriesAntenna = 0;
            AriesTuneState = false;
            MakeAriesVersionRequestMsg();                       // request h/w and s/w versions
            CheckAriesEnabled();
            MakeAriesATUEnableRequestMsg(AriesEnabled);         // explicitly send the state 1st time
            MakeAriesQuickTuneRequestMsg(AriesQuickTuneEnabled);        // send quick tune enable
            // (this might send a duplicate CAT message, once)
            UpdateAriesDisplayLabel();
            SetAriesAlexMode(aries_standalone);
        }

        // functions to tweak Aries Inductance and Capacitance value
        // set by Andromeda encoder; tells the ATU to adjust its tune
        void TweakAriesCapacitance(int Steps)
        {
            MakeAriesATUTuneTweakMsg(false, Steps);
        }

        void TweakAriesInductance(int Steps)
        {
            MakeAriesATUTuneTweakMsg(true, Steps);
        }

        // send CAT message to Aries to adjust tune 
        // re-uses the "encoder step" message to send an encoder step to Aries
        // encoder 1 = inductance; encoder 2 = capacitance
        // ZZZEnnm; m= no. steps; nn = encoder number (51+ = encoder 1+, turned anticlockwise)
        private void MakeAriesATUTuneTweakMsg(bool IsInductance, int TweakSteps)
        {
            int StepValue;
            string CATMsg = "ZZZE";               // encoder turn message, re-used
            if (TweakSteps >= 0)
                StepValue = 10;
            else
            {
                StepValue = 510;
                TweakSteps = -TweakSteps;
            }
            if (!IsInductance)
                StepValue += 10;
            if (TweakSteps <= 9)
                StepValue += TweakSteps;
            CATMsg += StepValue.ToString("D3");
            CATMsg += ";";
            if (AriesCATEnabled)
            {
                try
                {
                    AriesSiolisten.SIO6.put(CATMsg);
                }
                catch { }
            }
        }

        #endregion




        // G8NJJ: handlers for Ganymeda 500W PA protection
        #region GANYMEDE amplifier protection

        private int GanymedeTripState = 0;                      // amplifier trip

        // for now, put message in SETUP Apollo with current amplifier state
        // ideally when it has been tripped we should remove PTT too.
        public void CATHandleAmplifierTripMessage(int TripState)
        {
            string StatusMessage = "";
            switch (TripState)
            {
                case 0:
                    StatusMessage = "Normal operation";
                    break;
                case 1:
                    StatusMessage = "TRIP: Excess reverse power";
                    break;
                case 2:
                    StatusMessage = "TRIP: Excess drain current";
                    break;
                case 4:
                    StatusMessage = "TRIP: Excess PSU voltage";
                    break;
                case 8:
                    StatusMessage = "TRIP: Excess heatsink temperature";
                    break;
                case 16:
                    StatusMessage = "TRIP: Excess forward power";
                    break;
            }
            SetupForm.GanymedeStatus = StatusMessage;
        }

        // send a CAT message to Ganymede to reset the tripped state
        public void GanymedeResetPressed()
        {
            string CATMsg;
            if (GanymedeCATEnabled)
            {
                CATMsg = "ZZZA32;";
                try
                {
                    GanymedeSiolisten.SIO7.put(CATMsg);
                }
                catch { }
            }
        }

        // send a CAT message to Ganymede asking for h/w and s/w versions
        private void MakeGanymedeVersionRequestMsg()
        {
            string CATMsg;

            CATMsg = "ZZZS;";
            if (GanymedeCATEnabled)
            {
                try
                {
                    SetupForm.GanymedeVersionNumber = "requesting Ganymede;";
                    GanymedeSiolisten.SIO7.put(CATMsg);
                }
                catch { }
            }
        }

        // send a CAT message to Ganymede asking for amplifier status when first connected
        private void MakeGanymedeStatusRequestMsg()
        {
            string CATMsg;

            CATMsg = "ZZZA;";
            if (GanymedeCATEnabled)
            {
                try
                {
                    GanymedeSiolisten.SIO7.put(CATMsg);
                }
                catch { }
            }
        }


        #endregion





        #region Andromeda Button Bar functions

        // G8NJJ: define the Andromeda button bar menu
        public enum EButtonBarActions
        {
            eBBNone = 0,                // no action
            eBBStartStop,               // start/stop the radio
            eBBRX2OnOff,                // toggle RX2 on/off
            eBBDUP,                     // press DUP button
            eBBMON,                     // press MON button
            eBBTune,                    // Tune on/off
            eBBMOX,                     // MOX on/off
            eBBPuresignalOnOff,         // toggle Puresignal on/off
            eBBPuresignal2Tone,         // puresignal 2 tone test on/off
            eBBMenu,                    // activate another menu
            eBBNR,                      // press NR button
            eBBNB,                      // press NB button
            eBBSNB,                     // press SNB button
            eBBANF,                     // press ANF button
            eBBMNF,                     // press MNF button
            eBBVFOSwap,                 // press VFO swap button
            eBBVFOSplit,                // split operation
            eBBVFOAtoB,                 // copy A to B
            eBBVFOBtoA,                 // copy B to A
            eBBVFOZeroBeat,             // operate zero beat button
            eBBIFtoV,                   // operate IF->V button
            eBBVFOSyncOnOff,            // VFO sync
            eBBVFOLockOnOff,            // VFO Lock
            eBBVFOCTUNEOnOff,           // Click Tune
            eBBToggleAB,                // toggle betwee A & B
            eBBRITOnOff,                // toggle RIT on/off
            eBBXITOnOff,                // toggle XIT on/off
            eBBRITXITToggle,            // step off-RIT-XIT
            eBBClearRITXIT,             // clear RIT and XIT
            eBBClearRIT,                // clear RIT only
            eBBClearXIT,                // clear XIT only
            eBBRITPlus,                 // RIT step up
            eBBRITMinus,                // RIT step down
            eBBXITPlus,                 // XIT step up
            eBBXITMinus,                // XIT step down
            eBBRITXITPlus,              // increment whichever is selected
            eBBRITXITMinus,             // decrement whichever is selected
            eBBFilterReset,             // reset variable filter
            eBBFilterPlus,              // select next filter
            eBBFilterMinus,             // select next lower filter
            eBBBandPlus,                // step up band
            eBBBandMinus,               // step down band
            eBBModePlus,                // step up mode
            eBBModeMinus,               // step down mode
            eBBAttenStep,               // step the attenuation value in 6dB steps
            eBBMuteOnOff,               // mute on/off
            eBBBINOnOff,                // Binaural on/off
            eBBSDOnOff,                 // stereo diversity on/off
            eBBVAC1OnOff,               // toggle VAC1 on/off
            eBBVAC2OnOff,               // toggle VAC2 on/off
            eBBAGCStep,                 // step the AGC setting
            eBBSqlOnOff,                // step the squelch setting
            eBBRXEQOnOff,               // RX equaliser on/off
            eBBTXEQOnOff,               // TX equaliser on/off
            eBBTXFLShow,                // show TX filter
            eBBMICOnOff,                // MIC button on/off
            eBBCOMPOnOff,               // COMP button on/off
            eBBVOXOnOff,                // VOX on/off
            eBBDEXPOnOff,               // DEXP on/off
            eBBCWIambic,                // iambic keyer selected
            eBBCWSidetone,              // CW sidetone
            eBBCWShowTX,                // CW show tX frequency
            eBBCWShowZero,              // show CW zero freq
            eUnusedButton1,             // eBBCWSemiBreakin,           // semi breakin on/off
            eBBCWQSK,                   // QSK on/off
            eBBRX1APF,                  // RX1 APF on/off
            eBBCTCSSOnOff,              // FM CTCSS tone on/off
            eBBFMDeviation,             // Toggle FM deviation
            eBBDiversityOnOff,          // toggle diversity on/off
            eBBSubRXOnOff,              // toggle sub-RX on/off
            eBBRXMeterStep,             // step the setting of the RX meter
            eBBTXMeterStep,             // step the setting of the TX meter
            eBBDisplayModeStep,         // step the display mode
            eBBDisplayDSPAVG,           // AVG button
            eBBDisplayDSPPeak,          // AVG button
            eBBCentreDisplay,           // centre the display
            eBBZoomStep,                // step between the zoom step buttons
            eBBRecordAudio,             // record audio
            eBBPlayAudio,                 // play audio (parameter identified which)
            eBBModeForm,                // show MODE form
            eBBFilterForm,              // show FILTER form
            eBBBandForm,                // show BAND form
            eBBSliderForm,              // show "sliders" form
            eBBVFOSettingForm,          // show VFO Settings form
            eBBBandstackForm,           // show band stacks form
            eBBBandstack,               // select next band stack
            eBBQuickSave,               // save to "quick memory"
            eBBQuickRestore,            // restore from "quick memory"
            eBBRXAntenna,               // RX antenna button equivalent
            eBBDiversityForm,           // show the diversity form
            eBBModeSettingsForm,        // show the "mode dependent settings" form
            eBBPuresignalForm,          // show the Puresignal form
            eBBEqualiserForm,           // show equaliser form
            eBBDisplaySettingsForm,     // show the display settings form
            eBBAudioForm,               // open the audio record play form
            eBBSetupForm,               // open the setup form
            eBBATUOnOff,                // Auto ATU on/off
            eBBMenuButton,              // menu button below screen
            eBBMultiEncoderButton,      // multifunction encoder button
            eBBShift,                   // SHIFT allows 2nd function for front panel buttons, for band entry
            eBBMNFAdd,                  // add a manual notch filter
            eBBAntennaStep,             // step to a different antenna
            eBBBand160,                 // 160m band
            eBBBand80,                  // 80m band
            eBBBand60,                  // 60m band
            eBBBand40,                  // 40m band
            eBBBand30,                  // 30m band
            eBBBand20,                  // 20m band
            eBBBand17,                  // 17m band
            eBBBand15,                  // 15m band
            eBBBand12,                  // 12m band
            eBBBand10,                  // 10m band
            eBBBand6,                   // 6m band
            eBBBandLFMF                 // LF/MF band

        }

        // G8NJJ: define the actons an Andromeda encoder can have
        public enum EEncoderActions
        {
            eENNoAction,
            eENMasterGain,
            eENAFGain,
            eENStereoBalance,
            eENAGCLevel,
            eENStepAtten,
            eENFilterHigh,
            eENFilterLow,
            eENDrive,
            eENMicGain,
            eENVFOATune,
            eENVFOBTune,
            eENVOXGain,
            eENVOXHold,
            eENCWSidetone,
            eENCWSpeed,
            eENSquelch,
            eENDiversityGain,
            eENDiversityPhase,
            eENCompanderThreshold,
            eENRIT,
            eENXIT,
            eENRITXIT,
            eENDisplayPan,
            eENDisplayZoom,
            eENVACRX,
            eENVACTX,
            eENTuneStep,
            eENMulti                      // multifunction - this MUST be the last!
        }


        // define the indications a front panel indicator (LED) can have
        public enum EIndicatorActions
        {
            eINNone,
            eINMOX,
            eINTune,
            eINRIT,
            eINXIT,
            eINSplit,
            eINCTune,
            eINVFOSync,
            eINVFOAB,
            eINVFOLock,
            eINNB,
            eINNR,
            eINSNB,
            eINANF,
            eINSquelch,
            eINCompanderEnabled,
            eINPuresignalEnabled,
            eINDiversityEnabled,
            eINATUReady,
            eINShiftEnabled                         // button to enable front panel band entry
        }


        // property to set whether a G2 panel is attached; CAT via TCP/IP
        private bool andromeda_g2_enabled;
        public bool AndromedaG2Enabled
        {
            set
            {
                andromeda_g2_enabled = value;
                toolStripStatusLabelAndromedaMulti.Visible = true;
            }

            get { return andromeda_g2_enabled; }
        }


        // access the dataset from outside: to allow future editing of menus, encoders, pushbuttons etc
        public DataSet AndromedaSettings
        {
            get { return AndromedaSet; }

            set
            {
                AndromedaSet = value;
                SaveAndromedaDataset();
            }
        }

        public DataSet AndromedaComboStrings
        {
            get { return ComboSet; }

            set
            {
                ComboSet = value;
            }
        }


        // access the andromeda setup for shared buttons defaulting to "band" function
        private bool andromedaBandButtonIsDefault;
        public bool AndromedaBandButtonIsDefault
        {
            get { return andromedaBandButtonIsDefault; }
            set 
            { 
                andromedaBandButtonIsDefault = value;
                // set the start state for the band buttons function - band or other function
                AndromedaBandButtonsEnabled = value;
                AndromedaIndicatorCheck(EIndicatorActions.eINShiftEnabled, false, AndromedaBandButtonsEnabled);

            }
        }

        // access the andromeda setup for shift button being "sticky"
        private bool andromedaStickyShift;
        public bool AndromedaStickyShift
        {
            get { return andromedaStickyShift; }
            set { andromedaStickyShift = value; }
        }

        // access the andromeda setup for stick softkey menus
        private bool andromedastickymenus;
        public bool AndromedaStickyMenus
        {
            get { return andromedastickymenus; }
            set { andromedastickymenus = value; }
        }




        public AndromedaEditForm andromedaEditorForm;

        // this is called from the setup form, to edit control assignments
        public void EditAndromedaDataSet()
        {
            if (andromedaEditorForm == null) andromedaEditorForm = new AndromedaEditForm(this);
            andromedaEditorForm.Show();
        }


        DataSet AndromedaSet = new DataSet("Andromeda Data");           // settings held in 5 tables here
        DataSet ComboSet = new DataSet("Andromeda Combo String");       // non persistent settings held in tables here

        private int currentButtonBarMenu = 0;                       // current menu shown (points to 1st entry shown)
        private int CurrentMultifunctionOption = 0;                 // index to current multifunction control


        private bool AndromedaMultiEncoderState;                    // true if a step changes the multi action
        private bool AndromedaBandButtonsEnabled = false;           // true if andromeda SHIFT is pressed (latching action)  (name changed for clarity)

        System.Timers.Timer AndromedaTimer;                         // times display of a slider on andromeda bar 
        System.Timers.Timer AndromedaMenuTimer;                     // timeout for menu activity


        // initialise the data structures for andromeda.
        // there are 5 tables:
        // "Menu Bar Settings": softkey menus, for the bottom of the screen;
        // "Indicators": front panel indicator actions
        // "Encoders": front panel encoder actions
        // "Pushbuttons": front panel pushbutton actions
        // "Multifunction Settings": actions that can be assigned to the "multifunction" encoder
        private void InitialiseAndromedaMenus()
        {

            AndromedaTimer = new System.Timers.Timer();
            AndromedaTimer.Elapsed += new ElapsedEventHandler(Callback);
            AndromedaTimer.Enabled = false;

            AndromedaMenuTimer = new System.Timers.Timer();
            AndromedaMenuTimer.Elapsed += new ElapsedEventHandler(AndromedaMenuTimerCallback);
            AndromedaMenuTimer.Enabled = false;


            string Filename = AppDataPath + "andromedadata.xml";            // XML file for the settings
            if (File.Exists(Filename))                          // if we have a file, read it
            {
                try
                {
                    AndromedaSet.ReadXml(Filename);
                }
                catch
                { }
            }
            else
            {
                MakeNewAndromedaDataset();              // if no XML file, create dataset
                SaveAndromedaDataset();         //  and save file
            }
            //
            // make the non persistent data for combo box strings
            // this is only used in the editing form but kept here to make software maintenance easier
            // deliberately non persistent, and not saved - so we can change the options available
            // without having to tell users how to upgrade a file.

            // THERE MUST BE ONE TABLE ROW PER ENUM VALUE!

            // this table holds settings for rotary encoders
            DataTable EncoderComboTable = new DataTable("Encoder Combo Strings");
            EncoderComboTable.Columns.Add("ActionId", typeof(int));          // front panel pushbutton number
            EncoderComboTable.Columns.Add("ActionString", typeof(String));   // descriptive text
            EncoderComboTable.Rows.Add(EEncoderActions.eENNoAction, "No function");
            EncoderComboTable.Rows.Add(EEncoderActions.eENMasterGain, "Master AF gain");
            EncoderComboTable.Rows.Add(EEncoderActions.eENAFGain, "RX AF gain");
            EncoderComboTable.Rows.Add(EEncoderActions.eENStereoBalance, "RX L/R Stereo balance");
            EncoderComboTable.Rows.Add(EEncoderActions.eENAGCLevel, "RX AGC Level");
            EncoderComboTable.Rows.Add(EEncoderActions.eENStepAtten, "RX Step attenuator");
            EncoderComboTable.Rows.Add(EEncoderActions.eENFilterHigh, "RX IF filter high cut");
            EncoderComboTable.Rows.Add(EEncoderActions.eENFilterLow, "RX IF filter low cut");
            EncoderComboTable.Rows.Add(EEncoderActions.eENDrive, "TX drive");
            EncoderComboTable.Rows.Add(EEncoderActions.eENMicGain, "TX Mic gain");
            EncoderComboTable.Rows.Add(EEncoderActions.eENVFOATune, "VFO A tune");
            EncoderComboTable.Rows.Add(EEncoderActions.eENVFOBTune, "VFO B tune");
            EncoderComboTable.Rows.Add(EEncoderActions.eENVOXGain, "VOX gain");
            EncoderComboTable.Rows.Add(EEncoderActions.eENVOXHold, "VOX hold time");
            EncoderComboTable.Rows.Add(EEncoderActions.eENCWSidetone, "CW sidetone frequency");
            EncoderComboTable.Rows.Add(EEncoderActions.eENCWSpeed, "CW speed");
            EncoderComboTable.Rows.Add(EEncoderActions.eENSquelch, "RX squelch");
            EncoderComboTable.Rows.Add(EEncoderActions.eENDiversityGain, "RX diversity gain");
            EncoderComboTable.Rows.Add(EEncoderActions.eENDiversityPhase, "RX diversity phase");
            EncoderComboTable.Rows.Add(EEncoderActions.eENCompanderThreshold, "TX compander threshold");
            EncoderComboTable.Rows.Add(EEncoderActions.eENRIT, "RIT");
            EncoderComboTable.Rows.Add(EEncoderActions.eENXIT, "XIT");
            EncoderComboTable.Rows.Add(EEncoderActions.eENRITXIT, "Selectable RIT/XIT");
            EncoderComboTable.Rows.Add(EEncoderActions.eENDisplayPan, "Display pan");
            EncoderComboTable.Rows.Add(EEncoderActions.eENDisplayZoom, "Display zoom");
            EncoderComboTable.Rows.Add(EEncoderActions.eENVACRX, "VAC RX Gain");
            EncoderComboTable.Rows.Add(EEncoderActions.eENVACTX, "VAC TX Gain");
            EncoderComboTable.Rows.Add(EEncoderActions.eENTuneStep, "VFO Tune Step");
            EncoderComboTable.Rows.Add(EEncoderActions.eENMulti, "Multifunction");                     // multifunction - this MUST be the last!
            ComboSet.Tables.Add(EncoderComboTable);

            // RX override values for encoders, pushbuttons and menu buttons
            DataTable EncoderRXOverrideTable = new DataTable("Encoder RX Override Strings");
            EncoderRXOverrideTable.Columns.Add("OvrId", typeof(int));          // front panel pushbutton number
            EncoderRXOverrideTable.Columns.Add("OvrString", typeof(String));   // descriptive text
            EncoderRXOverrideTable.Rows.Add(0, "Default setting");
            EncoderRXOverrideTable.Rows.Add(1, "RX1 only");
            EncoderRXOverrideTable.Rows.Add(2, "RX2 only");
            ComboSet.Tables.Add(EncoderRXOverrideTable);

            // indicator values
            DataTable IndicatorComboTable = new DataTable("Indicator Combo Strings");
            IndicatorComboTable.Columns.Add("ActionId", typeof(int));          // front panel pushbutton number
            IndicatorComboTable.Columns.Add("ActionString", typeof(String));   // descriptive text
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINNone, "No function");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINMOX, "MOX active");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINTune, "TUNE active");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINRIT, "RIT selected");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINXIT, "XIT selected");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINSplit, "VFO Split active");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINCTune, "VFO Click tune active");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINVFOSync, "VFO Sync active");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINVFOAB, "VFO A selected");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINVFOLock, "VFO locked");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINNB, "Noise Blanker");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINNR, "Noise Reduction");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINSNB, "Spectral Noise Blanker");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINANF, "Auto notch filter");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINSquelch, "Squelch active");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINCompanderEnabled, "COMP selected");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINPuresignalEnabled, "Puresignal selected");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINDiversityEnabled, "Diversity enabled");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINATUReady, "ATU is enabled");
            IndicatorComboTable.Rows.Add(EIndicatorActions.eINShiftEnabled, "Band select shift pressed");                        // button to enable front panel band entry
            ComboSet.Tables.Add(IndicatorComboTable);

            // RX override values for indicators
            DataTable IndicatorRXOverrideTable = new DataTable("Indicator RX Override Strings");
            IndicatorRXOverrideTable.Columns.Add("OvrId", typeof(int));          // front panel pushbutton number
            IndicatorRXOverrideTable.Columns.Add("OvrString", typeof(String));   // descriptive text
            IndicatorRXOverrideTable.Rows.Add(0, "Not RX dependent");
            IndicatorRXOverrideTable.Rows.Add(1, "RX selected by VFO A/B");
            IndicatorRXOverrideTable.Rows.Add(2, "RX1 only");
            IndicatorRXOverrideTable.Rows.Add(3, "RX2 only");
            ComboSet.Tables.Add(IndicatorRXOverrideTable);

            DataTable ButtonComboTable = new DataTable("Pushbutton Combo Strings");
            ButtonComboTable.Columns.Add("ActionId", typeof(int));          // front panel pushbutton number
            ButtonComboTable.Columns.Add("ActionString", typeof(String));   // descriptive text
            ButtonComboTable.Columns.Add("MenuText", typeof(String));     // text to be displayed
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBNone, "No function", "---");
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBStartStop, "Radio start/stop", "start/stop");               // start/stop the radio
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBRX2OnOff, "RX2 on/off", "RX2");                // toggle RX2 on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBDUP, "Duplex on/off", "Duplex");                     // press DUP button
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBMON, "MON on/off", "MON");                     // press MON button
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBTune, "TUNE on/off", "TUNE");                    // Tune on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBMOX, "MOX on/off", "MOX");                     // MOX on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBPuresignalOnOff, "Puresignal on/off", "Puresignal");         // toggle Puresignal on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBPuresignal2Tone, "Puresignal 2 tone test", "2 Tone test");         // puresignal 2 tone test on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBMenu, "Change menu row", "Menu");                    // activate another menu
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBNR, "Noise Reduction", "NR");                      // press NR button
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBNB, "Noise Blanker", "NB");                      // press NB button
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBSNB, "Spectral Noise Blanker", "SNB");                     // press SNB button
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBANF, "Auto Notch Filter", "ANF");                     // press ANF button
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBMNF, "Manual Notch Filter", "MNF");                     // press MNF button
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBVFOSwap, "VFO swap", "A <> B");                 // press VFO swap button
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBVFOSplit, "VFO Split", "Split");                // split operation
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBVFOAtoB, "VFO copy A to B", "A > B");                 // copy A to B
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBVFOBtoA, "VFO copy B to A", "B > A");                 // copy B to A
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBVFOZeroBeat, "VFO zero beat", "0 beat");             // operate zero beat button
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBIFtoV, "VFO IF-> V", "IF > V");                   // operate IF->V button
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBVFOSyncOnOff, "VFO Sync on/off", "SYNC");            // VFO sync
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBVFOLockOnOff, "VFO Lock on/off", "LOCK");            // VFO Lock
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBVFOCTUNEOnOff, "VFO Click tune on/off", "CTUNE");           // Click Tune
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBToggleAB, "Toggle A/B VFO", "A/B");                // toggle betwee A & B
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBRITOnOff, "RIT on/off", "RIT");                // toggle RIT on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBXITOnOff, "XIT on/off", "XIT");                // toggle XIT on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBRITXITToggle, "Toggle RIT or XIT", "RIT/XIT");            // step off-RIT-XIT
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBClearRITXIT, "Clear RIT & XIT", "Clear RIT/XIT");             // clear RIT and XIT
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBClearRIT, "Clear RIT", "Clear RIT");                // clear RIT only
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBClearXIT, "Clear XIT", "Clear XIT");                // clear XIT only
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBRITPlus, "RIT step up", "RIT +");                 // RIT step up
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBRITMinus, "RIT step down", "RIT -");                // RIT step down
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBXITPlus, "XIT step up", "XIT +");                 // XIT step up
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBXITMinus, "XIT step down", "XIT -");                // XIT step down
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBRITXITPlus, "RIT/XIT step up", "RIT/XIT +");              // increment whichever is selected
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBRITXITMinus, "RIT/XIT step down", "RIT/XIT -");             // decrement whichever is selected
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBFilterReset, "Reset variable filters", "Filter reset");             // reset variable filter
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBFilterPlus, "Select next filter b/w", "Filter +");              // select next filter
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBFilterMinus, "Select lower filter b/w", "Filter -");             // select next lower filter
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBandPlus, "Select Next Band", "Band up");                // step up band
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBandMinus, "Select Previous Band", "Band down");               // step down band
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBModePlus, "Select Next Mode", "Mode +");                // step up mode
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBModeMinus, "Select Previous Mode", "Mode -");               // step down mode
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBAttenStep, "Step RX attenuator", "Att +");               // step the attenuation value in 6dB steps
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBMuteOnOff, "RX Mute on/off", "MUTE");               // mute on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBINOnOff, "RX Binaural on/off", "BIN");                // Binaural on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBSDOnOff, "RX Stereo Diversity on/off", "SD");                 // stereo diversity on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBVAC1OnOff, "VAC1 on/off", "VAC1");               // toggle VAC1 on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBVAC2OnOff, "VAC2 on/off", "VAC2");               // toggle VAC2 on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBAGCStep, "RX AGC step", "AGC step");                 // step the aGC setting
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBSqlOnOff, "RX Squelch on/off", "SQL");                // step the squelch setting
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBRXEQOnOff, "RX equaliser on/off", "RX EQ");               // RX equaliser on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBTXEQOnOff, "TX equaliser on/off", "TX EQ");               // TX equaliser on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBTXFLShow, "Show TX filter on/off", "TX Filt");                // show TX filter
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBMICOnOff, "MIC input on/off", "MIC");                // MIC button on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBCOMPOnOff, "Compander on/off", "COMP");               // COMP button on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBVOXOnOff, "VOX on/off", "VOX");                // VOX on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBDEXPOnOff, "Downward expander on/off", "DEXP");               // DEXP on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBCWIambic, "CW Iambic keyer on/off", "CW keyer");                // iambic keyer selected
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBCWSidetone, "CW sidetone on/off", "Sidetone");              // CW sidetone
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBCWShowTX, "Show CW TX line on/off", "show CW 0");                // CW show tX frequency
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBCWShowZero, "Show CW TX zero line on/off", "Show CW TX 0");              // show CW zero freq
            ButtonComboTable.Rows.Add(EButtonBarActions.eUnusedButton1, "Unused", "Unused");           // spare button
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBCWQSK, "CW Break-in Manual/Semi/QSK", "QSK");                   // Break-in Manual ,Semi, or QSK
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBRX1APF, "RX1 APF on/off", "APF");                  // RX1 APF on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBCTCSSOnOff, "CTCSS tone on/off", "CTCSS");             // FM CTCSS tone on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBFMDeviation, "Toggle FM deviation", "FM Dev");             // Toggle FM deviation
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBDiversityOnOff, "RX Diversity on/off", "Diversity");          // toggle diversity on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBSubRXOnOff, "Sub-RX on/off", "Sub-RX");              // toggle sub-RX on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBRXMeterStep, "Next RX meter setting", "RX meter +");             // step the setting of the RX meter
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBTXMeterStep, "Next TX meter setting", "TX meter +");             // step the setting of the TX meter
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBDisplayModeStep, "Next display mode", "Display mode");        // step the display mode
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBDisplayDSPAVG, "Toggle display AVG", "Disp AVG");           // AVG button
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBDisplayDSPPeak, "Toggle display Peak", "Disp Peak");          // AVG button
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBCentreDisplay, "Centre display", "Disp Centre");           // centre the display
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBZoomStep, "Next zoom step button", "Zoom Step");                // step between the zoom step buttons
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBRecordAudio, "Record Audio", "REC audio");             // record audio
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBPlayAudio, "Play Audio", "PLAY Audio");                 // play audio (parameter identified which)
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBModeForm, "Show Mode form", "Show Mode Form");               // show MODE form
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBFilterForm, "Show filter form", "Show Filter Form");              // show FILTER form
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBandForm, "Show band form", "Show Band Form");                // show BAND form
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBSliderForm, "Show slider form", "Show Slider Form");              // show "sliders" form
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBVFOSettingForm, "Show VFO settings form", "Show VFO Form");          // show VFO Settings form
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBandstackForm, "Show bandstack form", "Show bandstacks");           // show band stacks form
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBandstack, "Select next bandstack", "Bandstack +");               // select next band stack
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBQuickSave, "Save to quick VFO memory", "VFO > MEM");               // save to "quick memory"
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBQuickRestore, "Get from quick VFO memory", "MEM > VFO");            // restore from "quick memory"
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBRXAntenna, "Next RX antenna", "Antenna +");               // RX antenna button equivalent
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBDiversityForm, "Show Diversity form", "Show Diversity Form");           // show the diversity form
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBModeSettingsForm, "Show mode dependent settings", "Show Mode Settings");        // show the "mode dependent settings" form
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBPuresignalForm, "Show Puresignal form", "Show Puresignal form");          // show the Puresignal form
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBEqualiserForm, "Show Equaliser form", "Show Equaliser form");           // show equaliser form
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBDisplaySettingsForm, "Show Display settings form", "Show Display Settings");     // show the display settings form
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBAudioForm, "Show audio rec/replay form", "Show Audio form");               // open the audio record play form
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBSetupForm, "Show setup form", "show setup Form");               // open the setup form
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBATUOnOff, "Auto ATU on/off", "ATU");                // Auto ATU on/off
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBMenuButton, "Menu Softkey Button", "Menu Key");              // menu button below screen
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBMultiEncoderButton, "Multi Encoder pushbutton", "Multi button");      // multifunction encoder button
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBShift, "Band Shift front panel button", "band shift button");                     // SHIFT allows 2nd function for front panel buttons, for band entry
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBMNFAdd, "Add Manual Notch Filter", "Add MNF notch");                  // add manual notch
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBAntennaStep, "Step RX/Tx antenna", "Step antenna");                   // step the selected antenna
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBand160, "160m band", "160m band");                                   // select a band
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBand80, "80m band", "80m band");                                      // select a band
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBand60, "60m band", "60m band");                                      // select a band
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBand40, "40m band", "40m band");                                      // select a band
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBand30, "30m band", "30m band");                                      // select a band
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBand20, "20m band", "20m band");                                      // select a band
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBand17, "17m band", "17m band");                                      // select a band
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBand15, "15m band", "15m band");                                      // select a band
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBand12, "12m band", "12m band");                                      // select a band
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBand10, "10m band", "10m band");                                      // select a band
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBand6, "6m band", "6m band");                                         // select a band
            ButtonComboTable.Rows.Add(EButtonBarActions.eBBBandLFMF, "LFMF band", "LFMF band");                                  // select a band
            ComboSet.Tables.Add(ButtonComboTable);

            // RX override values for pushbuttons
            DataTable PushbuttonRXOverrideTable = new DataTable("Pushbutton RX Override Strings");
            PushbuttonRXOverrideTable.Columns.Add("OvrId", typeof(int));          // front panel pushbutton number
            PushbuttonRXOverrideTable.Columns.Add("OvrString", typeof(String));   // descriptive text
            PushbuttonRXOverrideTable.Rows.Add(0, "Default setting");
            PushbuttonRXOverrideTable.Rows.Add(1, "RX1 only");
            PushbuttonRXOverrideTable.Rows.Add(2, "RX2 only");
            PushbuttonRXOverrideTable.Rows.Add(11, "Execute softkey 1");
            PushbuttonRXOverrideTable.Rows.Add(12, "Execute softkey 2");
            PushbuttonRXOverrideTable.Rows.Add(13, "Execute softkey 3");
            PushbuttonRXOverrideTable.Rows.Add(14, "Execute softkey 4");
            PushbuttonRXOverrideTable.Rows.Add(15, "Execute softkey 5");
            PushbuttonRXOverrideTable.Rows.Add(16, "Execute softkey 6");
            PushbuttonRXOverrideTable.Rows.Add(17, "Execute softkey 7");
            PushbuttonRXOverrideTable.Rows.Add(18, "Execute softkey 8");
            ComboSet.Tables.Add(PushbuttonRXOverrideTable);
        }



        // create a new Andromeda dataset from scratch, if one doesn't yet exist
        // this is like a "factory reset" for the dataset if it can't be read from file
        // create tables, and add initial data to them
        private void MakeNewAndromedaDataset()
        {
            // this table holds settings for LED indicators
            DataTable IndicatorTable = new DataTable("Indicators");
            IndicatorTable.Columns.Add("Indicator Number", typeof(int));            // console indicator number
            IndicatorTable.Columns.Add("Indicator Action", typeof(int));            // function indicated by it (from EIndicatorActions)
            IndicatorTable.Columns.Add("Indicator Description", typeof(String));    // useful text?
            IndicatorTable.Columns.Add("Indicator RX Selector", typeof(int));       // 0: insensitive to RX; 1: indicator uses show_RX1 setting; 2: for RX1; 3: for RX2
            IndicatorTable.Rows.Add(1, (int)EIndicatorActions.eINMOX, "", 0);
            IndicatorTable.Rows.Add(2, (int)EIndicatorActions.eINATUReady, "", 0);
            IndicatorTable.Rows.Add(3, (int)EIndicatorActions.eINTune, "", 0);
            IndicatorTable.Rows.Add(4, (int)EIndicatorActions.eINPuresignalEnabled, "", 0);
            IndicatorTable.Rows.Add(5, (int)EIndicatorActions.eINDiversityEnabled, "", 0);
            IndicatorTable.Rows.Add(6, (int)EIndicatorActions.eINShiftEnabled, "", 0);
            IndicatorTable.Rows.Add(7, (int)EIndicatorActions.eINCTune, "", 1);      // pick up RX1 or 2
            IndicatorTable.Rows.Add(8, (int)EIndicatorActions.eINRIT, "", 0);
            IndicatorTable.Rows.Add(9, (int)EIndicatorActions.eINXIT, "", 0);
            IndicatorTable.Rows.Add(10, (int)EIndicatorActions.eINVFOAB, "", 0);
            IndicatorTable.Rows.Add(11, (int)EIndicatorActions.eINVFOLock, "", 0);
            IndicatorTable.Rows.Add(12, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(13, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(14, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(15, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(16, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(17, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(18, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(19, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(20, (int)EIndicatorActions.eINNone, "", 0);

            // this table holds settings for pushbuttons
            // this set for prototype V2; 0-19 = encoders; 20-98 = pushbuttons
            DataTable ButtonTable = new DataTable("Pushbuttons");
            ButtonTable.Columns.Add("Pushbutton Number", typeof(int));          // front panel pushbutton number
            ButtonTable.Columns.Add("Pushbutton Action", typeof(int));          // action assigned to button (from EButtonBarActions)
            ButtonTable.Columns.Add("Pushbutton Description", typeof(String));   // descriptive text
            ButtonTable.Columns.Add("Pushbutton RX Selector", typeof(int));     // overrides softkey number or RX1/RX2 assignment (0: use A/B; 1: use RX1; 2: use RX2)
            ButtonTable.Rows.Add(1, EButtonBarActions.eBBMuteOnOff, "", 1);
            ButtonTable.Rows.Add(2, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(3, EButtonBarActions.eBBMuteOnOff, "", 2);
            ButtonTable.Rows.Add(4, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(5, EButtonBarActions.eBBFilterReset, "", 0);
            ButtonTable.Rows.Add(6, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(7, EButtonBarActions.eBBDiversityOnOff, "", 0);
            ButtonTable.Rows.Add(8, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(9, EButtonBarActions.eBBClearRITXIT, "", 0);
            ButtonTable.Rows.Add(10, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(11, EButtonBarActions.eBBMultiEncoderButton, "", 0);
            ButtonTable.Rows.Add(12, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(13, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(14, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(15, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(16, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(17, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(18, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(19, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(20, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(21, EButtonBarActions.eBBMenuButton, "", 11);
            ButtonTable.Rows.Add(22, EButtonBarActions.eBBMenuButton, "", 12);
            ButtonTable.Rows.Add(23, EButtonBarActions.eBBMenuButton, "", 13);
            ButtonTable.Rows.Add(24, EButtonBarActions.eBBMenuButton, "", 14);
            ButtonTable.Rows.Add(25, EButtonBarActions.eBBMenuButton, "", 15);
            ButtonTable.Rows.Add(26, EButtonBarActions.eBBMenuButton, "", 16);
            ButtonTable.Rows.Add(27, EButtonBarActions.eBBMenuButton, "", 17);
            ButtonTable.Rows.Add(28, EButtonBarActions.eBBMenuButton, "", 18);
            ButtonTable.Rows.Add(29, EButtonBarActions.eBBShift, "", 0);
            ButtonTable.Rows.Add(30, EButtonBarActions.eBBBandPlus, "", 0);
            ButtonTable.Rows.Add(31, EButtonBarActions.eBBModePlus, "", 0);
            ButtonTable.Rows.Add(32, EButtonBarActions.eBBFilterPlus, "", 0);
            ButtonTable.Rows.Add(33, EButtonBarActions.eBBBandMinus, "", 0);
            ButtonTable.Rows.Add(34, EButtonBarActions.eBBModeMinus, "", 0);
            ButtonTable.Rows.Add(35, EButtonBarActions.eBBFilterMinus, "", 0);
            ButtonTable.Rows.Add(36, EButtonBarActions.eBBVFOAtoB, "", 0);
            ButtonTable.Rows.Add(37, EButtonBarActions.eBBVFOBtoA, "", 0);
            ButtonTable.Rows.Add(38, EButtonBarActions.eBBVFOSplit, "", 0);
            ButtonTable.Rows.Add(39, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(40, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(41, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(42, EButtonBarActions.eBBRITXITToggle, "", 0);
            ButtonTable.Rows.Add(43, EButtonBarActions.eBBToggleAB, "", 0);
            ButtonTable.Rows.Add(44, EButtonBarActions.eBBVFOLockOnOff, "", 0);
            ButtonTable.Rows.Add(45, EButtonBarActions.eBBVFOCTUNEOnOff, "", 0);
            ButtonTable.Rows.Add(46, EButtonBarActions.eBBStartStop, "", 0);
            ButtonTable.Rows.Add(47, EButtonBarActions.eBBMOX, "", 0);
            ButtonTable.Rows.Add(48, EButtonBarActions.eBBTune, "", 0);
            ButtonTable.Rows.Add(49, EButtonBarActions.eBBPuresignalOnOff, "", 0);
            ButtonTable.Rows.Add(50, EButtonBarActions.eBBPuresignal2Tone, "", 0);

            // this table holds settings for rotary encoders
            DataTable EncoderTable = new DataTable("Encoders");
            EncoderTable.Columns.Add("Encoder Number", typeof(int));          // front panel pushbutton number
            EncoderTable.Columns.Add("Encoder Action", typeof(int));          // action assigned to button (from EEncoderActions)
            EncoderTable.Columns.Add("Encoder Description", typeof(String));   // descriptive text
            EncoderTable.Columns.Add("Encoder RX Selector", typeof(int));     // overrides softkey number or RX1/RX2 assignment (0: use A/B; 1: use RX1; 2: use RX2)
            EncoderTable.Rows.Add(1, EEncoderActions.eENAFGain, "", 1);                 // 1A: RX1 AF
            EncoderTable.Rows.Add(2, EEncoderActions.eENAGCLevel, "", 1);              // 1B: RX1 AGC
            EncoderTable.Rows.Add(3, EEncoderActions.eENAFGain, "", 2);                 // 3A: RX2 AF
            EncoderTable.Rows.Add(4, EEncoderActions.eENAGCLevel, "", 2);              // 3B: RX2 AGC
            EncoderTable.Rows.Add(5, EEncoderActions.eENFilterHigh, "", 0);    // 5A: filter high
            EncoderTable.Rows.Add(6, EEncoderActions.eENFilterLow, "", 0);      // 5B: filter low
            EncoderTable.Rows.Add(7, EEncoderActions.eENDiversityGain, "", 0);    // 7A: diversity gain
            EncoderTable.Rows.Add(8, EEncoderActions.eENDiversityPhase, "", 0);  // 7B: diversity phase
            EncoderTable.Rows.Add(9, EEncoderActions.eENRIT, "", 0);                         // 9A: RIT
            EncoderTable.Rows.Add(10, EEncoderActions.eENXIT, "", 0);             // 9B: not assigned
            EncoderTable.Rows.Add(11, EEncoderActions.eENMulti, "", 0);            // 11A: multifunction
            EncoderTable.Rows.Add(12, EEncoderActions.eENDrive, "", 0);                    // 11B: drive
            EncoderTable.Rows.Add(13, EEncoderActions.eENNoAction, "", 0);
            EncoderTable.Rows.Add(14, EEncoderActions.eENNoAction, "", 0);
            EncoderTable.Rows.Add(15, EEncoderActions.eENNoAction, "", 0);
            EncoderTable.Rows.Add(16, EEncoderActions.eENNoAction, "", 0);
            EncoderTable.Rows.Add(17, EEncoderActions.eENNoAction, "", 0);
            EncoderTable.Rows.Add(18, EEncoderActions.eENNoAction, "", 0);
            EncoderTable.Rows.Add(19, EEncoderActions.eENNoAction, "", 0);
            EncoderTable.Rows.Add(20, EEncoderActions.eENNoAction, "", 0);

            // this table is all the allowed options for the multifunction encoder
            DataTable MultiTable = new DataTable("Multifunction Settings");
            MultiTable.Columns.Add("Multi Number", typeof(int));          // front panel pushbutton number
            MultiTable.Columns.Add("Multi Action", typeof(int));          // action assigned to button (from EEncoderActions)
            MultiTable.Columns.Add("Multi Description", typeof(String));   // descriptive text
            MultiTable.Columns.Add("Multi RX Selector", typeof(int));     // overrides softkey number or RX1/RX2 assignment (0: use A/B; 1: use RX1; 2: use RX2)
            MultiTable.Rows.Add(0, EEncoderActions.eENMasterGain, "Master AF Gain", 0);
            MultiTable.Rows.Add(1, EEncoderActions.eENAFGain, "RX1 AF Gain", 1);
            MultiTable.Rows.Add(2, EEncoderActions.eENAFGain, "RX2 AF Gain", 2);
            MultiTable.Rows.Add(3, EEncoderActions.eENAFGain, "Sub-RX AF Gain", 3);
            MultiTable.Rows.Add(4, EEncoderActions.eENAGCLevel, "RX1 AGC", 1);
            MultiTable.Rows.Add(5, EEncoderActions.eENAGCLevel, "RX2 AGC", 2);
            MultiTable.Rows.Add(6, EEncoderActions.eENStepAtten, "RX1 Step Atten", 1);
            MultiTable.Rows.Add(7, EEncoderActions.eENStepAtten, "RX2 Step Atten", 2);
            MultiTable.Rows.Add(8, EEncoderActions.eENFilterHigh, "RX1 Filter High Cut", 1);
            MultiTable.Rows.Add(9, EEncoderActions.eENFilterLow, "RX1 Filter Low Cut", 1);

            MultiTable.Rows.Add(10, EEncoderActions.eENFilterHigh, "RX2 Filter High Cut", 2);
            MultiTable.Rows.Add(11, EEncoderActions.eENFilterLow, "RX2 Filter Low Cut", 2);
            MultiTable.Rows.Add(12, EEncoderActions.eENSquelch, "RX1 Squelch", 1);
            MultiTable.Rows.Add(13, EEncoderActions.eENSquelch, "RX2 Squelch", 2);
            MultiTable.Rows.Add(14, EEncoderActions.eENDiversityGain, "Diversity Gain", 0);
            MultiTable.Rows.Add(15, EEncoderActions.eENDiversityPhase, "Diversity Phase", 0);
            MultiTable.Rows.Add(16, EEncoderActions.eENRIT, "RIT", 0);
            MultiTable.Rows.Add(17, EEncoderActions.eENXIT, "XIT", 0);
            MultiTable.Rows.Add(18, EEncoderActions.eENRITXIT, "RIT or XIT", 0);
            MultiTable.Rows.Add(19, EEncoderActions.eENDrive, "TX Drive", 0);

            MultiTable.Rows.Add(20, EEncoderActions.eENMicGain, "Mic Gain", 0);
            MultiTable.Rows.Add(21, EEncoderActions.eENVFOATune, "VFO A Tune", 0);
            MultiTable.Rows.Add(22, EEncoderActions.eENVFOBTune, "VFO B Tune", 0);
            MultiTable.Rows.Add(23, EEncoderActions.eENVOXGain, "VOX Gain", 0);
            MultiTable.Rows.Add(24, EEncoderActions.eENVOXHold, "VOX Hold", 0);
            MultiTable.Rows.Add(25, EEncoderActions.eENCWSidetone, "CW sidetone pitch", 0);
            MultiTable.Rows.Add(26, EEncoderActions.eENCWSpeed, "CW Speed", 0);
            MultiTable.Rows.Add(27, EEncoderActions.eENCompanderThreshold, "COMP Gain", 0);
            MultiTable.Rows.Add(28, EEncoderActions.eENDisplayPan, "Display Pan", 0);
            MultiTable.Rows.Add(29, EEncoderActions.eENDisplayZoom, "Display Zoom", 0);

            MultiTable.Rows.Add(30, EEncoderActions.eENStereoBalance, "RX1 Stereo Balance", 1);
            MultiTable.Rows.Add(31, EEncoderActions.eENStereoBalance, "RX2 Stereo Balance", 2);
            MultiTable.Rows.Add(32, EEncoderActions.eENStereoBalance, "Sub-RX Stereo Balance", 3);
            MultiTable.Rows.Add(33, EEncoderActions.eENVACRX, "VAC1 RX Gain", 1);
            MultiTable.Rows.Add(34, EEncoderActions.eENVACTX, "VAC1 TX Gain", 1);
            MultiTable.Rows.Add(35, EEncoderActions.eENVACRX, "VAC2 RX Gain", 2);
            MultiTable.Rows.Add(36, EEncoderActions.eENVACTX, "VAC2 TX Gain", 2);
            MultiTable.Rows.Add(37, EEncoderActions.eENTuneStep, "VFO Tune Step", 0);

            // this table describes the menu bar entries
            DataTable MenubarTable = new DataTable("Menu Bar Settings");
            MenubarTable.Columns.Add("Menu button Number", typeof(int));      // front panel pushbutton number
            MenubarTable.Columns.Add("Menu Action", typeof(int));             // action assigned to button (from EButtonBarActions)
            MenubarTable.Columns.Add("Menu Text", typeof(String));            // descriptive text
            MenubarTable.Columns.Add("Menu RX Selector", typeof(int));        // overrides softkey number or RX1/RX2 assignment (0: use A/B; 1: use RX1; 2: use RX2)
            MenubarTable.Columns.Add("Menu Number", typeof(int));             // softkey number to change menu to

            // create the menus, in groups of 8
            // menu 1 - quick access
            MenubarTable.Rows.Add(0, EButtonBarActions.eBBMenu, "Quick Menu", 0, 2);             // numerical parameter only for "menu" entries - points to next
            MenubarTable.Rows.Add(1, EButtonBarActions.eBBNR, "NR", 0, 0);
            MenubarTable.Rows.Add(2, EButtonBarActions.eBBNB, "NB", 0, 0);
            MenubarTable.Rows.Add(3, EButtonBarActions.eBBSNB, "SNB", 0, 0);
            MenubarTable.Rows.Add(4, EButtonBarActions.eBBANF, "ANF", 0, 0);
            MenubarTable.Rows.Add(5, EButtonBarActions.eBBAGCStep, "AGC Step", 0, 0);
            MenubarTable.Rows.Add(6, EButtonBarActions.eBBAttenStep, "Atten Step", 0, 0);
            MenubarTable.Rows.Add(7, EButtonBarActions.eBBAntennaStep, "change antenna", 0, 0);

            // menu 2 - RX
            MenubarTable.Rows.Add(8, EButtonBarActions.eBBMenu, "RX Menu", 0, 3);
            MenubarTable.Rows.Add(9, EButtonBarActions.eBBDiversityOnOff, "Diversity", 0, 0);
            MenubarTable.Rows.Add(10, EButtonBarActions.eBBDiversityForm, "Diversity Form", 0, 0);
            MenubarTable.Rows.Add(11, EButtonBarActions.eBBSliderForm, "Gain Form", 0, 0);
            MenubarTable.Rows.Add(12, EButtonBarActions.eBBFilterForm, "Filter Form", 0, 0);
            MenubarTable.Rows.Add(13, EButtonBarActions.eBBMuteOnOff, "Mute", 0, 0);
            MenubarTable.Rows.Add(14, EButtonBarActions.eBBRXAntenna, "RX Ant", 0, 0);
            MenubarTable.Rows.Add(15, EButtonBarActions.eBBNone, "----", 0, 0);

            // menu 3 - VFO
            MenubarTable.Rows.Add(16, EButtonBarActions.eBBMenu, "VFO Menu", 0, 4);
            MenubarTable.Rows.Add(17, EButtonBarActions.eBBBandForm, "Band Form", 0, 0);
            MenubarTable.Rows.Add(18, EButtonBarActions.eBBModeForm, "Mode Form", 0, 0);
            MenubarTable.Rows.Add(19, EButtonBarActions.eBBBandstackForm, "Bandstack Form", 0, 0);
            MenubarTable.Rows.Add(20, EButtonBarActions.eBBVFOSwap, "Swap A <--> B", 0, 0);
            MenubarTable.Rows.Add(21, EButtonBarActions.eBBVFOSettingForm, "Tune step Form", 0, 0);
            MenubarTable.Rows.Add(22, EButtonBarActions.eBBBandstack, "Bandstack", 0, 0);
            MenubarTable.Rows.Add(23, EButtonBarActions.eBBNone, "----", 0, 0);

            // menu 4 - TX
            MenubarTable.Rows.Add(24, EButtonBarActions.eBBMenu, "TX Menu", 0, 5);
            MenubarTable.Rows.Add(25, EButtonBarActions.eBBModeSettingsForm, "Mode settings form", 0, 0);
            MenubarTable.Rows.Add(26, EButtonBarActions.eBBPuresignalForm, "Puresignal Form", 0, 0);
            MenubarTable.Rows.Add(27, EButtonBarActions.eBBPuresignalOnOff, "Puresignal select", 0, 0);
            MenubarTable.Rows.Add(28, EButtonBarActions.eBBMOX, "MOX", 0, 0);
            MenubarTable.Rows.Add(29, EButtonBarActions.eBBTune, "TUNE", 0, 0);
            MenubarTable.Rows.Add(30, EButtonBarActions.eBBPuresignal2Tone, "PS 2 Tone test", 0, 0);
            MenubarTable.Rows.Add(31, EButtonBarActions.eBBATUOnOff, "ATU", 0, 0);

            // menu 5 - display
            MenubarTable.Rows.Add(32, EButtonBarActions.eBBMenu, "Display Menu", 0, 6);
            MenubarTable.Rows.Add(33, EButtonBarActions.eBBRXMeterStep, "RX Meter Mode Step", 0, 0);
            MenubarTable.Rows.Add(34, EButtonBarActions.eBBTXMeterStep, "TX Meter mode step", 0, 0);
            MenubarTable.Rows.Add(35, EButtonBarActions.eBBDisplayModeStep, "Display Mode Step", 0, 0);
            MenubarTable.Rows.Add(36, EButtonBarActions.eBBCentreDisplay, "Centre Display", 0, 0);
            MenubarTable.Rows.Add(37, EButtonBarActions.eBBDisplaySettingsForm, "Display Form", 0, 0);
            MenubarTable.Rows.Add(38, EButtonBarActions.eBBZoomStep, "Zoom", 0, 0);
            MenubarTable.Rows.Add(39, EButtonBarActions.eBBNone, "----", 0, 0);

            // menu 6 - audio
            MenubarTable.Rows.Add(40, EButtonBarActions.eBBMenu, "Audio Menu", 0, 7);
            MenubarTable.Rows.Add(41, EButtonBarActions.eBBRecordAudio, "Quick Record Audio", 0, 0);
            MenubarTable.Rows.Add(42, EButtonBarActions.eBBPlayAudio, "Quick Play Audio", 0, 0);
            MenubarTable.Rows.Add(43, EButtonBarActions.eBBNone, "----", 0, 0);
            MenubarTable.Rows.Add(44, EButtonBarActions.eBBAudioForm, "Audio rec/play Form", 0, 0);
            MenubarTable.Rows.Add(45, EButtonBarActions.eBBVAC1OnOff, "VAC1", 0, 0);
            MenubarTable.Rows.Add(46, EButtonBarActions.eBBVAC2OnOff, "VAC2", 0, 0);
            MenubarTable.Rows.Add(47, EButtonBarActions.eBBNone, "----", 0, 0);

            // menu 7 - setup
            MenubarTable.Rows.Add(48, EButtonBarActions.eBBMenu, "Setup Menu", 0, 1);
            MenubarTable.Rows.Add(49, EButtonBarActions.eBBDUP, "Duplex", 0, 0);
            MenubarTable.Rows.Add(50, EButtonBarActions.eBBMON, "TX Monitor", 0, 0);
            MenubarTable.Rows.Add(51, EButtonBarActions.eBBRX2OnOff, "RX2", 0, 0);
            MenubarTable.Rows.Add(52, EButtonBarActions.eBBSubRXOnOff, "Sub RX", 0, 0);
            MenubarTable.Rows.Add(53, EButtonBarActions.eBBEqualiserForm, "Equaliser Form", 0, 0);
            MenubarTable.Rows.Add(54, EButtonBarActions.eBBSetupForm, "Setup Form", 0, 0);
            MenubarTable.Rows.Add(55, EButtonBarActions.eBBMenu, "Extended Menu", 0, 8);

            // menu 8 - extended / test
            MenubarTable.Rows.Add(56, EButtonBarActions.eBBMenu, "Test Menu", 0, 1);
            MenubarTable.Rows.Add(57, EButtonBarActions.eBBQuickSave, "Quick Save", 0, 0);
            MenubarTable.Rows.Add(58, EButtonBarActions.eBBQuickRestore, "Quick Restore", 0, 0);
            MenubarTable.Rows.Add(59, EButtonBarActions.eBBFilterPlus, "filter up", 0, 0);
            MenubarTable.Rows.Add(60, EButtonBarActions.eBBFilterMinus, "filter down", 0, 0);
            MenubarTable.Rows.Add(61, EButtonBarActions.eBBBandPlus, "Band up", 0, 0);
            MenubarTable.Rows.Add(62, EButtonBarActions.eBBBandMinus, "Band down", 0, 0);
            MenubarTable.Rows.Add(63, EButtonBarActions.eBBNone, "----", 0, 0);

            // add the data tables to the dataset, and save it for next time
            AndromedaSet.Tables.Add(IndicatorTable);
            AndromedaSet.Tables.Add(ButtonTable);
            AndromedaSet.Tables.Add(EncoderTable);
            AndromedaSet.Tables.Add(MultiTable);
            AndromedaSet.Tables.Add(MenubarTable);
        }


        // create a new G2 panel dataset from scratch, if one doesn't yet exist
        // this is like a "factory reset" for the dataset if it can't be read from file
        // create tables, and add initial data to them
        private void MakeNewG2PanelDataset()
        {
            // this table holds settings for LED indicators
            // (note indicators not yet used)
            DataTable IndicatorTable = new DataTable("Indicators");
            IndicatorTable.Columns.Add("Indicator Number", typeof(int));            // console indicator number
            IndicatorTable.Columns.Add("Indicator Action", typeof(int));            // function indicated by it (from EIndicatorActions)
            IndicatorTable.Columns.Add("Indicator Description", typeof(String));    // useful text?
            IndicatorTable.Columns.Add("Indicator RX Selector", typeof(int));       // 0: insensitive to RX; 1: indicator uses show_RX1 setting; 2: for RX1; 3: for RX2
            IndicatorTable.Rows.Add(1, (int)EIndicatorActions.eINMOX, "", 0);
            IndicatorTable.Rows.Add(2, (int)EIndicatorActions.eINATUReady, "", 0);
            IndicatorTable.Rows.Add(3, (int)EIndicatorActions.eINTune, "", 0);
            IndicatorTable.Rows.Add(4, (int)EIndicatorActions.eINPuresignalEnabled, "", 0);
            IndicatorTable.Rows.Add(5, (int)EIndicatorActions.eINDiversityEnabled, "", 0);
            IndicatorTable.Rows.Add(6, (int)EIndicatorActions.eINShiftEnabled, "", 0);
            IndicatorTable.Rows.Add(7, (int)EIndicatorActions.eINCTune, "", 1);      // pick up RX1 or 2
            IndicatorTable.Rows.Add(8, (int)EIndicatorActions.eINRIT, "", 0);
            IndicatorTable.Rows.Add(9, (int)EIndicatorActions.eINXIT, "", 0);
            IndicatorTable.Rows.Add(10, (int)EIndicatorActions.eINVFOAB, "", 0);
            IndicatorTable.Rows.Add(11, (int)EIndicatorActions.eINVFOLock, "", 0);
            IndicatorTable.Rows.Add(12, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(13, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(14, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(15, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(16, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(17, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(18, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(19, (int)EIndicatorActions.eINNone, "", 0);
            IndicatorTable.Rows.Add(20, (int)EIndicatorActions.eINNone, "", 0);

            // this table holds settings for pushbuttons
            // G2 includs the shifted actions as additional button numbers
            DataTable ButtonTable = new DataTable("Pushbuttons");
            ButtonTable.Columns.Add("Pushbutton Number", typeof(int));              // front panel pushbutton number
            ButtonTable.Columns.Add("Pushbutton Action", typeof(int));              // action assigned to button (from EButtonBarActions)
            ButtonTable.Columns.Add("Pushbutton Description", typeof(String));      // descriptive text
            ButtonTable.Columns.Add("Pushbutton RX Selector", typeof(int));         // overrides softkey number or RX1/RX2 assignment (0: use A/B; 1: use RX1; 2: use RX2)
            ButtonTable.Rows.Add(1, EButtonBarActions.eBBMuteOnOff, "", 2);             // encoder 1
            ButtonTable.Rows.Add(2, EButtonBarActions.eBBMuteOnOff, "", 1);             // encoder 2
            ButtonTable.Rows.Add(3, EButtonBarActions.eBBMultiEncoderButton, "", 0);    // encoder 3
            ButtonTable.Rows.Add(4, EButtonBarActions.eBBNone, "", 0);                  // ATU button (no function yet)
            ButtonTable.Rows.Add(5, EButtonBarActions.eBBPuresignal2Tone, "", 0);
            ButtonTable.Rows.Add(6, EButtonBarActions.eBBTune, "", 0);
            ButtonTable.Rows.Add(7, EButtonBarActions.eBBMOX, "", 0);
            ButtonTable.Rows.Add(8, EButtonBarActions.eBBVFOCTUNEOnOff, "", 0);
            ButtonTable.Rows.Add(9, EButtonBarActions.eBBVFOLockOnOff, "", 0);
            ButtonTable.Rows.Add(10, EButtonBarActions.eBBToggleAB, "", 0);
            ButtonTable.Rows.Add(11, EButtonBarActions.eBBRITXITToggle, "", 0);
            ButtonTable.Rows.Add(12, EButtonBarActions.eBBClearRITXIT, "", 0);          // encoder 4
            ButtonTable.Rows.Add(13, EButtonBarActions.eBBFilterReset, "", 0);          // encoder 5
            ButtonTable.Rows.Add(14, EButtonBarActions.eBBModePlus, "", 0);
            ButtonTable.Rows.Add(15, EButtonBarActions.eBBFilterPlus, "", 0);
            ButtonTable.Rows.Add(16, EButtonBarActions.eBBBandPlus, "", 0);
            ButtonTable.Rows.Add(17, EButtonBarActions.eBBModeMinus, "", 0);
            ButtonTable.Rows.Add(18, EButtonBarActions.eBBFilterMinus, "", 0);
            ButtonTable.Rows.Add(19, EButtonBarActions.eBBBandMinus, "", 0);
            ButtonTable.Rows.Add(20, EButtonBarActions.eBBVFOAtoB, "", 0);
            ButtonTable.Rows.Add(21, EButtonBarActions.eBBVFOBtoA, "", 0);
            ButtonTable.Rows.Add(22, EButtonBarActions.eBBVFOSplit, "", 0);
            ButtonTable.Rows.Add(23, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(24, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(25, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(26, EButtonBarActions.eBBNone, "", 0);         // no assigned button
            ButtonTable.Rows.Add(27, EButtonBarActions.eBBBand160, "", 0);
            ButtonTable.Rows.Add(28, EButtonBarActions.eBBBand80, "", 0);
            ButtonTable.Rows.Add(29, EButtonBarActions.eBBBand60, "", 0);
            ButtonTable.Rows.Add(30, EButtonBarActions.eBBBand40, "", 0);
            ButtonTable.Rows.Add(31, EButtonBarActions.eBBBand30, "", 0);
            ButtonTable.Rows.Add(32, EButtonBarActions.eBBBand20, "", 0);
            ButtonTable.Rows.Add(33, EButtonBarActions.eBBBand17, "", 0);
            ButtonTable.Rows.Add(34, EButtonBarActions.eBBBand15, "", 0);
            ButtonTable.Rows.Add(35, EButtonBarActions.eBBBand12, "", 0);
            ButtonTable.Rows.Add(36, EButtonBarActions.eBBBand10, "", 0);
            ButtonTable.Rows.Add(37, EButtonBarActions.eBBBand6, "", 0);
            ButtonTable.Rows.Add(38, EButtonBarActions.eBBBandLFMF, "", 0);
            ButtonTable.Rows.Add(39, EButtonBarActions.eBBNone, "", 0);         // band shift if used
            ButtonTable.Rows.Add(40, EButtonBarActions.eBBNone, "", 0);         // mode shift if used
            ButtonTable.Rows.Add(41, EButtonBarActions.eBBDiversityOnOff, "", 0);
            ButtonTable.Rows.Add(42, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(43, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(44, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(45, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(46, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(47, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(48, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(49, EButtonBarActions.eBBNone, "", 0);
            ButtonTable.Rows.Add(50, EButtonBarActions.eBBNone, "", 0);
            // this table holds settings for rotary encoders
            DataTable EncoderTable = new DataTable("Encoders");
            EncoderTable.Columns.Add("Encoder Number", typeof(int));                // front panel pushbutton number
            EncoderTable.Columns.Add("Encoder Action", typeof(int));                // action assigned to button (from EEncoderActions)
            EncoderTable.Columns.Add("Encoder Description", typeof(String));        // descriptive text
            EncoderTable.Columns.Add("Encoder RX Selector", typeof(int));           // overrides softkey number or RX1/RX2 assignment (0: use A/B; 1: use RX1; 2: use RX2)
            EncoderTable.Rows.Add(1, EEncoderActions.eENAFGain, "", 2);             // 1A: RX2 AF
            EncoderTable.Rows.Add(2, EEncoderActions.eENAGCLevel, "", 2);           // 1B: RX2 AGC
            EncoderTable.Rows.Add(3, EEncoderActions.eENAFGain, "", 1);             // 2A: RX1 AF
            EncoderTable.Rows.Add(4, EEncoderActions.eENAGCLevel, "", 1);           // 2B: RX1 AGC
            EncoderTable.Rows.Add(5, EEncoderActions.eENMulti, "", 0);              // 3A: multifunction
            EncoderTable.Rows.Add(6, EEncoderActions.eENDrive, "", 0);              // 3B: drive
            EncoderTable.Rows.Add(7, EEncoderActions.eENRIT, "", 0);                // 4A: RIT
            EncoderTable.Rows.Add(8, EEncoderActions.eENXIT, "", 0);                // 4B: not assigned
            EncoderTable.Rows.Add(9, EEncoderActions.eENFilterHigh, "", 0);         // 5A: filter high
            EncoderTable.Rows.Add(10, EEncoderActions.eENFilterLow, "", 0);         // 5B: filter low
            EncoderTable.Rows.Add(11, EEncoderActions.eENDiversityGain, "", 0);     // 6A: diversity gain
            EncoderTable.Rows.Add(12, EEncoderActions.eENDiversityPhase, "", 0);    // 6B: diversity phase
            EncoderTable.Rows.Add(13, EEncoderActions.eENNoAction, "", 0);
            EncoderTable.Rows.Add(14, EEncoderActions.eENNoAction, "", 0);
            EncoderTable.Rows.Add(15, EEncoderActions.eENNoAction, "", 0);
            EncoderTable.Rows.Add(16, EEncoderActions.eENNoAction, "", 0);
            EncoderTable.Rows.Add(17, EEncoderActions.eENNoAction, "", 0);
            EncoderTable.Rows.Add(18, EEncoderActions.eENNoAction, "", 0);
            EncoderTable.Rows.Add(19, EEncoderActions.eENNoAction, "", 0);
            EncoderTable.Rows.Add(20, EEncoderActions.eENNoAction, "", 0);

            // this table is all the allowed options for the multifunction encoder
            DataTable MultiTable = new DataTable("Multifunction Settings");
            MultiTable.Columns.Add("Multi Number", typeof(int));          // front panel pushbutton number
            MultiTable.Columns.Add("Multi Action", typeof(int));          // action assigned to button (from EEncoderActions)
            MultiTable.Columns.Add("Multi Description", typeof(String));   // descriptive text
            MultiTable.Columns.Add("Multi RX Selector", typeof(int));     // overrides softkey number or RX1/RX2 assignment (0: use A/B; 1: use RX1; 2: use RX2)
            MultiTable.Rows.Add(0, EEncoderActions.eENMasterGain, "Master AF Gain", 0);
            MultiTable.Rows.Add(1, EEncoderActions.eENAFGain, "RX1 AF Gain", 1);
            MultiTable.Rows.Add(2, EEncoderActions.eENAFGain, "RX2 AF Gain", 2);
            MultiTable.Rows.Add(3, EEncoderActions.eENAFGain, "Sub-RX AF Gain", 3);
            MultiTable.Rows.Add(4, EEncoderActions.eENAGCLevel, "RX1 AGC", 1);
            MultiTable.Rows.Add(5, EEncoderActions.eENAGCLevel, "RX2 AGC", 2);
            MultiTable.Rows.Add(6, EEncoderActions.eENStepAtten, "RX1 Step Atten", 1);
            MultiTable.Rows.Add(7, EEncoderActions.eENStepAtten, "RX2 Step Atten", 2);
            MultiTable.Rows.Add(8, EEncoderActions.eENFilterHigh, "RX1 Filter High Cut", 1);
            MultiTable.Rows.Add(9, EEncoderActions.eENFilterLow, "RX1 Filter Low Cut", 1);

            MultiTable.Rows.Add(10, EEncoderActions.eENFilterHigh, "RX2 Filter High Cut", 2);
            MultiTable.Rows.Add(11, EEncoderActions.eENFilterLow, "RX2 Filter Low Cut", 2);
            MultiTable.Rows.Add(12, EEncoderActions.eENSquelch, "RX1 Squelch", 1);
            MultiTable.Rows.Add(13, EEncoderActions.eENSquelch, "RX2 Squelch", 2);
            MultiTable.Rows.Add(14, EEncoderActions.eENDiversityGain, "Diversity Gain", 0);
            MultiTable.Rows.Add(15, EEncoderActions.eENDiversityPhase, "Diversity Phase", 0);
            MultiTable.Rows.Add(16, EEncoderActions.eENRIT, "RIT", 0);
            MultiTable.Rows.Add(17, EEncoderActions.eENXIT, "XIT", 0);
            MultiTable.Rows.Add(18, EEncoderActions.eENRITXIT, "RIT or XIT", 0);
            MultiTable.Rows.Add(19, EEncoderActions.eENDrive, "TX Drive", 0);

            MultiTable.Rows.Add(20, EEncoderActions.eENMicGain, "Mic Gain", 0);
            MultiTable.Rows.Add(21, EEncoderActions.eENVFOATune, "VFO A Tune", 0);
            MultiTable.Rows.Add(22, EEncoderActions.eENVFOBTune, "VFO B Tune", 0);
            MultiTable.Rows.Add(23, EEncoderActions.eENVOXGain, "VOX Gain", 0);
            MultiTable.Rows.Add(24, EEncoderActions.eENVOXHold, "VOX Hold", 0);
            MultiTable.Rows.Add(25, EEncoderActions.eENCWSidetone, "CW sidetone pitch", 0);
            MultiTable.Rows.Add(26, EEncoderActions.eENCWSpeed, "CW Speed", 0);
            MultiTable.Rows.Add(27, EEncoderActions.eENCompanderThreshold, "COMP Gain", 0);
            MultiTable.Rows.Add(28, EEncoderActions.eENDisplayPan, "Display Pan", 0);
            MultiTable.Rows.Add(29, EEncoderActions.eENDisplayZoom, "Display Zoom", 0);

            MultiTable.Rows.Add(30, EEncoderActions.eENStereoBalance, "RX1 Stereo Balance", 1);
            MultiTable.Rows.Add(31, EEncoderActions.eENStereoBalance, "RX2 Stereo Balance", 2);
            MultiTable.Rows.Add(32, EEncoderActions.eENStereoBalance, "Sub-RX Stereo Balance", 3);
            MultiTable.Rows.Add(33, EEncoderActions.eENVACRX, "VAC1 RX Gain", 1);
            MultiTable.Rows.Add(34, EEncoderActions.eENVACTX, "VAC1 TX Gain", 1);
            MultiTable.Rows.Add(35, EEncoderActions.eENVACRX, "VAC2 RX Gain", 2);
            MultiTable.Rows.Add(36, EEncoderActions.eENVACTX, "VAC2 TX Gain", 2);
            MultiTable.Rows.Add(37, EEncoderActions.eENTuneStep, "VFO Tune Step", 0);

            // this table describes the menu bar entries
            DataTable MenubarTable = new DataTable("Menu Bar Settings");
            MenubarTable.Columns.Add("Menu button Number", typeof(int));      // front panel pushbutton number
            MenubarTable.Columns.Add("Menu Action", typeof(int));             // action assigned to button (from EButtonBarActions)
            MenubarTable.Columns.Add("Menu Text", typeof(String));            // descriptive text
            MenubarTable.Columns.Add("Menu RX Selector", typeof(int));        // overrides softkey number or RX1/RX2 assignment (0: use A/B; 1: use RX1; 2: use RX2)
            MenubarTable.Columns.Add("Menu Number", typeof(int));             // softkey number to change menu to

            // create the menus, in groups of 8
            // menu 1 - quick access
            MenubarTable.Rows.Add(0, EButtonBarActions.eBBMenu, "Quick Menu", 0, 2);             // numerical parameter only for "menu" entries - points to next
            MenubarTable.Rows.Add(1, EButtonBarActions.eBBNR, "NR", 0, 0);
            MenubarTable.Rows.Add(2, EButtonBarActions.eBBNB, "NB", 0, 0);
            MenubarTable.Rows.Add(3, EButtonBarActions.eBBSNB, "SNB", 0, 0);
            MenubarTable.Rows.Add(4, EButtonBarActions.eBBANF, "ANF", 0, 0);
            MenubarTable.Rows.Add(5, EButtonBarActions.eBBAGCStep, "AGC Step", 0, 0);
            MenubarTable.Rows.Add(6, EButtonBarActions.eBBAttenStep, "Atten Step", 0, 0);
            MenubarTable.Rows.Add(7, EButtonBarActions.eBBAntennaStep, "change antenna", 0, 0);

            // menu 2 - RX
            MenubarTable.Rows.Add(8, EButtonBarActions.eBBMenu, "RX Menu", 0, 3);
            MenubarTable.Rows.Add(9, EButtonBarActions.eBBDiversityOnOff, "Diversity", 0, 0);
            MenubarTable.Rows.Add(10, EButtonBarActions.eBBDiversityForm, "Diversity Form", 0, 0);
            MenubarTable.Rows.Add(11, EButtonBarActions.eBBSliderForm, "Gain Form", 0, 0);
            MenubarTable.Rows.Add(12, EButtonBarActions.eBBFilterForm, "Filter Form", 0, 0);
            MenubarTable.Rows.Add(13, EButtonBarActions.eBBMuteOnOff, "Mute", 0, 0);
            MenubarTable.Rows.Add(14, EButtonBarActions.eBBRXAntenna, "RX Ant", 0, 0);
            MenubarTable.Rows.Add(15, EButtonBarActions.eBBNone, "----", 0, 0);

            // menu 3 - VFO
            MenubarTable.Rows.Add(16, EButtonBarActions.eBBMenu, "VFO Menu", 0, 4);
            MenubarTable.Rows.Add(17, EButtonBarActions.eBBBandForm, "Band Form", 0, 0);
            MenubarTable.Rows.Add(18, EButtonBarActions.eBBModeForm, "Mode Form", 0, 0);
            MenubarTable.Rows.Add(19, EButtonBarActions.eBBBandstackForm, "Bandstack Form", 0, 0);
            MenubarTable.Rows.Add(20, EButtonBarActions.eBBVFOSwap, "Swap A <--> B", 0, 0);
            MenubarTable.Rows.Add(21, EButtonBarActions.eBBVFOSettingForm, "Tune step Form", 0, 0);
            MenubarTable.Rows.Add(22, EButtonBarActions.eBBBandstack, "Bandstack", 0, 0);
            MenubarTable.Rows.Add(23, EButtonBarActions.eBBNone, "----", 0, 0);

            // menu 4 - TX
            MenubarTable.Rows.Add(24, EButtonBarActions.eBBMenu, "TX Menu", 0, 5);
            MenubarTable.Rows.Add(25, EButtonBarActions.eBBModeSettingsForm, "Mode settings form", 0, 0);
            MenubarTable.Rows.Add(26, EButtonBarActions.eBBPuresignalForm, "Puresignal Form", 0, 0);
            MenubarTable.Rows.Add(27, EButtonBarActions.eBBPuresignalOnOff, "Puresignal select", 0, 0);
            MenubarTable.Rows.Add(28, EButtonBarActions.eBBMOX, "MOX", 0, 0);
            MenubarTable.Rows.Add(29, EButtonBarActions.eBBTune, "TUNE", 0, 0);
            MenubarTable.Rows.Add(30, EButtonBarActions.eBBPuresignal2Tone, "PS 2 Tone test", 0, 0);
            MenubarTable.Rows.Add(31, EButtonBarActions.eBBATUOnOff, "ATU", 0, 0);

            // menu 5 - display
            MenubarTable.Rows.Add(32, EButtonBarActions.eBBMenu, "Display Menu", 0, 6);
            MenubarTable.Rows.Add(33, EButtonBarActions.eBBRXMeterStep, "RX Meter Mode Step", 0, 0);
            MenubarTable.Rows.Add(34, EButtonBarActions.eBBTXMeterStep, "TX Meter mode step", 0, 0);
            MenubarTable.Rows.Add(35, EButtonBarActions.eBBDisplayModeStep, "Display Mode Step", 0, 0);
            MenubarTable.Rows.Add(36, EButtonBarActions.eBBCentreDisplay, "Centre Display", 0, 0);
            MenubarTable.Rows.Add(37, EButtonBarActions.eBBDisplaySettingsForm, "Display Form", 0, 0);
            MenubarTable.Rows.Add(38, EButtonBarActions.eBBZoomStep, "Zoom", 0, 0);
            MenubarTable.Rows.Add(39, EButtonBarActions.eBBNone, "----", 0, 0);

            // menu 6 - audio
            MenubarTable.Rows.Add(40, EButtonBarActions.eBBMenu, "Audio Menu", 0, 7);
            MenubarTable.Rows.Add(41, EButtonBarActions.eBBRecordAudio, "Quick Record Audio", 0, 0);
            MenubarTable.Rows.Add(42, EButtonBarActions.eBBPlayAudio, "Quick Play Audio", 0, 0);
            MenubarTable.Rows.Add(43, EButtonBarActions.eBBNone, "----", 0, 0);
            MenubarTable.Rows.Add(44, EButtonBarActions.eBBAudioForm, "Audio rec/play Form", 0, 0);
            MenubarTable.Rows.Add(45, EButtonBarActions.eBBVAC1OnOff, "VAC1", 0, 0);
            MenubarTable.Rows.Add(46, EButtonBarActions.eBBVAC2OnOff, "VAC2", 0, 0);
            MenubarTable.Rows.Add(47, EButtonBarActions.eBBNone, "----", 0, 0);

            // menu 7 - setup
            MenubarTable.Rows.Add(48, EButtonBarActions.eBBMenu, "Setup Menu", 0, 1);
            MenubarTable.Rows.Add(49, EButtonBarActions.eBBDUP, "Duplex", 0, 0);
            MenubarTable.Rows.Add(50, EButtonBarActions.eBBMON, "TX Monitor", 0, 0);
            MenubarTable.Rows.Add(51, EButtonBarActions.eBBRX2OnOff, "RX2", 0, 0);
            MenubarTable.Rows.Add(52, EButtonBarActions.eBBSubRXOnOff, "Sub RX", 0, 0);
            MenubarTable.Rows.Add(53, EButtonBarActions.eBBEqualiserForm, "Equaliser Form", 0, 0);
            MenubarTable.Rows.Add(54, EButtonBarActions.eBBSetupForm, "Setup Form", 0, 0);
            MenubarTable.Rows.Add(55, EButtonBarActions.eBBMenu, "Extended Menu", 0, 8);

            // menu 8 - extended / test
            MenubarTable.Rows.Add(56, EButtonBarActions.eBBMenu, "Test Menu", 0, 1);
            MenubarTable.Rows.Add(57, EButtonBarActions.eBBQuickSave, "Quick Save", 0, 0);
            MenubarTable.Rows.Add(58, EButtonBarActions.eBBQuickRestore, "Quick Restore", 0, 0);
            MenubarTable.Rows.Add(59, EButtonBarActions.eBBFilterPlus, "filter up", 0, 0);
            MenubarTable.Rows.Add(60, EButtonBarActions.eBBFilterMinus, "filter down", 0, 0);
            MenubarTable.Rows.Add(61, EButtonBarActions.eBBBandPlus, "Band up", 0, 0);
            MenubarTable.Rows.Add(62, EButtonBarActions.eBBBandMinus, "Band down", 0, 0);
            MenubarTable.Rows.Add(63, EButtonBarActions.eBBNone, "----", 0, 0);

            // add the data tables to the dataset, and save it for next time
            AndromedaSet.Tables.Add(IndicatorTable);
            AndromedaSet.Tables.Add(ButtonTable);
            AndromedaSet.Tables.Add(EncoderTable);
            AndromedaSet.Tables.Add(MultiTable);
            AndromedaSet.Tables.Add(MenubarTable);
        }



        void SaveAndromedaDataset()
        {
            string Filename = AppDataPath + "andromedadata.xml";            // XML file for the settings
            AndromedaSet.WriteXml(Filename, XmlWriteMode.WriteSchema);
            InitialiseAndromedaIndicators(true);
            currentButtonBarMenu = 0;
            UpdateButtonBarButtons();
        }

        public void ResetAndromedaDataset()
        {
            AndromedaSet.Tables.Clear();
            MakeNewAndromedaDataset();              // if no XML file, create dataset
            SaveAndromedaDataset();         //  and save file
            InitialiseAndromedaIndicators(true);
        }


        public void ResetG2PanelDataset()
        {
            AndromedaSet.Tables.Clear();
            MakeNewG2PanelDataset();              // if no XML file, create dataset
            SaveAndromedaDataset();         //  and save file
            InitialiseAndromedaIndicators(true);
        }


        //
        // indicator check
        // this is called from control CheckedChanged() handlers to see if an Andromeda indicator needs to be updated
        // this PUSHes the indicator setting to Andromeda rather than periodic polling
        // IsRX1: true for controls belonging to RX1; ignored otherwise
        // State: true if indicator should be lit
        // search the indicator table, and send message to front panel if a match is found
        //
        void AndromedaIndicatorCheck(EIndicatorActions IndicatorType, bool IsRX1, bool State)
        {
            if (!AndromedaCATEnabled) return; // MW0LGE

            int Cntr;
            int Override;                                                   // indicator table setting
            bool Selected = true;                                           // true if RX1/2 test matches
            EIndicatorActions action;

            DataTable table = AndromedaSet.Tables["Indicators"];
            int RowCount = table.Rows.Count;

            for (Cntr = 0; Cntr < RowCount; Cntr++)
            {
                action = (EIndicatorActions)table.Rows[Cntr]["Indicator Action"];
                if (action == IndicatorType)           // found a match
                {
                    Override = (int)table.Rows[Cntr]["Indicator RX Selector"];
                    if (Override == 1)                  // use show_RX1
                        Selected = (show_rx1 == IsRX1);
                    else if (Override == 2)
                        Selected = IsRX1;
                    else if (Override == 3)
                        Selected = !IsRX1;

                    if (Selected)
                        MakeIndicatorCATMsg(Cntr + 1, State);         // +1 because the s/w numbers start at zero
                }
            }
        }

        // send a CAT message to Andromeda asking for h/w and s/w versions
        private void MakeAndromedaVersionRequestMsg()
        {
            string CATMsg;

            CATMsg = "ZZZS;";
            try
            {
                AndromedaSiolisten.SIO5.put(CATMsg);
            }
            catch { }
        }

        // send a CAT message to Andromeda if enabled
        // indicator number = number to send (0-19)
        // State true if indicator should be lit
        void MakeIndicatorCATMsg(int IndicatorNumber, bool State)
        {
            string CATMsg;

            CATMsg = "ZZZI";
            CATMsg += IndicatorNumber.ToString("D2");
            if (State == true)
                CATMsg += "1;";
            else
                CATMsg += "0;";
            try
            {
                AndromedaSiolisten.SIO5.put(CATMsg);
            }
            catch { }
        }

        //
        // initialise indicators after console initialised.
        // scan through list and send required state.
        // the CAT port should have been created by this point.
        // InitialiseAll: if true, updates all; otherwise only indicators which should change when RX1/RX2 is toggled
        private void InitialiseAndromedaIndicators(bool InitialiseAll)
        {
            EIndicatorActions IndicatorType;
            int Cntr;
            int Override;
            bool Use_RX1 = false;
            bool State = false;                             // indicator state to report
            bool IsABSensitive = false;
            if (AndromedaCATEnabled)                        // only process if we have a CAT port assigned
            {

                DataTable table = AndromedaSet.Tables["Indicators"];
                int RowCount = table.Rows.Count;

                for (Cntr = 0; Cntr < RowCount; Cntr++)
                {
                    IsABSensitive = false;
                    IndicatorType = (EIndicatorActions)table.Rows[Cntr]["Indicator Action"];
                    Override = (int)table.Rows[Cntr]["Indicator RX Selector"];
                    // work out which or RX1/2 or VFO A/B buttons to use
                    if (Override == 1)               // use show_rx1 setting
                    {
                        Use_RX1 = show_rx1;
                        IsABSensitive = true;
                    }
                    else if (Override == 2)         // use RX1
                        Use_RX1 = true;
                    else if (Override == 3)         // use RX2
                        Use_RX1 = false;
                    switch (IndicatorType)
                    {
                        case EIndicatorActions.eINNone:
                            State = false;
                            break;

                        case EIndicatorActions.eINMOX:
                            State = chkMOX.Checked;
                            break;

                        case EIndicatorActions.eINTune:
                            State = chkTUN.Checked;
                            break;

                        case EIndicatorActions.eINRIT:
                            State = chkRIT.Checked;
                            break;

                        case EIndicatorActions.eINXIT:
                            State = chkXIT.Checked;
                            break;

                        case EIndicatorActions.eINSplit:
                            State = chkVFOSplit.Checked;
                            break;

                        case EIndicatorActions.eINCTune:
                            if (Use_RX1)
                                State = chkFWCATU.Checked;
                            else
                                State = chkX2TR.Checked;
                            break;

                        case EIndicatorActions.eINVFOSync:
                            State = chkVFOSync.Checked;
                            break;

                        case EIndicatorActions.eINVFOAB:
                            State = show_rx1;
                            break;

                        case EIndicatorActions.eINVFOLock:
                            if (Use_RX1)
                                State = chkVFOLock.Checked;
                            else
                                State = chkVFOBLock.Checked;
                            break;

                        case EIndicatorActions.eINNB:
                            if (Use_RX1)
                                State = chkNB.Checked;
                            else
                                State = chkRX2NB.Checked;
                            break;

                        case EIndicatorActions.eINNR:
                            if (Use_RX1)
                                State = chkNR.Checked;
                            else
                                State = chkRX2NR.Checked;
                            break;

                        case EIndicatorActions.eINSNB:
                            if (Use_RX1)
                                State = chkDSPNB2.Checked;
                            else
                                State = chkRX2NB2.Checked;
                            break;

                        case EIndicatorActions.eINANF:
                            if (Use_RX1)
                                State = chkANF.Checked;
                            else
                                State = chkRX2ANF.Checked;
                            break;

                        case EIndicatorActions.eINSquelch:
                            if (Use_RX1)
                                State = chkSquelch.Checked;
                            else
                                State = chkRX2Squelch.Checked;
                            break;

                        case EIndicatorActions.eINCompanderEnabled:
                            State = chkCPDR.Checked;
                            break;

                        case EIndicatorActions.eINPuresignalEnabled:
                            State = chkFWCATUBypass.Checked;
                            break;

                        case EIndicatorActions.eINDiversityEnabled:
                            State = Diversity2;
                            break;
                        case EIndicatorActions.eINATUReady:
                            State = AriesEnabled;
                            break;
                        case EIndicatorActions.eINShiftEnabled:
                            State = AndromedaBandButtonsEnabled;
                            break;

                    }
                    if ((InitialiseAll) || (IsABSensitive))       // send message if we are scanning all, or if A/B sensitive
                        MakeIndicatorCATMsg(Cntr + 1, State);
                }
                if (InitialiseAll)
                    MakeAndromedaVersionRequestMsg();
            }
        }


        //
        // andromeda button bar button event handlers
        //
        private void btnAndrBar1_Click(object sender, EventArgs e)
        {
            ExecuteButtonBarPress(1);
        }

        private void btnAndrBar2_Click(object sender, EventArgs e)
        {
            ExecuteButtonBarPress(2);
        }

        private void btnAndrBar3_Click(object sender, EventArgs e)
        {
            ExecuteButtonBarPress(3);
        }

        private void btnAndrBar4_Click(object sender, EventArgs e)
        {
            ExecuteButtonBarPress(4);
        }

        private void btnAndrBar5_Click(object sender, EventArgs e)
        {
            ExecuteButtonBarPress(5);
        }

        private void btnAndrBar6_Click(object sender, EventArgs e)
        {
            ExecuteButtonBarPress(6);
        }

        private void btnAndrBar7_Click(object sender, EventArgs e)
        {
            ExecuteButtonBarPress(7);
        }

        private void btnAndrBar8_Click(object sender, EventArgs e)
        {
            ExecuteButtonBarPress(8);
        }

        //
        // handle a rotational step from a front panel encoder, sent by CAT command
        // encoder = 0-19; steps = number of turns; +ve = clockwise
        //
        public void HandleFrontPanelEncoderStep(int Encoder, int Steps)
        {
            int Override = 0;                                                     // RX number override if needed
            bool UsedForSetup = false;                                            // true if we passed encoder setting to the control editor form
            EEncoderActions Action = EEncoderActions.eENNoAction;                 // assigned action for this encoder
            DataTable table = AndromedaSet.Tables["Encoders"];
            int RowCount = table.Rows.Count;
            // see if control editor form open. If it is, send encoder number to that
            if(AndromedaCATEnabled || AndromedaG2Enabled)
            {
            if (andromedaEditorForm != null)
            {
                if (andromedaEditorForm.AndromedaEditorVisible)
                {
                    andromedaEditorForm.SetEncoderNumber(Encoder);
                    UsedForSetup = true;
                }
            }
            // if we didn't send it to the editor form:
            // check the number range provided; lookup the encoder action from a table;
            // if multifunction, either update the action assigned to multi or execute that function
            // if the control editor form is open, pass the encoder number to it
            if ((Encoder >= 0) && (Encoder < RowCount) && (!UsedForSetup))
            {
                Action = (EEncoderActions)table.Rows[Encoder]["Encoder Action"];
                Override = (int)table.Rows[Encoder]["Encoder RX Selector"];
                if (Action == EEncoderActions.eENMulti)                         // if multifunction
                {
                    DataTable multitable = AndromedaSet.Tables["Multifunction Settings"];
                    int MultiCount = multitable.Rows.Count;
                    if (AndromedaMultiEncoderState == true)                     // if encoder button pressed, update the assigned option
                    {
                        EncoderUpdate(Steps, ref CurrentMultifunctionOption, 0, MultiCount - 1);      // update the selected option for multi
                                                                                                      //                        TitleBarMultifunctionString = "   multifunction encoder = " + multitable.Rows[CurrentMultifunctionOption]["Multi Description"];
                        toolStripStatusLabelAndromedaMulti.Text = multitable.Rows[CurrentMultifunctionOption]["Multi Description"].ToString();
                    }
                    else
                    {
                        Action = (EEncoderActions)multitable.Rows[CurrentMultifunctionOption]["Multi Action"];           // get the action multi is set to
                        Override = (int)multitable.Rows[CurrentMultifunctionOption]["Multi RX Selector"];           // get the RX override that multi is set to
                    }
                }
                if (Action != EEncoderActions.eENMulti)                         // if not multifunction, execute it
                    ExecuteEncoderStep(Action, Steps, Override);
            }
        }
        }


        private const int VFMSTEPCOUNT = 24;
        private int FMSteps;
        //
        // handle a rotational step from a front panel VFO encoder
        // steps = number of turns; +ve = clockwise
        // in FM mode, count several clicks before stepping VFO, to make the dial "slower"
        //
        public void HandleFrontPanelVFOEncoderStep(int Steps)
        {
            if(AndromedaG2Enabled || AndromedaCATEnabled)
            {
            if (!IsSetupFormNull)
                if (SetupForm.AndromedaFastTune)
                    Steps = CalculateFastTuneSteps(Steps);

            if (show_rx1)
            {
                if (RX1DSPMode == DSPMode.FM)
                {
                    FMSteps += Steps;                       // add the new count
                    Steps = FMSteps / VFMSTEPCOUNT;         // see if enough to move VFO
                    FMSteps = FMSteps % VFMSTEPCOUNT;       // and keep the residue
                }
                VFOAFreq = CATVFOA + (double)Steps * TuneStepList[TuneStepIndex].StepHz * 10e-7;
            }

            else
            {
                if (RX2DSPMode == DSPMode.FM)
                {
                    FMSteps += Steps;                       // add the new count
                    Steps = FMSteps / VFMSTEPCOUNT;         // see if enough to move VFO
                    FMSteps = FMSteps % VFMSTEPCOUNT;       // and keep the residue
                }
                VFOBFreq = CATVFOB + (double)Steps * TuneStepList[TuneStepIndex].StepHz * 10e-7;
            }
        }
        }

        // calculate fast tune rate. This uses a cubic calculation to increase apparent tune rate if tune knob moved more quickly.
        int CalculateFastTuneSteps(int RawSteps)
        {
            int SpeededUpSteps = 0;
            int PosSteps;                           // step count, always positive
            const double a = 0.8;
            const double b = 0.04;
            const double c = 0.005;

            double CalculatedSteps;

            if (RawSteps > 0)                       // convert to positive steps count, but remember sign
                PosSteps = RawSteps;
            else
                PosSteps = -RawSteps;

            // calculate cubic term to speed up. See spreadsheet for a,b and c values
            CalculatedSteps = a * PosSteps + b * PosSteps * PosSteps + c * PosSteps * PosSteps * PosSteps;
            if (CalculatedSteps > 200.0)
                CalculatedSteps = 200.0;                // cap on rate
            SpeededUpSteps = (int)(CalculatedSteps + 0.5);
            if (RawSteps < 0)
                SpeededUpSteps = -SpeededUpSteps;
            return SpeededUpSteps;
        }

        //
        // handle software and hardware versions from front panel Arduino controller
        // (also ATU and Ganymede PA controller)
        // handle CAT message with product ID, h/w and s/w version of attached hardware
        // will apply to at least Andromeda, Aries and Ganymede
        public int HandleAttachedHardwareID
        {
            set
            {
                int Input = value;
                int ProductID = 0;
                int HardwareVersion = 0;
                int SoftwareVersion = 0;

                ProductID = Input / 100000;
                Input = Input % 100000;
                HardwareVersion = Input / 1000;
                SoftwareVersion = Input % 1000;
                MakeAttachedVersionString(ProductID, HardwareVersion, SoftwareVersion);
            }
        }

        //
        // handle a button press from a front panel physical button, sent by CAT command
        // button = 0-98
        // state true if pressed normally; 
        // LongPress = true if a "long press" event
        // if AndromedaBandButtonsEnabled, treat as a band keypad instead
        //
        public void HandleFrontPanelButtonPress(int Button, bool State, bool LongPress)
        {
            Band BandSelected = Band.B160M;
            String BandName = "";
            EButtonBarActions BtnAction;            // assigned action for button
            int BtnParam;                           // paramter override
            DataTable table = AndromedaSet.Tables["Pushbuttons"];
            int RowCount = table.Rows.Count;
            bool UsedForSetup = false;                                            // true if we passed pushbutton setting to the control editor form

            if(AndromedaG2Enabled || AndromedaCATEnabled)
            {
            // if the control editor form is open, pass the pushbutton number to it
            if (andromedaEditorForm != null)
            {
                if (andromedaEditorForm.AndromedaEditorVisible)
                {
                    andromedaEditorForm.SetPushbuttonNumber(Button);
                    UsedForSetup = true;
                }
            }
            if (!UsedForSetup)                  // if not sent to setup form, process normally
            {
                    if(andromeda_g2_enabled)                // G2 buttons are handled differently; no shift etc
                    {
                        if (LongPress)
                        {
                            BtnAction = (EButtonBarActions)table.Rows[Button]["Pushbutton Action"];
                            BtnParam = (int)table.Rows[Button]["Pushbutton RX Selector"];
                            ExecuteButtonLongpress(BtnAction, BtnParam);       // implement the button action
                        }
                        else if (State)             // normal button press.
                        {
                            BtnAction = (EButtonBarActions)table.Rows[Button]["Pushbutton Action"];
                            BtnParam = (int)table.Rows[Button]["Pushbutton RX Selector"];
                            ExecuteButtonAction(BtnAction, BtnParam);       // implement the button action
                        }
                    }
                    else if ((Button >= 29) && (Button <= 40))               // if it's one of the buttons in 3x4 "band" grid
                {
                    // one of the band button group. If a long press- just do it
                    if(LongPress)
                    {
                        BtnAction = (EButtonBarActions)table.Rows[Button]["Pushbutton Action"];
                        BtnParam = (int)table.Rows[Button]["Pushbutton RX Selector"];
                        ExecuteButtonLongpress(BtnAction, BtnParam);       // implement the button action
                    }
                    else if (State)             // normal button press.
                    {
                        if (AndromedaBandButtonsEnabled)        // perform the "band" function of the button
                        {
                            switch (Button)
                            {
                                case 29: BandName = "160m"; BandSelected = Band.B160M; break;
                                case 30: BandName = "80m"; BandSelected = Band.B80M; break;
                                case 31: BandName = "60m"; BandSelected = Band.B60M; break;
                                case 32: BandName = "40m"; BandSelected = Band.B40M; break;
                                case 33: BandName = "30m"; BandSelected = Band.B30M; break;
                                case 34: BandName = "20m"; BandSelected = Band.B20M; break;
                                case 35: BandName = "17m"; BandSelected = Band.B17M; break;
                                case 36: BandName = "15m"; BandSelected = Band.B15M; break;
                                case 37: BandName = "12m"; BandSelected = Band.B12M; break;
                                case 38: BandName = "10m"; BandSelected = Band.B10M; break;
                                case 39: BandName = "6m"; BandSelected = Band.B6M; break;
                                case 40: BandName = "GEN"; BandSelected = Band.GEN; break;
                            }
                            // we have changed band, so setup the new band
                            if (show_rx1)                           // set RX1 or 2 band
                                SetCATBand(BandSelected);
                            else
                            {
                                SetupRX2Band(BandName);
                            }
                        }
                        else                     // perform the non band function
                        {
                            BtnAction = (EButtonBarActions)table.Rows[Button]["Pushbutton Action"];
                            BtnParam = (int)table.Rows[Button]["Pushbutton RX Selector"];
                            ExecuteButtonAction(BtnAction, BtnParam);       // implement the button action
                        }
// now decide if we need to release the "shift" action. If sticky, we don't change it.
                        if(!AndromedaStickyShift)
                        {
                            if(AndromedaBandButtonIsDefault)
                                AndromedaBandButtonsEnabled = true;          // cancel shift
                            else
                                AndromedaBandButtonsEnabled = false;          // cancel shift
                            AndromedaIndicatorCheck(EIndicatorActions.eINShiftEnabled, false, AndromedaBandButtonsEnabled);
                        }
                    }
                }
                // else - a button not in the band group
                else if ((Button >= 0) && (Button < RowCount))           // check valid button range
                {
                    BtnAction = (EButtonBarActions)table.Rows[Button]["Pushbutton Action"];
                    BtnParam = (int)table.Rows[Button]["Pushbutton RX Selector"];

                    if ((BtnAction == EButtonBarActions.eBBMenuButton) && (State == true))     // if a menu softkey button press:
                    {
                        switch (BtnParam)
                        {
                            case 0:                    // softkey 1
                            case 11:
                                btnAndrBar1_Click(null, null);
                                break;

                            case 1:                    // softkey 2
                            case 12:
                                btnAndrBar2_Click(null, null);
                                break;

                            case 2:                    // softkey 3
                            case 13:
                                btnAndrBar3_Click(null, null);
                                break;

                            case 3:                    // softkey 4
                            case 14:
                                btnAndrBar4_Click(null, null);
                                break;

                            case 4:                    // softkey 5
                            case 15:
                                btnAndrBar5_Click(null, null);
                                break;

                            case 5:                    // softkey 6
                            case 16:
                                btnAndrBar6_Click(null, null);
                                break;

                            case 6:                    // softkey 7
                            case 17:
                                btnAndrBar7_Click(null, null);
                                break;

                            case 7:                    // softkey 8
                            case 18:
                                btnAndrBar8_Click(null, null);
                                break;
                        }
                    }
                    // the button isn't in the band group or menu group
                    else
                    {
                        if (State)                                     // ordinary press
                            ExecuteButtonAction(BtnAction, BtnParam);       // implement the button action
                        else if (LongPress)
                            ExecuteButtonLongpress(BtnAction, BtnParam);       // implement the button action
                    }
                }
            }//if (!UsedForSetup)
        }
        }


        //
        // make version string for Andromeda, Aries and Ganymede
        // these arise from ZZZS; CAT messages
        //
        public void MakeAttachedVersionString(int Product, int HardwareVersion, int SoftwareVersion)
        {
            string Result;

            switch (Product)
            {
                case 1:                 // Andromeda
                    Result = "Andromeda: h/w=" + HardwareVersion;
                    Result += "  s/w=" + SoftwareVersion;
                    if (!IsSetupFormNull)
                        SetupForm.AndromedaVersionNumber = Result;
                    break;

                case 2:                 // Aries
                    Result = "Aries: h/w=" + HardwareVersion;
                    Result += "  s/w=" + SoftwareVersion;
                    if (!IsSetupFormNull)
                        SetupForm.AriesVersionNumber = Result;
                    break;

                case 3:                 // Ganymede
                    Result = "Ganymede: h/w=" + HardwareVersion;
                    Result += "  s/w=" + SoftwareVersion;
                    if (!IsSetupFormNull)
                        SetupForm.GanymedeVersionNumber = Result;
                    break;

                case 4:                 // G2
                    Result = "G2 panel: h/w=" + HardwareVersion;
                    Result += "  s/w=" + SoftwareVersion;
                    if (!IsSetupFormNull)
                        SetupForm.AndromedaVersionNumber = Result;
                    break;

                case 5:                 // G2 V2
                    Result = "G2V2 panel: h/w=" + HardwareVersion;
                    Result += "  s/w=" + SoftwareVersion;
                    if (!IsSetupFormNull)
                        SetupForm.AndromedaVersionNumber = Result;
                    break;

            }
        }

        //
        // handler for encoder steps
        // OverrideRX sets how to select the RX control used
        //   OverrideRX=0: use setting set by show_rx1 variable (from radio button)
        //   OverrideRX = 1: use RX1
        //   OverrideRX = 2: use RX2
        //   OverrideRX = 3: use Sub-RX
        // these are only relevant to some controls!
        private void ExecuteEncoderStep(EEncoderActions Action, int Steps, int OverrideRX)
        {
            bool UseRX1 = false;                                      // true if we should process actions for RX1
            bool UseSubRX = false;
            int Value;
            decimal DecValue;
            DSPMode CurrentMode;                                      // current RX mode for RX1 or RX2
            int FilterIncrement;                                                 // frequency step for filters

            if (OverrideRX == 0)          // no override
                UseRX1 = show_rx1;
            else if (OverrideRX == 3)
                UseSubRX = true;
            else if (OverrideRX == 1)     // override to RX1
                UseRX1 = true;
            else
                UseRX1 = false;

            switch (Action)
            {
                case EEncoderActions.eENNoAction:
                    break;

                case EEncoderActions.eENMasterGain:
                    Value = AF;
                    EncoderUpdate(Steps, ref Value, ptbAF.Minimum, ptbAF.Maximum);
                    AF = Value;
                    CheckGainFormAutoShow();
                    break;

                case EEncoderActions.eENAFGain:
                    if (UseSubRX)
                    {
                        Value = RX1Gain;
                        EncoderUpdate(Steps, ref Value, ptbRX1Gain.Minimum, ptbRX1Gain.Maximum);
                        RX1Gain = Value;
                        ShowAndromedaSlider(Value, ptbRX1Gain.Minimum, ptbRX1Gain.Maximum, "Sub RX AF");
                    }
                    else if (UseRX1)
                    {
                        Value = RX0Gain;
                        EncoderUpdate(Steps, ref Value, ptbRX0Gain.Minimum, ptbRX0Gain.Maximum);
                        RX0Gain = Value;
                        ShowAndromedaSlider(Value, ptbRX0Gain.Minimum, ptbRX0Gain.Maximum, "RX1 AF");
                    }
                    else
                    {
                        Value = RX2Gain;
                        EncoderUpdate(Steps, ref Value, ptbRX2Gain.Minimum, ptbRX2Gain.Maximum);
                        RX2Gain = Value;
                        ShowAndromedaSlider(Value, ptbRX2Gain.Minimum, ptbRX2Gain.Maximum, "RX2 AF");
                    }
                    CheckGainFormAutoShow();
                    break;

                case EEncoderActions.eENStereoBalance:
                    if (UseSubRX)
                    {
                        Value = PanSubRX;
                        EncoderUpdate(Steps, ref Value, ptbPanSubRX.Minimum, ptbPanSubRX.Maximum);
                        ShowAndromedaSlider(Value, ptbPanSubRX.Minimum, ptbPanSubRX.Maximum, "Sub RX balance");
                        PanSubRX = Value;
                    }
                    else if (UseRX1)
                    {
                        Value = PanMainRX;
                        EncoderUpdate(Steps, ref Value, ptbPanMainRX.Minimum, ptbPanMainRX.Maximum);
                        ShowAndromedaSlider(Value, ptbPanMainRX.Minimum, ptbPanMainRX.Maximum, "RX1 balance");
                        PanMainRX = Value;
                    }
                    else
                    {
                        Value = RX2Pan;
                        EncoderUpdate(Steps, ref Value, ptbRX2Pan.Minimum, ptbRX2Pan.Maximum);
                        ShowAndromedaSlider(Value, ptbRX2Pan.Minimum, ptbRX2Pan.Maximum, "RX2 balance");
                        RX2Pan = Value;
                    }
                    CheckGainFormAutoShow();
                    break;

                case EEncoderActions.eENAGCLevel:
                    if (UseRX1)
                    {
                        Value = RF;
                        EncoderUpdate(Steps, ref Value, ptbRF.Minimum, ptbRF.Maximum);
                        ShowAndromedaSlider(Value, ptbRF.Minimum, ptbRF.Maximum, "RX1 AGC");
                        if (Value != RF && AutoAGCRX1) AutoAGCRX1 = false; // turn off 'auto agc' only if different MW0LGE_21k8
                        RF = Value;
                    }
                    else
                    {
                        Value = RX2RF;
                        EncoderUpdate(Steps, ref Value, ptbRX2RF.Minimum, ptbRX2RF.Maximum);
                        ShowAndromedaSlider(Value, ptbRX2RF.Minimum, ptbRX2RF.Maximum, "RX2 AGC");
                        if (Value != RX2RF && AutoAGCRX2) AutoAGCRX2 = false; // turn off 'auto agc' only if different MW0LGE_21k8
                        RX2RF = Value;
                    }
                    CheckGainFormAutoShow();
                    break;

                case EEncoderActions.eENStepAtten:
                    if (UseRX1)
                    {
                        Value = SetupForm.ATTOnRX1;
                        EncoderUpdate(Steps, ref Value, (int)udRX1StepAttData.Minimum, (int)udRX1StepAttData.Maximum);
                        ShowAndromedaSlider(Value, (int)udRX1StepAttData.Minimum, (int)udRX1StepAttData.Maximum, "RX1 ATT");
                        SetupForm.ATTOnRX1 = Value;
                    }
                    else
                    {
                        Value = SetupForm.ATTOnRX2; //RX2ATT; // MW0LGE_21d step atten changes
                        EncoderUpdate(Steps, ref Value, (int)udRX2StepAttData.Minimum, (int)udRX2StepAttData.Maximum);
                        ShowAndromedaSlider(Value, (int)udRX2StepAttData.Minimum, (int)udRX2StepAttData.Maximum, "RX2 ATT");
                        /*RX2ATT*/SetupForm.ATTOnRX2 = Value; // MW0LGE_21d step atten changes
                    }
                    CheckGainFormAutoShow();
                    break;

                case EEncoderActions.eENFilterHigh:             // filter high cut - audio high frequency
                    if (UseRX1)
                    {
                        CurrentMode = RX1DSPMode;               // get operating mode
                        if ((CurrentMode == DSPMode.CWL) || (CurrentMode == DSPMode.CWU))        // smaller step for CW
                            FilterIncrement = 10;
                        else
                            FilterIncrement = 50;

                        SelectRX1VarFilter();
                        // depending on whether we are lower or upper sideband, edit filter settings
                        // lower sideband: low cut alters high filter, high cut alters low filter
                        // this is so the controls affect the resulting **audio** frequency
                        if ((CurrentMode == DSPMode.LSB) || (CurrentMode == DSPMode.CWL) || (CurrentMode == DSPMode.DIGL))      // lower sideband
                        {
                            Value = RX1FilterLow;
                            EncoderUpdate(Steps * -FilterIncrement, ref Value, (int)udFilterLow.Minimum, (int)udFilterLow.Maximum);
                            RX1FilterLow = Value;
                        }
                        else                                    // upper sideband
                        {
                            Value = RX1FilterHigh;
                            EncoderUpdate(Steps * FilterIncrement, ref Value, (int)udFilterHigh.Minimum, (int)udFilterHigh.Maximum);
                            RX1FilterHigh = Value;
                        }
                        UpdateRX1Filters(RX1FilterLow, RX1FilterHigh);
                    }
                    else                          // RX2
                    {
                        CurrentMode = RX2DSPMode;               // get operating mode
                        if ((CurrentMode == DSPMode.CWL) || (CurrentMode == DSPMode.CWU))        // smaller step for CW
                            FilterIncrement = 10;
                        else
                            FilterIncrement = 50;

                        SelectRX2VarFilter();
                        // depending on whether we are lower or upper sideband, edit filter settings
                        // lower sideband: low cut alters high filter, high cut alters low filter
                        // this is so the controls affect the resulting **audio** frequency
                        if ((CurrentMode == DSPMode.LSB) || (CurrentMode == DSPMode.CWL) || (CurrentMode == DSPMode.DIGL))      // lower sideband
                        {
                            Value = RX2FilterLow;
                            EncoderUpdate(Steps * -FilterIncrement, ref Value, (int)udRX2FilterLow.Minimum, (int)udRX2FilterLow.Maximum);
                            RX2FilterLow = Value;
                        }
                        else                                    // upper sideband
                        {
                            Value = RX2FilterHigh;
                            EncoderUpdate(Steps * FilterIncrement, ref Value, (int)udRX2FilterHigh.Minimum, (int)udRX2FilterHigh.Maximum);
                            RX2FilterHigh = Value;
                        }
                        UpdateRX2Filters(RX2FilterLow, RX2FilterHigh);
                    }
                    break;

                case EEncoderActions.eENFilterLow:             // filter low cut - audio low frequency
                    if (UseRX1)
                    {
                        CurrentMode = RX1DSPMode;               // get operating mode
                        if ((CurrentMode == DSPMode.CWL) || (CurrentMode == DSPMode.CWU))        // smaller step for CW
                            FilterIncrement = 10;
                        else
                            FilterIncrement = 50;

                        SelectRX1VarFilter();
                        // depending on whether we are lower or upper sideband, edit filter settings
                        // lower sideband: low cut alters high filter, high cut alters low filter
                        // this is so the controls affect the resulting **audio** frequency
                        if ((CurrentMode == DSPMode.LSB) || (CurrentMode == DSPMode.CWL) || (CurrentMode == DSPMode.DIGL))      // lower sideband
                        {
                            Value = RX1FilterHigh;
                            EncoderUpdate(Steps * -FilterIncrement, ref Value, (int)udFilterHigh.Minimum, (int)udFilterHigh.Maximum);
                            RX1FilterHigh = Value;
                        }
                        else                                    // upper sideband
                        {
                            Value = RX1FilterLow;
                            EncoderUpdate(Steps * FilterIncrement, ref Value, (int)udFilterLow.Minimum, (int)udFilterLow.Maximum);
                            RX1FilterLow = Value;
                        }
                        UpdateRX1Filters(RX1FilterLow, RX1FilterHigh);
                    }
                    else                                        // RX2
                    {
                        CurrentMode = RX2DSPMode;               // get operating mode
                        if ((CurrentMode == DSPMode.CWL) || (CurrentMode == DSPMode.CWU))        // smaller step for CW
                            FilterIncrement = 10;
                        else
                            FilterIncrement = 50;

                        SelectRX2VarFilter();
                        // depending on whether we are lower or upper sideband, edit filter settings
                        // lower sideband: low cut alters high filter, high cut alters low filter
                        // this is so the controls affect the resulting **audio** frequency
                        if ((CurrentMode == DSPMode.LSB) || (CurrentMode == DSPMode.CWL) || (CurrentMode == DSPMode.DIGL))      // lower sideband
                        {
                            Value = RX2FilterHigh;
                            EncoderUpdate(Steps * -FilterIncrement, ref Value, (int)udRX2FilterHigh.Minimum, (int)udRX2FilterHigh.Maximum);
                            RX2FilterHigh = Value;
                        }
                        else
                        {
                            Value = RX2FilterLow;
                            EncoderUpdate(Steps * FilterIncrement, ref Value, (int)udRX2FilterLow.Minimum, (int)udRX2FilterLow.Maximum);
                            RX2FilterLow = Value;
                        }
                        UpdateRX2Filters(RX2FilterLow, RX2FilterHigh);
                    }
                    break;

                case EEncoderActions.eENDrive:
                    Value = PWR;
                    EncoderUpdate(Steps, ref Value, ptbPWR.Minimum, ptbPWR.Maximum);
                    ShowAndromedaSlider(Value, ptbPWR.Minimum, ptbPWR.Maximum, "Drive");
                    PWR = Value;
                    CheckGainFormAutoShow();
                    break;

                case EEncoderActions.eENMicGain:
                    Value = CATMIC;
                    EncoderUpdate(Steps, ref Value, ptbMic.Minimum, ptbMic.Maximum);
                    ShowAndromedaSlider(Value, ptbMic.Minimum, ptbMic.Maximum, "Mic Gain");
                    CATMIC = Value;
                    CheckGainFormAutoShow();
                    break;

                case EEncoderActions.eENVFOATune:
                    VFOAFreq = CATVFOA + (double)Steps * TuneStepList[TuneStepIndex].StepHz * 10e-7;
                    break;

                case EEncoderActions.eENVFOBTune:
                    VFOBFreq = CATVFOB + (double)Steps * TuneStepList[TuneStepIndex].StepHz * 10e-7;
                    break;

                case EEncoderActions.eENVOXGain:
                    Value = VOXSens;
                    EncoderUpdate(Steps, ref Value, ptbVOX.Minimum, ptbVOX.Maximum);
                    ShowAndromedaSlider(Value, ptbVOX.Minimum, ptbVOX.Maximum, "VOX Gain");
                    VOXSens = Value;
                    break;

                // use steps of 50ms; and own assigned mix, max values
                case EEncoderActions.eENVOXHold:
                    Value = (int)VOXHangTime;
                    EncoderUpdate(Steps * 50, ref Value, 100, 4000);
                    ShowAndromedaSlider(Value, 100, 4000, "VOX hold");
                    VOXHangTime = Value;
                    break;

                case EEncoderActions.eENCWSidetone:
                    Value = SetupForm.CATCWPitch;
                    EncoderUpdate(Steps * 10, ref Value, (int)udCWPitch.Minimum, (int)udCWPitch.Maximum);
                    ShowAndromedaSlider(Value, (int)udCWPitch.Minimum, (int)udCWPitch.Maximum, "CW pitch");
                    SetupForm.CATCWPitch = Value;
                    break;

                case EEncoderActions.eENCWSpeed:
                    Value = CATCWSpeed;
                    EncoderUpdate(Steps, ref Value, ptbCWSpeed.Minimum, ptbCWSpeed.Maximum);
                    ShowAndromedaSlider(Value, ptbCWSpeed.Minimum, ptbCWSpeed.Maximum, "CW speed");
                    CATCWSpeed = Value;
                    break;

                case EEncoderActions.eENSquelch:
                    if (UseRX1)
                    {
                        Value = Squelch;
                        EncoderUpdate(Steps, ref Value, ptbSquelch.Minimum, ptbSquelch.Maximum);
                        ShowAndromedaSlider(Value, ptbSquelch.Minimum, ptbSquelch.Maximum, "RX1 squelch");
                        Squelch = Value;
                    }
                    else
                    {
                        Value = Squelch2;
                        EncoderUpdate(Steps, ref Value, ptbRX2Squelch.Minimum, ptbRX2Squelch.Maximum);
                        ShowAndromedaSlider(Value, ptbRX2Squelch.Minimum, ptbRX2Squelch.Maximum, "RX2 squelch");
                        Squelch2 = Value;
                    }
                    CheckGainFormAutoShow();
                    break;

                // increase/decrease gain in multiples of 0.025; limits of 0, 5.000 <-- limited to the diversity form, not 5.0 MW0LGE_[2.9.0.7]
                // in TX mode, this sets Aries inductance
                case EEncoderActions.eENDiversityGain:
                    if (chkMOX.Checked)
                        TweakAriesInductance(Steps);
                    else
                    {
                        DecValue = CATDiversityGain;
                        DecValue += Steps * 0.025m;
                        //MW0LGE_[2.9.0.7] validated in diversity form code, fixed for andromeda panel freeze up
                        //if (DecValue < 0.0m)
                        //    DecValue = 0.0m;
                        //if (DecValue > 5.0m)
                        //    DecValue = 5.0m;
                        CATDiversityGain = DecValue;
                        CheckDiversityFormAutoShow();
                    }
                    break;

                // increase phase in 5 degree steps, then wrap at +/- 180
                // in TX modes, this sets Aries Capacitance
                case EEncoderActions.eENDiversityPhase:
                    if (chkMOX.Checked)
                        TweakAriesCapacitance(Steps);
                    else
                    {
                        DecValue = CATDiversityPhase;
                        DecValue += Steps * 5.0m;
                        if (DecValue >= 180.0m) DecValue -= 360.0m;
                        else if (DecValue <= -180.0m) DecValue += 360.0m;
                        CATDiversityPhase = DecValue;
                        CheckDiversityFormAutoShow();
                    }
                    break;

                case EEncoderActions.eENCompanderThreshold:
                    Value = CPDRLevel;
                    EncoderUpdate(Steps, ref Value, ptbCPDR.Minimum, ptbCPDR.Maximum);
                    ShowAndromedaSlider(Value, ptbCPDR.Minimum, ptbCPDR.Maximum, "COMP level");
                    CPDRLevel = Value;
                    break;

                // RIT - change in steps of 10Hz
                case EEncoderActions.eENRIT:
                    Value = RITValue;
                    EncoderUpdate(Steps * 10, ref Value, (int)udRIT.Minimum, (int)udRIT.Maximum);
                    ShowAndromedaSlider(Value, (int)udRIT.Minimum, (int)udRIT.Maximum, "RIT");
                    RITValue = Value;
                    break;

                // XIT - change in steps of 10Hz
                case EEncoderActions.eENXIT:
                    Value = XITValue;
                    EncoderUpdate(Steps * 10, ref Value, (int)udXIT.Minimum, (int)udXIT.Maximum);
                    ShowAndromedaSlider(Value, (int)udXIT.Minimum, (int)udXIT.Maximum, "XIT");
                    XITValue = Value;
                    break;

                case EEncoderActions.eENRITXIT:
                    if (chkRIT.Checked)
                    {
                        Value = RITValue;
                        EncoderUpdate(Steps * 10, ref Value, (int)udRIT.Minimum, (int)udRIT.Maximum);
                        ShowAndromedaSlider(Value, (int)udRIT.Minimum, (int)udRIT.Maximum, "RIT");
                        RITValue = Value;
                    }
                    else if (chkXIT.Checked)
                    {
                        Value = XITValue;
                        EncoderUpdate(Steps * 10, ref Value, (int)udXIT.Minimum, (int)udXIT.Maximum);
                        ShowAndromedaSlider(Value, (int)udXIT.Minimum, (int)udXIT.Maximum, "XIT");
                        XITValue = Value;
                    }
                    break;

                case EEncoderActions.eENDisplayPan:
                    Value = Pan;
                    EncoderUpdate(Steps, ref Value, ptbDisplayPan.Minimum, ptbDisplayPan.Maximum);
                    ShowAndromedaSlider(Value, ptbDisplayPan.Minimum, ptbDisplayPan.Maximum, "PAN");
                    Pan = Value;
                    break;

                case EEncoderActions.eENDisplayZoom:
                    Value = Zoom;
                    EncoderUpdate(Steps, ref Value, ptbDisplayZoom.Minimum, ptbDisplayZoom.Maximum);
                    ShowAndromedaSlider(Value, ptbDisplayZoom.Minimum, ptbDisplayZoom.Maximum, "Zoom");
                    Zoom = Value;
                    break;

                case EEncoderActions.eENVACRX:
                    if (SetupForm != null)
                    {
                        if (UseRX1)
                        {
                            Value = SetupForm.VACRXGain;
                            EncoderUpdate(Steps, ref Value, -40, 40);
                            SetupForm.VACRXGain = Value;
                            ShowAndromedaSlider(Value, -40, 40, "VAC1 RX");
                        }
                        else
                        {
                            Value = SetupForm.VAC2RXGain;
                            EncoderUpdate(Steps, ref Value, -40, 40);
                            SetupForm.VAC2RXGain = Value;
                            ShowAndromedaSlider(Value, -40, 40, "VAC2 RX");
                        }
                        CheckGainFormAutoShow();
                    }
                    break;

                case EEncoderActions.eENVACTX:
                    if (SetupForm != null)
                    {
                        if (UseRX1)
                        {
                            Value = SetupForm.VACTXGain;
                            EncoderUpdate(Steps, ref Value, -40, 40);
                            SetupForm.VACTXGain = Value;
                            ShowAndromedaSlider(Value, -40, 40, "VAC1 TX");
                        }
                        else
                        {
                            Value = SetupForm.VAC2TXGain;
                            EncoderUpdate(Steps, ref Value, -40, 40);
                            SetupForm.VAC2TXGain = Value;
                            ShowAndromedaSlider(Value, -40, 40, "VAC2 TX");
                        }
                        CheckGainFormAutoShow();
                    }
                    break;

                case EEncoderActions.eENTuneStep:
                    Value = TuneStepIndex;
                    EncoderUpdate(Steps, ref Value, 0, tune_step_list.Count - 1);
                    TuneStepIndex = Value;

                    break;
                // this should never be called - handled before this!
                case EEncoderActions.eENMulti:                      // multifunction - this MUST be the last!
                    break;

            }

        }

        // method to check of the gain control form should be auto-shown if an encoder event occurred
        // called whenever an encoder event for a control on this form happens
        void CheckGainFormAutoShow()
        {
            if (!IsSetupFormNull)
            {
                if (SetupForm.AndromedaGainAutoShow)
                {
                    if (sliderForm == null || sliderForm.IsDisposed) sliderForm = new SliderSettingsForm(this);
                    Invoke(new MethodInvoker(sliderForm.FormEncoderEvent));
                }
            }
        }

        // method to check of the gain control form should be auto-shown if an encoder event occurred
        // called whenever an encoder event for a control on this form happens
        void CheckDiversityFormAutoShow()
        {
            if (!IsSetupFormNull)
            {
                if (SetupForm.AndromedaDiversityAutoShow)
                {
                    if (diversityForm == null || diversityForm.IsDisposed) diversityForm = new DiversityForm(this);
                    Invoke(new MethodInvoker(diversityForm.FormEncoderEvent));
                }
            }
        }


        // helper to display relative position of the adjusted control on the Andromeda display
        // this is a value i percent between 0 and 100, because min and max values are data type dependent
        // ideally the control will be turned off after 2s delay
        void ShowAndromedaSlider(int Value, int Min, int Max, string Label)
        {
            double PercentComplete;
            if (Max == Min)
                PercentComplete = 0.0;
            else
                PercentComplete = 100.0 * (double)(Value - Min) / (double)(Max - Min);

            tbAndromedaEncoderSlider.Value = (int)PercentComplete;
            tbAndromedaEncoderSlider.Visible = true;
            lblAndromedaEncoderSlider.Text = Label;
            lblAndromedaEncoderSlider.Visible = true;
            // ideally at this point: set up a timer callback for 2 seconds

            AndromedaTimer.Enabled = false;
            AndromedaTimer.AutoReset = false;                   // just one callback
            AndromedaTimer.Interval = 5000;                     // 5 seconds
            AndromedaTimer.Enabled = true;
        }


        private void Callback(object source, ElapsedEventArgs e)
        {
            lblAndromedaEncoderSlider.Visible = false;
            tbAndromedaEncoderSlider.Visible = false;
            AndromedaTimer.Enabled = false;
        }


        //
        // helper to clip an encoder adjusted value at the min and max allowed
        // Steps     number of encoder steps to add/subtract
        // value     the control value being edited
        // Minimum   min allowed value for control
        // maximum   max allowed value for control
        public void EncoderUpdate(int Steps, ref int Value, int Minimum, int Maximum)
        {
            Value += Steps;
            if (Value < Minimum)                    // clip at lower limit
                Value = Minimum;
            if (Value > Maximum)                    // clip at upper limit
                Value = Maximum;
        }

        //
        // execute events for menu button bar presses
        // called with a button number; finds the action assigned and implements it
        //
        private void ExecuteButtonBarPress(int ButtonNumber)
        {
            int button;                                             // button to press
            EButtonBarActions assignedAction;
            int Override;                                           // 0: no override; 1: RX1; 2: RX2
            DataTable table = AndromedaSet.Tables["Menu Bar Settings"];
            int RowCount = table.Rows.Count;


            if ((ButtonNumber >= 1) && (ButtonNumber <= 8))         // check range!
            {
                button = (ButtonNumber - 1) + currentButtonBarMenu * 8;
                assignedAction = (EButtonBarActions)table.Rows[button]["Menu Action"];
                Override = (int)table.Rows[button]["Menu RX Selector"];

                if (assignedAction == EButtonBarActions.eBBMenu)
                {
                    currentButtonBarMenu = (int)table.Rows[button]["Menu Number"] - 1;     // menu number turned into row number
                    UpdateButtonBarButtons();
                }
                else
                    ExecuteButtonAction(assignedAction, Override);

                // now set 10s timeout timer, unless menus are set to be "sticky"
                // after timeout, menu will change to the 1st "quick" menu
                if(!AndromedaStickyMenus)
                {
                    AndromedaMenuTimer.Enabled = false;
                    AndromedaMenuTimer.AutoReset = false;                   // just one callback
                    AndromedaMenuTimer.Interval = 10000;                    // 10 seconds
                    AndromedaMenuTimer.Enabled = true;
                }

            }
        }

        //
        // callback for andromeda menu timer. If it times out,
        // a menu hasn't been touched for 10 seconds so reset to 1st menu
        //
        private void AndromedaMenuTimerCallback(object source, ElapsedEventArgs e)
        {
            AndromedaMenuTimer.Enabled = false;         // turn off timer
            currentButtonBarMenu = 0;                   // menu number now = 0
            UpdateButtonBarButtons();                   // redraw menus
        }



        //
        // execute a single button press action
        // this can be invoked by a menu button press or front panel button press
        private void ExecuteButtonAction(EButtonBarActions assignedAction, int OverrideRX)
        {
            bool UseRX1;                                            // true if we should process actions for RX1
            if (OverrideRX == 0)          // no override
                UseRX1 = show_rx1;
            else if (OverrideRX == 1)     // override to RX1
                UseRX1 = true;
            else
                UseRX1 = false;

            switch (assignedAction)
            {
                case EButtonBarActions.eBBNone:
                    break;

                case EButtonBarActions.eBBBand160:
                    if (show_rx1)                           // set RX1 or 2 band
                        SetCATBand(Band.B160M);
                    else
                        SetupRX2Band("160m");
                    break;

                case EButtonBarActions.eBBBand80:
                    if (show_rx1)                           // set RX1 or 2 band
                        SetCATBand(Band.B80M);
                    else
                        SetupRX2Band("80m");
                    break;

                case EButtonBarActions.eBBBand60:
                    if (show_rx1)                           // set RX1 or 2 band
                        SetCATBand(Band.B60M);
                    else
                        SetupRX2Band("60m");
                    break;

                case EButtonBarActions.eBBBand40:
                    if (show_rx1)                           // set RX1 or 2 band
                        SetCATBand(Band.B40M);
                    else
                        SetupRX2Band("40m");
                    break;

                case EButtonBarActions.eBBBand30:
                    if (show_rx1)                           // set RX1 or 2 band
                        SetCATBand(Band.B30M);
                    else
                        SetupRX2Band("30m");
                    break;

                case EButtonBarActions.eBBBand20:
                    if (show_rx1)                           // set RX1 or 2 band
                        SetCATBand(Band.B20M);
                    else
                        SetupRX2Band("20m");
                    break;

                case EButtonBarActions.eBBBand17:
                    if (show_rx1)                           // set RX1 or 2 band
                        SetCATBand(Band.B17M);
                    else
                        SetupRX2Band("17m");
                    break;

                case EButtonBarActions.eBBBand15:
                    if (show_rx1)                           // set RX1 or 2 band
                        SetCATBand(Band.B15M);
                    else
                        SetupRX2Band("15m");
                    break;

                case EButtonBarActions.eBBBand12:
                    if (show_rx1)                           // set RX1 or 2 band
                        SetCATBand(Band.B12M);
                    else
                        SetupRX2Band("12m");
                    break;

                case EButtonBarActions.eBBBand10:
                    if (show_rx1)                           // set RX1 or 2 band
                        SetCATBand(Band.B10M);
                    else
                        SetupRX2Band("10m");
                    break;

                case EButtonBarActions.eBBBand6:
                    if (show_rx1)                           // set RX1 or 2 band
                        SetCATBand(Band.B60M);
                    else
                        SetupRX2Band("6m");
                    break;

                case EButtonBarActions.eBBBandLFMF:
                    if (show_rx1)                           // set RX1 or 2 band
                        SetCATBand(Band.GEN);
                    else
                        SetupRX2Band("GEN");
                    break;


                case EButtonBarActions.eBBStartStop:               // start/stop the radio
                    chkPower.Checked = !chkPower.Checked;
                    break;

                case EButtonBarActions.eBBRX2OnOff:                // toggle RX2 on/off
                    chkRX2.Checked = !chkRX2.Checked;
                    break;

                case EButtonBarActions.eBBDUP:                      // DUPlex on/off
                    chkRX2SR.Checked = !chkRX2SR.Checked;
                    break;

                case EButtonBarActions.eBBMON:                      // monitor on/off
                    chkMON.Checked = !chkMON.Checked;
                    break;

                case EButtonBarActions.eBBTune:                    // Tune on/off
                    chkTUN.Checked = !chkTUN.Checked;
                    break;

                case EButtonBarActions.eBBMOX:                     // MOX on/off
                    chkMOX.Checked = !chkMOX.Checked;
                    break;

                case EButtonBarActions.eBBPuresignalOnOff:         // toggle Puresignal on/off
                    chkFWCATUBypass.Checked = !chkFWCATUBypass.Checked;
                    break;

                case EButtonBarActions.eBBPuresignal2Tone:         // puresignal 2 tone test on/off
                    if (CATTTTest == 0) CATTTTest = 1; else CATTTTest = 0;
                    break;

                case EButtonBarActions.eBBNR:
                    if (UseRX1)
                    {
                        if (chkNR.CheckState == CheckState.Unchecked) chkNR.CheckState = CheckState.Checked;       // off to NR
                        else if (chkNR.CheckState == CheckState.Checked) chkNR.CheckState = CheckState.Indeterminate;       // NR to NR2
                        else chkNR.CheckState = CheckState.Unchecked;
                    }
                    else
                    {
                        if (chkRX2NR.CheckState == CheckState.Unchecked) chkRX2NR.CheckState = CheckState.Checked;       // off to NR
                        else if (chkRX2NR.CheckState == CheckState.Checked) chkRX2NR.CheckState = CheckState.Indeterminate;       // NR to NR2
                        else chkRX2NR.CheckState = CheckState.Unchecked;
                    }
                    break;

                case EButtonBarActions.eBBNB:
                    if (UseRX1)
                    {
                        if (chkNB.CheckState == CheckState.Unchecked) chkNB.CheckState = CheckState.Checked;       // off to NR
                        else if (chkNB.CheckState == CheckState.Checked) chkNB.CheckState = CheckState.Indeterminate;       // NR to NR2
                        else chkNB.CheckState = CheckState.Unchecked;
                    }
                    else
                    {
                        if (chkRX2NB.CheckState == CheckState.Unchecked) chkRX2NB.CheckState = CheckState.Checked;       // off to NR
                        else if (chkRX2NB.CheckState == CheckState.Checked) chkRX2NB.CheckState = CheckState.Indeterminate;       // NR to NR2
                        else chkRX2NB.CheckState = CheckState.Unchecked;
                    }
                    break;

                case EButtonBarActions.eBBSNB:
                    if (UseRX1) chkDSPNB2.Checked = !chkDSPNB2.Checked; else chkRX2NB2.Checked = !chkRX2NB2.Checked;
                    break;

                case EButtonBarActions.eBBANF:
                    if (UseRX1) chkANF.Checked = !chkANF.Checked; else chkRX2ANF.Checked = !chkRX2ANF.Checked;
                    break;

                case EButtonBarActions.eBBMNF:
                    chkTNF.Checked = !chkTNF.Checked;
                    break;

                case EButtonBarActions.eBBVFOSwap:                 // press VFO swap button
                    btnVFOSwap_Click(null, null);
                    break;

                case EButtonBarActions.eBBVFOSplit:                // split operation
                    chkVFOSplit.Checked = !chkVFOSplit.Checked;
                    break;

                case EButtonBarActions.eBBVFOAtoB:                 // copy A to B
                    btnVFOAtoB_Click(null, null);
                    break;

                case EButtonBarActions.eBBVFOBtoA:                 // copy B to A
                    btnVFOBtoA_Click(null, null);
                    break;

                case EButtonBarActions.eBBVFOZeroBeat:             // operate zero beat button
                    btnZeroBeat_Click(null, null);
                    break;

                case EButtonBarActions.eBBIFtoV:                   // operate IF->V button
                    btnIFtoVFO_Click(null, null);
                    break;

                case EButtonBarActions.eBBVFOSyncOnOff:            // VFO sync
                    chkVFOSync.Checked = !chkVFOSync.Checked;
                    break;

                case EButtonBarActions.eBBVFOLockOnOff:            // VFO Lock
                    if (UseRX1)
                        chkVFOLock.Checked = !chkVFOLock.Checked;
                    else
                        chkVFOBLock.Checked = !chkVFOBLock.Checked;
                    break;

                case EButtonBarActions.eBBVFOCTUNEOnOff:           // Click Tune
                    if (UseRX1)
                        chkFWCATU.Checked = !chkFWCATU.Checked;
                    else
                        chkX2TR.Checked = !chkX2TR.Checked;
                    break;

                case EButtonBarActions.eBBToggleAB:                // toggle between A & B
                    if (CATRX1RX2RadioButton == 0) CATRX1RX2RadioButton = 1; else CATRX1RX2RadioButton = 0;
                    break;

                case EButtonBarActions.eBBRITOnOff:                // toggle RIT on/off
                    chkRIT.Checked = !chkRIT.Checked;
                    break;

                case EButtonBarActions.eBBXITOnOff:                // toggle XIT on/off
                    chkXIT.Checked = !chkXIT.Checked;
                    break;

                case EButtonBarActions.eBBRITXITToggle:            // step off-RIT-XIT
                    if (chkRIT.Checked)
                    {
                        chkRIT.Checked = false;
                        chkXIT.Checked = true;
                    }
                    else if (chkXIT.Checked)
                    {
                        chkRIT.Checked = false;
                        chkXIT.Checked = false;
                    }
                    else
                    {
                        chkRIT.Checked = true;
                        chkXIT.Checked = false;
                    }
                    break;

                case EButtonBarActions.eBBClearRITXIT:             // clear RIT and XIT
                    udRIT.Value = 0;
                    udXIT.Value = 0;
                    break;

                case EButtonBarActions.eBBClearRIT:                // clear RIT only
                    udRIT.Value = 0;
                    break;

                case EButtonBarActions.eBBClearXIT:                // clear XIT only
                    udXIT.Value = 0;
                    break;

                case EButtonBarActions.eBBRITPlus:                 // RIT step up
                    RITValue += 10;                                 // same code as CATCommands
                    break;

                case EButtonBarActions.eBBRITMinus:                // RIT step down
                    RITValue -= 10;                                 // same code as CATCommands
                    break;

                case EButtonBarActions.eBBXITPlus:                 // XIT step up
                    XITValue += 10;                                 // same code as CATCommands
                    break;

                case EButtonBarActions.eBBXITMinus:                // XIT step down
                    XITValue -= 10;                                 // same code as CATCommands
                    break;

                case EButtonBarActions.eBBRITXITPlus:              // RIT/XIT up - whichever is selected
                    if (chkRIT.Checked) RITValue += 10; else if (chkXIT.Checked) XITValue += 10;
                    break;

                case EButtonBarActions.eBBRITXITMinus:             // RIT/XIT down - whichever is selected
                    if (chkRIT.Checked) RITValue -= 10; else if (chkXIT.Checked) XITValue -= 10;
                    break;

                case EButtonBarActions.eBBFilterReset:             // reset variable filter
                    btnFilterShiftReset_Click(null, null);
                    break;

                // filter enum runs from F1 to VAR2
                case EButtonBarActions.eBBFilterPlus:              // select next filter
                    if (UseRX1)
                    { if (RX1Filter != Filter.VAR2) RX1Filter = (Filter)((int)RX1Filter + 1); }
                    else
                    { if (RX2Filter != Filter.VAR2) RX2Filter = (Filter)((int)RX2Filter + 1); }
                    break;

                case EButtonBarActions.eBBFilterMinus:             // select next lower filter
                    if (UseRX1)
                    { if (RX1Filter != Filter.F1) RX1Filter = (Filter)((int)RX1Filter - 1); }
                    else
                    { if (RX2Filter != Filter.F1) RX2Filter = (Filter)((int)RX2Filter - 1); }
                    break;

                // Band enum for HF covers b160m to b6m
                case EButtonBarActions.eBBBandPlus:                // step up band
                    if (UseRX1)
                    { if (RX1Band != Band.B6M) SetCATBand((Band)((int)RX1Band + 1)); }
                    else
                    { if (RX2Band != Band.B6M) RX2Band = (Band)((int)RX2Band + 1); }
                    break;

                case EButtonBarActions.eBBBandMinus:               // step down band
                    if (UseRX1)
                    { if (RX1Band != Band.B160M) SetCATBand((Band)((int)RX1Band - 1)); }
                    else
                    { if (RX2Band != Band.B160M) RX2Band = (Band)((int)RX2Band - 1); }
                    break;

                // DSPMode enum runs from LSB to DRM
                case EButtonBarActions.eBBModePlus:                // step up mode
                    if (UseRX1)
                    { if (RX1DSPMode != DSPMode.DRM) RX1DSPMode = (DSPMode)((int)RX1DSPMode + 1); }
                    else
                    { if (RX2DSPMode != DSPMode.DRM) RX2DSPMode = (DSPMode)((int)RX2DSPMode + 1); }
                    break;

                case EButtonBarActions.eBBModeMinus:               // step down mode
                    if (UseRX1)
                    { if (RX1DSPMode != DSPMode.LSB) RX1DSPMode = (DSPMode)((int)RX1DSPMode - 1); }
                    else
                    { if (RX2DSPMode != DSPMode.LSB) RX2DSPMode = (DSPMode)((int)RX2DSPMode - 1); }
                    break;

                case EButtonBarActions.eBBAttenStep:               // step the attenuation value in 6dB steps
                    if (UseRX1)
                    {
                        if (udRX1StepAttData.Value < 6) udRX1StepAttData.Value = 6;
                        else if (udRX1StepAttData.Value < 12) udRX1StepAttData.Value = 12;
                        else if (udRX1StepAttData.Value < 18) udRX1StepAttData.Value = 18;
                        else if (udRX1StepAttData.Value < 24) udRX1StepAttData.Value = 24;
                        else if (udRX1StepAttData.Value < 30) udRX1StepAttData.Value = 30;
                        else udRX1StepAttData.Value = 0;
                    }
                    else
                    {
                        if (udRX2StepAttData.Value < 6) udRX2StepAttData.Value = 6;
                        else if (udRX2StepAttData.Value < 12) udRX2StepAttData.Value = 12;
                        else if (udRX2StepAttData.Value < 18) udRX2StepAttData.Value = 18;
                        else if (udRX2StepAttData.Value < 24) udRX2StepAttData.Value = 24;
                        else if (udRX2StepAttData.Value < 30) udRX2StepAttData.Value = 30;
                        else udRX2StepAttData.Value = 0;
                    }
                    break;

                case EButtonBarActions.eBBMuteOnOff:               // mute on/off
                    if (UseRX1)
                        chkMUT.Checked = !chkMUT.Checked;
                    else
                        chkRX2Mute.Checked = !chkRX2Mute.Checked;
                    break;

                case EButtonBarActions.eBBBINOnOff:                // Binaural on/off
                    if (UseRX1)
                        chkBIN.Checked = !chkBIN.Checked;
                    else
                        chkRX2BIN.Checked = !chkRX2BIN.Checked;
                    break;

                case EButtonBarActions.eBBSDOnOff:                 // stereo diversity on/off
                    chkDX.Checked = !chkDX.Checked;
                    break;

                case EButtonBarActions.eBBVAC1OnOff:               // toggle VAC1 on/off
                    chkVAC1.Checked = !chkVAC1.Checked;
                    break;

                case EButtonBarActions.eBBVAC2OnOff:               // toggle VAC2 on/off
                    chkVAC2.Checked = !chkVAC2.Checked;
                    break;

                case EButtonBarActions.eBBAGCStep:                 // step the AGC setting
                    if (UseRX1)
                    {
                        if (comboAGC.SelectedIndex < comboAGC.Items.Count - 1)
                            comboAGC.SelectedIndex++;
                        else
                            comboAGC.SelectedIndex = 0;
                    }
                    else
                    {
                        if (comboRX2AGC.SelectedIndex < comboRX2AGC.Items.Count - 1)
                            comboRX2AGC.SelectedIndex++;
                        else
                            comboRX2AGC.SelectedIndex = 0;
                    }
                    break;

                case EButtonBarActions.eBBSqlOnOff:                // step the squelch setting
                    if (UseRX1)
                        chkSquelch.Checked = !chkSquelch.Checked;
                    else
                        chkRX2Squelch.Checked = !chkRX2Squelch.Checked;
                    break;

                case EButtonBarActions.eBBRXEQOnOff:               // RX equaliser on/off
                    chkRXEQ.Checked = !chkRXEQ.Checked;
                    break;

                case EButtonBarActions.eBBTXEQOnOff:               // TX equaliser on/off
                    chkTXEQ.Checked = !chkTXEQ.Checked;
                    break;

                case EButtonBarActions.eBBTXFLShow:                // show TX filter
                    chkShowTXFilter.Checked = !chkShowTXFilter.Checked;
                    break;

                case EButtonBarActions.eBBMICOnOff:                // MIC button on/off
                    chkMicMute.Checked = !chkMicMute.Checked;
                    break;

                case EButtonBarActions.eBBCOMPOnOff:               // COMP button on/off
                    chkCPDR.Checked = !chkCPDR.Checked;
                    break;

                case EButtonBarActions.eBBVOXOnOff:                // VOX on/off
                    chkVOX.Checked = !chkVOX.Checked;
                    break;

                case EButtonBarActions.eBBDEXPOnOff:               // DEXP on/off
                    chkNoiseGate.Checked = !chkNoiseGate.Checked;
                    break;

                case EButtonBarActions.eBBCWIambic:                // iambic keyer selected
                    chkCWIambic.Checked = !chkCWIambic.Checked;
                    break;

                case EButtonBarActions.eBBCWSidetone:              // CW sidetone
                    chkCWSidetone.Checked = !chkCWSidetone.Checked;
                    break;

                case EButtonBarActions.eBBCWShowTX:                // CW show tX frequency
                    chkShowTXCWFreq.Checked = !chkShowTXCWFreq.Checked;
                    break;

                case EButtonBarActions.eBBCWShowZero:              // show CW zero freq
                    chkShowCWZero.Checked = !chkShowCWZero.Checked;
                    break;

                case EButtonBarActions.eUnusedButton1:           // spare button
                    break;

                case EButtonBarActions.eBBCWQSK:                   // Break-In manual/semi/qsk
                    if (chkQSK.CheckState == CheckState.Unchecked) chkQSK.CheckState = CheckState.Checked;           // manual break-in to semi break-in
                    else if (chkQSK.CheckState == CheckState.Checked) chkQSK.CheckState = CheckState.Indeterminate;  // semi break-in to QSK
                    else chkQSK.CheckState = CheckState.Unchecked;
                    break;

                case EButtonBarActions.eBBRX1APF:                  // RX1 APF on/off
                    chkCWAPFEnabled.Checked = !chkCWAPFEnabled.Checked;
                    break;

                case EButtonBarActions.eBBCTCSSOnOff:              // FM CTCSS tone on/off
                    chkFMCTCSS.Checked = !chkFMCTCSS.Checked;
                    break;

                case EButtonBarActions.eBBFMDeviation:             // Toggle FM Deviation
                    if (radFMDeviation2kHz.Checked) radFMDeviation5kHz.Checked = true; else radFMDeviation2kHz.Checked = true;
                    break;

                case EButtonBarActions.eBBDiversityOnOff:          // toggle diversity on/off
                    CATDiversityEnable = !CATDiversityEnable;
                    break;

                case EButtonBarActions.eBBSubRXOnOff:              // toggle sub-RX on/off
                    chkEnableMultiRX.Checked = !chkEnableMultiRX.Checked;
                    break;

                case EButtonBarActions.eBBRXMeterStep:             // step the setting of the RX meter
                    if (UseRX1)
                    {
                        if (comboMeterRXMode.SelectedIndex < comboMeterRXMode.Items.Count - 1)
                            comboMeterRXMode.SelectedIndex++;
                        else
                            comboMeterRXMode.SelectedIndex = 0;
                    }
                    else
                    {
                        if (comboRX2MeterMode.SelectedIndex < comboRX2MeterMode.Items.Count - 1)
                            comboRX2MeterMode.SelectedIndex++;
                        else
                            comboRX2MeterMode.SelectedIndex = 0;
                    }
                    break;

                case EButtonBarActions.eBBTXMeterStep:             // step the setting of the TX meter
                    if (comboMeterTXMode.SelectedIndex < comboMeterTXMode.Items.Count - 1)
                        comboMeterTXMode.SelectedIndex++;
                    else
                        comboMeterTXMode.SelectedIndex = 0;
                    break;

                case EButtonBarActions.eBBDisplayModeStep:         // step the display mode
                    if (UseRX1)
                    {
                        if (comboDisplayMode.SelectedIndex < comboDisplayMode.Items.Count - 1)
                            comboDisplayMode.SelectedIndex++;
                        else
                            comboDisplayMode.SelectedIndex = 0;
                    }
                    else
                    {
                        if (comboRX2DisplayMode.SelectedIndex < comboRX2DisplayMode.Items.Count - 1)
                            comboRX2DisplayMode.SelectedIndex++;
                        else
                            comboRX2DisplayMode.SelectedIndex = 0;
                    }
                    break;

                case EButtonBarActions.eBBDisplayDSPAVG:           // display DSP AVG button
                    if (UseRX1)
                        chkDisplayAVG.Checked = !chkDisplayAVG.Checked;
                    else
                        chkRX2DisplayAVG.Checked = !chkRX2DisplayAVG.Checked;
                    break;

                case EButtonBarActions.eBBDisplayDSPPeak:          // display DSP PEAK button
                    if (UseRX1)
                        chkDisplayPeak.Checked = !chkDisplayPeak.Checked;
                    else
                        chkRX2DisplayPeak.Checked = !chkRX2DisplayPeak.Checked;
                    break;

                case EButtonBarActions.eBBCentreDisplay:           // centre the display
                    btnDisplayPanCenter_Click(null, null);
                    break;

                case EButtonBarActions.eBBZoomStep:                // step between the zoom step buttons
                    if (radDisplayZoom05.Checked) radDisplayZoom1x.Checked = true;
                    else if (radDisplayZoom1x.Checked) radDisplayZoom2x.Checked = true;
                    else if (radDisplayZoom2x.Checked) radDisplayZoom4x.Checked = true;
                    else radDisplayZoom05.Checked = true;
                    break;

                case EButtonBarActions.eBBRecordAudio:             // record audio
                    ckQuickRec.Checked = !ckQuickRec.Checked;
                    break;

                case EButtonBarActions.eBBPlayAudio:                 // play audio: parameter identifies which audio
                    ckQuickPlay.Checked = !ckQuickPlay.Checked;
                    break;

                case EButtonBarActions.eBBModeForm:
                    if (modePopupForm == null || modePopupForm.IsDisposed) modePopupForm = new ModeButtonsPopup(this);
                    Skin.Restore(CurrentSkin, AppDataPath, modePopupForm);
                    Invoke(new MethodInvoker(modePopupForm.Show));
                    break;

                case EButtonBarActions.eBBFilterForm:
                    if (filterPopupForm == null || filterPopupForm.IsDisposed) filterPopupForm = new FilterButtonsPopup(this);
                    Skin.Restore(CurrentSkin, AppDataPath, filterPopupForm);
                    Invoke(new MethodInvoker(filterPopupForm.Show));
                    break;

                case EButtonBarActions.eBBBandForm:
                    if (bandPopupForm == null || bandPopupForm.IsDisposed) bandPopupForm = new BandButtonsPopup(this);
                    Skin.Restore(CurrentSkin, AppDataPath, bandPopupForm);
                    Invoke(new MethodInvoker(bandPopupForm.RepopulateForm));
                    Invoke(new MethodInvoker(bandPopupForm.Show));
                    break;

                case EButtonBarActions.eBBSliderForm:
                    if (sliderForm == null || sliderForm.IsDisposed) sliderForm = new SliderSettingsForm(this);
                    Skin.Restore(CurrentSkin, AppDataPath, sliderForm);
                    Invoke(new MethodInvoker(sliderForm.Show));
                    break;

                case EButtonBarActions.eBBVFOSettingForm:          // show VFO Settings form
                    if (VFOSettingsForm == null || VFOSettingsForm.IsDisposed) VFOSettingsForm = new VFOSettingsPopup(this);
                    Skin.Restore(CurrentSkin, AppDataPath, VFOSettingsForm);
                    Invoke(new MethodInvoker(VFOSettingsForm.Show));
                    break;

                case EButtonBarActions.eBBBandstackForm:           // show band stacks form
                    //if (StackForm == null || StackForm.IsDisposed) StackForm = new StackControl(this);
                    //Invoke(new MethodInvoker(StackForm.Show));
                    //StackForm.Focus();
                    //StackForm.WindowState = FormWindowState.Normal; // ke9ns add

                    Invoke(new MethodInvoker(BandStack2Form.Show)); //MW0LGE_21d BandStack2
                    break;

                case EButtonBarActions.eBBBandstack:
                    SetCATBand(RX1Band);
                    break;

                case EButtonBarActions.eBBQuickSave:               // save to "quick memory"
                    btnMemoryQuickSave_Click(null, null);
                    break;

                case EButtonBarActions.eBBQuickRestore:            // restore from "quick memory"
                    btnMemoryQuickRestore_Click(null, null);
                    break;

                case EButtonBarActions.eBBRXAntenna:               // RX antenna button equivalent
                    chkRxAnt.Checked = !chkRxAnt.Checked;
                    break;


                case EButtonBarActions.eBBDiversityForm:           // show the diversity form
                    CATDiversityForm = true;
                    break;

                case EButtonBarActions.eBBModeSettingsForm:        // show the "mode dependent settings" form
                    if (modeDependentSettingsForm == null || modeDependentSettingsForm.IsDisposed) modeDependentSettingsForm = new ModeDependentSettingsForm(this);

                    Invoke(new MethodInvoker(modeDependentSettingsForm.Show));

                    setupModePanels();

                    SelectModeDependentPanel();
                    break;

                case EButtonBarActions.eBBPuresignalForm:          // show the Puresignal form
                    if (psform == null || psform.IsDisposed)
                        psform = new PSForm(this);
                    Invoke(new MethodInvoker(psform.Show));
                    break;

                case EButtonBarActions.eBBEqualiserForm:           // show equaliser form
                    if (EQForm == null || EQForm.IsDisposed)
                        EQForm = new EQForm(this);
                    Invoke(new MethodInvoker(EQForm.Show));
                    break;

                case EButtonBarActions.eBBDisplaySettingsForm:    // show the display settings form
                    if (displaySettingsForm == null || displaySettingsForm.IsDisposed) displaySettingsForm = new DisplaySettingsForm(this);
                    Invoke(new MethodInvoker(displaySettingsForm.Show));
                    break;

                case EButtonBarActions.eBBAudioForm:               // open the audio record play form
                    if (WaveForm.IsDisposed)
                        WaveForm = new WaveControl(this);
                    Invoke(new MethodInvoker(WaveForm.Show));
                    break;

                case EButtonBarActions.eBBSetupForm:               // open the setup form
                    if (IsSetupFormNull)
                        //SetupForm = new Setup(this);
                        //Invoke(new MethodInvoker(SetupForm.Show));
                        //setupToolStripMenuItem_Click(this, EventArgs.Empty);
                        setupToolStripMenuItem1_Click(this, EventArgs.Empty);
                    break;

                case EButtonBarActions.eBBATUOnOff:                  // Auto ATU on/off
                    int idx = (int)TXBand - (int)Band.B160M;         // get TX band then look up the antenna in use
                    int TXAntenna = 0;
                    if (idx < ARIESANTARRAYSIZE)
                    {
                        TXAntenna = AntennaArrayByBand[idx];
                        if (!IsSetupFormNull)
                            SetupForm.SetAriesEnabledButton(TXAntenna, !AriesEnabled);
                    }
                    AndromedaIndicatorCheck(EIndicatorActions.eINATUReady, true, AriesEnabled);

                    break;

                case EButtonBarActions.eBBMenuButton:                // menu button below screen - shouldn't be called!
                    break;

                case EButtonBarActions.eBBMultiEncoderButton:        // multifunction encoder button
                    AndromedaMultiEncoderState = !AndromedaMultiEncoderState;
                    break;

                case EButtonBarActions.eBBShift:                    // shift function to select Andromeda band buttons action
                    if (AndromedaBandButtonsEnabled)
                        AndromedaBandButtonsEnabled = false;              // deactivate
                    else
                        AndromedaBandButtonsEnabled = true;               // activate shift if not latched
                    AndromedaIndicatorCheck(EIndicatorActions.eINShiftEnabled, false, AndromedaBandButtonsEnabled);
                    break;

                case EButtonBarActions.eBBMNFAdd:                   // add a manual notch filter entry
                    btnTNFAdd_Click(null, null);
                    break;

                case EButtonBarActions.eBBAntennaStep:              // step RX and TX antenna
                    TXAntennaStep();
                    break;

            }
            UpdateButtonBarButtons();                               // re-check texts
        }
        public void UpdateAndromedaSkins()
        {
            if (modePopupForm != null && modePopupForm.Visible)
                Skin.Restore(CurrentSkin, AppDataPath, modePopupForm);
            if (filterPopupForm != null && filterPopupForm.Visible)
                Skin.Restore(CurrentSkin, AppDataPath, filterPopupForm);
            if (bandPopupForm != null && bandPopupForm.Visible)
                Skin.Restore(CurrentSkin, AppDataPath, bandPopupForm);
            if (sliderForm != null && sliderForm.Visible)
                Skin.Restore(CurrentSkin, AppDataPath, sliderForm);
            if (VFOSettingsForm != null && VFOSettingsForm.Visible)
                Skin.Restore(CurrentSkin, AppDataPath, VFOSettingsForm);
        }
        private void setupModePanels()
        {
            Invoke(new MethodInvoker(panelModeSpecificCW.Show));
            Invoke(new MethodInvoker(panelModeSpecificPhone.Show));
            Invoke(new MethodInvoker(panelModeSpecificDigital.Show));
            Invoke(new MethodInvoker(panelModeSpecificFM.Show));

            panelModeSpecificCW.Location = new Point(0, 0); // NOTE: we check this in SelectModeDependentPanel() to see if has been moved
            panelModeSpecificPhone.Location = new Point(0, 0);
            panelModeSpecificDigital.Location = new Point(0, 0);
            panelModeSpecificFM.Location = new Point(0, 0);

            panelModeSpecificCW.Parent = modeDependentSettingsForm;
            panelModeSpecificPhone.Parent = modeDependentSettingsForm;
            panelModeSpecificDigital.Parent = modeDependentSettingsForm;
            panelModeSpecificFM.Parent = modeDependentSettingsForm;
        }
        //
        // execute a single button longpress action
        // this can be invoked by a menu button press or front panel button press
        // only a few buttons support long press)
        private void ExecuteButtonLongpress(EButtonBarActions assignedAction, int OverrideRX)
        {
            bool UseRX1;                                            // true if we should process actions for RX1
            if (OverrideRX == 0)          // no override
                UseRX1 = show_rx1;
            else if (OverrideRX == 1)     // override to RX1
                UseRX1 = true;
            else
                UseRX1 = false;

            switch (assignedAction)
            {
                case EButtonBarActions.eBBNone:
                    break;

                // filter enum runs from F1 to VAR2
                case EButtonBarActions.eBBFilterPlus:              // select next filter
                    if (filterPopupForm == null || filterPopupForm.IsDisposed) filterPopupForm = new FilterButtonsPopup(this);
                    Invoke(new MethodInvoker(filterPopupForm.Show));
                    break;

                case EButtonBarActions.eBBFilterMinus:             // select next lower filter
                    if (filterPopupForm == null || filterPopupForm.IsDisposed) filterPopupForm = new FilterButtonsPopup(this);
                    Invoke(new MethodInvoker(filterPopupForm.Show));
                    break;

                // DSPMode enum runs from LSB to DRM
                case EButtonBarActions.eBBModePlus:                // step up mode
                    if (modePopupForm == null || modePopupForm.IsDisposed) modePopupForm = new ModeButtonsPopup(this);
                    Invoke(new MethodInvoker(modePopupForm.Show));
                    break;

                case EButtonBarActions.eBBModeMinus:               // step down mode
                    if (modePopupForm == null || modePopupForm.IsDisposed) modePopupForm = new ModeButtonsPopup(this);
                    Invoke(new MethodInvoker(modePopupForm.Show));
                    break;
            }
            UpdateButtonBarButtons();                               // re-check texts
        }



        //
        // bring the right mode dependent panel to the front
        //
        private void SelectModeDependentPanel()
        {
            // MW0LGE [2.10.1.0]
            bool bHaveModeDependentForm = modeDependentSettingsForm != null && !modeDependentSettingsForm.IsDisposed;

            if (_iscollapsed && !_isexpanded)
            {
                // MW0LGE [2.9.0.7] in collapsed view, hide them all
                //https://github.com/ramdor/Thetis-2.9.0/issues/90

                // MW0LGE [2.10.1.0] andromeda mode dependant form fixes
                //https://github.com/ramdor/Thetis/issues/145
                if (bHaveModeDependentForm && modeDependentSettingsForm.Visible)
                {
                    // need to move the frames to the modeDepForm
                    setupModePanels();
                }
                else
                {
                    panelModeSpecificPhone.Hide();
                    panelModeSpecificCW.Hide();
                    panelModeSpecificDigital.Hide();
                    panelModeSpecificFM.Hide();
                    return;
                }
            }
            else
            {
                //[2.10.3.5]MW0LGE we are expanded, so ok to move them always
                moveModeSpecificPanels();
            }

            //MW0LGE_21k9d changed to show/hide as it was causing some unexplained
            //slow down, perhaps z-order fighting, not sure. ~1-3 seconds taken to get through
            //this function, changing from digi to something else.
            //Hidden controls are still returned in this.Controls so will still be saved out ok


            // MI0BOT: Make the panel based on mode of the current transmit VFO
            DSPMode currentMode;

            if (Console.getConsole() != null &&
                Console.getConsole().CurrentHPSDRModel == HPSDRModel.HERMESLITE)
            {
                if (chkVFOBTX.Checked)
                    currentMode = RX2DSPMode;
                else
                    currentMode = RX1DSPMode;
            }
            else
            {
                currentMode = RX1DSPMode;
            }

            switch (currentMode)
            {
                case DSPMode.LSB:
                case DSPMode.USB:
                case DSPMode.DSB:
                case DSPMode.AM:
                case DSPMode.SAM:
                case DSPMode.SPEC:
                    panelModeSpecificPhone.Show();
                    panelModeSpecificCW.Hide();
                    panelModeSpecificDigital.Hide();
                    panelModeSpecificFM.Hide();
                    //panelModeSpecificPhone.BringToFront();
                    break;

                case DSPMode.CWL:
                case DSPMode.CWU:
                    panelModeSpecificCW.Show();
                    panelModeSpecificDigital.Hide();
                    panelModeSpecificFM.Hide();
                    panelModeSpecificPhone.Hide();
                    //panelModeSpecificCW.BringToFront();
                    break;

                case DSPMode.FM:
                    panelModeSpecificFM.Show();
                    panelModeSpecificCW.Hide();
                    panelModeSpecificDigital.Hide();
                    panelModeSpecificPhone.Hide();
                    //panelModeSpecificFM.BringToFront();
                    break;

                case DSPMode.DIGU:
                case DSPMode.DIGL:
                case DSPMode.DRM:
                    panelModeSpecificDigital.Show();
                    panelModeSpecificCW.Hide();
                    panelModeSpecificFM.Hide();
                    panelModeSpecificPhone.Hide();
                    //panelModeSpecificDigital.BringToFront();
                    break;
            }
        }



        //
        // update text for button bar buttons
        // most will be labelled with default text; but they get an opportunity to rename themselves
        //
        private String UpdateButtonBarLabel(EButtonBarActions assignedAction, String DefaultString, bool UseRX1)
        {
            String NewString = "";

            switch (assignedAction)
            {
                case EButtonBarActions.eBBNR:
                    if (UseRX1)
                    {
                        if (chkNR.Checked) NewString = "RX1 " + chkNR.Text; else NewString = "RX1 NR: off";
                    }
                    else
                    {
                        if (chkRX2NR.Checked) NewString = "RX2 " + chkRX2NR.Text; else NewString = "RX2 NR: off";
                    }
                    break;

                case EButtonBarActions.eBBNB:
                    if (UseRX1)
                    {
                        if (chkNB.Checked) NewString = "RX1 " + chkNB.Text; else NewString = "RX1 NB: off";
                    }
                    else
                    {
                        if (chkRX2NB.Checked) NewString = "RX2 " + chkRX2NB.Text; else NewString = "RX2 NB: off";
                    }
                    break;

                case EButtonBarActions.eBBSNB:
                    if (UseRX1) NewString = "RX1 SNB"; else NewString = "RX2 SNB";
                    break;

                case EButtonBarActions.eBBANF:
                    if (UseRX1) NewString = "RX1 ANF"; else NewString = "RX2 ANF";
                    break;

                case EButtonBarActions.eBBFilterPlus:
                    if (UseRX1) NewString = "RX1 filter step up: " + lblFilterLabel.Text; else NewString = "RX2 filter step up: " + lblRX2FilterLabel.Text;
                    break;

                case EButtonBarActions.eBBFilterMinus:
                    if (UseRX1) NewString = "RX1 filter step down: " + lblFilterLabel.Text; else NewString = "RX2 filter step down: " + lblRX2FilterLabel.Text;
                    break;

                case EButtonBarActions.eBBBandPlus:
                    if (UseRX1) NewString = "RX1 Band step UP"; else NewString = "RX2 Band step UP";
                    break;

                case EButtonBarActions.eBBBandMinus:
                    if (UseRX1) NewString = "RX1 Band step DOWN"; else NewString = "RX2 Band step DOWN";
                    break;

                case EButtonBarActions.eBBModePlus:
                    if (UseRX1) NewString = "RX1 Mode step UP"; else NewString = "RX2 Mode step UP";
                    break;

                case EButtonBarActions.eBBModeMinus:
                    if (UseRX1) NewString = "RX1 Mode step DOWN"; else NewString = "RX2 Mode step DOWN";
                    break;

                case EButtonBarActions.eBBAttenStep:
                    if (UseRX1) NewString = "RX1 Atten: " + udRX1StepAttData.Value.ToString() + "dB"; else NewString = "RX2 Atten: " + udRX2StepAttData.Value.ToString() + "dB";
                    break;

                case EButtonBarActions.eBBMuteOnOff:
                    if (UseRX1) NewString = "RX1 Mute"; else NewString = "RX2 Mute";
                    break;

                case EButtonBarActions.eBBBINOnOff:
                    if (UseRX1) NewString = "RX1 Binaural"; else NewString = "RX2 Binaural";
                    break;

                case EButtonBarActions.eBBAGCStep:
                    if (UseRX1) NewString = "RX1 AGC: " + comboAGC.Text; else NewString = "RX2 AGC: " + comboRX2AGC.Text;
                    break;

                case EButtonBarActions.eBBSqlOnOff:
                    if (UseRX1) NewString = "RX1 Squelch"; else NewString = "RX2 Squelch";
                    break;

                case EButtonBarActions.eBBFMDeviation:
                    if (radFMDeviation2kHz.Checked) NewString = "FM Deviation: 2KHz"; else NewString = "FM Deviation: 5KHz";
                    break;

                case EButtonBarActions.eBBRXMeterStep:             // step the setting of the RX meter
                    if (UseRX1) NewString = "RX1 Meter: " + comboMeterRXMode.Text; else NewString = "RX2 Meter: " + comboRX2MeterMode.Text;
                    break;

                case EButtonBarActions.eBBTXMeterStep:             // step the setting of the TX meter
                    NewString = "TX Meter: " + comboMeterTXMode.Text;
                    break;

                case EButtonBarActions.eBBDisplayModeStep:         // step the display mode
                    if (UseRX1) NewString = "RX1 Display: " + comboDisplayMode.Text; else NewString = "RX2 Display: " + comboRX2DisplayMode.Text;
                    break;

                case EButtonBarActions.eBBDisplayDSPAVG:
                    if (UseRX1) NewString = "RX1 Display AVG"; else NewString = "RX2 Display AVG";
                    break;

                case EButtonBarActions.eBBDisplayDSPPeak:
                    if (UseRX1) NewString = "RX1 Display PEAK"; else NewString = "RX2 Display PEAK";
                    break;

                case EButtonBarActions.eBBBandstack:
                    NewString = DefaultString + "  " + regBandStackCurrentEntry.Text + "/" + regBandStackTotalEntries.Text;
                    break;

                case EButtonBarActions.eBBQuickRestore:               // restore from "quick memory"
                    NewString = DefaultString + " " + txtMemoryQuick.Text;
                    break;

                case EButtonBarActions.eBBRXAntenna:               // RX antenna toggle
                    if (Alex.trx_ant_different)
                        NewString = chkRxAnt.Text;
                    else
                        NewString = DefaultString + " (already = TX ant)";
                    break;

                case EButtonBarActions.eBBCWQSK:
                    if (chkQSK.Checked) NewString = chkQSK.Text; else NewString = "QSK: off";
                    break;

                case EButtonBarActions.eBBATUOnOff:
                    if (AriesEnabled) NewString = "ATU: On"; else NewString = "ATU: Off";
                    break;


                default:
                    NewString = DefaultString;                     // for the others - just use the default stribng from the menu entry
                    break;
            }
            return NewString;
        }


        //
        // check if buttons on button bar should be highlighted (generally to indicate on/off state).
        // if response is true, button will be highlighted
        //
        private bool CheckButtonHighlight(EButtonBarActions assignedAction, bool UseRX1)
        {
            bool State = false;

            switch (assignedAction)
            {
                case EButtonBarActions.eBBStartStop:
                    State = chkPower.Checked;
                    break;

                case EButtonBarActions.eBBRX2OnOff:
                    State = chkRX2.Checked;
                    break;

                case EButtonBarActions.eBBDUP:
                    State = chkRX2SR.Checked;
                    break;

                case EButtonBarActions.eBBMON:
                    State = chkMON.Checked;
                    break;

                case EButtonBarActions.eBBTune:
                    State = chkTUN.Checked;
                    break;

                case EButtonBarActions.eBBMOX:
                    State = chkMOX.Checked;
                    break;

                case EButtonBarActions.eBBPuresignalOnOff:
                    State = chkFWCATUBypass.Checked;
                    break;

                case EButtonBarActions.eBBPuresignal2Tone:
                    break;

                case EButtonBarActions.eBBNR:
                    if (UseRX1) State = chkNR.Checked; else State = chkRX2NR.Checked;
                    break;

                case EButtonBarActions.eBBNB:
                    if (UseRX1) State = chkNB.Checked; else State = chkRX2NB.Checked;
                    break;

                case EButtonBarActions.eBBSNB:
                    if (UseRX1) State = chkDSPNB2.Checked; else State = chkRX2NB2.Checked;
                    break;

                case EButtonBarActions.eBBANF:
                    if (UseRX1) State = chkANF.Checked; else State = chkRX2ANF.Checked;
                    break;

                case EButtonBarActions.eBBMNF:
                    State = chkTNF.Checked;                         // there is only an RX1 MNF button
                    break;

                case EButtonBarActions.eBBVFOSplit:
                    State = chkVFOSplit.Checked;
                    break;

                case EButtonBarActions.eBBVFOSyncOnOff:
                    State = chkVFOSync.Checked;
                    break;

                case EButtonBarActions.eBBVFOLockOnOff:
                    if (UseRX1) State = chkVFOLock.Checked; else State = chkVFOBLock.Checked;
                    break;

                case EButtonBarActions.eBBVFOCTUNEOnOff:
                    if (UseRX1) State = chkFWCATU.Checked; else State = chkX2TR.Checked;
                    break;

                case EButtonBarActions.eBBToggleAB:
                    if (CATRX1RX2RadioButton == 1) State = true;
                    break;

                case EButtonBarActions.eBBRITOnOff:                // toggle RIT on/off
                    State = chkRIT.Checked;
                    break;

                case EButtonBarActions.eBBXITOnOff:                // toggle XIT on/off
                    State = chkXIT.Checked;
                    break;

                case EButtonBarActions.eBBMuteOnOff:
                    if (UseRX1) State = chkMUT.Checked; else State = chkRX2Mute.Checked;
                    break;

                case EButtonBarActions.eBBBINOnOff:
                    if (UseRX1) State = chkBIN.Checked; else State = chkRX2BIN.Checked;
                    break;

                case EButtonBarActions.eBBSDOnOff:                // toggle stereo diversity
                    State = chkDX.Checked;
                    break;

                case EButtonBarActions.eBBVAC1OnOff:                // toggle VAC1 on/off
                    State = chkVAC1.Checked;
                    break;

                case EButtonBarActions.eBBVAC2OnOff:                // toggle VAC2 on/off
                    State = chkVAC2.Checked;
                    break;

                case EButtonBarActions.eBBSqlOnOff:                // toggle squelch on/off
                    if (UseRX1) State = chkSquelch.Checked; else State = chkRX2Squelch.Checked;
                    break;

                case EButtonBarActions.eBBRXEQOnOff:                // RX equaliser
                    State = chkRXEQ.Checked;
                    break;

                case EButtonBarActions.eBBTXEQOnOff:                // TX equaliser
                    State = chkTXEQ.Checked;
                    break;

                case EButtonBarActions.eBBTXFLShow:                 // show TX filter
                    State = chkShowTXFilter.Checked;
                    break;

                case EButtonBarActions.eBBMICOnOff:                 // toggle Mic mute
                    State = chkMicMute.Checked;
                    break;

                case EButtonBarActions.eBBCOMPOnOff:                // toggle COMP on/off
                    State = chkCPDR.Checked;
                    break;

                case EButtonBarActions.eBBVOXOnOff:                 // toggle Vox on/off
                    State = chkVOX.Checked;
                    break;

                case EButtonBarActions.eBBDEXPOnOff:                // toggle DEXP on/off
                    State = chkNoiseGate.Checked;
                    break;

                case EButtonBarActions.eBBCWIambic:                 // toggle iambic
                    State = chkCWIambic.Checked;
                    break;

                case EButtonBarActions.eBBCWSidetone:               // toggle sidetone on/off
                    State = chkCWSidetone.Checked;
                    break;

                case EButtonBarActions.eBBCWShowTX:                 // toggle show TX freq
                    State = chkShowTXCWFreq.Checked;
                    break;

                case EButtonBarActions.eBBCWShowZero:               // toggle show zero line
                    State = chkShowCWZero.Checked;
                    break;

                case EButtonBarActions.eUnusedButton1:              // toggle spare button
                    break;

                case EButtonBarActions.eBBCWQSK:                    // toggle break-in
                    State = chkQSK.Checked;
                    break;

                case EButtonBarActions.eBBRX1APF:                   // toggle CW APF
                    State = chkCWAPFEnabled.Checked;
                    break;

                case EButtonBarActions.eBBCTCSSOnOff:               // toggle CTCSS
                    State = chkFMCTCSS.Checked;
                    break;

                case EButtonBarActions.eBBDiversityOnOff:          // toggle diversity on/off
                    State = CATDiversityEnable;
                    break;

                case EButtonBarActions.eBBSubRXOnOff:               // toggle sub-RX on/off
                    State = chkEnableMultiRX.Checked;
                    break;

                case EButtonBarActions.eBBDisplayDSPAVG:            // toggle display AVERAGE on/off
                    if (UseRX1) State = chkDisplayAVG.Checked; else State = chkRX2DisplayAVG.Checked;
                    break;

                case EButtonBarActions.eBBDisplayDSPPeak:           // toggle display PEAK on/off
                    if (UseRX1) State = chkDisplayPeak.Checked; else State = chkRX2DisplayPeak.Checked;
                    break;

                case EButtonBarActions.eBBRXAntenna:                // toggle RX Ant button
                    State = chkRxAnt.Checked;
                    break;

                case EButtonBarActions.eBBRecordAudio:             // record audio
                    State = ckQuickRec.Checked;
                    break;

                case EButtonBarActions.eBBPlayAudio:                 // play audio: parameter identifies which audio
                    State = ckQuickPlay.Checked;
                    break;

                case EButtonBarActions.eBBATUOnOff:                  // Auto ATU on/off
                    State = AriesEnabled;                                   // not yet implemented
                    break;

                case EButtonBarActions.eBBMenuButton:                // menu button below screen
                    State = false;                                   // no indicators available!
                    break;

                case EButtonBarActions.eBBMultiEncoderButton:        // multifunction encoder button
                    State = AndromedaMultiEncoderState;              // this can eventually be true if multi active
                    break;

                default:                        // not highlighted unless specific code added!
                    State = false;
                    break;
            }
            return State;
        }

        //
        // put text onto buttons for current menu
        //
        private void UpdateButtonBarButtons()
        {
            int buttonNumber;
            bool UseRX1;
            EButtonBarActions Action;                           // assigned action for one button
            String Text;
            Color Colour;
            int Override;

            DataTable table = AndromedaSet.Tables["Menu Bar Settings"];
            int RowCount = table.Rows.Count;

            if (this._showAndromedaButtonBar)
            {
                buttonNumber = currentButtonBarMenu * 8;            // point to 1st button
                                                                    // for each button: get its text; give it an opportunity to edit; and set highlight
                Action = (EButtonBarActions)table.Rows[buttonNumber]["Menu Action"];
                Override = (int)table.Rows[buttonNumber]["Menu RX Selector"];
                Text = (string)table.Rows[buttonNumber]["Menu Text"];
                if (Override == 0) UseRX1 = show_rx1; else if (Override == 1) UseRX1 = true; else UseRX1 = false;
                btnAndrBar1.Text = UpdateButtonBarLabel(Action, Text, UseRX1);
                if (CheckButtonHighlight(Action, UseRX1)) Colour = SystemColors.GradientActiveCaption; else Colour = SystemColors.ButtonFace;
                btnAndrBar1.BackColor = Colour;
                buttonNumber++;

                Action = (EButtonBarActions)table.Rows[buttonNumber]["Menu Action"];
                Override = (int)table.Rows[buttonNumber]["Menu RX Selector"];
                Text = (string)table.Rows[buttonNumber]["Menu Text"];
                if (Override == 0) UseRX1 = show_rx1; else if (Override == 1) UseRX1 = true; else UseRX1 = false;
                btnAndrBar2.Text = UpdateButtonBarLabel(Action, Text, UseRX1);
                if (CheckButtonHighlight(Action, UseRX1)) Colour = SystemColors.GradientActiveCaption; else Colour = SystemColors.ButtonFace;
                btnAndrBar2.BackColor = Colour;
                buttonNumber++;

                Action = (EButtonBarActions)table.Rows[buttonNumber]["Menu Action"];
                Override = (int)table.Rows[buttonNumber]["Menu RX Selector"];
                Text = (string)table.Rows[buttonNumber]["Menu Text"];
                if (Override == 0) UseRX1 = show_rx1; else if (Override == 1) UseRX1 = true; else UseRX1 = false;
                btnAndrBar3.Text = UpdateButtonBarLabel(Action, Text, UseRX1);
                if (CheckButtonHighlight(Action, UseRX1)) Colour = SystemColors.GradientActiveCaption; else Colour = SystemColors.ButtonFace;
                btnAndrBar3.BackColor = Colour;
                buttonNumber++;

                Action = (EButtonBarActions)table.Rows[buttonNumber]["Menu Action"];
                Override = (int)table.Rows[buttonNumber]["Menu RX Selector"];
                Text = (string)table.Rows[buttonNumber]["Menu Text"];
                if (Override == 0) UseRX1 = show_rx1; else if (Override == 1) UseRX1 = true; else UseRX1 = false;
                btnAndrBar4.Text = UpdateButtonBarLabel(Action, Text, UseRX1);
                if (CheckButtonHighlight(Action, UseRX1)) Colour = SystemColors.GradientActiveCaption; else Colour = SystemColors.ButtonFace;
                btnAndrBar4.BackColor = Colour;
                buttonNumber++;

                Action = (EButtonBarActions)table.Rows[buttonNumber]["Menu Action"];
                Override = (int)table.Rows[buttonNumber]["Menu RX Selector"];
                Text = (string)table.Rows[buttonNumber]["Menu Text"];
                if (Override == 0) UseRX1 = show_rx1; else if (Override == 1) UseRX1 = true; else UseRX1 = false;
                btnAndrBar5.Text = UpdateButtonBarLabel(Action, Text, UseRX1);
                if (CheckButtonHighlight(Action, UseRX1)) Colour = SystemColors.GradientActiveCaption; else Colour = SystemColors.ButtonFace;
                btnAndrBar5.BackColor = Colour;
                buttonNumber++;

                Action = (EButtonBarActions)table.Rows[buttonNumber]["Menu Action"];
                Override = (int)table.Rows[buttonNumber]["Menu RX Selector"];
                Text = (string)table.Rows[buttonNumber]["Menu Text"];
                if (Override == 0) UseRX1 = show_rx1; else if (Override == 1) UseRX1 = true; else UseRX1 = false;
                btnAndrBar6.Text = UpdateButtonBarLabel(Action, Text, UseRX1);
                if (CheckButtonHighlight(Action, UseRX1)) Colour = SystemColors.GradientActiveCaption; else Colour = SystemColors.ButtonFace;
                btnAndrBar6.BackColor = Colour;
                buttonNumber++;

                Action = (EButtonBarActions)table.Rows[buttonNumber]["Menu Action"];
                Override = (int)table.Rows[buttonNumber]["Menu RX Selector"];
                Text = (string)table.Rows[buttonNumber]["Menu Text"];
                if (Override == 0) UseRX1 = show_rx1; else if (Override == 1) UseRX1 = true; else UseRX1 = false;
                btnAndrBar7.Text = UpdateButtonBarLabel(Action, Text, UseRX1);
                if (CheckButtonHighlight(Action, UseRX1)) Colour = SystemColors.GradientActiveCaption; else Colour = SystemColors.ButtonFace;
                btnAndrBar7.BackColor = Colour;
                buttonNumber++;

                Action = (EButtonBarActions)table.Rows[buttonNumber]["Menu Action"];
                Override = (int)table.Rows[buttonNumber]["Menu RX Selector"];
                Text = (string)table.Rows[buttonNumber]["Menu Text"];
                if (Override == 0) UseRX1 = show_rx1; else if (Override == 1) UseRX1 = true; else UseRX1 = false;
                btnAndrBar8.Text = UpdateButtonBarLabel(Action, Text, UseRX1);
                if (CheckButtonHighlight(Action, UseRX1)) Colour = SystemColors.GradientActiveCaption; else Colour = SystemColors.ButtonFace;
                btnAndrBar8.BackColor = Colour;
                buttonNumber++;
            }
        }


        private void panelButtonBar_Layout(object sender, LayoutEventArgs e)
        {
            UpdateButtonBarButtons();
        }

        #endregion

    }
}
