using System;
using System.Windows.Forms;
using CapaControlador_BtnRuta_Reporteador;

namespace CapaVista_BtnRuta_Reporteador
{
    public partial class BtnRutaReporteador : UserControl
    {
        private readonly ClsControladorBtnRutaReporteador _Controlador;

        public TextBox CampoTextoRuta { get; set; }

        public BtnRutaReporteador()
        {
            InitializeComponent();

            _Controlador =
                new ClsControladorBtnRutaReporteador();

            // Conectar el botón del UserControl
            // directamente al método de selección
            this.BtnRutaReportesReporteador.Click +=
                ReporteadorMetSeleccionarArchivo;
        }

        private void ReporteadorMetSeleccionarArchivo(
            object sender,
            EventArgs e)
        {
            using (OpenFileDialog ReporteadorOfdSeleccionarArchivo =
                new OpenFileDialog())
            {
                ReporteadorOfdSeleccionarArchivo.Title =
                    "Seleccionar reporte en PDF";

                ReporteadorOfdSeleccionarArchivo.Filter =
                    "Archivos PDF (*.pdf)|*.pdf";

                ReporteadorOfdSeleccionarArchivo.CheckFileExists =
                    true;

                ReporteadorOfdSeleccionarArchivo.Multiselect =
                    false;

                if (ReporteadorOfdSeleccionarArchivo.ShowDialog()
                    == DialogResult.OK)
                {
                    string RutaReporte =
                        ReporteadorOfdSeleccionarArchivo.FileName;

                    if (_Controlador.ReporteadorMetValidarRuta(
                        RutaReporte,
                        out string Mensaje))
                    {
                        if (CampoTextoRuta != null)
                        {
                            CampoTextoRuta.Text =
                                RutaReporte;
                        }
                        else
                        {
                            MessageBox.Show(
                                "No se ha asignado el control de texto para la ruta.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            Mensaje,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}