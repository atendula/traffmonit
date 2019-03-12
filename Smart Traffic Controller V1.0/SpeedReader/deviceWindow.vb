Public Class deviceWindow


    Dim lis As New List(Of String)

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim choice As MsgBoxResult = MsgBox("A Conexão será recusada e o cliente não será salvo! Proceder?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirmar")
        If choice = MsgBoxResult.Yes Then '
            Me.DialogResult = System.Windows.Forms.DialogResult.No
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Try
                lis.Add(txtDescription.Text)
                lis.Add(cbxZone.Text)
                lis.Add(txtRed.Text)
                lis.Add(txtYelloiw.Text)
                lis.Add(txtGreen.Text)
                'SysMonitor.setList(lis)

                ' SysMonitor.confData = lis
            Catch ex As Exception
                MsgBox("Erro durante a leitura de valores: " & ex.Message)
            End Try
            If txtDescription.Text = "" Or txtGreen.Text = "" Or txtRed.Text = "" Or txtYelloiw.Text = "" Then
                MessageBox.Show("Com excepção da zona, campos vazios não são aceitáveis")
            Else
                Dim choice As MsgBoxResult = MsgBox("Salvar e começar a escutar? ", MsgBoxStyle.Question & MsgBoxStyle.YesNo, "Confirmação")
                If choice = MsgBoxResult.Yes Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.Yes
                Else
                    Me.DialogResult = System.Windows.Forms.DialogResult.No
                End If
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao salvar: " & ex.Message)
        End Try

    End Sub

    Private Function deviceWindow_FormClosing(sender As Object, e As FormClosingEventArgs) As System.Windows.Forms.DialogResult
        Return Me.DialogResult
    End Function

    Public Overloads Function ShowDialog(ByVal id As String) As System.Windows.Forms.DialogResult
        txtID.Text = id
        Me.ShowDialog()
        Me.Focus()
        Return Me.DialogResult
    End Function
    Public Function getList()
        Return lis
    End Function

    Private Sub deviceWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class