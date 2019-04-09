/* SPI.H 

   See the header of the associated C file for descriptive details.                                   

*/ 

#ifndef SPI_H
#define SPI_H

/* Includes must go here */

/* Local definition macros */
#ifdef _SPI_C_
 #define DECLARATION volatile 
 #define INIT_VALUE(A) = (A)
#else
 #define DECLARATION extern volatile
 #define INIT_VALUE(A)
#endif

/*--------------------------------------------------------------------------*/

/* Module definitions */

// In this version, we know the chip select to be on PMOD pin 1
// Be sure in other coding that this is not activiated when the device
// is not configured for SPI
#define SPI_CS                              PMOD_HW_PIN1
          
/*--------------------------------------------------------------------------*/

void SPI_Configure(void);
void SPI_SetClockPhase(BYTE NewClockPhase);
BYTE SPI_Transaction(BYTE Count, void *WriteContent, void *ReadContent); 

/*--------------------------------------------------------------------------*/

#undef DECLARATION
#undef INIT_VALUE
#endif

