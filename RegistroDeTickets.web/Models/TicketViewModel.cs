using System.ComponentModel.DataAnnotations;

namespace RegistroDeTickets.web.Models
{
    public class TicketViewModel
    {
        [Required]
        public required string Motivo { get; set; }
        [Required]
        [Range(1,3, ErrorMessage = "Debe seleccionar una prioridad válida.")]
        public required int Prioridad { get; set; } // Cambiar a string luego para mostrar "Baja", "Media", "Alta"
        [Required]
        public required string Descripcion { get; set; }
    }
}
