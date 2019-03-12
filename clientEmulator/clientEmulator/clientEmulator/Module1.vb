Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Module Module1
    Dim tc As TcpClient = New TcpClient()
    Dim ns As NetworkStream
    Dim br As BinaryReader
    Dim bw As BinaryWriter
    Sub Main()
        If tc.Connected Then
            Try
                If ns.DataAvailable Then
                    br = New BinaryReader(ns)
                    Console.WriteLine(br.ReadString)
                Else
                    Console.ReadLine()

                End If
            Catch ex As Exception
                MsgBox("Error reading from stream :" + ex.ToString)
            End Try
        Else
            Try
                ' tc.Connect("192.168.100.7", 11050)
                tc.Connect("127.0.0.1", 11050)
                If tc.Connected Then
                    Console.WriteLine("Connected to Server!")
                    Console.ReadLine()
                End If
            Catch ex As Exception
                MsgBox("Error Trying to connect!")
            End Try
        End If
    End Sub
    '← Connect to server →
    '← Write a value to server →
    'bw.Write(TextBox2.Text)
    '← Read a value from server with message box →
    'MsgBox(br.ReadString)
End Module
