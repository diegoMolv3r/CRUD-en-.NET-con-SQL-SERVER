using Microsoft.AspNetCore.Mvc;
using RegistroDeTickets.Entidades;
using RegistroDeTickets.Service;
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
            _usuarioService.AgregarUsuario(new UsuarioEntity
            {
                Username = usuarioVM.Username,
                Email = usuarioVM.Email,
                Contrasenia = usuarioVM.Contrasenia
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
