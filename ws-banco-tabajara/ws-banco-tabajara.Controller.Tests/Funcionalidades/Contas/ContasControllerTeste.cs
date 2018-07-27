using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using ws_banco_tabajara.API.Controladores.Funcionalidades.Contas;
using ws_banco_tabajara.Application.Funcionalidades.Contas;
using ws_banco_tabajara.Common.Tests.Funcionalidades;
using ws_banco_tabajara.Controller.Tests.Inicializador;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

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
        public void Conta_Controller_Put_Sacar_Sucesso()
        {
            // Arrange
            double valorSaque = 10;
            var conta = ObjectMother.ObterContaValida();
            conta.Id = 1;
            _contaServicoMock.Setup(c => c.Editar(conta));
            // Action
            IHttpActionResult callback = _contasController.Sacar(conta.Id, valorSaque);
            // Assert
            //Descomentar linha abaixo e trocar pelo tipo de retorno do método
            //var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            //httpResponse.Content.Should().BeTrue();
            _contaServicoMock.Verify(s => s.Sacar(conta.Id, valorSaque), Times.Once);

            1.Should().Be(2);
        }

        [Test]
        public void Conta_Controller_Put_Depositar_Sucesso()
        {
            // Arrange
            double valorDeposito = 10;
            var conta = ObjectMother.ObterContaValida();
            conta.Id = 1;
            _contaServicoMock.Setup(c => c.Editar(conta));
            // Action
            IHttpActionResult callback = _contasController.Depositar(conta.Id, valorDeposito);
            // Assert
            //Descomentar linha abaixo e trocar pelo tipo de retorno do método
            //var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            //httpResponse.Content.Should().BeTrue();
            _contaServicoMock.Verify(s => s.Depositar(conta.Id, valorDeposito), Times.Once);

            1.Should().Be(2);
        }

        [Test]
        public void Conta_Controller_Put_Transferir_Sucesso()
        {
            // Arrange
            double valorTransferido = 10;
            var conta = ObjectMother.ObterContaValida();
            conta.Id = 1;

            var contaDestino = ObjectMother.ObterContaValida();
            contaDestino.Id = 2;

            _contaServicoMock.Setup(c => c.Editar(conta));
            // Action
            IHttpActionResult callback = _contasController.Transferir(conta.Id, contaDestino.Id, valorTransferido);
            // Assert
            //Descomentar linha abaixo e trocar pelo tipo de retorno do método
            //var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            //httpResponse.Content.Should().BeTrue();
            _contaServicoMock.Verify(s => s.Transferir(conta.Id, contaDestino.Id, valorTransferido), Times.Once);

            1.Should().Be(2);
        }

    }
}
