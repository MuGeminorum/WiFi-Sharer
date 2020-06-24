<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Sharer
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sharer))
        Me.IconMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem_Show = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Monitor = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenu_On = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenu_Off = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSplit = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.DefButton = New System.Windows.Forms.Button()
        Me.SettingPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.DeskGroup = New System.Windows.Forms.GroupBox()
        Me.MonitorCheck = New System.Windows.Forms.CheckBox()
        Me.ShortcutCheck = New System.Windows.Forms.CheckBox()
        Me.StartGroup = New System.Windows.Forms.GroupBox()
        Me.MiniCheck = New System.Windows.Forms.CheckBox()
        Me.AutoCheck = New System.Windows.Forms.CheckBox()
        Me.BootCheck = New System.Windows.Forms.CheckBox()
        Me.NotifyPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.NotifyGroup = New System.Windows.Forms.GroupBox()
        Me.DeviceCheck = New System.Windows.Forms.CheckBox()
        Me.PartnerCheck = New System.Windows.Forms.CheckBox()
        Me.InternetCheck = New System.Windows.Forms.CheckBox()
        Me.WlanCheck = New System.Windows.Forms.CheckBox()
        Me.NotifyPowerGroup = New System.Windows.Forms.GroupBox()
        Me.NotifyPowerPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.NotifyOffRadio = New System.Windows.Forms.RadioButton()
        Me.NotifyOnRadio = New System.Windows.Forms.RadioButton()
        Me.MainPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.MainScreenPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.LockCheck = New System.Windows.Forms.CheckBox()
        Me.HideCheck = New System.Windows.Forms.CheckBox()
        Me.WifiNameLabel = New System.Windows.Forms.Label()
        Me.ConnectorLabel = New System.Windows.Forms.Label()
        Me.PassLabel = New System.Windows.Forms.Label()
        Me.ClientNumLabel = New System.Windows.Forms.Label()
        Me.PassTextBox = New System.Windows.Forms.TextBox()
        Me.WifiNameTextBox = New System.Windows.Forms.TextBox()
        Me.ClearImage = New System.Windows.Forms.Button()
        Me.MainButtonPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.DisButton = New System.Windows.Forms.Button()
        Me.CreateButton = New System.Windows.Forms.Button()
        Me.ProgramPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControlMain = New System.Windows.Forms.TabControl()
        Me.TabPageHotspot = New System.Windows.Forms.TabPage()
        Me.TabPageControl = New System.Windows.Forms.TabPage()
        Me.TabPageDevices = New System.Windows.Forms.TabPage()
        Me.ClistView = New System.Windows.Forms.ListView()
        Me.HandlerPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.MinimizeImage = New System.Windows.Forms.PictureBox()
        Me.CloseImage = New System.Windows.Forms.PictureBox()
        Me.DeleteMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.IconMenu.SuspendLayout()
        Me.ControlPanel.SuspendLayout()
        Me.SettingPanel.SuspendLayout()
        Me.DeskGroup.SuspendLayout()
        Me.StartGroup.SuspendLayout()
        Me.NotifyPanel.SuspendLayout()
        Me.NotifyGroup.SuspendLayout()
        Me.NotifyPowerGroup.SuspendLayout()
        Me.NotifyPowerPanel.SuspendLayout()
        Me.MainPanel.SuspendLayout()
        Me.MainScreenPanel.SuspendLayout()
        Me.MainButtonPanel.SuspendLayout()
        Me.ProgramPanel.SuspendLayout()
        Me.TabControlMain.SuspendLayout()
        Me.TabPageHotspot.SuspendLayout()
        Me.TabPageControl.SuspendLayout()
        Me.TabPageDevices.SuspendLayout()
        Me.HandlerPanel.SuspendLayout()
        CType(Me.MinimizeImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CloseImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DeleteMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'IconMenu
        '
        Me.IconMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.IconMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.IconMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_Show, Me.ToolStripMenuItem_Monitor, Me.ToolStripMenu_On, Me.ToolStripMenu_Off, Me.ToolStripSplit, Me.ToolStripMenuItem_Exit})
        Me.IconMenu.Name = "ContextMenuStrip1"
        Me.IconMenu.Size = New System.Drawing.Size(197, 140)
        '
        'ToolStripMenuItem_Show
        '
        Me.ToolStripMenuItem_Show.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ToolStripMenuItem_Show.Name = "ToolStripMenuItem_Show"
        Me.ToolStripMenuItem_Show.Size = New System.Drawing.Size(196, 26)
        Me.ToolStripMenuItem_Show.Text = "Activate window"
        '
        'ToolStripMenuItem_Monitor
        '
        Me.ToolStripMenuItem_Monitor.Name = "ToolStripMenuItem_Monitor"
        Me.ToolStripMenuItem_Monitor.Size = New System.Drawing.Size(196, 26)
        Me.ToolStripMenuItem_Monitor.Text = "Show monitor"
        '
        'ToolStripMenu_On
        '
        Me.ToolStripMenu_On.Name = "ToolStripMenu_On"
        Me.ToolStripMenu_On.Size = New System.Drawing.Size(196, 26)
        Me.ToolStripMenu_On.Text = "Hotspot on"
        '
        'ToolStripMenu_Off
        '
        Me.ToolStripMenu_Off.Checked = True
        Me.ToolStripMenu_Off.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenu_Off.Enabled = False
        Me.ToolStripMenu_Off.Name = "ToolStripMenu_Off"
        Me.ToolStripMenu_Off.Size = New System.Drawing.Size(196, 26)
        Me.ToolStripMenu_Off.Text = "Hotspot off"
        '
        'ToolStripSplit
        '
        Me.ToolStripSplit.Name = "ToolStripSplit"
        Me.ToolStripSplit.Size = New System.Drawing.Size(193, 6)
        '
        'ToolStripMenuItem_Exit
        '
        Me.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit"
        Me.ToolStripMenuItem_Exit.Size = New System.Drawing.Size(196, 26)
        Me.ToolStripMenuItem_Exit.Text = "Exit"
        '
        'ControlPanel
        '
        Me.ControlPanel.ColumnCount = 2
        Me.ControlPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ControlPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ControlPanel.Controls.Add(Me.SaveButton, 0, 1)
        Me.ControlPanel.Controls.Add(Me.DefButton, 1, 1)
        Me.ControlPanel.Controls.Add(Me.SettingPanel, 0, 0)
        Me.ControlPanel.Controls.Add(Me.NotifyPanel, 1, 0)
        Me.ControlPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ControlPanel.Location = New System.Drawing.Point(0, 0)
        Me.ControlPanel.Name = "ControlPanel"
        Me.ControlPanel.RowCount = 2
        Me.ControlPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.ControlPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.ControlPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ControlPanel.Size = New System.Drawing.Size(368, 210)
        Me.ControlPanel.TabIndex = 23
        '
        'SaveButton
        '
        Me.SaveButton.BackColor = System.Drawing.Color.Transparent
        Me.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SaveButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SaveButton.FlatAppearance.BorderSize = 0
        Me.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue
        Me.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SaveButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveButton.ForeColor = System.Drawing.Color.DodgerBlue
        Me.SaveButton.Location = New System.Drawing.Point(2, 159)
        Me.SaveButton.Margin = New System.Windows.Forms.Padding(2)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(180, 49)
        Me.SaveButton.TabIndex = 2
        Me.SaveButton.Text = "Apply"
        Me.SaveButton.UseVisualStyleBackColor = False
        '
        'DefButton
        '
        Me.DefButton.BackColor = System.Drawing.Color.Transparent
        Me.DefButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DefButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DefButton.FlatAppearance.BorderSize = 0
        Me.DefButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue
        Me.DefButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DefButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DefButton.ForeColor = System.Drawing.Color.DodgerBlue
        Me.DefButton.Location = New System.Drawing.Point(186, 159)
        Me.DefButton.Margin = New System.Windows.Forms.Padding(2)
        Me.DefButton.Name = "DefButton"
        Me.DefButton.Size = New System.Drawing.Size(180, 49)
        Me.DefButton.TabIndex = 1
        Me.DefButton.Text = "Default"
        Me.DefButton.UseVisualStyleBackColor = False
        '
        'SettingPanel
        '
        Me.SettingPanel.ColumnCount = 1
        Me.SettingPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.SettingPanel.Controls.Add(Me.DeskGroup, 0, 1)
        Me.SettingPanel.Controls.Add(Me.StartGroup, 0, 0)
        Me.SettingPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SettingPanel.Location = New System.Drawing.Point(0, 0)
        Me.SettingPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.SettingPanel.Name = "SettingPanel"
        Me.SettingPanel.RowCount = 2
        Me.SettingPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.0!))
        Me.SettingPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.SettingPanel.Size = New System.Drawing.Size(184, 157)
        Me.SettingPanel.TabIndex = 4
        '
        'DeskGroup
        '
        Me.DeskGroup.Controls.Add(Me.MonitorCheck)
        Me.DeskGroup.Controls.Add(Me.ShortcutCheck)
        Me.DeskGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DeskGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeskGroup.ForeColor = System.Drawing.Color.Black
        Me.DeskGroup.Location = New System.Drawing.Point(3, 86)
        Me.DeskGroup.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.DeskGroup.Name = "DeskGroup"
        Me.DeskGroup.Size = New System.Drawing.Size(178, 68)
        Me.DeskGroup.TabIndex = 35
        Me.DeskGroup.TabStop = False
        Me.DeskGroup.Text = "Desktop"
        '
        'MonitorCheck
        '
        Me.MonitorCheck.AutoSize = True
        Me.MonitorCheck.Dock = System.Windows.Forms.DockStyle.Top
        Me.MonitorCheck.Location = New System.Drawing.Point(3, 42)
        Me.MonitorCheck.Name = "MonitorCheck"
        Me.MonitorCheck.Size = New System.Drawing.Size(172, 22)
        Me.MonitorCheck.TabIndex = 17
        Me.MonitorCheck.Text = "Show net monitor"
        Me.MonitorCheck.UseVisualStyleBackColor = True
        '
        'ShortcutCheck
        '
        Me.ShortcutCheck.AutoSize = True
        Me.ShortcutCheck.Dock = System.Windows.Forms.DockStyle.Top
        Me.ShortcutCheck.Location = New System.Drawing.Point(3, 20)
        Me.ShortcutCheck.Name = "ShortcutCheck"
        Me.ShortcutCheck.Size = New System.Drawing.Size(172, 22)
        Me.ShortcutCheck.TabIndex = 6
        Me.ShortcutCheck.Text = "Add desktop shortcut"
        Me.ShortcutCheck.UseVisualStyleBackColor = True
        '
        'StartGroup
        '
        Me.StartGroup.Controls.Add(Me.MiniCheck)
        Me.StartGroup.Controls.Add(Me.AutoCheck)
        Me.StartGroup.Controls.Add(Me.BootCheck)
        Me.StartGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StartGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartGroup.ForeColor = System.Drawing.Color.Black
        Me.StartGroup.Location = New System.Drawing.Point(3, 3)
        Me.StartGroup.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.StartGroup.Name = "StartGroup"
        Me.StartGroup.Size = New System.Drawing.Size(178, 83)
        Me.StartGroup.TabIndex = 34
        Me.StartGroup.TabStop = False
        Me.StartGroup.Text = "Startup"
        '
        'MiniCheck
        '
        Me.MiniCheck.AutoSize = True
        Me.MiniCheck.Dock = System.Windows.Forms.DockStyle.Top
        Me.MiniCheck.Location = New System.Drawing.Point(3, 64)
        Me.MiniCheck.Name = "MiniCheck"
        Me.MiniCheck.Size = New System.Drawing.Size(172, 22)
        Me.MiniCheck.TabIndex = 8
        Me.MiniCheck.Text = "Auto-hide main form"
        Me.MiniCheck.UseVisualStyleBackColor = True
        '
        'AutoCheck
        '
        Me.AutoCheck.AutoSize = True
        Me.AutoCheck.Dock = System.Windows.Forms.DockStyle.Top
        Me.AutoCheck.Location = New System.Drawing.Point(3, 42)
        Me.AutoCheck.Name = "AutoCheck"
        Me.AutoCheck.Size = New System.Drawing.Size(172, 22)
        Me.AutoCheck.TabIndex = 7
        Me.AutoCheck.Text = "Auto-create hotspot"
        Me.AutoCheck.UseVisualStyleBackColor = True
        '
        'BootCheck
        '
        Me.BootCheck.AutoSize = True
        Me.BootCheck.Dock = System.Windows.Forms.DockStyle.Top
        Me.BootCheck.Location = New System.Drawing.Point(3, 20)
        Me.BootCheck.Name = "BootCheck"
        Me.BootCheck.Size = New System.Drawing.Size(172, 22)
        Me.BootCheck.TabIndex = 6
        Me.BootCheck.Text = "Start with Windows"
        Me.BootCheck.UseVisualStyleBackColor = True
        '
        'NotifyPanel
        '
        Me.NotifyPanel.ColumnCount = 1
        Me.NotifyPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.NotifyPanel.Controls.Add(Me.NotifyGroup, 0, 1)
        Me.NotifyPanel.Controls.Add(Me.NotifyPowerGroup, 0, 0)
        Me.NotifyPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NotifyPanel.Location = New System.Drawing.Point(184, 0)
        Me.NotifyPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.NotifyPanel.Name = "NotifyPanel"
        Me.NotifyPanel.RowCount = 2
        Me.NotifyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.NotifyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.NotifyPanel.Size = New System.Drawing.Size(184, 157)
        Me.NotifyPanel.TabIndex = 5
        '
        'NotifyGroup
        '
        Me.NotifyGroup.Controls.Add(Me.DeviceCheck)
        Me.NotifyGroup.Controls.Add(Me.PartnerCheck)
        Me.NotifyGroup.Controls.Add(Me.InternetCheck)
        Me.NotifyGroup.Controls.Add(Me.WlanCheck)
        Me.NotifyGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NotifyGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NotifyGroup.ForeColor = System.Drawing.Color.Black
        Me.NotifyGroup.Location = New System.Drawing.Point(3, 54)
        Me.NotifyGroup.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.NotifyGroup.Name = "NotifyGroup"
        Me.NotifyGroup.Size = New System.Drawing.Size(178, 100)
        Me.NotifyGroup.TabIndex = 33
        Me.NotifyGroup.TabStop = False
        Me.NotifyGroup.Text = "Notify when"
        '
        'DeviceCheck
        '
        Me.DeviceCheck.AutoSize = True
        Me.DeviceCheck.Dock = System.Windows.Forms.DockStyle.Top
        Me.DeviceCheck.Location = New System.Drawing.Point(3, 86)
        Me.DeviceCheck.Name = "DeviceCheck"
        Me.DeviceCheck.Size = New System.Drawing.Size(172, 22)
        Me.DeviceCheck.TabIndex = 37
        Me.DeviceCheck.Text = "New device joins"
        Me.DeviceCheck.UseVisualStyleBackColor = True
        '
        'PartnerCheck
        '
        Me.PartnerCheck.AutoSize = True
        Me.PartnerCheck.Dock = System.Windows.Forms.DockStyle.Top
        Me.PartnerCheck.Location = New System.Drawing.Point(3, 64)
        Me.PartnerCheck.Name = "PartnerCheck"
        Me.PartnerCheck.Size = New System.Drawing.Size(172, 22)
        Me.PartnerCheck.TabIndex = 36
        Me.PartnerCheck.Text = "Partner status changes"
        Me.PartnerCheck.UseVisualStyleBackColor = True
        '
        'InternetCheck
        '
        Me.InternetCheck.AutoSize = True
        Me.InternetCheck.Dock = System.Windows.Forms.DockStyle.Top
        Me.InternetCheck.Location = New System.Drawing.Point(3, 42)
        Me.InternetCheck.Name = "InternetCheck"
        Me.InternetCheck.Size = New System.Drawing.Size(172, 22)
        Me.InternetCheck.TabIndex = 35
        Me.InternetCheck.Text = "Internet status changes"
        Me.InternetCheck.UseVisualStyleBackColor = True
        '
        'WlanCheck
        '
        Me.WlanCheck.AutoSize = True
        Me.WlanCheck.Dock = System.Windows.Forms.DockStyle.Top
        Me.WlanCheck.Location = New System.Drawing.Point(3, 20)
        Me.WlanCheck.Name = "WlanCheck"
        Me.WlanCheck.Size = New System.Drawing.Size(172, 22)
        Me.WlanCheck.TabIndex = 34
        Me.WlanCheck.Text = "WLAN status changes"
        Me.WlanCheck.UseVisualStyleBackColor = True
        '
        'NotifyPowerGroup
        '
        Me.NotifyPowerGroup.Controls.Add(Me.NotifyPowerPanel)
        Me.NotifyPowerGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NotifyPowerGroup.ForeColor = System.Drawing.Color.Black
        Me.NotifyPowerGroup.Location = New System.Drawing.Point(3, 3)
        Me.NotifyPowerGroup.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.NotifyPowerGroup.Name = "NotifyPowerGroup"
        Me.NotifyPowerGroup.Size = New System.Drawing.Size(178, 51)
        Me.NotifyPowerGroup.TabIndex = 0
        Me.NotifyPowerGroup.TabStop = False
        Me.NotifyPowerGroup.Text = "Notification"
        '
        'NotifyPowerPanel
        '
        Me.NotifyPowerPanel.ColumnCount = 2
        Me.NotifyPowerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.NotifyPowerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.NotifyPowerPanel.Controls.Add(Me.NotifyOffRadio, 0, 0)
        Me.NotifyPowerPanel.Controls.Add(Me.NotifyOnRadio, 0, 0)
        Me.NotifyPowerPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NotifyPowerPanel.Location = New System.Drawing.Point(3, 20)
        Me.NotifyPowerPanel.Name = "NotifyPowerPanel"
        Me.NotifyPowerPanel.RowCount = 1
        Me.NotifyPowerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.NotifyPowerPanel.Size = New System.Drawing.Size(172, 28)
        Me.NotifyPowerPanel.TabIndex = 0
        '
        'NotifyOffRadio
        '
        Me.NotifyOffRadio.AutoSize = True
        Me.NotifyOffRadio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NotifyOffRadio.Location = New System.Drawing.Point(89, 3)
        Me.NotifyOffRadio.Name = "NotifyOffRadio"
        Me.NotifyOffRadio.Size = New System.Drawing.Size(80, 22)
        Me.NotifyOffRadio.TabIndex = 3
        Me.NotifyOffRadio.TabStop = True
        Me.NotifyOffRadio.Text = "Off"
        Me.NotifyOffRadio.UseVisualStyleBackColor = True
        '
        'NotifyOnRadio
        '
        Me.NotifyOnRadio.AutoSize = True
        Me.NotifyOnRadio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NotifyOnRadio.Location = New System.Drawing.Point(3, 3)
        Me.NotifyOnRadio.Name = "NotifyOnRadio"
        Me.NotifyOnRadio.Size = New System.Drawing.Size(80, 22)
        Me.NotifyOnRadio.TabIndex = 2
        Me.NotifyOnRadio.TabStop = True
        Me.NotifyOnRadio.Text = "On"
        Me.NotifyOnRadio.UseVisualStyleBackColor = True
        '
        'MainPanel
        '
        Me.MainPanel.BackColor = System.Drawing.Color.Transparent
        Me.MainPanel.ColumnCount = 1
        Me.MainPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainPanel.Controls.Add(Me.MainScreenPanel, 0, 0)
        Me.MainPanel.Controls.Add(Me.MainButtonPanel, 0, 1)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.RowCount = 2
        Me.MainPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.MainPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.MainPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.MainPanel.Size = New System.Drawing.Size(368, 210)
        Me.MainPanel.TabIndex = 24
        '
        'MainScreenPanel
        '
        Me.MainScreenPanel.ColumnCount = 3
        Me.MainScreenPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.MainScreenPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.MainScreenPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.MainScreenPanel.Controls.Add(Me.LockCheck, 2, 0)
        Me.MainScreenPanel.Controls.Add(Me.HideCheck, 2, 2)
        Me.MainScreenPanel.Controls.Add(Me.WifiNameLabel, 0, 1)
        Me.MainScreenPanel.Controls.Add(Me.ConnectorLabel, 0, 0)
        Me.MainScreenPanel.Controls.Add(Me.PassLabel, 0, 2)
        Me.MainScreenPanel.Controls.Add(Me.ClientNumLabel, 1, 0)
        Me.MainScreenPanel.Controls.Add(Me.PassTextBox, 1, 2)
        Me.MainScreenPanel.Controls.Add(Me.WifiNameTextBox, 1, 1)
        Me.MainScreenPanel.Controls.Add(Me.ClearImage, 2, 1)
        Me.MainScreenPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainScreenPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainScreenPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.MainScreenPanel.Name = "MainScreenPanel"
        Me.MainScreenPanel.RowCount = 3
        Me.MainScreenPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.MainScreenPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.MainScreenPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.MainScreenPanel.Size = New System.Drawing.Size(368, 157)
        Me.MainScreenPanel.TabIndex = 0
        '
        'LockCheck
        '
        Me.LockCheck.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LockCheck.Appearance = System.Windows.Forms.Appearance.Button
        Me.LockCheck.AutoSize = True
        Me.LockCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.LockCheck.Checked = True
        Me.LockCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LockCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.LockCheck.Enabled = False
        Me.LockCheck.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.LockCheck.FlatAppearance.BorderSize = 0
        Me.LockCheck.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.LockCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.LockCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.LockCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LockCheck.ForeColor = System.Drawing.Color.Transparent
        Me.LockCheck.Image = Global.Sharer.My.Resources.Resources.unlock
        Me.LockCheck.Location = New System.Drawing.Point(338, 15)
        Me.LockCheck.Margin = New System.Windows.Forms.Padding(0)
        Me.LockCheck.Name = "LockCheck"
        Me.LockCheck.Size = New System.Drawing.Size(22, 22)
        Me.LockCheck.TabIndex = 13
        Me.LockCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LockCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.LockCheck.UseVisualStyleBackColor = False
        '
        'HideCheck
        '
        Me.HideCheck.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.HideCheck.Appearance = System.Windows.Forms.Appearance.Button
        Me.HideCheck.AutoSize = True
        Me.HideCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.HideCheck.Checked = True
        Me.HideCheck.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.HideCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.HideCheck.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.HideCheck.FlatAppearance.BorderSize = 0
        Me.HideCheck.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.HideCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.HideCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.HideCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.HideCheck.ForeColor = System.Drawing.Color.Transparent
        Me.HideCheck.Image = Global.Sharer.My.Resources.Resources.view
        Me.HideCheck.Location = New System.Drawing.Point(338, 119)
        Me.HideCheck.Margin = New System.Windows.Forms.Padding(0)
        Me.HideCheck.Name = "HideCheck"
        Me.HideCheck.Size = New System.Drawing.Size(22, 22)
        Me.HideCheck.TabIndex = 0
        Me.HideCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.HideCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.HideCheck.UseVisualStyleBackColor = False
        '
        'WifiNameLabel
        '
        Me.WifiNameLabel.AutoSize = True
        Me.WifiNameLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WifiNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.WifiNameLabel.Location = New System.Drawing.Point(4, 52)
        Me.WifiNameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.WifiNameLabel.Name = "WifiNameLabel"
        Me.WifiNameLabel.Size = New System.Drawing.Size(102, 52)
        Me.WifiNameLabel.TabIndex = 4
        Me.WifiNameLabel.Text = "Wi-Fi Name :"
        Me.WifiNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ConnectorLabel
        '
        Me.ConnectorLabel.AutoSize = True
        Me.ConnectorLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ConnectorLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ConnectorLabel.Location = New System.Drawing.Point(4, 0)
        Me.ConnectorLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ConnectorLabel.Name = "ConnectorLabel"
        Me.ConnectorLabel.Size = New System.Drawing.Size(102, 52)
        Me.ConnectorLabel.TabIndex = 7
        Me.ConnectorLabel.Text = "Clients :"
        Me.ConnectorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PassLabel
        '
        Me.PassLabel.AutoSize = True
        Me.PassLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PassLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PassLabel.Location = New System.Drawing.Point(4, 104)
        Me.PassLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PassLabel.Name = "PassLabel"
        Me.PassLabel.Size = New System.Drawing.Size(102, 53)
        Me.PassLabel.TabIndex = 5
        Me.PassLabel.Text = "Password :"
        Me.PassLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ClientNumLabel
        '
        Me.ClientNumLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ClientNumLabel.AutoSize = True
        Me.ClientNumLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ClientNumLabel.ForeColor = System.Drawing.Color.DimGray
        Me.ClientNumLabel.Location = New System.Drawing.Point(207, 13)
        Me.ClientNumLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ClientNumLabel.Name = "ClientNumLabel"
        Me.ClientNumLabel.Size = New System.Drawing.Size(26, 25)
        Me.ClientNumLabel.TabIndex = 8
        Me.ClientNumLabel.Text = "--"
        Me.ClientNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PassTextBox
        '
        Me.PassTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PassTextBox.BackColor = System.Drawing.SystemColors.Window
        Me.PassTextBox.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PassTextBox.ForeColor = System.Drawing.Color.DarkOrange
        Me.PassTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.PassTextBox.Location = New System.Drawing.Point(110, 115)
        Me.PassTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.PassTextBox.MaxLength = 13
        Me.PassTextBox.Name = "PassTextBox"
        Me.PassTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.PassTextBox.Size = New System.Drawing.Size(220, 30)
        Me.PassTextBox.TabIndex = 2
        Me.PassTextBox.Tag = ""
        '
        'WifiNameTextBox
        '
        Me.WifiNameTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WifiNameTextBox.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WifiNameTextBox.ForeColor = System.Drawing.Color.LimeGreen
        Me.WifiNameTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.WifiNameTextBox.Location = New System.Drawing.Point(110, 63)
        Me.WifiNameTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.WifiNameTextBox.MaxLength = 13
        Me.WifiNameTextBox.Name = "WifiNameTextBox"
        Me.WifiNameTextBox.Size = New System.Drawing.Size(220, 30)
        Me.WifiNameTextBox.TabIndex = 1
        Me.WifiNameTextBox.Tag = ""
        '
        'ClearImage
        '
        Me.ClearImage.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ClearImage.AutoSize = True
        Me.ClearImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClearImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClearImage.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ClearImage.FlatAppearance.BorderSize = 0
        Me.ClearImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ClearImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ClearImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ClearImage.ForeColor = System.Drawing.Color.Transparent
        Me.ClearImage.Image = Global.Sharer.My.Resources.Resources.clear
        Me.ClearImage.Location = New System.Drawing.Point(338, 67)
        Me.ClearImage.Margin = New System.Windows.Forms.Padding(0)
        Me.ClearImage.Name = "ClearImage"
        Me.ClearImage.Size = New System.Drawing.Size(22, 22)
        Me.ClearImage.TabIndex = 14
        Me.ClearImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ClearImage.UseVisualStyleBackColor = False
        '
        'MainButtonPanel
        '
        Me.MainButtonPanel.ColumnCount = 3
        Me.MainButtonPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.MainButtonPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.MainButtonPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.MainButtonPanel.Controls.Add(Me.ResetButton, 1, 0)
        Me.MainButtonPanel.Controls.Add(Me.DisButton, 2, 0)
        Me.MainButtonPanel.Controls.Add(Me.CreateButton, 0, 0)
        Me.MainButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainButtonPanel.Location = New System.Drawing.Point(0, 157)
        Me.MainButtonPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.MainButtonPanel.Name = "MainButtonPanel"
        Me.MainButtonPanel.RowCount = 1
        Me.MainButtonPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainButtonPanel.Size = New System.Drawing.Size(368, 53)
        Me.MainButtonPanel.TabIndex = 25
        '
        'ResetButton
        '
        Me.ResetButton.BackColor = System.Drawing.Color.Transparent
        Me.ResetButton.CausesValidation = False
        Me.ResetButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ResetButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResetButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ResetButton.FlatAppearance.BorderSize = 0
        Me.ResetButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue
        Me.ResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ResetButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ResetButton.ForeColor = System.Drawing.Color.DodgerBlue
        Me.ResetButton.Location = New System.Drawing.Point(124, 2)
        Me.ResetButton.Margin = New System.Windows.Forms.Padding(2)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(118, 49)
        Me.ResetButton.TabIndex = 9
        Me.ResetButton.Text = "Reset"
        Me.ResetButton.UseVisualStyleBackColor = False
        '
        'DisButton
        '
        Me.DisButton.BackColor = System.Drawing.Color.Transparent
        Me.DisButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DisButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DisButton.Enabled = False
        Me.DisButton.FlatAppearance.BorderSize = 0
        Me.DisButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue
        Me.DisButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DisButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DisButton.ForeColor = System.Drawing.Color.DodgerBlue
        Me.DisButton.Location = New System.Drawing.Point(246, 2)
        Me.DisButton.Margin = New System.Windows.Forms.Padding(2)
        Me.DisButton.Name = "DisButton"
        Me.DisButton.Size = New System.Drawing.Size(120, 49)
        Me.DisButton.TabIndex = 8
        Me.DisButton.Text = "Disconnect"
        Me.DisButton.UseVisualStyleBackColor = False
        '
        'CreateButton
        '
        Me.CreateButton.BackColor = System.Drawing.Color.Transparent
        Me.CreateButton.CausesValidation = False
        Me.CreateButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CreateButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CreateButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.CreateButton.FlatAppearance.BorderSize = 0
        Me.CreateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue
        Me.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CreateButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CreateButton.ForeColor = System.Drawing.Color.DodgerBlue
        Me.CreateButton.Location = New System.Drawing.Point(2, 2)
        Me.CreateButton.Margin = New System.Windows.Forms.Padding(2)
        Me.CreateButton.Name = "CreateButton"
        Me.CreateButton.Size = New System.Drawing.Size(118, 49)
        Me.CreateButton.TabIndex = 7
        Me.CreateButton.Text = "Create"
        Me.CreateButton.UseVisualStyleBackColor = False
        '
        'ProgramPanel
        '
        Me.ProgramPanel.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ProgramPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.ProgramPanel.ColumnCount = 1
        Me.ProgramPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ProgramPanel.Controls.Add(Me.TabControlMain, 0, 1)
        Me.ProgramPanel.Controls.Add(Me.HandlerPanel, 0, 0)
        Me.ProgramPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgramPanel.ForeColor = System.Drawing.Color.DimGray
        Me.ProgramPanel.Location = New System.Drawing.Point(0, 0)
        Me.ProgramPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.ProgramPanel.Name = "ProgramPanel"
        Me.ProgramPanel.RowCount = 2
        Me.ProgramPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.ProgramPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.ProgramPanel.Size = New System.Drawing.Size(378, 270)
        Me.ProgramPanel.TabIndex = 27
        '
        'TabControlMain
        '
        Me.TabControlMain.Controls.Add(Me.TabPageHotspot)
        Me.TabControlMain.Controls.Add(Me.TabPageControl)
        Me.TabControlMain.Controls.Add(Me.TabPageDevices)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.Location = New System.Drawing.Point(1, 28)
        Me.TabControlMain.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.Padding = New System.Drawing.Point(0, 0)
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(376, 241)
        Me.TabControlMain.TabIndex = 28
        '
        'TabPageHotspot
        '
        Me.TabPageHotspot.BackColor = System.Drawing.Color.White
        Me.TabPageHotspot.Controls.Add(Me.MainPanel)
        Me.TabPageHotspot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPageHotspot.ForeColor = System.Drawing.Color.DimGray
        Me.TabPageHotspot.Location = New System.Drawing.Point(4, 27)
        Me.TabPageHotspot.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPageHotspot.Name = "TabPageHotspot"
        Me.TabPageHotspot.Size = New System.Drawing.Size(368, 210)
        Me.TabPageHotspot.TabIndex = 0
        Me.TabPageHotspot.Text = "Hotspot"
        '
        'TabPageControl
        '
        Me.TabPageControl.BackColor = System.Drawing.Color.White
        Me.TabPageControl.Controls.Add(Me.ControlPanel)
        Me.TabPageControl.Location = New System.Drawing.Point(4, 27)
        Me.TabPageControl.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPageControl.Name = "TabPageControl"
        Me.TabPageControl.Size = New System.Drawing.Size(368, 210)
        Me.TabPageControl.TabIndex = 1
        Me.TabPageControl.Text = "Control"
        '
        'TabPageDevices
        '
        Me.TabPageDevices.BackColor = System.Drawing.Color.White
        Me.TabPageDevices.Controls.Add(Me.ClistView)
        Me.TabPageDevices.Location = New System.Drawing.Point(4, 27)
        Me.TabPageDevices.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPageDevices.Name = "TabPageDevices"
        Me.TabPageDevices.Size = New System.Drawing.Size(368, 210)
        Me.TabPageDevices.TabIndex = 2
        Me.TabPageDevices.Text = "Devices"
        '
        'ClistView
        '
        Me.ClistView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ClistView.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ClistView.ForeColor = System.Drawing.Color.DimGray
        Me.ClistView.GridLines = True
        Me.ClistView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ClistView.LabelEdit = True
        Me.ClistView.Location = New System.Drawing.Point(0, 0)
        Me.ClistView.Name = "ClistView"
        Me.ClistView.Size = New System.Drawing.Size(368, 210)
        Me.ClistView.TabIndex = 0
        Me.ClistView.UseCompatibleStateImageBehavior = False
        '
        'HandlerPanel
        '
        Me.HandlerPanel.ColumnCount = 2
        Me.HandlerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.HandlerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.HandlerPanel.Controls.Add(Me.MinimizeImage, 0, 0)
        Me.HandlerPanel.Controls.Add(Me.CloseImage, 1, 0)
        Me.HandlerPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.HandlerPanel.Location = New System.Drawing.Point(334, 1)
        Me.HandlerPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.HandlerPanel.Name = "HandlerPanel"
        Me.HandlerPanel.RowCount = 1
        Me.HandlerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.HandlerPanel.Size = New System.Drawing.Size(43, 26)
        Me.HandlerPanel.TabIndex = 29
        '
        'MinimizeImage
        '
        Me.MinimizeImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MinimizeImage.Image = CType(resources.GetObject("MinimizeImage.Image"), System.Drawing.Image)
        Me.MinimizeImage.Location = New System.Drawing.Point(4, 4)
        Me.MinimizeImage.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimizeImage.Name = "MinimizeImage"
        Me.MinimizeImage.Size = New System.Drawing.Size(13, 18)
        Me.MinimizeImage.TabIndex = 5
        Me.MinimizeImage.TabStop = False
        '
        'CloseImage
        '
        Me.CloseImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CloseImage.Image = CType(resources.GetObject("CloseImage.Image"), System.Drawing.Image)
        Me.CloseImage.Location = New System.Drawing.Point(25, 4)
        Me.CloseImage.Margin = New System.Windows.Forms.Padding(4)
        Me.CloseImage.Name = "CloseImage"
        Me.CloseImage.Size = New System.Drawing.Size(14, 18)
        Me.CloseImage.TabIndex = 4
        Me.CloseImage.TabStop = False
        '
        'DeleteMenu
        '
        Me.DeleteMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.DeleteMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.DeleteMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.DeleteMenu.Name = "ContextMenuStrip2"
        Me.DeleteMenu.Size = New System.Drawing.Size(119, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'TrayIcon
        '
        Me.TrayIcon.ContextMenuStrip = Me.IconMenu
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        Me.TrayIcon.Text = "Sharer"
        Me.TrayIcon.Visible = True
        '
        'Sharer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(378, 270)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgramPanel)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "Sharer"
        Me.Opacity = 0.97R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SHARER"
        Me.IconMenu.ResumeLayout(False)
        Me.ControlPanel.ResumeLayout(False)
        Me.SettingPanel.ResumeLayout(False)
        Me.DeskGroup.ResumeLayout(False)
        Me.DeskGroup.PerformLayout()
        Me.StartGroup.ResumeLayout(False)
        Me.StartGroup.PerformLayout()
        Me.NotifyPanel.ResumeLayout(False)
        Me.NotifyGroup.ResumeLayout(False)
        Me.NotifyGroup.PerformLayout()
        Me.NotifyPowerGroup.ResumeLayout(False)
        Me.NotifyPowerPanel.ResumeLayout(False)
        Me.NotifyPowerPanel.PerformLayout()
        Me.MainPanel.ResumeLayout(False)
        Me.MainScreenPanel.ResumeLayout(False)
        Me.MainScreenPanel.PerformLayout()
        Me.MainButtonPanel.ResumeLayout(False)
        Me.ProgramPanel.ResumeLayout(False)
        Me.TabControlMain.ResumeLayout(False)
        Me.TabPageHotspot.ResumeLayout(False)
        Me.TabPageControl.ResumeLayout(False)
        Me.TabPageDevices.ResumeLayout(False)
        Me.HandlerPanel.ResumeLayout(False)
        CType(Me.MinimizeImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CloseImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DeleteMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents IconMenu As ContextMenuStrip
    Friend WithEvents ToolStripMenu_On As ToolStripMenuItem
    Friend WithEvents ToolStripMenu_Off As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Show As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Exit As ToolStripMenuItem
    Friend WithEvents ToolStripSplit As ToolStripSeparator
    Friend WithEvents ControlPanel As TableLayoutPanel
    Friend WithEvents SaveButton As Button
    Friend WithEvents DefButton As Button
    Friend WithEvents MainPanel As TableLayoutPanel
    Friend WithEvents MainScreenPanel As TableLayoutPanel
    Friend WithEvents HideCheck As CheckBox
    Friend WithEvents WifiNameLabel As Label
    Friend WithEvents ConnectorLabel As Label
    Friend WithEvents PassLabel As Label
    Friend WithEvents ClientNumLabel As Label
    Friend WithEvents PassTextBox As TextBox
    Friend WithEvents WifiNameTextBox As TextBox
    Friend WithEvents MainButtonPanel As TableLayoutPanel
    Friend WithEvents DisButton As Button
    Friend WithEvents CreateButton As Button
    Friend WithEvents ToolStripMenuItem_Monitor As ToolStripMenuItem
    Friend WithEvents ResetButton As Button
    Friend WithEvents ProgramPanel As TableLayoutPanel
    Friend WithEvents TabControlMain As TabControl
    Friend WithEvents TabPageHotspot As TabPage
    Friend WithEvents TabPageControl As TabPage
    Friend WithEvents TabPageDevices As TabPage
    Friend WithEvents HandlerPanel As TableLayoutPanel
    Friend WithEvents CloseImage As PictureBox
    Friend WithEvents MinimizeImage As PictureBox
    Friend WithEvents ClistView As ListView
    Friend WithEvents DeleteMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DeskGroup As System.Windows.Forms.GroupBox
    Friend WithEvents ShortcutCheck As System.Windows.Forms.CheckBox
    Friend WithEvents StartGroup As System.Windows.Forms.GroupBox
    Friend WithEvents MiniCheck As System.Windows.Forms.CheckBox
    Friend WithEvents AutoCheck As System.Windows.Forms.CheckBox
    Friend WithEvents BootCheck As System.Windows.Forms.CheckBox
    Friend WithEvents MonitorCheck As System.Windows.Forms.CheckBox
    Friend WithEvents NotifyPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents NotifyGroup As System.Windows.Forms.GroupBox
    Friend WithEvents DeviceCheck As System.Windows.Forms.CheckBox
    Friend WithEvents PartnerCheck As System.Windows.Forms.CheckBox
    Friend WithEvents InternetCheck As System.Windows.Forms.CheckBox
    Friend WithEvents WlanCheck As System.Windows.Forms.CheckBox
    Friend WithEvents NotifyPowerGroup As System.Windows.Forms.GroupBox
    Friend WithEvents NotifyPowerPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents NotifyOffRadio As System.Windows.Forms.RadioButton
    Friend WithEvents NotifyOnRadio As System.Windows.Forms.RadioButton
    Friend WithEvents TrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents LockCheck As System.Windows.Forms.CheckBox
    Friend WithEvents ClearImage As System.Windows.Forms.Button
End Class
