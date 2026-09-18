using System;
using System.Data;
using CapaModelo_BtnBusqueda_Reporteador.Repositorios;

namespace CapaControlador_BtnBusqueda_Reporteador
{
    public class ClsModeloBtnBusquedaReporteador
    {
        private readonly ClsRepositorioBtnBusquedaReporteador repositorio;

        public ClsModeloBtnBusquedaReporteador()
        {
            repositorio = new ClsRepositorioBtnBusquedaReporteador();
        }

        public DataTable BuscarReportes(
            string nombreReporte,
            DateTime? fechaReporte,
            bool buscarPorNombre,
            bool buscarPorFecha)
        {
            return repositorio.BuscarReportes(
                nombreReporte,
                fechaReporte,
                buscarPorNombre,
                buscarPorFecha
            );
        }
    }
}