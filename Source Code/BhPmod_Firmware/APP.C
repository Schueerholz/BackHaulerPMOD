/*--------------------------------------------------------------------------*/
/* APP.C
 
   Application module for Backhauler PMOD host baseline  

   Original Author: Mark A. Shaw

   Copyright (C) 2013 Allied Component Works                                
   
   This specific variant of the Allied Component Works embedded code 
   baseline is assigned to the exclusive benefit of -					 
   
   Open source community using Backhauler PMOD   				 
   
   See additional conditions with tool kit code components. 
   
   See global.h for version information.   
   
   Structure:
   
   This is a TASK module per definition of Allied Component Works
   cooperative multitasking embedded code architecture.  The routine
   <task>_Start() must exist even if there is nothing in it, and
   it must be called early in code execution, dependant on application 
   architecture but before any other routine in this module is called.
   The start routine must be called after all driver dependencies are
   configured.  The routine <task>_Process() must exist and is called
   in round robin from the main executive.  This routine must complete 
   a minimum number of operations and return to the main executive, 
   thus "cooperating" on use of time.  This routine returns 1 if it 
   does something and 0 if it does nothing.  Finally, service routines 
   may exist which generally implement high level application features.  
   Some such routines may be exported, and if so will follow the 
   <task>_<name>() naming convention.
   
   The original tool chain is Kiel for the 8051 architecture.
   
   Rules for application:
   
   The authorship shall be void if ANY portion of this file is modified.  
   The original author disclaims all copyrights or any association at all 
   with any such derivative works.  However, the original and any usage 
   for the same purpose shall otherwise remain under copyright as shown
   above, with all rights reserved.

   See additional conditions with tool kit code components such as 
   drivers and general purpose task modules.
   
   Derivative author comments here -
   < must be filled in if authored by other than Allied Component Works >  
*/
/*--------------------------------------------------------------------------*/

/* NOTES UNIQUE TO THIS APP
   
*/

#define _APP_C_

#include "global.h"
#include "delays.h"
#include "timer.h"
#include "spi.h"
#include "i2c.h"
#include "serial.h"
#include "pmod.h"
#include "usb.h"
#include "app.h"
			
/* Local private functions */
void TestCode(BYTE *MessageData);

/* Local private data */

// Grant peek/poke access to xdata space with a base pointer
volatile BYTE xdata XDATA_Base _at_ 0x0000;
#define XDATA_AsArray (&XDATA_Base) 

/*--------------------------------------------------------------------------*/
/* Module Public Functions                                                  */
/*--------------------------------------------------------------------------*/

/* APP_START performs any task needed to prepare the device for use.
   
*/

void APP_Start(void)
 {   	   
  
 }

/*--------------------------------------------------------------------------*/

/* APP_PROCESS dispatches application activities.  In a device that is 
   more or less strictly host driven, there really are no local activities
   to perform.  But if there were such activities, this is where they would
   happen or be launched.  By convention this routine returns a 1 if it 
   does anything and a 0 if it does nothing.  

*/                   
  
BYTE APP_Process(void)
 { 
  // Moderate the speed of the main loop
  DELAY_mS;
  
  // Return an indication that something was done
  return(1);                  
 }

/*--------------------------------------------------------------------------*/

/* APP_COMMANDMESSAGE accepts a command as received from a command source
   such as USB and processes its contents.  This is the location where the
   token is interpreted and the appropriate action dispatched.  Usually this
   will involve calling a service routine.  The response is sent by calling
   a USB module response function.  

   Important - The MessageData argument should point to memory large enough
   to receive the largest possible (62 byte) read message.  This is the 
   default case for USB, but should be checked.  This saves memory over 
   creating yet another buffer.  This pointer is only provided by the
   embedded code, so the validity of the pointer is not checked in order
   to save processing time.  
*/

void APP_CommandMessage(BYTE Token, BYTE Count, BYTE *MessageData)
 { 
  BYTE rdcnt, wrcnt;

  // Check argument
  if(Count > 62)
   {
    USB_SendStatus(APP_Status | STATUS_BIT_ERROR);
    return;
   };

  // Interpret token
  switch(Token)
   {  
    case TOKEN_COMMAND_PMOD_SET_PIN_DRIVE:
     // Check arguments and error if not well formed
     if(Count != 2) { APP_SendStatusCommandModeError(); break; }; 
     // Direct call to PMOD driver
     PMOD_SetPinDrive(MessageData[0], MessageData[1]);
     // Status response
     APP_SendStatusCommandMode();
     break;

    case TOKEN_COMMAND_PMOD_WRITE_PIN:
     // Check arguments and error if not well formed
     if(Count != 2) { APP_SendStatusCommandModeError(); break; }; 
     // Direct call to PMOD driver
     PMOD_SetPinState(MessageData[0], MessageData[1]);
     // Status response
     APP_SendStatusCommandMode();
     break;

    case TOKEN_COMMAND_PMOD_READ_PIN:
     // Check arguments and error if not well formed
     if(Count != 1) { APP_SendStatusCommandModeError(); break; }; 
     // Direct call to PMOD driver
     PMOD_GetPinState(MessageData[0], MessageData);
     // Pin state response
     USB_SendResponse(TOKEN_RESPONSE_PMOD_READ_PIN, 1, MessageData); 
     break;

    case TOKEN_COMMAND_PMOD_SET_CONFIGURATION:
     // Check arguments and error if not well formed
     if(Count != 1) { APP_SendStatusCommandModeError(); break; }; 
     // Select configuration of the PMOD connector by call to PMOD driver
     // If the argument is not valid, the driver just sets the default
     PMOD_SetConfiguration(MessageData[0]);
     // Status response
     APP_SendStatusCommandMode();
     break;

    case TOKEN_COMMAND_SET_SPI_CLOCK_PHASE:
     // Check arguments and error if not well formed
     if(Count != 1) { APP_SendStatusCommandModeError(); break; }; 
     // Select clock phase at any time by call to SPI driver
     // If the argument is not valid, the driver just sets the default
     SPI_SetClockPhase(MessageData[0]);
     // Status response
     APP_SendStatusCommandMode();
     break;

    case TOKEN_COMMMAND_SPI_TRANSACTION:
     // If we are in SPI mode, proceed with normal transaction 
     // Otherwise, just return an echo with 0 data bytes
     // A count of 0 is well formed but is a nop
     if(PMOD_USING_SPI && (Count != 0))
      // Standard pass through SPI transaction
      Count = SPI_Transaction(Count, MessageData, MessageData); 
     else
      Count = 0;
     USB_SendResponse(TOKEN_RESPONSE_SPI_TRANSACTION, Count, MessageData); 
     break;

    case TOKEN_COMMAND_I2C_WRITE:
     // I2C message bytes per ICD -
     // 0 = Device address
     // 1 = Subaddress size
     // 2,3 = Subaddress (8-bit use 2, 16-bit use both with high byte in 2)
     // 4 = Count of I2C data bytes (return value will be number actually written)
     // 5+ = Content
     // Check arguments and error if not well formed
     if(Count < 5) { APP_SendStatusCommandModeError(); break; }; 
     // If we are in I2C mode, proceed with normal transaction 
     // Otherwise, just return an echo with 0 data bytes
     if(PMOD_USING_I2C)
      {
       // Normal
       wrcnt = I2C_Write(MessageData[0], MessageData[1], &MessageData[2], MessageData[4], &MessageData[5]);
       MessageData[4] = wrcnt;
       Count = 5 + wrcnt;
      }
     else
      {
       // Nop
       MessageData[4] = 0;
       Count = 5;
      };
     // Return response       
     USB_SendResponse(TOKEN_RESPONSE_I2C_WRITE, Count, MessageData); 
     break;
     
    case TOKEN_COMMAND_I2C_READ:
     // I2C message bytes per ICD -
     // 0 = Device address
     // 1 = Subaddress size
     // 2,3 = Subaddress (8-bit use 2, 16-bit use both with high byte in 2)
     // 4 = Count of I2C data bytes (return value will be number actually read)
     // 5+ = Content
     // Check arguments and error if not well formed
     if(Count < 5) { APP_SendStatusCommandModeError(); break; }; 
     // If we are in I2C mode, proceed with normal transaction 
     // Otherwise, just return an echo with 0 data bytes
     if(PMOD_USING_I2C)
      {
       // Normal
       rdcnt = I2C_Read(MessageData[0], MessageData[1], &MessageData[2], MessageData[4], &MessageData[5]);
       MessageData[4] = rdcnt;
       Count = 5 + rdcnt;
      }
     else
      {
       // Nop
       MessageData[4] = 0;
       Count = 5;
      };
     // Return response       
     USB_SendResponse(TOKEN_RESPONSE_I2C_READ, Count, MessageData); 
     break; 

    case TOKEN_COMMAND_SERIAL_WRITE:
     // Send bytes to serial port
     // If we are in serial mode, proceed with normal transaction 
     // Otherwise, just respond with 0 data bytes
     if(PMOD_USING_SERIAL)
      Count = SERIAL_SendString(SERIAL_PORT_UART0, Count, MessageData);
     else
      Count = 0;
     // Return response       
     USB_SendResponse(TOKEN_RESPONSE_SERIAL_WRITE, Count, MessageData);        
     break;

    case TOKEN_COMMAND_SERIAL_READ:
     // Read bytes from serial port
     // If we are in serial mode, proceed with normal transaction 
     // Otherwise, just respond with 0 data bytes
     if(PMOD_USING_SERIAL)
      {
       rdcnt = 0;
       while((rdcnt < Count) && SERIAL_SeekByte(SERIAL_PORT_UART0, NULL))
        {
         SERIAL_GetByte(SERIAL_PORT_UART0, &MessageData[rdcnt]);       
         rdcnt += 1;
        };
       Count = rdcnt;
      }
     else
      Count = 0;
     // Return response       
     USB_SendResponse(TOKEN_RESPONSE_SERIAL_READ, Count, MessageData);           
     break;

    case TOKEN_COMMAND_GET_STATUS:
     // General get status
     APP_SendStatusCommandMode();
     break;

    case TOKEN_COMMAND_TEST:
     // Debug messages
     TestCode(MessageData);
     break;

    default:
     // Not recognized
     APP_SendStatusCommandModeError();
   };
 }

/*--------------------------------------------------------------------------*/

/* APP_SENDSTATUSCOMMANDMODE constructs and sends an application status message
   including status of various elements for the case where command mode
   is active.  The status is held globally so that temporary status changes,
   such as a command error, can be added to this status without seeking 
   the entire status again.  Exceptional conditions may rewrite the entire
   application status global.
*/

void APP_SendStatusCommandMode(void)
 {
  APP_Status = STATUS_BIT_COMMAND_MODE_READY | STATUS_BIT_POWER_ON;
  USB_SendStatus(APP_Status);  
 }

/*--------------------------------------------------------------------------*/

/* APP_SENDSTATUSCOMMANDMODEERROR constructs and sends an application status 
   message with the error bit set and including status of various elements 
   for the case where command mode is active.  The status is held globally 
   so that temporary status changes can be added to this status without seeking 
   the entire status again.  Exceptional conditions may rewrite the entire
   application status global.  A zero is returned for convenience.
*/

BYTE APP_SendStatusCommandModeError(void)
 {
  APP_Status = STATUS_BIT_COMMAND_MODE_READY | STATUS_BIT_ERROR | STATUS_BIT_POWER_ON;
  USB_SendStatus(APP_Status);  
  return(0);
 }

/*--------------------------------------------------------------------------*/

/* APP_DATAOUTPHASE will receive raw data packets from the host through the 
   USB module when the application has set to the global USB_DataOutPhase bit.  
   This bit must be cleared here to return to command/response mode.  Some 
   devices do not use this functionality because they do not use large blocks 
   of data from the host.
   
   An example is using this to send data to the FPGA driver.  The driver exports 
   a register indicating what to call.  Remember, passing through this module 
   keeps the USB module generic.
*/

void APP_DataOutPhase(BYTE Count, BYTE *MessageData)
 {
  Count = MessageData[0];
 }
 
/*--------------------------------------------------------------------------*/
/* Module Support Functions                                                 */
/*--------------------------------------------------------------------------*/

/* TESTCODE is a location for trying out hardware in a non-production way.
   The test code token passes a number of bytes here which can be anything
   and is defined only here and in the corresponding data controller 
   test code routine.  Any manner of response can come from here too, again
   only controlled by test code developers.  There is essentially no error
   checking here, so this is not acceptable for any production code.
*/

void TestCode(BYTE *MessageData)
 {
  BYTE test_number = MessageData[0];
  WORD addr;
  //LWORD wval;
  BYTE buf[10];

  // For test that need an address
  addr = MAKEWORD(MessageData[2], MessageData[1]);
       
  // Interpret test number
  switch(test_number)
   {
    case 0:
     break;

    case 1: 
     break;

    case 90:
     // Poke xdata
     XDATA_AsArray[addr] = MessageData[3];
     break;

    case 91:
     // Peek xdata
     buf[0] = XDATA_AsArray[addr];
     USB_SendResponse(TOKEN_RESPONSE_TEST, 1, buf);        
     break;

    case 100:
     // Call potentially unreferenced routines to avoid linker warnings
     SERIAL_Print(SERIAL_PORT_UART0, NULL);
     SERIAL_SendString(SERIAL_PORT_UART0, 0, NULL);
     USB_DataInPhase(0, NULL);
     test_number = HexTable[0]; 
     break;
   };             
 }

/*--------------------------------------------------------------------------*/

/* END OF MODULE */




