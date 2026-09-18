namespace CapaVista_BtnLimpiar_Reporteador
{
    partial class BtnLimpiarReporteador
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool Disposing)
        {
            if (Disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(Disposing);
        }

        private void InitializeComponent()
        {
            this.ReporteadorBtnAccionLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReporteadorBtnAccionLimpiar
            // 
            this.ReporteadorBtnAccionLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.ReporteadorBtnAccionLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ReporteadorBtnAccionLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReporteadorBtnAccionLimpiar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReporteadorBtnAccionLimpiar.FlatAppearance.BorderSize = 0;
            this.ReporteadorBtnAccionLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReporteadorBtnAccionLimpiar.Image = global::CapaVista_BtnLimpiar_Reporteador.Properties.Resources.btn_limpiarReporte;
            this.ReporteadorBtnAccionLimpiar.Location = new System.Drawing.Point(0, 0);
            this.ReporteadorBtnAccionLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReporteadorBtnAccionLimpiar.Name = "ReporteadorBtnAccionLimpiar";
            this.ReporteadorBtnAccionLimpiar.Size = new System.Drawing.Size(75, 69);
            this.ReporteadorBtnAccionLimpiar.TabIndex = 0;
            this.ReporteadorBtnAccionLimpiar.UseVisualStyleBackColor = false;
            this.ReporteadorBtnAccionLimpiar.Click += new System.EventHandler(this.ReporteadorMetLimpiarClick);
            // 
            // BtnLimpiar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReporteadorBtnAccionLimpiar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BtnLimpiar";
            this.Size = new System.Drawing.Size(75, 69);
            this.ResumeLayout(false);
        }


        private System.Windows.Forms.Button ReporteadorBtnAccionLimpiar;

        
    }
}
