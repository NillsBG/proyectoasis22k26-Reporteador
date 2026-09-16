using CapaModelo_BtnLimpiar.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControlador_BtnLimpiar
{
    public class ClsModeloBtnLimpiar
    {
        private readonly ClsRepositorioBtnLimpiar repositorio;

        public ClsModeloBtnLimpiar()
        {
            repositorio =
                new ClsRepositorioBtnLimpiar();
        }

        public bool EjecutarLimpieza(
            out string mensaje)
        {
            bool resultado =
                repositorio.LimpiarDatos(
                    out string error);

            if (resultado)
            {
                mensaje =
                    "Los campos fueron limpiados correctamente.";

                return true;
            }

            mensaje = error;

            return false;
        }
    }
}
