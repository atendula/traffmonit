Imports System.Net.Sockets
Imports System.IO
Imports System.Net
Imports System.Text

'classe dedicada para Clientes
Public Class ClassForClient

    Public message As String

    Public TCPclient As TcpClient
    Public Thread As System.Threading.Thread
    Public Property Description As String
    Public Property ID As String
    Public Property Zone As String
    Public Stream As NetworkStream
    Sub New(cliente As TcpClient, name As String, clientZone As String)
        TCPclient = cliente
        ID = TCPclient.Client.RemoteEndPoint.ToString
        Stream = TCPclient.GetStream
        Description = name
        Zone = clientZone
    End Sub

    Sub sendCodes(message As String)
        Try
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(message)
            If Stream.CanWrite Then
                Stream.Write(bytes, 0, bytes.Length)
                Stream.Flush()
            End If
        Catch ex As Exception
            MessageBox.Show("Error Sending")
        End Try
    End Sub


End Class
