using CapaDal;
using CapaServicios;
using CapaServicios.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaNatalia.Servicios
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosController : ControllerBase
    {
        private readonly ApplicationDbContext conection;
        public DatosController(ApplicationDbContext conection)
        {
            this.conection = conection;
        }

        [HttpPost]
        public bool contieneNombre(String[] info, string nombre)
        {
            int filas = info.Length;
            int columnas = info[0].Length;
            bool resultado = false;
            // 1. Buscar en horizontal
            foreach (var fila in info)
            {
                if (fila.Contains(nombre))
                {
                    resultado = true;
                }
            }

            // 2. Buscar en vertical
            for (int col = 0; col < columnas; col++)
            {
                string columna = "";
                for (int fila = 0; fila < filas; fila++)
                {
                    columna += info[fila][col];
                }
                if (columna.Contains(nombre))
                {
                    resultado = true;
                }
            }

            // 3. Buscar en diagonal (\\)
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    // Verificar diagonal hacia abajo derecha (\\)
                    string diagonal = "";
                    int x = i, y = j;
                    while (x < filas && y < columnas)
                    {
                        diagonal += info[x][y];
                        x++;
                        y++;
                    }
                    if (diagonal.Contains(nombre))
                    {
                        resultado = true;
                    }

                    // Verificar diagonal hacia arriba derecha (\\)
                    diagonal = "";
                    x = i;
                    y = j;
                    while (x < filas && y < columnas)
                    {
                        diagonal += info[y][x];
                        x++;
                        y++;
                    }
                    if (diagonal.Contains(nombre))
                    {
                        resultado = true;
                    }

                    // Verificar diagonal hacia arriba izquierda (\\)

                    diagonal = "";
                    x = i; y = j;
                    while (x < filas && y >= 0)
                    {
                        diagonal += info[y][x];
                        x++;
                        y--;
                    }
                    if (diagonal.Contains(nombre))
                    {
                        resultado = true;
                    }

                    // Verificar diagonal hacia abajo izquierda (/)
                    diagonal = "";
                    x = i; y = j;
                    while (x < filas && y >= 0)
                    {
                        diagonal += info[x][y];
                        x++;
                        y--;
                    }
                    if (diagonal.Contains(nombre))
                    {
                        resultado = true;
                    }
                }
            }

            resultado = false;

            ReporteServicio reporteServicio = new ReporteServicio();
            ReporteModel reporteModel = new ReporteModel();
            reporteModel.Nombre = nombre;
            reporteModel.Estado = resultado;
            reporteServicio.AgregarReporte(reporteModel, conection);

            return resultado;
        }

    }
}
