using RegistroDeTickets.Data.Entidades;

namespace RegistroDeTickets.Repository
{
    public interface ITicketRepository // esta interfaz se podria hacer generica para no hacer una por cada entidad?
    {
        void AgregarTicket(Ticket ticket);
        List<Ticket> ObtenerTickets();
        void EditarTicket(Ticket ticket);
        void EliminarTicket(Ticket ticket);
        Ticket BuscarTicketPorId(int id);
    }

    public class TicketRepository : ITicketRepository
    {
        private static readonly RegistroDeTicketsPw3Context ctx = new();

        public void AgregarTicket(Ticket ticket)
        {
            ctx.Tickets.Add(ticket);
            ctx.SaveChanges();
        }

        public Ticket BuscarTicketPorId(int id) // borrable este metodo
        {
            return ctx.Tickets.Find(id);
        }

        public void EditarTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void EliminarTicket(Ticket ticket)
        {
            ctx.Tickets.Remove(BuscarTicketPorId(ticket.Id));
            ctx.SaveChanges();
        }

        public List<Ticket> ObtenerTickets()
        {
            return ctx.Tickets.ToList();
        }
    }
}
