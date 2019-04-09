/* BHPMODFIPSYLOADER.H                                                              

   Header file for Fipsy loader library.

*/

// This definition allows this header file to be used for export and import.
// Export names are defined in a .def file to be equivalent to the names 
// defined in this header file and not mangled.  Include the .lib file
// with the source files to link with a C project.
#define DCAPI extern "C" DWORD WINAPI

/*---------------------------------------------------------------------------*/
/* API Exports                                                               */
/*---------------------------------------------------------------------------*/

DCAPI Fipsy_Open(void);
DCAPI Fipsy_Close(void);
DCAPI Fipsy_ReadDeviceID(BYTE *DeviceID);
DCAPI Fipsy_ReadUniqueID(BYTE *UniqueID);
DCAPI Fipsy_EraseAll(void);
DCAPI Fipsy_LoadConfiguration(void);
DCAPI Fipsy_WriteFeatures(BYTE *FeatureRow, BYTE *Feabits);
DCAPI Fipsy_WriteConfiguration(char *JEDECFileName);

/*--------------------------------------------------------------------------*/

/* End of header file */

