using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_BtnEliminar.Contratos
{
    // Contrato del repositorio de estado.
    // No implica ninguna tecnologia de almacenamiento
    // en particular. La implementacion actual
    // (ClsRepositorioDeshabilitadosArchivo) usa un
    // archivo de texto plano.

    public interface ClsRepositorioDeshabilitar
    {
        bool EstaDeshabilitado(int numeroReporte);

        void Deshabilitar(int numeroReporte);

        IEnumerable<int> ObtenerTodos();
    }
}