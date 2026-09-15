using System.Data.Odbc;

namespace CapaModelo_BtnActualizar.Repositorios
{
    public abstract class ClsRepositorio
    {
        private readonly string _CadenaConexion;

        public ClsRepositorio()
        {
            _CadenaConexion = "Dsn=dbReporteador";
        }

        protected OdbcConnection BtnActualizarMetObtenerConexion()
        {
            return new OdbcConnection(_CadenaConexion);
        }
    }
}
