Imports System.IO
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySal.Data.MySalclient
Imports MySql.Data.MySqlClient
Public Class movieForm
    Dim mintRecCount, mintResult, mintMovieID As Integer
    Dim mstrratings, mstrCaption, mstrTitle, mstrLeadCharacter, mstrDirector, mstrCategory As String
    Dim arrImage() As Byte
    Dim mstream As New System.IO.MemoryStream
    Private Sub movieForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call showListView()
        buttons(True, False, False, False, True, False)
        Disable(False, False, False, False, False, False)
    End Sub


    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        Call buttons(False, True, True, True, False, False)
        mintMovieID = ListView1.SelectedItems(0).SubItems(0).Text
        txtTitle.Text = ListView1.SelectedItems(0).SubItems(1).Text
        cboLeadCharacter.Text = ListView1.SelectedItems(0).SubItems(2).Text
        cboDirector.Text = ListView1.SelectedItems(0).SubItems(3).Text
        cboGenre.Text = ListView1.SelectedItems(0).SubItems(4).Text
        cboRatings.Text = ListView1.SelectedItems(0).SubItems(5).Text
        Sql = "SELECT imageFile FROM movies WHERE movieID= " & mintMovieID & ""
        Try
            openConnection()
            cmd = New MySqlCommand(Sql, con)
            dataReader = cmd.ExecuteReader()
            cmd.CommandType = CommandType.Text
            While dataReader.Read
                arrImage = dataReader.Item("ImageFile")
                Dim mstream As New System.IO.MemoryStream(arrImage)
                picImage.Image = System.Drawing.Image.FromStream(mstream)
            End While
            dataReader.Close()
        Catch ex As Exception
            MsgBox("Error in Displaying the data. Error is : " + ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        openConnection()
        If MsgBox("Do you want to Delete this Data?", vbYesNo, "Confirm") = vbYes Then
            Sql = "Delete from movies where movieID = '" & mintMovieID & "'"
            MsgBox("data deleted", vbOKOnly)
            'Call TryCatch()
            Try
                cmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, con)
                dataReader = cmd.ExecuteReader()
                dataReader.Close()
                ' Call openConnection()
            Catch ex As Exception
                MsgBox("Error in saving/updating to table movies. Error is " + ex.Message)
                dataReader.Close()
            Finally
                con.Close()
            End Try
        Else
            MsgBox("Deleting has been cancelled", vbOKOnly)
            Me.Visible = True
        End If
        Call buttons(True, False, False, False, True, False)
        Call showlistview()
        Call Clear()
        AcceptButton = btnAddSave
        CancelButton = btnExit
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If btnAddSave.Text = "&Save" Or btnEditUpdate.Text = "&Update" Then
            btnAddSave.Text = "Add"
            btnEditUpdate.Text = "Edit"
        End If

        Call Clear()
        Disable(False, False, False, False, False, False)
        buttons(True, False, False, False, True, False)
    End Sub

    Private Sub imageBtn_Click(sender As Object, e As EventArgs) Handles btnSelectImage.Click
        Try
            With OpenFileDialog1
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = "jpg"
                .DereferenceLinks = True
                .FileName = ""
                .Filter = "(*.jpg)|*.jpg|(*.png)|*.png|(*.jpg)|*.jpg|All files|*.*"
                .Multiselect = False
                .RestoreDirectory = True
                .Title = "Select a file to open"
                .ValidateNames = True
                If .ShowDialog = DialogResult.OK Then
                    Try
                        picImage.Image = Image.FromFile(OpenFileDialog1.FileName)
                    Catch fileException As Exception
                        Throw fileException
                    End Try
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub btnAddSave_Click(sender As Object, e As EventArgs) Handles btnAddSave.Click
        If btnAddSave.Text = "Add" Then
            btnAddSave.Text = "&Save"
            buttons(True, False, False, True, False, True)
            Disable(True, True, True, True, True, True)
            Call Clear()
            AcceptButton = btnAddSave
            CancelButton = btnCancel
            txtTitle.Focus()
        Else
            mstrTitle = txtTitle.Text
            mstrLeadCharacter = cboLeadCharacter.Text
            mstrDirector = cboDirector.Text
            mstrCategory = cboGenre.Text
            mstrratings = cboRatings.Text
            mintRecCount = mintRecCount + 1

            If txtTitle.Text = "" Or cboLeadCharacter.Text = "" Or cboDirector.Text = "" Or cboGenre.Text = "" Or cboRatings.Text = "" Then
                MsgBox("Please fill up all the fields.")
                Exit Sub
            End If

            mstrCaption = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
            picImage.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrImage = mstream.GetBuffer()

            Dim FileSize As UInt64
            FileSize = mstream.Length
            mstream.Close()

            openConnection()
            Try
                Sql = "INSERT INTO movies (title, leadcharacter, director, category, rating, imageFile)VALUES (@mstrTitle, @mstrLeadCharacter, @mstrDirector, @mstrCategory, @mstrRatings, @imageFile)"
                cmd = New MySqlCommand
                With cmd
                    .Connection = con
                    .CommandText = Sql
                    '.Parameters.AddWithValue("@mintRecCount", mintRecCount)
                    .Parameters.AddWithValue("@mstrTitle", mstrTitle)
                    .Parameters.AddWithValue("@mstrLeadCharacter", mstrLeadCharacter)
                    .Parameters.AddWithValue("@mstrDirector", mstrDirector)
                    .Parameters.AddWithValue("@mstrCategory", mstrCategory)
                    .Parameters.AddWithValue("@mstrRatings", mstrratings)
                    .Parameters.AddWithValue("@imageFile", arrImage)
                    mintResult = .ExecuteNonQuery()
                End With

                MsgBox("Successfully saved.")
                If MsgBox("Do you want to add another?", vbYesNo, "Confirm") = vbYes Then
                    Call showlistview()
                    Call Clear()
                    Call buttons(True, False, False, True, False, True)
                    Me.AcceptButton = btnAddSave
                    Me.CancelButton = btnCancel()
                    Me.CancelButton = btnCancel
                    txtTitle.Focus()
                Else
                    Call Clear()
                    Call buttons(True, False, False, False, True, False)
                    Me.AcceptButton = btnAddSave
                    Me.CancelButton = btnExit
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
                btnAddSave.Text = "&Add"
                Call showlistview()
            End Try

        End If
    End Sub

    Private Sub cboLeadCharacter_Dropdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLeadCharacter.DropDown
        Call openConnection()
        Sql = "Select * from movies"
        Try
            cmd = New MySqlCommand(Sql, con)
            dataReader = cmd.ExecuteReader()
            cmd.CommandType = CommandType.Text
            While dataReader.Read
                If dataReader(0) IsNot Nothing Then
                    If Not cboLeadCharacter.Items.Contains(dataReader(2).ToString()) Then
                        cboLeadCharacter.Items.Add(dataReader(2).ToString())
                    End If
                End If
            End While
            dataReader.Close()
        Catch ex As Exception
            MsgBox("Error in Displaying LeadCharacter in dropdown. Error is: " &
            ex.Message)
            dataReader.Close()
            Exit Sub
        End Try
        con.Close()
    End Sub

    Private Sub cboLeadDirector_Dropdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDirector.DropDown
        Call openConnection()
        Sql = "Select * from movies"
        Try
            cmd = New MySqlCommand(Sql, con)
            dataReader = cmd.ExecuteReader()
            cmd.CommandType = CommandType.Text
            While dataReader.Read
                If dataReader(0) IsNot Nothing Then
                    If Not cboDirector.Items.Contains(dataReader(3).ToString()) Then
                        cboDirector.Items.Add(dataReader(3).ToString())
                    End If
                End If
            End While
            dataReader.Close()
        Catch ex As Exception
            MsgBox("Error in Displaying LeadCharacter in dropdown. Error is " + ex.Message)
            dataReader.Close()
            Exit Sub
        End Try
        con.Close()
    End Sub

    Private Sub cboGenre_Dropdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGenre.DropDown
        Call openConnection()
        Sql = "Select * from movies"
        Try
            cmd = New MySqlCommand(Sql, con)
            dataReader = cmd.ExecuteReader()
            cmd.CommandType = CommandType.Text
            While dataReader.Read
                If dataReader(0) IsNot Nothing Then
                    If Not cboGenre.Items.Contains(dataReader(4).ToString()) Then
                        cboGenre.Items.Add(dataReader(4).ToString())
                    End If
                End If
            End While
            dataReader.Close()
        Catch ex As Exception
            MsgBox("Error in Displaying LeadCharacter in dropdown. Error is: " +
            ex.Message)
            dataReader.Close()
            Exit Sub
        End Try
        con.Close()
    End Sub

    Private Sub cboRating_Dropdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRatings.DropDown
        Call openConnection()
        Sql = "Select * from movies"
        Try
            cmd = New MySqlCommand(Sql, con)
            dataReader = cmd.ExecuteReader()
            cmd.CommandType = CommandType.Text
            While dataReader.Read
                If dataReader(0) IsNot Nothing Then
                    If Not cboRatings.Items.Contains(dataReader(5).ToString()) Then
                        cboRatings.Items.Add(dataReader(5).ToString())
                    End If
                End If
            End While
            dataReader.Close()
        Catch ex As Exception
            MsgBox("Error in Displaying LeadCharacter in dropdown. Error is: " +
            ex.Message)
            dataReader.Close()
            Exit Sub
        End Try
        con.Close()
    End Sub



    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnEditUpdate_Click(sender As Object, e As EventArgs) Handles btnEditUpdate.Click

        If btnEditUpdate.Text = "&Edit" Then
            btnEditUpdate.Text = "&Update"
            Disable(True, True, True, True, True, True)
            buttons(False, True, False, True, False, True)
        Else
            updateImplementation()
        End If
    End Sub



    Private Sub showlistview()
        Try
            openConnection()
            dataSet = New DataSet
            dataAdapter = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from movies", con)
            dataAdapter.Fill(dataSet, "tblMovie")
            Me.ListView1.Items.Clear()

            If dataSet.Tables("tblMovie").Rows.Count > 0 Then
                For i As Integer = 0 To dataSet.Tables("tblMovie").Rows.Count - 1
                    With ListView1.Items.Add(dataSet.Tables("tblMovie").Rows(i).Item(0).ToString)
                        .SubItems.Add(dataSet.Tables("tblMovie").Rows(i).Item(1).ToString)
                        .SubItems.Add(dataSet.Tables("tblMovie").Rows(i).Item(2).ToString)
                        .SubItems.Add(dataSet.Tables("tblMovie").Rows(i).Item(3).ToString)
                        .SubItems.Add(dataSet.Tables("tblMovie").Rows(i).Item(4).ToString)
                        .SubItems.Add(dataSet.Tables("tblMovie").Rows(i).Item(5).ToString)
                    End With
                    mintRecCount = dataSet.Tables("tblMovie").Rows.Count
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub TryCatch()
        Try
            cmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, con)
            dataReader = cmd.ExecuteReader()
            dataReader.Close()
            Call openConnection()
        Catch ex As Exception
            MsgBox("Error in saving/updating to table movies. Error is " + ex.Message)
            dataReader.Close()
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub buttons(ByVal mAddSave As Boolean, ByVal mEditUpdate As Boolean, ByVal mDelete As Boolean, ByVal mCancel As Boolean, ByVal mExit As Boolean, ByVal mImage As Boolean)
        btnAddSave.Enabled = mAddSave
        btnEditUpdate.Enabled = mEditUpdate
        btnDelete.Enabled = mDelete
        btnCancel.Enabled = mCancel
        btnExit.Enabled = mExit
        btnSelectImage.Enabled = mImage
    End Sub

    Private Sub Clear()
        txtTitle.Text = ""
        cboLeadCharacter.Text = ""
        cboDirector.Text = ""
        cboGenre.Text = ""
        cboRatings.Text = ""
        clearPictureImage()
    End Sub

    Private Sub Disable(ByVal mTitle As Boolean, ByVal mLeadCharacter As Boolean, ByVal mDirector As Boolean, ByVal mCategory As Boolean, ByVal mRatings As Boolean, ByVal mImage As Boolean)
        txtTitle.Enabled = mTitle
        cboLeadCharacter.Enabled = mLeadCharacter
        cboDirector.Enabled = mDirector
        cboGenre.Enabled = mCategory
        cboRatings.Enabled = mRatings
        btnSelectImage.Enabled = mImage
    End Sub


    Private Sub updateImplementation()
        Try
            'Open a Data base connection
            openConnection()

            ' Reinitialize the MemoryStream to ensure it starts from the beginning
            mstream = New MemoryStream()
            picImage.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrImage = mstream.ToArray()
            mstream.Close()
            'Update SQL query
            Dim query As String = "UPDATE movies SET title = @title, leadCharacter = @leadCharacter, director = @director, category = @category, rating = @rating, imageFile = @imageFile WHERE movieID = @movieID"

            'Prepare the SQL command
            cmd.Connection = con
            cmd.CommandText = query
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@title", txtTitle.Text)
            cmd.Parameters.AddWithValue("@leadCharacter", cboLeadCharacter.Text)
            cmd.Parameters.AddWithValue("@director", cboDirector.Text)
            cmd.Parameters.AddWithValue("@category", cboGenre.Text)
            cmd.Parameters.AddWithValue("@rating", cboRatings.Text)
            cmd.Parameters.AddWithValue("@imageFile", arrImage)
            cmd.Parameters.AddWithValue("@movieID", mintMovieID)

            'Execute the command
            cmd.ExecuteNonQuery()
            MessageBox.Show("Record Updated Successfull!")

        Catch ex As Exception
            'Handle any exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'Close all the connection and Reset all the component to its original state
            btnEditUpdate.Text = "&Edit"
            Call Clear()
            con.Close()
            showlistview()
            Disable(False, False, False, False, False, False)
            buttons(True, False, False, False, True, False)
        End Try
    End Sub

    'Clear Image
    Private Sub clearPictureImage()
        If picImage.Image IsNot Nothing Then
            picImage.Image = Nothing
        End If
    End Sub


End Class
