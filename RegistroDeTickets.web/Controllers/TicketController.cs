using Microsoft.AspNetCore.Mvc;
using RegistroDeTickets.Service;
using RegistroDeTickets.Data.Entidades;
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

        public IActionResult Eliminar(int id)
        {
            _ticketService.EliminarTicket(id);
            return RedirectToAction("Listar");
        }
    }
}
