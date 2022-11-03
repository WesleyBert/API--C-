
using API_C_.Data;
using API_C_.model;
using Microsoft.EntityFrameworkCore;

namespace API_C_.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context){
            _context = context;
        }
        public void addUsuario(Usuario usuario)
        {
            _context.Add(usuario);
        }

        public void DeleteUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetUsuarioById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task <IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}