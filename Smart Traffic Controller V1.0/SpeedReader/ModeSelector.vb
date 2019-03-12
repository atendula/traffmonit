Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class ModeSelector
    Dim connector As SqlConnection = New SqlConnection(My.Settings.connectionString)
    Public command As SqlCommand
    Public dataSet As DataSet
    Public dataAdapter As SqlDataAdapter
    Private results As String



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        SerialReader.Show()
    End Sub

    Private Sub ModeSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SysMonitor.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        GUIServer.Show()
    End Sub

    Private Sub ModeSelector_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub startDB()
        Try
            connector.Open()
            MessageBox.Show("Database opened sucessfully!")
        Catch ex As Exception
            MessageBox.Show("Erro: " + ex.Message)
        End Try

    End Sub

    Private Sub closeDB()
        Try
            connector.Close()
        Catch ex As Exception
            MessageBox.Show("Erro: " + ex.Message)
        End Try
    End Sub


End Class