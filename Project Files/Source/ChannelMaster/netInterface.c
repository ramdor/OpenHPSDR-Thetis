/*
 * netinterface.c
 * Copyright (C) 2006,2007  Bill Tracey (bill@ejwt.com) (KD5TFD)
 * Copyright (C) 2010-2020 Doug Wigley (W5WC)
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 *
 */

#include <stdio.h>
#include <stdbool.h>
#include "network.h"
#include "obbuffs.h"

#define MDECAY 0.99f;
const int numInputBuffs = 12;

int audio_running = 0;
PORT
int StartAudioNative()
{
	int myrc = 0;
	int rc;
	if (audio_running) return 0;
	audio_running = 1;
	HaveSync = 1;
	// make sure we're not already opened
	if (IOThreadRunning || prn == NULL) 
	{
		return 3;
	}

	UpdateRadioProtocolSampleSize(); // we know the radio protocol - need to update sample sizes
	cm_asioStart(RadioProtocol);
	if (RadioProtocol == USB)
	{		
		do { // once								
			rc = SendStartToMetis();
			if (rc != 0) {
				printf("SendStart failed ...\n"); fflush(stdout);
				StopReadThread();
				myrc = -3;
				break;
			}

			if (prn != NULL)
			{				
				prn->hReadThreadInitSem = CreateSemaphore(NULL, 0, 1, NULL);				
				prn->hReadThreadMain = (HANDLE)_beginthreadex(NULL, 0, MetisReadThreadMain, 0, 0, NULL);
			
				WaitForSingleObject(prn->hReadThreadInitSem, INFINITE); // wait for the thread to get going
				
				prn->hWriteThreadInitSem = CreateSemaphore(NULL, 0, 1, NULL);
				prn->hWriteThreadMain = (HANDLE)_beginthreadex(NULL, 0, sendProtocol1Samples, 0, 0, NULL);
				// Create Events
				prn->hsendEventHandles[0] = ( prn->hsendLRSem = CreateSemaphore(NULL, 0, 1, NULL));
				prn->hsendEventHandles[1] = ( prn->hsendIQSem = CreateSemaphore(NULL, 0, 1, NULL));
				prn->hobbuffsRun[0] = CreateSemaphore (NULL, 0, 1, NULL);
				prn->hobbuffsRun[1] = CreateSemaphore (NULL, 0, 1, NULL);
			}

		} while (0);
	}
	else
	{
		do { 		
				StartReadThread();
				prn->hReadThreadInitSem = CreateSemaphore(NULL, 0, 1, NULL);
				prn->hReadThreadMain = (HANDLE)_beginthreadex(NULL, 0, ReadThreadMain, 0, 0, NULL);
				WaitForSingleObject(prn->hReadThreadInitSem, INFINITE); // wait for the thread to get going
				prn->hKeepAliveThread = (HANDLE)_beginthreadex(NULL, 0, KeepAliveMain, 0, 0, NULL);
		} while (0);
	}

	   if (myrc != 0) 
	   {  // we failed -- clean up
		   StopReadThread(); /* is a no op if not running */
	   }

	return myrc;

}

PORT
void StopAudio() 
{
	int rc;
	if (!audio_running) return;
	audio_running = 0;
	printf("stop audio called\n");  fflush(stdout);
	rc = IOThreadStop();
	if (rc != 0) 
	{
		fprintf(stderr, "Warning: IOThreadStop failed with rc=%d\n", rc);
	}
	printf("iothread stopped\n");   fflush(stdout);

	StopReadThread();
	cm_asioStop();
	destroy_obbuffs(0);
	destroy_obbuffs(1);
}

int getDDPTTcount = 0;
int last_DDP = 0;

PORT
int nativeGetDotDashPTT() 
{
	return (prn->dot_in |
		prn->dash_in |
		prn->ptt_in) & 0x7;
}

PORT
int getAndResetADC_Overload() 
{
	int n = prn->adc[0].adc_overload | (prn->adc[1].adc_overload << 1) | (prn->adc[2].adc_overload << 2);

	return n;
}

PORT
int getOOO() { // OOO == Out Of Order packet
	int result = 0;
	if (prn->cc_seq_err > 0) // High Priority Command & Control
		result = 1;
	if (prn->rx[0].rx_in_seq_err > 0) // DDC0 I/Q data
		result += 2;
	if (prn->rx[1].rx_in_seq_err > 0) // DDC1 I/Q data
		result += 4;
	if (prn->rx[2].rx_in_seq_err > 0) // DDC2 I/Q data
		result += 8;
	if (prn->rx[3].rx_in_seq_err > 0) // DDC3 I/Q data
		result += 16;
	if (prn->rx[4].rx_in_seq_err > 0) // DDC4 I/Q data
		result += 32;
	if (prn->rx[5].rx_in_seq_err > 0) // DDC5 I/Q data
		result += 64;
	if (prn->rx[6].rx_in_seq_err > 0) // DDC6 I/Q data
		result += 128;
	if (prn->tx[0].mic_in_seq_err > 0) // mic_in data
		result += 256;


	if (result > 0)
	{
		prn->cc_seq_err = 0;
		prn->rx[0].rx_in_seq_err = 0;
		prn->rx[1].rx_in_seq_err = 0;
		prn->rx[2].rx_in_seq_err = 0;
		prn->rx[3].rx_in_seq_err = 0;
		prn->rx[4].rx_in_seq_err = 0;
		prn->rx[5].rx_in_seq_err = 0;
		prn->rx[6].rx_in_seq_err = 0;
		prn->tx[0].mic_in_seq_err = 0;
	}

	return result;
}

PORT
int getSeqInDelta(int nInit, int rx, int deltas[], char* dateTimeStamp, int *received_seqnum, int *last_seqnum) 
{
	int nRet = 0;

	EnterCriticalSection(&prn->seqErrors);
	
	if (nInit == 1) prn->rx[rx].snapshot = prn->rx[rx].snapshots_head;

	if (prn->rx[rx].snapshot != NULL) 
	{
		memcpy(deltas, prn->rx[rx].snapshot->rx_in_seq_snapshot, sizeof(int) * MAX_IN_SEQ_LOG);
		memcpy(dateTimeStamp, prn->rx[rx].snapshot->dateTimeStamp, sizeof(char) * 24);

		*received_seqnum = prn->rx[rx].snapshot->received_seqnum;
		*last_seqnum = prn->rx[rx].snapshot->last_seqnum;

		prn->rx[rx].snapshot = prn->rx[rx].snapshot->next;

		nRet = 1;
	}

	LeaveCriticalSection(&prn->seqErrors);

	return nRet;
}

PORT
int GetPLLLock()
{
	return (prn->pll_locked & 0x10) != 0;
}
//NOTE: these 4 user get fuctions are named for P1 //MW0LGE_22b
// Bit [0] - User I/O (IO1) 1 = active, 0 = inactive
// Bit [1] - User I/O (IO2) 1 = active, 0 = inactive
// Bit [2] - User I/O (IO3) 1 = active, 0 = inactive
// Bit [3] - User I/O (IO4) 1 = active, 0 = inactive
PORT
int getUserI01() 
{
	return (prn->user_dig_in & 0x1) != 0;
}

PORT
int getUserI02() 
{
	return (prn->user_dig_in & 0x2) != 0;
}

PORT
int getUserI03() 
{
	return (prn->user_dig_in & 0x4) != 0;
}

PORT
int getUserI04() 
{
	return (prn->user_dig_in & 0x8) != 0;
}
//

//NOTE: these 5 user get functions are named for P2 //MW0LGE_22b
// Bit [0] - User I/O (IO4) 1 = active, 0 = inactive
// Bit [1] - User I/O (IO5) 1 = active, 0 = inactive
// Bit [2] - User I/O (IO6) 1 = active, 0 = inactive
// Bit [3] - User I/O (IO8) 1 = active, 0 = inactive
// Bit [4] - User I/O (IO2) 1 = active, 0 = inactive
PORT
int getUserI04_p2()
{
	return (prn->user_dig_in & 0x1) != 0;
}

PORT
int getUserI05_p2()
{
	return (prn->user_dig_in & 0x2) != 0;
}

PORT
int getUserI06_p2()
{
	return (prn->user_dig_in & 0x4) != 0;
}

PORT
int getUserI08_p2()
{
	return (prn->user_dig_in & 0x8) != 0;
}
PORT
int getUserI02_p2()
{
	return (prn->user_dig_in & 0x10) != 0; //[2.10.3.5]MW0LGE changed to 0x10 from 0x16, spotted by G8NJJ
}
//

PORT
int getExciterPower() 
{

	return prn->tx[0].exciter_power;
}

PORT
float getFwdPower() 
{

	return FwdPower;
}

PORT
float getRevPower() 
{

	return RevPower;
}

PORT
int getUserADC0() 
{

	return prn->user_adc0;
}

PORT
int getUserADC1() 
{

	return prn->user_adc1;
}

PORT
int getUserADC2() 
{

	return prn->user_adc2;
}

PORT
int getUserADC3() 
{

	return prn->user_adc3;
}

PORT
int getHermesDCVoltage() 
{

	return prn->supply_volts;
}

PORT
void SetPttOut(int xmit) 
{
	if (prn->tx[0].ptt_out != xmit)
	{
		XmitBit = xmit;
		prn->tx[0].ptt_out = xmit & 0x1;
		if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
			CmdHighPriority();
	}
}

PORT
void SetTRXrelay(int bit) 
{
	if (prbpfilter->_TR_Relay != bit)
	{
		if (!prn->tx[0].pa) // disable PA
			prbpfilter->_TR_Relay = bit & 0x1;
		prbpfilter->_trx_status = prbpfilter->_TR_Relay; // TXRX_STATUS
		prbpfilter2->_trx_status = prbpfilter->_TR_Relay; // TXRX_STATUS for Alex1
		if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
			CmdHighPriority();
	}
}

PORT
void EnableEClassModulation(int bit) 
{
	if (prn->cw.eer != bit) 
	{
		prn->cw.eer = bit;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetOCBits(int b) 
{
	if (prn->oc_output != b)
	{
		prn->oc_output = b;
		if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
			CmdHighPriority();
	}
}

PORT
void SetAlexAtten(int bits) 
{
	if (mkiibpf) return;

	if ((prbpfilter->_20_dB_Atten | prbpfilter->_10_dB_Atten) != bits)
	{
		prbpfilter->_20_dB_Atten = (bits & 0x2) == 0x2;
		prbpfilter->_10_dB_Atten = bits & 0x1;
		if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
			CmdHighPriority();
	}
}

PORT
void SetADCDither(int bits) 
{

	if (prn->adc[0].dither != bits) 
	{
		prn->adc[0].dither = prn->adc[1].dither = prn->adc[2].dither = bits;
		if (listenSock != INVALID_SOCKET)
			CmdRx();
	}
}

PORT
void SetADCRandom(int bits) 
{

	if (prn->adc[0].random != bits) 
	{
		prn->adc[0].random = prn->adc[1].random = prn->adc[2].random = bits;
		if (listenSock != INVALID_SOCKET)
			CmdRx();
	}
}

PORT
void SetAntBits(int rx_only_ant, int trx_ant, int tx_ant, int rx_out, char tx) {

	if (mkiibpf)
	{
		if (rx_only_ant == 1 || tx) // set rx bypass only if Ext2 enabled
		{
			prbpfilter->_Rx_1_Out = (rx_out & 0x01) != 0; // RX BYPASS OUT RL17
			prbpfilter->_10_dB_Atten = 0; // RX MASTER IN SEL RL22
		}
		else
		{
			prbpfilter->_Rx_1_Out = 0; // RX BYPASS OUT RL17
			prbpfilter->_10_dB_Atten = rx_out & 0x1; // RX MASTER IN SEL RL22
		}
	}
	else
	{
		prbpfilter->_Rx_1_Out = (rx_out & 0x01) != 0; // RX BYPASS OUT RL17
	}

	prbpfilter->_Rx_1_In = (rx_only_ant & (0x01 | 0x02)) == 0x01; // Ext2
	prbpfilter->_Rx_2_In = (rx_only_ant & (0x01 | 0x02)) == 0x02; // Ext1
	prbpfilter->_XVTR_Rx_In = (rx_only_ant & (0x01 | 0x02)) == (0x01 | 0x02); // XVTR

	prbpfilter->_ANT_1 = (trx_ant & (0x01 | 0x02)) == 0x01;
	prbpfilter->_ANT_2 = (trx_ant & (0x01 | 0x02)) == 0x02;
	prbpfilter->_ANT_3 = (trx_ant & (0x01 | 0x02)) == (0x01 | 0x02);

	// clear the ANT 1-3 bits and set LPF bits from Alex0
	// Alex1 LPF bits will also get set realtime from SetAlexLPFBits()
	prbpfilter2->bpfilter &= prbpfilter2->bpfilter & 0x0700ffff;
	prbpfilter2->bpfilter |= prbpfilter->bpfilter & 0xf8ff0000;

	// then set the TX mode ANT 1-3 bits
	prbpfilter2->_TXANT_1 = (tx_ant & (0x01 | 0x02)) == 0x01;
	prbpfilter2->_TXANT_2 = (tx_ant & (0x01 | 0x02)) == 0x02;
	prbpfilter2->_TXANT_3 = (tx_ant & (0x01 | 0x02)) == (0x01 | 0x02);

	if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
		CmdHighPriority();
}

PORT
void SetVFOfreq(int id, int freq, int tx) 
{
	if (tx)
	{
		if (prn != NULL && prn->tx[id].frequency != freq)
		{
			prn->tx[id].frequency = freq;
			if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
				CmdHighPriority();
		}
	}
	else
	{
		if (prn != NULL && prn->rx[id].frequency != freq)
		{
			prn->rx[id].frequency = freq;
			if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
				CmdHighPriority();
		}
	}
}

PORT
void SetOutputPowerFactor(int u) 
{
	if (prn->tx[0].drive_level != u)
	{
		prn->tx[0].drive_level = u;
		if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
			CmdHighPriority();
	}
}

PORT
void SetMicBoost(int bits) 
{
	if (prn->mic.mic_boost != bits) 
	{
		prn->mic.mic_boost = bits;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetMicXlr(int bits)
{
	if (prn->mic.mic_xlr != bits)
	{
		prn->mic.mic_xlr = bits;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetLineIn(int bits) 
{
	if (prn->mic.line_in != bits) 
	{
		prn->mic.line_in = bits;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void EnableApolloFilter(int bits) 
{
	if (bits != 0)
		ApolloFilt = 0x4;
	else
		ApolloFilt = 0;
}

PORT
void EnableApolloTuner(int bits) 
{
	if (bits != 0)
		ApolloTuner = 0x8;
	else
		ApolloTuner = 0;
}

PORT
void EnableApolloAutoTune(int bits) 
{
	if (bits != 0)
		ApolloATU = 0x10;
	else
		ApolloATU = 0;
}

PORT
void SelectApolloFilter(int bits) 
{
	if (bits != 0)
		ApolloFiltSelect = 0x20;
	else
		ApolloFiltSelect = 0;
}

PORT
void SetAlexHPFBits(int bits) 
{
	if (AlexHPFMask != bits) 
	{
		prbpfilter->_13MHz_HPF = (bits & 0x01) != 0;
		prbpfilter->_20MHz_HPF = (bits & 0x02) != 0;
		prbpfilter->_9_5MHz_HPF = (bits & 0x04) != 0;
		prbpfilter->_6_5MHz_HPF = (bits & 0x08) != 0;
		prbpfilter->_1_5MHz_HPF = (bits & 0x10) != 0;
		prbpfilter->_Bypass = (bits & 0x20) != 0;
		prbpfilter->_6M_preamp = (bits & 0x40) != 0;
		if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
			CmdHighPriority();
	}

	AlexHPFMask = bits;
}

PORT
void DisablePA(int bit) 
{
	if (prn->tx[0].pa != bit) 
	{
		if (prn->discovery.BoardType == HermesLite)
			EnableApolloTuner(!bit);	// MI0BOT: This call used on HL2 to enable/disable PA

		prn->tx[0].pa = bit;		
		if (listenSock != INVALID_SOCKET)
			CmdGeneral();
	}
}

PORT
void SetAlex2HPFBits(int bits) 
{
	if (Alex2HPFMask != bits) 
	{
		prbpfilter2->_13MHz_HPF = (bits & 0x01) != 0;
		prbpfilter2->_20MHz_HPF = (bits & 0x02) != 0;
		prbpfilter2->_9_5MHz_HPF = (bits & 0x04) != 0;
		prbpfilter2->_6_5MHz_HPF = (bits & 0x08) != 0;
		prbpfilter2->_1_5MHz_HPF = (bits & 0x10) != 0;
		prbpfilter2->_Bypass = (bits & 0x20) != 0;
		prbpfilter2->_6M_preamp = (bits & 0x40) != 0;
		if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
			CmdHighPriority();
	}

	Alex2HPFMask = bits;
}

PORT
void SetBPF2Gnd(int bits) 
{
	if ((prbpfilter2->_rx2_gnd) != bits)
	{
		prbpfilter2->_rx2_gnd = (bits & 0x1) != 0;
		if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
			CmdHighPriority();
	}
}

PORT
void SetAlex3HPFBits(int bits) 
{
	Alex3HPFMask = bits;
}

PORT
void SetAlex4HPFBits(int bits) 
{
	Alex4HPFMask = bits;
}

PORT
// LPF bits can be used in older radioas as part of RX filtering too.
// Change to protocol 2 from 4.3 onwards: TX settings are encoded in the Alex1 word
// to remain comparible with older hardware, the logic will be:
// if MOX, write settings to alex0 and alex1
// if not MOX, write to alex1 if a TX setting else write to alex0
PORT
void SetAlexLPFBits(int bits, bool isTX, bool isMox)
{
	bool Alex0Changed = false;
	bool Alex1Changed = false;

	if (isMox || isTX)        // true if Alex1 should be written
	{
		if (Alex1LPFMask != bits) 
		{
			Alex1Changed = true;
			prbpfilter2->bpfilter &= 0x0700ffff;     // copy over Alex0 settings
			prbpfilter2->bpfilter |= prbpfilter->bpfilter & 0xf8ff0000;
			prbpfilter2->_30_20_LPF = (bits & 0x01) != 0;
			prbpfilter2->_60_40_LPF = (bits & 0x02) != 0;
			prbpfilter2->_80_LPF = (bits & 0x04) != 0;
			prbpfilter2->_160_LPF = (bits & 0x08) != 0;
			prbpfilter2->_6_LPF = (bits & 0x10) != 0;
			prbpfilter2->_12_10_LPF = (bits & 0x20) != 0;
			prbpfilter2->_17_15_LPF = (bits & 0x40) != 0;
			Alex1LPFMask = bits;
		}
	}

	if (isMox || !isTX)        // true if Alex0 should be written
	{
		if (AlexLPFMask != bits) 
		{
			Alex0Changed = true;
			prbpfilter->_30_20_LPF = (bits & 0x01) != 0;
			prbpfilter->_60_40_LPF = (bits & 0x02) != 0;
			prbpfilter->_80_LPF = (bits & 0x04) != 0;
			prbpfilter->_160_LPF = (bits & 0x08) != 0;
			prbpfilter->_6_LPF = (bits & 0x10) != 0;
			prbpfilter->_12_10_LPF = (bits & 0x20) != 0;
			prbpfilter->_17_15_LPF = (bits & 0x40) != 0;
			AlexLPFMask = bits;
		}
	}

	if (Alex1Changed || Alex0Changed)
	{
		if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
			CmdHighPriority();
	}
}

PORT
void SetAlex2LPFBits(int bits) 
{
	Alex2LPFMask = bits;
}

PORT
void SetAlex3LPFBits(int bits) 
{
	Alex3LPFMask = bits;
}

PORT
void SetAlex4LPFBits(int bits) 
{
	Alex4LPFMask = bits;
}

PORT
void SetRX1Preamp(int bits) 
{

	if (prn->rx[0].preamp != bits)
	{
		prn->rx[0].preamp = bits;
		if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
			CmdHighPriority();
	}
}

PORT
void SetRX2Preamp(int bits) 
{
	if (prn->rx[1].preamp != bits)
	{
		prn->rx[1].preamp = bits;
		if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
			CmdHighPriority();
	}
}

PORT
void SetMicTipRing(int bits) 
{
	if (prn->mic.mic_trs != bits) 
	{
		prn->mic.mic_trs = bits;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetMicBias(int bits) 
{
	if (prn->mic.mic_bias != bits) 
	{
		prn->mic.mic_bias = bits;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetMicPTT(int bits) 
{
	if (prn->mic.mic_ptt != bits) 
	{
		prn->mic.mic_ptt = bits;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetLineBoost(int bits) 
{
	if (prn->mic.line_in_gain != bits) 
	{
		prn->mic.line_in_gain = bits;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT // MI0BOT: Causes a HL2 to perform a reset on disconnect
void SetResetOnDisconnect(int bit) 
{
	if (prn->reset_on_disconnect != bit)
	{
		prn->reset_on_disconnect = bit & 0x1;
	}
}

PORT
void SetPureSignal(int bit) 
{
	if (prn->puresignal_run != bit)
	{
		prn->puresignal_run = bit & 0x1;
		//if (listenSock != INVALID_SOCKET)
		//	CmdHighPriority();
	}
}

PORT
void SetUserOut0(int out) 
{
	prn->user_dig_out = out & 1;	
}

PORT
void SetUserOut1(int out) 
{
	prn->user_dig_out = (out << 1) & 2;	
}

PORT
void SetUserOut2(int out) 
{
	prn->user_dig_out = (out << 2) & 4;
}

PORT
void SetUserOut3(int out) 
{
	prn->user_dig_out = (out << 3) & 8;	
}

PORT
void SetADC1StepAttenData(int data) 
{
	if (prn->adc[0].rx_step_attn != data)
	{
		prn->adc[0].rx_step_attn = data;
		if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
			CmdHighPriority();
	}
}

PORT
void SetADC2StepAttenData(int data) 
{
	if (prn->adc[1].rx_step_attn != data)
	{
		prn->adc[1].rx_step_attn = data;
		if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
			CmdHighPriority();
	}
}

PORT
void SetADC3StepAttenData(int data) 
{
	if (prn->adc[2].rx_step_attn != data)
	{
		prn->adc[2].rx_step_attn = data;
		if (listenSock != INVALID_SOCKET)
			CmdHighPriority();
	}
}

PORT
void ReversePaddles(int bits) 
{
	if (prn->cw.rev_paddle != bits) 
	{
		prn->cw.rev_paddle = bits;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetCWKeyerSpeed(int speed) 
{
	if (prn->cw.keyer_speed != speed) 
	{
		prn->cw.keyer_speed = speed;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetCWKeyerMode(int mode) 
{
	if (prn->cw.mode_b != mode) 
	{
		prn->cw.mode_b = mode;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetCWKeyerWeight(int weight) 
{
	if (prn->cw.keyer_weight != weight) 
	{
		prn->cw.keyer_weight = weight;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void EnableCWKeyerSpacing(int bits) 
{
	if (prn->cw.strict_spacing != bits) 
	{
		prn->cw.strict_spacing = bits;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetCWEdgeLength(int edge_length)
{
	if (prn->cw.edge_length != edge_length)
	{
		prn->cw.edge_length = edge_length;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetADC_cntrl1(int bits) 
{
	if (ADC_cntrl1 != bits) 
	{
		prn->rx[0].rx_adc = bits & 0x3;
		prn->rx[1].rx_adc = (bits >> 2) & 0x3;
		prn->rx[2].rx_adc = (bits >> 4) & 0x3;
		prn->rx[3].rx_adc = (bits >> 6) & 0x3;
		//if (listenSock != INVALID_SOCKET)
		//	CmdRx();
	}

	ADC_cntrl1 = bits;
}

PORT
int GetADC_cntrl1() 
{
	return ADC_cntrl1;
}

PORT
void SetADC_cntrl2(int bits) 
{
	if (ADC_cntrl2 != bits) 
	{
		prn->rx[4].rx_adc = bits & 0x3;
		prn->rx[5].rx_adc = (bits >> 2) & 0x3;
		prn->rx[6].rx_adc = (bits >> 4) & 0x3;
		//if (listenSock != INVALID_SOCKET)
		//	CmdRx();
	}

	ADC_cntrl2 = bits;
}

PORT
int GetADC_cntrl2() 
{
	return ADC_cntrl2;
}


PORT
void SetADC_cntrl_P1(int bits)						// ADC assignment for protocol1.  14 bits, 2 per DDC:  66554433221100
{
	P1_adc_cntrl = bits;
}

PORT
int GetADC_cntrl_P1()
{
	return P1_adc_cntrl;
}


PORT
void SetTxAttenData(int bits) 
{
	int i;

	if (prn->adc[0].tx_step_attn != bits) 
	{
		for (i = 0; i < MAX_ADC; i++) 
		{
			prn->adc[i].tx_step_attn = bits;
		}
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void EnableCWKeyer(int enable) 
{
	if (prn->cw.cw_enable != enable) 
	{
		prn->cw.cw_enable = enable;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetCWSidetoneVolume(int vol) 
{
	if (prn->cw.sidetone_level != vol) 
	{
		prn->cw.sidetone_level = vol;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetCWPTTDelay(int delay) 
{
	if (prn->cw.rf_delay != delay) 
	{
		prn->cw.rf_delay = delay;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetCWHangTime(int time) 
{
	if (prn->cw.hang_delay != time)
	{
		prn->cw.hang_delay = time;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetCWSidetoneFreq(int freq) 
{
	if (prn->cw.sidetone_freq != freq) 
	{
		prn->cw.sidetone_freq = freq;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetEERPWMmin(int min) 
{
	if (prn->tx[0].epwm_min != min)
	{
		prn->tx[0].epwm_min = min;
		if (listenSock != INVALID_SOCKET)
			CmdGeneral();
	}
}

PORT
void SetEERPWMmax(int max) 
{
	if (prn->tx[0].epwm_max != max)
	{
		prn->tx[0].epwm_max = max;
		if (listenSock != INVALID_SOCKET)
			CmdGeneral();
	}
}

//MW0LGE_22b
PORT
void SetAudioAmpEnable(int enable)
{
	if (audioamp_enable != enable)
	{
		audioamp_enable = enable;
		if (listenSock != INVALID_SOCKET && prn->sendHighPriority != 0)
			CmdHighPriority();
	}
}

// *************************************************
// misc functions
// *************************************************
PORT
void SetCWSidetone(int enable) 
{
	if (prn->cw.sidetone != enable) 
	{
		prn->cw.sidetone = enable;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetCWIambic(int enable) 
{
	if (prn->cw.iambic != enable) 
	{
		prn->cw.iambic = enable;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetCWBreakIn(int enable) 
{
	if (prn->cw.break_in != enable) 
	{
		prn->cw.break_in = enable;
		if (listenSock != INVALID_SOCKET)
			CmdTx();
	}
}

PORT
void SetCWDash(int bit) 
{
	if (prn->tx[0].dash != bit) 
	{
		prn->tx[0].dash = bit;
		if (listenSock != INVALID_SOCKET)
			CmdHighPriority();
	}
}

PORT
void SetCWDot(int bit) 
{
	if (prn->tx[0].dot != bit) 
	{
		prn->tx[0].dot = bit;
		if (listenSock != INVALID_SOCKET)
			CmdHighPriority();
	}
}

PORT
void SetCWX(int bit) 
{
	if (prn->tx[0].cwx != bit) 
	{
		prn->tx[0].cwx = bit;
		if (listenSock != INVALID_SOCKET) //[2.10.3.6]MW0LGE high priority always
			CmdHighPriority();
	}
}

PORT // MI0BOT: On the HL2 the CWX protocol has been updated to pass PTT in Bit 3 
void SetCWXPTT(int bit) 
{
	if (prn->tx[0].cwx_ptt != bit) 
	{
		prn->tx[0].cwx_ptt = bit;
		if (listenSock != INVALID_SOCKET)
			CmdHighPriority();
	}
}

PORT
int getHaveSync() 
{
	return HaveSync;
}

PORT
int getControlByteIn(int n) 
{
	if (n < 0 || n > 4) 
	{
		return -1;
	}
	return ControlBytesIn[n];
}

PORT
void EnableRx(int id, int enable) 
{
	if (prn->rx[id].enable != enable)
	{
		prn->rx[id].enable = enable & 0x1;
		if (listenSock != INVALID_SOCKET)
			CmdRx();
	}
}

PORT
void EnableRxs(int rxs) 
{
	int i, sum = 0;

	for (i = 0; i < 4; i++)
	{
		sum += (prn->rx[i].enable << i);
	}

	if (sum != rxs)
	{
		for (i = 0; i < 4; i++)
		{
			prn->rx[i].enable = (rxs >> i) & 0x1;
		}
	}

	if (RadioProtocol == USB)
	{
		sum = 0;
		for (i = 0; i < 4; i++)
		{
			sum += (prn->rx[i].enable);
		}
		nreceivers = sum;
	}
}

PORT
void EnableRxSync(int id, int sync)
{
	if (prn->rx[id].sync != sync)
	{
		prn->rx[id].sync = sync & 0xff;
	}
}

PORT
void Protocol1DDCConfig(int ddcconfig, int en_diversity, int rxcount, int inddc)
{
	P1ddcconfig = ddcconfig;
	P1_en_diversity = en_diversity;
	nddc = inddc;
	P1_rxcount = rxcount;
}

PORT
void SetDDCRate(int id, int rate)
{
		switch (rate)
		{
		case 0:
			prn->rx[id].sampling_rate = 0;
			break;
		case 48000:
			prn->rx[id].sampling_rate = 48;
			break;
		case 96000:
			prn->rx[id].sampling_rate = 96;
			break;
		case 192000:
			prn->rx[id].sampling_rate = 192;
			break;
		case 384000:
			prn->rx[id].sampling_rate = 384;
			break;
		case 768000:
			prn->rx[id].sampling_rate = 768;
			break;
		case 1536000:
			prn->rx[id].sampling_rate = 1536;
			break;
		}

		if (id == 0 && RadioProtocol == USB)
		{
			switch (rate)
			{
			case 48000:
				SampleRateIn2Bits = 0;
				mic_decimation_factor = 1;
				break;
			case 96000:
				SampleRateIn2Bits = 1;
				mic_decimation_factor = 2;
				break;
			case 192000:
				SampleRateIn2Bits = 2;
				mic_decimation_factor = 4;
				break;
			case 384000:
				SampleRateIn2Bits = 3;
				mic_decimation_factor = 8;
				break;
			default:
				SampleRateIn2Bits = 2;
				mic_decimation_factor = 4;
				break;
			}
            mic_decimation_count = 0;
		}
}

PORT
void SetRxADC(int n) 
{
	if (prn->num_adc != n)
	{
		prn->num_adc = n;
		if (listenSock != INVALID_SOCKET)
			CmdRx();
	}
}

// wideband data display
PORT
void SetWBPacketsPerFrame(int ppf)
{
	prn->wb_packets_per_frame = ppf;
	if (listenSock != INVALID_SOCKET)
		CmdGeneral();
}

PORT
void SetWBUpdateRate(int ur)
{
	prn->wb_update_rate = ur;
	if (listenSock != INVALID_SOCKET)
		CmdGeneral();
}

PORT
void SetWBEnable(int adc, int enable)
{
	if (enable) InterlockedBitTestAndSet(&prn->wb_enable, adc);
	else        InterlockedBitTestAndReset(&prn->wb_enable, adc);
	if (listenSock != INVALID_SOCKET)
		CmdGeneral();
}

PORT
void SendHighPriority(int send) 
{
	if (send)
	{
		prn->sendHighPriority = 1;
		if (listenSock != INVALID_SOCKET)
			CmdHighPriority();
	}
	else prn->sendHighPriority = 0;
}

PORT
void SetWatchdogTimer(int enable)
{
	if (prn->wdt != enable)
	{
		prn->wdt = enable;
		if (listenSock != INVALID_SOCKET)
			CmdGeneral();
	}
}

PORT
void SetMKIIBPF(int bpf)
{
	mkiibpf = bpf;
}

PORT
void SetXVTREnable(int enable)
{
	if (xvtr_enable != enable)
	{
		xvtr_enable = enable;
		if (listenSock != INVALID_SOCKET)
			CmdHighPriority();
	}
}

PORT
void ATU_Tune(int tune)
{
	if (atu_tune != tune)
	{
		atu_tune = tune;
		if (listenSock != INVALID_SOCKET)
			CmdHighPriority();
	}
}

PORT
int getLEDs()
{
	return prn->hardware_LEDs;
}

PORT
void LRAudioSwap (int swap)
{
	if (prn->lr_audio_swap != swap)
		prn->lr_audio_swap = swap;
}

PORT // MI0BOT: Board type is now discovered to allow different operations for the HL2
void SetDiscoveryBoardType (int boardType)
{
	prn->discovery.BoardType = boardType;
}

PORT // MI0BOT: Controls the delay for PTT to Tx power out for HL2
void SetTxLatency (int txLatency)
{
	prn->tx[0].tx_latency = txLatency;
}

PORT // MI0BOT: Determines the delay until Tx/Rx change over after Tx buffer empties for the HL2
void SetPttHang (int pttHang)
{
	prn->tx[0].ptt_hang = pttHang;
}

PORT // MI0BOT: Initialises for a read of the I2C on the HL2
int I2CReadInitiate(int bus, int address, int control)
{
	int return_code = -1;

	// Only read when a sequence of writes are not in progress
	// This is true only when the IN and OUT indexes are the same

	if (prn->i2c.in_index == prn->i2c.out_index)
	{
		// Get the next free spot in the queue

		unsigned char next = prn->i2c.in_index + 1 >= MAX_I2C_QUEUE ? 0 : prn->i2c.in_index + 1;

		prn->i2c.i2c_queue[next].bus = bus;
		prn->i2c.i2c_queue[next].address = address;
		prn->i2c.i2c_queue[next].control = control;

		prn->i2c.i2c_control = 0;	// Clear all the control bits
		prn->i2c.ctrl_read = 1;
		prn->i2c.ctrl_stop = 1;
		prn->i2c.ctrl_request = 1;

		prn->i2c.in_index = next;	// Move IN index on to start the transmission

		return_code = 0;
	}

	return return_code;
}

PORT // MI0BOT: Initialises for a write of the I2C on the HL2 where a return is expected
int I2CWriteInitiate(int bus, int address, int control, int data)
{
	int return_code = -1;

	if (0 == prn->i2c.ctrl_read)
	{
		// Only proceed if read is not in progress

		// Get the next index in the IN queue
		unsigned char next = prn->i2c.in_index + 1 >= MAX_I2C_QUEUE ? 0 : prn->i2c.in_index + 1;

		if (next != prn->i2c.out_index)
		{
			// Only proceed if the indexes are not the same, as that is the overflow condition

			prn->i2c.i2c_queue[next].bus = bus;
			prn->i2c.i2c_queue[next].address = address;
			prn->i2c.i2c_queue[next].control = control;
			prn->i2c.i2c_queue[next].write_data = data;

			// We are expecting a response
			prn->i2c.ctrl_request = 1;

			// Move the index on to start the transmission
			prn->i2c.in_index = next;

			return_code = 0;
		}
	}

	return return_code;
}

PORT // MI0BOT: Write to the I2C on the HL2 when a return is not expected
int I2CWrite(int bus, int address, int control, int data)
{
	int return_code = -1;

	if (0 == prn->i2c.ctrl_read)
	{
		// Only proceed if read is not in progress

		// Get the next index in the IN queue
		unsigned char next = prn->i2c.in_index + 1 >= MAX_I2C_QUEUE ? 0 : prn->i2c.in_index + 1;

		if (next != prn->i2c.out_index)
		{
			// Only proceed if the indexs are not the same, as that is the overflow condition

			prn->i2c.i2c_queue[next].bus = bus;
			prn->i2c.i2c_queue[next].address = address;
			prn->i2c.i2c_queue[next].control = control;
			prn->i2c.i2c_queue[next].write_data = data;

			// Move the index on to start the transmission
			prn->i2c.in_index = next;

			return_code = 0;
		}
	}

	return return_code;
}

PORT // MI0BOT: Handles the I2C responses for the HL2
int I2CResponse(unsigned char* read_data)
{
	int return_code = 1;

	if (prn->i2c.ctrl_error)
	{
		return_code = -1;
	}
	else if (prn->i2c.ctrl_read_available)
	{
		prn->i2c.i2c_control = 0;

		read_data[0] = prn->i2c.read_data[0];
		read_data[1] = prn->i2c.read_data[1];
		read_data[2] = prn->i2c.read_data[2];
		read_data[3] = prn->i2c.read_data[3];

		return_code = 0;
	}

	return return_code;
}

PORT
void create_rnet() 
{
	int i;

	prn = (RADIONET)malloc(sizeof(radionet));
	if (prn) {
		prn->RxBuff = (double**) calloc (8, sizeof (double*));
		for (int i = 0; i < 8; i++)
			prn->RxBuff[i] = (double*) calloc (64, 2 * sizeof (double));
		prn->RxReadBufp = (double*)calloc(1, 2 * sizeof(double) * 240);
		prn->TxReadBufp = (double*)calloc(1, 2 * sizeof(double) * 720);
		prn->ReadBufp = (unsigned char*)calloc(1, sizeof(unsigned char) * 1444);
		prn->OutBufp = (char*)calloc(1, sizeof(char) * 1440);
		prn->outLRbufp = (double*)calloc(1, sizeof(double) * 1440); 
		prn->outIQbufp = (double*)calloc(1, sizeof(double) * 1440);
		prn->rx_base_port = 1035;
		prn->run = 0;
		prn->wdt = 0;
		prn->sendHighPriority = 1;
		prn->num_adc = 1;
		prn->num_dac = 1;
		prn->ptt_in = 0;
		prn->dot_in = 0;
		prn->dash_in = 0;
		prn->pll_locked = 0; //MW0LGE_21d
		prn->cc_seq_no = 0;
		prn->cc_seq_err = 0;

		prn->i2c.i2c_control = 0;	// MI0BOT: HL2 I2C variables 
		prn->i2c.returned_address = 0;
		prn->i2c.read_data[0] = 0;
		prn->i2c.read_data[1] = 0;
		prn->i2c.read_data[2] = 0;
		prn->i2c.read_data[3] = 0;
		prn->i2c.in_index = 0;
		prn->i2c.out_index = 0;
		prn->i2c.delay = 0;

		prn->cw.mode_control = 0;
		prn->cw.sidetone_level = 0;
		prn->cw.sidetone_freq = 0;
		prn->cw.keyer_speed = 0;
		prn->cw.keyer_weight = 0;
		prn->cw.hang_delay = 0;
		prn->cw.rf_delay = 0;
		prn->cw.edge_length = 7;

		prn->mic.mic_control = 0;
		prn->mic.line_in_gain = 0;
		prn->mic.spp = 64; // I-samples per packet

		prn->wb_base_port = 1027;
		prn->wb_base_dispid = 32;
		prn->wb_enable = 0;
		prn->wb_samples_per_packet = 512;
		prn->wb_sample_size = 16;
		prn->wb_update_rate = 70;
		prn->wb_packets_per_frame = 32;
		prn->lr_audio_swap = 0;
		prn->CATPort = 0;
		for (i = 0; i < MAX_ADC; i++) {
			prn->adc[i].id = i;
			prn->adc[i].rx_step_attn = 0;
			prn->adc[i].tx_step_attn = 31;
			prn->adc[i].adc_overload = 0;
			prn->adc[i].dither = 0;
			prn->adc[i].random = 0;
			prn->adc[i].wb_seqnum = 0;
			prn->adc[i].wb_state = 0;
			prn->adc[i].wb_buff = (double*)malloc0(1024 * sizeof(double));
		}

		for (i = 0; i < MAX_RX_STREAMS; i++) 
		{
			prn->rx[i].id = i;
			prn->rx[i].rx_adc = 0;
			prn->rx[i].frequency = 0;
			prn->rx[i].enable = 0;
			prn->rx[i].sync = 0;
			prn->rx[i].sampling_rate = 48;
			prn->rx[i].bit_depth = 24;
			prn->rx[i].preamp = 0;
			prn->rx[i].rx_in_seq_no = 0;
			prn->rx[i].rx_out_seq_no = 0;
			prn->rx[i].rx_in_seq_err = 0;
			prn->rx[i].time_stamp = 0;
			prn->rx[i].bits_per_sample = 0;
			prn->rx[i].spp = 238;				// IQ-samples per packet

			prn->rx[i].rx_in_seq_delta_index = 0;
			for (int ii = 0; ii < MAX_IN_SEQ_LOG; ii++) 
			{
				prn->rx[i].rx_in_seq_delta[ii] = 0;
			}
			prn->rx[i].snapshots_head = NULL;
			prn->rx[i].snapshots_tail = NULL;
			prn->rx[i].snapshot_length = 0;
			prn->rx[i].snapshot = NULL;
		}

		for (i = 0; i < MAX_TX_STREAMS; i++) 
		{
			prn->tx[i].id = i;
			prn->tx[i].frequency = 0;
			prn->tx[i].sampling_rate = 192;
			prn->tx[i].cwx = 0;
			prn->tx[i].cwx_ptt = 0;	// MI0BOT: HL2 control of PTT via CWX protocol
			prn->tx[i].dash = 0;
			prn->tx[i].dot = 0;
			prn->tx[i].ptt_out = 0;
			prn->tx[i].drive_level = 0;
			prn->tx[i].phase_shift = 0;
			prn->tx[i].epwm_max = 0;
			prn->tx[i].epwm_min = 0;
			prn->tx[i].pa = 0;
			prn->tx[i].tx_latency = 20;	// MI0BOT: HL2 
			prn->tx[i].ptt_hang = 12;	// MI0BOT: HL2 
			prn->tx[i].mic_in_seq_no = 0;
			prn->tx[i].mic_in_seq_err = 0;
			prn->tx[i].mic_out_seq_no = 0;
			prn->tx[i].spp = 240;	// IQ-samples per packet
		}

		for (i = 0; i < MAX_AUDIO_STREAMS; i++)
		{
			prn->audio[i].spp = 64; // LR-samples per packet
		}

		prn->puresignal_run = 0;

		prn->reset_on_disconnect = 0;	// MI0BOT: Intialised to not reset on software disconnect
		
		for (i = 0; i < 6; i++)
			prn->discovery.MACAddr[i] = 0;
		prn->discovery.BoardType = 0;
		prn->discovery.protocolVersion = 0;
		prn->discovery.fwCodeVersion = 0;
		prn->discovery.MercuryVersion_0 = 0;
		prn->discovery.MercuryVersion_1 = 0;
		prn->discovery.MercuryVersion_2 = 0;
		prn->discovery.MercuryVersion_3 = 0;
		prn->discovery.PennyVersion = 0;
		prn->discovery.MetisVersion = 0;
		prn->discovery.numRxs = 0;

		prbpfilter = (RBPFILTER)malloc0(sizeof(rbpfilter));
		prbpfilter->bpfilter = 0;
		prbpfilter->enable = 1;

		prbpfilter2 = (RBPFILTER2)malloc0(sizeof(rbpfilter2));
		prbpfilter2->bpfilter = 0;
		prbpfilter2->enable = 2;

		prn->hReadThreadMain = NULL;
		prn->hReadThreadInitSem = NULL;
		prn->hWriteThreadMain = NULL;
		prn->hWriteThreadInitSem = NULL;
		prn->hKeepAliveThread = NULL;
		prn->hTimer = NULL;

		(void)InitializeCriticalSectionAndSpinCount(&prn->udpOUT, 2500);
		(void)InitializeCriticalSectionAndSpinCount(&prn->sendOUT, 2500);		
		(void)InitializeCriticalSectionAndSpinCount(&prn->rcvpkt, 2500);
		(void)InitializeCriticalSectionAndSpinCount(&prn->sndpkt, 2500);
		(void)InitializeCriticalSectionAndSpinCount(&prn->rcvpktp1, 2500);
		(void)InitializeCriticalSectionAndSpinCount(&prn->seqErrors, 0); 

		switch (pcm->audioCodecId)
		{
		case HERMES:
			SendpOutboundRx(OutBound);
			break;
		case ASIO:
			SendpOutboundRx(asioOUT);
			break;
		case WASAPI:
			// not implmented
			break;
		}
		SendpOutboundTx(OutBound);
	}
}

PORT
void clearSnapshots()
{
	EnterCriticalSection(&prn->seqErrors);
	int i;
	for (i = 0; i < MAX_RX_STREAMS; i++) 
	{
		while (prn->rx[i].snapshots_head != NULL)
		{
			_seqLogSnapshot_t* tmp = prn->rx[i].snapshots_head;
			prn->rx[i].snapshots_head = tmp->next;
			free(tmp);
		}
		prn->rx[i].snapshot_length = 0;
		prn->rx[i].snapshots_tail = NULL;
	}
	LeaveCriticalSection(&prn->seqErrors);
}

PORT
void destroy_rnet() 
{
	int i;
	for (i = 0; i < MAX_ADC; i++)
	{
		_aligned_free(prn->adc[i].wb_buff);
	}
	DeleteCriticalSection(&prn->udpOUT);
	DeleteCriticalSection(&prn->rcvpkt);
	DeleteCriticalSection(&prn->sndpkt);
	DeleteCriticalSection(&prn->rcvpktp1);
	if (prn->OutBufp != NULL)
	    free(prn->OutBufp);
	free(prn->TxReadBufp);
	free(prn->RxReadBufp);
	for (i = 0; i < 8; i++)
		free (prn->RxBuff[i]);
	free (prn->RxBuff);
	free(prn->ReadBufp);
	clearSnapshots();
	DeleteCriticalSection(&prn->seqErrors);
	free(prn);
	_aligned_free(prbpfilter);
	_aligned_free(prbpfilter2);
	// destroy_obbuffs(0);
	// destroy_obbuffs(1);
}

void
PrintTimeHack() 
{
	GetLocalTime(&lt);
	printf("(%02d/%02d %02d:%02d:%02d:%03d) ", lt.wMonth, lt.wDay, lt.wHour, lt.wMinute, lt.wSecond, lt.wMilliseconds);
}

void PeakFwdPower(float fwd)
{
	if (fwd > FwdPower)
		FwdPower = fwd;
	else
		FwdPower *= MDECAY;
}

void PeakRevPower(float rev)
{
	if (rev > RevPower)
		RevPower = rev;
	else
		RevPower *= MDECAY;
}

void UpdateRadioProtocolSampleSize()
{
	int i;

	prn->mic.spp = RadioProtocol == USB ? 63 : 64;              // I-samples per packet

	for (i = 0; i < MAX_RX_STREAMS; i++) 
	{
		prn->rx[i].spp = RadioProtocol == USB ? 63 : 238;		// IQ-samples per packet
	}
	for (i = 0; i < MAX_TX_STREAMS; i++) 
	{
		prn->tx[i].spp = RadioProtocol == USB ? 126 : 240;	    // IQ-samples per packet
	}

	for (i = 0; i < MAX_AUDIO_STREAMS; i++)
	{
		prn->audio[i].spp = RadioProtocol == USB ? 126 : 64;    // LR-samples per packet
	}

	create_obbuffs(0, 1, 2048, prn->audio[0].spp);	// rx audio - last parameter is number of samples per packet
	create_obbuffs(1, 1, 2048, prn->tx[0].spp);    // tx mic audio
}

// set CAT over TCP port for remote communication with protocol client apps
PORT
void SetCATPort(int port)
{
	prn->CATPort = port;    // LR-samples per packet
	if (listenSock != INVALID_SOCKET)
		CmdHighPriority();

}