/* DELAYS.H 

   See the header of the associated C file for descriptive details.                                   

*/ 

#ifndef DELAYS_H
#define DELAYS_H

/* Includes must go here */

/* Local definition macros */
#ifdef _DELAYS_C_
 #define DECLARATION volatile 
 #define INIT_VALUE(A) = (A)
#else
 #define DECLARATION extern volatile
 #define INIT_VALUE(A)
#endif

/*--------------------------------------------------------------------------*/

/* Calls to delay primitives, tuned for this processor and clock rate */
#define DELAY_uS        DELAYS_Short(2)     
#define DELAY_10uS      DELAYS_Short(29)
#define DELAY_100uS     DELAYS_Long(28, 10)
#define DELAY_mS        DELAYS_Long(28, 91)

/*--------------------------------------------------------------------------*/

void DELAYS_Short(BYTE count);
void DELAYS_Long(BYTE count, BYTE dwell);

/*--------------------------------------------------------------------------*/

#undef DECLARATION
#undef INIT_VALUE
#endif

