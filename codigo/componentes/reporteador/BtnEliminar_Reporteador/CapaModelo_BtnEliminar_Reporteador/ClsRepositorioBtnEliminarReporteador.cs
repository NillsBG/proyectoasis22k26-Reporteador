using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_BtnEliminar_Reporteador
{
    public class ClsRepositorioBtnEliminarReporteador
        : ClsRepositorio
    {

        public bool ReporteadorMetEstaDeshabilitado(
            int numeroReporte)
        {
            return ReporteadorMetLeerNumeros()
                .Contains(numeroReporte);
        }


        public void ReporteadorMetDeshabilitar(
            int numeroReporte)
        {
            List<int> actuales =
                ReporteadorMetLeerNumeros();

            if (actuales.Contains(numeroReporte))
            {
                // Ya estaba, no se duplica.
                return;
            }

            actuales.Add(numeroReporte);

            ReporteadorMetEscribirNumeros(actuales);
        }


        public IEnumerable<int> ReporteadorMetObtenerTodos()
        {
            return ReporteadorMetLeerNumeros();
        }
    }
}