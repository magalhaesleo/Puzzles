using projeto_pizzaria.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Pedidos.Excecoes
{
    public class PedidoSemFormaDePagamentoExcecao : ExcecaoDeNegocio
    {
        public PedidoSemFormaDePagamentoExcecao() : base("Pedido deve ter uma forma de pagamento.")
        {
        }
    }
}
