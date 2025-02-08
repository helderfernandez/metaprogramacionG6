<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlantillas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPlantillas))
        Me.DocumentContainer1 = New TD.SandDock.DocumentContainer
        Me.DockControl1 = New TD.SandDock.DockControl
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbDisponibles = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txbRuta = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnGenerarClase = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.RDB1Vb1 = New System.Windows.Forms.RadioButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.DockControl2 = New TD.SandDock.DockControl
        Me.P = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.DockControl3 = New TD.SandDock.DockControl
        Me.SandDockManager1 = New TD.SandDock.SandDockManager
        Me.leftSandDock = New TD.SandDock.DockContainer
        Me.rightSandDock = New TD.SandDock.DockContainer
        Me.bottomSandDock = New TD.SandDock.DockContainer
        Me.topSandDock = New TD.SandDock.DockContainer
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog
        Me.DocumentContainer1.SuspendLayout()
        Me.DockControl1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockControl2.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DocumentContainer1
        '
        Me.DocumentContainer1.Controls.Add(Me.DockControl1)
        Me.DocumentContainer1.Controls.Add(Me.DockControl2)
        Me.DocumentContainer1.Controls.Add(Me.DockControl3)
        Me.DocumentContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.DocumentContainer1.Guid = New System.Guid("a73fb6f0-69a2-49d2-b149-4ef9058f9568")
        Me.DocumentContainer1.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400, System.Windows.Forms.Orientation.Horizontal, New TD.SandDock.LayoutSystemBase() {CType(New TD.SandDock.DocumentLayoutSystem(493, 367, New TD.SandDock.DockControl() {Me.DockControl1, Me.DockControl2, Me.DockControl3}, Me.DockControl1), TD.SandDock.LayoutSystemBase)})
        Me.DocumentContainer1.Location = New System.Drawing.Point(0, 0)
        Me.DocumentContainer1.Manager = Nothing
        Me.DocumentContainer1.Name = "DocumentContainer1"
        Me.DocumentContainer1.Size = New System.Drawing.Size(495, 369)
        Me.DocumentContainer1.TabIndex = 0
        '
        'DockControl1
        '
        Me.DockControl1.Controls.Add(Me.TextBox2)
        Me.DockControl1.Controls.Add(Me.Label2)
        Me.DockControl1.Controls.Add(Me.cmbDisponibles)
        Me.DockControl1.Controls.Add(Me.Button1)
        Me.DockControl1.Controls.Add(Me.Label1)
        Me.DockControl1.Controls.Add(Me.txbRuta)
        Me.DockControl1.Controls.Add(Me.ToolStrip1)
        Me.DockControl1.Controls.Add(Me.RDB1Vb1)
        Me.DockControl1.Controls.Add(Me.PictureBox1)
        Me.DockControl1.Guid = New System.Guid("25d61da7-8ea9-4270-a3f7-916e751b87b5")
        Me.DockControl1.Location = New System.Drawing.Point(3, 23)
        Me.DockControl1.Name = "DockControl1"
        Me.DockControl1.Size = New System.Drawing.Size(489, 343)
        Me.DockControl1.TabIndex = 0
        Me.DockControl1.Text = "Visual Basic"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(230, 102)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(240, 20)
        Me.TextBox2.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(227, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Plantillas Disponibles"
        '
        'cmbDisponibles
        '
        Me.cmbDisponibles.FormattingEnabled = True
        Me.cmbDisponibles.Location = New System.Drawing.Point(230, 57)
        Me.cmbDisponibles.Name = "cmbDisponibles"
        Me.cmbDisponibles.Size = New System.Drawing.Size(240, 21)
        Me.cmbDisponibles.TabIndex = 14
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(173, 224)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(34, 23)
        Me.Button1.TabIndex = 13
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 210)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Ruta"
        '
        'txbRuta
        '
        Me.txbRuta.Location = New System.Drawing.Point(3, 227)
        Me.txbRuta.Name = "txbRuta"
        Me.txbRuta.Size = New System.Drawing.Size(164, 20)
        Me.txbRuta.TabIndex = 11
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGenerarClase, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 318)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(489, 25)
        Me.ToolStrip1.TabIndex = 10
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGenerarClase
        '
        Me.btnGenerarClase.Image = CType(resources.GetObject("btnGenerarClase.Image"), System.Drawing.Image)
        Me.btnGenerarClase.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGenerarClase.Name = "btnGenerarClase"
        Me.btnGenerarClase.Size = New System.Drawing.Size(105, 22)
        Me.btnGenerarClase.Text = "Generar Plantilla"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(99, 22)
        Me.ToolStripButton2.Text = "Cargar plantilla"
        '
        'RDB1Vb1
        '
        Me.RDB1Vb1.AutoSize = True
        Me.RDB1Vb1.Location = New System.Drawing.Point(3, 190)
        Me.RDB1Vb1.Name = "RDB1Vb1"
        Me.RDB1Vb1.Size = New System.Drawing.Size(118, 17)
        Me.RDB1Vb1.TabIndex = 2
        Me.RDB1Vb1.TabStop = True
        Me.RDB1Vb1.Text = "SandDockManager"
        Me.RDB1Vb1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(9, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(215, 163)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'DockControl2
        '
        Me.DockControl2.Controls.Add(Me.P)
        Me.DockControl2.Controls.Add(Me.ComboBox1)
        Me.DockControl2.Controls.Add(Me.TextBox3)
        Me.DockControl2.Controls.Add(Me.Button2)
        Me.DockControl2.Controls.Add(Me.TextBox1)
        Me.DockControl2.Controls.Add(Me.ToolStrip2)
        Me.DockControl2.Controls.Add(Me.RadioButton1)
        Me.DockControl2.Controls.Add(Me.PictureBox2)
        Me.DockControl2.Guid = New System.Guid("453d63b9-a150-4532-8e7d-c075dbb05e54")
        Me.DockControl2.Location = New System.Drawing.Point(3, 23)
        Me.DockControl2.Name = "DockControl2"
        Me.DockControl2.Size = New System.Drawing.Size(489, 343)
        Me.DockControl2.TabIndex = 1
        Me.DockControl2.Text = "Visual c#."
        '
        'P
        '
        Me.P.AutoSize = True
        Me.P.Location = New System.Drawing.Point(228, 21)
        Me.P.Name = "P"
        Me.P.Size = New System.Drawing.Size(105, 13)
        Me.P.TabIndex = 21
        Me.P.Text = "Plantillas Disponibles"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(231, 56)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(224, 21)
        Me.ComboBox1.TabIndex = 20
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(231, 111)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(224, 20)
        Me.TextBox3.TabIndex = 19
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(173, 213)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(34, 23)
        Me.Button2.TabIndex = 18
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(3, 216)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(164, 20)
        Me.TextBox1.TabIndex = 17
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton4, Me.ToolStripButton5})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 318)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(489, 25)
        Me.ToolStrip2.TabIndex = 16
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(105, 22)
        Me.ToolStripButton4.Text = "Generar Plantilla"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(99, 22)
        Me.ToolStripButton5.Text = "Cargar Plantilla"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(3, 179)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(118, 17)
        Me.RadioButton1.TabIndex = 15
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "SandDockManager"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(3, 10)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(198, 163)
        Me.PictureBox2.TabIndex = 14
        Me.PictureBox2.TabStop = False
        '
        'DockControl3
        '
        Me.DockControl3.Guid = New System.Guid("99fea58b-a456-496f-b771-1d788907e900")
        Me.DockControl3.Location = New System.Drawing.Point(3, 23)
        Me.DockControl3.Name = "DockControl3"
        Me.DockControl3.Size = New System.Drawing.Size(686, 343)
        Me.DockControl3.TabIndex = 2
        Me.DockControl3.Text = "Asp. Net"
        '
        'SandDockManager1
        '
        Me.SandDockManager1.OwnerForm = Me
        '
        'leftSandDock
        '
        Me.leftSandDock.Dock = System.Windows.Forms.DockStyle.Left
        Me.leftSandDock.Guid = New System.Guid("4cf99fb2-f164-42e7-986f-ee8a16c439e3")
        Me.leftSandDock.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400)
        Me.leftSandDock.Location = New System.Drawing.Point(0, 0)
        Me.leftSandDock.Manager = Me.SandDockManager1
        Me.leftSandDock.Name = "leftSandDock"
        Me.leftSandDock.Size = New System.Drawing.Size(0, 369)
        Me.leftSandDock.TabIndex = 1
        '
        'rightSandDock
        '
        Me.rightSandDock.Dock = System.Windows.Forms.DockStyle.Right
        Me.rightSandDock.Guid = New System.Guid("27745a1e-e0fd-4f3f-b4dd-bfd877b37cba")
        Me.rightSandDock.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400)
        Me.rightSandDock.Location = New System.Drawing.Point(495, 0)
        Me.rightSandDock.Manager = Me.SandDockManager1
        Me.rightSandDock.Name = "rightSandDock"
        Me.rightSandDock.Size = New System.Drawing.Size(0, 369)
        Me.rightSandDock.TabIndex = 2
        '
        'bottomSandDock
        '
        Me.bottomSandDock.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bottomSandDock.Guid = New System.Guid("6b62cd45-155b-4afd-ac93-d9018db58798")
        Me.bottomSandDock.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400)
        Me.bottomSandDock.Location = New System.Drawing.Point(0, 369)
        Me.bottomSandDock.Manager = Me.SandDockManager1
        Me.bottomSandDock.Name = "bottomSandDock"
        Me.bottomSandDock.Size = New System.Drawing.Size(495, 0)
        Me.bottomSandDock.TabIndex = 3
        '
        'topSandDock
        '
        Me.topSandDock.Dock = System.Windows.Forms.DockStyle.Top
        Me.topSandDock.Guid = New System.Guid("e0ef5fe4-9e48-492b-a63d-ebabee018451")
        Me.topSandDock.LayoutSystem = New TD.SandDock.SplitLayoutSystem(250, 400)
        Me.topSandDock.Location = New System.Drawing.Point(0, 0)
        Me.topSandDock.Manager = Me.SandDockManager1
        Me.topSandDock.Name = "topSandDock"
        Me.topSandDock.Size = New System.Drawing.Size(495, 0)
        Me.topSandDock.TabIndex = 4
        '
        'FrmPlantillas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 369)
        Me.Controls.Add(Me.DocumentContainer1)
        Me.Controls.Add(Me.leftSandDock)
        Me.Controls.Add(Me.rightSandDock)
        Me.Controls.Add(Me.bottomSandDock)
        Me.Controls.Add(Me.topSandDock)
        Me.Name = "FrmPlantillas"
        Me.Text = "Plantillas predisenadas"
        Me.DocumentContainer1.ResumeLayout(False)
        Me.DockControl1.ResumeLayout(False)
        Me.DockControl1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockControl2.ResumeLayout(False)
        Me.DockControl2.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DocumentContainer1 As TD.SandDock.DocumentContainer
    Friend WithEvents DockControl1 As TD.SandDock.DockControl
    Friend WithEvents RDB1Vb1 As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents SandDockManager1 As TD.SandDock.SandDockManager
    Friend WithEvents leftSandDock As TD.SandDock.DockContainer
    Friend WithEvents rightSandDock As TD.SandDock.DockContainer
    Friend WithEvents bottomSandDock As TD.SandDock.DockContainer
    Friend WithEvents topSandDock As TD.SandDock.DockContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGenerarClase As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents DockControl2 As TD.SandDock.DockControl
    Friend WithEvents DockControl3 As TD.SandDock.DockControl
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txbRuta As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents FolderBrowserDialog2 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbDisponibles As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents P As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
End Class
