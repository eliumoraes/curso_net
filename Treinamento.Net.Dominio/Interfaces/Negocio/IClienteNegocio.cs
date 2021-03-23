using System.Collections.Generic;
using Treinamento.Net.Dominio.Entidades;

namespace Treinamento.Net.Dominio.Interfaces.Negocio
{
    public interface IClienteNegocio
    {
        ClienteResponse Consultar(int codigoDoCliente);
        List<ClienteResponse> Listar();
    }
}
