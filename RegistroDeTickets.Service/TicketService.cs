using RegistroDeTickets.Entidades;

namespace RegistroDeTickets.Service
{
    public interface ITicketService
    {
        void AgregarTicket(TicketEntity ticket);
        List<TicketEntity> ObtenerTickets();

        void EliminarTicket(int id);
    }

    public class TicketService : ITicketService
    {
        public List<TicketEntity> _tickets = new List<TicketEntity>();

        public void AgregarTicket(TicketEntity ticket)
        {
            ticket.Id = _tickets.Count + 1;
            ticket.Estado = "Abierto";
            ticket.FechaCreacion = DateTime.Now;
            _tickets.Add(ticket);
        }

        public List<TicketEntity> ObtenerTickets()
        {
            return _tickets;
        }

        public void EliminarTicket(int id)
        {
            var ticket = _tickets.FirstOrDefault(t => t.Id == id);
            if (ticket != null)
            {
                _tickets.Remove(ticket);
            }
        }

    }
}
