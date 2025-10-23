using RegistroDeTickets.Data.Entidades;

namespace RegistroDeTickets.Service
{
    public interface ITicketService
    {
        void AgregarTicket(Ticket ticket);
        List<Ticket> ObtenerTickets();

        void EliminarTicket(int id);
    }

    public class TicketService : ITicketService
    {

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

        public void EliminarTicket(int id)
        {
            // var ticket = _tickets.FirstOrDefault(t => t.Id == id);
            // if (ticket != null)
            // {
            // _tickets.Remove(ticket);
            // }
        }

    }
}
