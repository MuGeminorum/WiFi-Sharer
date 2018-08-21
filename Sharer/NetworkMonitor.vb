Imports System.Timers
Imports System.Collections
Imports System.Diagnostics
''' <summary>
''' The NetworkMonitor class monitors network speed for each network adapter on the computer,
''' using classes for Performance counter in .NET library.
''' </summary>
Public Class NetworkMonitor
    Private timer As Timer
    ' The timer event executes every second to refresh the values in adapters.
    Private m_adapters As ArrayList
    ' The list of adapters on the computer.
    Private monitoredAdapters As ArrayList
    ' The list of currently monitored adapters.
    Public Sub New()
        Me.m_adapters = New ArrayList()
        Me.monitoredAdapters = New ArrayList()
        EnumerateNetworkAdapters()

        timer = New Timer(1000)
        AddHandler timer.Elapsed, New ElapsedEventHandler(AddressOf timer_Elapsed)
    End Sub
    ''' <summary>
    ''' Enumerates network adapters installed on the computer.
    ''' </summary>
    Private Sub EnumerateNetworkAdapters()
        Dim category As New PerformanceCounterCategory("Network Interface")

        For Each name As String In category.GetInstanceNames()
            ' This one exists on every computer.
            If name.ToString Like "*isatap*" Or Mid(name.ToString, 1, 33) = "Teredo Tunneling Pseudo-Interface" Then Continue For

            ' Create an instance of NetworkAdapter class, and create performance counters for it.
            Dim adapter As New NetworkAdapter(name)
            adapter.dlCounter = New PerformanceCounter("Network Interface", "Bytes Received/sec", name)
            adapter.ulCounter = New PerformanceCounter("Network Interface", "Bytes Sent/sec", name)
            ' Add it to ArrayList adapter
            Me.m_adapters.Add(adapter)

        Next
    End Sub

    Private Sub timer_Elapsed(sender As Object, e As ElapsedEventArgs)
        For Each adapter As NetworkAdapter In Me.monitoredAdapters
            adapter.refresh()
        Next
    End Sub
    ''' <summary>
    ''' Get instances of NetworkAdapter for installed adapters on this computer.
    ''' </summary>
    Public ReadOnly Property Adapters() As NetworkAdapter()
        Get
            Return DirectCast(Me.m_adapters.ToArray(GetType(NetworkAdapter)), NetworkAdapter())
        End Get
    End Property
    ''' <summary>
    ''' Enable the timer and add all adapters to the monitoredAdapters list, 
    ''' unless the adapters list is empty.
    ''' </summary>
    Public Sub StartMonitoring()

        If Me.m_adapters.Count > 0 Then
            For Each adapter As NetworkAdapter In Me.m_adapters
                If Not Me.monitoredAdapters.Contains(adapter) Then
                    Me.monitoredAdapters.Add(adapter)
                    adapter.init()
                End If
            Next
            timer.Enabled = True
        End If
    End Sub
    ''' <summary>
    ''' Enable the timer, and add the specified adapter to the monitoredAdapters list
    ''' </summary>
    Public Sub StartMonitoring(adapter As NetworkAdapter)
        If Not Me.monitoredAdapters.Contains(adapter) Then
            Me.monitoredAdapters.Add(adapter)
            adapter.init()
        End If
        timer.Enabled = True
    End Sub
    ''' <summary>
    ''' Disable the timer, and clear the monitoredAdapters list.
    ''' </summary>
    Public Sub StopMonitoring()
        Me.monitoredAdapters.Clear()
        timer.Enabled = False
    End Sub
    ''' <summary>
    ''' Remove the specified adapter from the monitoredAdapters list, and 
    ''' disable the timer if the monitoredAdapters list is empty.
    ''' </summary>
    Public Sub StopMonitoring(adapter As NetworkAdapter)
        If Me.monitoredAdapters.Contains(adapter) Then
            Me.monitoredAdapters.Remove(adapter)
        End If
        If Me.monitoredAdapters.Count = 0 Then
            timer.Enabled = False
        End If
    End Sub
End Class

