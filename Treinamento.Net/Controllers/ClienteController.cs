using Microsoft.AspNetCore.Mvc;
using Treinamento.Net.Dominio.Entidades.Parametros;
using Treinamento.Net.Dominio.Interfaces.Negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Treinamento.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteNegocio _clienteNegocio;

        public ClienteController(IClienteNegocio clienteNegocio)
        {
            _clienteNegocio = clienteNegocio;
        }

        // GET: api/<ClienteController>
        /// <summary>
        /// Consultar lista de clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clienteNegocio.Listar());
        }

        // GET api/<ClienteController>/5
        /// <summary>
        /// Consultar o cliente por ID
        /// </summary>
        /// <param name="id">Código do cliente</param>
        /// <returns>Retorna os dados do cliente</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliente = _clienteNegocio.Consultar(id);

            if (cliente?.CodigoDoCliente <= 0)
                return NotFound(new
                {
                    sucesso = false,
                    mensagem = "Cliente não encontrado."
                });

            return Ok(cliente);
        }

        // POST api/<ClienteController>
        /// <summary>
        /// Incluir cliente
        /// </summary>
        /// <param name="cliente"></param>
        [HttpPost]
        public IActionResult Post([FromBody] ClienteRequest cliente)
        {
            bool clienteCadastrado = _clienteNegocio.Incluir(cliente);
            if (clienteCadastrado)
            {
                return Ok(new
                {
                    sucesso = true,
                    mensagem = "Cliente cadastrado com sucesso."
                });
            }
            return NotFound(new
            {
                sucesso = false,
                mensagem = "Cliente não cadastrado."
            });
        }

        // PUT api/<ClienteController>/5
        /// <summary>
        /// Alterar dados do cliente
        /// </summary>
        /// <param name="id">Código do cliente</param>
        /// <param name="nomeDoCliente">Nome do cliente</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string nomeDoCliente)
        {
            bool clienteAlterado = _clienteNegocio.Alterar(id, nomeDoCliente);

            if (clienteAlterado)
            {
                var cliente = _clienteNegocio.Consultar(id);
                return Ok(new
                {
                    sucesso = clienteAlterado,
                    mensagem = "Cliente alterado.",
                    data = cliente
                });
            }
            return NotFound(new
            {
                sucesso = false,
                mensagem = "Cliente não alterado."
            });
        }

        // DELETE api/<ClienteController>/5
        /// <summary>
        /// Deletar o cliente por ID
        /// </summary>
        /// <param name="id">Código do cliente</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
