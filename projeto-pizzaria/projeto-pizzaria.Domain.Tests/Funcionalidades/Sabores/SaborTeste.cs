using FluentAssertions;
using Moq;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Calzones;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Pizzas;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Tests.Funcionalidades.Sabores
{
    [TestFixture]
    public class SaborTeste
    {
        private Sabor _sabor;
        private Mock<Calzone> _calzoneMock;
        private Mock<Pizza> _pizzaMock;

        [SetUp]
        public void IniciarCenario()
        {
            _sabor = new Sabor();
            _calzoneMock = new Mock<Calzone>();
            _pizzaMock = new Mock<Pizza>();
        }
        [Test]
        public void Sabor_Dominio_ObterValor_Calzone_Sucesso()
        {
            _sabor = ObjectMother.ObterSaborValido();

            double valor =_sabor.ObterValorDoSabor(_calzoneMock.Object);
            valor.Should().Be(_sabor.ValorCalzone);
        }

        [Test]
        public void Sabor_Dominio_ObterValor_PizzaGrande_Sucesso()
        {
            _pizzaMock.Setup(p => p.Tamanho).Returns(TamanhoPizza.GRANDE);
            _sabor = ObjectMother.ObterSaborValido();

            double valor = _sabor.ObterValorDoSabor(_pizzaMock.Object);
            valor.Should().Be(_sabor.ValorGrande);
        }

        [Test]
        public void Sabor_Dominio_ObterValor_PizzaMedia_Sucesso()
        {
            _pizzaMock.Setup(p => p.Tamanho).Returns(TamanhoPizza.MEDIA);
            _sabor = ObjectMother.ObterSaborValido();

            double valor = _sabor.ObterValorDoSabor(_pizzaMock.Object);
            valor.Should().Be(_sabor.ValorMedia);
        }

        [Test]
        public void Sabor_Dominio_ObterValor_PizzaPequena_Sucesso()
        {
            _pizzaMock.Setup(p => p.Tamanho).Returns(TamanhoPizza.PEQUENA);
            _sabor = ObjectMother.ObterSaborValido();

            double valor = _sabor.ObterValorDoSabor(_pizzaMock.Object);
            valor.Should().Be(_sabor.ValorPequena);
        }
    }
}
