using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        /// Incluir o cliente
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClienteController>/5
        /// <summary>
        /// Alterar dados do cliente
        /// </summary>
        /// <param name="id">Código do cliente</param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
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
