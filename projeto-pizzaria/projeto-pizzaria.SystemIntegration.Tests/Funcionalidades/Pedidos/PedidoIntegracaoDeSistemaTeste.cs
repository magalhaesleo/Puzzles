using FluentAssertions;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests;
using projeto_pizzaria.Domain.Funcionalidades.Adicionais;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Funcionalidades.Produtos;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Calzones;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Pizzas;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.ProdutosPedido;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos.Bebidas;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.SystemIntegration.Tests.Funcionalidades.Pedidos
{
    [TestFixture]
    public class PedidoIntegracaoDeSistemaTeste
    {
        #region Casos Levantados
        /*
        Pedido_IntegracaoDeSistema_Realizar_UmaPizza_UmSabor_Sucesso
        Pedido_IntegracaoDeSistema_Realizar_UmaPizza_DoisSabores_Sucesso
        Pedido_IntegracaoDeSistema_Realizar_DuasPizzas_UmSabor_Sucesso
        Pedido_IntegracaoDeSistema_Realizar_DuasPizzas_DoisSabores_Sucesso
        Pedido_IntegracaoDeSistema_Realizar_Calzone_Sucesso
        Pedido_IntegracaoDeSistema_Realizar_Bebida_Sucesso
        Pedido_IntegracaoDeSistema_Realizar_UmaPizza_UmaBebida_Sucesso
        Pedido_IntegracaoDeSistema_Realizar_UmaPizza_ComBorda_Sucesso
        Pedido_IntegracaoDeSistema_Realizar_UmaPizzaComDoisSaboresEBorda_UmCalzone_UmaBebida_Sucesso
        */
        #endregion

        private Pedido _pedido;

        private Cliente _cliente;

        private Pizza _pizza;
        private Calzone _calzone;
        private Sabor _saborQueijo;
        private Sabor _saborCoracao;
        private Adicional _bordaCatupiry;

        private ProdutoPedido _produtoPedido;
        private ProdutoGenerico _produtoGenerico;

        [SetUp]
        public void IniciarCenario()
        {
            _pedido = new Pedido();

            _cliente = new Cliente();

            _pizza = new Pizza();
            _calzone = new Calzone();
            _produtoPedido = new ProdutoPedido();
            _produtoGenerico = new Bebida();

            _saborQueijo = new Sabor();
            _saborQueijo.ValorPequena = 30;
            _saborQueijo.ValorMedia = 40;
            _saborQueijo.ValorGrande = 50;
            _saborQueijo.ValorCalzone = 45;

            _saborCoracao = new Sabor();
            _saborCoracao.ValorPequena = 40;
            _saborCoracao.ValorMedia = 50;
            _saborCoracao.ValorGrande = 60;
            _saborCoracao.ValorCalzone = 55;

            _bordaCatupiry = ObjectMother.ObterAdicional_BordaCatupiry();

            _pedido.Cliente = _cliente;
            _pedido.FormaPagamento = FormaPagamentoPedido.DINHEIRO;
        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_UmaPizza_UmSabor_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.GRANDE;
            _pizza.Sabor1 = _saborQueijo;

            _pedido.Produtos.Add(_pizza);

            double valorTotalEsperado = _saborQueijo.ValorGrande;

            Action realizarPedido = _pedido.Realizar;

            realizarPedido.Should().NotThrow();
            _pedido.Status.Should().Be(StatusPedido.AGUARDANDO_MONTAGEM);

            _pedido.ValorTotal.Should().Be(valorTotalEsperado);
        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_UmaPizza_DoisSabores_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.GRANDE;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Sabor2 = _saborCoracao;

            _pedido.Produtos.Add(_pizza);

            double valorTotalEsperado = _saborCoracao.ValorGrande;

            Action realizarPedido = _pedido.Realizar;

            realizarPedido.Should().NotThrow();
            _pedido.Status.Should().Be(StatusPedido.AGUARDANDO_MONTAGEM);

            _pedido.ValorTotal.Should().Be(valorTotalEsperado);
        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_UmaPizza_UmSaborComBorda_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.GRANDE;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Adicional = _bordaCatupiry;

            _pedido.Produtos.Add(_pizza);

            double valorTotalEsperado = _saborQueijo.ValorGrande + _bordaCatupiry.ValorGrande;

            Action realizarPedido = _pedido.Realizar;

            realizarPedido.Should().NotThrow();
            _pedido.Status.Should().Be(StatusPedido.AGUARDANDO_MONTAGEM);

            _pedido.ValorTotal.Should().Be(valorTotalEsperado);
        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_DuasPizzas_UmSabor_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.GRANDE;
            _pizza.Sabor1 = _saborQueijo;

            _pedido.Produtos.Add(_pizza);

            _pizza = new Pizza();
            _pizza.Tamanho = TamanhoPizza.MEDIA;
            _pizza.Sabor1 = _saborCoracao;

            _pedido.Produtos.Add(_pizza);

            double valorTotalEsperado = _saborQueijo.ValorGrande + _saborCoracao.ValorMedia;

            Action realizarPedido = _pedido.Realizar;

            realizarPedido.Should().NotThrow();
            _pedido.Status.Should().Be(StatusPedido.AGUARDANDO_MONTAGEM);

            _pedido.ValorTotal.Should().Be(valorTotalEsperado);
        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_DuasPizzas_DoisSabores_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.GRANDE;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Sabor2 = _saborCoracao;

            _pedido.Produtos.Add(_pizza);

            _pizza = new Pizza();
            _pizza.Tamanho = TamanhoPizza.MEDIA;
            _pizza.Sabor1 = _saborCoracao;
            _pizza.Sabor2 = _saborQueijo;

            _pedido.Produtos.Add(_pizza);

            double valorTotalEsperado = _saborCoracao.ValorGrande + _saborCoracao.ValorMedia;

            Action realizarPedido = _pedido.Realizar;

            realizarPedido.Should().NotThrow();
            _pedido.Status.Should().Be(StatusPedido.AGUARDANDO_MONTAGEM);

            _pedido.ValorTotal.Should().Be(valorTotalEsperado);
        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_DuasPizzas_UmSabor_AdicionalNaPrimeira_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.GRANDE;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Adicional = _bordaCatupiry;

            _pedido.Produtos.Add(_pizza);

            _pizza = new Pizza();
            _pizza.Tamanho = TamanhoPizza.MEDIA;
            _pizza.Sabor1 = _saborCoracao;

            _pedido.Produtos.Add(_pizza);

            double valorTotalEsperado = _saborQueijo.ValorGrande + _saborCoracao.ValorMedia + _bordaCatupiry.ValorGrande;

            Action realizarPedido = _pedido.Realizar;

            realizarPedido.Should().NotThrow();
            _pedido.Status.Should().Be(StatusPedido.AGUARDANDO_MONTAGEM);

            _pedido.ValorTotal.Should().Be(valorTotalEsperado);

        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_DuasPizzas_UmSabor_AdicionalNaSegunda_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.GRANDE;
            _pizza.Sabor1 = _saborQueijo;

            _pedido.Produtos.Add(_pizza);

            _pizza = new Pizza();
            _pizza.Tamanho = TamanhoPizza.MEDIA;
            _pizza.Sabor1 = _saborCoracao;
            _pizza.Adicional = _bordaCatupiry;

            _pedido.Produtos.Add(_pizza);

            double valorTotalEsperado = _saborQueijo.ValorGrande + _saborCoracao.ValorMedia + _bordaCatupiry.ValorMedia;

            Action realizarPedido = _pedido.Realizar;

            realizarPedido.Should().NotThrow();
            _pedido.Status.Should().Be(StatusPedido.AGUARDANDO_MONTAGEM);

            _pedido.ValorTotal.Should().Be(valorTotalEsperado);
        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_DuasPizzas_UmSabor_AdicionalNasDuas_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.GRANDE;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Adicional = _bordaCatupiry;

            _pedido.Produtos.Add(_pizza);

            _pizza = new Pizza();
            _pizza.Tamanho = TamanhoPizza.MEDIA;
            _pizza.Sabor1 = _saborCoracao;
            _pizza.Adicional = _bordaCatupiry;

            _pedido.Produtos.Add(_pizza);

            double valorTotalEsperado = _saborQueijo.ValorGrande + _saborCoracao.ValorMedia + _bordaCatupiry.ValorMedia + _bordaCatupiry.ValorGrande;

            Action realizarPedido = _pedido.Realizar;

            realizarPedido.Should().NotThrow();
            _pedido.Status.Should().Be(StatusPedido.AGUARDANDO_MONTAGEM);

            _pedido.ValorTotal.Should().Be(valorTotalEsperado);
        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_Calzone_Sucesso()
        {
            _calzone.Sabor1 = _saborQueijo;

            _pedido.Produtos.Add(_calzone);

            double valorTotalEsperado = _saborQueijo.ValorCalzone;

            Action realizarPedido = _pedido.Realizar;

            realizarPedido.Should().NotThrow();
            _pedido.Status.Should().Be(StatusPedido.AGUARDANDO_MONTAGEM);

            _pedido.ValorTotal.Should().Be(valorTotalEsperado);
        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_Bebida_Sucesso()
        {
            _produtoGenerico.Descricao = "Coca-cola 2L";
            _produtoGenerico.Valor = 10;

            _produtoPedido.Produto = _produtoGenerico;

            _pedido.Produtos.Add(_produtoPedido);

            double valorTotalEsperado = _produtoGenerico.Valor;

            Action realizarPedido = _pedido.Realizar;

            realizarPedido.Should().NotThrow();
            _pedido.Status.Should().Be(StatusPedido.AGUARDANDO_MONTAGEM);

            _pedido.ValorTotal.Should().Be(valorTotalEsperado);
        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_UmaPizza_UmaBebida_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.GRANDE;
            _pizza.Sabor1 = _saborQueijo;

            _pedido.Produtos.Add(_pizza);

            _produtoGenerico.Descricao = "Coca-cola 2L";
            _produtoGenerico.Valor = 10;

            _produtoPedido.Produto = _produtoGenerico;

            _pedido.Produtos.Add(_produtoPedido);

            double valorTotalEsperado = _saborQueijo.ValorGrande + _produtoGenerico.Valor;

            Action realizarPedido = _pedido.Realizar;

            realizarPedido.Should().NotThrow();
            _pedido.Status.Should().Be(StatusPedido.AGUARDANDO_MONTAGEM);

            _pedido.ValorTotal.Should().Be(valorTotalEsperado);
        }



        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_UmaPizzaComDoisSaboresEBorda_UmCalzone_UmaBebida_Sucesso()
        {
            _pizza.Tamanho = TamanhoPizza.GRANDE;
            _pizza.Sabor1 = _saborQueijo;
            _pizza.Sabor2 = _saborCoracao;
            _pizza.Adicional = _bordaCatupiry;

            _pedido.Produtos.Add(_pizza);

            _calzone.Sabor1 = _saborQueijo;

            _pedido.Produtos.Add(_calzone);

            _produtoGenerico.Descricao = "Coca-cola 2L";
            _produtoGenerico.Valor = 10;

            _produtoPedido.Produto = _produtoGenerico;

            _pedido.Produtos.Add(_produtoPedido);

            double valorTotalEsperado = _saborCoracao.ValorGrande + _bordaCatupiry.ValorGrande + _saborQueijo.ValorCalzone + _produtoGenerico.Valor;

            Action realizarPedido = _pedido.Realizar;

            realizarPedido.Should().NotThrow();
            _pedido.Status.Should().Be(StatusPedido.AGUARDANDO_MONTAGEM);

            _pedido.ValorTotal.Should().Be(valorTotalEsperado);
        }
    }
}
