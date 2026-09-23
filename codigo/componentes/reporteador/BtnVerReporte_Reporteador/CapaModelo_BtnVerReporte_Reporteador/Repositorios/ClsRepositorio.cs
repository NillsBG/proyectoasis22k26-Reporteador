using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_BtnVerReporte_Reporteador.Repositorios
{
    public abstract class ClsRepositorio
    {
        private readonly string _CadenaConexion;

        public ClsRepositorio()
        {
            _CadenaConexion = "Dsn=dbReporteador";
        }

        protected OdbcConnection BtnVerReporteMetObtenerConexion()
        {
            return new OdbcConnection(_CadenaConexion);
        }
    }
}
