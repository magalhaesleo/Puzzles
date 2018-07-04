using projeto_pizzaria.Domain.Excecoes;
using System;
using System.Runtime.Serialization;

namespace projeto_pizzaria.Domain.Funcionalidades.Pedidos.Excecoes
{
    public class PedidoSemProdutosExcecao : ExcecaoDeNegocio
    {
        public PedidoSemProdutosExcecao() : base("O pedido deve possuir ao menos um produto.")
        {
        }
    }
}