Imports System.Data.SqlClient
Imports System.Data.OleDb


Public Class FrmAuditoria
    Private da As OleDbDataAdapter
    Private ds As DataSet
    Private conexion As OleDbConnection
    Private t As New conexion
    Dim nrofilas As Integer
    Dim yapaso As Boolean = False
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
    Private Sub cargarAtributos(ByVal tabla As String)
        Dim cadenita As String
        cadenita = "packet size=4096;integrated security=SSPI;data source=" & Me.txtserver.Text & ";persist security info=False;initial catalog=" & Me.txtdb.Text
        Dim cn As New SqlConnection(cadenita)
        Dim da As New SqlDataAdapter("SELECT * FROM [" & tabla & "]", cn) ' los [] ban por si es una tabla de nombre compuesto
        Dim cb As New SqlCommandBuilder(da)
        Dim ds As New DataSet
        Dim dc As DataColumn
        da.Fill(ds, "tabla")
        Dim indice As Short
        indice = 0
        ReDim arrEstructura(ds.Tables("tabla").Columns.Count() - 1)
        For Each dc In ds.Tables("tabla").Columns()
            arrEstructura(indice).nombre = dc.ColumnName.ToString
            arrEstructura(indice).tipo = Mid$(dc.DataType.ToString, InStr(dc.DataType.ToString, ".", CompareMethod.Text) + 1)
            indice = indice + 1
        Next
    End Sub
    Public Function CargarComboGDV(ByRef cbo As DataGridViewComboBoxColumn, ByVal tabla As String)
        cbo.Items.Clear()
        Dim reg As regCampo
        cargarAtributos(tabla)
        For Each reg In arrEstructura
            cbo.Items.Add(reg.nombre)
        Next
        Return cbo
    End Function
    'Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
    '    If yacargo Then
    '        Dim reg As regCampo
    '        dgvcampo.RowCount = 0
    '        cargarAtributos()
    '        Dim i As Integer = 0
    '        For Each reg In arrEstructura
    '            Me.dgvcampo.Rows.Add()
    '            Me.dgvcampo.Rows(i).Cells("NombreColumna").Value = reg.nombre
    '            Me.dgvcampo.Rows(i).Cells("TipoDato").Value = reg.tipo
    '            Me.dgvcampo.Rows(i).Cells("TipoAtributo").Value = "Descriptor"
    '            Me.dgvcampo.Rows(i).Cells("Componente").Value = "TextBox"
    '            i += 1
    '        Next
    '        Me.CargarComboGDV(dgvcampo.Columns(4))
    '    End If
    'End Sub

    Private Sub cargartablas()
        Dim cad As String = "packet size=4096;integrated security=SSPI;data source=" + Me.txtserver.Text + ";persist security info=False;initial catalog=" + Me.txtdb.Text
        Me.txtCadena.Text = cad
        Dim nomtablas() As String
        Dim i As Integer
        nomtablas = Me.nombrestablas()
        If Not nomtablas Is Nothing Then
            Dim cbo As New DataGridViewComboBoxColumn
            For i = 0 To nomtablas.Length - 1
                If nomtablas(i) <> "sysdiagrams" And nomtablas(i) <> "AUDIT" Then
                    Me.dgvTablas.Rows.Add()
                    Me.dgvTablas.Rows(nrofilas).Cells("NombreTabla").Value = nomtablas(i)
                    'Me.CargarComboGDV(dgvTablas.Columns("CampoDescriptor"), nomtablas(i)) 'carga el combo con la tabla
                    'Me.CargarComboGDV(dgvTablas.Columns("CampoDescriptor"), nomtablas(i)) 'carga el combo con la tabla
                    nrofilas = nrofilas + 1
                End If
            Next
        End If
    End Sub

    Public Sub cargarCombo(ByVal cbo As DataGridViewComboBoxColumn)
        cbo.Items.Add("123")
    End Sub

    Public Sub cartgartablasgrilla()
        Me.dgvTablas.Rows.Clear()
        Me.nrofilas = 0
        cargartablas()
      
    End Sub
    Private Sub FrmAuditoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtCadena.SelectAll()
        If Utilitarios.servidor = String.Empty Then
            MsgBox("Configure los datos del servidor...", MsgBoxStyle.Information)
            txtserver.Enabled = True
            Me.txtdb.Enabled = True
        Else
            Me.txtdb.Text = Utilitarios.Basededatos
            Me.txtserver.Text = Utilitarios.servidor
            cartgartablasgrilla()
        End If
        yapaso = True
    End Sub

    Private Sub btnCargarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarTabla.Click
        Utilitarios.servidor = Me.txtserver.Text
        Utilitarios.Basededatos = Me.txtdb.Text
        cartgartablasgrilla()
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
    Private Sub GenerarDisparadorParaInsert(ByVal Clase As String, ByVal pathmasNombreProcedimiento As String, ByVal NombreProcedimiento As String, ByVal CampoDescriptor As String)
        ' Doy formato al nombre del archivo
        Dim cad As String = "packet size=4096;integrated security=SSPI;data source=" + Me.txtserver.Text + ";persist security info=False;initial catalog=" + Me.txtdb.Text
        Me.txtCadena.Text = cad
        Call Cargar(cad, Clase)       ' Cargo la estructura de la tabla en un array "modular"
        ' Doy formato al nombre del archivo
        Dim auxnombreproc As String = NombreProcedimiento
        ' Defino variables
        Dim libre As Integer = FreeFile()
        Dim reg As regCampo
        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, pathmasNombreProcedimiento + ".sql", OpenMode.Output)
        PrintLine(libre, "use " & Me.txtdb.Text)
        PrintLine(libre, "GO") ' Comienzo a generar el procedimiento

        PrintLine(libre, "IF EXISTS (SELECT * FROM sysobjects WHERE type = 'TR' AND name = '" & auxnombreproc & "')")  ' Comienzo a generar el procedimiento
        PrintLine(libre, TAB(4), "BEGIN")
        PrintLine(libre, TAB(4), "     DROP  Trigger " & auxnombreproc)
        PrintLine(libre, TAB(4), "End ")
        PrintLine(libre, TAB(4), "GO ")
        PrintLine(libre, "")     ' Creo una línea divisoria (espacio en blanco)
        PrintLine(libre, "CREATE TRIGGER " & auxnombreproc & " on " & Clase & " For Insert")
        PrintLine(libre, "as")
        PrintLine(libre, "insert into AUDIT select 'Insert', getdate(), (select'Nombre Insertado: ' +    convert(char(15)," + CampoDescriptor + ")  from INSERTED), SYSTEM_USER, host_name(), APP_NAME()")
        ' Cierro el archivo de versión
        FileClose(libre)
    End Sub
    Private Sub GenerarDisparadorParaUpdate(ByVal Clase As String, ByVal pathmasNombreProcedimiento As String, ByVal NombreProcedimiento As String, ByVal CampoDescriptor As String)
        ' Doy formato al nombre del archivo
        Dim cad As String = "packet size=4096;integrated security=SSPI;data source=" + Me.txtserver.Text + ";persist security info=False;initial catalog=" + Me.txtdb.Text
        Me.txtCadena.Text = cad
        Call Cargar(cad, Clase)       ' Cargo la estructura de la tabla en un array "modular"
        ' Doy formato al nombre del archivo
        Dim auxnombreproc As String = NombreProcedimiento
        ' Defino variables
        Dim libre As Integer = FreeFile()
        Dim reg As regCampo
        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, pathmasNombreProcedimiento + ".sql", OpenMode.Output)
        PrintLine(libre, "use " & Me.txtdb.Text)
        PrintLine(libre, "GO") ' Comienzo a generar el procedimiento

        PrintLine(libre, "IF EXISTS (SELECT * FROM sysobjects WHERE type = 'TR' AND name = '" & auxnombreproc & "')")  ' Comienzo a generar el procedimiento
        PrintLine(libre, TAB(4), "BEGIN")
        PrintLine(libre, TAB(4), "     DROP  Trigger " & auxnombreproc)
        PrintLine(libre, TAB(4), "End ")
        PrintLine(libre, TAB(4), "GO ")
        PrintLine(libre, "")     ' Creo una línea divisoria (espacio en blanco)
        PrintLine(libre, "CREATE TRIGGER " & auxnombreproc & " on " & Clase & " For Update")
        PrintLine(libre, "as")
        PrintLine(libre, "insert into AUDIT select 'Update', getdate(), (select'Nombre Actualizado: ' +    convert(char(15)," + CampoDescriptor + ")  from deleted), SYSTEM_USER, host_name(), APP_NAME()")
        ' Cierro el archivo de versión
        FileClose(libre)
    End Sub
    Private Sub GenerarDisparadorParadelete(ByVal Clase As String, ByVal pathmasNombreProcedimiento As String, ByVal NombreProcedimiento As String, ByVal CampoDescriptor As String)
        ' Doy formato al nombre del archivo
        Dim cad As String = "packet size=4096;integrated security=SSPI;data source=" + Me.txtserver.Text + ";persist security info=False;initial catalog=" + Me.txtdb.Text
        Me.txtCadena.Text = cad
        Call Cargar(cad, Clase)       ' Cargo la estructura de la tabla en un array "modular"
        ' Doy formato al nombre del archivo
        Dim auxnombreproc As String = NombreProcedimiento
        Dim libre As Integer = FreeFile()
        Dim reg As regCampo
        FileOpen(libre, pathmasNombreProcedimiento + ".sql", OpenMode.Output)
        PrintLine(libre, "use " & Me.txtdb.Text)
        PrintLine(libre, "GO") ' Comienzo a generar el procedimiento
        PrintLine(libre, "IF EXISTS (SELECT * FROM sysobjects WHERE type = 'TR' AND name = '" & auxnombreproc & "')")  ' Comienzo a generar el procedimiento
        PrintLine(libre, TAB(4), "BEGIN")
        PrintLine(libre, TAB(4), "     DROP  Trigger " & auxnombreproc)
        PrintLine(libre, TAB(4), "End ")
        PrintLine(libre, TAB(4), "GO ")
        PrintLine(libre, "")     ' Creo una línea divisoria (espacio en blanco)
        PrintLine(libre, "CREATE TRIGGER " & auxnombreproc & " on " & Clase & " For Delete")
        PrintLine(libre, "as")
        PrintLine(libre, "insert into AUDIT select 'Delete', getdate(), (select'Nombre Eliminado: ' +    convert(char(15)," + CampoDescriptor + ")  from Deleted), SYSTEM_USER, host_name(), APP_NAME()")
        FileClose(libre)
    End Sub

    Private Sub btnGenerarProcedimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarProcedimiento.Click
        Try
            Dim sw As Boolean
            Dim i As Integer
            Dim PathnombreArchivo As String
            For i = 0 To Me.dgvTablas.Rows.Count - 1
                If (Me.dgvTablas.Rows(i).Cells("Generar").Value = True) Then
                    'generamos los cursores
                    If Me.dgvTablas.Rows(i).Cells("Insertar").Value = True Then
                        Dim nombreTrigerInsert As String = "TG_AUDITINS_Insert" & Me.dgvTablas.Rows(i).Cells("NombreTabla").Value
                        If Me.dgvTablas.Rows(i).Cells("Guardaren").Value.ToString() = "c:\" Then
                            PathnombreArchivo = Me.dgvTablas.Rows(i).Cells("Guardaren").Value.ToString() + nombreTrigerInsert + ".sql"
                        Else
                            PathnombreArchivo = Me.dgvTablas.Rows(i).Cells("Guardaren").Value.ToString() + "\" + nombreTrigerInsert + ".sql"
                        End If
                        Me.GenerarDisparadorParaInsert(Me.dgvTablas.Rows(i).Cells("NombreTabla").Value.ToString(), PathnombreArchivo, nombreTrigerInsert, Me.dgvTablas.Rows(i).Cells("CampoDescriptor").Value.ToString())
                        sw = True
                    End If
                    If Me.dgvTablas.Rows(i).Cells("Modificar").Value = True Then
                        Dim nombreTrigerUpdate As String = "TG_AUDITINS_Update" & Me.dgvTablas.Rows(i).Cells("NombreTabla").Value
                        If Me.dgvTablas.Rows(i).Cells("Guardaren").Value.ToString() = "c:\" Then
                            PathnombreArchivo = Me.dgvTablas.Rows(i).Cells("Guardaren").Value.ToString() + nombreTrigerUpdate + ".sql"
                        Else
                            PathnombreArchivo = Me.dgvTablas.Rows(i).Cells("Guardaren").Value.ToString() + "\" + nombreTrigerUpdate + ".sql"
                        End If
                        Me.GenerarDisparadorParaUpdate(Me.dgvTablas.Rows(i).Cells("NombreTabla").Value.ToString(), PathnombreArchivo, nombreTrigerUpdate, Me.dgvTablas.Rows(i).Cells("CampoDescriptor").Value.ToString())
                        sw = True
                    End If
                    If Me.dgvTablas.Rows(i).Cells("Eliminar").Value = True Then
                        Dim nombreTrigerDelete As String = "TG_AUDITINS_Delete" & Me.dgvTablas.Rows(i).Cells("NombreTabla").Value
                        If Me.dgvTablas.Rows(i).Cells("Guardaren").Value.ToString() = "c:\" Then
                            PathnombreArchivo = Me.dgvTablas.Rows(i).Cells("Guardaren").Value.ToString() + nombreTrigerDelete + ".sql"
                        Else
                            PathnombreArchivo = Me.dgvTablas.Rows(i).Cells("Guardaren").Value.ToString() + "\" + nombreTrigerDelete + ".sql"
                        End If

                        Me.GenerarDisparadorParadelete(Me.dgvTablas.Rows(i).Cells("NombreTabla").Value.ToString(), PathnombreArchivo, nombreTrigerDelete, Me.dgvTablas.Rows(i).Cells("CampoDescriptor").Value.ToString())
                        sw = True
                    End If
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
    Private Sub dgvTablas_CellClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTablas.CellClick
        If e.ColumnIndex = 1 Then 'auditar 
            Dim objfrmparametrosauditoria As New FrmParametrosAuditoria
            Utilitarios.Tabla = Me.dgvTablas.Rows(Me.dgvTablas.CurrentCell.RowIndex).Cells(0).Value.ToString
            objfrmparametrosauditoria.ShowDialog()
            'actualizamos los compos de la grilla
            Me.dgvTablas.Rows(Me.dgvTablas.CurrentCell.RowIndex).Cells("CampoDescriptor").Value = Utilitarios.AtributoDescriptor
            Me.dgvTablas.Rows(Me.dgvTablas.CurrentCell.RowIndex).Cells("Insertar").Value = Utilitarios.insertar
            Me.dgvTablas.Rows(Me.dgvTablas.CurrentCell.RowIndex).Cells("Modificar").Value = Utilitarios.Modificar
            Me.dgvTablas.Rows(Me.dgvTablas.CurrentCell.RowIndex).Cells("Eliminar").Value = Utilitarios.Eliminar
        End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Dim i As Integer
        For i = 0 To Me.dgvTablas.Rows.Count - 1
            If CheckBox2.Checked = True And (Me.dgvTablas.Rows(i).Cells("Generar").Value = True) Then
                Me.dgvTablas.Rows(i).Cells("Insertar").Value = True
            Else
                Me.dgvTablas.Rows(i).Cells("Insertar").Value = False

            End If
        Next
    End Sub
    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        Dim i As Integer
        For i = 0 To Me.dgvTablas.Rows.Count - 1
            If CheckBox3.Checked = True And (Me.dgvTablas.Rows(i).Cells("Generar").Value = True) Then
                Me.dgvTablas.Rows(i).Cells("Modificar").Value = True
            Else
                Me.dgvTablas.Rows(i).Cells("Modificar").Value = False
            End If
        Next


       
    End Sub

    Private Sub CheckBox4_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        Dim i As Integer
        For i = 0 To Me.dgvTablas.Rows.Count - 1
            If CheckBox4.Checked = True And (Me.dgvTablas.Rows(i).Cells("Generar").Value = True) Then
                Me.dgvTablas.Rows(i).Cells("Guardaren").Value = Me.txbunidaddisco.Text
            Else
                Me.dgvTablas.Rows(i).Cells("Guardaren").Value = String.Empty

            End If
        Next
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        txbunidaddisco.Text = FolderBrowserDialog1.SelectedPath
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim i As Integer
        For i = 0 To Me.dgvTablas.Rows.Count - 1
            If CheckBox1.Checked = True And (Me.dgvTablas.Rows(i).Cells("Generar").Value = True) Then
                Me.dgvTablas.Rows(i).Cells("Eliminar").Value = True
            Else
                Me.dgvTablas.Rows(i).Cells("Eliminar").Value = False

            End If
        Next
    End Sub
   
    Private Sub dgvTablas_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTablas.CellDoubleClick
        If (e.RowIndex >= 0) Then
            If (e.ColumnIndex = 6) Then
                FolderBrowserDialog1.ShowDialog()
                dgvTablas.Rows(e.RowIndex).Cells(6).Value = FolderBrowserDialog1.SelectedPath
            End If
            If (e.ColumnIndex = 7) Then
                If Me.dgvTablas.Rows(e.RowIndex).Cells("Insertar").Value = True Then
                    ejecutar_tg_en_origen("insert", Me.dgvTablas.Rows(e.RowIndex).Cells(0).Value, Me.dgvTablas.Rows(e.RowIndex).Cells("CampoDescriptor").Value)
                End If
                If Me.dgvTablas.Rows(e.RowIndex).Cells("Modificar").Value = True Then
                    ejecutar_tg_en_origen("update", Me.dgvTablas.Rows(e.RowIndex).Cells(0).Value.ToString, Me.dgvTablas.Rows(e.RowIndex).Cells("CampoDescriptor").Value.ToString)
                End If
                If Me.dgvTablas.Rows(e.RowIndex).Cells("Eliminar").Value = True Then
                    ejecutar_tg_en_origen("delete", Me.dgvTablas.Rows(e.RowIndex).Cells(0).Value.ToString, Me.dgvTablas.Rows(e.RowIndex).Cells("CampoDescriptor").Value.ToString)
                End If
            End If
        End If
        
    End Sub
    Private Sub ejecutar_tg_en_origen(ByVal tipo As String, ByVal nombre As String, ByVal CampoDescriptor As String)
        Select Case tipo
            Case "insert"
                crear_codigo_tg_insert(nombre, CampoDescriptor)
                ejecutar_tg(Application.StartupPath + "\" + nombre + ".txt", "TG_AUDITINS_Insert" & nombre)
            Case "update"
                crear_codigo_tg_update(nombre, CampoDescriptor)
                ejecutar_tg(Application.StartupPath + "\" + nombre + ".txt", "TG_AUDITINS_Update" & nombre)
            Case "delete"
                crear_codigo_tg_delete(nombre, CampoDescriptor)
                ejecutar_tg(Application.StartupPath + "\" + nombre + ".txt", "TG_AUDITINS_Delete" & nombre)
        End Select

    End Sub

    Private Sub crear_codigo_tg_insert(ByVal nombre As String, ByVal CampoDescriptor As String)
        ' Doy formato al nombre del archivo
        Dim cad As String = "packet size=4096;integrated security=SSPI;data source=" + Me.txtserver.Text + ";persist security info=False;initial catalog=" + Me.txtdb.Text
        Me.txtCadena.Text = cad
        Call Cargar(cad, nombre)       ' Cargo la estructura de la tabla en un array "modular"
        ' Doy formato al nombre del archivo
        Dim auxnombreproc As String = "TG_AUDITINS_Insert" & nombre
        ' Defino variables
        Dim libre As Integer = FreeFile()
        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, Application.StartupPath + "\" + nombre + ".txt", OpenMode.Output)
        PrintLine(libre, "CREATE TRIGGER " & auxnombreproc & " on " & nombre & " For Insert")
        PrintLine(libre, "as")
        PrintLine(libre, "insert into AUDIT select 'Insert', getdate(), (select'Nombre Insertado: ' +    convert(char(15)," + CampoDescriptor + ")  from INSERTED), SYSTEM_USER, host_name(), APP_NAME()")
        ' Cierro el archivo de versión
        FileClose(libre)
    End Sub

    Private Sub crear_codigo_tg_update(ByVal nombre As String, ByVal CampoDescriptor As String)
        ' Doy formato al nombre del archivo
        Dim cad As String = "packet size=4096;integrated security=SSPI;data source=" + Me.txtserver.Text + ";persist security info=False;initial catalog=" + Me.txtdb.Text
        Me.txtCadena.Text = cad
        Call Cargar(cad, nombre)       ' Cargo la estructura de la tabla en un array "modular"
        ' Doy formato al nombre del archivo
        Dim auxnombreproc As String = "TG_AUDITINS_Update" & nombre
        ' Defino variables
        Dim libre As Integer = FreeFile()
        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, Application.StartupPath + "\" + nombre + ".txt", OpenMode.Output)
        PrintLine(libre, "CREATE TRIGGER " & auxnombreproc & " on " & nombre & " For Update")
        PrintLine(libre, "as")
        PrintLine(libre, "insert into AUDIT select 'Update', getdate(), (select'Nombre Actualizado: ' +    convert(char(15)," + CampoDescriptor + ")  from deleted), SYSTEM_USER, host_name(), APP_NAME()")
        ' Cierro el archivo de versión
        FileClose(libre)
    End Sub
    Private Sub crear_codigo_tg_delete(ByVal nombre As String, ByVal CampoDescriptor As String)
        ' Doy formato al nombre del archivo
        Dim cad As String = "packet size=4096;integrated security=SSPI;data source=" + Me.txtserver.Text + ";persist security info=False;initial catalog=" + Me.txtdb.Text
        Me.txtCadena.Text = cad
        Call Cargar(cad, nombre)       ' Cargo la estructura de la tabla en un array "modular"
        ' Doy formato al nombre del archivo
        Dim auxnombreproc As String = "TG_AUDITINS_Delete" & nombre
        Dim libre As Integer = FreeFile()
        FileOpen(libre, Application.StartupPath + "\" + nombre + ".txt", OpenMode.Output)
        PrintLine(libre, "CREATE TRIGGER " & auxnombreproc & " on " & nombre & " For Delete")
        PrintLine(libre, "as")
        PrintLine(libre, "insert into AUDIT select 'Delete', getdate(), (select'Nombre Eliminado: ' +    convert(char(15)," + CampoDescriptor + ")  from Deleted), SYSTEM_USER, host_name(), APP_NAME()")
        FileClose(libre)
    End Sub

    Private Sub ejecutar_tg(ByVal PathnombreArchivo As String, ByVal nombre As String)
        If IO.File.Exists(PathnombreArchivo) Then
            Dim tgstr As String = My.Computer.FileSystem.ReadAllText(PathnombreArchivo)
            IO.File.Delete(PathnombreArchivo)
            Dim tgcmd As New OleDb.OleDbCommand
            tgcmd.CommandText = tgstr
            tgcmd.Connection = Me.conexion
            Try
                tgcmd.CommandType = CommandType.Text
                tgcmd.ExecuteNonQuery()
                MsgBox("Trigger creado en el origen.")
            Catch
                drop_tg(nombre)
                Try
                    tgcmd.ExecuteNonQuery()
                    MsgBox("Procedimiento creado en el origen.")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End Try
        Else
            MsgBox("Error.")
        End If
    End Sub
    Private Sub drop_tg(ByVal nombre As String)
        Dim tgcmd As New OleDb.OleDbCommand
        tgcmd.CommandText = "drop Trigger " & nombre
        tgcmd.Connection = Me.conexion
        tgcmd.CommandType = CommandType.Text
        Try
            tgcmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub
    
End Class