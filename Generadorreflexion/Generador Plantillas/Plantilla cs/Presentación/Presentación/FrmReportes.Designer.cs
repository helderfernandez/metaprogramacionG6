namespace Presentación
{
    partial class FrmReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.visor = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // visor
            // 
            this.visor.ActiveViewIndex = -1;
            this.visor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.visor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visor.Location = new System.Drawing.Point(0, 0);
            this.visor.Name = "visor";
            this.visor.SelectionFormula = "";
            this.visor.Size = new System.Drawing.Size(863, 413);
            this.visor.TabIndex = 0;
            this.visor.ViewTimeSelectionFormula = "";
            this.visor.Load += new System.EventHandler(this.visor_Load);
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 413);
            this.Controls.Add(this.visor);
            this.Name = "FrmReportes";
            this.Text = "FrmReportes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer visor;
    }
}