using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_BtnEditar_Reporteador
{
    public partial class BtnEditarReporteador : UserControl
    {
        public TextBox ReporteadorTxtNombreReporte
        {
            get;
            set;
        }

        public TextBox ReporteadorTxtRutaReporte
        {
            get;
            set;
        }

        // Nombre del método del formulario contenedor que debe ejecutarse
        // al hacer clic en "Editar" (por defecto "BtnEditar_Click", que ya
        // existe en FrmReportes: selecciona la fila del grid, llena los
        // textboxes y pone el formulario en modo edición). Se invoca por
        // reflexión, sin depender de que el evento Click de este control
        // esté enlazado en el diseñador del formulario.
        [Category("Reporteador")]
        [DefaultValue("BtnEditar_Click")]
        public string MetodoEditarFormulario { get; set; } = "BtnEditar_Click";

        public BtnEditarReporteador()
        {
            InitializeComponent();

            ReporteadorBtnAccionEditar.Click +=
                ReporteadorMetAccionEditarClick;
        }

        private void ReporteadorMetAccionEditarClick(
            object Sender,
            EventArgs Evento)
        {
            ReporteadorMetInvocarEditarFormulario();

            OnClick(EventArgs.Empty);
        }

        private void ReporteadorMetInvocarEditarFormulario()
        {
            try
            {
                Form contenedor = FindForm();

                if (contenedor == null || string.IsNullOrWhiteSpace(MetodoEditarFormulario))
                {
                    return;
                }

                // El método del formulario (por ejemplo BtnEditar_Click)
                // tiene la firma estándar de un manejador de evento:
                // (object sender, EventArgs e)
                MethodInfo metodo = contenedor.GetType().GetMethod(
                    MetodoEditarFormulario,
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                    null,
                    new[] { typeof(object), typeof(EventArgs) },
                    null);

                if (metodo != null)
                {
                    metodo.Invoke(contenedor, new object[] { contenedor, EventArgs.Empty });
                    return;
                }

                // Alternativa: si el método existe sin parámetros.
                metodo = contenedor.GetType().GetMethod(
                    MetodoEditarFormulario,
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
                    MessageBox.Show(
                        "No se encontró el método '" + MetodoEditarFormulario + "' en el formulario.",
                        "Ocurrió un error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (TargetInvocationException tie) when (tie.InnerException != null)
            {
                MessageBox.Show(
                    "Ocurrió un error al preparar la edición del reporte." + Environment.NewLine + Environment.NewLine + tie.InnerException.Message,
                    "Ocurrió un error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al preparar la edición del reporte." + Environment.NewLine + Environment.NewLine + ex.Message,
                    "Ocurrió un error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}