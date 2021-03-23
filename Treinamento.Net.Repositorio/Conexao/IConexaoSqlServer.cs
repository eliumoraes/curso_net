using System.Data;

namespace Treinamento.Net.Repositorio.Conexao
{
    public interface IConexaoSqlServer
    {
        IDbConnection AbrirConexao();
    }
}
