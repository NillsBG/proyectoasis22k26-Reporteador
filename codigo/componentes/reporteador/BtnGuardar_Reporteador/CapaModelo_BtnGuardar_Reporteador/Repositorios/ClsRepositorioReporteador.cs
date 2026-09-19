using System;
using System.Data.Odbc;

namespace CapaModelo_BtnGuardar_Reporteador.Repositorios
{
    public abstract class ClsRepositorioReporteador
    {
        public readonly string connectionString;

        public ClsRepositorioReporteador()
        {
            connectionString = "Dsn=dbreporteador";
        }

        protected OdbcConnection ObtenerConexion()
        {
            return new OdbcConnection(connectionString);
        }
    }
}