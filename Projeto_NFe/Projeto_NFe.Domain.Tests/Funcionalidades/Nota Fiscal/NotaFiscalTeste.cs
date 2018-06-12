using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
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
        Mock<Transportador> _transportadorMock;
        Mock<Destinatario> _destinatarioMock;
        Mock<Emitente> _emitenteMock;
        Mock<Produto> _produtoMock;
        Mock<ProdutoNotaFiscal> _produtoNotaFiscal;
        Mock<Endereco> _enderecoMock;
        Mock<CNPJ> _cnpjMock;

        List<ProdutoNotaFiscal> _produtosNotaFiscal;
        NotaFiscal _notaFiscal;

        [SetUp]
        public void IniciarCenario()
        {
            _produtoMock = new Mock<Produto>();
            _transportadorMock = new Mock<Transportador>();
            _destinatarioMock = new Mock<Destinatario>();
            _emitenteMock = new Mock<Emitente>();
            _enderecoMock = new Mock<Endereco>();
            _produtoNotaFiscal = new Mock<ProdutoNotaFiscal>(_notaFiscal, _produtoMock.Object, 1);
            _produtosNotaFiscal = new List<ProdutoNotaFiscal>();
            _cnpjMock = new Mock<CNPJ>();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_Sucesso()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object);

            Action resultado = _notaFiscal.ValidarGeracao;

            resultado.Should().NotThrow<ExcecaoDeNegocio>();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_TransportadorVazioDeveReceberValoresDestinatario_Sucesso()
        {
            //CNPJ
            _cnpjMock.Object.NumeroComPontuacao = "99.327.235/0001-50";

            //Endereço
            _enderecoMock.Object.Id = 1;
            _enderecoMock.Object.Numero = 222;
            _enderecoMock.Object.Bairro = "Coral";
            _enderecoMock.Object.Logradouro = "Rua";
            _enderecoMock.Object.Municipio = "Lages";
            _enderecoMock.Object.Estado = "SC";
            _enderecoMock.Object.Pais = "BR";

            //Destinatário
            _destinatarioMock.Object.NomeRazaoSocial = "nome";
            _destinatarioMock.Object.InscricaoEstadual = "636.330.646.110";
            _destinatarioMock.Object.Endereco = _enderecoMock.Object;
            _destinatarioMock.Setup(des => des.Documento).Returns(_cnpjMock.Object);

            _produtoNotaFiscal.Setup(pnf => pnf.ValorTotal).Returns(100);
            _produtosNotaFiscal.Add(_produtoNotaFiscal.Object);
            _notaFiscal = ObjectMother.PegarNotaFiscalValidaComListaDeProdutos(_emitenteMock.Object, _destinatarioMock.Object, null, _produtosNotaFiscal);

            _notaFiscal.ValidarParaEmitir();

            _notaFiscal.Transportador.Should().NotBeNull();
            _notaFiscal.Transportador.NomeRazaoSocial.Should().Be(_notaFiscal.Destinatario.NomeRazaoSocial);
            _notaFiscal.Transportador.InscricaoEstadual.Should().Be(_notaFiscal.Destinatario.InscricaoEstadual);
            _notaFiscal.Transportador.Endereco.Id.Should().Be(_notaFiscal.Destinatario.Endereco.Id);
            _notaFiscal.Transportador.Documento.NumeroComPontuacao.Should().Be(_notaFiscal.Destinatario.Documento.NumeroComPontuacao);
            _notaFiscal.Transportador.ResponsabilidadeFrete.Should().BeTrue();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_SemDestinatario_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalSemDestinatario(_emitenteMock.Object, _transportadorMock.Object);

            Action acaoComExcecao = _notaFiscal.ValidarGeracao;

            acaoComExcecao.Should().Throw<ExcecaoDestinatarioInvalido>();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_SemEmitente_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalSemEmitente(_destinatarioMock.Object, _transportadorMock.Object);

            Action acaoComExcecao = _notaFiscal.ValidarGeracao;

            acaoComExcecao.Should().Throw<ExcecaoEmitenteInvalido>();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_SemNaturezaOperacao_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalSemNaturezaOperacao(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object);

            Action acaoComExcecao = _notaFiscal.ValidarGeracao;

            acaoComExcecao.Should().Throw<ExcecaoSemNaturezaOperacao>();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_DataEntradaInvalida_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object);
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
            _produtoNotaFiscal.Setup(pnf => pnf.ValorTotal).Returns(100);
            _produtosNotaFiscal.Add(_produtoNotaFiscal.Object);
            _notaFiscal = ObjectMother.PegarNotaFiscalValidaComListaDeProdutos(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object, _produtosNotaFiscal);

            Action resultado = _notaFiscal.ValidarParaEmitir;

            resultado.Should().NotThrow<ExcecaoDeNegocio>();
        }

        [Test]
        public void NotaFiscal_Dominio_ValidarValorICMS_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object);
            _notaFiscal.ValorTotalICMS = 0;
          
            Action resultado = _notaFiscal.ValidarParaEmitir;

            resultado.Should().Throw<ExcecaoValorTotalICMSInvalido>();
        }

        [Test]
        public void NotaFiscal_Dominio_ValidarValorIPI_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object);
            _notaFiscal.ValorTotalIPI = -10;
      
            Action resultado = _notaFiscal.ValidarParaEmitir;

            resultado.Should().Throw<ExcecaoValorTotalIPIInvalido>();
        }

        [Test]
        public void NotaFiscal_Dominio_ValidarValorTotalProdutos_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object);
            _notaFiscal.ValorTotalProdutos = 0;
     
            Action resultado = _notaFiscal.ValidarParaEmitir;

            resultado.Should().Throw<ExcecaoValorTotalProdutoInvalido>();
        }


        [Test]
        public void NotaFiscal_Dominio_ValidarValorProdutoLista_Falha()
        {
            _produtoMock.Setup(p => p.Valor).Returns(5);
            _produtoNotaFiscal.Object.Produto = _produtoMock.Object;
            _produtoNotaFiscal.Setup(pnf => pnf.Quantidade).Returns(1);
            _produtoNotaFiscal.Setup(pnf => pnf.ValorTotal).Returns(0);
            List<ProdutoNotaFiscal> listaProdutosNotaFiscal = new List<ProdutoNotaFiscal>();
            listaProdutosNotaFiscal.Add(_produtoNotaFiscal.Object);
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
            Mock<ProdutoNotaFiscal> produtoNotaFiscal2 = new Mock<ProdutoNotaFiscal>(_notaFiscal, _produtoMock.Object, 1);
            _produtoNotaFiscal.Setup(pnf => pnf.ValorTotal).Returns(100);
            produtoNotaFiscal2.Setup(pnf => pnf.ValorTotal).Returns(50);
            _produtoNotaFiscal.Setup(pnf => pnf.ValorICMS).Returns(70);
            produtoNotaFiscal2.Setup(pnf => pnf.ValorICMS).Returns(40);
            _produtoNotaFiscal.Setup(pnf => pnf.ValorIPI).Returns(30);
            produtoNotaFiscal2.Setup(pnf => pnf.ValorIPI).Returns(50);
            _produtosNotaFiscal.Add(_produtoNotaFiscal.Object);
            _produtosNotaFiscal.Add(produtoNotaFiscal2.Object);
            _notaFiscal = ObjectMother.PegarNotaFiscalValidaComListaDeProdutos(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object, _produtosNotaFiscal);

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
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object);
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
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object);
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
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object);
            
            _cnpjMock.Object.NumeroComPontuacao = "45.923.622/0001-20";

            _notaFiscal.NaturezaOperacao = "Natureza";
            _notaFiscal.DataEntrada = DateTime.Now;
            _notaFiscal.Transportador = _transportadorMock.Object;
            _notaFiscal.Emitente = _emitenteMock.Object;
            _notaFiscal.Destinatario = _destinatarioMock.Object;
            _destinatarioMock.Setup(dm => dm.Documento).Returns(_cnpjMock.Object);
            _emitenteMock.Setup(em => em.CNPJ).Returns(_cnpjMock.Object);

            Action acaoComExcecao =_notaFiscal.ValidarGeracao;

            acaoComExcecao.Should().Throw<ExcecaoDestinatarioIgualAEmitente>();
        }

        [Test]
        public void NotaFiscal_Dominio_VerificarValidarDeDestinatario_Sucesso()
        {
            _destinatarioMock.Setup(des => des.Validar());
            _produtoNotaFiscal.Setup(pnf => pnf.ValorTotal).Returns(100);
            _produtosNotaFiscal.Add(_produtoNotaFiscal.Object);
            _notaFiscal = ObjectMother.PegarNotaFiscalValidaComListaDeProdutos(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object, _produtosNotaFiscal);           

            _notaFiscal.ValidarParaEmitir();

            _destinatarioMock.Verify(des => des.Validar());       
        }

        [Test]
        public void NotaFiscal_Dominio_VerificarValidarDeEmitente_Sucesso()
        {
            _emitenteMock.Setup(em => em.Validar());
            _produtoNotaFiscal.Setup(pnf => pnf.ValorTotal).Returns(100);
            _produtosNotaFiscal.Add(_produtoNotaFiscal.Object);
            _notaFiscal = ObjectMother.PegarNotaFiscalValidaComListaDeProdutos(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object, _produtosNotaFiscal);

            _notaFiscal.ValidarParaEmitir();

            _emitenteMock.Verify(em => em.Validar());
        }

        [Test]
        public void NotaFiscal_Dominio_VerificarValidarDeTransportador_Sucesso()
        {
            _transportadorMock.Setup(tr => tr.Validar());
            _produtoNotaFiscal.Setup(pnf => pnf.ValorTotal).Returns(100);
            _produtosNotaFiscal.Add(_produtoNotaFiscal.Object);
            _notaFiscal = ObjectMother.PegarNotaFiscalValidaComListaDeProdutos(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object, _produtosNotaFiscal);

            _notaFiscal.ValidarParaEmitir();

            _transportadorMock.Verify(tr => tr.Validar());
        }

        [Test]
        public void NotaFiscal_Dominio_ListaDeProdutoNula_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object);

            Action acaoComExcecao = _notaFiscal.ValidarParaEmitir;

            acaoComExcecao.Should().Throw<ExcecaoListaDeProdutoVazia>();
        }

        [Test]
        public void NotaFiscal_Dominio_ListaDeProdutoVazia_Falha()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValidaComListaDeProdutos(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object, _produtosNotaFiscal);

            Action acaoComExcecao = _notaFiscal.ValidarParaEmitir;

            acaoComExcecao.Should().Throw<ExcecaoListaDeProdutoVazia>();
        }

        [Test]
        public void NotaFiscal_Dominio_ValidarSeFoiEmitida_Sucesso()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object);
            _notaFiscal.ChaveAcesso = "11111111111111111111111111111111111171111111";
           _notaFiscal.FoiEmitida.Should().BeTrue();
        }

        [Test]
        public void NotaFiscal_Dominio_ValidarSeNaoFoiEmitida_Sucesso()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object);
            _notaFiscal.ChaveAcesso = "";
            _notaFiscal.FoiEmitida.Should().BeFalse();
        }

    }
}
