<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SysMonitor
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblThreadCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblProcessosCliente = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblMeasurements = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstLogg = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvClients = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgvSpeedReader = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtMin = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtMax = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LimiteDeMedidasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtLim = New System.Windows.Forms.ToolStripTextBox()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvClients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvSpeedReader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 2000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblThreadCount, Me.ToolStripStatusLabel2, Me.lblProcessosCliente, Me.ToolStripStatusLabel3, Me.lblMeasurements, Me.ToolStripStatusLabel4})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 460)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1207, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "Clientes conectados :"
        '
        'lblThreadCount
        '
        Me.lblThreadCount.Name = "lblThreadCount"
        Me.lblThreadCount.Size = New System.Drawing.Size(22, 17)
        Me.lblThreadCount.Text = "---"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(112, 17)
        Me.ToolStripStatusLabel2.Text = "Clientes em escuta :"
        '
        'lblProcessosCliente
        '
        Me.lblProcessosCliente.Name = "lblProcessosCliente"
        Me.lblProcessosCliente.Size = New System.Drawing.Size(22, 17)
        Me.lblProcessosCliente.Text = "---"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(141, 17)
        Me.ToolStripStatusLabel3.Text = "Measurements Received :"
        '
        'lblMeasurements
        '
        Me.lblMeasurements.Name = "lblMeasurements"
        Me.lblMeasurements.Size = New System.Drawing.Size(22, 17)
        Me.lblMeasurements.Text = "---"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel4.Text = "|"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstLogg)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(482, 417)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Histórico"
        '
        'lstLogg
        '
        Me.lstLogg.FormattingEnabled = True
        Me.lstLogg.Location = New System.Drawing.Point(12, 19)
        Me.lstLogg.Name = "lstLogg"
        Me.lstLogg.ScrollAlwaysVisible = True
        Me.lstLogg.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstLogg.Size = New System.Drawing.Size(464, 394)
        Me.lstLogg.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvClients)
        Me.GroupBox2.Location = New System.Drawing.Point(496, 34)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(311, 417)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Online Devices"
        '
        'dgvClients
        '
        Me.dgvClients.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvClients.Location = New System.Drawing.Point(3, 16)
        Me.dgvClients.MultiSelect = False
        Me.dgvClients.Name = "dgvClients"
        Me.dgvClients.ReadOnly = True
        Me.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClients.Size = New System.Drawing.Size(305, 398)
        Me.dgvClients.TabIndex = 1
        Me.dgvClients.VirtualMode = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvSpeedReader)
        Me.GroupBox3.Location = New System.Drawing.Point(813, 34)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(381, 417)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Speed Averages"
        '
        'dgvSpeedReader
        '
        Me.dgvSpeedReader.AllowUserToAddRows = False
        Me.dgvSpeedReader.AllowUserToDeleteRows = False
        Me.dgvSpeedReader.AllowUserToOrderColumns = True
        Me.dgvSpeedReader.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSpeedReader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSpeedReader.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSpeedReader.Location = New System.Drawing.Point(3, 16)
        Me.dgvSpeedReader.Name = "dgvSpeedReader"
        Me.dgvSpeedReader.ReadOnly = True
        Me.dgvSpeedReader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvSpeedReader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSpeedReader.Size = New System.Drawing.Size(375, 398)
        Me.dgvSpeedReader.TabIndex = 7
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem5, Me.ToolStripMenuItem1, Me.txtMin, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.txtMax, Me.ToolStripMenuItem4, Me.LimiteDeMedidasToolStripMenuItem, Me.txtLim})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1207, 27)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartToolStripMenuItem})
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(62, 23)
        Me.ToolStripMenuItem5.Text = "Servidor"
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.StartToolStripMenuItem.Text = "Start"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(97, 23)
        Me.ToolStripMenuItem1.Text = "Limite Mínimo"
        '
        'txtMin
        '
        Me.txtMin.Name = "txtMin"
        Me.txtMin.Size = New System.Drawing.Size(50, 23)
        Me.txtMin.Text = "0.5"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(22, 23)
        Me.ToolStripMenuItem2.Text = "|"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(98, 23)
        Me.ToolStripMenuItem3.Text = "Limite Máximo"
        '
        'txtMax
        '
        Me.txtMax.Name = "txtMax"
        Me.txtMax.Size = New System.Drawing.Size(50, 23)
        Me.txtMax.Text = "1"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(22, 23)
        Me.ToolStripMenuItem4.Text = "|"
        '
        'LimiteDeMedidasToolStripMenuItem
        '
        Me.LimiteDeMedidasToolStripMenuItem.Name = "LimiteDeMedidasToolStripMenuItem"
        Me.LimiteDeMedidasToolStripMenuItem.Size = New System.Drawing.Size(131, 23)
        Me.LimiteDeMedidasToolStripMenuItem.Text = "Total Leituras/Cliente"
        '
        'txtLim
        '
        Me.txtLim.Name = "txtLim"
        Me.txtLim.Size = New System.Drawing.Size(50, 23)
        Me.txtLim.Text = "2"
        '
        'SysMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1207, 482)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MaximizeBox = False
        Me.Name = "SysMonitor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traffic Monitoring System"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvClients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvSpeedReader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblThreadCount As ToolStripStatusLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lstLogg As ListBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents lblProcessosCliente As ToolStripStatusLabel
    Friend WithEvents dgvClients As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dgvSpeedReader As DataGridView
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents lblMeasurements As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents txtMin As ToolStripTextBox
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents txtMax As ToolStripTextBox
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents LimiteDeMedidasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtLim As ToolStripTextBox
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents StartToolStripMenuItem As ToolStripMenuItem
End Class
