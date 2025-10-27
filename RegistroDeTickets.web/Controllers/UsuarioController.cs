using Microsoft.AspNetCore.Mvc;
using RegistroDeTickets.Service;
using RegistroDeTickets.Data.Entidades;
using RegistroDeTickets.web.Models;

namespace RegistroDeTickets.web.Controllers
{
    public class UsuarioController(IUsuarioService usuarioService) : Controller
    {
        public readonly IUsuarioService _usuarioService = usuarioService;

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
                return RedirectToAction("IniciarSesion");
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        public IActionResult Logout() 
        {
            return RedirectToAction("Registrar");
        }
    }
}
