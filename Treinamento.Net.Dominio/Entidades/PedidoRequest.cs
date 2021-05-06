using System;
using System.Collections.Generic;
using System.Text;

namespace Treinamento.Net.Dominio.Entidades
{
    public class PedidoRequest
    {
        public int NumeroDoPedido { get; set; }
        public int CodigoDoCliente { get; set; }
        public string CepDoCliente { get; set; }
    }
}
