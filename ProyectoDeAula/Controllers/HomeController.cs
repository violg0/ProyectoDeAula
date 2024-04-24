using Microsoft.AspNetCore.Mvc;
using ProyectoDeAula.Models.Entidades;
using ProyectoDeAula.Models;
using System.Diagnostics;
using ProyectoDeAula_JulianaAlvarezVioletaAgudelo.Models.Entidades;


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

        public IActionResult Datos()
        {
            ViewData["Title"] = "Informacion";
            return View();
        }

        public IActionResult Factura()
        {
            return View();
        }

        public IActionResult RegistrarCliente() 
        { 
            return PartialView("RegistrarCliente");
        }

        public IActionResult ConsumoAgua()
        {
            return PartialView("ConsumoAgua");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult Crear(Cliente cliente)
        {
            
            int sumaConsumoAhorro = cliente.consumo_agua + cliente.meta_ahorro;

            ViewData["SumaConsumoAhorro"] = sumaConsumoAhorro;
            ViewData["SumaConsumoAhorro"] = sumaConsumoAhorro;
            ViewData["Clientes"] = cliente;

         
            return View("Registro", cliente);

        }

        private static List<Cliente> clientes = new List<Cliente>();


        [HttpPost]
        public IActionResult Registrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                GestionClientes.AgregarClientes(clientes, cliente);
                return View("RegistrarCliente", new Cliente());

            }
            else
            { 
                return View("RegistrarCliente", cliente);
            }
        }

        public IActionResult MostrarClientes()
        {
            return View("MostrarClientes", clientes);
        }
        public IActionResult TextoClientes()
        {
            var textoClientes = GestionClientes.MostrarClientes(clientes);
            return Content(textoClientes);
        }


        [HttpGet]
        public IActionResult factura()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalcularPago(int cedula)
        {

            Cliente? cliente = clientes.FirstOrDefault(c => c.Cedula == cedula);

            if (cliente != null)
            {

                int valorAPagar = CalculoPagoCliente.CalcularValorAPagar(cliente, clientes);
                ViewBag.ValorAPagar = valorAPagar;
            }
            else
            {

                ViewBag.Error = "No se encontr� un cliente con esa c�dula.";
            }

            return View("Factura");
        }
        [HttpPost]
        public IActionResult aguaconsumo()
        {
            int promedio_agua = Agua.CalcularPromedioConsumoAgua(clientes);

            List<int> clientes_mayor = Agua.MostrarClientesConConsumoAguaMayorAlPromedio(clientes);

            int estrato_mas_ahorro = Agua.EstratoConMayorAhorroDeAgua(clientes);

            ViewData["promedioagua"] = promedio_agua;
            ViewData["estratomasahorro"] = estrato_mas_ahorro;

            string estratosString = string.Join(", ", clientes_mayor);

            ViewData["consumomayor"] = estratosString;

            return View("ConsumoAgua", clientes);
        }
    }

}


