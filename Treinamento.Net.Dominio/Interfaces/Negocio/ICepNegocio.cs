using Treinamento.Net.Dominio.Entidades.DTO;

namespace Treinamento.Net.Dominio.Interfaces.Negocio
{
    public interface ICepNegocio
    {
        Cep Consultar(string cep);
    }
}
