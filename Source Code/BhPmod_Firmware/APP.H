/* APP.H 

   See the header of the associated C file for descriptive details.                                   

*/ 

#ifndef APP_H
#define APP_H

/* Includes must go here */

/* Local definition macros */
#ifdef _APP_C_
 #define DECLARATION volatile 
 #define INIT_VALUE(A) = (A)
#else
 #define DECLARATION extern volatile
 #define INIT_VALUE(A)
#endif

/*--------------------------------------------------------------------------*/

// Application status
// Use this byte to save status as defined in the ICD to be sent upon request
// Other application modules might use or affect this if they ever exist
DECLARATION BYTE APP_Status INIT_VALUE(STATUS_BIT_COMMAND_MODE_READY | STATUS_BIT_POWER_ON);

/*--------------------------------------------------------------------------*/

void APP_Start(void);
BYTE APP_Process(void);
void APP_CommandMessage(BYTE Token, BYTE Count, BYTE *MessageData);
void APP_SendStatusCommandMode(void);
BYTE APP_SendStatusCommandModeError(void);
void APP_DataOutPhase(BYTE Count, BYTE *MessageData);

/*--------------------------------------------------------------------------*/

#undef DECLARATION
#undef INIT_VALUE
#endif



