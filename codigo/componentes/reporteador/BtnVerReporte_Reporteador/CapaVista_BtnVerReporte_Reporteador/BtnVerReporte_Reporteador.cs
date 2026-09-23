using System;
using System.IO;
using System.Windows.Forms;

namespace CapaVista_BtnVerReporte_Reporteador
{
    public partial class BtnVerReporte_Reporteador : UserControl
    {
        public string RutaReporte { get; set; }

        public TextBox CampoTextoRuta { get; set; }

        public BtnVerReporte_Reporteador()
        {
            InitializeComponent();
            ReporteadorBtnVerReporte.Click += ReporteadorMetVerReporte;
        }

        private void ReporteadorMetVerReporte(object sender, EventArgs e)
        {
            string ruta = CampoTextoRuta?.Text;
            if (string.IsNullOrWhiteSpace(ruta))
            {
                ruta = RutaReporte;
            }

            if (string.IsNullOrWhiteSpace(ruta))
            {
                MessageBox.Show("Debe indicar la ruta del reporte .rdlc.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ruta = ruta.Trim();
            if (!string.Equals(Path.GetExtension(ruta), ".rdlc", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("La ruta debe apuntar a un archivo .rdlc.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(ruta))
            {
                MessageBox.Show("No se encontró el reporte en la ruta indicada.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var vistaPrevia = new FrmVistaPrevia(ruta))
                {
                    vistaPrevia.ShowDialog(FindForm());
                }
            }
            catch (Exception excepcion)
            {
                MessageBox.Show("No fue posible cargar el reporte: " + excepcion.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
