using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_BtnEliminar.Contratos
{
    // Contrato del repositorio de estado.
    // archivo de texto plano.

    public interface ClsRepositorioDeshabilitar
    {
        bool EstaDeshabilitado(int numeroReporte);

        void Deshabilitar(int numeroReporte);

        IEnumerable<int> ObtenerTodos();
    }
}