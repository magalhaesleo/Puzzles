using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Enderecos.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Funcionalidades.Enderecos
{
    [TestFixture]
    public class EnderecoTeste
    {

        [Test]
        public void Endereco_Dominio_Validar_Sucesso()
        {
            Endereco enderecoParaValidar = ObjectMother.PegarEnderecoValido();

            Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

            resultadoDaValidacao.Should().NotThrow<Exception>();
        }

        [Test]
        public void Endereco_Dominio_Validar_ExcecaoEnderecoSemBairro_Falha()
        {
            Endereco enderecoParaValidar = ObjectMother.PegarEnderecoSemBairro();

            Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<ExcecaoEnderecoSemBairro>();
        }

        [Test]
        public void Endereco_Dominio_Validar_ExcecaoEnderecoSemMunicipio_Falha()
        {
            Endereco enderecoParaValidar = ObjectMother.PegarEnderecoSemMunicipio();

            Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<ExcecaoEnderecoSemMunicipio>();
        }

        [Test]
        public void Endereco_Dominio_Validar_ExcecaoEnderecoSemPais_Falha()
        {
            Endereco enderecoParaValidar = ObjectMother.PegarEnderecoSemPais();

            Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<ExcecaoEnderecoSemPais>();
        }

        [Test]
        public void Endereco_Dominio_Validar_ExcecaoEnderecoSemEstado_Falha()
        {
            Endereco enderecoParaValidar = ObjectMother.PegarEnderecoSemEstado();

            Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<ExcecaoEnderecoSemEstado>();
        }

        [Test]
        public void Endereco_Dominio_Validar_ExcecaoEnderecoSemLogradouro_Falha()
        {
            Endereco enderecoParaValidar = ObjectMother.PegarEnderecoSemLogradouro();

            Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<ExcecaoEnderecoSemLogradouro>();
        }

        [Test]
        public void Endereco_Dominio_Validar_ExcecaoEnderecoSemNumero_Falha()
        {
            Endereco enderecoParaValidar = ObjectMother.PegarEnderecoSemNumero();

            Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<ExcecaoEnderecoSemNumero>();
        }
    }
}
