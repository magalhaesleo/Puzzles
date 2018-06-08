using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
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
        Mock<Emitente> emitenteMock;

        NotaFiscal _notaFiscal;

        [SetUp]
        public void IniciarCenario()
        {
            _notaFiscal = new NotaFiscal();
            transportadorMock = new Mock<Transportador>();
            destinatarioMock = new Mock<Destinatario>();
            emitenteMock = new Mock<Emitente>();
        }

        [Test]
        public void NotaFiscal_Validar_Sucesso()
        {
            _notaFiscal.Emitente = emitenteMock.Object;
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
            _notaFiscal.Emitente = emitenteMock.Object;
            _notaFiscal.Destinatario = destinatarioMock.Object;
            _notaFiscal.NaturezaOperacao = "Natureza";
            _notaFiscal.DataEntrada = DateTime.Now;

            Action resultado = _notaFiscal.ValidarGeracao;

            resultado.Should().Throw<ExcecaoTransportadorInvalido>();
        }

        [Test]
        public void NotaFiscal_Validar_SemDestinatario_Falha()
        {
            _notaFiscal.Emitente = emitenteMock.Object;
            _notaFiscal.Transportador = transportadorMock.Object;
            _notaFiscal.NaturezaOperacao = "Natureza";
            _notaFiscal.DataEntrada = DateTime.Now;

            Action acaoComExcecao = _notaFiscal.ValidarGeracao;

            acaoComExcecao.Should().Throw<ExcecaoDestinatarioInvalido>();
        }

        [Test]
        public void NotaFiscal_Validar_SemEmitente_Falha()
        {
            _notaFiscal.Destinatario = destinatarioMock.Object;
            _notaFiscal.Transportador = transportadorMock.Object;
            _notaFiscal.NaturezaOperacao = "Natureza";
            _notaFiscal.DataEntrada = DateTime.Now;

            Action acaoComExcecao = _notaFiscal.ValidarGeracao;

            acaoComExcecao.Should().Throw<ExcecaoEmitenteInvalido>();
        }

        [Test]
        public void NotaFiscal_Validar_SemNaturezaOperacao_Falha()
        {
            _notaFiscal.Emitente = emitenteMock.Object;
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
            _notaFiscal.Emitente = emitenteMock.Object;
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
        public void NotaFiscal_ValidarParaEmissao_Sucesso()
        {
            _notaFiscal.ValorTotalICMS = 20;
            _notaFiscal.ValorTotalIPI = 10;
            _notaFiscal.ValorTotalFrete = 50;
            _notaFiscal.ValorTotalNota = 1000;
            _notaFiscal.ValorTotalProduto = 920;
            Action resultado = _notaFiscal.ValidarParaEmitir;

            resultado.Should().NotThrow<ExcecaoDeNegocio>();
        }

        [Test]
        public void NotaFiscal_ValidarValorICMS_Falha()
        {
            _notaFiscal.ValorTotalICMS = 0;
            _notaFiscal.ValorTotalIPI = 10;
            _notaFiscal.ValorTotalFrete = 50;
            _notaFiscal.ValorTotalNota = 1000;
            _notaFiscal.ValorTotalProduto = 940;
            Action resultado = _notaFiscal.ValidarParaEmitir;

            resultado.Should().Throw<ExcecaoValorTotalICMSInvalido>();
        }

        [Test]
        public void NotaFiscal_ValidarValorIPI_Falha()
        {
            _notaFiscal.ValorTotalICMS = 90;
            _notaFiscal.ValorTotalIPI = -10;
            _notaFiscal.ValorTotalFrete = 50;
            _notaFiscal.ValorTotalNota = 1000;
            _notaFiscal.ValorTotalProduto = 850;
            Action resultado = _notaFiscal.ValidarParaEmitir;

            resultado.Should().Throw<ExcecaoValorTotalIPIInvalido>();
        }

        [Test]
        public void NotaFiscal_ValidarValorProduto_Falha()
        {
            _notaFiscal.ValorTotalICMS = 90;
            _notaFiscal.ValorTotalIPI = 10;
            _notaFiscal.ValorTotalFrete = 50;
            _notaFiscal.ValorTotalNota = 1000;
            _notaFiscal.ValorTotalProduto = 0;
            Action resultado = _notaFiscal.ValidarParaEmitir;

            resultado.Should().Throw<ExcecaoValorTotalProdutoInvalido>();
        }

    }
}
