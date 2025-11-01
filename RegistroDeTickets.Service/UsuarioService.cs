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

        // Buscar por email
        Usuario BuscarPorEmail(string email);

        Usuario RegistrarUsuarioGoogle(string email, string nombreCompleto);
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

        public Usuario BuscarPorEmail(string email)
        {
            return _usuarioRepository.BuscarPorEmail(email);
        }

        public Usuario RegistrarUsuarioGoogle(string email, string nombreCompleto)
        {
            var usuarioExistente = _usuarioRepository.BuscarPorEmail(email);
            if (usuarioExistente != null)
            {
                return usuarioExistente;
            }

            //trata de setear e primer nombre con username si no puede pone el mail

            string primerNombre = (nombreCompleto ?? email).Split(' ')[0];

            var nuevoUsuario = new Usuario
            {
                Username = primerNombre,
                Email = email,
                PasswordHash = "" // Google gestiona la autenticación
            };

            _usuarioRepository.AgregarUsuario(nuevoUsuario);
            return nuevoUsuario;
        }
    }
}
