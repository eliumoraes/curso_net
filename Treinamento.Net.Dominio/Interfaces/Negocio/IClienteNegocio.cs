using System.Collections.Generic;
using Treinamento.Net.Dominio.Entidades;
using Treinamento.Net.Dominio.Entidades.Parametros;

namespace Treinamento.Net.Dominio.Interfaces.Negocio
{
    public interface IClienteNegocio
    {
        ClienteResponse Consultar(int codigoDoCliente);
        List<ClienteResponse> Listar();
        bool Incluir(ClienteRequest cliente);
        bool Alterar(int codigoDoCLiente, string nomeDoCliente);
    }
}
