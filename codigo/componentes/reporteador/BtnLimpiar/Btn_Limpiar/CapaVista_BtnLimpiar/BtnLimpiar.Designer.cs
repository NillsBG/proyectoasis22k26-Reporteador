
   
namespace CapaVista_BtnLimpiar
    {
        partial class BtnLimpiar
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
            this.BtnLimpiarReportes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnLimpiarReportes
            // 
            this.BtnLimpiarReportes.BackColor = System.Drawing.Color.Transparent;
            this.BtnLimpiarReportes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnLimpiarReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiarReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLimpiarReportes.FlatAppearance.BorderSize = 0;
            this.BtnLimpiarReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiarReportes.Image = global::CapaVista_BtnLimpiar.Properties.Resources.btn_limpiarReporte;
            this.BtnLimpiarReportes.Location = new System.Drawing.Point(0, 0);
            this.BtnLimpiarReportes.Name = "BtnLimpiarReportes";
            this.BtnLimpiarReportes.Size = new System.Drawing.Size(56, 56);
            this.BtnLimpiarReportes.TabIndex = 0;
            this.BtnLimpiarReportes.UseVisualStyleBackColor = false;
            // 
            // BtnLimpiar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.BtnLimpiarReportes);
            this.Name = "BtnLimpiar";
            this.Size = new System.Drawing.Size(56, 56);
            this.ResumeLayout(false);

            }

            private System.Windows.Forms.Button BtnLimpiarReportes;
        }
    }

