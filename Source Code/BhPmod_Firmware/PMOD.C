/*--------------------------------------------------------------------------*/
/* PMOD.C 

   Purpose:
   
   This driver module provides a means of configuring the PMOD
   connector interface and operating discrete pins.
    
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

#define _PMOD_C_

#include "global.h"
#include "delays.h"
#include "pmod.h"

/* Local private functions */

/* Local private data */

/*--------------------------------------------------------------------------*/
/* Module Public Functions                                                  */
/*--------------------------------------------------------------------------*/

/* PMOD_CONFIGURE prepares the interface for operation.  Nominally there is
   nothing to do here, but for good measure we simply reset the interface
   even though that effort is generally duplicative.
*/

void PMOD_Configure(void)
 {
  PMOD_SetConfiguration(PMOD_CONFIGURATION_IO_ONLY);
 }

/*--------------------------------------------------------------------------*/

/* PMOD_SETCONFIGURATION establishes the configuration and signal routing 
   of to the PMOD connector based on the argument, which should be one of 
   the configurations specified in the ICD.  If the argument is invalid,
   then the default is set per requirement of the ICD.

   Notes on PMOD_CONFIGURATION_IO_ONLY (Default) -
   This configuration is the lowest energy and most benign setting.  All 
   peripherals are disconnected from the pins and the I/O are set to passive 
   pull-up state.  This is the same as the power on state.  And yes the code 
   could be shared, but that violates normal procedure flow of this software 
   structure, not all registers need to be addressed here as some are never 
   changed, and a different order could be important here.

   Notes on PMOD_CONFIGURATION_SPI -
   Note that in the baseline, the SPI peripheral chip selection function is
   left as a discrete I/O (3 wire SPI).  This means that this signal must be
   protected from inadvertent operation by a discrete I/O means, as done
   elsewhere in this module.

   Notes on PMOD_CONFIGURATION_I2C -
   Note that PMOD peripherals usually join pins 3-9, and 4-10, so discrete I/O must 
   be prevented from causing interference in this way, as done elsewhere in this module.

   Notes on PMOD_CONFIGURATION_SERIAL -
   Note that in the baseline, the CTS/RTS functions are not handled by the serial driver.  
   Although they could be added to that driver, the need is not common.  They can be used
   as digital I/O directly from the host.  Implementing them in the driver would take the 
   same approach, just a bit more automatically at the embedded level as would be required 
   if actually used for handshaking.  However, note that which is input or output may
   also depend on wiring of the peripheral, which often does not fully appreciate strict 
   definitions of DTE and DCE, or may itself be configurable.  At the level of this routine, 
   nothing is done with these pins, leaving that configuration step to the handshaking code, 
   if and where implemented.  The pins will be left in as passive pull-up here, generally 
   being an inactive state for these pins.  This default behaviour also protects marginally 
   compliant PMOD peripherals that may do unexpected things with these pins.
*/

void PMOD_SetConfiguration(BYTE Configuration)
 {
  // Start by setting the default IO_ONLY configuration to clear any configuration already established
  // Make all pins more benign (not push-pull)
  P0MDOUT = 0x00;      
  P1MDOUT = 0x00;         
  // Set the output registers high (will be passive pull up when no peripheral is using it)
  P0 = 0xFF;     
  P1 = 0xFF;        
  // Take all the peripherals off the pins
  XBR0 = 0x00;
  // There are no pins routed out, so nothing needs to be skipped 
  P0SKIP = 0x00;      

  // Set the differences for specific configurations
  switch(Configuration)
   {
    case PMOD_CONFIGURATION_SPI: 
     // Set the chip SPI outputs and chip select to push-pull 
     P0MDOUT = 0x0D;  
     // Route the peripheral to the pins
     XBR0 = 0x02; 
     break;   

    case PMOD_CONFIGURATION_I2C:
     // Push the skips so the the peripheral will show up on the right port pins
     P0SKIP = 0xFF;  
     // Route the peripheral to the pins
     XBR0 = 0x04;
     break;   

    case PMOD_CONFIGURATION_SERIAL: 
		 // Set transmit pin to push-pull
		 // Others including handshake signals remain passive for later determination by user
     P0MDOUT = 0x10;		
     // Route the peripheral to the pins
     XBR0 = 0x01; 
     break;   
   };
 }

/*--------------------------------------------------------------------------*/
 
/* PMOD_SETPINDRIVE sets the output drive of a specified pin on the PMOD connector 
   to be push pull or not (1 or 0 respectively).  More specifically, this sets the 
   associated bit in PnMDOUT register output register, which may or may not change the 
   state of the pin depending on how else that pin is being used.  It will not impact 
   the operation of a peripheral using that pin, and the setting will be effectively 
   ignored.  It could set up a new opportunity to fight an external driver of that pin, 
   albeit with a small resistor in the way on the board. No error reporting is done at 
   this level, so if a pin is not valid nothing happens.
   
   This routine follows the same exception rules as changing the state of the pin 
   as described with the PMOD_SetPinState function.   
*/ 

void PMOD_SetPinDrive(BYTE PinNumber, BYTE PushPull)
 {
  // Force the meaning of the argument to binary
  bit bstate = PushPull ? 1 : 0; 
  
  // Check for exceptions
  if(PMOD_USING_SERIAL && ((PinNumber == 2) || (PinNumber == 3))) return;
  if(PMOD_USING_I2C && ((PinNumber == 3) || (PinNumber == 4))) return;
  if(PMOD_USING_SPI && (PinNumber == 1)) return;
    
  // Set the pin push-pull control
  // It is unfortunate that these registers are not bit addressable
  // so this code will need to be maintained seperately and carefully
  switch(PinNumber)
   {
    case  1: if (bstate) P0MDOUT |= 0x08; else P0MDOUT &= ~0x08; break;
    case  2: if (bstate) P0MDOUT |= 0x04; else P0MDOUT &= ~0x04; break;
    case  3: if (bstate) P0MDOUT |= 0x02; else P0MDOUT &= ~0x02; break;
    case  4: if (bstate) P0MDOUT |= 0x01; else P0MDOUT &= ~0x01; break;
    case  7: if (bstate) P0MDOUT |= 0x80; else P0MDOUT &= ~0x80; break;
    case  8: if (bstate) P0MDOUT |= 0x40; else P0MDOUT &= ~0x40; break;
    case  9: if (bstate) P1MDOUT |= 0x02; else P1MDOUT &= ~0x02; break;
    case 10: if (bstate) P1MDOUT |= 0x01; else P1MDOUT &= ~0x01; break;
   }; 
 }

/*--------------------------------------------------------------------------*/

/* PMOD_SETPINSTATE attempts to set the specified pin on the PMOD connector 
   to the specified state (1/0).  More specifically, this sets the associated 
   bit in the output register, which may or may not change the state of the 
   pin depending on how else that pin is being used.  It will not impact the 
   operation of a peripheral using that pin, and the setting will be effectively 
   ignored.  It will fight with an external driver of that pin, albeit with a 
   small resistor in the way on the board.  No error reporting is done at this 
   level, so if a pin is not valid nothing happens.
   
   Exceptions - 
   1) PIN2 and PIN3 are shared, so this function will do nothing if those pins 
      are involved and the serial port is in use. If SPI is in use, the register 
      will be set but nothing will happen.
   2) PIN3 and PIN4 are generally connected to PIN9 and PIN10 on an I2C PMOD 
      peripheral, so this function will do nothing if those pins are involved 
      and I2C is in use.  If pin 9 or 10 is activated in this way, the register 
      will be set but nothing will happen.
   3) In SPI mode, PIN1 is reserved for chip select, so this function will do 
      nothing if that pin is involved and SPI is in use.
*/

void PMOD_SetPinState(BYTE PinNumber, BYTE State)
 {
  // Force the meaning of the argument to binary
  bit bstate = State ? 1 : 0; 
  
  // Check for exceptions
  if(PMOD_USING_SERIAL && ((PinNumber == 2) || (PinNumber == 3))) return;
  if(PMOD_USING_I2C && ((PinNumber == 3) || (PinNumber == 4))) return;
  if(PMOD_USING_SPI && (PinNumber == 1)) return;
     
  // Set the pin bit
  switch(PinNumber)
   {
    case  1: PMOD_HW_PIN1 = bstate; break;
    case  2: PMOD_HW_PIN2 = bstate; break;
    case  3: PMOD_HW_PIN3 = bstate; break;
    case  4: PMOD_HW_PIN4 = bstate; break;
    case  7: PMOD_HW_PIN7 = bstate; break;
    case  8: PMOD_HW_PIN8 = bstate; break;
    case  9: PMOD_HW_PIN9 = bstate; break;
    case 10: PMOD_HW_PIN10 = bstate; break;
   };
 } 
 
/*--------------------------------------------------------------------------*/

/* PMOD_GETPINSTATE returns the state (1/0) of the specified pin of the PMOD connector.
   The pin state can always be read, but its meaning my be limited if the pin is in 
   use by a peripheral.  No error reporting is done at this level.  If the pin is 
   not valid, then the return value will be 0 and mean nothing.
*/ 

void PMOD_GetPinState(BYTE PinNumber, BYTE *State)
 {
  // Check return argument
  if(State == NULL) return;
  // Default state on any error is 0
  *State = 0;
  // Look for pin input 
  switch(PinNumber)
   {
    case  1: *State = PMOD_HW_PIN1; break;
    case  2: *State = PMOD_HW_PIN2; break;
    case  3: *State = PMOD_HW_PIN3; break;
    case  4: *State = PMOD_HW_PIN4; break;
    case  7: *State = PMOD_HW_PIN7; break;
    case  8: *State = PMOD_HW_PIN8; break;
    case  9: *State = PMOD_HW_PIN9; break;
    case 10: *State = PMOD_HW_PIN10; break;   
   };
 }
 
/*--------------------------------------------------------------------------*/

/* END OF MODULE */




