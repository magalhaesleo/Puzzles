using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosPedido;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Common.Tests.Funcionalidades.ProdutosPedido
{
    public static partial class ObjectMother
    {
        public static ProdutoPedido ObterProdutoPedidoSemProduto(Pedido pedido,List<Sabor> sabores)
        {
            ProdutoPedido produtoPedido = new ProdutoPedido();
            produtoPedido.Pedido = pedido;
            produtoPedido.Quantidade = 1;
            produtoPedido.Sabores = sabores;
            produtoPedido.ValorTotal = 100;
            produtoPedido.Adicional = adicional;

            return produtoPedido;
        }
    }
}
