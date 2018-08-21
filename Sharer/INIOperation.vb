Module INIOperation
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32
    Private Declare Function GetPrivateProfileSection Lib "kernel32" Alias "GetPrivateProfileSectionA" (ByVal lpAppName As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    Structure Sections
        Dim Mac As String
        Dim Name As String
    End Structure

    Public Function GetINI(ByVal Section As String, ByVal AppName As String) As String
        Dim FileName As String = StartupPath & "\Data.ini"
        Dim lpDefault As String = ""
        Dim Str As String = ""
        Str = LSet(Str, 255)
        GetPrivateProfileString(Section, AppName, lpDefault, Str, Len(Str), FileName)
        Return Trim(Microsoft.VisualBasic.Left(Str, InStr(Str, Chr(0)) - 1))
    End Function

    Public Function WriteINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String) As Long
        Dim FileName As String = StartupPath & "\Data.ini"
        WriteINI = WritePrivateProfileString(Trim(Section), Trim(AppName), Trim(lpDefault), FileName)
    End Function

    Public Function GetAllSection(ByVal strSection As String) As Sections()
        Dim strReturn As String = ""
        Dim FileName As String = StartupPath & "\Data.ini"
        strReturn = LSet(strReturn, 255)

        Dim strTmp As String
        Dim nStart As Integer
        Dim nEnd As Integer
        Dim i As Integer = 0
        Dim sArray(0 To 0) As Sections

        GetPrivateProfileSection(strSection, strReturn, Len(strReturn), FileName)
        strTmp = strReturn

        Do While strTmp <> ""
            nStart = nEnd + 1
            nEnd = InStr(nStart, strReturn, vbNullChar)
            strTmp = Mid$(strReturn, nStart, nEnd - nStart)

            If Len(strTmp) > 0 Then
                ReDim Preserve sArray(0 To i)
                sArray(i).Mac = Trim(strTmp.Split("=")(0))
                sArray(i).Name = Trim(strTmp.Split("=")(1))
                i += 1
            End If
        Loop

        Return sArray
    End Function

    Public Sub CreateINI()
        If Dir(StartupPath & "\Data.ini") = "" Then

            Dim MyStream As New System.IO.FileStream(StartupPath & "\Data.ini", System.IO.FileMode.Create)
            MyStream.Close()

            WriteINI("User", "SSID", "WifiHotSpot")
            WriteINI("User", "Key", "1234567890")
            WriteINI("User", "HidePass", "False")

            WriteINI("Setting", "Boot", "False")
            WriteINI("Setting", "AutoShare", "False")
            WriteINI("Setting", "AutoHide", "False")
            WriteINI("Setting", "Shortcut", "True")
            WriteINI("Setting", "MonitorOn", "True")
            WriteINI("Setting", "NotifyOn", "False")

            WriteINI("Notify", "Reconnect", "False")
            WriteINI("Notify", "WLReminder", "False")
            WriteINI("Notify", "DSReminder", "False")
            WriteINI("Notify", "NewDevice", "False")

            WriteINI("Monitor", "Left", (WBound - 240).ToString)
            WriteINI("Monitor", "Top", (HBound - 30).ToString)
            WriteINI("Monitor", "Opacity", "0.9")

        End If
    End Sub

End Module
