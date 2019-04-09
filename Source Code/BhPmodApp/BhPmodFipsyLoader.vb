Module BhPmodFipsyLoader

'---------------------------------------------------------------------------------------
'API functions as defined in DLL 
'---------------------------------------------------------------------------------------

' General library interface functions
Declare Function Fipsy_Open Lib "BhPmodFipsyLoader.dll" () As UInteger
Declare Function Fipsy_Close Lib "BhPmodFipsyLoader.dll" () As UInteger

' Fipsy FPGA module interface functions
Declare Function Fipsy_ReadDeviceID Lib "BhPmodFipsyLoader.dll" (ByRef aDeviceID As Byte) As UInteger
Declare Function Fipsy_ReadUniqueID Lib "BhPmodFipsyLoader.dll" (ByRef aUniqueID As Byte) As UInteger
Declare Function Fipsy_EraseAll Lib "BhPmodFipsyLoader.dll" () As UInteger
Declare Function Fipsy_LoadConfiguration Lib "BhPmodFipsyLoader.dll" () As UInteger
Declare Function Fipsy_WriteFeatures Lib "BhPmodFipsyLoader.dll" (ByRef aFeatureRow As Byte, ByRef aFeabits As Byte) As UInteger
Declare Function Fipsy_WriteConfiguration Lib "BhPmodFipsyLoader.dll" (ByVal aJEDECFileName As String) As UInteger

'---------------------------------------------------------------------------------------
'End of module
'---------------------------------------------------------------------------------------

End Module
