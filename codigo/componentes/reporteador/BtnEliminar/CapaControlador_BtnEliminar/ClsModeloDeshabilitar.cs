using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_BtnEliminar.Contratos;
using CapaModelo_BtnEliminar.Entidades;
using CapaModelo_BtnEliminar.Repositorios;


namespace CapaControlador_BtnEliminar
{
    public class ClsModeloDeshabilitar
        : ClsDeshabilitarReporte
    {
        private readonly ClsRepositorioDeshabilitar
            RepositorioDeshabilitar;

        public ClsModeloDeshabilitar()
        {
            RepositorioDeshabilitar =
                new ClsRepositorioDeshabilitadosArchivo();
        }


        public string Deshabilitar(
            ClsReporteSeleccionado reporte)
        {
            try
            {
                // -----------------------------------------
                // VALIDACIONES
                // -----------------------------------------

                if (reporte == null)
                {
                    return
                        "No hay ningun reporte seleccionado.";
                }

                if (reporte.NumeroReporte <= 0)
                {
                    return
                        "El numero del reporte no es valido.";
                }


                // -----------------------------------------
                // YA ESTABA DESHABILITADO?
                // -----------------------------------------

                if (RepositorioDeshabilitar
                    .EstaDeshabilitado(
                        reporte.NumeroReporte))
                {
                    return
                        "El reporte ya se encuentra " +
                        "deshabilitado.";
                }


                // -----------------------------------------
                // DESHABILITAR
                // -----------------------------------------

                RepositorioDeshabilitar.Deshabilitar(
                    reporte.NumeroReporte);

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


        public IEnumerable<int>
            ObtenerNumerosDeshabilitados()
        {
            try
            {
                return RepositorioDeshabilitar
                    .ObtenerTodos();
            }
            catch (Exception)
            {
                // Si falla la lectura del archivo,
                // simplemente no se pinta ninguna fila.
                return new List<int>();
            }
        }
    }
}