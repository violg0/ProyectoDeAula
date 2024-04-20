using Microsoft.AspNetCore.Mvc;
using ProyectoDeAula.Models.Entidades;
using ProyectoDeAula.Models;
using System.Diagnostics;


namespace ProyectoDeAula.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult Factura()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult Crear(Cliente cliente)
        {
            // Aquí puedes agregar validaciones si es necesario

            // Calcula la suma del consumo de agua y la meta de ahorro
            int sumaConsumoAhorro = cliente.consumo_agua + cliente.meta_ahorro;

            // Pasa la suma a la vista
            ViewData["SumaConsumoAhorro"] = sumaConsumoAhorro;

            // Puedes hacer otras operaciones aquí, como guardar el cliente en la base de datos, etc.

            // Devuelve la vista con el resultado
            return View("Registro", cliente);
        }


    }
   
}