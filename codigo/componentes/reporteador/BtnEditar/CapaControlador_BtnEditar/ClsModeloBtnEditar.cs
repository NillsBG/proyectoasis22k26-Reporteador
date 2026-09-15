using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_BtnEditar.Repositorios;

namespace CapaControlador_BtnEditar
{
    public class ClsModeloBtnEditar
    {
        private readonly
            ClsRepositorioBtnEditar repositorio;

        public ClsModeloBtnEditar()
        {
            repositorio =
                new ClsRepositorioBtnEditar();
        }

        public bool EjecutarEdicion(
            int numeroReporte,
            string nombreReporte,
            string rutaReporte,
            DateTime fechaReporte,
            out string mensaje)
        {
            if (numeroReporte <= 0)
            {
                mensaje =
                    "Debe seleccionar un reporte.";

                return false;
            }

            if (string.IsNullOrWhiteSpace(
                nombreReporte))
            {
                mensaje =
                    "El nombre del reporte no puede estar vacío.";

                return false;
            }

            if (string.IsNullOrWhiteSpace(
                rutaReporte))
            {
                mensaje =
                    "La ruta del reporte es requerida.";

                return false;
            }

            bool exito =
                repositorio.EditarReporte(
                    numeroReporte,
                    nombreReporte,
                    rutaReporte,
                    fechaReporte,
                    out string errorBD);

            if (exito)
            {
                mensaje =
                    "Actualización exitosa";

                return true;
            }

            mensaje = errorBD;

            return false;
        }
    }

}
