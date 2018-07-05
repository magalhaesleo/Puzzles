using FluentAssertions;
using NUnit.Framework;
using projeto_pizzaria.Domain.Excecoes;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosPedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Tests.Funcionalidades.ProdutosPedido
{
    [TestFixture]
    public class ProdutoPedidoTeste
    {
        public ProdutoPedido _produtoPedido;
        [SetUp]
        public void IniciarCenario()
        {
            _produtoPedido = new ProdutoPedido();
        }
        [Test]
        public void ProdutoPedido_Dominio_Validar_Sucesso()
        {
            Action resultado =_produtoPedido.Validar;

            resultado.Should().NotThrow<ExcecaoDeNegocio>();
        }
        [Test]
        public void ProdutoPedido_Dominio_Validar_SemProduto_Falha()
        {
            Action resultado = _produtoPedido.Validar;

            resultado.Should().NotThrow<ExcecaoDeNegocio>();
        }
    }
}
