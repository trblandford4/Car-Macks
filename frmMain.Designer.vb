<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NetworkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmNodes = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmArcs = New System.Windows.Forms.ToolStripMenuItem()
        Me.MapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lstPath = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotalDistance = New System.Windows.Forms.TextBox()
        Me.btnResetNet = New System.Windows.Forms.Button()
        Me.btnShortestPath = New System.Windows.Forms.Button()
        Me.lstBoxSelected = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnRemoveAsset = New System.Windows.Forms.Button()
        Me.btnAddAsset = New System.Windows.Forms.Button()
        Me.LstBoxAvailable = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.wbGoogleMaps = New System.Windows.Forms.WebBrowser()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NetworkToolStripMenuItem, Me.MapToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(2400, 40)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NetworkToolStripMenuItem
        '
        Me.NetworkToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmNodes, Me.tsmArcs})
        Me.NetworkToolStripMenuItem.Name = "NetworkToolStripMenuItem"
        Me.NetworkToolStripMenuItem.Size = New System.Drawing.Size(125, 36)
        Me.NetworkToolStripMenuItem.Text = "About Us"
        '
        'tsmNodes
        '
        Me.tsmNodes.Name = "tsmNodes"
        Me.tsmNodes.Size = New System.Drawing.Size(319, 38)
        Me.tsmNodes.Text = "Car Macks"
        '
        'tsmArcs
        '
        Me.tsmArcs.Name = "tsmArcs"
        Me.tsmArcs.Size = New System.Drawing.Size(319, 38)
        Me.tsmArcs.Text = "Traveling Salesman"
        '
        'MapToolStripMenuItem
        '
        Me.MapToolStripMenuItem.Name = "MapToolStripMenuItem"
        Me.MapToolStripMenuItem.Size = New System.Drawing.Size(189, 36)
        Me.MapToolStripMenuItem.Text = "Meet the Team"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 40)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblProgress)
        Me.SplitContainer1.Panel1.Controls.Add(Me.StatusStrip1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ProgressBar1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstPath)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtTotalDistance)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnResetNet)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnShortestPath)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstBoxSelected)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnRemoveAsset)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnAddAsset)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LstBoxAvailable)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.wbGoogleMaps)
        Me.SplitContainer1.Size = New System.Drawing.Size(2400, 1196)
        Me.SplitContainer1.SplitterDistance = 790
        Me.SplitContainer1.TabIndex = 14
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(176, 1025)
        Me.lblProgress.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(98, 25)
        Me.lblProgress.TabIndex = 31
        Me.lblProgress.Text = "Progress"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(40, 40)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 1159)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 10, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(790, 37)
        Me.StatusStrip1.TabIndex = 30
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslStatus
        '
        Me.tslStatus.Name = "tslStatus"
        Me.tslStatus.Size = New System.Drawing.Size(84, 32)
        Me.tslStatus.Text = "Status."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(176, 1056)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(436, 53)
        Me.ProgressBar1.TabIndex = 29
        '
        'lstPath
        '
        Me.lstPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lstPath.FormattingEnabled = True
        Me.lstPath.HorizontalScrollbar = True
        Me.lstPath.ItemHeight = 25
        Me.lstPath.Location = New System.Drawing.Point(176, 899)
        Me.lstPath.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lstPath.Name = "lstPath"
        Me.lstPath.Size = New System.Drawing.Size(437, 79)
        Me.lstPath.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(171, 868)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 25)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Path"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(171, 797)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 25)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Total Distance"
        '
        'txtTotalDistance
        '
        Me.txtTotalDistance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtTotalDistance.Enabled = False
        Me.txtTotalDistance.Location = New System.Drawing.Point(176, 826)
        Me.txtTotalDistance.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTotalDistance.Name = "txtTotalDistance"
        Me.txtTotalDistance.ReadOnly = True
        Me.txtTotalDistance.Size = New System.Drawing.Size(437, 31)
        Me.txtTotalDistance.TabIndex = 27
        '
        'btnResetNet
        '
        Me.btnResetNet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnResetNet.Location = New System.Drawing.Point(414, 682)
        Me.btnResetNet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnResetNet.Name = "btnResetNet"
        Me.btnResetNet.Size = New System.Drawing.Size(158, 73)
        Me.btnResetNet.TabIndex = 24
        Me.btnResetNet.Text = "Reset"
        Me.btnResetNet.UseVisualStyleBackColor = True
        '
        'btnShortestPath
        '
        Me.btnShortestPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnShortestPath.Location = New System.Drawing.Point(201, 682)
        Me.btnShortestPath.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnShortestPath.Name = "btnShortestPath"
        Me.btnShortestPath.Size = New System.Drawing.Size(158, 73)
        Me.btnShortestPath.TabIndex = 23
        Me.btnShortestPath.Text = "Find Route"
        Me.btnShortestPath.UseVisualStyleBackColor = True
        '
        'lstBoxSelected
        '
        Me.lstBoxSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lstBoxSelected.FormattingEnabled = True
        Me.lstBoxSelected.ItemHeight = 25
        Me.lstBoxSelected.Location = New System.Drawing.Point(176, 431)
        Me.lstBoxSelected.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.lstBoxSelected.Name = "lstBoxSelected"
        Me.lstBoxSelected.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstBoxSelected.Size = New System.Drawing.Size(437, 154)
        Me.lstBoxSelected.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(171, 400)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 25)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Selected Cars:"
        '
        'btnRemoveAsset
        '
        Me.btnRemoveAsset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveAsset.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnRemoveAsset.BackgroundImage = Global.CarMacks.My.Resources.Resources.arrow_up_c
        Me.btnRemoveAsset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRemoveAsset.Location = New System.Drawing.Point(414, 293)
        Me.btnRemoveAsset.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnRemoveAsset.Name = "btnRemoveAsset"
        Me.btnRemoveAsset.Size = New System.Drawing.Size(158, 73)
        Me.btnRemoveAsset.TabIndex = 20
        Me.btnRemoveAsset.UseVisualStyleBackColor = False
        '
        'btnAddAsset
        '
        Me.btnAddAsset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnAddAsset.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAddAsset.BackgroundImage = Global.CarMacks.My.Resources.Resources.arrow_down_c
        Me.btnAddAsset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAddAsset.ForeColor = System.Drawing.Color.White
        Me.btnAddAsset.Location = New System.Drawing.Point(201, 293)
        Me.btnAddAsset.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnAddAsset.Name = "btnAddAsset"
        Me.btnAddAsset.Size = New System.Drawing.Size(158, 73)
        Me.btnAddAsset.TabIndex = 19
        Me.btnAddAsset.UseVisualStyleBackColor = False
        '
        'LstBoxAvailable
        '
        Me.LstBoxAvailable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.LstBoxAvailable.FormattingEnabled = True
        Me.LstBoxAvailable.ItemHeight = 25
        Me.LstBoxAvailable.Location = New System.Drawing.Point(176, 74)
        Me.LstBoxAvailable.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.LstBoxAvailable.Name = "LstBoxAvailable"
        Me.LstBoxAvailable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.LstBoxAvailable.Size = New System.Drawing.Size(437, 129)
        Me.LstBoxAvailable.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(171, 33)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 25)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Available Cars:"
        '
        'wbGoogleMaps
        '
        Me.wbGoogleMaps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbGoogleMaps.Location = New System.Drawing.Point(0, 0)
        Me.wbGoogleMaps.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbGoogleMaps.Name = "wbGoogleMaps"
        Me.wbGoogleMaps.Size = New System.Drawing.Size(1606, 1196)
        Me.wbGoogleMaps.TabIndex = 1
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2400, 1236)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Welcome to Car Macks!"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents NetworkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsmNodes As ToolStripMenuItem
    Friend WithEvents tsmArcs As ToolStripMenuItem
    Friend WithEvents MapToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents LstBoxAvailable As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnRemoveAsset As Button
    Friend WithEvents btnAddAsset As Button
    Friend WithEvents lstBoxSelected As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnResetNet As Button
    Friend WithEvents btnShortestPath As Button
    Friend WithEvents lstPath As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtTotalDistance As TextBox
    Friend WithEvents wbGoogleMaps As WebBrowser
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tslStatus As ToolStripStatusLabel
    Friend WithEvents lblProgress As Label
End Class
