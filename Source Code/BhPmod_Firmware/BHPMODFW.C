/*--------------------------------------------------------------------------*/
/* BHPMODFW.C
 
   Firmware for Backhauler PMOD host baseline  

   Original Author: Mark A. Shaw

   Copyright (C) 2013 Allied Component Works                                
  
   This specific variant of the Allied Component Works embedded code 
   baseline is assigned to the exclusive benefit of -					 
   
   Open source community using Backhauler PMOD   				 
   
   See additional conditions with tool kit code components. 
   
   See global.h for version information.   

   Structure:
   
   This is the main executive per definition of Allied Component Works
   cooperative multitasking embedded code architecture.  This module
   contains the main() routine, which shall perform the following tasks.
   1) Configure hardware primitives
   2) Configure drivers
   3) Enable interrupts if used
   4) Start tasks
   5) Execute tasks in an infinite loop
   The main loop may contain primitive control steps and test points, but
   it may not be involved in any application feature.  In general, the 
   application specific features are implemented in the APP.C application
   task module.  Though other task modules may also contribute application 
   specific features, they will generally be provided as more of a 
   modification of a generic feature set rather than the nearly fully 
   unique code of the application module.
   
   The original tool chain is Kiel for the 8051 architecture.
   
   Rules for application:
   
   The authorship shall be void if ANY portion of this file is modified.  
   The original author disclaims all copyrights or any association at all 
   with any such derivative works.  However, the original and any usage 
   for the same purpose shall otherwise remain under copyright as shown
   above, with all rights reserved.

   See additional conditions with tool kit code components such as 
   drivers and general purpose task modules.
   
   Derivative author comments here -
   < must be filled in if authored by other than Allied Component Works >  
*/
/*--------------------------------------------------------------------------*/

#define _MAIN_C_

#include "global.h"
#include "delays.h"
#include "timer.h"
#include "spi.h"
#include "i2c.h"
#include "serial.h"
#include "pmod.h"
#include "usb.h"
#include "app.h"

/* Local private functions */
void Init_Processor(void);

/* Local private data */

// Loop time test point  
// Use this point and an oscilloscope to see how long the main look takes
// This is shared with C2D, and is set to active drive in the setup for this alternate use
sbit LoopTimeTest = P3 ^ 0;     
                
/*--------------------------------------------------------------------------*/
/* Main Executive                                                           */
/*--------------------------------------------------------------------------*/

/* MAIN initializes everything and then dispatches task process routines 
   in round robin.  
*/         
               
void main(void)
 {       
  // Complete processor setup
  Init_Processor();
 
  // Configure driver modules (order is important in some cases)
  // PMOD - For this unique application, peripherals are configured but
  // are not at this point routed to pins, and may or may not be routed to pins
  // depending on the host configuration instructions.
  TIMER_Configure();    // The timer module may have limited use for PMOD, but is nice to have
  SPI_Configure();      // Peripheral subject to routing - master only
  I2C_Configure();      // Peripheral subject to routing - master only
  SERIAL_Configure();   // Peripheral subject to routing - limited to 9600,N,8,1 until more uses are identified 
  PMOD_Configure();     // The PMOD driver offers methods to route the peripherals and operate discrete pins
    
  // Global enable interrupts for the benefit of drivers that use them
  EA = 1;   

  // Start process modules (order is important)  
  USB_Start();          // Starts driver and also sets SYSCLK to 48MHz          
  // The clock must be running the right speed for the application to start correctly   
  APP_Start();          // Starts the application functionality
     
  // Perform process tasks 
  while(1)
   { 
    LoopTimeTest = ~LoopTimeTest;  
    USB_Process();
	APP_Process();
   }; 
 }

/*--------------------------------------------------------------------------*/
/* Main Support Functions                                                   */
/*--------------------------------------------------------------------------*/

/* INIT_PROCESSOR configures the special function registers of this 
   specific processor configuration.  This covers setup of values 
   needed by multiple processes and the design in general.  Specific   
   peripheral setup is handled in the driver modules configure routines.
*/

void Init_Processor(void)
 {
  // Disable watchdog timer
  PCA0MD    = 0x00;

  // Short delay
  DELAY_10uS;

  // Initial oscillator setup 
  // This forms a default prior to USB initialization and is preferred where we do not use USB
  // We end here with 12MHz running everywhere, which affects all timing
  // If we run USB, the driver will set us to run 48MHz everywhere and we must adjust our timing for that
  OSCICN    = 0x83;     // High frequency oscillator runs at 12 MHz
  OSCLCN    = 0x80;     // Low frequency oscillator runs at 10 KHz
  CLKSEL    = 0x10;     // Run on HF oscillator to start

  // SPI setup pinout control 
  // This is the place to decide if we are using 3 wire or 4 wire SPI
  // The skip registers must be set only after this selection
  // Do not enable SPI here
  SPI0CN    = 0x02;     // We are using SPI in 3 wire master mode

  // Port I/O and cross bar setup
  // Default state reiterated where no change desired or required

  // Digital output latches
  // Point by point determination of defaults - mostly high - inputs must be high here, keep unused high to reduce power
  // PMOD - These settings are prior to host software configuration of a specific mode - set all high
  P0        = 0xFF;     
  P1        = 0xFF;     
  P2        = 0xFF;     
  P3        = 0xFF;     
  P4        = 0xFF;      

  // Select pins which should be analog inputs (0 analog, 1 digital I/O)
  // PMOD - This processor has limited analog features, and the PMOD application uses none of them - set all digital
  P0MDIN    = 0xFF;     
  P1MDIN    = 0xFF;     
  P2MDIN    = 0xFF;      
  P3MDIN    = 0xFF;       
  P4MDIN    = 0xFF;

  // Select pins which should be push pull if they are digital outputs (1 = push pull, 0 = passive pull up output, or digital input if output high)
  // Default states are as defined above, use of push-pull depends on application detail
  // PMOD - leave unused pins hanging in passive pull-up mode, leave all pins in this mode prior to host configuration
  P0MDOUT   = 0x00;      
  P1MDOUT   = 0x00;      
  P2MDOUT   = 0x00;      
  P3MDOUT   = 0x01;     // This processor has only one pin of port 3 bonded out, and it has a shared function, driven here for test purposes 
  P4MDOUT   = 0x00;     // This processor does not actually have a port 4 bonded out

  // Select pins to be skipped in cross bar due to more mundane use  
  // PMOD - this functionality will be worked heavily by the host configuration, so for now skip nothing
  P0SKIP    = 0x00;      
  P1SKIP    = 0x00;     
  P2SKIP    = 0x00;      
  P3SKIP    = 0x00;     
                        // Port4 is not accessed by the cross bar
           
  // Setup cross bar to provide needed resources
  // PMOD - this functionality will be worked heavily by the host configuration, so for now do not rout out anything
  XBR0      = 0x00;      
  XBR2      = 0x00;      
  XBR1      = 0x40;     // Cross bar enabled and weak pull-ups enabled

  // Interrupts are configured by individual users
  // Generally interrupts are only globally enabled after all users are ready
  // All priorities are equal so interrupts don't interrupt each other
  IP        = 0xFF;
  EIP1      = 0xFF;
  EIP2      = 0xFF;     
  IE        = 0x00;
  EIE1      = 0x00;
  EIE2      = 0x00;
 }

/*--------------------------------------------------------------------------*/

/* END OF MODULE */




