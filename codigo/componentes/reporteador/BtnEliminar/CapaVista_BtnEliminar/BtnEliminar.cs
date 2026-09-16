using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

using CapaControlador_BtnEliminar;
using CapaModelo_BtnEliminar.Contratos;
using CapaModelo_BtnEliminar.Entidades;


namespace CapaVista_BtnEliminar
{


    public partial class BtnEliminarReporte : UserControl
    {
        // =====================================================
        // CONTROLADOR
        // =====================================================

        private readonly ClsDeshabilitarReporte
            controladorDeshabilitar;


        // =====================================================
        // PROPIEDADES
        // =====================================================

        [Browsable(false)]
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Hidden)]
        public DataGridView GridReportes { get; set; }


        [Category("Reporteador")]
        [DefaultValue("ReporteadorDgvReportes")]
        public string NombreGridReportes { get; set; }
            = "ReporteadorDgvReportes";


        [Category("Reporteador")]
        [DefaultValue("NumeroReporte")]
        public string ColumnaNumeroReporte { get; set; }
            = "NumeroReporte";


        [Category("Reporteador")]
        [DefaultValue("NombreReporte")]
        public string ColumnaNombreReporte { get; set; }
            = "NombreReporte";


        [Category("Reporteador")]
        [DefaultValue("RutaReporte")]
        public string ColumnaRutaReporte { get; set; }
            = "RutaReporte";


        [Category("Reporteador")]
        [DefaultValue("FechaReporte")]
        public string ColumnaFechaReporte { get; set; }
            = "FechaReporte";


        // Metodo publico del formulario que recarga
        // la tabla despues de deshabilitar.
        [Category("Reporteador")]
        [DefaultValue("CargarTabla")]
        public string MetodoRecargar { get; set; }
            = "CargarTabla";


        // =====================================================
        // EVENTO
        // =====================================================

        public event EventHandler Deshabilitado;

        protected virtual void OnDeshabilitado()
        {
            if (Deshabilitado != null)
            {
                Deshabilitado(this, EventArgs.Empty);
            }
        }


        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public BtnEliminarReporte()
        {
            InitializeComponent();

            controladorDeshabilitar =
                new ClsModeloDeshabilitar();

            BtnEliminar.Click +=
                BtnEliminarInterno_Click;
        }


        // =====================================================
        // AUTODETECCION DEL GRID
        // =====================================================

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
            {
                return;
            }

            if (GridReportes == null)
            {
                GridReportes = BuscarGrid();
            }

            if (GridReportes != null)
            {
                // Cada vez que el form vuelve a cargar
                // datos en el grid, se repinta.
                GridReportes.DataBindingComplete +=
                    (s, args) => MarcarFilasDeshabilitadas();

                MarcarFilasDeshabilitadas();
            }
        }


        private DataGridView BuscarGrid()
        {
            try
            {
                Form contenedor = FindForm();

                if (contenedor == null)
                {
                    return null;
                }

                Control[] encontrados =
                    contenedor.Controls.Find(
                        NombreGridReportes,
                        true);

                foreach (Control control in encontrados)
                {
                    DataGridView grid =
                        control as DataGridView;

                    if (grid != null)
                    {
                        return grid;
                    }
                }

                return PrimerGrid(contenedor);
            }
            catch (Exception)
            {
                // Falla silenciosa: se reintenta
                // al hacer click.
                return null;
            }
        }


        private DataGridView PrimerGrid(
            Control contenedor)
        {
            foreach (Control control
                     in contenedor.Controls)
            {
                DataGridView grid =
                    control as DataGridView;

                if (grid != null)
                {
                    return grid;
                }

                DataGridView anidado =
                    PrimerGrid(control);

                if (anidado != null)
                {
                    return anidado;
                }
            }

            return null;
        }


        // =====================================================
        // CLICK
        // =====================================================

        private void BtnEliminarInterno_Click(
            object sender, EventArgs e)
        {
            DeshabilitarSeleccionado();

            OnClick(EventArgs.Empty);
        }


        // =====================================================
        // DESHABILITAR SELECCIONADO
        // =====================================================

        public void DeshabilitarSeleccionado()
        {
            try
            {
                // -----------------------------------------
                // GRID
                // -----------------------------------------

                if (GridReportes == null)
                {
                    GridReportes = BuscarGrid();
                }

                if (GridReportes == null)
                {
                    MostrarError(
                        "No se encontro la tabla de reportes " +
                        "en el formulario.");

                    return;
                }


                // -----------------------------------------
                // FILA SELECCIONADA
                // -----------------------------------------

                DataGridViewRow fila =
                    GridReportes.CurrentRow;

                if (fila == null || fila.IsNewRow)
                {
                    MostrarError(
                        "Seleccione el reporte que desea " +
                        "deshabilitar.");

                    return;
                }


                // -----------------------------------------
                // LEER LA FILA
                // -----------------------------------------

                ClsReporteSeleccionado seleccionado =
                    LeerFila(fila);

                if (seleccionado == null)
                {
                    return;
                }


                // -----------------------------------------
                // VENTANA DE ADVERTENCIA / CONFIRMACION
                // -----------------------------------------
                // SIEMPRE se pregunta antes de deshabilitar.

                string pregunta =
                    "Esta seguro que desea deshabilitar " +
                    "este reporte?" +
                    Environment.NewLine +
                    Environment.NewLine +
                    "Numero: " +
                    seleccionado.NumeroReporte +
                    Environment.NewLine +
                    "Nombre: " +
                    seleccionado.NombreReporte +
                    Environment.NewLine +
                    Environment.NewLine +
                    "El reporte NO se borrara ni se " +
                    "modificara en la base de datos, solo " +
                    "quedara marcado como inactivo en este " +
                    "equipo.";

                if (!MostrarConfirmacion(pregunta))
                {
                    // El usuario cancelo. No se hace nada.
                    return;
                }


                // -----------------------------------------
                // DESHABILITAR (CONTROLADOR)
                // -----------------------------------------

                string error =
                    controladorDeshabilitar.Deshabilitar(
                        seleccionado);

                if (string.IsNullOrWhiteSpace(error))
                {
                    MostrarExito(
                        "El reporte se deshabilito " +
                        "correctamente.");

                    RecargarTabla();

                    MarcarFilasDeshabilitadas();

                    OnDeshabilitado();

                    return;
                }

                MostrarError(
                    "No se pudo deshabilitar el reporte." +
                    Environment.NewLine +
                    Environment.NewLine +
                    error);
            }
            catch (Exception ex)
            {
                MostrarError(
                    "Ocurrio un error inesperado al " +
                    "deshabilitar el reporte." +
                    Environment.NewLine +
                    Environment.NewLine +
                    ex.Message);
            }
        }


        // =====================================================
        // MARCAR VISUALMENTE LAS FILAS DESHABILITADAS
        // =====================================================

        // Como no se toca la BD ni el GetAll() del proyecto principal, la tabla sigue trayendo todos los reportes. Esto pinta en gris/cursiva los que estan
        // en el archivo de deshabilitados, para que se distingan a simple vista.

        private void MarcarFilasDeshabilitadas()
        {
            try
            {
                if (GridReportes == null)
                {
                    return;
                }

                HashSet<int> deshabilitados =
                    new HashSet<int>(
                        controladorDeshabilitar
                        .ObtenerNumerosDeshabilitados());

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
                        ObtenerValor(
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
                // si falla, no debe interrumpir el flujo.
            }
        }


        // =====================================================
        // LEER LA FILA DEL GRID
        // =====================================================

        private ClsReporteSeleccionado LeerFila(
            DataGridViewRow fila)
        {
            try
            {
                object valorNumero =
                    ObtenerValor(
                        fila, ColumnaNumeroReporte);

                int numeroReporte;

                if (valorNumero == null ||
                    !int.TryParse(
                        valorNumero.ToString(),
                        out numeroReporte))
                {
                    MostrarError(
                        "No se pudo leer el numero del " +
                        "reporte seleccionado." +
                        Environment.NewLine +
                        "Verifique que exista la columna '" +
                        ColumnaNumeroReporte + "'.");

                    return null;
                }

                object valorNombre =
                    ObtenerValor(
                        fila, ColumnaNombreReporte);

                object valorRuta =
                    ObtenerValor(
                        fila, ColumnaRutaReporte);

                object valorFecha =
                    ObtenerValor(
                        fila, ColumnaFechaReporte);

                DateTime fechaReporte;

                if (valorFecha == null ||
                    !DateTime.TryParse(
                        valorFecha.ToString(),
                        out fechaReporte))
                {
                    fechaReporte = DateTime.Now.Date;
                }

                return new ClsReporteSeleccionado
                {
                    NumeroReporte = numeroReporte,

                    NombreReporte =
                        valorNombre == null
                            ? ""
                            : valorNombre.ToString(),

                    RutaReporte =
                        valorRuta == null
                            ? ""
                            : valorRuta.ToString(),

                    FechaReporte = fechaReporte
                };
            }
            catch (Exception ex)
            {
                MostrarError(
                    "No se pudo leer la fila seleccionada." +
                    Environment.NewLine +
                    ex.Message);

                return null;
            }
        }


        private object ObtenerValor(
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


        // =====================================================
        // RECARGAR LA TABLA DEL FORM
        // =====================================================

        private void RecargarTabla()
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
                MostrarError(
                    "El reporte se deshabilito, pero no " +
                    "se pudo refrescar la tabla." +
                    Environment.NewLine +
                    ex.Message);
            }
        }


        // =====================================================
        // DIALOGOS
        // =====================================================

        private void MostrarExito(string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "Operacion exitosa",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        private void MostrarError(string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "Ocurrio un error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }


        // Ventana emergente de advertencia con Si/No.
        private bool MostrarConfirmacion(string mensaje)
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