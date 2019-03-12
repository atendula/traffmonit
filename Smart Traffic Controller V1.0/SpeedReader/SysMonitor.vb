Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Threading.Thread
Imports System.Threading

Public Class SysMonitor

    Public confData As New List(Of String)

    Public deviceWindow As deviceWindow

    Dim Listning As TcpListener

    Public stream As NetworkStream

    Public listaClientes As New List(Of ClassForClient)
    Dim listapProcessos As New List(Of Thread)

    Dim speedRecordList As New List(Of DataPacket)
    Dim visuaLizers As New List(Of speedLogger)

    Dim clientExec As Boolean = True
    Dim bsBinder As BindingSource
    Dim bsSpeed As BindingSource
    Dim listClientBinders As New List(Of BindingSource)



    Dim thread As System.Threading.Thread



    Private Sub Logger_load(sender As Object, e As EventArgs) Handles MyBase.Load

        Control.CheckForIllegalCrossThreadCalls = False
        bsBinder = New BindingSource
        bsSpeed = New BindingSource


        bsBinder.DataSource = listaClientes
        dgvClients.DataSource = bsBinder
        bsSpeed.DataSource = speedRecordList
        dgvSpeedReader.DataSource = bsSpeed

        ' dgvBindings.DataSource = bsBinder


    End Sub

    Private Sub startServer()
        Try
            'starts the server
            Listning = New TcpListener(IPAddress.Any, 11050)
            Listning.Start()
            lstLogg.Items.Add(TimeOfDay.ToString + " : Server Started!")
            'creates a new thread to deal with connections
            thread = New System.Threading.Thread(AddressOf clienteManagement)
            thread.Start()
            'starts a timer to deal specifically with keeping track of how many clients are connected
            Timer1.Start()
        Catch ex As Exception
            MessageBox.Show("Load Error: " + ex.Message)
        End Try
    End Sub

    Private Sub stopServer()
        Try
            clientExec = False
            'tries to close all of the clients
            For i As Integer = listaClientes.Count - 1 To 0 Step -1
                Try
                    listaClientes(i).TCPclient.Close()
                Catch ex As Exception

                End Try
            Next
            'tries to close all of the threads
            For i As Integer = listapProcessos.Count - 1 To 0 Step -1
                Try
                    listapProcessos(i).Abort()
                Catch ex As Exception

                End Try
            Next
            Listning.Stop()
            thread.Abort()
            MessageBox.Show("Server Stopped!")
            Timer1.Stop()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Logger_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dim choice As MsgBoxResult = MsgBox("Tem Certeza que pretende sair?", MsgBoxStyle.YesNo)
        If choice = MsgBoxResult.Yes Then
            Try
                stopServer()
            Catch ex As Exception

            End Try

        End If
    End Sub


    Private Sub clienteManagement()
        While clientExec
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

                            bsBinder.Add(novoCliente)
                            'generates a new windows for visualizing speed measurements of each client

                            lstLogg.Items.Add(Now.ToString + " : " + novoCliente.TCPclient.Client.RemoteEndPoint.ToString + " is connected! ")
                            'Dim code As String = InputBox("Insira as configuraçóes para  " + novoCliente.TCPclient.Client.RemoteEndPoint.ToString)
                            Dim code As String = "TTV " & CInt(confData.Item(4)) & "," & CInt(confData.Item(3)) & "," & CInt(confData.Item(2)) & "," & CDbl(txtMin.Text) * 100 & "," & CDbl(txtMax.Text) * 100
                            If code IsNot "" Then
                                'MessageBox.Show(code)
                                novoCliente.sendCodes(code)
                                lstLogg.Items.Add(Now.ToString + " Instrução < " & code & ">  enviada para " & confData.Item(0))
                            End If
                            novoCliente.Thread = New Thread(Sub() Me.controller(novoCliente))
                            novoCliente.Thread.Start()
                            listapProcessos.Add(novoCliente.Thread)
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
                clientExec = False
            End Try
        End While

    End Sub
    '------------------------function below has been deprecated --------------------------------
    'Private Sub messageReader(cliente As TcpClient, flow As NetworkStream)

    '    While True
    '        Try
    '            'only listens when the client is connected
    '            If cliente.Connected Then
    '                If flow.DataAvailable And flow.DataAvailable <> Nothing Then
    '                    Dim receptor(Allclient.ReceiveBufferSize) As Byte
    '                    stream.Read(receptor, 0, CInt(Allclient.ReceiveBufferSize))
    '                    Dim mensagem As String = Encoding.UTF8.GetString(receptor)
    '                    Dim extract As Double
    '                    extract = Double.Parse(mensagem)
    '                    lstLogg.Items.Add(TimeOfDay.ToString + Allclient.Client.RemoteEndPoint.ToString + " enviou " + extract.ToString)
    '                Else
    '                    'goes to the next iteration as long as the client is connected
    '                    Continue While
    '                End If
    '            Else
    '                'if it detects that the client has been disconected, it exits the while loop, ending the process
    '                MessageBox.Show(cliente.Client.RemoteEndPoint.ToString + " Has been disconected!")
    '                Exit While
    '            End If

    '        Catch ex As Exception
    '            MessageBox.Show(" Message Reader Error: " + ex.Message)
    '            Exit While
    '        End Try
    '    End While
    'End Sub
    '------------------------function above has been deprecated --------------------------------

    Public Sub controller(client As ClassForClient)
        Try
            Dim control As Boolean = True
            'lista criada para armazenar as leituras de velocidade do cliente
            Dim speedDouble As New List(Of Double)
            Dim dataPacket As DataPacket
            'componente recebe a classe Stream do Cliente
            Using stream As NetworkStream = client.TCPclient.GetStream
                While True
                    If client.TCPclient.Client.Connected And stream.DataAvailable And stream.DataAvailable <> Nothing Then
                        'le a mensagem do buffer e converte em double
                        Dim receptor(client.TCPclient.ReceiveBufferSize) As Byte
                        stream.Read(receptor, 0, CInt(client.TCPclient.ReceiveBufferSize))
                        Dim mensagem As String = Encoding.UTF8.GetString(receptor)
                        Dim extract As Double
                        Try
                            extract = Double.Parse(mensagem)
                        Catch ex As Exception

                        End Try

                        'calcula a media de velocidade depois de receber 5 leituras
                        If speedDouble.Count = CInt(txtLim.Text) Then
                            Dim avg As Double = 0
                            For i = 0 To speedDouble.Count - 1 Step 1
                                avg += speedDouble.Item(i)
                            Next
                            Dim total As Double = avg / speedDouble.Count
                            'MessageBox.Show("Média de " + txtLim.Text + " leituras é " + total.ToString)
                            dataPacket = New DataPacket(client.ID, total, Now)

                            'verifica se os valores recebidos estao dentro da norma
                            If total < CDbl(txtMin.Text) Or total > CDbl(txtMax.Text) Then
                                Dim ajuste = MsgBox("Velocidade Medida está fora dos padrões! Ajustar?", MsgBoxStyle.YesNo)
                                If ajuste = MsgBoxResult.Yes Then
                                    If total < CDbl(txtMin.Text) Then
                                        Dim code As String = InputBox("Inserir comando para aumentar a média:")
                                        client.sendCodes(code)
                                        lstLogg.Items.Add(Now.ToString + ": " + client.ID + " enviou --> " + code)
                                    End If
                                    If total > CDbl(txtMax.Text) Then
                                        Dim code As String = InputBox("Inserir comando para reduzir a média:")
                                        client.sendCodes(code)
                                        lstLogg.Items.Add(Now.ToString + ": " + client.ID + "  enviou --> " + code)
                                    End If
                                End If
                            End If
                            '
                            bsSpeed.Add(dataPacket)
                            speedDouble.Clear()
                        Else
                            speedDouble.Add(extract)
                            MessageBox.Show("Received: " + extract.ToString)

                        End If
                        'Dim newSpeed = New DataPacket(client.ID, extract, Now)
                        'bsSpeed.Add(newSpeed)
                        'speedDouble.Clear()

                        'lstLogg.Items.Add(Now.ToString + client.ID + " enviou " + extract.ToString)

                    ElseIf client.TCPclient.Client.Connected = False Then
                        Exit While
                    Else
                        Threading.Thread.Sleep(500)
                        'goes to the next iteration as long as the client is connected
                        Continue While
                    End If

                End While

                'client gracefully closed the connection on the remote end
            End Using

        Catch ocex As OperationCanceledException
            'the expected exception if this routines's async method calls honor signaling of the cancelation token
            '*NOTE: NetworkStream.ReadAsync() will not honor the cancelation signal
        Catch odex As ObjectDisposedException
            'server disconnected client while reading
        Catch ioex As IOException
            'client terminated (remote application terminated without socket close) while reading
        Finally
            'ensure the client is closed - this is typically a redundant call, but in the
            'case of an unhandled exception it may be necessary
            client.TCPclient.Close()
            MessageBox.Show("client has been disconnected and process terminated")
            'remove the client from the list of connected clients
            'bsBinder.Remove(client)
            'remove the client's task from the list of running tasks
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblThreadCount.Text = listaClientes.Count
        lblProcessosCliente.Text = listapProcessos.Count

    End Sub

    Private Sub dgvBindings_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClients.CellDoubleClick
        Try
            Dim index As Integer = dgvClients.CurrentCell.RowIndex

            If dgvClients.Rows(index).Cells(0).Value.ToString IsNot vbNullString Then
                codeSend.index = index
                codeSend.ShowDialog()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub enviarCodes(mensagem As String, index As Integer)
        Try
            listaClientes(index).sendCodes(mensagem)
        Catch ex As Exception
            MessageBox.Show("Send Code Error: " + ex.Message)
        End Try

    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click

        Select Case StartToolStripMenuItem.Text
            Case "Start"
                startServer()
                StartToolStripMenuItem.Text = "Stop"
            Case "Stop"
                stopServer()
                StartToolStripMenuItem.Text = "Start"
        End Select
    End Sub

    Public Sub setList(ByVal list As List(Of String))
        confData = list
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class