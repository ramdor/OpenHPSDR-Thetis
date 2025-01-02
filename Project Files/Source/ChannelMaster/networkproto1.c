/*
 * networkprot1.c
 * Copyright (C) 2020 Doug Wigley (W5WC)
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
#include "network.h"
#include "pro.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int SeqError = 0;
int out_control_idx = 0;
int MetisLastRecvSeq = 0;
int PreviousTXBit = 0;							// used to detect TX/RX change
unsigned int MetisOutBoundSeqNum;
PRO prop;

int SendStartToMetis(void) {
	int i;
	int starting_seq;
	prop = create_pro(1, 1024, 16, 5);
	struct outdgram {
		unsigned char packetbuf[64];
	} outpacket;

	struct indgram {
		unsigned char fbuf[2000];
	} inpacket;

	memset(outpacket.packetbuf, 0, sizeof(outpacket));

	outpacket.packetbuf[0] = 0xef;
	outpacket.packetbuf[1] = 0xfe;
	outpacket.packetbuf[2] = 0x04;
	outpacket.packetbuf[3] = 0x01;

	starting_seq = MetisLastRecvSeq;
	for (i = 0; i < 5; i++) {
		ForceCandCFrame(1);
		sendPacket(listenSock, (char*)&outpacket, sizeof(outpacket), RemotePort);	// MI0BOT: Remote port configurable 
		MetisReadDirect((unsigned char*)&inpacket);
		if (MetisLastRecvSeq != starting_seq) {
			break;
		}

		Sleep(10);
	}

	if (MetisLastRecvSeq == starting_seq) {
		return -1;
	}

	return 0;
}

PORT
int SendStopToMetis() {
	int starting_seq;
	struct outdgram {
		unsigned char packetbuf[64];
	} outpacket;

	int i;

	memset(outpacket.packetbuf, 0, sizeof(outpacket));

	outpacket.packetbuf[0] = 0xef;
	outpacket.packetbuf[1] = 0xfe;
	outpacket.packetbuf[2] = 0x04;
	outpacket.packetbuf[3] = 0x00;

	starting_seq = MetisLastRecvSeq;
	for (i = 0; i < 5; i++) {
		sendPacket(listenSock, (char*)&outpacket, sizeof(outpacket), RemotePort);	// MI0BOT: Remote port configurable 
		Sleep(10);
		if (MetisLastRecvSeq == starting_seq) {
			break;
		}
	}
	if (MetisLastRecvSeq != starting_seq) {
		return -1;
	}
	destroy_pro (prop);
	prop = NULL; // MW0LGE_21g a change to ForceReset in setup.cs will cause calls to SendStopToMetis
				 // even if it potentially does not have a matching StartMetis. Consequently
				 // destroy_pro would fail. Destroy_pro does handle NULL state, so let us
				 // just set prop to null here
	return 0;
}

void ForceCandCFrames(int count, int c0, int vfofreq) {
	unsigned char buf[1024];
	int	i;
	memset(buf, 0, sizeof(buf));

	buf[0] = 0x7f;
	buf[1] = 0x7f;
	buf[2] = 0x7f;
	buf[3] = 0;						    /* c0 */
	buf[4] = (SampleRateIn2Bits & 3);   /* c1 */
	buf[5] = 0;							/* c2 */
	buf[6] = 0;                         /* c3 */
	buf[7] = (nddc - 1) << 3; 

	buf[512] = 0x7f;
	buf[513] = 0x7f;
	buf[514] = 0x7f;
	buf[515] = c0; 						/* c0 */
	buf[516] = (vfofreq >> 24) & 0xff;	/* byte	0 of freq -	c1 */
	buf[517] = (vfofreq >> 16) & 0xff;	/* byte	1 of freq -	c2 */
	buf[518] = (vfofreq >> 8) & 0xff;	/* byte	2 of freq -	c3 */
	buf[519] = vfofreq & 0xff;			/* byte	3 of freq -	c4 */

	for (i = 0; i < count; i++) {
		MetisWriteFrame(2, (char*)buf);
	}
}

void ForceCandCFrame(int count) {
	ForceCandCFrames(count, 2, prn->tx[0].frequency);
	Sleep(10);
	ForceCandCFrames(count, 4, prn->rx[0].frequency);
	Sleep(10);
}

int MetisReadDirect(unsigned char* bufp) {
	struct indgram {
		unsigned char readbuf[1074];
	} inpacket;

	struct sockaddr_in fromaddr;
	int fromlen;
	int rc;
	unsigned int endpoint;
	unsigned int seqnum;
	unsigned char* seqbytep = (unsigned char*)&seqnum;

	EnterCriticalSection(&prn->rcvpktp1);
	fromlen = sizeof(fromaddr);
	rc = recvfrom(listenSock, (char*)&inpacket, sizeof(inpacket), 0, (struct sockaddr*)&fromaddr, &fromlen);
	if (rc == -1) //SOCKET_ERROR
	{
		errno = WSAGetLastError();
		if (errno == WSAEWOULDBLOCK || errno == WSAEMSGSIZE)
		{
			printf("Error code %d: recvfrom() : %s\n", errno, strerror(errno));
			fflush(stdout);
		}
		LeaveCriticalSection(&prn->rcvpktp1);
		return rc;
	}

	/* check frame is from who we expect */
	if (rc == 1032) {   /* looks like a data frame */
		if ((inpacket.readbuf[0] == 0xef) && (inpacket.readbuf[1] == 0xfe) && (inpacket.readbuf[2] == 0x01)) {
			endpoint = (unsigned int)inpacket.readbuf[3];
			seqbytep[3] = inpacket.readbuf[4];
			seqbytep[2] = inpacket.readbuf[5];
			seqbytep[1] = inpacket.readbuf[6];
			seqbytep[0] = inpacket.readbuf[7];

			if (endpoint == 6) {
				if ((inpacket.readbuf[8] == 0x7f) && (inpacket.readbuf[9] == 0x7f) && (inpacket.readbuf[10] == 0x7f)) {
					HaveSync = 1;
				}
				else {
					HaveSync = 0;
					printf("MRD: sync error on frame %d\n", seqnum);
				}
				memcpy(bufp, inpacket.readbuf + 8, 1024);
				xpro(prop, seqnum, bufp); // resequence out of order packets
				if (seqnum != (1 + MetisLastRecvSeq)) {
					SeqError += 1;
				}
				MetisLastRecvSeq = seqnum;

				LeaveCriticalSection(&prn->rcvpktp1);

				return 1024;
			}
			else {
				printf("MRD: ignoring data for ep %d\n", endpoint);
			}
		}
		else {
			printf("MRD: ignoring right sized frame bad header! %d\n", rc);
		}
	}
	else {
		printf("MRD: ignoring short frame size=%d\n", rc);
	}

	LeaveCriticalSection(&prn->rcvpktp1);
	return 0;
}

int MetisWriteFrame(int endpoint, char* bufp) {
	int result = 0;
	struct outdgram {
		unsigned char framebuf[1032];
	} outpacket;
	unsigned char* p = (unsigned char*)&MetisOutBoundSeqNum;
	
	outpacket.framebuf[0] = 0xef;
	outpacket.framebuf[1] = 0xfe;
	outpacket.framebuf[2] = 01;
	outpacket.framebuf[3] = endpoint;
	outpacket.framebuf[4] = p[3];
	outpacket.framebuf[5] = p[2];
	outpacket.framebuf[6] = p[1];
	outpacket.framebuf[7] = p[0];
	++MetisOutBoundSeqNum;
	memcpy(outpacket.framebuf + 8, bufp, 1024);

	result = sendPacket(listenSock, (char*)&outpacket, 1024 + 8, RemotePort);	// MI0BOT: Remote port configurable 
	result -= 8;
	return result;
}

// this is the main thread that reads data
DWORD WINAPI MetisReadThreadMain(LPVOID n) {
	DWORD taskIndex = 0;
	HANDLE hTask = AvSetMmThreadCharacteristics(TEXT("Pro Audio"), &taskIndex);
	if (hTask != 0) AvSetMmThreadPriority(hTask, 2);
	else SetThreadPriority(GetCurrentThread(), THREAD_PRIORITY_HIGHEST);

	io_keep_running = 1;
	IOThreadRunning = 1;

	ReleaseSemaphore(prn->hReadThreadInitSem, 1, NULL);
	printf("MetisReadThread runs...\n"); fflush(stdout);

	if (prn->discovery.BoardType == HermesLite)	// MI0BOT: Different read loop for HL2
		MetisReadThreadMainLoop_HL2();
	else
		MetisReadThreadMainLoop();

	IOThreadRunning = 0;
	printf("MetisReadThread dies...\n"); fflush(stdout);

	return 0;
}

void twist (int nsamples, int stream0, int stream1, int port)
{
	int i, j;
	for (i = 0, j = 0; i < 2 * nsamples; i += 2, j += 4)
	{
		prn->RxReadBufp[j + 0] = prn->RxBuff[stream0][i + 0];
		prn->RxReadBufp[j + 1] = prn->RxBuff[stream0][i + 1];
		prn->RxReadBufp[j + 2] = prn->RxBuff[stream1][i + 0];
		prn->RxReadBufp[j + 3] = prn->RxBuff[stream1][i + 1];
	}
	xrouter(0, 0, port, 2 * nsamples, prn->RxReadBufp);
}

void MetisReadThreadMainLoop(void)
{
	mic_decimation_count = 0;
	SeqError = 0;
	// allocate buffers for I/O
	FPGAReadBufp = (unsigned char*)calloc(1024, sizeof(unsigned char));
	FPGAWriteBufp = (char*)calloc(1024, sizeof(char));

	ForceCandCFrame(3); // send 3 C&C frames
	printf("iot: main loop starting\n"); fflush(stdout);

	prn->hDataEvent = WSACreateEvent();
	WSAEventSelect(listenSock, prn->hDataEvent, FD_READ);
	PrintTimeHack();
	printf("- MetisReadThreadMainLoop()\n");
	fflush(stdout);

	while (io_keep_running != 0)
	{
		//MW0LGE_21g WSAWaitForMultipleEvents(1, &prn->hDataEvent, FALSE, WSA_INFINITE, FALSE);
		//added similar timout code from ReadThreadMainLoop
		DWORD retVal = WSAWaitForMultipleEvents(1, &prn->hDataEvent, FALSE, prn->wdt ? 3000 : WSA_INFINITE, FALSE);
		if ((retVal == WSA_WAIT_FAILED) || (retVal == WSA_WAIT_TIMEOUT))
		{
			HaveSync = 0; //send console LOS		
			destroy_pro(prop);
			prop = NULL; // this needed bacause of a change to ForceReset in setup.cs
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

				MetisReadDirect(FPGAReadBufp);

				{
					int frame, cb, isamp;
					int isample, iddc, spr;
					unsigned char* bptr;
					int mic_sample_count;
					for (frame = 0; frame < 2; frame++)
					{
						bptr = FPGAReadBufp + 512 * frame;
						if ((bptr[0] == 0x7f) && (bptr[1] == 0x7f) && (bptr[2] == 0x7f))
						{
							for (cb = 0; cb < 5; cb++)
								ControlBytesIn[cb] = bptr[cb + 3];

							prn->ptt_in = ControlBytesIn[0] & 0x1;
							prn->dash_in = (ControlBytesIn[0] << 1) & 0x1;
							prn->dot_in = (ControlBytesIn[0] << 2) & 0x1;
							switch (ControlBytesIn[0] & 0xf8)
							{
							case 0x00: // C0 0000 0000
								prn->adc[0].adc_overload = ControlBytesIn[1] & 0x01;
								prn->user_dig_in = ((ControlBytesIn[1] >> 1) & 0xf);
								break;
							case 0x08: // C0 0000 1xxx
								prn->tx[0].exciter_power = ((ControlBytesIn[1] << 8) & 0xff00) | (((int)(ControlBytesIn[2])) & 0xff); // (AIN5) drive power
								prn->tx[0].fwd_power = ((ControlBytesIn[3] << 8) & 0xff00) | (((int)(ControlBytesIn[4])) & 0xff); // (AIN1) PA coupler
								PeakFwdPower((float)(prn->tx[0].fwd_power));
								break;
							case 0x10: // C0 0001 0xxx
								prn->tx[0].rev_power = ((ControlBytesIn[1] << 8) & 0xff00) | (((int)(ControlBytesIn[2])) & 0xff); // (AIN2) PA reverse power
								PeakRevPower((float)(prn->tx[0].rev_power));
								prn->user_adc0 = ((ControlBytesIn[3] << 8) & 0xff00) | (((int)(ControlBytesIn[4])) & 0xff); // AIN3 MKII PA Volts
								break;
							case 0x18: // C0 0001 1xxx
								prn->user_adc1 = ((ControlBytesIn[1] << 8) & 0xff00) | (((int)(ControlBytesIn[2])) & 0xff); // AIN4 MKII PA Amps						
								prn->supply_volts = ((ControlBytesIn[3] << 8) & 0xff00) | (((int)(ControlBytesIn[4])) & 0xff); // AIN6 Hermes Volts                                                              
								break;
							case 0x20: // C0 0010 0xxx
								prn->adc[0].adc_overload = ControlBytesIn[1] & 1;
								prn->adc[1].adc_overload = (ControlBytesIn[2] & 1) << 1;
								prn->adc[2].adc_overload = (ControlBytesIn[3] & 1) << 2;
								break;
							}
							spr = 504 / (6 * nddc + 2);											// samples per ddc
							for (iddc = 0; iddc < nddc; iddc++)									// 'nddc' is the number of DDCs running
							{
								for (isample = 0; isample < spr; isample++)
								{
									int k = 8 + isample * (6 * nddc + 2) + iddc * 6;
									prn->RxBuff[iddc][2 * isample + 0] = const_1_div_2147483648_ *
										(double)(bptr[k + 0] << 24 |
											bptr[k + 1] << 16 |
											bptr[k + 2] << 8);
									prn->RxBuff[iddc][2 * isample + 1] = const_1_div_2147483648_ *
										(double)(bptr[k + 3] << 24 |
											bptr[k + 4] << 16 |
											bptr[k + 5] << 8);
								}
							}
							// WriteAudio(30.0, 48000, spr, prn->RxBuff[0], 3);
							switch (nddc)
							{
							case 2:
								twist(spr, 0, 1, 1035);
								break;
							case 4:
								xrouter(0, 0, 1035, spr, prn->RxBuff[0]);
								twist(spr, 2, 3, 1036);
								xrouter(0, 0, 1037, spr, prn->RxBuff[1]);
								break;
							case 5:
								twist(spr, 0, 1, 1035);
								twist(spr, 3, 4, 1036);
								xrouter(0, 0, 1037, spr, prn->RxBuff[2]);
								break;
							}
							mic_sample_count = 0;

							for (isamp = 0; isamp < spr; isamp++)							// for each set of samples
							{
								int k = 8 + nddc * 6 + isamp * (2 + nddc * 6);

								mic_decimation_count++;
								if (mic_decimation_count == mic_decimation_factor)
								{
									mic_decimation_count = 0;
									prn->TxReadBufp[2 * mic_sample_count + 0] = const_1_div_2147483648_ *
										(double)(bptr[k + 0] << 24 |
											bptr[k + 1] << 16);
									prn->TxReadBufp[2 * mic_sample_count + 1] = 0.0;

									mic_sample_count++;
								}
							}

							Inbound(inid(1, 0), mic_sample_count, prn->TxReadBufp);
						}
					}
				}
			}
		}
	}
}

void MetisReadThreadMainLoop_HL2(void)
{
	mic_decimation_count = 0;
	SeqError = 0;
	// allocate buffers for I/O
	FPGAReadBufp = (unsigned char*)calloc(1024, sizeof(unsigned char));
	FPGAWriteBufp = (char*)calloc(1024, sizeof(char));

	ForceCandCFrame(3); // send 3 C&C frames
	printf("iot: main loop starting\n"); fflush(stdout);

	prn->hDataEvent = WSACreateEvent();
	WSAEventSelect(listenSock, prn->hDataEvent, FD_READ);
	PrintTimeHack();
	printf("- MetisReadThreadMainLoop()\n");
	fflush(stdout);

	while (io_keep_running != 0)
	{
		//MW0LGE_21g WSAWaitForMultipleEvents(1, &prn->hDataEvent, FALSE, WSA_INFINITE, FALSE);
		//added similar timout code from ReadThreadMainLoop
		DWORD retVal = WSAWaitForMultipleEvents(1, &prn->hDataEvent, FALSE, prn->wdt ? 3000 : WSA_INFINITE, FALSE);
		if ((retVal == WSA_WAIT_FAILED) || (retVal == WSA_WAIT_TIMEOUT))
		{
			HaveSync = 0; //send console LOS		
			destroy_pro(prop);
			prop = NULL; // this needed bacause of a change to ForceReset in setup.cs
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

				MetisReadDirect(FPGAReadBufp);

				{
					int frame, cb, isamp;
					int isample, iddc, spr;
					unsigned char* bptr;
					int mic_sample_count;
					for (frame = 0; frame < 2; frame++)
					{
						bptr = FPGAReadBufp + 512 * frame;
						if ((bptr[0] == 0x7f) && (bptr[1] == 0x7f) && (bptr[2] == 0x7f))
						{
							for (cb = 0; cb < 5; cb++)
								ControlBytesIn[cb] = bptr[cb + 3];

							if (ControlBytesIn[0] & 0x80)
							{
								if (0x3f == prn->i2c.returned_address)
								{
									prn->i2c.ctrl_error = 1;
								}
								else
								{
									prn->i2c.read_data[0] = ControlBytesIn[1];
									prn->i2c.read_data[1] = ControlBytesIn[2];
									prn->i2c.read_data[2] = ControlBytesIn[3];
									prn->i2c.read_data[3] = ControlBytesIn[4];

									prn->i2c.ctrl_read_available = 1;
								}
							}
							else
							{
								prn->ptt_in = ControlBytesIn[0] & 0x1;
								prn->dash_in = (ControlBytesIn[0] << 1) & 0x1;
								prn->dot_in = (ControlBytesIn[0] << 2) & 0x1;
								switch (ControlBytesIn[0] & 0xf8)
								{
								case 0x00: // C0 0000 0000
									prn->adc[0].adc_overload = ControlBytesIn[1] & 0x01;
									prn->user_dig_in = ((ControlBytesIn[1] >> 1) & 0xf);
									break;
								case 0x08: // C0 0000 1xxx
									prn->tx[0].exciter_power = ((ControlBytesIn[1] << 8) & 0xff00) | (((int)(ControlBytesIn[2])) & 0xff); // (AIN5) drive power
									prn->tx[0].fwd_power = ((ControlBytesIn[3] << 8) & 0xff00) | (((int)(ControlBytesIn[4])) & 0xff); // (AIN1) PA coupler
									PeakFwdPower((float)(prn->tx[0].fwd_power));
									break;
								case 0x10: // C0 0001 0xxx
									prn->tx[0].rev_power = ((ControlBytesIn[1] << 8) & 0xff00) | (((int)(ControlBytesIn[2])) & 0xff); // (AIN2) PA reverse power
									PeakRevPower((float)(prn->tx[0].rev_power));
									prn->user_adc0 = ((ControlBytesIn[3] << 8) & 0xff00) | (((int)(ControlBytesIn[4])) & 0xff); // AIN3 MKII PA Volts
									break;
								case 0x18: // C0 0001 1xxx
									prn->user_adc1 = ((ControlBytesIn[1] << 8) & 0xff00) | (((int)(ControlBytesIn[2])) & 0xff); // AIN4 MKII PA Amps						
									prn->supply_volts = ((ControlBytesIn[3] << 8) & 0xff00) | (((int)(ControlBytesIn[4])) & 0xff); // AIN6 Hermes Volts                                                              
									break;
								case 0x20: // C0 0010 0xxx
									prn->adc[0].adc_overload = ControlBytesIn[1] & 1;
									prn->adc[1].adc_overload = (ControlBytesIn[2] & 1) << 1;
									prn->adc[2].adc_overload = (ControlBytesIn[3] & 1) << 2;
									break;
								}
							}

							spr = 504 / (6 * nddc + 2);											// samples per ddc
							for (iddc = 0; iddc < nddc; iddc++)									// 'nddc' is the number of DDCs running
							{
								for (isample = 0; isample < spr; isample++)
								{
									int k = 8 + isample * (6 * nddc + 2) + iddc * 6;
									prn->RxBuff[iddc][2 * isample + 0] = const_1_div_2147483648_ *
										(double)(bptr[k + 0] << 24 |
											bptr[k + 1] << 16 |
											bptr[k + 2] << 8);
									prn->RxBuff[iddc][2 * isample + 1] = const_1_div_2147483648_ *
										(double)(bptr[k + 3] << 24 |
											bptr[k + 4] << 16 |
											bptr[k + 5] << 8);
								}
							}
							// WriteAudio(30.0, 48000, spr, prn->RxBuff[0], 3);
							switch (nddc)
							{
							case 2:
								twist(spr, 0, 1, 1035);
								break;
							case 4:
								xrouter(0, 0, 1035, spr, prn->RxBuff[0]);
								twist(spr, 2, 3, 1036);
								xrouter(0, 0, 1037, spr, prn->RxBuff[1]);
								break;
							case 5:
								twist(spr, 0, 1, 1035);
								twist(spr, 3, 4, 1036);
								xrouter(0, 0, 1037, spr, prn->RxBuff[2]);
								break;
							}
							mic_sample_count = 0;

							for (isamp = 0; isamp < spr; isamp++)							// for each set of samples
							{
								int k = 8 + nddc * 6 + isamp * (2 + nddc * 6);

								mic_decimation_count++;
								if (mic_decimation_count == mic_decimation_factor)
								{
									mic_decimation_count = 0;
									prn->TxReadBufp[2 * mic_sample_count + 0] = const_1_div_2147483648_ *
										(double)(bptr[k + 0] << 24 |
											bptr[k + 1] << 16);
									prn->TxReadBufp[2 * mic_sample_count + 1] = 0.0;

									mic_sample_count++;
								}
							}

							Inbound(inid(1, 0), mic_sample_count, prn->TxReadBufp);
						}
					}
				}
			}
		}
	}
}


void WriteMainLoop(char* bufp)
{
	// now attempt to TX if there is a frame of data to send
	int txframe;
	unsigned char C0 = 0, C1 = 0, C2 = 0, C3 = 0, C4 = 0;
	unsigned char CWMode;
	char* txbptr;
	int ddc_freq;
	// create 2 USB frames
	for (txframe = 0; txframe < 2; txframe++)
	{
		txbptr = FPGAWriteBufp + 512 * txframe;
		txbptr[0] = 0x7f;			// add the 3 sync bytes
		txbptr[1] = 0x7f;
		txbptr[2] = 0x7f;

		// if TX/RX has changed we need to change the DDC0 frequency for Hermes-II; so jump to that C&C next	
		if (XmitBit != PreviousTXBit)
		{
			if (nddc == 2)
				out_control_idx = 2;
			PreviousTXBit = XmitBit;
		}

		// add the 5 control bytes: get  inc TX bit
        // "C0=0" used to be sent often, but will rarely be changed
        // so it is now sent at the same rate as everything else
		C0 = (unsigned char)XmitBit;

		switch (out_control_idx)	// now m=pick the frame of control bytes
		{
		case 0:						// C0=0: general settings
			C1 = (SampleRateIn2Bits & 3);
			C2 = (prn->cw.eer & 1) | ((prn->oc_output << 1) & 0xFE);
			C3 = (prbpfilter->_10_dB_Atten & 1) | ((prbpfilter->_20_dB_Atten << 1) & 2) | 
				((prn->rx[0].preamp << 2) & 0b00000100) | ((prn->adc[0].dither << 3) & 0b00001000) |
				((prn->adc[0].random << 4) & 0b00010000) | ((prbpfilter->_Rx_1_Out << 7) & 0b10000000);
			if (prbpfilter->_XVTR_Rx_In)
				C3 |= 0b01100000;
			else if (prbpfilter->_Rx_1_In)
				C3 |= 0b00100000;
			else if (prbpfilter->_Rx_2_In)
				C3 |= 0b01000000;

			if (prbpfilter->_ANT_3 == 1)
				C4 = 0b10;
			else if (prbpfilter->_ANT_2 == 1)
				C4 = 0b01;
			else
				C4 = 0b0;
			C4 |= 0b00000100;					// duplex bit /* Should be assigned */
			C4 |= (nddc - 1) << 3;				// number of DDCs to run
			C4 |= (P1_en_diversity) << 7;		// if diversity, locks VFOs
			break;

			// the frequency assignments will need to change
			// when we work out a mapping for the ADC channels
		case 1: //TX VFO
			C0 |= 2;
			C1 = (prn->tx[0].frequency >> 24) & 0xff; // byte 0 of tx freq 
			C2 = (prn->tx[0].frequency >> 16) & 0xff; // byte 1 of tx freq 
			C3 = (prn->tx[0].frequency >> 8) & 0xff; // byte 2 of tx freq 
			C4 = (prn->tx[0].frequency) & 0xff; // byte 3 of tx freq 
			break;

		case 2: //RX1 VFO (DDC0)
			C0 |= 4;
			// DDC0 is always RX0 freqency, except if Puresignal TX with hermes-II
			if ((nddc == 2) && (XmitBit == 1) && (prn->puresignal_run))
				ddc_freq = prn->tx[0].frequency;
			else
				ddc_freq = prn->rx[0].frequency;
			C1 = (ddc_freq >> 24) & 0xff; // byte 0 of rx1 freq 
			C2 = (ddc_freq >> 16) & 0xff; // byte 1 of rx1 freq 
			C3 = (ddc_freq >> 8) & 0xff; // byte 2 of rx1 freq 
			C4 = (ddc_freq) & 0xff; // byte 3 of rx1 freq 
			break;

		case 3: //RX2 VFO (DDC1)
			C0 |= 6;
			// DDC1 is TX freq if Hermes-II && TX && Puresignal; 
			// RX1 freq if Orion;
			// else RX2 freq if Hermes
			if ((nddc == 2) && (XmitBit == 1) && (prn->puresignal_run))
				ddc_freq = prn->tx[0].frequency;
			else if (nddc == 5)
				ddc_freq = prn->rx[0].frequency;
			else
				ddc_freq = prn->rx[1].frequency; //Hermes RX2 freq
			C1 = (ddc_freq >> 24) & 0xff; // byte 0 of rx2 freq 
			C2 = (ddc_freq >> 16) & 0xff; // byte 1 of rx2 freq 
			C3 = (ddc_freq >> 8) & 0xff; // byte 2 of rx2 freq 
			C4 = (ddc_freq) & 0xff; // byte 3 of rx2 freq 
			break;

			// ADC assignments hardwired according to the configuration (see spreadsheet)
			// orion: taken from setup form
			// Hermes/Hermes-E don't use this data
		case 4: // ADC assignments & ADC Tx ATT
			C0 |= 0x1c; //C0 0001 110x
			C1 = P1_adc_cntrl & 0xFF;
			C2 = (P1_adc_cntrl >> 8) & 0b0011111111;
			C3 = prn->adc[0].tx_step_attn & 0b00011111;
			C4 = 0;
			break;

		case 5: //RX3 VFO (DDC2)
			C0 |= 8;
			// if Orion, DDC2 is RX2 frequency; else TX frequency for Hermes
			if(nddc == 5)
				ddc_freq = prn->rx[3].frequency;
			else
				ddc_freq = prn->tx[0].frequency;
			C1 = (ddc_freq >> 24) & 0xff; // byte 0 of rx3 freq 
			C2 = (ddc_freq >> 16) & 0xff; // byte 1 of rx3 freq 
			C3 = (ddc_freq >> 8) & 0xff; // byte 2 of rx3 freq 
			C4 = (ddc_freq) & 0xff; // byte 3 of rx3 freq 
			break;

		case 6: //RX4 VFO (DDC3)
			C0 |= 0x0a;
			// DDC3 is TX frequency always
			ddc_freq = prn->tx[0].frequency;
			C1 = (ddc_freq >> 24) & 0xff; // byte 0 of rx4 freq 
			C2 = (ddc_freq >> 16) & 0xff; // byte 1 of rx4 freq 
			C3 = (ddc_freq >> 8) & 0xff; // byte 2 of rx4 freq 
			C4 = (ddc_freq) & 0xff; // byte 3 of rx4 freq 
			break;

		case 7: //RX5 VFO (DDC4)
			C0 |= 0x0c;
			// DDC4 is TX frequency for Orion2 TX with puresignal, otherwise not used, so make TX always
			ddc_freq = prn->tx[0].frequency;
			C1 = (ddc_freq >> 24) & 0xff; // byte 0 of rx5 freq 
			C2 = (ddc_freq >> 16) & 0xff; // byte 1 of rx5 freq 
			C3 = (ddc_freq >> 8) & 0xff; // byte 2 of rx5 freq 
			C4 = (ddc_freq) & 0xff; // byte 3 of rx5 freq 
			break;

		case 8: //RX6 VFO
			C0 |= 0x0e;
			// DDC5 not used
			ddc_freq = prn->rx[0].frequency;
			C1 = (ddc_freq >> 24) & 0xff; // byte 0 of rx6 freq 
			C2 = (ddc_freq >> 16) & 0xff; // byte 1 of rx6 freq 
			C3 = (ddc_freq >> 8) & 0xff; // byte 2 of rx6 freq 
			C4 = (ddc_freq) & 0xff; // byte 3 of rx6 freq 
			break;

		case 9: //RX7 VFO
			C0 |= 0x10;
			// DDC6 not used
			ddc_freq = prn->rx[0].frequency;
			C1 = (ddc_freq >> 24) & 0xff; // byte 0 of rx7 freq 
			C2 = (ddc_freq >> 16) & 0xff; // byte 1 of rx7 freq 
			C3 = (ddc_freq >> 8) & 0xff; // byte 2 of rx7 freq 
			C4 = (ddc_freq) & 0xff; // byte 3 of rx7 freq 
			break;

		case 10:
			C0 |= 0x12; //C0 0001 001x
			C1 = prn->tx[0].drive_level;				// SWR adjustment before this in SetOutputPowerFactor()
			C2 = ((prn->mic.mic_boost & 1) | ((prn->mic.line_in & 1) << 1) | ApolloFilt |
				ApolloTuner | ApolloATU | ApolloFiltSelect | 0b01000000) & 0x7f;
			C3 = (prbpfilter->_13MHz_HPF & 1) | ((prbpfilter->_20MHz_HPF & 1) << 1) |
				((prbpfilter->_9_5MHz_HPF & 1) << 2) | ((prbpfilter->_6_5MHz_HPF & 1) << 3) |
				((prbpfilter->_1_5MHz_HPF & 1) << 4) | ((prbpfilter->_Bypass & 1) << 5) |
				((prbpfilter->_6M_preamp & 1) << 6) | ((prn->tx[0].pa & 1) << 7);
			C4 = (prbpfilter->_30_20_LPF & 1) | ((prbpfilter->_60_40_LPF & 1) << 1) |
				((prbpfilter->_80_LPF & 1) << 2) | ((prbpfilter->_160_LPF & 1) << 3) |
				((prbpfilter->_6_LPF & 1) << 4) | ((prbpfilter->_12_10_LPF & 1) << 5) |
				((prbpfilter->_17_15_LPF & 1) << 6);
			break;

		case 11: //Preamp control
			C0 |= 0x14; //C0 0001 010x
			C1 = (prn->rx[0].preamp & 1) | ((prn->rx[1].preamp & 1) << 1) |
				((prn->rx[2].preamp & 1) << 2) | ((prn->rx[0].preamp & 1) << 3) |
				((prn->mic.mic_trs & 1) << 4) | ((prn->mic.mic_bias & 1) << 5) |
				((prn->mic.mic_ptt & 1) << 6);
			C2 = (prn->mic.line_in_gain & 0b00011111) | ((prn->puresignal_run & 1) << 6);				
			C3 = prn->user_dig_out & 0b00001111;
			C4 = (prn->adc[0].rx_step_attn & 0b00011111) | 0b00100000;
			break;

		case 12: // Step ATT control
			C0 |= 0x16; //C0 0001 011x
			if (XmitBit)
				C1 = 0x1F;
			else
				C1 = (prn->adc[1].rx_step_attn);
			C1 |= 0b00100000;
			C2 = (prn->adc[2].rx_step_attn & 0b00011111) | 0b00100000 |
				((prn->cw.rev_paddle & 1) << 6);

			if (prn->cw.iambic == 0)
				CWMode = 0b00000000;
			else if (prn->cw.mode_b == 0)
				CWMode = 0b01000000;
			else
				CWMode = 0b10000000;
			C3 = (prn->cw.keyer_speed & 0b00111111) | CWMode;
			C4 = (prn->cw.keyer_weight & 0b01111111) | ((prn->cw.strict_spacing) << 7);
			break;

			// 0x18, 1A are reserved

		case 13: // CW
			C0 |= 0x1e; //C0 0001 111x
			C1 = prn->cw.cw_enable;
			C2 = prn->cw.sidetone_level; 
			C3 = prn->cw.rf_delay;
			C4 = 0;
			break;

		case 14: // CW
			C0 |= 0x20; //C0 0010 000x
			C1 = (prn->cw.hang_delay >> 2) & 0b11111111;
			C2 = (prn->cw.hang_delay & 0b00000011);
			C3 = (prn->cw.sidetone_freq >> 4) & 0b11111111;
			C4 = (prn->cw.sidetone_freq) & 0b00001111;
			break;

		case 15: // EER PWM
			C0 |= 0x22; //C0 0010 001x
			C1 = (prn->tx[0].epwm_min >> 2) & 0b11111111;
			C2 = (prn->tx[0].epwm_min & 0b00000011);
			C3 = (prn->tx[0].epwm_max >> 2) & 0b11111111;
			C4 = (prn->tx[0].epwm_max & 0b00000011);
			break;

		case 16: // BPF2
			C0 |= 0x24; //C0 0010 010x
			C1 = (prbpfilter2->_13MHz_HPF & 1) | ((prbpfilter2->_20MHz_HPF & 1) << 1) |
				((prbpfilter2->_9_5MHz_HPF & 1) << 2) | ((prbpfilter2->_6_5MHz_HPF & 1) << 3) |
				((prbpfilter2->_1_5MHz_HPF & 1) << 4) | ((prbpfilter2->_Bypass & 1) << 5) |
				((prbpfilter2->_6M_preamp & 1) << 6) | ((prbpfilter2->_rx2_gnd) << 7);
			C2 = (xvtr_enable & 1) | ((prn->puresignal_run & 1) << 6);
			C3 = 0;
			C4 = 0;
			break;
		}			
		txbptr[3] = C0;							// add the C0-C4 bytes to USB frame
		txbptr[4] = C1;
		txbptr[5] = C2;
		txbptr[6] = C3;
		txbptr[7] = C4;
		if (out_control_idx < 16)				// ready for next USB frame
			out_control_idx++;
		else
			out_control_idx = 0;
	}

	// now add the data for the two USB frames
	memcpy(FPGAWriteBufp + 8, bufp, sizeof(char) * 8 * 63); // add LRIQ to frame 1 
	memcpy(FPGAWriteBufp + 520, bufp + 504, sizeof(char) * 8 * 63); // add LRIQ to frame 2

	// we created 2 USB frames, so send them
	MetisWriteFrame(0x02, FPGAWriteBufp);
	ReleaseSemaphore(prn->hobbuffsRun[0], 1, 0);
	ReleaseSemaphore(prn->hobbuffsRun[1], 1, 0);
}

void WriteMainLoop_HL2(char* bufp)
{
	// now attempt to TX if there is a frame of data to send
	int txframe;
	unsigned char C0 = 0, C1 = 0, C2 = 0, C3 = 0, C4 = 0;
	unsigned char CWMode;
	char* txbptr;
	int ddc_freq;
	// create 2 USB frames
	for (txframe = 0; txframe < 2; txframe++)
	{
		txbptr = FPGAWriteBufp + 512 * txframe;
		txbptr[0] = 0x7f;			// add the 3 sync bytes
		txbptr[1] = 0x7f;
		txbptr[2] = 0x7f;

		// if TX/RX has changed we need to change the DDC0 frequency for Hermes-II; so jump to that C&C next	
		if (XmitBit != PreviousTXBit)
		{
			if (nddc == 2)
				out_control_idx = 2;
			PreviousTXBit = XmitBit;
		}

		// add the 5 control bytes: get  inc TX bit
		// "C0=0" used to be sent often, but will rarely be changed
		// so it is now sent at the same rate as everything else
		C0 = (unsigned char)XmitBit;

		//if (0 != prn->i2c.delay)
		//{
		//	prn->i2c.delay--;
		//}

		if ((0 >= --prn->i2c.delay) &&
			(prn->i2c.in_index != prn->i2c.out_index))
		{
			prn->i2c.delay = 5;

			// The IN and OUT indexes are not the same, so there is data for transmission

			unsigned char next = prn->i2c.out_index + 1 >= MAX_I2C_QUEUE ? 0 : prn->i2c.out_index + 1;

			if (0 == prn->i2c.i2c_queue[next].bus)
			{
				C0 |= (0x3c << 1) | (prn->i2c.ctrl_request << 7);    //I2C1 0x3c
			}
			else
			{
				C0 |= (0x3d << 1) | (prn->i2c.ctrl_request << 7);    //I2C1 0x3d
			}

			unsigned char address = prn->i2c.i2c_queue[next].address;

			if (0x7f < address)
			{
				address = address >> 1;
			}

			C2 = 0x80 | address; // Stop request

			if (prn->i2c.ctrl_read)
			{
				C1 = 0x07;
			}
			else
			{
				C1 = 0x06;
			}

			C3 = prn->i2c.i2c_queue[next].control;
			C4 = prn->i2c.i2c_queue[next].write_data;

			prn->i2c.out_index = next;
		}
		else
		{
			switch (out_control_idx)	// now m=pick the frame of control bytes
			{
			case 0:						// C0=0: general settings
				C1 = (SampleRateIn2Bits & 3);
				C2 = (prn->cw.eer & 1) | ((prn->oc_output << 1) & 0xFE);
				C3 = (prbpfilter->_10_dB_Atten & 1) | ((prbpfilter->_20_dB_Atten << 1) & 2) |
					((prn->rx[0].preamp << 2) & 0b00000100) | ((prn->adc[0].dither << 3) & 0b00001000) |
					((prn->adc[0].random << 4) & 0b00010000) | ((prbpfilter->_Rx_1_Out << 7) & 0b10000000);
				if (prbpfilter->_XVTR_Rx_In)
					C3 |= 0b01100000;
				else if (prbpfilter->_Rx_1_In)
					C3 |= 0b00100000;
				else if (prbpfilter->_Rx_2_In)
					C3 |= 0b01000000;

				if (prbpfilter->_ANT_3 == 1)
					C4 = 0b10;
				else if (prbpfilter->_ANT_2 == 1)
					C4 = 0b01;
				else
					C4 = 0b0;
				C4 |= 0b00000100;					// duplex bit /* Should be assigned */
				C4 |= (nddc - 1) << 3;				// number of DDCs to run
				C4 |= (P1_en_diversity) << 7;		// if diversity, locks VFOs
				break;

				// the frequency assignments will need to change
				// when we work out a mapping for the ADC channels
			case 1: //TX VFO 0x01
				C0 |= 2;
				C1 = (prn->tx[0].frequency >> 24) & 0xff; // byte 0 of tx freq 
				C2 = (prn->tx[0].frequency >> 16) & 0xff; // byte 1 of tx freq 
				C3 = (prn->tx[0].frequency >> 8) & 0xff; // byte 2 of tx freq 
				C4 = (prn->tx[0].frequency) & 0xff; // byte 3 of tx freq 
				break;

			case 2: //RX1 VFO (DDC0) 0x02
				C0 |= 4;
				// DDC0 is always RX0 freqency, except if Puresignal TX with hermes-II
				if ((nddc == 2) && (XmitBit == 1) && (prn->puresignal_run))
					ddc_freq = prn->tx[0].frequency;
				else
					ddc_freq = prn->rx[0].frequency;
				C1 = (ddc_freq >> 24) & 0xff; // byte 0 of rx1 freq 
				C2 = (ddc_freq >> 16) & 0xff; // byte 1 of rx1 freq 
				C3 = (ddc_freq >> 8) & 0xff; // byte 2 of rx1 freq 
				C4 = (ddc_freq) & 0xff; // byte 3 of rx1 freq 
				break;

			case 3: //RX2 VFO (DDC1) 0x03
				C0 |= 6;
				// DDC1 is TX freq if Hermes-II && TX && Puresignal; 
				// RX1 freq if Orion;
				// else RX2 freq if Hermes
				if ((nddc == 2) && (XmitBit == 1) && (prn->puresignal_run))
					ddc_freq = prn->tx[0].frequency;
				else if (nddc == 5)
					ddc_freq = prn->rx[0].frequency;
				else
					ddc_freq = prn->rx[1].frequency; //Hermes RX2 freq
				C1 = (ddc_freq >> 24) & 0xff; // byte 0 of rx2 freq 
				C2 = (ddc_freq >> 16) & 0xff; // byte 1 of rx2 freq 
				C3 = (ddc_freq >> 8) & 0xff; // byte 2 of rx2 freq 
				C4 = (ddc_freq) & 0xff; // byte 3 of rx2 freq 
				break;

				// ADC assignments hardwired according to the configuration (see spreadsheet)
				// orion: taken from setup form
				// Hermes/Hermes-E don't use this data
			case 4: // ADC assignments & ADC Tx ATT 0x0e
				C0 |= 0x1c; //C0 0001 110x
				C1 = P1_adc_cntrl & 0xFF;
				C2 = (P1_adc_cntrl >> 8) & 0b0011111111;
				C3 = prn->adc[0].tx_step_attn & 0b00011111;
				C4 = 0;
				break;

			case 5: //RX3 VFO (DDC2) 0x04
				C0 |= 8;
				// if Orion, DDC2 is RX2 frequency; else TX frequency for Hermes
				if (nddc == 5)
					ddc_freq = prn->rx[3].frequency;
				else
					ddc_freq = prn->tx[0].frequency;
				C1 = (ddc_freq >> 24) & 0xff; // byte 0 of rx3 freq 
				C2 = (ddc_freq >> 16) & 0xff; // byte 1 of rx3 freq 
				C3 = (ddc_freq >> 8) & 0xff; // byte 2 of rx3 freq 
				C4 = (ddc_freq) & 0xff; // byte 3 of rx3 freq 
				break;

			case 6: //RX4 VFO (DDC3) 0x05
				C0 |= 0x0a;
				// DDC3 is TX frequency always
				ddc_freq = prn->tx[0].frequency;
				C1 = (ddc_freq >> 24) & 0xff; // byte 0 of rx4 freq 
				C2 = (ddc_freq >> 16) & 0xff; // byte 1 of rx4 freq 
				C3 = (ddc_freq >> 8) & 0xff; // byte 2 of rx4 freq 
				C4 = (ddc_freq) & 0xff; // byte 3 of rx4 freq 
				break;

			case 7: //RX5 VFO (DDC4) 0x06
				C0 |= 0x0c;
				// DDC4 is TX frequency for Orion2 TX with puresignal, otherwise not used, so make TX always
				ddc_freq = prn->tx[0].frequency;
				C1 = (ddc_freq >> 24) & 0xff; // byte 0 of rx5 freq 
				C2 = (ddc_freq >> 16) & 0xff; // byte 1 of rx5 freq 
				C3 = (ddc_freq >> 8) & 0xff; // byte 2 of rx5 freq 
				C4 = (ddc_freq) & 0xff; // byte 3 of rx5 freq 
				break;

			case 8: //RX6 VFO 0x07
				C0 |= 0x0e;
				// DDC5 not used
				ddc_freq = prn->rx[0].frequency;
				C1 = (ddc_freq >> 24) & 0xff; // byte 0 of rx6 freq 
				C2 = (ddc_freq >> 16) & 0xff; // byte 1 of rx6 freq 
				C3 = (ddc_freq >> 8) & 0xff; // byte 2 of rx6 freq 
				C4 = (ddc_freq) & 0xff; // byte 3 of rx6 freq 
				break;

			case 9: //RX7 VFO 0x08
				C0 |= 0x10;
				// DDC6 not used
				ddc_freq = prn->rx[0].frequency;
				C1 = (ddc_freq >> 24) & 0xff; // byte 0 of rx7 freq 
				C2 = (ddc_freq >> 16) & 0xff; // byte 1 of rx7 freq 
				C3 = (ddc_freq >> 8) & 0xff; // byte 2 of rx7 freq 
				C4 = (ddc_freq) & 0xff; // byte 3 of rx7 freq 
				break;

			case 10: // 0x09
				C0 |= 0x12; //C0 0001 001x
				C1 = prn->tx[0].drive_level;				// SWR adjustment before this in SetOutputPowerFactor()
				C2 = ((prn->mic.mic_boost & 1) | ((prn->mic.line_in & 1) << 1) | ApolloFilt |
					ApolloTuner | ApolloATU | ApolloFiltSelect | 0b01000000) & 0x7f;
				C3 = (prbpfilter->_13MHz_HPF & 1) | ((prbpfilter->_20MHz_HPF & 1) << 1) |
					((prbpfilter->_9_5MHz_HPF & 1) << 2) | ((prbpfilter->_6_5MHz_HPF & 1) << 3) |
					((prbpfilter->_1_5MHz_HPF & 1) << 4) | ((prbpfilter->_Bypass & 1) << 5) |
					((prbpfilter->_6M_preamp & 1) << 6) | ((prn->tx[0].pa & 1) << 7);
				C4 = (prbpfilter->_30_20_LPF & 1) | ((prbpfilter->_60_40_LPF & 1) << 1) |
					((prbpfilter->_80_LPF & 1) << 2) | ((prbpfilter->_160_LPF & 1) << 3) |
					((prbpfilter->_6_LPF & 1) << 4) | ((prbpfilter->_12_10_LPF & 1) << 5) |
					((prbpfilter->_17_15_LPF & 1) << 6);
				break;

			case 11: //Preamp control 0x0a
				C0 |= 0x14; //C0 0001 010x
				C1 = (prn->rx[0].preamp & 1) | ((prn->rx[1].preamp & 1) << 1) |
					((prn->rx[2].preamp & 1) << 2) | ((prn->rx[0].preamp & 1) << 3) |
					((prn->mic.mic_trs & 1) << 4) | ((prn->mic.mic_bias & 1) << 5) |
					((prn->mic.mic_ptt & 1) << 6);
				C2 = (prn->mic.line_in_gain & 0b00011111) | ((prn->puresignal_run & 1) << 6);
				C3 = prn->user_dig_out & 0b00001111;
				if (XmitBit)
					C4 = (prn->adc[0].tx_step_attn & 0b00111111) | 0b01000000;	// Larger range for the HL2 attenuator 
				else
					C4 = (prn->adc[0].rx_step_attn & 0b00111111) | 0b01000000;	// Larger range for the HL2 attenuator 
				break;

			case 12: // Step ATT control 0x0b
				C0 |= 0x16; //C0 0001 011x
				if (XmitBit)
					C1 = 0x1F;
				else
					C1 = (prn->adc[1].rx_step_attn);
				C1 |= 0b00100000;
				C2 = (prn->adc[2].rx_step_attn & 0b00011111) | 0b00100000 |
					((prn->cw.rev_paddle & 1) << 6);

				if (prn->cw.iambic == 0)
					CWMode = 0b00000000;
				else if (prn->cw.mode_b == 0)
					CWMode = 0b01000000;
				else
					CWMode = 0b10000000;
				C3 = (prn->cw.keyer_speed & 0b00111111) | CWMode;
				C4 = (prn->cw.keyer_weight & 0b01111111) | ((prn->cw.strict_spacing) << 7);
				break;

				// 0x18, 1A are reserved

			case 13: // CW 0x0f
				C0 |= 0x1e; //C0 0001 111x
				C1 = prn->cw.cw_enable;
				C2 = prn->cw.sidetone_level;
				C3 = prn->cw.rf_delay;
				C4 = 0;
				break;

			case 14: // CW 0x10
				C0 |= 0x20; //C0 0010 000x
				C1 = (prn->cw.hang_delay >> 2) & 0b11111111;
				C2 = (prn->cw.hang_delay & 0b00000011);
				C3 = (prn->cw.sidetone_freq >> 4) & 0b11111111;
				C4 = (prn->cw.sidetone_freq) & 0b00001111;
				break;

			case 15: // EER PWM 0x11
				C0 |= 0x22; //C0 0010 001x
				C1 = (prn->tx[0].epwm_min >> 2) & 0b11111111;
				C2 = (prn->tx[0].epwm_min & 0b00000011);
				C3 = (prn->tx[0].epwm_max >> 2) & 0b11111111;
				C4 = (prn->tx[0].epwm_max & 0b00000011);
				break;

			case 16: // BPF2 0x12
				C0 |= 0x24; //C0 0010 010x
				C1 = (prbpfilter2->_13MHz_HPF & 1) | ((prbpfilter2->_20MHz_HPF & 1) << 1) |
					((prbpfilter2->_9_5MHz_HPF & 1) << 2) | ((prbpfilter2->_6_5MHz_HPF & 1) << 3) |
					((prbpfilter2->_1_5MHz_HPF & 1) << 4) | ((prbpfilter2->_Bypass & 1) << 5) |
					((prbpfilter2->_6M_preamp & 1) << 6) | ((prbpfilter2->_rx2_gnd) << 7);
				C2 = (xvtr_enable & 1) | ((prn->puresignal_run & 1) << 6);
				C3 = 0;
				C4 = 0;
				break;

			case 17: // TX latency and PTT hang 0x17
				C0 |= 0x2e; //C0 0010 111x
				C1 = 0;
				C2 = 0;
				C3 = (prn->tx[0].ptt_hang & 0b00011111);
				C4 = (prn->tx[0].tx_latency & 0b01111111);
				break;

			case 18: // Reset on disconnect 0x3a
				C0 |= 0x74; //C0 0111 010x
				C1 = 0;
				C2 = 0;
				C3 = 0;
				C4 = prn->reset_on_disconnect;
				break;

			}

			if (out_control_idx < 18)				// ready for next USB frame
				out_control_idx++;
			else
				out_control_idx = 0;
		}

		txbptr[3] = C0;							// add the C0-C4 bytes to USB frame
		txbptr[4] = C1;
		txbptr[5] = C2;
		txbptr[6] = C3;
		txbptr[7] = C4;
	}

	// now add the data for the two USB frames
	memcpy(FPGAWriteBufp + 8, bufp, sizeof(char) * 8 * 63); // add LRIQ to frame 1 
	memcpy(FPGAWriteBufp + 520, bufp + 504, sizeof(char) * 8 * 63); // add LRIQ to frame 2

	// we created 2 USB frames, so send them
	MetisWriteFrame(0x02, FPGAWriteBufp);
	ReleaseSemaphore(prn->hobbuffsRun[0], 1, 0);
	ReleaseSemaphore(prn->hobbuffsRun[1], 1, 0);
}


DWORD WINAPI sendProtocol1Samples(LPVOID n)
{
	DWORD taskIndex = 0;
	HANDLE hTask = AvSetMmThreadCharacteristics(TEXT("Pro Audio"), &taskIndex);
	if (hTask != 0) AvSetMmThreadPriority(hTask, 2);
	else SetThreadPriority(GetCurrentThread(), THREAD_PRIORITY_HIGHEST);

	int i, j, k;
	short temp;
	double swap;
	double *pbuffs [2];
	pbuffs[0] = prn->outLRbufp;
	pbuffs[1] = prn->outIQbufp;

	while (io_keep_running != 0)
	{
		WaitForMultipleObjects(2, prn->hsendEventHandles, TRUE, INFINITE);
		// if ((nddc == 2) || (nddc == 4))
		if (pcm->xmtr[0].peer->run && XmitBit)
		{
			// if eer/etr mode and transmitting, overwrite LR data with EER data
			memcpy(prn->outLRbufp, prn->outIQbufp + 256, sizeof(complex) * 126);
		}
		if (!XmitBit) memset(prn->outIQbufp, 0, sizeof(complex) * 126);
		// WriteAudio (30.0, 48000, 126, prn->outIQbufp, 3);
		// WriteAudio (60.0, 48000, 126, prn->outLRbufp, 3);
		for (i = 0; i < 4 * 63; i += 2)			// swap L & R audio; firmware bug fix
		{
			swap = pbuffs[0][i + 0];
			pbuffs[0][i + 0] = pbuffs[0][i + 1];
			pbuffs[0][i + 1] = swap;
		}
		for (i = 0; i < 2 * 63; i++)				// for each sample from both sets, 8 bytes per
			for (j = 0; j < 2; j++)					// for a sample from each set, 4 bytes per
				for (k = 0; k < 2; k++)				// for each component of the sample, 2 per
				{
					temp = pbuffs[j][i * 2 + k] >= 0.0 ? (short)floor(pbuffs[j][i * 2 + k] * 32767.0 + 0.5) :
						(short)ceil(pbuffs[j][i * 2 + k] * 32767.0 - 0.5);
					if (prn->cw.cw_enable && j == 1)
						if (prn->discovery.BoardType == HermesLite)
							temp = (prn->tx[0].cwx_ptt << 3 |	// MI0BOT: Bit 3 in HL2 is used to signal PTT for CWX
						    		prn->tx[0].dot << 2 |
									prn->tx[0].dash << 1 |
						    		prn->tx[0].cwx) & 0b00001111;
						else
							temp = (prn->tx[0].dot << 2 |
									prn->tx[0].dash << 1 |
						    		prn->tx[0].cwx) & 0b00000111;
					prn->OutBufp[8 * i + 4 * j + 2 * k + 0] = (char)((temp >> 8) & 0xff);
					prn->OutBufp[8 * i + 4 * j + 2 * k + 1] = (char)(temp & 0xff);
				}

		if (prn->discovery.BoardType == HermesLite)	// MI0BOT: Different write loop for HL2
			WriteMainLoop_HL2(prn->OutBufp);
		else
			WriteMainLoop(prn->OutBufp);
	}
	return 0;
}

