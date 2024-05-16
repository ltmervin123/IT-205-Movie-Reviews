Imports MySal.Data.MySalclient
Public Class movieForm
    Dim mintRecCount, mintResult, mintMovieID As Integer
    Dim mstrratings, mstrCaption, mstrTitle, mstrLeadCharacter, mstrDirector, mstrCategory As String


    Dim arrImage As Byte
    Dim mstream As New System.IO.MemoryStream
    Private Sub imageBtn_Click(sender As Object, e As EventArgs) Handles imageBtn.Click
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
                        PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
                    Catch fileException As Exception
                        Throw fileException
                    End Try
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub showListView()
        Dim query As String = "SELECT * FROM movies"
        Try
            cmd.Connection = con
            cmd.CommandText = query
            adapter.SelectCommand = cmd
            adapter.Fill(dataset, "movieTable")
            Me.cboRatings.Items.Clear()

            If dataset.Tables("movieTable").Rows.Count > 0 Then

            End If


        Catch ex As Exception

        End Try
    End Sub

    'Private Sub btnAddSave_Click(sender As Object, e As EventArgs) Handles btnAddSave.Click
    'If btnAddSave.Text = "&Add" Then
    'btnAddSave.Text = "&Save"
    'but'tons(True, False, False, True, False, True)
    'Disable(True, True, True, True, True, True)
    'Call Clear()
    'AcceptButton = btnAddSave
    'CancelButton = btnCancel
    'tx'tTitle.Focus()
    ' Else
    'mstrTitle = txtTitle.Text
    'mstrLeadCharacter = cboLeadCharacter.Text
    ''mstrDirector = cboDirector.Text
    'mstrCategory = cboGenre.Text
    'strratings = cboRatings.Text
    'mintRecCount = mintRecCount + 1
    'If' txtTitle.Text = "" Or cboLeadCharacter.Text = "" Or cboDirector.Text = "" Or cboGenre.Text = "" Or cboRatings.Text = "" Then
    'sgBox("Please fill up all the fields.")
    'Exit Sub
    ' End If
    '   mstrCaption = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
    ' End If
    'End Sub

End Class
