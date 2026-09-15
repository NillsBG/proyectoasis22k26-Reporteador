namespace CapaVista_BtnBusqueda
{
    partial class BtnBusqueda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BtnBusqueda));
            this.btnAccionBusqueda = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAccionBusqueda
            // 
            this.btnAccionBusqueda.BackColor = System.Drawing.Color.Transparent;
            this.btnAccionBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccionBusqueda.FlatAppearance.BorderSize = 0;
            this.btnAccionBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccionBusqueda.Image = ((System.Drawing.Image)(resources.GetObject("btnAccionBusqueda.Image")));
            this.btnAccionBusqueda.Location = new System.Drawing.Point(-1, 0);
            this.btnAccionBusqueda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAccionBusqueda.Name = "btnAccionBusqueda";
            this.btnAccionBusqueda.Size = new System.Drawing.Size(56, 56);
            this.btnAccionBusqueda.TabIndex = 0;
            this.btnAccionBusqueda.UseVisualStyleBackColor = false;
            // 
            // BtnBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnAccionBusqueda);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BtnBusqueda";
            this.Size = new System.Drawing.Size(55, 56);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccionBusqueda;
    }
}
