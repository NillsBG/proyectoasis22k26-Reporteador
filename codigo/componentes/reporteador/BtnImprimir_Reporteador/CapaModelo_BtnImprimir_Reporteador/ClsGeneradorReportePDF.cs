using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Reporting.WinForms;

namespace CapaModelo_BtnImprimir_Reporteador
{
    public class ClsGeneradorReportePDF
    {
        public byte[] ReporteadorMetGenerarPDF(
            string RutaRDLC)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(RutaRDLC))
                {
                    throw new Exception(
                        "No se proporcionó la ruta del reporte.");
                }

                RutaRDLC =
                    RutaRDLC.Trim();

                if (!File.Exists(RutaRDLC))
                {
                    throw new Exception(
                        "No existe el archivo RDLC seleccionado.");
                }

                if (!Path.GetExtension(RutaRDLC)
                    .Equals(
                        ".rdlc",
                        StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception(
                        "El archivo seleccionado no es un reporte RDLC.");
                }

                LocalReport Reporte =
                    new LocalReport();

                Reporte.ReportPath =
                    RutaRDLC;

                Reporte.DataSources.Clear();

                ReporteadorMetCargarDataSets(
                    Reporte,
                    RutaRDLC);

                Reporte.Refresh();

                Warning[] Warnings;
                string[] Streams;
                string MimeType;
                string Encoding;
                string Extension;

                byte[] ArchivoPDF =
                    Reporte.Render(
                        "PDF",
                        null,
                        out MimeType,
                        out Encoding,
                        out Extension,
                        out Streams,
                        out Warnings);

                if (ArchivoPDF == null ||
                    ArchivoPDF.Length == 0)
                {
                    throw new Exception(
                        "El PDF generado está vacío.");
                }

                return ArchivoPDF;
            }
            catch (Exception Ex)
            {
                string Mensaje =
                    ReporteadorMetObtenerMensajeCompleto(
                        Ex);

                throw new Exception(
                    "No se pudo convertir el RDLC a PDF."
                    + Environment.NewLine
                    + Environment.NewLine
                    + Mensaje,
                    Ex);
            }
        }

        private void ReporteadorMetCargarDataSets(
            LocalReport Reporte,
            string RutaRDLC)
        {
            try
            {
                IList<string> NombresDataSet =
                    Reporte.GetDataSourceNames();

                if (NombresDataSet == null ||
                    NombresDataSet.Count == 0)
                {
                    return;
                }

                XDocument Documento =
                    XDocument.Load(
                        RutaRDLC);

                foreach (string NombreDataSet
                    in NombresDataSet)
                {
                    DataTable Tabla =
                        ReporteadorMetCrearTablaDataSet(
                            Documento,
                            NombreDataSet);

                    ReportDataSource FuenteDatos =
                        new ReportDataSource(
                            NombreDataSet,
                            Tabla);

                    Reporte.DataSources.Add(
                        FuenteDatos);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(
                    "No se pudieron preparar los DataSet del RDLC."
                    + Environment.NewLine
                    + Ex.Message,
                    Ex);
            }
        }

        private DataTable ReporteadorMetCrearTablaDataSet(
            XDocument Documento,
            string NombreDataSet)
        {
            DataTable Tabla =
                new DataTable(
                    NombreDataSet);

            XElement DataSet =
                Documento
                    .Descendants()
                    .FirstOrDefault(
                        Elemento =>
                            Elemento.Name.LocalName
                                .Equals(
                                    "DataSet",
                                    StringComparison.OrdinalIgnoreCase)
                            &&
                            Elemento.Attribute("Name") != null
                            &&
                            Elemento.Attribute("Name").Value
                                .Equals(
                                    NombreDataSet,
                                    StringComparison.OrdinalIgnoreCase));

            if (DataSet == null)
            {
                return Tabla;
            }

            IEnumerable<XElement> Campos =
                DataSet
                    .Descendants()
                    .Where(
                        Elemento =>
                            Elemento.Name.LocalName
                                .Equals(
                                    "Field",
                                    StringComparison.OrdinalIgnoreCase));

            foreach (XElement Campo in Campos)
            {
                XAttribute NombreCampo =
                    Campo.Attribute("Name");

                if (NombreCampo == null)
                {
                    continue;
                }

                string Nombre =
                    NombreCampo.Value;

                if (string.IsNullOrWhiteSpace(
                    Nombre))
                {
                    continue;
                }

                if (!Tabla.Columns.Contains(
                    Nombre))
                {
                    Tabla.Columns.Add(
                        Nombre,
                        typeof(object));
                }
            }

            return Tabla;
        }

        private string ReporteadorMetObtenerMensajeCompleto(
            Exception Ex)
        {
            string Mensaje =
                string.Empty;

            Exception ErrorActual =
                Ex;

            while (ErrorActual != null)
            {
                if (!string.IsNullOrWhiteSpace(
                    ErrorActual.Message))
                {
                    if (!string.IsNullOrWhiteSpace(
                        Mensaje))
                    {
                        Mensaje +=
                            Environment.NewLine
                            + Environment.NewLine;
                    }

                    Mensaje +=
                        ErrorActual.GetType().Name
                        + ": "
                        + ErrorActual.Message;
                }

                ErrorActual =
                    ErrorActual.InnerException;
            }

            return Mensaje;
        }

        public string ReporteadorMetGuardarPDF(
            byte[] ArchivoPDF,
            string RutaPDF)
        {
            try
            {
                if (ArchivoPDF == null ||
                    ArchivoPDF.Length == 0)
                {
                    throw new Exception(
                        "El archivo PDF está vacío.");
                }

                if (string.IsNullOrWhiteSpace(
                    RutaPDF))
                {
                    throw new Exception(
                        "No se proporcionó la ruta del PDF.");
                }

                RutaPDF =
                    RutaPDF.Trim();

                string Carpeta =
                    Path.GetDirectoryName(
                        RutaPDF);

                if (!string.IsNullOrWhiteSpace(
                    Carpeta))
                {
                    Directory.CreateDirectory(
                        Carpeta);
                }

                File.WriteAllBytes(
                    RutaPDF,
                    ArchivoPDF);

                if (!File.Exists(
                    RutaPDF))
                {
                    throw new Exception(
                        "No se pudo crear el PDF.");
                }

                FileInfo InformacionPDF =
                    new FileInfo(
                        RutaPDF);

                if (InformacionPDF.Length == 0)
                {
                    throw new Exception(
                        "El archivo PDF generado está vacío.");
                }

                return RutaPDF;
            }
            catch (Exception Ex)
            {
                throw new Exception(
                    "No se pudo guardar el PDF."
                    + Environment.NewLine
                    + Environment.NewLine
                    + Ex.Message,
                    Ex);
            }
        }
    }
}