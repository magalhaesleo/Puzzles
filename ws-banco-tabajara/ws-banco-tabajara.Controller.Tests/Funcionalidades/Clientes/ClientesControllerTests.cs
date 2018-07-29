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
using ws_banco_tabajara.API.Controladores.Funcionalidades.Clientes;
using ws_banco_tabajara.Application.Funcionalidades.Clientes;
using ws_banco_tabajara.Common.Tests.Funcionalidades;
using ws_banco_tabajara.Controller.Tests.Inicializador;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;

namespace ws_banco_tabajara.Controller.Tests.Funcionalidades.Clientes
{
    [TestFixture]
    public class ClientesControllerTests : ControladorBaseTeste
    {
        private ClientesController _clientesController;
        private Mock<IClienteServico> _mockServicoCliente;
        private Mock<Cliente> _mockCliente;

        [SetUp]
        public void IniciarCenario()
        {
            HttpRequestMessage requisicao = new HttpRequestMessage();
            requisicao.SetConfiguration(new HttpConfiguration());
            _mockServicoCliente = new Mock<IClienteServico>();
            _clientesController = new ClientesController()
            {
                Request = requisicao,
                _clienteServico = _mockServicoCliente.Object,
            };
            _mockCliente = new Mock<Cliente>();
        }

        #region GET

        [Test]
        public void Cliente_Controller_Get_Sucesso()
        {
            Cliente cliente = ObjectMother.ObterClienteValido();
            cliente.Id = 1;
            var resposta = new List<Cliente> { cliente }.AsQueryable();
            _mockServicoCliente.Setup(msc => msc.BuscarTodos()).Returns(resposta);

            var callback = _clientesController.BuscarTodos();

            _mockServicoCliente.Verify(msc => msc.BuscarTodos(), Times.Once);
            var respostaHttp = callback.Should().BeOfType<OkNegotiatedContentResult<List<Cliente>>>().Subject;
            respostaHttp.Content.Should().NotBeNullOrEmpty();
            respostaHttp.Content.First().Id.Should().Be(cliente.Id);
        }

        [Test]
        public void Cliente_Controller_Get_Limitado_Sucesso()
        {
            Cliente cliente = ObjectMother.ObterClienteValido();
            IQueryable<Cliente> resposta = new List<Cliente>() { cliente, cliente }.AsQueryable();
            int quantidadeParaBuscar = 2;
            _mockServicoCliente.Setup(msc => msc.BuscarListaPorQuantidadeDefinida(quantidadeParaBuscar)).Returns(resposta);
            UriBuilder uriComQuantidadeDeContas = new UriBuilder();
            uriComQuantidadeDeContas.Query = "quantidade=2";
            _clientesController.Request = new HttpRequestMessage(HttpMethod.Get, uriComQuantidadeDeContas.Uri);

            IHttpActionResult callback = _clientesController.BuscarTodos();

            _mockServicoCliente.Verify(msc => msc.BuscarListaPorQuantidadeDefinida(quantidadeParaBuscar), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<Cliente>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.Should().HaveCount(quantidadeParaBuscar);
        }

        [Test]
        public void Cliente_Controller_Get_IdEspecifico_Sucesso()
        {
            Cliente cliente = ObjectMother.ObterClienteValido();
            cliente.Id = 1;
            _mockServicoCliente.Setup(msc => msc.Buscar(cliente.Id)).Returns(cliente);

            var callback = _clientesController.Buscar(cliente.Id);

            _mockServicoCliente.Verify(msc => msc.Buscar(cliente.Id), Times.Once);
            var respostaHttp = callback.Should().BeOfType<OkNegotiatedContentResult<Cliente>>().Subject;
            respostaHttp.Content.Should().NotBeNull();
            respostaHttp.Content.Id.Should().Be(cliente.Id);
        }

        #endregion GET

        #region POST


        [Test]
        public void Cliente_Controller_Post_Sucesso()
        {
            Cliente cliente = ObjectMother.ObterClienteValido();
            _mockServicoCliente.Setup(msc => msc.Adicionar(cliente)).Returns(cliente);

            IHttpActionResult callback = _clientesController.Adicionar(cliente);

            var respostaHttp = callback.Should().BeOfType<OkNegotiatedContentResult<Cliente>>().Subject;

            respostaHttp.Content.Should().Be(cliente);
            _mockServicoCliente.Verify(msc => msc.Adicionar(cliente), Times.Once);
        }

        #endregion POST

        #region PUT


        [Test]
        public void Cliente_Controller_Put_Sucesso()
        {
            Cliente cliente = ObjectMother.ObterClienteValido();
            cliente.Id = 1;
            var clienteAtualizado = true;

            _mockServicoCliente.Setup(msc => msc.Editar(cliente));

            IHttpActionResult callback = _clientesController.Editar(cliente);

            var respostaHttp = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            respostaHttp.Content.Should().BeTrue();
            _mockServicoCliente.Verify(msc => msc.Editar(cliente), Times.Once);
        }

        #endregion PUT

        #region DELETE


        [Test]
        public void Cliente_Controller_Delete_Sucesso()
        {
            long idCliente = 1;

            _mockServicoCliente.Setup(msc => msc.Excluir(idCliente));

            IHttpActionResult callback = _clientesController.Excluir(idCliente);

            var respostaHttp = callback.Should().BeOfType<OkResult>().Subject;
            _mockServicoCliente.Verify(msc => msc.Excluir(idCliente), Times.Once);
        }

        #endregion DELETE

    }
}
