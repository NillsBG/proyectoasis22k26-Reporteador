using CapaControlador_Reporteador;
using System;
using System.IO;
using System.Windows.Forms;

namespace CapaVista_Reporteador
{
    public partial class FrmReportes : Form
    {
        private ClsModeloReporteador modeloReporteador;

        private bool modoEdicion = false;
        private int numeroReporteEdicion = 0;

        public FrmReportes()
        {
            InitializeComponent();

            modeloReporteador = new ClsModeloReporteador();

            // NOMBRE DEL REPORTE (1) - NUNCA BLOQUEADO, EDITABLE
            ReporteadorTxtNombreReporte.Enabled = true;
            ReporteadorTxtNombreReporte.ReadOnly = false;
            ReporteadorTxtNombreReporte.TabStop = true;

            // NOMBRE DEL REPORTE (2) - NUNCA BLOQUEADO, EDITABLE
            ReporteadorTxtNombreReporte2.Enabled = true;
            ReporteadorTxtNombreReporte2.ReadOnly = false;
            ReporteadorTxtNombreReporte2.TabStop = true;

            // RUTA DEL REPORTE - BLOQUEADA PARA ESCRITURA MANUAL
            ReporteadorTxtRutaReporte.Enabled = true;
            ReporteadorTxtRutaReporte.ReadOnly = true;
            ReporteadorTxtRutaReporte.TabStop = false;

            // CONECTAR BOTON DE RUTA
            if (BtnRutaReporteador != null)
            {
                BtnRutaReporteador.CampoTextoRuta = ReporteadorTxtRutaReporte;
            }

            ReporteadorDgvReportes.SelectionChanged += ReporteadorDgvReportes_SelectionChanged;

            if (BtnBusquedaReporteador != null)
            {
                BtnBusquedaReporteador.TxtNombreReporte = ReporteadorTxtNombreReporte2;
                BtnBusquedaReporteador.DtpFechaReporte = ReporteadorDtpFechaReporte;
                BtnBusquedaReporteador.ChkNombreReporte = ReporteadorChkNombreReporte;
                BtnBusquedaReporteador.ChkFechaReporte = ReporteadorChkFechaReporte;
                BtnBusquedaReporteador.DgvReportes = ReporteadorDgvReportes;
            }

            if (BtnActualizarReporteador != null)
            {
                BtnActualizarReporteador.DgvReportes = ReporteadorDgvReportes;
            }

            if (BtnLimpiarReporteador != null)
            {
                BtnLimpiarReporteador.Click += BtnLimpiar_Click;
            }

            if (BtnImprimirReporteador != null)
            {
                BtnImprimirReporteador.RutaReporte = null;
            }

            Load += FrmReportes_Load;
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            try
            {
                ReporteadorTxtNombreReporte.Enabled = true;
                ReporteadorTxtNombreReporte.ReadOnly = false;
                ReporteadorTxtNombreReporte.TabStop = true;

                ReporteadorTxtNombreReporte2.Enabled = true;
                ReporteadorTxtNombreReporte2.ReadOnly = false;
                ReporteadorTxtNombreReporte2.TabStop = true;

                ReporteadorTxtRutaReporte.Enabled = true;
                ReporteadorTxtRutaReporte.ReadOnly = true;
                ReporteadorTxtRutaReporte.TabStop = false;

                if (BtnRutaReporteador != null)
                {
                    BtnRutaReporteador.CampoTextoRuta = ReporteadorTxtRutaReporte;
                }

                CargarTabla();

                modoEdicion = false;
                numeroReporteEdicion = 0;

                PrepararNuevoRegistro();

                ReporteadorTxtNombreReporte.Focus();
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo cargar el formulario.\n\n" + ex.Message);
            }
        }

        private void BtnGuardarReporteador_Click(object sender, EventArgs e)
        {
            GuardarReporte();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ReporteadorDgvReportes.CurrentRow == null)
                {
                    MostrarError("Debe seleccionar un reporte para editar.");
                    return;
                }

                object numero = ReporteadorDgvReportes.CurrentRow.Cells["NumeroReporte"].Value;
                object nombre = ReporteadorDgvReportes.CurrentRow.Cells["NombreReporte"].Value;
                object ruta = ReporteadorDgvReportes.CurrentRow.Cells["RutaReporte"].Value;
                object fecha = ReporteadorDgvReportes.CurrentRow.Cells["FechaReporte"].Value;

                if (numero == null || numero == DBNull.Value)
                {
                    MostrarError("No se pudo obtener el número del reporte.");
                    return;
                }

                numeroReporteEdicion = Convert.ToInt32(numero);

                ReporteadorTxtNombreReporte.Text = nombre == null || nombre == DBNull.Value ? "" : nombre.ToString();
                ReporteadorTxtRutaReporte.Text = ruta == null || ruta == DBNull.Value ? "" : ruta.ToString();

                ReporteadorTxtNombreReporte.Enabled = true;
                ReporteadorTxtNombreReporte.ReadOnly = false;
                ReporteadorTxtNombreReporte.TabStop = true;

                ReporteadorTxtNombreReporte2.Enabled = true;
                ReporteadorTxtNombreReporte2.ReadOnly = false;
                ReporteadorTxtNombreReporte2.TabStop = true;

                ReporteadorTxtRutaReporte.Enabled = true;
                ReporteadorTxtRutaReporte.ReadOnly = true;
                ReporteadorTxtRutaReporte.TabStop = false;

                modeloReporteador = new ClsModeloReporteador();
                modeloReporteador.Estado = ClsEstadoEntidad.Modified;
                modeloReporteador.NumeroReporte = numeroReporteEdicion;

                if (fecha != null && fecha != DBNull.Value)
                {
                    modeloReporteador.FechaReporte = Convert.ToDateTime(fecha);
                }
                else
                {
                    modeloReporteador.FechaReporte = DateTime.Now.Date;
                }

                if (ReporteadorDtpFechaReporte != null)
                {
                    ReporteadorDtpFechaReporte.Value = modeloReporteador.FechaReporte;
                }

                modoEdicion = true;
                ReporteadorTxtNombreReporte.Focus();
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo preparar el reporte para editar.\n\n" + ex.Message);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                ReporteadorTxtRutaReporte.Clear();
                ReporteadorTxtNombreReporte.Clear();
                ReporteadorTxtNombreReporte2.Clear();

                ReporteadorDtpFechaReporte.Value = DateTime.Now;

                if (ReporteadorChkNombreReporte != null)
                {
                    ReporteadorChkNombreReporte.Checked = false;
                }

                if (ReporteadorChkFechaReporte != null)
                {
                    ReporteadorChkFechaReporte.Checked = false;
                }

                modoEdicion = false;
                numeroReporteEdicion = 0;

                modeloReporteador = new ClsModeloReporteador();

                PrepararNuevoRegistro();
                CargarTabla();

                if (BtnImprimirReporteador != null)
                {
                    BtnImprimirReporteador.RutaReporte = null;
                }

                ReporteadorTxtNombreReporte.Enabled = true;
                ReporteadorTxtNombreReporte.ReadOnly = false;
                ReporteadorTxtNombreReporte.TabStop = true;

                ReporteadorTxtNombreReporte2.Enabled = true;
                ReporteadorTxtNombreReporte2.ReadOnly = false;
                ReporteadorTxtNombreReporte2.TabStop = true;

                ReporteadorTxtRutaReporte.Enabled = true;
                ReporteadorTxtRutaReporte.ReadOnly = true;
                ReporteadorTxtRutaReporte.TabStop = false;

                if (BtnRutaReporteador != null)
                {
                    BtnRutaReporteador.CampoTextoRuta = ReporteadorTxtRutaReporte;
                }

                ReporteadorTxtNombreReporte.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Limpiar formulario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GuardarReporte()
        {
            try
            {
                string nombre = ReporteadorTxtNombreReporte.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MostrarError("Debe ingresar el nombre del reporte.");
                    ReporteadorTxtNombreReporte.Focus();
                    return;
                }

                string ruta = ReporteadorTxtRutaReporte.Text.Trim();

                if (string.IsNullOrWhiteSpace(ruta))
                {
                    MostrarError("Debe seleccionar el archivo PDF del reporte.");
                    return;
                }

                if (!ruta.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    MostrarError("El archivo seleccionado debe ser un PDF.");
                    return;
                }

                if (!File.Exists(ruta))
                {
                    MostrarError("El archivo seleccionado no existe.\n\nSeleccione nuevamente el PDF.");
                    return;
                }

                if (modeloReporteador == null)
                {
                    modeloReporteador = new ClsModeloReporteador();
                }

                if (modoEdicion)
                {
                    modeloReporteador.Estado = ClsEstadoEntidad.Modified;
                    modeloReporteador.NumeroReporte = numeroReporteEdicion;
                }
                else
                {
                    modeloReporteador.Estado = ClsEstadoEntidad.Added;

                    // Asignación automática comenzando desde 3001, recalculada aquí
                    // mismo justo antes de guardar para GARANTIZAR que nunca quede en 0
                    // (evita el error "Debe ingresar el número de reporte" del modelo).
                    modeloReporteador.NumeroReporte = ObtenerSiguienteNumeroReporte();
                }

                modeloReporteador.NombreReporte = nombre;
                modeloReporteador.RutaReporte = ruta;

                if (ReporteadorDtpFechaReporte != null)
                {
                    modeloReporteador.FechaReporte = ReporteadorDtpFechaReporte.Value.Date;
                }
                else
                {
                    modeloReporteador.FechaReporte = DateTime.Now.Date;
                }

                // Verificación de seguridad adicional: si por cualquier motivo
                // el número sigue en 0, se asigna aquí antes de llamar a GrabarCambios.
                if (modeloReporteador.NumeroReporte <= 0)
                {
                    modeloReporteador.NumeroReporte = ObtenerSiguienteNumeroReporte();
                }

                string resultado = modeloReporteador.GrabarCambios();

                if (resultado == "Grabación exitosa" || resultado == "Actualización exitosa")
                {
                    if (modoEdicion)
                    {
                        MostrarExito("Actualización exitosa");
                    }
                    else
                    {
                        MostrarExito("Grabación exitosa");
                    }

                    modoEdicion = false;
                    numeroReporteEdicion = 0;

                    LimpiarFormulario();

                    modeloReporteador = new ClsModeloReporteador();
                    PrepararNuevoRegistro();
                    CargarTabla();

                    ReporteadorDgvReportes.Refresh();
                    return;
                }

                MostrarError("No se pudo guardar el reporte.\n\n" + resultado);
            }
            catch (Exception ex)
            {
                MostrarError("Ocurrió un error al guardar el reporte.\n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Calcula el siguiente número de reporte disponible, comenzando en 3001,
        /// en base al máximo actual presente en la tabla cargada en pantalla.
        /// </summary>
        private int ObtenerSiguienteNumeroReporte()
        {
            int nuevoNumero = 3001;

            if (ReporteadorDgvReportes != null && ReporteadorDgvReportes.Rows.Count > 0)
            {
                int maxId = 3000;
                foreach (DataGridViewRow row in ReporteadorDgvReportes.Rows)
                {
                    if (row.Cells["NumeroReporte"].Value != null && int.TryParse(row.Cells["NumeroReporte"].Value.ToString(), out int id))
                    {
                        if (id > maxId)
                        {
                            maxId = id;
                        }
                    }
                }
                nuevoNumero = maxId + 1;
            }

            return nuevoNumero;
        }

        private void PrepararNuevoRegistro()
        {
            try
            {
                if (modeloReporteador == null)
                {
                    modeloReporteador = new ClsModeloReporteador();
                }

                modeloReporteador.Estado = ClsEstadoEntidad.Added;
                modeloReporteador.NumeroReporte = ObtenerSiguienteNumeroReporte();
                modeloReporteador.FechaReporte = DateTime.Now.Date;

                if (ReporteadorDtpFechaReporte != null)
                {
                    ReporteadorDtpFechaReporte.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo generar el número del reporte.\n\n" + ex.Message);
            }
        }

        public void CargarTabla()
        {
            try
            {
                if (modeloReporteador == null)
                {
                    modeloReporteador = new ClsModeloReporteador();
                }

                var lista = modeloReporteador.GetAll();

                ReporteadorDgvReportes.DataSource = null;
                ReporteadorDgvReportes.Columns.Clear();
                ReporteadorDgvReportes.AutoGenerateColumns = false;

                DataGridViewTextBoxColumn colNumero = new DataGridViewTextBoxColumn();
                colNumero.Name = "NumeroReporte";
                colNumero.HeaderText = "NumeroReporte";
                colNumero.DataPropertyName = "NumeroReporte";
                colNumero.Width = 100;
                ReporteadorDgvReportes.Columns.Add(colNumero);

                DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
                colNombre.Name = "NombreReporte";
                colNombre.HeaderText = "NombreReporte";
                colNombre.DataPropertyName = "NombreReporte";
                colNombre.Width = 180;
                ReporteadorDgvReportes.Columns.Add(colNombre);

                DataGridViewTextBoxColumn colRuta = new DataGridViewTextBoxColumn();
                colRuta.Name = "RutaReporte";
                colRuta.HeaderText = "RutaReporte";
                colRuta.DataPropertyName = "RutaReporte";
                colRuta.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ReporteadorDgvReportes.Columns.Add(colRuta);

                DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn();
                colFecha.Name = "FechaReporte";
                colFecha.HeaderText = "FechaReporte";
                colFecha.DataPropertyName = "FechaReporte";
                colFecha.Width = 100;
                colFecha.DefaultCellStyle.Format = "dd/MM/yyyy";
                ReporteadorDgvReportes.Columns.Add(colFecha);

                ReporteadorDgvReportes.DataSource = lista;
                ReporteadorDgvReportes.Refresh();
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo cargar la lista de reportes.\n\n" + ex.Message);
            }
        }

        private void ReporteadorDgvReportes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (BtnImprimirReporteador == null)
                {
                    return;
                }

                if (ReporteadorDgvReportes.CurrentRow == null)
                {
                    BtnImprimirReporteador.RutaReporte = null;
                    return;
                }

                object ruta = ReporteadorDgvReportes.CurrentRow.Cells["RutaReporte"].Value;

                if (ruta == null || ruta == DBNull.Value)
                {
                    BtnImprimirReporteador.RutaReporte = null;
                    return;
                }

                BtnImprimirReporteador.RutaReporte = ruta.ToString();
            }
            catch
            {
                if (BtnImprimirReporteador != null)
                {
                    BtnImprimirReporteador.RutaReporte = null;
                }
            }
        }

        private void LimpiarFormulario()
        {
            ReporteadorTxtNombreReporte.Clear();
            ReporteadorTxtRutaReporte.Clear();
            ReporteadorTxtNombreReporte2.Clear();

            if (ReporteadorDtpFechaReporte != null)
            {
                ReporteadorDtpFechaReporte.Value = DateTime.Now;
            }

            if (ReporteadorChkNombreReporte != null)
            {
                ReporteadorChkNombreReporte.Checked = false;
            }

            if (ReporteadorChkFechaReporte != null)
            {
                ReporteadorChkFechaReporte.Checked = false;
            }

            if (BtnImprimirReporteador != null)
            {
                BtnImprimirReporteador.RutaReporte = null;
            }

            ReporteadorTxtNombreReporte.Enabled = true;
            ReporteadorTxtNombreReporte.ReadOnly = false;
            ReporteadorTxtNombreReporte.TabStop = true;

            ReporteadorTxtNombreReporte2.Enabled = true;
            ReporteadorTxtNombreReporte2.ReadOnly = false;
            ReporteadorTxtNombreReporte2.TabStop = true;

            ReporteadorTxtRutaReporte.Enabled = true;
            ReporteadorTxtRutaReporte.ReadOnly = true;
            ReporteadorTxtRutaReporte.TabStop = false;

            ReporteadorTxtNombreReporte.Focus();
        }

        private void MostrarExito(string mensaje)
        {
            using (Form frmExito = new Form())
            {
                frmExito.Text = "Operación exitosa";
                frmExito.StartPosition = FormStartPosition.CenterParent;
                frmExito.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmExito.MaximizeBox = false;
                frmExito.MinimizeBox = false;
                frmExito.ShowInTaskbar = false;
                frmExito.ClientSize = new System.Drawing.Size(430, 180);

                Panel circulo = new Panel();
                circulo.Size = new System.Drawing.Size(52, 52);
                circulo.Location = new System.Drawing.Point(25, 45);
                circulo.BackColor = System.Drawing.Color.ForestGreen;

                circulo.Paint += (sender, e) =>
                {
                    using (System.Drawing.SolidBrush pincel = new System.Drawing.SolidBrush(System.Drawing.Color.White))
                    {
                        e.Graphics.FillEllipse(pincel, 14, 14, 24, 24);
                    }

                    using (System.Drawing.Pen lapiz = new System.Drawing.Pen(System.Drawing.Color.ForestGreen, 3))
                    {
                        e.Graphics.DrawLine(lapiz, 19, 26, 24, 31);
                        e.Graphics.DrawLine(lapiz, 24, 31, 35, 20);
                    }
                };

                frmExito.Controls.Add(circulo);

                Label lblMensaje = new Label();
                lblMensaje.AutoSize = false;
                lblMensaje.Location = new System.Drawing.Point(95, 40);
                lblMensaje.Size = new System.Drawing.Size(300, 55);
                lblMensaje.Text = mensaje;
                lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
                lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                frmExito.Controls.Add(lblMensaje);

                Button btnAceptar = new Button();
                btnAceptar.Text = "Aceptar";
                btnAceptar.Size = new System.Drawing.Size(90, 32);
                btnAceptar.Location = new System.Drawing.Point(320, 120);
                btnAceptar.DialogResult = DialogResult.OK;

                frmExito.Controls.Add(btnAceptar);
                frmExito.AcceptButton = btnAceptar;

                frmExito.ShowDialog(this);
            }
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool MostrarConfirmacion(string mensaje)
        {
            DialogResult resultado = MessageBox.Show(
                mensaje,
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            return resultado == DialogResult.Yes;
        }
    }
}