<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporte
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
        Me.visor = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'visor
        '
        Me.visor.ActiveViewIndex = -1
        Me.visor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.visor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.visor.Location = New System.Drawing.Point(0, 0)
        Me.visor.Name = "visor"
        Me.visor.SelectionFormula = ""
        Me.visor.Size = New System.Drawing.Size(1080, 549)
        Me.visor.TabIndex = 0
        Me.visor.ViewTimeSelectionFormula = ""
        '
        'FrmReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 549)
        Me.Controls.Add(Me.visor)
        Me.Name = "FrmReporte"
        Me.Text = "FrmReporte"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents visor As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
