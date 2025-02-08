<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.txtserver = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.txtdb = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgvcampo = New System.Windows.Forms.DataGridView
        Me.NombreColumna = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TipoDato = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TipoAtributo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Componente = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.TablaEnlace = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.DocumentContainer1 = New TD.SandDock.DocumentContainer
        Me.DockControl1 = New TD.SandDock.DockControl
        Me.DockControl2 = New TD.SandDock.DockControl
        Me.cmbLenguaje = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.TxbRutaCtrl = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.txbRuta = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnGenerarClase = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        CType(Me.dgvcampo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.DocumentContainer1.SuspendLayout()
        Me.DockControl1.SuspendLayout()
        Me.DockControl2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtserver
        '
        Me.txtserver.Location = New System.Drawing.Point(58, 12)
        Me.txtserver.Name = "txtserver"
        Me.txtserver.Size = New System.Drawing.Size(137, 20)
        Me.txtserver.TabIndex = 26
        Me.txtserver.Text = "Serversie"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(447, 13)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(103, 24)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "Generar Tablas"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(48, 14)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(164, 21)
        Me.ComboBox1.TabIndex = 20
        '
        'txtdb
        '
        Me.txtdb.Location = New System.Drawing.Point(283, 15)
        Me.txtdb.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtdb.Name = "txtdb"
        Me.txtdb.Size = New System.Drawing.Size(147, 20)
        Me.txtdb.TabIndex = 19
        Me.txtdb.Text = "dbbosque"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Tablas"
        '
        'dgvcampo
        '
        Me.dgvcampo.AllowUserToAddRows = False
        Me.dgvcampo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvcampo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NombreColumna, Me.TipoDato, Me.TipoAtributo, Me.Componente, Me.TablaEnlace})
        Me.dgvcampo.Location = New System.Drawing.Point(10, 138)
        Me.dgvcampo.Name = "dgvcampo"
        Me.dgvcampo.Size = New System.Drawing.Size(671, 205)
        Me.dgvcampo.TabIndex = 30
        '
        'NombreColumna
        '
        Me.NombreColumna.HeaderText = "Campo"
        Me.NombreColumna.Name = "NombreColumna"
        Me.NombreColumna.ReadOnly = True
        '
        'TipoDato
        '
        Me.TipoDato.HeaderText = "Tipo de Dato"
        Me.TipoDato.Name = "TipoDato"
        '
        'TipoAtributo
        '
        Me.TipoAtributo.HeaderText = "Tipo de Atributo"
        Me.TipoAtributo.Items.AddRange(New Object() {"Descriptor", "Llave Primaria", "Llave Foranea"})
        Me.TipoAtributo.Name = "TipoAtributo"
        '
        'Componente
        '
        Me.Componente.HeaderText = "Tipo Componente"
        Me.Componente.Items.AddRange(New Object() {"TextBox", "ComboBox"})
        Me.Componente.Name = "Componente"
        Me.Componente.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Componente.Width = 120
        '
        'TablaEnlace
        '
        Me.TablaEnlace.HeaderText = "Tabla Enlace"
        Me.TablaEnlace.Name = "TablaEnlace"
        Me.TablaEnlace.Width = 135
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.txtserver)
        Me.GroupBox1.Controls.Add(Me.txtdb)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(556, 41)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(201, 15)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(77, 13)
        Me.LinkLabel2.TabIndex = 4
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Base de Datos"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(6, 15)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(46, 13)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Servidor"
        '
        'DocumentContainer1
        '
        Me.DocumentContainer1.Controls.Add(Me.DockControl1)
        Me.DocumentContainer1.Controls.Add(Me.DockControl2)
        Me.DocumentContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.DocumentContainer1.Dock = System.Windows.Forms.DockStyle.None
        Me.DocumentContainer1.Guid = New System.Guid("bd794c1a-480f-41f4-af3d-b92885ff49f8")
        Me.DocumentContainer1.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400, System.Windows.Forms.Orientation.Horizontal, New TD.SandDock.LayoutSystemBase() {CType(New TD.SandDock.DocumentLayoutSystem(672, 110, New TD.SandDock.DockControl() {Me.DockControl2, Me.DockControl1}, Me.DockControl1), TD.SandDock.LayoutSystemBase)})
        Me.DocumentContainer1.Location = New System.Drawing.Point(10, 20)
        Me.DocumentContainer1.Manager = Nothing
        Me.DocumentContainer1.Name = "DocumentContainer1"
        Me.DocumentContainer1.Size = New System.Drawing.Size(674, 112)
        Me.DocumentContainer1.TabIndex = 33
        '
        'DockControl1
        '
        Me.DockControl1.Controls.Add(Me.GroupBox1)
        Me.DockControl1.Guid = New System.Guid("4573cc89-81bf-4b63-b23c-df511f371a49")
        Me.DockControl1.Location = New System.Drawing.Point(3, 23)
        Me.DockControl1.Name = "DockControl1"
        Me.DockControl1.Size = New System.Drawing.Size(668, 86)
        Me.DockControl1.TabIndex = 0
        Me.DockControl1.Text = "Configuracion del servidor"
        '
        'DockControl2
        '
        Me.DockControl2.Controls.Add(Me.cmbLenguaje)
        Me.DockControl2.Controls.Add(Me.Label3)
        Me.DockControl2.Controls.Add(Me.Button3)
        Me.DockControl2.Controls.Add(Me.TxbRutaCtrl)
        Me.DockControl2.Controls.Add(Me.Label2)
        Me.DockControl2.Controls.Add(Me.Button1)
        Me.DockControl2.Controls.Add(Me.ComboBox1)
        Me.DockControl2.Controls.Add(Me.txbRuta)
        Me.DockControl2.Controls.Add(Me.Label1)
        Me.DockControl2.Controls.Add(Me.Label4)
        Me.DockControl2.Guid = New System.Guid("97daba78-92f4-4f6a-9b9c-ebc4ec0821de")
        Me.DockControl2.Location = New System.Drawing.Point(3, 23)
        Me.DockControl2.Name = "DockControl2"
        Me.DockControl2.Size = New System.Drawing.Size(668, 86)
        Me.DockControl2.TabIndex = 1
        Me.DockControl2.Text = "Parametros del formulario"
        '
        'cmbLenguaje
        '
        Me.cmbLenguaje.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmbLenguaje.Items.AddRange(New Object() {"Visua Basic", "C#"})
        Me.cmbLenguaje.Location = New System.Drawing.Point(58, 50)
        Me.cmbLenguaje.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbLenguaje.Name = "cmbLenguaje"
        Me.cmbLenguaje.Size = New System.Drawing.Size(154, 21)
        Me.cmbLenguaje.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Lenguaje"
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(623, 39)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(34, 23)
        Me.Button3.TabIndex = 40
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TxbRutaCtrl
        '
        Me.TxbRutaCtrl.Location = New System.Drawing.Point(326, 41)
        Me.TxbRutaCtrl.Name = "TxbRutaCtrl"
        Me.TxbRutaCtrl.Size = New System.Drawing.Size(291, 20)
        Me.TxbRutaCtrl.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(225, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 32)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Ruta de la Clase de control"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(623, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(34, 23)
        Me.Button1.TabIndex = 37
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txbRuta
        '
        Me.txbRuta.Location = New System.Drawing.Point(326, 15)
        Me.txbRuta.Name = "txbRuta"
        Me.txbRuta.Size = New System.Drawing.Size(291, 20)
        Me.txbRuta.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(225, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Ruta del formulario"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGenerarClase, Me.ToolStripButton2, Me.ToolStripButton1, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 370)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(708, 25)
        Me.ToolStrip1.TabIndex = 34
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGenerarClase
        '
        Me.btnGenerarClase.Image = CType(resources.GetObject("btnGenerarClase.Image"), System.Drawing.Image)
        Me.btnGenerarClase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGenerarClase.Name = "btnGenerarClase"
        Me.btnGenerarClase.Size = New System.Drawing.Size(119, 22)
        Me.btnGenerarClase.Text = "Generar Formulario"
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 395)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DocumentContainer1)
        Me.Controls.Add(Me.dgvcampo)
        Me.Name = "Form1"
        Me.Text = "Generacion de formulario simple"
        CType(Me.dgvcampo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.DocumentContainer1.ResumeLayout(False)
        Me.DockControl1.ResumeLayout(False)
        Me.DockControl2.ResumeLayout(False)
        Me.DockControl2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtserver As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtdb As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvcampo As System.Windows.Forms.DataGridView
    Friend WithEvents NombreColumna As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoDato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoAtributo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Componente As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents TablaEnlace As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents DocumentContainer1 As TD.SandDock.DocumentContainer
    Friend WithEvents DockControl1 As TD.SandDock.DockControl
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGenerarClase As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txbRuta As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents DockControl2 As TD.SandDock.DockControl
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TxbRutaCtrl As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbLenguaje As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
