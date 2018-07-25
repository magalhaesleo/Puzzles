using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Common.Tests.Base;
using ws_banco_tabajara.Common.Tests.Funcionalidades;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;
using ws_banco_tabajara.Infra.ORM.Contextos;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Contas;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Infra.ORM.Tests.Funcionalidades.Movimentacoes
{
    [TestFixture]
    public class MovimentacaoRepositorioSQLTeste
    {
        private MovimentacaoRepositorioSQL _repositorio;
        private ContaRepositorioSQL _contaRepositorioSQL;
        private ContextoBancoTabajara _contexto;

        private Movimentacao _movimentacao;
        private Conta _conta;
        private Conta _contaMovimentada;

        [SetUp]
        public void IniciarCenario()
        {
            _contexto = new ContextoBancoTabajara();

            Database.SetInitializer(new BaseSqlTeste());
            _contexto.Database.Initialize(true);

            _repositorio = new MovimentacaoRepositorioSQL(_contexto);
            _contaRepositorioSQL = new ContaRepositorioSQL(_contexto);

            _conta = ObjectMother.ObterContaValida();
            _contaMovimentada = ObjectMother.ObterContaValida();
            _movimentacao = ObjectMother.ObterMovimentacaoValida(_conta, _contaMovimentada);
        }

        [Test]
        public void Movimentacao_InfraData_Adicionar_Sucesso()
        {
            int numeroMovimentacoesAdicionadasPorEsteTeste = 1;

            _movimentacao = _repositorio.Adicionar(_movimentacao);

            _movimentacao.Id.Should().BeGreaterThan(0);

            var movimentacoesDaConta = _repositorio.BuscarPorConta(_movimentacao.Conta.Id).ToList();

            movimentacoesDaConta.Should().NotBeNull();
            movimentacoesDaConta.Count().Should().Be(numeroMovimentacoesAdicionadasPorEsteTeste);
            movimentacoesDaConta.Last().Should().Be(_movimentacao);
        }

        [Test]
        public void Movimentacao_InfraData_BuscarPorConta_Sucesso()
        {
            long idDaContaInseridaPorBaseSql = 1;
            int numeroMovimentacoesDaContaDeId1 = 1;

            var movimentacoesDaConta = _repositorio.BuscarPorConta(idDaContaInseridaPorBaseSql).ToList();

            movimentacoesDaConta.Should().NotBeNull();
            movimentacoesDaConta.Should().HaveCount(numeroMovimentacoesDaContaDeId1);
        }
    }
}
