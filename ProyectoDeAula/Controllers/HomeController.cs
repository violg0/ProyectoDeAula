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
            // agregar validaciones si es necesario

            // Calcula la suma del consumo de agua y la meta de ahorro
            int sumaConsumoAhorro = cliente.consumo_agua + cliente.meta_ahorro;

            // Pasa la suma a la vista
            ViewData["SumaConsumoAhorro"] = sumaConsumoAhorro;
            ViewData["SumaConsumoAhorro"] = sumaConsumoAhorro;
            ViewData["Clientes"] = cliente;

            // Devuelve la vista con el resultado
            return View("Registro", cliente);

            // Puedes hacer otras operaciones aquí.
        }

        private static List<Cliente> clientes = new List<Cliente>();

        // Otros miembros del controlador...

        [HttpPost]
        public IActionResult Registrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                GestionClientes.AgregarClientes(clientes, cliente);
                return View("Registro", new Cliente());

            }
            else
            { 
                return View("Registro", cliente);
            }
        }
        public IActionResult MostrarClientes()
        {
            // Aquí obtienes la lista de clientes y la pasas a la vista
            return View("MostrarClientes", clientes);
        }
        public IActionResult TextoClientes()
        {
            var textoClientes = GestionClientes.MostrarClientes(clientes);
            return Content(textoClientes);
        }

    }
}