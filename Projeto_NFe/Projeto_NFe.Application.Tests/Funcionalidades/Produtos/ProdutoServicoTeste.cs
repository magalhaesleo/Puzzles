using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Produtos;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Tests.Funcionalidades.Produtos
{
    [TestFixture]
    public class ProdutoServicoTeste
    {

        Mock<IProdutoRepositorio> _mockRepositorioProduto;
        Mock<Produto> _mockProduto;
        IProdutoServico _produtoServico;
        [SetUp]
        public void Inicializar()
        {
            _mockRepositorioProduto = new Mock<IProdutoRepositorio>();
            _mockProduto = new Mock<Produto>();
            _produtoServico = new ProdutoServico(_mockRepositorioProduto.Object);
        }

        [Test]
        public void ProdutoServico_Adicionar_Sucesso()
        {
            _mockProduto.Setup(mp => mp.Validar());
            _mockRepositorioProduto.Setup(mrp => mrp.Adicionar(_mockProduto.Object)).Returns(_mockProduto.Object);

            _produtoServico.Adicionar(_mockProduto.Object);

            _mockProduto.Verify(mp => mp.Validar());
            _mockRepositorioProduto.Verify(mrp => mrp.Adicionar(_mockProduto.Object));

        }

        [Test]
        public void ProdutoServico_Atualizar_Sucesso()
        {
            _mockProduto.Setup(mp => mp.Validar());
            _mockProduto.Setup(mp => mp.Id).Returns(1);
            _mockRepositorioProduto.Setup(mrp => mrp.Atualizar(_mockProduto.Object)).Returns(_mockProduto.Object);

            _produtoServico.Atualizar(_mockProduto.Object);

            _mockProduto.Verify(mp => mp.Validar());
            _mockRepositorioProduto.Verify(mrp => mrp.Atualizar(_mockProduto.Object));
        }

        [Test]
        public void ProdutoServico_Atualizar_ExcecaoIdentificadorIndefinido_Falha()
        {
            long idInvalido = 0;

            _mockProduto.Setup(mp => mp.Id).Returns(idInvalido);

            Action acaoQueDeveRetornarExcecaoIdentificadorIndefinido = () => _produtoServico.Atualizar(_mockProduto.Object);

            acaoQueDeveRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoIdentificadorIndefinido>();

            _mockRepositorioProduto.VerifyNoOtherCalls();
        }

        [Test]
        public void ProdutoServico_BuscarPorId_Sucesso()
        {
            long idValido = 1;

            _mockProduto.Setup(mp => mp.Id).Returns(idValido);
            _mockRepositorioProduto.Setup(mrp => mrp.BuscarPorId(_mockProduto.Object.Id)).Returns(_mockProduto.Object);

            _produtoServico.BuscarPorId(_mockProduto.Object.Id);

            _mockProduto.Verify(mp => mp.Id);
            _mockRepositorioProduto.Verify(mrp => mrp.BuscarPorId(_mockProduto.Object.Id));
        }

        [Test]
        public void ProdutoServico_BuscarPorId_ExcecaoIdentificadorIndefinido_Falha()
        {
            long idInvalido = 0;

            _mockProduto.Setup(mp => mp.Id).Returns(idInvalido);

            Action acaoQueDeveRetornarExcecaoIdentificadorIndefinido = () => _produtoServico.BuscarPorId(_mockProduto.Object.Id);

            acaoQueDeveRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoIdentificadorIndefinido>();

            _mockRepositorioProduto.VerifyNoOtherCalls();
        }

        [Test]
        public void ProdutoServico_BuscarTodos_Sucesso()
        {
            _mockRepositorioProduto.Setup(mpr => mpr.BuscarTodos());

            _produtoServico.BuscarTodos();

            _mockRepositorioProduto.Verify(mrp => mrp.BuscarTodos());
        }

        [Test]
        public void ProdutoServico_Excluir_Sucesso()
        {
            long idValido = 1;

            _mockProduto.Setup(mp => mp.Id).Returns(idValido);

            _mockRepositorioProduto.Setup(mrp => mrp.Excluir(_mockProduto.Object));

            _produtoServico.Excluir(_mockProduto.Object);

            _mockRepositorioProduto.Verify(mrp => mrp.Excluir(_mockProduto.Object));

        }

        [Test]
        public void ProdutoServico_Excluir_ExcecaoIdentificadorIndefinido_Falha()
        {
            long idInvalido = 0;

            _mockProduto.Setup(mp => mp.Id).Returns(idInvalido);

            _mockRepositorioProduto.Setup(mrp => mrp.Excluir(_mockProduto.Object));

            Action acaoQueDeveRetornarExcecaoIdentificadorIndefinido = () => _produtoServico.Excluir(_mockProduto.Object);

            acaoQueDeveRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoIdentificadorIndefinido>();

            _mockRepositorioProduto.VerifyNoOtherCalls();
        }


    }

}
