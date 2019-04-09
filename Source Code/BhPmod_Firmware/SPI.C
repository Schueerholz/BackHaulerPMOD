/*--------------------------------------------------------------------------*/
/* SPI.C 

   Purpose:
  
   This driver module operates the SPI bus from the SiLabs 8051 master 
   controller to perform primitive reads and writes on the bus.  This module 
   operates all physical layer controls including application specific chip 
   select and clock phase settings.  This version operates one device with 
   a known chip select.  The clock phase is set by a seperate function 
   defined here and is maintained for all transactions with the single device
   until and unless it is changed again by the caller.  The clock rate is 
   set relatively slow so as to maintain the most compatibility without
   additional code.  The driver is thus kept very simple whereas a more 
   generalized form may be unnecessarily complex for a deeply embedded 
   environment such as this application.
   
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
                        
#define _SPI_C_

#include "global.h"
#include "delays.h"
#include "pmod.h"
#include "spi.h"
                     
/* Local private functions */

/* Local private defines */

// SPI port configuration register operations
#define SPI_SCK_POL_0                       {SPI0CFG &= 0xEF;} 
#define SPI_SCK_POL_1                       {SPI0CFG |= 0x10;}  
#define SPI_SCK_PHA_0                       {SPI0CFG &= 0xDF;}  
#define SPI_SCK_PHA_1                       {SPI0CFG |= 0x20;} 

// SPI bus busy status bit
#define SPI_BUSY                            (SPI0CFG & 0x80)
     
/*--------------------------------------------------------------------------*/
/* Module Public Functions                                                  */
/*--------------------------------------------------------------------------*/

/* SPI_CONFIGURE prepares the SPI bus for normal operation.

*/

void SPI_Configure(void)
 {                 
  // Set the SPI clock rate 
  // With a 48 MHz system clock, this makes for 400KHz operation
  SPI0CKR = 59;     	// 239 for 100KHz, 59 for 400KHz 
    
  // Set the configuration register to enable master mode, otherwise default
  SPI0CFG = 0x40;

  // Enable the SPI port
  // Do not change the mode configuration from that chosen with global pin configuration
  SPI0CN |= 0x01; 

  // Send at least one byte of data, no chip selects
  SPI0DAT = 0xFF;
	 
	// Set the clock phase to default
  SPI_SetClockPhase(SPI_CLOCK_PHASE_0);	 
 } 

/*--------------------------------------------------------------------------*/

/* SPI_SETCLOCKPHASE configures the clock polarity and phase information 
   according to the argument, using the values in the ICD.  This is a simple
   register setting function and can be used at any time after the SPI is
   initially configured.  If the argument is invalid, then the default is set
   per requirement of the ICD.
*/

void SPI_SetClockPhase(BYTE NewClockPhase)
 {  
  switch(NewClockPhase)
   {
    case SPI_CLOCK_PHASE_1: SPI_SCK_POL_0; SPI_SCK_PHA_1; break;   
    case SPI_CLOCK_PHASE_2: SPI_SCK_POL_1; SPI_SCK_PHA_0; break;   
    case SPI_CLOCK_PHASE_3: SPI_SCK_POL_1; SPI_SCK_PHA_1; break;   
    // SPI_CLOCK_PHASE_0 is the default
    default: SPI_SCK_POL_0; SPI_SCK_PHA_0; break;
   };
 } 

/*--------------------------------------------------------------------------*/

/* SPI_TRANSACTION moves data to and from the specified device.  

   The device is part of a hardware configuration with application specific
   connection details.  The configuration is part of this layer of SPI 
   subsystem design.  The details of activating the device are established
   in this module.  Failure to activate a device or other errors will 
   cause a 0 to be returned by value, otherwise the return value is the 
   number of bytes transferred.

   This routine activates one device with a known chip select signal and 
   sends the Count bytes of WriteContent over the bus MSB first.  SPI is defined 
   as MSB first in each byte.  While data are being written, received bytes are 
   written into ReadContent, thereby returning the read values by reference.  
   If the WriteContent is NULL then all bytes written are 0xFF.  If the ReadContent 
   is NULL then no data are returned.  The void pointers allow a caller to 
   conveniently handle larger word sizes in many cases.  By SPI definition, 
   there will always be the same number of bytes written and read, so the buffers 
   should be the same size. The buffers can point to the same physical memory space.

   This version is coded for somehwat higher write speed.  For this reason, this version 
   also does not allow the NULL write content as this condition would rarely exist.  
   Howver, the SPI in use here is actually relatively slow, so we do wait for the SPI 
   busy bit to identify when a byte is complete.  
*/

BYTE SPI_Transaction(BYTE Count, void *WriteContent, void *ReadContent) 
 { 
  BYTE data i, wrla;
  BYTE *wrcont = (BYTE *)WriteContent;
  BYTE *rdcont = (BYTE *)ReadContent;
  BYTE data cnt = Count;
  BYTE data rce = (rdcont == NULL) ? 0 : 1;

  // Conditions not allowed
  if(wrcont == NULL) return(0);
     
  // Leave if bus busy
  if(SPI_BUSY) return(0);

  // Activate the device
  SPI_CS = 0;
  // Give some relatively slow CS to first clock time
  DELAY_uS;
  DELAY_uS;
 
  // Transfer data
  wrla = wrcont[0];
  for(i=0;i<cnt;i++)    
   {
    // Send a byte  
    SPI0DAT = wrla;
    // Look ahead read while waiting for transfer (ok to read over end of buffer, just not write)
    wrla = wrcont[i+1];
    // Wait for the byte to finish - this is guranteed if anything at all is still working
    while(SPI_BUSY);  
    // Return a byte if requested
    if(rce) rdcont[i] = SPI0DAT;
   };

  // Give some relatively slow last clock to CS inactive
  DELAY_uS;
  DELAY_uS;
  // Dectivate the device
  SPI_CS = 1;

  // Return success
  return(Count);
 } 
  
/*--------------------------------------------------------------------------*/
/* Module Support Functions                                                 */
/*--------------------------------------------------------------------------*/


/*--------------------------------------------------------------------------*/

/* END OF MODULE */




