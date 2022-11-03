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
        public IActionResult Get()
        {
            return Ok(Usuarios());
        }


        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _repository.addUsuario(usuario);
            return await _repository.SaveChangesAsync() ? Ok("Usuario Adicionado") :
            BadRequest("Algo deu errado");

        }
    }
}