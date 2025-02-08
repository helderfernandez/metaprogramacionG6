<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmpreviewclase
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
        Me.RTBclase = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'RTBclase
        '
        Me.RTBclase.Location = New System.Drawing.Point(3, 3)
        Me.RTBclase.Name = "RTBclase"
        Me.RTBclase.Size = New System.Drawing.Size(676, 503)
        Me.RTBclase.TabIndex = 0
        Me.RTBclase.Text = ""
        '
        'frmpreviewclase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 511)
        Me.Controls.Add(Me.RTBclase)
        Me.Name = "frmpreviewclase"
        Me.Text = "frmpreviewclase"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RTBclase As System.Windows.Forms.RichTextBox
End Class
