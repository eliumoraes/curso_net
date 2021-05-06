using System.Threading.Tasks;
using Treinamento.Net.Dominio.Entidades.ViaCep;

namespace Treinamento.Net.ServicoExterno.ViaCep
{
    public interface IViaCep
    {
        Task<ViaCepResponse.ViaCep> ConsultarCep(string cep);
    }
}
