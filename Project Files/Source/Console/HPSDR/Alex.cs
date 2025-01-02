/*
*
* Copyright (C) 2008 Bill Tracey, KD5TFD, bill@ewjt.com 
* Copyright (C) 2010-2020  Doug Wigley
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

// this module contains code to support the Alex Filter and Antenna Selection board 
// 
// 

namespace Thetis
{
	/// <summary>
	/// Summary description for Penny.
	/// </summary>
	using System.Diagnostics;
	public class Alex
	{
		private static Alex theSingleton = null; 
		
		public  static Alex getAlex() 
		{ 
			lock ( typeof(Alex) ) 
			{
				if ( theSingleton == null ) 
				{ 
					theSingleton = new Alex(); 
				} 
			}
			return theSingleton; 
		} 

		private Alex()
		{		
			for ( int i = 0; i < 12; i++ ) 
			{
				TxAnt[i] = 1; 
				RxAnt[i] = 1; 
				RxOnlyAnt[i] = 0; 
			}
		}


		private byte[] TxAnt = new byte[12]; 
		private byte[] RxAnt = new byte[12]; 
		private byte[] RxOnlyAnt = new byte[12];		// 1 = rx1, 2 = rx2, 3 = xv, 0 = none selected 
		private bool LimitTXRXAntenna = false;			// when set, antennas should stay on 1 (for external Aries ATU)
        public static bool RxOutOnTx = false;
        public static bool Ext1OutOnTx = false;
        public static bool Ext2OutOnTx = false;
        public static bool init_update = false;
        public static bool rx_out_override = false;
        public static bool TRxAnt = false;				// Flag, set true to identify that the transmit antenna is being used for reception 

        public static bool trx_ant_different { set; get; }
		
		//
		// SetAntennasTo1 causes RX, TX antennas to be set to 1
		// the various RX "bypass" unaffected
		public void SetAntennasTo1(bool IsSetTo1)
        {
			LimitTXRXAntenna = IsSetTo1;

		}
		public void setRxAnt(Band band, byte ant) 
		{ 
			if ( ant > 3 ) 
			{ 
				ant = 1; 
			} 
			int idx = (int)band - (int)Band.B160M; 
			RxAnt[idx] = ant; 
		} 

		public void setRxOnlyAnt(Band band, byte ant) 
		{ 
			if ( ant > 3 ) 
			{ 
				//ant = 0; 
			} 
			int idx = (int)band - (int)Band.B160M; 
			RxOnlyAnt[idx] = ant; 
		} 

		public void setTxAnt(Band band, byte ant) 
		{ 
			if ( ant > 3 ) 
			{ 
				ant = 1; 
			} 
			int idx = (int)band - (int)Band.B160M; 
			TxAnt[idx] = ant;
		} 


		private bool AlexEnableIsStateSaved = false; 
		private bool AlexEnableSavedState;
        public static Band AntBandFromFreq(double freq)
        {
            Band result;
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
        public static Band AntBandFromFreq(bool tx) 
		{
			Band result;
 
			Console c = Console.getConsole(); 
			if ( c == null ) 
			{ 
				System.Console.WriteLine("no console"); 
				return Band.LAST; 				
			}

			//[2.10.3.6]MW0LGE
			double freq;//  = Console.getConsole().VFOAFreq;   //was = 0.0 Vk4xv Txvr fix.
			if (tx)
			{
				if (c.VFOATX)
					freq = c.VFOAFreq;
				else
					freq = c.VFOBFreq;
			}
			else
                freq = c.VFOAFreq;

            if (c.RX1XVTRIndex >= 0)
                freq = c.XVTRForm.TranslateFreq(freq);
            //[2.10.3.6]MW0LGE else freq = Console.getConsole().VFOAFreq;

            System.Console.WriteLine("Freq is: " + freq); 

			result = AntBandFromFreq(freq);
            //if ( freq >= 12.075 ) 
            //{ 
            //	if ( freq >= 23.17 ) 
            //	{
            //		if ( freq >= 26.465 ) 
            //		{ 
            //			result = freq >= 39.85 ? Band.B6M : Band.B10M; 
            //		}
            //		else /* >23.17  <26.465 */
            //		{
            //			result = Band.B12M;
            //		}
            //	}
            //	else  /* >12.075  <23.17 */ 
            //	{ 
            //		if ( freq >= 16.209 ) 
            //		{ 
            //			result = freq >= 19.584 ? Band.B15M : Band.B17M;
            //		}
            //		else 
            //		{ 
            //			result = Band.B20M; 
            //		} 
            //	}
            //} 
            //else  /* < 12.075 */ 
            //{
            //	if ( freq  >= 6.20175 ) 
            //	{
            //		result = freq >= 8.7 ? Band.B30M : Band.B40M; 
            //	}
            //	else 
            //	{ 
            //		if ( freq >= 4.66525 ) 
            //		{
            //			result = Band.B60M;
            //		}
            //		else 
            //		{
            //			result = freq >= 2.75 ? Band.B80M : Band.B160M;
            //		}
            //	} 
            //}

            System.Console.WriteLine("Band is: " + result);
            return result; 
		}

        public static Band AntBandFromFreqB()
        {
            Band result;

            Console c = Console.getConsole();
            if (c == null)
            {
                System.Console.WriteLine("no console");
                return Band.LAST;
            }

            double freq = Console.getConsole().VFOBFreq;   //was = 0.0 Vk4xv Txvr fix.

            if (c.RX2XVTRIndex >= 0)
                freq = c.XVTRForm.TranslateFreq(freq);
            else freq = Console.getConsole().VFOBFreq;

            System.Console.WriteLine("Freq is: " + freq);

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

        public void UpdateAlexAntSelection(Band band, bool tx, bool xvtr)  
		{ 
			UpdateAlexAntSelection(band, tx, true, xvtr); 
		}

		private int m_nOld_rx_only_ant = -99;
		private int m_nOld_trx_ant = -99;
		private int m_nOld_tx_ant = -99;
		private int m_nOld_rx_out = -99;
		private bool m_bOld_tx = false;
		private bool m_bOld_alex_enabled = false;
        public void UpdateAlexAntSelection(Band band, bool tx, bool alex_enabled, bool xvtr) 
		{
			if ( !alex_enabled ) 
			{
                NetworkIO.SetAntBits(0, 0, 0, 0, false);
                m_bOld_alex_enabled = alex_enabled;
                return;
			}

            Console c = Console.getConsole();

            if (c == null)
            {
                System.Console.WriteLine("no console");
            }

            int rx_only_ant;	// Holds the current receive only port based on the current band selected  
			int trx_ant; 
			int tx_ant; 
			int rx_out;			// Flag to identify if one of the rx only ports should be used while transmitting		

			int idx = (int)band - (int)Band.B160M; 

            if (idx < 0 || idx > 11)
            {
				band = AntBandFromFreq(tx); 

                idx = (int)band - (int)Band.B160M;
                if (idx < 0 || idx > 11)
                {
                    System.Console.WriteLine("No good ant!");
                    return;
                }
            }
            
			//System.Console.WriteLine("Ant idx: " + idx);  //moved into different check down below			            
			tx_ant = TxAnt[idx];

			if ( tx ) 
			{				
                if (Ext2OutOnTx) rx_only_ant = 1;
                else if (Ext1OutOnTx) rx_only_ant = 2;
                else rx_only_ant = 0;

                rx_out = RxOutOnTx || Ext1OutOnTx || Ext2OutOnTx ? 1 : 0; 
				trx_ant = TxAnt[idx]; 
			} 
			else 
			{
                rx_only_ant = RxOnlyAnt[idx];
                if (xvtr)
                {
					if (c.CurrentHPSDRModel == HPSDRModel.HERMESLITE)
					{
                        int xvtrAnt = c.XVTRForm.GetRXAntenna(c.RX1XVTRIndex);

						if (xvtrAnt == 4 ||		// MI0BOT: Alt RX has been requested or TX and Rx are not the same
                           TRxAnt == false)
							rx_only_ant = 1;
						else
							rx_only_ant = 0;
                    }
					else
					{
						if (rx_only_ant >= 3) rx_only_ant = 3;
						else rx_only_ant = 0;
					}
                }
                else
                {
                    if (rx_only_ant >= 3) rx_only_ant -= 3; // do not use XVTR ant port if not using transverter
                }

                rx_out = rx_only_ant != 0 ? 1 : 0;

                if (TRxAnt) trx_ant = TxAnt[idx];
                else trx_ant = RxAnt[idx];

                if ((RxAnt[idx] != TxAnt[idx]) ||
					(0 != rx_only_ant && c.CurrentHPSDRModel == HPSDRModel.HERMESLITE))  // MI0BOT: Antenna not the same is valid
                {                                                                        //         for receive only aerial as well
                    trx_ant_different = true;
				}
				else
				{
                    trx_ant_different = false;                    
				}
            }

            if (rx_out_override && rx_out == 1)
            {
                if (!tx) trx_ant = 4;
               // rx_out = 0; // disable Rx_Bypass_Out relay
                if (tx) // override override
                    rx_out = RxOutOnTx || Ext1OutOnTx || Ext2OutOnTx ? 1 : 0;
                else rx_out = 0; // disable Rx_Bypass_Out relay
            }
			//
			// G8NJJ support for external Aries ATU on antenna port 1
			// force TX and RX antenna to 1 if selected
			// this is only enabled if "external Aries" selected in setup
			//
			if ((trx_ant != 4) && (LimitTXRXAntenna == true))
				trx_ant = 1;
            //
            //if (init_update)
            //{
            //    if (rx_out == 0) xrx_out = 1; // workaround for Hermes
            //    else xrx_out = 0;
            //    NetworkIO.SetAlexAntBits(rx_only_ant, trx_ant, xrx_out);
            //    init_update = false;
            //    Thread.Sleep(10);
            //}

            if (TRxAnt && c.CurrentHPSDRModel == HPSDRModel.HERMESLITE && !xvtr)
            {
                // MI0BOT: Transmit antenna is being used for reception in split aerial operation
                //         so switch of the rx only aerial but not with transverter operation

                rx_only_ant = 0;    
            }

			//MW0LGE_21k9d only set bits if different
			if (m_nOld_rx_only_ant != rx_only_ant ||
				m_nOld_trx_ant != trx_ant ||
				m_nOld_tx_ant != tx_ant ||
				m_nOld_rx_out != rx_out ||
				m_bOld_tx != tx ||
                m_bOld_alex_enabled != alex_enabled)
			{                             
				NetworkIO.SetAntBits(rx_only_ant, trx_ant, tx_ant, rx_out, tx);

				System.Console.WriteLine("Ant idx: " + idx + "(" + ((Band)idx + (int)Band.B160M).ToString() + ")");
                System.Console.WriteLine("Ant Rx Only {0} , TRx Ant {1}, Tx Ant {2}, Rx Out {3}, TX {4}", rx_only_ant.ToString(), trx_ant.ToString(), tx_ant.ToString(), rx_out.ToString(), tx.ToString());

                if (c.CurrentHPSDRModel == HPSDRModel.HERMESLITE)
					c.SetIOBoardAerialPorts(rx_only_ant, trx_ant - 1, tx_ant - 1, tx);   // MI0BOT: Sets the aerial controls on the I/O board 

				//store old
				m_nOld_rx_only_ant = rx_only_ant;
				m_nOld_trx_ant = trx_ant;
				m_nOld_tx_ant = tx_ant;
				m_nOld_rx_out = rx_out;
				m_bOld_tx = tx;
				m_bOld_alex_enabled = alex_enabled;
            }

			// don't allow changing antenna selections when mox is activated 
			/*	if ( tx )  
				{ 
					AlexEnableSavedState = Console.getConsole().SetupForm.SetAlexAntEnabled(false); 
					AlexEnableIsStateSaved = true; 
				} 
				else if ( AlexEnableIsStateSaved ) 
				{ 
					Console.getConsole().SetupForm.SetAlexAntEnabled(AlexEnableSavedState); 
					AlexEnableIsStateSaved = false; 
				} */

			return; 
		}




#if false
		public void setBandBitMask(Band band, byte mask, bool tx) 
		{ 
			int idx = (int)band - (int)Band.B160M; 
			if ( tx ) 
			{ 
				TXBitMasks[idx] = mask;
			} 
			else 
			{ 
				RXBitMasks[idx] = mask;
			} 
			return; 

		} 

		public void ExtCtrlEnable(bool enable, Band band, bool tx ) 
		{
			if ( !enable ) 
			{
				JanusAudio.SetPennyOCBits(0); 
			}
			else 
			{
				UpdateExtCtrl(band, tx);
			}
		}

		public void UpdateExtCtrl(Band band, bool tx) 
		{
			int idx = (int)band - (int)Band.B160M; 
			int bits; 
			if ( idx < 0 || idx > 11 ) 
			{ 
				bits = 0; 
			} 
			else 
			{ 
				if ( tx ) 
				{ 
					bits = TXBitMasks[idx]; 
				}
				else 
				{
					bits = RXBitMasks[idx];
				}
			}
			System.Console.WriteLine("Bits: " + bits + " Band: " + (int)band); 
			JanusAudio.SetPennyOCBits(bits);
	
		}
#endif
	}
}
