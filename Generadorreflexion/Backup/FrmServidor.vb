Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class FrmServidor
    Private conexion As OleDbConnection
    Private t As New conexion
    Friend servidorNoConfigurado As Boolean = False
    Friend principal As MDIParent1

    Private Sub btnCargarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarTabla.Click
        Utilitarios.servidor = Me.txtserver.Text
        Utilitarios.Basededatos = Me.cbdb.Text

        If CheckBox1.Checked Then
            guardaUltimoServidor()

        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                MsgBox("No se puede guardar con login en blanco")
            Else
                conSeña = True
                usuario = TextBox2.Text
                contraseña = TextBox1.Text

            End If
        End If

        If (conecta()) Then
            principal.abreFuncionalidades()
            servidorNoConfigurado = False
            MsgBox("Servidor registrado")
        Else
            MsgBox("Error al conectar")
        End If
    End Sub

    Private Sub guardaUltimoServidor()
        Dim path As String = Directory.GetCurrentDirectory() & "\servidor.conf"

        If File.Exists(path) Then
            File.Delete(path)
        End If

        File.AppendAllText(path, "" & Me.txtserver.Text & " " & Me.cbdb.Text)
    End Sub

    Private Sub BtnProbarConexion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProbarConexion.Click
        Try
            conexion = t.conectar(Me.cbdb.Text, Me.txtserver.Text)
            If conexion.State <> ConnectionState.Open Then

                If CheckBox1.Checked Then
                    conexion.Open()
                Else
                    conexion = t.conectar(Me.cbdb.Text, Me.txtserver.Text, TextBox2.Text, TextBox1.Text)
                    conexion.Open()
                End If

            End If
            MsgBox("Conexion Satisafactoria", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Error en la Conexion", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function conecta() As Boolean
        Try
            conexion = t.conectar(Me.cbdb.Text, Me.txtserver.Text)
            If conexion.State <> ConnectionState.Open Then

                If CheckBox1.Checked Then
                    conexion.Open()
                Else
                    conexion = t.conectar(Me.cbdb.Text, Me.txtserver.Text, TextBox2.Text, TextBox1.Text)
                    conexion.Open()
                End If

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub FrmServidor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtserver.Text = Utilitarios.servidor
        cbdb.Items.Add(Utilitarios.Basededatos)
        cbdb.SelectedIndex = 0
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        GroupBox2.Enabled = Not CheckBox1.Checked
        TextBox2.Enabled = Not CheckBox1.Checked
        TextBox1.Enabled = Not CheckBox1.Checked

    End Sub

   

   
    Private Sub FrmServidor_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (servidorNoConfigurado) Then
            Application.Exit()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If conectar_para_traer_dbs() Then
            Dim ds As New DataSet
            Dim da As New OleDb.OleDbDataAdapter
            Dim cmd As New OleDb.OleDbCommand
            Dim dt As DataTable
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_databases"
            cmd.Connection = Me.conexion
            cmd.ExecuteNonQuery()
            da.SelectCommand = cmd
            da.Fill(ds)
            dt = ds.Tables(0)
            Me.cbdb.DisplayMember = "DATABASE_NAME"
            Me.cbdb.ValueMember = "DATABASE_NAME"
            Me.cbdb.DataSource = dt
            conexion.Close()

        End If
    End Sub
    Private Function conectar_para_traer_dbs() As Boolean
        Try
            conexion.Close()
            If conexion.State <> ConnectionState.Open Then
                If CheckBox1.Checked Then
                    conexion = t.conectar(Me.txtserver.Text)
                Else
                    conexion = t.conectar(Me.txtserver.Text, TextBox2.Text, TextBox1.Text)
                End If
            End If
            Return True
        Catch
            Try
                If CheckBox1.Checked Then
                    conexion = t.conectar(Me.txtserver.Text)
                Else
                    conexion = t.conectar(Me.txtserver.Text, TextBox2.Text, TextBox1.Text)
                End If
                Return True
            Catch ex As Exception
                MsgBox("Error en la Conexion", MsgBoxStyle.Critical)
                Return False
            End Try

        End Try

    End Function
End Class