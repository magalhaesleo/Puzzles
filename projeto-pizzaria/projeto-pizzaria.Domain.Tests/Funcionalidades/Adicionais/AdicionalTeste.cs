using FluentAssertions;
using Moq;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests;
using projeto_pizzaria.Domain.Funcionalidades.Adicionais;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Tests.Funcionalidades.Adicionais
{
    [TestFixture]
    public class AdicionalTeste
    {
        private Adicional _adicional;
        private Mock<Pizza> _pizzaMock;

        [SetUp]
        public void IniciarCenario()
        {
            _adicional = new Adicional();
            _pizzaMock = new Mock<Pizza>();
        }

        [Test]
        public void Adicional_Dominio_Tipo_Sucesso()
        {
            _adicional = ObjectMother.ObterAdicional_BordaCatupiry();
            _adicional.Tipo.Should().Be("Adicional");
        }

        [Test]
        public void Adicional_Dominio_ObterValor_PizzaPequena_Sucesso()
        {
            _pizzaMock.Setup(p => p.Tamanho).Returns(TamanhoPizza.PEQUENA);
            _adicional = ObjectMother.ObterAdicional_BordaCatupiry();

            double valor = _adicional.ObterValorAdicional(_pizzaMock.Object);
            valor.Should().Be(_adicional.ValorPequena);
        }

        [Test]
        public void Adicional_Dominio_ObterValor_PizzaMedia_Sucesso()
        {
            _pizzaMock.Setup(p => p.Tamanho).Returns(TamanhoPizza.MEDIA);
            _adicional = ObjectMother.ObterAdicional_BordaCatupiry();

            double valor = _adicional.ObterValorAdicional(_pizzaMock.Object);
            valor.Should().Be(_adicional.ValorMedia);
        }

        [Test]
        public void Adicional_Dominio_ObterValor_PizzaGrande_Sucesso()
        {
            _pizzaMock.Setup(p => p.Tamanho).Returns(TamanhoPizza.GRANDE);
            _adicional = ObjectMother.ObterAdicional_BordaCatupiry();

            double valor = _adicional.ObterValorAdicional(_pizzaMock.Object);
            valor.Should().Be(_adicional.ValorGrande);
        }
    }
}
