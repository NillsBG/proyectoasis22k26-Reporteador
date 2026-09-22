using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_BtnVerReporte_Reporteador.Repositorios
{
    public abstract class ClsRepositorioMaestroBtnVerReporte : ClsRepositorio
    {
        private DataTable dtTablaDatos;
        public DataTable EjecucionConsulta(string _comandoTexto, CommandType _comandoTipo)
        {
            dtTablaDatos = new DataTable();
            using (var conexion = BtnVerReporteMetObtenerConexion())
            {
                conexion.Open();
                using (var ocComando = new OdbcCommand())
                {
                    ocComando.Connection = conexion;
                    ocComando.CommandText = _comandoTexto;
                    ocComando.CommandType = _comandoTipo;
                    using (var reader = ocComando.ExecuteReader())
                        dtTablaDatos.Load(reader);
                }
                return dtTablaDatos;
            }
        }
    }
}
