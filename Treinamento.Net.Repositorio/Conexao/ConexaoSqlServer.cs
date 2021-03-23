using System;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Treinamento.Net.Repositorio.Conexao
{
    public class ConexaoSqlServer : IConexaoSqlServer
    {
        private IDbConnection _db;
        private string _connectionString;
        public ConexaoSqlServer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("cursoApi");
        }

        public IDbConnection AbrirConexao()
        {
            _db = new System.Data.SqlClient.SqlConnection(_connectionString);
            try
            {
                _db.Open();
            }
            catch (Exception ex)
            {
                //TODO: adicionar log
                throw;
            }
            return _db; 
        }
    }
}
