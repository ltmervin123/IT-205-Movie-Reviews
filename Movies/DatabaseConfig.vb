Imports System.Data.Common
Imports System.Net.Http.Headers
Imports MySql.Data.MySqlClient
Module DatabaseConfig
    Public con As New MySqlConnection
    Public cmd As New MySqlCommand
    Public dataSet As New DataSet
    Public dataAdapter As New MySqlDataAdapter
    Public dataReader As MySqlDataReader
    Public Sql As String
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

