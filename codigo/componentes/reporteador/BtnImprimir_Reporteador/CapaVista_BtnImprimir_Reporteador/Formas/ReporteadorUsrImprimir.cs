using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using CapaControlador_BtnImprimir_Reporteador;

namespace CapaVista_BtnImprimir_Reporteador
{
    [ToolboxItem(true)]
    [Description(
        "Botón reutilizable para visualizar e imprimir reportes RDLC.")]
    public partial class ReporteadorUsrImprimir
        : UserControl
    {
        private Button ReporteadorBtnImprimir;

        private readonly ClsControladorBtnImprimir
            _Controlador;

        public string RutaReporte
        {
            get;
            set;
        }

        public ReporteadorUsrImprimir()
        {
            InitializeComponent();

            _Controlador =
                new ClsControladorBtnImprimir();

            RutaReporte =
                string.Empty;

            ReporteadorBtnImprimir.Click +=
                BtnAccionImprimir_Click;
        }

        private void BtnAccionImprimir_Click(
            object Sender,
            EventArgs E)
        {
            ReporteadorMetEjecutarImpresion();
        }

        private void ReporteadorMetEjecutarImpresion()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(
                    RutaReporte))
                {
                    MessageBox.Show(
                        "Debe seleccionar un reporte para imprimir.",
                        "Imprimir reporte",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                RutaReporte =
                    RutaReporte.Trim();

                if (!File.Exists(
                    RutaReporte))
                {
                    MessageBox.Show(
                        "El archivo del reporte no existe."
                        + Environment.NewLine
                        + Environment.NewLine
                        + RutaReporte,
                        "Imprimir reporte",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!Path.GetExtension(
                        RutaReporte)
                    .Equals(
                        ".rdlc",
                        StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "El archivo seleccionado no es un reporte .rdlc.",
                        "Imprimir reporte",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string CarpetaPDF =
                    Path.Combine(
                        Path.GetTempPath(),
                        "Reporteador");

                Directory.CreateDirectory(
                    CarpetaPDF);

                string NombrePDF =
                    Path.GetFileNameWithoutExtension(
                        RutaReporte)
                    + "_"
                    + DateTime.Now.ToString(
                        "yyyyMMdd_HHmmss")
                    + ".pdf";

                string RutaPDF =
                    Path.Combine(
                        CarpetaPDF,
                        NombrePDF);

                bool Resultado =
                    _Controlador
                        .ReporteadorMetGenerarPDF(
                            RutaReporte,
                            RutaPDF,
                            out string Mensaje);

                if (!Resultado)
                {
                    MessageBox.Show(
                        Mensaje,
                        "Imprimir reporte",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!File.Exists(
                    RutaPDF))
                {
                    throw new Exception(
                        "No se pudo crear el archivo PDF.");
                }

                FileInfo InformacionPDF =
                    new FileInfo(
                        RutaPDF);

                if (InformacionPDF.Length == 0)
                {
                    throw new Exception(
                        "El archivo PDF generado está vacío.");
                }

                ProcessStartInfo Informacion =
                    new ProcessStartInfo();

                Informacion.FileName =
                    RutaPDF;

                Informacion.UseShellExecute =
                    true;

                Process.Start(
                    Informacion);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(
                    "No se pudo imprimir el reporte."
                    + Environment.NewLine
                    + Environment.NewLine
                    + Ex.Message,
                    "Imprimir reporte",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.ReporteadorBtnImprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReporteadorBtnImprimir
            // 
            this.ReporteadorBtnImprimir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReporteadorBtnImprimir.FlatAppearance.BorderSize = 0;
            this.ReporteadorBtnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReporteadorBtnImprimir.Image = global::CapaVista_BtnImprimir_Reporteador.Properties.Resources.btn_imprimir;
            this.ReporteadorBtnImprimir.Location = new System.Drawing.Point(0, 0);
            this.ReporteadorBtnImprimir.Name = "ReporteadorBtnImprimir";
            this.ReporteadorBtnImprimir.Size = new System.Drawing.Size(56, 56);
            this.ReporteadorBtnImprimir.TabIndex = 0;
            this.ReporteadorBtnImprimir.UseVisualStyleBackColor = true;
            // 
            // ReporteadorUsrImprimir
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ReporteadorBtnImprimir);
            this.Name = "ReporteadorUsrImprimir";
            this.Size = new System.Drawing.Size(56, 56);
            this.ResumeLayout(false);

        }

        
    }
}