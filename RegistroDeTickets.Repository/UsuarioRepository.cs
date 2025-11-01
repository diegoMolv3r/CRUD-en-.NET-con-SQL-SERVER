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

        // UPDATE --> seria necesario implementar este metodo?
        void EditarUsuario(Usuario usuario);

        // DELETE
        void EliminarUsuario(Usuario usuario);
        Usuario BuscarPorEmail(string email);
    }
    public class UsuarioRepository(RegistroDeTicketsPw3Context ctx) : IUsuarioRepository
    {
        private readonly RegistroDeTicketsPw3Context _ctx = ctx;

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

        Usuario IUsuarioRepository.BuscarPorEmail(string email)
        {
            return _ctx.Usuarios
            .FirstOrDefault(u => u.Email == email);

        }
    }
}