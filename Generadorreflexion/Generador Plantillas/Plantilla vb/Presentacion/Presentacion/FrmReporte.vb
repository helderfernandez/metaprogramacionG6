Public Class FrmReporte
    Public objCtrlReporte As New Reportes.CtrlReportes
#Region "metodos"
    Private Sub mostrarReporte()
        Select Case Utilitario.NroReporte
            'Case Utilitario.ListaReporte.ListadoDeEspecies
            '    Dim objrptEspecie As New Reportes.rptEspecie  'Es el Reporte               
            '    objrptEspecie.SetDataSource(objCtrlReporte.ListadoEspecie(Utilitario.Idespecie))
            '    visor.ReportSource = objrptEspecie
            'Case Utilitario.ListaReporte.ListadoBosqueArbol
            '    Dim objrptbosquearbol As New Reportes.RptBosqueArbol
            '    objrptbosquearbol.SetDataSource(objCtrlReporte.ListadoBosqueArboles(Utilitario.idarbol))
            '    Me.visor.ReportSource = objrptbosquearbol
            'Case Utilitario.ListaReporte.listdopedido
            '    Dim objrptpedido As New Reportes.rptpedido
            '    objrptpedido.SetDataSource(objCtrlReporte.Listadopedido(Utilitario.idpedido))
            '    Me.visor.ReportSource = objrptpedido

        End Select
    End Sub
#End Region



    Private Sub FrmReporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mostrarReporte()
    End Sub

   
End Class