using System.ComponentModel.DataAnnotations;

namespace RegistroDeTickets.web.Models
{
    public class UsuarioViewModel
    {
        // Falta agregar las validaciones que queramos
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Contrasenia { get; set; }
    }
}
