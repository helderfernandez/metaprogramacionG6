Imports System.Data.SqlClient
Imports System.Data.OleDb


Public Class formGeneradorClasesSQL
    Inherits System.Windows.Forms.Form
    Private da As OleDbDataAdapter
    Private ds As DataSet
    Private conexion As OleDbConnection
    Private t As New conexion
    Dim nrofilas As Integer
    Friend WithEvents btnCargarTabla As System.Windows.Forms.Button
    Friend WithEvents dgvTablas As System.Windows.Forms.DataGridView
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txbunidaddisco As System.Windows.Forms.TextBox
    Friend WithEvents NombreTabla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Generar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NombreArchivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreClase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Guardaren As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Ver As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    ' Defino la estructura del array de campos
    Structure regCampo
        Dim nombre As String
        Dim tipo As String
    End Structure

    ' Defino el array donde se guardarán los datos de la tabla
    Dim arrEstructura() As regCampo

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents grpInformacionClase As System.Windows.Forms.GroupBox
    Friend WithEvents txtCadena As System.Windows.Forms.TextBox
    Friend WithEvents lblCadena As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtdb As System.Windows.Forms.TextBox
    Friend WithEvents txtserver As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGenerarClase As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cblenguajeProgramacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txbcarpeta As System.Windows.Forms.TextBox
    Friend WithEvents TxBLibreriadeclases As System.Windows.Forms.TextBox
    Friend WithEvents checkedListBox2 As System.Windows.Forms.CheckedListBox
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents SandDockManager1 As TD.SandDock.SandDockManager
    Friend WithEvents leftSandDock As TD.SandDock.DockContainer
    Friend WithEvents bottomSandDock As TD.SandDock.DockContainer
    Friend WithEvents topSandDock As TD.SandDock.DockContainer
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents rightSandDock As TD.SandDock.DockContainer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formGeneradorClasesSQL))
        Me.grpInformacionClase = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txbunidaddisco = New System.Windows.Forms.TextBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.dgvTablas = New System.Windows.Forms.DataGridView()
        Me.NombreTabla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Generar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NombreArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreClase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Guardaren = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Ver = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.txtCadena = New System.Windows.Forms.TextBox()
        Me.lblCadena = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCargarTabla = New System.Windows.Forms.Button()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtdb = New System.Windows.Forms.TextBox()
        Me.txtserver = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGenerarClase = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.checkedListBox2 = New System.Windows.Forms.CheckedListBox()
        Me.TxBLibreriadeclases = New System.Windows.Forms.TextBox()
        Me.txbcarpeta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cblenguajeProgramacion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SandDockManager1 = New TD.SandDock.SandDockManager()
        Me.leftSandDock = New TD.SandDock.DockContainer()
        Me.bottomSandDock = New TD.SandDock.DockContainer()
        Me.topSandDock = New TD.SandDock.DockContainer()
        Me.rightSandDock = New TD.SandDock.DockContainer()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.grpInformacionClase.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvTablas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpInformacionClase
        '
        Me.grpInformacionClase.Controls.Add(Me.Panel1)
        Me.grpInformacionClase.Controls.Add(Me.dgvTablas)
        Me.grpInformacionClase.Controls.Add(Me.txtCadena)
        Me.grpInformacionClase.Controls.Add(Me.lblCadena)
        Me.grpInformacionClase.Location = New System.Drawing.Point(8, 310)
        Me.grpInformacionClase.Name = "grpInformacionClase"
        Me.grpInformacionClase.Size = New System.Drawing.Size(810, 319)
        Me.grpInformacionClase.TabIndex = 1
        Me.grpInformacionClase.TabStop = False
        Me.grpInformacionClase.Text = "Información de la clase"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.txbunidaddisco)
        Me.Panel1.Controls.Add(Me.CheckBox4)
        Me.Panel1.Controls.Add(Me.CheckBox3)
        Me.Panel1.Controls.Add(Me.CheckBox2)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Location = New System.Drawing.Point(13, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(790, 25)
        Me.Panel1.TabIndex = 20
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(697, -3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 25)
        Me.Button1.TabIndex = 38
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txbunidaddisco
        '
        Me.txbunidaddisco.Location = New System.Drawing.Point(590, -1)
        Me.txbunidaddisco.Name = "txbunidaddisco"
        Me.txbunidaddisco.Size = New System.Drawing.Size(100, 22)
        Me.txbunidaddisco.TabIndex = 24
        Me.txbunidaddisco.Text = "c:\"
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(533, 2)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(48, 20)
        Me.CheckBox4.TabIndex = 23
        Me.CheckBox4.Text = "En:"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(409, 2)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(96, 20)
        Me.CheckBox3.TabIndex = 22
        Me.CheckBox3.Text = "Automatico"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(286, 2)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(96, 20)
        Me.CheckBox2.TabIndex = 21
        Me.CheckBox2.Text = "Automatico"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(175, 2)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(69, 20)
        Me.CheckBox1.TabIndex = 20
        Me.CheckBox1.Text = "Todas"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'dgvTablas
        '
        Me.dgvTablas.AllowUserToAddRows = False
        Me.dgvTablas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvTablas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTablas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NombreTabla, Me.Generar, Me.NombreArchivo, Me.NombreClase, Me.Guardaren, Me.Ver})
        Me.dgvTablas.Location = New System.Drawing.Point(7, 80)
        Me.dgvTablas.Name = "dgvTablas"
        Me.dgvTablas.RowHeadersWidth = 51
        Me.dgvTablas.Size = New System.Drawing.Size(777, 232)
        Me.dgvTablas.TabIndex = 15
        '
        'NombreTabla
        '
        Me.NombreTabla.HeaderText = "Tabla"
        Me.NombreTabla.MinimumWidth = 6
        Me.NombreTabla.Name = "NombreTabla"
        Me.NombreTabla.Width = 125
        '
        'Generar
        '
        Me.Generar.HeaderText = "Generar"
        Me.Generar.MinimumWidth = 6
        Me.Generar.Name = "Generar"
        Me.Generar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Generar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Generar.Width = 125
        '
        'NombreArchivo
        '
        Me.NombreArchivo.HeaderText = "Nombre Archivo"
        Me.NombreArchivo.MinimumWidth = 6
        Me.NombreArchivo.Name = "NombreArchivo"
        Me.NombreArchivo.Width = 125
        '
        'NombreClase
        '
        Me.NombreClase.HeaderText = "Nombre Clase"
        Me.NombreClase.MinimumWidth = 6
        Me.NombreClase.Name = "NombreClase"
        Me.NombreClase.Width = 125
        '
        'Guardaren
        '
        Me.Guardaren.HeaderText = "path"
        Me.Guardaren.MinimumWidth = 6
        Me.Guardaren.Name = "Guardaren"
        Me.Guardaren.Width = 125
        '
        'Ver
        '
        Me.Ver.HeaderText = "Vista Previa"
        Me.Ver.MinimumWidth = 6
        Me.Ver.Name = "Ver"
        Me.Ver.Width = 125
        '
        'txtCadena
        '
        Me.txtCadena.Location = New System.Drawing.Point(163, 18)
        Me.txtCadena.Name = "txtCadena"
        Me.txtCadena.ReadOnly = True
        Me.txtCadena.Size = New System.Drawing.Size(580, 22)
        Me.txtCadena.TabIndex = 0
        Me.txtCadena.Text = "packet size=4096;integrated security=SSPI;data source=server;persist security inf" &
    "o=False;initial catalog=db"
        '
        'lblCadena
        '
        Me.lblCadena.AutoSize = True
        Me.lblCadena.Location = New System.Drawing.Point(19, 21)
        Me.lblCadena.Name = "lblCadena"
        Me.lblCadena.Size = New System.Drawing.Size(131, 16)
        Me.lblCadena.TabIndex = 0
        Me.lblCadena.Text = "Cadena de conexión"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCargarTabla)
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.txtdb)
        Me.GroupBox1.Controls.Add(Me.txtserver)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 269)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(813, 45)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parametros"
        '
        'btnCargarTabla
        '
        Me.btnCargarTabla.Location = New System.Drawing.Point(589, 9)
        Me.btnCargarTabla.Name = "btnCargarTabla"
        Me.btnCargarTabla.Size = New System.Drawing.Size(144, 26)
        Me.btnCargarTabla.TabIndex = 5
        Me.btnCargarTabla.Text = "Cargar Tabla"
        Me.btnCargarTabla.UseVisualStyleBackColor = True
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(242, 15)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(97, 16)
        Me.LinkLabel2.TabIndex = 4
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Base de Datos"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 15)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(58, 16)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Servidor"
        '
        'txtdb
        '
        Me.txtdb.Location = New System.Drawing.Point(342, 12)
        Me.txtdb.Name = "txtdb"
        Me.txtdb.Size = New System.Drawing.Size(240, 22)
        Me.txtdb.TabIndex = 1
        Me.txtdb.Text = "dbbosque"
        '
        'txtserver
        '
        Me.txtserver.Location = New System.Drawing.Point(72, 12)
        Me.txtserver.Name = "txtserver"
        Me.txtserver.Size = New System.Drawing.Size(120, 22)
        Me.txtserver.TabIndex = 0
        Me.txtserver.Text = "COMPUTER-09"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGenerarClase, Me.ToolStripButton2, Me.ToolStripButton1, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 543)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(687, 27)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGenerarClase
        '
        Me.btnGenerarClase.Image = CType(resources.GetObject("btnGenerarClase.Image"), System.Drawing.Image)
        Me.btnGenerarClase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGenerarClase.Name = "btnGenerarClase"
        Me.btnGenerarClase.Size = New System.Drawing.Size(124, 24)
        Me.btnGenerarClase.Text = "Generar Clase"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(90, 24)
        Me.ToolStripButton2.Text = "Cancelar"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(108, 24)
        Me.ToolStripButton1.Text = "Ver Archivo"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(62, 24)
        Me.ToolStripButton3.Text = "Salir"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TabControl1)
        Me.GroupBox2.Controls.Add(Me.TxBLibreriadeclases)
        Me.GroupBox2.Controls.Add(Me.txbcarpeta)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cblenguajeProgramacion)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(808, 257)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Parametro para generar"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(7, 55)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(777, 185)
        Me.TabControl1.TabIndex = 17
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CheckedListBox1)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(769, 156)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Clases que usan instruccion sql."
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"Crear la Clase", "Crear la Clase con metodos para el uso de transacciones"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(10, 17)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(456, 72)
        Me.CheckedListBox1.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(7, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(461, 38)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Los metodos que se generan para hacer las altas, bajas y modificaciones.  Utiliza" &
    "n instrucciones SQL."
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.checkedListBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(769, 156)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Clases que usan procedimientos almacenados"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(4, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(460, 46)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Los metodos que se generan para hacer las altas, bajas y modificaciones.  Utiliza" &
    "n procedimientos almacenados que tambien son generados por esta aplicacion."
        '
        'checkedListBox2
        '
        Me.checkedListBox2.FormattingEnabled = True
        Me.checkedListBox2.Items.AddRange(New Object() {"Crear la Clase", "Crear la Clase con metodos para el uso de transacciones"})
        Me.checkedListBox2.Location = New System.Drawing.Point(7, 17)
        Me.checkedListBox2.Name = "checkedListBox2"
        Me.checkedListBox2.Size = New System.Drawing.Size(739, 72)
        Me.checkedListBox2.TabIndex = 14
        '
        'TxBLibreriadeclases
        '
        Me.TxBLibreriadeclases.Enabled = False
        Me.TxBLibreriadeclases.Location = New System.Drawing.Point(503, 32)
        Me.TxBLibreriadeclases.Name = "TxBLibreriadeclases"
        Me.TxBLibreriadeclases.Size = New System.Drawing.Size(79, 22)
        Me.TxBLibreriadeclases.TabIndex = 16
        Me.TxBLibreriadeclases.Text = "Negocio."
        '
        'txbcarpeta
        '
        Me.txbcarpeta.Enabled = False
        Me.txbcarpeta.Location = New System.Drawing.Point(589, 32)
        Me.txbcarpeta.Name = "txbcarpeta"
        Me.txbcarpeta.Size = New System.Drawing.Size(186, 22)
        Me.txbcarpeta.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(374, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Espacio de nombre:"
        '
        'cblenguajeProgramacion
        '
        Me.cblenguajeProgramacion.FormattingEnabled = True
        Me.cblenguajeProgramacion.Items.AddRange(New Object() {"Visual Basic .Net", "C#.Net"})
        Me.cblenguajeProgramacion.Location = New System.Drawing.Point(174, 24)
        Me.cblenguajeProgramacion.Name = "cblenguajeProgramacion"
        Me.cblenguajeProgramacion.Size = New System.Drawing.Size(193, 24)
        Me.cblenguajeProgramacion.TabIndex = 11
        Me.cblenguajeProgramacion.Text = "Visual Basic .Net"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Lenguaje de programacion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(689, 640)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Por: Ing. Ernesto Soto Roca"
        '
        'SandDockManager1
        '
        Me.SandDockManager1.OwnerForm = Me
        '
        'leftSandDock
        '
        Me.leftSandDock.Dock = System.Windows.Forms.DockStyle.Left
        Me.leftSandDock.Guid = New System.Guid("0bcb2495-6001-4934-afdc-ddf66be56be2")
        Me.leftSandDock.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400)
        Me.leftSandDock.Location = New System.Drawing.Point(0, 0)
        Me.leftSandDock.Manager = Me.SandDockManager1
        Me.leftSandDock.Name = "leftSandDock"
        Me.leftSandDock.Size = New System.Drawing.Size(0, 570)
        Me.leftSandDock.TabIndex = 11
        '
        'bottomSandDock
        '
        Me.bottomSandDock.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bottomSandDock.Guid = New System.Guid("c1ffbb0c-fd57-48b6-b3da-cb82588b77c2")
        Me.bottomSandDock.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400)
        Me.bottomSandDock.Location = New System.Drawing.Point(0, 570)
        Me.bottomSandDock.Manager = Me.SandDockManager1
        Me.bottomSandDock.Name = "bottomSandDock"
        Me.bottomSandDock.Size = New System.Drawing.Size(687, 0)
        Me.bottomSandDock.TabIndex = 13
        '
        'topSandDock
        '
        Me.topSandDock.Dock = System.Windows.Forms.DockStyle.Top
        Me.topSandDock.Guid = New System.Guid("2c31ae25-bcff-4bb3-a1a2-1ed59fa76456")
        Me.topSandDock.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400)
        Me.topSandDock.Location = New System.Drawing.Point(0, 0)
        Me.topSandDock.Manager = Me.SandDockManager1
        Me.topSandDock.Name = "topSandDock"
        Me.topSandDock.Size = New System.Drawing.Size(687, 0)
        Me.topSandDock.TabIndex = 14
        '
        'rightSandDock
        '
        Me.rightSandDock.Dock = System.Windows.Forms.DockStyle.Right
        Me.rightSandDock.Guid = New System.Guid("e1adfd6a-85b6-41ce-b261-c1da0e27af0c")
        Me.rightSandDock.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400)
        Me.rightSandDock.Location = New System.Drawing.Point(687, 0)
        Me.rightSandDock.Manager = Me.SandDockManager1
        Me.rightSandDock.Name = "rightSandDock"
        Me.rightSandDock.Size = New System.Drawing.Size(0, 543)
        Me.rightSandDock.TabIndex = 12
        '
        'formGeneradorClasesSQL
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(687, 570)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rightSandDock)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpInformacionClase)
        Me.Controls.Add(Me.leftSandDock)
        Me.Controls.Add(Me.bottomSandDock)
        Me.Controls.Add(Me.topSandDock)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formGeneradorClasesSQL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generador de clase."
        Me.grpInformacionClase.ResumeLayout(False)
        Me.grpInformacionClase.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvTablas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

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
            MsgBox("Error de conexion al servidor", MsgBoxStyle.Critical)
        End Try

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
        End If
    End Sub
    Private Sub formGeneradorClasesSQL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCadena.SelectAll()
        If Utilitarios.servidor = String.Empty Then
            MsgBox("Configure los datos del servidor...", MsgBoxStyle.Information)
        Else
            Me.txtdb.Text = Utilitarios.Basededatos
            Me.txtserver.Text = Utilitarios.servidor
            cartgartablasgrilla()
        End If
    End Sub


    Private Sub SeleccionarTexto(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCadena.GotFocus
        ' Selecciono el texto del casillero
        sender.SelectAll()
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

    ' Este procedimiento genera un archivo de texto con extensión .VB con la definición de una clase correspondiente a una tabla de una base de datos.
    ' Al basarse enteramente en la estructura de una tabla de SQL Server, las propiedades de la clases son el mismo tipo que en la tabla "física", por
    ' ejemplo en lugar de tener propiedades tipo Integer va a tener propiedades de tipo Int32, en lugar de Short van a ser Int16, etc.
    ' Esto no genera ningún problema, ya que VB.NET convierte en forma automática los datos (ya que las clase toma los datos "oficiales" de .NET).

    Private Sub GenerarClasevb_sp(ByVal archivo As String, ByVal clase As String)
        ' Doy formato al nombre del archivo
        ' Defino variables
        Dim libre As Integer = FreeFile()
        Dim reg As regCampo

        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, archivo, OpenMode.Output)

        ' Comienzo a generar la clase
        PrintLine(libre, "public class " & clase)
        PrintLine(libre, TAB(4), "Inherits Dal.TDatosSQL")

        ' Creo una línea divisoria (espacio en blanco)
        PrintLine(libre, "")

        ' Comienzo a recorrer todos los campos guardados en el array
        'region de atributos
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "atributos" & Chr(34))
        For Each reg In arrEstructura
            ' Creo la variable local para usarse con la propiedad
            PrintLine(libre, TAB(4), TAB(4), "    private " & reg.nombre & " as " & reg.tipo)
        Next
        PrintLine(libre, TAB(4), "#end region")
        'la region de propiedades
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "propiedades" & Chr(34))
        Dim cantidaddeatribuotas As Integer
        For Each reg In arrEstructura
            ' Creo la cabecera de la propiedad
            PrintLine(libre, TAB(4), "public property P" & reg.nombre & "() as " & reg.tipo)
            ' Creo la cabecera del get de la propiedad
            PrintLine(libre, TAB(8), "get")
            ' Creo el cuerpo del get de la propiedad
            PrintLine(libre, TAB(12), "return " & reg.nombre)
            ' Creo el pie del get de la propiedad
            PrintLine(libre, TAB(8), "end get")
            ' Creo una línea divisoria (espacio en blanco)
            PrintLine(libre, "")
            ' Creo la cabecera del set de la propiedad
            PrintLine(libre, TAB(8), "set(byval value as " & reg.tipo & ")")
            ' Creo el cuerpo del set de la propiedad
            PrintLine(libre, TAB(12), "" & reg.nombre & " = value")
            ' Creo el pie del set de la propiedad
            PrintLine(libre, TAB(8), "end set")
            ' Creo el pie de la propiedad
            PrintLine(libre, TAB(4), "end property")
            ' Creo una línea divisoria (espacio en blanco)
            PrintLine(libre, "")
            cantidaddeatribuotas += 1
        Next
        PrintLine(libre, TAB(4), "#end region")
        'la region de metodos
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "Metodos" & Chr(34))
        PrintLine(libre, TAB(4), "Private Function ABM(ByVal tarea As Utilitario.Utilitario.Tarea) As Integer")
        PrintLine(libre, TAB(4), "    Dim resultado As Integer")
        PrintLine(libre, TAB(4), "    Dim args(" & (cantidaddeatribuotas + 2).ToString & ") As System.Object")
        PrintLine(libre, TAB(4), "    args(0) = tarea")
        Dim i As Integer = 1
        For Each reg In arrEstructura
            PrintLine(libre, TAB(4), TAB(4), "    args(" & i.ToString() & ") = Me.p" & reg.nombre)
            i = i + 1
        Next
        PrintLine(libre, TAB(4), "    args(" & i.ToString() & ") = resultado")
        PrintLine(libre, TAB(4), "    resultado = Me.Ejecutar(" & Chr(34) & "Sp_abm" & clase & Chr(34) & ", args)")
        PrintLine(libre, TAB(4), "    Return resultado")
        PrintLine(libre, TAB(4), "End Function")
        PrintLine(libre, TAB(4), "Public Function Guardar() As Integer")
        PrintLine(libre, TAB(4), "    Return ABM(Utilitario.Tarea.guardar)")
        PrintLine(libre, TAB(4), "End Function")
        PrintLine(libre, TAB(4), "Public Function modificar() As Integer")
        PrintLine(libre, TAB(4), "    Return ABM(Utilitario.Tarea.modificar)")
        PrintLine(libre, TAB(4), "End Function")
        PrintLine(libre, TAB(4), "Public Function eliminar() As Integer")
        PrintLine(libre, TAB(4), "    Return ABM(Utilitario.Tarea.eliminar)")
        PrintLine(libre, TAB(4), "End Function")
        PrintLine(libre, TAB(4), "Public Function Traer_" & clase & "() As DataTable")
        PrintLine(libre, TAB(4), "    Dim args(1) As System.Object")
        PrintLine(libre, TAB(4), "    args(0) = Me.pId" & clase)
        PrintLine(libre, TAB(4), "    Return Me.TraerDataTable(" & Chr(34) & "sp_traer" & clase & Chr(34) & ", args)")
        PrintLine(libre, TAB(4), "End Function")

        PrintLine(libre, TAB(4), "Public Function Generarid() As Long")
        PrintLine(libre, TAB(4), "    Return Me.generarcodigo(" & Chr(34) & clase & Chr(34) & ")")
        PrintLine(libre, TAB(4), "End Function")

        PrintLine(libre, TAB(4), "#end region")

        ' Comienzo a generar la clase
        PrintLine(libre, "end class")

        ' Cierro el archivo de versión
        FileClose(libre)
    End Sub

    Private Sub GenerarClaseTransaccionesvb_sp(ByVal archivo As String, ByVal clase As String)
        ' Doy formato al nombre del archivo

        ' Defino variables
        Dim libre As Integer = FreeFile()
        Dim reg As regCampo

        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, archivo, OpenMode.Output)

        ' Comienzo a generar la clase
        PrintLine(libre, "public class " & clase)
        PrintLine(libre, TAB(4), "Inherits Dal.TDatosSQL")

        ' Creo una línea divisoria (espacio en blanco)
        PrintLine(libre, "")

        ' Comienzo a recorrer todos los campos guardados en el array
        'region de atributos
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "atributos" & Chr(34))
        For Each reg In arrEstructura
            ' Creo la variable local para usarse con la propiedad
            PrintLine(libre, TAB(4), TAB(4), "    private " & reg.nombre & " as " & reg.tipo)
        Next
        PrintLine(libre, TAB(4), "#end region")
        'la region de propiedades
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "propiedades" & Chr(34))
        Dim cantidaddeatribuotas As Integer
        For Each reg In arrEstructura
            ' Creo la cabecera de la propiedad
            PrintLine(libre, TAB(4), "public property P" & reg.nombre & "() as " & reg.tipo)
            ' Creo la cabecera del get de la propiedad
            PrintLine(libre, TAB(8), "get")
            ' Creo el cuerpo del get de la propiedad
            PrintLine(libre, TAB(12), "return " & reg.nombre)
            ' Creo el pie del get de la propiedad
            PrintLine(libre, TAB(8), "end get")
            ' Creo una línea divisoria (espacio en blanco)
            PrintLine(libre, "")
            ' Creo la cabecera del set de la propiedad
            PrintLine(libre, TAB(8), "set(byval value as " & reg.tipo & ")")
            ' Creo el cuerpo del set de la propiedad
            PrintLine(libre, TAB(12), "" & reg.nombre & " = value")
            ' Creo el pie del set de la propiedad
            PrintLine(libre, TAB(8), "end set")
            ' Creo el pie de la propiedad
            PrintLine(libre, TAB(4), "end property")
            ' Creo una línea divisoria (espacio en blanco)
            PrintLine(libre, "")
            cantidaddeatribuotas += 1
        Next
        PrintLine(libre, TAB(4), "#end region")
        'la region de metodos
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "Metodos" & Chr(34))
        PrintLine(libre, TAB(4), "Private Function ABM(ByVal tarea As Utilitario.Utilitario.Tarea, ByRef t As System.Data.SqlClient.SqlTransaction) As Integer")
        PrintLine(libre, TAB(4), "    Dim resultado As Integer")
        PrintLine(libre, TAB(4), "    Dim args(" & (cantidaddeatribuotas + 2).ToString & ") As System.Object")
        PrintLine(libre, TAB(4), "    args(0) = tarea")
        Dim i As Integer = 1
        For Each reg In arrEstructura
            PrintLine(libre, TAB(4), TAB(4), "    args(" & i.ToString() & ") = Me.p" & reg.nombre)
            i = i + 1
        Next
        PrintLine(libre, TAB(4), "    args(" & i.ToString() & ") = resultado")
        PrintLine(libre, TAB(4), "    resultado = Me.Ejecutar(" & Chr(34) & "Sp_abm" & clase & Chr(34) & ", args,t)")
        PrintLine(libre, TAB(4), "    return resultado")
        PrintLine(libre, TAB(4), "End Function")
        PrintLine(libre, TAB(4), "Public Function Guardar(ByRef t As System.Data.SqlClient.SqlTransaction) As Integer")
        PrintLine(libre, TAB(4), "    Return ABM(Utilitario.Tarea.Guardar,t)")
        PrintLine(libre, TAB(4), "End Function")
        PrintLine(libre, TAB(4), "Public Function modificar(ByRef t As System.Data.SqlClient.SqlTransaction) As Integer")
        PrintLine(libre, TAB(4), "    return ABM(Utilitario.Tarea.modificar,t)")
        PrintLine(libre, TAB(4), "End Function")
        PrintLine(libre, TAB(4), "Public Function eliminar(ByRef t As System.Data.SqlClient.SqlTransaction) As Integer")
        PrintLine(libre, TAB(4), "    return ABM(Utilitario.Tarea.eliminar,t)")
        PrintLine(libre, TAB(4), "End Function")
        PrintLine(libre, TAB(4), "Public Function Traer_" & clase & "() As DataTable")
        PrintLine(libre, TAB(4), "    Dim args(1) As System.Object")
        PrintLine(libre, TAB(4), "    args(0) = Me.pId" & clase)
        PrintLine(libre, TAB(4), "    return Me.TraerDataTable(" & Chr(34) & "sp_traer" & clase & Chr(34) & ", args)")
        PrintLine(libre, TAB(4), "End Function")
        PrintLine(libre, TAB(4), "Public Function Generarid() As Long")
        PrintLine(libre, TAB(4), "    Return Me.generarcodigo(" & Chr(34) & clase & Chr(34) & ")")
        PrintLine(libre, TAB(4), "End Function")

        PrintLine(libre, TAB(4), "#end region")

        ' Comienzo a generar la clase
        PrintLine(libre, "end class")

        ' Cierro el archivo de versión
        FileClose(libre)
    End Sub
    Private Sub GenerarClasevbsql(ByVal archivo As String, ByVal clase As String)
        ' Defino variables
        Dim libre As Integer = FreeFile()
        Dim reg As regCampo

        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, archivo, OpenMode.Output)

        ' Comienzo a generar la clase
        PrintLine(libre, "public class " & clase)
        PrintLine(libre, TAB(4), "Inherits Dal.TDatosSQL")

        ' Creo una línea divisoria (espacio en blanco)
        PrintLine(libre, "")

        ' Comienzo a recorrer todos los campos guardados en el array
        'region de atributos
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "atributos" & Chr(34))
        For Each reg In arrEstructura
            ' Creo la variable local para usarse con la propiedad
            PrintLine(libre, TAB(4), TAB(4), "    private " & reg.nombre & " as " & reg.tipo)
        Next
        PrintLine(libre, TAB(4), "#end region")
        'la region de propiedades
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "propiedades" & Chr(34))
        Dim cantidaddeatribuotas As Integer
        For Each reg In arrEstructura
            ' Creo la cabecera de la propiedad
            PrintLine(libre, TAB(4), "public property P" & reg.nombre & "() as " & reg.tipo)
            ' Creo la cabecera del get de la propiedad
            PrintLine(libre, TAB(8), "get")
            ' Creo el cuerpo del get de la propiedad
            PrintLine(libre, TAB(12), "return " & reg.nombre)
            ' Creo el pie del get de la propiedad
            PrintLine(libre, TAB(8), "end get")
            ' Creo una línea divisoria (espacio en blanco)
            PrintLine(libre, "")
            ' Creo la cabecera del set de la propiedad
            PrintLine(libre, TAB(8), "set(byval value as " & reg.tipo & ")")
            ' Creo el cuerpo del set de la propiedad
            PrintLine(libre, TAB(12), "" & reg.nombre & " = value")
            ' Creo el pie del set de la propiedad
            PrintLine(libre, TAB(8), "end set")
            ' Creo el pie de la propiedad
            PrintLine(libre, TAB(4), "end property")
            ' Creo una línea divisoria (espacio en blanco)
            PrintLine(libre, "")
            cantidaddeatribuotas += 1
        Next
        PrintLine(libre, TAB(4), "#end region")
        'la region de metodos
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "Metodos" & Chr(34))


        PrintLine(libre, TAB(4), "Public Function guardar() As Integer")
        Dim cadenasql As String = "Dim strcad As String = " & Chr(34) & "Insert into " & clase & " values("
        Dim i As Integer = 1
        'Dim strcad As String = "Insert into natural values (acod_cliente,'anombre','aapp','apm',afec_nac,aCod_profesion)"
        For Each reg In arrEstructura 'cadena sql base
            If (reg.tipo = "String") Then
                cadenasql = cadenasql & "'#" & reg.nombre & "',"
            Else
                cadenasql = cadenasql & "#" & reg.nombre & ","
            End If
        Next
        cadenasql = Mid(cadenasql, 1, (cadenasql.Length) - 1)
        cadenasql = cadenasql & ")" & Chr(34)
        PrintLine(libre, TAB(4), TAB(4), cadenasql)

        For Each reg In arrEstructura ' reemplazamos las partes de la cadena
            PrintLine(libre, TAB(4), TAB(4), "    strcad = strcad.Replace(" & Chr(34) & "#" & reg.nombre & Chr(34) & ", Me.P" & reg.nombre & ")")
        Next
        PrintLine(libre, TAB(4), TAB(4), "    Return Me.ejecutarDML(strcad)")
        PrintLine(libre, TAB(4), "End Function")

        PrintLine(libre, TAB(4), "Public Function Traer_" & clase & "(ByVal strwhere As String) As DataTable")
        PrintLine(libre, TAB(4), "   Dim strcad As String =" & Chr(34) & " select * from " & clase & Chr(34))

        PrintLine(libre, TAB(4), "   If Not (strwhere = String.Empty) Then")
        PrintLine(libre, TAB(4), "        strcad = strcad & " & Chr(34) & "Where" & Chr(34) & " & strwhere")
        PrintLine(libre, TAB(4), "   End If")
        PrintLine(libre, TAB(4), "   Return Me.TraerDataTablestrSql(strcad)")
        PrintLine(libre, TAB(4), "End Function")


        PrintLine(libre, TAB(4), "Public Function eliminar(ByVal strwhere As String) As Integer")
        PrintLine(libre, TAB(4), "    Dim strcad As String = " & Chr(34) & "delete * from " & clase & Chr(34))
        PrintLine(libre, TAB(4), "    If strwhere <> String.Empty Then")
        PrintLine(libre, TAB(4), "        strcad = strcad & " & Chr(34) & "Where" & Chr(34) & " & strwhere")
        PrintLine(libre, TAB(4), "    End If")
        PrintLine(libre, TAB(4), "    Return Me.ejecutarDML(strcad)")
        PrintLine(libre, TAB(4), "End Function")

        'modificar
        PrintLine(libre, TAB(4), "Public Function Modificar() As Integer")
        cadenasql = String.Empty ' "Dim strcad As String = "update " & clase & " set"
        i = 1
        'Dim strcad As String = "update tipo set cod_tipo=#cod_tipo,descripcion_tipo='#descripcion_tipo') where idtipo=#idtipo"
        For Each reg In arrEstructura 'cadena sql base
            If (reg.tipo = "String") Then
                cadenasql = cadenasql & reg.nombre & "'=#" & reg.nombre & "',"
            Else
                cadenasql = cadenasql & reg.nombre & "=#" & reg.nombre & ","
            End If
        Next
        cadenasql = Mid(cadenasql, 1, (cadenasql.Length) - 1)
        cadenasql = "Dim strcad As String =" & Chr(34) & "update " & clase & " set " & cadenasql & Chr(34)
        PrintLine(libre, TAB(4), TAB(4), "    " & cadenasql)

        For Each reg In arrEstructura ' reemplazamos las partes de la cadena
            PrintLine(libre, TAB(4), TAB(4), "    strcad = strcad.Replace(" & Chr(34) & "#" & reg.nombre & Chr(34) & ", Me.P" & reg.nombre & ")")
        Next
        PrintLine(libre, TAB(4), TAB(4), "    Return Me.ejecutarDML(strcad)")
        PrintLine(libre, TAB(4), "End Function")

        PrintLine(libre, TAB(4), "Public Function Generarid() As Long")
        PrintLine(libre, TAB(4), "    Return Me.generarcodigo(" & Chr(34) & clase & Chr(34) & ")")
        PrintLine(libre, TAB(4), "End Function")

        PrintLine(libre, TAB(4), "#end region")

        ' Comienzo a generar la clase
        PrintLine(libre, "end class")

        ' Cierro el archivo de versión
        FileClose(libre)
    End Sub
    Private Sub GenerarClasevbsqlTrans(ByVal archivo As String, ByVal clase As String)
        ' Doy formato al nombre del archivo
        ' Defino variables
        Dim libre As Integer = FreeFile()
        Dim reg As regCampo

        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, archivo, OpenMode.Output)

        ' Comienzo a generar la clase
        PrintLine(libre, "public class " & clase)
        PrintLine(libre, TAB(4), "Inherits Dal.TDatosSQL")

        ' Creo una línea divisoria (espacio en blanco)
        PrintLine(libre, "")

        ' Comienzo a recorrer todos los campos guardados en el array
        'region de atributos
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "atributos" & Chr(34))
        For Each reg In arrEstructura
            ' Creo la variable local para usarse con la propiedad
            PrintLine(libre, TAB(4), TAB(4), "    private " & reg.nombre & " as " & reg.tipo)
        Next
        PrintLine(libre, TAB(4), "#end region")
        'la region de propiedades
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "propiedades" & Chr(34))
        Dim cantidaddeatribuotas As Integer
        For Each reg In arrEstructura
            PrintLine(libre, TAB(4), "public property P" & reg.nombre & "() as " & reg.tipo)
            PrintLine(libre, TAB(8), "get")
            PrintLine(libre, TAB(12), "return " & reg.nombre)
            PrintLine(libre, TAB(8), "end get")
            PrintLine(libre, "")
            PrintLine(libre, TAB(8), "set(byval value as " & reg.tipo & ")")
            PrintLine(libre, TAB(12), "" & reg.nombre & " = value")
            PrintLine(libre, TAB(8), "end set")
            PrintLine(libre, TAB(4), "end property")
            PrintLine(libre, "")
            cantidaddeatribuotas += 1
        Next
        PrintLine(libre, TAB(4), "#end region")
        'la region de metodos
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "Metodos" & Chr(34))
        PrintLine(libre, TAB(4), "Public Function guardar(ByRef t As System.Data.SqlClient.SqlTransaction) As Integer")
        Dim cadenasql As String = "Dim strcad As String = " & Chr(34) & "Insert into " & clase & " values("
        Dim i As Integer = 1
        For Each reg In arrEstructura 'cadena sql base
            If (reg.tipo = "String") Then
                cadenasql = cadenasql & "'#" & reg.nombre & "',"
            Else
                cadenasql = cadenasql & "#" & reg.nombre & ","
            End If
        Next
        cadenasql = Mid(cadenasql, 1, (cadenasql.Length) - 1)
        cadenasql = cadenasql & ")" & Chr(34)
        PrintLine(libre, TAB(4), TAB(4), "    " & cadenasql)

        For Each reg In arrEstructura ' reemplazamos las partes de la cadena
            PrintLine(libre, TAB(4), TAB(4), "    strcad = strcad.Replace(" & Chr(34) & "#" & reg.nombre & Chr(34) & ", Me.P" & reg.nombre & ")")
        Next
        PrintLine(libre, TAB(4), TAB(4), "    Return Me.ejecutarDML(strcad, t)")
        PrintLine(libre, TAB(4), "End Function")

        'modificar
        PrintLine(libre, TAB(4), "Public Function Modificar(ByRef t As System.Data.SqlClient.SqlTransaction) As Integer")
        cadenasql = String.Empty ' "Dim strcad As String = "update " & clase & " set"
        i = 1
        'Dim strcad As String = "update tipo set cod_tipo=#cod_tipo,descripcion_tipo='#descripcion_tipo') where idtipo=#idtipo"
        For Each reg In arrEstructura 'cadena sql base
            If (reg.tipo = "String") Then
                cadenasql = cadenasql & reg.nombre & "'=#" & reg.nombre & "',"
            Else
                cadenasql = cadenasql & reg.nombre & "=#" & reg.nombre & ","
            End If
        Next
        cadenasql = Mid(cadenasql, 1, (cadenasql.Length) - 1)
        cadenasql = "Dim strcad As String =" & Chr(34) & "update " & clase & " set " & cadenasql & Chr(34)
        PrintLine(libre, TAB(4), TAB(4), "    " & cadenasql)

        For Each reg In arrEstructura ' reemplazamos las partes de la cadena
            PrintLine(libre, TAB(4), TAB(4), "    strcad = strcad.Replace(" & Chr(34) & "#" & reg.nombre & Chr(34) & ", Me.P" & reg.nombre & ")")
        Next
        PrintLine(libre, TAB(4), TAB(4), "    Return Me.ejecutarDML(strcad,t)")
        PrintLine(libre, TAB(4), "End Function")

        PrintLine(libre, TAB(4), "Public Function Traer_" & clase & "(ByVal strwhere As String) As DataTable")
        PrintLine(libre, TAB(4), "   Dim strcad As String =" & Chr(34) & " select * from " & clase & Chr(34))

        PrintLine(libre, TAB(4), "   If Not (strwhere = String.Empty) Then")
        PrintLine(libre, TAB(4), "        strcad = strcad & " & Chr(34) & "Where" & Chr(34) & " & strwhere")
        PrintLine(libre, TAB(4), "   End If")
        PrintLine(libre, TAB(4), "   Return Me.TraerDataTablestrSql(strcad)")
        PrintLine(libre, TAB(4), "End Function")


        PrintLine(libre, TAB(4), "Public Function eliminar(ByVal strwhere As String) As Integer")
        PrintLine(libre, TAB(4), "    Dim strcad As String = " & Chr(34) & "delete * from " & clase & Chr(34))
        PrintLine(libre, TAB(4), "    If strwhere <> String.Empty Then")
        PrintLine(libre, TAB(4), "        strcad = strcad & " & Chr(34) & "Where" & Chr(34) & " & strwhere")
        PrintLine(libre, TAB(4), "    End If")
        PrintLine(libre, TAB(4), "    Return Me.ejecutarDML(strcad)")
        PrintLine(libre, TAB(4), "End Function")

        PrintLine(libre, TAB(4), "Public Function Generarid() As Long")
        PrintLine(libre, TAB(4), "    Return Me.generarcodigo(" & Chr(34) & clase & Chr(34) & ")")
        PrintLine(libre, TAB(4), "End Function")

        PrintLine(libre, TAB(4), "#end region")

        ' Comienzo a generar la clase
        PrintLine(libre, "end class")

        ' Cierro el archivo de versión
        FileClose(libre)
    End Sub
    Private Sub GenerarClasec(ByVal archivo As String, ByVal clase As String)

        ' Defino variables
        Dim libre As Integer = FreeFile()
        Dim reg As regCampo

        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, archivo, OpenMode.Output)

        ' Comienzo a generar la clase


        PrintLine(libre, "using System;")
        PrintLine(libre, "using System.Collections.Generic;")
        PrintLine(libre, "using System.Text;")
        PrintLine(libre, "using System.Data;")
        PrintLine(libre, "")
        PrintLine(libre, "namespace " & Me.TxBLibreriadeclases.Text & Me.txbcarpeta.Text & "{")
        PrintLine(libre, "public class " & clase & ":DAL.TDatosSql {")
        'region de atributos
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "atributos" & Chr(34))
        For Each reg In arrEstructura
            ' Creo la variable local para usarse con la propiedad
            PrintLine(libre, TAB(4), TAB(4), "    private " & reg.tipo & " " & reg.nombre & ";")
        Next
        PrintLine(libre, TAB(4), "#endregion")
        'la region de propiedades
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "propiedades" & Chr(34))
        Dim cantidaddeatribuotas As Integer
        For Each reg In arrEstructura
            ' Creo la cabecera de la propiedad
            PrintLine(libre, TAB(8), "public " & reg.tipo & " P" & reg.nombre & "{")
            PrintLine(libre, TAB(8), "   set {" & reg.nombre & "=value;}")
            PrintLine(libre, TAB(8), "   get { return " & reg.nombre & ";}")
            PrintLine(libre, TAB(8), "}")
            PrintLine(libre, "")
            cantidaddeatribuotas += 1
        Next
        PrintLine(libre, TAB(4), "#endregion")

        'la region de metodos
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "Metodos" & Chr(34))
        PrintLine(libre, TAB(4), "private int ABM(Utilitario.Utilitario._ABM tarea) {")
        PrintLine(libre, TAB(4), "    int resultado=0;")
        PrintLine(libre, TAB(4), "    System.Object[] args = new System.Object[" & (cantidaddeatribuotas + 2).ToString & "];")
        PrintLine(libre, TAB(4), "    args[0] = tarea;")
        Dim i As Integer = 1
        For Each reg In arrEstructura
            PrintLine(libre, TAB(4), TAB(4), "    args[" & i.ToString() & "] = this.P" & reg.nombre & ";")
            i = i + 1
        Next
        PrintLine(libre, TAB(4), "    args[" & i.ToString() & "] = resultado;")
        PrintLine(libre, TAB(4), "    resultado = this.Ejecutar(" & Chr(34) & "Sp_abm" & clase & Chr(34) & ", args);")
        PrintLine(libre, TAB(4), "    return resultado;")
        PrintLine(libre, TAB(4), "}")

        PrintLine(libre, TAB(4), "public int Guardar(){")
        PrintLine(libre, TAB(4), "    return ABM(Utilitario.Tarea.guardar);")
        PrintLine(libre, TAB(4), "}")
        PrintLine(libre, TAB(4), "public int Modificar(){")
        PrintLine(libre, TAB(4), "    return ABM(Utilitario.Utilitario._ABM.Modificar);")
        PrintLine(libre, TAB(4), "}")
        PrintLine(libre, TAB(4), " public int Eliminar(){")
        PrintLine(libre, TAB(4), "    return ABM(Utilitario.Utilitario._ABM.Eliminar);")
        PrintLine(libre, TAB(4), "}")
        PrintLine(libre, TAB(4), "public DataTable Traer_" & clase & "(){")
        PrintLine(libre, TAB(4), "    System.Object[] args = new System.Object[1];")
        PrintLine(libre, TAB(4), "    args[0] = this.Pid" & clase & ";")
        PrintLine(libre, TAB(4), "    return this.TraerDataTable(" & Chr(34) & "sp_traer" & clase & Chr(34) & ", args);")
        PrintLine(libre, TAB(4), "}")
        PrintLine(libre, TAB(4), "#endregion")

        PrintLine(libre, "}")
        PrintLine(libre, "}")
        FileClose(libre) ' Cierro el archivo de versión
    End Sub
    Private Sub GenerarClasecTransaccion(ByVal archivo As String, ByVal clase As String)
        ' Doy formato al nombre del archivo
        ' Defino variables
        Dim libre As Integer = FreeFile()
        Dim reg As regCampo

        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, archivo, OpenMode.Output)

        ' Comienzo a generar la clase
        PrintLine(libre, "using System;")
        PrintLine(libre, "using System.Collections.Generic;")
        PrintLine(libre, "using System.Text;")
        PrintLine(libre, "using System.Data;")
        PrintLine(libre, "")
        PrintLine(libre, "namespace " & Me.TxBLibreriadeclases.Text & Me.txbcarpeta.Text & "{")
        PrintLine(libre, "public class " & clase & ":DAL.TDatosSql {")
        'region de atributos
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "atributos" & Chr(34))
        For Each reg In arrEstructura
            ' Creo la variable local para usarse con la propiedad
            PrintLine(libre, TAB(4), TAB(4), "    private " & reg.tipo & " " & reg.nombre & ";")
        Next
        PrintLine(libre, TAB(4), "#endregion")
        'la region de propiedades
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "propiedades" & Chr(34))
        Dim cantidaddeatribuotas As Integer
        For Each reg In arrEstructura
            ' Creo la cabecera de la propiedad
            PrintLine(libre, TAB(8), "public " & reg.tipo & " P" & reg.nombre & "{")
            PrintLine(libre, TAB(8), "   set {" & reg.nombre & "=value;}")
            PrintLine(libre, TAB(8), "   get { return " & reg.nombre & ";}")
            PrintLine(libre, TAB(8), "}")
            PrintLine(libre, "")
            cantidaddeatribuotas += 1
        Next
        PrintLine(libre, TAB(4), "#endregion")

        'la region de metodos
        PrintLine(libre, TAB(4), "#region" & Chr(34) & "Metodos" & Chr(34))
        PrintLine(libre, TAB(4), "private   int  ABM(Utilitario.Utilitario._ABM tarea,ref System.Data.SqlClient.SqlTransaction t){")
        PrintLine(libre, TAB(4), "    int resultado=0;")
        PrintLine(libre, TAB(4), "    System.Object[] args = new System.Object[" & (cantidaddeatribuotas + 2).ToString & "];")
        PrintLine(libre, TAB(4), "    args[0] = tarea;")
        Dim i As Integer = 1
        For Each reg In arrEstructura
            PrintLine(libre, TAB(4), TAB(4), "    args[" & i.ToString() & "] = this.P" & reg.nombre & ";")
            i = i + 1
        Next
        PrintLine(libre, TAB(4), "    args[" & i.ToString() & "] = resultado;")
        PrintLine(libre, TAB(4), "    resultado = this.Ejecutar(" & Chr(34) & "Sp_abm" & clase & Chr(34) & ", args,t);")
        PrintLine(libre, TAB(4), "    return resultado;")
        PrintLine(libre, TAB(4), "}")

        PrintLine(libre, TAB(4), " public int Guardar(System.Data.SqlClient.SqlTransaction t){")
        PrintLine(libre, TAB(4), "    return ABM(Utilitario.Tarea.Guardar,t);")
        PrintLine(libre, TAB(4), "}")
        PrintLine(libre, TAB(4), "public int Modificar(System.Data.SqlClient.SqlTransaction t){")
        PrintLine(libre, TAB(4), "    return ABM(Utilitario.Utilitario._ABM.Modificar,t);")
        PrintLine(libre, TAB(4), "}")
        PrintLine(libre, TAB(4), "public int Eliminar (System.Data.SqlClient.SqlTransaction t){")
        PrintLine(libre, TAB(4), "    return ABM(Utilitario.Utilitario._ABM.Eliminar,t);")
        PrintLine(libre, TAB(4), "}")
        PrintLine(libre, TAB(4), "public DataTable Traer_" & clase & "(){")
        PrintLine(libre, TAB(4), "    System.Object[] args = new System.Object[1];")
        PrintLine(libre, TAB(4), "    args[0] = this.PId" & clase & ";")
        PrintLine(libre, TAB(4), "    return this.TraerDataTable(" & Chr(34) & "sp_traer" & clase & Chr(34) & ", args);")
        PrintLine(libre, TAB(4), "}")
        PrintLine(libre, TAB(4), "#endregion")

        PrintLine(libre, "}")
        PrintLine(libre, "}")
        FileClose(libre) ' Cierro el archivo de versión
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub LeerArchivo2(ByVal Ruta As String, ByVal Nombre_Extencion As String, ByRef objRichTextBox As RichTextBox)
        Try
            Dim F, A
            F = CreateObject("Scripting.FileSystemObject")
            A = F.OpenTextFile(Ruta & "\" & Nombre_Extencion, 1)
            While A.AtEndOfStream <> True ' hasta que no se termine el archivo sigue leyendo    
                objRichTextBox.Text = objRichTextBox.Text & (vbNewLine & A.ReadLine)
            End While
            A.Close()
            F = Nothing 'Destruye los objetos
            A = Nothing 'Destruye los objetosEnd Sub
        Catch ex As Exception
            MsgBox("Error al abrir archivo :" & ex.Message)
        End Try
    End Sub
    Private Sub btnGenerarClase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarClase.Click
        Dim sw As Boolean
        Dim i As Integer
        Dim PathnombreArchivo As String
        For i = 0 To Me.dgvTablas.Rows.Count - 1
            If (Me.dgvTablas.Rows(i).Cells("Generar").Value = True) Then
                PathnombreArchivo = Me.dgvTablas.Rows(i).Cells("Guardaren").Value.ToString() + "\" + Me.dgvTablas.Rows(i).Cells("NombreArchivo").Value.ToString()
                generarClase(Me.dgvTablas.Rows(i).Cells("NombreClase").Value.ToString(), PathnombreArchivo)
                sw = True
            End If
        Next
        If sw Then
            MsgBox("Clase generada con exito", MsgBoxStyle.Information)
        Else
            MsgBox("No se genero ninguna clase", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Sub generarClase(ByVal NombreClase As String, ByVal PathnombreArchivo As String)
        ' Verifico si se trata de una o todas las tablas
        Dim cad As String = "packet size=4096;integrated security=SSPI;data source=" + Me.txtserver.Text + ";persist security info=False;initial catalog=" + Me.txtdb.Text
        Me.txtCadena.Text = cad
        Call Cargar(cad, NombreClase) ' Cargo la estructura de la tabla en un array "modular"
        Dim i As Integer
        Dim sw As Boolean = False
        If (Me.TabControl1.SelectedTab.Text = "Clases que usan instruccion sql.") Then
            Select Case Me.cblenguajeProgramacion.Text
                Case "Visual Basic .Net"
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        Select Case CheckedListBox1.CheckedItems(i).ToString
                            Case "Crear la Clase"
                                Call GenerarClasevbsql(PathnombreArchivo, NombreClase)
                            Case "Crear la Clase con metodos para el uso de transacciones"
                                Call Me.GenerarClasevbsqlTrans(PathnombreArchivo, NombreClase)
                        End Select
                    Next i
                Case "C#.Net"
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        Select Case CheckedListBox1.CheckedItems(i).ToString
                            Case "Crear la Clase"
                                Call Me.GenerarClasec(PathnombreArchivo, NombreClase)
                            Case "Crear la Clase con metodos para el uso de transacciones"
                                Call Me.GenerarClasecTransaccion(PathnombreArchivo, NombreClase)

                        End Select
                    Next

            End Select
        End If
        If (TabControl1.SelectedTab.Text = "Clases que usan procedimientos almacenados") Then
            Select Case Me.cblenguajeProgramacion.Text
                Case "Visual Basic .Net"
                    For i = 0 To checkedListBox2.CheckedItems.Count - 1
                        Select Case checkedListBox2.CheckedItems(i).ToString
                            Case "Crear la Clase"
                                Call Me.GenerarClasevb_sp(PathnombreArchivo, NombreClase)
                            Case "Crear la Clase con metodos para el uso de transacciones"
                                Call Me.GenerarClaseTransaccionesvb_sp(PathnombreArchivo, NombreClase)

                        End Select
                    Next i
                Case "C#.Net"
                    For i = 0 To checkedListBox2.CheckedItems.Count - 1
                        Select Case checkedListBox2.CheckedItems(i).ToString
                            Case "Crear la Clase"
                                Call Me.GenerarClasec(PathnombreArchivo, NombreClase)
                            Case "Crear la Clase con metodos para el uso de transacciones"
                                Call Me.GenerarClasecTransaccion(PathnombreArchivo, NombreClase)

                        End Select
                    Next
            End Select
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        ' SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.Cancel) Then
            Dim FileName As String = SaveFileDialog.FileName
            '  txtArchivo.Text = SaveFileDialog.InitialDirectory
        End If
    End Sub

    Private Sub cblenguajeProgramacion_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cblenguajeProgramacion.SelectedValueChanged
        If Me.cblenguajeProgramacion.Text = "C#.Net" Then
            Me.txbcarpeta.Enabled = True
            Me.TxBLibreriadeclases.Enabled = True
        Else
            Me.txbcarpeta.Enabled = False
            Me.TxBLibreriadeclases.Enabled = False
        End If

    End Sub

    Public Sub ver_archivo()
        Select Case Me.cblenguajeProgramacion.Text
            Case "Visual Basic .Net"
                '   Me.LeerArchivo2("c:\", Me.txtTabla.Text & ".vb", Me.RichTextBox1)
                Dim i As Integer
                For i = 0 To checkedListBox2.CheckedItems.Count - 1
                    Select Case checkedListBox2.CheckedItems(i).ToString
                        Case "Crear procedimientos Almacenados (abm)"
                            '              Me.LeerArchivo2("c:\", "Sp_abm" & Me.txtTabla.Text & ".sql", Me.RichTextBox2)
                        Case "Crear procedimientos almacenados para traer datos"
                            '             Me.LeerArchivo2("c:\", "Sp_traer" & Me.txtTabla.Text & ".sql", Me.RichTextBox3)

                    End Select
                Next i
            Case "C#.Net"
                ' Me.LeerArchivo2("c:\", Me.txtTabla.Text & ".cs", Me.RichTextBox1)
                Dim i As Integer
                For i = 0 To checkedListBox2.CheckedItems.Count - 1
                    Select Case checkedListBox2.CheckedItems(i).ToString
                        Case "Crear procedimientos Almacenados (abm)"
                            '            Me.LeerArchivo2("c:\", "Sp_abm" & Me.txtTabla.Text & ".sql", Me.RichTextBox2)
                        Case "Crear procedimientos almacenados para traer datos"
                            '           Me.LeerArchivo2("c:\", "Sp_traer" & Me.txtTabla.Text & ".sql", Me.RichTextBox3)
                    End Select
                Next i
        End Select

    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.ver_archivo()
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


    Private Sub btnCargarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarTabla.Click
        Utilitarios.servidor = Me.txtserver.Text
        Utilitarios.Basededatos = Me.txtdb.Text
        cartgartablasgrilla()
    End Sub



    Private Sub CheckBox1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
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
            If CheckBox2.Checked = True And (Me.dgvTablas.Rows(i).Cells("Generar").Value = True) Then
                If Me.cblenguajeProgramacion.Text = "Visual Basic .Net" Then
                    Me.dgvTablas.Rows(i).Cells("NombreArchivo").Value = Me.dgvTablas.Rows(i).Cells("NombreTabla").Value + ".vb"
                Else
                    Me.dgvTablas.Rows(i).Cells("NombreArchivo").Value = Me.dgvTablas.Rows(i).Cells("NombreTabla").Value + ".cs"
                End If
            Else
                Me.dgvTablas.Rows(i).Cells("NombreArchivo").Value = String.Empty
            End If
        Next
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        Dim i As Integer
        For i = 0 To Me.dgvTablas.Rows.Count - 1
            If CheckBox3.Checked = True And (Me.dgvTablas.Rows(i).Cells("Generar").Value = True) Then
                Me.dgvTablas.Rows(i).Cells("NombreClase").Value = Me.dgvTablas.Rows(i).Cells("NombreTabla").Value
            Else
                Me.dgvTablas.Rows(i).Cells("NombreClase").Value = String.Empty

            End If
        Next
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        Dim i As Integer
        For i = 0 To Me.dgvTablas.Rows.Count - 1
            If CheckBox3.Checked = True And (Me.dgvTablas.Rows(i).Cells("Generar").Value = True) Then
                Me.dgvTablas.Rows(i).Cells("Guardaren").Value = Me.txbunidaddisco.Text
            Else
                Me.dgvTablas.Rows(i).Cells("NombreClase").Value = String.Empty

            End If
        Next
    End Sub
    Private Sub dgvTablas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTablas.CellDoubleClick
        If (e.RowIndex >= 0) Then
            If (e.ColumnIndex = 4) Then
                FolderBrowserDialog1.ShowDialog()
                dgvTablas.Rows(e.RowIndex).Cells(4).Value = FolderBrowserDialog1.SelectedPath
            End If
            If (e.ColumnIndex = 5) Then
                Dim PathnombreArchivo As String = Application.StartupPath + "\" + Me.dgvTablas.Rows(e.RowIndex).Cells(0).Value.ToString() + ".txt"
                generarClase(Me.dgvTablas.Rows(e.RowIndex).Cells(0).Value.ToString(), PathnombreArchivo)
                If IO.File.Exists(PathnombreArchivo) Then
                    Dim objfrmpreviewclase As New frmpreviewclase()
                    objfrmpreviewclase.RTBclase.Text = My.Computer.FileSystem.ReadAllText(PathnombreArchivo)
                    objfrmpreviewclase.Text = "Clase " + Me.dgvTablas.Rows(e.RowIndex).Cells(0).Value.ToString()
                    objfrmpreviewclase.Show()
                    IO.File.Delete(PathnombreArchivo)
                Else
                    MsgBox("No se puede crear una vista previa de la clase hasta que seleccione alguna creación de clase")
                End If
            End If
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        txbunidaddisco.Text = FolderBrowserDialog1.SelectedPath
    End Sub

End Class
