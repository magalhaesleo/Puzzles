using FluentAssertions;
using Moq;
using NUnit.Framework;
using projeto_pizzaria.Domain.Funcionalidades.Enderecos;
using projeto_pizzaria.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Tests.Funcionalidades.Clientes
{
    [TestFixture]
    public class ClienteTeste
    {

        Mock<Endereco> _mockEndereco;
        Mock<IDocumento> _mockDocumento;

        [SetUp]
        public void IniciarCenario()
        {

        }

        [Test]
        public void Cliente_Dominio_Validar_Sucesso()
        {
            1.Should().Be(2);
        }

        [Test]
        public void Cliente_Dominio_Validar_Sucesso()
        {
            1.Should().Be(2);
        }

        [Test]
        public void Cliente_Dominio_Validar_Sucesso()
        {
            1.Should().Be(2);
        }
    }
}
