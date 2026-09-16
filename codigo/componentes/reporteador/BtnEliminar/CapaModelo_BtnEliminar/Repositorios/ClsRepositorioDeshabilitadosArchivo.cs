using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaModelo_BtnEliminar.Contratos;
using System.IO;


namespace CapaModelo_BtnEliminar.Repositorios
{
    // NO toca la base de datos. El estado "deshabilitado"
    // se guarda en un archivo de texto plano: un numero
    // de reporte por linea.
    //
    // Ejemplo de contenido de ReportesDeshabilitados.txt:
    //     3001
    //     3005
    //     3012

    public class ClsRepositorioDeshabilitadosArchivo
        : ClsRepositorioDeshabilitar
    {
        private readonly string rutaArchivo;

        // Evita choques si dos operaciones intentan
        // leer/escribir el archivo al mismo tiempo.
        private static readonly object candado =
            new object();


        public ClsRepositorioDeshabilitadosArchivo()
            : this(RutaPorDefecto())
        {
        }


        public ClsRepositorioDeshabilitadosArchivo(
            string rutaArchivo)
        {
            this.rutaArchivo = rutaArchivo;
        }


        // Carpeta donde corre el ejecutable
        // (o donde este cargada la DLL).
        private static string RutaPorDefecto()
        {
            string carpeta =
                AppDomain.CurrentDomain.BaseDirectory;

            return Path.Combine(
                carpeta,
                "ReportesDeshabilitados.txt");
        }


        public bool EstaDeshabilitado(
            int numeroReporte)
        {
            lock (candado)
            {
                return ObtenerTodos()
                    .Contains(numeroReporte);
            }
        }


        public void Deshabilitar(int numeroReporte)
        {
            lock (candado)
            {
                HashSet<int> actuales =
                    new HashSet<int>(ObtenerTodos());

                if (actuales.Contains(numeroReporte))
                {
                    // Ya estaba, no se duplica.
                    return;
                }

                actuales.Add(numeroReporte);

                File.WriteAllLines(
                    rutaArchivo,
                    actuales
                        .OrderBy(n => n)
                        .Select(n => n.ToString()));
            }
        }


        public IEnumerable<int> ObtenerTodos()
        {
            lock (candado)
            {
                if (!File.Exists(rutaArchivo))
                {
                    return new List<int>();
                }

                List<int> lista = new List<int>();

                foreach (string linea
                         in File.ReadAllLines(
                             rutaArchivo))
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
    }
}