using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
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
        Mock<Produto> produtoMock;
        Mock<ProdutoNotaFiscal> produtoNotaFiscal;


        NotaFiscal _notaFiscal;

        [SetUp]
        public void IniciarCenario()
        {
            produtoMock = new Mock<Produto>();
            _notaFiscal = new NotaFiscal();
            transportadorMock = new Mock<Transportador>();
            destinatarioMock = new Mock<Destinatario>();
            emitenteMock = new Mock<Emitente>();
            produtoNotaFiscal = new Mock<ProdutoNotaFiscal>(_notaFiscal, produtoMock.Object, 1);
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_Sucesso()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(emitenteMock.Object, destinatarioMock.Object, transportadorMock.Object);

            Action resultado = _notaFiscal.ValidarGeracao;

            resultado.Should().NotThrow<ExcecaoDeNegocio>();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_SemTransportador_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalSemTransportador(emitenteMock.Object, destinatarioMock.Object);

            Action resultado = _notaFiscal.ValidarGeracao;

            resultado.Should().Throw<ExcecaoTransportadorInvalido>();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_SemDestinatario_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalSemDestinatario(emitenteMock.Object, transportadorMock.Object);

            Action acaoComExcecao = _notaFiscal.ValidarGeracao;

            acaoComExcecao.Should().Throw<ExcecaoDestinatarioInvalido>();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_SemEmitente_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalSemEmitente(destinatarioMock.Object, transportadorMock.Object);

            Action acaoComExcecao = _notaFiscal.ValidarGeracao;

            acaoComExcecao.Should().Throw<ExcecaoEmitenteInvalido>();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_SemNaturezaOperacao_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalSemNaturezaOperacao(emitenteMock.Object, destinatarioMock.Object, transportadorMock.Object);

            Action acaoComExcecao = _notaFiscal.ValidarGeracao;

            acaoComExcecao.Should().Throw<ExcecaoSemNaturezaOperacao>();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_DataEntradaInvalida_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(emitenteMock.Object, destinatarioMock.Object, transportadorMock.Object);
            _notaFiscal.DataEntrada = DateTime.Now.AddDays(2);

            Action acaoComExcecao = _notaFiscal.ValidarGeracao;

            acaoComExcecao.Should().Throw<ExcecaoDataEntradaInvalida>();
        }

        [Test]
        public void NotaFiscal_Dominio_TamanhoChaveDeAcessoDeveSer44_Sucesso()
        {
            Random sorteador = new Random();
            _notaFiscal.GerarChaveDeAcesso(sorteador);
            string chaveGerada = _notaFiscal.ChaveAcesso;

            chaveGerada.Length.Should().Be(44);
        }

        [Test]
        public void NotaFiscal_Dominio_ValidarParaEmissao_Sucesso()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(emitenteMock.Object, destinatarioMock.Object, transportadorMock.Object);

            Action resultado = _notaFiscal.ValidarParaEmitir;

            resultado.Should().NotThrow<ExcecaoDeNegocio>();
        }

        [Test]
        public void NotaFiscal_Dominio_ValidarValorICMS_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(emitenteMock.Object, destinatarioMock.Object, transportadorMock.Object);
            _notaFiscal.ValorTotalICMS = 0;
          
            Action resultado = _notaFiscal.ValidarParaEmitir;

            resultado.Should().Throw<ExcecaoValorTotalICMSInvalido>();
        }

        [Test]
        public void NotaFiscal_Dominio_ValidarValorIPI_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(emitenteMock.Object, destinatarioMock.Object, transportadorMock.Object);
            _notaFiscal.ValorTotalIPI = -10;
      
            Action resultado = _notaFiscal.ValidarParaEmitir;

            resultado.Should().Throw<ExcecaoValorTotalIPIInvalido>();
        }

        [Test]
        public void NotaFiscal_Dominio_ValidarValorTotalProdutos_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(emitenteMock.Object, destinatarioMock.Object, transportadorMock.Object);
            _notaFiscal.ValorTotalProdutos = 0;
     
            Action resultado = _notaFiscal.ValidarParaEmitir;

            resultado.Should().Throw<ExcecaoValorTotalProdutoInvalido>();
        }


        [Test]
        public void NotaFiscal_Dominio_ValidarValorProdutoLista_Falha()
        {
            produtoMock.Setup(p => p.Valor).Returns(5);
            produtoNotaFiscal.Object.Produto = produtoMock.Object;
            produtoNotaFiscal.Setup(pnf => pnf.Quantidade).Returns(1);
            produtoNotaFiscal.Setup(pnf => pnf.ValorTotal).Returns(0);
            List<ProdutoNotaFiscal> listaProdutosNotaFiscal = new List<ProdutoNotaFiscal>();
            listaProdutosNotaFiscal.Add(produtoNotaFiscal.Object);
            _notaFiscal.Produtos = listaProdutosNotaFiscal;
            _notaFiscal.ValorTotalICMS = 90;
            _notaFiscal.ValorTotalIPI = 10;
            _notaFiscal.ValorTotalFrete = 50;
            _notaFiscal.ValorTotalNota = 1000;
            _notaFiscal.ValorTotalProdutos = 900;
            _notaFiscal.ValorTotalImpostos = 100;

            Action resultado = _notaFiscal.ValidarParaEmitir;

            resultado.Should().Throw<ExcecaoProdutoSemValor>();
        }

        [Test]
        public void NotaFiscal_Dominio_CalcularValoresTotais_Sucesso()
        {
            Mock<ProdutoNotaFiscal> produtoNotaFiscal2 = new Mock<ProdutoNotaFiscal>(_notaFiscal, produtoMock.Object, 1);
            produtoNotaFiscal.Setup(pnf => pnf.ValorTotal).Returns(100);
            produtoNotaFiscal2.Setup(pnf => pnf.ValorTotal).Returns(50);
            produtoNotaFiscal.Setup(pnf => pnf.ValorICMS).Returns(70);
            produtoNotaFiscal2.Setup(pnf => pnf.ValorICMS).Returns(40);
            produtoNotaFiscal.Setup(pnf => pnf.ValorIPI).Returns(30);
            produtoNotaFiscal2.Setup(pnf => pnf.ValorIPI).Returns(50);
            List<ProdutoNotaFiscal> produtosNotaFiscal = new List<ProdutoNotaFiscal>();
            produtosNotaFiscal.Add(produtoNotaFiscal.Object);
            produtosNotaFiscal.Add(produtoNotaFiscal2.Object);
            _notaFiscal.Produtos = produtosNotaFiscal;

            _notaFiscal.ValorTotalFrete = 50;
            _notaFiscal.CalcularValoresTotais();

            _notaFiscal.ValorTotalProdutos.Should().Be(150);
            _notaFiscal.ValorTotalICMS.Should().Be(110);
            _notaFiscal.ValorTotalIPI.Should().Be(80);
            _notaFiscal.ValorTotalImpostos.Should().Be(190);
            _notaFiscal.ValorTotalNota.Should().Be(390);
        }

        [Test]
        public void NotaFiscal_Dominio_ValidarValorTotalImpostos_Falha()
        {
            _notaFiscal.ValorTotalICMS = 90;
            _notaFiscal.ValorTotalIPI = 10;
            _notaFiscal.ValorTotalFrete = 50;
            _notaFiscal.ValorTotalNota = 1000;
            _notaFiscal.ValorTotalProdutos = 800;
            _notaFiscal.ValorTotalImpostos = 0;

            Action acaoComExcecao = _notaFiscal.ValidarParaEmitir;

            acaoComExcecao.Should().Throw<ExcecaoValorTotalImpostosInvalido>();
        }

        [Test]
        public void NotaFiscal_Dominio_ValidarValorTotalNota_Falha()
        {
            _notaFiscal.ValorTotalICMS = 90;
            _notaFiscal.ValorTotalIPI = 10;
            _notaFiscal.ValorTotalFrete = 50;
            _notaFiscal.ValorTotalNota = 0;
            _notaFiscal.ValorTotalProdutos = 800;
            _notaFiscal.ValorTotalImpostos = 100;

            Action acaoComExcecao = _notaFiscal.ValidarParaEmitir;

            acaoComExcecao.Should().Throw<ExcecaoValorTotalNotaInvalido>();
        }

        [Test]
        public void NotaFiscal_Dominio_DestinatarioIgualEmitente_Falha()
        {
            Mock<CNPJ> cnpjMock = new Mock<CNPJ>();
            cnpjMock.Object.NumeroComPontuacao = "45.923.622/0001-20";

            _notaFiscal.NaturezaOperacao = "Natureza";
            _notaFiscal.DataEntrada = DateTime.Now;
            _notaFiscal.Transportador = transportadorMock.Object;
            _notaFiscal.Emitente = emitenteMock.Object;
            _notaFiscal.Destinatario = destinatarioMock.Object;
            destinatarioMock.Setup(dm => dm.Documento).Returns(cnpjMock.Object);
            emitenteMock.Setup(em => em.CNPJ).Returns(cnpjMock.Object);

            Action acaoComExcecao =_notaFiscal.ValidarGeracao;

            acaoComExcecao.Should().Throw<ExcecaoDestinatarioIgualAEmitente>();
        }
    }
}
