using System.Data;
using CapaModelo_BtnActualizar.Repositorios;

namespace CapaControlador_BtnActualizar
{
    public class ClsControladorBtnVerReporte
    {
        private ClsRepositorioBtnActualizar _RepositorioBtnActualizar;

        public ClsControladorBtnVerReporte()
        {
            _RepositorioBtnActualizar = new ClsRepositorioBtnActualizar();
        }

        public DataTable BtnActualizarFuncObtenerReportes()
        {
            return _RepositorioBtnActualizar.BtnActualizarFuncObtenerTodos();
        }
    }
}
