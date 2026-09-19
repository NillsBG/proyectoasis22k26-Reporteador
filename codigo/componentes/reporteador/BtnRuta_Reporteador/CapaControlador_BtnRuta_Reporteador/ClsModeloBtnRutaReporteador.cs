using System;
using System.IO;
using CapaModelo_BtnRuta_Reporteador.Repositorios;

namespace CapaModelo_BtnRuta_Reporteador
{
    public class ClsModeloBtnRutaReporteador
    {
        private readonly ClsRepositorioBtnRutaReporteador _Repositorio;

        public ClsModeloBtnRutaReporteador()
        {
            _Repositorio = new ClsRepositorioBtnRutaReporteador();
        }

        public bool ReporteadorMetValidarRuta(string RutaReporte, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(RutaReporte))
            {
                Mensaje = "La ruta del reporte es requerida.";
                return false;
            }

            if (!File.Exists(RutaReporte))
            {
                Mensaje = "El archivo seleccionado no existe.";
                return false;
            }

            string Extension = Path.GetExtension(RutaReporte);

            if (!Extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                Mensaje = "El archivo seleccionado debe ser un documento PDF.";
                return false;
            }

            return true;
        }
    }
}