
Imports System.Threading
Module InitPublic
    Public isConnected As Integer
    Public Panel(0 To 9) As Boolean
    Public HBound = My.Computer.Screen.WorkingArea.Height
    Public WBound = My.Computer.Screen.WorkingArea.Width 'get screen height & width
    Public StartupPath As String = Application.StartupPath()

    Public Sub BeginThread(ByVal Th As Thread, ByRef Ad As ParameterizedThreadStart)
        EndThread(Th)
        Th = New Thread(Ad)
        Th.Start()
    End Sub

    Public Sub EndThread(ByVal Th As Thread)
        If Not IsNothing(Th) Then
            If Th.IsAlive Then
                Do
                    Th.Abort()
                Loop Until Not Th.IsAlive
            End If
        End If
    End Sub

    Public Function isBool(s As String)
        Return Trim(s).ToUpper = "TRUE" Or Trim(s).ToUpper = "FALSE"
    End Function
    Public Function isNum(s As String)
        Return Trim(s).Length = Val(s).ToString.Length
    End Function

    Public Sub TimerOperate(SUTimers As Timers.Timer(), order As Integer, Optional top As Integer = 0)
        If Not IsNothing(SUTimers) Then
            If SUTimers.Count > 0 Then

                Dim TimerNum As Integer = 0
                If top > 0 Then
                    TimerNum = top - 1
                Else
                    TimerNum = SUTimers.Count - 1
                End If

                Select Case order
                    Case 0
                        For i As Integer = 0 To TimerNum
                            SUTimers(i).Dispose()
                        Next
                    Case 1
                        For i As Integer = 0 To TimerNum
                            SUTimers(i).Start()
                        Next
                    Case 2
                        Dim istop As Boolean = True
                        Do
                            For i As Integer = 0 To TimerNum
                                SUTimers(i).Stop()
                                istop = Not SUTimers(i).Enabled And istop
                            Next
                        Loop Until istop
                End Select

            End If
        End If
    End Sub

End Module
