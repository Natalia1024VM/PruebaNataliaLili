using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PruebaNatalia.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PruebaNatalia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Index(IndexViewModel viewModel, string consulta)
        {
            if (viewModel.Nombre == "" || viewModel.Nombre == null)
            {
                ModelState.AddModelError("", "Nombre Obligatorio");
            }
            else
            {
                string[] info = {
                "ATFVLA",
                "B4KUES",
                "5JNNTY",
                "TAIRF3",
                "ELLJ54",
                "24JKRT" };
                bool resultado = contieneNombre(info, viewModel.Nombre);

                Console.WriteLine(resultado);
                viewModel.Nombre = viewModel.Nombre;
                if (resultado)
                {
                    ModelState.AddModelError("", "El nombre es True");
                }
                else
                {
                    ModelState.AddModelError("", "El nombre es False");

                }
            }
            return View(viewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool contieneNombre(string[] info, string nombre)
        {
            int filas = info.Length;
            int columnas = info[0].Length;

            // 1. Buscar en horizontal
            foreach (var fila in info)
            {
                if (fila.Contains(nombre))
                {
                    return true;
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
                    return true;
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
                        return true;
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
                        return true;
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
                        return true;
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
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
