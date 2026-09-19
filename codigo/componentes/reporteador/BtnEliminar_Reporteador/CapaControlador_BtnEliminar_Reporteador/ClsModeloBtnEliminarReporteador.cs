using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaModelo_BtnEliminar_Reporteador;


namespace CapaControlador_BtnEliminar_Reporteador
{
    public class ClsModeloBtnEliminarReporteador
    {
 
        private readonly
            ClsRepositorioBtnEliminarReporteador
            _RepositorioBtnEliminarReporteador;


        public ClsModeloBtnEliminarReporteador()
        {
            _RepositorioBtnEliminarReporteador =
                new ClsRepositorioBtnEliminarReporteador();
        }


        public string ReporteadorMetDeshabilitar(
            int numeroReporte)
        {
            try
            {
                if (numeroReporte <= 0)
                {
                    return
                        "El numero del reporte no es valido.";
                }

                if (_RepositorioBtnEliminarReporteador
                    .ReporteadorMetEstaDeshabilitado(
                        numeroReporte))
                {
                    return
                        "El reporte ya se encuentra " +
                        "deshabilitado.";
                }

                _RepositorioBtnEliminarReporteador
                    .ReporteadorMetDeshabilitar(
                        numeroReporte);

                return null;
            }
            catch (Exception ex)
            {
                return
                    "Ocurrio un error al deshabilitar el " +
                    "reporte." + Environment.NewLine +
                    ex.Message;
            }
        }


        public bool ReporteadorMetEstaDeshabilitado(
            int numeroReporte)
        {
            try
            {
                return _RepositorioBtnEliminarReporteador
                    .ReporteadorMetEstaDeshabilitado(
                        numeroReporte);
            }
            catch (Exception)
            {
                return false;
            }
        }


        public IEnumerable<int>
            ReporteadorMetObtenerNumerosDeshabilitados()
        {
            try
            {
                return _RepositorioBtnEliminarReporteador
                    .ReporteadorMetObtenerTodos();
            }
            catch (Exception)
            {
                return new List<int>();
            }
        }
    }
}