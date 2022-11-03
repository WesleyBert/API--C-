using API_C_.model;

namespace API_C_.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<IEnumerable<Usuario>> GetUsuarioById(int id);
        void addUsuario(Usuario usuario);

        void UpdateUsuario(Usuario usuario);

        void DeleteUsuario(Usuario usuario);

        Task<bool> SaveChangesAsync();
    }
}