using FluentAssertions;
using Moq;
using NUnit.Framework;
using projeto_pizzaria.Applications.Funcionalidades.ProdutosGenericos;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos.Bebidas;
using projeto_pizzaria.Domain.Interfaces.ProdutosGenericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Applications.Tests.Funcionalidades.ProdutosGenericos
{
    [TestFixture]
    public class ProdutoGenericoServicoTeste
    {
        private ProdutoGenericoServico _produtoGenericoServico;

        private Mock<ProdutoGenerico> _mockProdutoGenerico;

        private Mock<IProdutoGenericoRepositorio> _mockProdutoGenericoRepositorio;

        [SetUp]
        public void IniciarCenario()
        {
            _mockProdutoGenericoRepositorio = new Mock<IProdutoGenericoRepositorio>();
            _produtoGenericoServico = new ProdutoGenericoServico(_mockProdutoGenericoRepositorio.Object);

            _mockProdutoGenerico = new Mock<ProdutoGenerico>();
        }

        [Test]
        public void ProdutoGenerico_Aplicacao_BuscarTodos_Bebidas_Sucesso()
        {
            Mock<List<Bebida>> mockListaBebidas = new Mock<List<Bebida>>();

            _mockProdutoGenericoRepositorio.Setup(mpgr => mpgr.BuscarTodos<Bebida>()).Returns(mockListaBebidas.Object);

            List<ProdutoGenerico> produtosBuscados = _produtoGenericoServico.BuscarTodos<Bebida>().ToList();

            produtosBuscados.Should().NotBeNull();

            _mockProdutoGenericoRepositorio.Verify(mpgr => mpgr.BuscarTodos<Bebida>());
        }

        [Test]
        public void ProdutoGenerico_Aplicacao_BuscarTodos_Sucesso()
        {
            Mock<List<ProdutoGenerico>> mockListaBebidas = new Mock<List<ProdutoGenerico>>();

            _mockProdutoGenericoRepositorio.Setup(mpgr => mpgr.BuscarTodos()).Returns(mockListaBebidas.Object);

            List<ProdutoGenerico> produtosBuscados = _produtoGenericoServico.BuscarTodos().ToList();

            produtosBuscados.Should().NotBeNull();

            _mockProdutoGenericoRepositorio.Verify(mpgr => mpgr.BuscarTodos());
        }
    }
}
