/*--------------------------------------------------------------------------*/
/* DELAYS.C 

   Purpose:
   
   This is a primitive module for primitive code based delays.  There is some 
   functionality which is compiler specific.  Delays are highly dependant
   on system configuration, clock speed, and even the compiler.  These
   delays are tuned for each application.  They are also interruptible,
   so the delay implied should generally be considered the minimum 
   and also only approximate.
    
   Structure:
   
   This is a primitive module per definition of Allied Component Works
   cooperative multitasking embedded code architecture.  The routines 
   are simplistic, have no dependencies, and may be called at any time.
   
   The original tool chain is Kiel for the 8051 architecture.
 
   Rules for application:
   
   This module is free software; you can redistribute it and/or modify it
   under the terms of the GNU General Public License as published by the
   Free Software Foundation; either version 2, or (at your option) any
   later version.

   This software is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License 
   along with this software; see the file COPYING. If not, write to the
   Free Software Foundation, 51 Franklin Street, Fifth Floor, Boston,
   MA 02110-1301, USA.

   As a special exception, if you link this software with other files
   to produce an executable, this software does not by itself cause the 
   resulting executable to be covered by the GNU General Public License. 
   This exception does not however invalidate any other reasons why the 
   executable file might be covered by the GNU General Public License.
   
   This software is typically modified in its detail to fit a specific
   application, the total of which may be held as proprietary to the 
   author or assigns of such derivative works, and various copyrights 
   may apply to such derivatives.   
   
   Original work on this software is from the tool kit of Mark A. Shaw
   at Allied Component Works, Gaithersburg, MD, USA.  The original shall 
   thus be Copyright (C) 2013 Allied Component Works per the above terms. 
   This authorship shall be void if ANY portion of this file is modified.  
   The original author disclaims all copyrights or any association at all 
   with any such derivative works.  However, the original shall remain
   free as described here.
   
   Derivative author comments here -
   < must be filled in if authored by other than Allied Component Works >
*/   
/*--------------------------------------------------------------------------*/

#define _DELAYS_C_

#include "global.h"
#include "delays.h"

/* Local private functions */

/* Local private macros */

/* Local private data */

/*--------------------------------------------------------------------------*/
/* Module Public Functions                                                  */
/*--------------------------------------------------------------------------*/

/* DELAYS_SHORT performs a counted short delay through using a short loop.
   Delay tends to be about 1uS for the first count (includes call and return) 
   and 0.25 us for every additional count depending on the clock frequency
   in use.
*/

void DELAYS_Short(BYTE DelayCount) 
 {
  while(--DelayCount);
 }

/*--------------------------------------------------------------------------*/

/* DELAYS_LONG performs a counted long delay through using a short loop.
   The delays are nearly equivilent to short delays repeated count times.
*/

void DELAYS_Long(BYTE DelayCount, BYTE CountRep)  
 {
  BYTE cnt;
  while(--CountRep) { cnt = DelayCount; while(--cnt); };
 }

/*--------------------------------------------------------------------------*/

/* END OF MODULE */



