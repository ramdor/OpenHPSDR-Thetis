/*  network.h

This file is part of a program that implements a Software-Defined Radio.

Copyright (C) 2015-2020 Doug Wigley, W5WC

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

*/
#pragma once

#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <ws2tcpip.h>
#include <Mswsock.h>
#include <VersionHelpers.h>
#include "analyzer.h"
#include "cmcomm.h"

#define MAX_ADC					(3)
#define MAX_RX_STREAMS			(12)
#define MAX_TX_STREAMS			(3)
#define MAX_AUDIO_STREAMS		(2)
#define MAX_SYNC_RX             (2)
#define CACHE_ALIGN __declspec (align(16))

// MI0BOT: For I2C use on HL2
#define MAX_I2C_QUEUE			(32)

#define MAX_IN_SEQ_LOG			(40)
#define MAX_IN_SEQ_SNAPSHOTS	(20)

typedef struct _seqLogSnapshot {
	struct _seqLogSnapshot* next;
	struct _seqLogSnapshot* previous;

	int rx_in_seq_snapshot[MAX_IN_SEQ_LOG];
	char dateTimeStamp[24];
	unsigned int received_seqnum;
	unsigned int last_seqnum;
} _seqLogSnapshot_t;

typedef struct CACHE_ALIGN _radionet
{
	double** RxBuff;
	double* RxReadBufp;
	double* TxReadBufp;
	unsigned char* ReadBufp;
	char* OutBufp;
	double* outLRbufp;
	double* outIQbufp;
	//double* syncrxbuff[2];
	int rx_base_port;
	int run;
	int wdt;
	int sendHighPriority;
	int num_adc;
	int num_dac;
	int ptt_in;
	int dot_in;
	int dash_in;
	int pll_locked;
	int oc_output;
	int supply_volts;
	int user_adc0;
	int user_adc1;
	int user_adc2;
	int user_adc3;
	int user_dig_in;
	int user_dig_out;
	unsigned int cc_seq_no;
	unsigned int cc_seq_err;
	HANDLE hReadThreadMain;
	HANDLE hReadThreadInitSem;
	HANDLE hWriteThreadMain;
	HANDLE hWriteThreadInitSem;
	HANDLE hsendLRSem;
	HANDLE hsendIQSem;
	HANDLE hsendEventHandles[2];
	HANDLE hobbuffsRun[2];
	HANDLE hKeepAliveThread;
	HANDLE hTimer;
	LARGE_INTEGER liDueTime;
	CRITICAL_SECTION udpOUT;
	CRITICAL_SECTION sendOUT;
	CRITICAL_SECTION rcvpkt;
	CRITICAL_SECTION sndpkt;
	CRITICAL_SECTION seqErrors;
	CRITICAL_SECTION rcvpktp1;
	WSAEVENT hDataEvent;
	WSANETWORKEVENTS wsaProcessEvents;

	int hardware_LEDs;
	int reset_on_disconnect;	// MI0BOT: Reset on software disconnect

	struct _i2c	// MI0BOT: I2C data structure for HL2
	{
#pragma pack(push, 1)
		union
		{
			unsigned char i2c_control;
			struct {
				unsigned char ctrl_read : 1, // bit 00
							  ctrl_stop : 1, // bit 01   
						   ctrl_request : 1, // bit 02
						     ctrl_error : 1, // bit 03
					ctrl_read_available : 1, // bit 04
					                    : 1, // bit 05
					                    : 1, // bit 06
					                    : 1; // bit 07
			};
		};
#pragma pack(pop)

#pragma pack(push, 1)
		struct {
			unsigned char bus;
			unsigned char address;
			unsigned char control;
			unsigned char write_data;
		} i2c_queue[MAX_I2C_QUEUE];
#pragma pack(pop)

		unsigned char in_index;
		unsigned char out_index;
		  signed char delay;

		unsigned char returned_address;
		unsigned char read_data[4];

	} i2c;

	// puresignal settings
	int puresignal_run;

	// wideband settings
	int wb_base_port;
	int wb_base_dispid;
	int wb_samples_per_packet;
	int wb_sample_size;
	int wb_update_rate;
	int wb_packets_per_frame;
	volatile long wb_enable;

	// L & R audio swap for certain models; fixes firmware bugs
	int lr_audio_swap;

	// CAT over TCP/IP port
	int CATPort;

	struct _adc
	{
		int id;
		int rx_step_attn;
		int tx_step_attn;
		int adc_overload;
		int dither;
		int random;
		// wideband dynamic variables & data (per adc)
		int wb_seqnum;
		int wb_state;
		double* wb_buff;
	} adc[MAX_ADC];

	struct _cw
	{
		int sidetone_level;
		int sidetone_freq;
		int keyer_speed;
		int keyer_weight;
		int hang_delay;
		int rf_delay;
		int edge_length;
#pragma pack(push, 1)
		union
		{
			unsigned char mode_control;
			struct {
				unsigned char eer            : 1, // bit 00
				              cw_enable      : 1, // bit 01
				              rev_paddle     : 1, // bit 02
				              iambic         : 1, // bit 03
				              sidetone       : 1, // bit 04
			                  mode_b         : 1, // bit 05
				              strict_spacing : 1, // bit 06
			                  break_in       : 1; // bit 07
			};
		};
#pragma pack(pop)
	}cw;

	struct _mic
	{
		int line_in_gain;
#pragma pack(push, 1)
		union
		{
			unsigned char mic_control;
			struct {
				unsigned char line_in   : 1, // bit 00
				              mic_boost : 1, // bit 01
				              mic_ptt   : 1, // bit 02
				              mic_trs   : 1, // bit 03
				              mic_bias  : 1, // bit 04
				              mic_xlr   : 1, // bit 05
				                        : 1, // bit 06
				                        : 1; // bit 07
			};
		};
#pragma pack(pop)
		int  spp;			// I-samples per network packet
	} mic;

	struct _rx
	{
		int id;
		int rx_adc;
		int frequency;
		int enable;
		int sync;
		int sampling_rate;
		int bit_depth;
		int preamp;
		unsigned rx_in_seq_no;
		unsigned rx_in_seq_err;
		unsigned rx_out_seq_no;
		time_t time_stamp;
		unsigned bits_per_sample;
		int spp;							// IQ-samples per network packet
		int rx_in_seq_delta[MAX_IN_SEQ_LOG];	// ring buffer that contains a delta expected frame number vs recevied frame number
		int rx_in_seq_delta_index;		// next slot to use in ring
		_seqLogSnapshot_t* snapshots_head;		// simple linked list of snapshots of this ring buffer when a seq error occurs
		_seqLogSnapshot_t* snapshots_tail;		// simple linked list of snapshots of this ring buffer when a seq error occurs
		int snapshot_length;					// len of this snapshot list (used to limit)
		_seqLogSnapshot_t* snapshot;			// used by netInterface to work through the list each call;
	} rx[MAX_RX_STREAMS];

	struct _tx
	{
		int id;
		int frequency;
		int sampling_rate;
		int cwx;
		int cwx_ptt;	// MI0BOT: CWX enhancement for PTT on HL2
		int dash;
		int dot;
		int ptt_out;
		int drive_level;
		int exciter_power;
		int fwd_power;
		int rev_power;
		int phase_shift;
		int epwm_max;
		int epwm_min;
		int pa;
		int tx_latency;	// MI0BOT: Delay in TX buffer
		int ptt_hang;	// MI0BOT: Delay before PTT drops out after TX buffer empties 
		unsigned mic_in_seq_no;
		unsigned mic_in_seq_err;
		unsigned mic_out_seq_no;
		int spp;							// IQ-samples per network packet
	} tx[MAX_TX_STREAMS];

	struct _audio
	{
		int  spp;							// LR-samples per network packet
	} audio[MAX_AUDIO_STREAMS];

	struct _discovery
	{
		unsigned char MACAddr[6];
		char BoardType;
		char protocolVersion;
		char fwCodeVersion;
		char MercuryVersion_0;
		char MercuryVersion_1;
		char MercuryVersion_2;
		char MercuryVersion_3;
		char PennyVersion;
		char MetisVersion;
		char numRxs;
	} discovery;

} radionet, *RADIONET;

RADIONET prn;

#pragma pack(push, 1)
typedef struct _rbpfilter // radio band pass filter
{
	int  enable;
	union
	{
		unsigned bpfilter;
		struct {
			unsigned char  _rx_yellow_led : 1, // bit 00
			               _13MHz_HPF     : 1, // bit 01
			               _20MHz_HPF     : 1, // bit 02
			               _6M_preamp     : 1, // bit 03
			               _9_5MHz_HPF    : 1, // bit 04
			               _6_5MHz_HPF    : 1, // bit 05
			               _1_5MHz_HPF    : 1, // bit 06
			                              : 1, // bit 07

			               _XVTR_Rx_In    : 1, // bit 08			
			               _Rx_2_In       : 1, // bit 09 EXT1		
			               _Rx_1_In       : 1, // bit 10 EXT2
			               _Rx_1_Out      : 1, // bit 11 K36 RL17
			               _Bypass        : 1, // bit 12
			               _20_dB_Atten   : 1, // bit 13
			               _10_dB_Atten   : 1, // bit 14 (RX MASTER IN SEL RL22)
			               _rx_red_led    : 1, // bit 15

			                              : 1, // bit 16
			                              : 1, // bit 17
			               _trx_status    : 1, // bit 18
			               _tx_yellow_led : 1, // bit 19
			               _30_20_LPF     : 1, // bit 20
			               _60_40_LPF     : 1, // bit 21
			               _80_LPF        : 1, // bit 22
			               _160_LPF       : 1, // bit 23

			               _ANT_1         : 1, // bit 24
			               _ANT_2         : 1, // bit 25
			               _ANT_3         : 1, // bit 26
			               _TR_Relay      : 1, // bit 27
			               _tx_red_led    : 1, // bit 28
			               _6_LPF         : 1, // bit 29
			               _12_10_LPF     : 1, // bit 30
			               _17_15_LPF     : 1; // bit 31
		};
	};
}rbpfilter, *RBPFILTER;
#pragma pack(pop)
RBPFILTER prbpfilter;

#pragma pack(push, 1)
typedef struct _rbpfilter2 // radio band pass filter
{
	int  enable;
	union
	{
		unsigned bpfilter;
		struct {
			unsigned char  _rx_yellow_led : 1, // bit 00
			               _13MHz_HPF     : 1, // bit 01
			               _20MHz_HPF     : 1, // bit 02
			               _6M_preamp     : 1, // bit 03
			               _9_5MHz_HPF    : 1, // bit 04
			               _6_5MHz_HPF    : 1, // bit 05
			               _1_5MHz_HPF    : 1, // bit 06
			                              : 1, // bit 07

			               _rx2_gnd       : 1, // bit 08	
			                              : 1, // bit 09
			                              : 1, // bit 10
			                              : 1, // bit 11
			               _Bypass        : 1, // bit 12
			                              : 1, // bit 13
			                              : 1, // bit 14
			               _rx_red_led    : 1, // bit 15

			                              : 1, // bit 16
			                              : 1, // bit 17
			               _trx_status    : 1, // bit 18
			               _tx_yellow_led : 1, // bit 19
			               _30_20_LPF     : 1, // bit 20
			               _60_40_LPF     : 1, // bit 21
			               _80_LPF        : 1, // bit 22
			               _160_LPF       : 1, // bit 23

			               _TXANT_1       : 1, // bit 24
			               _TXANT_2       : 1, // bit 25
			               _TXANT_3       : 1, // bit 26
			               _TR_Relay      : 1, // bit 27
			               _tx_red_led    : 1, // bit 28
			               _6_LPF         : 1, // bit 29
			               _12_10_LPF     : 1, // bit 30
			               _17_15_LPF     : 1; // bit 31
		};
	};
}rbpfilter2, *RBPFILTER2;
#pragma pack(pop)
RBPFILTER2 prbpfilter2;

extern __declspec(dllexport) void create_rnet();
extern __declspec(dllexport) void destroy_rnet();
void WriteUDPFrame(int id, char *bufp, int buflen);
int sendPacket(SOCKET sock, char *data, int length, int port);
void CmdGeneral(void);
void CmdHighPriority(void);
extern __declspec(dllexport) void CmdRx(void);
void CmdTx(void);
DWORD WINAPI ReadThreadMain(LPVOID);
DWORD WINAPI KeepAliveMain(LPVOID);
void ReadThreadMainLoop();
void KeepAliveLoop();
void PrintTimeHack();
void PeakFwdPower(float fwd);
void PeakRevPower(float rev);
void UpdateRadioProtocolSampleSize();
int IOThreadStop(void);
int StartReadThread(void);
void StopReadThread(void);
__declspec (dllexport) int SendStartToMetis(void);
int io_keep_running;
int IOThreadRunning;   // non zero if IOThread is running
int XmitBit;
unsigned char ControlBytesIn[5];
int HaveSync;
int ADC_cntrl1;
int ADC_cntrl2;
int nreceivers;
int xvtr_enable;
int atu_tune; // controls J16 pin 10 on Orion MKII board
int audioamp_enable; // constrol audio amp on ?? board //MW0LGE_22b
int AlexHPFMask;
int AlexLPFMask;
int Alex1LPFMask;
int AlexTRRelay;
int Alex2HPFMask;
int Alex2LPFMask;
int Alex3HPFMask;
int Alex3LPFMask;
int Alex4HPFMask;
int Alex4LPFMask;
int mkiibpf;
float RevPower;
float FwdPower;
int ApolloFilt;
int ApolloFiltSelect;
int ApolloTuner;
int ApolloATU;

int WSAinitialized;
SOCKET listenSock;
int RemotePort;		// MI0BOT: Allows different remote port for WAN access
SYSTEMTIME lt;
static const double const_1_div_2147483648_ = 1.0 / 2147483648.0;

enum _TXPort
{

};

enum _RXPort
{
	HPCCPort = 1025, // High Priority C&C Data
	RxMicSampPort = 1026, // 16-bit Mic Samples
	WB0Port = 1027, // 16-Raw ADC Samples
};

enum HPSDRHW
{
	Atlas = 0,
	Hermes = 1,    // ANAN-10/100
	HermesII = 2,  // ANAN-10E/100B
	Angelia = 3,   // ANAN-100D
	Orion = 4,     // ANAN-200D
	OrionMKII = 5, // ANAN-7000DLE/8000DLE AnvelinaPro3
	HermesLite = 6 // MI0BOT: HL2 allocated number
};

enum _RadioProtocol
{
	USB = 0,  // Protocol USB (P1)
	ETH = 1   // Protocol ETH (P2)
} RadioProtocol;

// Protocol 1 USB
DWORD WINAPI MetisReadThreadMain(LPVOID n);
void WriteMainLoop(char* bufp);
void WriteMainLoop_HL2(char* bufp);		// MI0BOT: Different write loop for HL2
void MetisReadThreadMainLoop(void);
void MetisReadThreadMainLoop_HL2(void);	// MI0BOT: Different read loop for HL2
DWORD WINAPI  sendProtocol1Samples(LPVOID n);
 int MetisReadDirect(unsigned char* bufp);
 int MetisWriteFrame(int endpoint, char* bufp);
 void ForceCandCFrame(int);
 extern __declspec(dllexport) int SendStopToMetis();
 int FPGAReadBufSize;
 int FPGAWriteBufSize;
 unsigned char* FPGAReadBufp;
 char* FPGAWriteBufp;
 int P1ddcconfig;		// DDCconfig for P1 (h/w and mode dependent)
 int P1_en_diversity;		// true if diversity enabled
 int P1_rxcount;
 int P1_adc_cntrl;
 int nddc;
 int XmitBit;
 unsigned char SampleRateIn2Bits;
 int mic_decimation_factor;
 int mic_decimation_count;
