Imports IWshRuntimeLibrary

Module ShortCut

    Public Function CreateShortCut(ByVal dpath As String)
        Try
            Dim WshShell As New WshShell
            Dim shortCut As IWshRuntimeLibrary.IWshShortcut
            shortCut = CType(WshShell.CreateShortcut(dpath & "\Sharer.lnk"), IWshRuntimeLibrary.IWshShortcut)
            With shortCut
                .TargetPath = StartupPath & "\Launcher.exe" 'Application.ExecutablePath
                .WindowStyle = 1
                .Description = Application.ProductName
                .IconLocation = System.Reflection.Assembly.GetExecutingAssembly.Location() & ", 0"
                .Save()
            End With
            'MsgBox(path & " " & Application.ExecutablePath.ToString & " " & System.Reflection.Assembly.GetExecutingAssembly.Location().ToString)
            Return True
        Catch ex As System.Exception
            Return False
        End Try
    End Function

    Public Sub DesktopShortcut(ByVal des As Boolean)
        Dim desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        If des Then
            If Dir(desktopPath & "\Sharer.lnk") = "" Then CreateShortCut(desktopPath)
        Else
            If Dir(desktopPath & "\Sharer.lnk") <> "" Then Kill(desktopPath & "\Sharer.lnk")
        End If
    End Sub

    Public Sub writeReg(ByVal ord As Boolean)

        Dim Reg As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True) 'LocalMachine
        If Reg Is Nothing Then Reg = My.Computer.Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run")

        If ord Then
            If Reg.GetValue("SHARER") Is Nothing Then Reg.SetValue("SHARER", StartupPath & "\Launcher.exe") 'Application.ExecutablePath)  Reg.SetValue("SHARER", StartupPath & "\Launcher.exe")
        Else
            If Reg.GetValue("SHARER") IsNot Nothing Then Reg.DeleteValue("SHARER")
        End If

    End Sub

End Module
