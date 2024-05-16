Imports System.Data.Common
Imports MySql.Data.MySqlClient
Module DatabaseConfig
    Public con As New MySqlConnection
    Public cmd As New MySqlCommand
    Public dataset As New DataSet
    Public adapter As New MySqlDataAdapter

    Public Sub openConnection()
        Dim connectionURL As String = "server=localhost;port=3306;user=root;password=;database=listofmovies"
        Try
            con.ConnectionString = connectionURL
            con.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Module

