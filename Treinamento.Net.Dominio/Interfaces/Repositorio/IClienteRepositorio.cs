using System.Collections.Generic;
using Treinamento.Net.Dominio.Entidades;

namespace Treinamento.Net.Dominio.Interfaces.Repositorio
{
    public interface IClienteRepositorio
    {
        ClienteResponse Consultar(int codigoDoCliente);
        List<ClienteResponse> Listar();
    }
}
