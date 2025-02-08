<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAuditoria
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAuditoria))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnGenerarProcedimiento = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnCargarTabla = New System.Windows.Forms.Button
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.txtdb = New System.Windows.Forms.TextBox
        Me.txtserver = New System.Windows.Forms.TextBox
        Me.grpInformacionClase = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txbunidaddisco = New System.Windows.Forms.TextBox
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.dgvTablas = New System.Windows.Forms.DataGridView
        Me.txtCadena = New System.Windows.Forms.TextBox
        Me.lblCadena = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.NombreTabla = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Generar = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.CampoDescriptor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Insertar = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Modificar = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Eliminar = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Guardaren = New System.Windows.Forms.DataGridViewButtonColumn
        Me.ejecutar = New System.Windows.Forms.DataGridViewButtonColumn
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpInformacionClase.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvTablas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGenerarProcedimiento, Me.ToolStripButton2, Me.ToolStripButton1, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 505)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(892, 25)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGenerarProcedimiento
        '
        Me.btnGenerarProcedimiento.Image = CType(resources.GetObject("btnGenerarProcedimiento.Image"), System.Drawing.Image)
        Me.btnGenerarProcedimiento.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGenerarProcedimiento.Name = "btnGenerarProcedimiento"
        Me.btnGenerarProcedimiento.Size = New System.Drawing.Size(183, 22)
        Me.btnGenerarProcedimiento.Text = "Generar controles para auditoria"
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCargarTabla)
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.txtdb)
        Me.GroupBox1.Controls.Add(Me.txtserver)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(797, 43)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parametros"
        '
        'btnCargarTabla
        '
        Me.btnCargarTabla.Location = New System.Drawing.Point(549, 11)
        Me.btnCargarTabla.Name = "btnCargarTabla"
        Me.btnCargarTabla.Size = New System.Drawing.Size(120, 22)
        Me.btnCargarTabla.TabIndex = 5
        Me.btnCargarTabla.Text = "Cargar Tabla"
        Me.btnCargarTabla.UseVisualStyleBackColor = True
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(260, 16)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(77, 13)
        Me.LinkLabel2.TabIndex = 4
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Base de Datos"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(68, 16)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(46, 13)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Servidor"
        '
        'txtdb
        '
        Me.txtdb.Enabled = False
        Me.txtdb.Location = New System.Drawing.Point(343, 13)
        Me.txtdb.Name = "txtdb"
        Me.txtdb.Size = New System.Drawing.Size(200, 20)
        Me.txtdb.TabIndex = 1
        Me.txtdb.Text = "dbbosque"
        '
        'txtserver
        '
        Me.txtserver.Enabled = False
        Me.txtserver.Location = New System.Drawing.Point(118, 13)
        Me.txtserver.Name = "txtserver"
        Me.txtserver.Size = New System.Drawing.Size(100, 20)
        Me.txtserver.TabIndex = 0
        Me.txtserver.Text = "Serversie"
        '
        'grpInformacionClase
        '
        Me.grpInformacionClase.Controls.Add(Me.Panel1)
        Me.grpInformacionClase.Controls.Add(Me.dgvTablas)
        Me.grpInformacionClase.Controls.Add(Me.txtCadena)
        Me.grpInformacionClase.Controls.Add(Me.lblCadena)
        Me.grpInformacionClase.Location = New System.Drawing.Point(12, 44)
        Me.grpInformacionClase.Name = "grpInformacionClase"
        Me.grpInformacionClase.Size = New System.Drawing.Size(893, 458)
        Me.grpInformacionClase.TabIndex = 15
        Me.grpInformacionClase.TabStop = False
        Me.grpInformacionClase.Text = "Información de la clase"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.txbunidaddisco)
        Me.Panel1.Controls.Add(Me.CheckBox4)
        Me.Panel1.Controls.Add(Me.CheckBox3)
        Me.Panel1.Controls.Add(Me.CheckBox2)
        Me.Panel1.Location = New System.Drawing.Point(8, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(781, 28)
        Me.Panel1.TabIndex = 22
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(544, 3)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(56, 17)
        Me.CheckBox1.TabIndex = 39
        Me.CheckBox1.Text = "Todas"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(749, -1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 22)
        Me.Button1.TabIndex = 38
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txbunidaddisco
        '
        Me.txbunidaddisco.Location = New System.Drawing.Point(660, 1)
        Me.txbunidaddisco.Name = "txbunidaddisco"
        Me.txbunidaddisco.Size = New System.Drawing.Size(83, 20)
        Me.txbunidaddisco.TabIndex = 24
        Me.txbunidaddisco.Text = "c:\"
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(622, 3)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(42, 17)
        Me.CheckBox4.TabIndex = 23
        Me.CheckBox4.Text = "En:"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(446, 4)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(56, 17)
        Me.CheckBox3.TabIndex = 22
        Me.CheckBox3.Text = "Todas"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBox2.Location = New System.Drawing.Point(343, 4)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(62, 18)
        Me.CheckBox2.TabIndex = 21
        Me.CheckBox2.Text = "Todas"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'dgvTablas
        '
        Me.dgvTablas.AllowUserToAddRows = False
        Me.dgvTablas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTablas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NombreTabla, Me.Generar, Me.CampoDescriptor, Me.Insertar, Me.Modificar, Me.Eliminar, Me.Guardaren, Me.ejecutar})
        Me.dgvTablas.Location = New System.Drawing.Point(8, 79)
        Me.dgvTablas.Name = "dgvTablas"
        Me.dgvTablas.Size = New System.Drawing.Size(872, 360)
        Me.dgvTablas.TabIndex = 21
        '
        'txtCadena
        '
        Me.txtCadena.Location = New System.Drawing.Point(136, 16)
        Me.txtCadena.Name = "txtCadena"
        Me.txtCadena.ReadOnly = True
        Me.txtCadena.Size = New System.Drawing.Size(483, 20)
        Me.txtCadena.TabIndex = 0
        Me.txtCadena.Text = "packet size=4096;integrated security=SSPI;data source=server;persist security inf" & _
            "o=False;initial catalog=db"
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
        'NombreTabla
        '
        Me.NombreTabla.HeaderText = "Tabla"
        Me.NombreTabla.Name = "NombreTabla"
        '
        'Generar
        '
        Me.Generar.HeaderText = "Generar"
        Me.Generar.Name = "Generar"
        Me.Generar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Generar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'CampoDescriptor
        '
        Me.CampoDescriptor.HeaderText = "Campo Descriptor"
        Me.CampoDescriptor.Name = "CampoDescriptor"
        '
        'Insertar
        '
        Me.Insertar.HeaderText = "Insercion"
        Me.Insertar.Name = "Insertar"
        Me.Insertar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Insertar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Modificar
        '
        Me.Modificar.HeaderText = "Modificacion"
        Me.Modificar.Name = "Modificar"
        Me.Modificar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Modificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Eliminar
        '
        Me.Eliminar.HeaderText = "Borrado"
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Guardaren
        '
        Me.Guardaren.HeaderText = "path"
        Me.Guardaren.Name = "Guardaren"
        '
        'ejecutar
        '
        Me.ejecutar.HeaderText = "Ejecutar"
        Me.ejecutar.Name = "ejecutar"
        Me.ejecutar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ejecutar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'FrmAuditoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 530)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpInformacionClase)
        Me.Name = "FrmAuditoria"
        Me.Text = "FrmAuditoria"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpInformacionClase.ResumeLayout(False)
        Me.grpInformacionClase.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvTablas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGenerarProcedimiento As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCargarTabla As System.Windows.Forms.Button
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtdb As System.Windows.Forms.TextBox
    Friend WithEvents txtserver As System.Windows.Forms.TextBox
    Friend WithEvents grpInformacionClase As System.Windows.Forms.GroupBox
    Friend WithEvents txtCadena As System.Windows.Forms.TextBox
    Friend WithEvents lblCadena As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents dgvTablas As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txbunidaddisco As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents NombreTabla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Generar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CampoDescriptor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Insertar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Modificar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Eliminar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Guardaren As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ejecutar As System.Windows.Forms.DataGridViewButtonColumn
End Class
