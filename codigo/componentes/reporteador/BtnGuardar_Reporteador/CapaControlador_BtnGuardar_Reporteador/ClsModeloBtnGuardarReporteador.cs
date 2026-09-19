using System;
using CapaModelo_BtnGuardar_Reporteador.Repositorios;

namespace CapaControlador_BtnGuardar_Reporteador
{
    public class ClsModeloBtnGuardarReporteador
    {
        private readonly ClsRepositorioBtnGuardarReporteador _Repositorio;

        public ClsModeloBtnGuardarReporteador()
        {
            _Repositorio = new ClsRepositorioBtnGuardarReporteador();
        }

        public string ReporteadorMetGuardar(int numeroReporte, string nombreReporte, string rutaReporte, DateTime fechaReporte, bool esEdicion)
        {
            if (numeroReporte <= 0)
            {
                return "El número de reporte debe ser mayor a cero.";
            }

            if (string.IsNullOrWhiteSpace(nombreReporte))
            {
                return "El nombre del reporte no puede estar vacío.";
            }

            if (string.IsNullOrWhiteSpace(rutaReporte))
            {
                return "La ruta del reporte es requerida.";
            }

            bool exito = _Repositorio.ReporteadorMetGuardarReporte(numeroReporte, nombreReporte, rutaReporte, fechaReporte, esEdicion, out string errorBD);

            if (exito)
            {
                return string.Empty; // Vacío indica éxito
            }
            else
            {
                return errorBD;
            }
        }
    }
}