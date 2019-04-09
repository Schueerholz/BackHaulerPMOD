Module BhPmodApi

'---------------------------------------------------------------------------------------
'API functions as defined in DLL 
'---------------------------------------------------------------------------------------

' General utility functions - always valid
Declare Function BHPMOD_GetStatus Lib "BhPmodApi.dll" (ByRef aStatus As Byte) As UInteger
Declare Function BHPMOD_SetConfiguration Lib "BhPmodApi.dll" (ByVal aConfiguration As Byte) As UInteger

' Discrete I/O functions - valid in any configuration within limitations
Declare Function BHPMOD_SetPinDrive Lib "BhPmodApi.dll" (ByVal aPinNumber As Byte, ByVal aPushPull As Byte) As UInteger
Declare Function BHPMOD_SetPinState Lib "BhPmodApi.dll" (ByVal aPinNumber As Byte, ByVal aState As Byte) As UInteger
Declare Function BHPMOD_GetPinState Lib "BhPmodApi.dll" (ByVal aPinNumber As Byte, ByRef aState As Byte) As UInteger

' SPI functions - valid in SPI configuration 
Declare Function BHPMOD_SPI_SetClockPhase Lib "BhPmodApi.dll" (ByVal ClockPhase As Byte) As UInteger
Declare Function BHPMOD_SPI_Transaction Lib "BhPmodApi.dll" (ByRef aCount As Byte, ByRef aBuffer As Byte) As UInteger

' I2C functions - valid in I2C configuration
Declare Function BHPMOD_I2C_Write Lib "BhPmodApi.dll" (ByVal Address As Byte, ByVal SubAddrSize As Byte, ByRef aSubAddr As Byte, ByRef aCount As Byte, ByRef aContent As Byte) As UInteger
Declare Function BHPMOD_I2C_Read Lib "BhPmodApi.dll" (ByVal Address As Byte, ByVal SubAddrSize As Byte, ByRef aSubAddr As Byte, ByRef aCount As Byte, ByRef aContent As Byte) As UInteger

' SERIAL functions - valid in SERIAL configuration
Declare Function BHPMOD_SERIAL_Print Lib "BhPmodApi.dll" (ByVal aStrz As String) As UInteger
Declare Function BHPMOD_SERIAL_Write Lib "BhPmodApi.dll" (ByRef aCount As Byte, ByRef aContent As Byte) As UInteger
Declare Function BHPMOD_SERIAL_Read Lib "BhPmodApi.dll" (ByRef aCount As Byte, ByRef aContent As Byte) As UInteger

' Test and development functions - used only during intense embedded development
Declare Function BHPMOD_TestCode Lib "BhPmodApi.dll" (ByVal aTestNumber As Byte, ByVal aArgStr1 As String, ByVal aArgStr2 As String) As UInteger

'---------------------------------------------------------------------------------------
'Values defined in ICD and relevant to API call arguments
'---------------------------------------------------------------------------------------

'PMOD connector configurations
'Power on default at the device is IO_ONLY, but that is not the same thing as starting up the host software,
'so it is a good idea to always set exactly what we want
Public Const PMOD_CONFIGURATION_IO_ONLY As Byte = 0
Public Const PMOD_CONFIGURATION_SPI As Byte = 1
Public Const PMOD_CONFIGURATION_I2C As Byte = 2
Public Const PMOD_CONFIGURATION_SERIAL As Byte = 3

'SPI clock to data phase relationship options
'Default - Clock idles low, peripheral accepts data on rising clock, master changes data on falling clock (POL=0, PHA=0)
Public Const SPI_CLOCK_PHASE_0 As Byte = 0
'Clock idles low, peripheral accepts data on falling clock, master changes data on rising clock (POL=0, PHA=1) 
Public Const SPI_CLOCK_PHASE_1 As Byte = 1
'Clock idles high, peripheral accepts data on falling clock, master changes data on rising clock (POL=1, PHA=0)
Public Const SPI_CLOCK_PHASE_2 As Byte = 2
'Clock idles high, peripheral accepts data on rising clock, master changes data on falling clock (POL=1, PHA=1) 
Public Const SPI_CLOCK_PHASE_3 As Byte = 3

'Application status bits
Public Const STATUS_BIT_COMMAND_MODE_READY As Byte = 1
Public Const STATUS_BIT_BUSY As Byte = 2
Public Const STATUS_BIT_ERROR As Byte = 4
Public Const STATUS_BIT_POWER_ON As Byte = 32
Public Const STATUS_BIT_DATA_IN_PHASE As Byte = 64
Public Const STATUS_BIT_DATA_OUT_PHASE As Byte = 128

'---------------------------------------------------------------------------------------
'End of module
'---------------------------------------------------------------------------------------

End Module
