using CapaModelo_BtnVerReporte_Reporteador.Entidades;
using CapaModelo_BtnVerReporte_Reporteador.Contratos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace CapaModelo_BtnVerReporte_Reporteador.Repositorios
{
    public class ClsRepositorioBtnVerReporte : ClsRepositorioMaestroBtnVerReporte, IRepositorioBtnVerReporte
    {
        private const string SelectAll = @"SELECT numeroReporte,
                                                  nombreReporte,
                                                  rutaReporte,
                                                  fechaReporte
                                           FROM tblReporte
                                           ORDER BY numeroReporte";

        public IEnumerable<ClsEntidadesBtnVerReporte> GetAll()
        {
            var reportes = new List<ClsEntidadesBtnVerReporte>();
            var tblTabla = EjecucionConsulta(SelectAll, CommandType.Text);
            foreach (DataRow row in tblTabla.Rows)
            {
                reportes.Add(new ClsEntidadesBtnVerReporte
                {
                    NumeroReporte = Convert.ToInt32(row["numeroReporte"]),
                    NombreReporte = Convert.ToString(row["nombreReporte"]),
                    RutaReporte = Convert.ToString(row["rutaReporte"]),
                    FechaReporte = Convert.ToDateTime(row["fechaReporte"])
                });
            }
            return reportes;
        }
    }
}
