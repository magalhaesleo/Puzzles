using FluentAssertions;
using Moq;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Excecoes;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos.Excecoes;
using projeto_pizzaria.Domain.Funcionalidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Tests.Funcionalidades.Pedidos
{
    [TestFixture]
    public class PedidoTeste
    {
        private Pedido _pedido;

        private Mock<Cliente> _clienteMock;
        private List<Produto> _produtos;
        private Mock<Produto> _produtoMock;

        [SetUp]
        public void IniciarCenario()
        {
            _pedido = new Pedido();
            _clienteMock = new Mock<Cliente>();
            _produtos = new List<Produto>();
            _produtoMock = new Mock<Produto>();
        }

        [Test]
        public void Pedido_Dominio_Validar_Sucesso()
        {
            _produtoMock.Setup(pm => pm.Valor).Returns(1);
            _produtos.Add(_produtoMock.Object);
            _pedido = ObjectMother.ObterPedidoValido(_clienteMock.Object, _produtos);

            Action resultado = _pedido.Validar;

            resultado.Should().NotThrow<ExcecaoDeNegocio>();
        }

        [Test]
        public void Pedido_Dominio_Validar_PedidoSemCliente_Falha()
        {
            _pedido.Cliente = null;

            Action resultado = _pedido.Validar;

            resultado.Should().Throw<PedidoSemClienteExcecao>();
        }

        [Test]
        public void Pedido_Dominio_Validar_PedidoSemProdutos_Falha()
        {
            _pedido.Cliente = _clienteMock.Object;
            _pedido.Produtos = _produtos;
            _pedido.FormaPagamento = FormaPagamentoPedido.DINHEIRO;

            Action resultado = _pedido.Validar;

            resultado.Should().Throw<PedidoSemProdutosExcecao>();
        }


        [Test]
        public void Pedido_Dominio_Validar_PedidoSemFormaDePagamentoExcecao_Falha()
        {
            _produtos.Add(_produtoMock.Object);
            _pedido = ObjectMother.ObterPedidoSemFormaDePagamento(_clienteMock.Object, _produtos);

            Action resultado = _pedido.Validar;

            resultado.Should().Throw<PedidoSemFormaDePagamentoExcecao>();
        }

        [Test]
        public void Pedido_Dominio_Validar_PedidoComValorTotalZeroOuNegativoExcecao_Falha()
        {
            _produtos.Add(_produtoMock.Object);
            _pedido = ObjectMother.ObterPedidoValido(_clienteMock.Object, _produtos);

            Action resultado = _pedido.Validar;

            resultado.Should().Throw<PedidoComValorTotalZeroOuNegativoExcecao>();
        }


        [Test]
        public void Pedido_Dominio_AtualizarStatus_Sucesso()
        {
            _produtoMock.Setup(pm => pm.Valor).Returns(1);
            _produtos.Add(_produtoMock.Object);
            _pedido = ObjectMother.ObterPedidoValido(_clienteMock.Object, _produtos);

            _pedido.AtualizarStatus();

            _pedido.Status.Should().Be(StatusPedido.EM_MONTAGEM);
        }

        [Test]
        public void Pedido_Dominio_AtualizarStatus_PedidoEntregue_DevePermanecerEntregue()
        {
            _produtoMock.Setup(pm => pm.Valor).Returns(1);
            _produtos.Add(_produtoMock.Object);
            _pedido = ObjectMother.ObterPedidoValido(_clienteMock.Object, _produtos);

            _pedido.Status = StatusPedido.ENTREGUE;

            _pedido.AtualizarStatus();

            _pedido.Status.Should().Be(StatusPedido.ENTREGUE);
        }
    }
}
