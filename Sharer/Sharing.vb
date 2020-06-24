Imports NETCONLib
Module Sharing

    Private Sub SharingDisabled()
        Dim sharing As INetSharingConfiguration
        Dim netSharingMgr As New NetSharingManager
        Dim connections As INetSharingEveryConnectionCollection

        connections = netSharingMgr.EnumEveryConnection
        For Each Conn In connections
            sharing = netSharingMgr.INetSharingConfigurationForINetConnection((Conn))
            sharing.DisableSharing()
        Next
    End Sub

    Private Function SharingEnabled() As Boolean
        Dim enabled As Boolean = False
        Dim sharing As INetSharingConfiguration
        Dim netSharingMgr As New NetSharingManager
        Dim connections As INetSharingEveryConnectionCollection

        connections = netSharingMgr.EnumEveryConnection
        For Each Conn In connections
            sharing = netSharingMgr.INetSharingConfigurationForINetConnection((Conn))
            If sharing.SharingEnabled() Then
                enabled = True
                Exit For
            End If
        Next
        Return enabled
    End Function

    Public Sub DisableSharing()
        Do
            Call SharingDisabled()
        Loop Until Not SharingEnabled()
    End Sub

    Public Sub EnableSharing(ByVal SourceNetwork As String, ByVal Destination As String)
RetryShare:
        Call DisableSharing()

        Try

            Dim connProps As INetConnectionProps
            Dim sharing As INetSharingConfiguration
            Dim netSharingMgr As New NetSharingManager
            Dim connections As INetSharingEveryConnectionCollection

            connections = netSharingMgr.EnumEveryConnection
            For Each Conn In connections
                connProps = netSharingMgr.NetConnectionProps(Conn)
                sharing = netSharingMgr.INetSharingConfigurationForINetConnection((Conn))

                If connProps.Name = SourceNetwork Then
                    sharing.EnableSharing(tagSHARINGCONNECTIONTYPE.ICSSHARINGTYPE_PUBLIC)
                ElseIf connProps.Name = Destination Then
                    sharing.EnableSharing(tagSHARINGCONNECTIONTYPE.ICSSHARINGTYPE_PRIVATE)
                End If

            Next

        Catch ex As Exception

            If ex.ToString <> "" Then GoTo RetryShare
 
        End Try

    End Sub

End Module
