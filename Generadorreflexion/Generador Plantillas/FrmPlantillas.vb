Public Class FrmPlantillas

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        txbRuta.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub btnGenerarClase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarClase.Click
        Dim inf As String
        Dim fso1 As Object
        fso1 = CreateObject("Scripting.fileSystemObject")
        inf = Me.TextBox2.Text
        MsgBox(inf)
        fso1.CopyFolder(inf, Me.txbRuta.Text & "\")
        fso1 = Nothing
     



    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim inf2 As String
        Dim fso2 As Object
        fso2 = CreateObject("Scripting.FileSystemObject")
        inf2 = Me.TextBox3.Text
        MsgBox(inf2)
        fso2.CopyFolder(inf2, Me.TextBox1.Text & "\")
        fso2 = Nothing
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
     
        FolderBrowserDialog2.ShowDialog()
        Me.TextBox1.Text = FolderBrowserDialog2.SelectedPath

    End Sub

    Private Sub DockControl2_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DockControl2.Closing

    End Sub

    Private Sub DockControl1_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DockControl1.Closing

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim frmagregar As New FrmAgregar
        frmagregar.Show()


    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RDB1Vb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDB1Vb1.CheckedChanged

    End Sub

    Private Sub DocumentContainer1_ActiveDocumentChanged(ByVal sender As System.Object, ByVal e As TD.SandDock.ActiveDocumentEventArgs) Handles DocumentContainer1.ActiveDocumentChanged

    End Sub
    Sub showfilesinfolder()
        Dim file As String
        Dim fi As IO.FileInfo
        Me.cmbDisponibles.Items.Clear()
        For Each file In IO.Directory.GetFiles(IO.Directory.GetCurrentDirectory + "\Plantilla vb")
            fi = New IO.FileInfo(file)
            If fi.Extension = ".txt" Then
                Me.cmbDisponibles.Items.Add(fi.Name)
            End If
        Next

    End Sub

    Private Sub FrmPlantillas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        showfilesinfolder()



    End Sub

    Private Sub cmbDisponibles_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDisponibles.SelectionChangeCommitted


    End Sub

    Private Sub cmbDisponibles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDisponibles.SelectedIndexChanged
        Dim rutacom As String
        Dim c, f As String
        Dim r, s As String

        c = Me.cmbDisponibles.Text
        r = IO.Directory.GetCurrentDirectory() & "\Plantilla vb\" & c
        Dim lector As IO.StreamReader = IO.File.OpenText(r)
        rutacom = lector.ReadLine
        s = System.IO.Path.GetFileName(rutacom)
        Me.TextBox2.Text = rutacom
        f = Me.TextBox2.Text
        Dim img As Image

        
        img = Image.FromFile(f & "\" & s & ".bmp")
        PictureBox1.Image = img


    End Sub

    Private Sub cmbDisponibles_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmbDisponibles.MouseClick

        showfilesinfolder()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Dim frm As New FrmAgregar
        frm.Show()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim rutacom As String
        Dim c, f As String
        Dim r, s As String

        c = Me.ComboBox1.Text
        r = IO.Directory.GetCurrentDirectory() & "\Plantilla cs\" & c
        Dim lector As IO.StreamReader = IO.File.OpenText(r)
        rutacom = lector.ReadLine
        s = System.IO.Path.GetFileName(rutacom)
        Me.TextBox3.Text = rutacom
        f = Me.TextBox3.Text
        Dim img As Image

        If f & "\" & s & ".bmp " <> s Then
            MsgBox("El Archivo de imagen es incorrecto")
        Else
            img = Image.FromFile(f & "\" & s & ".bmp")
            PictureBox2.Image = img
        End If
    End Sub
End Class