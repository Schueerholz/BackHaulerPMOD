/* I2C.H 

   See the header of the associated C file for descriptive details.                                   

*/ 

#ifndef I2C_H
#define I2C_H

/* Includes must go here */

/* Local definition macros */
#ifdef _I2C_C_
 #define DECLARATION volatile 
 #define INIT_VALUE(A) = (A)
#else
 #define DECLARATION extern volatile
 #define INIT_VALUE(A)
#endif

/*--------------------------------------------------------------------------*/

/* Module definitions */

// Note that addresses are defined as for I2C, not shifted by one bit for 
// the R/W as is often done for convenience but at the cost of errors.

/*--------------------------------------------------------------------------*/

void I2C_Configure(void);
BYTE I2C_Write(BYTE Address, BYTE SubAddrSize, void *SubAddr, BYTE Count, void *Content);
BYTE I2C_Read(BYTE Address, BYTE SubAddrSize, void *SubAddr, BYTE Count, void *Content);
BYTE I2C_Reset(void);

/*--------------------------------------------------------------------------*/

#undef DECLARATION
#undef INIT_VALUE
#endif



