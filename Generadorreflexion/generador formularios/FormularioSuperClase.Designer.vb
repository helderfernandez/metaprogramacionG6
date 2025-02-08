<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormularioSuperClase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormularioSuperClase))
        Me.dgvtabla = New System.Windows.Forms.DataGridView
        Me.tabla = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dependiente = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.DocumentContainer1 = New TD.SandDock.DocumentContainer
        Me.DockControl1 = New TD.SandDock.DockControl
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.txtdb = New System.Windows.Forms.TextBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Button3 = New System.Windows.Forms.Button
        Me.txtserver = New System.Windows.Forms.TextBox
        Me.DockControl2 = New TD.SandDock.DockControl
        Me.cmbLenguaje = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.TxbRutaCtrl = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.txbRuta = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnGenerarClase = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        CType(Me.dgvtabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DocumentContainer1.SuspendLayout()
        Me.DockControl1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.DockControl2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvtabla
        '
        Me.dgvtabla.AllowUserToAddRows = False
        Me.dgvtabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvtabla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tabla, Me.dependiente})
        Me.dgvtabla.Location = New System.Drawing.Point(7, 162)
        Me.dgvtabla.Name = "dgvtabla"
        Me.dgvtabla.Size = New System.Drawing.Size(352, 170)
        Me.dgvtabla.TabIndex = 49
        '
        'tabla
        '
        Me.tabla.HeaderText = "Nombre Tabla"
        Me.tabla.Name = "tabla"
        Me.tabla.ReadOnly = True
        Me.tabla.Width = 125
        '
        'dependiente
        '
        Me.dependiente.HeaderText = "Clase Dependiente"
        Me.dependiente.Name = "dependiente"
        Me.dependiente.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dependiente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dependiente.Width = 135
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(3, 30)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(214, 21)
        Me.ComboBox1.TabIndex = 42
        '
        'DocumentContainer1
        '
        Me.DocumentContainer1.Controls.Add(Me.DockControl1)
        Me.DocumentContainer1.Controls.Add(Me.DockControl2)
        Me.DocumentContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.DocumentContainer1.Dock = System.Windows.Forms.DockStyle.None
        Me.DocumentContainer1.Guid = New System.Guid("bd794c1a-480f-41f4-af3d-b92885ff49f8")
        Me.DocumentContainer1.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400, System.Windows.Forms.Orientation.Horizontal, New TD.SandDock.LayoutSystemBase() {CType(New TD.SandDock.DocumentLayoutSystem(672, 107, New TD.SandDock.DockControl() {Me.DockControl2, Me.DockControl1}, Me.DockControl1), TD.SandDock.LayoutSystemBase)})
        Me.DocumentContainer1.Location = New System.Drawing.Point(7, 24)
        Me.DocumentContainer1.Manager = Nothing
        Me.DocumentContainer1.Name = "DocumentContainer1"
        Me.DocumentContainer1.Size = New System.Drawing.Size(674, 109)
        Me.DocumentContainer1.TabIndex = 50
        '
        'DockControl1
        '
        Me.DockControl1.Controls.Add(Me.GroupBox1)
        Me.DockControl1.Guid = New System.Guid("4573cc89-81bf-4b63-b23c-df511f371a49")
        Me.DockControl1.Location = New System.Drawing.Point(3, 23)
        Me.DockControl1.Name = "DockControl1"
        Me.DockControl1.Size = New System.Drawing.Size(668, 83)
        Me.DockControl1.TabIndex = 0
        Me.DockControl1.Text = "Configuracion del servidor"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.txtdb)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.txtserver)
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
        'txtdb
        '
        Me.txtdb.Location = New System.Drawing.Point(284, 12)
        Me.txtdb.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtdb.Name = "txtdb"
        Me.txtdb.Size = New System.Drawing.Size(147, 20)
        Me.txtdb.TabIndex = 41
        Me.txtdb.Text = "dbbosque"
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
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(447, 13)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(103, 24)
        Me.Button3.TabIndex = 21
        Me.Button3.Text = "Generar Tablas"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'txtserver
        '
        Me.txtserver.Location = New System.Drawing.Point(58, 13)
        Me.txtserver.Name = "txtserver"
        Me.txtserver.Size = New System.Drawing.Size(137, 20)
        Me.txtserver.TabIndex = 45
        Me.txtserver.Text = "Serversie"
        '
        'DockControl2
        '
        Me.DockControl2.Controls.Add(Me.cmbLenguaje)
        Me.DockControl2.Controls.Add(Me.Label1)
        Me.DockControl2.Controls.Add(Me.Button4)
        Me.DockControl2.Controls.Add(Me.TxbRutaCtrl)
        Me.DockControl2.Controls.Add(Me.Label3)
        Me.DockControl2.Controls.Add(Me.Label4)
        Me.DockControl2.Controls.Add(Me.Button5)
        Me.DockControl2.Controls.Add(Me.ComboBox1)
        Me.DockControl2.Controls.Add(Me.txbRuta)
        Me.DockControl2.Controls.Add(Me.Label5)
        Me.DockControl2.Guid = New System.Guid("97daba78-92f4-4f6a-9b9c-ebc4ec0821de")
        Me.DockControl2.Location = New System.Drawing.Point(3, 23)
        Me.DockControl2.Name = "DockControl2"
        Me.DockControl2.Size = New System.Drawing.Size(668, 83)
        Me.DockControl2.TabIndex = 1
        Me.DockControl2.Text = "Parametros del formulario"
        '
        'cmbLenguaje
        '
        Me.cmbLenguaje.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmbLenguaje.Items.AddRange(New Object() {"Visua Basic", "C#"})
        Me.cmbLenguaje.Location = New System.Drawing.Point(63, 58)
        Me.cmbLenguaje.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbLenguaje.Name = "cmbLenguaje"
        Me.cmbLenguaje.Size = New System.Drawing.Size(154, 21)
        Me.cmbLenguaje.TabIndex = 49
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Lenguaje"
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(623, 39)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(34, 23)
        Me.Button4.TabIndex = 40
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TxbRutaCtrl
        '
        Me.TxbRutaCtrl.Location = New System.Drawing.Point(326, 41)
        Me.TxbRutaCtrl.Name = "TxbRutaCtrl"
        Me.TxbRutaCtrl.Size = New System.Drawing.Size(291, 20)
        Me.TxbRutaCtrl.TabIndex = 38
        Me.TxbRutaCtrl.Text = "c:\"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(225, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 32)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Ruta de la Clase de control"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Elegir Superclase"
        '
        'Button5
        '
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(623, 13)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(34, 23)
        Me.Button5.TabIndex = 37
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txbRuta
        '
        Me.txbRuta.Location = New System.Drawing.Point(326, 15)
        Me.txbRuta.Name = "txbRuta"
        Me.txbRuta.Size = New System.Drawing.Size(291, 20)
        Me.txbRuta.TabIndex = 35
        Me.txbRuta.Text = "c:\"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(225, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Ruta del formulario"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGenerarClase, Me.ToolStripButton2, Me.ToolStripButton1, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 354)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(691, 25)
        Me.ToolStrip1.TabIndex = 51
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
        'FormularioSuperClase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 379)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DocumentContainer1)
        Me.Controls.Add(Me.dgvtabla)
        Me.Name = "FormularioSuperClase"
        Me.Text = "FormularioSuperClase"
        CType(Me.dgvtabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DocumentContainer1.ResumeLayout(False)
        Me.DockControl1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.DockControl2.ResumeLayout(False)
        Me.DockControl2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvtabla As System.Windows.Forms.DataGridView
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents DocumentContainer1 As TD.SandDock.DocumentContainer
    Friend WithEvents DockControl1 As TD.SandDock.DockControl
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DockControl2 As TD.SandDock.DockControl
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TxbRutaCtrl As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents txbRuta As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtdb As System.Windows.Forms.TextBox
    Friend WithEvents txtserver As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGenerarClase As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents tabla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dependiente As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cmbLenguaje As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
