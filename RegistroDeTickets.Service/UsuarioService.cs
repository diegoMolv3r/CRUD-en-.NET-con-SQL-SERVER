using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroDeTickets.Entidades;

namespace RegistroDeTickets.Service
{   
    public interface IUsuarioService
    {
        void AgregarUsuario(UsuarioEntity usuario);
        List<UsuarioEntity> ObtenerUsuarios();

        void EliminarUsuario(int id);
    }
    public class UsuarioService : IUsuarioService
    {
        public static List<UsuarioEntity> _usuarios = new List<UsuarioEntity>();

        public void AgregarUsuario(UsuarioEntity usuario)
        {
            usuario.Id = _usuarios.Count + 1;
            _usuarios.Add(usuario);
        }
        public List<UsuarioEntity> ObtenerUsuarios()
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
