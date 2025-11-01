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
        
        // UPDATE
        void EditarUsuario(Usuario usuario);
        
        // DELETE
        void EliminarUsuario(Usuario usuario);
        Usuario BuscarPorEmail(string email);
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

        Usuario IUsuarioService.BuscarPorEmail(string email)
        {
            return _usuarioRepository.BuscarPorEmail(email);
        }
    }
}
