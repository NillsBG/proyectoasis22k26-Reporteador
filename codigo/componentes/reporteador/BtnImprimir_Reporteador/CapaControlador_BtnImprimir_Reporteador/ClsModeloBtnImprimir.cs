using System;
using System.IO;

namespace CapaModelo_BtnImprimir_Reporteador
{
    public class ClsModeloBtnImprimir
    {
        public string RutaReporte
        {
            get;
            set;
        }

        public ClsModeloBtnImprimir()
        {
            RutaReporte = string.Empty;
        }

        public bool ReporteadorMetValidarReporte(
            string Ruta,
            out string MensajeError)
        {
            MensajeError = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(Ruta))
                {
                    MensajeError =
                        "No se ha seleccionado un reporte.";

                    return false;
                }

                Ruta = Ruta.Trim();

                if (!File.Exists(Ruta))
                {
                    MensajeError =
                        "El archivo del reporte no existe.";

                    return false;
                }

                if (!Path.GetExtension(Ruta)
                    .Equals(
                        ".rdlc",
                        StringComparison.OrdinalIgnoreCase))
                {
                    MensajeError =
                        "El archivo seleccionado no es un reporte .rdlc.";

                    return false;
                }

                RutaReporte = Ruta;

                return true;
            }
            catch (UnauthorizedAccessException)
            {
                MensajeError =
                    "No se tiene permiso para acceder al archivo del reporte.";

                return false;
            }
            catch (Exception Ex)
            {
                MensajeError =
                    "No se pudo validar el archivo del reporte."
                    + Environment.NewLine
                    + Ex.Message;

                return false;
            }
        }
    }
}