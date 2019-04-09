/* GLOBAL.H 

   Header file for application specific hardware definitions and generally applied
   types and global variables.  This header file is named with a standard name 
   because it is included with all standard modules.

   This version is associated with - ACW Backhauler PMOD (BHPMODFW.C)  
*/ 

#ifndef GLOBAL_H
#define GLOBAL_H

/* Includes must go here */

// The following are the SiLabs provided part specific header files (renamed slightly)
// Note - Until we can get the correct header, we are using the compatible 34x header
#include "C8051F340.H"      

// The following are the general purpose libraries most often needed
#include <absacc.h>
#include <stdlib.h>
#include <stdio.h>
#include <ctype.h>   
#include <string.h>
#include <math.h>  

/* Local definition macros */
#ifdef _MAIN_C_
 #define DECLARATION volatile 
 #define INIT_VALUE(A) = (A)
#else
 #define DECLARATION extern volatile
 #define INIT_VALUE(A)
#endif

/*--------------------------------------------------------------------------*/

/* Application specific memory map, register, and bit definitions */

// Define the version only in this location (not even in comments elsewhere)
// Hardware version text format
#define HARDWARE_VERSION_TEXT					"BHPMOD_X1"
// Firmware version text format
#define FIRMWARE_VERSION_TEXT					"1.10"
// Firmware version nibble format 
// Examples - production version 1.1 = 0x11 or prototype version 0.1 = 0x01
#define FIRMWARE_VERSION_CODE					0x11

// I/O bits for the application

// Pins that can be used for I2C when so configured
sbit I2C_SCL                          = P1 ^ 1;
sbit I2C_SDA                          = P1 ^ 0;

/*--------------------------------------------------------------------------*/

/* The following are definitions of useful general purpose macros and values */
                            
#define MAKEWORD(a,b)   ((b) * 0x100 + (a))

#define HIBYTE(a)       (((a) >> 8) & 0xFF) // (((a) / 0x100) & 0xFF)

#define LOBYTE(a)       ((a) & 0xFF)

#define LIMITBYTE(a)    ((a > 0xFF) ? 0xFF : a)                     
           
// FROUND does work for negative numbers too - consider the precise definition of floor(x)  
// For example FROUND(-0.6) = -1 + ((-0.6 - -1) > 0.5 ? 1 : 0) = -1       
#define FROUND(a)       ((long)(floor(a) + (((a - floor(a)) >= 0.5) ? 1.0 : 0.0)))

#define XOR(a,b)        ((a && !b) || (!a && b))

#define ABS(a)          ((a<0) ? -a : a )

// Some useful ASCII definitions 
#ifndef NULL
#define NULL            0
#endif                             
#define BS              8           
#define LF              10
#define CR              13
#define ESC             27                                                 
#define DC1             17
#define DC2             18
#define DC3             19
#define DC4             20
#define STX             2
#define EOT             4

/*--------------------------------------------------------------------------*/

/* The following are definitions of useful general purpose data types and
   global scratch pad variables.
*/

// Some useful type definitions 
// These tend to drive the Kiel environment closer to alignment with Microsoft Visual Studio
typedef bit BOOL;
#define FALSE           0 
#define TRUE            1 
#define OFF             0 
#define ON              1 
#define FAIL            0 
#define PASS            1 
#define DOWN            0 
#define UP              1
typedef unsigned char BYTE;
typedef unsigned int WORD;
typedef unsigned long LWORD;
typedef unsigned int UINT;
typedef unsigned long ULONG;

// LWORD translation union  
DECLARATION union 
 {
  unsigned long value;
  unsigned char bytes[4];
 } xdata lwordunion;

// Float translation union  
DECLARATION union
 {
  float value;
  unsigned char bytes[4];
 } xdata floatunion;

// Translation for hex ASCII characters
#ifdef _MAIN_C_
 BYTE code HexTable[16] = {'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};
#else
 extern BYTE code HexTable[];
#endif

/*--------------------------------------------------------------------------*/

/* Append the system interface control document (ICD) header file here. 

   Loading this header here allows it to be available where needed while requiring
   only one edit every time the file moves relative to the project directory.  
   The location may change as the ICD header is generally at a location shared
   with other users of the ICD.  It must be at the bottom of this file because
   the header uses some of the global definitions.  
*/
#include "../bhpmodicd.h"
            
/*--------------------------------------------------------------------------*/

#undef DECLARATION
#undef INIT_VALUE
#endif

 