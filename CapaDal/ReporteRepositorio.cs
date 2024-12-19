using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDal.Entidad;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CapaDal
{
    public class ReporteRepositorio
    {
        public async Task<List<Reporte>> ConsultarReporte(ApplicationDbContext conection)
        {
            var ListaResultado = conection.Reporte
                .FromSqlInterpolated($"Exec SP_ConsultarReportes")
                .AsAsyncEnumerable();

            List<Reporte> Lista = new List<Reporte>();

            await foreach (var item in ListaResultado)
            {
                Lista.Add(item);
            }
            return Lista;
        }

        public static int AgregarReporte(Reporte Reporte, ApplicationDbContext conection)
        {
            var id = 0;
            var parametroID = new SqlParameter("@resultado", SqlDbType.Int);
            parametroID.Direction = ParameterDirection.Output;

            conection.Database
                .ExecuteSqlInterpolatedAsync($@"Exec SP_InsertarReporte
                                             @Nombre={Reporte.Nombre}, @Estado={Reporte.Estado}, 
                                             @resultado={parametroID} OUTPUT");

            System.Threading.Thread.Sleep(100);

            if (parametroID.SqlValue != null)
            {
                string valor = parametroID.SqlValue.ToString();
                id = Convert.ToInt32(valor);
            }
            return id;
        }
    }
}
