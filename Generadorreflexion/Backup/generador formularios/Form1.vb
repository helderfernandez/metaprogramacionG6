Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO.Directory
Public Class Form1

    Private da As OleDbDataAdapter
    Private ds As DataSet
    Private conexion As OleDbConnection
    Private t As New conexion
    Dim yacargo As Boolean = False

    Const VISUAL_BASIC As Byte = 0
    Const C_SHARP As Byte = 1
    Private varLenguaje As Byte = VISUAL_BASIC

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.ComboBox1.Items.Clear()
        Me.cargartablas()
        yacargo = True
    End Sub
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
            MsgBox("Error al conectarse al servidor... configure los datos de su servidor")
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
    Structure regCampo
        Dim nombre As String
        Dim tipo As String
    End Structure

    Dim arrEstructura() As regCampo
    Dim arrstring() As String

    Public Sub cargarstring()
        ReDim arrstring(4)
        arrstring(0) = "Nuevo"
        arrstring(1) = "Guardar"
        arrstring(2) = "Modificar"
        arrstring(3) = "Imprimir"
        arrstring(4) = "Salir"

    End Sub

    Private Sub cargarAtributos()
        Dim cadenita As String
        cadenita = "packet size=4096;integrated security=SSPI;data source=" & Me.txtserver.Text & ";persist security info=False;initial catalog=" & Me.txtdb.Text
        Dim cn As New SqlConnection(cadenita)
        Dim da As New SqlDataAdapter("SELECT * FROM [" & Me.ComboBox1.Text & "]", cn) ' los [] ban por si es una tabla de nombre compuesto
        Dim cb As New SqlCommandBuilder(da)
        Dim ds As New DataSet

        Dim dc As DataColumn

        da.Fill(ds, "tabla")
        Dim indice As Short
        indice = 0
        ReDim arrEstructura(ds.Tables("tabla").Columns.Count() - 1)
        For Each dc In ds.Tables("tabla").Columns()
            ' Guardo el nombre y tipo de cada uno de los campos
            ' La fórmula en el tipo es para eliminar el "system." si llegase a aparecer
            arrEstructura(indice).nombre = dc.ColumnName.ToString
            arrEstructura(indice).tipo = Mid$(dc.DataType.ToString, InStr(dc.DataType.ToString, ".", CompareMethod.Text) + 1)

            ' Incremento la posisión dentro del array
            indice = indice + 1
        Next
    End Sub


    Private Sub cargartablas()
        Dim nomtablas() As String
        Dim i As Integer
        nomtablas = Me.nombrestablas()
        If Not nomtablas Is Nothing Then
            For i = 0 To nomtablas.Length - 1
                Me.ComboBox1.Items.Add(nomtablas(i))
            Next
            If Me.ComboBox1.Items.Count > 0 Then
                Me.ComboBox1.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub crearClaseCrl(ByVal Ruta As String)
        Dim archivo As String
        'Valida si Existe el archivo
        If Mid$(Me.ComboBox1.Text, Len(Me.ComboBox1.Text) - 3, 3) <> ".vb" Then
            'crea un nuevo archivo 
            archivo = Ruta & "\Ctrl" & Me.ComboBox1.Text & ".vb"
        Else
            'Sobreescribe el archivo
            archivo = Ruta & "\Ctrl" & Me.ComboBox1.Text
        End If

        Dim libre As String = FreeFile()
        FileOpen(libre, archivo, OpenMode.Output)

        PrintLine(libre, "Public Class Ctrl" & ComboBox1.Text)
        PrintLine(libre, "")
        PrintLine(libre, TAB(4), "Public Function guardar" & ComboBox1.Text & " (ByVal obj" & ComboBox1.Text & " As Negocio." & ComboBox1.Text & ") As Integer")
        PrintLine(libre, TAB(8), "Return obj" & ComboBox1.Text & ".guardar()")
        PrintLine(libre, TAB(4), "End Function")
        PrintLine(libre, TAB(4), "")
        PrintLine(libre, TAB(4), "")
        PrintLine(libre, TAB(4), "Public Function modificar" & ComboBox1.Text & " (ByVal obj" & ComboBox1.Text & " As Negocio." & ComboBox1.Text & ") As Integer")
        PrintLine(libre, TAB(8), "Return obj" & ComboBox1.Text & ".modificar()")
        PrintLine(libre, TAB(4), "End Function")
        PrintLine(libre, "End Class")
        FileClose(libre)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub
    Private Sub crearComponentes(ByVal Ruta As String)
        Dim archivo As String
        'Valida si Existe el archivo
        If Mid$(Me.ComboBox1.Text, Len(Me.ComboBox1.Text) - 3, 3) <> ".Designer.vb" Then
            'crea un nuevo archivo 
            archivo = Ruta & "\Frm" & Me.ComboBox1.Text & ".Designer.vb"
        Else
            'Sobreescribe el archivo
            archivo = Ruta & "\Frm" & Me.ComboBox1.Text
        End If

        Dim libre As String = FreeFile()
        Dim reg As regCampo
        Dim i, j, x, y As Integer
        x = 90
        y = 70
        i = 200
        j = 70
        'Abre el archivo de Texto
        FileOpen(libre, archivo, OpenMode.Output)

        PrintLine(libre, "<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _")
        PrintLine(libre, "Partial Class Frm" & Me.ComboBox1.Text)
        PrintLine(libre, TAB(5), "Inherits System.Windows.Forms.Form")
        PrintLine(libre, "")
        PrintLine(libre, TAB(5), "'Form reemplaza a Dispose para limpiar la lista de componentes.")
        PrintLine(libre, TAB(5), "<System.Diagnostics.DebuggerNonUserCode()> _")
        PrintLine(libre, TAB(5), "Protected Overrides Sub Dispose(ByVal disposing As Boolean)")
        PrintLine(libre, TAB(9), "If Disposing AndAlso components IsNot Nothing Then")
        PrintLine(libre, TAB(13), "components.Dispose()")
        PrintLine(libre, TAB(9), "End If")
        PrintLine(libre, TAB(9), "MyBase.Dispose(Disposing)")
        PrintLine(libre, TAB(5), "End Sub")
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "'Requerido por el Diseñador de Windows Forms")
        PrintLine(libre, TAB(5), "Private components As System.ComponentModel.IContainer")
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento")
        PrintLine(libre, TAB(5), "'Se puede modificar usando el Diseñador de Windows Forms.")
        PrintLine(libre, TAB(5), "'No lo modifique con el editor de código.")
        PrintLine(libre, TAB(5), "<System.Diagnostics.DebuggerStepThrough()> _")
        PrintLine(libre, TAB(5), "Private Sub InitializeComponent()")
        PrintLine(libre, TAB(5), "Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm" & ComboBox1.Text & "))")

        Dim uno As Integer = 0
        For Each reg In arrEstructura
            Dim valor = dgvcampo.Rows(uno).Cells.Item(3).Value.ToString
            If valor = "TextBox" Then
                PrintLine(libre, TAB(9), "Me.txt" & reg.nombre & " = New System.Windows.Forms.TextBox")
            Else
                PrintLine(libre, TAB(9), "Me.cb" & reg.nombre & " = New System.Windows.Forms.ComboBox")
            End If
            uno += 1
        Next

        For Each reg In arrEstructura
            PrintLine(libre, TAB(9), "Me.lb" & reg.nombre & " = New System.Windows.Forms.Label")
        Next

        PrintLine(libre, TAB(9), "Me.ToolStrip1 = New System.Windows.Forms.ToolStrip")
        'TS Significa ToolStrip
        'Agregar Botonoes al ToolsTrip
        Dim Strip1 = "Nuevo"
        Dim Strip2 = "Guardar"
        Dim Strip3 = "Modificar"
        Dim Strip4 = "Imprimir"
        Dim Strip5 = "Salir"
        cargarstring()
        Dim Strip As String

        For Each Strip In arrstring
            PrintLine(libre, TAB(9), "Me.TS" & Strip & " = New System.Windows.Forms.ToolStripButton")
        Next

        PrintLine(libre, TAB(9), "Me.ToolStrip1.SuspendLayout()")
        PrintLine(libre, TAB(9), "Me.SuspendLayout()")
        'Crear TextBox en el Formulario
        Dim dos As Integer = 0
        For Each reg In arrEstructura
            Dim valor = dgvcampo.Rows(dos).Cells.Item(3).Value.ToString

            If valor = "TextBox" Then
                PrintLine(libre, TAB(9), "'")
                PrintLine(libre, TAB(9), "'txt" & reg.nombre)
                PrintLine(libre, TAB(9), "'")
                PrintLine(libre, TAB(9), "Me.txt" & reg.nombre & ".Location = New System.Drawing.Point(" & i & "," & j & ")")
                PrintLine(libre, TAB(9), "Me.txt" & reg.nombre & ".Name = " & Chr(34) & "txt" & reg.nombre & Chr(34))
                PrintLine(libre, TAB(9), "Me.txt" & reg.nombre & ".Size = New System.Drawing.Size(137, 20)")
                PrintLine(libre, TAB(9), "Me.txt" & reg.nombre & ".TabIndex = 26")
            Else
                PrintLine(libre, TAB(9), "'")
                PrintLine(libre, TAB(9), "'cb" & reg.nombre)
                PrintLine(libre, TAB(9), "'")
                PrintLine(libre, TAB(9), "Me.cb" & reg.nombre & ".FormattingEnabled = True")
                PrintLine(libre, TAB(9), "Me.cb" & reg.nombre & ".Location = New System.Drawing.Point(" & i & "," & j & ")")
                PrintLine(libre, TAB(9), "Me.cb" & reg.nombre & ".Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)")
                PrintLine(libre, TAB(9), "Me.cb" & reg.nombre & ".Name = " & Chr(34) & "cb" & reg.nombre & Chr(34))
                PrintLine(libre, TAB(9), "Me.cb" & reg.nombre & ".Size = New System.Drawing.Size(137, 20)")
                PrintLine(libre, TAB(9), "Me.cb" & reg.nombre & ".TabIndex = 26")
            End If
            ' Creo la variable local para usarse con la propiedad
            j += 30
            dos += 1
        Next

        'Crear Label en el Formulario
        For Each reg In arrEstructura
            ' Creo la variable local para usarse con la propiedad
            PrintLine(libre, TAB(9), "'")
            PrintLine(libre, TAB(9), "'lb" & reg.nombre)
            PrintLine(libre, TAB(9), "'")
            PrintLine(libre, TAB(9), "Me.lb" & reg.nombre & ".AutoSize = True")
            PrintLine(libre, TAB(9), "Me.lb" & reg.nombre & ".Location = New System.Drawing.Point(" & x & "," & y & ")")
            PrintLine(libre, TAB(9), "Me.lb" & reg.nombre & ".Name = " & Chr(34) & "lb" & reg.nombre & Chr(34))
            PrintLine(libre, TAB(9), "Me.lb" & reg.nombre & ".Size = New System.Drawing.Size(137, 20)")
            PrintLine(libre, TAB(9), "Me.lb" & reg.nombre & ".TabIndex = 26")
            PrintLine(libre, TAB(9), "Me.lb" & reg.nombre & ".Text = " & Chr(34) & reg.nombre & Chr(34))
            y += 30
        Next

        'Se Crea el Componente ToolStrip
        PrintLine(libre, TAB(9), "'")
        PrintLine(libre, TAB(9), "'ToolStrip1")
        PrintLine(libre, TAB(9), "'")
        PrintLine(libre, TAB(9), "Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom")
        PrintLine(libre, TAB(9), "Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TS" & Strip1 & ", Me.TS" & Strip2 & ", Me.TS" & Strip3 & ", Me.TS" & Strip4 & ", Me.TS" & Strip5 & "})")
        PrintLine(libre, TAB(9), "Me.ToolStrip1.Location = New System.Drawing.Point(0, 173)")
        PrintLine(libre, TAB(9), "Me.ToolStrip1.Name = " & Chr(34) & "ToolStrip1" & Chr(34))
        PrintLine(libre, TAB(9), " Me.ToolStrip1.Size = New System.Drawing.Size(336, 25)")
        PrintLine(libre, TAB(9), "Me.ToolStrip1.TabIndex = 6")
        PrintLine(libre, TAB(9), "Me.ToolStrip1.Text = " & Chr(34) & "ToolStrip1" & Chr(34))

        'Agregando Caracteristicas al ToolStrip Principal
        For Each Strip In arrstring
            PrintLine(libre, TAB(9), " '")
            PrintLine(libre, TAB(9), "'TS" & Strip)
            PrintLine(libre, TAB(9), "'")
            PrintLine(libre, TAB(9), "Me.TS" & Strip & ".Image = CType(Resources.GetObject(" & Chr(34) & "TS" & Strip & ".Image" & Chr(34) & "), System.Drawing.Image)")
            PrintLine(libre, TAB(9), "Me.TS" & Strip & ".ImageTransparentColor = System.Drawing.Color.Magenta")
            PrintLine(libre, TAB(9), "Me.TS" & Strip & ".Name = " & Chr(34) & "TS" & Strip & Chr(34))
            PrintLine(libre, TAB(9), "Me.TS" & Strip & ".Size = New System.Drawing.Size(58, 22)")
            PrintLine(libre, TAB(9), "Me.TS" & Strip & ".Text = " & Chr(34) & Strip & Chr(34))
        Next


        PrintLine(libre, TAB(9), "'")
        PrintLine(libre, TAB(9), "'Frm" & Me.ComboBox1.Text)
        PrintLine(libre, TAB(9), "'")
        PrintLine(libre, TAB(9), "Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)")
        PrintLine(libre, TAB(9), "Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font")
        PrintLine(libre, TAB(9), "Me.ClientSize = New System.Drawing.Size(500, 500)")
        PrintLine(libre, TAB(9), "Me.Controls.Add(Me.ToolStrip1)")
        Dim tres As Integer = 0
        For Each reg In arrEstructura
            Dim valor = dgvcampo.Rows(tres).Cells.Item(3).Value.ToString
            If valor = "TextBox" Then
                PrintLine(libre, TAB(9), "Me.Controls.Add(Me.txt" & reg.nombre & ")")
            Else

                PrintLine(libre, TAB(9), "Me.Controls.Add(Me.cb" & reg.nombre & ")")
            End If
            tres += 1
        Next

        For Each reg In arrEstructura
            PrintLine(libre, TAB(9), "Me.Controls.Add(Me.lb" & reg.nombre & ")")
            x += 1
        Next

        PrintLine(libre, TAB(9), "Me.Name = " & Chr(34) & "Frm" & Me.ComboBox1.Text & Chr(34))
        PrintLine(libre, TAB(9), "Me.Text = " & Chr(34) & "Frm" & Me.ComboBox1.Text & Chr(34))
        PrintLine(libre, TAB(9), "Me.ToolStrip1.ResumeLayout(False)")
        PrintLine(libre, TAB(9), "Me.ToolStrip1.PerformLayout()")
        PrintLine(libre, TAB(9), "Me.ResumeLayout(False)")
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "End Sub")

        'Crea Label
        For Each reg In arrEstructura
            PrintLine(libre, TAB(5), "Friend WithEvents lb" & reg.nombre & " As System.Windows.Forms.Label")
        Next
        'Crea Button
        Dim cuatro As Integer
        For Each reg In arrEstructura
            Dim valor = dgvcampo.Rows(cuatro).Cells.Item(3).Value.ToString
            If valor = "TextBox" Then
                PrintLine(libre, TAB(5), "Friend WithEvents txt" & reg.nombre & " As System.Windows.Forms.TextBox")
            Else
                PrintLine(libre, TAB(5), "Friend WithEvents cb" & reg.nombre & " As System.Windows.Forms.ComboBox")
            End If
            cuatro += 1
        Next

        'ToolStrip1
        PrintLine(libre, TAB(5), "Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip")

        'Botones del ToolStrip1
        For Each Strip In arrstring
            PrintLine(libre, TAB(5), "Friend WithEvents TS" & Strip & " As System.Windows.Forms.ToolStripButton")
        Next
        PrintLine(libre, "End Class")
        'Cierra el Archivo
        FileClose(libre)
    End Sub

    Private Sub Crearclase(ByVal Ruta As String)
        Dim archivo As String
        'Valida si Existe el archivo
        If Mid$(Me.ComboBox1.Text, Len(Me.ComboBox1.Text) - 3, 3) <> ".vb" Then
            'crea un nuevo archivo 
            archivo = Ruta & "\Frm" & Me.ComboBox1.Text & ".vb"
        Else
            'Sobreescribe el archivo
            archivo = Ruta & "\Frm" & Me.ComboBox1.Text
        End If

        Dim libre As String = FreeFile()
        Dim reg As regCampo
        Dim strip1 As String
        Me.cargarstring()

        'Abre el archivo de Texto
        FileOpen(libre, archivo, OpenMode.Output)

        PrintLine(libre, "Public Class Frm" & Me.ComboBox1.Text)

        PrintLine(libre, TAB(5), "Dim obj" & ComboBox1.Text & " As New Negocio." & ComboBox1.Text)
        PrintLine(libre, TAB(5), "Dim objcontrol As New Negocio.Ctrl" & ComboBox1.Text)

        PrintLine(libre, TAB(5), "")

        '---------------------------------------Metodo Guardar
        PrintLine(libre, TAB(5), "Public Sub guardar()")
        Dim op As Integer = 0
        Dim pos As Integer = 0
        For Each reg In arrEstructura


            Dim valor = dgvcampo.Rows(op).Cells.Item(3).Value.ToString
            If valor = "TextBox" Then
                PrintLine(libre, TAB(9), "obj" & ComboBox1.Text & ".P" & reg.nombre & " = Me.txt" & reg.nombre & ".Text")
            Else
                PrintLine(libre, TAB(9), "obj" & ComboBox1.Text & ".P" & reg.nombre & " = Me.cb" & reg.nombre & ".SelectedValue")

            End If
            op += 1
            pos += 1
        Next

        PrintLine(libre, TAB(9), " If objcontrol.guardar" & ComboBox1.Text & "(obj" & ComboBox1.Text & ") = 1 Then")
        PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "Se Grabo Exitosamente" & Chr(34) & ")")
        PrintLine(libre, TAB(9), "Else")
        PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "### E R R O R ####" & Chr(34) & ")")
        PrintLine(libre, TAB(9), "End If")
        PrintLine(libre, TAB(5), "End Sub")
        '--------------------------------------------------

        '----------------------------------------Metodo Nuevo
        PrintLine(libre, TAB(5), "Private Sub Nuevo")
        op = 0
        For Each reg In arrEstructura
            Dim valor = dgvcampo.Rows(op).Cells.Item(3).Value.ToString
            If valor = "TextBox" Then
                PrintLine(libre, TAB(9), "me.txt" & reg.nombre & ".Clear()")
            End If
            op += 1
        Next
        PrintLine(libre, TAB(5), "End Sub")
        '-----------------------------------------


        'Crear el Evento Load para Cargar Combos
        PrintLine(libre, TAB(5), "Private Sub Frm" & ComboBox1.Text & "_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        op = 0
        Dim h As Integer = 0
        Dim combo(pos) As String
        Dim nombre(pos) As String
        Dim j As Integer = 0

        For Each reg In arrEstructura
            'Obtengo el nombre del combobox
            Dim valor0 = dgvcampo.Rows(op).Cells.Item(0).Value.ToString
            Dim valor = dgvcampo.Rows(op).Cells.Item(2).Value.ToString
            Dim valor1 = dgvcampo.Rows(op).Cells.Item(3).Value.ToString
            'Dim objcoombogrid As New DataGridViewComboBoxColumn
            'objcoombogrid = dgvcampo.Rows(op).Cells("tablaenlace")
            Dim valor2 = dgvcampo.Rows(op).Cells.Item(4).Value

            If (valor = "Llave Foranea") And (valor1 = "ComboBox") And (valor2 <> "") Then
                combo(h) = valor2
                PrintLine(libre, TAB(9), "Me.CargarCombo" & combo(h))
                nombre(h) = valor0
                h += 1
                j += 1
            End If
            op += 1
        Next
        PrintLine(libre, TAB(5), "End Sub")
        PrintLine(libre, TAB(5), "")

        'Crear los Metodos del Evento Cargar
        Dim co = 0
        For h = 0 To j - 1
            PrintLine(libre, TAB(5), "'Carga el Combo" & combo(h))
            PrintLine(libre, TAB(5), "Private Sub CargarCombo" & combo(h))
            PrintLine(libre, TAB(9), "Dim obj" & combo(h) & " As New Negocio." & combo(h))

            For Each reg In arrEstructura
                If nombre(co) = reg.nombre Then
                    PrintLine(libre, TAB(9), "Me.cb" & reg.nombre & ".DataSource = obj" & combo(h) & ".Traer_" & combo(h) & "(String.Empty)")
                    PrintLine(libre, TAB(9), "Me.cb" & reg.nombre & ".DisplayMember = " & Chr(34) & Chr(34))
                    PrintLine(libre, TAB(9), "Me.cb" & reg.nombre & ".ValueMember = " & Chr(34) & Chr(34))

                End If
            Next
            co += 1
            'Me.ComboBox1.DataSource = objcategoria.Traer_Categoria(String.Empty)
            ' ComboBox1.DisplayMember = "NombreCategoria"
            'ComboBox1.ValueMember = "idcategoria"
            PrintLine(libre, TAB(5), "End Sub")
            PrintLine(libre, TAB(5), "")
            ' PrintLine(libre, TAB(5), reg.nombre)


        Next





        '----------------------------------------Metodo Modificar
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "Private Sub Modificar")
        op = 0
        For Each reg In arrEstructura
            Dim valor = dgvcampo.Rows(op).Cells.Item(3).Value.ToString
            If valor = "TextBox" Then
                PrintLine(libre, TAB(9), "obj" & ComboBox1.Text & ".P" & reg.nombre & " = Me.txt" & reg.nombre & ".Text")
            Else
                PrintLine(libre, TAB(9), "obj" & ComboBox1.Text & ".P" & reg.nombre & " = Me.cb" & reg.nombre & ".SelectedValue")

            End If
            op += 1
        Next

        PrintLine(libre, TAB(9), " If objcontrol.modificar" & ComboBox1.Text & "(obj" & ComboBox1.Text & ") = 1 Then")
        PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "Se Grabo Exitosamente" & Chr(34) & ")")
        PrintLine(libre, TAB(9), "Else")
        PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "### E R R O R ####" & Chr(34) & ")")
        PrintLine(libre, TAB(9), "End If")
        PrintLine(libre, TAB(5), "End Sub")
        PrintLine(libre, TAB(5), "")

        '----------------------------------------Metodo Imprimir
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "Private Sub Imprimir")
        PrintLine(libre, TAB(9), "")
        PrintLine(libre, TAB(5), "End Sub")
        PrintLine(libre, TAB(5), "")

        '---------------------------------------Metodo Salir
        PrintLine(libre, TAB(5), "Private Sub Salir")
        PrintLine(libre, TAB(9), "Me.Close()")
        PrintLine(libre, TAB(5), "End Sub")
        PrintLine(libre, TAB(5), "")
        '---------------------------------Eventos del Toolstrip
        For Each strip1 In arrstring
            PrintLine(libre, TAB(5), "Private Sub TSG" & strip1 & "_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TS" & strip1 & ".Click")
            PrintLine(libre, TAB(9), "Me." & strip1 & "()")
            PrintLine(libre, TAB(5), "End Sub")
            PrintLine(libre, TAB(5), "")
        Next

        PrintLine(libre, TAB(5), "")
        PrintLine(libre, "End Class")
        'Cierra el Archivo
        FileClose(libre)
    End Sub
    Private Sub CrearFormularios(ByVal Ruta As String)
        Dim archivo As String
        'Valida si Existe el archivo
        If Mid$(Me.ComboBox1.Text, Len(Me.ComboBox1.Text) - 3, 3) <> ".resx" Then
            'crea un nuevo archivo 
            archivo = Ruta & "\Frm" & Me.ComboBox1.Text & ".resx"
        Else
            'Sobreescribe el archivo
            archivo = Ruta & "\Frm" & Me.ComboBox1.Text

        End If

        Dim libre As String = FreeFile()
        'Abre el archivo de Texto
        FileOpen(libre, archivo, OpenMode.Output)
        'escribe el codigo para generar el form
        PrintLine(libre, "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & "?>")
        PrintLine(libre, "<root>")
        PrintLine(libre, TAB(3), "<xsd:schema id=" & Chr(34) & "root" & Chr(34) & " xmlns=" & Chr(34) & Chr(34) & " xmlns:xsd=" & Chr(34) & "http://www.w3.org/2001/XMLSchema" & Chr(34) & " xmlns:msdata=" & Chr(34) & "urn:schemas-microsoft-com:xml-msdata" & Chr(34) & ">")
        PrintLine(libre, TAB(5), "<xsd:import namespace=" & Chr(34) & "http://www.w3.org/XML/1998/namespace" & Chr(34) & " />")
        PrintLine(libre, TAB(5), "<xsd:element name=" & Chr(34) & "root" & Chr(34) & " msdata:IsDataSet=" & Chr(34) & "true" & Chr(34) & ">")
        PrintLine(libre, TAB(7), "<xsd:complexType>")
        PrintLine(libre, TAB(9), "<xsd:choice maxOccurs=" & Chr(34) & "unbounded" & Chr(34) & ">")
        PrintLine(libre, TAB(11), "<xsd:element name=" & Chr(34) & "metadata" & Chr(34) & ">")
        PrintLine(libre, TAB(13), "<xsd:complexType>")
        PrintLine(libre, TAB(15), "<xsd:sequence>")
        PrintLine(libre, TAB(17), "<xsd:element name=" & Chr(34) & "value" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " minOccurs=" & Chr(34) & "0" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "</xsd:sequence>")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "name" & Chr(34) & " use=" & Chr(34) & "required" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "type" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "mimetype" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "<xsd:attribute ref=" & Chr(34) & "xml:space" & Chr(34) & " />")
        PrintLine(libre, TAB(13), "</xsd:complexType>")
        PrintLine(libre, TAB(11), "</xsd:element>")
        PrintLine(libre, TAB(11), "<xsd:element name=" & Chr(34) & "assembly" & Chr(34) & ">")
        PrintLine(libre, TAB(13), "<xsd:complexType>")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "alias" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "name" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " />")
        PrintLine(libre, TAB(13), "</xsd:complexType>")
        PrintLine(libre, TAB(11), "</xsd:element>")
        PrintLine(libre, TAB(11), "<xsd:element name=" & Chr(34) & "data" & Chr(34) & ">")
        PrintLine(libre, TAB(13), "<xsd:complexType>")
        PrintLine(libre, TAB(15), "<xsd:sequence>")
        PrintLine(libre, TAB(17), "<xsd:element name=" & Chr(34) & "value" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " minOccurs=" & Chr(34) & "0" & Chr(34) & " msdata:Ordinal=" & Chr(34) & "1" & Chr(34) & " />")
        PrintLine(libre, TAB(17), "<xsd:element name=" & Chr(34) & "comment" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " minOccurs=" & Chr(34) & "0" & Chr(34) & " msdata:Ordinal=" & Chr(34) & "2" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "</xsd:sequence>")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "name" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " use=" & Chr(34) & "required" & Chr(34) & " msdata:Ordinal=" & Chr(34) & "1" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "name" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " use=" & Chr(34) & "required" & Chr(34) & " msdata:Ordinal=" & Chr(34) & "1" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "type" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " msdata:Ordinal=" & Chr(34) & "3" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "mimetype" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " msdata:Ordinal=" & Chr(34) & "4" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "<xsd:attribute ref=" & Chr(34) & "xml:space" & Chr(34) & " />")
        PrintLine(libre, TAB(13), "</xsd:complexType>")
        PrintLine(libre, TAB(11), "</xsd:element>")
        PrintLine(libre, TAB(11), "<xsd:element name=" & Chr(34) & "resheader" & Chr(34) & ">")
        PrintLine(libre, TAB(13), "<xsd:complexType>")
        PrintLine(libre, TAB(15), "<xsd:sequence>")
        PrintLine(libre, TAB(17), "<xsd:element name=" & Chr(34) & "value" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " minOccurs=" & Chr(34) & "0" & Chr(34) & " msdata:Ordinal=" & Chr(34) & "1" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "</xsd:sequence>")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "name" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " use=" & Chr(34) & "required" & Chr(34) & " />")
        PrintLine(libre, TAB(13), "</xsd:complexType>")
        PrintLine(libre, TAB(11), "</xsd:element>")
        PrintLine(libre, TAB(9), "</xsd:choice>")
        PrintLine(libre, TAB(7), "</xsd:complexType>")
        PrintLine(libre, TAB(5), "</xsd:element>")
        PrintLine(libre, TAB(3), "</xsd:schema>")
        PrintLine(libre, TAB(3), "<resheader name=" & Chr(34) & "resmimetype" & Chr(34) & ">")
        PrintLine(libre, TAB(5), "<value>text/microsoft-resx</value>")
        PrintLine(libre, TAB(3), "</resheader>")
        PrintLine(libre, TAB(3), "<resheader name=" & Chr(34) & "version" & Chr(34) & ">")
        PrintLine(libre, TAB(5), "<value>2.0</value>")
        PrintLine(libre, TAB(3), "</resheader>")
        PrintLine(libre, TAB(3), "<resheader name=" & Chr(34) & "reader" & Chr(34) & ">")
        PrintLine(libre, TAB(5), "<value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>")
        PrintLine(libre, TAB(3), " </resheader>")
        PrintLine(libre, TAB(3), "<resheader name=" & Chr(34) & "writer" & Chr(34) & ">")
        PrintLine(libre, TAB(5), "<value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>")
        PrintLine(libre, TAB(3), "</resheader>")
        PrintLine(libre, "</root>")
        'Cierra el Archivo
        FileClose(libre)
    End Sub


    Public Function CargarComboGDV(ByRef cbo As DataGridViewComboBoxColumn)
        Dim nomtablas() As String
        nomtablas = Me.nombrestablas()
        For k As Integer = 0 To nomtablas.Length - 1
            cbo.Items.Add(nomtablas(k))
        Next
        Return cbo
    End Function


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If yacargo Then
            Dim reg As regCampo
            dgvcampo.RowCount = 0
            cargarAtributos()
            Dim i As Integer = 0
            For Each reg In arrEstructura
                Me.dgvcampo.Rows.Add()
                Me.dgvcampo.Rows(i).Cells("NombreColumna").Value = reg.nombre
                Me.dgvcampo.Rows(i).Cells("TipoDato").Value = reg.tipo
                Me.dgvcampo.Rows(i).Cells("TipoAtributo").Value = "Descriptor"
                Me.dgvcampo.Rows(i).Cells("Componente").Value = "TextBox"
                i += 1
            Next
            Me.CargarComboGDV(dgvcampo.Columns(4))
            'Me.cargarVisualizacion()
        End If
    End Sub

    'Private Sub cargarVisualizacion()
    '    Dim path As String = GetCurrentDirectory() & "\tempXXX"
    '    If (Exists(path)) Then
    '        Delete(path)
    '    End If

    '    CreateDirectory(path)

    '    ' crea todo el formulario
    '    Me.CrearFormulariosCSharp(path)
    '    Me.CrearClaseCSharp(path)
    '    Me.crearComponentesCSharp(path)


    'End Sub

    Private Sub btnCargarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ComboBox1.Items.Clear()
        Me.cargartablas()
        yacargo = True
    End Sub

    Private Sub btnGenerarClase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarClase.Click
        If MessageBox.Show("¿ Confirma crear el Formulario " & Me.ComboBox1.Text, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

            If varLenguaje = VISUAL_BASIC Then
                generarEnVisual()
            Else
                generarEnCSharp()
            End If
        End If
    End Sub

    Private Sub generarEnCSharp()
        Me.CrearFormulariosCSharp(Me.txbRuta.Text)
        Me.CrearClaseCSharp(Me.txbRuta.Text)
        Me.crearComponentesCSharp(Me.txbRuta.Text)
        Me.crearClaseCrlCSharp(Me.TxbRutaCtrl.Text)
        MessageBox.Show("El Formulario " & Me.ComboBox1.Text & " se Creo Correctamente", "Confirmacion")
    End Sub

#Region "Metodos Formularios en C#"
    Private Sub CrearFormulariosCSharp(ByVal Ruta As String)
        Dim archivo As String
        'Valida si Existe el archivo
        If Mid$(Me.ComboBox1.Text, Len(Me.ComboBox1.Text) - 3, 3) <> ".resx" Then
            'crea un nuevo archivo 
            archivo = Ruta & "\Frm" & Me.ComboBox1.Text & ".resx"
        Else
            'Sobreescribe el archivo
            archivo = Ruta & "\Frm" & Me.ComboBox1.Text

        End If

        Dim libre As String = FreeFile()
        'Abre el archivo de Texto
        FileOpen(libre, archivo, OpenMode.Output)
        'escribe el codigo para generar el form
        PrintLine(libre, "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "utf-8" & Chr(34) & "?>")
        PrintLine(libre, "<root>")
        PrintLine(libre, TAB(3), "<!--")
        PrintLine(libre, TAB(5), "Microsoft ResX Schema")
        PrintLine(libre, "")
        PrintLine(libre, TAB(5), "Version 2.0")
        PrintLine(libre, "")
        PrintLine(libre, TAB(5), "The primary goals of this format is to allow a simple XML format")
        PrintLine(libre, TAB(5), "that is mostly human readable. The generation and parsing of the")
        PrintLine(libre, TAB(5), "various data types are done through the TypeConverter classes")
        PrintLine(libre, TAB(5), "associated with the data types.")
        PrintLine(libre, "")
        PrintLine(libre, TAB(5), "Example:")
        PrintLine(libre, "")
        PrintLine(libre, TAB(5), "... ado.net/XML headers & schema ...")
        PrintLine(libre, TAB(5), "<resheader name=" & Chr(34) & "resmimetype" & Chr(34) & ">text/microsoft-resx</resheader>")
        PrintLine(libre, TAB(5), "<resheader name=" & Chr(34) & "version" & Chr(34) & ">2.0</resheader>")
        PrintLine(libre, TAB(5), "<resheader name=" & Chr(34) & "reader" & Chr(34) & ">System.Resources.ResXResourceReader, System.Windows.Forms, ...</resheader>")
        PrintLine(libre, TAB(5), "<resheader name=" & Chr(34) & "writer" & Chr(34) & ">System.Resources.ResXResourceWriter, System.Windows.Forms, ...</resheader>")
        PrintLine(libre, TAB(5), "<data name=" & Chr(34) & "Name1" & Chr(34) & "><value>this is my long string</value><comment>this is a comment</comment></data>")
        PrintLine(libre, TAB(5), "<data name=" & Chr(34) & "Color1" & Chr(34) & " type=" & Chr(34) & "System.Drawing.Color, System.Drawing" & Chr(34) & ">Blue</data>")
        PrintLine(libre, TAB(5), "<data name=" & Chr(34) & "Bitmap1" & Chr(34) & "mimetype=" & Chr(34) & "application/x-microsoft.net.object.binary.base64" & Chr(34) & ">")
        PrintLine(libre, TAB(9), "<value>[base64 mime encoded serialized .NET Framework object]</value>")
        PrintLine(libre, TAB(5), "</data>")
        PrintLine(libre, TAB(5), "<data name=" & Chr(34) & "Icon1" & Chr(34) & " type=" & Chr(34) & "System.Drawing.Icon, System.Drawing" & Chr(34) & " mimetype=" & Chr(34) & "application/x-microsoft.net.object.bytearray.base64" & Chr(34) & ">")
        PrintLine(libre, TAB(9), "<value>[base64 mime encoded string representing a byte array form of the .NET Framework object]</value>")
        PrintLine(libre, TAB(9), "<comment>This is a comment</comment>")
        PrintLine(libre, TAB(5), "</data>")
        PrintLine(libre, "")
        PrintLine(libre, TAB(5), "There are any number of " & Chr(34) & "resheader" & Chr(34) & " rows that contain simple")
        PrintLine(libre, TAB(5), "name/value pairs.")
        PrintLine(libre, "")
        PrintLine(libre, TAB(5), "Each data row contains a name, and value. The row also contains a")
        PrintLine(libre, TAB(5), "type or mimetype. Type corresponds to a .NET class that support")
        PrintLine(libre, TAB(5), "text/value conversion through the TypeConverter architecture.")
        PrintLine(libre, TAB(5), "Classes that don't support this are serialized and stored with the")
        PrintLine(libre, TAB(5), "mimetype set.")
        PrintLine(libre, "")
        PrintLine(libre, TAB(5), "The mimetype is used for serialized objects, and tells the")
        PrintLine(libre, TAB(5), "ResXResourceReader how to depersist the object. This is currently not")
        PrintLine(libre, TAB(5), "extensible. For a given mimetype the value must be set accordingly:")
        PrintLine(libre, "")
        PrintLine(libre, TAB(5), "Note - application/x-microsoft.net.object.binary.base64 is the format")
        PrintLine(libre, TAB(5), "that the ResXResourceWriter will generate, however the reader can")
        PrintLine(libre, TAB(5), "read any of the formats listed below.")
        PrintLine(libre, "")
        PrintLine(libre, TAB(5), "mimetype: application/x-microsoft.net.object.binary.base64")
        PrintLine(libre, TAB(5), "value   : The object must be serialized with")
        PrintLine(libre, TAB(13), ": System.Runtime.Serialization.Formatters.Binary.BinaryFormatter")
        PrintLine(libre, TAB(13), ": and then encoded with base64 encoding.")
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "mimetype: application/x-microsoft.net.object.soap.base64")
        PrintLine(libre, TAB(5), "value   : The object must be serialized with")
        PrintLine(libre, TAB(13), ": System.Runtime.Serialization.Formatters.Soap.SoapFormatter")
        PrintLine(libre, TAB(13), ": and then encoded with base64 encoding.")
        PrintLine(libre, "")
        PrintLine(libre, TAB(5), "mimetype: application/x-microsoft.net.object.bytearray.base64")
        PrintLine(libre, TAB(5), "value   : The object must be serialized into a byte array")
        PrintLine(libre, TAB(13), ": using a System.ComponentModel.TypeConverter")
        PrintLine(libre, TAB(13), ": and then encoded with base64 encoding.")
        PrintLine(libre, TAB(5), "-->")
        PrintLine(libre, TAB(3), "<xsd:schema id=" & Chr(34) & "root" & Chr(34) & " xmlns=" & Chr(34) & Chr(34) & " xmlns:xsd=" & Chr(34) & "http://www.w3.org/2001/XMLSchema" & Chr(34) & " xmlns:msdata=" & Chr(34) & "urn:schemas-microsoft-com:xml-msdata" & Chr(34) & ">")
        PrintLine(libre, TAB(5), "<xsd:import namespace=" & Chr(34) & "http://www.w3.org/XML/1998/namespace" & Chr(34) & " />")
        PrintLine(libre, TAB(5), "<xsd:element name=" & Chr(34) & "root" & Chr(34) & " msdata:IsDataSet=" & Chr(34) & "true" & Chr(34) & ">")
        PrintLine(libre, TAB(7), "<xsd:complexType>")
        PrintLine(libre, TAB(9), "<xsd:choice maxOccurs=" & Chr(34) & "unbounded" & Chr(34) & ">")
        PrintLine(libre, TAB(11), "<xsd:element name=" & Chr(34) & "metadata" & Chr(34) & ">")
        PrintLine(libre, TAB(13), "<xsd:complexType>")
        PrintLine(libre, TAB(15), "<xsd:sequence>")
        PrintLine(libre, TAB(17), "<xsd:element name=" & Chr(34) & "value" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " minOccurs=" & Chr(34) & "0" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "</xsd:sequence>")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "name" & Chr(34) & " use=" & Chr(34) & "required" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "type" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "mimetype" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "<xsd:attribute ref=" & Chr(34) & "xml:space" & Chr(34) & " />")
        PrintLine(libre, TAB(13), "</xsd:complexType>")
        PrintLine(libre, TAB(11), "</xsd:element>")
        PrintLine(libre, TAB(11), "<xsd:element name=" & Chr(34) & "assembly" & Chr(34) & ">")
        PrintLine(libre, TAB(13), "<xsd:complexType>")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "alias" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "name" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " />")
        PrintLine(libre, TAB(13), "</xsd:complexType>")
        PrintLine(libre, TAB(11), "</xsd:element>")
        PrintLine(libre, TAB(11), "<xsd:element name=" & Chr(34) & "data" & Chr(34) & ">")
        PrintLine(libre, TAB(13), "<xsd:complexType>")
        PrintLine(libre, TAB(15), "<xsd:sequence>")
        PrintLine(libre, TAB(17), "<xsd:element name=" & Chr(34) & "value" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " minOccurs=" & Chr(34) & "0" & Chr(34) & " msdata:Ordinal=" & Chr(34) & "1" & Chr(34) & " />")
        PrintLine(libre, TAB(17), "<xsd:element name=" & Chr(34) & "comment" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " minOccurs=" & Chr(34) & "0" & Chr(34) & " msdata:Ordinal=" & Chr(34) & "2" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "</xsd:sequence>")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "name" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " use=" & Chr(34) & "required" & Chr(34) & " msdata:Ordinal=" & Chr(34) & "1" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "type" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " msdata:Ordinal=" & Chr(34) & "3" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "mimetype" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " msdata:Ordinal=" & Chr(34) & "4" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "<xsd:attribute ref=" & Chr(34) & "xml:space" & Chr(34) & " />")
        PrintLine(libre, TAB(13), "</xsd:complexType>")
        PrintLine(libre, TAB(11), "</xsd:element>")
        PrintLine(libre, TAB(11), "<xsd:element name=" & Chr(34) & "resheader" & Chr(34) & ">")
        PrintLine(libre, TAB(13), "<xsd:complexType>")
        PrintLine(libre, TAB(15), "<xsd:sequence>")
        PrintLine(libre, TAB(17), "<xsd:element name=" & Chr(34) & "value" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " minOccurs=" & Chr(34) & "0" & Chr(34) & " msdata:Ordinal=" & Chr(34) & "1" & Chr(34) & " />")
        PrintLine(libre, TAB(15), "</xsd:sequence>")
        PrintLine(libre, TAB(15), "<xsd:attribute name=" & Chr(34) & "name" & Chr(34) & " type=" & Chr(34) & "xsd:string" & Chr(34) & " use=" & Chr(34) & "required" & Chr(34) & " />")
        PrintLine(libre, TAB(13), "</xsd:complexType>")
        PrintLine(libre, TAB(11), "</xsd:element>")
        PrintLine(libre, TAB(9), "</xsd:choice>")
        PrintLine(libre, TAB(7), "</xsd:complexType>")
        PrintLine(libre, TAB(5), "</xsd:element>")
        PrintLine(libre, TAB(3), "</xsd:schema>")
        PrintLine(libre, TAB(3), "<resheader name=" & Chr(34) & "resmimetype" & Chr(34) & ">")
        PrintLine(libre, TAB(5), "<value>text/microsoft-resx</value>")
        PrintLine(libre, TAB(3), "</resheader>")
        PrintLine(libre, TAB(3), "<resheader name=" & Chr(34) & "version" & Chr(34) & ">")
        PrintLine(libre, TAB(5), "<value>2.0</value>")
        PrintLine(libre, TAB(3), "</resheader>")
        PrintLine(libre, TAB(3), "<resheader name=" & Chr(34) & "reader" & Chr(34) & ">")
        PrintLine(libre, TAB(5), "<value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>")
        PrintLine(libre, TAB(3), "</resheader>")
        PrintLine(libre, TAB(3), "<resheader name=" & Chr(34) & "writer" & Chr(34) & ">")
        PrintLine(libre, TAB(5), "<value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>")
        PrintLine(libre, TAB(3), "</resheader>")
        PrintLine(libre, "</root>")

        'Cierra el Archivo
        FileClose(libre)
    End Sub

    Private Sub CrearClaseCSharp(ByVal ruta As String)
        Dim archivo As String
        'Valida si Existe el archivo
        If Mid$(Me.ComboBox1.Text, Len(Me.ComboBox1.Text) - 3, 3) <> ".cs" Then
            'crea un nuevo archivo 
            archivo = ruta & "\Frm" & Me.ComboBox1.Text & ".cs"
        Else
            'Sobreescribe el archivo
            archivo = ruta & "\Frm" & Me.ComboBox1.Text
        End If

        Dim libre As String = FreeFile()
        Dim reg As regCampo
        Dim strip1 As String
        Me.cargarstring()

        'Abre el archivo de Texto
        FileOpen(libre, archivo, OpenMode.Output)

        PrintLine(libre, "using System;")
        PrintLine(libre, "using System.Collections.Generic;")
        PrintLine(libre, "using System.ComponentModel;")
        PrintLine(libre, "using System.Data;")
        PrintLine(libre, "using System.Drawing;")
        PrintLine(libre, "using System.Text;")
        PrintLine(libre, "using System.Windows.Forms;")
        PrintLine(libre, "")
        PrintLine(libre, "public partial class Frm" & Me.ComboBox1.Text & " : Form")
        PrintLine(libre, "{")

        ' objetos negocio y control
        PrintLine(libre, TAB(5), "Negocio." & ComboBox1.Text & " obj" & ComboBox1.Text & " = new Negocio." & ComboBox1.Text & "();")
        PrintLine(libre, TAB(5), "Negocio.Ctrl" & ComboBox1.Text & " objcontrol = new Negocio.Ctrl" & ComboBox1.Text & "();")

        PrintLine(libre, TAB(5), "")

        PrintLine(libre, TAB(5), "public Frm" & Me.ComboBox1.Text & "()")
        PrintLine(libre, TAB(5), "{")
        PrintLine(libre, TAB(9), "InitializeComponent();")
        PrintLine(libre, TAB(5), "}")


        '---------------------------------------Metodo Guardar
        PrintLine(libre, TAB(5), "public void guardar()")
        PrintLine(libre, TAB(5), "{")
        Dim op As Integer = 0
        Dim pos As Integer = 0
        For Each reg In arrEstructura


            Dim valor = dgvcampo.Rows(op).Cells.Item(3).Value.ToString
            If valor = "TextBox" Then
                PrintLine(libre, TAB(9), "obj" & ComboBox1.Text & ".P" & reg.nombre & " = this.txt" & reg.nombre & ".Text;")
            Else
                PrintLine(libre, TAB(9), "obj" & ComboBox1.Text & ".P" & reg.nombre & " = this.cb" & reg.nombre & ".SelectedValue;")

            End If
            op += 1
            pos += 1
        Next

        PrintLine(libre, "")

        PrintLine(libre, TAB(9), " if ( objcontrol.guardar" & ComboBox1.Text & "(obj" & ComboBox1.Text & ") == 1 )")
        PrintLine(libre, TAB(9), "{")
        PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "Se Grabo Exitosamente" & Chr(34) & ");")
        PrintLine(libre, TAB(9), "}")
        PrintLine(libre, TAB(9), "else")
        PrintLine(libre, TAB(9), "{")
        PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "### E R R O R ####" & Chr(34) & ");")
        PrintLine(libre, TAB(9), "}")
        PrintLine(libre, TAB(5), "}")
        '--------------------------------------------------

        '----------------------------------------Metodo Nuevo
        PrintLine(libre, TAB(5), "private void Nuevo()")
        PrintLine(libre, TAB(5), "{")
        op = 0
        For Each reg In arrEstructura
            Dim valor = dgvcampo.Rows(op).Cells.Item(3).Value.ToString
            If valor = "TextBox" Then
                PrintLine(libre, TAB(9), "this.txt" & reg.nombre & ".Clear();")
            End If
            op += 1
        Next
        PrintLine(libre, TAB(5), "}")
        '-----------------------------------------


        'Crear el Evento Load para Cargar Combos
        PrintLine(libre, TAB(5), "private void Frm" & ComboBox1.Text & "_Load(object sender, EventArgs e)")
        PrintLine(libre, TAB(5), "{")
        op = 0
        Dim h As Integer = 0
        Dim combo(pos) As String
        Dim nombre(pos) As String
        Dim j As Integer = 0

        For Each reg In arrEstructura
            'Obtengo el nombre del combobox
            Dim valor0 = dgvcampo.Rows(op).Cells.Item(0).Value.ToString
            Dim valor = dgvcampo.Rows(op).Cells.Item(2).Value.ToString
            Dim valor1 = dgvcampo.Rows(op).Cells.Item(3).Value.ToString
            'Dim objcoombogrid As New DataGridViewComboBoxColumn
            'objcoombogrid = dgvcampo.Rows(op).Cells("tablaenlace")
            Dim valor2 = dgvcampo.Rows(op).Cells.Item(4).Value

            If (valor = "Llave Foranea") And (valor1 = "ComboBox") And (valor2 <> "") Then
                combo(h) = valor2
                PrintLine(libre, TAB(9), "this.CargarCombo" & combo(h) & "();")
                nombre(h) = valor0
                h += 1
                j += 1
            End If
            op += 1
        Next
        PrintLine(libre, TAB(5), "}")
        PrintLine(libre, TAB(5), "")

        'Crear los Metodos del Evento Cargar
        Dim co = 0
        For h = 0 To j - 1
            PrintLine(libre, TAB(5), "'Carga el Combo" & combo(h) & "();")
            PrintLine(libre, TAB(5), "private void CargarCombo" & combo(h) & "()")
            PrintLine(libre, TAB(9), "Negocio." & combo(h) & " obj" & combo(h) & " = New Negocio." & combo(h) & "();")

            For Each reg In arrEstructura
                If nombre(co) = reg.nombre Then
                    PrintLine(libre, TAB(9), "this.cb" & reg.nombre & ".DataSource = obj" & combo(h) & ".Traer_" & combo(h) & "(String.Empty);")
                    PrintLine(libre, TAB(9), "this.cb" & reg.nombre & ".DisplayMember = " & Chr(34) & Chr(34) & ";")
                    PrintLine(libre, TAB(9), "this.cb" & reg.nombre & ".ValueMember = " & Chr(34) & Chr(34) & ";")

                End If
            Next
            co += 1
            'Me.ComboBox1.DataSource = objcategoria.Traer_Categoria(String.Empty)
            ' ComboBox1.DisplayMember = "NombreCategoria"
            'ComboBox1.ValueMember = "idcategoria"
            PrintLine(libre, TAB(5), "}")
            PrintLine(libre, TAB(5), "")
            ' PrintLine(libre, TAB(5), reg.nombre)


        Next





        '----------------------------------------Metodo Modificar
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "private void Modificar()")
        PrintLine(libre, TAB(5), "{")
        op = 0
        For Each reg In arrEstructura
            Dim valor = dgvcampo.Rows(op).Cells.Item(3).Value.ToString
            If valor = "TextBox" Then
                PrintLine(libre, TAB(9), "obj" & ComboBox1.Text & ".P" & reg.nombre & " = this.txt" & reg.nombre & ".Text;")
            Else
                PrintLine(libre, TAB(9), "obj" & ComboBox1.Text & ".P" & reg.nombre & " = this.cb" & reg.nombre & ".SelectedValue;")

            End If
            op += 1
        Next

        PrintLine(libre, TAB(9), " if ( objcontrol.modificar" & ComboBox1.Text & "(obj" & ComboBox1.Text & ") = 1 )")
        PrintLine(libre, TAB(9), "{")
        PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "Se Grabo Exitosamente" & Chr(34) & ");")
        PrintLine(libre, TAB(9), "}")
        PrintLine(libre, TAB(9), "else")
        PrintLine(libre, TAB(9), "{")
        PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "### E R R O R ####" & Chr(34) & ");")
        PrintLine(libre, TAB(9), "}")
        PrintLine(libre, TAB(5), "}")
        PrintLine(libre, TAB(5), "")

        '----------------------------------------Metodo Imprimir
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "private void Imprimir()")
        PrintLine(libre, TAB(9), "{")
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(9), "}")
        PrintLine(libre, TAB(5), "")

        '---------------------------------------Metodo Salir
        PrintLine(libre, TAB(5), "private void Salir()")
        PrintLine(libre, TAB(5), "{")
        PrintLine(libre, TAB(9), "this.Close();")
        PrintLine(libre, TAB(5), "}")
        PrintLine(libre, TAB(5), "")
        '---------------------------------Eventos del Toolstrip
        For Each strip1 In arrstring
            PrintLine(libre, TAB(5), "private void TSG" & strip1 & "_Click(object sender, EventArgs e)")
            PrintLine(libre, TAB(5), "{")
            PrintLine(libre, TAB(9), "this." & strip1 & "();")
            PrintLine(libre, TAB(5), "}")
            PrintLine(libre, TAB(5), "")
        Next

        PrintLine(libre, TAB(5), "")
        PrintLine(libre, "}")
        'Cierra el Archivo
        FileClose(libre)
    End Sub

    Private Sub crearComponentesCSharp(ByVal Ruta As String)
        Dim archivo As String
        'Valida si Existe el archivo
        If Mid$(Me.ComboBox1.Text, Len(Me.ComboBox1.Text) - 3, 3) <> ".Designer.cs" Then
            'crea un nuevo archivo 
            archivo = Ruta & "\Frm" & Me.ComboBox1.Text & ".Designer.cs"
        Else
            'Sobreescribe el archivo
            archivo = Ruta & "\Frm" & Me.ComboBox1.Text
        End If

        Dim libre As String = FreeFile()
        Dim reg As regCampo
        Dim i, j, x, y As Integer
        x = 90
        y = 70
        i = 200
        j = 70
        'Abre el archivo de Texto
        FileOpen(libre, archivo, OpenMode.Output)


        PrintLine(libre, "partial class Frm" & Me.ComboBox1.Text)
        PrintLine(libre, "{")
        PrintLine(libre, "")
        PrintLine(libre, TAB(5), "/// <summary>")
        PrintLine(libre, TAB(5), "/// Variable del diseñador requerida.")
        PrintLine(libre, TAB(5), "/// </summary>")
        PrintLine(libre, TAB(5), "private System.ComponentModel.IContainer components = null;")
        PrintLine(libre, "")
        PrintLine(libre, TAB(5), "/// <summary>")
        PrintLine(libre, TAB(5), "/// Limpiar los recursos que se estén utilizando.")
        PrintLine(libre, TAB(5), "/// </summary>")
        PrintLine(libre, TAB(5), "/// <param name=" & Chr(34) & Disposing & Chr(34) & ">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>")
        PrintLine(libre, TAB(5), "protected override void Dispose(bool disposing)")
        PrintLine(libre, TAB(5), "{")
        PrintLine(libre, TAB(9), "if (disposing && (components != null))")
        PrintLine(libre, TAB(9), "{")
        PrintLine(libre, TAB(13), "components.Dispose();")
        PrintLine(libre, TAB(9), "}")
        PrintLine(libre, TAB(9), "base.Dispose(disposing);")
        PrintLine(libre, TAB(5), "}")
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), " #region Código generado por el Diseñador de Windows Forms")
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "/// <summary>")
        PrintLine(libre, TAB(5), "/// Método necesario para admitir el Diseñador. No se puede modificar")
        PrintLine(libre, TAB(5), "/// el contenido del método con el editor de código.")
        PrintLine(libre, TAB(5), "/// </summary>")
        PrintLine(libre, TAB(5), "private void InitializeComponent()")
        PrintLine(libre, TAB(5), "{")
        PrintLine(libre, TAB(5), "System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(GetType(Frm" & ComboBox1.Text & "));")

        Dim uno As Integer = 0
        For Each reg In arrEstructura
            Dim valor = dgvcampo.Rows(uno).Cells.Item(3).Value.ToString
            If valor = "TextBox" Then
                PrintLine(libre, TAB(9), "this.txt" & reg.nombre & " = new System.Windows.Forms.TextBox();")
            Else
                PrintLine(libre, TAB(9), "this.cb" & reg.nombre & " = new System.Windows.Forms.ComboBox();")
            End If
            uno += 1
        Next

        For Each reg In arrEstructura
            PrintLine(libre, TAB(9), "this.lb" & reg.nombre & " = new System.Windows.Forms.Label();")
        Next

        PrintLine(libre, TAB(9), "this.ToolStrip1 = new System.Windows.Forms.ToolStrip();")
        'TS Significa ToolStrip
        'Agregar Botonoes al ToolsTrip
        Dim Strip1 = "Nuevo"
        Dim Strip2 = "Guardar"
        Dim Strip3 = "Modificar"
        Dim Strip4 = "Imprimir"
        Dim Strip5 = "Salir"
        cargarstring()
        Dim Strip As String

        For Each Strip In arrstring
            PrintLine(libre, TAB(9), "this.TS" & Strip & " = new System.Windows.Forms.ToolStripButton();")
        Next

        PrintLine(libre, TAB(9), "this.ToolStrip1.SuspendLayout();")
        PrintLine(libre, TAB(9), "this.SuspendLayout();")
        'Crear TextBox en el Formulario
        Dim dos As Integer = 0
        For Each reg In arrEstructura
            Dim valor = dgvcampo.Rows(dos).Cells.Item(3).Value.ToString

            If valor = "TextBox" Then
                PrintLine(libre, TAB(9), "//")
                PrintLine(libre, TAB(9), "//txt" & reg.nombre)
                PrintLine(libre, TAB(9), "//")
                PrintLine(libre, TAB(9), "this.txt" & reg.nombre & ".Location = new System.Drawing.Point(" & i & "," & j & ");")
                PrintLine(libre, TAB(9), "this.txt" & reg.nombre & ".Name = " & Chr(34) & "txt" & reg.nombre & Chr(34) & ";")
                PrintLine(libre, TAB(9), "this.txt" & reg.nombre & ".Size = new System.Drawing.Size(137, 20);")
                PrintLine(libre, TAB(9), "this.txt" & reg.nombre & ".TabIndex = 26;")
            Else
                PrintLine(libre, TAB(9), "//")
                PrintLine(libre, TAB(9), "//cb" & reg.nombre)
                PrintLine(libre, TAB(9), "//")
                PrintLine(libre, TAB(9), "this.cb" & reg.nombre & ".FormattingEnabled = true;")
                PrintLine(libre, TAB(9), "this.cb" & reg.nombre & ".Location = new System.Drawing.Point(" & i & "," & j & ");")
                PrintLine(libre, TAB(9), "this.cb" & reg.nombre & ".Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);")
                PrintLine(libre, TAB(9), "this.cb" & reg.nombre & ".Name = " & Chr(34) & "cb" & reg.nombre & Chr(34) & ";")
                PrintLine(libre, TAB(9), "this.cb" & reg.nombre & ".Size = new System.Drawing.Size(137, 20);")
                PrintLine(libre, TAB(9), "this.cb" & reg.nombre & ".TabIndex = 26;")
            End If
            ' Creo la variable local para usarse con la propiedad
            j += 30
            dos += 1
        Next

        'Crear Label en el Formulario
        For Each reg In arrEstructura
            ' Creo la variable local para usarse con la propiedad
            PrintLine(libre, TAB(9), "//")
            PrintLine(libre, TAB(9), "//lb" & reg.nombre)
            PrintLine(libre, TAB(9), "//")
            PrintLine(libre, TAB(9), "this.lb" & reg.nombre & ".AutoSize = true;")
            PrintLine(libre, TAB(9), "this.lb" & reg.nombre & ".Location = new System.Drawing.Point(" & x & "," & y & ");")
            PrintLine(libre, TAB(9), "this.lb" & reg.nombre & ".Name = " & Chr(34) & "lb" & reg.nombre & Chr(34) & ";")
            PrintLine(libre, TAB(9), "this.lb" & reg.nombre & ".Size = new System.Drawing.Size(137, 20);")
            PrintLine(libre, TAB(9), "this.lb" & reg.nombre & ".TabIndex = 26;")
            PrintLine(libre, TAB(9), "this.lb" & reg.nombre & ".Text = " & Chr(34) & reg.nombre & Chr(34) & ";")
            y += 30
        Next

        'Se Crea el Componente ToolStrip
        PrintLine(libre, TAB(9), "//")
        PrintLine(libre, TAB(9), "//ToolStrip1")
        PrintLine(libre, TAB(9), "//")
        PrintLine(libre, TAB(9), "this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;")
        PrintLine(libre, TAB(9), "this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.TS" & Strip1 & ", this.TS" & Strip2 & ", this.TS" & Strip3 & ", this.TS" & Strip4 & ", this.TS" & Strip5 & "});")
        PrintLine(libre, TAB(9), "this.ToolStrip1.Location = new System.Drawing.Point(0, 173);")
        PrintLine(libre, TAB(9), "this.ToolStrip1.Name = " & Chr(34) & "ToolStrip1" & Chr(34) & ";")
        PrintLine(libre, TAB(9), " this.ToolStrip1.Size = new System.Drawing.Size(336, 25);")
        PrintLine(libre, TAB(9), "this.ToolStrip1.TabIndex = 6;")
        PrintLine(libre, TAB(9), "this.ToolStrip1.Text = " & Chr(34) & "ToolStrip1" & Chr(34) & ";")

        'Agregando Caracteristicas al ToolStrip Principal
        For Each Strip In arrstring
            PrintLine(libre, TAB(9), " //")
            PrintLine(libre, TAB(9), "//TS" & Strip)
            PrintLine(libre, TAB(9), "//")
            '*********FALTA CTYPE EN C#
            PrintLine(libre, TAB(9), "this.TS" & Strip & ".Image = (System.Drawing.Image) resources.GetObject(" & Chr(34) & "TS" & Strip & ".Image" & Chr(34) & ") ;")
            PrintLine(libre, TAB(9), "this.TS" & Strip & ".ImageTransparentColor = System.Drawing.Color.Magenta;")
            PrintLine(libre, TAB(9), "this.TS" & Strip & ".Name = " & Chr(34) & "TS" & Strip & Chr(34) & ";")
            PrintLine(libre, TAB(9), "this.TS" & Strip & ".Size = new System.Drawing.Size(58, 22);")
            PrintLine(libre, TAB(9), "this.TS" & Strip & ".Text = " & Chr(34) & Strip & Chr(34) & ";")
            PrintLine(libre, TAB(9), "this.TS" & Strip & ".Click += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TSG" & Strip & "_Click);")
        Next


        PrintLine(libre, TAB(9), "//")
        PrintLine(libre, TAB(9), "//Frm" & Me.ComboBox1.Text)
        PrintLine(libre, TAB(9), "//")
        PrintLine(libre, TAB(9), "this.AutoScaleDimensions = new System.Drawing.SizeF(6.0f, 13.0f);")
        PrintLine(libre, TAB(9), "this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;")
        PrintLine(libre, TAB(9), "this.ClientSize = new System.Drawing.Size(500, 500);")
        PrintLine(libre, TAB(9), "this.Controls.Add(this.ToolStrip1);")
        Dim tres As Integer = 0
        For Each reg In arrEstructura
            Dim valor = dgvcampo.Rows(tres).Cells.Item(3).Value.ToString
            If valor = "TextBox" Then
                PrintLine(libre, TAB(9), "this.Controls.Add(this.txt" & reg.nombre & ");")
            Else

                PrintLine(libre, TAB(9), "this.Controls.Add(this.cb" & reg.nombre & ");")
            End If
            tres += 1
        Next

        For Each reg In arrEstructura
            PrintLine(libre, TAB(9), "this.Controls.Add(this.lb" & reg.nombre & ");")
            x += 1
        Next

        PrintLine(libre, TAB(9), "this.Name = " & Chr(34) & "Frm" & Me.ComboBox1.Text & Chr(34) & ";")
        PrintLine(libre, TAB(9), "this.Text = " & Chr(34) & "Frm" & Me.ComboBox1.Text & Chr(34) & ";")
        PrintLine(libre, TAB(9), "this.Load += new System.EventHandler(this.Frm" & ComboBox1.Text & "_Load);")
        PrintLine(libre, TAB(9), "this.ToolStrip1.ResumeLayout(false);")
        PrintLine(libre, TAB(9), "this.ToolStrip1.PerformLayout();")
        PrintLine(libre, TAB(9), "this.ResumeLayout(false);")
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "}")
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "#endregion")

        'Crea Label
        For Each reg In arrEstructura
            PrintLine(libre, TAB(5), "private System.Windows.Forms.Label lb" & reg.nombre & ";")
        Next
        'Crea Button
        Dim cuatro As Integer
        For Each reg In arrEstructura
            Dim valor = dgvcampo.Rows(cuatro).Cells.Item(3).Value.ToString
            If valor = "TextBox" Then
                PrintLine(libre, TAB(5), "private System.Windows.Forms.TextBox txt" & reg.nombre & ";")
            Else
                PrintLine(libre, TAB(5), "private System.Windows.Forms.ComboBox cb" & reg.nombre & ";")
            End If
            cuatro += 1
        Next

        'ToolStrip1
        PrintLine(libre, TAB(5), "private System.Windows.Forms.ToolStrip ToolStrip1;")

        'Botones del ToolStrip1
        For Each Strip In arrstring
            PrintLine(libre, TAB(5), "private System.Windows.Forms.ToolStrip TS" & Strip & ";")

        Next
        PrintLine(libre, "}")
        'Cierra el Archivo
        FileClose(libre)
    End Sub

    Private Sub crearClaseCrlCSharp(ByVal Ruta As String)
        Dim archivo As String
        'Valida si Existe el archivo
        If Mid$(Me.ComboBox1.Text, Len(Me.ComboBox1.Text) - 3, 3) <> ".cs" Then
            'crea un nuevo archivo 
            archivo = Ruta & "\Ctrl" & Me.ComboBox1.Text & ".cs"
        Else
            'Sobreescribe el archivo
            archivo = Ruta & "\Ctrl" & Me.ComboBox1.Text
        End If

        Dim libre As String = FreeFile()
        FileOpen(libre, archivo, OpenMode.Output)

        PrintLine(libre, "public class Ctrl" & ComboBox1.Text)
        PrintLine(libre, "{")
        PrintLine(libre, TAB(4), "public int guardar" & ComboBox1.Text & " (" & " Negocio." & ComboBox1.Text & "obj" & ComboBox1.Text & ")")
        PrintLine(libre, TAB(4), "{")
        PrintLine(libre, TAB(8), "return obj" & ComboBox1.Text & ".guardar();")
        PrintLine(libre, TAB(4), "}")
        PrintLine(libre, TAB(4), "")
        PrintLine(libre, TAB(4), "")
        PrintLine(libre, TAB(4), "public int modificar" & ComboBox1.Text & " (" & " Negocio." & ComboBox1.Text & "obj" & ComboBox1.Text & ")")
        PrintLine(libre, TAB(4), "{")
        PrintLine(libre, TAB(8), "return obj" & ComboBox1.Text & ".modificar();")
        PrintLine(libre, TAB(4), "}")
        PrintLine(libre, "}")
        FileClose(libre)
    End Sub
#End Region

    Private Sub generarEnVisual()
        Me.CrearFormularios(Me.txbRuta.Text)
        Me.Crearclase(Me.txbRuta.Text)
        Me.crearComponentes(Me.txbRuta.Text)
        Me.crearClaseCrl(Me.TxbRutaCtrl.Text)
        MessageBox.Show("El Formulario " & Me.ComboBox1.Text & " se Creo Correctamente", "Confirmacion")
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        txbRuta.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FolderBrowserDialog1.ShowDialog()
        Me.TxbRutaCtrl.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' txtCadena.SelectAll()
        If Utilitarios.servidor = String.Empty Then
            MsgBox("Configure los datos del servidor...", MsgBoxStyle.Information)
        Else
            Me.txtdb.Text = Utilitarios.Basededatos
            Me.txtserver.Text = Utilitarios.servidor
            Me.cargartablas()
        End If

        cmbLenguaje.SelectedIndex = 0

        ' Generar Tablas
        Button2_Click(Me, New EventArgs())

        ' carga los registros en dataGridView
        ComboBox1_SelectedIndexChanged(Me, New EventArgs())

        ' mantieneBackColor()
    End Sub

    Private Sub mantieneBackColor()
        Dim cli As New MdiClient()
        For Each c As Control In Me.Controls
            If (c.GetType() Is cli.GetType()) Then
                c.BackColor = Me.BackColor
            End If
        Next
    End Sub

    Private Sub DockControl2_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DockControl2.Closing

    End Sub

    Private Sub cmbLenguaje_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLenguaje.SelectedIndexChanged
       varLenguaje = cmbLenguaje.SelectedIndex
    End Sub

End Class
