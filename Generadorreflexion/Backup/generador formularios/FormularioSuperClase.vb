Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class FormularioSuperClase

    Private da As OleDbDataAdapter
    Private ds As DataSet
    Private conexion As OleDbConnection
    Private t As New conexion

    Const VISUAL_BASIC As Byte = 0
    Const C_SHARP As Byte = 1
    Private varLenguaje As Byte = VISUAL_BASIC

    Structure regCampo
        Dim nombre As String
        Dim tipo As String
    End Structure
    'Vector de Tipo RegCampo
    Dim arrEstructura() As regCampo


    Structure subtabla
        Dim nombre As String
    End Structure
    Dim tablas() As subtabla

    Private Sub CargarGrillaTabla()
        dgvtabla.RowCount = 0
        Dim nomtablas() As String
        Dim i, j As Integer
        nomtablas = Me.nombrestablas()
        If Not nomtablas Is Nothing Then
            For i = 0 To nomtablas.Length - 1
                If Me.ComboBox1.Text <> nomtablas(i) Then
                    dgvtabla.Rows.Add()
                    dgvtabla.Rows(j).Cells("tabla").Value = nomtablas(i)
                    j += 1
                End If

            Next
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ComboBox1.Items.Clear()
        Me.cargartablas()
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

    Function nombrestablas() As String()
        Try
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
        Catch ex As Exception
            MsgBox("Error de conexion al servidor")
        End Try

    End Function

    Private Sub CrearFormularios(ByVal Ruta As String)
        Dim archivo As String
        'Valida si Existe el archivo
        If Mid$(Me.ComboBox1.Text, Len(Me.ComboBox1.Text) - 3, 3) <> ".resx" Then
            'crea un nuevo archivo 
            archivo = Ruta & "\FrmSuper" & Me.ComboBox1.Text & ".resx"
        Else
            'Sobreescribe el archivo
            archivo = Ruta & "\FrmSuper" & Me.ComboBox1.Text

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

    Private Sub TablaHijo(ByVal valor)
        Dim cadenita As String
        cadenita = "packet size=4096;integrated security=SSPI;data source=" & Me.txtserver.Text & ";persist security info=False;initial catalog=" & Me.txtdb.Text
        Dim cn As New SqlConnection(cadenita)
        Dim da As New SqlDataAdapter("SELECT * FROM [" & valor & "]", cn) ' los [] ban por si es una tabla de nombre compuesto
        Dim cb As New SqlCommandBuilder(da)
        Dim ds As New DataSet

        Dim dc As DataColumn

        da.Fill(ds, "tabla")
        Dim indice As Short
        indice = 0
        ReDim tablas(ds.Tables("tabla").Columns.Count() - 1)
        For Each dc In ds.Tables("tabla").Columns()
            ' Guardo el nombre y tipo de cada uno de los campos
            ' La fórmula en el tipo es para eliminar el "system." si llegase a aparecer
            tablas(indice).nombre = dc.ColumnName.ToString
            ' Incremento la posisión dentro del array
            indice = indice + 1
        Next
    End Sub



    Private Sub crearComponentes(ByVal Ruta As String)
        Dim archivo As String
        'Valida si Existe el archivo
        If Mid$(Me.ComboBox1.Text, Len(Me.ComboBox1.Text) - 3, 3) <> ".Designer.vb" Then
            'crea un nuevo archivo 
            archivo = Ruta & "\FrmSuper" & Me.ComboBox1.Text & ".Designer.vb"
        Else
            'Sobreescribe el archivo
            archivo = Ruta & "\FrmSuper" & Me.ComboBox1.Text
        End If

        Dim libre As String = FreeFile()
        Dim reg As regCampo
        Dim i, j, x, y, p As Integer
        x = 90
        y = 30
        p = 200
        j = 30
        'Abre el archivo de Texto
        FileOpen(libre, archivo, OpenMode.Output)

        PrintLine(libre, "<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _")
        PrintLine(libre, "Partial Class FrmSuper" & Me.ComboBox1.Text)
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
        PrintLine(libre, TAB(5), "Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSuper" & ComboBox1.Text & "))")
        cargarAtributos()
        'Declarar un variable de Tipo vector cargo todos las tablas tikeadas
        'del datagridview
        'Dim algo As String = 
        Dim tikeada(50)
        Dim tik = 0
        For i = 0 To dgvtabla.RowCount - 1
            If dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                Dim nombretabla = dgvtabla.Rows(i).Cells.Item(0).Value.ToString()
                tikeada(tik) = nombretabla
                tik += 1
            End If
        Next
        Dim valtabla As subtabla

        For Each reg In arrEstructura
            PrintLine(libre, TAB(9), "Me.txt" & reg.nombre & " = New System.Windows.Forms.TextBox")
        Next

        For Each reg In arrEstructura
            PrintLine(libre, TAB(9), "Me.lb" & reg.nombre & " = New System.Windows.Forms.Label")
        Next
        Dim n = 0
        For i = 0 To tik - 1
            TablaHijo(tikeada(i))
            For Each valtabla In tablas
                PrintLine(libre, TAB(9), "Me.txt" & valtabla.nombre & n & " = New System.Windows.Forms.TextBox")
                PrintLine(libre, TAB(9), "Me.lb" & valtabla.nombre & n & " = New System.Windows.Forms.Label")
            Next

            PrintLine(libre, TAB(9), "Me.TabP" & tikeada(i) & " = New System.Windows.Forms.TabPage")
            n += 1
        Next
        PrintLine(libre, TAB(9), "")

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
        PrintLine(libre, TAB(9), "Me.TabControl1 = New System.Windows.Forms.TabControl")


        PrintLine(libre, TAB(9), "Me.TabControl1.SuspendLayout()")
        For i = 0 To tik - 1
            PrintLine(libre, TAB(9), "Me.TabP" & tikeada(i) & ".SuspendLayout()")
        Next
        PrintLine(libre, TAB(9), "")
        PrintLine(libre, TAB(9), "Me.ToolStrip1.SuspendLayout()")
        PrintLine(libre, TAB(9), "Me.SuspendLayout()")
        'Crear TextBox en el Formulario
        Dim dos As Integer = 0
        For Each reg In arrEstructura
            PrintLine(libre, TAB(9), "'")
            PrintLine(libre, TAB(9), "'txt" & reg.nombre)
            PrintLine(libre, TAB(9), "'")
            PrintLine(libre, TAB(9), "Me.txt" & reg.nombre & ".Location = New System.Drawing.Point(" & p & "," & j & ")")
            PrintLine(libre, TAB(9), "Me.txt" & reg.nombre & ".Name = " & Chr(34) & "txt" & reg.nombre & Chr(34))
            PrintLine(libre, TAB(9), "Me.txt" & reg.nombre & ".Size = New System.Drawing.Size(137, 20)")
            PrintLine(libre, TAB(9), "Me.txt" & reg.nombre & ".TabIndex = 26")
            ' Creo la variable local para usarse con la propiedad
            j += 30
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


        'Se Agrega los TabPage al TabControl Principal

        PrintLine(libre, TAB(9), "'")
        PrintLine(libre, TAB(9), "'TabControl1")
        PrintLine(libre, TAB(9), "'")
        For i = 0 To tik - 1
            PrintLine(libre, TAB(9), "Me.TabControl1.Controls.Add(Me.TabP" & tikeada(i) & ")")
        Next
        PrintLine(libre, TAB(9), "Me.TabControl1.Location = New System.Drawing.Point(49, 191)")
        PrintLine(libre, TAB(9), "Me.TabControl1.Name = " & Chr(34) & "TabControl1" & Chr(34))
        PrintLine(libre, TAB(9), "Me.TabControl1.SelectedIndex = 0")
        PrintLine(libre, TAB(9), "Me.TabControl1.Size = New System.Drawing.Size(424, 245)")
        PrintLine(libre, TAB(9), "Me.TabControl1.TabIndex = 16")

        PrintLine(libre, TAB(9), "")


        'TablaHijo(tabla(i))
        n = 0
        For i = 0 To tik - 1
            TablaHijo(tikeada(i))
            For Each valtabla In tablas
                PrintLine(libre, TAB(9), "Me.TabP" & tikeada(i) & ".Controls.Add(Me.lb" & valtabla.nombre & n & ")")
                PrintLine(libre, TAB(9), "Me.TabP" & tikeada(i) & ".Controls.Add(Me.txt" & valtabla.nombre & n & ")")
            Next
            PrintLine(libre, TAB(9), "Me.TabP" & tikeada(i) & ".Location = New System.Drawing.Point(4, 22)")
            PrintLine(libre, TAB(9), "Me.TabP" & tikeada(i) & ".Name = " & Chr(34) & "TabP" & tikeada(i) & Chr(34))
            PrintLine(libre, TAB(9), "Me.TabP" & tikeada(i) & ".Padding = New System.Windows.Forms.Padding(3)")
            PrintLine(libre, TAB(9), "Me.TabP" & tikeada(i) & ".Size = New System.Drawing.Size(416, 185)")
            PrintLine(libre, TAB(9), "Me.TabP" & tikeada(i) & ".TabIndex = 1")
            PrintLine(libre, TAB(9), "Me.TabP" & tikeada(i) & ".Text = " & Chr(34) & "TabP" & tikeada(i) & Chr(34))
            PrintLine(libre, TAB(9), "Me.TabP" & tikeada(i) & ".UseVisualStyleBackColor = True")
            n += 1
        Next


        'Creo los Componentes TextBox que Estan dentro del TapPage
        n = 0
        For i = 0 To tik - 1
            TablaHijo(tikeada(i))
            Dim pe = 150
            Dim ka = 22
            For Each valtabla In tablas
                PrintLine(libre, TAB(9), "'")
                PrintLine(libre, TAB(9), "'txt" & valtabla.nombre & n)
                PrintLine(libre, TAB(9), "'")
                PrintLine(libre, TAB(9), "Me.txt" & valtabla.nombre & n & ".Location = New System.Drawing.Point(" & pe & "," & ka & ")")
                PrintLine(libre, TAB(9), "Me.txt" & valtabla.nombre & n & ".Name = " & Chr(34) & "txt" & valtabla.nombre & n & Chr(34))
                PrintLine(libre, TAB(9), "Me.txt" & valtabla.nombre & n & ".Size = New System.Drawing.Size(137, 20)")
                PrintLine(libre, TAB(9), "Me.txt" & valtabla.nombre & n & ".TabIndex = 26")
                PrintLine(libre, TAB(9), "")
                PrintLine(libre, TAB(9), "")
                ka += 25
            Next
            n += 1
        Next


        'Creo los Componentes Label que Estan dentro del TapPage
        n = 0
        For i = 0 To tik - 1
            TablaHijo(tikeada(i))
            Dim pe = 51
            Dim ka = 25
            For Each valtabla In tablas
                PrintLine(libre, TAB(9), "'")
                PrintLine(libre, TAB(9), "'lb" & valtabla.nombre & n)
                PrintLine(libre, TAB(9), "'")
                PrintLine(libre, TAB(9), "Me.lb" & valtabla.nombre & n & ".AutoSize = True")
                PrintLine(libre, TAB(9), "Me.lb" & valtabla.nombre & n & ".Location = New System.Drawing.Point(" & pe & "," & ka & ")")
                PrintLine(libre, TAB(9), "Me.lb" & valtabla.nombre & n & ".Name = " & Chr(34) & "lb" & valtabla.nombre & n & Chr(34))
                PrintLine(libre, TAB(9), "Me.lb" & valtabla.nombre & n & ".Size = New System.Drawing.Size(137, 20)")
                PrintLine(libre, TAB(9), "Me.lb" & valtabla.nombre & n & ".TabIndex = 26")
                PrintLine(libre, TAB(9), "Me.lb" & valtabla.nombre & n & ".Text = " & Chr(34) & valtabla.nombre & n & Chr(34))
                PrintLine(libre, TAB(9), "")
                PrintLine(libre, TAB(9), "")
                ka += 25
            Next
            n += 1
        Next


        PrintLine(libre, TAB(9), "'")
        PrintLine(libre, TAB(9), "'FrmSuper" & Me.ComboBox1.Text)
        PrintLine(libre, TAB(9), "'")
        PrintLine(libre, TAB(9), "Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)")
        PrintLine(libre, TAB(9), "Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font")
        PrintLine(libre, TAB(9), "Me.ClientSize = New System.Drawing.Size(517, 512)")
        PrintLine(libre, TAB(9), "Me.Controls.Add(Me.ToolStrip1)")
        PrintLine(libre, TAB(9), "Me.Controls.Add(Me.TabControl1)")

        For Each reg In arrEstructura
            PrintLine(libre, TAB(9), "Me.Controls.Add(Me.txt" & reg.nombre & ")")
            PrintLine(libre, TAB(9), "Me.Controls.Add(Me.lb" & reg.nombre & ")")
        Next



        PrintLine(libre, TAB(9), "Me.Name = " & Chr(34) & "FrmSuper" & Me.ComboBox1.Text & Chr(34))
        PrintLine(libre, TAB(9), "Me.Text = " & Chr(34) & "FrmSuper" & Me.ComboBox1.Text & Chr(34))
        PrintLine(libre, TAB(9), "Me.ToolStrip1.ResumeLayout(False)")
        PrintLine(libre, TAB(9), "Me.ToolStrip1.PerformLayout()")
        PrintLine(libre, TAB(9), "Me.TabControl1.ResumeLayout(False)")
        For i = 0 To tik - 1
            PrintLine(libre, TAB(9), "Me.TabP" & tikeada(i) & ".ResumeLayout(False)")
            PrintLine(libre, TAB(9), "Me.TabP" & tikeada(i) & ".PerformLayout()")
        Next

        PrintLine(libre, TAB(9), "Me.ResumeLayout(False)")
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "End Sub")

        'Crea Label
        For Each reg In arrEstructura
            PrintLine(libre, TAB(5), "Friend WithEvents txt" & reg.nombre & " As System.Windows.Forms.TextBox")
            PrintLine(libre, TAB(5), "Friend WithEvents lb" & reg.nombre & " As System.Windows.Forms.Label")

        Next
        'Crea Button

        'ToolStrip1
        PrintLine(libre, TAB(5), "Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip")

        'Botones del ToolStrip1
        For Each Strip In arrstring
            PrintLine(libre, TAB(5), "Friend WithEvents TS" & Strip & " As System.Windows.Forms.ToolStripButton")
        Next

        PrintLine(libre, TAB(5), "Friend WithEvents TabControl1 As System.Windows.Forms.TabControl")
        n = 0
        For i = 0 To tik - 1
            TablaHijo(tikeada(i))
            For Each valtabla In tablas
                PrintLine(libre, TAB(5), "Friend WithEvents txt" & valtabla.nombre & n & " As System.Windows.Forms.TextBox")
                PrintLine(libre, TAB(5), "Friend WithEvents lb" & valtabla.nombre & n & " As System.Windows.Forms.Label")
            Next
            PrintLine(libre, TAB(5), "Friend WithEvents TabP" & tikeada(i) & " As System.Windows.Forms.TabPage")
            n += 1
        Next
        PrintLine(libre, "End Class")
        'Cierra el Archivo
        FileClose(libre)
    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub crearClaseCtrl(ByVal ruta As String)
        Dim archivo As String
        'Valida si Existe el archivo
        If Mid$(Me.ComboBox1.Text, Len(Me.ComboBox1.Text) - 3, 3) <> ".vb" Then
            'crea un nuevo archivo 
            archivo = ruta & "\Ctrl" & Me.ComboBox1.Text & ".vb"
        Else
            'Sobreescribe el archivo
            archivo = ruta & "\Ctrl" & Me.ComboBox1.Text
        End If

        Dim libre As String = FreeFile()
        FileOpen(libre, archivo, OpenMode.Output)

        PrintLine(libre, "Public Class Ctrl" & ComboBox1.Text)
        PrintLine(libre, TAB(4), "Inherits Dal.TDatosSQL")
        PrintLine(libre, "")
        Dim i As Integer
        Dim strcabeserafuncion As String = "Public Function guardar" & ComboBox1.Text & " (byval obj" & ComboBox1.Text & " as Negocio." & ComboBox1.Text & ","
        For i = 0 To Me.dgvtabla.RowCount - 1
            If Me.dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                strcabeserafuncion = strcabeserafuncion + " byval obj" & Me.dgvtabla.Rows(i).Cells("tabla").Value & " as Negocio." & Me.dgvtabla.Rows(i).Cells("tabla").Value & ","
            End If
        Next i
        strcabeserafuncion = Mid(strcabeserafuncion, 1, (strcabeserafuncion.Length) - 1) & ")  as integer"
        PrintLine(libre, TAB(5), strcabeserafuncion)

        PrintLine(libre, TAB(9), "Dim t As System.Data.SqlClient.SqlTransaction")
        PrintLine(libre, TAB(9), "t = Me.IniciarTransaccion")


        Dim strcad As String = String.Empty
        For i = 0 To Me.dgvtabla.RowCount - 1
            If Me.dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                strcad = strcad + "(obj" & Me.dgvtabla.Rows(i).Cells("tabla").Value & ".Guardar(t)=1) and "
            End If
        Next i
        strcad = Mid(strcad, 1, (strcad.Length) - 4)
        strcad = "if " & strcad & " Then"
        PrintLine(libre, TAB(9), strcad)
        PrintLine(libre, TAB(14), "t.Commit()")
        PrintLine(libre, TAB(14), "Return (1)")
        PrintLine(libre, TAB(9), "Else")
        PrintLine(libre, TAB(14), "t.Rollback()")
        PrintLine(libre, TAB(14), "Return (0)")
        PrintLine(libre, TAB(9), "End If")
        PrintLine(libre, TAB(5), "End Function")

        'metodo actualizar
        strcabeserafuncion = "Public Function Modificar" & ComboBox1.Text & " (byval obj" & ComboBox1.Text & " as Negocio." & ComboBox1.Text & ","
        For i = 0 To Me.dgvtabla.RowCount - 1
            If Me.dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                strcabeserafuncion = strcabeserafuncion + " byval obj" & Me.dgvtabla.Rows(i).Cells("tabla").Value & " as Negocio." & Me.dgvtabla.Rows(i).Cells("tabla").Value & ","
            End If
        Next i
        strcabeserafuncion = Mid(strcabeserafuncion, 1, (strcabeserafuncion.Length) - 1) & ")  as integer"
        PrintLine(libre, TAB(5), strcabeserafuncion)

        PrintLine(libre, TAB(9), "Dim t As System.Data.SqlClient.SqlTransaction")
        PrintLine(libre, TAB(9), "t = Me.IniciarTransaccion")


        strcad = String.Empty
        For i = 0 To Me.dgvtabla.RowCount - 1
            If Me.dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                strcad = strcad + "(obj" & Me.dgvtabla.Rows(i).Cells("tabla").Value & ".Modificar(t)=1) and "
            End If
        Next i
        strcad = Mid(strcad, 1, (strcad.Length) - 4)
        strcad = "if " & strcad & " Then"
        PrintLine(libre, TAB(9), strcad)
        PrintLine(libre, TAB(14), "t.Commit()")
        PrintLine(libre, TAB(14), "Return (1)")
        PrintLine(libre, TAB(9), "Else")
        PrintLine(libre, TAB(14), "t.Rollback()")
        PrintLine(libre, TAB(14), "Return (0)")
        PrintLine(libre, TAB(9), "End If")
        PrintLine(libre, TAB(5), "End Function")

        'metodo Eliminar
        strcabeserafuncion = "Public Function Eliminar" & ComboBox1.Text & " (byval obj" & ComboBox1.Text & " as Negocio." & ComboBox1.Text & ","
        For i = 0 To Me.dgvtabla.RowCount - 1
            If Me.dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                strcabeserafuncion = strcabeserafuncion + " byval obj" & Me.dgvtabla.Rows(i).Cells("tabla").Value & " as Negocio." & Me.dgvtabla.Rows(i).Cells("tabla").Value & ","
            End If
        Next i
        strcabeserafuncion = Mid(strcabeserafuncion, 1, (strcabeserafuncion.Length) - 1) & ")  as integer"
        PrintLine(libre, TAB(5), strcabeserafuncion)

        PrintLine(libre, TAB(9), "Dim t As System.Data.SqlClient.SqlTransaction")
        PrintLine(libre, TAB(9), "t = Me.IniciarTransaccion")


        strcad = String.Empty
        For i = 0 To Me.dgvtabla.RowCount - 1
            If Me.dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                strcad = strcad + "(obj" & Me.dgvtabla.Rows(i).Cells("tabla").Value & ".Eliminar(t)=1) and "
            End If
        Next i
        strcad = Mid(strcad, 1, (strcad.Length) - 4)
        strcad = "if " & strcad & " Then"
        PrintLine(libre, TAB(9), strcad)
        PrintLine(libre, TAB(14), "t.Commit()")
        PrintLine(libre, TAB(14), "Return (1)")
        PrintLine(libre, TAB(9), "Else")
        PrintLine(libre, TAB(14), "t.Rollback()")
        PrintLine(libre, TAB(14), "Return (0)")
        PrintLine(libre, TAB(9), "End If")
        PrintLine(libre, TAB(5), "End Function")




        PrintLine(libre, "End Class")
        FileClose(libre)



       
        'Public Function Modificararbol(ByVal objarbol As Negocio.Arbol, ByVal objhoja As Negocio.Hoja, ByVal objraiz As Negocio.Raiz, ByVal objtallo As Negocio.tallo) As Integer
        '    Dim t As System.Data.SqlClient.SqlTransaction
        '    t = Me.IniciarTransaccion
        '    If (objarbol.Modificar(t) = 1) And (objhoja.Modificar(t) = 1) And (objraiz.Modificar(t) = 1) And (objtallo.Modificar(t) = 1) Then
        '        t.Commit()
        '        Return (1)
        '    Else
        '        t.Rollback()
        '        Return (0)
        '    End If
        'End Function
        'Public Function Eliminarrarbol(ByVal objarbol As Negocio.Arbol, ByVal objhoja As Negocio.Hoja, ByVal objraiz As Negocio.Raiz, ByVal objtallo As Negocio.tallo) As Integer
        '    Dim t As System.Data.SqlClient.SqlTransaction
        '    t = Me.IniciarTransaccion
        '    If (objarbol.Eliminar(t) = 1) And (objhoja.Eliminar(t) = 1) And (objraiz.Eliminar(t) = 1) And (objtallo.Eliminar(t) = 1) Then
        '        t.Commit()
        '        Return (1)
        '    Else
        '        t.Rollback()
        '        Return (0)
        '    End If
        'End Function



    End Sub




    Dim arrstring() As String

    Public Sub cargarstring()
        ReDim arrstring(4)
        arrstring(0) = "Nuevo"
        arrstring(1) = "Guardar"
        arrstring(2) = "Modificar"
        arrstring(3) = "Imprimir"
        arrstring(4) = "Salir"

    End Sub

    Private Sub Crearclase(ByVal Ruta As String)
        Dim archivo As String
        'Valida si Existe el archivo
        If Mid$(Me.ComboBox1.Text, Len(Me.ComboBox1.Text) - 3, 3) <> ".vb" Then
            'crea un nuevo archivo 
            archivo = Ruta & "\FrmSuper" & Me.ComboBox1.Text & ".vb"
        Else
            'Sobreescribe el archivo
            archivo = Ruta & "\FrmSuper" & Me.ComboBox1.Text
        End If

        Dim libre As String = FreeFile()
        Dim reg As regCampo
        Dim strip1 As String
        Me.cargarstring()
        cargarAtributos()
        'Abre el archivo de Texto
        FileOpen(libre, archivo, OpenMode.Output)

        Dim tikeada(50)
        Dim tik = 0
        Dim i As Integer
        For i = 0 To dgvtabla.RowCount - 1
            If dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                Dim nombretabla = dgvtabla.Rows(i).Cells.Item(0).Value.ToString()
                tikeada(tik) = nombretabla
                tik += 1
            End If
        Next

        Dim valtabla As subtabla

        PrintLine(libre, "Public Class FrmSuper" & Me.ComboBox1.Text)
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "Dim obj" & ComboBox1.Text & " As New Negocio." & ComboBox1.Text)
        PrintLine(libre, TAB(5), "Dim objcontrol As New Negocio.Ctrl" & ComboBox1.Text)
        PrintLine(libre, TAB(5), "")
        'Creo los objetos de los TabPages 
        For i = 0 To tik - 1
            PrintLine(libre, TAB(5), "Dim objcontrol" & tikeada(i) & " As New Negocio.Ctrl" & tikeada(i))
            PrintLine(libre, TAB(5), "Dim obj" & tikeada(i) & " As New Negocio." & tikeada(i))
        Next
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "")

        For Each strip1 In arrstring
            PrintLine(libre, TAB(5), "")
            PrintLine(libre, TAB(5), "Private Sub TSG" & strip1 & "_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TS" & strip1 & ".Click")
            PrintLine(libre, TAB(9), "'Me." & strip1 & "()")
            PrintLine(libre, TAB(5), "End Sub")
            PrintLine(libre, TAB(5), "")
        Next

        PrintLine(libre, TAB(5), "Private Sub Guardar")

        For Each reg In arrEstructura
            PrintLine(libre, TAB(9), "obj" & Me.ComboBox1.Text & ".P" & reg.nombre & " = Me.txt" & reg.nombre & ".Text")
        Next

        PrintLine(libre, TAB(9), " If objcontrol.guardar" & ComboBox1.Text & "(obj" & ComboBox1.Text & ") = 1 Then")

        For i = 0 To tik - 1
            PrintLine(libre, TAB(13), "If TabControl1.SelectedTab.Text = " & Chr(34) & "TabP" & tikeada(i) & Chr(34))
            PrintLine(libre, TAB(18), "Guardar" & tikeada(i))
            PrintLine(libre, TAB(13), "End If")
        Next
        'PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "Se Grabo Exitosamente" & Chr(34) & ")")
        PrintLine(libre, TAB(9), "Else")
        PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "### E R R O R ####" & Chr(34) & ")")
        PrintLine(libre, TAB(9), "End If")
        PrintLine(libre, TAB(5), "End Sub")
        Dim n = 0
        For i = 0 To tik - 1
            TablaHijo(tikeada(i))
            PrintLine(libre, TAB(5), "")
            PrintLine(libre, TAB(5), "Private Sub Guardar" & tikeada(i))
            For Each valtabla In tablas
                PrintLine(libre, TAB(9), "obj" & tikeada(i) & ".P" & valtabla.nombre & " = Me.txt" & valtabla.nombre & n & ".Text")
            Next
            PrintLine(libre, TAB(9), " If objcontrol" & tikeada(i) & ".guardar" & tikeada(i) & "(obj" & tikeada(i) & ") = 1 Then")
            PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "Se Grabo Exitosamente" & Chr(34) & ")")
            PrintLine(libre, TAB(9), "Else")
            PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "### E R R O R ####" & Chr(34) & ")")
            PrintLine(libre, TAB(9), "End If")
            PrintLine(libre, TAB(5), "End Sub")
            PrintLine(libre, TAB(5), "")
            n += 1
        Next

        PrintLine(libre, TAB(5), "")
        PrintLine(libre, "End Class")
        'Cierra el Archivo
        FileClose(libre)
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        CargarGrillaTabla()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.ComboBox1.Items.Clear()
        Me.cargartablas()
    End Sub
    Private Sub btnGenerarClase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarClase.Click
        If MessageBox.Show("¿ Confirma crear el Formulario " & Me.ComboBox1.Text, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            If varLenguaje = VISUAL_BASIC Then
                generarFormulariosVisualBasic()
            Else
                generarFormulariosCSharp()
            End If

        End If
    End Sub

    Private Sub generarFormulariosCSharp()
        Me.CrearFormulariosCSharp(Me.txbRuta.Text)
        Me.CrearclasCsharp(Me.txbRuta.Text)
        Me.crearComponentesCSharp(Me.txbRuta.Text)
        Me.crearClaseCtrlCSharp(Me.TxbRutaCtrl.Text)
        MessageBox.Show("El Formulario " & Me.ComboBox1.Text & " se Creo Correctamente", "Confirmacion")
    End Sub

    Private Sub generarFormulariosVisualBasic()
        Me.CrearFormularios(Me.txbRuta.Text)
        Me.Crearclase(Me.txbRuta.Text)
        Me.crearComponentes(Me.txbRuta.Text)
        Me.crearClaseCtrl(Me.TxbRutaCtrl.Text)
        MessageBox.Show("El Formulario " & Me.ComboBox1.Text & " se Creo Correctamente", "Confirmacion")
    End Sub

#Region "Metodos para generar Formularios en C#"
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

    Private Sub CrearclasCsharp(ByVal Ruta As String)
        Dim archivo As String
        'Valida si Existe el archivo
        If Mid$(Me.ComboBox1.Text, Len(Me.ComboBox1.Text) - 3, 3) <> ".cs" Then
            'crea un nuevo archivo 
            archivo = Ruta & "\FrmSuper" & Me.ComboBox1.Text & ".cs"
        Else
            'Sobreescribe el archivo
            archivo = Ruta & "\FrmSuper" & Me.ComboBox1.Text
        End If

        Dim libre As String = FreeFile()
        Dim reg As regCampo
        Dim strip1 As String
        Me.cargarstring()
        cargarAtributos()
        'Abre el archivo de Texto
        FileOpen(libre, archivo, OpenMode.Output)

        Dim tikeada(50)
        Dim tik = 0
        Dim i As Integer
        For i = 0 To dgvtabla.RowCount - 1
            If dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                Dim nombretabla = dgvtabla.Rows(i).Cells.Item(0).Value.ToString()
                tikeada(tik) = nombretabla
                tik += 1
            End If
        Next

        Dim valtabla As subtabla

        PrintLine(libre, "using System;")
        PrintLine(libre, "using System.Collections.Generic;")
        PrintLine(libre, "using System.ComponentModel;")
        PrintLine(libre, "using System.Data;")
        PrintLine(libre, "using System.Drawing;")
        PrintLine(libre, "using System.Text;")
        PrintLine(libre, "using System.Windows.Forms;")
        PrintLine(libre, "")
        PrintLine(libre, "public partial class FrmSuper" & Me.ComboBox1.Text & " : Form")
        PrintLine(libre, "{")
        PrintLine(libre, TAB(5), "private" & " Negocio." & ComboBox1.Text & " obj" & ComboBox1.Text & " = new Negocio." & ComboBox1.Text & "();")
        PrintLine(libre, TAB(5), "private" & " Negocio.Ctrl" & ComboBox1.Text & " objcontrol = new Negocio.Ctrl" & ComboBox1.Text & "();")
        'Creo los objetos de los TabPages 
        For i = 0 To tik - 1
            PrintLine(libre, TAB(5), "private" & " Negocio.Ctrl" & tikeada(i) & " objcontrol" & tikeada(i) & " = new Negocio.Ctrl" & tikeada(i) & "();")
            PrintLine(libre, TAB(5), "private" & " Negocio." & tikeada(i) & " obj" & tikeada(i) & " = new Negocio." & tikeada(i) & "();")
        Next
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "")

        For Each strip1 In arrstring
            PrintLine(libre, TAB(5), "")
            PrintLine(libre, TAB(5), "private void TSG" & strip1 & "_Click(object sender, EventArgs e)")
            PrintLine(libre, TAB(5), "{")
            PrintLine(libre, TAB(9), " this." & strip1 & "();")
            PrintLine(libre, TAB(5), "}")
            PrintLine(libre, TAB(5), "")
        Next

        PrintLine(libre, TAB(5), "private void Guardar()")
        PrintLine(libre, TAB(5), "{")
        For Each reg In arrEstructura
            PrintLine(libre, TAB(9), "obj" & Me.ComboBox1.Text & ".P" & reg.nombre & " = this.txt" & reg.nombre & ".Text;")
        Next

        PrintLine(libre, TAB(9), " if( objcontrol.guardar" & ComboBox1.Text & "(obj" & ComboBox1.Text & ") == 1 )")
        PrintLine(libre, TAB(9), "{")
        For i = 0 To tik - 1
            PrintLine(libre, TAB(13), "if( TabControl1.SelectedTab.Text == " & Chr(34) & "TabP" & tikeada(i) & Chr(34) & ")")
            PrintLine(libre, TAB(13), "{")
            PrintLine(libre, TAB(18), "Guardar" & tikeada(i) & " ();")
            PrintLine(libre, TAB(13), "}")
        Next
        'PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "Se Grabo Exitosamente" & Chr(34) & ")")
        PrintLine(libre, TAB(9), "}")
        PrintLine(libre, TAB(9), "else")
        PrintLine(libre, TAB(9), "{")
        PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "### E R R O R ####" & Chr(34) & ");")
        PrintLine(libre, TAB(9), "}")
        PrintLine(libre, TAB(5), "}")
        Dim n = 0
        For i = 0 To tik - 1
            TablaHijo(tikeada(i))
            PrintLine(libre, TAB(5), "")
            PrintLine(libre, TAB(5), "private void Guardar" & tikeada(i) & "()")
            PrintLine(libre, TAB(5), "{")
            For Each valtabla In tablas
                PrintLine(libre, TAB(9), "obj" & tikeada(i) & ".P" & valtabla.nombre & " = this.txt" & valtabla.nombre & n & ".Text;")
            Next
            PrintLine(libre, TAB(9), " if( objcontrol" & tikeada(i) & ".guardar" & tikeada(i) & "(obj" & tikeada(i) & ") == 1 )")
            PrintLine(libre, TAB(9), " {")
            PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "Se Grabo Exitosamente" & Chr(34) & ");")
            PrintLine(libre, TAB(9), " }")
            PrintLine(libre, TAB(9), "else")
            PrintLine(libre, TAB(9), " {")
            PrintLine(libre, TAB(13), "MessageBox.Show(" & Chr(34) & "### E R R O R ####" & Chr(34) & ");")
            PrintLine(libre, TAB(9), "}")
            PrintLine(libre, TAB(5), "}")
            PrintLine(libre, TAB(5), "")
            n += 1
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
            archivo = Ruta & "\FrmSuper" & Me.ComboBox1.Text & ".Designer.cs"
        Else
            'Sobreescribe el archivo
            archivo = Ruta & "\FrmSuper" & Me.ComboBox1.Text
        End If

        Dim libre As String = FreeFile()
        Dim reg As regCampo
        Dim i, j, x, y, p As Integer
        x = 90
        y = 30
        p = 200
        j = 30
        'Abre el archivo de Texto
        FileOpen(libre, archivo, OpenMode.Output)

        PrintLine(libre, "partial class FrmSuper" & Me.ComboBox1.Text)
        PrintLine(libre, "{")
        PrintLine(libre, TAB(5), "/// <summary>")
        PrintLine(libre, TAB(5), "/// Variable del diseñador requerida.")
        PrintLine(libre, TAB(5), "/// </summary>")
        PrintLine(libre, TAB(5), "private System.ComponentModel.IContainer components = null;")
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "/// <summary>")
        PrintLine(libre, TAB(5), "/// Limpiar los recursos que se estén utilizando.")
        PrintLine(libre, TAB(5), "/// </summary>")
        PrintLine(libre, TAB(5), "/// <param name=""disposing"">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>")
        PrintLine(libre, TAB(5), "protected override void Dispose(bool disposing)")
        PrintLine(libre, TAB(5), "{")
        PrintLine(libre, TAB(9), "if (disposing && (components != null))")
        PrintLine(libre, TAB(9), "{")
        PrintLine(libre, TAB(11), "components.Dispose();")
        PrintLine(libre, TAB(9), "}")
        PrintLine(libre, TAB(9), "base.Dispose(disposing);")
        PrintLine(libre, TAB(5), "}")
        PrintLine(libre, "")
        PrintLine(libre, TAB(5), "#region Código generado por el Diseñador de Windows Forms")
        PrintLine(libre, "")
        PrintLine(libre, TAB(5), "/// <summary>")
        PrintLine(libre, TAB(5), "/// Método necesario para admitir el Diseñador. No se puede modificar")
        PrintLine(libre, TAB(5), "/// el contenido del método con el editor de código.")
        PrintLine(libre, TAB(5), "/// </summary>")
        PrintLine(libre, TAB(5), "private void InitializeComponent()")
        PrintLine(libre, TAB(5), "{")


        PrintLine(libre, TAB(5), "System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(GetType(FrmSuper" & ComboBox1.Text & "));")
        cargarAtributos()
        'Declarar un variable de Tipo vector cargo todos las tablas tikeadas
        'del datagridview
        'Dim algo As String = 
        Dim tikeada(50)
        Dim tik = 0
        For i = 0 To dgvtabla.RowCount - 1
            If dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                Dim nombretabla = dgvtabla.Rows(i).Cells.Item(0).Value.ToString()
                tikeada(tik) = nombretabla
                tik += 1
            End If
        Next
        Dim valtabla As subtabla

        For Each reg In arrEstructura
            PrintLine(libre, TAB(9), "this.txt" & reg.nombre & " = new System.Windows.Forms.TextBox();")
        Next

        For Each reg In arrEstructura
            PrintLine(libre, TAB(9), "this.lb" & reg.nombre & " = new System.Windows.Forms.Label();")
        Next
        Dim n = 0
        For i = 0 To tik - 1
            TablaHijo(tikeada(i))
            For Each valtabla In tablas
                PrintLine(libre, TAB(9), "this.txt" & valtabla.nombre & n & " = new System.Windows.Forms.TextBox();")
                PrintLine(libre, TAB(9), "this.lb" & valtabla.nombre & n & " = new System.Windows.Forms.Label();")
            Next

            PrintLine(libre, TAB(9), "this.TabP" & tikeada(i) & " = new System.Windows.Forms.TabPage();")
            n += 1
        Next
        PrintLine(libre, TAB(9), "")

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
        PrintLine(libre, TAB(9), "this.TabControl1 = new System.Windows.Forms.TabControl();")


        PrintLine(libre, TAB(9), "this.TabControl1.SuspendLayout();")
        For i = 0 To tik - 1
            PrintLine(libre, TAB(9), "this.TabP" & tikeada(i) & ".SuspendLayout();")
        Next
        PrintLine(libre, TAB(9), "")
        PrintLine(libre, TAB(9), "this.ToolStrip1.SuspendLayout();")
        PrintLine(libre, TAB(9), "this.SuspendLayout();")
        'Crear TextBox en el Formulario
        Dim dos As Integer = 0
        For Each reg In arrEstructura
            PrintLine(libre, TAB(9), "//")
            PrintLine(libre, TAB(9), "// txt" & reg.nombre)
            PrintLine(libre, TAB(9), "//")
            PrintLine(libre, TAB(9), "this.txt" & reg.nombre & ".Location = new System.Drawing.Point(" & p & "," & j & ");")
            PrintLine(libre, TAB(9), "this.txt" & reg.nombre & ".Name = " & Chr(34) & "txt" & reg.nombre & Chr(34) & ";")
            PrintLine(libre, TAB(9), "this.txt" & reg.nombre & ".Size = new System.Drawing.Size(137, 20);")
            PrintLine(libre, TAB(9), "this.txt" & reg.nombre & ".TabIndex = 26;")
            ' Creo la variable local para usarse con la propiedad
            j += 30
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
        PrintLine(libre, TAB(9), "// ToolStrip1")
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
            PrintLine(libre, TAB(9), "//")
            PrintLine(libre, TAB(9), "// TS" & Strip)
            PrintLine(libre, TAB(9), "//")
            PrintLine(libre, TAB(9), "this.TS" & Strip & ".Image = (System.Drawing.Image) resources.GetObject(" & Chr(34) & "TS" & Strip & ".Image" & Chr(34) & ") ;")
            PrintLine(libre, TAB(9), "this.TS" & Strip & ".ImageTransparentColor = System.Drawing.Color.Magenta;")
            PrintLine(libre, TAB(9), "this.TS" & Strip & ".Name = " & Chr(34) & "TS" & Strip & Chr(34) & ";")
            PrintLine(libre, TAB(9), "this.TS" & Strip & ".Size = new System.Drawing.Size(58, 22);")
            PrintLine(libre, TAB(9), "this.TS" & Strip & ".Text = " & Chr(34) & Strip & Chr(34) & ";")
            PrintLine(libre, TAB(9), "this.TS" & Strip & ".Click += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TSG" & Strip & "_Click);")
        Next


        'Se Agrega los TabPage al TabControl Principal

        PrintLine(libre, TAB(9), "//")
        PrintLine(libre, TAB(9), "// TabControl1")
        PrintLine(libre, TAB(9), "//")
        For i = 0 To tik - 1
            PrintLine(libre, TAB(9), "this.TabControl1.Controls.Add(this.TabP" & tikeada(i) & ");")
        Next
        PrintLine(libre, TAB(9), "this.TabControl1.Location = new System.Drawing.Point(49, 191);")
        PrintLine(libre, TAB(9), "this.TabControl1.Name = " & Chr(34) & "TabControl1" & Chr(34) & ";")
        PrintLine(libre, TAB(9), "this.TabControl1.SelectedIndex = 0;")
        PrintLine(libre, TAB(9), "this.TabControl1.Size = new System.Drawing.Size(424, 245);")
        PrintLine(libre, TAB(9), "this.TabControl1.TabIndex = 16;")

        PrintLine(libre, TAB(9), "")


        'TablaHijo(tabla(i))
        n = 0
        For i = 0 To tik - 1
            TablaHijo(tikeada(i))
            For Each valtabla In tablas
                PrintLine(libre, TAB(9), "this.TabP" & tikeada(i) & ".Controls.Add(this.lb" & valtabla.nombre & n & ");")
                PrintLine(libre, TAB(9), "this.TabP" & tikeada(i) & ".Controls.Add(this.txt" & valtabla.nombre & n & ");")
            Next
            PrintLine(libre, TAB(9), "this.TabP" & tikeada(i) & ".Location = new System.Drawing.Point(4, 22);")
            PrintLine(libre, TAB(9), "this.TabP" & tikeada(i) & ".Name = " & Chr(34) & "TabP" & tikeada(i) & Chr(34) & ";")
            PrintLine(libre, TAB(9), "this.TabP" & tikeada(i) & ".Padding = new System.Windows.Forms.Padding(3);")
            PrintLine(libre, TAB(9), "this.TabP" & tikeada(i) & ".Size = new System.Drawing.Size(416, 185);")
            PrintLine(libre, TAB(9), "this.TabP" & tikeada(i) & ".TabIndex = 1;")
            PrintLine(libre, TAB(9), "this.TabP" & tikeada(i) & ".Text = " & Chr(34) & "TabP" & tikeada(i) & Chr(34) & ";")
            PrintLine(libre, TAB(9), "this.TabP" & tikeada(i) & ".UseVisualStyleBackColor = true;")
            n += 1
        Next


        'Creo los Componentes TextBox que Estan dentro del TapPage
        n = 0
        For i = 0 To tik - 1
            TablaHijo(tikeada(i))
            Dim pe = 150
            Dim ka = 22
            For Each valtabla In tablas
                PrintLine(libre, TAB(9), "//")
                PrintLine(libre, TAB(9), "// txt" & valtabla.nombre & n)
                PrintLine(libre, TAB(9), "//")
                PrintLine(libre, TAB(9), "this.txt" & valtabla.nombre & n & ".Location = new System.Drawing.Point(" & pe & "," & ka & ");")
                PrintLine(libre, TAB(9), "this.txt" & valtabla.nombre & n & ".Name = " & Chr(34) & "txt" & valtabla.nombre & n & Chr(34) & ";")
                PrintLine(libre, TAB(9), "this.txt" & valtabla.nombre & n & ".Size = new System.Drawing.Size(137, 20);")
                PrintLine(libre, TAB(9), "this.txt" & valtabla.nombre & n & ".TabIndex = 26;")
                PrintLine(libre, TAB(9), "")
                PrintLine(libre, TAB(9), "")
                ka += 25
            Next
            n += 1
        Next


        'Creo los Componentes Label que Estan dentro del TapPage
        n = 0
        For i = 0 To tik - 1
            TablaHijo(tikeada(i))
            Dim pe = 51
            Dim ka = 25
            For Each valtabla In tablas
                PrintLine(libre, TAB(9), "//")
                PrintLine(libre, TAB(9), "// lb" & valtabla.nombre & n)
                PrintLine(libre, TAB(9), "//")
                PrintLine(libre, TAB(9), "this.lb" & valtabla.nombre & n & ".AutoSize = true;")
                PrintLine(libre, TAB(9), "this.lb" & valtabla.nombre & n & ".Location = new System.Drawing.Point(" & pe & "," & ka & ");")
                PrintLine(libre, TAB(9), "this.lb" & valtabla.nombre & n & ".Name = " & Chr(34) & "lb" & valtabla.nombre & n & Chr(34) & ";")
                PrintLine(libre, TAB(9), "this.lb" & valtabla.nombre & n & ".Size = new System.Drawing.Size(137, 20);")
                PrintLine(libre, TAB(9), "this.lb" & valtabla.nombre & n & ".TabIndex = 26;")
                PrintLine(libre, TAB(9), "this.lb" & valtabla.nombre & n & ".Text = " & Chr(34) & valtabla.nombre & n & Chr(34) & ";")
                PrintLine(libre, TAB(9), "")
                PrintLine(libre, TAB(9), "")
                ka += 25
            Next
            n += 1
        Next


        PrintLine(libre, TAB(9), "//")
        PrintLine(libre, TAB(9), "// FrmSuper" & Me.ComboBox1.Text)
        PrintLine(libre, TAB(9), "//")
        PrintLine(libre, TAB(9), "this.AutoScaleDimensions = new System.Drawing.SizeF(6.0f, 13.0f);")
        PrintLine(libre, TAB(9), "this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;")
        PrintLine(libre, TAB(9), "this.ClientSize = new System.Drawing.Size(517, 512);")
        PrintLine(libre, TAB(9), "this.Controls.Add(this.ToolStrip1);")
        PrintLine(libre, TAB(9), "this.Controls.Add(this.TabControl1);")

        For Each reg In arrEstructura
            PrintLine(libre, TAB(9), "this.Controls.Add(this.txt" & reg.nombre & ");")
            PrintLine(libre, TAB(9), "this.Controls.Add(this.lb" & reg.nombre & ");")
        Next



        PrintLine(libre, TAB(9), "this.Name = " & Chr(34) & "FrmSuper" & Me.ComboBox1.Text & Chr(34) & ";")
        PrintLine(libre, TAB(9), "this.Text = " & Chr(34) & "FrmSuper" & Me.ComboBox1.Text & Chr(34) & ";")
        PrintLine(libre, TAB(9), "this.ToolStrip1.ResumeLayout(false);")
        PrintLine(libre, TAB(9), "this.ToolStrip1.PerformLayout();")
        PrintLine(libre, TAB(9), "this.TabControl1.ResumeLayout(false);")
        For i = 0 To tik - 1
            PrintLine(libre, TAB(9), "this.TabP" & tikeada(i) & ".ResumeLayout(false);")
            PrintLine(libre, TAB(9), "this.TabP" & tikeada(i) & ".PerformLayout();")
        Next

        PrintLine(libre, TAB(9), "this.ResumeLayout(false);")
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "}")
        PrintLine(libre, TAB(5), "")
        PrintLine(libre, TAB(5), "#endregion")
        PrintLine(libre, TAB(5), "")
        'Crea Label
        For Each reg In arrEstructura
            PrintLine(libre, TAB(5), "private System.Windows.Forms.TextBox txt" & reg.nombre & ";")
            PrintLine(libre, TAB(5), "private System.Windows.Forms.Label lb" & reg.nombre & ";")

        Next
        'Crea Button

        'ToolStrip1
        PrintLine(libre, TAB(5), "private System.Windows.Forms.ToolStrip ToolStrip1;")

        'Botones del ToolStrip1
        For Each Strip In arrstring
            PrintLine(libre, TAB(5), "private System.Windows.Forms.ToolStripButton TS" & Strip & ";")
        Next

        PrintLine(libre, TAB(5), "private System.Windows.Forms.TabControl TabControl1;")
        n = 0
        For i = 0 To tik - 1
            TablaHijo(tikeada(i))
            For Each valtabla In tablas
                PrintLine(libre, TAB(5), "private System.Windows.Forms.TextBox txt" & valtabla.nombre & n & ";")
                PrintLine(libre, TAB(5), "private System.Windows.Forms.Label lb" & valtabla.nombre & n & ";")
            Next
            PrintLine(libre, TAB(5), "private System.Windows.Forms.TabPage TabP" & tikeada(i) & ";")
            n += 1
        Next


        PrintLine(libre, "}")
        'Cierra el Archivo
        FileClose(libre)
    End Sub

    Private Sub crearClaseCtrlCSharp(ByVal ruta As String)
        Dim archivo As String
        'Valida si Existe el archivo
        If Mid$(Me.ComboBox1.Text, Len(Me.ComboBox1.Text) - 3, 3) <> ".cs" Then
            'crea un nuevo archivo 
            archivo = ruta & "\Ctrl" & Me.ComboBox1.Text & ".cs"
        Else
            'Sobreescribe el archivo
            archivo = ruta & "\Ctrl" & Me.ComboBox1.Text
        End If

        Dim libre As String = FreeFile()
        FileOpen(libre, archivo, OpenMode.Output)

        PrintLine(libre, "using System;")
        PrintLine(libre, "using System.Collections.Generic;")
        PrintLine(libre, "using System.Linq;")
        PrintLine(libre, "using System.Text;")
        PrintLine(libre, "using System.Text;")
        PrintLine(libre, "")
        PrintLine(libre, "public class Ctrl" & ComboBox1.Text & " : Dal.TDatosSQL")
        PrintLine(libre, "{")
        PrintLine(libre, "")
        Dim i As Integer
        Dim strcabeserafuncion As String = "public int guardar" & ComboBox1.Text & " (" & "Negocio." & ComboBox1.Text & " obj" & ComboBox1.Text & ","
        For i = 0 To Me.dgvtabla.RowCount - 1
            If Me.dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                strcabeserafuncion = strcabeserafuncion + " Negocio." & Me.dgvtabla.Rows(i).Cells("tabla").Value & " obj" & Me.dgvtabla.Rows(i).Cells("tabla").Value & ","
            End If
        Next i
        strcabeserafuncion = Mid(strcabeserafuncion, 1, (strcabeserafuncion.Length) - 1) & ")"
        PrintLine(libre, TAB(5), strcabeserafuncion)
        PrintLine(libre, TAB(9), "System.Data.SqlClient.SqlTransaction t;")
        PrintLine(libre, TAB(9), "t = this.IniciarTransaccion();")


        Dim strcad As String = String.Empty
        For i = 0 To Me.dgvtabla.RowCount - 1
            If Me.dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                strcad = strcad + "(obj" & Me.dgvtabla.Rows(i).Cells("tabla").Value & ".Guardar(t)==1) && "
            End If
        Next i
        strcad = Mid(strcad, 1, (strcad.Length) - 4)
        strcad = "if( " & strcad & " )"
        PrintLine(libre, TAB(9), strcad)
        PrintLine(libre, TAB(9), "{")
        PrintLine(libre, TAB(14), "t.Commit();")
        PrintLine(libre, TAB(14), "return (1);")
        PrintLine(libre, TAB(9), "}")
        PrintLine(libre, TAB(9), "else")
        PrintLine(libre, TAB(9), "{")
        PrintLine(libre, TAB(14), "t.Rollback();")
        PrintLine(libre, TAB(14), "return (0);")
        PrintLine(libre, TAB(9), "}")
        PrintLine(libre, TAB(5), "}")

        'metodo actualizar
        strcabeserafuncion = "public int Modificar" & ComboBox1.Text & " (" & " Negocio." & ComboBox1.Text & " obj" & ComboBox1.Text & ","
        For i = 0 To Me.dgvtabla.RowCount - 1
            If Me.dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                strcabeserafuncion = strcabeserafuncion + " Negocio." & Me.dgvtabla.Rows(i).Cells("tabla").Value & " obj" & Me.dgvtabla.Rows(i).Cells("tabla").Value & ","
            End If
        Next i
        strcabeserafuncion = Mid(strcabeserafuncion, 1, (strcabeserafuncion.Length) - 1) & ")"
        PrintLine(libre, TAB(5), strcabeserafuncion)
        PrintLine(libre, TAB(5), "{")

        PrintLine(libre, TAB(9), "System.Data.SqlClient.SqlTransaction t;")
        PrintLine(libre, TAB(9), "t = this.IniciarTransaccion;")


        strcad = String.Empty
        For i = 0 To Me.dgvtabla.RowCount - 1
            If Me.dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                strcad = strcad + "(obj" & Me.dgvtabla.Rows(i).Cells("tabla").Value & ".Modificar(t)==1) && "
            End If
        Next i
        strcad = Mid(strcad, 1, (strcad.Length) - 4)
        strcad = "if( " & strcad & " )"
        PrintLine(libre, TAB(9), strcad)
        PrintLine(libre, TAB(9), "{")
        PrintLine(libre, TAB(14), "t.Commit();")
        PrintLine(libre, TAB(14), "return (1);")
        PrintLine(libre, TAB(9), "}")
        PrintLine(libre, TAB(9), "else")
        PrintLine(libre, TAB(9), "{")
        PrintLine(libre, TAB(14), "t.Rollback();")
        PrintLine(libre, TAB(14), "return (0);")
        PrintLine(libre, TAB(9), "}")
        PrintLine(libre, TAB(5), "}")

        'metodo Eliminar
        strcabeserafuncion = "public int Eliminar" & ComboBox1.Text & " (" & " Negocio." & ComboBox1.Text & " obj" & ComboBox1.Text & ","
        For i = 0 To Me.dgvtabla.RowCount - 1
            If Me.dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                strcabeserafuncion = strcabeserafuncion + " Negocio." & Me.dgvtabla.Rows(i).Cells("tabla").Value & " obj" & Me.dgvtabla.Rows(i).Cells("tabla").Value & ","
            End If
        Next i
        strcabeserafuncion = Mid(strcabeserafuncion, 1, (strcabeserafuncion.Length) - 1) & ")"
        PrintLine(libre, TAB(5), strcabeserafuncion)
        PrintLine(libre, TAB(5), "{")

        PrintLine(libre, TAB(9), "System.Data.SqlClient.SqlTransaction t;")
        PrintLine(libre, TAB(9), "t = this.IniciarTransaccion;")


        strcad = String.Empty
        For i = 0 To Me.dgvtabla.RowCount - 1
            If Me.dgvtabla.Rows(i).Cells("dependiente").Value = True Then
                strcad = strcad + "(obj" & Me.dgvtabla.Rows(i).Cells("tabla").Value & ".Eliminar(t)==1) && "
            End If
        Next i
        strcad = Mid(strcad, 1, (strcad.Length) - 4)
        strcad = "if( " & strcad & " )"
        PrintLine(libre, TAB(9), strcad)
        PrintLine(libre, TAB(9), "{")
        PrintLine(libre, TAB(14), "t.Commit();")
        PrintLine(libre, TAB(14), "return (1);")
        PrintLine(libre, TAB(9), "}")
        PrintLine(libre, TAB(9), "else")
        PrintLine(libre, TAB(9), "{")
        PrintLine(libre, TAB(14), "t.Rollback();")
        PrintLine(libre, TAB(14), "return (0);")
        PrintLine(libre, TAB(9), "}")
        PrintLine(libre, TAB(5), "}")




        PrintLine(libre, "}")
        FileClose(libre)




        'Public Function Modificararbol(ByVal objarbol As Negocio.Arbol, ByVal objhoja As Negocio.Hoja, ByVal objraiz As Negocio.Raiz, ByVal objtallo As Negocio.tallo) As Integer
        '    Dim t As System.Data.SqlClient.SqlTransaction
        '    t = Me.IniciarTransaccion
        '    If (objarbol.Modificar(t) = 1) And (objhoja.Modificar(t) = 1) And (objraiz.Modificar(t) = 1) And (objtallo.Modificar(t) = 1) Then
        '        t.Commit()
        '        Return (1)
        '    Else
        '        t.Rollback()
        '        Return (0)
        '    End If
        'End Function
        'Public Function Eliminarrarbol(ByVal objarbol As Negocio.Arbol, ByVal objhoja As Negocio.Hoja, ByVal objraiz As Negocio.Raiz, ByVal objtallo As Negocio.tallo) As Integer
        '    Dim t As System.Data.SqlClient.SqlTransaction
        '    t = Me.IniciarTransaccion
        '    If (objarbol.Eliminar(t) = 1) And (objhoja.Eliminar(t) = 1) And (objraiz.Eliminar(t) = 1) And (objtallo.Eliminar(t) = 1) Then
        '        t.Commit()
        '        Return (1)
        '    Else
        '        t.Rollback()
        '        Return (0)
        '    End If
        'End Function



    End Sub
#End Region

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        FolderBrowserDialog1.ShowDialog()
        txbRuta.Text = FolderBrowserDialog1.SelectedPath
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        FolderBrowserDialog1.ShowDialog()
        Me.TxbRutaCtrl.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub FormularioSuperClase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Utilitarios.servidor = String.Empty Then
            MsgBox("Configure los datos del servidor...", MsgBoxStyle.Information)
        Else
            Me.txtdb.Text = Utilitarios.Basededatos
            Me.txtserver.Text = Utilitarios.servidor
            Me.cargartablas()
        End If

        varLenguaje = VISUAL_BASIC
        cmbLenguaje.SelectedIndex = VISUAL_BASIC

    End Sub

    Private Sub cmbLenguaje_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLenguaje.SelectedIndexChanged
        varLenguaje = cmbLenguaje.SelectedIndex
    End Sub
End Class