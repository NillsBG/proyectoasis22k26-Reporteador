using CapaControlador_BtnBusqueda_Reporteador;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVista_BtnBusqueda_Reporteador
{
    public partial class BtnBusqueda_Reporteador : UserControl
    {
        private ClsModeloBtnBusquedaReporteador modeloBusqueda;

        public TextBox TxtNombreReporte { get; set; }
        public DateTimePicker DtpFechaReporte { get; set; }
        public CheckBox ChkNombreReporte { get; set; }
        public CheckBox ChkFechaReporte { get; set; }
        public DataGridView DgvReportes { get; set; }

        public BtnBusqueda_Reporteador()
        {
            InitializeComponent();

            modeloBusqueda = new ClsModeloBtnBusquedaReporteador();
            btnAccionBusqueda.Click += BtnAccionBusqueda_Click;
        }

        private void BtnAccionBusqueda_Click(object sender, EventArgs e)
        {
            EjecutarBusqueda();
        }

        public void EjecutarBusqueda()
        {
            try
            {
                string nombreReporte = "";
                DateTime? fechaReporte = null;

                bool buscarPorNombre =
                    ChkNombreReporte != null &&
                    ChkNombreReporte.Checked;

                bool buscarPorFecha =
                    ChkFechaReporte != null &&
                    ChkFechaReporte.Checked;

                if (buscarPorNombre && TxtNombreReporte != null)
                {
                    nombreReporte = TxtNombreReporte.Text.Trim();
                }

                if (buscarPorFecha && DtpFechaReporte != null)
                {
                    fechaReporte = DtpFechaReporte.Value.Date;
                }

                DataTable resultados = modeloBusqueda.BuscarReportes(
                    nombreReporte,
                    fechaReporte,
                    buscarPorNombre,
                    buscarPorFecha
                );

                if (DgvReportes != null)
                {
                    DgvReportes.DataSource = resultados;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron buscar los reportes.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnAccionBusqueda_Click_1(object sender, EventArgs e)
        {

        }
    }
}