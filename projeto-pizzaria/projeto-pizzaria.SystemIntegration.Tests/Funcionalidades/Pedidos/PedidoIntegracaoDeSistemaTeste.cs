using FluentAssertions;
using NUnit.Framework;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Funcionalidades.Produtos;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Calzones;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Pizzas;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
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
        private List<Produto> _produtos;

        private Pizza _pizza;
        private Calzone _calzone;
        private ProdutoGenerico _produtoGenerico;

        [SetUp]
        public void IniciarCenario()
        {
            _pedido = new Pedido();

            _cliente = new Cliente();
            _produtos = new List<Produto>();

            _pizza = new Pizza();
            _calzone = new Calzone();
            _produtoGenerico = new ProdutoGenerico();
        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_UmaPizza_UmSabor_Sucesso()
        {
            1.Should().Be(2);
        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_UmaPizza_DoisSabores_Sucesso()
        {
            1.Should().Be(2);

        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_DuasPizzas_UmSabor_Sucesso()
        {
            1.Should().Be(2);

        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_DuasPizzas_DoisSabores_Sucesso()
        {
            1.Should().Be(2);

        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_Calzone_Sucesso()
        {
            1.Should().Be(2);

        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_Bebida_Sucesso()
        {
            1.Should().Be(2);

        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_UmaPizza_UmaBebida_Sucesso()
        {
            1.Should().Be(2);

        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_UmaPizza_ComBorda_Sucesso()
        {
            1.Should().Be(2);

        }

        [Test]
        public void Pedido_IntegracaoDeSistema_Realizar_UmaPizzaComDoisSaboresEBorda_UmCalzone_UmaBebida_Sucesso()
        {
            1.Should().Be(2);

        }
    }
}
