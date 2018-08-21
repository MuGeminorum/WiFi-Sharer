Imports Microsoft.VisualBasic.ApplicationServices

Imports System.IO
Imports System.Timers
Imports System.Threading

Public Class Sharer
    Dim oldLocation As Point
    Dim OldMacList As String()
    Dim HideKey, IsMouseDown As Boolean
    Dim WifiName, Pass, WAN, LAN As String
    Dim CreateThread, DisConnThread As Thread
    Dim OldX, OldY, OldFormX, OldFormY, OldPeerNum, NetOn As Integer

    Dim AllTimers(0 To 4) As System.Timers.Timer
    Private MyIcon(0 To 5), MyIconLoc(0 To 5) As Icon

    Dim IcoNum As Integer = 0

    Private Delegate Sub IcoDel(IcoNum As Integer)

    Private Delegate Sub FailDel()
    Private Delegate Sub CreateDel(hwnd As Boolean)
    Private Delegate Sub DisConnDel(hwnd As Boolean)

    Private Delegate Sub AjaxDel(k As Integer, NotifyMess As String(), client As Clist())
    Private Delegate Sub NetypeDel(netypemessage As String, fColor As Integer, hostedneton As Integer)

    'Private Sub StartTimers()

    '    For i As Integer = 0 To 3
    '        AllTimers(i).Start()
    '    Next
    'End Sub

    'Private Sub StopTimers()

    '    Do
    '        For i As Integer = 0 To 4
    '            AllTimers(i).Stop()
    '        Next
    '    Loop Until Not (AllTimers(0).Enabled Or AllTimers(1).Enabled Or AllTimers(2).Enabled Or AllTimers(3).Enabled Or AllTimers(4).Enabled)

    'End Sub

    'Private Sub DisposeTimers()

    '    For i As Integer = 0 To 4
    '        AllTimers(i).Dispose()
    '    Next
    'End Sub

    Private Sub InitMe()
        Me.Width = 378
        Me.Height = 270

        Me.Left = (WBound - Me.Width) * 0.5
        Me.Top = (HBound - Me.Height) * 0.5

        Me.TopMost = True
    End Sub

    '=========================================================  actions ===================================================================
    Private Sub ClosingSharer()

        TrayIcon.Visible = False
        If Panel(4) Then Monitor.Hide()
        Me.Hide()

        'Call DisposeTimers()
        TimerOperate(AllTimers, 0)
        Call TemPass()
        Call SavePass()

        Me.Dispose()
    End Sub

    Private Sub Sharer_QueryUnload() Handles MyBase.Disposed
        Call NetStop()
        Call DisableSharing()
        Call ExitHostedNetWork()

        System.Environment.Exit(0)
    End Sub


    Private Sub Sharer_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
            Close()
            Exit Sub
        End If

        If Not My.User.IsInRole(BuiltInRole.Administrator) Then
            MsgBox("Please run as admin.")
            Me.Dispose()
        Else

            Call InitNetlist()
            Call InitHostedNetWork()
            AllowHostedNetWork(True)

            Call CreateINI()

            Call InitMe()
            Call InitIcon()

            Call InitClist()
            Call LoadClist()

            Call InitSet()
            Call AppSet()
            Call UpdateSet()

            Call InitUser()
            Call InitCreateButton()

            If Panel(1) Then Call StartCreate()

        End If
    End Sub


    Private Sub WifiNameTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles WifiNameTextBox.TextChanged
        If WifiNameTextBox.Text <> "" Then
            If Not ((Asc(Microsoft.VisualBasic.Right(WifiNameTextBox.Text, 1)) > 47 And
                    Asc(Microsoft.VisualBasic.Right(WifiNameTextBox.Text, 1)) < 58) Or
                (Asc(Microsoft.VisualBasic.Right(WifiNameTextBox.Text, 1)) > 64 And
                    Asc(Microsoft.VisualBasic.Right(WifiNameTextBox.Text, 1)) < 91) Or
                (Asc(Microsoft.VisualBasic.Right(WifiNameTextBox.Text, 1)) > 96 And
                    Asc(Microsoft.VisualBasic.Right(WifiNameTextBox.Text, 1)) < 123) Or
                Microsoft.VisualBasic.Right(WifiNameTextBox.Text, 1) = "_") Then

                WifiNameTextBox.Text = Microsoft.VisualBasic.Left(WifiNameTextBox.Text, Len(WifiNameTextBox.Text) - 1)
                WifiNameTextBox.SelectionStart = Len(WifiNameTextBox.Text)
            End If
        End If

        Call InitCreateButton()
    End Sub

    Private Sub PassTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PassTextBox.TextChanged
        If PassTextBox.Text <> "" Then
            If Not ((Asc(Microsoft.VisualBasic.Right(PassTextBox.Text, 1)) > 47 And
                    Asc(Microsoft.VisualBasic.Right(PassTextBox.Text, 1)) < 58) Or
                (Asc(Microsoft.VisualBasic.Right(PassTextBox.Text, 1)) > 64 And
                    Asc(Microsoft.VisualBasic.Right(PassTextBox.Text, 1)) < 91) Or
                (Asc(Microsoft.VisualBasic.Right(PassTextBox.Text, 1)) > 96 And
                    Asc(Microsoft.VisualBasic.Right(PassTextBox.Text, 1)) < 123)) Then

                PassTextBox.Text = Microsoft.VisualBasic.Left(PassTextBox.Text, Len(PassTextBox.Text) - 1)
                PassTextBox.SelectionStart = Len(PassTextBox.Text)
            End If
        End If

        Call InitCreateButton()
    End Sub
 

    Private Sub ResetButton_Enabled(ByVal sender As Object, ByVal e As EventArgs) Handles WifiNameTextBox.TextChanged, PassTextBox.TextChanged
        ResetButton.Enabled = Not ((WifiName = WifiNameTextBox.Text) And (Pass = PassTextBox.Text))
    End Sub

    Private Sub WifiNameTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles WifiNameTextBox.KeyPress
        If e.KeyChar.Equals(Convert.ToChar(Keys.Enter)) Then PassTextBox.Focus()
    End Sub

    Private Sub PassTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PassTextBox.KeyPress
        Dim a As Char = Convert.ToChar(Keys.Enter)
        If e.KeyChar.Equals(a) Then CreateButton.Focus()
    End Sub

    Private Sub HideCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HideCheck.CheckedChanged
        If HideCheck.Checked Then
            PassTextBox.PasswordChar = "●"
            HideCheck.Image = My.Resources.hide
        Else
            PassTextBox.PasswordChar = ""
            HideCheck.Image = My.Resources.view
        End If

    End Sub

    Private Sub ClearImage_Click(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ClearImage.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            WifiNameTextBox.Text = ""
            PassTextBox.Text = ""
        End If
    End Sub

    Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveButton.Click
        Call SaveSet()
        Call AppSet()
    End Sub

    Private Sub SetDefault()
        BootCheck.Checked = False
        AutoCheck.Checked = False
        MiniCheck.Checked = False
        ShortcutCheck.Checked = True
        MonitorCheck.Checked = True

        NotifyOnRadio.Checked = False
        NotifyOffRadio.Checked = True

        WlanCheck.Checked = False
        InternetCheck.Checked = False
        PartnerCheck.Checked = False
        DeviceCheck.Checked = False
    End Sub
    Private Sub DefButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DefButton.Click
        Call SetDefault()

    End Sub


    Private Sub ToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem_Monitor.Click
        'Panel(4) = True
        Monitor.Show()
    End Sub

    Private Sub ResetButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ResetButton.Click

        WifiNameTextBox.Text = WifiName
        PassTextBox.Text = Pass
    End Sub

    Private Sub Close_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseImage.Click
        Call ClosingSharer()
    End Sub

    Private Sub Minimize_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MinimizeImage.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub TabControl_Changed(ByVal sender As Object, ByVal e As EventArgs) Handles TabControlMain.SelectedIndexChanged
        If TabControlMain.SelectedIndex = 1 Then UpdateSet()
    End Sub

    Private Sub ClistView_Edit(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ClistView.MouseDoubleClick
        If e.Button = MouseButtons.Left Then ClistView.SelectedItems.Item(0).BeginEdit()
    End Sub

    Private Sub ClistView_Delete(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ClistView.MouseClick
        If e.Button = MouseButtons.Right And ClistView.SelectedItems.Count > 0 Then DeleteMenu.Show(Cursor.Position.X, Cursor.Position.Y)
    End Sub

    Private Sub ContextMenuStrip2_Opening(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles DeleteMenu.MouseClick
        If e.Button = MouseButtons.Left Then
            Dim index As Integer
            Dim n As Integer = ClistView.SelectedItems.Count
            Dim key As String
            For i As Integer = 0 To n - 1
                key = ClistView.SelectedItems.Item(n - 1 - i).SubItems.Item(1).Text
                index = ClistView.SelectedIndices.Item(n - 1 - i)
                If ClistView.Items.Item(index).ForeColor = Color.DimGray Then
                    ClistView.Items.RemoveAt(index)
                    WriteINI("Device", key, vbNullString)
                End If
            Next

        End If
    End Sub

    Public Sub InitSharing()
        isConnected = NetworkAlive()
        If isConnected = 1 Then
            Dim initStatus As GetCurrEnum = GetCurrStatus()
            LAN = initStatus.cLAN
            WAN = initStatus.cWAN

            If LAN <> "" And WAN <> "" Then EnableSharing(LAN, WAN)
        End If
    End Sub


    Private Sub ClientTree_LabelEdit(ByVal sender As Object, ByVal e As LabelEditEventArgs) Handles ClistView.AfterLabelEdit
        Dim name As String = ClistView.SelectedItems.Item(0).SubItems.Item(1).Text
        Dim text As String = Trim(e.Label)

        If text <> "" And text <> ClistView.SelectedItems.Item(0).SubItems.Item(0).Text Then

            If LTrim(e.Label) <> e.Label Then
                e.CancelEdit = True
                ClistView.SelectedItems.Item(0).SubItems.Item(0).Text = text
            End If


            WriteINI("Device", name, text)

        Else
            e.CancelEdit = True
        End If
    End Sub

    Private Sub Clist_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ProgramPanel.MouseDown
        IsMouseDown = True
        OldFormX = Me.Location.X
        OldFormY = Me.Location.Y
        OldX = Cursor.Position.X
        OldY = Cursor.Position.Y
    End Sub

    Private Sub Clist_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ProgramPanel.MouseUp
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

    End Sub

    Private Sub Clist_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ProgramPanel.MouseMove
        If IsMouseDown Then Me.Location = New Point(OldFormX + Cursor.Position.X - OldX, OldFormY + Cursor.Position.Y - OldY)
    End Sub

    Private Sub Sharer_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = False
            Me.TrayIcon.Visible = True
        End If

    End Sub

    Private Sub ToolStripMenuItem0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenu_Off.Click
        Call StopCreate()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenu_On.Click
        Call StartCreate()
    End Sub

    Private Sub ShowToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem_Show.Click
        Call RestoreWin()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem_Exit.Click
        Call ClosingSharer()
    End Sub

    Public Sub RestoreWin()
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
    End Sub



    Private Sub CreateButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CreateButton.Click
        Call StartCreate()
    End Sub

    Private Sub DisButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DisButton.Click
        Call StopCreate()
    End Sub
    '===================================   create   ==========================================



    Private Sub StartCreate()
        UpdateCreateUI(False)
        BeginThread(CreateThread, AddressOf Create)
    End Sub

    Private Sub Create()
        Call NetStop()
        SetSSID(WifiName)
        SetKEY(Pass)
        Call SavePass()

        Dim dwRes As Integer = StartHostedNetWork() '12 is wlan_hosted_network_reason_interface_unavailable
        If dwRes = 0 Then
            Call InitSharing()
            Me.Invoke(New CreateDel(AddressOf UpdateCreateUI), True)
        Else
            Me.Invoke(New FailDel(AddressOf FailedUI))
        End If
    End Sub

    Private Sub FailedUI()
        IcoTimerOn(False)
        TrayIcon.Icon = MyIcon(0)
        If Panel(5) Then TrayIcon.ShowBalloonTip(0, "Failed to start WLAN", "This version of WLAN driver or computer does not support hosted network.", ToolTipIcon.Error)
        CLabel("Clients :", "--", Color.DimGray)
        ToolStripMenu_On.Checked = False
        ToolStripMenu_Off.Checked = True
        ToolStripMenu_Off.Enabled = False
        ProtectedPanel(True)
        Call RestoreWin()
    End Sub

    Private Sub UpdateCreateUI(hwnd As Boolean)

        If hwnd Then
            IcoTimerOn(False)
            DisButton.Enabled = True
            LockCheck.Enabled = True
            CLabel("Clients :", "0", FontColor(isConnected))

            If Panel(2) Then Me.WindowState = FormWindowState.Minimized
            'If Panel(4) Then Call MonitorUpdateUI()

            If isConnected <> 1 Then
                UpdateIco(4)
                If (Panel(5) And Panel(7)) Then TrayIcon.ShowBalloonTip(0, "Internet status changed", "Internet crashed, now is LAN mode.", ToolTipIcon.Info)
            Else
                UpdateIco(5)
            End If

            'Call StartTimers()
            TimerOperate(AllTimers, 1, 4)
        Else
            IcoTimerOn(True)
            CLabel("Starting  ", "...", Color.DimGray)
            ToolStripMenu_Off.Checked = False

            Call TemPass()
            ResetButton.Enabled = False
        End If

        ToolStripMenu_On.Checked = hwnd
        ToolStripMenu_Off.Enabled = hwnd
        ProtectedPanel(hwnd)

    End Sub


    '======================================   disconnect  ==============================================
    Private Sub IcoTimerOn(open As Boolean)
        If open Then
            IcoNum = 0
            AllTimers(4).Start()
        Else
            Do
                AllTimers(4).Stop()
            Loop Until Not AllTimers(4).Enabled
        End If
    End Sub

    Private Sub StopCreate()
        UpdateDisConnUI(False)
        BeginThread(DisConnThread, AddressOf DisConnect)
    End Sub

    Private Sub DisConnect()
        Call NetStop()
        Call DisableSharing()
        Me.Invoke(New CreateDel(AddressOf UpdateDisConnUI), True)
    End Sub


    Private Sub UpdateDisConnUI(hwnd As Boolean)

        If hwnd Then
            ToolStripMenu_On.Checked = False
            ToolStripMenu_Off.Checked = True
            CLabel("Clients :", "--", Color.DimGray)
            Call UnloadClist()
        Else
            'Call StopTimers()
            TimerOperate(AllTimers, 2)
            LockCheck.Enabled = False
            DisButton.Enabled = False
            ToolStripMenu_Off.Enabled = False
            TrayIcon.Icon = MyIcon(0)
        End If

        CreateButton.Enabled = hwnd
        ToolStripMenu_On.Enabled = hwnd
    End Sub

    Private Sub CLabel(t As String, n As String, c As Color)
        ConnectorLabel.Text = t
        ClientNumLabel.ForeColor = c
        ClientNumLabel.Text = n
    End Sub

    '==================================  Clist  (Client Tree View Freshing) ======================================



    Private Sub AjaxClist()

        Dim n As Integer = GetPeerNumber()
        If n < 0 Then n = 0
        Dim NewMacList As String() = MacList(n)
        Dim ini As Sections() = GetAllSection("Device")
        Dim cnf As ClistNeedEnum = ClistNeedFresh(OldMacList, NewMacList, (Panel(5) And Panel(8)), (Panel(5) And Panel(9)))

        Dim NeedFresh As Boolean = cnf.isNeedFresh
        Dim NotifyEnum(0 To 1) As String
        NotifyEnum(0) = cnf.NotifyMessage
        NotifyEnum(1) = cnf.TipType

        If ini.Count + n > 0 And NeedFresh Then
            Dim FreshClist As Clist() = ClistFreshList(ini, NewMacList)
            Me.Invoke(New AjaxDel(AddressOf AjaxUpdateUI), n, NotifyEnum, FreshClist)
        End If

        OldMacList = NewMacList
        OldPeerNum = n
    End Sub

    Private Sub AjaxUpdateUI(k As Integer, NotifyMess As String(), client As Clist())
        If ClientNumLabel.Text <> "--" Then
            Dim n As Integer = client.Count
            If n > 0 Then
                With ClistView.Items
                    .Clear()
                    For i As Integer = 0 To n - 1
                        Dim a = New ListViewItem
                        a.ForeColor = client(i).FontColor
                        a.SubItems.Item(0).Text = client(i).Name
                        a.SubItems.Add(client(i).Mac)
                        .Add(a)
                    Next
                End With
            End If
            ClientNumLabel.Text = k.ToString
            If NotifyMess(0) <> "" Then TrayIcon.ShowBalloonTip(0, NotifyMess(1), NotifyMess(0), ToolTipIcon.Info)
        End If
    End Sub

    '=================================================   Netype (Main UI Freshing)  =======================================================



    Private Sub Netype()

        Dim CurConnected As Integer = NetworkAlive()
        Dim cNetOn As Integer = HostedNetworkOn()

        Dim nom As NetOnEnum = NetOnMessage(isConnected, CurConnected, NetOn, cNetOn)
        Dim NetOnMess As Integer = nom.NetOnMessage
        Dim NetypeMess As String = nom.NetypeMessage

        Me.Invoke(New NetypeDel(AddressOf NetypeUpdateUI), NetypeMess, CurConnected, NetOnMess)

        isConnected = CurConnected
        NetOn = cNetOn

    End Sub

    Private Sub NetypeUpdateUI(netypemessage As String, CurConn As Integer, hostedneton As Integer)
        If ClientNumLabel.Text <> "--" Then

            If netypemessage <> "" Then
                NetypeIco(CurConn)
                ClientNumLabel.ForeColor = FontColor(CurConn)
                If (Panel(5) And Panel(7)) Then TrayIcon.ShowBalloonTip(0, "Internet status changed", netypemessage, ToolTipIcon.Info)
            End If

            Select Case hostedneton
                Case 1
                    CLabel("Restarting  ", "...", Color.DimGray)
                    If (Panel(5) And Panel(6)) Then TrayIcon.ShowBalloonTip(0, "WLAN status changed", "WLAN crashed, restarting...", ToolTipIcon.Info)
                    IcoTimerOn(True)
                Case 2
                    IcoTimerOn(False)
                    CLabel("Clients :", "0", FontColor(CurConn))
                    If (Panel(5) And Panel(6)) Then TrayIcon.ShowBalloonTip(0, "WLAN status changed", "WLAN restarted!", ToolTipIcon.Info)
                    NetypeIco(CurConn)
            End Select

        End If
    End Sub

    ' ===========================================   Speed (Monitor UI Freshing) ===========================================================



    Private Sub AjaxNetList()
        If NetworkAlive() = 1 Then

            Dim cStatus As GetCurrEnum = GetCurrStatus()
            Dim cLAN As String = cStatus.cLAN
            Dim cWAN As String = cStatus.cWAN

            If (cLAN <> "" And cWAN <> "") And (cLAN <> LAN Or cWAN <> WAN) Then
                EnableSharing(cLAN, cWAN)

                LAN = cLAN
                WAN = cWAN
            End If

        End If
    End Sub

    'Private Sub MonitorUpdateUI()

    '    Call Monitor.InitMenu()
    'End Sub

    ' ================================================ UI functions ===============================================================


    Private Sub InitNetlist()

        AllTimers(0) = New System.Timers.Timer(55000)
        AddHandler AllTimers(0).Elapsed, New ElapsedEventHandler(AddressOf UnSleep_Tick)  'keep unsleeping (no UI interaction)

        AllTimers(1) = New System.Timers.Timer(1500)
        AddHandler AllTimers(1).Elapsed, New ElapsedEventHandler(AddressOf AjaxClist)     'update client list with notifiction (with UI interaction)

        AllTimers(2) = New System.Timers.Timer(1500)
        AddHandler AllTimers(2).Elapsed, New ElapsedEventHandler(AddressOf Netype)        'update wlan and internet status (with UI interaction)

        AllTimers(3) = New System.Timers.Timer(1500)
        AddHandler AllTimers(3).Elapsed, New ElapsedEventHandler(AddressOf AjaxNetList)   'update sharing status (no UI interaction)

        isConnected = NetworkAlive()

        OldPeerNum = 0
        OldMacList = MacList(OldPeerNum)

        NetOn = 0
    End Sub

    Private Sub InitSet_s(ByVal k As Integer, ByVal AppName As String)
        Dim lpDefault As Boolean = (AppName = "Shortcut" Or AppName = "MonitorOn")

        Dim Section As String = "Setting"
        If k > 5 Then Section = "Notify"

        Dim lp As String = GetINI(Section, AppName)
        If isBool(lp) Then
            Panel(k) = lp
        Else
            Panel(k) = lpDefault
        End If
    End Sub

    Private Sub InitSet()

        InitSet_s(0, "Boot")
        InitSet_s(1, "AutoShare")
        InitSet_s(2, "AutoHide")
        InitSet_s(3, "Shortcut")
        InitSet_s(4, "MonitorOn")
        InitSet_s(5, "NotifyOn")

        InitSet_s(6, "Reconnect")
        InitSet_s(7, "WLReminder")
        InitSet_s(8, "DSReminder")
        InitSet_s(9, "NewDevice")

    End Sub

    Private Sub InitUser()
        PassTextBox.ShortcutsEnabled = False
        WifiNameTextBox.ShortcutsEnabled = False

        WifiName = GetINI("User", "SSID")
        Pass = GetINI("User", "Key")

        If WifiName = "" Or Pass = "" Then
            WifiName = "WifiHotSpot"
            Pass = "1234567890"
            HideKey = False
        Else
            Dim hp As String = GetINI("User", "HidePass")
            If isBool(hp) Then
                HideKey = hp
            Else
                HideKey = False
            End If
        End If

        WifiNameTextBox.Text = WifiName
        PassTextBox.Text = Pass
        HideCheck.Checked = HideKey

        If HideKey Then
            HideCheck.Image = My.Resources.hide
        Else
            HideCheck.Image = My.Resources.view
        End If
    End Sub

    Private Sub TemPass()
        WifiName = WifiNameTextBox.Text
        Pass = PassTextBox.Text
        HideKey = HideCheck.Checked
    End Sub

    Private Sub SavePass()
        WriteINI("User", "SSID", WifiName)
        WriteINI("User", "Key", Pass)
        WriteINI("User", "HidePass", HideKey.ToString)
    End Sub

    Private Sub InitCreateButton()
        CreateButton.Enabled = (Len(WifiNameTextBox.Text) > 0 And Len(WifiNameTextBox.Text) < 14 And Len(PassTextBox.Text) > 7 And Len(PassTextBox.Text) < 14)
    End Sub

    Private Sub AppSet()
        writeReg(Panel(0))

        DesktopShortcut(Panel(3))

        If Panel(4) Then
            Monitor.Show()
        Else
            Monitor.Hide()
        End If
    End Sub

    Private Sub SaveSet()
        Panel(0) = BootCheck.Checked
        Panel(1) = AutoCheck.Checked
        Panel(2) = MiniCheck.Checked
        Panel(3) = ShortcutCheck.Checked
        Panel(4) = MonitorCheck.Checked
        Panel(5) = NotifyOnRadio.Checked

        Panel(6) = WlanCheck.Checked
        Panel(7) = InternetCheck.Checked
        Panel(8) = PartnerCheck.Checked
        Panel(9) = DeviceCheck.Checked


        WriteINI("Setting", "Boot", Panel(0).ToString)
        WriteINI("Setting", "AutoShare", Panel(1).ToString)
        WriteINI("Setting", "AutoHide", Panel(2).ToString)
        WriteINI("Setting", "Shortcut", Panel(3).ToString)
        WriteINI("Setting", "MonitorOn", Panel(4).ToString)
        WriteINI("Setting", "NotifyOn", Panel(5).ToString)

        WriteINI("Notify", "Reconnect", Panel(6).ToString)
        WriteINI("Notify", "WLReminder", Panel(7).ToString)
        WriteINI("Notify", "DSReminder", Panel(8).ToString)
        WriteINI("Notify", "NewDevice", Panel(9).ToString)
    End Sub

    Private Sub UpdateSet()
        BootCheck.Checked = Panel(0)
        AutoCheck.Checked = Panel(1)
        MiniCheck.Checked = Panel(2)
        ShortcutCheck.Checked = Panel(3)
        MonitorCheck.Checked = Panel(4)
        NotifyOnRadio.Checked = Panel(5)
        NotifyOffRadio.Checked = Not Panel(5)

        WlanCheck.Checked = Panel(6)
        InternetCheck.Checked = Panel(7)
        PartnerCheck.Checked = Panel(8)
        DeviceCheck.Checked = Panel(9)
    End Sub

    Private Sub InitClist()
        Dim w As Integer = (Me.Width - 10) * 0.5

        With ClistView
            .Clear()
            .View = View.Details
            .FullRowSelect = True
            .HideSelection = False
            .MultiSelect = True
            .GridLines = True
            .HeaderStyle = ColumnHeaderStyle.Nonclickable
            .ForeColor = Color.DimGray
            .Columns.Add("Device Name", CInt(w), HorizontalAlignment.Left)
            .Columns.Add("Mac Address", CInt(w - 3.68), HorizontalAlignment.Left)
        End With
    End Sub

    Private Sub LoadClist()

        Dim textArr As Sections() = GetAllSection("Device")
        With ClistView.Items
            .Clear()
            If textArr(0).Mac <> "" Then
                For i As Integer = 0 To textArr.Count - 1
                    .Add(textArr(i).Name).SubItems.Add(textArr(i).Mac)
                Next
            End If
        End With

    End Sub

    Private Sub UnloadClist()
        With ClistView.Items
            If .Count > 0 Then
                For i = 0 To .Count - 1
                    .Item(i).ForeColor = Color.DimGray
                Next
            End If
        End With
    End Sub

    Private Sub NotifyOnRadio_CheckedChanged(sender As Object, e As EventArgs) Handles NotifyOnRadio.CheckedChanged, NotifyOffRadio.CheckedChanged
        NotifyGroup.Enabled = NotifyOnRadio.Checked
    End Sub

    Private Sub IcoTick()
        If IcoNum = 5 Then IcoNum = 0
        Me.Invoke(New IcoDel(AddressOf UpdateIco), IcoNum)
        IcoNum += 1
    End Sub

    Private Sub UpdateIco(k As Integer)
        If LockCheck.Checked Then
            TrayIcon.Icon = MyIcon(k)
        Else
            TrayIcon.Icon = MyIconLoc(k)
        End If
    End Sub

    Private Sub NetypeIco(isConn As Integer)
        If isConn <> 1 Then
            UpdateIco(4)
        Else
            UpdateIco(5)
        End If
    End Sub

    Private Sub InitIcon()

        MyIcon(0) = My.Resources.wificon_0
        MyIcon(1) = My.Resources.wificon_1
        MyIcon(2) = My.Resources.wificon_2
        MyIcon(3) = My.Resources.wificon_3
        MyIcon(4) = My.Resources.wificon_4
        MyIcon(5) = My.Resources.wificon_5

        MyIconLoc(0) = My.Resources.wificon_lock_0
        MyIconLoc(1) = My.Resources.wificon_lock_1
        MyIconLoc(2) = My.Resources.wificon_lock_2
        MyIconLoc(3) = My.Resources.wificon_lock_3
        MyIconLoc(4) = My.Resources.wificon_lock_4
        MyIconLoc(5) = My.Resources.wificon_lock_5

        AllTimers(4) = New Timers.Timer(200)
        AddHandler AllTimers(4).Elapsed, New ElapsedEventHandler(AddressOf IcoTick)

        TrayIcon.Icon = MyIcon(0)
    End Sub

    Private Sub ProtectedPanel(hwnd As Boolean)
        WifiNameTextBox.Enabled = hwnd
        PassTextBox.Enabled = hwnd
        ClearImage.Enabled = hwnd
        MainButtonPanel.Enabled = hwnd
        ToolStripMenu_On.Enabled = hwnd

    End Sub

    Private Sub Locker(hwnd As Boolean)
        If hwnd Then
            LockCheck.Image = My.Resources.unlock
        Else
            LockCheck.Image = My.Resources.lock
        End If

        NetypeIco(isConnected)

        CloseImage.Enabled = hwnd
        ToolStripMenuItem_Exit.Enabled = hwnd
        ToolStripMenu_Off.Enabled = hwnd
        ProtectedPanel(hwnd)
    End Sub

    Private Sub LockCheck_CheckedChanged(sender As Object, e As EventArgs) Handles LockCheck.CheckedChanged
        If LockCheck.Created And LockCheck.Enabled Then Call Locker(LockCheck.Checked)
    End Sub

    Private Sub TrayIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TrayIcon.MouseDoubleClick
        Call RestoreWin()
    End Sub

    Private Sub Default_Judge(sender As Object, e As EventArgs) Handles DeviceCheck.CheckedChanged, PartnerCheck.CheckedChanged, InternetCheck.CheckedChanged, MonitorCheck.CheckedChanged, ShortcutCheck.CheckedChanged, MiniCheck.CheckedChanged, AutoCheck.CheckedChanged, BootCheck.CheckedChanged, WlanCheck.CheckedChanged, NotifyOnRadio.CheckedChanged, NotifyOffRadio.CheckedChanged
        DefButton.Enabled = Not (Not (BootCheck.Checked Or AutoCheck.Checked Or MiniCheck.Checked Or NotifyOnRadio.Checked Or WlanCheck.Checked Or InternetCheck.Checked Or PartnerCheck.Checked Or DeviceCheck.Checked) And ShortcutCheck.Checked And MonitorCheck.Checked And NotifyOffRadio.Checked)
    End Sub
End Class