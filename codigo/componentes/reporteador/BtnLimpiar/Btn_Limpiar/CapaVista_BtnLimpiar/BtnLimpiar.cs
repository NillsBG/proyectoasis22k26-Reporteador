using CapaControlador_BtnLimpiar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_BtnLimpiar
{
    public partial class BtnLimpiar : UserControl
    {

        private readonly ClsModeloBtnLimpiar controlador;

        public BtnLimpiar()
        {
            InitializeComponent();

            controlador =
                new ClsModeloBtnLimpiar();

            btnAccionLimpiar.Click +=
                BtnAccionLimpiar_Click;
        }

        private void BtnAccionLimpiar_Click(
            object sender,
            EventArgs e)
        {
            bool resultado =
                controlador.EjecutarLimpieza(
                    out string mensaje);

            if (resultado)
            {
                // Avisar al formulario principal
                OnClick(e);
            }
            else
            {
                MessageBox.Show(
                    mensaje,
                    "Limpiar formulario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}