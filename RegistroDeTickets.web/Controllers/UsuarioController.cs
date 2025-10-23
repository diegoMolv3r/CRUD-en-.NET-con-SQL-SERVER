using Microsoft.AspNetCore.Mvc;
using RegistroDeTickets.Service;
using RegistroDeTickets.Data.Entidades;
using RegistroDeTickets.web.Models;

namespace RegistroDeTickets.web.Controllers
{
    public class UsuarioController : Controller
    {
        public readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(UsuarioViewModel usuarioVM)
        {
            if (!ModelState.IsValid)
            {
                return View(usuarioVM);
            }
            _usuarioService.AgregarUsuario(new Usuario
            {
                Username = usuarioVM.Username,
                Email = usuarioVM.Email,
                PasswordHash = usuarioVM.Contrasenia
            });
                return RedirectToAction("Listar");
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
