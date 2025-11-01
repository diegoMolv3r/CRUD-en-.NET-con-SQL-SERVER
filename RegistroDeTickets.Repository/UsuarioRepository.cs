using Microsoft.EntityFrameworkCore;
using RegistroDeTickets.Data.Entidades;

namespace RegistroDeTickets.Repository
{
    public interface IUsuarioRepository
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
    }

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly RegistroDeTicketsPw3Context _ctx;

        public UsuarioRepository(RegistroDeTicketsPw3Context ctx)
        {
            _ctx = ctx;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            _ctx.Usuarios.Add(usuario);
            _ctx.SaveChanges();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _ctx.Usuarios.ToList();
        }

        public void EditarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void EliminarUsuario(Usuario usuario)
        {
            _ctx.Usuarios.Remove(usuario);
            _ctx.SaveChanges();
        }

        public Usuario BuscarPorEmail(string email)
        {
            return _ctx.Usuarios.FirstOrDefault(u => u.Email == email);
        }
    }
}
