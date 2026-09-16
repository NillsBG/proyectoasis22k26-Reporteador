using CapaControlador_Reporteador;
using CapaVista_BtnGuardar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CapaVista_Reporteador
{
    public partial class FrmReportes : Form
    {
        // =========================================================
        // MODELO
        // =========================================================

        private ClsModeloReporteador modeloReporteador;

        // =========================================================
        // VARIABLES PARA BTN EDITAR
        // =========================================================

        private bool modoEdicion = false;
        private int numeroReporteEdicion = 0;


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public FrmReportes()
        {
            InitializeComponent();

            modeloReporteador =
                new ClsModeloReporteador();


            // =====================================================
            // BTN RUTA
            // =====================================================

            if (BtnRuta != null)
            {
                BtnRuta.CampoTextoRuta =
                    ReporteadorTxtRutaReporte;
            }


            // =====================================================
            // BTN GUARDAR
            // =====================================================

            if (BtnGuardar != null)
            {
                BtnGuardar.TxtNombreReporte =
                    ReporteadorTxtNombreReporte;

                BtnGuardar.TxtRutaReporte =
                    ReporteadorTxtRutaReporte;

                BtnGuardar.Click +=
                    BtnGuardar1_Click;
            }


            // =====================================================
            // BTN BUSQUEDA
            // =====================================================

            if (btnBusqueda1 != null)
            {
                btnBusqueda1.TxtNombreReporte =
                    ReporteadorTxtNombreReporte2;

                btnBusqueda1.DtpFechaReporte =
                    ReporteadorDtpFechaReporte;

                btnBusqueda1.ChkNombreReporte =
                    ReporteadorChkNombreReporte;

                btnBusqueda1.ChkFechaReporte =
                    ReporteadorChkFechaReporte;

                btnBusqueda1.DgvReportes =
                    ReporteadorDgvReportes;
            }


            // =====================================================
            // BTN ACTUALIZAR
            // =====================================================

            if (BtnActualizar != null)
            {
                BtnActualizar.DgvReportes =
                    ReporteadorDgvReportes;
            }


            // =====================================================
            // BTN IMPRIMIR
            // =====================================================

            if (BtnImprimir != null)
            {
                BtnImprimir.RutaReporte =
                    null;
            }


            // =====================================================
            // BTN EDITAR
            // =====================================================

            if (BtnEditar != null)
            {
                BtnEditar.Click +=
                    BtnEditar_Click;
            }


            // =====================================================
            // BTN LIMPIAR
            // =====================================================

            if (BtnLimpiar != null)
            {
                BtnLimpiar.Click +=
                    BtnLimpiar_Click;
            }


            // =====================================================
            // SELECTION CHANGED
            // =====================================================

            ReporteadorDgvReportes.SelectionChanged +=
                ReporteadorDgvReportes_SelectionChanged;


            // =====================================================
            // CARGAR FORMULARIO
            // =====================================================

            Load += FrmReportes_Load;
        }


        // =========================================================
        // LOAD
        // =========================================================

        private void FrmReportes_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                // =================================================
                // BTN RUTA
                // =================================================

                if (BtnRuta != null)
                {
                    BtnRuta.CampoTextoRuta =
                        ReporteadorTxtRutaReporte;
                }


                // =================================================
                // BTN GUARDAR
                // =================================================

                if (BtnGuardar != null)
                {
                    BtnGuardar.TxtNombreReporte =
                        ReporteadorTxtNombreReporte;

                    BtnGuardar.TxtRutaReporte =
                        ReporteadorTxtRutaReporte;
                }


                // =================================================
                // BTN BUSQUEDA
                // =================================================

                if (btnBusqueda1 != null)
                {
                    btnBusqueda1.TxtNombreReporte =
                        ReporteadorTxtNombreReporte2;

                    btnBusqueda1.DtpFechaReporte =
                        ReporteadorDtpFechaReporte;

                    btnBusqueda1.ChkNombreReporte =
                        ReporteadorChkNombreReporte;

                    btnBusqueda1.ChkFechaReporte =
                        ReporteadorChkFechaReporte;

                    btnBusqueda1.DgvReportes =
                        ReporteadorDgvReportes;
                }


                // =================================================
                // BTN ACTUALIZAR
                // =================================================

                if (BtnActualizar != null)
                {
                    BtnActualizar.DgvReportes =
                        ReporteadorDgvReportes;
                }


                // =================================================
                // CARGAR TABLA
                // =================================================

                CargarTabla();


                // =================================================
                // PREPARAR NUEVO REGISTRO
                // =================================================

                modoEdicion = false;

                numeroReporteEdicion = 0;

                PrepararNuevoRegistro();
            }
            catch (Exception ex)
            {
                MostrarError(
                    "No se pudo cargar el formulario.\n\n" +
                    ex.Message
                );
            }
        }


        // =========================================================
        // CLICK BTN GUARDAR
        // =========================================================

        private void BtnGuardar1_Click(
            object sender,
            EventArgs e)
        {
            GuardarReporte();
        }


        // =========================================================
        // CLICK BTN EDITAR
        // =========================================================

        private void BtnEditar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // =================================================
                // VALIDAR SELECCIÓN
                // =================================================

                if (ReporteadorDgvReportes.CurrentRow == null)
                {
                    MostrarError(
                        "Debe seleccionar un reporte para editar."
                    );

                    return;
                }


                // =================================================
                // OBTENER NUMERO
                // =================================================

                object numero =
                    ReporteadorDgvReportes
                    .CurrentRow
                    .Cells["NumeroReporte"]
                    .Value;


                // =================================================
                // OBTENER NOMBRE
                // =================================================

                object nombre =
                    ReporteadorDgvReportes
                    .CurrentRow
                    .Cells["NombreReporte"]
                    .Value;


                // =================================================
                // OBTENER RUTA
                // =================================================

                object ruta =
                    ReporteadorDgvReportes
                    .CurrentRow
                    .Cells["RutaReporte"]
                    .Value;


                // =================================================
                // OBTENER FECHA
                // =================================================

                object fecha =
                    ReporteadorDgvReportes
                    .CurrentRow
                    .Cells["FechaReporte"]
                    .Value;


                // =================================================
                // VALIDAR NUMERO
                // =================================================

                if (numero == null ||
                    numero == DBNull.Value)
                {
                    MostrarError(
                        "No se pudo obtener el número del reporte."
                    );

                    return;
                }


                // =================================================
                // GUARDAR NUMERO A EDITAR
                // =================================================

                numeroReporteEdicion =
                    Convert.ToInt32(numero);


                // =================================================
                // CARGAR NOMBRE
                // =================================================

                ReporteadorTxtNombreReporte.Text =
                    nombre == null ||
                    nombre == DBNull.Value
                        ? ""
                        : nombre.ToString();


                // =================================================
                // CARGAR RUTA
                // =================================================

                ReporteadorTxtRutaReporte.Text =
                    ruta == null ||
                    ruta == DBNull.Value
                        ? ""
                        : ruta.ToString();


                // =================================================
                // CREAR MODELO
                // =================================================

                modeloReporteador =
                    new ClsModeloReporteador();


                // =================================================
                // INDICAR MODIFICACIÓN
                // =================================================

                modeloReporteador.Estado =
                    ClsEstadoEntidad.Modified;

                modeloReporteador.NumeroReporte =
                    numeroReporteEdicion;


                // =================================================
                // CARGAR FECHA
                // =================================================

                if (fecha != null &&
                    fecha != DBNull.Value)
                {
                    modeloReporteador.FechaReporte =
                        Convert.ToDateTime(fecha);
                }
                else
                {
                    modeloReporteador.FechaReporte =
                        DateTime.Now.Date;
                }


                // =================================================
                // CARGAR DATE TIME PICKER
                // =================================================

                if (ReporteadorDtpFechaReporte != null)
                {
                    ReporteadorDtpFechaReporte.Value =
                        modeloReporteador.FechaReporte;
                }


                // =================================================
                // ACTIVAR MODO EDICIÓN
                // =================================================

                modoEdicion = true;


                // =================================================
                // FOCUS
                // =================================================

                ReporteadorTxtNombreReporte.Focus();
            }
            catch (Exception ex)
            {
                MostrarError(
                    "No se pudo preparar el reporte para editar.\n\n" +
                    ex.Message
                );
            }
        }


        // =========================================================
        // CLICK BTN LIMPIAR
        // =========================================================

        private void BtnLimpiar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // =================================================
                // LIMPIAR CAMPOS
                // =================================================

                ReporteadorTxtRutaReporte.Clear();

                ReporteadorTxtNombreReporte.Clear();

                ReporteadorTxtNombreReporte2.Clear();


                // =================================================
                // REINICIAR FECHA
                // =================================================

                ReporteadorDtpFechaReporte.Value =
                    DateTime.Now;


                // =================================================
                // CANCELAR MODO EDICIÓN
                // =================================================

                modoEdicion = false;

                numeroReporteEdicion = 0;


                // =================================================
                // CREAR MODELO NUEVO
                // =================================================

                modeloReporteador =
                    new ClsModeloReporteador();


                // =================================================
                // PREPARAR NUEVO REGISTRO
                // =================================================

                PrepararNuevoRegistro();


                // =================================================
                // FOCUS
                // =================================================

                ReporteadorTxtNombreReporte.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Limpiar formulario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }


        // =========================================================
        // GUARDAR / ACTUALIZAR REPORTE
        // =========================================================

        private void GuardarReporte()
        {
            try
            {
                // =================================================
                // VALIDAR NOMBRE
                // =================================================

                string nombre =
                    ReporteadorTxtNombreReporte.Text.Trim();


                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MostrarError(
                        "Debe ingresar el nombre del reporte."
                    );

                    ReporteadorTxtNombreReporte.Focus();

                    return;
                }


                // =================================================
                // VALIDAR RUTA
                // =================================================

                string ruta =
                    ReporteadorTxtRutaReporte.Text.Trim();


                if (string.IsNullOrWhiteSpace(ruta))
                {
                    MostrarError(
                        "Debe seleccionar el archivo PDF del reporte."
                    );

                    return;
                }


                // =================================================
                // VALIDAR EXTENSIÓN
                // =================================================

                if (!ruta.EndsWith(
                    ".pdf",
                    StringComparison.OrdinalIgnoreCase))
                {
                    MostrarError(
                        "El archivo seleccionado debe ser un PDF."
                    );

                    return;
                }


                // =================================================
                // VALIDAR ARCHIVO
                // =================================================

                if (!File.Exists(ruta))
                {
                    MostrarError(
                        "El archivo seleccionado no existe.\n\n" +
                        "Seleccione nuevamente el PDF."
                    );

                    return;
                }


                // =================================================
                // ASEGURAR MODELO
                // =================================================

                if (modeloReporteador == null)
                {
                    modeloReporteador =
                        new ClsModeloReporteador();
                }


                // =================================================
                // PREPARAR OPERACIÓN
                // =================================================

                if (modoEdicion)
                {
                    // ---------------------------------------------
                    // ACTUALIZAR
                    // ---------------------------------------------

                    modeloReporteador.Estado =
                        ClsEstadoEntidad.Modified;

                    modeloReporteador.NumeroReporte =
                        numeroReporteEdicion;
                }
                else
                {
                    // ---------------------------------------------
                    // NUEVO REGISTRO
                    // ---------------------------------------------

                    modeloReporteador.Estado =
                        ClsEstadoEntidad.Added;

                    modeloReporteador.NumeroReporte =
                        modeloReporteador
                        .GenerarSiguienteNumeroReporte(30);
                }


                // =================================================
                // ASIGNAR NOMBRE
                // =================================================

                modeloReporteador.NombreReporte =
                    nombre;


                // =================================================
                // ASIGNAR RUTA
                // =================================================

                modeloReporteador.RutaReporte =
                    ruta;


                // =================================================
                // ASIGNAR FECHA
                // =================================================

                if (ReporteadorDtpFechaReporte != null)
                {
                    modeloReporteador.FechaReporte =
                        ReporteadorDtpFechaReporte.Value.Date;
                }
                else
                {
                    modeloReporteador.FechaReporte =
                        DateTime.Now.Date;
                }


                // =================================================
                // GRABAR CAMBIOS
                // =================================================

                string resultado =
                    modeloReporteador.GrabarCambios();


                // =================================================
                // OPERACIÓN EXITOSA
                // =================================================

                if (resultado == "Grabación exitosa" ||
                    resultado == "Actualización exitosa")
                {
                    bool fueEdicion =
                        modoEdicion;


                    // =================================================
                    // MOSTRAR MENSAJE
                    // =================================================

                    if (fueEdicion)
                    {
                        MostrarExito(
                            "Actualización exitosa"
                        );
                    }
                    else
                    {
                        MostrarExito(
                            "Grabación exitosa"
                        );
                    }


                    // =================================================
                    // SALIR DE EDICIÓN
                    // =================================================

                    modoEdicion = false;

                    numeroReporteEdicion = 0;


                    // =================================================
                    // LIMPIAR
                    // =================================================

                    LimpiarFormulario();


                    // =================================================
                    // CREAR NUEVO MODELO
                    // =================================================

                    modeloReporteador =
                        new ClsModeloReporteador();


                    // =================================================
                    // PREPARAR NUEVO REGISTRO
                    // =================================================

                    PrepararNuevoRegistro();


                    // =================================================
                    // ACTUALIZAR DATAGRIDVIEW
                    // =================================================

                    CargarTabla();

                    ReporteadorDgvReportes.Refresh();

                    return;
                }


                // =================================================
                // ERROR
                // =================================================

                MostrarError(
                    "No se pudo guardar el reporte.\n\n" +
                    resultado
                );
            }
            catch (Exception ex)
            {
                MostrarError(
                    "Ocurrió un error al guardar el reporte.\n\n" +
                    ex.Message
                );
            }
        }


        // =========================================================
        // PREPARAR NUEVO REGISTRO
        // =========================================================

        private void PrepararNuevoRegistro()
        {
            try
            {
                // =================================================
                // ESTADO
                // =================================================

                modeloReporteador.Estado =
                    ClsEstadoEntidad.Added;


                // =================================================
                // GENERAR NUMERO
                // =================================================

                modeloReporteador.NumeroReporte =
                    modeloReporteador
                    .GenerarSiguienteNumeroReporte(30);


                // =================================================
                // FECHA
                // =================================================

                modeloReporteador.FechaReporte =
                    DateTime.Now.Date;


                // =================================================
                // DATE TIME PICKER
                // =================================================

                if (ReporteadorDtpFechaReporte != null)
                {
                    ReporteadorDtpFechaReporte.Value =
                        DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MostrarError(
                    "No se pudo generar el número del reporte.\n\n" +
                    ex.Message
                );
            }
        }


        // =========================================================
        // CARGAR DATAGRIDVIEW
        // =========================================================

        public void CargarTabla()
        {
            try
            {
                // =================================================
                // ASEGURAR MODELO
                // =================================================

                if (modeloReporteador == null)
                {
                    modeloReporteador =
                        new ClsModeloReporteador();
                }


                // =================================================
                // OBTENER DATOS
                // =================================================

                var lista =
                    modeloReporteador.GetAll();


                // =================================================
                // LIMPIAR DATAGRIDVIEW
                // =================================================

                ReporteadorDgvReportes.DataSource =
                    null;

                ReporteadorDgvReportes.Columns.Clear();

                ReporteadorDgvReportes.AutoGenerateColumns =
                    false;


                // =================================================
                // NUMERO REPORTE
                // =================================================

                DataGridViewTextBoxColumn colNumero =
                    new DataGridViewTextBoxColumn();

                colNumero.Name =
                    "NumeroReporte";

                colNumero.HeaderText =
                    "NumeroReporte";

                colNumero.DataPropertyName =
                    "NumeroReporte";

                colNumero.Width =
                    100;

                ReporteadorDgvReportes.Columns.Add(
                    colNumero
                );


                // =================================================
                // NOMBRE REPORTE
                // =================================================

                DataGridViewTextBoxColumn colNombre =
                    new DataGridViewTextBoxColumn();

                colNombre.Name =
                    "NombreReporte";

                colNombre.HeaderText =
                    "NombreReporte";

                colNombre.DataPropertyName =
                    "NombreReporte";

                colNombre.Width =
                    180;

                ReporteadorDgvReportes.Columns.Add(
                    colNombre
                );


                // =================================================
                // RUTA REPORTE
                // =================================================

                DataGridViewTextBoxColumn colRuta =
                    new DataGridViewTextBoxColumn();

                colRuta.Name =
                    "RutaReporte";

                colRuta.HeaderText =
                    "RutaReporte";

                colRuta.DataPropertyName =
                    "RutaReporte";

                colRuta.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;

                ReporteadorDgvReportes.Columns.Add(
                    colRuta
                );


                // =================================================
                // FECHA REPORTE
                // =================================================

                DataGridViewTextBoxColumn colFecha =
                    new DataGridViewTextBoxColumn();

                colFecha.Name =
                    "FechaReporte";

                colFecha.HeaderText =
                    "FechaReporte";

                colFecha.DataPropertyName =
                    "FechaReporte";

                colFecha.Width =
                    100;

                colFecha.DefaultCellStyle.Format =
                    "dd/MM/yyyy";

                ReporteadorDgvReportes.Columns.Add(
                    colFecha
                );


                // =================================================
                // CARGAR DATOS
                // =================================================

                ReporteadorDgvReportes.DataSource =
                    lista;


                // =================================================
                // REFRESCAR
                // =================================================

                ReporteadorDgvReportes.Refresh();
            }
            catch (Exception ex)
            {
                MostrarError(
                    "No se pudo cargar la lista de reportes.\n\n" +
                    ex.Message
                );
            }
        }


        // =========================================================
        // SELECCIÓN DEL REPORTE PARA IMPRIMIR
        // =========================================================

        private void ReporteadorDgvReportes_SelectionChanged(
            object sender,
            EventArgs e)
        {
            try
            {
                if (BtnImprimir == null)
                {
                    return;
                }


                if (ReporteadorDgvReportes.CurrentRow == null)
                {
                    BtnImprimir.RutaReporte =
                        null;

                    return;
                }


                object valorRuta =
                    ReporteadorDgvReportes
                    .CurrentRow
                    .Cells["RutaReporte"]
                    .Value;


                if (valorRuta == null ||
                    valorRuta == DBNull.Value)
                {
                    BtnImprimir.RutaReporte =
                        null;

                    return;
                }


                BtnImprimir.RutaReporte =
                    valorRuta.ToString();
            }
            catch
            {
                BtnImprimir.RutaReporte =
                    null;
            }
        }


        // =========================================================
        // LIMPIAR FORMULARIO
        // =========================================================

        private void LimpiarFormulario()
        {
            ReporteadorTxtNombreReporte.Clear();

            ReporteadorTxtRutaReporte.Clear();

            ReporteadorTxtNombreReporte2.Clear();


            if (ReporteadorDtpFechaReporte != null)
            {
                ReporteadorDtpFechaReporte.Value =
                    DateTime.Now;
            }


            ReporteadorTxtNombreReporte.Focus();
        }


        // =========================================================
        // MENSAJE DE ÉXITO
        // =========================================================

        private void MostrarExito(string mensaje)
        {
            using (Form frmExito = new Form())
            {
                // =================================================
                // CONFIGURACIÓN
                // =================================================

                frmExito.Text =
                    "Operación exitosa";

                frmExito.StartPosition =
                    FormStartPosition.CenterParent;

                frmExito.FormBorderStyle =
                    FormBorderStyle.FixedDialog;

                frmExito.MaximizeBox =
                    false;

                frmExito.MinimizeBox =
                    false;

                frmExito.ShowInTaskbar =
                    false;

                frmExito.ClientSize =
                    new System.Drawing.Size(
                        430,
                        180
                    );


                // =================================================
                // CÍRCULO VERDE
                // =================================================

                Panel circulo =
                    new Panel();

                circulo.Size =
                    new System.Drawing.Size(
                        52,
                        52
                    );

                circulo.Location =
                    new System.Drawing.Point(
                        25,
                        45
                    );

                circulo.BackColor =
                    System.Drawing.Color.ForestGreen;


                circulo.Paint += (sender, e) =>
                {
                    using (
                        System.Drawing.SolidBrush pincel =
                        new System.Drawing.SolidBrush(
                            System.Drawing.Color.White))
                    {
                        e.Graphics.FillEllipse(
                            pincel,
                            14,
                            14,
                            24,
                            24
                        );
                    }


                    using (
                        System.Drawing.Pen lapiz =
                        new System.Drawing.Pen(
                            System.Drawing.Color.ForestGreen,
                            3))
                    {
                        e.Graphics.DrawLine(
                            lapiz,
                            19,
                            26,
                            24,
                            31
                        );

                        e.Graphics.DrawLine(
                            lapiz,
                            24,
                            31,
                            35,
                            20
                        );
                    }
                };


                frmExito.Controls.Add(
                    circulo
                );


                // =================================================
                // MENSAJE
                // =================================================

                Label lblMensaje =
                    new Label();

                lblMensaje.AutoSize =
                    false;

                lblMensaje.Location =
                    new System.Drawing.Point(
                        95,
                        40
                    );

                lblMensaje.Size =
                    new System.Drawing.Size(
                        300,
                        55
                    );

                lblMensaje.Text =
                    mensaje;

                lblMensaje.Font =
                    new System.Drawing.Font(
                        "Microsoft Sans Serif",
                        10F
                    );

                lblMensaje.TextAlign =
                    System.Drawing.ContentAlignment.MiddleLeft;


                frmExito.Controls.Add(
                    lblMensaje
                );


                // =================================================
                // BOTÓN ACEPTAR
                // =================================================

                Button btnAceptar =
                    new Button();

                btnAceptar.Text =
                    "Aceptar";

                btnAceptar.Size =
                    new System.Drawing.Size(
                        90,
                        32
                    );

                btnAceptar.Location =
                    new System.Drawing.Point(
                        320,
                        120
                    );

                btnAceptar.DialogResult =
                    DialogResult.OK;


                frmExito.Controls.Add(
                    btnAceptar
                );


                frmExito.AcceptButton =
                    btnAceptar;


                // =================================================
                // MOSTRAR
                // =================================================

                frmExito.ShowDialog(this);
            }
        }


        // =========================================================
        // MENSAJE DE ERROR
        // =========================================================

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "Ocurrió un error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }


        // =========================================================
        // CONFIRMACIÓN
        // =========================================================

        private bool MostrarConfirmacion(
            string mensaje)
        {
            DialogResult resultado =
                MessageBox.Show(
                    mensaje,
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            return resultado ==
                   DialogResult.Yes;
        }
    }
}