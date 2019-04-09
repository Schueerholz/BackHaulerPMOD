/* TIMER.H 

   See the header of the associated C file for descriptive details.                                   

*/ 

#ifndef TIMER_H
#define TIMER_H

/* Includes must go here */

/* Local definition macros */
#ifdef _TIMER_C_
 #define DECLARATION volatile 
 #define INIT_VALUE(A) = (A)
#else
 #define DECLARATION extern volatile
 #define INIT_VALUE(A)
#endif

/*--------------------------------------------------------------------------*/


/*--------------------------------------------------------------------------*/

void TIMER_Configure(void);
void TIMER_SetTime(LWORD Seconds);
void TIMER_GetTime(LWORD *Seconds);
BYTE TIMER_DeltaTime(LWORD StartTimeSeconds, LWORD Delta);

/*--------------------------------------------------------------------------*/

#undef DECLARATION
#undef INIT_VALUE
#endif



