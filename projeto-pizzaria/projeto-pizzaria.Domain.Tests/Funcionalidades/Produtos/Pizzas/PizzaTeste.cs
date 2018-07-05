using Moq;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests.Funcionalidades.Produtos.Pizzas;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Pizzas;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Tests.Funcionalidades.Produtos.Pizzas
{
    [TestFixture]
    public class PizzaTeste
    {
        private Pizza _pizza;
        private Mock<Sabor> _sabor1Mock;
        private Mock<Sabor> _sabor2Mock;
        [SetUp]
        public void IniciarCenario()
        {
            _pizza = new Pizza();
            _sabor1Mock = new Mock<Sabor>();
            _sabor2Mock = new Mock<Sabor>();
        }
        [Test]
        public void ProdutoPedido_Dominio_ObterValor_SaboresComValorDiferentes_Sucesso()
        {
            _sabor1Mock.Setup( s=> s.)
            _pizza = ObjectMother.ObterPizzaComMaisDeUmSabor()
        }
        [Test]
        public void ProdutoPedido_Dominio_CalcularValor_PizzaPequena_Sucesso()
        {
            //_pizzaMoq.Setup(p => p.Tamanho).Returns(TamanhoPizza.PEQUENA);
            //_pizzaMoq.Setup()

            //_produtoPedidoValido.ValorTotal.Should().Be(40);
        }
    }
}
