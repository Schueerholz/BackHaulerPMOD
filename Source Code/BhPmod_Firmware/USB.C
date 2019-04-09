/*--------------------------------------------------------------------------*/
/* USB.C 

   Purpose:  
   
   This task module serves as the application layer task for servicing
   the device specific protocol of USB packets.  USB communication uses
   the SiLabs library.
    
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

/*  NOTES ON THIS VARIANT  

*/

#define _USB_C_

#include "global.h"
#include "delays.h"
#include "app.h"
#include "usb.h"
			
/* Local private functions */
BYTE WaitForUSBIn(void);

/* Local private data */
// Ready bits 
// The USB process uses these to identify status as prescribed by the USB library interrupt.
// The directions are with respect to the host, as standard for USB, despite the names in the library.
bit USB_IN_Ready = 0;
bit USB_OUT_Ready = 0;

// Data to be packaged and sent to the host
BYTE xdata USB_IN_Buffer[64];

// Data received from the host
BYTE xdata USB_OUT_Buffer[64];

// These are the descriptor data for this device
BYTE code USB_StrDesc_CompanyID[]={46,0x03,'A',0,'l',0,'l',0,'i',0,'e',0,'d',0,' ',0,'C',0,'o',0,'m',0,'p',0,'o',0,'n',0,'e',0,'n',0,'t',0,' ',0,'W',0,'o',0,'r',0,'k',0,'s',0};
BYTE code USB_StrDesc_ProductID[]={42,0x03,'B',0,'a',0,'c',0,'k',0,'H',0,'a',0,'u',0,'l',0,'e',0,'r',0,' ',0,'P',0,'M',0,'O',0,'D',0,' ',0,'H',0,'o',0,'s',0,'t',0};
BYTE code USB_StrDesc_SerialNumber[]={8,0x03,'1',0,'0',0,'0',0};
WORD code USB_VendorID = BHPMOD_VENDOR_ID;
WORD code USB_ProductID = BHPMOD_PRODUCT_ID;

/*--------------------------------------------------------------------------*/
/* Module Public Functions                                                  */
/*--------------------------------------------------------------------------*/

/* USB_START initializes the USB interface library.  This will enable the 
   internal interrupt routines and so on.  This will also complete anything 
   else required to prepare the USB hardware and software.

   Note that if we want to run the system at 48MHz (and waste power) then
   we should do that after the USB has had its way with the clocks.  This
   selection is made here for convenience of applications using USB.
*/

void USB_Start(void)
 {              
  // Call library clock initialization routine
  USB_Clock_Start();   							 

  // Call library initialization routine
  USB_Init(USB_VendorID,
           USB_ProductID,
           USB_StrDesc_CompanyID,
           USB_StrDesc_ProductID,
           USB_StrDesc_SerialNumber,
           250,     /* 500mA to give full fexibility */
           0x80,    /* Bus powered device, no wakeup */   
           0x0100   /* Version 1.00 */
          );   
          
  // Allow the API to begin throwing software interrupts
  USB_Int_Enable(); 

  // Show that we are ready to send data to the host
  USB_IN_Ready = 1;

  // Now that the USB has started, we have a 48MHz clock  
  // running the way the USB driver wants it
  // Set our system clock to run at 48MHz
  CLKSEL |= 0x03;

  // Wait for clock to settle 
  DELAY_mS;
  DELAY_mS;
 }

/*--------------------------------------------------------------------------*/

/* USB_PROCESS looks to see if there is an incoming USB command message and 
   passes it to the application in tokenized form.  The device is entirely 
   command/response driven meaning no data are generated for the host 
   except in response to a command from the host.  Therefore, there is 
   no reason to ask if the host is ready for data or reason to send any 
   data from this process.

   If a command is received from the host, the process calls the application
   module command processing function with the token, count, and data.  
   In principal, this could take place directly from the USB library interrupt
   routine.  However, doing it this way makes the command activity synchronous
   to other activity on the device.  That is, if the interrupt routine called
   for command execution, it could happen while the application process is 
   doing something and thus cause confusion.  This way commands are only executed
   when the main loop gets to this point, which is deterministic in device time.
   The host will just have to wait for that to happen, which should not be long
   for properly written device code.  The interrupt routine only processes data
   directly if the application has intentionally entered a data phase.

   This routine will clear the data ready flag before calling the application
   routine because the data ready flag is only relevant to this module and
   only read by this routine.  The flag can be set again soon after the
   application sends a response if the host sends the next command.
   
   By convention, a 1 is returned if anything is done here and a 0 is 
   returned if there was nothing to do.
*/                   
      
BYTE USB_Process(void)
 {  
  // See if there is a packet to consider, and if not then there is nothing to do
  if(!USB_OUT_Ready) return(0);

  // There is a packet to look at
  // Clear the flag for next time
  USB_OUT_Ready = 0;
  // Ask the application to process the message and send any response
  APP_CommandMessage(USB_OUT_Buffer[0], USB_OUT_Buffer[1], &USB_OUT_Buffer[2]);

  // Return that we did something
  return(1);                     
 }

/*--------------------------------------------------------------------------*/

/* USB_SENDRESPONSE sends a response packet over the USB with the token and
   data specified.  This function is used by the application to send
   a response to the host.  A 1/0 response is returned.  Note that NULL data
   is allowed if only the token will be returned.  
   
   This response is limited by the ICD protocol to 64 bytes in total.  This is 
   not a software or hardware limit.  However, it is chosen to coincide with 
   the maximum of 64 bytes that the USB library is design to handle per USB
   transaction, which simplifies data flow at some level.
*/

BYTE USB_SendResponse(BYTE Token, BYTE Count, void *MessageData)
 {
  BYTE i;                    
  BYTE *message = (BYTE *)MessageData;

  // Check arguments
  if(Count > 62) return(0);
  if((Count > 0) && (MessageData == NULL)) return(0);

  // Construct the packet
  USB_IN_Buffer[0] = Token;
  USB_IN_Buffer[1] = Count;

  // Load the data  
  for(i=0;i<Count;i++)
   USB_IN_Buffer[2+i] = message[i];   

  // Send the response
  if(!WaitForUSBIn()) return(0);
  Block_Write(USB_IN_Buffer, Count+2);

  // Return success
  return(1);   
 }

/*--------------------------------------------------------------------------*/

/* USB_SENDSTATUS constructs and sends a status message with the 
   status byte indicated.  This is a specific version of the USB response
   function, the return value of which is returned here.
*/

BYTE USB_SendStatus(BYTE Status)
 {
  return(USB_SendResponse(TOKEN_RESPONSE_STATUS, 1, &Status));
 }

/*--------------------------------------------------------------------------*/

/* USB_DATAINPHASE sends the data in the argument over the USB when possible 
   without any further construction.  This is used by an application to send 
   a block of input data.  

   The size is limited to 4096 based on the published limitation of the USB
   library function.  However, this is unrealistically large for a block of
   data in an 8051 application, so it should never be reached.  The data are
   actually transmitted in 64 byte sections by the library, so the host 
   can not assume that the entire block is received at once.  Similarly the
   host does not assume that data received is only one transaction.  In many 
   cases the device will use this routine to send a known quantity of data and
   immediately follow with something else, like status.  The protocol and host
   code must be constructed in such a way that this is expected.   

   Update - We can and do transfer a full 4096 bytes when we access the data 
   from an external memory address, such as in an FPGA or other external memory.
*/

BYTE USB_DataInPhase(WORD Count, void *MessageData)
 {
  BYTE *message = (BYTE *)MessageData;

  // Check arguments
  if(Count > 4096) return(0);
  if(Count == 0) return(0);

  // Send the data
  if(!WaitForUSBIn()) return(0);
  Block_Write(message, Count);

  // Return success
  return(1);   
 }

/*--------------------------------------------------------------------------*/
/* Module Support Functions                                                 */
/*--------------------------------------------------------------------------*/

/* WAIT_FOR_USB_IN waits up to one second to be able to send data to the host.
   Generally, unless something strange happened this function will return 
   very quickly.  So the fact that there is a wait here is not a concern because
   generally that would mean another exceptional problem has happened.  If the
   wait does fail, a 0 is returned.  A 1 is returned if data can be sent.
*/

BYTE WaitForUSBIn(void)
 {
  WORD timeout;

  for(timeout=0;timeout<1000;timeout++)
   {
    if(USB_IN_Ready) return(1);
    DELAY_mS;
   }; 
  return(0);
 }

/*--------------------------------------------------------------------------*/

/* USB_API_ISR is the interrupt service routine for software interrupts 
   thrown by the USB library.  It is up to this routine to determine what
   the library has discovered and handle data as appropriate.

   It is not clear if this is a traditional interrupt routine or more of 
   a callback routine.  It's function is like a callback routine which 
   indicates when an I/O activity has completed.  Anyway, enabling the 
   interrupt is handled by a call to a library function.   
*/

void USB_API_ISR(void) interrupt 17       
 {          
  BYTE IntReasonCode = Get_Interrupt_Source();  // Library call for source 
  BYTE count;

  // TX completion (to host)  
  if(IntReasonCode & TX_COMPLETE) USB_IN_Ready = 1; 

  // RX completion (from host)
  // Note that we must get data here because returning from this service routine 
  // will make the USB library believe it can accept more out data.  Normally, in 
  // command/response mode this is not an issue because no other out data will arrive 
  // until the device responds.  Thus we just copy the data and set the ready flag.
  // If data are expected back to back (like in a data phase), then they must be 
  // processed from here.  In that case, this step will not set the ready flag but
  // load the buffer and call the application data phase routine to dispatch the 
  // appropriate action.  This stops when the data phase routine sets the global 
  // flag to 0 again.  
  if(IntReasonCode & RX_COMPLETE)    
   {
    // Get the data
    count = Block_Read(USB_OUT_Buffer, 64);
    // If we are in the data phase, call the application data phase routine
    // If not, then just set the data ready flag
    if(USB_DataOutPhase) 
     APP_DataOutPhase(count, USB_OUT_Buffer);
    else 
     USB_OUT_Ready = 1;
   };

  // Device configuration complete service
  if(IntReasonCode & DEV_CONFIGURED)
   {
    // If bus powered, the device can now use as much bus power as requested
    // If self powered, we don't care about this
   };

  // Device suspend service
  if(IntReasonCode & DEV_SUSPEND)
   {
    // Nominally we should turn down our power and 
    // call the library to put the USB system in suspend state.
    // This can be safely ignored for self powered devices.

    // Turn down power of system by call from here

    // In this application we don't have any control, so we don't really support suspend

    // Call USB system suspend, which stops us here and returns upon resume
    // USB_Suspend();  

    // We are out of suspend, so turn our system back on by call from here
   };
 }

/*--------------------------------------------------------------------------*/

/* END OF MODULE */




