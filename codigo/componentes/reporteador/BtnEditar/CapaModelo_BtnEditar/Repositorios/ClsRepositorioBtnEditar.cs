using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_BtnEditar.Repositorios
{
    public class ClsRepositorioBtnEditar : ClsRepositorio
    {
        public bool EditarReporte(
            int numeroReporte,
            string nombreReporte,
            string rutaReporte,
            DateTime fechaReporte,
            out string mensajeError)
        {
            mensajeError = string.Empty;

            string query =
                @"UPDATE tblReporte
                  SET nombreReporte = ?,
                      rutaReporte = ?,
                      fechaReporte = ?
                  WHERE numeroReporte = ?";

            try
            {
                using (var conexion =
                    ObtenerConexion())
                {
                    conexion.Open();

                    using (var comando =
                        new OdbcCommand())
                    {
                        comando.Connection =
                            conexion;

                        comando.CommandType =
                            CommandType.Text;

                        comando.CommandText =
                            query;

                        comando.Parameters.Add(
                            new OdbcParameter(
                                "p_nombreReporte",
                                nombreReporte));

                        comando.Parameters.Add(
                            new OdbcParameter(
                                "p_rutaReporte",
                                rutaReporte));

                        comando.Parameters.Add(
                            new OdbcParameter(
                                "p_fechaReporte",
                                fechaReporte.Date));

                        comando.Parameters.Add(
                            new OdbcParameter(
                                "p_numeroReporte",
                                numeroReporte));

                        int filasAfectadas =
                            comando.ExecuteNonQuery();

                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;

                return false;
            }
        }
    }

}
