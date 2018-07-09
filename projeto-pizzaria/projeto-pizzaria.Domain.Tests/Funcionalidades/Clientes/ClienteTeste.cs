using FluentAssertions;
using Moq;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Clientes.Excecoes;
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
            _mockEndereco = new Mock<Endereco>();
            _mockDocumento = new Mock<IDocumento>();
        }

        [Test]
        public void Cliente_Dominio_Validar_Sucesso()
        {
            Cliente clienteParaValidar = ObjectMother.ObterClienteValidoSemDocumento(_mockEndereco.Object);

            Action resultadoDaValidacao = () => clienteParaValidar.Validar();

            resultadoDaValidacao.Should().NotThrow<Exception>();
        }

        [Test]
        public void Cliente_Dominio_Validar_ClienteSemEnderecoExcecao_Falha()
        {
            Cliente clienteParaValidar = ObjectMother.ObterClienteSemEnderecoNemDocumento();

            Action resultadoDaValidacao = () => clienteParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<ClienteSemEnderecoExcecao>();
        }

        [Test]
        public void Cliente_Dominio_Validar_ClienteSemTelefoneExcecao_Falha()
        {
            Cliente clienteParaValidar = ObjectMother.ObterClienteSemTelefoneNemDocumento(_mockEndereco.Object);

            Action resultadoDaValidacao = () => clienteParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<ClienteSemTelefoneExcecao>();
        }

        [Test]
        public void Cliente_Dominio_Validar_ClienteSemNomeExcecao_Falha()
        {
            Cliente clienteParaValidar = ObjectMother.ObterClienteSemNomeNemDocumento(_mockEndereco.Object);

            Action resultadoDaValidacao = () => clienteParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<ClienteSemNomeExcecao>();
        }
    }
}
