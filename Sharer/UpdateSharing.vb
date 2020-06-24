Module UpdateSharing

    Structure GetCurrEnum
 
        Dim cLAN As String
        Dim cWAN As String
    End Structure

    Public Function SelectSourceNet() As GetCurrEnum
        Dim res As GetCurrEnum
        Dim cwire As Integer = 2
        Dim cwireless As Integer = 2
        Dim nics() As System.Net.NetworkInformation.NetworkInterface = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
        If nics.Length > 0 Then
            For Each netState In nics
                If netState.Description Like "*Controller*" Or netState.Description Like "*控制器*" Then

                    cwire = netState.OperationalStatus

                ElseIf netState.Description Like "*802.11*" Then

                    cwireless = netState.OperationalStatus

                ElseIf netState.Description Like "*Software Loopback Interface*" Then

                    Exit For

                End If
            Next
        End If
        res.cLAN = cwire
        res.cWAN = cwireless
        Return res
    End Function

    'Private Function iStop() As Boolean
    '    Dim istopped As Boolean = True
    '    Dim nics() As System.Net.NetworkInformation.NetworkInterface = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
    '    If nics.Length > 0 Then
    '        For Each netState In nics
    '            If netState.Description Like "*Microsoft*" And (netState.Description Like "*适配器*" Or netState.Description Like "*Adapter*") Then
    '                istopped = (netState.OperationalStatus = 2)
    '                Exit For
    '            ElseIf netState.Description Like "*Software Loopback Interface*" Then
    '                Exit For
    '            End If
    '        Next
    '    End If
    '    Return istopped
    'End Function


    Public Function GetCurrStatus() As GetCurrEnum
        Dim ReturnGetCurr As GetCurrEnum
        Dim nics() As System.Net.NetworkInformation.NetworkInterface

 
        Dim cwan As String = ""
        Dim clan As String = ""
        Dim clan1 As String = ""
        Dim clan2 As String = ""

RetryNetList:

        nics = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()

        If nics.Length > 0 Then
            For Each netState In nics
                If netState.OperationalStatus = 1 Then

                    If netState.Description Like "*Microsoft*" And (netState.Description Like "*适配器*" Or netState.Description Like "*Adapter*") Then

                        cwan = netState.Name

                    ElseIf netState.Description Like "*Controller*" Or netState.Description Like "*控制器*" Then

                        clan1 = netState.Name

                    ElseIf netState.Description Like "*802.11*" Then

                        clan2 = netState.Name

                    ElseIf netState.Description Like "*Software Loopback Interface*" Or (cwan <> "" And clan1 <> "" And clan2 <> "") Then

                        Exit For

                    End If

                End If
            Next

            If clan1 <> "" Then
                clan = clan1
            Else
                clan = clan2
            End If

        Else
            GoTo RetryNetList
        End If

        ReturnGetCurr.cLAN = clan
        ReturnGetCurr.cWAN = cwan
 

        Return ReturnGetCurr
    End Function

End Module
