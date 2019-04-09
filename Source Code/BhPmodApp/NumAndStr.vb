Module NumAndStr

'  NumAndStr.vb 
'
'  Purpose:
'  
'  This module provides some simple functions to validate and process
'  numbers and strings, such as from user entries or other external 
'  sources, so that the data may be processed or displayed.  This module
'  is typically adjusted and augmented over time as new needs arise.
'  The functions should all do things which are useful in a general sense
'  and not handle application specific situations.
'
'  Rules for application:
'  
'  This module is free software; you can redistribute it and/or modify it
'  under the terms of the GNU General Public License as published by the
'  Free Software Foundation; either version 2, or (at your option) any
'  later version.
'
'  This software is distributed in the hope that it will be useful,
'  but WITHOUT ANY WARRANTY; without even the implied warranty of
'  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
'  GNU General Public License for more details.
'
'  You should have received a copy of the GNU General Public License 
'  along with this software; see the file COPYING. If not, write to the
'  Free Software Foundation, 51 Franklin Street, Fifth Floor, Boston,
'  MA 02110-1301, USA.
'
'  As a special exception, if you link this software with other files
'  to produce an executable, this software does not by itself cause the 
'  resulting executable to be covered by the GNU General Public License. 
'  This exception does not however invalidate any other reasons why the 
'  executable file might be covered by the GNU General Public License.
'  
'  This software is typically modified in its detail to fit a specific
'  application, the total of which may be held as proprietary to the 
'  author or assigns of such derivative works, and various copyrights 
'  may apply to such derivatives.   
'  
'  Original work on this software is from the tool kit of Mark A. Shaw
'  at Allied Component Works, Gaithersburg, MD, USA.  The original shall 
'  thus be Copyright (C) 2013 Allied Component Works per the above terms. 
'  This authorship shall be void if ANY portion of this file is modified.  
'  The original author disclaims all copyrights or any association at all 
'  with any such derivative works.  However, the original shall remain
'  free as described here.
'   
'  Derivative author comments here -
'  < must be filled in if authored by other than Allied Component Works >
   
'Constants for status LED colors
Public LED_COLOR_STATUS_OFF As Color = Color.Gray
Public LED_COLOR_STATUS_ON As Color = Color.Yellow
Public LED_COLOR_STATUS_GOOD As Color = Color.Lime
Public LED_COLOR_STATUS_BAD As Color = Color.Red
Public LED_COLOR_STATUS_GRAY As Color = Color.Silver

Public Function HexIntToLng(ByVal numstr As String) As Long
 Dim num, digit, i As Long
 Dim testchr As Integer
 Dim teststr As String

 HexIntToLng = 0
 If (numstr = "") Then Exit Function
 If (Len(numstr) > 4) Then Exit Function
 teststr = numstr
 Do Until Len(teststr) = 4
  teststr = "0" + teststr
 Loop
 num = 0

 For i = 0 To 3
  testchr = Asc(Right(Left(teststr, 4 - i), 1))
  Select Case testchr
   Case Asc("0") To Asc("9")
    digit = testchr - &H30&
    num = num + digit * 16 ^ i
   Case Asc("a"), Asc("A")
    num = num + 10 * 16 ^ i
   Case Asc("b"), Asc("B")
    num = num + 11 * 16 ^ i
   Case Asc("c"), Asc("C")
    num = num + 12 * 16 ^ i
   Case Asc("d"), Asc("D")
    num = num + 13 * 16 ^ i
   Case Asc("e"), Asc("E")
    num = num + 14 * 16 ^ i
   Case Asc("f"), Asc("F")
    num = num + 15 * 16 ^ i
  End Select
 Next i

 HexIntToLng = num

End Function

Public Function LngToDecByte(ByVal num As Long) As String
 Dim temp As String

 If (num > 255) Then
  LngToDecByte = "---"
  Exit Function
 End If

 temp = Trim(Str(num))
 Do While Len(temp) < 3
  temp = " " + temp
 Loop

 LngToDecByte = temp

End Function

Public Function LngToDecInt(ByVal num As Long) As String
 Dim temp As String

 If (num > 65535) Then
  LngToDecInt = "-----"
  Exit Function
 End If

 temp = Trim(Str(num))
 Do While Len(temp) < 5
  temp = " " + temp
 Loop

 LngToDecInt = temp

End Function

Public Function LngToHexByte(ByVal num As Long) As String
 Dim temp As String

 If (num > 255) Then
  LngToHexByte = "--"
  Exit Function
 End If

 temp = Trim(Hex(num))
 If (Len(temp) = 1) Then temp = "0" + temp

 LngToHexByte = temp

End Function

Public Function LngToHexInt(ByVal num As Long) As String
 Dim temp As String

 If (num > 65535) Then
  LngToHexInt = "----"
  Exit Function
 End If

 temp = Trim(Hex(num))
 Do While Len(temp) < 4
  temp = "0" + temp
 Loop

 LngToHexInt = temp

End Function

Public Function IsHex(ByVal numstr As String) As Boolean
 Dim i As Long
 Dim testchr As Integer

 IsHex = False
 If (numstr = "") Then Exit Function

 i = 0
 Do Until i = Len(numstr)
  testchr = Asc(Right(numstr, Len(numstr) - i))
  Select Case testchr
   Case Asc("0") To Asc("9"), Asc("a") To Asc("f"), Asc("A") To Asc("F")
    i = i + 1
   Case Else
    Exit Function
  End Select
 Loop

 IsHex = True

End Function

End Module


