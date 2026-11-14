namespace CapaVista_CierreInventario_Logistica.Formularios
{
    partial class FrmCierreInventario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCierreInventario));
            this.LogisticaCboSucursal = new System.Windows.Forms.ComboBox();
            this.LogisticaCboMesCierre = new System.Windows.Forms.ComboBox();
            this.LogisticaCboAñoCierre = new System.Windows.Forms.ComboBox();
            this.LogisticaPnlCierreInventario = new System.Windows.Forms.Panel();
            this.LogisticaBtnConfirmarCierre = new System.Windows.Forms.Button();
            this.LogisticaBtnValidarPeriodo = new System.Windows.Forms.Button();
            this.LogisticaBtnLimpiar = new System.Windows.Forms.Button();
            this.LogisticaBtnConsultarCierre = new System.Windows.Forms.Button();
            this.LogisticaLblDetalleInventario = new System.Windows.Forms.Label();
            this.LogisticaLblTextoBodegasIncluidas = new System.Windows.Forms.Label();
            this.LogisticaLblTextoProductosDiferencias = new System.Windows.Forms.Label();
            this.LogisticaLblTextoProductosRegistrados = new System.Windows.Forms.Label();
            this.LogisticaLblTextoMovimientoMes = new System.Windows.Forms.Label();
            this.LogisticaLblProductosDiferencias = new System.Windows.Forms.Label();
            this.LogisticaDgvDetalleCierre = new System.Windows.Forms.DataGridView();
            this.LogisticaLblMovimientoMes = new System.Windows.Forms.Label();
            this.LogisticaLblDatosCierre = new System.Windows.Forms.Label();
            this.LogisticaLblBodegasIncluidas = new System.Windows.Forms.Label();
            this.LogisticaLblMesCierre = new System.Windows.Forms.Label();
            this.LogisticaLblProductosRegistrados = new System.Windows.Forms.Label();
            this.LogisticaLblSucursal = new System.Windows.Forms.Label();
            this.LogisticaLblAñoCierre = new System.Windows.Forms.Label();
            this.LogisticaLblResumenInventario = new System.Windows.Forms.Label();
            this.LogisticaLblTituloCierreInventario = new System.Windows.Forms.Label();
            this.LogisticaPnlCierreInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogisticaDgvDetalleCierre)).BeginInit();
            this.SuspendLayout();
            // 
            // LogisticaCboSucursal
            // 
            this.LogisticaCboSucursal.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.LogisticaCboSucursal.FormattingEnabled = true;
            this.LogisticaCboSucursal.Location = new System.Drawing.Point(113, 194);
            this.LogisticaCboSucursal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogisticaCboSucursal.Name = "LogisticaCboSucursal";
            this.LogisticaCboSucursal.Size = new System.Drawing.Size(460, 31);
            this.LogisticaCboSucursal.TabIndex = 1;
            // 
            // LogisticaCboMesCierre
            // 
            this.LogisticaCboMesCierre.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.LogisticaCboMesCierre.FormattingEnabled = true;
            this.LogisticaCboMesCierre.Location = new System.Drawing.Point(115, 306);
            this.LogisticaCboMesCierre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogisticaCboMesCierre.Name = "LogisticaCboMesCierre";
            this.LogisticaCboMesCierre.Size = new System.Drawing.Size(215, 31);
            this.LogisticaCboMesCierre.TabIndex = 5;
            // 
            // LogisticaCboAñoCierre
            // 
            this.LogisticaCboAñoCierre.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.LogisticaCboAñoCierre.FormattingEnabled = true;
            this.LogisticaCboAñoCierre.Location = new System.Drawing.Point(377, 306);
            this.LogisticaCboAñoCierre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogisticaCboAñoCierre.Name = "LogisticaCboAñoCierre";
            this.LogisticaCboAñoCierre.Size = new System.Drawing.Size(196, 31);
            this.LogisticaCboAñoCierre.TabIndex = 6;
            // 
            // LogisticaPnlCierreInventario
            // 
            this.LogisticaPnlCierreInventario.BackgroundImage = global::CapaVista_CierreInventario_Logistica.Properties.Resources.FondoLogica21;
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaBtnConfirmarCierre);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaBtnValidarPeriodo);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaBtnLimpiar);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaBtnConsultarCierre);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaLblDetalleInventario);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaLblTextoBodegasIncluidas);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaLblTextoProductosDiferencias);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaLblTextoProductosRegistrados);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaLblTextoMovimientoMes);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaLblProductosDiferencias);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaDgvDetalleCierre);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaLblMovimientoMes);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaLblDatosCierre);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaLblBodegasIncluidas);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaLblMesCierre);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaLblProductosRegistrados);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaLblSucursal);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaLblAñoCierre);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaLblResumenInventario);
            this.LogisticaPnlCierreInventario.Controls.Add(this.LogisticaLblTituloCierreInventario);
            this.LogisticaPnlCierreInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogisticaPnlCierreInventario.Location = new System.Drawing.Point(0, 0);
            this.LogisticaPnlCierreInventario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogisticaPnlCierreInventario.Name = "LogisticaPnlCierreInventario";
            this.LogisticaPnlCierreInventario.Size = new System.Drawing.Size(1141, 734);
            this.LogisticaPnlCierreInventario.TabIndex = 24;
            // 
            // LogisticaBtnConfirmarCierre
            // 
            this.LogisticaBtnConfirmarCierre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(216)))), ((int)(((byte)(197)))));
            this.LogisticaBtnConfirmarCierre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogisticaBtnConfirmarCierre.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(99)))), ((int)(((byte)(46)))));
            this.LogisticaBtnConfirmarCierre.FlatAppearance.BorderSize = 2;
            this.LogisticaBtnConfirmarCierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogisticaBtnConfirmarCierre.ForeColor = System.Drawing.Color.Teal;
            this.LogisticaBtnConfirmarCierre.Location = new System.Drawing.Point(965, 567);
            this.LogisticaBtnConfirmarCierre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogisticaBtnConfirmarCierre.Name = "LogisticaBtnConfirmarCierre";
            this.LogisticaBtnConfirmarCierre.Size = new System.Drawing.Size(80, 69);
            this.LogisticaBtnConfirmarCierre.TabIndex = 23;
            this.LogisticaBtnConfirmarCierre.Text = "Confirmar Cierre";
            this.LogisticaBtnConfirmarCierre.UseVisualStyleBackColor = false;
            // 
            // LogisticaBtnValidarPeriodo
            // 
            this.LogisticaBtnValidarPeriodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(216)))), ((int)(((byte)(197)))));
            this.LogisticaBtnValidarPeriodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogisticaBtnValidarPeriodo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(99)))), ((int)(((byte)(46)))));
            this.LogisticaBtnValidarPeriodo.FlatAppearance.BorderSize = 2;
            this.LogisticaBtnValidarPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogisticaBtnValidarPeriodo.ForeColor = System.Drawing.Color.Teal;
            this.LogisticaBtnValidarPeriodo.Location = new System.Drawing.Point(396, 354);
            this.LogisticaBtnValidarPeriodo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogisticaBtnValidarPeriodo.Name = "LogisticaBtnValidarPeriodo";
            this.LogisticaBtnValidarPeriodo.Size = new System.Drawing.Size(76, 66);
            this.LogisticaBtnValidarPeriodo.TabIndex = 19;
            this.LogisticaBtnValidarPeriodo.Text = "Validar";
            this.LogisticaBtnValidarPeriodo.UseVisualStyleBackColor = false;
            // 
            // LogisticaBtnLimpiar
            // 
            this.LogisticaBtnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(216)))), ((int)(((byte)(197)))));
            this.LogisticaBtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogisticaBtnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(99)))), ((int)(((byte)(46)))));
            this.LogisticaBtnLimpiar.FlatAppearance.BorderSize = 2;
            this.LogisticaBtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogisticaBtnLimpiar.ForeColor = System.Drawing.Color.Teal;
            this.LogisticaBtnLimpiar.Location = new System.Drawing.Point(485, 354);
            this.LogisticaBtnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogisticaBtnLimpiar.Name = "LogisticaBtnLimpiar";
            this.LogisticaBtnLimpiar.Size = new System.Drawing.Size(76, 66);
            this.LogisticaBtnLimpiar.TabIndex = 20;
            this.LogisticaBtnLimpiar.Text = "Limpiar";
            this.LogisticaBtnLimpiar.UseVisualStyleBackColor = false;
            // 
            // LogisticaBtnConsultarCierre
            // 
            this.LogisticaBtnConsultarCierre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogisticaBtnConsultarCierre.FlatAppearance.BorderSize = 0;
            this.LogisticaBtnConsultarCierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogisticaBtnConsultarCierre.Image = global::CapaVista_CierreInventario_Logistica.Properties.Resources.btn_consultar;
            this.LogisticaBtnConsultarCierre.Location = new System.Drawing.Point(965, 457);
            this.LogisticaBtnConsultarCierre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogisticaBtnConsultarCierre.Name = "LogisticaBtnConsultarCierre";
            this.LogisticaBtnConsultarCierre.Size = new System.Drawing.Size(80, 81);
            this.LogisticaBtnConsultarCierre.TabIndex = 21;
            this.LogisticaBtnConsultarCierre.UseVisualStyleBackColor = true;
            this.LogisticaBtnConsultarCierre.Click += new System.EventHandler(this.LogisticaBtnConsultarCierre_Click_1);
            // 
            // LogisticaLblDetalleInventario
            // 
            this.LogisticaLblDetalleInventario.AutoSize = true;
            this.LogisticaLblDetalleInventario.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblDetalleInventario.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.LogisticaLblDetalleInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.LogisticaLblDetalleInventario.Location = new System.Drawing.Point(112, 386);
            this.LogisticaLblDetalleInventario.Name = "LogisticaLblDetalleInventario";
            this.LogisticaLblDetalleInventario.Size = new System.Drawing.Size(173, 23);
            this.LogisticaLblDetalleInventario.TabIndex = 14;
            this.LogisticaLblDetalleInventario.Text = "Detalle del Inventario";
            // 
            // LogisticaLblTextoBodegasIncluidas
            // 
            this.LogisticaLblTextoBodegasIncluidas.AutoSize = true;
            this.LogisticaLblTextoBodegasIncluidas.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblTextoBodegasIncluidas.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.LogisticaLblTextoBodegasIncluidas.ForeColor = System.Drawing.SystemColors.WindowText;
            this.LogisticaLblTextoBodegasIncluidas.Location = new System.Drawing.Point(889, 203);
            this.LogisticaLblTextoBodegasIncluidas.Name = "LogisticaLblTextoBodegasIncluidas";
            this.LogisticaLblTextoBodegasIncluidas.Size = new System.Drawing.Size(146, 23);
            this.LogisticaLblTextoBodegasIncluidas.TabIndex = 10;
            this.LogisticaLblTextoBodegasIncluidas.Text = "bodegas incluidas";
            // 
            // LogisticaLblTextoProductosDiferencias
            // 
            this.LogisticaLblTextoProductosDiferencias.AutoSize = true;
            this.LogisticaLblTextoProductosDiferencias.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblTextoProductosDiferencias.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.LogisticaLblTextoProductosDiferencias.ForeColor = System.Drawing.Color.Black;
            this.LogisticaLblTextoProductosDiferencias.Location = new System.Drawing.Point(863, 306);
            this.LogisticaLblTextoProductosDiferencias.Name = "LogisticaLblTextoProductosDiferencias";
            this.LogisticaLblTextoProductosDiferencias.Size = new System.Drawing.Size(206, 23);
            this.LogisticaLblTextoProductosDiferencias.TabIndex = 12;
            this.LogisticaLblTextoProductosDiferencias.Text = "productos con diferencias";
            // 
            // LogisticaLblTextoProductosRegistrados
            // 
            this.LogisticaLblTextoProductosRegistrados.AutoSize = true;
            this.LogisticaLblTextoProductosRegistrados.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblTextoProductosRegistrados.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.LogisticaLblTextoProductosRegistrados.ForeColor = System.Drawing.SystemColors.WindowText;
            this.LogisticaLblTextoProductosRegistrados.Location = new System.Drawing.Point(633, 203);
            this.LogisticaLblTextoProductosRegistrados.Name = "LogisticaLblTextoProductosRegistrados";
            this.LogisticaLblTextoProductosRegistrados.Size = new System.Drawing.Size(176, 23);
            this.LogisticaLblTextoProductosRegistrados.TabIndex = 9;
            this.LogisticaLblTextoProductosRegistrados.Text = "Productos registrados";
            // 
            // LogisticaLblTextoMovimientoMes
            // 
            this.LogisticaLblTextoMovimientoMes.AutoSize = true;
            this.LogisticaLblTextoMovimientoMes.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblTextoMovimientoMes.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.LogisticaLblTextoMovimientoMes.ForeColor = System.Drawing.Color.Black;
            this.LogisticaLblTextoMovimientoMes.Location = new System.Drawing.Point(633, 306);
            this.LogisticaLblTextoMovimientoMes.Name = "LogisticaLblTextoMovimientoMes";
            this.LogisticaLblTextoMovimientoMes.Size = new System.Drawing.Size(172, 23);
            this.LogisticaLblTextoMovimientoMes.TabIndex = 11;
            this.LogisticaLblTextoMovimientoMes.Text = "Movimientos del mes";
            // 
            // LogisticaLblProductosDiferencias
            // 
            this.LogisticaLblProductosDiferencias.AutoSize = true;
            this.LogisticaLblProductosDiferencias.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblProductosDiferencias.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogisticaLblProductosDiferencias.Location = new System.Drawing.Point(953, 353);
            this.LogisticaLblProductosDiferencias.Name = "LogisticaLblProductosDiferencias";
            this.LogisticaLblProductosDiferencias.Size = new System.Drawing.Size(23, 28);
            this.LogisticaLblProductosDiferencias.TabIndex = 18;
            this.LogisticaLblProductosDiferencias.Text = "0";
            // 
            // LogisticaDgvDetalleCierre
            // 
            this.LogisticaDgvDetalleCierre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogisticaDgvDetalleCierre.Location = new System.Drawing.Point(113, 457);
            this.LogisticaDgvDetalleCierre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogisticaDgvDetalleCierre.Name = "LogisticaDgvDetalleCierre";
            this.LogisticaDgvDetalleCierre.RowHeadersWidth = 51;
            this.LogisticaDgvDetalleCierre.RowTemplate.Height = 24;
            this.LogisticaDgvDetalleCierre.Size = new System.Drawing.Size(829, 230);
            this.LogisticaDgvDetalleCierre.TabIndex = 13;
            // 
            // LogisticaLblMovimientoMes
            // 
            this.LogisticaLblMovimientoMes.AutoSize = true;
            this.LogisticaLblMovimientoMes.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblMovimientoMes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogisticaLblMovimientoMes.Location = new System.Drawing.Point(709, 353);
            this.LogisticaLblMovimientoMes.Name = "LogisticaLblMovimientoMes";
            this.LogisticaLblMovimientoMes.Size = new System.Drawing.Size(23, 28);
            this.LogisticaLblMovimientoMes.TabIndex = 17;
            this.LogisticaLblMovimientoMes.Text = "0";
            // 
            // LogisticaLblDatosCierre
            // 
            this.LogisticaLblDatosCierre.AutoSize = true;
            this.LogisticaLblDatosCierre.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblDatosCierre.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogisticaLblDatosCierre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.LogisticaLblDatosCierre.Location = new System.Drawing.Point(111, 98);
            this.LogisticaLblDatosCierre.Name = "LogisticaLblDatosCierre";
            this.LogisticaLblDatosCierre.Size = new System.Drawing.Size(276, 30);
            this.LogisticaLblDatosCierre.TabIndex = 2;
            this.LogisticaLblDatosCierre.Text = "Datos generales de cierre";
            // 
            // LogisticaLblBodegasIncluidas
            // 
            this.LogisticaLblBodegasIncluidas.AutoSize = true;
            this.LogisticaLblBodegasIncluidas.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblBodegasIncluidas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogisticaLblBodegasIncluidas.Location = new System.Drawing.Point(953, 247);
            this.LogisticaLblBodegasIncluidas.Name = "LogisticaLblBodegasIncluidas";
            this.LogisticaLblBodegasIncluidas.Size = new System.Drawing.Size(23, 28);
            this.LogisticaLblBodegasIncluidas.TabIndex = 16;
            this.LogisticaLblBodegasIncluidas.Text = "0";
            // 
            // LogisticaLblMesCierre
            // 
            this.LogisticaLblMesCierre.AutoSize = true;
            this.LogisticaLblMesCierre.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblMesCierre.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.LogisticaLblMesCierre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.LogisticaLblMesCierre.Location = new System.Drawing.Point(124, 266);
            this.LogisticaLblMesCierre.Name = "LogisticaLblMesCierre";
            this.LogisticaLblMesCierre.Size = new System.Drawing.Size(112, 23);
            this.LogisticaLblMesCierre.TabIndex = 4;
            this.LogisticaLblMesCierre.Text = "Mes de cierre";
            // 
            // LogisticaLblProductosRegistrados
            // 
            this.LogisticaLblProductosRegistrados.AutoSize = true;
            this.LogisticaLblProductosRegistrados.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblProductosRegistrados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogisticaLblProductosRegistrados.Location = new System.Drawing.Point(709, 247);
            this.LogisticaLblProductosRegistrados.Name = "LogisticaLblProductosRegistrados";
            this.LogisticaLblProductosRegistrados.Size = new System.Drawing.Size(23, 28);
            this.LogisticaLblProductosRegistrados.TabIndex = 15;
            this.LogisticaLblProductosRegistrados.Text = "0";
            // 
            // LogisticaLblSucursal
            // 
            this.LogisticaLblSucursal.AutoSize = true;
            this.LogisticaLblSucursal.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblSucursal.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.LogisticaLblSucursal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.LogisticaLblSucursal.Location = new System.Drawing.Point(125, 158);
            this.LogisticaLblSucursal.Name = "LogisticaLblSucursal";
            this.LogisticaLblSucursal.Size = new System.Drawing.Size(73, 23);
            this.LogisticaLblSucursal.TabIndex = 3;
            this.LogisticaLblSucursal.Text = "Sucursal";
            // 
            // LogisticaLblAñoCierre
            // 
            this.LogisticaLblAñoCierre.AutoSize = true;
            this.LogisticaLblAñoCierre.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblAñoCierre.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.LogisticaLblAñoCierre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.LogisticaLblAñoCierre.Location = new System.Drawing.Point(392, 266);
            this.LogisticaLblAñoCierre.Name = "LogisticaLblAñoCierre";
            this.LogisticaLblAñoCierre.Size = new System.Drawing.Size(41, 23);
            this.LogisticaLblAñoCierre.TabIndex = 7;
            this.LogisticaLblAñoCierre.Text = "Año";
            // 
            // LogisticaLblResumenInventario
            // 
            this.LogisticaLblResumenInventario.AutoSize = true;
            this.LogisticaLblResumenInventario.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblResumenInventario.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogisticaLblResumenInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.LogisticaLblResumenInventario.Location = new System.Drawing.Point(708, 129);
            this.LogisticaLblResumenInventario.Name = "LogisticaLblResumenInventario";
            this.LogisticaLblResumenInventario.Size = new System.Drawing.Size(255, 30);
            this.LogisticaLblResumenInventario.TabIndex = 8;
            this.LogisticaLblResumenInventario.Text = "Resumen del inventario";
            // 
            // LogisticaLblTituloCierreInventario
            // 
            this.LogisticaLblTituloCierreInventario.AutoSize = true;
            this.LogisticaLblTituloCierreInventario.BackColor = System.Drawing.Color.Transparent;
            this.LogisticaLblTituloCierreInventario.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold);
            this.LogisticaLblTituloCierreInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.LogisticaLblTituloCierreInventario.Location = new System.Drawing.Point(37, 22);
            this.LogisticaLblTituloCierreInventario.Name = "LogisticaLblTituloCierreInventario";
            this.LogisticaLblTituloCierreInventario.Size = new System.Drawing.Size(368, 50);
            this.LogisticaLblTituloCierreInventario.TabIndex = 0;
            this.LogisticaLblTituloCierreInventario.Text = "Cierre de Inventario";
            // 
            // FrmCierreInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 734);
            this.Controls.Add(this.LogisticaCboAñoCierre);
            this.Controls.Add(this.LogisticaCboMesCierre);
            this.Controls.Add(this.LogisticaCboSucursal);
            this.Controls.Add(this.LogisticaPnlCierreInventario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FrmCierreInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "5020 - Cierre de Inventario";
            this.LogisticaPnlCierreInventario.ResumeLayout(false);
            this.LogisticaPnlCierreInventario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogisticaDgvDetalleCierre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LogisticaLblTituloCierreInventario;
        private System.Windows.Forms.ComboBox LogisticaCboSucursal;
        private System.Windows.Forms.Label LogisticaLblDatosCierre;
        private System.Windows.Forms.Label LogisticaLblSucursal;
        private System.Windows.Forms.Label LogisticaLblMesCierre;
        private System.Windows.Forms.ComboBox LogisticaCboMesCierre;
        private System.Windows.Forms.ComboBox LogisticaCboAñoCierre;
        private System.Windows.Forms.Label LogisticaLblAñoCierre;
        private System.Windows.Forms.Label LogisticaLblResumenInventario;
        private System.Windows.Forms.Label LogisticaLblTextoProductosRegistrados;
        private System.Windows.Forms.Label LogisticaLblTextoBodegasIncluidas;
        private System.Windows.Forms.Label LogisticaLblTextoMovimientoMes;
        private System.Windows.Forms.Label LogisticaLblTextoProductosDiferencias;
        private System.Windows.Forms.DataGridView LogisticaDgvDetalleCierre;
        private System.Windows.Forms.Label LogisticaLblDetalleInventario;
        private System.Windows.Forms.Label LogisticaLblProductosRegistrados;
        private System.Windows.Forms.Label LogisticaLblBodegasIncluidas;
        private System.Windows.Forms.Label LogisticaLblMovimientoMes;
        private System.Windows.Forms.Label LogisticaLblProductosDiferencias;
        private System.Windows.Forms.Button LogisticaBtnValidarPeriodo;
        private System.Windows.Forms.Button LogisticaBtnLimpiar;
        private System.Windows.Forms.Button LogisticaBtnConsultarCierre;
        private System.Windows.Forms.Button LogisticaBtnConfirmarCierre;
        private System.Windows.Forms.Panel LogisticaPnlCierreInventario;
    }
}