namespace CapaVista_BtnEditar
{
    partial class BtnEditar
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

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            this.RtnEditarReporte = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RtnEditarReporte
            // 
            this.RtnEditarReporte.BackColor = System.Drawing.Color.Transparent;
            this.RtnEditarReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RtnEditarReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RtnEditarReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtnEditarReporte.FlatAppearance.BorderSize = 0;
            this.RtnEditarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RtnEditarReporte.Image = global::CapaVista_BtnEditar.Properties.Resources.btn_modificar;
            this.RtnEditarReporte.Location = new System.Drawing.Point(0, 0);
            this.RtnEditarReporte.Name = "RtnEditarReporte";
            this.RtnEditarReporte.Size = new System.Drawing.Size(56, 56);
            this.RtnEditarReporte.TabIndex = 0;
            this.RtnEditarReporte.UseVisualStyleBackColor = false;
            // 
            // BtnEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.RtnEditarReporte);
            this.Name = "BtnEditar";
            this.Size = new System.Drawing.Size(56, 56);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RtnEditarReporte;
    }
}
