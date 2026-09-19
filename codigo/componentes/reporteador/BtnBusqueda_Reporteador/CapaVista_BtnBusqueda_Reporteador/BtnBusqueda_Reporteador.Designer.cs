namespace CapaVista_BtnBusqueda_Reporteador
{
    partial class BtnBusquedaReporteador
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BtnBusquedaReporteador));
            this.BtnBusqueda = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnBusqueda
            // 
            this.BtnBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.BtnBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnBusqueda.FlatAppearance.BorderSize = 0;
            this.BtnBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBusqueda.Image = ((System.Drawing.Image)(resources.GetObject("BtnBusqueda.Image")));
            this.BtnBusqueda.Location = new System.Drawing.Point(0, 0);
            this.BtnBusqueda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnBusqueda.Name = "BtnBusqueda";
            this.BtnBusqueda.Size = new System.Drawing.Size(56, 56);
            this.BtnBusqueda.TabIndex = 0;
            this.BtnBusqueda.UseVisualStyleBackColor = false;
            // 
            // BtnBusquedaReporteador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.BtnBusqueda);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "BtnBusquedaReporteador";
            this.Size = new System.Drawing.Size(56, 56);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnBusqueda;
    }
}
