using FluentAssertions;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using ws_banco_tabajara.API.Excecoes;
using ws_banco_tabajara.Controller.Tests.Inicializador;
using ws_banco_tabajara.Domain.Excecoes;

namespace ws_banco_tabajara.Controller.Tests.Base
{
    [TestFixture]
    public class ControladorBaseAPITeste : ControladorBaseTeste
    {
        private ControladorBaseAPIFake _controladorBaseAPIFake;
        private Mock<ControladorBaseAPIDummy> _controladorBaseAPIDummy;

        [SetUp]
        public void IniciarCenario()
        {
            HttpRequestMessage requisicao = new HttpRequestMessage();
            requisicao.SetConfiguration(new HttpConfiguration());
            _controladorBaseAPIFake = new ControladorBaseAPIFake()
            {
                Request = requisicao
            };
            _controladorBaseAPIDummy = new Mock<ControladorBaseAPIDummy>();
        }

        #region HandleCallback

        [Test]
        public void Base_Controlador_HandleCallback_DeveTratarExcecaoDeNegocio()
        {
            //Arrange
            var mensagem = "Teste de erro";
            var excecao = new ExcecaoDeNegocio(CodigosDeErro.AlreadyExists, mensagem);
            // Action
            var callback = _controladorBaseAPIFake.HandleCallback<ControladorBaseAPIDummy>(() => throw excecao);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            httpResponse.Content.CodigoDoErro.Should().Be((int)CodigosDeErro.AlreadyExists);
            httpResponse.Content.MensagemDoErro.Should().Be(mensagem);
        }

        [Test]
        public void Base_Controlador_HandleCallback_DeveTratarExcecaoEmTempoDeExecucao()
        {
            //Arrange
            var mensagem = "Teste de erro";
            var excecao = new Exception(mensagem);
            // Action
            var callback = _controladorBaseAPIFake.HandleCallback<ControladorBaseAPIDummy>(() => throw excecao);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<ExceptionPayload>>().Subject;
            httpResponse.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
            httpResponse.Content.CodigoDoErro.Should().Be((int)CodigosDeErro.Unhandled);
            httpResponse.Content.MensagemDoErro.Should().Be(mensagem);
        }

        #endregion

        #region HandleQuery

        [Test]
        public void Base_Controlador_HandleQuery_Sucesso()
        {
            //Arrange
            var query = new List<ControladorBaseAPIDummy>() { _controladorBaseAPIDummy.Object }.AsQueryable();
            // Action
            var callback = _controladorBaseAPIFake.HandleQuery(query);
            //Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<ControladorBaseAPIDummy>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
        }

        #endregion

        #region HandleQueryable

        [Test]
        public void Base_Controlador_HandleQueryable_Sucesso()
        {
            //Arrange
            var query = new List<ControladorBaseAPIDummy>() { _controladorBaseAPIDummy.Object }.AsQueryable();
            // Action
            var callback = _controladorBaseAPIFake.HandleQueryable<ControladorBaseAPIDummy>(query);
            //Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<ControladorBaseAPIDummy>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
        }

        #endregion

        #region HandleValidationFailure

        [Test]
        public void Base_Controlador_HandleValidationFailure_DeveTratarErrosDeValidacao()
        {
            //Arrange
            var validationFailure = new ValidationFailure("", ((int)CodigosDeErro.Unhandled).ToString());
            IList<ValidationFailure> erros = new List<ValidationFailure>() { validationFailure };
            // Action
            var callback = _controladorBaseAPIFake.HandleValidationFailure(erros);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.FirstOrDefault().Should().Be(validationFailure);
        }

        #endregion
    }
}
