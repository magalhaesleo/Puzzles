using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Funcionalidades.Produtos;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Produto;
using Projeto_NFe.Domain.Funcionalidades.Produto.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
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

        [Test]
        public void Produto_Validar_AliquotaIPI_Sucesso()
        {
            Produto produtoParaSerValidado = ObjectMother.ObterProdutoValido();

            Action acaoQueNaoDeveRetornarExcessao = () => produtoParaSerValidado.Validar();

            acaoQueNaoDeveRetornarExcessao.Should().NotThrow<ExcecaoDeNegocio>();

            produtoParaSerValidado.AliquotaIPI.Should().Be(0.10);
        }

        [Test]
        public void Produto_Validar_AliquotaICMS_Sucesso()
        {
            Produto produtoParaSerValidado = ObjectMother.ObterProdutoValido();

            Action acaoQueNaoDeveRetornarExcessao = () => produtoParaSerValidado.Validar();

            acaoQueNaoDeveRetornarExcessao.Should().NotThrow<ExcecaoDeNegocio>();

            produtoParaSerValidado.AliquotaICMS.Should().Be(0.04);
        }

    }
}
