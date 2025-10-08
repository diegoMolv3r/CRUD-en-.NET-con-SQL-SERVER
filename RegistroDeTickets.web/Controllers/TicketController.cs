using Microsoft.AspNetCore.Mvc;
using RegistroDeTickets.Entidades;
using RegistroDeTickets.Service;
using RegistroDeTickets.web.Models;

namespace RegistroDeTickets.web.Controllers
{
    public class TicketController : Controller
    {
        ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(TicketViewModel ticketVM)
        {
            if (!ModelState.IsValid)
            {
                return View(ticketVM);
            }
            
            _ticketService.AgregarTicket(new RegistroDeTickets.Entidades.TicketEntity
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
            List<TicketEntity> tickets = _ticketService.ObtenerTickets();
            return View(tickets);
        }
    }
}
