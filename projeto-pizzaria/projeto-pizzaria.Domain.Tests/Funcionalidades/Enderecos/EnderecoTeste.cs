using FluentAssertions;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests.Funcionalidades;
using projeto_pizzaria.Domain.Funcionalidades.Enderecos;
using projeto_pizzaria.Domain.Funcionalidades.Enderecos.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Tests.Funcionalidades.Enderecos
{
    [TestFixture]
    public class EnderecoTeste
    {
        [SetUp]
        public void IniciarCenario()
        {

        }

        [Test]
        public void Endereco_Dominio_Validar_Sucesso()
        {
            Endereco enderecoParaValidar = ObjectMother.PegarEnderecoValido();

            Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

            resultadoDaValidacao.Should().NotThrow<Exception>();
        }

        [Test]
        public void Endereco_Dominio_Validar_EnderecoSemCEPExcecao_Falha()
        {
            Endereco enderecoParaValidar = ObjectMother.PegarEnderecoSemCEP();

            Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<EnderecoSemCEPExcecao>();
        }

        [Test]
        public void Endereco_Dominio_Validar_EnderecoSemCidadeExcecao_Falha()
        {
            Endereco enderecoParaValidar = ObjectMother.PegarEnderecoSemCidade();

            Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<EnderecoSemCidadeExcecao>();
        }

        [Test]
        public void Endereco_Dominio_Validar_EnderecoSemBairroExcecao_Falha()
        {
            Endereco enderecoParaValidar = ObjectMother.PegarEnderecoSemBairro();

            Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<EnderecoSemBairroExcecao>();
        }

        [Test]
        public void Endereco_Dominio_Validar_EnderecoSemRuaExcecao_Falha()
        {
            Endereco enderecoParaValidar = ObjectMother.PegarEnderecoSemRua();

            Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<EnderecoSemRuaExcecao>();
        }

        [Test]
        public void Endereco_Dominio_Validar_EnderecoSemNumeroExcecao_Falha()
        {
            Endereco enderecoParaValidar = ObjectMother.PegarEnderecoSemNumero();

            Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<EnderecoSemNumeroExcecao>();
        }

        [Test]
        public void Endereco_Dominio_Validar_EnderecoSemComplementoExcecao_Falha()
        {
            Endereco enderecoParaValidar = ObjectMother.PegarEnderecoSemComplemento();

            Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<EnderecoSemComplementoExcecao>();
        }
    }
}
