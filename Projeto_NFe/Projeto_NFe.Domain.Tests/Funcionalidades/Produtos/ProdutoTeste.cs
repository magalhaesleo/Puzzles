using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Funcionalidades.Produtos;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Produto;
using Projeto_NFe.Domain.Funcionalidades.Produto.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Funcionalidades.Produtos
{
    [TestFixture]
    public class ProdutoTeste
    {
        [SetUp]
        public void Inicializar()
        {

        }

        [Test]
        public void Produto_Validar_Sucesso()
        {
            Produto produtoParaSerValidado = ObjectMother.ObterProdutoValido();

            Action acaoQueNaoDeveRetornarExcessao = () => produtoParaSerValidado.Validar();

            acaoQueNaoDeveRetornarExcessao.Should().NotThrow<ExcecaoDeNegocio>();
        }

        [Test]
        public void Produto_Validar_ExcecaoProdutoComValorNegativo_Falha()
        {
            Produto produtoParaSerValidado = ObjectMother.ObterProdutoComValorNegativo();

            Action acaoQueNaoDeveRetornarExcessao = () => produtoParaSerValidado.Validar();

            acaoQueNaoDeveRetornarExcessao.Should().Throw<ExcecaoProdutoComValorNegativo>();
        }

        [Test]
        public void Produto_Validar_ExcecaoProdutoSemCodigo_Falha()
        {
            Produto produtoParaSerValidado = ObjectMother.ObterProdutoSemCodigo();

            Action acaoQueNaoDeveRetornarExcessao = () => produtoParaSerValidado.Validar();

            acaoQueNaoDeveRetornarExcessao.Should().Throw<ExcecaoProdutoSemCodigo>();
        }

        [Test]
        public void Produto_Validar_ExcecaoProdutoSemDescricao_Falha()
        {
            Produto produtoParaSerValidado = ObjectMother.ObterProdutoSemDescricao();

            Action acaoQueNaoDeveRetornarExcessao = () => produtoParaSerValidado.Validar();

            acaoQueNaoDeveRetornarExcessao.Should().Throw<ExcecaoProdutoSemDescricao>();
        }

    }
}
