using System.Collections.Generic;
using Treinamento.Net.Dominio.Entidades;
using Treinamento.Net.Dominio.Interfaces.Negocio;
using Treinamento.Net.Dominio.Interfaces.Repositorio;

namespace Treinamento.Net.Negocio
{
    public class ClienteNegocio : IClienteNegocio
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteNegocio(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        public ClienteResponse Consultar(int codigoDoCliente)
        {
            if(codigoDoCliente > 0)
            {
                return _clienteRepositorio.Consultar(codigoDoCliente);
            }
            return null;
        }

        public List<ClienteResponse> Listar()
        {
            return _clienteRepositorio.Listar();
        }
    }
}