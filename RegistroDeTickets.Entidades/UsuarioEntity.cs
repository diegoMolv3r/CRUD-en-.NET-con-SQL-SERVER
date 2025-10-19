using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeTickets.Entidades
{
    public class UsuarioEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public long Dni { get; set; }
        public string Contrasenia { get; set; }
    }
}
