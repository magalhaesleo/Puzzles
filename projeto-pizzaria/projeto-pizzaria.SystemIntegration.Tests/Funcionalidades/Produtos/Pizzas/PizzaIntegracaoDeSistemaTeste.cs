using FluentAssertions;
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

namespace projeto_pizzaria.SystemIntegration.Tests.Funcionalidades.Produtos.Pizzas
{
    [TestFixture]
    public class PizzaIntegracaoDeSistemaTeste
    {
        #region Casos Levantados
        /*
        Pizza_IntegracaoDeSistema_Valor_PizzaPequena_Sucesso
        Pizza_IntegracaoDeSistema_Valor_PizzaPequenaComBordaCatupiry_Sucesso
        Pizza_IntegracaoDeSistema_Valor_PizzaPequenaComBordaCheddar_Sucesso
        Pizza_IntegracaoDeSistema_Valor_PizzaMedia_Sucesso
        Pizza_IntegracaoDeSistema_Valor_PizzaMediaComBordaCatupiry_Sucesso
        Pizza_IntegracaoDeSistema_Valor_PizzaMediaComBordaCheddar_Sucesso
        Pizza_IntegracaoDeSistema_Valor_PizzaGrande_Sucesso
        Pizza_IntegracaoDeSistema_Valor_PizzaGrandeComBordaCatupiry_Sucesso
        Pizza_IntegracaoDeSistema_Valor_PizzaGrandeComBordaCheddar_Sucesso
        Pizza_IntegracaoDeSistema_Valor_PizzaPequenaComDoisSaboresValorIgual_Sucesso
        Pizza_IntegracaoDeSistema_Valor_PizzaPequenaComDoisSaboresValoresDiferentes_Sucesso
        Pizza_IntegracaoDeSistema_Valor_PizzaMediaComDoisSaboresValorIgual_Sucesso
        Pizza_IntegracaoDeSistema_Valor_PizzaMediaComDoisSaboresValoresDiferentes_Sucesso
        Pizza_IntegracaoDeSistema_Valor_PizzaGrandeComDoisSaboresValorIgual_Sucesso
        Pizza_IntegracaoDeSistema_Valor_PizzaGrandeComDoisSaboresValoresDiferentes_Sucesso
        */
        #endregion

        private Pizza _pizza;

        private Sabor _saborQueijo;
        private Sabor _saborCalabresa;
        private Sabor _saborCoracao;

        private Adicional _bordaCatupiry;
        private Adicional _bordaCheddar;

        [SetUp]
        public void IniciarCenario()
        {
            _pizza = new Pizza();

            _saborQueijo = new Sabor();
            _saborQueijo.ValorPequena = 30;
            _saborQueijo.ValorMedia = 40;
            _saborQueijo.ValorGrande = 50;

            _saborCalabresa = new Sabor();
            _saborCalabresa.ValorPequena = 30;
            _saborCalabresa.ValorMedia = 40;
            _saborCalabresa.ValorGrande = 50;

            _saborCoracao = new Sabor();
            _saborCoracao.ValorPequena = 40;
            _saborCoracao.ValorMedia = 50;
            _saborCoracao.ValorGrande = 60;

            _bordaCatupiry = ObjectMother.ObterAdicional_BordaCatupiry();
            _bordaCheddar = ObjectMother.ObterAdicional_BordaCheddar();
        }

        [Test]
        public void Pizza_IntegracaoDeSistema_Valor_PizzaPequena_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.PEQUENA;
            _pizza.Sabor1 = _saborQueijo;

            _pizza.Valor.Should().Be(_saborQueijo.ValorPequena);
        }

        [Test]
        public void Pizza_IntegracaoDeSistema_Valor_PizzaPequenaComBordaCatupiry_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.PEQUENA;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Adicional = _bordaCatupiry;

            _pizza.Valor.Should().Be(_saborQueijo.ValorPequena + _bordaCatupiry.ValorPequena);
        }

        [Test]
        public void Pizza_IntegracaoDeSistema_Valor_PizzaPequenaComBordaCheddar_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.PEQUENA;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Adicional = _bordaCheddar;

            _pizza.Valor.Should().Be(_saborQueijo.ValorPequena + _bordaCheddar.ValorPequena);
        }

        [Test]
        public void Pizza_IntegracaoDeSistema_Valor_PizzaMedia_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.MEDIA;
            _pizza.Sabor1 = _saborQueijo;

            _pizza.Valor.Should().Be(_saborQueijo.ValorMedia);
        }

        [Test]
        public void Pizza_IntegracaoDeSistema_Valor_PizzaMediaComBordaCatupiry_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.MEDIA;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Adicional = _bordaCatupiry;

            _pizza.Valor.Should().Be(_saborQueijo.ValorMedia + _bordaCatupiry.ValorMedia);
        }

        [Test]
        public void Pizza_IntegracaoDeSistema_Valor_PizzaMediaComBordaCheddar_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.MEDIA;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Adicional = _bordaCheddar;

            _pizza.Valor.Should().Be(_saborQueijo.ValorMedia + _bordaCheddar.ValorMedia);
        }

        [Test]
        public void Pizza_IntegracaoDeSistema_Valor_PizzaGrande_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.GRANDE;
            _pizza.Sabor1 = _saborQueijo;

            _pizza.Valor.Should().Be(_saborQueijo.ValorGrande);
        }

        [Test]
        public void Pizza_IntegracaoDeSistema_Valor_PizzaGrandeComBordaCatupiry_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.GRANDE;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Adicional = _bordaCatupiry;

            _pizza.Valor.Should().Be(_saborQueijo.ValorGrande + _bordaCatupiry.ValorGrande);
        }

        [Test]
        public void Pizza_IntegracaoDeSistema_Valor_PizzaGrandeComBordaCheddar_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.GRANDE;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Adicional = _bordaCheddar;

            _pizza.Valor.Should().Be(_saborQueijo.ValorGrande + _bordaCheddar.ValorGrande);
        }

        [Test]
        public void Pizza_IntegracaoDeSistema_Valor_PizzaPequenaComDoisSaboresValorIgual_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.PEQUENA;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Sabor2 = _saborCalabresa;

            //Dois sabores com o mesmo preço
            double precoDosDoisSabores = _saborQueijo.ValorPequena;

            _pizza.Valor.Should().Be(precoDosDoisSabores);
        }

        [Test]
        public void Pizza_IntegracaoDeSistema_Valor_PizzaPequenaComDoisSaboresValoresDiferentes_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.PEQUENA;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Sabor2 = _saborCoracao;

            //Sabores com preços diferentes
            double precoDoSaborMaisCaro = _saborCoracao.ValorPequena;

            _pizza.Valor.Should().Be(precoDoSaborMaisCaro);
        }

        [Test]
        public void Pizza_IntegracaoDeSistema_Valor_PizzaMediaComDoisSaboresValorIgual_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.MEDIA;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Sabor2 = _saborCalabresa;

            //Dois sabores com o mesmo preço
            double precoDosDoisSabores = _saborQueijo.ValorMedia;

            _pizza.Valor.Should().Be(precoDosDoisSabores);
        }

        [Test]
        public void Pizza_IntegracaoDeSistema_Valor_PizzaMediaComDoisSaboresValoresDiferentes_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.MEDIA;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Sabor2 = _saborCoracao;

            //Sabores com preços diferentes
            double precoDoSaborMaisCaro = _saborCoracao.ValorMedia;

            _pizza.Valor.Should().Be(precoDoSaborMaisCaro);
        }

        [Test]
        public void Pizza_IntegracaoDeSistema_Valor_PizzaGrandeComDoisSaboresValorIgual_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.GRANDE;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Sabor2 = _saborCalabresa;

            //Dois sabores com o mesmo preço
            double precoDosDoisSabores = _saborQueijo.ValorGrande;

            _pizza.Valor.Should().Be(precoDosDoisSabores);
        }

        [Test]
        public void Pizza_IntegracaoDeSistema_Valor_PizzaGrandeComDoisSaboresValoresDiferentes_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.GRANDE;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Sabor2 = _saborCoracao;

            //Sabores com preços diferentes
            double precoDoSaborMaisCaro = _saborCoracao.ValorGrande;

            _pizza.Valor.Should().Be(precoDoSaborMaisCaro);
        }
    }
}
