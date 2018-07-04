using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Funcionalidades.Produtos;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosPedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Common.Tests.Funcionalidades.ProdutosPedido
{
    public static partial class ObjectMother
    {
        public static ProdutoPedido ObterProdutoPedidoValidoSemAdicional(Produto produto, Pedido pedido)
        {
            return new ProdutoPedido(produto, pedido)
            {
                Produto = produto,
                Pedido = pedido,
                Quantidade = 1,
                Sabores = 
            };
        }
    }
}
