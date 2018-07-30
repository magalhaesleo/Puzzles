using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using ws_banco_tabajara.API.Controladores.Funcionalidades.Contas;
using ws_banco_tabajara.Application.Funcionalidades.Contas;
using ws_banco_tabajara.Common.Tests.Funcionalidades;
using ws_banco_tabajara.Controller.Tests.Inicializador;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Extratos;

namespace ws_banco_tabajara.Controller.Tests.Funcionalidades.Contas
{
    [TestFixture]
    public class ContasControllerTeste : ControladorBaseTeste
    {
        private ContasController _contasController;
        private Mock<IContaServico> _contaServicoMock;

        private Mock<Conta> _contaMock;

        [SetUp]
        public void IniciarCenario()
        {
            HttpRequestMessage requisicao = new HttpRequestMessage();
            requisicao.SetConfiguration(new HttpConfiguration());
            _contaServicoMock = new Mock<IContaServico>();
            _contasController = new ContasController()
            {
                Request = requisicao,
                _contaServico = _contaServicoMock.Object,
            };
            _contaMock = new Mock<Conta>();
        }
        [Test]
        public void Conta_Controller_Get_BuscarTodas_Sucesso()
        {
            Conta conta = ObjectMother.ObterContaValida();
            conta.Id = 1;
            IQueryable<Conta> response = new List<Conta>() { conta }.AsQueryable();
            _contaServicoMock.Setup(s => s.BuscarTodos()).Returns(response);

            IHttpActionResult callback = _contasController.BuscarTodos();


            _contaServicoMock.Verify(s => s.BuscarTodos(), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<Conta>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(conta.Id);
        }
        [Test]
        public void Conta_Controller_Get_Limitado_Sucesso()
        {
            Conta conta = ObjectMother.ObterContaValida();
            IQueryable<Conta> response = new List<Conta>() { conta, conta }.AsQueryable();
            int quantidadeParaBuscar = 2;
            _contaServicoMock.Setup(s => s.BuscarListaPorQuantidadeDefinida(quantidadeParaBuscar)).Returns(response);
            UriBuilder uriComQuantidadeDeContas = new UriBuilder();
            uriComQuantidadeDeContas.Query = "quantidade=2";
            _contasController.Request = new HttpRequestMessage(HttpMethod.Get, uriComQuantidadeDeContas.Uri);

            IHttpActionResult callback = _contasController.BuscarTodos();

            _contaServicoMock.Verify(s => s.BuscarListaPorQuantidadeDefinida(quantidadeParaBuscar), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<Conta>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.Should().HaveCount(quantidadeParaBuscar);
        }
        [Test]
        public void Conta_Controller_Get_IdEspecifico_Sucesso()
        {
            Conta conta = ObjectMother.ObterContaValida();
            conta.Id = 1;
            _contaServicoMock.Setup(c => c.Buscar(conta.Id)).Returns(conta);

            IHttpActionResult callback = _contasController.Buscar(conta.Id);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<Conta>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(conta.Id);
            _contaServicoMock.Verify(s => s.Buscar(conta.Id), Times.Once);
        }
        [Test]
        public void Conta_Controller_Post_Sucesso()
        {
            Conta conta = ObjectMother.ObterContaValida();
            conta.Id = 1;
            _contaServicoMock.Setup(c => c.Adicionar(conta)).Returns(conta);

            IHttpActionResult callback = _contasController.Adicionar(conta);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<Conta>>().Subject;
            httpResponse.Content.Should().Be(conta);
            _contaServicoMock.Verify(s => s.Adicionar(conta), Times.Once);
        }

        [Test]
        public void Conta_Controller_Put_Editar_Sucesso()
        {
            Conta conta = ObjectMother.ObterContaValida();
            bool resultadoEdicaoconta = true;
            _contaServicoMock.Setup(c => c.Editar(conta)).Returns(resultadoEdicaoconta);

            IHttpActionResult callback = _contasController.Editar(conta);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _contaServicoMock.Verify(s => s.Editar(conta), Times.Once);
        }

        [Test]
        public void Conta_Controller_Delete_Excluir_Sucesso()
        {
            long idConta = 1;

            _contaServicoMock.Setup(c => c.Excluir(idConta));

            IHttpActionResult callback = _contasController.Excluir(idConta);

            var httpResponse = callback.Should().BeOfType<OkResult>().Subject;
            _contaServicoMock.Verify(s => s.Excluir(idConta), Times.Once);
        }

        [Test]
        public void Conta_Controller_Patch_AlterarStatus_Sucesso()
        {
            long idConta = 1;
            bool statusAlteradoRetorno = true;
            _contaServicoMock.Setup(c => c.AlterarStatusConta(idConta)).Returns(statusAlteradoRetorno);

            IHttpActionResult callback = _contasController.AlterarStatus(idConta);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().Be(statusAlteradoRetorno);
            _contaServicoMock.Verify(s => s.AlterarStatusConta(idConta), Times.Once);
        }
        [Test]
        public void Conta_Controller_Put_Sacar_Sucesso()
        {
            double valorSaque = 10;
            var conta = ObjectMother.ObterContaValida();

            _contaServicoMock.Setup(c => c.Sacar(conta.Id, valorSaque)).Returns(conta);

            IHttpActionResult callback = _contasController.Sacar(conta.Id, valorSaque);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<Conta>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _contaServicoMock.Verify(s => s.Sacar(conta.Id, valorSaque), Times.Once);
        }

        [Test]
        public void Conta_Controller_Put_Depositar_Sucesso()
        {
            double valorDeposito = 10;
            var conta = ObjectMother.ObterContaValida();
            _contaServicoMock.Setup(c => c.Depositar(conta.Id, valorDeposito)).Returns(conta);

            IHttpActionResult callback = _contasController.Depositar(conta.Id, valorDeposito);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<Conta>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _contaServicoMock.Verify(s => s.Depositar(conta.Id, valorDeposito), Times.Once);
        }

        [Test]
        public void Conta_Controller_Put_Transferir_Sucesso()
        {
            double valorTransferido = 10;
            var conta = ObjectMother.ObterContaValida();
            conta.Id = 1;

            var contaDestino = ObjectMother.ObterContaValida();
            contaDestino.Id = 2;

            _contaServicoMock.Setup(c => c.Transferir(conta.Id, contaDestino.Id, valorTransferido)).Returns(conta);

            IHttpActionResult callback = _contasController.Transferir(conta.Id, contaDestino.Id, valorTransferido);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<Conta>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _contaServicoMock.Verify(s => s.Transferir(conta.Id, contaDestino.Id, valorTransferido), Times.Once);
        }

        [Test]
        public void Conta_Controller_Get_Extrato_Sucesso()
        {
            Extrato extrato = ObjectMother.ObterExtratoValido();
            long idConta = 1;
            _contaServicoMock.Setup(c => c.GerarExtrato(idConta)).Returns(extrato);

            IHttpActionResult callback = _contasController.GerarExtrato(idConta);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<Extrato>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _contaServicoMock.Verify(s => s.GerarExtrato(idConta), Times.Once);
        }
    }
}
