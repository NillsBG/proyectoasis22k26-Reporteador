using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_BtnLimpiar.Repositorios
{
    public class ClsRepositorioBtnLimpiar
    {
        public bool LimpiarDatos(
            out string mensajeError)
        {
            mensajeError = string.Empty;

            try
            {

                return true;
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
                return false;
            }
        }
    }
}
