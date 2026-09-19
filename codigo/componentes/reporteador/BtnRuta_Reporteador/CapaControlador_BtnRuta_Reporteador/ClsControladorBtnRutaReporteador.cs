using CapaModelo_BtnRuta_Reporteador;

namespace CapaControlador_BtnRuta_Reporteador
{
    public class ClsControladorBtnRutaReporteador
    {
        private readonly ClsModeloBtnRutaReporteador _Modelo;

        public ClsControladorBtnRutaReporteador()
        {
            _Modelo = new ClsModeloBtnRutaReporteador();
        }

        public bool ReporteadorMetValidarRuta(string RutaReporte, out string Mensaje)
        {
            return _Modelo.ReporteadorMetValidarRuta(RutaReporte, out Mensaje);
        }
    }
}