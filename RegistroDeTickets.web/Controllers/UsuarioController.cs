﻿using Microsoft.AspNetCore.Mvc;
using RegistroDeTickets.Service;
using RegistroDeTickets.Data.Entidades;
using RegistroDeTickets.web.Models;

namespace RegistroDeTickets.web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

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
    }
}
