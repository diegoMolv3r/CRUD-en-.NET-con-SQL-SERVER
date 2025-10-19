using Microsoft.AspNetCore.Mvc;

namespace RegistroDeTickets.web.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Registrar()
        {
            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        public IActionResult Listar()
        {
            return View();
        }
    }
}
