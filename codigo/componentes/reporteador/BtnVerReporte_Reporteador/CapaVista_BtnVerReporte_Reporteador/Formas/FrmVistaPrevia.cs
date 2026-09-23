using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using CapaControlador_BtnVerReporte_Reporteador;

namespace CapaVista_BtnVerReporte_Reporteador
{
    public partial class FrmVistaPrevia : Form
    {
       
        private readonly string _rutaReporte;
        private readonly ClsControladorBtnVerReporte _controlador = new ClsControladorBtnVerReporte();

        public FrmVistaPrevia(string rutaReporte)
        {
            if (string.IsNullOrWhiteSpace(rutaReporte))
                throw new ArgumentException("La ruta del reporte es obligatoria.", nameof(rutaReporte));
            if (!File.Exists(rutaReporte))
                throw new FileNotFoundException("No se encontró el archivo .rdlc.", rutaReporte);
            if (!string.Equals(Path.GetExtension(rutaReporte), ".rdlc", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("El archivo debe tener extensión .rdlc.", nameof(rutaReporte));

            _rutaReporte = rutaReporte;
            InitializeComponent();
        }

        private void FrmVistaPrevia_Load(object Sender, EventArgs E)
        {
            ReporteadorRpvVistaPrevia.ProcessingMode = ProcessingMode.Local;
            ReporteadorRpvVistaPrevia.LocalReport.ReportPath = _rutaReporte;
            ReporteadorRpvVistaPrevia.LocalReport.DataSources.Clear();
            ReporteadorRpvVistaPrevia.LocalReport.DataSources.Add(
                new ReportDataSource("Reporteador", _controlador.GetAll()));
            ReporteadorRpvVistaPrevia.RefreshReport();

        }
    }
}
