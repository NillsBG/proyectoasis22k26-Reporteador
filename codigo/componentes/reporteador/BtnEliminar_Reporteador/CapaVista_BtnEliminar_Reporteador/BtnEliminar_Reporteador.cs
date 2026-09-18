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

using CapaControlador_BtnEliminar_Reporteador;


namespace CapaVista_BtnEliminar_Reporteador
{
    // El boton se ve y se llama "Eliminar", pero NO borra
    // el registro y NO toca la base de datos: guarda el
    // numero de reporte en un archivo de texto local
    // (ReportesDeshabilitados.txt).
    //
    // Ademas, mientras un reporte este deshabilitado,
    // bloquea sus campos de texto (Nombre, Ruta) en el
    // formulario para que no se puedan modificar.

    public partial class BtnEliminar_Reporteador
        : UserControl
    {

        // CONTROLADOR

        private readonly ClsModeloBtnEliminarReporteador
            _Controlador;

        // PROPIEDADES

        [Browsable(false)]
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Hidden)]
        public DataGridView GridReportes { get; set; }


        [Browsable(false)]
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Hidden)]
        public TextBox TxtNombreReporte { get; set; }


        [Browsable(false)]
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Hidden)]
        public TextBox TxtRutaReporte { get; set; }


        [Category("Reporteador")]
        [DefaultValue("ReporteadorDgvReportes")]
        public string NombreGridReportes { get; set; }
            = "ReporteadorDgvReportes";


        [Category("Reporteador")]
        [DefaultValue("ReporteadorTxtNombreReporte")]
        public string NombreTxtNombreReporte { get; set; }
            = "ReporteadorTxtNombreReporte";


        [Category("Reporteador")]
        [DefaultValue("ReporteadorTxtRutaReporte")]
        public string NombreTxtRutaReporte { get; set; }
            = "ReporteadorTxtRutaReporte";


        [Category("Reporteador")]
        [DefaultValue("NumeroReporte")]
        public string ColumnaNumeroReporte { get; set; }
            = "NumeroReporte";


        [Category("Reporteador")]
        [DefaultValue("NombreReporte")]
        public string ColumnaNombreReporte { get; set; }
            = "NombreReporte";


        // Metodo publico del formulario que recarga la tabla despues de deshabilitar.
        [Category("Reporteador")]
        [DefaultValue("CargarTabla")]
        public string MetodoRecargar { get; set; }
            = "CargarTabla";


        // EVENTO

        public event EventHandler Deshabilitado;

        protected virtual void OnDeshabilitado()
        {
            if (Deshabilitado != null)
            {
                Deshabilitado(this, EventArgs.Empty);
            }
        }


        // CONSTRUCTOR

        public BtnEliminar_Reporteador()
        {
            InitializeComponent();

            _Controlador =
                new ClsModeloBtnEliminarReporteador();

            BtnEliminarReporteador.Click +=
                ReporteadorBtnEliminar_Click;
        }


        // AUTODETECCION DE CONTROLES DEL FORM


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
            {
                return;
            }

            if (GridReportes == null)
            {
                GridReportes =
                    ReporteadorMetBuscarControl<DataGridView>(
                        NombreGridReportes);
            }

            if (TxtNombreReporte == null)
            {
                TxtNombreReporte =
                    ReporteadorMetBuscarControl<TextBox>(
                        NombreTxtNombreReporte);
            }

            if (TxtRutaReporte == null)
            {
                TxtRutaReporte =
                    ReporteadorMetBuscarControl<TextBox>(
                        NombreTxtRutaReporte);
            }

            if (GridReportes != null)
            {
            // Cada vez que el form recarga datos en el grid, se repinta y se revisa el bloqueo de campos.
                GridReportes.DataBindingComplete +=
                    (s, args) =>
                    {
                        ReporteadorMetMarcarFilasDeshabilitadas();
                        ReporteadorMetActualizarBloqueoCampos();
                    };

                GridReportes.SelectionChanged +=
                    (s, args) =>
                        ReporteadorMetActualizarBloqueoCampos();

                ReporteadorMetMarcarFilasDeshabilitadas();
                ReporteadorMetActualizarBloqueoCampos();
            }
        }


        private T ReporteadorMetBuscarControl<T>(
            string nombre) where T : Control
        {
            try
            {
                Form contenedor = FindForm();

                if (contenedor == null ||
                    string.IsNullOrWhiteSpace(nombre))
                {
                    return null;
                }

                Control[] encontrados =
                    contenedor.Controls.Find(
                        nombre, true);

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


        // CLICK

        private void ReporteadorBtnEliminar_Click(
            object sender, EventArgs e)
        {
            ReporteadorMetDeshabilitarSeleccionado();

            OnClick(EventArgs.Empty);
        }


 
        // DESHABILITAR SELECCIONADO
 

        public void ReporteadorMetDeshabilitarSeleccionado()
        {
            try
            {

                // GRID


                if (GridReportes == null)
                {
                    GridReportes =
                        ReporteadorMetBuscarControl<DataGridView>(
                            NombreGridReportes);
                }

                if (GridReportes == null)
                {
                    ReporteadorMetMostrarError(
                        "No se encontro la tabla de " +
                        "reportes en el formulario.");

                    return;
                }

                // FILA SELECCIONADA

                DataGridViewRow fila =
                    GridReportes.CurrentRow;

                if (fila == null || fila.IsNewRow)
                {
                    ReporteadorMetMostrarError(
                        "Seleccione el reporte que desea " +
                        "deshabilitar.");

                    return;
                }


                object valorNumero =
                    ReporteadorMetObtenerValor(
                        fila, ColumnaNumeroReporte);

                int numeroReporte;

                if (valorNumero == null ||
                    !int.TryParse(
                        valorNumero.ToString(),
                        out numeroReporte))
                {
                    ReporteadorMetMostrarError(
                        "No se pudo leer el numero del " +
                        "reporte seleccionado." +
                        Environment.NewLine +
                        "Verifique que exista la columna '" +
                        ColumnaNumeroReporte + "'.");

                    return;
                }

                object valorNombre =
                    ReporteadorMetObtenerValor(
                        fila, ColumnaNombreReporte);

                string nombreReporte =
                    valorNombre == null
                        ? ""
                        : valorNombre.ToString();


   
                // VENTANA DE ADVERTENCIA / CONFIRMACION
                // -----------------------------------------
                // SIEMPRE se pregunta antes de deshabilitar.

                string pregunta =
                    "Esta seguro que desea deshabilitar " +
                    "este reporte?" +
                    Environment.NewLine +
                    Environment.NewLine +
                    "Numero: " + numeroReporte +
                    Environment.NewLine +
                    "Nombre: " + nombreReporte +
                    Environment.NewLine +
                    Environment.NewLine +
                    "El reporte NO se borrara ni se " +
                    "modificara en la base de datos. " +
                    "Quedara marcado como inactivo y sus " +
                    "campos no podran editarse.";

                if (!ReporteadorMetMostrarConfirmacion(
                        pregunta))
                {
                    // El usuario cancelo. No se hace nada.
                    return;
                }

                // DESHABILITAR (CONTROLADOR)


                string error =
                    _Controlador
                    .ReporteadorMetDeshabilitar(
                        numeroReporte);

                if (string.IsNullOrWhiteSpace(error))
                {
                    ReporteadorMetMostrarExito(
                        "El reporte se deshabilito " +
                        "correctamente.");

                    ReporteadorMetRecargarTabla();

                    ReporteadorMetMarcarFilasDeshabilitadas();

                    ReporteadorMetActualizarBloqueoCampos();

                    OnDeshabilitado();

                    return;
                }

                ReporteadorMetMostrarError(
                    "No se pudo deshabilitar el reporte." +
                    Environment.NewLine +
                    Environment.NewLine +
                    error);
            }
            catch (Exception ex)
            {
                ReporteadorMetMostrarError(
                    "Ocurrio un error inesperado al " +
                    "deshabilitar el reporte." +
                    Environment.NewLine +
                    Environment.NewLine +
                    ex.Message);
            }
        }


        // BLOQUEAR CAMPOS SI LA FILA ACTUAL ESTA DESHABILITADA
        // mientras el reporte seleccionado este deshabilitado,
        // sus TextBox de Nombre y Ruta quedan inhabilitados,
        // asi el boton Guardar no puede editarlos.

        private void ReporteadorMetActualizarBloqueoCampos()
        {
            try
            {
                if (GridReportes == null)
                {
                    return;
                }

                DataGridViewRow fila =
                    GridReportes.CurrentRow;

                bool bloquear = false;

                if (fila != null && !fila.IsNewRow)
                {
                    object valor =
                        ReporteadorMetObtenerValor(
                            fila, ColumnaNumeroReporte);

                    int numero;

                    if (valor != null &&
                        int.TryParse(
                            valor.ToString(),
                            out numero))
                    {
                        bloquear =
                            _Controlador
                            .ReporteadorMetEstaDeshabilitado(
                                numero);
                    }
                }

                if (TxtNombreReporte != null)
                {
                    TxtNombreReporte.Enabled = !bloquear;
                }

                if (TxtRutaReporte != null)
                {
                    TxtRutaReporte.Enabled = !bloquear;
                }
            }
            catch (Exception)
            {
                // El bloqueo de campos es un extra:
                // si falla, no debe frenar el flujo.
            }
        }


        // MARCAR VISUALMENTE LAS FILAS DESHABILITADAS


        private void ReporteadorMetMarcarFilasDeshabilitadas()
        {
            try
            {
                if (GridReportes == null)
                {
                    return;
                }

                HashSet<int> deshabilitados =
                    new HashSet<int>(
                        _Controlador
                        .ReporteadorMetObtenerNumerosDeshabilitados());

                Font fuenteNormal =
                    GridReportes.DefaultCellStyle.Font
                    ?? GridReportes.Font;

                Font fuenteCursiva =
                    new Font(
                        fuenteNormal,
                        FontStyle.Italic);

                foreach (DataGridViewRow fila
                         in GridReportes.Rows)
                {
                    if (fila.IsNewRow)
                    {
                        continue;
                    }

                    object valor =
                        ReporteadorMetObtenerValor(
                            fila, ColumnaNumeroReporte);

                    int numero;

                    bool estaDeshabilitado =
                        valor != null &&
                        int.TryParse(
                            valor.ToString(),
                            out numero) &&
                        deshabilitados.Contains(numero);

                    if (estaDeshabilitado)
                    {
                        fila.DefaultCellStyle.BackColor =
                            Color.Gainsboro;

                        fila.DefaultCellStyle.ForeColor =
                            Color.DimGray;

                        fila.DefaultCellStyle.Font =
                            fuenteCursiva;
                    }
                    else
                    {
                        fila.DefaultCellStyle.BackColor =
                            Color.Empty;

                        fila.DefaultCellStyle.ForeColor =
                            Color.Empty;

                        fila.DefaultCellStyle.Font = null;
                    }
                }
            }
            catch (Exception)
            {
                // El marcado visual es un extra:
                // si falla, no debe frenar el flujo.
            }
        }


        private object ReporteadorMetObtenerValor(
            DataGridViewRow fila,
            string nombreColumna)
        {
            if (string.IsNullOrWhiteSpace(nombreColumna))
            {
                return null;
            }

            if (!fila.DataGridView
                 .Columns.Contains(nombreColumna))
            {
                return null;
            }

            return fila.Cells[nombreColumna].Value;
        }

        // RECARGAR LA TABLA DEL FORM

        private void ReporteadorMetRecargarTabla()
        {
            try
            {
                Form contenedor = FindForm();

                if (contenedor == null ||
                    string.IsNullOrWhiteSpace(
                        MetodoRecargar))
                {
                    return;
                }

                MethodInfo metodo =
                    contenedor.GetType().GetMethod(
                        MetodoRecargar,
                        BindingFlags.Public |
                        BindingFlags.NonPublic |
                        BindingFlags.Instance,
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
                ReporteadorMetMostrarError(
                    "El reporte se deshabilito, pero no " +
                    "se pudo refrescar la tabla." +
                    Environment.NewLine +
                    ex.Message);
            }
        }


        // DIALOGOS

        private void ReporteadorMetMostrarExito(
            string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "Operacion exitosa",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        private void ReporteadorMetMostrarError(
            string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "Ocurrio un error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }


        // Ventana emergente de advertencia con Si/No.
        private bool ReporteadorMetMostrarConfirmacion(
            string mensaje)
        {
            DialogResult resultado =
                MessageBox.Show(
                    mensaje,
                    "Confirmar deshabilitacion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

            return resultado == DialogResult.Yes;
        }
    }
}