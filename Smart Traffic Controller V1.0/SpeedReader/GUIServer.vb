Imports System.Net.Sockets
Imports System.Net
Imports System.IO
Imports System.Text
Public Class GUIServer

    Dim port As Int32 = 11050
    Dim localAddr As IPAddress = IPAddress.Any
    Dim server As New TcpListener(localAddr, port)

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            server.Start()

        Catch ex As Exception
            MessageBox.Show(e.ToString)
        End Try
    End Sub

    Private Sub GUIServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Timer1.Enabled Then
            Timer1.Enabled = False
        End If

    End Sub

    Private Sub IniciarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IniciarToolStripMenuItem.Click
        SysMonitor.Show()

    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Enabled = True
        Timer1.Start()



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If CDbl(txtMax.Text) < CDbl(txtMin.Text) Then
            txtMax.Text = CDbl(txtMax.Text) + 0.5
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Stop()
        Timer1.Enabled = False

    End Sub
End Class