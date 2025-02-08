using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentación
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void mostrarReportes() {

            switch (Utilitario.Utilitarios.listadoReporte)
            {
                case 1:
                    Reportes.CtrlReportes objctrlreporte = new Reportes.CtrlReportes();
                    Reportes.Gestionar_arbol.rptarbol objrptarbol = new Reportes.Gestionar_arbol.rptarbol();
                    objrptarbol.SetDataSource (objctrlreporte.ListadoArboles(Utilitario.Utilitarios.idarbol));
                    this.visor.ReportSource = objrptarbol;
                    break;
                default:
                    break;
            }
        
        
        
        }
        private void FrmReportes_Load(object sender, EventArgs e)
        {
            this.mostrarReportes();
        }

    }
}