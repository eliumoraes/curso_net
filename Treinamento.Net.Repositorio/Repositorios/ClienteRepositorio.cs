using Dapper;
using System.Collections.Generic;
using System.Linq;
using Treinamento.Net.Dominio.Entidades;
using Treinamento.Net.Dominio.Entidades.Parametros;
using Treinamento.Net.Dominio.Interfaces.Repositorio;
using Treinamento.Net.Repositorio.Conexao;

namespace Treinamento.Net.Repositorio.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly IConexaoSqlServer _conexaoSql;
        public ClienteRepositorio(IConexaoSqlServer conexaoSqlServer)
        {
            _conexaoSql = conexaoSqlServer;
        }

        public ClienteResponse Consultar(int codigoDoCliente)
        {
            string sql = @"SELECT id as CodigoDoCliente,
                                  nome as NomeDoCliente,
                                  cpf as CpfDoCliente
                            FROM cliente
                            WHERE id = @codigoDoCliente";

            return Dapper.SqlMapper.QueryFirstOrDefault<ClienteResponse>(_conexaoSql.AbrirConexao(), sql, new
            {
                codigoDoCliente
            });
        }

        public bool Incluir(ClienteRequest cliente)
        {
            string sql = @"INSERT INTO cliente 
                                (nome, cpf)
                         values(
                                @NomeDoCliente, 
                                @CpfDoCliente
                                )";
            //Expressão booleana: Returna true ou false
            return SqlMapper.Execute(_conexaoSql.AbrirConexao(), sql, cliente) > 0;
        }

        public bool Alterar(int codigoDoCLiente, string nomeDoCliente)
        {
            string sql = @"UPDATE cliente
                            SET 
                                nome = @nome

                            WHERE 
                                id = @codigo";

            return SqlMapper.Execute(_conexaoSql.AbrirConexao(), sql, new
            {
                codigo = codigoDoCLiente,
                nome = nomeDoCliente
            }) > 0;
        }

        public List<ClienteResponse> Listar()
        {
            string sql = @"SELECT   
                                id as CodigoDoCliente,
                                nome as NomeDoCliente,
                                cpf as CpfDoCliente
                            FROM cliente";

            return Dapper.SqlMapper.Query<ClienteResponse>(_conexaoSql.AbrirConexao(), sql).ToList();
        }
    }
}
