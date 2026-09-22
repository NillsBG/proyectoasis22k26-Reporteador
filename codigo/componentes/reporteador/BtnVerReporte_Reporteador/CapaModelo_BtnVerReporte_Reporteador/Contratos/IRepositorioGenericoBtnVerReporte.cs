using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_BtnVerReporte_Reporteador.Contratos
{
    public interface IRepositorioGenericoBtnVerReporte<Entity> where Entity : class
    {
        IEnumerable<Entity> GetAll();
    }
}
