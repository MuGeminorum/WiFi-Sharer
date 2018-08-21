Module UnSleep
    Const ES_SYSTEM_REQUIRED As Integer = &H1
    Const ES_DISPLAY_REQUIRED As Integer = &H2

    Private Declare Function SetThreadExecutionState Lib "Kernel32" (ByVal esFlag As Integer) As Integer

    Public Sub UnSleep_Tick()
        Call SetThreadExecutionState(ES_DISPLAY_REQUIRED)
        Call SetThreadExecutionState(ES_SYSTEM_REQUIRED)
    End Sub

End Module
 
