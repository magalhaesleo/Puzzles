using FluentAssertions;
using NUnit.Framework;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Pizzas;
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
        Pizza _pizza;

        [SetUp]
        public void IniciarCenario()
        {
            _pizza = new Pizza();
        }

        [Test]
        public void Pizza_Dominio_ObterTipo_DeveRetornarPizza()
        {
            _pizza.ObterTipo().Should().Be("Pizza");
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
