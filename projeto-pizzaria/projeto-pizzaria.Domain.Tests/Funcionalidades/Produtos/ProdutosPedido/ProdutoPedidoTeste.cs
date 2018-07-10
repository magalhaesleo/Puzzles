using FluentAssertions;
using Moq;
using NUnit.Framework;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.ProdutosPedido;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Tests.Funcionalidades.Produtos.ProdutosPedido
{
    [TestFixture]
    public class ProdutoPedidoTeste
    {
        private ProdutoPedido _produtoPedido;

        private Mock<ProdutoGenerico> _mockProduto;

        [Test]
        public void ProdutoPedido_Dominio_Tipo_Sucesso()
        {
            _mockProduto = new Mock<ProdutoGenerico>();
            _mockProduto.Setup(mp => mp.Tipo).Returns("Bebida");

            _produtoPedido = new ProdutoPedido();
            _produtoPedido.Produto = _mockProduto.Object;

            _produtoPedido.Tipo.Should().Be(_mockProduto.Object.Tipo);
        }
    }
}
