using Treinamento.Net.Dominio.Entidades.DTO;
using Treinamento.Net.Dominio.Interfaces.Negocio;
using Treinamento.Net.ServicoExterno.ViaCep;

namespace Treinamento.Net.Negocio
{
    public class CepNegocio : ICepNegocio
    {
        private readonly IViaCep _viaCep;
        public CepNegocio(IViaCep viaCep)
        {
            _viaCep = viaCep;
        }
        public Cep Consultar(string cep)
        {
            var result = _viaCep.ConsultarCep(cep).Result;
            //if(!result.IsCompletedSuccessfully)
            //{
            //    tentar em outra api de cep.
            //}
                
            return new Cep(result);
            
        }
    }
}
