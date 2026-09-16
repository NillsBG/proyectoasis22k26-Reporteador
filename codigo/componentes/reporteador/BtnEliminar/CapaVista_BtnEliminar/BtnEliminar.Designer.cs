namespace CapaVista_BtnEliminar
{
    partial class BtnEliminar
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
            this.BotonEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BotonEliminar
            // 
            this.BotonEliminar.BackColor = System.Drawing.Color.Transparent;
            this.BotonEliminar.BackgroundImage = global::CapaVista_BtnEliminar.Properties.Resources.btn_eliminar;
            this.BotonEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BotonEliminar.Location = new System.Drawing.Point(3, 3);
            this.BotonEliminar.Name = "BotonEliminar";
            this.BotonEliminar.Size = new System.Drawing.Size(65, 63);
            this.BotonEliminar.TabIndex = 0;
            this.BotonEliminar.UseVisualStyleBackColor = false;
            // 
            // BtnEliminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BotonEliminar);
            this.Name = "BtnEliminar";
            this.Size = new System.Drawing.Size(73, 69);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BotonEliminar;
    }
}