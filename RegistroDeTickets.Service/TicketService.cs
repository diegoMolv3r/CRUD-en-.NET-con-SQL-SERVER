﻿using RegistroDeTickets.Data.Entidades;
using RegistroDeTickets.Repository;

namespace RegistroDeTickets.Service
{
    public interface ITicketService
    {
        void AgregarTicket(Ticket ticket);
        List<Ticket> ObtenerTickets();
        void EditarTicket(Ticket ticket);
        void EliminarTicket(Ticket ticket);
        Ticket BuscarTicketPorId(int id);
        void AsignarTecnicoATicket(int idTicket, int idTecnico);
    }

    public class TicketService(ITicketRepository ticketRepository) : ITicketService
    {
        private readonly ITicketRepository _ticketRepository = ticketRepository;

        public void AgregarTicket(Ticket ticket)
        {
            ticket.IdCliente = 1; // Por ahora asigno un usuario fijo, luego se debe obtener el usuario logueado
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

        public Ticket BuscarTicketPorId(int id)
        {
            return _ticketRepository.BuscarTicketPorId(id);
        }

        public void AsignarTecnicoATicket(int idTicket, int idTecnico)
        {
            Ticket ticket = _ticketRepository.BuscarTicketPorId(idTicket);
            ticket.IdTecnico = idTecnico;
            EditarTicket(ticket);
        }
    }
}
