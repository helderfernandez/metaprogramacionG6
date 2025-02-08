Imports System.Data.SqlClient

Public Class formGeneradorClasesSQL
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents txtTabla As System.Windows.Forms.TextBox
    Friend WithEvents txtArchivo As System.Windows.Forms.TextBox
    Friend WithEvents txtClase As System.Windows.Forms.TextBox
    Friend WithEvents lblClase As System.Windows.Forms.Label
    Friend WithEvents lblArchivo As System.Windows.Forms.Label
    Friend WithEvents lblTabla As System.Windows.Forms.Label
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
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txbcarpeta As System.Windows.Forms.TextBox
    Friend WithEvents TxBLibreriadeclases As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents checkedListBox2 As System.Windows.Forms.CheckedListBox
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents SandDockManager1 As TD.SandDock.SandDockManager
    Friend WithEvents leftSandDock As TD.SandDock.DockContainer
    Friend WithEvents bottomSandDock As TD.SandDock.DockContainer
    Friend WithEvents topSandDock As TD.SandDock.DockContainer
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents rightSandDock As TD.SandDock.DockContainer
    Friend WithEvents DockControl1 As TD.SandDock.DockControl
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintPreviewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DockControl2 As TD.SandDock.DockControl
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents RichTextBox3 As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton13 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton14 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton15 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkNombresAutomaticos As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formGeneradorClasesSQL))
        Me.grpInformacionClase = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtClase = New System.Windows.Forms.TextBox
        Me.txtArchivo = New System.Windows.Forms.TextBox
        Me.txtTabla = New System.Windows.Forms.TextBox
        Me.txtCadena = New System.Windows.Forms.TextBox
        Me.lblClase = New System.Windows.Forms.Label
        Me.lblArchivo = New System.Windows.Forms.Label
        Me.lblTabla = New System.Windows.Forms.Label
        Me.lblCadena = New System.Windows.Forms.Label
        Me.chkNombresAutomaticos = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.txtdb = New System.Windows.Forms.TextBox
        Me.txtserver = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnGenerarClase = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label6 = New System.Windows.Forms.Label
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label4 = New System.Windows.Forms.Label
        Me.checkedListBox2 = New System.Windows.Forms.CheckedListBox
        Me.TxBLibreriadeclases = New System.Windows.Forms.TextBox
        Me.txbcarpeta = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cblenguajeProgramacion = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SandDockManager1 = New TD.SandDock.SandDockManager
        Me.leftSandDock = New TD.SandDock.DockContainer
        Me.bottomSandDock = New TD.SandDock.DockContainer
        Me.topSandDock = New TD.SandDock.DockContainer
        Me.DockControl1 = New TD.SandDock.DockControl
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintPreviewToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.rightSandDock = New TD.SandDock.DockContainer
        Me.DockControl2 = New TD.SandDock.DockControl
        Me.Label5 = New System.Windows.Forms.Label
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton14 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton15 = New System.Windows.Forms.ToolStripButton
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox
        Me.grpInformacionClase.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.DockControl1.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.rightSandDock.SuspendLayout()
        Me.DockControl2.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpInformacionClase
        '
        Me.grpInformacionClase.Controls.Add(Me.Button1)
        Me.grpInformacionClase.Controls.Add(Me.txtClase)
        Me.grpInformacionClase.Controls.Add(Me.txtArchivo)
        Me.grpInformacionClase.Controls.Add(Me.txtTabla)
        Me.grpInformacionClase.Controls.Add(Me.txtCadena)
        Me.grpInformacionClase.Controls.Add(Me.lblClase)
        Me.grpInformacionClase.Controls.Add(Me.lblArchivo)
        Me.grpInformacionClase.Controls.Add(Me.lblTabla)
        Me.grpInformacionClase.Controls.Add(Me.lblCadena)
        Me.grpInformacionClase.Location = New System.Drawing.Point(8, 63)
        Me.grpInformacionClase.Name = "grpInformacionClase"
        Me.grpInformacionClase.Size = New System.Drawing.Size(719, 111)
        Me.grpInformacionClase.TabIndex = 1
        Me.grpInformacionClase.TabStop = False
        Me.grpInformacionClase.Text = "Información de la clase"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(560, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 21)
        Me.Button1.TabIndex = 15
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtClase
        '
        Me.txtClase.Location = New System.Drawing.Point(136, 88)
        Me.txtClase.MaxLength = 250
        Me.txtClase.Name = "txtClase"
        Me.txtClase.Size = New System.Drawing.Size(544, 20)
        Me.txtClase.TabIndex = 3
        '
        'txtArchivo
        '
        Me.txtArchivo.Location = New System.Drawing.Point(136, 64)
        Me.txtArchivo.MaxLength = 250
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(418, 20)
        Me.txtArchivo.TabIndex = 2
        '
        'txtTabla
        '
        Me.txtTabla.Location = New System.Drawing.Point(136, 40)
        Me.txtTabla.MaxLength = 250
        Me.txtTabla.Name = "txtTabla"
        Me.txtTabla.Size = New System.Drawing.Size(544, 20)
        Me.txtTabla.TabIndex = 1
        '
        'txtCadena
        '
        Me.txtCadena.Location = New System.Drawing.Point(136, 16)
        Me.txtCadena.Name = "txtCadena"
        Me.txtCadena.ReadOnly = True
        Me.txtCadena.Size = New System.Drawing.Size(544, 20)
        Me.txtCadena.TabIndex = 0
        Me.txtCadena.Text = "packet size=4096;integrated security=SSPI;data source=server;persist security inf" & _
            "o=False;initial catalog=db"
        '
        'lblClase
        '
        Me.lblClase.AutoSize = True
        Me.lblClase.Location = New System.Drawing.Point(16, 90)
        Me.lblClase.Name = "lblClase"
        Me.lblClase.Size = New System.Drawing.Size(98, 13)
        Me.lblClase.TabIndex = 3
        Me.lblClase.Text = "Nombre de la clase"
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.Location = New System.Drawing.Point(16, 66)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(82, 13)
        Me.lblArchivo.TabIndex = 2
        Me.lblArchivo.Text = "Nombre archivo"
        '
        'lblTabla
        '
        Me.lblTabla.AutoSize = True
        Me.lblTabla.Location = New System.Drawing.Point(16, 42)
        Me.lblTabla.Name = "lblTabla"
        Me.lblTabla.Size = New System.Drawing.Size(96, 13)
        Me.lblTabla.TabIndex = 1
        Me.lblTabla.Text = "Nombre de la tabla"
        '
        'lblCadena
        '
        Me.lblCadena.AutoSize = True
        Me.lblCadena.Location = New System.Drawing.Point(16, 18)
        Me.lblCadena.Name = "lblCadena"
        Me.lblCadena.Size = New System.Drawing.Size(105, 13)
        Me.lblCadena.TabIndex = 0
        Me.lblCadena.Text = "Cadena de conexión"
        '
        'chkNombresAutomaticos
        '
        Me.chkNombresAutomaticos.Checked = True
        Me.chkNombresAutomaticos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNombresAutomaticos.Location = New System.Drawing.Point(6, 17)
        Me.chkNombresAutomaticos.Name = "chkNombresAutomaticos"
        Me.chkNombresAutomaticos.Size = New System.Drawing.Size(160, 24)
        Me.chkNombresAutomaticos.TabIndex = 4
        Me.chkNombresAutomaticos.Text = "Usar nombre automáticos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.txtdb)
        Me.GroupBox1.Controls.Add(Me.txtserver)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(715, 36)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parametros"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(267, 14)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(77, 13)
        Me.LinkLabel2.TabIndex = 4
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Base de Datos"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(75, 14)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(46, 13)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Servidor"
        '
        'txtdb
        '
        Me.txtdb.Location = New System.Drawing.Point(350, 11)
        Me.txtdb.Name = "txtdb"
        Me.txtdb.Size = New System.Drawing.Size(200, 20)
        Me.txtdb.TabIndex = 1
        '
        'txtserver
        '
        Me.txtserver.Location = New System.Drawing.Point(125, 11)
        Me.txtserver.Name = "txtserver"
        Me.txtserver.Size = New System.Drawing.Size(100, 20)
        Me.txtserver.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGenerarClase, Me.ToolStripButton2, Me.ToolStripButton1, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 499)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1025, 25)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGenerarClase
        '
        Me.btnGenerarClase.Image = CType(resources.GetObject("btnGenerarClase.Image"), System.Drawing.Image)
        Me.btnGenerarClase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGenerarClase.Name = "btnGenerarClase"
        Me.btnGenerarClase.Size = New System.Drawing.Size(95, 22)
        Me.btnGenerarClase.Text = "Generar Clase"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripButton2.Text = "Cancelar"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(82, 22)
        Me.ToolStripButton1.Text = "Ver Archivo"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(47, 22)
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
        Me.GroupBox2.Controls.Add(Me.chkNombresAutomaticos)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 180)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(719, 284)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Parametro para generar"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 94)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(707, 189)
        Me.TabControl1.TabIndex = 17
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.CheckedListBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(699, 163)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Clases que usan instruccion sql."
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(384, 40)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Los metodos que se generan para hacer las altas, bajas y modificaciones.  Utiliza" & _
            "n instrucciones SQL."
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"Crear la Clase ", "Crear la Clase con metodos para el uso de transacciones"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(6, 15)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(380, 79)
        Me.CheckedListBox1.TabIndex = 15
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.checkedListBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(699, 163)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Clases que usan procedimientos almacenados"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(384, 40)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Los metodos que se generan para hacer las altas, bajas y modificaciones.  Utiliza" & _
            "n procedimientos almacenados que tambien son generados por esta aplicacion."
        '
        'checkedListBox2
        '
        Me.checkedListBox2.FormattingEnabled = True
        Me.checkedListBox2.Items.AddRange(New Object() {"Crear la Clase ", "Crear la Clase con metodos para el uso de transacciones", "Crear procedimientos Almacenados (abm)", "Crear procedimientos almacenados para traer datos"})
        Me.checkedListBox2.Location = New System.Drawing.Point(6, 15)
        Me.checkedListBox2.Name = "checkedListBox2"
        Me.checkedListBox2.Size = New System.Drawing.Size(362, 79)
        Me.checkedListBox2.TabIndex = 14
        '
        'TxBLibreriadeclases
        '
        Me.TxBLibreriadeclases.Enabled = False
        Me.TxBLibreriadeclases.Location = New System.Drawing.Point(172, 68)
        Me.TxBLibreriadeclases.Name = "TxBLibreriadeclases"
        Me.TxBLibreriadeclases.Size = New System.Drawing.Size(66, 20)
        Me.TxBLibreriadeclases.TabIndex = 16
        Me.TxBLibreriadeclases.Text = "Negocio."
        '
        'txbcarpeta
        '
        Me.txbcarpeta.Enabled = False
        Me.txbcarpeta.Location = New System.Drawing.Point(247, 69)
        Me.txbcarpeta.Name = "txbcarpeta"
        Me.txbcarpeta.Size = New System.Drawing.Size(115, 20)
        Me.txbcarpeta.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Espacio de nombre:"
        '
        'cblenguajeProgramacion
        '
        Me.cblenguajeProgramacion.FormattingEnabled = True
        Me.cblenguajeProgramacion.Items.AddRange(New Object() {"Visual Basic .Net", "C#.Net"})
        Me.cblenguajeProgramacion.Location = New System.Drawing.Point(172, 41)
        Me.cblenguajeProgramacion.Name = "cblenguajeProgramacion"
        Me.cblenguajeProgramacion.Size = New System.Drawing.Size(190, 21)
        Me.cblenguajeProgramacion.TabIndex = 11
        Me.cblenguajeProgramacion.Text = "Visual Basic .Net"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Elija el lenguaje de programacion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(643, 506)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 9)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Por: Ing. Ernesto Soto Roca"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
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
        Me.leftSandDock.Size = New System.Drawing.Size(0, 524)
        Me.leftSandDock.TabIndex = 11
        '
        'bottomSandDock
        '
        Me.bottomSandDock.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bottomSandDock.Guid = New System.Guid("c1ffbb0c-fd57-48b6-b3da-cb82588b77c2")
        Me.bottomSandDock.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400)
        Me.bottomSandDock.Location = New System.Drawing.Point(0, 524)
        Me.bottomSandDock.Manager = Me.SandDockManager1
        Me.bottomSandDock.Name = "bottomSandDock"
        Me.bottomSandDock.Size = New System.Drawing.Size(1025, 0)
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
        Me.topSandDock.Size = New System.Drawing.Size(1025, 0)
        Me.topSandDock.TabIndex = 14
        '
        'DockControl1
        '
        Me.DockControl1.Closable = False
        Me.DockControl1.Controls.Add(Me.RichTextBox1)
        Me.DockControl1.Controls.Add(Me.ToolStrip)
        Me.DockControl1.Enabled = False
        Me.DockControl1.Guid = New System.Guid("47c1c902-862c-426c-9009-f5a4e848ac6b")
        Me.DockControl1.Location = New System.Drawing.Point(4, 18)
        Me.DockControl1.Name = "DockControl1"
        Me.DockControl1.Size = New System.Drawing.Size(123, 458)
        Me.DockControl1.TabIndex = 0
        Me.DockControl1.Text = "Clase"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.AutoWordSelection = True
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 25)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(123, 433)
        Me.RichTextBox1.TabIndex = 9
        Me.RichTextBox1.Text = ""
        '
        'ToolStrip
        '
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.OpenToolStripButton, Me.SaveToolStripButton, Me.ToolStripSeparator1, Me.PrintToolStripButton, Me.PrintPreviewToolStripButton, Me.ToolStripSeparator2, Me.HelpToolStripButton})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(123, 25)
        Me.ToolStrip.TabIndex = 7
        Me.ToolStrip.Text = "ToolStrip"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NewToolStripButton.Text = "New"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "Open"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "Save"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 20)
        Me.PrintToolStripButton.Text = "Print"
        '
        'PrintPreviewToolStripButton
        '
        Me.PrintPreviewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintPreviewToolStripButton.Image = CType(resources.GetObject("PrintPreviewToolStripButton.Image"), System.Drawing.Image)
        Me.PrintPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.PrintPreviewToolStripButton.Name = "PrintPreviewToolStripButton"
        Me.PrintPreviewToolStripButton.Size = New System.Drawing.Size(23, 20)
        Me.PrintPreviewToolStripButton.Text = "Print Preview"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.Size = New System.Drawing.Size(23, 20)
        Me.HelpToolStripButton.Text = "Help"
        '
        'rightSandDock
        '
        Me.rightSandDock.Controls.Add(Me.DockControl1)
        Me.rightSandDock.Controls.Add(Me.DockControl2)
        Me.rightSandDock.Dock = System.Windows.Forms.DockStyle.Right
        Me.rightSandDock.Guid = New System.Guid("e1adfd6a-85b6-41ce-b261-c1da0e27af0c")
        Me.rightSandDock.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400, System.Windows.Forms.Orientation.Horizontal, New TD.SandDock.LayoutSystemBase() {CType(New TD.SandDock.SplitLayoutSystem(250, 499, System.Windows.Forms.Orientation.Vertical, New TD.SandDock.LayoutSystemBase() {CType(New TD.SandDock.ControlLayoutSystem(123, 499, New TD.SandDock.DockControl() {Me.DockControl1}, Me.DockControl1), TD.SandDock.LayoutSystemBase), CType(New TD.SandDock.ControlLayoutSystem(123, 499, New TD.SandDock.DockControl() {Me.DockControl2}, Me.DockControl2), TD.SandDock.LayoutSystemBase)}), TD.SandDock.LayoutSystemBase)})
        Me.rightSandDock.Location = New System.Drawing.Point(771, 0)
        Me.rightSandDock.Manager = Me.SandDockManager1
        Me.rightSandDock.Name = "rightSandDock"
        Me.rightSandDock.Size = New System.Drawing.Size(254, 499)
        Me.rightSandDock.TabIndex = 12
        '
        'DockControl2
        '
        Me.DockControl2.Closable = False
        Me.DockControl2.Controls.Add(Me.Label5)
        Me.DockControl2.Controls.Add(Me.ToolStrip3)
        Me.DockControl2.Controls.Add(Me.RichTextBox3)
        Me.DockControl2.Controls.Add(Me.ToolStrip2)
        Me.DockControl2.Controls.Add(Me.RichTextBox2)
        Me.DockControl2.Enabled = False
        Me.DockControl2.Guid = New System.Guid("0d16079f-3c72-46aa-b1e2-8f4b2b692807")
        Me.DockControl2.Location = New System.Drawing.Point(131, 18)
        Me.DockControl2.Name = "DockControl2"
        Me.DockControl2.Size = New System.Drawing.Size(123, 458)
        Me.DockControl2.TabIndex = 1
        Me.DockControl2.Text = "Procedimientos almacenados"
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label5.Location = New System.Drawing.Point(0, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 28)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Procedimientos para hacer ABM."
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton10, Me.ToolStripButton11, Me.ToolStripButton12, Me.ToolStripSeparator5, Me.ToolStripButton13, Me.ToolStripButton14, Me.ToolStripSeparator6, Me.ToolStripButton15})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 231)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(123, 25)
        Me.ToolStrip3.TabIndex = 13
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton10.Text = "New"
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
        Me.ToolStripButton11.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton11.Text = "Open"
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
        Me.ToolStripButton12.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton12.Text = "Save"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton13
        '
        Me.ToolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton13.Image = CType(resources.GetObject("ToolStripButton13.Image"), System.Drawing.Image)
        Me.ToolStripButton13.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripButton13.Name = "ToolStripButton13"
        Me.ToolStripButton13.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton13.Text = "Print"
        '
        'ToolStripButton14
        '
        Me.ToolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton14.Image = CType(resources.GetObject("ToolStripButton14.Image"), System.Drawing.Image)
        Me.ToolStripButton14.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripButton14.Name = "ToolStripButton14"
        Me.ToolStripButton14.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton14.Text = "Print Preview"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton15
        '
        Me.ToolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton15.Image = CType(resources.GetObject("ToolStripButton15.Image"), System.Drawing.Image)
        Me.ToolStripButton15.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripButton15.Name = "ToolStripButton15"
        Me.ToolStripButton15.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton15.Text = "Help"
        '
        'RichTextBox3
        '
        Me.RichTextBox3.AutoWordSelection = True
        Me.RichTextBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.RichTextBox3.Location = New System.Drawing.Point(0, 25)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(123, 181)
        Me.RichTextBox3.TabIndex = 12
        Me.RichTextBox3.Text = ""
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator3, Me.ToolStripButton7, Me.ToolStripButton8, Me.ToolStripSeparator4, Me.ToolStripButton9})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(123, 25)
        Me.ToolStrip2.TabIndex = 11
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "New"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "Open"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "Save"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton7.Text = "Print"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton8.Text = "Print Preview"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton9.Text = "Help"
        '
        'RichTextBox2
        '
        Me.RichTextBox2.AutoWordSelection = True
        Me.RichTextBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RichTextBox2.Location = New System.Drawing.Point(0, 256)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(123, 202)
        Me.RichTextBox2.TabIndex = 10
        Me.RichTextBox2.Text = ""
        '
        'formGeneradorClasesSQL
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1025, 524)
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.DockControl1.ResumeLayout(False)
        Me.DockControl1.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.rightSandDock.ResumeLayout(False)
        Me.DockControl2.ResumeLayout(False)
        Me.DockControl2.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub formGeneradorClasesSQL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DockControl1.Hide()
        txtCadena.SelectAll()
    End Sub

    Private Sub chkNombresAutomaticos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNombresAutomaticos.CheckedChanged
        ' Verirfico el estado del campo nombres automáticos
        If chkNombresAutomaticos.Checked Then
            ' Deshabilito los casilleros
            txtArchivo.Enabled = False
            txtClase.Enabled = False

            ' Fuerzo a recargarse los casilleros de texto
            Call GenerarNombres()
        Else
            ' Habilito los casilleros
            txtArchivo.Enabled = True
            txtClase.Enabled = True

            ' Limpio los nombres que ya hubiese
            txtArchivo.Text = ""
            txtClase.Text = ""
        End If
    End Sub



    Private Sub CambioNombreTabla(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTabla.KeyUp
        ' Verifico si se está en nombres automáticos
        If chkNombresAutomaticos.Checked Then
            Call GenerarNombres()
        End If
    End Sub

    Private Sub GenerarNombres()
        ' Defino variables
        Dim tabla As String

        ' Doy formato al nombre de la tabla
        tabla = txtTabla.Text.Trim.ToLower
        tabla = tabla.Replace(" ", Nothing)
        tabla = Mid$(tabla, 1, 1).ToUpper & Mid$(tabla, 2).ToLower

        ' Genero los nombres en base al nombre de la tabla
        If txtTabla.Text <> "" Then
            txtArchivo.Text = tabla
            txtClase.Text = tabla
        Else
            txtArchivo.Text = ""
            txtClase.Text = ""
        End If
    End Sub

    Private Sub LimpiarEspaciosFinales(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCadena.LostFocus, txtTabla.LostFocus, txtArchivo.LostFocus, txtClase.LostFocus
        ' Limpio los espacios finales que pudiese llegar a tener la cadena
        sender.Text.Trim()
    End Sub

    Private Sub SeleccionarTexto(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCadena.GotFocus, txtTabla.GotFocus, txtArchivo.GotFocus, txtClase.GotFocus
        ' Selecciono el texto del casillero
        sender.SelectAll()
    End Sub

    Private Sub Verificar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCadena.TextChanged, txtTabla.TextChanged, txtArchivo.TextChanged, txtClase.TextChanged

        If txtCadena.Text <> "" And txtTabla.Text <> "" And txtArchivo.Text <> "" And txtClase.Text <> "" Then
            btnGenerarClase.Enabled = True
        Else
            btnGenerarClase.Enabled = False
        End If
        'End If
    End Sub

    ' Este procedimiento recibe una cadena conexión y el nombre de una tabla y carga un array con el nombre y tipo de cada uno de los campos de la tabla.
    ' El array es de tipo regCampo y su alcance es "modular". El mismo es una estructura conteniendo nombre y tipo del campo. Los tipos de los campos se
    ' guardan en el formato "oficial" de .NET (por ejemplo los Integer son Int32, etc.).

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
        If Mid$(archivo, Len(archivo) - 3, 3) <> ".vb" Then
            archivo = "c:\" & archivo & ".vb"
        Else
            archivo = "c:\" & archivo
        End If

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
        If Mid$(archivo, Len(archivo) - 3, 3) <> ".vb" Then
            archivo = "c:\" & archivo & ".vb"
        Else
            archivo = "c:\" & archivo
        End If

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
        ' Doy formato al nombre del archivo
        If Mid$(archivo, Len(archivo) - 3, 3) <> ".vb" Then
            archivo = "c:\" & archivo & ".vb"
        Else
            archivo = "c:\" & archivo
        End If

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
        If Mid$(archivo, Len(archivo) - 3, 3) <> ".vb" Then
            archivo = "c:\" & archivo & ".vb"
        Else
            archivo = "c:\" & archivo
        End If

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
        PrintLine(libre, TAB(4), TAB(4), cadenasql)

        For Each reg In arrEstructura ' reemplazamos las partes de la cadena
            PrintLine(libre, TAB(4), TAB(4), "    strcad = strcad.Replace(" & Chr(34) & "#" & reg.nombre & Chr(34) & ", Me.P" & reg.nombre & ")")
        Next
        PrintLine(libre, TAB(4), TAB(4), "    Return Me.ejecutarDML(strcad, t)")
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
        ' Doy formato al nombre del archivo
        If Mid$(archivo, Len(archivo) - 3, 3) <> ".cs" Then
            archivo = "c:\" & archivo & ".cs"
        Else
            archivo = "c:\" & archivo
        End If

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
        If Mid$(archivo, Len(archivo) - 3, 3) <> ".cs" Then
            archivo = "c:\" & archivo & ".cs"
        Else
            archivo = "c:\" & archivo
        End If

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


    Private Sub GenerarProcedimientosAlmacenadosABM(ByVal Clase As String, ByVal NombreProcedimiento As String)
        ' Doy formato al nombre del archivo
        Dim auxnombreproc As String = NombreProcedimiento
        If Mid$(NombreProcedimiento, Len(NombreProcedimiento) - 3, 3) <> ".sql" Then
            NombreProcedimiento = "c:\" & NombreProcedimiento & ".sql"
        Else
            NombreProcedimiento = "c:\" & NombreProcedimiento
        End If

        ' Defino variables
        Dim libre As Integer = FreeFile()
        Dim reg As regCampo

        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, NombreProcedimiento, OpenMode.Output)

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
        PrintLine(libre, TAB(4), TAB(4), "    @tarea integer,")
        For Each reg In arrEstructura
            Select Case reg.tipo
                Case "String"
                    PrintLine(libre, TAB(4), TAB(4), "    @" & reg.nombre & " varchar(250),")
                Case "Int64"
                    PrintLine(libre, TAB(4), TAB(4), "    @" & reg.nombre & " bigint,")
                Case "Int32"
                    PrintLine(libre, TAB(4), TAB(4), "    @" & reg.nombre & " integer,")
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
        PrintLine(libre, TAB(4), "       Return (1)")
        PrintLine(libre, TAB(4), "   End")
        PrintLine(libre, TAB(4), "   Else")
        PrintLine(libre, TAB(4), "     begin")
        PrintLine(libre, TAB(4), "         set @resultado=0")
        PrintLine(libre, TAB(4), "         Return (0)")
        PrintLine(libre, TAB(4), "     End ")

        ' Cierro el archivo de versión
        FileClose(libre)
    End Sub

    Private Sub GenerarProcedimientosAlmacenadosTraer(ByVal Clase As String, ByVal NombreProcedimiento As String)
        ' Doy formato al nombre del archivo
        Dim auxnombreproc As String = NombreProcedimiento
        If Mid$(NombreProcedimiento, Len(NombreProcedimiento) - 3, 3) <> ".sql" Then
            NombreProcedimiento = "c:\" & NombreProcedimiento & ".sql"
        Else
            NombreProcedimiento = "c:\" & NombreProcedimiento
        End If

        ' Defino variables
        Dim libre As Integer = FreeFile()
        Dim reg As regCampo
        ' Abro un archivo de texto (si el mismo existía se reempleza)
        FileOpen(libre, NombreProcedimiento, OpenMode.Output)

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
        ' Verifico si se trata de una o todas las tablas
        Dim cad As String = "packet size=4096;integrated security=SSPI;data source=" + Me.txtserver.Text + ";persist security info=False;initial catalog=" + Me.txtdb.Text
        Me.txtCadena.Text = cad
        If MessageBox.Show("¿ Confirma crear la clase '" & txtClase.Text & "' basándose en la tabla '" & txtTabla.Text & "' ?", "Conformación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Call Cargar(cad, txtTabla.Text) ' Cargo la estructura de la tabla en un array "modular"
            Dim i As Integer
            Dim sw As Boolean = False
            If (TabControl1.SelectedTab.Text = "Clases que usan instruccion sql.") Then
                Select Case Me.cblenguajeProgramacion.Text
                    Case "Visual Basic .Net"
                        For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                            Select Case CheckedListBox1.CheckedItems(i).ToString
                                Case "Crear la Clase "
                                    Call GenerarClasevbsql(txtArchivo.Text, txtClase.Text)
                                Case "Crear la Clase con metodos para el uso de transacciones"
                                    Call Me.GenerarClasevbsqlTrans(txtArchivo.Text, txtClase.Text)
                            End Select
                        Next i
                    Case "C#.Net"
                        For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                            Select Case CheckedListBox1.CheckedItems(i).ToString
                                Case "Crear la Clase "
                                    Call Me.GenerarClasec(txtArchivo.Text, txtClase.Text)
                                Case "Crear la Clase con metodos para el uso de transacciones"
                                    Call Me.GenerarClasecTransaccion(txtArchivo.Text, txtClase.Text)
                                Case "Crear procedimientos Almacenados (abm)"
                                    Call GenerarProcedimientosAlmacenadosABM(txtClase.Text, "Sp_ABM" & txtClase.Text)
                                Case "Crear procedimientos almacenados para traer datos"
                                    Call GenerarProcedimientosAlmacenadosTraer(txtClase.Text, "Sp_Traer" & txtClase.Text)

                            End Select
                        Next

                End Select
            End If
            If (TabControl1.SelectedTab.Text = "Clases que usan procedimientos almacenados") Then
                Select Case Me.cblenguajeProgramacion.Text
                    Case "Visual Basic .Net"
                        For i = 0 To checkedListBox2.CheckedItems.Count - 1
                            Select Case checkedListBox2.CheckedItems(i).ToString
                                Case "Crear la Clase "
                                    Call Me.GenerarClasevb_sp(txtArchivo.Text, txtClase.Text)
                                Case "Crear la Clase con metodos para el uso de transacciones"
                                    Call Me.GenerarClaseTransaccionesvb_sp(txtArchivo.Text, txtClase.Text)
                                Case "Crear procedimientos Almacenados (abm)"
                                    Call GenerarProcedimientosAlmacenadosABM(txtClase.Text, "Sp_abm" & txtClase.Text)
                                Case "Crear procedimientos almacenados para traer datos"
                                    Call GenerarProcedimientosAlmacenadosTraer(txtClase.Text, "Sp_traer" & txtClase.Text)

                            End Select
                        Next i
                    Case "C#.Net"
                        For i = 0 To checkedListBox2.CheckedItems.Count - 1
                            Select Case checkedListBox2.CheckedItems(i).ToString
                                Case "Crear la Clase "
                                    Call Me.GenerarClasec(txtArchivo.Text, txtClase.Text)
                                Case "Crear la Clase con metodos para el uso de transacciones"
                                    Call Me.GenerarClasecTransaccion(txtArchivo.Text, txtClase.Text)
                                Case "Crear procedimientos Almacenados (abm)"
                                    Call GenerarProcedimientosAlmacenadosABM(txtClase.Text, "Sp_ABM" & txtClase.Text)
                                Case "Crear procedimientos almacenados para traer datos"
                                    Call GenerarProcedimientosAlmacenadosTraer(txtClase.Text, "Sp_Traer" & txtClase.Text)

                            End Select
                        Next
                End Select

            End If
            MessageBox.Show("Se ha generado la clase '" & txtClase.Text & "' en el archivo '" & txtArchivo.Text & "' basándose en la tabla '" & txtTabla.Text & "'." & Chr(13) & Chr(13) & "El archivo resultante se ha grabado en c:\." & Chr(13) & Chr(13), "Generación de clases", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        ' SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.Cancel) Then
            Dim FileName As String = SaveFileDialog.FileName
            txtArchivo.Text = SaveFileDialog.InitialDirectory
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
        Me.RichTextBox1.Text = String.Empty
        Me.RichTextBox2.Text = String.Empty
        Me.RichTextBox3.Text = String.Empty
        Select Case Me.cblenguajeProgramacion.Text
            Case "Visual Basic .Net"
                Me.LeerArchivo2("c:\", Me.txtTabla.Text & ".vb", Me.RichTextBox1)
                Dim i As Integer
                For i = 0 To checkedListBox2.CheckedItems.Count - 1
                    Select Case checkedListBox2.CheckedItems(i).ToString
                        Case "Crear procedimientos Almacenados (abm)"
                            Me.LeerArchivo2("c:\", "Sp_abm" & Me.txtTabla.Text & ".sql", Me.RichTextBox2)
                        Case "Crear procedimientos almacenados para traer datos"
                            Me.LeerArchivo2("c:\", "Sp_traer" & Me.txtTabla.Text & ".sql", Me.RichTextBox3)

                    End Select
                Next i
            Case "C#.Net"
                Me.LeerArchivo2("c:\", Me.txtTabla.Text & ".cs", Me.RichTextBox1)
                Dim i As Integer
                For i = 0 To checkedListBox2.CheckedItems.Count - 1
                    Select Case checkedListBox2.CheckedItems(i).ToString
                        Case "Crear procedimientos Almacenados (abm)"
                            Me.LeerArchivo2("c:\", "Sp_abm" & Me.txtTabla.Text & ".sql", Me.RichTextBox2)
                        Case "Crear procedimientos almacenados para traer datos"
                            Me.LeerArchivo2("c:\", "Sp_traer" & Me.txtTabla.Text & ".sql", Me.RichTextBox3)
                    End Select
                Next i
        End Select
        Me.DockControl1.Open()
        Me.DockControl1.Enabled = True
        Me.DockControl2.Enabled = True
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.ver_archivo()
    End Sub
End Class
