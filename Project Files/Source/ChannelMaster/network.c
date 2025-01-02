/*
 * network.c
 * Copyright (C) 2015-2020 Doug Wigley (W5WC)
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

#define _WINSOCK_DEPRECATED_NO_WARNINGS
#define _CRT_SECURE_NO_WARNINGS

#ifndef WIN32_LEAN_AND_MEAN
#define WIN32_LEAN_AND_MEAN
#endif

#include "network.h" 
#include <Iphlpapi.h>

#pragma comment(lib, "IPHLPAPI.lib")
#pragma comment(lib, "ws2_32.lib")

#define OBSOLETE (0) 
#define BUFLEN 1444

char MetisMACAddr[6] = { 0, 0, 0, 0, 0, 0 };
char MetisCodeVersion[1] = { 0 };
char MetisBoardID[1] = { 0 };
int rxreads = 0;
int mic_samples_buf = 0;
int rx_samples_buf = 0;
int rxreads_buf = 0;
int rxreads_buf_after = 0;
int rxreads_bf = 0;

int WSA_inited = 0; //MW0LGE_22b moved here

int initWSA(void) {
	WSADATA data;
	WORD wVersionRequested = 0x202;

	if (WSAinitialized) {
		if(WSA_inited) WSACleanup(); // MW0LGE_22b
	}

	//WSAinitialized = 1;//MW0LGE_22b
	if (WSAStartup(wVersionRequested, &data) != 0) {
		printf("Failed. Error Code : %d", WSAGetLastError());
		return 1;
	}
	WSAinitialized = 1;

	return 0;
}

u_long MetisAddr = 0;
struct sockaddr_in MetisSockAddr;
struct fd_set readfds, writefds;

PORT
void DeInitMetisSockets() {
	closesocket(listenSock);
	listenSock = INVALID_SOCKET;
	if (WSA_inited) { // MW0LGE_22b
		WSACleanup(); 
		WSA_inited = 0;
		WSAinitialized = 0;
	}
}

/* returns 0 on success, != 0 otherwise */	// MI0BOT: Added remotePort to allow remote access to several HL2s by different port number
PORT
int nativeInitMetis(char* netaddr, char* localaddr, int localport, int protocol, int remotePort) {
	IPAddr DestIp = 0;
	IPAddr SrcIp = 0;       /* default for src ip */
	ULONG MacAddr[2];       /* for 6-byte hardware addresses */
	ULONG PhysAddrLen = 6;  /* default to length of six bytes */
	int rc;
	int sndbufsize;
	struct sockaddr_in local = { 0 };

	RadioProtocol = protocol;

	//if (!WSA_inited) {
	//	rc = initWSA();
	//	if (rc != 0) {
	//		return rc;
	//	}
	//	WSA_inited = 1;
	//	printf("initWSA ok!\n");
	//}

	local.sin_port = htons((u_short)localport);
	local.sin_family = AF_INET;
	local.sin_addr.s_addr = inet_addr(localaddr);

	//if ((listenSock = socket(AF_INET, SOCK_DGRAM, 0)) == INVALID_SOCKET) {
	//	printf("createSocket Error: socket failed %ld\n", WSAGetLastError());
	//	WSACleanup();
	//	return INVALID_SOCKET;
	//}

	//MW0LGE_22b
	//winsock dll can already by initialised externally for this process
	//for example, by .NET, so we do not always need to do it
	//we can check this by the return from creating a socket()
	//Likewise, we only want to wsacleanup if we wsastarted 

	int initState = 1;
	while (initState > 0)
	{
		listenSock = socket(AF_INET, SOCK_DGRAM, 0);

		if (listenSock == (SOCKET)WSANOTINITIALISED) {
			WSA_inited = 0;

			if (initState == 2) // we alrady tried, and we are still not initialised
			{
				printf("socket() still returns wsa not initialised!\n");
				return 1;
			}		

			rc = initWSA();
			if (rc != 0) {
				printf("initWSA failed rc!\n");
				return rc;
			}
			initState = 2;
			WSA_inited = 1;
			printf("initWSA ok!\n");
			///
		}
		else if (listenSock == INVALID_SOCKET) {
			printf("createSocket Error: socket failed %ld\n", WSAGetLastError());
			if(WSA_inited) WSACleanup(); //MW0LGE_22b
			return INVALID_SOCKET;
		}
		else {
			initState = 0;
		}
	}

	// bind to the local address
	bind(listenSock, (SOCKADDR*)&local, sizeof(local));
	MetisAddr = inet_addr(netaddr);
	fflush(stdout);

	sndbufsize = 0xfa000;
	setsockopt(listenSock, SOL_SOCKET, SO_SNDBUF, (const char *)&sndbufsize, sizeof(int));	
	sndbufsize = 0xfa000; // MW0LGE [2.9.0.8] from Warren, changed from 0x10000
	setsockopt(listenSock, SOL_SOCKET, SO_RCVBUF, (const char *)&sndbufsize, sizeof(int));
	
	DestIp = inet_addr(netaddr);

	if (DestIp != 0) {
		printf("destination addr: 0x%08x\n", DestIp);
		fflush(stdout);

		RemotePort = remotePort;	// MI0BOT: Remote access over WAN using different port

		//add to ARP table
		memset(&MacAddr, 0xff, sizeof(MacAddr));
		SendARP(DestIp, SrcIp, &MacAddr, &PhysAddrLen);
		return 0;
	}
	return -4;
}

PORT
int GetMetisIPAddr(void) {
	return MetisAddr;
}

PORT
void GetMACAddr(unsigned char addr_bytes[]) {
	memcpy(addr_bytes, prn->discovery.MACAddr, 6);
}

PORT
void GetCodeVersion(unsigned char addr_bytes[]) {
	memcpy(addr_bytes, &(prn->discovery.fwCodeVersion), 1);
}

PORT
void GetBoardID(char addr_bytes[]) {
	memcpy(addr_bytes, &(prn->discovery.BoardType), 1);
}

int SendStart(void) {
	prn->run = 1;
	CmdGeneral(); //1024
	CmdRx(); //1025
	CmdTx(); //1026
	CmdHighPriority(); //1027

	return 0;
}

int SendStop(void) {
	prn->run = 0;
	CmdHighPriority();

	return 0;
}

/* returns 0 on success, !0 on failure */
int StartReadThread(void) {
	int myrc = 0;

	do {

		if (SendStart() != 0) {
			printf("SendStart failed ...\n"); fflush(stdout);
			StopReadThread();
			myrc = -3;
			break;
		}


	} while (0);

	return myrc;
}

void StopReadThread() {
	PrintTimeHack();
	printf("- StopReadThread()\n");
	fflush(stdout);
	if (RadioProtocol == ETH) SendStop();
	else SendStopToMetis();
	DeInitMetisSockets();
}

void addSnapShot(int rx, unsigned int received_seqnum, unsigned int last_seqnum)
{
	// add newest to head
	EnterCriticalSection(&prn->seqErrors);

	_seqLogSnapshot_t* snapshot = malloc(sizeof(_seqLogSnapshot_t));
	if (snapshot == NULL) {
		LeaveCriticalSection(&prn->seqErrors);
		return; //eek
	}

	memcpy(snapshot->rx_in_seq_snapshot, prn->rx[rx].rx_in_seq_delta, sizeof(int) * MAX_IN_SEQ_LOG);

	snapshot->previous = NULL;

	SYSTEMTIME localTime;
	GetLocalTime(&localTime);
	sprintf(snapshot->dateTimeStamp, "%02d/%02d %02d:%02d:%02d:%03d", localTime.wMonth, localTime.wDay, localTime.wHour, localTime.wMinute, localTime.wSecond, localTime.wMilliseconds);

	snapshot->received_seqnum = received_seqnum;
	snapshot->last_seqnum = last_seqnum;

	if (prn->rx[rx].snapshot_length == MAX_IN_SEQ_SNAPSHOTS) {
		// too many in the list, dump tail
		_seqLogSnapshot_t* tmp = prn->rx[rx].snapshots_tail;

		prn->rx[rx].snapshots_tail = tmp->previous;
		prn->rx[rx].snapshots_tail->next = NULL;
		prn->rx[rx].snapshot_length--;

		//check to see if prn->rx[rx].snapshot is the one we are dumping
		//prn->rx[rx].snapshot is used in the retrieve snapshot code in netinterface
		if (prn->rx[rx].snapshot == tmp) {
			prn->rx[rx].snapshot = prn->rx[rx].snapshots_tail;
		}

		free(tmp);
	}

	if (prn->rx[rx].snapshots_head == NULL) {
		// new
		snapshot->next = NULL;
		prn->rx[rx].snapshots_head = snapshot;
		prn->rx[rx].snapshots_tail = snapshot;
	}
	else
	{
		// add to head
		prn->rx[rx].snapshots_head->previous = snapshot;
		snapshot->next = prn->rx[rx].snapshots_head;
		prn->rx[rx].snapshots_head = snapshot;
	}

	prn->rx[rx].snapshot_length++;

	LeaveCriticalSection(&prn->seqErrors);
}

void storeRXSeqDelta(int rx, unsigned int received_seqnum) {
	EnterCriticalSection(&prn->seqErrors);

	int delta = (int)received_seqnum - (1 + prn->rx[rx].rx_in_seq_no);

	int i = prn->rx[rx].rx_in_seq_delta_index;

	prn->rx[rx].rx_in_seq_delta[i] = delta;

	i++;
	if (i == MAX_IN_SEQ_LOG) i = 0;
	prn->rx[rx].rx_in_seq_delta_index = i;

	LeaveCriticalSection(&prn->seqErrors);
}

int ReadUDPFrame(unsigned char* bufp)
{
	unsigned char readbuf[1444];
	struct sockaddr_in fromaddr;
	int fromlen;
	int nrecv, inport;
	unsigned int seqnum;
	unsigned char* seqbytep = (unsigned char*)&seqnum;
	fromlen = sizeof(fromaddr);

	EnterCriticalSection(&prn->rcvpkt);

	nrecv = recvfrom(listenSock, readbuf, sizeof(readbuf), 0, (SOCKADDR*)&fromaddr, &fromlen);

	if (nrecv == -1) //SOCKET_ERROR
	{
		errno = WSAGetLastError();
		if (errno == WSAEWOULDBLOCK || errno == WSAEMSGSIZE)
		{
			printf("Error code %d: recvfrom() : %s\n", errno, strerror(errno));
			fflush(stdout);
		}
		LeaveCriticalSection(&prn->rcvpkt);
		return nrecv;
	}

	seqbytep[3] = readbuf[0];
	seqbytep[2] = readbuf[1];
	seqbytep[1] = readbuf[2];
	seqbytep[0] = readbuf[3];

	switch (inport = ntohs(fromaddr.sin_port))
	{
	case HPCCPort: //1025: // 60 bytes - High Priority C&C data
		if (nrecv != 60) break; // check for malformed packet

		if (seqnum != (1 + prn->cc_seq_no) && seqnum != 0)
		{
			prn->cc_seq_err += 1;
			//PrintTimeHack();
			printf("- Rx High Priority C&C: seq error this: %i last: %i\n", seqnum, prn->cc_seq_no);
			fflush(stdout);
		}

		prn->cc_seq_no = seqnum;
		memcpy(bufp, readbuf + 4, 56);
		break;

	case  RxMicSampPort: //1026: // 132 bytes - 16-bit mic samples (48ksps)
		if (nrecv != 132) break; // check for malformed packet

		//mic_samples_buf++;
		if (seqnum != (1 + prn->tx[0].mic_in_seq_no) && seqnum != 0)
		{
			prn->tx[0].mic_in_seq_err += 1;
			//PrintTimeHack();
			printf("- Mic samples: seq error this: %i last: %i\n", seqnum, prn->tx[0].mic_in_seq_no);
			fflush(stdout);
		}

		prn->tx[0].mic_in_seq_no = seqnum;
		memcpy(bufp, readbuf + 4, 128);
		break;

	case WB0Port: //1027: // 1028 bytes - 16-bit raw ADC (default values)
	{
		if (nrecv != 1028) break; // check for malformed packet

		int adc_id = inport - prn->wb_base_port;				// adc number
		int wb_spp = prn->wb_samples_per_packet;			// samples per packet
		int wb_ppf = prn->wb_packets_per_frame;			// packets per frame
		int disp_id = prn->wb_base_dispid + adc_id;				// display id
		double* wb_buff = prn->adc[adc_id].wb_buff;				// data buffer for wideband samples
		// NOTE:  This code assumes 16-bits per sample ... can add other options as needed.
		int ii, jj;
		for (ii = 0, jj = 4; ii < wb_spp; ii++, jj += 2)		// convert the samples to doubles
			wb_buff[ii] = const_1_div_2147483648_ *
			(double)(readbuf[jj + 0] << 24 |
				readbuf[jj + 1] << 16);
		switch (prn->adc[adc_id].wb_state)
		{
		case 0:		// wait for frame to begin
			prn->adc[adc_id].wb_seqnum = 0;
			if (seqnum == 0)
			{
				prn->adc[adc_id].wb_state = 1;
				Spectrum(disp_id, 0, 0, wb_buff, wb_buff);
				prn->adc[adc_id].wb_seqnum++;
			}
			break;

		case 1:		// continue within the frame
			if (seqnum == prn->adc[adc_id].wb_seqnum)			// sequence correct:  send the data
			{
				Spectrum(disp_id, 0, 0, wb_buff, wb_buff);
				if (prn->adc[adc_id].wb_seqnum == wb_ppf - 1)
					prn->adc[adc_id].wb_state = 0;
			}
			else												// sequence error:  pad frame with zeros
			{
				memset(wb_buff, 0, wb_spp * sizeof(double));
				for (jj = prn->adc[adc_id].wb_seqnum; jj < wb_ppf; jj++)
					Spectrum(disp_id, 0, 0, wb_buff, wb_buff);
				prn->adc[adc_id].wb_state = 0;
			}
			prn->adc[adc_id].wb_seqnum++;
			break;
		}

		break;
	}

	case 1035:// ddc0
	case 1036:// ddc1
	case 1037:// ddc2
	case 1038:// ddc3
	case 1039:// ddc4
	case 1040:// ddc5
	case 1041:// ddc6
	{
		if (nrecv != 1444) break; // check for malformed packet

		int ddc = inport - 1035;

		if (seqnum != 0) storeRXSeqDelta(ddc, seqnum);

		if (seqnum != (1 + prn->rx[ddc].rx_in_seq_no) && seqnum != 0)
		{
			prn->rx[ddc].rx_in_seq_err += 1;
			printf("- Rx%d I/Q: seq error this: %d last: %d\n", ddc, seqnum, prn->rx[ddc].rx_in_seq_no);
			fflush(stdout);

			addSnapShot(ddc, seqnum, prn->rx[ddc].rx_in_seq_no);
		}

		prn->rx[ddc].rx_in_seq_no = seqnum;
		memcpy(bufp, readbuf + 16, 1428);
		break;
	}

	default:
		printf("Rcvd data on Port %d\n", nrecv);
		break;

	}

	LeaveCriticalSection(&prn->rcvpkt);

	return inport;
}

void
ReadThreadMainLoop() {
	int i, rc, k;
	//double sbuf[500] = { 0 };	// FOR DEBUG ONLY

	prn->hDataEvent = WSACreateEvent();
	WSAEventSelect(listenSock, prn->hDataEvent, FD_READ);
	PrintTimeHack();
	printf("- ReadThreadMainLoop()\n");
	fflush(stdout);

	while (io_keep_running != 0) {
		DWORD retVal = WSAWaitForMultipleEvents(1, &prn->hDataEvent, FALSE, prn->wdt ? 3000 : WSA_INFINITE, FALSE);
		if ((retVal == WSA_WAIT_FAILED) || (retVal == WSA_WAIT_TIMEOUT))
		{
			HaveSync = 0; //send console LOS			
			SendStop();
			memset(prn->RxReadBufp, 0, prn->rx[0].spp);
			memset(prn->TxReadBufp, 0, prn->mic.spp);
			Inbound(inid(0, 0), prn->rx[0].spp, prn->RxReadBufp);
			Inbound(inid(0, 1), prn->rx[1].spp, prn->RxReadBufp);
			Inbound(inid(1, 0), prn->mic.spp, prn->TxReadBufp);
			continue;
		}
		else
		{
			WSAEnumNetworkEvents(listenSock, prn->hDataEvent, &prn->wsaProcessEvents);
			if (prn->wsaProcessEvents.lNetworkEvents & FD_READ)
			{
				if (prn->wsaProcessEvents.iErrorCode[FD_READ_BIT] != 0)
				{
					printf("FD_READ failed with error %d\n",
						prn->wsaProcessEvents.iErrorCode[FD_READ_BIT]);
					break;
				}

				rc = ReadUDPFrame(prn->ReadBufp);

				switch (rc)
				{
				case 1025:
					//Byte 0 - Bit [0] - PTT  1 = active, 0 = inactive
					//         Bit [1] - Dot  1 = active, 0 = inactive
					//         Bit [2] - Dash 1 = active, 0 = inactive
					prn->ptt_in = prn->ReadBufp[0] & 0x1;
					prn->dot_in = prn->ReadBufp[0] & 0x2;
					prn->dash_in = prn->ReadBufp[0] & 0x4;
					prn->pll_locked = prn->ReadBufp[0] & 0x10; //MW0LGE_21d

					//Byte 1 - Bit [0] - ADC0  Overload 1 = active, 0 = inactive
					//		   Bit [1] - ADC1  Overload 1 = active, 0 = inactive
					//         Bit [2] - ADC2  Overload 1 = active, 0 = inactive  * ADC2-7 set to 0 for Angelia
					//         Bit [3] - ADC3  Overload 1 = active, 0 = inactive
					//         Bit [4] - ADC4  Overload 1 = active, 0 = inactive
					//         Bit [5] - ADC5  Overload 1 = active, 0 = inactive
					//         Bit [6] - ADC6  Overload 1 = active, 0 = inactive
					//         Bit [7] - ADC7  Overload 1 = active, 0 = inactive
					for (i = 0; i < MAX_ADC; i++)
						prn->adc[i].adc_overload = ((prn->ReadBufp[1] >> i) & 0x1) != 0;

					//Bytes 2,3      Exciter Power [15:0]     * 12 bits sign extended to 16
					//Bytes 10,11    FWD Power [15:0]           ditto
					//Bytes 18,19    REV Power [15:0]           ditto
					prn->tx[0].exciter_power = prn->ReadBufp[2] << 8 | prn->ReadBufp[3];
					prn->tx[0].fwd_power = prn->ReadBufp[10] << 8 | prn->ReadBufp[11];
					prn->tx[0].rev_power = prn->ReadBufp[18] << 8 | prn->ReadBufp[19];
					PeakFwdPower((float)(prn->tx[0].fwd_power));
					PeakRevPower((float)(prn->tx[0].rev_power));
					//Bytes 45,46  Supply Volts [15:0]          
					prn->supply_volts = prn->ReadBufp[45] << 8 | prn->ReadBufp[46];

					//Bytes 47,48  User ADC3 [15:0]            
					//Bytes 49,50  User ADC2 [15:0]             
					//Bytes 51,52  User ADC1 [15:0]            
					//Bytes 53,54  User ADC0 [15:0]             
					prn->user_adc3 = prn->ReadBufp[47] << 8 | prn->ReadBufp[48];
					prn->user_adc2 = prn->ReadBufp[49] << 8 | prn->ReadBufp[50];
					prn->user_adc1 = prn->ReadBufp[51] << 8 | prn->ReadBufp[52]; // AIN4
					prn->user_adc0 = prn->ReadBufp[53] << 8 | prn->ReadBufp[54]; // AIN3

					SetAmpProtectADCValue(0, prn->user_adc0);

					//Byte 55 - Bit [0] - User I/O (IO4) 1 = active, 0 = inactive
					//          Bit [1] - User I/O (IO5) 1 = active, 0 = inactive
					//          Bit [2] - User I/O (IO6) 1 = active, 0 = inactive
					//          Bit [3] - User I/O (IO8) 1 = active, 0 = inactive
					//          Bit [4] - User I/O (IO2) 1 = active, 0 = inactive
					prn->user_dig_in = prn->ReadBufp[55];

					prn->hardware_LEDs = prn->ReadBufp[26] << 8 | prn->ReadBufp[27];

					break;
				case 1026: // 1440 bytes 16-bit mic samples
					for (i = 0, k = 0; i < prn->mic.spp; i++, k += 2)
					{
						// prn->TxReadBufp[2 * i] = ((prn->ReadBufp[k + 0] & 0xff) | 
						// 	(prn->ReadBufp[k + 1] << 8)) / 32768.0;
						prn->TxReadBufp[2 * i] = const_1_div_2147483648_ *
							(double)(prn->ReadBufp[k + 0] << 24 |
								prn->ReadBufp[k + 1] << 16);
						prn->TxReadBufp[2 * i + 1] = 0.0;
					}
					//WriteAudio(30.0, 48000, 64, prn->TxReadBufp,3);
					Inbound(inid(1, 0), prn->mic.spp, prn->TxReadBufp);
					break;
				case 1027: // 1024 bytes 16bit raw ADC data, handled in ReadUDPFrame()
				case 1028:
				case 1029:
				case 1030:
				case 1031:
				case 1032:
				case 1033:
				case 1034:
					break;
				case 1035: // DDC I&Q data
				case 1036:
				case 1037:
				case 1038:
				case 1039:
				case 1040:
				case 1041:
					for (i = 0, k = 0; i < prn->rx[0].spp; i++, k += 6)
					{
						prn->RxReadBufp[2 * i + 0] = const_1_div_2147483648_ *
							(double)(prn->ReadBufp[k + 0] << 24 |
								prn->ReadBufp[k + 1] << 16 |
								prn->ReadBufp[k + 2] << 8);

						prn->RxReadBufp[2 * i + 1] = const_1_div_2147483648_ *
							(double)(prn->ReadBufp[k + 3] << 24 |
								prn->ReadBufp[k + 4] << 16 |
								prn->ReadBufp[k + 5] << 8);
					}

					//// sbuf[] USED FOR DEBUG ONLY
					//for (i = 0; i < 2 * prn->rx[0].spp; i++)
					//	sbuf[i] = prn->RxReadBufp[i];

					xrouter(0, 0, rc, prn->rx[0].spp, prn->RxReadBufp);
					//Inbound (1, 238, prn->RxReadBufp);
					break;
					//default:
					//	memset(RxReadBufp, 0, 240);
					//	Inbound (0, 240, RxReadBufp);
					//	break;
				}
			}
		}
	}
}

void CmdGeneral() { // port 1024

	char packetbuf[60];
	memset(packetbuf, 0, sizeof(packetbuf)); // fill the frame with 0x00
	// Command
	packetbuf[4] = 0x00;
	// Rx Specific port #1025
	packetbuf[5] = 0x04;
	packetbuf[6] = 0x01;
	// Tx Specific port #1026
	packetbuf[7] = 0x04;
	packetbuf[8] = 0x02;
	// High priority from PC port #1027
	packetbuf[9] = 0x04;
	packetbuf[10] = 0x03;
	// High Priority to PC port #1025
	packetbuf[11] = 0x04;
	packetbuf[12] = 0x01;
	// Rx Audio port #1028
	packetbuf[13] = 0x04;
	packetbuf[14] = 0x04;
	// Tx0 I&Q port #1029
	packetbuf[15] = 0x04;
	packetbuf[16] = 0x05;
	// Rx0 port #1035
	packetbuf[17] = prn->rx_base_port >> 8;
	packetbuf[18] = prn->rx_base_port & 0xff;
	// Mic Samples port #1026
	packetbuf[19] = 0x04;
	packetbuf[20] = 0x02;
	// Wideband ADC0 port default #1027
	packetbuf[21] = prn->wb_base_port >> 8;
	packetbuf[22] = prn->wb_base_port & 0xff;
	// Wideband enable WB0  = [0], WB1 = 1�..WB7 = [7]
	packetbuf[23] = (char)_InterlockedAnd(&prn->wb_enable, 0xff);
	// Wideband Samples per packet 512
	packetbuf[24] = prn->wb_samples_per_packet >> 8;
	packetbuf[25] = prn->wb_samples_per_packet & 0xff;
	// Wideband sample size 16-bits
	packetbuf[26] = prn->wb_sample_size;
	// Wideband update rate in milliseconds
	packetbuf[27] = prn->wb_update_rate;
	// Wideband packets per frame, default = 32
	packetbuf[28] = prn->wb_packets_per_frame;
	// Envelope PWM_max
	packetbuf[33] = prn->tx[0].epwm_max >> 8; // [15:8]
	packetbuf[34] = prn->tx[0].epwm_max & 0xff; // [7:0]
	//Envelope PWM_min
	packetbuf[35] = prn->tx[0].epwm_min >> 8; // [15:8]
	packetbuf[36] = prn->tx[0].epwm_min & 0xff; // [7:0]
	// Bits - [0]Time stamp, [1]VITA-49, [2]VNA mode [3] freq or phase word
	packetbuf[37] = 0x08; // send phase word
	// Watchdog Timer default = 0 disabled
	packetbuf[38] = prn->wdt;
	// Bits - Atlas bus configuration
	packetbuf[56] = 0x00;
	// Bits - 10MHz ref source
	packetbuf[57] = 0x00;
	// Bits - PA, Apollo, Mercury, Clock source
	packetbuf[58] = (!prn->tx[0].pa) & 0x01;
	// Bits - Alex(n) enable, 1 = enable, 0 = disable
	packetbuf[59] = prbpfilter->enable | prbpfilter2->enable;
	// sendto port 1024
	if (listenSock != INVALID_SOCKET &&
		RadioProtocol == ETH)
		sendPacket(listenSock, packetbuf, sizeof(packetbuf), RemotePort);	// MI0BOT: Now selectable port
}

void CmdHighPriority() { // port 1027

	char packetbuf[BUFLEN];
	memset(packetbuf, 0, sizeof(packetbuf)); // fill the frame with 0x00

	// High Priority Command & Control packet
	// Byte 0-3 Sequence #
	// Byte 4 Run, PTT(n)
	// bit [0] - Run 1 = true, 0 = false
	// bit [1] - PTT[0] 1 = active, 0 = inactive
	// bit [7] - PureSignal
	packetbuf[4] = (prn->tx[0].ptt_out << 1 |
		prn->run) & 0xff;

	// Byte 5 CWX0
	// Bit [0]  - CWX 1 = active, 0 = inactive
	// Bit [1]  - Dot 1 = active, 0 = inactive
	// Bit [2]  - Dash 1 = active, 0 = inactive
	packetbuf[5] = (prn->tx[0].dash << 2 |
		prn->tx[0].dot << 1 |
		prn->tx[0].cwx) & 0x7;

	// RX0 (Hz)/Mercury0 - Rx0 Frequency
	packetbuf[9] = prn->tx[0].ptt_out && prn->puresignal_run ? (prn->tx[0].frequency >> 24) & 0xff : (prn->rx[0].frequency >> 24) & 0xff;
	packetbuf[10] = prn->tx[0].ptt_out && prn->puresignal_run ? (prn->tx[0].frequency >> 16) & 0xff : (prn->rx[0].frequency >> 16) & 0xff;
	packetbuf[11] = prn->tx[0].ptt_out && prn->puresignal_run ? (prn->tx[0].frequency >> 8) & 0xff : (prn->rx[0].frequency >> 8) & 0xff;
	packetbuf[12] = prn->tx[0].ptt_out && prn->puresignal_run ? prn->tx[0].frequency & 0xff : prn->rx[0].frequency & 0xff;

	// RX1 (Hz)/Mercury0 - Rx1_Frequency
	packetbuf[13] = prn->tx[0].ptt_out && prn->puresignal_run ? (prn->tx[0].frequency >> 24) & 0xff : (prn->rx[1].frequency >> 24) & 0xff;
	packetbuf[14] = prn->tx[0].ptt_out && prn->puresignal_run ? (prn->tx[0].frequency >> 16) & 0xff : (prn->rx[1].frequency >> 16) & 0xff;
	packetbuf[15] = prn->tx[0].ptt_out && prn->puresignal_run ? (prn->tx[0].frequency >> 8) & 0xff : (prn->rx[1].frequency >> 8) & 0xff;
	packetbuf[16] = prn->tx[0].ptt_out && prn->puresignal_run ? prn->tx[0].frequency & 0xff : prn->rx[1].frequency & 0xff;

	// RX2 (Hz)/Mercury0 - Rx2 Frequency
	packetbuf[17] = (prn->rx[2].frequency >> 24) & 0xff;
	packetbuf[18] = (prn->rx[2].frequency >> 16) & 0xff;
	packetbuf[19] = (prn->rx[2].frequency >> 8) & 0xff;
	packetbuf[20] = prn->rx[2].frequency & 0xff;

	// RX3 (Hz)/Mercury1 - Rx0_Frequency
	packetbuf[21] = (prn->rx[3].frequency >> 24) & 0xff;
	packetbuf[22] = (prn->rx[3].frequency >> 16) & 0xff;
	packetbuf[23] = (prn->rx[3].frequency >> 8) & 0xff;
	packetbuf[24] = prn->rx[3].frequency & 0xff;

	// RX4 (Hz)/Mercury0 - Rx0 Frequency
	packetbuf[25] = (prn->rx[4].frequency >> 24) & 0xff;
	packetbuf[26] = (prn->rx[4].frequency >> 16) & 0xff;
	packetbuf[27] = (prn->rx[4].frequency >> 8) & 0xff;
	packetbuf[28] = prn->rx[4].frequency & 0xff;

	// RX5 (Hz)/Mercury1 - Rx1_Frequency
	packetbuf[29] = (prn->rx[5].frequency >> 24) & 0xff;
	packetbuf[30] = (prn->rx[5].frequency >> 16) & 0xff;
	packetbuf[31] = (prn->rx[5].frequency >> 8) & 0xff;
	packetbuf[32] = prn->rx[5].frequency & 0xff;

	// RX6 (Hz)/Mercury1 - Rx2 Frequency
	packetbuf[33] = (prn->rx[6].frequency >> 24) & 0xff;
	packetbuf[34] = (prn->rx[6].frequency >> 16) & 0xff;
	packetbuf[35] = (prn->rx[6].frequency >> 8) & 0xff;
	packetbuf[36] = prn->rx[6].frequency & 0xff;

	// RX7 (Hz)/Mercury1 - Rx3 Frequency
	packetbuf[37] = (prn->rx[7].frequency >> 24) & 0xff;
	packetbuf[38] = (prn->rx[7].frequency >> 16) & 0xff;
	packetbuf[39] = (prn->rx[7].frequency >> 8) & 0xff;
	packetbuf[40] = prn->rx[7].frequency & 0xff;

	// RX8 (Hz)/Mercury2 - Rx0 Frequency
	packetbuf[41] = (prn->rx[8].frequency >> 24) & 0xff;
	packetbuf[42] = (prn->rx[8].frequency >> 16) & 0xff;
	packetbuf[43] = (prn->rx[8].frequency >> 8) & 0xff;
	packetbuf[44] = prn->rx[8].frequency & 0xff;

	// RX9 (Hz)/Mercury2 - Rx1_Frequency
	packetbuf[45] = (prn->rx[9].frequency >> 24) & 0xff;
	packetbuf[46] = (prn->rx[9].frequency >> 16) & 0xff;
	packetbuf[47] = (prn->rx[9].frequency >> 8) & 0xff;
	packetbuf[48] = prn->rx[9].frequency & 0xff;

	// RX10 (Hz)/Mercury2 - Rx2 Frequency
	packetbuf[49] = (prn->rx[10].frequency >> 24) & 0xff;
	packetbuf[50] = (prn->rx[10].frequency >> 16) & 0xff;
	packetbuf[51] = (prn->rx[10].frequency >> 8) & 0xff;
	packetbuf[52] = prn->rx[10].frequency & 0xff;

	// RX11 (Hz)/Mercury2 - Rx3 Frequency
	packetbuf[53] = (prn->rx[11].frequency >> 24) & 0xff;
	packetbuf[54] = (prn->rx[11].frequency >> 16) & 0xff;
	packetbuf[55] = (prn->rx[11].frequency >> 8) & 0xff;
	packetbuf[56] = prn->rx[11].frequency & 0xff;

	// TX0 Frequency
	packetbuf[329] = (prn->tx[0].frequency >> 24) & 0xff;
	packetbuf[330] = (prn->tx[0].frequency >> 16) & 0xff;
	packetbuf[331] = (prn->tx[0].frequency >> 8) & 0xff;
	packetbuf[332] = prn->tx[0].frequency & 0xff;

	// TX0 drive level
	packetbuf[345] = prn->tx[0].drive_level;

	// CAT over TCP/IP port
	packetbuf[1398] = (prn->CATPort >> 8) & 0xff;		// top 16 bits
	packetbuf[1399] = (prn->CATPort) & 0xff;			// bittom 16 bits

	// Enable transverter T/R relay 8   Mute Audio Amp bit 1 from J16 pin 9 IO4---DLE
	//packetbuf[1400] = xvtr_enable | ((!(prn->user_dig_in & 0x01)) << 1 | atu_tune << 2);
	packetbuf[1400] = xvtr_enable | (!audioamp_enable) << 1 | atu_tune << 2; //MW0LGE_22b  // user_dig_in was gettin overwritten by 1025 packet read

	// Open Collector Outputs
	packetbuf[1401] = (prn->oc_output << 1) & 0xfe;

	// User Outputs DB9 pins 1-4
	packetbuf[1402] = prn->user_dig_out & 0xf;

	// Mercury Attenuator (20dB)
	packetbuf[1403] = prn->rx[1].preamp << 1 |
		prn->rx[0].preamp;

	// Alex1 data 
	packetbuf[1428] = (prbpfilter2->bpfilter >> 24) & 0xff; // [31:24] TXANT
	packetbuf[1429] = (prbpfilter2->bpfilter >> 16) & 0xff; // [23:16] TXANT
	packetbuf[1430] = (prbpfilter2->bpfilter >> 8) & 0xff; //RX1
	packetbuf[1431] = prbpfilter2->bpfilter & 0xff; //RX1

	// Alex0 data
	packetbuf[1432] = (prbpfilter->bpfilter >> 24) & 0xff; // [31:24] TX
	packetbuf[1433] = (prbpfilter->bpfilter >> 16) & 0xff; // [23:16] TX
	packetbuf[1434] = (prbpfilter->bpfilter >> 8) & 0xff; // [15:8] RX0
	packetbuf[1435] = prbpfilter->bpfilter & 0xff; // [7:0] RX0

	// Step Attenuator 2
	//packetbuf[1441] = prn->adc[2].rx_step_attn;
	// Step Attenuator 1
	packetbuf[1442] = prn->adc[1].rx_step_attn;
	// Step Attenuator 0
	packetbuf[1443] = prn->adc[0].rx_step_attn;

	// sendto port 1027
	if (listenSock != INVALID_SOCKET &&
		RadioProtocol == ETH)
		sendPacket(listenSock, packetbuf, BUFLEN, 1027);
}

PORT
void CmdRx() { // port 1025

	char packetbuf[BUFLEN];
	memset(packetbuf, 0, sizeof(packetbuf)); // fill the frame with 0x00

	// Rx Specific control packet
	// Byte 0-3 Sequence #
	// Byte 4 Number of ADCs
	packetbuf[4] = prn->num_adc;

	// Byte 5 Dither ADC0...7
	// Bit [0]  - ADC0 1 = active, 0 = inactive
	// Bit [1]  - ADC1 1 = active, 0 = inactive
	// Bit [2]  - ADC2 1 = active, 0 = inactive
	packetbuf[5] = (prn->adc[2].dither << 2 |
		prn->adc[1].dither << 1 |
		prn->adc[0].dither) & 0x7;

	// Byte 6 Random ADC0...7 
	// Bit [0]  - ADC0 1 = active, 0 = inactive
	// Bit [1]  - ADC1 1 = active, 0 = inactive
	// Bit [2]  - ADC2 1 = active, 0 = inactive
	packetbuf[6] = (prn->adc[2].random << 2 |
		prn->adc[1].random << 1 |
		prn->adc[0].random) & 0x7;

	// Byte 7 Enable Rx0...Rx7
	// Bit [0]  - Rx0 1 = active, 0 = inactive
	// Bit [1]  - Rx1 1 = active, 0 = inactive
	// Bit [2]  - Rx2 1 = active, 0 = inactive
	// Bit [3]  - Rx3 1 = active, 0 = inactive
	packetbuf[7] = (prn->rx[6].enable << 6 |
		prn->rx[5].enable << 5 |
		prn->rx[4].enable << 4 |
		prn->rx[3].enable << 3 |
		prn->rx[2].enable << 2 |
		prn->rx[1].enable << 1 |
		prn->rx[0].enable) & 0xff;

	// Byte 17 ADC Rx0/Mercury0
	packetbuf[17] = prn->rx[0].rx_adc;

	// Bytes 18 & 19 Sampling Rate Rx0
	// [15:8] 48/96/192/384....
	// [7:0]
	packetbuf[18] = (prn->rx[0].sampling_rate >> 8) & 0xff;
	packetbuf[19] = prn->rx[0].sampling_rate & 0xff;

	// Byte 22 Sample Size Rx0
	packetbuf[22] = prn->rx[0].bit_depth;

	// Byte 23 ADC Rx1/Mercury0
	packetbuf[23] = prn->rx[1].rx_adc;

	// Bytes 24 & 25 Sampling Rate Rx0
	// [15:8] 48/96/192/384....
	// [7:0]
	packetbuf[24] = (prn->rx[1].sampling_rate >> 8) & 0xff;
	packetbuf[25] = prn->rx[1].sampling_rate & 0xff;

	// Byte 28 Sample Size Rx1
	packetbuf[28] = prn->rx[1].bit_depth;

	// Byte 29 ADC Rx2/Mercury0
	packetbuf[29] = prn->rx[2].rx_adc;

	// Bytes 30 & 31 Sampling Rate Rx0
	// [15:8] 48/96/192/384....
	// [7:0]
	packetbuf[30] = (prn->rx[2].sampling_rate >> 8) & 0xff;
	packetbuf[31] = prn->rx[2].sampling_rate & 0xff;

	// Byte 34 Sample Size Rx0
	packetbuf[34] = prn->rx[2].bit_depth;

	// Byte 35 ADC Rx3/Mercury0
	packetbuf[35] = prn->rx[3].rx_adc;

	// Bytes 36 & 37 Sampling Rate Rx0
	// [15:8] 48/96/192/384....
	// [7:0]
	packetbuf[36] = (prn->rx[3].sampling_rate >> 8) & 0xff;
	packetbuf[37] = prn->rx[3].sampling_rate & 0xff;

	// Byte 40 Sample Size Rx0
	packetbuf[40] = prn->rx[3].bit_depth;

	// Rx4
	packetbuf[41] = prn->rx[4].rx_adc;
	packetbuf[42] = (prn->rx[4].sampling_rate >> 8) & 0xff;
	packetbuf[43] = prn->rx[4].sampling_rate & 0xff;
	packetbuf[46] = prn->rx[4].bit_depth;

	// Rx5
	packetbuf[47] = prn->rx[5].rx_adc;
	packetbuf[48] = (prn->rx[5].sampling_rate >> 8) & 0xff;
	packetbuf[49] = prn->rx[5].sampling_rate & 0xff;
	packetbuf[52] = prn->rx[5].bit_depth;

	// Rx6
	packetbuf[53] = prn->rx[6].rx_adc;
	packetbuf[54] = (prn->rx[6].sampling_rate >> 8) & 0xff;
	packetbuf[55] = prn->rx[6].sampling_rate & 0xff;
	packetbuf[58] = prn->rx[6].bit_depth;

	// Byte 1363 SyncRx0 [Rx0+Rx(n)]
	packetbuf[1363] = prn->rx[0].sync;
	// packetbuff[1443] = 1;	// FOR TESTING MUX MODE

	// sendto port 1025
	if (listenSock != INVALID_SOCKET &&
		RadioProtocol == ETH)
		sendPacket(listenSock, packetbuf, BUFLEN, 1025);
}

void CmdTx() { // port 1026
	char packetbuf[60];
	memset(packetbuf, 0, sizeof(packetbuf)); // fill the frame with 0x00

	// Tx Specific control packet
	// Byte 0-3 Sequence #
	// Byte 4 Number of DACs
	packetbuf[4] = prn->num_dac;

	// Byte 5 Mode, CW, Reverse, Key Mode. 0 = off, 1 = on.
	// Bit [0]  - EER 1 = active, 0 = inactive
	// Bit [1]  - CW 1 = active, 0 = inactive
	// Bit [2]  - Reverse CW Keys 1 = active, 0 = inactive
	// Bit [3]  - Iambic
	// Bit [4]  - Sidetone
	// Bit [5]  - Mode B
	// Bit [6]  - Strict Character Spacing
	// Bit [7]  - Break-In
	packetbuf[5] = prn->cw.mode_control;

	// Byte 6 Sidetone Level
	packetbuf[6] = prn->cw.sidetone_level;
	// Byte 7 Sidetone Frequency (Hz) [15:8]
	packetbuf[7] = (prn->cw.sidetone_freq >> 8) & 0xff;
	// Byte 8 Sidetone Frequency (Hz) [7:0]
	packetbuf[8] = prn->cw.sidetone_freq & 0xff;
	// Byte 9 Keyer Speed
	packetbuf[9] = prn->cw.keyer_speed;
	// Byte 10 Keyer Weight
	packetbuf[10] = prn->cw.keyer_weight;
	// Byte 11 Hang Delay [15:8]
	packetbuf[11] = (prn->cw.hang_delay >> 8) & 0xff;
	// Byte 12 Hang Delay [7:0]
	packetbuf[12] = prn->cw.hang_delay & 0xff;
	// Byte 13 RF Delay
	packetbuf[13] = prn->cw.rf_delay;
	// Byte 14 Tx0 Sampling Rate [15:8]
	packetbuf[14] = (prn->tx[0].sampling_rate >> 8) & 0xff;
	// Byte 15 Tx0 Sampling Rate [7:0]
	packetbuf[15] = prn->tx[0].sampling_rate & 0xff;
	// Byte 17 CW Edge Length (ms)
	packetbuf[17] = prn->cw.edge_length & 0xff;
	// Byte 26 Tx0 Phase Shift (0 - 359 degrees) [15:8]
	packetbuf[26] = (prn->tx[0].phase_shift >> 8) & 0xff;
	// Byte 27 Tx0 Phase Shift [7:0]
	packetbuf[27] = prn->tx[0].phase_shift & 0xff;
	// Byte 50 Tx0 Line In, Mic Boost, Orion Mic. 0 = off, 1 = on.
	// Bit [0]  - Line In
	// Bit [1]  - Mic Boost
	// Bit [2]  - 0 = Orion mic PTT enabled, 1 = Orion mic PTT disabled
	// Bit [3]  - 0 = Orion mic ptt to ring and mic/mic bias to tip, 1 = Orion mic ptt to tip and mic/mic bias to ring
	// Bit [4]  - 0 = disables Orion mic bias, 1 = enables Orion microphone bias
	// bit [5]  - 0 = disables balanced input, 1 = select balabced input (Saturn)
	packetbuf[50] = prn->mic.mic_control;
	// Byte 51 Line in gain
	packetbuf[51] = prn->mic.line_in_gain;
	// Byte 57 Step Attenuator ADC2 on Tx (0 - 31 dB)
	packetbuf[57] = prn->adc[2].tx_step_attn;
	// Byte 58 Step Attenuator ADC1 on Tx (0 - 31 dB)
	packetbuf[58] = prn->adc[1].tx_step_attn;
	// Byte 59 Step Attenuator ADC0 on Tx (0 - 31 dB)
	packetbuf[59] = prn->adc[0].tx_step_attn;

	// sendto port 1026
	if (listenSock != INVALID_SOCKET &&
		RadioProtocol == ETH)
		sendPacket(listenSock, packetbuf, sizeof(packetbuf), 1026);
}

void sendOutbound(int id, double* out)
{
	int i;
	short temp;
	int itemp;

	//// convert from complex to byte
	//// big-endian

	if (RadioProtocol == ETH)
	{
		EnterCriticalSection(&prn->udpOUT);
		if (id == 1)
		{
			// WriteAudio (15.0, 192000, prn->tx[0].spp, out, 3);
			for (i = 0; i < 2 * prn->tx[0].spp; i++)
			{
				itemp = out[i] >= 0.0 ? (int)floor(out[i] * 8388607.0 + 0.5) :
					(int)ceil(out[i] * 8388607.0 - 0.5);
				prn->OutBufp[i * 3] = (char)((itemp >> 16) & 0xff);
				prn->OutBufp[i * 3 + 1] = (char)((itemp >> 8) & 0xff);
				prn->OutBufp[i * 3 + 2] = (char)(itemp & 0xff);
			}
			WriteUDPFrame(id, prn->OutBufp, prn->tx[0].spp * 6);
		}
		else
		{
			if (prn->lr_audio_swap)
			{
				double swap;
				for (i = 0; i < 2 * prn->audio[0].spp; i += 2)
				{
					swap       = out[i + 0];
					out[i + 0] = out[i + 1];
					out[i + 1] = swap;
				}
			}
			for (i = 0; i < 2 * prn->audio[0].spp; i++)
			{
				temp = out[i] >= 0.0 ? (short)floor(out[i] * 32767.0 + 0.5) :
					(short)ceil(out[i] * 32767.0 - 0.5);
				prn->OutBufp[i * 2] = (char)((temp >> 8) & 0xff);
				prn->OutBufp[i * 2 + 1] = (char)(temp & 0xff);
			}
			WriteUDPFrame(id, prn->OutBufp, prn->audio[0].spp * 4);
		}
		LeaveCriticalSection(&prn->udpOUT);
	}
	else	//  PROTOCOL_1
	{
		// note:  packet won't be sent until BOTH 'hsendIQSem' and 'hsendLRSem' are released
		// note:  'hobbuffsRun[0]' and 'hobbuffsRun[1]' are released AFTER we write the packet and can therefore
		//        refill 'the buffers'outIQbufp' and 'outLRbufp'
		// note:  there are 63 I-Q samples and 63 L-R samples per P1 frame => 126 of each per packet
		if (pcm->xmtr[0].peer->run)	// if eer/etr is running
		{
			if (id == 1)	// TX I-Q data arriving
			{
				static int ptr = 0;
				memcpy((void *)(prn->outIQbufp + 720), out, sizeof(complex) * 126);
				// de-interleave the two sample streams
				for (int n = 0, i = ptr, j = 256 + ptr, k = 720; n < 63; n++, i+=2, j+=2, k+=4)
				{
					// final location of I-Q data
					prn->outIQbufp[i + 0] = prn->outIQbufp[k + 0];
					prn->outIQbufp[i + 1] = prn->outIQbufp[k + 1];
					// L-R data will be copied from here if needed
					prn->outIQbufp[j + 0] = prn->outIQbufp[k + 2];
					prn->outIQbufp[j + 1] = prn->outIQbufp[k + 3];
				}
				ptr = (ptr + 126) % 252;
				if (ptr == 0)
				{
					// release semaphore, indicating IQ data received and complete.  
					ReleaseSemaphore(prn->hsendIQSem, 1, 0);
					// wait to refill 'outIQbuffp' until the packet is sent
					WaitForSingleObject(prn->hobbuffsRun[0], INFINITE);
				}
			}
			else			// RX L-R data arriving
			{
				memcpy(prn->outLRbufp, out, sizeof(complex) * 126);
				// release semaphore indicating L-R data ready
				ReleaseSemaphore(prn->hsendLRSem, 1, 0);
				// wait to refill 'outLRbufp' until the packet is sent
				WaitForSingleObject(prn->hobbuffsRun[1], INFINITE);
			}
		}
		else					// eer/etr is NOT running
		{
			if (id == 1)
			{
				memcpy(prn->outIQbufp, out, sizeof(complex) * 126);
				ReleaseSemaphore(prn->hsendIQSem, 1, 0);
				WaitForSingleObject(prn->hobbuffsRun[0], INFINITE);
			}
			else
			{
				memcpy(prn->outLRbufp, out, sizeof(complex) * 126);
				ReleaseSemaphore(prn->hsendLRSem, 1, 0);
				WaitForSingleObject(prn->hobbuffsRun[1], INFINITE);
			}
		}
	}
}

void WriteUDPFrame(int id, char* bufp, int buflen) {

	char framebuf[BUFLEN];
	unsigned char* p;

	switch (id)
	{
	case 0: // receiver audio
		p = (unsigned char*)&prn->rx[0].rx_out_seq_no;
		framebuf[0] = p[3];
		framebuf[1] = p[2];
		framebuf[2] = p[1];
		framebuf[3] = p[0];
		++prn->rx[0].rx_out_seq_no;
		memcpy(framebuf + 4, bufp, buflen);
		if (listenSock != INVALID_SOCKET &&
			RadioProtocol == ETH)
			sendPacket(listenSock, framebuf, buflen + 4, 1028);
		//send pcm packet
		//sendPacket(listenSock, framebuf+4, buflen, 1050);
		break;
	case 1: // mic data
		mic_samples_buf++;
		p = (unsigned char*)&prn->tx[0].mic_out_seq_no;
		framebuf[0] = p[3];
		framebuf[1] = p[2];
		framebuf[2] = p[1];
		framebuf[3] = p[0];
		++prn->tx[0].mic_out_seq_no;
		memcpy(framebuf + 4, bufp, buflen);
		if (listenSock != INVALID_SOCKET &&
			RadioProtocol == ETH)
			sendPacket(listenSock, framebuf, buflen + 4, 1029);
		//send pcm packet
		//sendPacket(listenSock, framebuf + 4, buflen, 1051);
		break;
	}
}

int sendPacket(SOCKET sock, char* data, int length, int port)
{
	int ret;
	struct sockaddr_in dest = { 0 };

	EnterCriticalSection(&prn->sndpkt);
	dest.sin_port = htons((u_short)port);
	dest.sin_family = AF_INET;
	dest.sin_addr.s_addr = MetisAddr;
	ret = sendto(sock, data, length, 0, (SOCKADDR*)&dest, sizeof(dest));
	LeaveCriticalSection(&prn->sndpkt);

	if (ret == SOCKET_ERROR)
	{
		wprintf(L"sendto failed with error:%d\n", WSAGetLastError());
	}

	return ret;
}

void KeepAliveLoop(void)
{
	prn->liDueTime.QuadPart = -10000000LL;

	prn->hTimer = CreateWaitableTimer(NULL, FALSE, NULL);
	if (prn->hTimer == NULL)
	{
		printf("CreateWaitableTimer failed (%d)\n", GetLastError());
	}
	else
	{
		if (!SetWaitableTimer(prn->hTimer, &prn->liDueTime, 500, NULL, NULL, 0))
		{
			printf("SetWaitableTimer failed (%d)\n", GetLastError());
		}

		while (io_keep_running)
		{
			WaitForSingleObject(prn->hTimer, INFINITE);
			if (prn->run && prn->wdt) CmdGeneral();
		}

		CancelWaitableTimer(prn->hTimer);
		CloseHandle(prn->hTimer);
	}
}

static const double const_1_div_8388608_ = 1.0 / 8388608.0;

// stops and kill's the IOThread
int IOThreadStop() {
	if (io_keep_running == 0) {  // not running
		return 1;
	}
	io_keep_running = 0;  // flag to stop

	if (prn->discovery.BoardType == HermesLite)
	{
		// MI0BOT: Thread locking up, so timeout added.
		if (WAIT_TIMEOUT == WaitForSingleObject(prn->hReadThreadMain, 1000))
		{
			// Thread has stopped, so let everybody know
			IOThreadRunning = 0;
		}
	}
	else
	{
		WaitForSingleObject(prn->hReadThreadMain, INFINITE);
	}

	CloseHandle(prn->hReadThreadMain);
	CloseHandle(prn->hReadThreadInitSem);
	//CloseHandle(prn->hWriteThreadMain); //[2.10.3.7]MW0LGE moved below, this only gets created with USB, crash if connected to a p2, then moved to a p1 etc
	//CloseHandle(prn->hWriteThreadInitSem); //[2.10.3.7]MW0LGE moved below, this only gets created with USB

	// Protocol 1 handles
	if (RadioProtocol == USB)
	{
		CloseHandle(prn->hWriteThreadMain);
		CloseHandle(prn->hWriteThreadInitSem);

		CloseHandle(prn->hsendIQSem);
		CloseHandle(prn->hsendLRSem);
		CloseHandle(prn->hobbuffsRun[0]);
		CloseHandle(prn->hobbuffsRun[1]);
	}

	return EXIT_SUCCESS;
}

DWORD WINAPI ReadThreadMain(LPVOID n) {
	DWORD taskIndex = 0;
	HANDLE hTask = AvSetMmThreadCharacteristics(TEXT("Pro Audio"), &taskIndex);
	if (hTask != 0) AvSetMmThreadPriority(hTask, 2);
	else SetThreadPriority(GetCurrentThread(), THREAD_PRIORITY_TIME_CRITICAL);

	io_keep_running = 1;
	IOThreadRunning = 1;
	ReleaseSemaphore(prn->hReadThreadInitSem, 1, NULL);
	ReadThreadMainLoop();
	IOThreadRunning = 0;

	return 0;
}

DWORD WINAPI KeepAliveMain(LPVOID n) {
	KeepAliveLoop();

	return 0;
}
