Imports System.Data.SqlClient
Imports System.Data.OleDb



Public Class FrmSP
    Private da As OleDbDataAdapter
    Private ds As DataSet
    Private conexion As OleDbConnection
    Private t As New conexion
    Dim nrofilas As Integer

    ' Defino la estructura del array de campos
    Structure regCampo
        Dim nombre As String
        Dim tipo As String
    End Structure

    ' Defino el array donde se guardarán los datos de la tabla
    Dim arrEstructura() As regCampo
    Function nombrestablas() As String()
        Dim nomtablas() As String
        Dim datatable As DataTable
        Dim dbnull As System.DBNull
        Dim restrictions() As Object = {dbnull, dbnull, dbnull, "TABLE"}
        Dim i As Integer

        If Not conSeña Then
            conexion = t.conectar(Me.txtdb.Text, Me.txtserver.Text)
        Else
            conexion = t.conectar(Me.txtdb.Text, Me.txtserver.Text, usuario, contraseña)
        End If

        Try
            If conexion.State <> ConnectionState.Open Then

                conexion.Open()
            End If
        Catch ex As Exception
            MsgBox("Error al conectarse al servidor")
        End Try


        datatable = conexion.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions)
        i = datatable.Rows.Count - 1
        If i > -1 Then
            ReDim nomtablas(i)
            For i = 0 To datatable.Rows.Count - 1
                nomtablas(i) = datatable.Rows(i).Item("TABLE_NAME").ToString()
            Next
        End If
        Return nomtablas
    End Function
    Private Sub cargartablas()
        Dim nomtablas() As String
        Dim i As Integer
        nomtablas = Me.nombrestablas()
        If Not nomtablas Is Nothing Then
            For i = 0 To nomtablas.Length - 1
                If nomtablas(i) <> "sysdiagrams" Then
                    Me.dgvTablas.Rows.Add()
                    Me.dgvTablas.Rows(nrofilas).Cells("NombreTabla").Value = nomtablas(i)
                    nrofilas = nrofilas + 1
                End If
            Next
            'If Me.ComboBox1.Items.Count > 0 Then
            '    Me.ComboBox1.SelectedIndex = 0
            'End If
        End If

    End Sub
    Public Sub cartgartablasgrilla()
        Me.dgvTablas.Rows.Clear()
        Me.nrofilas = 0
        cargartablas()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
    End Sub
    Private Sub FrmSP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCadena.SelectAll()
        If Utilitarios.servidor = String.Empty Then
            MsgBox("Configure los datos del servidor...", MsgBoxStyle.Information)
        Else
            Me.txtdb.Text = Utilitarios.Basededatos
            Me.txtserver.Text = Utilitarios.servidor
            cartgartablasgrilla()
        End If
    End Sub

    Private Sub btnCargarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarTabla.Click
        Utilitarios.servidor = Me.txtserver.Text
        Utilitarios.Basededatos = Me.txtdb.Text
        cartgartablasgrilla()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim i As Integer
        For i = 0 To Me.dgvTablas.Rows.Count - 1
            If CheckBox1.Checked = True Then
                Me.dgvTablas.Rows(i).Cells("Generar").Value = True
             
            Else
                Me.dgvTablas.Rows(i).Cells("Generar").Value = False

            End If
        Next
    End Sub


    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Dim i As Integer
        For i = 0 To Me.dgvTablas.Rows.Count - 1
            If (CheckBox2.Checked = True) And (Me.dgvTablas.Rows(i).Cells("Generar").Value = True) Then
                Me.dgvTablas.Rows(i).Cells("NombrespABM").Value = "SP_ABM" & Me.dgvTablas.Rows(i).Cells("NombreTabla").Value
            Else
                Me.dgvTablas.Rows(i).Cells("NombrespABM").Value = String.Empty
            End If
        Next
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        Dim i As Integer
        For i = 0 To Me.dgvTablas.Rows.Count - 1
            If (CheckBox5.Checked = True) Then
                Me.dgvTablas.Rows(i).Cells("ParaTraer").Value = True
            Else
                Me.dgvTablas.Rows(i).Cells("ParaTraer").Value = False

            End If
        Next
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        Dim i As Integer
        For i = 0 To Me.dgvTablas.Rows.Count - 1
            If (CheckBox2.Checked = True) And (Me.dgvTablas.Rows(i).Cells("ParaTraer").Value = True) Then
                Me.dgvTablas.Rows(i).Cells("NombreSPTraer").Value = "SP_Traer" & Me.dgvTablas.Rows(i).Cells("NombreTabla").Value
            Else
                Me.dgvTablas.Rows(i).Cells("NombreSPTraer").Value = String.Empty
            End If
        Next
    End Sub

    Private Sub dgvTablas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTablas.CellDoubleClick
         If (e.RowIndex >= 0) Then
            If (e.ColumnIndex = 5) Then
                FolderBrowserDialog1.ShowDialog()
                dgvTablas.Rows(e.RowIndex).Cells(5).Value = FolderBrowserDialog1.SelectedPath
            End If
            If (e.ColumnIndex = 6) Then
                If (Me.dgvTablas.Rows(e.RowIndex).Cells("Generar").Value = True) Then
                    Dim PathnombreArchivo As String = Application.StartupPath + "\" + Me.dgvTablas.Rows(e.RowIndex).Cells(0).Value.ToString()
                    GenerarProcedimientosAlmacenadosABM(Me.dgvTablas.Rows(e.RowIndex).Cells(0).Value.ToString(), PathnombreArchivo)
                    If IO.File.Exists(PathnombreArchivo + ".sql") Then
                        Dim objfrmpreviewclase As New frmpreviewclase()
                        objfrmpreviewclase.RTBclase.Text = My.Computer.FileSystem.ReadAllText(PathnombreArchivo + ".sql")
                        objfrmpreviewclase.Text = "Procedimiento " + Me.dgvTablas.Rows(e.RowIndex).Cells(0).Value.ToString()
                        objfrmpreviewclase.Show()
                        IO.File.Delete(PathnombreArchivo + ".sql")
                    Else
                        MsgBox("No se puede crear una vista previa del procedimiento.")
                    End If
                End If
                If (Me.dgvTablas.Rows(e.RowIndex).Cells("ParaTraer").Value = True) Then
                    Dim PathnombreArchivo As String = Application.StartupPath + "\" + Me.dgvTablas.Rows(e.RowIndex).Cells(0).Value.ToString()
                    GenerarProcedimientosAlmacenadosTraer(Me.dgvTablas.Rows(e.RowIndex).Cells(0).Value.ToString(), PathnombreArchivo)
                    If IO.File.Exists(PathnombreArchivo + ".sql") Then
                        Dim objfrmpreviewclase As New frmpreviewclase()
                        objfrmpreviewclase.RTBclase.Text = My.Computer.FileSystem.ReadAllText(PathnombreArchivo + ".sql")
                        objfrmpreviewclase.Text = "Procedimiento " + Me.dgvTablas.Rows(e.RowIndex).Cells(0).Value.ToString()
                        objfrmpreviewclase.Show()
                        IO.File.Delete(PathnombreArchivo + ".sql")
                    Else
                        MsgBox("No se puede crear una vista previa del procedimiento.")
                    End If
                End If
            End If
        End If
        If (e.ColumnIndex = 7) Then
            If (Me.dgvTablas.Rows(e.RowIndex).Cells("Generar").Value = True) Then
                crear_spABM_en_origen(Me.dgvTablas.Rows(e.RowIndex).Cells(0).Value.ToString())
            End If
            If (Me.dgvTablas.Rows(e.RowIndex).Cells("ParaTraer").Value = True) Then
                crear_spparatraer_en_origen(Me.dgvTablas.Rows(e.RowIndex).Cells(0).Value.ToString())
            End If
        End If
    End Sub
    Private Sub crear_spparatraer_en_origen(ByVal nombre As String)
        Dim PathnombreArchivo As String = Application.StartupPath + "\" + nombre
        crear_codigo_sp_paratraer(PathnombreArchivo & ".txt", nombre)
        If IO.File.Exists(PathnombreArchivo & ".txt") Then
            Dim objfrmpreviewclase As New frmpreviewclase()
            Dim tgstr As String = My.Computer.FileSystem.ReadAllText(PathnombreArchivo & ".txt")
            MsgBox(tgstr)
            IO.File.Delete(PathnombreArchivo)
            Dim tgcmd As New OleDb.OleDbCommand
            tgcmd.CommandText = tgstr
            tgcmd.Connection = Me.conexion
            Try
                tgcmd.CommandType = CommandType.Text
                tgcmd.ExecuteNonQuery()
                MsgBox("Procedimiento creado en el origen.")
            Catch
                drop_sp("SP_ABM" & nombre)
                Try
                    tgcmd.ExecuteNonQuery()
                    MsgBox("Procedimiento creado en el origen.")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End Try
            IO.File.Delete(PathnombreArchivo & ".txt")
        Else
            MsgBox("Error.")
        End If
    End Sub
    Private Sub crear_codigo_sp_paratraer(ByVal pathnombrearchivo As String, ByVal nombre As String)
        Dim cad As String = "packet size=4096;integrated security=SSPI;data source=" + Me.txtserver.Text + ";persist security info=False;initial catalog=" + Me.txtdb.Text
        Me.txtCadena.Text = cad
        Call Cargar(cad, nombre)
        Dim libre As Integer = FreeFile()
        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, pathnombrearchivo, OpenMode.Output)
        PrintLine(libre, "CREATE Procedure SP_Traer" & nombre)
        PrintLine(libre, "@Id" & nombre & " codigo")
        PrintLine(libre, "as")
        PrintLine(libre, "if (@Id" & nombre & "=0)")
        PrintLine(libre, TAB(4), TAB(4), "select * from " & nombre & " order by " & "Id" & nombre & " desc")
        PrintLine(libre, "else")
        PrintLine(libre, TAB(4), TAB(4), "select * from " & nombre & " where  Id" & nombre & "=@Id" & nombre & " order by " & "Id" & nombre & " desc")
        ' Cierro el archivo de versión
        FileClose(libre)
    End Sub
    Private Sub crear_spABM_en_origen(ByVal nombre As String)
        Dim PathnombreArchivo As String = Application.StartupPath + "\" + nombre
        crear_codigo_spABM(PathnombreArchivo & ".txt", nombre)
        If IO.File.Exists(PathnombreArchivo & ".txt") Then
            Dim objfrmpreviewclase As New frmpreviewclase()
            Dim tgstr As String = My.Computer.FileSystem.ReadAllText(PathnombreArchivo & ".txt")
            IO.File.Delete(PathnombreArchivo)
            Dim tgcmd As New OleDb.OleDbCommand
            tgcmd.CommandText = tgstr
            tgcmd.Connection = Me.conexion
            Try
                tgcmd.CommandType = CommandType.Text
                tgcmd.ExecuteNonQuery()
                MsgBox("Procedimiento creado en el origen.")
            Catch
                drop_sp("SP_ABM" & nombre)
                Try
                    tgcmd.ExecuteNonQuery()
                    MsgBox("Procedimiento creado en el origen.")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End Try
            IO.File.Delete(PathnombreArchivo & ".txt")
        Else
            MsgBox("Error.")
        End If
    End Sub
    

    Private Sub crear_codigo_spABM(ByVal PathnombreArchivo As String, ByVal nombre As String)
        Dim cad As String = "packet size=4096;integrated security=SSPI;data source=" + Me.txtserver.Text + ";persist security info=False;initial catalog=" + Me.txtdb.Text
        Me.txtCadena.Text = cad
        Call Cargar(cad, nombre)
        Dim libre As Integer = FreeFile()
        Dim reg As regCampo
        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, PathnombreArchivo, OpenMode.Output)
        Dim strcad As String = String.Empty
        Dim strcad2 As String = String.Empty
        PrintLine(libre, "CREATE Procedure SP_ABM" & nombre)
        PrintLine(libre, TAB(4), TAB(4), "    @tarea int,")
        For Each reg In arrEstructura
            Select Case reg.tipo
                Case "String"
                    PrintLine(libre, TAB(4), TAB(4), "    @" & reg.nombre & " varchar(250),")
                Case "Int64"
                    PrintLine(libre, TAB(4), TAB(4), "    @" & reg.nombre & " bigint,")
                Case "Int32"
                    PrintLine(libre, TAB(4), TAB(4), "    @" & reg.nombre & " int,")
                Case "Double"
                    PrintLine(libre, TAB(4), TAB(4), "    @" & reg.nombre & " Float,")
                Case Else
                    PrintLine(libre, TAB(4), TAB(4), "    @" & reg.nombre & " " & reg.tipo & ",")
            End Select
            strcad = strcad & "@" & reg.nombre & ","
            strcad2 = strcad2 & reg.nombre & "=@" & reg.nombre & ","
        Next
        strcad = Mid(strcad, 1, (strcad.Length) - 1)
        strcad2 = Mid(strcad2, 1, (strcad2.Length) - 1)
        strcad2 = strcad2 & " where id" & nombre & "= @id" & nombre
        PrintLine(libre, TAB(4), TAB(4), "    @resultado integer output")
        PrintLine(libre, TAB(4), "as")
        PrintLine(libre, TAB(4), " if (@tarea=1)")
        PrintLine(libre, TAB(4), "     insert into " & nombre & " values(" & strcad & ")")
        PrintLine(libre, TAB(4), " if (@tarea=2)")
        PrintLine(libre, TAB(4), "     update " & nombre & " set " & strcad2)
        PrintLine(libre, TAB(4), " if (@tarea=3)")
        PrintLine(libre, TAB(4), "    delete from " & nombre & " where id" & nombre & "= @id" & nombre)
        'actualizo la variable resultado
        PrintLine(libre, TAB(4), " if(@@error=0)")
        PrintLine(libre, TAB(4), "   begin")
        PrintLine(libre, TAB(4), "       set @resultado=1")
        PrintLine(libre, TAB(4), "   End")
        PrintLine(libre, TAB(4), "   Else")
        PrintLine(libre, TAB(4), "     begin")
        PrintLine(libre, TAB(4), "         set @resultado=0")
        PrintLine(libre, TAB(4), "     End ")
        ' Cierro el archivo de versión
        FileClose(libre)
    End Sub
    Private Sub drop_sp(ByVal nombre As String)
        Dim tgcmd As New OleDb.OleDbCommand
        tgcmd.CommandText = "drop procedure " & nombre
        tgcmd.Connection = Me.conexion
        tgcmd.CommandType = CommandType.Text
        Try
            tgcmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        Dim i As Integer
        For i = 0 To Me.dgvTablas.Rows.Count - 1
            If CheckBox4.Checked = True Then
                Me.dgvTablas.Rows(i).Cells("Guardaren").Value = Me.txbunidaddisco.Text
            Else
                Me.dgvTablas.Rows(i).Cells("Guardaren").Value = String.Empty

            End If
        Next
    End Sub

    Private Sub GenerarProcedimientosAlmacenadosABM(ByVal Clase As String, ByVal pathmasNombreProcedimiento As String)
        Dim cad As String = "packet size=4096;integrated security=SSPI;data source=" + Me.txtserver.Text + ";persist security info=False;initial catalog=" + Me.txtdb.Text
        Me.txtCadena.Text = cad
        Call Cargar(cad, Clase)       ' Cargo la estructura de la tabla en un array "modular"
        ' Doy formato al nombre del archivo
        Dim auxnombreproc As String = "SP_ABM" + Clase

        ' Defino variables
        Dim libre As Integer = FreeFile()
        Dim reg As regCampo

        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, pathmasNombreProcedimiento + ".sql", OpenMode.Output)

        ' Comienzo a generar la clase
        PrintLine(libre, "IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = '" & auxnombreproc & "')")
        PrintLine(libre, TAB(4), "BEGIN")
        PrintLine(libre, TAB(4), "     DROP  Procedure " & auxnombreproc)
        PrintLine(libre, TAB(4), "End ")
        PrintLine(libre, TAB(4), "GO ")
        ' Creo una línea divisoria (espacio en blanco)
        PrintLine(libre, "")

        ' Comienzo a recorrer todos los campos guardados en el array
        Dim strcad As String = String.Empty
        Dim strcad2 As String = String.Empty
        PrintLine(libre, "CREATE Procedure " & auxnombreproc)
        PrintLine(libre, TAB(4), TAB(4), "    @tarea int,")
        For Each reg In arrEstructura
            Select Case reg.tipo
                Case "String"
                    PrintLine(libre, TAB(4), TAB(4), "    @" & reg.nombre & " varchar(250),")
                Case "Int64"
                    PrintLine(libre, TAB(4), TAB(4), "    @" & reg.nombre & " bigint,")
                Case "Int32"
                    PrintLine(libre, TAB(4), TAB(4), "    @" & reg.nombre & " int,")
                Case "Double"
                    PrintLine(libre, TAB(4), TAB(4), "    @" & reg.nombre & " Float,")
                Case Else
                    PrintLine(libre, TAB(4), TAB(4), "    @" & reg.nombre & " " & reg.tipo & ",")
            End Select
            strcad = strcad & "@" & reg.nombre & ","
            strcad2 = strcad2 & reg.nombre & "=@" & reg.nombre & ","
        Next
        strcad = Mid(strcad, 1, (strcad.Length) - 1)
        strcad2 = Mid(strcad2, 1, (strcad2.Length) - 1)
        strcad2 = strcad2 & " where id" & Clase & "= @id" & Clase
        PrintLine(libre, TAB(4), TAB(4), "    @resultado integer output")
        PrintLine(libre, TAB(4), "as")
        PrintLine(libre, TAB(4), " if (@tarea=1)")
        PrintLine(libre, TAB(4), "     insert into " & Clase & " values(" & strcad & ")")
        PrintLine(libre, TAB(4), " if (@tarea=2)")
        PrintLine(libre, TAB(4), "     update " & Clase & " set " & strcad2)
        PrintLine(libre, TAB(4), " if (@tarea=3)")
        PrintLine(libre, TAB(4), "    delete from " & Clase & " where id" & Clase & "= @id" & Clase)
        'actualizo la variable resultado
        PrintLine(libre, TAB(4), " if(@@error=0)")
        PrintLine(libre, TAB(4), "   begin")
        PrintLine(libre, TAB(4), "       set @resultado=1")
        PrintLine(libre, TAB(4), "   End")
        PrintLine(libre, TAB(4), "   Else")
        PrintLine(libre, TAB(4), "     begin")
        PrintLine(libre, TAB(4), "         set @resultado=0")
        PrintLine(libre, TAB(4), "     End ")

        ' Cierro el archivo de versión
        FileClose(libre)
    End Sub

    Private Sub GenerarProcedimientosAlmacenadosTraer(ByVal Clase As String, ByVal pathmasNombreProcedimiento As String)
        ' Doy formato al nombre del archivo
        Dim cad As String = "packet size=4096;integrated security=SSPI;data source=" + Me.txtserver.Text + ";persist security info=False;initial catalog=" + Me.txtdb.Text
        Me.txtCadena.Text = cad
        Call Cargar(cad, Clase)       ' Cargo la estructura de la tabla en un array "modular"
        ' Doy formato al nombre del archivo
        Dim auxnombreproc As String = "SP_Traer" + Clase

        ' Defino variables
        Dim libre As Integer = FreeFile()
        Dim reg As regCampo
        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, pathmasNombreProcedimiento + ".sql", OpenMode.Output)

        PrintLine(libre, "IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = '" & auxnombreproc & "')")  ' Comienzo a generar el procedimiento
        PrintLine(libre, TAB(4), "BEGIN")
        PrintLine(libre, TAB(4), "     DROP  Procedure " & auxnombreproc)
        PrintLine(libre, TAB(4), "End ")
        PrintLine(libre, TAB(4), "GO ")
        PrintLine(libre, "")     ' Creo una línea divisoria (espacio en blanco)
        PrintLine(libre, "CREATE Procedure " & auxnombreproc)
        PrintLine(libre, "@Id" & Clase & " codigo")
        PrintLine(libre, "as")
        PrintLine(libre, "if (@Id" & Clase & "=0)")
        PrintLine(libre, TAB(4), TAB(4), "select * from " & Clase & " order by " & "Id" & Clase & " desc")
        PrintLine(libre, "else")
        PrintLine(libre, TAB(4), TAB(4), "select * from " & Clase & " where  Id" & Clase & "=@Id" & Clase & " order by " & "Id" & Clase & " desc")
        ' Cierro el archivo de versión
        FileClose(libre)
    End Sub

    Private Sub btnGenerarProcedimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarProcedimiento.Click
        Try
            Dim sw As Boolean
            Dim i As Integer
            Dim PathnombreArchivo As String
            For i = 0 To Me.dgvTablas.Rows.Count - 1
                If (Me.dgvTablas.Rows(i).Cells("Generar").Value = True) Then
                    PathnombreArchivo = Me.dgvTablas.Rows(i).Cells("Guardaren").Value.ToString() + "\" + Me.dgvTablas.Rows(i).Cells("NombrespABM").Value.ToString() + ".sql"
                    GenerarProcedimientosAlmacenadosABM(Me.dgvTablas.Rows(i).Cells("NombreTabla").Value.ToString(), PathnombreArchivo)
                    sw = True
                End If
                If (Me.dgvTablas.Rows(i).Cells("ParaTraer").Value = True) Then
                    PathnombreArchivo = Me.dgvTablas.Rows(i).Cells("Guardaren").Value.ToString() + "\" + Me.dgvTablas.Rows(i).Cells("NombreSPTraer").Value.ToString()
                    GenerarProcedimientosAlmacenadosTraer(Me.dgvTablas.Rows(i).Cells("NombreTabla").Value.ToString(), PathnombreArchivo)
                    sw = True
                End If
            Next
            If sw Then
                MsgBox("Procedimientos generados con exito", MsgBoxStyle.Information)
            Else
                MsgBox("No se genero ninguna clase", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox(" Error : Ruta de archivo", MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub Cargar(ByVal conexion As String, ByVal tabla As String)
        ' Defino variables de acceso y manipulación de datos
        Dim cn As New SqlConnection(conexion)
        Dim da As New SqlDataAdapter("SELECT * FROM [" & tabla & "]", cn) ' los [] ban por si es una tabla de nombre compuesto
        Dim cb As New SqlCommandBuilder(da)
        Dim ds As New DataSet

        Dim dc As DataColumn

        ' Cargo la tabla "en memoria" (el nombre "tabla" es sólo para la tabla virtual)
        da.Fill(ds, "tabla")

        ' Defino variables
        Dim indice As Short

        ' Redimensiono el array con tantas posisiones como campos haya en la tabla
        ' El -1 va porque el array guarda el número de la posisión mayor y no la cantidad de elementos
        ReDim arrEstructura(ds.Tables("tabla").Columns.Count() - 1)

        ' Inicializo variables
        indice = 0

        ' Recorro la lista de campos en la estructura de la tabla "virtual"
        For Each dc In ds.Tables("tabla").Columns()
            ' Guardo el nombre y tipo de cada uno de los campos
            ' La fórmula en el tipo es para eliminar el "system." si llegase a aparecer
            arrEstructura(indice).nombre = dc.ColumnName.ToString
            arrEstructura(indice).tipo = Mid$(dc.DataType.ToString, InStr(dc.DataType.ToString, ".", CompareMethod.Text) + 1)

            ' Incremento la posisión dentro del array
            indice = indice + 1
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        txbunidaddisco.Text = FolderBrowserDialog1.SelectedPath
    End Sub


End Class