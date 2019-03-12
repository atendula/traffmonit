Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Threading.Thread
Imports System.Threading
Public Class ZoneManagerGUI
    Public confData As New List(Of String)
    Dim readData As ZoneClientData
    Dim clientOneData, clientTwoData As New List(Of ZoneClientData)
    Dim listOfClients As New List(Of ClassForClient)
    Dim device1, device2 As ClassForClient
    Dim Listning As TcpListener
    Dim clientOneSyncThread As System.Threading.Thread
    Dim clientTwoSynchThread As System.Threading.Thread
    Dim synchManager As System.Threading.Thread
    Dim client1Mode As Integer = 10, client2Mode As Integer = 10

    Public Sub setZoneClients(ByRef client1 As ClassForClient, ByRef client2 As ClassForClient)
        listOfClients.Add(client1)
        listOfClients.Add(client2)
    End Sub

    Private Sub ZoneManagerGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Control.CheckForIllegalCrossThreadCalls = False
        Try
            Ard1bs.DataSource = clientOneData
            Chart1.DataSource = Ard1bs
            Ard2bs.DataSource = clientTwoData
            Chart2.DataSource = Ard2bs
            If listOfClients.Count = 2 Then
                clientOneSyncThread = New System.Threading.Thread(AddressOf clientOneSynch)
                clientTwoSynchThread = New System.Threading.Thread(AddressOf clientTwoSynch)


            End If
        Catch ex As Exception

        End Try

        'Ard2bs.DataSource = speedRecordList
        'dgvSpeedReader.DataSource = bsSpeed

        ' dgvBindings.DataSource = bsBinder

    End Sub

    Private Sub clientOneSynch()
        Dim instr As String = ""
        Using stream As NetworkStream = listOfClients.Item(0).TCPclient.GetStream
            While client1Mode < 10
                Select Case client1Mode
                    Case 0
                        'case 0 is for when the program is starting
                        listOfClients.Item(0).sendCodes("SSR" + tkBrVermelho.Value)
                        client1Mode = 1
                    Case 1
                        If stream.DataAvailable Then

                        End If
                End Select
            End While

        End Using

    End Sub

    Private Sub clientTwoSynch()

    End Sub

    Private Sub tkBrVermelho_Scroll(sender As Object, e As EventArgs) Handles tkBrVermelho.Scroll
        tkBrVerde.Value = 10 - tkBrVermelho.Value

    End Sub

    Private Sub clienteManagement()
        While True
            Try
                'recebe uma nova conexão e associa a mesma a um objecto do tipo ClassForClients
                Dim pedido As TcpClient = Listning.AcceptTcpClient

                'deviceWindow.ShowDialog(Me)

                confData.Clear()

                deviceWindow = New deviceWindow

                'deviceWindow.txtID.Text = pedido.Client.RemoteEndPoint.ToString

                If deviceWindow.ShowDialog(pedido.Client.RemoteEndPoint.ToString) = System.Windows.Forms.DialogResult.Yes Then

                    confData = deviceWindow.getList()

                    'MessageBox.Show("Conf Returned: " & confData.Count.ToString)

                    Dim results As MsgBoxResult = MsgBox("Descrição: " & confData.Item(0) & vbCrLf & "Zone: " & confData.Item(1) & vbCrLf & "Red Timer: " & confData.Item(2) & vbCrLf & "Yellow Timer: " & confData.Item(3) & vbCrLf & "Green Timer: " & confData.Item(4), MsgBoxStyle.YesNo, "Confirmar valores")

                    If results = MsgBoxResult.Yes Then
                        Dim novoCliente As New ClassForClient(pedido, confData.Item(0), confData.Item(1))

                        If novoCliente.TCPclient.Connected Then

                            'bsBinder.Add(novoCliente)
                            'generates a new windows for visualizing speed measurements of each client

                            'lstLogg.Items.Add(Now.ToString + " : " + novoCliente.TCPclient.Client.RemoteEndPoint.ToString + " is connected! ")
                            'Dim code As String = InputBox("Insira as configuraçóes para  " + novoCliente.TCPclient.Client.RemoteEndPoint.ToString)
                            'Dim code As String = "TTV " & CInt(confData.Item(4)) & "," & CInt(confData.Item(3)) & "," & CInt(confData.Item(2)) & "," & CDbl(txtMin.Text) * 100 & "," & CDbl(txtMax.Text) * 100
                            'If code IsNot "" Then
                            'MessageBox.Show(code)
                            ' novoCliente.sendCodes(code)
                            'lstLogg.Items.Add(Now.ToString + " Instrução < " & code & ">  enviada para " & confData.Item(0))
                            '  End If
                            'novoCliente.Thread = New Thread(Sub() Me.controller(novoCliente))
                            'novoCliente.Thread.Start()
                            'listapProcessos.Add(novoCliente.Thread)
                            'graph.Series.Add(novoCliente.TCPclient.Client.RemoteEndPoint.ToString)
                            'Try
                            '    'each window is added to a list for control purposes
                            '    speedLogger.bsSpeedBinder = bsSpeed
                            '    speedLogger.Show()
                            'Catch ex As Exception
                            '    MessageBox.Show("Erro: " + ex.Message)
                            'End Try

                        End If
                    Else
                        pedido.Client.Close()
                        MessageBox.Show("Connection Denied!")

                    End If

                End If
                Threading.Thread.Sleep(500)
            Catch ex As Exception
                MessageBox.Show("Client Management : " + ex.Message)
                Exit While
            End Try
        End While

    End Sub


    Private Function readMessage(ByVal message As String)
        Dim code As String = message.Substring(3)
        Dim value As Double = 0
        If message.StartsWith("ST") Then
            Return code
        End If
        If message.StartsWith("SRX") Then
            Try
                value = code
                Return value
            Catch ex As Exception
                MessageBox.Show("Conversion error was identified")
                Return 0
            End Try
        End If
    End Function

    Private Function readBuffer(ByVal client As TcpClient, ByVal netStream As NetworkStream)
        Dim receptor(client.ReceiveBufferSize) As Byte
        netStream.Read(receptor, 0, CInt(client.ReceiveBufferSize))
        Dim mensagem As String = Encoding.UTF8.GetString(receptor)
        Return mensagem
    End Function
End Class