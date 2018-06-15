using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Notas_Fiscais;
using Projeto_NFe.Common.Tests.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Infrastructure.XML.Funcionalidades.Nota_Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Tests.Funcionalidades.Nota_Fiscal
{
    [TestFixture]
    public class NotaFiscalServicoTeste
    {

        private INotaFiscalServico _servicoNotaFiscal;

        private Mock<INotaFiscalRepositorio> _mockNotaFiscalRepositorio;
        private Mock<INotaFiscalEmitidaRepositorio> _mockNotaFiscalEmitidaRepositorio;
        private Mock<IProdutoNotaFiscalRepositorio> _mockProdutoNotaFiscalRepositorio;
        private Mock<NotaFiscalRepositorioXML> _mockNotaFiscalRepositorioXML;

        private Mock<List<ProdutoNotaFiscal>> _mockListaDeProdutoNotaFiscal;
        private Mock<List<NotaFiscal>> _mockListaNotaFiscal;

        private Mock<NotaFiscal> _mockNotaFiscal;
        private Mock<ProdutoNotaFiscal> _mockProdutoNotaFiscal;

        [SetUp]
        public void Inicializar()
        {
            _mockNotaFiscalRepositorio = new Mock<INotaFiscalRepositorio>();
            _mockNotaFiscalEmitidaRepositorio = new Mock<INotaFiscalEmitidaRepositorio>();
            _mockProdutoNotaFiscalRepositorio = new Mock<IProdutoNotaFiscalRepositorio>();
            _mockNotaFiscalRepositorioXML = new Mock<NotaFiscalRepositorioXML>();
            _mockListaDeProdutoNotaFiscal = new Mock<List<ProdutoNotaFiscal>>();
            _mockListaNotaFiscal = new Mock<List<NotaFiscal>>();

            _servicoNotaFiscal = new NotaFiscalServico(_mockNotaFiscalRepositorio.Object, _mockNotaFiscalEmitidaRepositorio.Object, _mockProdutoNotaFiscalRepositorio.Object, _mockNotaFiscalRepositorioXML.Object);

            _mockNotaFiscal = new Mock<NotaFiscal>();
            _mockProdutoNotaFiscal = new Mock<ProdutoNotaFiscal>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Adicionar_Sucesso()
        {
            long idValidoDaNota = 1;
            _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(idValidoDaNota);

            _mockNotaFiscalRepositorio.Setup(nfr => nfr.Adicionar(_mockNotaFiscal.Object)).Returns(_mockNotaFiscal.Object);

            _mockProdutoNotaFiscalRepositorio.Setup(mpnfr => mpnfr.Adicionar(_mockProdutoNotaFiscal.Object));

            _mockListaDeProdutoNotaFiscal.Object.Add(_mockProdutoNotaFiscal.Object);

            _mockProdutoNotaFiscal.Setup(mpnf => mpnf.NotaFiscal.Id).Returns(idValidoDaNota);

            _mockNotaFiscal.Setup(mnf => mnf.Produtos).Returns(_mockListaDeProdutoNotaFiscal.Object);

            NotaFiscal notaFiscalAdicionada = _servicoNotaFiscal.Adicionar(_mockNotaFiscal.Object);

            _mockNotaFiscalRepositorio.Verify(nfr => nfr.Adicionar(_mockNotaFiscal.Object));

            notaFiscalAdicionada.Should().NotBeNull();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Atualizar_Sucesso()
        {
            _mockNotaFiscal.Setup(mnf => mnf.ValidarGeracao());

            _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(1);

            _mockNotaFiscalRepositorio.Setup(mnfr => mnfr.Atualizar(_mockNotaFiscal.Object));

            _mockNotaFiscalRepositorio.Setup(nfr => nfr.Atualizar(_mockNotaFiscal.Object)).Returns(_mockNotaFiscal.Object);

            _mockProdutoNotaFiscalRepositorio.Setup(mpnfr => mpnfr.Adicionar(_mockProdutoNotaFiscal.Object));

            _mockListaDeProdutoNotaFiscal.Object.Add(_mockProdutoNotaFiscal.Object);

            _mockNotaFiscal.Setup(mnf => mnf.Produtos).Returns(new List<ProdutoNotaFiscal>());

            _servicoNotaFiscal.Atualizar(_mockNotaFiscal.Object);

            _mockNotaFiscalRepositorio.Verify(mnfr => mnfr.Atualizar(_mockNotaFiscal.Object));
            _mockNotaFiscal.Verify(mnfr => mnfr.Id);
        }

        [Test]
        public void NotaFiscal_Aplicacao_Atualizar_ExcecaoIdentificadorIndefinido_Falha()
        {
            _mockNotaFiscal.Setup(mnf => mnf.ValidarGeracao());
            _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(0);

            Action acaoQueDeveRetornarExcecaoIdentificadorIndefinido = () => _servicoNotaFiscal.Atualizar(_mockNotaFiscal.Object);

            acaoQueDeveRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoIdentificadorIndefinido>();

            _mockNotaFiscalRepositorio.VerifyNoOtherCalls();

        }

        [Test]
        public void NotaFiscal_Aplicacao_Excluir_Sucesso()
        {
            long idValido = 1;

            _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(idValido);

            _mockNotaFiscalRepositorio.Setup(nfr => nfr.Excluir(_mockNotaFiscal.Object));

            _servicoNotaFiscal.Excluir(_mockNotaFiscal.Object);

            _mockNotaFiscal.Verify(mnf => mnf.Id);

            _mockNotaFiscalRepositorio.Verify(mnfr => mnfr.Excluir(_mockNotaFiscal.Object));


        }

        [Test]
        public void NotaFiscal_Aplicacao_Excluir_ExcecaoIdentificadorIndefinido_Falha()
        {
            long idInvalido = 0;

            _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(idInvalido);


            Action acaoQueDeveRetornarExcecaoIdentificadorIndefinido = () => _servicoNotaFiscal.Excluir(_mockNotaFiscal.Object);

            acaoQueDeveRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoIdentificadorIndefinido>();

            _mockNotaFiscal.Verify(mnf => mnf.Id);

            _mockNotaFiscalRepositorio.VerifyNoOtherCalls();


        }

        [Test]
        public void NotaFiscal_Aplicacao_BuscarPorId_Sucesso()
        {
            long idValido = 1;

            _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(idValido);

            _mockNotaFiscalRepositorio.Setup(nfr => nfr.BuscarPorId(_mockNotaFiscal.Object.Id)).Returns(_mockNotaFiscal.Object);

            _servicoNotaFiscal.BuscarPorId(_mockNotaFiscal.Object.Id);

            _mockNotaFiscalRepositorio.Verify(nfr => nfr.BuscarPorId(_mockNotaFiscal.Object.Id));
        }

        [Test]
        public void NotaFiscal_Aplicacao_BuscarPorId_ExcecaoIdentificadorIndefinido_Falha()
        {
            long idInvalido = 0;

            _mockNotaFiscal.Setup(er => er.Id).Returns(idInvalido);

            _mockNotaFiscalRepositorio.Setup(nfr => nfr.BuscarPorId(_mockNotaFiscal.Object.Id)).Returns(_mockNotaFiscal.Object);

            Action acaoQueDeveRetornarExcecaoIdentificadorIndefinido = () => _servicoNotaFiscal.BuscarPorId(_mockNotaFiscal.Object.Id);

            acaoQueDeveRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoIdentificadorIndefinido>();
            _mockNotaFiscalRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void NotaFiscal_Aplicacao_BuscarTodos_Sucesso()
        {
            _mockNotaFiscalRepositorio.Setup(nfr => nfr.BuscarTodos()).Returns(_mockListaNotaFiscal.Object);
            
            _mockListaNotaFiscal.Object.Add(_mockNotaFiscal.Object);

            _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(1);
            _mockProdutoNotaFiscalRepositorio.Setup(mpnf => mpnf.BuscarListaPorId(_mockNotaFiscal.Object.Id)).Returns(_mockListaDeProdutoNotaFiscal.Object);

            _mockListaDeProdutoNotaFiscal.Object.Add(_mockProdutoNotaFiscal.Object);

            _servicoNotaFiscal.BuscarTodos();

            _mockNotaFiscalRepositorio.Verify(mnfr => mnfr.BuscarTodos());
            _mockProdutoNotaFiscalRepositorio.Verify(mpnfr => mpnfr.BuscarListaPorId(_mockNotaFiscal.Object.Id));
            _mockNotaFiscal.Verify(mnf => mnf.Id);

        }

        [Test]
        public void NotaFiscal_Aplicacao_Emitir_ComFakeParaRepetirChaveDeAcesso_Sucesso()
        {
            long idAposAdicionar = 1;
            string xmlObitdo = "";

            FakeNotaFiscalEmitidaRepositorio fakeNotaFiscalEmitidaRepositorio = new FakeNotaFiscalEmitidaRepositorio();

            NotaFiscalServico _servicoNotaFiscalComRepositorioFake = new NotaFiscalServico(_mockNotaFiscalRepositorio.Object, fakeNotaFiscalEmitidaRepositorio, _mockProdutoNotaFiscalRepositorio.Object, _mockNotaFiscalRepositorioXML.Object);

            Mock<Random> mockRandom = new Mock<Random>();

            _mockNotaFiscal.Setup(mnf => mnf.CalcularValoresTotais());
            _mockNotaFiscal.Setup(mnf => mnf.ValidarParaEmitir());
            _mockNotaFiscal.Setup(mnf => mnf.GerarChaveDeAcesso(mockRandom.Object));
            _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(idAposAdicionar);

            //Setup mock nota fiscal repositorio
            _mockNotaFiscalRepositorio.Setup(mnfr => mnfr.Excluir(_mockNotaFiscal.Object));
            _mockNotaFiscalRepositorioXML.Setup(mnfrx => mnfrx.Serializar(_mockNotaFiscal.Object)).Returns(xmlObitdo);

            //Acao
            _servicoNotaFiscalComRepositorioFake.Emitir(_mockNotaFiscal.Object, mockRandom.Object);

            //Verificacoes
            _mockNotaFiscal.Verify(mnf => mnf.ValidarParaEmitir());
            _mockNotaFiscal.Verify(mnf => mnf.GerarChaveDeAcesso(mockRandom.Object));
            _mockNotaFiscal.Verify(mnf => mnf.ChaveAcesso);

            _mockNotaFiscalRepositorio.Verify(mnfr => mnfr.Excluir(_mockNotaFiscal.Object));

            _mockNotaFiscalRepositorioXML.Verify(mnfrx => mnfrx.Serializar(_mockNotaFiscal.Object));
        }

        [Test]
        public void NotaFiscal_Aplicacao_Emitir_Sucesso()
        {
            long idAposAdicionar = 1;
            string xml = "";

            Mock<Random> mockRandom = new Mock<Random>();

            _mockNotaFiscal.Setup(mnf => mnf.CalcularValoresTotais());
            _mockNotaFiscal.Setup(mnf => mnf.ValidarParaEmitir());
            _mockNotaFiscal.Setup(mnf => mnf.GerarChaveDeAcesso(mockRandom.Object));
            _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(idAposAdicionar);

            _mockNotaFiscal.Setup(mnf => mnf.ChaveAcesso).Returns("21098309812309812038912098312098312089312121212");

            //Setup mock nota fiscal repositorio
            _mockNotaFiscalRepositorio.Setup(mnfr => mnfr.Excluir(_mockNotaFiscal.Object));
            _mockNotaFiscalEmitidaRepositorio.Setup(mnfer => mnfer.Adicionar(xml, _mockNotaFiscal.Object.ChaveAcesso)).Returns(idAposAdicionar);
            _mockNotaFiscalRepositorioXML.Setup(mnfrx => mnfrx.Serializar(_mockNotaFiscal.Object)).Returns(xml);

            //Acao
            _servicoNotaFiscal.Emitir(_mockNotaFiscal.Object, mockRandom.Object);

            //Verificacoes
            _mockNotaFiscal.Verify(mnf => mnf.ValidarParaEmitir());
            _mockNotaFiscal.Verify(mnf => mnf.GerarChaveDeAcesso(mockRandom.Object));
            _mockNotaFiscal.Verify(mnf => mnf.ChaveAcesso);

            _mockNotaFiscalRepositorio.Verify(mnfr => mnfr.Excluir(_mockNotaFiscal.Object));
            _mockNotaFiscalEmitidaRepositorio.Verify(mnfer => mnfer.Adicionar(xml, _mockNotaFiscal.Object.ChaveAcesso));
            _mockNotaFiscalRepositorioXML.Verify(mnfrx => mnfrx.Serializar(_mockNotaFiscal.Object));
        }

        [Test]
        public void NotaFiscal_Aplicacao_Emitir_ComIdZero_Sucesso()
        {
            long idAposAdicionar = 0;

            Mock<Random> mockRandom = new Mock<Random>();

            _mockNotaFiscal.Setup(mnf => mnf.CalcularValoresTotais());
            _mockNotaFiscal.Setup(mnf => mnf.ValidarParaEmitir());
            _mockNotaFiscal.Setup(mnf => mnf.GerarChaveDeAcesso(mockRandom.Object));
            _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(idAposAdicionar);
            _mockNotaFiscal.Setup(mnf => mnf.ChaveAcesso).Returns("21098309812309812038912098312098312089312121212");
            string xml = "";


            //Setup mock nota fiscal repositorio
            _mockNotaFiscalRepositorio.Setup(mnfr => mnfr.Excluir(_mockNotaFiscal.Object));
            _mockNotaFiscalEmitidaRepositorio.Setup(mnfer => mnfer.Adicionar(xml, _mockNotaFiscal.Object.ChaveAcesso)).Returns(idAposAdicionar);
            _mockNotaFiscalRepositorioXML.Setup(mnfrx => mnfrx.Serializar(_mockNotaFiscal.Object)).Returns(xml);

            //Acao
            _servicoNotaFiscal.Emitir(_mockNotaFiscal.Object, mockRandom.Object);

            //Verificacoes
            _mockNotaFiscal.Verify(mnf => mnf.ValidarParaEmitir());
            _mockNotaFiscal.Verify(mnf => mnf.GerarChaveDeAcesso(mockRandom.Object));
            _mockNotaFiscal.Verify(mnf => mnf.ChaveAcesso);

            _mockNotaFiscalRepositorio.VerifyNoOtherCalls();
            _mockNotaFiscalEmitidaRepositorio.Verify(mnfer => mnfer.Adicionar(xml, _mockNotaFiscal.Object.ChaveAcesso));
            _mockNotaFiscalRepositorioXML.Verify(mnfrx => mnfrx.Serializar(_mockNotaFiscal.Object));
        }

        [Test]
        public void NotaFiscal_Aplicacao_ConsultarExistenciaDeNotaEmitida_Sucesso()
        {
            string chaveDeAcessoParaConsultarExistencia = "21098309812309812038912098312098312089312121212";

            _mockNotaFiscalEmitidaRepositorio.Setup(mnfer => mnfer.ConsultarExistenciaDeNotaEmitida(chaveDeAcessoParaConsultarExistencia));

            _servicoNotaFiscal.ConsultarExistenciaDeNotaEmitida(chaveDeAcessoParaConsultarExistencia);

            _mockNotaFiscalEmitidaRepositorio.Verify(mnfer => mnfer.ConsultarExistenciaDeNotaEmitida(chaveDeAcessoParaConsultarExistencia));
        }

        [Test]
        public void NotaFiscal_Aplicacao_BuscarNotaFiscalEmitidaPorChave_Sucesso()
        {

            string chaveDeAcessoParaBuscar = "21098309812309812038912098312098312089312121212";

            _mockNotaFiscalEmitidaRepositorio.Setup(mnfer => mnfer.BuscarNotaFiscalEmitidaPorChave(chaveDeAcessoParaBuscar));

            _servicoNotaFiscal.BuscarNotaFiscalEmitidaPorChave(chaveDeAcessoParaBuscar);

            _mockNotaFiscalEmitidaRepositorio.Verify(mnfer => mnfer.BuscarNotaFiscalEmitidaPorChave(chaveDeAcessoParaBuscar));


        }
    }
}
