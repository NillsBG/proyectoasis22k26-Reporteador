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
                Deshabilitado(
                    this,
                    EventArgs.Empty);
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
        // CARGA DEL CONTROL
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
                // Cuando se cargan nuevamente los datos
                GridReportes.DataBindingComplete -=
                    GridReportes_DataBindingComplete;

                GridReportes.DataBindingComplete +=
                    GridReportes_DataBindingComplete;


                // Cuando cambia la fila seleccionada
                GridReportes.SelectionChanged -=
                    GridReportes_SelectionChanged;

                GridReportes.SelectionChanged +=
                    GridReportes_SelectionChanged;


                // Estado inicial
                MarcarFilasDeshabilitadas();

                ActualizarEstadoBotones();
            }
        }


        // =====================================================
        // CUANDO TERMINA DE CARGAR EL DATAGRIDVIEW
        // =====================================================

        private void GridReportes_DataBindingComplete(
            object sender,
            DataGridViewBindingCompleteEventArgs e)
        {
            MarcarFilasDeshabilitadas();

            ActualizarEstadoBotones();
        }


        // =====================================================
        // CUANDO CAMBIA LA FILA SELECCIONADA
        // =====================================================

        private void GridReportes_SelectionChanged(
            object sender,
            EventArgs e)
        {
            ActualizarEstadoBotones();
        }


        // =====================================================
        // BUSCAR DATAGRIDVIEW
        // =====================================================

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
                return null;
            }
        }


        // =====================================================
        // BUSCAR PRIMER DATAGRIDVIEW
        // =====================================================

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
        // CLICK DEL BOTON ELIMINAR
        // =====================================================

        private void BtnEliminarInterno_Click(
            object sender,
            EventArgs e)
        {
            DeshabilitarSeleccionado();

            OnClick(EventArgs.Empty);
        }


        // =====================================================
        // DESHABILITAR REPORTE SELECCIONADO
        // =====================================================

        public void DeshabilitarSeleccionado()
        {
            try
            {
                // -----------------------------------------
                // OBTENER GRID
                // -----------------------------------------

                if (GridReportes == null)
                {
                    GridReportes =
                        BuscarGrid();
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


                if (fila == null ||
                    fila.IsNewRow)
                {
                    MostrarError(
                        "Seleccione el reporte que desea " +
                        "deshabilitar.");

                    return;
                }


                // -----------------------------------------
                // LEER FILA
                // -----------------------------------------

                ClsReporteSeleccionado seleccionado =
                    LeerFila(fila);


                if (seleccionado == null)
                {
                    return;
                }


                // -----------------------------------------
                // CONFIRMACION
                // -----------------------------------------

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


                if (!MostrarConfirmacion(
                        pregunta))
                {
                    return;
                }


                // -----------------------------------------
                // DESHABILITAR
                // -----------------------------------------

                string error =
                    controladorDeshabilitar.Deshabilitar(
                        seleccionado);


                if (string.IsNullOrWhiteSpace(error))
                {
                    MostrarExito(
                        "El reporte se deshabilito " +
                        "correctamente.");


                    // Recargar tabla
                    RecargarTabla();


                    // Pintar filas
                    MarcarFilasDeshabilitadas();


                    // Actualizar botones
                    ActualizarEstadoBotones();


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
        // ACTUALIZAR ESTADO DE LOS BOTONES
        // =====================================================

        private void ActualizarEstadoBotones()
        {
            try
            {
                if (GridReportes == null)
                {
                    RestaurarTodosLosBotones();

                    return;
                }


                DataGridViewRow fila =
                    GridReportes.CurrentRow;


                // -------------------------------------------------
                // NO HAY FILA
                // -------------------------------------------------

                if (fila == null ||
                    fila.IsNewRow)
                {
                    RestaurarTodosLosBotones();

                    return;
                }


                // -------------------------------------------------
                // OBTENER NUMERO
                // -------------------------------------------------

                object valorNumero =
                    ObtenerValor(
                        fila,
                        ColumnaNumeroReporte);


                if (valorNumero == null ||
                    valorNumero == DBNull.Value)
                {
                    RestaurarTodosLosBotones();

                    return;
                }


                int numeroReporte;


                if (!int.TryParse(
                        valorNumero.ToString(),
                        out numeroReporte))
                {
                    RestaurarTodosLosBotones();

                    return;
                }


                // -------------------------------------------------
                // COMPROBAR SI ESTA DESHABILITADO
                // -------------------------------------------------

                bool estaDeshabilitado =
                    EstaReporteDeshabilitado(
                        numeroReporte,
                        fila);


                // -------------------------------------------------
                // REPORTE DESHABILITADO
                // -------------------------------------------------

                if (estaDeshabilitado)
                {
                    BloquearTodosLosBotones();

                    return;
                }


                // -------------------------------------------------
                // REPORTE ACTIVO
                // -------------------------------------------------

                RestaurarTodosLosBotones();
            }
            catch (Exception)
            {
                // Si ocurre un problema, dejamos los botones
                // en funcionamiento normal.
                RestaurarTodosLosBotones();
            }
        }


        // =====================================================
        // COMPROBAR SI EL REPORTE ESTA DESHABILITADO
        // =====================================================

        private bool EstaReporteDeshabilitado(
            int numeroReporte,
            DataGridViewRow fila)
        {
            try
            {
                // -------------------------------------------------
                // PRIMERA OPCION:
                // INTENTAR OBTENER LA LISTA MEDIANTE REFLEXION
                // -------------------------------------------------

                List<int> numeros =
                    ObtenerNumerosDeshabilitados();


                if (numeros != null)
                {
                    return numeros.Contains(
                        numeroReporte);
                }
            }
            catch
            {
                // Si no existe el metodo o falla,
                // usamos la informacion visual de la fila.
            }


            // -------------------------------------------------
            // SEGUNDA OPCION:
            // COMPROBAR EL ESTILO VISUAL DE LA FILA
            // -------------------------------------------------

            if (fila != null)
            {
                Color fondo =
                    fila.DefaultCellStyle.BackColor;


                Font fuente =
                    fila.DefaultCellStyle.Font;


                if (fondo == Color.Gainsboro)
                {
                    return true;
                }


                if (fuente != null &&
                    fuente.Italic)
                {
                    return true;
                }
            }


            return false;
        }


        // =====================================================
        // OBTENER NUMEROS DESHABILITADOS
        // =====================================================
        //
        // IMPORTANTE:
        // Aqui NO se llama directamente a:
        //
        // controladorDeshabilitar
        //     .ObtenerNumerosDeshabilitados();
        //
        // Se utiliza reflexion para evitar el error de
        // compilacion si ese metodo no esta expuesto
        // directamente por ClsDeshabilitarReporte.
        // =====================================================

        private List<int> ObtenerNumerosDeshabilitados()
        {
            List<int> resultado =
                new List<int>();


            try
            {
                Type tipo =
                    controladorDeshabilitar.GetType();


                MethodInfo metodo =
                    tipo.GetMethod(
                        "ObtenerNumerosDeshabilitados",
                        BindingFlags.Public |
                        BindingFlags.NonPublic |
                        BindingFlags.Instance);


                if (metodo == null)
                {
                    return resultado;
                }


                object respuesta =
                    metodo.Invoke(
                        controladorDeshabilitar,
                        null);


                if (respuesta == null)
                {
                    return resultado;
                }


                // -------------------------------------------------
                // CASO List<int>
                // -------------------------------------------------

                List<int> lista =
                    respuesta as List<int>;


                if (lista != null)
                {
                    return lista;
                }


                // -------------------------------------------------
                // CASO IEnumerable<int>
                // -------------------------------------------------

                IEnumerable<int> enumerable =
                    respuesta as IEnumerable<int>;


                if (enumerable != null)
                {
                    foreach (int numero
                             in enumerable)
                    {
                        resultado.Add(numero);
                    }


                    return resultado;
                }
            }
            catch
            {
                // Si no existe el metodo o no puede ejecutarse,
                // devolvemos una lista vacia.
            }


            return resultado;
        }


        // =====================================================
        // BLOQUEAR TODOS LOS BOTONES
        // =====================================================

        private void BloquearTodosLosBotones()
        {
            // IMPORTANTE:
            // NO deshabilitamos este UserControl completo.
            //
            // Si hacemos:
            //
            // this.Enabled = false;
            //
            // despues puede ser complicado volver a habilitar
            // correctamente el control desde la seleccion.
            //
            // Por eso bloqueamos solamente sus botones.

            BloquearBotonesRecursivamente(
                FindForm());
        }


        // =====================================================
        // BLOQUEAR BOTONES RECURSIVAMENTE
        // =====================================================

        private void BloquearBotonesRecursivamente(
            Control contenedor)
        {
            if (contenedor == null)
            {
                return;
            }


            foreach (Control control
                     in contenedor.Controls)
            {
                // -------------------------------------------------
                // CONTROLES QUE EMPIEZAN CON Btn
                // -------------------------------------------------

                if (!string.IsNullOrEmpty(
                        control.Name) &&
                    control.Name.StartsWith(
                        "Btn",
                        StringComparison.OrdinalIgnoreCase))
                {
                    control.Enabled = false;
                }


                // -------------------------------------------------
                // BUTTONS NORMALES
                // -------------------------------------------------

                if (control is ButtonBase)
                {
                    control.Enabled = false;
                }


                // -------------------------------------------------
                // CONTROLES INTERNOS
                // -------------------------------------------------

                if (control.HasChildren)
                {
                    BloquearBotonesRecursivamente(
                        control);
                }
            }
        }


        // =====================================================
        // RESTAURAR TODOS LOS BOTONES
        // =====================================================

        private void RestaurarTodosLosBotones()
        {
            Control formulario =
                FindForm();


            if (formulario == null)
            {
                return;
            }


            HabilitarBotonesRecursivamente(
                formulario);
        }


        // =====================================================
        // HABILITAR BOTONES RECURSIVAMENTE
        // =====================================================

        private void HabilitarBotonesRecursivamente(
            Control contenedor)
        {
            if (contenedor == null)
            {
                return;
            }


            foreach (Control control
                     in contenedor.Controls)
            {
                // -------------------------------------------------
                // CONTROLES QUE EMPIEZAN CON Btn
                // -------------------------------------------------

                if (!string.IsNullOrEmpty(
                        control.Name) &&
                    control.Name.StartsWith(
                        "Btn",
                        StringComparison.OrdinalIgnoreCase))
                {
                    control.Enabled = true;
                }


                // -------------------------------------------------
                // BUTTONS NORMALES
                // -------------------------------------------------

                if (control is ButtonBase)
                {
                    control.Enabled = true;
                }


                // -------------------------------------------------
                // CONTROLES INTERNOS
                // -------------------------------------------------

                if (control.HasChildren)
                {
                    HabilitarBotonesRecursivamente(
                        control);
                }
            }
        }


        // =====================================================
        // MARCAR FILAS DESHABILITADAS
        // =====================================================

        private void MarcarFilasDeshabilitadas()
        {
            try
            {
                if (GridReportes == null)
                {
                    return;
                }


                // -------------------------------------------------
                // OBTENER LISTA SIN LLAMADA DIRECTA AL METODO
                // -------------------------------------------------

                List<int> numerosDeshabilitados =
                    ObtenerNumerosDeshabilitados();


                HashSet<int> deshabilitados =
                    new HashSet<int>(
                        numerosDeshabilitados);


                Font fuenteNormal =
                    GridReportes
                    .DefaultCellStyle
                    .Font
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
                            fila,
                            ColumnaNumeroReporte);


                    int numero;


                    bool estaDeshabilitado =
                        valor != null &&
                        int.TryParse(
                            valor.ToString(),
                            out numero) &&
                        deshabilitados.Contains(
                            numero);


                    // -------------------------------------------------
                    // DESHABILITADO
                    // -------------------------------------------------

                    if (estaDeshabilitado)
                    {
                        fila.DefaultCellStyle.BackColor =
                            Color.Gainsboro;


                        fila.DefaultCellStyle.ForeColor =
                            Color.DimGray;


                        fila.DefaultCellStyle.Font =
                            fuenteCursiva;
                    }


                    // -------------------------------------------------
                    // ACTIVO
                    // -------------------------------------------------

                    else
                    {
                        fila.DefaultCellStyle.BackColor =
                            Color.Empty;


                        fila.DefaultCellStyle.ForeColor =
                            Color.Empty;


                        fila.DefaultCellStyle.Font =
                            null;
                    }
                }
            }
            catch
            {
                // El marcado visual no debe detener
                // el funcionamiento del formulario.
            }
        }


        // =====================================================
        // LEER FILA
        // =====================================================

        private ClsReporteSeleccionado LeerFila(
            DataGridViewRow fila)
        {
            try
            {
                // -----------------------------------------
                // NUMERO
                // -----------------------------------------

                object valorNumero =
                    ObtenerValor(
                        fila,
                        ColumnaNumeroReporte);


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
                        ColumnaNumeroReporte +
                        "'.");

                    return null;
                }


                // -----------------------------------------
                // NOMBRE
                // -----------------------------------------

                object valorNombre =
                    ObtenerValor(
                        fila,
                        ColumnaNombreReporte);


                // -----------------------------------------
                // RUTA
                // -----------------------------------------

                object valorRuta =
                    ObtenerValor(
                        fila,
                        ColumnaRutaReporte);


                // -----------------------------------------
                // FECHA
                // -----------------------------------------

                object valorFecha =
                    ObtenerValor(
                        fila,
                        ColumnaFechaReporte);


                DateTime fechaReporte;


                if (valorFecha == null ||
                    !DateTime.TryParse(
                        valorFecha.ToString(),
                        out fechaReporte))
                {
                    fechaReporte =
                        DateTime.Now.Date;
                }


                // -----------------------------------------
                // OBJETO
                // -----------------------------------------

                return new ClsReporteSeleccionado
                {
                    NumeroReporte =
                        numeroReporte,


                    NombreReporte =
                        valorNombre == null
                            ? ""
                            : valorNombre.ToString(),


                    RutaReporte =
                        valorRuta == null
                            ? ""
                            : valorRuta.ToString(),


                    FechaReporte =
                        fechaReporte
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


        // =====================================================
        // OBTENER VALOR DE CELDA
        // =====================================================

        private object ObtenerValor(
            DataGridViewRow fila,
            string nombreColumna)
        {
            if (fila == null)
            {
                return null;
            }


            if (string.IsNullOrWhiteSpace(
                nombreColumna))
            {
                return null;
            }


            if (fila.DataGridView == null)
            {
                return null;
            }


            if (!fila.DataGridView
                .Columns.Contains(
                    nombreColumna))
            {
                return null;
            }


            return fila.Cells[
                nombreColumna].Value;
        }


        // =====================================================
        // RECARGAR TABLA
        // =====================================================

        private void RecargarTabla()
        {
            try
            {
                Form contenedor =
                    FindForm();


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
                    metodo.Invoke(
                        contenedor,
                        null);

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
        // MENSAJE DE EXITO
        // =====================================================

        private void MostrarExito(
            string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "Operacion exitosa",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        // =====================================================
        // MENSAJE DE ERROR
        // =====================================================

        private void MostrarError(
            string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "Ocurrio un error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }


        // =====================================================
        // CONFIRMACION
        // =====================================================

        private bool MostrarConfirmacion(
            string mensaje)
        {
            DialogResult resultado =
                MessageBox.Show(
                    mensaje,
                    "Confirmar deshabilitacion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);


            return resultado ==
                   DialogResult.Yes;
        }
    }
}