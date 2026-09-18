using CapaModelo_BtnLimpiar_Reporteador.RepositoriosBtnLimpiarReporteador;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControlador_BtnLimpiar_Reporteador
{
    public class ClsModeloBtnLimpiarReporteador
    {
        private readonly ClsRepositorioBtnLimpiarReporteador _Repositorio;

        public ClsModeloBtnLimpiarReporteador()
        {
            _Repositorio = new ClsRepositorioBtnLimpiarReporteador();
        }

  
        public bool ReporteadorFuncEjecutarLimpieza(out string Mensaje)
        {
            bool Resultado = _Repositorio.ReporteadorFuncLimpiarDatos(out string Error);

            if (Resultado)
            {
                Mensaje = "Los campos fueron limpiados correctamente.";
                return true;
            }

            Mensaje = Error;
            return false;
        }
    }
}
