using System.Data.Odbc;

namespace CapaModelo_BtnRuta_Reporteador.Repositorios
{
    public abstract class ClsRepositorioReporteador
    {
        protected readonly string ConnectionString;

        protected ClsRepositorioReporteador()
        {
            ConnectionString = "Dsn=dbreporteador";
        }

        protected OdbcConnection ReporteadorMetObtenerConexion()
        {
            return new OdbcConnection(ConnectionString);
        }
    }
}