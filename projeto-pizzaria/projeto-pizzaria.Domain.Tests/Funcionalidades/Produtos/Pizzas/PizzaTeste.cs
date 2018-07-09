using FluentAssertions;
using Moq;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests;
using projeto_pizzaria.Domain.Funcionalidades.Adicionais;
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
        #region Casos Levantados
        /*
        Pizza_Dominio_Valor_PizzaPequena_Sucesso
        Pizza_Dominio_Valor_PizzaPequenaComBordaCatupiry_Sucesso
        Pizza_Dominio_Valor_PizzaPequenaComBordaCheddar_Sucesso
        Pizza_Dominio_Valor_PizzaMedia_Sucesso
        Pizza_Dominio_Valor_PizzaMediaComBordaCatupiry_Sucesso
        Pizza_Dominio_Valor_PizzaMediaComBordaCheddar_Sucesso
        Pizza_Dominio_Valor_PizzaGrande_Sucesso
        Pizza_Dominio_Valor_PizzaGrandeComBordaCatupiry_Sucesso
        Pizza_Dominio_Valor_PizzaGrandeComBordaCheddar_Sucesso
        Pizza_Dominio_Valor_PizzaPequenaComDoisSaboresValorIgual_Sucesso
        Pizza_Dominio_Valor_PizzaPequenaComDoisSaboresValoresDiferentes_Sucesso
        Pizza_Dominio_Valor_PizzaMediaComDoisSaboresValorIgual_Sucesso
        Pizza_Dominio_Valor_PizzaMediaComDoisSaboresValoresDiferentes_Sucesso
        Pizza_Dominio_Valor_PizzaGrandeComDoisSaboresValorIgual_Sucesso
        Pizza_Dominio_Valor_PizzaGrandeComDoisSaboresValoresDiferentes_Sucesso
        
             Observação:
                Casos de teste que não aparecem abaixo é porque, ao usar mocks,
                são criadas situações de equivalência. Esses deverão ser contemplados
                nos testes de integração de sistema.
             */
        #endregion

        private Pizza _pizza;
        private Mock<Sabor> _sabor1Mock;
        private Mock<Sabor> _sabor2Mock;
        private Mock<Adicional> _adicionalMock;

        [SetUp]
        public void IniciarCenario()
        {
            _pizza = new Pizza();
            _sabor1Mock = new Mock<Sabor>();
            _sabor2Mock = new Mock<Sabor>();
            _adicionalMock = new Mock<Adicional>();
        }

        [Test]
        public void Pizza_Dominio_Valor_PizzaPequena_Sucesso()
        {
            _pizza = ObjectMother.ObterPizzaComTamanhoEUmSabor(TamanhoPizza.PEQUENA, _sabor1Mock.Object);

            double valorSabor1PizzaPequena = 20;
            _sabor1Mock.Setup(s1 => s1.ObterValorDoSabor(_pizza)).Returns(valorSabor1PizzaPequena);

            _pizza.Valor.Should().Be(valorSabor1PizzaPequena);
            _sabor1Mock.Verify(s1 => s1.ObterValorDoSabor(_pizza));
            _pizza.ValorAdicional.Should().Be(0);
        }

        [Test]
        public void Pizza_Dominio_Valor_PizzaPequenaComBordaCatupiry_Sucesso()
        {
            _pizza = ObjectMother.ObterPizzaComTamanhoEUmSabor(TamanhoPizza.PEQUENA, _sabor1Mock.Object);

            double valorSabor1PizzaPequena = 20;
            _sabor1Mock.Setup(s1 => s1.ObterValorDoSabor(_pizza)).Returns(valorSabor1PizzaPequena);

            double valorBordaCatupiryPizzaPequena = 1.25;
            _adicionalMock.Setup(am => am.ObterValorAdicional(_pizza)).Returns(valorBordaCatupiryPizzaPequena);

            _pizza.Adicional = _adicionalMock.Object;

            _pizza.Valor.Should().Be(valorSabor1PizzaPequena + valorBordaCatupiryPizzaPequena);
            _sabor1Mock.Verify(s1 => s1.ObterValorDoSabor(_pizza));
            _adicionalMock.Verify(am => am.ObterValorAdicional(_pizza));
            _pizza.ValorAdicional.Should().Be(valorBordaCatupiryPizzaPequena);
        }

        
        [Test]
        public void Pizza_Dominio_Valor_PizzaPequenaComDoisSaboresValorIgual_Sucesso()
        {
            _pizza = ObjectMother.ObterPizzaComTamanhoEUmSabor(TamanhoPizza.PEQUENA, _sabor1Mock.Object);
            double valorSabores = 20;

            double valorSabor1PizzaPequena = valorSabores;
            _sabor1Mock.Setup(s1 => s1.ObterValorDoSabor(_pizza)).Returns(valorSabor1PizzaPequena);

            double valorSabor2PizzaPequena = valorSabores;
            _sabor2Mock.Setup(s2 => s2.ObterValorDoSabor(_pizza)).Returns(valorSabor2PizzaPequena);

            _pizza.Valor.Should().Be(valorSabores);
            _sabor1Mock.Verify(s1 => s1.ObterValorDoSabor(_pizza));
            _pizza.ValorAdicional.Should().Be(0);
        }

        [Test]
        public void Pizza_Dominio_Valor_PizzaPequenaComDoisSaboresValoresDiferentes_PrimeiroSaborMaisCaro_Sucesso()
        {
            _pizza = ObjectMother.ObterPizzaComTamanhoEDoisSabores(TamanhoPizza.PEQUENA, _sabor1Mock.Object, _sabor2Mock.Object);

            double valorSabor1PizzaPequena = 25;
            _sabor1Mock.Setup(s1 => s1.ObterValorDoSabor(_pizza)).Returns(valorSabor1PizzaPequena);

            double valorSabor2PizzaPequena = 15;
            _sabor2Mock.Setup(s2 => s2.ObterValorDoSabor(_pizza)).Returns(valorSabor2PizzaPequena);

            _pizza.Valor.Should().Be(valorSabor1PizzaPequena);
            _pizza.Valor.Should().Be(_pizza.ValorSaboresSemAdicional);
            _sabor1Mock.Verify(s1 => s1.ObterValorDoSabor(_pizza));
            _pizza.ValorAdicional.Should().Be(0);
        }

        [Test]
        public void Pizza_Dominio_Valor_PizzaPequenaComDoisSaboresValoresDiferentes_SegundoSaborMaisCaro_Sucesso()
        {
            _pizza = ObjectMother.ObterPizzaComTamanhoEDoisSabores(TamanhoPizza.PEQUENA, _sabor1Mock.Object, _sabor2Mock.Object);

            double valorSabor1PizzaPequena = 15;
            _sabor1Mock.Setup(s1 => s1.ObterValorDoSabor(_pizza)).Returns(valorSabor1PizzaPequena);

            double valorSabor2PizzaPequena = 25;
            _sabor2Mock.Setup(s2 => s2.ObterValorDoSabor(_pizza)).Returns(valorSabor2PizzaPequena);

            _pizza.Valor.Should().Be(valorSabor2PizzaPequena);
            _pizza.Valor.Should().Be(_pizza.ValorSaboresSemAdicional);
            _sabor1Mock.Verify(s1 => s1.ObterValorDoSabor(_pizza));
            _pizza.ValorAdicional.Should().Be(0);
        }

        [Test]
        public void Pizza_Dominio_Tipo_Sucesso()
        {
            _pizza = ObjectMother.ObterPizzaComTamanhoEUmSabor(TamanhoPizza.PEQUENA, _sabor1Mock.Object);

            string tipoDesejado = "Pizza";

            _pizza.Tipo.Should().Be(tipoDesejado);
        }
    }
}
