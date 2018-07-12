using FluentAssertions;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests.Base;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos.Bebidas;
using projeto_pizzaria.Infra.Data.Contextos;
using projeto_pizzaria.Infra.Data.Funcionalidades.ProdutosGenericos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.InfraData.Tests.Funcionalidades.ProdutosGenericos
{
    [TestFixture]
    public class ProdutoGenericoRepositorioSQLTeste
    {
        private PizzariaContexto _pizzariaContexto;
        private ProdutoGenericoRepositorioSQL _produtoGenericoRepositorioSQL;

        [SetUp]
        public void IniciarCenario()
        {
            _pizzariaContexto = new PizzariaContexto();
            _produtoGenericoRepositorioSQL = new ProdutoGenericoRepositorioSQL(_pizzariaContexto);

            Database.SetInitializer(new BaseSQLTeste());

            _pizzariaContexto.Database.Initialize(true);
        }
        [Test]
        public void ProdutoGenerico_InfraDados_BuscarTodos_Sucesso()
        {
            IEnumerable<ProdutoGenerico> produtos = _produtoGenericoRepositorioSQL.BuscarTodos<ProdutoGenerico>();

            produtos.Should().NotBeNull();
            produtos.Should().HaveCountGreaterOrEqualTo(1);
        }
        [Test]
        public void ProdutoGenerico_InfraDados_BuscarTodasBebidas_Sucesso()
        {
            IEnumerable<ProdutoGenerico> produtos = _produtoGenericoRepositorioSQL.BuscarTodos<Bebida>();

            produtos.Should().NotBeNull();
            produtos.Should().HaveCountGreaterOrEqualTo(1);

            IEnumerable<Bebida> bebidas = produtos.OfType<Bebida>();
            bebidas.Should().HaveCountLessOrEqualTo(produtos.Count());
        }
    }
}
