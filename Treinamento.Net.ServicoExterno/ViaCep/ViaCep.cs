using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Treinamento.Net.Dominio.Entidades.ViaCep;

namespace Treinamento.Net.ServicoExterno.ViaCep
{
    public class ViaCep : IViaCep
    {
        private string _endpoint;
        private HttpClient _httpClient;
        public ViaCep(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            //_endpoint = configuration.GetSection("ViaCep").GetSection("endPoint").Value;
            _endpoint = configuration.GetSection("ViaCep:endPoint").Value;

            _httpClient = httpClientFactory.CreateClient("HttpClient");
        }

        public async Task<ViaCepResponse.ViaCep> ConsultarCep(string cep)
        {
            var result = await _httpClient.GetAsync(string.Format(_endpoint, cep));

            if(result.IsSuccessStatusCode 
                && result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = await result.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ViaCepResponse.ViaCep>(json);
            }
            return null;
        }
    }
}
