/* SERIAL.H 

   See the header of the associated C file for descriptive details.                                   

*/

#ifndef SERIAL_H
#define SERIAL_H

/* Includes must go here */

/* Local definition macros */
#ifdef _SERIAL_C_
 #define DECLARATION volatile 
 #define INIT_VALUE(A) = (A)
#else
 #define DECLARATION extern volatile
 #define INIT_VALUE(A)
#endif

/*--------------------------------------------------------------------------*/

// Serial port identifiers  
// CAUTION: Buffering operations depend on these absolute values  
#define SERIAL_PORT_UART0       0

/*--------------------------------------------------------------------------*/

// General exported functions
void SERIAL_Configure(void);
BYTE SERIAL_SeekByte(BYTE port_id, BYTE *dat);
BYTE SERIAL_GetByte(BYTE port_id, BYTE *dat); 
BYTE SERIAL_SendByte(BYTE port_id, BYTE *dat);
BYTE SERIAL_SendString(BYTE port_id, BYTE len, BYTE *dat);
BYTE SERIAL_Print(BYTE port_id, const char *dat);
BYTE SERIAL_Reset(BYTE port_id);

/*--------------------------------------------------------------------------*/

#undef DECLARATION
#undef INIT_VALUE
#endif



