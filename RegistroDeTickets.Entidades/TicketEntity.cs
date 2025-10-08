namespace RegistroDeTickets.Entidades
{
    public class TicketEntity
    {
        public int Id { get; set; }
        public string Motivo { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; }
    }
}
