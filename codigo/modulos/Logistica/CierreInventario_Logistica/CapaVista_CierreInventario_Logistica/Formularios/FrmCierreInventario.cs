/* ============================================================================
 * MÓDULO: LOGÍSTICA | FORMULARIO: FrmCierreInventario
 * DESCRIPCIÓN: Validación y ejecución de cierre mensual mediante MVC.
 * RESPONSABLE: Nills Berducido Gómez
 * ============================================================================ */
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using CapaControlador_CierreInventario_Logistica;
using CapaModelo_CierreInventario_Logistica.Entidad;

namespace CapaVista_CierreInventario_Logistica.Formularios
{
    public partial class FrmCierreInventario : Form
    {
        private readonly ClsControladorCierreInventario controlador = new ClsControladorCierreInventario();
        private bool periodoValidado;

        public FrmCierreInventario()
        {
            InitializeComponent();
            Load += FrmCierreInventario_Load;
            LogisticaBtnValidarPeriodo.Click += LogisticaBtnValidarPeriodo_Click;
            LogisticaBtnConfirmarCierre.Click += LogisticaBtnConfirmarCierre_Click;
            LogisticaBtnLimpiar.Click += LogisticaBtnLimpiar_Click;
            LogisticaCboSucursal.SelectedIndexChanged += Seleccion_Modificada;
            LogisticaCboMesCierre.SelectedIndexChanged += Seleccion_Modificada;
            LogisticaCboAñoCierre.SelectedIndexChanged += Seleccion_Modificada;
            LogisticaBtnConfirmarCierre.Enabled = false;
        }

        private void FrmCierreInventario_Load(object sender, EventArgs e)
        {
            try
            {
                LogisticaCboSucursal.DropDownStyle = ComboBoxStyle.DropDownList;
                LogisticaCboMesCierre.DropDownStyle = ComboBoxStyle.DropDownList;
                LogisticaCboAñoCierre.DropDownStyle = ComboBoxStyle.DropDownList;
                LogisticaCboSucursal.DisplayMember = "nombreSucursal";
                LogisticaCboSucursal.ValueMember = "idSucursal";
                LogisticaCboSucursal.DataSource = controlador.ObtenerSucursales();
                LogisticaCboMesCierre.Items.Clear();
                for (int mes = 1; mes <= 12; mes++)
                    LogisticaCboMesCierre.Items.Add(new CultureInfo("es-GT").DateTimeFormat.GetMonthName(mes));
                LogisticaCboAñoCierre.Items.Clear();
                for (int anio = DateTime.Today.Year - 5; anio <= DateTime.Today.Year; anio++)
                    LogisticaCboAñoCierre.Items.Add(anio);
                LogisticaCboMesCierre.SelectedIndex = DateTime.Today.Month - 1;
                LogisticaCboAñoCierre.SelectedItem = DateTime.Today.Year;
                LogisticaDgvDetalleCierre.ReadOnly = true;
                LogisticaDgvDetalleCierre.AllowUserToAddRows = false;
                LogisticaDgvDetalleCierre.AllowUserToDeleteRows = false;
                LogisticaDgvDetalleCierre.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                LogisticaDgvDetalleCierre.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                ReiniciarResultados();
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        private void Seleccion_Modificada(object sender, EventArgs e) { ReiniciarResultados(); }

        private void ReiniciarResultados()
        {
            periodoValidado = false;
            LogisticaBtnConfirmarCierre.Enabled = false;
            LogisticaDgvDetalleCierre.DataSource = null;
            LogisticaLblProductosRegistrados.Text = "0";
            LogisticaLblBodegasIncluidas.Text = "0";
            LogisticaLblMovimientoMes.Text = "0";
            LogisticaLblProductosDiferencias.Text = "0";
        }

        private bool SeleccionValida(out int sucursal, out int anio, out int mes)
        {
            sucursal = 0; anio = 0; mes = 0;
            if (LogisticaCboSucursal.SelectedValue == null ||
                LogisticaCboSucursal.SelectedValue is DataRowView ||
                LogisticaCboMesCierre.SelectedIndex < 0 || LogisticaCboAñoCierre.SelectedItem == null)
            { MessageBox.Show("Seleccione sucursal, mes y año."); return false; }
            sucursal = Convert.ToInt32(LogisticaCboSucursal.SelectedValue);
            mes = LogisticaCboMesCierre.SelectedIndex + 1;
            anio = Convert.ToInt32(LogisticaCboAñoCierre.SelectedItem);
            return true;
        }

        private void LogisticaBtnValidarPeriodo_Click(object sender, EventArgs e)
        {
            int sucursal, anio, mes;
            if (!SeleccionValida(out sucursal, out anio, out mes)) return;
            ReiniciarResultados();
            try
            {
                ResultadoCierre resultado = controlador.ValidarPeriodo(sucursal, anio, mes);
                LogisticaDgvDetalleCierre.DataSource = resultado.Detalle;
                if (LogisticaDgvDetalleCierre.Columns.Contains("idStock"))
                    LogisticaDgvDetalleCierre.Columns["idStock"].Visible = false;
                if (LogisticaDgvDetalleCierre.Columns.Contains("IdBodega"))
                    LogisticaDgvDetalleCierre.Columns["IdBodega"].Visible = false;
                if (LogisticaDgvDetalleCierre.Columns.Contains("IdProducto"))
                    LogisticaDgvDetalleCierre.Columns["IdProducto"].Visible = false;
                LogisticaLblProductosRegistrados.Text = resultado.Productos.ToString();
                LogisticaLblBodegasIncluidas.Text = resultado.Bodegas.ToString();
                LogisticaLblMovimientoMes.Text = resultado.Movimientos.ToString();
                LogisticaLblProductosDiferencias.Text = resultado.Diferencias.ToString();
                periodoValidado = resultado.PuedeCerrar;
                LogisticaBtnConfirmarCierre.Enabled = periodoValidado;
                MessageBox.Show(resultado.PuedeCerrar
                    ? "El período está cuadrado. Puede confirmar el cierre."
                    : "No se puede cerrar:\n" + resultado.Mensaje,
                    "Validación del cierre", MessageBoxButtons.OK,
                    resultado.PuedeCerrar ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        private void LogisticaBtnConfirmarCierre_Click(object sender, EventArgs e)
        {
            if (!periodoValidado) return;
            int sucursal, anio, mes;
            if (!SeleccionValida(out sucursal, out anio, out mes)) return;
            if (MessageBox.Show("El cierre mensual es DEFINITIVO y no se puede anular.\n¿Desea ejecutarlo?",
                "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
            LogisticaBtnConfirmarCierre.Enabled = false;
            try
            {
                // El modelo vuelve a validar dentro de la transacción antes de escribir.
                int codigo = controlador.ConfirmarCierre(sucursal, anio, mes);
                MessageBox.Show("Cierre ejecutado exitosamente. Código: " + codigo,
                    "Cierre de inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReiniciarResultados();
            }
            catch (Exception ex) { ReiniciarResultados(); MostrarError(ex); }
        }

        private void LogisticaBtnLimpiar_Click(object sender, EventArgs e)
        {
            ReiniciarResultados();
            if (LogisticaCboSucursal.Items.Count > 0) LogisticaCboSucursal.SelectedIndex = 0;
            LogisticaCboMesCierre.SelectedIndex = DateTime.Today.Month - 1;
            LogisticaCboAñoCierre.SelectedItem = DateTime.Today.Year;
        }

        private void LogisticaBtnConsultarCierre_Click_1(object sender, EventArgs e)
        {
            using (FrmConsultaCierres consulta = new FrmConsultaCierres()) consulta.ShowDialog(this);
        }

        private void MostrarError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Cierre de inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
