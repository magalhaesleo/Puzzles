using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Notas_Fiscais;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
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

        private Mock<NotaFiscal> _mockNotaFiscal;
        

        [SetUp]
        public void Inicializar()
        {
            _mockNotaFiscalRepositorio = new Mock<INotaFiscalRepositorio>();
            _mockNotaFiscalEmitidaRepositorio = new Mock<INotaFiscalEmitidaRepositorio>();

            _servicoNotaFiscal = new NotaFiscalServico(_mockNotaFiscalRepositorio.Object, _mockNotaFiscalEmitidaRepositorio.Object);

            _mockNotaFiscal = new Mock<NotaFiscal>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Adicionar_Sucesso()
        {
            _mockNotaFiscalRepositorio.Setup(nfr => nfr.Adicionar(_mockNotaFiscal.Object)).Returns(_mockNotaFiscal.Object);

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
            _mockNotaFiscalRepositorio.Setup(nfr => nfr.BuscarTodos());

            _servicoNotaFiscal.BuscarTodos();

            _mockNotaFiscalRepositorio.Verify(mnfr => mnfr.BuscarTodos());

        }

        [Test]
        public void NotaFiscal_Aplicacao_Emitir_Sucesso()
        {
            1.Should().Be(2);
        }

        [Test]
        public void NotaFiscal_Aplicacao_ConsultarExistenciaDeNotaEmitida_Sucesso()
        {
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
