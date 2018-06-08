using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Funcionalidades.ProdutosNotasFiscais
{
    [TestFixture]
    public class ProdutoNotaFiscalTeste 
    {
        Mock<Produto> _mockProduto;
        Mock<NotaFiscal> _mockNotaFiscal;

        [SetUp]
        public void Inicializar()
        {
            _mockProduto = new Mock<Produto>();
            _mockNotaFiscal = new Mock<NotaFiscal>();
        }

        [Test]
        public void ProdutoNotaFiscal_Validar_Sucesso()
        {
            ProdutoNotaFiscal produtoParaSerValidado = ObjectMother.PegarProdutoNotaFiscalValido(_mockProduto.Object,_mockNotaFiscal.Object);

            Action acaoQueNaoDeveRetornarExcecao = () => produtoParaSerValidado.Validar();

            acaoQueNaoDeveRetornarExcecao.Should().NotThrow<ExcecaoDeNegocio>();
        }

        [Test]
        public void ProdutoNotaFiscal_Validar_ExcecaoProdutoNotaFiscalSemProduto()
        {
            ProdutoNotaFiscal produtoParaSerValidado = ObjectMother.PegarProdutoNotaFiscalSemProdutoVinculadoValido(_mockNotaFiscal.Object);

            Action acaoQueDeveRetornarExcecaoProdutoNotaFiscalSemProduto = () => produtoParaSerValidado.Validar();

            acaoQueDeveRetornarExcecaoProdutoNotaFiscalSemProduto.Should().Throw<ExcecaoProdutoNotaFiscalSemProduto>();
        }

        [Test]
        public void ProdutoNotaFiscal_Validar_ExcecaoProdutoNotaFiscalSemNotaFiscal()
        {
            ProdutoNotaFiscal produtoParaSerValidado = ObjectMother.PegarProdutoNotaFiscalSemNotaFiscalVinculadaValido(_mockProduto.Object);

            Action acaoQueDeveRetornarExcecaoProdutoNotaFiscalSemNotaFiscal= () => produtoParaSerValidado.Validar();

            acaoQueDeveRetornarExcecaoProdutoNotaFiscalSemNotaFiscal.Should().Throw<ExcecaoProdutoNotaFiscalSemNotaFiscal>();
        }

        [Test]
        public void ProdutoNotaFiscal_Validar_ExcecaoProdutoNotaFiscalComQuantidadeInferiorAum()
        {
            ProdutoNotaFiscal produtoParaSerValidado = ObjectMother.PegarProdutoNotaFiscalComQuantidadeInferiorAumValido(_mockProduto.Object, _mockNotaFiscal.Object);

            Action acaoQueDeveRetornarExcecaoProdutoNotaFiscalComQuantidadeInferiorAum = () => produtoParaSerValidado.Validar();

            acaoQueDeveRetornarExcecaoProdutoNotaFiscalComQuantidadeInferiorAum.Should().Throw<ExcecaoProdutoNotaFiscalComQuantidadeInferiorAum>();
        }

        [Test]
        public void ProdutoNotaFiscal_ValorTotal_Sucesso()
        {
            ProdutoNotaFiscal produtoNotaFiscalParaCalcularValorTotal = ObjectMother.PegarProdutoNotaFiscalValido(_mockProduto.Object, _mockNotaFiscal.Object);

            int quantidadeDeProdutosDoObjectMother = 10;
            int valorEsperadoDoProduto = 100;

            _mockProduto.Setup(mp => mp.Valor).Returns(valorEsperadoDoProduto);

            produtoNotaFiscalParaCalcularValorTotal.ValorTotal.Should().Be(valorEsperadoDoProduto * quantidadeDeProdutosDoObjectMother);
        }

        [Test]
        public void ProdutoNotaFiscal_ValorIPI_Sucesso()
        {
            ProdutoNotaFiscal produtoNotaFiscalParaCalcularValorIPI = ObjectMother.PegarProdutoNotaFiscalValido(_mockProduto.Object, _mockNotaFiscal.Object);

            int quantidadeDeProdutosDoObjectMother = 10;
            int valorEsperadoDoProduto = 100;
            double produtoAliquotaIPI = 0.10;
            
            _mockProduto.Setup(mp => mp.Valor).Returns(valorEsperadoDoProduto);
            _mockProduto.Setup(mp => mp.AliquotaIPI).Returns(produtoAliquotaIPI);

            produtoNotaFiscalParaCalcularValorIPI.ValorIPI.Should().Be(valorEsperadoDoProduto * quantidadeDeProdutosDoObjectMother * produtoAliquotaIPI);
        }

        [Test]
        public void ProdutoNotaFiscal_ValorICMS_Sucesso()
        {
            ProdutoNotaFiscal produtoNotaFiscalParaCalcularValorICMS = ObjectMother.PegarProdutoNotaFiscalValido(_mockProduto.Object, _mockNotaFiscal.Object);

            int quantidadeDeProdutosDoObjectMother = 10;
            int valorEsperadoDoProduto = 100;
            double produtoAliquotaICMS = 0.04;

            _mockProduto.Setup(mp => mp.Valor).Returns(valorEsperadoDoProduto);
            _mockProduto.Setup(mp => mp.AliquotaICMS).Returns(produtoAliquotaICMS);

            _mockProduto.Setup(mp => mp.Valor).Returns(valorEsperadoDoProduto);

            produtoNotaFiscalParaCalcularValorICMS.ValorICMS.Should().Be(valorEsperadoDoProduto * quantidadeDeProdutosDoObjectMother * produtoAliquotaICMS);
        }
    }
}
