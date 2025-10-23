using RegistroDeTickets.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeTickets.Service
{   
    public interface IUsuarioService
    {
        void AgregarUsuario(Usuario usuario);
        List<Usuario> ObtenerUsuarios();

        void EliminarUsuario(int id);
    }
    public class UsuarioService : IUsuarioService
    {
        public static List<Usuario> _usuarios = new List<Usuario>();

        public void AgregarUsuario(Usuario usuario)
        {
            usuario.Id = _usuarios.Count + 1;
            _usuarios.Add(usuario);
        }
        public List<Usuario> ObtenerUsuarios()
        {
            return _usuarios;
        }
        public void EliminarUsuario(int id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                _usuarios.Remove(usuario);
            }
        }
    }
}
