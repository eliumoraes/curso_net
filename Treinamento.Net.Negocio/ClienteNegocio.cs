using System.Collections.Generic;
using Treinamento.Net.Dominio.Entidades;
using Treinamento.Net.Dominio.Entidades.Parametros;
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

        public bool Alterar(int codigoDoCLiente, string nomeDoCliente)
        {
            if (codigoDoCLiente > 0)
            {
                return _clienteRepositorio.Alterar(codigoDoCLiente, nomeDoCliente);
            }
            return false;
        }

        public ClienteResponse Consultar(int codigoDoCliente)
        {
            if (codigoDoCliente > 0)
            {
                return _clienteRepositorio.Consultar(codigoDoCliente);
            }
            return null;
        }

        public bool Incluir(ClienteRequest cliente)
        {
            return _clienteRepositorio.Incluir(cliente);
        }

        public List<ClienteResponse> Listar()
        {
            return _clienteRepositorio.Listar();
        }
    }
}