/*--------------------------------------------------------------------------*/
/* TIMER.C 

   Purpose:
   
   This driver module keeps track of time since the program started.  
   The time is kept locally and updated by an interrupt heart beat.  It is 
   accessed through exported functions which provide useful features based 
   on time.  The special timer 3 is used to generate the heart beat.  This 
   module also depends on CKCON, so be sure to review other uses.  The 
   configuration is dependant on the system clock frequency and certain
   other global settings, including global interrupt enable.
    
   Structure:
   
   This is a DRIVER module per definition of Allied Component Works
   cooperative multitasking embedded code architecture.  The routine
   <driver>_Configure() must exist even if there is nothing in it, and
   it must be called early in code execution, dependant on application 
   architecture but before any other routine in this module is called. 
   
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

#define _TIMER_C_

#include "global.h"
#include "delays.h"
#include "timer.h"

/* Local private functions */
// Marcos to operate the interrupt (this is chip dependant)
#define ENABLE_TIMER_INTERRUPT      {EIE1 |= 0x80;}
#define DISABLE_TIMER_INTERRUPT     {EIE1 &= 0x7F;}

/* Local private data */
// Master time variables - initialize to zero on reset 
LWORD TIMER_Seconds = 0;
WORD TIMER_Milliseconds = 0;

/*--------------------------------------------------------------------------*/
/* Module Public Functions                                                  */
/*--------------------------------------------------------------------------*/

/* TIMER_CONFIGURE prepares the timer for operation.  This module uses the 
   timer 3 available in this variant.  The global interrupt configuration 
   is handled in the main module for the benefit of all modules.
*/

void TIMER_Configure(void)
 {
  LWORD sec;  

  // Set up the timers based on the system clock frequency
  TMR3CN    = 0x00;
  TMR3RLL   = 0xC0;
  TMR3RLH   = 0x63;
  TMR3L     = 0xC0;
  TMR3H     = 0x63;
  TMR3CN    = 0x04; 

  // Enable interrupts for this function
  ENABLE_TIMER_INTERRUPT;

  // Call functions at least once for clean compile
  TIMER_SetTime(0);
  TIMER_GetTime(&sec);
  TIMER_DeltaTime(0, 10);
 }

/*--------------------------------------------------------------------------*/

/* TIMER_SETTIME sets the current time to the specified value.  This could 
   allow this module to be used as a real time clock.  The time is a 32-bit 
   value in seconds.  Setting should be done while aware of timed events 
   using a current value of time.   
*/

void TIMER_SetTime(LWORD Seconds)
 {
  DISABLE_TIMER_INTERRUPT;
  TIMER_Seconds = Seconds;
  TIMER_Milliseconds = 0;
  ENABLE_TIMER_INTERRUPT;
 }

/*--------------------------------------------------------------------------*/

/* TIMER_GETTIME reads the current time in seconds.  This is a 32-bit value
   typically in seconds since the system last reset.   
*/

void TIMER_GetTime(LWORD *Seconds)
 { 
  DISABLE_TIMER_INTERRUPT;
  *Seconds = TIMER_Seconds;
  ENABLE_TIMER_INTERRUPT;
 }

/*--------------------------------------------------------------------------*/

/* TIMER_DELTATIME determines if the specified delta in seconds has passed 
   since the specified start time in seconds.  A 1/0 value is returned.
*/

BYTE TIMER_DeltaTime(LWORD StartTimeSeconds, LWORD Delta)
 {
  LWORD current_seconds;
  LWORD current_delta;

  // Grab a snapshot of time 
  DISABLE_TIMER_INTERRUPT;
  current_seconds = TIMER_Seconds;
  ENABLE_TIMER_INTERRUPT;

  // Subtract the two to get the delta
  // If the counter has lapsed, we have to do more
  if(StartTimeSeconds > TIMER_Seconds)
   current_delta = 0xFFFFFFFF - StartTimeSeconds + current_seconds + 1;
  else
   current_delta = current_seconds - StartTimeSeconds;

  // See if the delta has expired and return result
  return((current_delta >= Delta) ? 1 : 0);
 }

/*--------------------------------------------------------------------------*/
/* Module Support Functions                                                 */
/*--------------------------------------------------------------------------*/

/* TIMER_ISR is executed when the auto reload expires on the timer 3 special 
   purpose timer.  This routine updates the time values and sets up to 
   receive the next interrupt.  This makes the heartbeat of the system.
*/             
                 
void TIMER_ISR(void) interrupt INTERRUPT_TIMER3 using 1        
 {               
  // Update the time
  TIMER_Milliseconds += 10;
  if(TIMER_Milliseconds >= 1000)
   {
    TIMER_Milliseconds = 0;
    TIMER_Seconds += 1;
   };     
  // Clear the overflow flag and keep the timer enabled
  TMR3CN = 0x04;             
 }

/*--------------------------------------------------------------------------*/

/* END OF MODULE */




