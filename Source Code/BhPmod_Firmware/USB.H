/* USB.H 

   See the header of the associated C file for descriptive details.                                   

*/ 

#ifndef USB_H
#define USB_H

/* Includes must go here */

/* Local definition macros */
#ifdef _USB_C_
 #define DECLARATION volatile 
 #define INIT_VALUE(A) = (A)
#else
 #define DECLARATION extern volatile
 #define INIT_VALUE(A)
#endif

/*--------------------------------------------------------------------------*/

// Defines from SiLabs USBExpress library
// Get_Interrupt_Source() return value bit masks
// Note - More than one bit can be set at the same time.
#define USB_RESET            0x01      // USB Reset Interrupt has occurred
#define TX_COMPLETE          0x02      // Transmit Complete Interrupt has occurred
#define RX_COMPLETE          0x04      // Receive Complete Interrupt has occurred
#define FIFO_PURGE           0x08      // Command received (and serviced) from the host to purge the USB buffers
#define DEVICE_OPEN          0x10      // Device Instance Opened on host side
#define DEVICE_CLOSE         0x20      // Device Instance Closed on host side
#define DEV_CONFIGURED       0x40      // Device has entered configured state
#define DEV_SUSPEND          0x80      // USB suspend signaling present on bus

// Data phase flag is set to 1 by an application routine which needs
// back to back data as it arrives.  Setting this to 1 bypasses normal 
// USB operation and passes data directly to the application data phase 
// handling routine.
DECLARATION bit USB_DataOutPhase INIT_VALUE(0);

/*--------------------------------------------------------------------------*/

/* Function prototypes defined for SiLabs USBExpress library */
void USB_Clock_Start(void) large;
void USB_Init(UINT,UINT,BYTE*,BYTE*,BYTE*,BYTE,BYTE,UINT) large;
UINT Block_Write(BYTE*, UINT) large;
BYTE Block_Read(BYTE*, BYTE) large;
BYTE Get_Interrupt_Source(void) large;
void USB_Int_Enable(void) large;
void USB_Int_Disable(void) large;
void USB_Disable(void) large;
void USB_Suspend(void) large;
UINT USB_Get_Library_Version(void) large;
// Translation of interrupt prototype
void USBXcore_USB_ISR(void);

/*--------------------------------------------------------------------------*/

/* Function prototypes for USB task module */
void USB_Start(void);
BYTE USB_Process(void);
BYTE USB_SendResponse(BYTE Token, BYTE Count, void *MessageData);
BYTE USB_SendStatus(BYTE Status);
BYTE USB_DataInPhase(WORD Count, void *MessageData);

/*--------------------------------------------------------------------------*/

#undef DECLARATION
#undef INIT_VALUE
#endif



