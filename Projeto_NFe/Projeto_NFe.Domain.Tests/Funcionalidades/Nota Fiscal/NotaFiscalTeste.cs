using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Funcionalidades.Nota_Fiscal
{
    [TestFixture]
    public class NotaFiscalTeste
    {
        Mock<Transportador> transportadorMock;
        Mock<Destinatario> destinatarioMock;
        NotaFiscal _notaFiscal;
        
        [SetUp]
        public void IniciarCenario()
        {
            _notaFiscal = new NotaFiscal();
            transportadorMock = new Mock<Transportador>();
            destinatarioMock = new Mock<Destinatario>();
        }

        [Test]
        public void NotaFiscal_Validar_Sucesso()
        {
            _notaFiscal.Destinatario = destinatarioMock.Object;
            _notaFiscal.Transportador = transportadorMock.Object;
            _notaFiscal.NaturezaOperacao = "Natureza";
            _notaFiscal.DataEntrada = DateTime.Now;

            Action resultado = _notaFiscal.ValidarGeracao;

            resultado.Should().NotThrow<ExcecaoDeNegocio>();
        }

        [Test]
        public void NotaFiscal_Validar_SemTransportador_Falha()
        {
            _notaFiscal.Destinatario = destinatarioMock.Object;
            _notaFiscal.NaturezaOperacao = "Natureza";
            _notaFiscal.DataEntrada = DateTime.Now;

            Action resultado = _notaFiscal.ValidarGeracao;

            resultado.Should().Throw<ExcecaoTransportadorInvalido>();
        }

        [Test]
        public void NotaFiscal_Validar_SemDestinatario_Falha()
        {
            _notaFiscal.Transportador = transportadorMock.Object;
            _notaFiscal.NaturezaOperacao = "Natureza";
            _notaFiscal.DataEntrada = DateTime.Now;

            Action acaoComExcecao = _notaFiscal.ValidarGeracao;

            acaoComExcecao.Should().Throw<ExcecaoDestinatarioInvalido>();
        }

        [Test]
        public void NotaFiscal_Validar_SemNaturezaOperacao_Falha()
        {
            _notaFiscal.Transportador = transportadorMock.Object;
            _notaFiscal.Destinatario = destinatarioMock.Object;
            _notaFiscal.NaturezaOperacao = "";
            _notaFiscal.DataEntrada = DateTime.Now;

            Action acaoComExcecao = _notaFiscal.ValidarGeracao;

            acaoComExcecao.Should().Throw<ExcecaoSemNaturezaOperacao>();
        }

        [Test]
        public void NotaFiscal_Validar_DataEntradaInvalida_Falha()
        {
            _notaFiscal.Destinatario = destinatarioMock.Object;
            _notaFiscal.Transportador = transportadorMock.Object;
            _notaFiscal.NaturezaOperacao = "Natureza";
            _notaFiscal.DataEntrada = DateTime.Now.AddDays(2);

            Action acaoComExcecao = _notaFiscal.ValidarGeracao;

            acaoComExcecao.Should().Throw<ExcecaoDataEntradaInvalida>();
        }

        [Test]
        public void NotaFiscal_TamanhoChaveDeAcessoDeveSer44_Sucesso()
        {
            Random sorteador = new Random();
            _notaFiscal.GerarChaveDeAcesso(sorteador);
            string chaveGerada = _notaFiscal.ChaveAcesso;

            chaveGerada.Length.Should().Be(44);
        }

        [Test]
        public void NotaFiscal_ValidarValores_Sucesso()
        {
            Random sorteador = new Random();
            _notaFiscal.GerarChaveDeAcesso(sorteador);
            string chaveGerada = _notaFiscal.ChaveAcesso;

            chaveGerada.Length.Should().Be(44);
        }
    }
}
