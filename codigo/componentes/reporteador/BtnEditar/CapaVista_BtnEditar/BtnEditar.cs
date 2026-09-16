using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_BtnEditar
{
    public partial class BtnEditar : UserControl
    {
        public TextBox TxtNombreReporte { get; set; }

        public TextBox TxtRutaReporte { get; set; }

        public BtnEditar()
        {
            InitializeComponent();

            RtnEditarReporte.Click += BtnAccionEditar_Click;
        }

        private void BtnAccionEditar_Click(object sender, EventArgs e)
        {
            OnClick(EventArgs.Empty);
        }
    }
}
