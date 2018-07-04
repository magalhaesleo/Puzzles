using Moq;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests.Funcionalidades.ProdutosPedido;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Funcionalidades.Produtos;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Pizzas;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosPedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Tests.Funcionalidades.ProdutosPedido
{
    [TestFixture]
    public class ProdutoPedidoTeste
    {

        private ProdutoPedido _produtoPedidoValido;
        private Mock<Pizza> _pizzaMoq;
        private Mock<Pedido> _pedidoMoq;

        [SetUp]
        public void IniciarCenario()
        {
            _pizzaMoq = new Mock<Pizza>();
            _pedidoMoq = new Mock<Pedido>();
            _produtoPedidoValido = ObjectMother.ObterProdutoPedidoValidoSemAdicional(_pizzaMoq.Object, _pedidoMoq.Object);
        }
        

        [Test]
        public void ProdutoPedido_Dominio_CalcularValor_PizzaPequena_Sucesso()
        {
            _pizzaMoq.Object.Tamanho
        }
    }


}
