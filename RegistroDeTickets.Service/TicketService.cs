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
        ITicketRepository _ticketRepository;
        public void AgregarTicket(Ticket ticket)
        {
            RegistroDeTicketsPw3Context ctx = new RegistroDeTicketsPw3Context();

            //ticket.Id = _tickets.Count + 1;  --> Entiendo que con el IDENTITY ya no es necesario calcular el ID manualmente
            ticket.Estado = "Abierto"; // Este estado se podria poner en un DEFAULT de la base de datos?
            ticket.FechaCreacion = DateTime.Now; // Este campo tambien podria ser un DEFAULT en la base de datos?

            ticket.IdUsuario = 1; // Por ahora asigno un usuario fijo, luego se debe obtener el usuario logueado

            ctx.Tickets.Add(ticket);
            ctx.SaveChanges();
        }

        public List<Ticket> ObtenerTickets()
        {
            RegistroDeTicketsPw3Context ctx = new RegistroDeTicketsPw3Context();

            return ctx.Tickets.ToList();
        }

        public void EditarTicket(Ticket ticket)
        {

        }

        public void EliminarTicket(Ticket ticket)
        {
            RegistroDeTicketsPw3Context ctx = new RegistroDeTicketsPw3Context();

            ctx.Tickets.Remove(ctx.Tickets.Find(ticket.Id));
            ctx.SaveChanges();
        }

    }
}
