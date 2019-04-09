/* PMOD.H 

   See the header of the associated C file for descriptive details.                                   

*/ 

#ifndef PMOD_H
#define PMOD_H

/* Includes must go here */

/* Local definition macros */
#ifdef _PMOD_C_
 #define DECLARATION volatile 
 #define INIT_VALUE(A) = (A)
#else
 #define DECLARATION extern volatile
 #define INIT_VALUE(A)
#endif

/*--------------------------------------------------------------------------*/

// Hardware connectivity of specific pins of the PMOD connector
sbit PMOD_HW_PIN1 = P0 ^ 3;
sbit PMOD_HW_PIN2 = P0 ^ 2;    // Also connected to P0.4 for crossbar routing reasons
sbit PMOD_HW_PIN3 = P0 ^ 1;    // Also connected to P0.5 for crossbar routing reasons 
sbit PMOD_HW_PIN4 = P0 ^ 0;
sbit PMOD_HW_PIN7 = P0 ^ 7;
sbit PMOD_HW_PIN8 = P0 ^ 6;
sbit PMOD_HW_PIN9 = P1 ^ 1;
sbit PMOD_HW_PIN10 = P1 ^ 0;

// We can see what configuration the PMOD connector is in by just looking at the crossbar
#define PMOD_USING_IO_ONLY  (XBR0 == 0x00)
#define PMOD_USING_SPI      (XBR0 == 0x02)
#define PMOD_USING_I2C      (XBR0 == 0x04)
#define PMOD_USING_SERIAL   (XBR0 == 0x01)

/*--------------------------------------------------------------------------*/

void PMOD_Configure(void);
void PMOD_SetConfiguration(BYTE Configuration);
void PMOD_SetPinDrive(BYTE PinNumber, BYTE PushPull);
void PMOD_SetPinState(BYTE PinNumber, BYTE State);
void PMOD_GetPinState(BYTE PinNumber, BYTE *State);

/*--------------------------------------------------------------------------*/

#undef DECLARATION
#undef INIT_VALUE
#endif



