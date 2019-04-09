/*--------------------------------------------------------------------------*/
/* I2C.C 

   Purpose:
   
   Manage an I2C bus on a SiLabs 8051 part.  This module does not handle
   the distribution of bus addresses, but does rely on a specific
   definition of pins in use for certain fail safe functionality.  
   The configuration depends on system clock speed.
   
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
                        
#define _I2C_C_

#include "global.h"
#include "delays.h"
#include "i2c.h"
                     
/* This driver module operates the I2C bus and performs primitive reads and 
   writes to devices on it.  Higher level drivers would know what the data 
   content means.

   This driver is a master only, so the steps are run to completion by polling 
   for the SI bit rather than having an interrupt routine.  Implementing an 
   interrupt would be a good thing if we were going to be a slave and receive 
   commands or something this way, but using an interrupt here would serve
   only a call back or wait for interrupt step.  Queuing I2C data sent or 
   received by a master does not make much sense as uses of the I2C bus are 
   generally sequential.  Though an interrupt implementation could allow the 
   main loop to do other things (register a transaction and come back
   to check its progress), in most cases it would cause as much difficulty 
   in use as it would save.

   Note: The SiLabs SMBus (I2C) port is very touchy.  Order of operations and 
   how they are interpreted by the port hardware is critical.  Use great care 
   in moving any piece of this code.  Subtle order of operations makes a 
   difference and may make more difference as SCL speed changes.  The notes in 
   the code are a start at elaborating on this ordering.  Much of the difficulty 
   in understanding the port comes from operating in polling mode and trying to 
   understand what functions the port undertakes automatically, when, and how.

   Protocol note: Normally we think of the I2C being 9 bits with the 9th bit being 
   the acknowledge cycle.  That is true for most devices.  However, it is allowed
   that the slave can extend the cycle by holding SCL low and/or SDA high for a 
   time and then providing the acknowledge.  The SiLabs port handles this, waiting 
   for SDA to drop before completing the acknowledge cycle or timing out.  Timeout 
   applies only to the address byte to deal with possible nonexistant devices.  
   Data bytes do not timeout, so a device could hold the bus long enough to for 
   example complete some operation like writing an EEPROM.  This imposes the potential 
   of an I/O deadlock for a failed device.  So we impose a timeout, but the timeout 
   should be quite long.  This may leave the I2C bus hung though.  If a device is 
   holding the bus then calls to this driver fail.
*/

/* Local private functions */
BYTE WaitForSI(void);

/* Local private data */
// Location of I2C pins for this application (define in global.h)
// These are defined only for monitoring the health of the bus
// Bus health monitoring test, should be false before a normal start
#define I2C_BUS_HUNG    ((I2C_SCL == 0) || (I2C_SDA == 0))                         

/*--------------------------------------------------------------------------*/
/* Module Public Functions                                                  */
/*--------------------------------------------------------------------------*/

/* I2C_CONFIGURE prepares the I2C bus for normal operation.

*/

void I2C_Configure(void)
 {                    
  // Setup timer 2 to free run  
  // This would make for under 200KHz from a 4MHz input (SYSCLK/12 as defined below)
  // Bit rate would be 1/3 of this
  // Tune so actual rate is no more than about 50KHz so it is compatible with all devices
  // particularly when including clock high and low time requirements
  TMR2RLL = 0xE6;   
  TMR2RLH = 0xFF;
  // Enable the timer for clock SYSCLK/12 (assumes CKCON default on timer 2 bits)
  TMR2CN = 0x04;    
              
  // Clear and configure the port
  I2C_Reset();
 } 

/*--------------------------------------------------------------------------*/

/* I2C_WRITE performs all steps necessary to write a given number of bytes
   to the I2C bus.  The addresses of connected devices are generally defined
   in headers or passed in from other software, but they are the unshfited
   7-bit address.  The count specifies the number of bytes to be written.  
   The content will be taken as big endian bytes, but the void makes it easy 
   to use any data type.  The return value is the number of bytes of the 
   content actually written.  
   
   This routine allows the caller to specify a subordinate address of a 
   specified number of bytes to precede the content.  This makes it easy for 
   a caller to include an internal register address or other subordinate 
   address (such as within an EEPROM) on one line.  The subordinate address 
   can be any size, but is typically one or two bytes.  The void pointer 
   makes it easier to use a larger word size for the subaddress.  The endian 
   order of bytes must always be watched, but the 8051 and generally target 
   I2C devices are big endian.  If there is no subordinate address, the 
   size should be 0 and the pointer NULL.

   This routine allows there to be no content and thus only write a subaddress.
   This might be useful for certain testing.  If there is no content, make the
   count 0 and the pointer NULL.  If there is neither subaddress nor content,
   then there is just a start, address, and stop, the return value being 0.
*/

BYTE I2C_Write(BYTE Address, BYTE SubAddrSize, void *SubAddr, BYTE Count, void *Content)
 {
  BYTE i;
  BYTE *cont;

  // Argument check
  if((SubAddrSize != 0) && (SubAddr == NULL)) return(0);
  if((Count != 0) && (Content == NULL)) return(0);

  // Make sure we are not delaying our response if something is broken
  if(I2C_BUS_HUNG) return(0); 

  // Perform a start
  STA = 1;          
  if(!WaitForSI()) return(I2C_Reset()); 
  STA = 0;

  // Tech note: STO is cleared by hardware after the stop condition is output, 
  // unlike STA for start.  We don't use this, but the hardware thus allows some 
  // fancy stop-start activities.  We clear STA before going on.  When the start 
  // condition is complete as indicated by SI, we must load the data register with 
  // the address to send before we clear SI.  Think interrupt routine, where the 
  // wait is a wait for interrupt and clearing SI would be the last thing to do 
  // before going into another wait cycle.  Clearing SI is the action which starts 
  // the write.  The bus is stalled when SI is set.  The data register can only 
  // be written with SI set.
   
  // Send the address with the R/W bit 0
  SMB0DAT = Address * 2;     
  SI = 0;
  if(!WaitForSI()) return(I2C_Reset()); 

  // Tech note: Again SI must be cleared only after the next byte is loaded unless 
  // there is no more data to send.  Imagine that this is an interrupt routine.  
  // The ACK bit will be the state of the slave ACK slot right before this SI.

  // If there is no acknowledge then drop out for bad address
  if(!ACK) return(I2C_Reset()); 

  // If there is a SubAddr
  if(SubAddrSize > 0)
   {
    // Get the address of the first byte of SubAddr
    cont = SubAddr;

    // Send each byte and wait for transmission
    // SI is cleared after each byte is loaded so we can wait for it as an indication 
    // that the byte has been transfered.  Again, clearing SI starts the transfer 
    // and we can't write the data register when SI is not set.  
    for(i=0;i<SubAddrSize;i++)
     {
      SMB0DAT = cont[i];
      SI = 0;                         
      if(!WaitForSI()) return(I2C_Reset());  
      if(!ACK) return(I2C_Reset()); 
     };  
   };

  // If there is content
  if(Count > 0)
   {
    // Get the address of the first byte of Content
    cont = Content;

    // Send each byte and wait for transmission
    // SI is cleared after each byte is loaded so we can wait for it as an indication 
    // that the byte has been transfered.  Again, clearing SI starts the transfer 
    // and we can't write the data register when SI is not set.  
    for(i=0;i<Count;i++)
     {
      SMB0DAT = cont[i];
      SI = 0;                         
      if(!WaitForSI()) return(I2C_Reset()+i);  
      if(!ACK) return(I2C_Reset()+i); 
     };  
   };

  // Last byte sent, set STO and clear SI  
  // This will end the transaction
  STO = 1;
  SI = 0;

  // Tech note: See that SI is clear as the absolute last thing done 

  // This is write recovery time needed by some devices
  DELAY_mS;

  // Return success
  return(Count);
 }

/*--------------------------------------------------------------------------*/

/* I2C_READ performs all steps necessary to read a given address on 
   the I2C bus.  The addresses of connected devices are generally defined
   in headers or passed in from other software, but they are the unshfited
   7-bit address.  The count specifies the number of bytes to be read.  
   The content will be taken as big endian bytes, but the void makes it 
   easy to use any data type.  The return value is the number of 
   bytes actually read into the content.  

   This routine allows the caller to specify a subordinate address of a 
   specified number of bytes to precede the content.  This makes it easy for 
   a caller to include an internal register address or other subordinate 
   address (such as within an EEPROM) on one line.  The subordinate address 
   can be any size, but is typically one or two bytes.  The void pointer 
   makes it easier to use a larger word size for the subaddress.  The endian 
   order of bytes must always be watched, but the 8051 and generally target 
   I2C devices are big endian. If there is no subordinate address, the 
   size should be 0 and the pointer NULL.

   The subordinate address is written as a write operation preceeding the read.
   Between the write and the read, a restart is performed.  All devices should 
   allow this, while some devices would forget the subordinate address if a 
   full stop is performed.  If a device does not allow it for some strange 
   reason, then perform a seperate write with the subordinate address as content 
   and do not include a subaddress here.

   This routine does not allow there to be zero content as that makes no sense.
   To write a subaddress alone, use the write routine.

   Note:  Tech notes that are the same as for write are not duplicated here.
*/


BYTE I2C_Read(BYTE Address, BYTE SubAddrSize, void *SubAddr, BYTE Count, void *Content)
 {
  BYTE i;
  BYTE *cont;

  // Argument check
  if((SubAddrSize != 0) && (SubAddr == NULL)) return(0);
  if(Count == 0) return(0);
  if(Content == NULL) return(0);
 
  // Make sure we are not delaying our response if something is broken
  if(I2C_BUS_HUNG) return(0); 

  // If there is a SubAddr then a write cycle must be performed for that
  // This write cycle does not perform a stop
  // See the write routine for tech notes
  if(SubAddrSize != 0)
   {
    // Perform a start
    STA = 1;          
    if(!WaitForSI()) return(I2C_Reset()); 
    STA = 0;
     
    // Send the address with the R/W bit 0
    SMB0DAT = Address * 2;     
    SI = 0;
    if(!WaitForSI()) return(I2C_Reset()); 

    // If there is no acknowledge then drop out for bad address
    if(!ACK) return(I2C_Reset()); 

    // Get the address of the first byte of SubAddr
    cont = SubAddr;

    // Send each byte and wait for transmission
    for(i=0;i<SubAddrSize;i++)
     {
      SMB0DAT = cont[i];
      SI = 0;                         
      if(!WaitForSI()) return(I2C_Reset());  
      if(!ACK) return(I2C_Reset()); 
     };  
   };

  // If there is no subaddress, this is the original start
  // If there is a subaddress, there is no stop, we just restart
  // We must clear SI after the restart so we can wait for the start to complete
  STA = 1;             
  SI = 0;
  if(!WaitForSI()) return(I2C_Reset()); 
  STA = 0;
  
  // Send the address with the R/W bit 1
  SMB0DAT = (Address * 2) + 1;   
  SI = 0;
  if(!WaitForSI()) return(I2C_Reset()); 

  // If there is no acknowledge then drop out for bad address
  if(!ACK) return(I2C_Reset());

  // Get the address of the first byte of content
  cont = Content;

  // Loop for each byte
  for(i=0;i<Count;i++)
   { 
    // Clear SI to start the read
    SI = 0;
    // Wait for the byte to arrive
    if(!WaitForSI()) return(I2C_Reset()+i); 
    // Get the byte
    cont[i] = SMB0DAT;
    // Set ACK except on the last byte
    ACK = (i>=(Count-1)) ? 0 : 1;
   };

  // Last byte has arrived, set STO and clear SI while the last ACK cycle is completing
  // This will end the transaction
  STO = 1;
  SI = 0;  

  // Tech note: Writing STO = 0 is not something we would ever do, but it would also 
  // do bad things.  Let hardware clear STO and try to leave the port alone until it 
  // has had a chance to clear out and complete the stop.  The recovery time should 
  // do this.  This applies to write as well.  This will keep down the rare possibility 
  // of attempting to start over a stop, which is allowed (restart), but also might 
  // cause unexpected settings of the SI bit.  

  // Tech note: See that SI is clear as the absolute last thing done 

  // This is the read recovery time required by some devices
  DELAY_mS;

  // Return success
  return(Count);
 }

/*--------------------------------------------------------------------------*/

/* I2C_RESET clears the I2C port to the idle state and prepares it for
   operation again.  This only clears a stuck port such as resulting from 
   an error on the bus.  It is not clear what any external caller might
   use this for.  Generally there should not be any down side to this call 
   if the port is not doing anything.  The final configuration settings 
   should match those in the configure routine, so the configure routine 
   calls this routine.  The routine returns a 0 for convenience.

   Note: This action will only clear the bus if the master is stuck.  
   If a slave is holding SDA low, the bus is stuck.
*/

BYTE I2C_Reset(void)
 {        
  // Disable the port
  SMB0CF = 0;
  // Wait for anything to clear
  DELAY_mS;
  DELAY_mS;
  // Clear the control register, including SI
  SMB0CN = 0;
  // Enable the port and select the bit rate source as timer 2
  // We often do use the extended setup and hold times (bit 4) 
	// Since we are the only master we don't bother with bus timeouts in general
  // but we do call for bus free detection anyway
  SMB0CF = 0xD6;	 
  // Return value
  return(0);
 } 

/*--------------------------------------------------------------------------*/
/* Module Support Functions                                                 */
/*--------------------------------------------------------------------------*/

/* WAITFORSI establishes a timeout wait for the SI bit.  If the SI bit does
   not set in the timeout period, a 0 is returned.  Otherwise when the wait 
   is completed successfully, a 1 is returned.  The timeout may in some cases 
   have to wait for an acknowledge from a slave with a slow processing time.  
   We wait here for up to 2 seconds.  If something is holding the bus, this 
   should be the last time this loop is called because the caller will check 
   for a hung bus before attempting this call.  The point of this long timeout 
   is to be able to escape an I/O failure.  We do a short delay before first 
   test to allow fast response device activity to not wait long.
*/

BYTE WaitForSI(void)
 {
  WORD timeout = 0;

  // Short response delays
  // Miniature 
  DELAY_uS;
  if(SI) return(1);
  // At least one bit time
  DELAY_10uS;
  DELAY_10uS;

  // Test with timeout
  while(!SI) 
   {
    DELAY_100uS;
    timeout += 1;
    if(timeout > 20000) return(0); 
   };

  // Normal return
  return(1);
 }
   
/*--------------------------------------------------------------------------*/

/* END OF MODULE */




