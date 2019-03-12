Imports System.Threading.Thread
Imports SpeedReader.ClassForClient
Imports System.Net.Sockets
Imports System.IO
Imports System.Text

Public Class ZoneManager
    Dim device1, device2 As ClassForClient
    Public confData As New List(Of String)
    Dim redTimer, greenTimer As Integer
    Dim zoneThread As System.Threading.Thread

    Dim stream1, stream2 As NetworkStream
    Dim Listning As TcpListener

    Dim clientExec As Boolean = True
    Dim bsBinder As BindingSource
    Public smsMode As Boolean = True
    Public curLight As String
    Public mode As Integer = 0


    Public Sub New(ByRef clientOne As ClassForClient, ByRef clientTwo As ClassForClient)
        device1 = clientOne
        device2 = clientTwo
        stream1 = device1.TCPclient.GetStream
        stream2 = device2.TCPclient.GetStream
        zoneThread = New System.Threading.Thread(AddressOf start)
        ' zoneThread = New System.Threading.Thread(AddressOf zoneSyncher)
        Try

            zoneThread.Start()
            MessageBox.Show("Zone Sync has Started")

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Private Sub zoneSyncher()


    End Sub

    Private Sub start()
        Try
            While (smsMode)
                If device1.TCPclient.Connected And device2.TCPclient.Connected Then
                    ' Force the clients to enter Sync Mode and make first start at
                    '-->  device one @ red, device two @ green

                    If mode = 0 Then
                        device1.sendCodes("SSR" + redTimer.ToString)
                        device2.sendCodes("SSG" + greenTimer.ToString)
                        mode = 1
                    End If

                    If mode = 1 Then
                        If stream1.DataAvailable <> Nothing And stream2.DataAvailable <> Nothing Then
                            'reads buffer cor client 1
                            Dim statusOne As String = readBuffer(device1.TCPclient, stream1)
                            Dim statusTwo As String = readBuffer(device2.TCPclient, stream2)

                            If TypeOf statusOne Is String And TypeOf statusTwo Is String Then
                                If statusOne = "STROK___" And statusTwo = "STGOK___" Then
                                    '
                                End If

                            Else

                            End If
                            'Dim receptor(device1.TCPclient.ReceiveBufferSize) As Byte
                            'stream1.Read(receptor, 0, CInt(device1.TCPclient.ReceiveBufferSize))
                            'Dim mensagem As String = Encoding.UTF8.GetString(receptor)


                        End If
                        'waits until confirmation messages from both clients are received
                        While (Not stream1.DataAvailable) And (Not stream2.DataAvailable)
                            Threading.Thread.Sleep(100)
                        End While

                        'waits until there is data from BOTH clients in their respective 


                        ' device 1 as master --> changes in device 2 only happen after changes in device 1

                        ' device 2 as master , device 1 as slave


                    Else
                        MessageBox.Show("Sincronização de Zona não possível porque um dos clientes não está conectado!")
                    End If
                End If
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Sub stopThread()
        Try
            zoneThread.Abort()
        Catch ex As Exception

        End Try
    End Sub

    Private Function readBuffer(ByVal client As TcpClient, ByVal netStream As NetworkStream)
        Dim receptor(client.ReceiveBufferSize) As Byte
        netStream.Read(receptor, 0, CInt(client.ReceiveBufferSize))
        Dim mensagem As String = Encoding.UTF8.GetString(receptor)
        Return mensagem
    End Function

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

    Public Sub zoneClient(client As ClassForClient, ByRef binder As BindingSource)
        Try
            Dim control As Boolean = True
            'lista criada para armazenar as leituras de velocidade do cliente
            Dim speedDouble As New List(Of Double)
            Dim dataPacket As ZoneClientData
            'componente recebe a classe Stream do Cliente
            Using stream As NetworkStream = client.TCPclient.GetStream
                While True
                    If client.TCPclient.Client.Connected And stream.DataAvailable And stream.DataAvailable <> Nothing Then

                        Dim message As String = readBuffer(client.TCPclient, stream)

                        If message.StartsWith("SRX") Then
                            Try
                                Dim value As Double = message.Substring(3)

                            Catch ex As Exception

                            End Try
                        End If
                        'calcula a media de velocidade depois de receber 5 leituras
                        'If speedDouble.Count = CInt(txtLim.Text) Then
                        '    Dim avg As Double = 0
                        '    For i = 0 To speedDouble.Count - 1 Step 1
                        '        avg += speedDouble.Item(i)
                        '    Next
                        '    Dim total As Double = avg / speedDouble.Count
                        '    'MessageBox.Show("Média de " + txtLim.Text + " leituras é " + total.ToString)
                        '    dataPacket = New DataPacket(client.ID, total, Now)

                        '    'verifica se os valores recebidos estao dentro da norma
                        '    If total < CDbl(txtMin.Text) Or total > CDbl(txtMax.Text) Then
                        '        Dim ajuste = MsgBox("Velocidade Medida está fora dos padrões! Ajustar?", MsgBoxStyle.YesNo)
                        '        If ajuste = MsgBoxResult.Yes Then
                        '            If total < CDbl(txtMin.Text) Then
                        '                Dim code As String = InputBox("Inserir comando para aumentar a média:")
                        '                client.sendCodes(code)
                        '                lstLogg.Items.Add(Now.ToString + ": " + client.ID + " enviou --> " + code)
                        '            End If
                        '            If total > CDbl(txtMax.Text) Then
                        '                Dim code As String = InputBox("Inserir comando para reduzir a média:")
                        '                client.sendCodes(code)
                        '                lstLogg.Items.Add(Now.ToString + ": " + client.ID + "  enviou --> " + code)
                        '            End If
                        '        End If
                        '    End If
                        '    '
                        '    bsSpeed.Add(dataPacket)
                        '    speedDouble.Clear()
                        'Else
                        '    speedDouble.Add(extract)


                        'End If


                    ElseIf client.TCPclient.Client.Connected = False Then
                        Exit While
                    Else
                        'sleeps for 500 milliseconds to avoid overworking the processor
                        Threading.Thread.Sleep(500)
                        'goes to the next iteration as long as the client is connected
                        Continue While
                    End If

                End While

                'client gracefully closed the connection on the remote end
            End Using


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

End Class
