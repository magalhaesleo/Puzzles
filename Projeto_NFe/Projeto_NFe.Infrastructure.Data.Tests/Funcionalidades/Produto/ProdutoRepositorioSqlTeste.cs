using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades.Produtos;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Tests.Funcionalidades.Produtos
{
    [TestFixture]
    public class ProdutoRepositorioSqlTeste
    {
        private IProdutoRepositorio _repositorio;

        [SetUp]
        public void IniciarCenario()
        {
            _repositorio = new ProdutoRepositorioSql();

            BaseSqlTeste.InicializarBancoDeDadosPrepararProduto();
        }

        [Test]
        public void ProdutoRepositorioSql_Adicionar_Sucesso()
        {
            Produto produto = ObjectMother.ObterProdutoValido();

            Produto produtoAdicionado = _repositorio.Adicionar(produto);

            produtoAdicionado.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoRepositorioSql_Atualizar_Sucesso()
        {
            Produto produtoParaAdicionar = ObjectMother.ObterProdutoValido();

            Produto produtoParaAtualizar = _repositorio.Adicionar(produtoParaAdicionar);

            produtoParaAtualizar.Valor = 1000;
            produtoParaAtualizar.Descricao = "Alterado";
            produtoParaAtualizar.Codigo = "123456";

            _repositorio.Atualizar(produtoParaAtualizar);

            Produto produtoAtualizado = _repositorio.BuscarPorId(produtoParaAtualizar.Id);

            produtoAtualizado.Should().NotBeNull();
            produtoAtualizado.Valor.Should().Be(produtoParaAtualizar.Valor);
            produtoAtualizado.Valor.Should().NotBe(ObjectMother.ObterProdutoValido().Valor);
            produtoAtualizado.Descricao.Should().Be(produtoParaAtualizar.Descricao);
            produtoAtualizado.Codigo.Should().Be(produtoParaAtualizar.Codigo);


        }

        [Test]
        public void ProdutoRepositorioSql_Excluir_Sucesso()
        {
            Produto produtoParaAdicionar = ObjectMother.ObterProdutoValido();

            Produto produtoAdicionado = _repositorio.Adicionar(produtoParaAdicionar);

            _repositorio.Excluir(produtoAdicionado);

            Produto produtoBuscado = _repositorio.BuscarPorId(produtoAdicionado.Id);

            produtoBuscado.Should().BeNull();
        }

        [Test]
        public void ProdutoRepositorioSql_BuscarPorId_Sucesso()
        {
            Produto produtoParaAdicionar = ObjectMother.ObterProdutoValido();

            Produto produtoParaBuscar = _repositorio.Adicionar(produtoParaAdicionar);

            Produto produtoBuscado = _repositorio.BuscarPorId(produtoParaBuscar.Id);

            produtoBuscado.Id.Should().Be(produtoParaBuscar.Id);
            produtoBuscado.Valor.Should().Be(produtoParaAdicionar.Valor);
            produtoBuscado.Codigo.Should().Be(produtoParaAdicionar.Codigo);
            produtoBuscado.Descricao.Should().Be(produtoParaAdicionar.Descricao);
        }

        [Test]
        public void ProdutoRepositorioSql_BuscarTodos_Sucesso()
        {
            IEnumerable<Produto> produtosBuscados;

            produtosBuscados = _repositorio.BuscarTodos();

            produtosBuscados.Should().NotBeNull();
            produtosBuscados.Count().Should().Be(1);
        }
    }
}
