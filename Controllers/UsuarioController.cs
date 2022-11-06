using API_C_.model;
using API_C_.Repository;
using Microsoft.AspNetCore.Mvc;

namespace usuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        private static List<Usuario> Usuarios()
        {
            return new List<Usuario>{
                new Usuario{
                    Nome = "Lucas",
                    Id = 1,
                    DataNascimento = new DateTime(1998,10,5)
                }
            };
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _repository.GetUsuarios();
            return usuarios.Any() ? Ok(usuarios) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _repository.GetUsuarioById(id);
            return usuario != null ? Ok(usuario) : NotFound("Usuario não encontrado");
        }


        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _repository.addUsuario(usuario);
            return await _repository.SaveChangesAsync() ? Ok("Usuario Adicionado") :
            BadRequest("Algo deu errado");

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Usuario usuario)
        {
            var usuarioExiste = await _repository.GetUsuarioById(id);
            if (usuarioExiste == null) return NotFound("Usuário não encontrado");

            usuarioExiste.Nome = usuario.Nome ?? usuarioExiste.Nome;
            usuarioExiste.DataNascimento = usuario.DataNascimento != new DateTime()
            ? usuario.DataNascimento : usuarioExiste.DataNascimento;

            _repository.UpdateUsuario(usuarioExiste);

            return await _repository.SaveChangesAsync() ? Ok("Usuario atualizado") : BadRequest("Algo deu errado.   ");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuarioExiste = await _repository.GetUsuarioById(id);
            if (usuarioExiste == null)
                return NotFound("Usuário não encontrado");

            _repository.DeleteUsuario(usuarioExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Usuário deletado.") : BadRequest("Algo deu errado.");
        }
    }

}
