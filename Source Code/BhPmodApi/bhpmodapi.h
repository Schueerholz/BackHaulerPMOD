/* BHPMODAPI.H                                                              

   Header file for Backhauler PMOD API.

*/

// This definition allows this header file to be used for export and import.
// Export names are defined in a .def file to be equivilent to the names 
// defined in this header file and not mangled.  Include the .lib 
// file with the source files to link with a C project.
#define DCAPI extern "C" DWORD WINAPI

/*---------------------------------------------------------------------------*/
/* API Data Definitions                                                      */
/*---------------------------------------------------------------------------*/


/*---------------------------------------------------------------------------*/
/* API Exports                                                               */
/*---------------------------------------------------------------------------*/

// General utility functions - always valid
DCAPI BHPMOD_GetStatus(BYTE *Status);
DCAPI BHPMOD_SetConfiguration(BYTE Configuration);

// Discrete I/O functions - valid in any configuration within limitations
DCAPI BHPMOD_SetPinDrive(BYTE PinNumber, BYTE PushPull);
DCAPI BHPMOD_SetPinState(BYTE PinNumber, BYTE State);
DCAPI BHPMOD_GetPinState(BYTE PinNumber, BYTE *State);

// SPI functions - valid in SPI configuration 
DCAPI BHPMOD_SPI_SetClockPhase(BYTE ClockPhase);
DCAPI BHPMOD_SPI_Transaction(BYTE *Count, BYTE *Buffer);

// I2C functions - valid in I2C configuration
DCAPI BHPMOD_I2C_Write(BYTE Address, BYTE SubAddrSize, void *SubAddr, BYTE *Count, void *Content);
DCAPI BHPMOD_I2C_Read(BYTE Address, BYTE SubAddrSize, void *SubAddr, BYTE *Count, void *Content);

// SERIAL functions - valid in SERIAL configuration
DCAPI BHPMOD_SERIAL_Print(char *Strz);
DCAPI BHPMOD_SERIAL_Write(BYTE *Count, BYTE *Content);
DCAPI BHPMOD_SERIAL_Read(BYTE *Count, BYTE *Content);

// Test and development functions - used only during intense embedded development
DCAPI BHPMOD_TestCode(BYTE TestNumber, char *ArgStr1, char *ArgStr2);

/*--------------------------------------------------------------------------*/

/* End of header file */

