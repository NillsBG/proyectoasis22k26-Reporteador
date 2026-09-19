using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

using CapaControlador_BtnGuardar_Reporteador;

namespace CapaVista_BtnGuardar_Reporteador
{
    // El boton permite guardar un nuevo registro o actualizar
    // uno existente en la base de datos mediante ODBC.
    public partial class BtnGuardar_Reporteador : UserControl
    {
        private readonly ClsModeloBtnGuardarReporteador _Controlador;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TextBox TxtNumeroReporte { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TextBox TxtNombreReporte { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TextBox TxtRutaReporte { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTimePicker DtpFechaReporte { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridView GridReportes { get; set; }

        [Category("Reporteador")]
        [DefaultValue("ReporteadorTxtNumeroReporte")]
        public string NombreTxtNumeroReporte { get; set; } = "ReporteadorTxtNumeroReporte";

        [Category("Reporteador")]
        [DefaultValue("ReporteadorTxtNombreReporte")]
        public string NombreTxtNombreReporte { get; set; } = "ReporteadorTxtNombreReporte";

        [Category("Reporteador")]
        [DefaultValue("ReporteadorTxtRutaReporte")]
        public string NombreTxtRutaReporte { get; set; } = "ReporteadorTxtRutaReporte";

        [Category("Reporteador")]
        [DefaultValue("ReporteadorDtpFechaReporte")]
        public string NombreDtpFechaReporte { get; set; } = "ReporteadorDtpFechaReporte";

        [Category("Reporteador")]
        [DefaultValue("ReporteadorDgvReportes")]
        public string NombreGridReportes { get; set; } = "ReporteadorDgvReportes";

        [Category("Reporteador")]
        [DefaultValue("CargarTabla")]
        public string MetodoRecargar { get; set; } = "CargarTabla";

        // NUEVO: nombre del método del formulario contenedor que debe
        // ejecutarse para guardar, cuando el número de reporte lo gestiona
        // el propio formulario (ver NumeroReporteGestionadoPorFormulario).
        // Se invoca por reflexión, sin depender de que el evento Click del
        // control esté enlazado en el diseñador.
        [Category("Reporteador")]
        [DefaultValue("GuardarReporte")]
        public string MetodoGuardarFormulario { get; set; } = "GuardarReporte";

        [Category("Reporteador")]
        [DefaultValue(false)]
        public bool EsEdicion { get; set; } = false;

        // Cuando el formulario que contiene este control genera el número
        // de reporte automáticamente (por ejemplo, comenzando en 3001) y NO
        // tiene un TextBox visible para ese número, este control deja de
        // exigirlo y de guardar por su cuenta: en su lugar invoca
        // MetodoGuardarFormulario directamente sobre el formulario.
        [Category("Reporteador")]
        [DefaultValue(false)]
        public bool NumeroReporteGestionadoPorFormulario { get; set; } = false;

        public event EventHandler GuardadoExitoso;

        protected virtual void OnGuardadoExitoso()
        {
            if (GuardadoExitoso != null)
            {
                GuardadoExitoso(this, EventArgs.Empty);
            }
        }

        public BtnGuardar_Reporteador()
        {
            InitializeComponent();

            _Controlador = new ClsModeloBtnGuardarReporteador();

            BtnGuardarReporteador.Click += ReporteadorBtnGuardar_Click;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
            {
                return;
            }

            if (TxtNumeroReporte == null)
            {
                TxtNumeroReporte = ReporteadorMetBuscarControl<TextBox>(NombreTxtNumeroReporte);
            }

            if (TxtNombreReporte == null)
            {
                TxtNombreReporte = ReporteadorMetBuscarControl<TextBox>(NombreTxtNombreReporte);
            }

            if (TxtRutaReporte == null)
            {
                TxtRutaReporte = ReporteadorMetBuscarControl<TextBox>(NombreTxtRutaReporte);
            }

            if (DtpFechaReporte == null)
            {
                DtpFechaReporte = ReporteadorMetBuscarControl<DateTimePicker>(NombreDtpFechaReporte);
            }

            if (GridReportes == null)
            {
                GridReportes = ReporteadorMetBuscarControl<DataGridView>(NombreGridReportes);
            }

            // Si el formulario no tiene un TextBox de número de reporte,
            // asumimos automáticamente que el número lo gestiona el formulario
            // (evita tener que marcar la propiedad manualmente en cada caso).
            if (TxtNumeroReporte == null)
            {
                NumeroReporteGestionadoPorFormulario = true;
            }
        }

        private T ReporteadorMetBuscarControl<T>(string nombre) where T : Control
        {
            try
            {
                Form contenedor = FindForm();

                if (contenedor == null || string.IsNullOrWhiteSpace(nombre))
                {
                    return null;
                }

                Control[] encontrados = contenedor.Controls.Find(nombre, true);

                foreach (Control control in encontrados)
                {
                    T tipado = control as T;
                    if (tipado != null)
                    {
                        return tipado;
                    }
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void ReporteadorBtnGuardar_Click(object sender, EventArgs e)
        {
            // Si el número de reporte lo gestiona el propio formulario
            // (por ejemplo, autogenerado desde 3001), este control NO valida
            // ni guarda nada por su cuenta: invoca directamente el método de
            // guardado del formulario (MetodoGuardarFormulario) por
            // reflexión, sin depender de que el evento Click del control
            // esté enlazado en el diseñador del formulario.
            if (NumeroReporteGestionadoPorFormulario)
            {
                ReporteadorMetInvocarGuardarFormulario();
                OnClick(EventArgs.Empty);
                return;
            }

            ReporteadorMetEjecutarGuardar();
            OnClick(EventArgs.Empty);
        }

        private void ReporteadorMetInvocarGuardarFormulario()
        {
            try
            {
                Form contenedor = FindForm();

                if (contenedor == null || string.IsNullOrWhiteSpace(MetodoGuardarFormulario))
                {
                    ReporteadorMetMostrarError("No se encontró el formulario para guardar el reporte.");
                    return;
                }

                MethodInfo metodo = contenedor.GetType().GetMethod(
                    MetodoGuardarFormulario,
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                    null,
                    Type.EmptyTypes,
                    null);

                if (metodo != null)
                {
                    metodo.Invoke(contenedor, null);
                }
                else
                {
                    ReporteadorMetMostrarError("No se encontró el método '" + MetodoGuardarFormulario + "' en el formulario.");
                }
            }
            catch (TargetInvocationException tie) when (tie.InnerException != null)
            {
                ReporteadorMetMostrarError("Ocurrió un error al guardar el reporte." + Environment.NewLine + Environment.NewLine + tie.InnerException.Message);
            }
            catch (Exception ex)
            {
                ReporteadorMetMostrarError("Ocurrió un error al guardar el reporte." + Environment.NewLine + Environment.NewLine + ex.Message);
            }
        }

        public void ReporteadorMetEjecutarGuardar()
        {
            try
            {
                if (NumeroReporteGestionadoPorFormulario)
                {
                    // El guardado real lo realiza el formulario contenedor
                    // (ver ReporteadorMetInvocarGuardarFormulario); este
                    // control no interviene en ese caso.
                    return;
                }

                if (TxtNumeroReporte == null)
                {
                    TxtNumeroReporte = ReporteadorMetBuscarControl<TextBox>(NombreTxtNumeroReporte);
                }
                if (TxtNombreReporte == null)
                {
                    TxtNombreReporte = ReporteadorMetBuscarControl<TextBox>(NombreTxtNombreReporte);
                }
                if (TxtRutaReporte == null)
                {
                    TxtRutaReporte = ReporteadorMetBuscarControl<TextBox>(NombreTxtRutaReporte);
                }
                if (DtpFechaReporte == null)
                {
                    DtpFechaReporte = ReporteadorMetBuscarControl<DateTimePicker>(NombreDtpFechaReporte);
                }

                if (TxtNumeroReporte == null || string.IsNullOrWhiteSpace(TxtNumeroReporte.Text))
                {
                    ReporteadorMetMostrarError("Debe ingresar el número de reporte.");
                    return;
                }

                int numeroReporte;
                if (!int.TryParse(TxtNumeroReporte.Text.Trim(), out numeroReporte))
                {
                    ReporteadorMetMostrarError("El número de reporte debe ser un valor numérico válido.");
                    return;
                }

                string nombreReporte = TxtNombreReporte != null ? TxtNombreReporte.Text.Trim() : string.Empty;
                string rutaReporte = TxtRutaReporte != null ? TxtRutaReporte.Text.Trim() : string.Empty;
                DateTime fechaReporte = DtpFechaReporte != null ? DtpFechaReporte.Value : DateTime.Now;

                string error = _Controlador.ReporteadorMetGuardar(numeroReporte, nombreReporte, rutaReporte, fechaReporte, EsEdicion);

                if (string.IsNullOrWhiteSpace(error))
                {
                    string mensajeExito = EsEdicion ? "Actualización exitosa" : "Grabación exitosa";
                    ReporteadorMetMostrarExito(mensajeExito);

                    ReporteadorMetRecargarTabla();
                    OnGuardadoExitoso();
                }
                else
                {
                    ReporteadorMetMostrarError("No se pudo guardar el registro." + Environment.NewLine + Environment.NewLine + error);
                }
            }
            catch (Exception ex)
            {
                ReporteadorMetMostrarError("Ocurrió un error inesperado al guardar." + Environment.NewLine + Environment.NewLine + ex.Message);
            }
        }

        private void ReporteadorMetRecargarTabla()
        {
            try
            {
                Form contenedor = FindForm();

                if (contenedor == null || string.IsNullOrWhiteSpace(MetodoRecargar))
                {
                    return;
                }

                MethodInfo metodo = contenedor.GetType().GetMethod(
                    MetodoRecargar,
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                    null,
                    Type.EmptyTypes,
                    null);

                if (metodo != null)
                {
                    metodo.Invoke(contenedor, null);
                    return;
                }

                if (GridReportes != null)
                {
                    GridReportes.Refresh();
                }
            }
            catch (Exception ex)
            {
                ReporteadorMetMostrarError("El registro se guardó, pero no se pudo refrescar la tabla." + Environment.NewLine + ex.Message);
            }
        }

        private void ReporteadorMetMostrarExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReporteadorMetMostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}