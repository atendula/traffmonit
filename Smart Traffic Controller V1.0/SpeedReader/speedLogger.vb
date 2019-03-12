Public Class speedLogger
    Public list As New List(Of DataPacket)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub speedLogger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try
        '    bsSpeedBinder.DataSource = list
        '    dgvDataViewer.DataSource = bsSpeedBinder
        'Catch ex As Exception

        'End Try


    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class