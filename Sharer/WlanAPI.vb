Imports System.Runtime.InteropServices
Module WlanAPI
 
    <DllImport("HostNetlib.dll", EntryPoint:="InitHostedNetWork")>
    Public Function InitHostedNetWork() As Integer
    End Function

    <DllImport("HostNetlib.dll", EntryPoint:="ExitHostedNetWork")>
    Public Function ExitHostedNetWork() As Integer
    End Function

    <DllImport("HostNetlib.dll", EntryPoint:="StartHostedNetWork")>
    Public Function StartHostedNetWork() As Integer
    End Function

    <DllImport("HostNetlib.dll", EntryPoint:="StopHostedNetWork")>
    Public Function StopHostedNetWork() As Integer
    End Function

    <DllImport("HostNetlib.dll", EntryPoint:="GetPeerNumber")>
    Public Function GetPeerNumber() As Integer
    End Function

    <DllImport("HostNetlib.dll", EntryPoint:="HostedNetworkOn")>
    Public Function HostedNetworkOn() As Integer
    End Function

    <DllImport("HostNetlib.dll", EntryPoint:="AllowHostedNetWork", CallingConvention:=CallingConvention.Cdecl)>
    Public Function AllowHostedNetWork(ByVal allow As Boolean) As Integer 
    End Function

    <DllImport("HostNetlib.dll", EntryPoint:="SetSSID", CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetSSID(ByVal ssid As Char()) As Integer
    End Function

    <DllImport("HostNetlib.dll", EntryPoint:="SetKEY", CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetKEY(ByVal key As Char()) As Integer
    End Function

    <DllImport("HostNetlib.dll", EntryPoint:="GetMacList", CallingConvention:=CallingConvention.Cdecl)>
    Public Function GetMacList(ByVal TargetString As System.Text.StringBuilder, ByVal n As Integer) As Integer
    End Function

End Module
