using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CapaVista_BtnImprimir_Reporteador.Formas
{
    public partial class FrmVerReporte : Form
    {
        private readonly string _RutaReporte;

        public FrmVerReporte(
            string RutaReporte)
        {
            InitializeComponent();

            _RutaReporte =
                RutaReporte;
        }

        private void FrmVerReporte_Load(
            object Sender,
            EventArgs E)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(
                    _RutaReporte))
                {
                    throw new Exception(
                        "No se proporcionó la ruta del reporte.");
                }

                if (!File.Exists(
                    _RutaReporte))
                {
                    throw new FileNotFoundException(
                        "No se encontró el archivo RDLC.",
                        _RutaReporte);
                }

                if (!Path.GetExtension(
                    _RutaReporte).Equals(
                        ".rdlc",
                        StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception(
                        "El archivo seleccionado no es un RDLC.");
                }

                ReporteadorRvwreporte.Reset();

                ReporteadorRvwreporte.ProcessingMode =
                    ProcessingMode.Local;

                ReporteadorRvwreporte.LocalReport.ReportPath =
                    _RutaReporte;

                ReporteadorRvwreporte.RefreshReport();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(
                    "No se pudo mostrar el reporte."
                    + Environment.NewLine
                    + Environment.NewLine
                    + Ex.Message,
                    "Reporteador",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}