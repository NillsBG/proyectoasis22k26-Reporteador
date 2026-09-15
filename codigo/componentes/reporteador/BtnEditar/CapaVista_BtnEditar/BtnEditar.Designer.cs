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
            this.btnAccionEditar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // btnAccionEditar
            // 
            this.btnAccionEditar.BackColor =
                System.Drawing.Color.Transparent;

            this.btnAccionEditar.BackgroundImageLayout =
                System.Windows.Forms.ImageLayout.Center;

            this.btnAccionEditar.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnAccionEditar.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.btnAccionEditar.FlatAppearance.BorderSize = 0;

            this.btnAccionEditar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnAccionEditar.Image =
                global::CapaVista_BtnEditar.Properties.Resources.btn_modificar;

            this.btnAccionEditar.Location =
                new System.Drawing.Point(0, 0);

            this.btnAccionEditar.Name =
                "btnAccionEditar";

            this.btnAccionEditar.Size =
                new System.Drawing.Size(56, 56);

            this.btnAccionEditar.TabIndex = 0;

            this.btnAccionEditar.UseVisualStyleBackColor =
                false;

            // 
            // BtnEditar
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(6F, 13F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.Controls.Add(this.btnAccionEditar);

            this.Name =
                "BtnEditar";

            this.Size =
                new System.Drawing.Size(56, 56);

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnAccionEditar;
    }
}
