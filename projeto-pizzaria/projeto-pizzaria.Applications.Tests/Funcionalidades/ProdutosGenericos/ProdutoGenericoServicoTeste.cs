using Moq;
using NUnit.Framework;
using projeto_pizzaria.Applications.Funcionalidades.ProdutosGenericos;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
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

        private Mock<ProdutoGenericoRepositorio> _mockProdutoGenericoRepositorio;

        [SetUp]
        public void IniciarCenario()
        {
            _mockProdutoGenericoRepositorio = new Mock<IPedidoRepositorio>();
            _produtoGenericoServico = new ProdutoGenericoServico(_mockProdutoGenericoRepositorio.Object);

            _produtoGenerico = new Mock<ProdutoGenerico>();
        }
    }
}
