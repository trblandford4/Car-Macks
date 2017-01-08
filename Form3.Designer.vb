<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdPlaceOrder = New System.Windows.Forms.Button()
        Me.lstBoxSelected = New System.Windows.Forms.ListBox()
        Me.LstBoxAvailable = New System.Windows.Forms.ListBox()
        Me.lblOrder = New System.Windows.Forms.Label()
        Me.lblDeliver = New System.Windows.Forms.Label()
        Me.btnAddAsset = New System.Windows.Forms.Button()
        Me.btnRemoveAsset = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdPlaceOrder
        '
        Me.cmdPlaceOrder.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdPlaceOrder.Location = New System.Drawing.Point(1046, 477)
        Me.cmdPlaceOrder.Margin = New System.Windows.Forms.Padding(6)
        Me.cmdPlaceOrder.Name = "cmdPlaceOrder"
        Me.cmdPlaceOrder.Size = New System.Drawing.Size(150, 44)
        Me.cmdPlaceOrder.TabIndex = 2
        Me.cmdPlaceOrder.Text = "Place Order"
        Me.cmdPlaceOrder.UseVisualStyleBackColor = False
        '
        'lstBoxSelected
        '
        Me.lstBoxSelected.FormattingEnabled = True
        Me.lstBoxSelected.ItemHeight = 25
        Me.lstBoxSelected.Location = New System.Drawing.Point(730, 92)
        Me.lstBoxSelected.Margin = New System.Windows.Forms.Padding(6)
        Me.lstBoxSelected.Name = "lstBoxSelected"
        Me.lstBoxSelected.Size = New System.Drawing.Size(466, 329)
        Me.lstBoxSelected.TabIndex = 1
        '
        'LstBoxAvailable
        '
        Me.LstBoxAvailable.FormattingEnabled = True
        Me.LstBoxAvailable.ItemHeight = 25
        Me.LstBoxAvailable.Location = New System.Drawing.Point(81, 92)
        Me.LstBoxAvailable.Margin = New System.Windows.Forms.Padding(6)
        Me.LstBoxAvailable.Name = "LstBoxAvailable"
        Me.LstBoxAvailable.Size = New System.Drawing.Size(466, 329)
        Me.LstBoxAvailable.TabIndex = 0
        '
        'lblOrder
        '
        Me.lblOrder.AutoSize = True
        Me.lblOrder.Location = New System.Drawing.Point(76, 50)
        Me.lblOrder.Name = "lblOrder"
        Me.lblOrder.Size = New System.Drawing.Size(141, 25)
        Me.lblOrder.TabIndex = 5
        Me.lblOrder.Text = "Cars Ordered"
        '
        'lblDeliver
        '
        Me.lblDeliver.AutoSize = True
        Me.lblDeliver.Location = New System.Drawing.Point(725, 50)
        Me.lblDeliver.Name = "lblDeliver"
        Me.lblDeliver.Size = New System.Drawing.Size(161, 25)
        Me.lblDeliver.TabIndex = 6
        Me.lblDeliver.Text = "Cars To Deliver"
        '
        'btnAddAsset
        '
        Me.btnAddAsset.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAddAsset.Location = New System.Drawing.Point(587, 180)
        Me.btnAddAsset.Margin = New System.Windows.Forms.Padding(6)
        Me.btnAddAsset.Name = "btnAddAsset"
        Me.btnAddAsset.Size = New System.Drawing.Size(112, 54)
        Me.btnAddAsset.TabIndex = 7
        Me.btnAddAsset.Text = ">>"
        Me.btnAddAsset.UseVisualStyleBackColor = False
        '
        'btnRemoveAsset
        '
        Me.btnRemoveAsset.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnRemoveAsset.Location = New System.Drawing.Point(587, 282)
        Me.btnRemoveAsset.Margin = New System.Windows.Forms.Padding(6)
        Me.btnRemoveAsset.Name = "btnRemoveAsset"
        Me.btnRemoveAsset.Size = New System.Drawing.Size(112, 54)
        Me.btnRemoveAsset.TabIndex = 8
        Me.btnRemoveAsset.Text = "<<"
        Me.btnRemoveAsset.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(1046, 545)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(150, 42)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(1275, 669)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnRemoveAsset)
        Me.Controls.Add(Me.btnAddAsset)
        Me.Controls.Add(Me.lblDeliver)
        Me.Controls.Add(Me.lblOrder)
        Me.Controls.Add(Me.cmdPlaceOrder)
        Me.Controls.Add(Me.lstBoxSelected)
        Me.Controls.Add(Me.LstBoxAvailable)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "Form"
        Me.Text = "CarMacks"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdPlaceOrder As Button
    Friend WithEvents LstBoxAvailable As ListBox
    Friend WithEvents lstBoxSelected As ListBox
    Friend WithEvents lblOrder As Label
    Friend WithEvents lblDeliver As Label
    Friend WithEvents btnAddAsset As Button
    Friend WithEvents btnRemoveAsset As Button
    Friend WithEvents btnClose As Button
End Class
