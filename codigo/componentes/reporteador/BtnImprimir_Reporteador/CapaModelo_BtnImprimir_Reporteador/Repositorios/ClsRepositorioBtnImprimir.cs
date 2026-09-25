using System;
using System.IO;

namespace CapaModelo_BtnImprimir_Reporteador
{
    public class ClsRepositorioBtnImprimir
    {
        public bool ReporteadorMetValidarArchivo(
            string RutaArchivo,
            out string MensajeError)
        {
            MensajeError = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(RutaArchivo))
                {
                    MensajeError =
                        "No se ha seleccionado un reporte.";

                    return false;
                }

                RutaArchivo =
                    RutaArchivo.Trim();

                if (!File.Exists(RutaArchivo))
                {
                    MensajeError =
                        "El archivo del reporte no existe.";

                    return false;
                }

                if (!Path.GetExtension(RutaArchivo)
                    .Equals(
                        ".rdlc",
                        StringComparison.OrdinalIgnoreCase))
                {
                    MensajeError =
                        "El archivo seleccionado no es un archivo .rdlc.";

                    return false;
                }

                return true;
            }
            catch (UnauthorizedAccessException)
            {
                MensajeError =
                    "No se tiene permiso para acceder al reporte.";

                return false;
            }
            catch (Exception Ex)
            {
                MensajeError =
                    "Ocurrió un error al validar el archivo del reporte."
                    + Environment.NewLine
                    + Ex.Message;

                return false;
            }
        }
    }
}