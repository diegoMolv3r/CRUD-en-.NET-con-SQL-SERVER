using Microsoft.AspNetCore.Mvc;
using RegistroDeTickets.Data.Entidades;
using RegistroDeTickets.Service;

namespace RegistroDeTickets.web.Controllers
{
    public class AdministradorController(ITicketService ticketService) : Controller
    {
        private readonly ITicketService _ticketService = ticketService;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EliminarTicket(Ticket ticket)
        {
            _ticketService.EliminarTicket(ticket);
            return RedirectToAction("Listar");
        }
    }
}
