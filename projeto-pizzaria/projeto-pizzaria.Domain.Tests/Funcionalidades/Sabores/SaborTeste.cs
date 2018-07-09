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
            _sabor.ValorCalzone = 10;

            double valor =_sabor.ObterValorDoSabor(_calzoneMock.Object);
            valor.Should().Be(10);

        }

        [Test]
        public void Sabor_Dominio_ObterValor_Pizza_Sucesso()
        {
            _pizzaMock.Setup(p => p.Tamanho).Returns(TamanhoPizza.GRANDE);
            _sabor = ObjectMother.ObterSaborValido();
            _sabor.ValorGrande = 74;

            double valor = _sabor.ObterValorDoSabor(_pizzaMock.Object);
            valor.Should().Be(74);

        }
    }
}
