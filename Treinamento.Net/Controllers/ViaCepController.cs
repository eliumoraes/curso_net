using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Treinamento.Net.Dominio.Entidades.DTO;
using Treinamento.Net.Dominio.Interfaces.Negocio;
using Treinamento.Net.ServicoExterno.ViaCep;

namespace Treinamento.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViaCepController : ControllerBase
    {
        private readonly ICepNegocio _cep;
        public ViaCepController(ICepNegocio cep)
        {
            _cep = cep;
        }

        [HttpGet("{cep}/json")]
        public IActionResult Get(string cep)
        {
            return Ok(_cep.Consultar(cep));
            
        }
    }
}
