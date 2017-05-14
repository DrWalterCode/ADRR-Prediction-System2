<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Passwordrecover
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Passwordrecover))
        Me.label7 = New System.Windows.Forms.Label()
        Me.t2 = New System.Windows.Forms.Label()
        Me.t1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.txtCell = New DevExpress.XtraEditors.TextEdit()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtCell.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'label7
        '
        Me.label7.AutoSize = true
        Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.label7.Location = New System.Drawing.Point(93, 41)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(237, 13)
        Me.label7.TabIndex = 38
        Me.label7.Text = "Please enter cell number  to recover password to"
        '
        't2
        '
        Me.t2.AutoSize = true
        Me.t2.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.t2.ForeColor = System.Drawing.SystemColors.InfoText
        Me.t2.Location = New System.Drawing.Point(30, -1)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(316, 13)
        Me.t2.TabIndex = 379
        Me.t2.Text = "CONNECTED TO ADRR SYSTEM SMS RECOVERY SERVER"
        Me.t2.Visible = false
        '
        't1
        '
        Me.t1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.t1.Appearance.Options.UseBackColor = true
        Me.t1.BarAnimationElementThickness = 2
        Me.t1.Caption = ""
        Me.t1.Description = ""
        Me.t1.Location = New System.Drawing.Point(100, 25)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(201, 13)
        Me.t1.TabIndex = 378
        Me.t1.Text = "ProgressPanel1"
        Me.t1.Visible = false
        Me.t1.WaitAnimationType = DevExpress.Utils.Animation.WaitingAnimatorType.Line
        '
        'txtCell
        '
        Me.txtCell.Location = New System.Drawing.Point(86, 57)
        Me.txtCell.Name = "txtCell"
        Me.txtCell.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtCell.Properties.Appearance.Options.UseBackColor = true
        Me.txtCell.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtCell.Properties.Mask.BeepOnError = true
        Me.txtCell.Properties.Mask.EditMask = "+263700000000"
        Me.txtCell.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
        Me.txtCell.Size = New System.Drawing.Size(260, 20)
        Me.txtCell.TabIndex = 380
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.Color.White
        Me.SimpleButton1.Appearance.Options.UseBackColor = true
        Me.SimpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"),System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(241, 106)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(105, 37)
        Me.SimpleButton1.TabIndex = 39
        Me.SimpleButton1.TabStop = false
        Me.SimpleButton1.Text = "Recover"
        '
        'Passwordrecover
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(401, 155)
        Me.Controls.Add(Me.txtCell)
        Me.Controls.Add(Me.t2)
        Me.Controls.Add(Me.t1)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.label7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "Passwordrecover"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Password Recover"
        CType(Me.txtCell.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Private WithEvents label7 As Label
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents t2 As Label
    Friend WithEvents t1 As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents txtCell As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
End Class
