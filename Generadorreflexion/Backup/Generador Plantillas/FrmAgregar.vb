Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Public Class FrmAgregar
    Dim nombreplantilla, rutap As String
    Dim rutaR As String

    

  

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim fso As Object
        Dim r As String
        If Me.CheckBox1.Checked = True Then
          
            rutap = txb_rutaplantilla.Text
            nombreplantilla = System.IO.Path.GetFileName(rutap)

            If Directory.Exists(Application.StartupPath & "\Plantilla vb\" & nombreplantilla) Then
                MsgBox("el Directorio existe")

            Else
                Directory.CreateDirectory(Application.StartupPath & "\Plantilla vb\" & nombreplantilla)
                fso = CreateObject("Scripting.FileSystemObject")
                MsgBox(Application.StartupPath + "\Plantilla vb\" & nombreplantilla)
                fso.Copyfolder(Me.txb_rutaplantilla.Text, Application.StartupPath & "\Plantilla vb\" & nombreplantilla)
                fso = Nothing
            End If
            r = Application.StartupPath & "\Plantilla vb\" & nombreplantilla & ".txt"
            File.AppendAllText(r, Application.StartupPath & "\Plantilla vb\" & nombreplantilla)
            Me.Close()
        ElseIf Me.CheckBox2.Checked = True Then
            
            rutap = txb_rutaplantilla.Text
            nombreplantilla = System.IO.Path.GetFileName(rutap)

            If Directory.Exists(Application.StartupPath & "\Plantilla cs\" & nombreplantilla) Then
                MsgBox("el Directorio existe")

            Else
                Directory.CreateDirectory(Application.StartupPath & "\Plantilla cs\" & nombreplantilla)
                fso = CreateObject("Scripting.FileSystemObject")
                MsgBox(Application.StartupPath + "\Plantilla cs\" & nombreplantilla)
                fso.Copyfolder(Me.txb_rutaplantilla.Text, Application.StartupPath & "\Plantilla cs\" & nombreplantilla)
                fso = Nothing
            End If
            r = Application.StartupPath & "\Plantilla cs\" & nombreplantilla & ".txt"
            File.AppendAllText(r, Application.StartupPath & "\Plantilla cs\" & nombreplantilla)
            Me.Close()
        End If

    End Sub
    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        txb_rutaplantilla.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged

        Me.CheckBox1.Checked = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        Me.CheckBox2.Checked = False
    End Sub
End Class