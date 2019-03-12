Imports System.IO.Ports
Imports System.Threading
Public Class SerialReader

    Private thread As Thread



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'gets all devices conected through serial into combobox1
        Try
            ComboBox1.Items.Clear()
            Dim ports As Array
            ports = IO.Ports.SerialPort.GetPortNames
            ComboBox1.Items.AddRange(ports)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'tries to establish a connection
        Try
            serialComm.PortName = ComboBox1.SelectedItem.ToString
            serialComm.BaudRate = TextBox1.Text
            serialComm.Open()
            If serialComm.IsOpen Then
                MessageBox.Show("Connection Sucessfuly Established!")
                Timer1.Start()

            Else
                MessageBox.Show("Connection to device failed!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim received As Single = serialComm.ReadExisting
            Label1.Text = "Current Reading : " & received.ToString & " m/s"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            serialComm.Close()
            Timer1.Stop()

        Catch ex As Exception
            MessageBox.Show("Error :" & ex.Message.ToString)
        End Try
    End Sub
End Class
