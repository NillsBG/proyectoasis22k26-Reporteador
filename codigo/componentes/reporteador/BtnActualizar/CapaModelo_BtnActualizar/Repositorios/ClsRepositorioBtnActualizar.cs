using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo_BtnActualizar.Repositorios
{
    public class ClsRepositorioBtnActualizar : ClsRepositorio
    {
        private string _ConsultaTodos;

        public ClsRepositorioBtnActualizar()
        {
            _ConsultaTodos =
                "SELECT numeroReporte AS NumeroReporte, " +
                "nombreReporte AS NombreReporte, " +
                "rutaReporte AS RutaReporte, " +
                "fechaReporte AS FechaReporte " +
                "FROM tblReporte";
        }

        public DataTable BtnActualizarFuncObtenerTodos()
        {
            return BtnActualizarMetEjecucionConsulta(
                _ConsultaTodos,
                CommandType.Text);
        }

        public DataTable BtnActualizarMetEjecucionConsulta(
            string ComandoTexto,
            CommandType ComandoTipo)
        {
            return BtnActualizarMetEjecucionConsulta(ComandoTexto, null, ComandoTipo);
        }

        public DataTable BtnActualizarMetEjecucionConsulta(
            string ComandoTexto,
            List<OdbcParameter> Parametros,
            CommandType ComandoTipo)
        {
            DataTable TablaDatos = new DataTable();

            using (OdbcConnection Conexion = BtnActualizarMetObtenerConexion())
            {
                Conexion.Open();

                using (OdbcCommand Comando = new OdbcCommand())
                {
                    Comando.Connection = Conexion;
                    Comando.CommandText = ComandoTexto;
                    Comando.CommandType = ComandoTipo;

                    if (Parametros != null)
                    {
                        Comando.Parameters.AddRange(Parametros.ToArray());
                    }

                    using (OdbcDataReader Lector = Comando.ExecuteReader())
                    {
                        TablaDatos.Load(Lector);
                    }
                }

                return TablaDatos;
            }
        }
    }
}
