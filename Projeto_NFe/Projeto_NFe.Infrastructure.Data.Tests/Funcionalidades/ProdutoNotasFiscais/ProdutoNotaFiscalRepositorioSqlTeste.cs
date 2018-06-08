using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.ProdutoNotasFiscais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Tests.Funcionalidades.ProdutoNotasFiscais
{
    [TestFixture]
    public class ProdutoNotaFiscalRepositorioSqlTeste
    {

        private IProdutoNotaFiscalRepositorio _repositorio;
        Mock<Produto> _mockProduto;
        Mock<NotaFiscal> _mockNotaFiscal;

        [SetUp]
        public void IniciarCenario()
        {
            BaseSqlTeste.InicializarBancoDeDadosPrepararNotaFiscal();
            _repositorio = new ProdutoNotaFiscalRepositorioSql();

            _mockProduto = new Mock<Produto>();
            _mockNotaFiscal = new Mock<NotaFiscal>();
        }

        [Test]
        public void ProdutoNotaFiscalRepositorioSql_Adicionar_Sucesso()
        {
            ProdutoNotaFiscal produtoNotaFiscalValido = ObjectMother.PegarProdutoNotaFiscalValido(_mockProduto.Object, _mockNotaFiscal.Object);

            long idDeProdutoCadastrado = 1;
            long idDeNotaFiscalCadastrada = 1;

            _mockProduto.Setup(mp => mp.Id).Returns(idDeProdutoCadastrado);
            _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(idDeNotaFiscalCadastrada);

            ProdutoNotaFiscal produtoNotaFiscalAdicionado = _repositorio.Adicionar(produtoNotaFiscalValido);

            produtoNotaFiscalAdicionado.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoNotaFiscalRepositorioSql_BuscarPorId_Sucesso()
        {
            ProdutoNotaFiscal produtoNotaFiscalValido = ObjectMother.PegarProdutoNotaFiscalValido(_mockProduto.Object, _mockNotaFiscal.Object);

            long idDeProdutoCadastrado = 1;
            long idDeNotaFiscalCadastrada = 1;

            _mockProduto.Setup(mp => mp.Id).Returns(idDeProdutoCadastrado);
            _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(idDeNotaFiscalCadastrada);

            ProdutoNotaFiscal produtoNotaFiscalAdicionado = _repositorio.Adicionar(produtoNotaFiscalValido);

            ProdutoNotaFiscal produtoNotaFiscalBuscado = _repositorio.BuscarPorId(produtoNotaFiscalAdicionado.Id);

            produtoNotaFiscalBuscado.Produto.Valor.Should().Be(produtoNotaFiscalAdicionado.Produto.Valor);
            produtoNotaFiscalBuscado.Quantidade.Should().Be(produtoNotaFiscalAdicionado.Quantidade);
        }

        [Test]
        public void ProdutoNotaFiscalRepositorioSql_BuscarTodos_Sucesso()
        {
            IEnumerable<ProdutoNotaFiscal> listaProdutoNotaFiscal = _repositorio.BuscarTodos();

            listaProdutoNotaFiscal.Should().NotBeNull();
            listaProdutoNotaFiscal.Count().Should().Be(1);

        }

        [Test]
        public void ProdutoNotaFiscalRepositorioSql_Atualizar_Sucesso()
        {
            1.Should().Be(2);

            //long idDoProdutoNotaFiscalDaBaseSql = 1;

            //ProdutoNotaFiscal produtoNotaFiscalResultadoDoBuscarParaAtualizar = _repositorio.BuscarPorId(idDoProdutoNotaFiscalDaBaseSql);

            //produtoNotaFiscalResultadoDoBuscarParaAtualizar.Documento = new CPF()
            //{
            //    NumeroComPontuacao = "085.544.678-00"
            //};

            //produtoNotaFiscalResultadoDoBuscarParaAtualizar.NomeRazaoSocial = "Alterado";
            //produtoNotaFiscalResultadoDoBuscarParaAtualizar.InscricaoEstadual = null;


            //_repositorio.Atualizar(produtoNotaFiscalResultadoDoBuscarParaAtualizar);

            //ProdutoNotaFiscal produtoNotaFiscalResultadoAposAtualizacao = _repositorio.BuscarPorId(produtoNotaFiscalResultadoDoBuscarParaAtualizar.Id);

            //produtoNotaFiscalResultadoAposAtualizacao.InscricaoEstadual.Should().Be(produtoNotaFiscalResultadoDoBuscarParaAtualizar.InscricaoEstadual);
            //produtoNotaFiscalResultadoAposAtualizacao.NomeRazaoSocial.Should().Be(produtoNotaFiscalResultadoDoBuscarParaAtualizar.NomeRazaoSocial);
            //produtoNotaFiscalResultadoAposAtualizacao.Documento.ObterTipo().Should().Be(produtoNotaFiscalResultadoDoBuscarParaAtualizar.Documento.ObterTipo());
        }

        [Test]
        public void ProdutoNotaFiscalRepositorioSql_Excluir_Sucesso()
        {
            ProdutoNotaFiscal produtoNotaFiscalValido = ObjectMother.PegarProdutoNotaFiscalValido(_mockProduto.Object, _mockNotaFiscal.Object);

            long idDeProdutoCadastrado = 1;
            long idDeNotaFiscalCadastrada = 1;

            _mockProduto.Setup(mp => mp.Id).Returns(idDeProdutoCadastrado);
            _mockNotaFiscal.Setup(mnf => mnf.Id).Returns(idDeNotaFiscalCadastrada);

            ProdutoNotaFiscal produtoNotaFiscalAdicionado = _repositorio.Adicionar(produtoNotaFiscalValido);

            _repositorio.Excluir(produtoNotaFiscalAdicionado);

            ProdutoNotaFiscal produtoBuscado = _repositorio.BuscarPorId(produtoNotaFiscalAdicionado.Id);

            produtoBuscado.Should().BeNull();
        }
    }
}
