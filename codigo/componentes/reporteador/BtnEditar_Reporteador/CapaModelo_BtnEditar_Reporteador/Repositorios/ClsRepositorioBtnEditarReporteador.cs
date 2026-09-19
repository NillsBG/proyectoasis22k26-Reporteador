using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_BtnEditar_Reporteador.Repositorios
{
    public class ClsRepositorioBtnEditarReporteador : ClsRepositorioReporteador
    {
        public bool ReporteadorMetEditarReporte(
            int NumeroReporte,
            string NombreReporte,
            string RutaReporte,
            DateTime FechaReporte,
            out string MensajeError)
        {
            MensajeError = string.Empty;

            string Query =
                @"UPDATE tblReporte
                  SET nombreReporte = ?,
                      rutaReporte = ?,
                      fechaReporte = ?
                  WHERE numeroReporte = ?";

            try
            {
                using (OdbcConnection Conexion =
                    ReporteadorMetObtenerConexion())
                {
                    Conexion.Open();

                    using (OdbcCommand Comando =
                        new OdbcCommand())
                    {
                        Comando.Connection =
                            Conexion;

                        Comando.CommandType =
                            CommandType.Text;

                        Comando.CommandText =
                            Query;

                        Comando.Parameters.Add(
                            new OdbcParameter(
                                "p_nombreReporte",
                                NombreReporte));

                        Comando.Parameters.Add(
                            new OdbcParameter(
                                "p_rutaReporte",
                                RutaReporte));

                        Comando.Parameters.Add(
                            new OdbcParameter(
                                "p_fechaReporte",
                                FechaReporte.Date));

                        Comando.Parameters.Add(
                            new OdbcParameter(
                                "p_numeroReporte",
                                NumeroReporte));

                        int FilasAfectadas =
                            Comando.ExecuteNonQuery();

                        return FilasAfectadas > 0;
                    }
                }
            }
            catch (Exception Excepcion)
            {
                MensajeError =
                    Excepcion.Message;

                return false;
            }
        }
    }
}
