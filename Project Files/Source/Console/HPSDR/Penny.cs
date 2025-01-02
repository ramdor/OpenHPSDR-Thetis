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

//
// this module contains code to support the Penelope Transmitter board 
// 
// 



namespace Thetis
{
	using System;
	/// <summary>
	/// Summary description for Penny.
	/// </summary>
	public class Penny
	{
		private static Penny theSingleton = null;

        private static object m_objLock = new Object();

		public  static Penny getPenny() 
		{
            //lock ( typeof(Penny) )    // https://bytes.com/topic/c-sharp/answers/249277-dont-lock-type-objects
            lock (m_objLock)
			{
				if ( theSingleton == null ) 
				{ 
					theSingleton = new Penny(); 
				} 
			}
			return theSingleton; 
		} 

		private Penny()
		{		
			//init
			for(int pin=0; pin<7; pin++)
            {
                for (int group = 0; group < 3; group++)
                {
                    TXPinAction[group, pin] = TXPinActions.MOX_TUNE_TWOTONE;
                    TXPinPA[group, pin] = false;
                    RXPinPA[group, pin] = false;
                }
            }
		}

		private byte[] TXABitMasks = new byte[41]; //25
		private byte[] RXABitMasks = new byte[41];
        private byte[] TXBBitMasks = new byte[41];
        private byte[] RXBBitMasks = new byte[41];

		private TXPinActions[,] TXPinAction = new TXPinActions[3,7]; // group=0-2, 7 output pins = 0-6
        private bool[,] TXPinPA = new bool[3, 7]; // group=0-2, 7 output pins = 0-6
        private bool[,] RXPinPA = new bool[3, 7]; // group=0-2, 7 output pins = 0-6

        public void setRXPinPA(int group, int pin, bool pa)
        {
            //group 0-2, 0=B160-B2M, 1=VHF0-VHF11, 2=B120-B11
            //pins 1-7
            //the pa state we want if this pin is to change to a high state
            if (group < 0 || group > 2 || pin < 1 || pin > 7) return;

            RXPinPA[group, pin - 1] = pa;
        }
        public void setTXPinPA(int group, int pin, bool pa)
        {
            //group 0-2, 0=B160-B2M, 1=VHF0-VHF11, 2=B120-B11
            //pins 1-7
            //the pa state we want if this pin is to change to a high state
            if (group < 0 || group > 2 || pin < 1 || pin > 7) return;

            TXPinPA[group, pin - 1] = pa;
        }

        public void setTXPinAction(int group, int pin, TXPinActions action)
        {
            //group 0-2, 0=B160-B2M, 1=VHF0-VHF11, 2=B120-B11
            //pins 1-7
            //action TXPinActions, the action we want if this pin is to change to a high state
            if (group<0 || group>2 || pin<1 || pin>7 || !(action > TXPinActions.FIRST && action < TXPinActions.LAST)) return;

			TXPinAction[group, pin - 1] = action;
		}

		public void setBandABitMask(Band band, byte mask, bool tx) 
		{ 
			int idx = (int)band - (int)Band.B160M; 
			if ( tx ) 
			{ 
				TXABitMasks[idx] = mask;
			} 
			else 
			{ 
				RXABitMasks[idx] = mask;
			} 
			return; 

		}

        public void setBandBBitMask(Band band, byte mask, bool tx)
        {
            int idx = (int)band - (int)Band.B160M;
            if (tx)
            {
                TXBBitMasks[idx] = mask;
            }
            else
            {
                RXBBitMasks[idx] = mask;
            }
            return;

        }

        public int ExtCtrlEnable(Band band, Band bandb, bool tx, bool enable, bool tune, bool twoTone, bool pa) 
		{
            int bits;
            if (!enable)
            {
                NetworkIO.SetOCBits(0);
                bits = 0;
            }
            else
            {
                bits = UpdateExtCtrl(band, bandb, tx, tune, twoTone, pa);
            }
            return bits;
        }

        public int RxABitMask = 0xf; // 4x3 split
        public bool SplitPins = false;
        public bool VFOBTX = false;
        // MW0LGE_21j added TX pin functionality

        private int m_nOldBits = -1;

        public int UpdateExtCtrl(Band band, Band bandb, bool tx, bool tune, bool twoTone, bool pa)
		{
            int idx = (int)band - (int)Band.B160M;
            int idxb = (int)bandb - (int)Band.B160M;
			int bits;

			if ( (idx < 0 || idx > 40) || (SplitPins && idxb < 0 || SplitPins && idxb > 40) ) //26
			{ 
				bits = 0; 
			} 
			else 
			{
                if (SplitPins)
                {
                    bits = tx ? (TXABitMasks[idx] & RxABitMask) | TXBBitMasks[idxb] : (RXABitMasks[idx] & RxABitMask) | RXBBitMasks[idxb];
                }
                else
                {
                    if (Console.getConsole().CurrentHPSDRModel == HPSDRModel.HERMESLITE)    // MI0BOT: Select correct LPF for 2 receivers
                    {
                        if (tx)
                        {
                            if (VFOBTX)
                                bits = TXABitMasks[idxb];
                            else
                                bits = TXABitMasks[idx];
                        }
                        else
                        {
                            if (Console.getConsole().RX2Enabled && (idxb > idx))     // MI0BOT: Select the filter for the high band 
                                bits = RXABitMasks[idxb];
                            else
                                bits = RXABitMasks[idx];
                        }
                    }
                    else
                    {
                        if (tx && VFOBTX)
                            bits = TXABitMasks[idxb];
                        else if (tx)
                            bits = TXABitMasks[idx];
                        else bits = RXABitMasks[idx];
                    }
                }
			}

            // adjust for pin action and/or PA
            if (tx)
                bits = adjustForTXAction(band, bandb, bits, tx, tune, twoTone, pa);
            else
                bits = adjustForRX(band, bandb, bits, tx, tune, twoTone, pa);
            //

            if (bits != m_nOldBits)
            {
                string bitsAsString = Convert.ToString(bits, 2).PadLeft(8, '0');
                System.Console.WriteLine("Bits: " + bits + " (" + bitsAsString + ") Band: " + (int)band + " BandB: " + (int)bandb + " tx: " + tx + " tune: " + tune + " 2ton: " + twoTone);

                NetworkIO.SetOCBits(bits);

                m_nOldBits = bits;
            }

            return bits;
		}

		private int getGroup(Band b)
        {
			int n = -1;

            switch (b)
            {
                case Band.GEN:
                case Band.B160M:
                case Band.B80M:
                case Band.B60M:
                case Band.B40M:
                case Band.B30M:
                case Band.B20M:
                case Band.B17M:
                case Band.B15M:
                case Band.B12M:
                case Band.B10M:
                case Band.B6M:
                case Band.B2M:
                case Band.WWV:
                    n = 0;
                    break;

                case Band.VHF0:
                case Band.VHF1:
                case Band.VHF2:
                case Band.VHF3:
                case Band.VHF4:
                case Band.VHF5:
                case Band.VHF6:
                case Band.VHF7:
                case Band.VHF8:
                case Band.VHF9:
                case Band.VHF10:
                case Band.VHF11:
                case Band.VHF12:
                case Band.VHF13:
                    n = 1;
                    break;

                case Band.BLMF:
                case Band.B120M:
                case Band.B90M:
                case Band.B61M:
                case Band.B49M:
                case Band.B41M:
                case Band.B31M:
                case Band.B25M:
                case Band.B22M:
                case Band.B19M:
                case Band.B16M:
                case Band.B14M:
                case Band.B13M:
                case Band.B11M:
                    n = 2;
                    break;
            }

			return n;
        }
        private int adjustForRX(Band band, Band bandb, int bits, bool tx, bool tune, bool twoTone, bool pa)
        {
            int mask = 0;

            for (int nPin = 0; nPin < 7; nPin++)
            {
                int group;
                if (SplitPins)
                {
                    // need to find the group that is VFOA/VFOB
                    if (((1 << nPin) & RxABitMask) != 0)
                        group = getGroup(band);
                    else
                        group = getGroup(bandb);
                }
                else
                {
                    if (VFOBTX)
                        group = getGroup(bandb);
                    else
                        group = getGroup(band);
                }

                if (group < 0) continue; // some issue finding band, skip

                bool bConisderPA = RXPinPA[group, nPin]; // are we considering the PA state for this pin?
                                                         // PA state is an override button on the front end console

                int nBit = !bConisderPA || (bConisderPA && pa) ? 1 : 0;

                mask |= nBit << nPin;
            }

            return bits & mask;
        }
        private int adjustForTXAction(Band band, Band bandb, int bits, bool tx, bool tune, bool twoTone, bool pa)
        {
            int mask = 0;

			for(int nPin = 0;nPin < 7; nPin++)
            {
                int group;
                if (SplitPins)
                {
                    // need to find the group that is VFOA/VFOB
                    if( ((1 << nPin) & RxABitMask) != 0)
                        group = getGroup(band);
                    else
                        group = getGroup(bandb);
                }
                else
                {
                    if (VFOBTX)
                        group = getGroup(bandb);
                    else
                        group = getGroup(band);
                }

                if (group < 0) continue; // some issue finding band, skip

                TXPinActions action = TXPinAction[group, nPin];
                bool bConisderPA = TXPinPA[group, nPin]; // are we considering the PA state for this pin?
                                                         // PA state is an override button on the front end console

                int nBit = 0;

                if (!bConisderPA || (bConisderPA && pa))
                {
                    switch (action)
                    {
                        case TXPinActions.MOX: // tx only
                            nBit = tx && !tune && !twoTone ? 1 : 0;
                            break;
                        case TXPinActions.TUNE: // tune
                            nBit = tune ? 1 : 0;
                            break;
                        case TXPinActions.TWOTONE: // twoTone
                            nBit = twoTone ? 1 : 0;
                            break;
                        case TXPinActions.MOX_TUNE: // tx or tune
                            nBit = (tx || tune) && !twoTone ? 1 : 0;
                            break;
                        case TXPinActions.MOX_TWOTONE: // tx or twoTone
                            nBit = (tx || twoTone) & !tune ? 1 : 0;
                            break;
                        case TXPinActions.TUNE_TWOTONE: // tune or twoTone
                            nBit = tune || twoTone ? 1 : 0;
                            break;
                        case TXPinActions.MOX_TUNE_TWOTONE: // tx or tune or twoTone
                            nBit = tx || tune || twoTone ? 1 : 0;
                            break;
                    }
                }

                mask |= nBit << nPin;
            }

			return bits & mask;
        }
	}
}
