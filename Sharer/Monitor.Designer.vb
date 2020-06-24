<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Monitor
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
        Me.SpeedMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChooseNetDisk = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChooseOpacity = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpacityMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Percent_100 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Percent_90 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Percent_75 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Percent_50 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Percent_25 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitTool = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.DLSpeedLabel = New System.Windows.Forms.Label()
        Me.ULSpeedLabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SpeedMenu.SuspendLayout()
        Me.OpacityMenu.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SpeedMenu
        '
        Me.SpeedMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.SpeedMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChooseNetDisk, Me.ChooseOpacity, Me.ToolStripSeparator1, Me.ExitTool})
        Me.SpeedMenu.Name = "ContextMenuStrip1"
        Me.SpeedMenu.ShowCheckMargin = True
        Me.SpeedMenu.ShowImageMargin = False
        Me.SpeedMenu.Size = New System.Drawing.Size(139, 82)
        '
        'ChooseNetDisk
        '
        Me.ChooseNetDisk.Name = "ChooseNetDisk"
        Me.ChooseNetDisk.Size = New System.Drawing.Size(138, 24)
        Me.ChooseNetDisk.Text = "Adapter"
        '
        'ChooseOpacity
        '
        Me.ChooseOpacity.DropDown = Me.OpacityMenu
        Me.ChooseOpacity.Name = "ChooseOpacity"
        Me.ChooseOpacity.Size = New System.Drawing.Size(138, 24)
        Me.ChooseOpacity.Text = "Opacity"
        '
        'OpacityMenu
        '
        Me.OpacityMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.OpacityMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Percent_100, Me.Percent_90, Me.Percent_75, Me.Percent_50, Me.Percent_25})
        Me.OpacityMenu.Name = "OpacityMenu"
        Me.OpacityMenu.OwnerItem = Me.ChooseOpacity
        Me.OpacityMenu.Size = New System.Drawing.Size(119, 124)
        '
        'Percent_100
        '
        Me.Percent_100.Name = "Percent_100"
        Me.Percent_100.Size = New System.Drawing.Size(118, 24)
        Me.Percent_100.Tag = "100"
        Me.Percent_100.Text = "100%"
        '
        'Percent_90
        '
        Me.Percent_90.Name = "Percent_90"
        Me.Percent_90.Size = New System.Drawing.Size(118, 24)
        Me.Percent_90.Tag = "90"
        Me.Percent_90.Text = "90%"
        '
        'Percent_75
        '
        Me.Percent_75.Name = "Percent_75"
        Me.Percent_75.Size = New System.Drawing.Size(118, 24)
        Me.Percent_75.Tag = "75"
        Me.Percent_75.Text = "75%"
        '
        'Percent_50
        '
        Me.Percent_50.Name = "Percent_50"
        Me.Percent_50.Size = New System.Drawing.Size(118, 24)
        Me.Percent_50.Tag = "50"
        Me.Percent_50.Text = "50%"
        '
        'Percent_25
        '
        Me.Percent_25.Name = "Percent_25"
        Me.Percent_25.Size = New System.Drawing.Size(118, 24)
        Me.Percent_25.Tag = "25"
        Me.Percent_25.Text = "25%"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(135, 6)
        '
        'ExitTool
        '
        Me.ExitTool.Name = "ExitTool"
        Me.ExitTool.Size = New System.Drawing.Size(138, 24)
        Me.ExitTool.Text = "Hide"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.0!))
        Me.TableLayoutPanel1.ContextMenuStrip = Me.SpeedMenu
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DLSpeedLabel, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ULSpeedLabel, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 0, 0)
        Me.TableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.DimGray
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(238, 29)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox2.ContextMenuStrip = Me.SpeedMenu
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.PictureBox2.Image = Global.Sharer.My.Resources.Resources.up
        Me.PictureBox2.Location = New System.Drawing.Point(127, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'DLSpeedLabel
        '
        Me.DLSpeedLabel.AutoSize = True
        Me.DLSpeedLabel.ContextMenuStrip = Me.SpeedMenu
        Me.DLSpeedLabel.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.DLSpeedLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DLSpeedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DLSpeedLabel.Location = New System.Drawing.Point(33, 0)
        Me.DLSpeedLabel.Name = "DLSpeedLabel"
        Me.DLSpeedLabel.Size = New System.Drawing.Size(84, 29)
        Me.DLSpeedLabel.TabIndex = 0
        Me.DLSpeedLabel.Text = "0.00 B/s"
        Me.DLSpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ULSpeedLabel
        '
        Me.ULSpeedLabel.AutoSize = True
        Me.ULSpeedLabel.ContextMenuStrip = Me.SpeedMenu
        Me.ULSpeedLabel.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ULSpeedLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ULSpeedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ULSpeedLabel.Location = New System.Drawing.Point(149, 0)
        Me.ULSpeedLabel.Name = "ULSpeedLabel"
        Me.ULSpeedLabel.Size = New System.Drawing.Size(86, 29)
        Me.ULSpeedLabel.TabIndex = 1
        Me.ULSpeedLabel.Text = "0.00 B/s"
        Me.ULSpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox1.ContextMenuStrip = Me.SpeedMenu
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.PictureBox1.Image = Global.Sharer.My.Resources.Resources.down
        Me.PictureBox1.Location = New System.Drawing.Point(11, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Monitor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(238, 29)
        Me.ContextMenuStrip = Me.SpeedMenu
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Monitor"
        Me.Opacity = 0.9R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        Me.SpeedMenu.ResumeLayout(False)
        Me.OpacityMenu.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SpeedMenu As ContextMenuStrip
    Friend WithEvents ChooseNetDisk As ToolStripMenuItem
    Friend WithEvents ExitTool As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ChooseOpacity As ToolStripMenuItem
    Friend WithEvents OpacityMenu As ContextMenuStrip
    Friend WithEvents Percent_100 As ToolStripMenuItem
    Friend WithEvents Percent_90 As ToolStripMenuItem
    Friend WithEvents Percent_75 As ToolStripMenuItem
    Friend WithEvents Percent_50 As ToolStripMenuItem
    Friend WithEvents Percent_25 As ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents DLSpeedLabel As Label
    Friend WithEvents ULSpeedLabel As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
