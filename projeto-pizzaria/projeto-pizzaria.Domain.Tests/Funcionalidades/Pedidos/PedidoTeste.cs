using FluentAssertions;
using Moq;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests;
using projeto_pizzaria.Domain.Excecoes;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos.Excecoes;
using projeto_pizzaria.Domain.Funcionalidades.Produtos;
using projeto_pizzaria.Infra.Interfaces;
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
        public void Pedido_Dominio_Validar_PedidoComClienteSemDocumentoExcecao_Falha()
        {
            _produtoMock.Setup(pm => pm.Valor).Returns(1);
            _produtos.Add(_produtoMock.Object);
            _pedido = ObjectMother.ObterPedidoValido(_clienteMock.Object, _produtos);
            _pedido.EmitirNota = true;

            _clienteMock.Setup(cm => cm.Documento).Returns(It.IsAny<IDocumento>());

            Action resultado = _pedido.Validar;

            resultado.Should().Throw<PedidoComClienteSemDocumentoExcecao>();

            _clienteMock.Verify(cm => cm.Documento);
        }

        [Test]
        public void Pedido_Dominio_Validar_PedidoParaEmpresaEmitindoNotaSemDepartamentoOuResponsavelExcecao_SemDepartamento_Falha()
        {
            string nomeResponsavel = "Responsavel";

            _produtoMock.Setup(pm => pm.Valor).Returns(1);
            _produtos.Add(_produtoMock.Object);
            _pedido = ObjectMother.ObterPedidoValido(_clienteMock.Object, _produtos);
            _pedido.EmitirNota = true;
            _pedido.Responsavel = nomeResponsavel;

            _clienteMock.Setup(cm => cm.Documento).Returns(ObjectMother.ObterCNPJValido());

            Action resultado = _pedido.Validar;

            resultado.Should().Throw<PedidoParaEmpresaEmitindoNotaSemDepartamentoOuResponsavelExcecao>();

            _clienteMock.Verify(cm => cm.Documento);
        }

        [Test]
        public void Pedido_Dominio_Validar_PedidoParaEmpresaEmitindoNotaSemDepartamentoOuResponsavelExcecao_SemResponsavel_Falha()
        {
            string departamento = "Departamento";

            _produtoMock.Setup(pm => pm.Valor).Returns(1);
            _produtos.Add(_produtoMock.Object);
            _pedido = ObjectMother.ObterPedidoValido(_clienteMock.Object, _produtos);
            _pedido.EmitirNota = true;
            _pedido.Departamento = departamento;

            _clienteMock.Setup(cm => cm.Documento).Returns(ObjectMother.ObterCNPJValido());

            Action resultado = _pedido.Validar;

            resultado.Should().Throw<PedidoParaEmpresaEmitindoNotaSemDepartamentoOuResponsavelExcecao>();

            _clienteMock.Verify(cm => cm.Documento);
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

        [Test]
        public void Pedido_Dominio_Realizar_ParaPessoaJuridica_Sucesso()
        {
            string nomeResponsavel = "Responsavel";
            string departamento = "Departamento";

            double valorProduto = 1;

            _clienteMock.Setup(cm => cm.Documento).Returns(ObjectMother.ObterCNPJValido());


            _produtoMock.Setup(pm => pm.Valor).Returns(valorProduto);
            _produtos.Add(_produtoMock.Object);
            _pedido = ObjectMother.ObterPedidoValido(_clienteMock.Object, _produtos);
            _pedido.EmitirNota = true;
            _pedido.Responsavel = nomeResponsavel;
            _pedido.Departamento = departamento;

            _pedido.Realizar();

            _pedido.ValorTotal.Should().Be(valorProduto);
        }

        [Test]
        public void Pedido_Dominio_Realizar_ParaPessoaFisica_Sucesso()
        {
            string nomeResponsavel = "Responsavel";
            string departamento = "Departamento";

            double valorProduto = 1;

            _clienteMock.Setup(cm => cm.Documento).Returns(ObjectMother.ObterCPFValido());


            _produtoMock.Setup(pm => pm.Valor).Returns(valorProduto);
            _produtos.Add(_produtoMock.Object);
            _pedido = ObjectMother.ObterPedidoValido(_clienteMock.Object, _produtos);
            _pedido.EmitirNota = true;
            _pedido.Responsavel = nomeResponsavel;
            _pedido.Departamento = departamento;

            _pedido.Realizar();

            _pedido.ValorTotal.Should().Be(valorProduto);
        }
    }
}
