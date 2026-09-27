namespace CapaVista_BtnVerReporte_Reporteador
{
    partial class FrmVistaPrevia
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.ReporteadorRpvVistaPrevia = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            //
            // ReporteadorRpvVistaPrevia
            //
            this.ReporteadorRpvVistaPrevia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReporteadorRpvVistaPrevia.Location = new System.Drawing.Point(0, 0);
            this.ReporteadorRpvVistaPrevia.Name = "ReporteadorRpvVistaPrevia";
            this.ReporteadorRpvVistaPrevia.ServerReport.BearerToken = null;
            this.ReporteadorRpvVistaPrevia.Size = new System.Drawing.Size(1000, 700);
            this.ReporteadorRpvVistaPrevia.TabIndex = 0;
            //
            // FrmVistaPrevia
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.ReporteadorRpvVistaPrevia);
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Name = "FrmVistaPrevia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "3002 – VistaPrevia";
            this.Load += new System.EventHandler(this.FrmVistaPrevia_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer ReporteadorRpvVistaPrevia;
    }
}
