namespace CapaVista_BtnActualizar
{
    partial class BtnActualizar
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

        private void InitializeComponent()
        {
            this.ReporteadorBtnActualizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReporteadorBtnActualizar
            // 
            this.ReporteadorBtnActualizar.BackColor = System.Drawing.Color.Transparent;
            this.ReporteadorBtnActualizar.BackgroundImage = global::CapaVista_BtnActualizar.Properties.Resources.btn_refrescar;
            this.ReporteadorBtnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ReporteadorBtnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReporteadorBtnActualizar.FlatAppearance.BorderSize = 0;
            this.ReporteadorBtnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReporteadorBtnActualizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            this.ReporteadorBtnActualizar.Location = new System.Drawing.Point(9, 7);
            this.ReporteadorBtnActualizar.Margin = new System.Windows.Forms.Padding(5);
            this.ReporteadorBtnActualizar.Name = "ReporteadorBtnActualizar";
            this.ReporteadorBtnActualizar.Size = new System.Drawing.Size(56, 56);
            this.ReporteadorBtnActualizar.TabIndex = 0;
            this.ReporteadorBtnActualizar.UseVisualStyleBackColor = false;
            this.ReporteadorBtnActualizar.Click += new System.EventHandler(this.ReporteadorBtnActualizar_Click);
            // 
            // BtnActualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            this.Controls.Add(this.ReporteadorBtnActualizar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BtnActualizar";
            this.Size = new System.Drawing.Size(75, 69);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button ReporteadorBtnActualizar;
    }
}
