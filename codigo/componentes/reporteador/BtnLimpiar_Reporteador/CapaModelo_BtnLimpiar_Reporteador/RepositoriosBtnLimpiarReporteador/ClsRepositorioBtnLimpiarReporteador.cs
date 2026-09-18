using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_BtnLimpiar_Reporteador.RepositoriosBtnLimpiarReporteador
{
    public class ClsRepositorioBtnLimpiarReporteador
    {
        public bool ReporteadorFuncLimpiarDatos(out string MensajeError)
        {
            MensajeError = string.Empty;

            try
            {
                return true;
            }
            catch (Exception Ex)
            {
                MensajeError = Ex.Message;
                return false;
            }
        }
    }
}
