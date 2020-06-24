Imports System.Net.NetworkInformation
Module UpdateIntConnState

    Structure NetOnEnum
        Dim NetOnMessage As Integer
        Dim NetypeMessage As String
    End Structure

    Public Sub NetStop()
        Do
            Call StopHostedNetWork()
        Loop Until HostedNetworkOn() < 0
    End Sub

    Private Function Ping(ByVal ip As String) As Integer
        Dim p As Ping = New Ping
        Dim reply As PingReply = p.Send(ip)
        If reply.Status = IPStatus.Success Then
            Return 1
        Else
            Return 2
        End If
    End Function

    Public Function NetworkAlive() As Integer
        Return Ping("13.107.21.200")
    End Function

    Public Function FontColor(ByVal netype As Integer) As Color
        If netype = 2 Then
            Return Color.DimGray
        Else
            Return Color.DodgerBlue
        End If
    End Function

    Public Function NetOnMessage(ByVal lConnected As Integer, ByVal nConnected As Integer, ByVal NetOn As Integer, ByVal cNetOn As Integer) As NetOnEnum
        Dim ReturnNetonMess As NetOnEnum
        Dim NetypeMess As String = ""
        Dim NetOnMess As Integer = 0

        If lConnected = 1 And nConnected = 2 Then
            NetypeMess = "Internet crashed, now is LAN mode."
        ElseIf lConnected = 2 And nConnected = 1 Then
            NetypeMess = "Internet recovered, now is WAN mode."
        End If

        If NetOn = 0 And cNetOn < 0 Then

            If cNetOn = -2 Then AllowHostedNetWork(True)
            Call StartHostedNetWork()
            NetOnMess = 1

        ElseIf NetOn < 0 And cNetOn < 0 Then

            If cNetOn = -2 Then AllowHostedNetWork(True)
            Call StartHostedNetWork()

        ElseIf NetOn < 0 And cNetOn = 0 Then

            NetOnMess = 2

        End If

        ReturnNetonMess.NetOnMessage = NetOnMess
        ReturnNetonMess.NetypeMessage = NetypeMess

        Return ReturnNetonMess
    End Function
End Module
