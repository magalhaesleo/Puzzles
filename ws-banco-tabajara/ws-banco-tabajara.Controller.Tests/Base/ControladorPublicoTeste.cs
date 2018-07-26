using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using ws_banco_tabajara.API.Controladores.Base;

namespace ws_banco_tabajara.Controller.Tests.Base
{
    [TestFixture]
    public class ControladorPublicoTeste
    {

        private ControladorPublico _controladorPublico;

        [SetUp]
        public void IniciarCenario()
        {
            HttpRequestMessage requisicao = new HttpRequestMessage();
            requisicao.SetConfiguration(new HttpConfiguration());
            _controladorPublico = new ControladorPublico()
            {
                Request = requisicao
            };
        }

        #region GET

        [Test]
        public void Publico_Controlador_IsAlive_Sucesso()
        {
            // Action
            var callback = _controladorPublico.IsAlive();

            //Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
        }

        #endregion

    }
}
