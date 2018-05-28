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

namespace Projeto_NFe.Domain.Tests.Enderecos
{
    [TestFixture]
    public class EnderecoTeste
    {
     
        [Test]
        public void Endereco_Validar_Sucesso()
        {
           Endereco enderecoParaValidar = ObjectMother.PegarEnderecoValido();

           Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

           resultadoDaValidacao.Should().NotThrow<Exception>();
        }

        [Test]
        public void Endereco_Validar_ExcecaoEnderecoSemBairro_Falha()
        {
            Endereco enderecoParaValidar = ObjectMother.PegarEnderecoSemBairro();

            Action resultadoDaValidacao = () => enderecoParaValidar.Validar();

            resultadoDaValidacao.Should().Throw<ExcecaoEnderecoSemBairro>();
        }
    }
}
