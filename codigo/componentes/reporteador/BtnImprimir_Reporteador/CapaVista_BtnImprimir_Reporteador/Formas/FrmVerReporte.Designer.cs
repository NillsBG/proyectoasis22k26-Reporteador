namespace CapaVista_BtnImprimir_Reporteador.Formas
{
    partial class FrmVerReporte
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVerReporte));
            this.ReporteadorRvwreporte = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // ReporteadorRvwreporte
            // 
            this.ReporteadorRvwreporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReporteadorRvwreporte.Location = new System.Drawing.Point(0, 0);
            this.ReporteadorRvwreporte.Name = "ReporteadorRvwreporte";
            this.ReporteadorRvwreporte.ServerReport.BearerToken = null;
            this.ReporteadorRvwreporte.Size = new System.Drawing.Size(900, 600);
            this.ReporteadorRvwreporte.TabIndex = 0;
            // 
            // FrmVerReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.ReporteadorRvwreporte);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVerReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3002 - Visualización del reporte";
            this.Load += new System.EventHandler(this.FrmVerReporte_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer
            ReporteadorRvwreporte;
    }
}