<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class movieForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.addBtn = New System.Windows.Forms.Button()
        Me.editBtn = New System.Windows.Forms.Button()
        Me.deleteBtn = New System.Windows.Forms.Button()
        Me.exitBtn = New System.Windows.Forms.Button()
        Me.cboRatings = New System.Windows.Forms.ListView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.imageBtn = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.cboLeadCharacter = New System.Windows.Forms.ComboBox()
        Me.cboGenre = New System.Windows.Forms.ComboBox()
        Me.cboDirector = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(419, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MOVIES"
        '
        'addBtn
        '
        Me.addBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.addBtn.Location = New System.Drawing.Point(304, 360)
        Me.addBtn.Name = "addBtn"
        Me.addBtn.Size = New System.Drawing.Size(145, 54)
        Me.addBtn.TabIndex = 1
        Me.addBtn.Text = "Add"
        Me.addBtn.UseVisualStyleBackColor = True
        '
        'editBtn
        '
        Me.editBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.editBtn.Location = New System.Drawing.Point(471, 360)
        Me.editBtn.Name = "editBtn"
        Me.editBtn.Size = New System.Drawing.Size(145, 54)
        Me.editBtn.TabIndex = 2
        Me.editBtn.Text = "Edit"
        Me.editBtn.UseVisualStyleBackColor = True
        '
        'deleteBtn
        '
        Me.deleteBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deleteBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.deleteBtn.Location = New System.Drawing.Point(644, 360)
        Me.deleteBtn.Name = "deleteBtn"
        Me.deleteBtn.Size = New System.Drawing.Size(145, 54)
        Me.deleteBtn.TabIndex = 3
        Me.deleteBtn.Text = "Delete"
        Me.deleteBtn.UseVisualStyleBackColor = True
        '
        'exitBtn
        '
        Me.exitBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.exitBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.exitBtn.Location = New System.Drawing.Point(822, 360)
        Me.exitBtn.Name = "exitBtn"
        Me.exitBtn.Size = New System.Drawing.Size(145, 54)
        Me.exitBtn.TabIndex = 4
        Me.exitBtn.Text = "Exit"
        Me.exitBtn.UseVisualStyleBackColor = True
        '
        'cboRatings
        '
        Me.cboRatings.BackColor = System.Drawing.SystemColors.Control
        Me.cboRatings.HideSelection = False
        Me.cboRatings.Location = New System.Drawing.Point(304, 92)
        Me.cboRatings.Name = "cboRatings"
        Me.cboRatings.Size = New System.Drawing.Size(663, 246)
        Me.cboRatings.TabIndex = 5
        Me.cboRatings.UseCompatibleStateImageBehavior = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox1.Location = New System.Drawing.Point(26, 92)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(220, 246)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'imageBtn
        '
        Me.imageBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.imageBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.imageBtn.Location = New System.Drawing.Point(26, 360)
        Me.imageBtn.Name = "imageBtn"
        Me.imageBtn.Size = New System.Drawing.Size(220, 54)
        Me.imageBtn.TabIndex = 7
        Me.imageBtn.Text = "Image"
        Me.imageBtn.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(26, 63)
        Me.txtTitle.Multiline = True
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(220, 22)
        Me.txtTitle.TabIndex = 8
        '
        'cboLeadCharacter
        '
        Me.cboLeadCharacter.FormattingEnabled = True
        Me.cboLeadCharacter.Location = New System.Drawing.Point(300, 64)
        Me.cboLeadCharacter.Name = "cboLeadCharacter"
        Me.cboLeadCharacter.Size = New System.Drawing.Size(188, 21)
        Me.cboLeadCharacter.TabIndex = 9
        '
        'cboGenre
        '
        Me.cboGenre.FormattingEnabled = True
        Me.cboGenre.Location = New System.Drawing.Point(548, 64)
        Me.cboGenre.Name = "cboGenre"
        Me.cboGenre.Size = New System.Drawing.Size(188, 21)
        Me.cboGenre.TabIndex = 10
        '
        'cboDirector
        '
        Me.cboDirector.FormattingEnabled = True
        Me.cboDirector.Location = New System.Drawing.Point(779, 65)
        Me.cboDirector.Name = "cboDirector"
        Me.cboDirector.Size = New System.Drawing.Size(188, 21)
        Me.cboDirector.TabIndex = 11
        '
        'movieForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(1019, 443)
        Me.Controls.Add(Me.cboDirector)
        Me.Controls.Add(Me.cboGenre)
        Me.Controls.Add(Me.cboLeadCharacter)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.imageBtn)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cboRatings)
        Me.Controls.Add(Me.exitBtn)
        Me.Controls.Add(Me.deleteBtn)
        Me.Controls.Add(Me.editBtn)
        Me.Controls.Add(Me.addBtn)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "movieForm"
        Me.Text = "Movie"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents addBtn As Button
    Friend WithEvents editBtn As Button
    Friend WithEvents deleteBtn As Button
    Friend WithEvents exitBtn As Button
    Friend WithEvents cboRatings As ListView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents imageBtn As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents cboLeadCharacter As ComboBox
    Friend WithEvents cboGenre As ComboBox
    Friend WithEvents cboDirector As ComboBox
End Class
