using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_BtnEditar_Reporteador.Repositorios
{
    public abstract class ClsRepositorioReporteador
    {
        public readonly string _ConnectionString;

        public ClsRepositorioReporteador()
        {
            _ConnectionString =
                "Dsn=dbreporteador";
        }

        protected OdbcConnection ReporteadorMetObtenerConexion()
        {
            return new OdbcConnection(
                _ConnectionString
            );
        }
    }
}
