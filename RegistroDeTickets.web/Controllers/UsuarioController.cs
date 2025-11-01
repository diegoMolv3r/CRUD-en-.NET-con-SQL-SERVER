﻿using Microsoft.AspNetCore.Mvc;
using RegistroDeTickets.Service;
using RegistroDeTickets.Data.Entidades;
using RegistroDeTickets.web.Models;
using RegistroDeTickets.Service;

namespace RegistroDeTickets.web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public readonly IEmailService _emailService;

        public UsuarioController(IUsuarioService usuarioService, IEmailService emailService)
        {
            _usuarioService = usuarioService;
            _emailService = emailService;
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
                return RedirectToAction("IniciarSesion");
        }

        [HttpGet]
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(LoginViewModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            var usuarioEncontrado = _usuarioService.BuscarUsuarioPorEmail(usuario.Email);

            if (usuarioEncontrado == null)
            { 
                TempData["Mensaje"] = "Usuario Inexistente";
                return View(usuario);
            }


            return RedirectToAction("Inicio","Home");
        }
        public IActionResult Listar()
        {
            return RedirectToAction("Registrar");
        }

        [HttpGet]
        public IActionResult SolicitarRecuperacion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SolicitarRecuperacion(SolicitarRecuperacionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var token = _usuarioService.GenerarTokenRecuperacion(vm.Email);

            if (token != null)
            {
                var link = GenerarLinkRecuperacion(vm.Email, token);

                var cuerpoEmail = GenerarCuerpoEmailRecuperacion(link);

                await _emailService.EnviarEmail(vm.Email, "Recuperación de Contraseña", cuerpoEmail);
            }

            return RedirectToAction("SolicitarRecuperacionConfirmacion");
        }

        private string GenerarLinkRecuperacion(string email, string token)
        {
            return Url.Action(
                action: "RestablecerContrasenia",
                controller: "Usuario",
                values: new { email = email, token = token },
                protocol: Request.Scheme
            );
        }

        private string GenerarCuerpoEmailRecuperacion(string link)
        {
            return $"<h1>Recuperación de Contraseña</h1>" +
                   $"<p>Recibimos una solicitud para restablecer tu contraseña. " +
                   $"Si no fuiste vos, ignorá este mensaje.</p>" +
                   $"<p>Hacé click en el siguiente enlace para continuar:</p>" +
                   $"<a href='{link}'>Restablecer mi contraseña</a>" +
                   $"<p>El enlace expirará en 30 minutos.</p>";
        }

        [HttpGet]
        public IActionResult SolicitarRecuperacionConfirmacion()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RestablecerContrasenia(string email, string token)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                return RedirectToAction("IniciarSesion");
            }

            var vm = new RestablecerContraseniaViewModel
            {
                Email = email,
                Token = token
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult RestablecerContrasenia(RestablecerContraseniaViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var exito = _usuarioService.RestablecerContrasenia(
                vm.Email,
                vm.Token,
                vm.NuevaContrasenia
            );

            if (exito)
            {
                TempData["MensajeExito"] = "¡Tu contraseña ha sido actualizada con éxito!";
                return RedirectToAction("IniciarSesion");
            }

            ModelState.AddModelError(string.Empty, "El enlace de recuperación no es válido o ha expirado. Por favor, solicitá uno nuevo.");
            return View(vm);
        }
    }
}

