using System.Data;
using CapaModelo_BtnActualizar.Repositorios;

namespace CapaControlador_BtnActualizar
{
    public class ClsControladorBtnActualizar
    {
        private ClsRepositorioBtnActualizar _RepositorioBtnActualizar;

        public ClsControladorBtnActualizar()
        {
            _RepositorioBtnActualizar = new ClsRepositorioBtnActualizar();
        }

        public DataTable BtnActualizarFuncObtenerReportes()
        {
            return _RepositorioBtnActualizar.BtnActualizarFuncObtenerTodos();
        }
    }
}
