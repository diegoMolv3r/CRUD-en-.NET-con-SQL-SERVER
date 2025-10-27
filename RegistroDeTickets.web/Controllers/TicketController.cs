﻿using Microsoft.AspNetCore.Mvc;
using RegistroDeTickets.Service;
using RegistroDeTickets.Data.Entidades;
using RegistroDeTickets.web.Models;

namespace RegistroDeTickets.web.Controllers
{
    public class TicketController(ITicketService ticketService) : Controller
    {
        private ITicketService _ticketService = ticketService;

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Verificar si el token de autenticacion es válido, solo peticiones POST
        public IActionResult Registrar(TicketViewModel ticketVM)
        {
            if (!ModelState.IsValid)
            {
                return View(ticketVM);
            }
            
            _ticketService.AgregarTicket(new Ticket
            {
                Motivo = ticketVM.Motivo,
                Tipo = ticketVM.Tipo,
                Descripcion = ticketVM.Descripcion
            });
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return View(_ticketService.ObtenerTickets());
        }

        public IActionResult Eliminar(Ticket ticket)
        {
            _ticketService.EliminarTicket(ticket);
            return RedirectToAction("Listar");
        }
    }
}
