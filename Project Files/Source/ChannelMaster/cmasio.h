/*  cmasio.h

This file is part of a program that implements a Software-Defined Radio.

Copyright (C) 2023 Bryan Rambo W4WMT

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

The author can be reached by email at

bryanr@bometals.com

*/

#ifndef _cmasio_h
#define _cmasio_h

void create_cmasio();
void destroy_cmasio();
long cm_asioStart(int protocol);
long cm_asioStop();
void asioIN(double* in_tx);
void asioOUT(int id, int nsamples, double* buff);

void CallbackASIO(void* inputL, void* inputR, void* outputL, void* outputR);

extern __declspec(dllimport) long getASIODriverString(void* szData);
extern __declspec(dllimport) long getASIOBlockNum(void* dwData);
extern __declspec(dllimport) int prepareASIO(int blocksize, int samplerate, char* asioDriverName, void (*CallbackASIO)(void* inputL, void* inputR, void* outputL, void* outputR));
extern __declspec(dllimport) void unloadASIO();
extern __declspec(dllimport) long asioStart();
extern __declspec(dllimport) long asioStop();

typedef struct _cmasio
{
	void* rmatchIN;
	void* rmatchOUT;
	double* input;
	double* output;
	int blocksize;
	int run;
	void* bufferFull;
	void* bufferEmpty;
	long overFlowsIn;
	long overFlowsOut;
	long underFlowsIn;
	long underFlowsOut;
	int lockMode;
	int protocol; // W4WMT cmASIO via Protocol 1
} cmasio, *CMASIO;

extern CMASIO pcma;

#endif
