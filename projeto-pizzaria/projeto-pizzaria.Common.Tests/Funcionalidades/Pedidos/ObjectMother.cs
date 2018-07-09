using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Funcionalidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Common.Tests.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Pedido ObterPedidoValido(Cliente cliente, List<Produto> produtos)
        {
            Pedido pedido = new Pedido();
            pedido.Cliente = cliente;
            pedido.Data = DateTime.Now;
            pedido.Produtos = produtos;
            pedido.FormaPagamento = FormaPagamentoPedido.DINHEIRO;

            return pedido;
        }

        public static Pedido ObterPedidoSemFormaDePagamento(Cliente cliente, List<Produto> produtos)
        {
            Pedido pedido = new Pedido();
            pedido.Cliente = cliente;
            pedido.Data = DateTime.Now;
            pedido.Produtos = produtos;

            return pedido;
        }
    }
}
