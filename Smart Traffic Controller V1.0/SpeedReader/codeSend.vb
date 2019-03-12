Public Class codeSend
    Public index As Integer
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxInstr.SelectedIndexChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtParameters.KeyPress



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim mensagem As String = cbxInstr.SelectedItem.ToString + " " + txtParameters.Text
            SysMonitor.enviarCodes(mensagem, index)
            SysMonitor.lstLogg.Items.Add(Now.ToString + ": Servidor enviou ---> " + mensagem)
            Me.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub codeSend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblClientIndex.Text = index
    End Sub
End Class