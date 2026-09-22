using CapaModelo_BtnVerReporte_Reporteador.Repositorios;
using System.Collections.Generic;
using CapaModelo_BtnVerReporte_Reporteador.Entidades;

namespace CapaControlador_BtnVerReporte_Reporteador
{
    public class ClsControladorBtnVerReporte
    {
        private readonly ClsRepositorioBtnVerReporte _Repositorio;

        public ClsControladorBtnVerReporte()
        {
            _Repositorio = new ClsRepositorioBtnVerReporte();
        }

        public List<ClsEntidadesBtnVerReporte> GetAll()
        {
            return new List<ClsEntidadesBtnVerReporte>(_Repositorio.GetAll());
        }
    }
}
