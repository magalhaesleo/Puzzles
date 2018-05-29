using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Funcionalidades.Emitentes
{
    [TestFixture]
    public class EmitenteTeste
    {
        private Mock<Endereco> _enderecoMock;

        [SetUp]
        public void Inicializa()
        {
            _enderecoMock = new Mock<Endereco>();
        }

        [Test]
        public void Emitente_Validar_Sucesso()
        {
            Emitente emitente = ObjectMother.PegarEmitenteValido(_enderecoMock.Object);

            Action resultado = () => emitente.Validar();

            resultado.Should().NotThrow<ExcecaoDeNegocio>();
        }
    }
}
