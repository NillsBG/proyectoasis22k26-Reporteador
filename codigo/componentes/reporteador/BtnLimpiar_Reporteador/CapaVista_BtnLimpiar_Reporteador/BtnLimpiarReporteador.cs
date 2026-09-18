using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador_BtnLimpiar_Reporteador;

namespace CapaVista_BtnLimpiar_Reporteador
{
    public partial class BtnLimpiarReporteador : UserControl
    {
        private readonly ClsModeloBtnLimpiarReporteador _Controlador;

        public BtnLimpiarReporteador()
        {
            InitializeComponent();

            _Controlador = new ClsModeloBtnLimpiarReporteador();
        }

        private void ReporteadorMetLimpiarClick(object Sender, EventArgs E)
        {
            bool Resultado = _Controlador.ReporteadorFuncEjecutarLimpieza(out string Mensaje);

            if (Resultado)
            {
                OnClick(E);
            }
            else
            {
                MessageBox.Show(
                    Mensaje,
                    "Limpiar formulario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}
