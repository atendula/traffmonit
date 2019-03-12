<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class codeSend
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
        Me.cbxInstr = New System.Windows.Forms.ComboBox()
        Me.txtParameters = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblClientIndex = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbxInstr
        '
        Me.cbxInstr.FormattingEnabled = True
        Me.cbxInstr.Items.AddRange(New Object() {"TTV", "CDE", "FRZE", "UPDT"})
        Me.cbxInstr.Location = New System.Drawing.Point(13, 23)
        Me.cbxInstr.Name = "cbxInstr"
        Me.cbxInstr.Size = New System.Drawing.Size(65, 21)
        Me.cbxInstr.TabIndex = 0
        '
        'txtParameters
        '
        Me.txtParameters.Location = New System.Drawing.Point(85, 23)
        Me.txtParameters.MaxLength = 25
        Me.txtParameters.Name = "txtParameters"
        Me.txtParameters.Size = New System.Drawing.Size(149, 20)
        Me.txtParameters.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(240, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Enviar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblClientIndex})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 62)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(338, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(72, 17)
        Me.ToolStripStatusLabel1.Text = "Client Index:"
        '
        'lblClientIndex
        '
        Me.lblClientIndex.Name = "lblClientIndex"
        Me.lblClientIndex.Size = New System.Drawing.Size(0, 17)
        '
        'codeSend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 84)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtParameters)
        Me.Controls.Add(Me.cbxInstr)
        Me.MaximizeBox = False
        Me.Name = "codeSend"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enviar Codido"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbxInstr As ComboBox
    Friend WithEvents txtParameters As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lblClientIndex As ToolStripStatusLabel
End Class
