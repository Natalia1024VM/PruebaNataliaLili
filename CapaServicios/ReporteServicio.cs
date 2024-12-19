using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDal;
using CapaDal.Entidad;
using CapaServicios.Mapeo;
using CapaServicios.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapaServicios
{
    public class ReporteServicio
    {

        public List<ReporteModel> ConsultarReporte(ApplicationDbContext application)
        {
            ReporteRepositorio reporteRepositorio = new ReporteRepositorio();
            var resultado = reporteRepositorio.ConsultarReporte(application);
            if (resultado.Result != null)
            {
                List<ReporteModel> lista = new List<ReporteModel>();
                foreach (var item in resultado.Result)
                {
                    lista.Add(ReporteMapeo.EntidadModel(item));
                }
                return lista;
            }
            else
            {
                return null;
            }
        }

        public int AgregarReporte(ReporteModel Reporte, ApplicationDbContext application)
        {

            var id = ReporteRepositorio.AgregarReporte(ReporteMapeo.modelEntidad(Reporte), application);

            return id;
        }

    }
}
