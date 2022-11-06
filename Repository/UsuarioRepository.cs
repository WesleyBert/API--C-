
using API_C_.Data;
using API_C_.model;
using Microsoft.EntityFrameworkCore;

namespace API_C_.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }
        public void addUsuario(Usuario usuario)
        {
            _context.Add(usuario);
        }

        public void DeleteUsuario(Usuario usuario)
        {
            _context.Remove(usuario);
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _context.Usuarios.Where(x => x.Id
            == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _context.Update(usuario);
        }

        Task<IEnumerable<Usuario>> IUsuarioRepository.GetUsuarioById(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Usuario>> IUsuarioRepository.GetUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}