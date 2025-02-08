Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class MDIParent1

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer = 0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objfrmgeneradorClase As New formGeneradorClasesSQL
        objfrmgeneradorClase.MdiParent = Me
        
        objfrmgeneradorClase.Show()
        

    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)
        Select Case e.Node.Text
            Case "Simple de transaccion "
                Dim objform1 As New Form1
                objform1.MdiParent = Me
                objform1.Show()

        End Select
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objfrmdervidor As New FrmServidor
        objfrmdervidor.ShowDialog()

    End Sub

    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargaservidor()
        evaluaConxion()
    End Sub

    Private Sub evaluaConxion()

        If ((Not conecta()) Or (Not File.Exists(Directory.GetCurrentDirectory() + "\\servidor.conf"))) Then
            cerraFuncionalidades()
            Dim objFrmSer As New FrmServidor()
            objFrmSer.MdiParent = Me
            objFrmSer.principal = Me
            objFrmSer.StartPosition = FormStartPosition.Manual
            objFrmSer.Location = New Point(270, 3)
            objFrmSer.servidorNoConfigurado = True
            objFrmSer.Show()

        End If
    End Sub

    Private Sub cerraFuncionalidades()
        Ribbon1.Enabled = False

        
        MsgBox("Configure los datos de su servidor")
    End Sub

    Friend Sub abreFuncionalidades()
        Ribbon1.Enabled = True
    End Sub

    Private Function conecta() As Boolean
        Dim conexion As OleDbConnection
        Dim t As New conexion

        Try
            conexion = t.conectar(Basededatos, servidor)
            If conexion.State <> ConnectionState.Open Then

                conexion.Open()

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub cargaservidor()


        If (File.Exists(Directory.GetCurrentDirectory() & "\servidor.conf")) Then

            Dim referencias() As String

            referencias = separaEnPalabras( _
               (File.ReadAllText(Directory.GetCurrentDirectory() & "\servidor.conf")))

            Utilitarios.servidor = referencias(0) ' server
            Utilitarios.Basededatos = referencias(1) ' db

        End If
    End Sub

    Private Function separaEnPalabras(ByVal cadena As String) As String()
        Dim palabras(contaPalabras(cadena) - 1) As String

        Dim c As Integer = 0
        For ite As Byte = 0 To palabras.Length
            palabras(ite) = ""

            While (Not (cadena(c).IsWhiteSpace(cadena(c))))
                palabras(ite) += cadena(c)
                c += 1

                If (c >= cadena.Length) Then Exit For
            End While

            c += 1

        Next

        Return palabras
    End Function

    Private Function contaPalabras(ByVal cadena As String)
        Dim c As Integer = 0
        Dim enPalabra As Boolean = False

        For ite As Integer = 0 To cadena.Length - 1
            If ((Not enPalabra) And ("" & cadena(ite)) <> " ") Then
                c += 1
                enPalabra = True
            Else
                If ("" & cadena(ite)) = " " Then
                    enPalabra = False
                End If
            End If
        Next
        Return c
    End Function

    Private Sub MenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub NavigationBar2_SelectedPaneChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TreeView2_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)

    End Sub

    Private Sub TreeView9_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView9.AfterSelect
        Select Case e.Node.Text
            Case "Definir Servidor"
                Dim objfrmservicdor As New FrmServidor
                objfrmservicdor.MdiParent = Me
                objfrmservicdor.principal = Me
                objfrmservicdor.StartPosition = FormStartPosition.Manual
                objfrmservicdor.Location = New Point(270, 3)
                objfrmservicdor.Show()
            Case "Definir Plantilla Inicial"
                Dim objfrmplantillaInicial As New FrmPlantillas
                objfrmplantillaInicial.MdiParent = Me
                objfrmplantillaInicial.StartPosition = FormStartPosition.Manual
                objfrmplantillaInicial.Location = New Point(270, 3)
                objfrmplantillaInicial.Show()

            Case "Definir tablas de auditoria"
                Dim objfrmAuditoria As New FrmAuditoria
                objfrmAuditoria.MdiParent = Me
                objfrmAuditoria.StartPosition = FormStartPosition.Manual
                objfrmAuditoria.Location = New Point(270, 3)
                objfrmAuditoria.Show()
            Case "Salir"
                Global.System.Windows.Forms.Application.Exit()
        End Select
    End Sub

    Private Sub TreeView8_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView8.AfterSelect
        Select Case e.Node.Text
            Case "Generar Procedimientos almacenados"
                Dim objfrmsp As New FrmSP
                objfrmsp.MdiParent = Me
                objfrmsp.StartPosition = FormStartPosition.Manual
                objfrmsp.Location = New Point(270, 3)
                objfrmsp.Show()
            Case "Salir"
                Global.System.Windows.Forms.Application.Exit()

        End Select
    End Sub

    Private Sub TreeView5_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView5.AfterSelect
        Select Case e.Node.Text
            Case "Generar Clases de software"
                Dim objfrmgeneradorclase As New formGeneradorClasesSQL
                objfrmgeneradorclase.MdiParent = Me
                objfrmgeneradorclase.StartPosition = FormStartPosition.Manual
                objfrmgeneradorclase.Location = New Point(270, 3)
                objfrmgeneradorclase.Show()
            Case "Salir"
                Global.System.Windows.Forms.Application.Exit()
        End Select
    End Sub

    Private Sub TreeView7_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView7.AfterSelect



        Select Case e.Node.Text
            Case "Simple de transaccion"
                Dim objfrmform1 As New Form1
                objfrmform1.MdiParent = Me
                objfrmform1.StartPosition = FormStartPosition.Manual
                objfrmform1.Location = New Point(270, 3)
                objfrmform1.Show()
            Case "Especializacion\Generalizacion"
                Dim objfrmform1 As New FormularioSuperClase
                objfrmform1.MdiParent = Me
                objfrmform1.StartPosition = FormStartPosition.Manual
                objfrmform1.Location = New Point(270, 3)
                objfrmform1.Show()

            Case "Salir"
                Global.System.Windows.Forms.Application.Exit()

        End Select
    End Sub

    Private Sub NavigationPane3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub NavigationPane4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub ExplorerBar1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ExplorerBar1.MouseClick

        'If me.ExplorerBar1.Groups.Item(0).Key = "Group1" Then
        'If e.Clicks = 1 Then
        '    ExplorerBar1.Groups.Item(0).Enabled = True
        '    ExplorerBar1.Groups.Item(0).Expanded = True
        '    ExplorerBar1.Groups.Item(1).Expanded = False
        '    ExplorerBar1.Groups.Item(2).Expanded = False
        '    ExplorerBar1.Groups.Item(3).Expanded = False
        '    ExplorerBar1.Groups.Item(1).Enabled = False
        '    ExplorerBar1.Groups.Item(2).Enabled = False
        '    ExplorerBar1.Groups.Item(3).Enabled = False
        'End If
        'If Me.ExplorerBar1.Groups.Item(1).Key = "Group2" Then
        '    ExplorerBar1.Groups.Item(1).Enabled = True
        '    ExplorerBar1.Groups.Item(0).Enabled = False
        '    ExplorerBar1.Groups.Item(0).Expanded = False
        '    ExplorerBar1.Groups.Item(2).Expanded = False
        '    ExplorerBar1.Groups.Item(3).Expanded = False
        '    ExplorerBar1.Groups.Item(2).Enabled = False
        '    ExplorerBar1.Groups.Item(3).Enabled = False
        '    ExplorerBar1.Groups.Item(1).Expanded = True
        'End If
        'If Me.ExplorerBar1.Groups.Item(2).Key = "Group3" Then
        '    ExplorerBar1.Groups.Item(2).Enabled = True
        '    ExplorerBar1.Groups.Item(0).Enabled = False
        '    ExplorerBar1.Groups.Item(0).Expanded = False
        '    ExplorerBar1.Groups.Item(1).Expanded = False
        '    ExplorerBar1.Groups.Item(3).Expanded = False
        '    ExplorerBar1.Groups.Item(1).Enabled = False
        '    ExplorerBar1.Groups.Item(3).Enabled = False
        '    ExplorerBar1.Groups.Item(2).Expanded = True
        'End If
        'If Me.ExplorerBar1.Groups.Item(3).Key = "Group4" Then
        '    ExplorerBar1.Groups.Item(3).Enabled = True
        '    ExplorerBar1.Groups.Item(0).Enabled = False
        '    ExplorerBar1.Groups.Item(0).Expanded = False
        '    ExplorerBar1.Groups.Item(1).Expanded = False
        '    ExplorerBar1.Groups.Item(2).Expanded = False
        '    ExplorerBar1.Groups.Item(1).Enabled = False
        '    ExplorerBar1.Groups.Item(2).Enabled = False
        '    ExplorerBar1.Groups.Item(3).Expanded = True
        'End If
    End Sub

    Private Sub TreeView7_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView7.MouseClick

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub ButtonCommand1_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles ButtonCommand1.Click

        'Configuracion del proyecto

        Me.ExplorerBar1.Visible = True
        'Me.ExplorerBarContainerControl4.Group.Enabled = True
        'Me.ExplorerBarContainerControl1.Group.Enabled = False
        'Me.ExplorerBarContainerControl2.Group.Enabled = False
        'Me.ExplorerBarContainerControl3.Group.Enabled = False

        ExplorerBar1.Groups.Item(0).Expanded = False
        ExplorerBar1.Groups.Item(1).Expanded = False
        ExplorerBar1.Groups.Item(2).Expanded = False
        ExplorerBar1.Groups.Item(3).Expanded = True
    End Sub

    Private Sub ButtonCommand3_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles ButtonCommand3.Click

        'Clases de Software 

        Me.ExplorerBar1.Visible = True
        'Me.ExplorerBarContainerControl1.Group.Enabled = True
        'Me.ExplorerBarContainerControl4.Group.Enabled = False
        'Me.ExplorerBarContainerControl2.Group.Enabled = False
        'Me.ExplorerBarContainerControl3.Group.Enabled = False


        ExplorerBar1.Groups.Item(0).Expanded = True
        ExplorerBar1.Groups.Item(1).Expanded = False
        ExplorerBar1.Groups.Item(2).Expanded = False
        ExplorerBar1.Groups.Item(3).Expanded = False
    End Sub

    Private Sub ButtonCommand2_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles ButtonCommand2.Click

        'Base de Datos

        Me.ExplorerBar1.Visible = True
        'Me.ExplorerBarContainerControl3.Group.Enabled = True
        'Me.ExplorerBarContainerControl1.Group.Enabled = False
        'Me.ExplorerBarContainerControl2.Group.Enabled = False
        'Me.ExplorerBarContainerControl4.Group.Enabled = False


        ExplorerBar1.Groups.Item(0).Expanded = False
        ExplorerBar1.Groups.Item(1).Expanded = False
        ExplorerBar1.Groups.Item(2).Expanded = True
        ExplorerBar1.Groups.Item(3).Expanded = False
    End Sub

    Private Sub ButtonCommand4_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles ButtonCommand4.Click

        'Generar Formularios

        Me.ExplorerBar1.Visible = True
        'Me.ExplorerBarContainerControl1.Group.Enabled = False
        'Me.ExplorerBarContainerControl4.Group.Enabled = False
        'Me.ExplorerBarContainerControl2.Group.Enabled = True
        'Me.ExplorerBarContainerControl3.Group.Enabled = False


        ExplorerBar1.Groups.Item(0).Expanded = False
        ExplorerBar1.Groups.Item(1).Expanded = True
        ExplorerBar1.Groups.Item(2).Expanded = False
        ExplorerBar1.Groups.Item(3).Expanded = False
    End Sub


    Private Sub DropDownCommand6_Click(ByVal sender As System.Object, ByVal e As Janus.Windows.Ribbon.CommandEventArgs) Handles DropDownCommand6.Click
        Global.System.Windows.Forms.Application.Exit()
    End Sub


    Private Sub ExplorerBar1_GroupClick(ByVal sender As System.Object, ByVal e As Janus.Windows.ExplorerBar.GroupEventArgs) Handles ExplorerBar1.GroupClick
        confGrupos((e.Group.Index))

    End Sub

    Private Sub confGrupos(ByVal n As Integer)
        For ite As Integer = 0 To 3
            If ite = n Then
                ' ExplorerBar1.Groups.Item(ite).Expanded = True
            Else
                ExplorerBar1.Groups.Item(ite).Expanded = False
            End If
        Next
    End Sub
End Class
