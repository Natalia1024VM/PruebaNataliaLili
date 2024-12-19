using CapaDal;
using CapaServicios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaNatalia.Servicios
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly ApplicationDbContext conection;
        public ReporteController(ApplicationDbContext conection)
        {
            this.conection = conection;
        }
        [HttpGet("reporte")]
        public IActionResult Get()
        {
            ReporteServicio reporteServicio = new ReporteServicio();
            var cuentaContieneNombre = reporteServicio.ConsultarReporte(conection).Where(x=> x.Estado == false).Count();
            var cuentaNoContieneNombre= reporteServicio.ConsultarReporte(conection).Where(x => x.Estado == true).Count();
            var relacion = cuentaContieneNombre / (double)(cuentaContieneNombre + cuentaNoContieneNombre);

            var reporte = new
            {
                cuenta_contieneNombre = cuentaContieneNombre,
                cuenta_noContieneNombre = cuentaNoContieneNombre,
                relacion = relacion
            };

            return Ok(reporte);
        }
    }
}
