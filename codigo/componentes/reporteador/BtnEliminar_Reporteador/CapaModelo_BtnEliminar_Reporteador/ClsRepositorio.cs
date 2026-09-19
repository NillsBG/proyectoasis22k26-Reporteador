using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CapaModelo_BtnEliminar_Reporteador
{
    // Clase base: sabe DONDE esta guardado el estado
    // de "deshabilitados" y COMO leerlo/escribirlo.
    // No toca la base de datos. El estado se guarda en
    // un archivo de texto plano junto al ejecutable:
    // un numero de reporte por linea.

    public abstract class ClsRepositorio
    {
 
        protected readonly string _RutaArchivo;

        // Evita choques si dos operaciones intentan
        // leer/escribir el archivo al mismo tiempo.
        private static readonly object _Candado =
            new object();


        public ClsRepositorio()
        {
            _RutaArchivo =
                ReporteadorMetRutaPorDefecto();
        }

        private string ReporteadorMetRutaPorDefecto()
        {
            string carpeta =
                AppDomain.CurrentDomain.BaseDirectory;

            return Path.Combine(
                carpeta,
                "ReportesDeshabilitados.txt");
        }


        protected List<int> ReporteadorMetLeerNumeros()
        {
            lock (_Candado)
            {
                if (!File.Exists(_RutaArchivo))
                {
                    return new List<int>();
                }

                List<int> lista = new List<int>();

                foreach (string linea
                         in File.ReadAllLines(
                             _RutaArchivo))
                {
                    int numero;

                    if (int.TryParse(
                            linea.Trim(),
                            out numero))
                    {
                        lista.Add(numero);
                    }
                }

                return lista;
            }
        }

        protected void ReporteadorMetEscribirNumeros(
            IEnumerable<int> numeros)
        {
            lock (_Candado)
            {
                File.WriteAllLines(
                    _RutaArchivo,
                    numeros
                        .OrderBy(n => n)
                        .Select(n => n.ToString()));
            }
        }
    }
}