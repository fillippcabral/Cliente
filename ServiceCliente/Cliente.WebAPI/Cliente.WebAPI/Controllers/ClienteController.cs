using Cliente.BancoDeDadosEF.Entidade;
using Cliente.BancoDeDadosEF.Repositorio;
using Cliente.WebAPI.Controllers.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly IArmazenadorCliente _armazenadorDoCliente;

        public ClienteController(IArmazenadorCliente armazenadorDoCliente)
        {
            _armazenadorDoCliente = armazenadorDoCliente;
        }

        [HttpGet(Name = "GetCliente")]
        public ActionResult<List<EntidadeCliente>> Get()
        {
            return _armazenadorDoCliente.ObterClientes();

        }

        [HttpPost(Name = "PostCliente")]
        public ActionResult Post(ClienteDto cliente)
        {
            EntidadeCliente entidade = new EntidadeCliente()
            {
                Idade = cliente.Idade,
                Nome = cliente.Nome
            };

            _armazenadorDoCliente.InserirCliente(entidade);

            return Ok(true);
        }

        [HttpPut(Name = "PutCliente")]
        public ActionResult Put(EntidadeCliente cliente)
        {
            _armazenadorDoCliente.AtualizarCliente(cliente);
            return Ok(true);
        }

        [HttpDelete(Name = "DeleteCliente")]
        public ActionResult Delete(Guid Id)
        {
            _armazenadorDoCliente.DeletarCliente(Id);
            return Ok(true);
        }
    }
}