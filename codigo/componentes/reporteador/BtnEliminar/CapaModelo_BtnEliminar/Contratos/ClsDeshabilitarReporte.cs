using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaModelo_BtnEliminar.Entidades;

namespace CapaModelo_BtnEliminar.Contratos
{
    public interface ClsDeshabilitarReporte
    {
        // Devuelve null si todo salio bien,
        // o el mensaje de error si algo fallo.
        string Deshabilitar(
            ClsReporteSeleccionado reporte);

        // Numeros de reporte marcados como
        // deshabilitados. Lo usa la Vista para
        // pintar las filas del grid.
        IEnumerable<int> ObtenerNumerosDeshabilitados();
    }
}