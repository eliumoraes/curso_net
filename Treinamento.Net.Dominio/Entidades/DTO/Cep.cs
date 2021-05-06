using System;
using System.Collections.Generic;
using System.Text;

namespace Treinamento.Net.Dominio.Entidades.DTO
{
    public class Cep
    {
        public Cep()
        {

        }

        public Cep(ViaCep.ViaCepResponse.ViaCep viaCep)
        {
            this.Bairro = viaCep.bairro;
            this.Cidade = viaCep.localidade;
            this.Logradouro = viaCep.logradouro;
            this.NumeroDoCep = viaCep.cep;
        }

        public string NumeroDoCep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}
