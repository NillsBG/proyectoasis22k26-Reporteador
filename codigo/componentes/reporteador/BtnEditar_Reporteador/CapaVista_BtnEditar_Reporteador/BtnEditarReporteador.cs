using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            OnClick(EventArgs.Empty);
        }
    }
}
