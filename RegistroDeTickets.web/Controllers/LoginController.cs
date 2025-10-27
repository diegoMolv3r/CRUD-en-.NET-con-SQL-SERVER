using Microsoft.AspNetCore.Mvc;
using RegistroDeTickets.Data.Entidades;
using RegistroDeTickets.Service;

namespace RegistroDeTickets.web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }
            Usuario encontrado = _usuarioService.BuscarUsuario(usuario);
            if (encontrado == null)
            {
                return View(usuario);
            }
            return RedirectToAction("Inicio");
        }
    }
}
