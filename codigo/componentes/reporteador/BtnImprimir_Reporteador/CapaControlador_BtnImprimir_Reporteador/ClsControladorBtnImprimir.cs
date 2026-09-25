using System;
using CapaModelo_BtnImprimir_Reporteador;

namespace CapaControlador_BtnImprimir_Reporteador
{
    public class ClsControladorBtnImprimir
    {
        private readonly ClsModeloBtnImprimir
            _Modelo;

        private readonly ClsRepositorioBtnImprimir
            _Repositorio;

        private readonly ClsGeneradorReportePDF
            _GeneradorPDF;

        public ClsControladorBtnImprimir()
        {
            _Modelo =
                new ClsModeloBtnImprimir();

            _Repositorio =
                new ClsRepositorioBtnImprimir();

            _GeneradorPDF =
                new ClsGeneradorReportePDF();
        }

        public bool ReporteadorMetEjecutarImpresion(
            string RutaReporte,
            out string Mensaje)
        {
            Mensaje =
                string.Empty;

            try
            {
                if (!_Repositorio
                    .ReporteadorMetValidarArchivo(
                        RutaReporte,
                        out Mensaje))
                {
                    return false;
                }

                _Modelo.RutaReporte =
                    RutaReporte.Trim();

                return true;
            }
            catch (Exception Ex)
            {
                Mensaje =
                    "Ocurrió un error al preparar el reporte."
                    + Environment.NewLine
                    + Ex.Message;

                return false;
            }
        }

        public bool ReporteadorMetGenerarPDF(
            string RutaReporte,
            string RutaPDF,
            out string Mensaje)
        {
            Mensaje =
                string.Empty;

            try
            {
                if (!_Repositorio
                    .ReporteadorMetValidarArchivo(
                        RutaReporte,
                        out Mensaje))
                {
                    return false;
                }

                byte[] ArchivoPDF =
                    _GeneradorPDF
                        .ReporteadorMetGenerarPDF(
                            RutaReporte);

                _GeneradorPDF
                    .ReporteadorMetGuardarPDF(
                        ArchivoPDF,
                        RutaPDF);

                return true;
            }
            catch (Exception Ex)
            {
                Mensaje =
                    Ex.Message;

                return false;
            }
        }
    }
}