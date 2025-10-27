using RegistroDeTickets.Data.Entidades;
using RegistroDeTickets.Repository;

namespace RegistroDeTickets.Service
{
    public interface ITicketService
    {
        void AgregarTicket(Ticket ticket);
        List<Ticket> ObtenerTickets();
        void EditarTicket(Ticket ticket);
        void EliminarTicket(Ticket ticket);
    }

    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public void AgregarTicket(Ticket ticket)
        {
            //ticket.Id = _tickets.Count + 1;  --> Entiendo que con el IDENTITY ya no es necesario calcular el ID manualmente
            ticket.Estado = "Abierto"; // Este estado se podria poner en un DEFAULT de la base de datos?
            ticket.FechaCreacion = DateTime.Now; // Este campo tambien podria ser un DEFAULT en la base de datos?
            ticket.IdUsuario = 1; // Por ahora asigno un usuario fijo, luego se debe obtener el usuario logueado

            _ticketRepository.AgregarTicket(ticket);
        }

        public List<Ticket> ObtenerTickets()
        {
            return _ticketRepository.ObtenerTickets();
        }

        public void EditarTicket(Ticket ticket)
        {
            _ticketRepository.EditarTicket(ticket);
        }

        public void EliminarTicket(Ticket ticket)
        {
            _ticketRepository.EliminarTicket(ticket);
        }

    }
}
