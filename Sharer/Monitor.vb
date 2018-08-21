Imports System.Timers
Public Class Monitor
    Dim oldLocation As Point
    Dim IsMouseDown As Boolean
    Dim SUTimers(0 To 1) As Timers.Timer
    Private MyAdapters() As NetworkAdapter
    Dim OldX, OldY, OldFormX, OldFormY, SelectedIndex, wire, wireless As Integer

    Private Delegate Sub SelectSourceDel(hwnd As Boolean)
    Private Delegate Sub SpeedStringDel(ds As String, us As String)

    Private Sub TimerInit()
        SUTimers(0) = New System.Timers.Timer(1500)
        AddHandler SUTimers(0).Elapsed, New ElapsedEventHandler(AddressOf AjaxAdapter)

        SUTimers(1) = New System.Timers.Timer(100)
        AddHandler SUTimers(1).Elapsed, New ElapsedEventHandler(AddressOf SpeedUpdateTimer_Tick)
    End Sub

    Private Sub InitMonitor()
        Dim initStatus As GetCurrEnum = SelectSourceNet()
        wire = initStatus.cLAN
        wireless = initStatus.cWAN
        InitMenu(wire = 2 And wireless = 1)
    End Sub


    Private Sub AjaxAdapter()

        Dim cStatus As GetCurrEnum = SelectSourceNet()

        Dim cwire As Integer = cStatus.cLAN
        Dim cwireless As Integer = cStatus.cWAN

        Dim f23 As Boolean = wire <> cwire And wire = cwireless And wireless = cwire
        Dim f13 As Boolean = wire <> cwire And wireless = 1 And cwireless = 1
        Dim f34 As Boolean = wireless <> cwireless And wire = 2 And cwire = 2

        If f23 Or f13 Or f34 Then
            Me.Invoke(New SelectSourceDel(AddressOf InitMenu), (cwire = 2 And cwireless = 1))

            wire = cwire
            wireless = cwireless
        End If

    End Sub


    Public Sub InitMenu(hwnd As Boolean)
        Dim MyMonitor = New NetworkMonitor
        MyAdapters = MyMonitor.Adapters
        Dim TempMenuStrip As ToolStripMenuItem = SpeedMenu.Items(0)
        TempMenuStrip.DropDownItems.Clear()
        If MyAdapters.Count > 0 Then
            For i = 0 To MyAdapters.Count - 1
                TempMenuStrip.DropDownItems.Add(MyAdapters(i).ToString)
                AddHandler TempMenuStrip.DropDownItems(i).Click, AddressOf MenuNetDisk_Click
            Next
            ChangeSelectedIndex(-1, hwnd)
            MyMonitor.StopMonitoring()
            MyMonitor.StartMonitoring(MyAdapters(SelectedIndex))
            SUTimers(1).Start()
        Else
            If Panel(5) Then Sharer.TrayIcon.ShowBalloonTip(0, "Net monitor", "Failed to initialize adapter list.", ToolTipIcon.Warning)
            ChooseNetDisk.Enabled = False
        End If
    End Sub

    Private Sub ChangeSelectedIndex(ByVal NewIndex As Integer, Optional hwnd As Boolean = False)
        If NewIndex = -1 Then
            For i = 0 To MyAdapters.Count - 1

                If hwnd Then

                    If MyAdapters(i).ToString Like "*802.11*" Then
                        Dim TempMenuStrip As ToolStripMenuItem = SpeedMenu.Items(0)
                        MenuNetDisk_Click(TempMenuStrip.DropDownItems(i), New EventArgs)
                        Exit Sub
                    End If

                Else

                    If MyAdapters(i).ToString Like "*Controller*" Or MyAdapters(i).ToString Like "*控制器*" Then
                        Dim TempMenuStrip As ToolStripMenuItem = SpeedMenu.Items(0)
                        MenuNetDisk_Click(TempMenuStrip.DropDownItems(i), New EventArgs)
                        Exit Sub
                    End If

                End If
            Next
            If SelectedIndex = -1 Then Exit Sub
        Else
            SelectedIndex = NewIndex
        End If
    End Sub

    Private Sub SpeedUpdateTimer_Tick()
        Dim tempAdapter As NetworkAdapter = MyAdapters(SelectedIndex) 
        Me.Invoke(New SpeedStringDel(AddressOf UpdateSpeed), tempAdapter.DownloadSpeedString, tempAdapter.UploadSpeedString)
    End Sub

    Private Sub UpdateSpeed(ds As String, us As String)
        DLSpeedLabel.Text = ds
        ULSpeedLabel.Text = us
    End Sub

    Private Sub InitMonitorUI()

        Me.Width = 240
        Me.Height = 30
        Me.TopMost = True
        DLSpeedLabel.ForeColor = Color.DimGray
        ULSpeedLabel.ForeColor = Color.DimGray

        Dim ML As String = GetINI("Monitor", "Left")
        Dim MT As String = GetINI("Monitor", "Top")

        If isNum(ML) And isNum(MT) Then

            Select Case Val(ML)
                Case Is < 0
                    Me.Left = 0
                Case Is < WBound - 240
                    Me.Left = Val(ML)
                Case Else
                    Me.Left = WBound - 240
            End Select

            Select Case Val(MT)
                Case Is < 0
                    Me.Top = 0
                Case Is < HBound - 30
                    Me.Top = Val(MT)
                Case Else
                    Me.Top = HBound - 30
            End Select

        Else
            Me.Left = WBound - 240
            Me.Top = HBound - 30
        End If

        Select Case Val(GetINI("Monitor", "Opacity"))
            Case 0.25
                MenuPercent_Click(Percent_25, Nothing)
            Case 0.5
                MenuPercent_Click(Percent_50, Nothing)
            Case 0.75
                MenuPercent_Click(Percent_75, Nothing)
            Case 1.0
                MenuPercent_Click(Percent_100, Nothing)
            Case Else
                MenuPercent_Click(Percent_90, Nothing)
        End Select

    End Sub
    Private Sub Speed_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Call TimerInit() 
        Call InitMonitorUI()
        Call InitMonitor()
        SUTimers(0).Start()
    End Sub

    Private Sub Speed_UnLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Disposed
        WriteINI("Monitor", "Left", Me.Location.X)
        WriteINI("Monitor", "Top", Me.Location.Y)
        WriteINI("Monitor", "Opacity", Me.Opacity)
    End Sub

    Private Sub Monitor_VisibleChange(ByVal sender As Object, ByVal e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            TimerOperate(SUTimers, 1)
        Else
            TimerOperate(SUTimers, 2)
        End If
    End Sub

    Private Sub TableLayoutPanel1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles DLSpeedLabel.MouseDown, ULSpeedLabel.MouseDown, TableLayoutPanel1.MouseDown, Me.MouseDown, PictureBox1.MouseDown, PictureBox2.MouseDown
        IsMouseDown = True
        OldFormX = Me.Location.X
        OldFormY = Me.Location.Y
        OldX = Cursor.Position.X
        OldY = Cursor.Position.Y
    End Sub

    Private Sub TableLayoutPanel1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles DLSpeedLabel.MouseUp, ULSpeedLabel.MouseUp, TableLayoutPanel1.MouseUp, Me.MouseUp, PictureBox1.MouseUp, PictureBox2.MouseUp
        IsMouseDown = False
        If Me.Top < 0 Then
            Me.Top = 0
        ElseIf Me.Top > HBound - Me.Height Then
            Me.Top = HBound - Me.Height
        End If

        If Me.Left < 0 Then
            Me.Left = 0
        ElseIf Me.Left > WBound - Me.Width Then
            Me.Left = WBound - Me.Width
        End If
        If e.Button = MouseButtons.Right Then TableLayoutPanel1.ContextMenuStrip.Show()
    End Sub

    Private Sub Speed_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles DLSpeedLabel.MouseMove, ULSpeedLabel.MouseMove, TableLayoutPanel1.MouseMove, Me.MouseMove, PictureBox1.MouseMove, PictureBox2.MouseMove
        If IsMouseDown Then Me.Location = New Point(OldFormX + Cursor.Position.X - OldX, OldFormY + Cursor.Position.Y - OldY)
    End Sub

    Private Sub Speed_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles DLSpeedLabel.MouseDoubleClick, ULSpeedLabel.MouseDoubleClick, TableLayoutPanel1.MouseDoubleClick, Me.MouseDoubleClick, PictureBox1.MouseDoubleClick, PictureBox2.MouseDoubleClick
        Call Sharer.RestoreWin()
    End Sub

    Private Sub MenuNetDisk_Click(ByVal sender As ToolStripMenuItem, ByVal e As EventArgs)
        Dim TempMenuStrip As ToolStripMenuItem = SpeedMenu.Items(0)
        For Each SubItem In TempMenuStrip.DropDownItems
            SubItem.checked = False
        Next
        sender.Checked = True
        ChangeSelectedIndex(TempMenuStrip.DropDownItems.IndexOf(sender))
    End Sub

    Private Sub MenuPercent_Click(ByVal sender As ToolStripMenuItem, ByVal e As EventArgs) Handles Percent_25.Click, Percent_50.Click, Percent_75.Click, Percent_90.Click, Percent_100.Click
        For Each SubItem In OpacityMenu.Items
            SubItem.checked = False
        Next
        sender.Checked = True
        Me.Opacity = sender.Tag * 0.01
    End Sub

    Private Sub MenuExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitTool.Click
        Me.Hide()
    End Sub

End Class
