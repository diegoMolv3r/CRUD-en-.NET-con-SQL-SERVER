using RegistroDeTickets.Data.Entidades;
using RegistroDeTickets.Repository;

namespace RegistroDeTickets.Service
{   
    public interface IUsuarioService
    {
        // CREATE
        void AgregarUsuario(Usuario usuario);
        // READ
        List<Usuario> ObtenerUsuarios();

        void EliminarUsuario(int id);
    }
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            _usuarioRepository.AgregarUsuario(usuario);
        }
        public List<Usuario> ObtenerUsuarios()
        {
            return _usuarioRepository.ObtenerUsuarios();
        }

        public void EditarUsuario(Usuario usuario)
        {
            _usuarioRepository.EditarUsuario(usuario);
        }

        public void EliminarUsuario(Usuario usuario)
        {
            _usuarioRepository.EliminarUsuario(usuario);
        }

        public Usuario BuscarUsuario(Usuario usuario)
        {
            var usuarioEmail = _usuarios.FirstOrDefault(u => u.Email == usuario.Email);
            return usuarioEmail;
        }
    }
}
