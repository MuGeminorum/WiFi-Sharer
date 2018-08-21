Module UpdateClients

    Structure Clist
        Dim Name As String
        Dim Mac As String
        Dim FontColor As Color
    End Structure

    Structure ClistNeedEnum
        Dim isNeedFresh As Boolean
        Dim TipType As String
        Dim NotifyMessage As String
    End Structure

    Private Function JudgExist(ByVal ini As String, ByVal mac As String()) As Boolean
        Dim user As Boolean = False
        Dim n As Integer = mac.Count
        If n > 0 Then
            For i As Integer = 0 To n - 1
                If ini = mac(i) Then
                    user = True
                    Exit For
                End If
            Next
        End If
        Return user
    End Function

    Public Function MacList(ByVal n As Integer) As String()
        If n > 0 Then
            Dim s(0 To n - 1) As String
            For i = 0 To n - 1
                Dim a = New System.Text.StringBuilder(255)
                GetMacList(a, i)
                s(i) = a.ToString
            Next
            Return s
        Else
            Return Nothing
        End If
    End Function

    Public Function ClistNeedFresh(ByVal OldMacList As String(), ByVal NewMacList As String(), ByVal b2 As Boolean, ByVal b3 As Boolean) As ClistNeedEnum
        Dim ReturnClistNeed As ClistNeedEnum
        Dim Tip As String = "Message"
        Dim NotifyEnum As String = ""

        Dim OldPeerNum As Integer = 0
        If Not OldMacList Is Nothing Then OldPeerNum = OldMacList.Count

        Dim n As Integer = 0
        If Not NewMacList Is Nothing Then n = NewMacList.Count

        Dim NeedFresh As Boolean = False

        If (OldPeerNum = n And (OldPeerNum > 0 Or n > 0)) Or (OldPeerNum <> n) Then

            If n = 0 Then
                NeedFresh = True
                For i As Integer = 0 To OldMacList.Count - 1
                    If b2 Then
                        Dim dn As String = GetINI("Device", OldMacList(i))
                        If NotifyEnum = "" Then
                            NotifyEnum = "Partner '" & dn & "' has left your Hotspot."
                        Else
                            NotifyEnum = NotifyEnum & vbCrLf & "Partner '" & dn & "' has left your Hotspot."
                        End If
                        Tip = "Partner status changed"
                    End If
                    'partner "OldMacList(i)" has left your hotspot   log out(OldMacList(i))
                Next

            ElseIf OldPeerNum = 0 Then
                NeedFresh = True
                For i = 0 To NewMacList.Count - 1
                    If GetINI("Device", NewMacList(i)) <> "" Then
                        If b2 Then
                            Dim dn As String = GetINI("Device", NewMacList(i))
                            If NotifyEnum = "" Then
                                NotifyEnum = "Partner '" & dn & "' has joined your Hotspot."
                            Else
                                NotifyEnum = NotifyEnum & vbCrLf & "Partner '" & dn & "' has joined your Hotspot."
                            End If
                            Tip = "Partner status changed"
                        End If
                        'log in(NewMacList(i))
                    Else
                        If b3 Then
                            Dim dn As String = NewMacList(i)
                            If NotifyEnum = "" Then
                                NotifyEnum = "New friend '" & dn & "' has joined your Hotspot."
                            Else
                                NotifyEnum = NotifyEnum & vbCrLf & "New friend '" & dn & "' has joined your Hotspot."
                            End If
                            Tip = "New device joined"
                        End If
                        'check in(NewMacList(i))
                    End If
                Next
            Else
                For i As Integer = 0 To OldMacList.Count - 1
                    If Not JudgExist(OldMacList(i), NewMacList) Then
                        NeedFresh = True
                        If b2 Then
                            Dim dn As String = GetINI("Device", OldMacList(i))
                            If NotifyEnum = "" Then
                                NotifyEnum = "Partner '" & dn & "' has left your Hotspot."
                            Else
                                NotifyEnum = NotifyEnum & vbCrLf & "Partner '" & dn & "' has left your Hotspot."
                            End If
                            Tip = "Partner status changed"
                        End If
                        'partner "OldMacList(i)" has left your hotspot   log out(OldMacList(i))
                    End If
                Next
                For i = 0 To NewMacList.Count - 1
                    If Not JudgExist(NewMacList(i), OldMacList) Then
                        NeedFresh = True
                        If GetINI("Device", NewMacList(i)) <> "" Then
                            If b2 Then
                                Dim dn As String = GetINI("Device", NewMacList(i))
                                If NotifyEnum = "" Then
                                    NotifyEnum = "Partner '" & dn & "' has joined your Hotspot."
                                Else
                                    NotifyEnum = NotifyEnum & vbCrLf & "Partner '" & dn & "' has joined your Hotspot."
                                End If
                                Tip = "Partner status changed"
                            End If
                            'log in(NewMacList(i))
                        Else
                            If b3 Then
                                Dim dn As String = NewMacList(i)
                                If NotifyEnum = "" Then
                                    NotifyEnum = "New friend '" & dn & "' has joined your Hotspot."
                                Else
                                    NotifyEnum = NotifyEnum & vbCrLf & "New friend '" & dn & "' has joined your Hotspot."
                                End If
                                Tip = "New device joined"
                            End If
                            'check in(NewMacList(i))
                        End If
                    End If
                Next
            End If
        End If
        ReturnClistNeed.isNeedFresh = NeedFresh
        ReturnClistNeed.TipType = Tip
        ReturnClistNeed.NotifyMessage = NotifyEnum
        Return ReturnClistNeed
    End Function


    Public Function ClistFreshList(ByVal ini As Sections(), ByVal NewMacList As String()) As Clist()
        Dim m As Integer = ini.Count
        Dim n As Integer

        If NewMacList Is Nothing Then
            n = 0
        Else
            n = NewMacList.Count
        End If

        Dim k As Integer = 0

        Dim clients(0 To m + n - 1) As Clist

        If m > 0 Then 'ini
            For i As Integer = 0 To m - 1
                If n > 0 Then
                    If Not JudgExist(ini(i).Mac, NewMacList) Then
                        clients(n + k).Mac = ini(i).Mac
                        clients(n + k).Name = GetINI("Device", ini(i).Mac)
                        clients(n + k).FontColor = Color.DimGray
                        k += 1
                    End If
                Else
                    clients(n + k).Mac = ini(i).Mac
                    clients(n + k).Name = GetINI("Device", ini(i).Mac)
                    clients(n + k).FontColor = Color.DimGray
                    k += 1
                End If
            Next
        End If

        If n > 0 Then 'NewMacList
            For i = 0 To n - 1
                clients(n - 1 - i).FontColor = Color.DodgerBlue
                clients(n - 1 - i).Mac = NewMacList(i)
                If GetINI("Device", NewMacList(i)) <> "" Then
                    clients(n - 1 - i).Name = GetINI("Device", NewMacList(i))
                    'log in
                Else
                    clients(n - 1 - i).Name = clients(n - 1 - i).Mac
                    WriteINI("Device", NewMacList(i), NewMacList(i))
                    'check in
                End If
            Next
        End If

        Dim FreshClist(0 To n + k - 1) As Clist
        For i = 0 To n + k - 1
            FreshClist(i) = clients(i)
        Next

        Return FreshClist
    End Function

End Module
