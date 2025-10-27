using RegistroDeTickets.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeTickets.Repository
{
    public interface ITicketRepository
    {
        void AgregarTicket(Ticket ticket);
        List<Ticket> ObtenerTickets();
        void EditarTicket(Ticket ticket);
        void EliminarTicket(Ticket ticket);
    }

    internal class TicketRepository : ITicketRepository
    {
        public void AgregarTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void EditarTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void EliminarTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> ObtenerTickets()
        {
            throw new NotImplementedException();
        }
    }
}
