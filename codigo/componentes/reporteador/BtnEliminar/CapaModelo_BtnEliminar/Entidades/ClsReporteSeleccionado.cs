using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_BtnEliminar.Entidades
{
    // Representa la fila que el usuario selecciono
    // en el DataGridView del formulario.

    public class ClsReporteSeleccionado
    {
        public int NumeroReporte { get; set; }

        public string NombreReporte { get; set; }

        public string RutaReporte { get; set; }

        public DateTime FechaReporte { get; set; }
    }
}