/*--------------------------------------------------------------------------*/
/* SERIAL.C 

   Purpose:
   
   Manage one or more asynchronous serial ports on a SiLabs 8051 part or
   other embedded device with serial ports.  The hardware specific aspects
   are built into variants of this module.  This module is designed so that 
   multiple ports can be handled, and this architecture is maintained even 
   if there is only one port in the system, even if that makes the code 
   awkward in places.  The configuration depends on certain hardware and 
   generally on system clock speed.  This module also depends on certain 
   global settings for I/O and interrupts.  Global interrupt enable is not 
   set or cleared by this module.     
   
   The primary reason for using interrupts and software buffers in the 
   serial port driver is because serial ports typically have limited buffer
   memory and often do not include flow control.  This driver in effect 
   expands the buffer memory, but it is still up to the user of the port 
   to collect the data before an overrun of the driver buffer occurs.
   On transmitting data it is useful that the caller typically does not
   have to wait for the serial port hardware, but the caller must still 
   be aware that the serial port may still be working on the data 
   after the call returns from the driver.
      
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
   at Allied Component Works, Gaitersburg, MD, USA.  The original shall 
   thus be Copyright (C) 2013 Allied Component Works per the above terms. 
   This authorship shall be void if ANY portion of this file is modified.  
   The original author disclaims all copyrights or any association at all 
   with any such derivative works.  However, the original shall remain
   free as described here.
   
   Derivative author comments here -
   < must be filled in if authored by other than Allied Component Works >
*/   
/*--------------------------------------------------------------------------*/

#define _SERIAL_C_

#include "global.h"
#include "delays.h"
#include "serial.h"

/* Local private functions */


/* Local private definitions and macros */

// Standardize SFR definitions versus specific target 
#define	SCON_UART0              SCON0
#define SBUF_UART0              SBUF0
#define RI_UART0                RI0
#define TI_UART0                TI0
#define S_UART0_CLR_RI          {RI_UART0 = 0;}
#define S_UART0_CLR_TI          {TI_UART0 = 0;}
#define S_UART0_SET_TI          {TI_UART0 = 1;}

// Buffer direction identifiers
#define S_BUF_UART0_TX          0
#define S_BUF_UART0_RX          1

#define S_BUF_DIR_TX            0
#define S_BUF_DIR_RX            1

#define NUM_SERIAL_PORTS        1

#define S_BUF_ID(port_id, dir)  ((port_id*2) + dir)

// Buffer macro definitions
#define S_BUF_FULL(bufid) \
 ( \
  (s_buf_head_ptr[bufid] == s_buf_tail_ptr[bufid] - 1) || \
  (s_buf_head_ptr[bufid] == (s_buf_depth[bufid]-1) && s_buf_tail_ptr[bufid] == 0) \
 )

#define S_BUF_EMPTY(bufid) \
 ( \
  s_buf_tail_ptr[bufid] == s_buf_head_ptr[bufid] \
 )

#define S_BUF_RESET(bufid) \
 { \
  s_buf_tail_ptr[bufid] = s_buf_head_ptr[bufid] = 0; \
 }

#define S_BUF_PUT(bufid, dat) \
 { \
  s_buf[bufid][s_buf_head_ptr[bufid]] = dat; \
  if(s_buf_head_ptr[bufid] == s_buf_depth[bufid]-1) \
   s_buf_head_ptr[bufid] = 0; \
  else \
   s_buf_head_ptr[bufid] += 1; \
 }

#define S_BUF_GET(bufid, dat) \
 { \
  dat = s_buf[bufid][s_buf_tail_ptr[bufid]]; \
  if(s_buf_tail_ptr[bufid] == s_buf_depth[bufid]-1) \
   s_buf_tail_ptr[bufid] = 0; \
  else \
   s_buf_tail_ptr[bufid] += 1; \
 }

#define S_BUF_PEEK(bufid, dat) \
 { \
  dat = s_buf[bufid][s_buf_tail_ptr[bufid]]; \
 }

/* Note on interrupts and buffers:  Interrupts are not disabled while moving 
   data in and out of the serial buffers.  This is because the interrupt routine 
   will always work with the opposite pointer versus the driver routine.
   The buffer macros are carefully structured so that data are placed before 
   pointers are moved and pointer assignments are never out of range or otherwise
   illegal while in the middle of a macro.  It is not easy to disable interrupts 
   as part of the macro, because there are some instances in which it is required 
   for other reasons that interrupts not be enabled on exit.  However, in general
   it is recommended that interrupts be disabled while buffers are examined and 
   manipulated.
*/

/* Serial Buffers 

   The buffers are subsections of memory pointed to by the *s_buf[] array of pointers.  
   These pointers are initialized as required in the configuration routine.  The buffers 
   can be dereferenced as a two dimensional array even in cases where the rows do 
   not all have the same number of columns (such as different size buffers in the set).  

   s_buf[(NUM_SERIAL_PORTS*2)][s_buf_depth[]] = | UART 0 port tx | UART 0 port rx | UART 1 port tx | UART 1 port rx | 
   UART 0 is identified as SERIAL_PORT_UART0
   UART 1 is identified as SERIAL_PORT_UART1 (does not exist in this version)

   The depths are defined by the s_buf_depth constant array for the benefit of the 
   buffer macros.  Only buffer macros ultimately access these arrays.

   The location of the buffer is reserved by declaring an array of the appropriate 
   length for the benefit of the compiler.  The configuration routine deposits 
   relative address values for use by the buffer macros.
*/
volatile BYTE xdata *s_buf[(NUM_SERIAL_PORTS*2)];
BYTE code s_buf_depth[(NUM_SERIAL_PORTS*2)] = { 128, 128 };
volatile BYTE xdata serial_buffer_memory[256];

/* The pointers are indexes into the buffer arrays */
volatile BYTE data s_buf_head_ptr[NUM_SERIAL_PORTS*2];
volatile BYTE data s_buf_tail_ptr[NUM_SERIAL_PORTS*2];

/* Software internal flow control bits */
volatile bit bdata S_UART0_tx_active = 0;

/* The following macros operate local interrupts for all serial ports.  These are 
   typically required to pause interrupts for a routine to manipulate the buffers 
   in some way.  This could be on the basis of individual ports, but when there 
   are few ports we just operate all of the associated interrupt enables.
*/
#define SERIAL_DI   {ES0 = 0;}
#define SERIAL_EI   {ES0 = 1;}

/*--------------------------------------------------------------------------*/
/* Module Public Functions                                                  */
/*--------------------------------------------------------------------------*/

/* SERIAL_CONFIGURE prepares the buffer and serial port hardware for 
   normal operation.  Interrupts are enabled in the main routine to 
   coordinate operation with other needs.
*/

void SERIAL_Configure(void)
 {
  /* Assign locations of serial buffers */
  s_buf[S_BUF_UART0_TX] = (BYTE xdata *)serial_buffer_memory; 
  s_buf[S_BUF_UART0_RX] = s_buf[S_BUF_UART0_TX] + s_buf_depth[S_BUF_UART0_TX]; 

  /* Initialize serial ports */
  
  // SERIAL_PORT_UART0
  // Setup baud rate generator  
  // In this application we are looking for 9600 baud from a 48MHz system clock (assuming USB is running)
  // We are using timer 1 - take care with CKCON
  TMOD = 0x20;    // Timer 1 by CKCON
  CKCON &= 0xF4;  // Source is SYSLCK/48 = 1MHz
  CKCON |= 0x02;
  TH1 = 204;      // Baud rate will be 9600 as a result
  TCON = 0x40;    // Enable timer 1
  // Enable the serial port
  SCON0 = 0x10;  
  
  /* Reset all the ports */
  // Note that the local port interrupt is enabled by this call
  // Global interrupt enable is not set or cleared by this module
  SERIAL_Reset(SERIAL_PORT_UART0);
 }

/*--------------------------------------------------------------------------*/

/* SERIAL_SEEKBYTE tests to see if there is a byte available on the 
   specified serial port and returns a 1/0 response.  Any byte found
   is returned by reference but is left on the buffer for other uses.  
   If the dat argument is NULL, then the byte is not returned and 
   only the status is returned.

   This routine must disable serial interrupts while it accesses
   the buffers. Serial interrupts will be enabled on exit.
*/

BYTE SERIAL_SeekByte(BYTE port_id, BYTE *dat)
 {
  BYTE rxbuf = S_BUF_ID(port_id, S_BUF_DIR_RX);

  /* If selected buffer not valid, return failure */
  if(port_id >= NUM_SERIAL_PORTS) return(0);  

  /* Disable interrupts to avoid conflicts */
  SERIAL_DI;

  /* If the buffer is empty, return 0 */
  if(S_BUF_EMPTY(rxbuf)) { SERIAL_EI; return(0); };

  /* If there is something, and we want to know, catch the first character */
  if(dat != NULL) S_BUF_PEEK(rxbuf, *dat);

  /* Enable interrupts */
  SERIAL_EI;

  /* Return 1 to indicate that there is a byte there */
  return(1);
 }

/*--------------------------------------------------------------------------*/

/* SERIAL_GETBYTE attempts to collect a single byte from the specified 
   serial port.  If a byte is available, it is returned by reference in the
   argument *dat and a 1 is returned by value.  If no byte is available, 
   a 0 is returned by value.  This function does not wait for a byte. 

   This routine must disable serial interrupts while it manipulates 
   the buffers.  Serial interrupts will be enabled on exit.
*/

BYTE SERIAL_GetByte(BYTE port_id, BYTE *dat) 
 { 
  BYTE rxbuf = S_BUF_ID(port_id, S_BUF_DIR_RX);
   
  /* If selected buffer not valid, return failure */
  if(port_id >= NUM_SERIAL_PORTS) return(0);  
  if(dat == NULL) return(0);
    
  /* Disable interrupts to avoid conflicts */
  SERIAL_DI;

  /* Look for data in selected buffer */
  if(S_BUF_EMPTY(rxbuf)) { SERIAL_EI; return(0); };
 
  /* If there are any data, return first byte */
  S_BUF_GET(rxbuf, *dat);

  /* Renable interrupts */
  SERIAL_EI;

  /* Return success */     
  return(1);
 }

/*--------------------------------------------------------------------------*/

/* SERIAL_SENDBYTE waits for the specified serial port to have room available 
   for a new byte.  It then sends the byte in the data argument to the port.
   If the byte added represents the bottom of the queue, the byte is manually 
   installed and the port enabled to start the interrupt process.

   This routine must disable serial interrupts while it manipulates 
   the buffers.  Serial interrupts will be enabled on exit.
*/

BYTE SERIAL_SendByte(BYTE port_id, BYTE *dat)
 {
  BYTE txbuf = S_BUF_ID(port_id, S_BUF_DIR_TX);
  BOOL full = FALSE;

  /* If selected, buffer not valid, return failure */
  if(port_id >= NUM_SERIAL_PORTS) return(0);  
  if(dat == NULL) return(0);

  /* Wait for room in selected buffer */
  /* If we are full on entry we expect an interrupt to remove bytes */
  do
   {
    SERIAL_DI;
    full = (S_BUF_FULL(txbuf)) ? TRUE : FALSE;        
    if(full) { SERIAL_EI; DELAY_mS; DELAY_mS; };
   }
  while(full);

  /* Do not allow interrupts while this is happening to avoid confusion */
  /* Based on above this should already be true */
  SERIAL_DI;  

  /* Install the byte on the buffer */
  S_BUF_PUT(txbuf, *dat);

  /* Proceed based on condition of port and interrupt operations */
  /* On first byte, start the flow manually by causing a transmit interrupt */
  /* Do any other step needed to enable data flow */
  /* Slightly different for each port */
  switch(port_id)
   {
    case SERIAL_PORT_UART0:
     if(!S_UART0_tx_active)  
      { /* First byte on dry port */
       S_UART0_tx_active = 1;
       /* Set interrupt to cause byte to be taken when interrupts enabled */
       S_UART0_SET_TI;
      };
     break;

    // This structure is more useful with multiple ports
   };       

  /* Enable interrupts - this may cause an interrupt */
  SERIAL_EI;

  /* Allow down time to capture any near term interrupts */
  DELAY_uS;

  /* Return success */
  return(1);   
 }

/*--------------------------------------------------------------------------*/

/* SERIAL_SENDSTRING sends length bytes from the the *dat buffer to the 
   specified serial port.  The routine does not return until all 
   bytes are sent unless an unrecoverable error occurs.  The routine 
   returns the number of bytes actually sent.

   This routine must disable serial interrupts while it manipulates 
   the buffers.  Serial interrupts will be enabled on exit.
*/

BYTE SERIAL_SendString(BYTE port_id, BYTE len, BYTE *dat)
 {
  BYTE i;   

  /* If selected buffer not valid, return failure */
  if(port_id >= NUM_SERIAL_PORTS) return(0);  
  if(dat == NULL) return(0);

  /* Send the data as specified */
  for(i=0;i<len;i++)  
   SERIAL_SendByte(port_id, &dat[i]); 

  /* Return the count */
  return(i);
 }

/*--------------------------------------------------------------------------*/

/* SERIAL_PRINT sends a character string over the specified serial port 
   and stops when a null termination is reached.  The null termination is 
   not sent.  The return value is 1/0 pass/fail. 

   This routine calls others which will exit with serial interrupts enabled.
*/

BYTE SERIAL_Print(BYTE port_id, const char *dat)
 {
  /* If selected buffer not valid, return failure */
  if(port_id >= NUM_SERIAL_PORTS) return(0);  
  if(dat == NULL) return(0);

  /* Send the data to the end of string */
  while(*dat!=0)  
   SERIAL_SendByte(port_id, dat++); 

  /* Return success */
  return(1);
 }               

/*--------------------------------------------------------------------------*/

/* SERIAL_RESET resets the specified serial port by clearing the buffers.  
   This process must not be interrupted so interrupts will be disabled 
   on entry and enabled on exit.  This is therefore the typical way to 
   enable interrupts initially.  The global interrupt enable is not
   set or cleared by this module.
*/

BYTE SERIAL_Reset(BYTE port_id)
 {
  BYTE rxbuf = S_BUF_ID(port_id, S_BUF_DIR_RX);
  BYTE txbuf = S_BUF_ID(port_id, S_BUF_DIR_TX);

  /* Verify arguments */
  if(port_id >= NUM_SERIAL_PORTS) return(0);

  /* Disable interrupts to avoid conflicts */
  SERIAL_DI;

  /* Clear status flags */
  switch(port_id)
   {
    case SERIAL_PORT_UART0:
     S_UART0_tx_active = 0;
     S_UART0_CLR_TI;
     S_UART0_CLR_RI;
     break;

    // This structure is more useful with multiple ports
   };

  /* Clear all data existing in the buffer currently */
  S_BUF_RESET(rxbuf); 
  S_BUF_RESET(txbuf);

  /* Enable interrupts */
  SERIAL_EI;

  /* Return success */
  return(1);
 }

/*--------------------------------------------------------------------------*/
/* Module Support Functions                                                 */
/*--------------------------------------------------------------------------*/

/* SERIAL_UART0_ISR is the interrupt service routine for the UART0 serial 
   port to identify services needed by that connection.  

   This routine must prevent the overflow or underflow of the buffers.  This 
   implementation simply stops filling the buffer and loses data in that event.
   Discrete signal handshaking ability could be added to this routine.  This
   would generally require some support from routines in this module, but not
   so much from calling routines.
 
   This interrupt is of the highest priority but equal to other serial ports.
   The active registers are saved through bank switching.  This priority and 
   bank assignment needs to be evaluated by applications which use this module.
*/

void SERIAL_UART0_ISR(void) interrupt INTERRUPT_UART0 using 1        
 {
  BYTE ch_dat;
   
  /* Case of UART0 receive data available */
  if(RI_UART0)
   {
    /* get the data byte */
    ch_dat = SBUF_UART0;
					   
    /* If room available in buffer */
    if(!S_BUF_FULL(S_BUF_UART0_RX))
     {
      /* Put the data byte in the buffer */
      S_BUF_PUT(S_BUF_UART0_RX, ch_dat);  
     };

    /* Clear the status flag no matter what we did */
    S_UART0_CLR_RI; 
   };

  /* Case of previous transmission complete */
  if(TI_UART0)
   { 
    /* If there is data in the buffer to send */ 
    if(!S_BUF_EMPTY(S_BUF_UART0_TX))
     {
      /* Send data from buffer */
      S_BUF_GET(S_BUF_UART0_TX, ch_dat);
      SBUF_UART0 = ch_dat;
     }
    else
     {
      /* If the buffer has emptied on last transmission, turn off tx active */
      S_UART0_tx_active = 0;
     };
     
    /* Clear the status flag */
    S_UART0_CLR_TI;    
   }; 
 }

/*--------------------------------------------------------------------------*/

/* END OF MODULE */




