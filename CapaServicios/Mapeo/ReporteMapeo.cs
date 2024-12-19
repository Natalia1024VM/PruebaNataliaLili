using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDal.Entidad;
using CapaServicios.Models;

namespace CapaServicios.Mapeo
{
    public class ReporteMapeo
    {
        public static Reporte modelEntidad(ReporteModel model)
        {
            if (model != null)
            {

                Reporte entidad = new Reporte();
                entidad.Id = model.Id;
                entidad.Nombre = model.Nombre;
                entidad.Estado = model.Estado;
                return entidad;
            }

            return null;
        }
        public static ReporteModel EntidadModel(Reporte entidad)
        {
            if (entidad != null)
            {

                ReporteModel model = new ReporteModel();
                model.Id = entidad.Id ;
                model.Nombre = entidad.Nombre ;
                model.Estado = entidad.Estado;
                return model;
            }

            return null;
        }
        public static List<ReporteModel> entidadToModel(List<Reporte> entidades)
        {
            if (entidades != null)
            {
                List<ReporteModel> models = new List<ReporteModel>();
                foreach (Reporte entidad in entidades)
                {
                    ReporteModel model = new ReporteModel();

                    model.Id = entidad.Id;
                    model.Nombre = entidad.Nombre;
                    model.Estado = entidad.Estado;
                    models.Add(model);
                }

                return models;
            }

            return null;
        }

    }
}
