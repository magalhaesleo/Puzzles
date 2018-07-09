using FluentAssertions;
using Moq;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests;
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
        public void Pizza_Dominio_ObterValorSemAdicional_SaboresComValorDiferentes_Sucesso()
        {
            _sabor1Mock.Setup(s => s.ValorMedia).Returns(50);
            _sabor2Mock.Setup(s => s.ValorMedia).Returns(40);
            _pizza = ObjectMother.ObterPizzaComMaisDeUmSabor(_sabor1Mock.Object, _sabor2Mock.Object);
            _pizza.Tamanho = TamanhoPizza.MEDIA;

            double valorPizza = _pizza.ObterValorSemAdicional();

            valorPizza.Should().Be(50);
        }
        [Test]
        public void Pizza_Dominio_ObterValorSemAdicional_SomenteUmSabor_Sucesso()
        {
            _sabor1Mock.Setup(s => s.ValorMedia).Returns(50);
            _pizza = ObjectMother.ObterPizzaComUmSabor(_sabor1Mock.Object);
            _pizza.Tamanho = TamanhoPizza.MEDIA;

            double valorPizza = _pizza.ObterValorSemAdicional();

            valorPizza.Should().Be(50);
        }
    }
}
