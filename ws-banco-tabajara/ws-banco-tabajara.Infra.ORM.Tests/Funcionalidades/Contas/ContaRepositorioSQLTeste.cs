using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using ws_banco_tabajara.Common.Tests.Base;
using ws_banco_tabajara.Common.Tests.Funcionalidades;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;
using ws_banco_tabajara.Infra.ORM.Contextos;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Contas;

namespace ws_banco_tabajara.Infra.ORM.Tests.Funcionalidades.Contas
{
    [TestFixture]
    public class ContaRepositorioSQLTeste
    {
        private ContaRepositorioSQL _contaRepositorio;
        private ContextoBancoTabajara _contextoBancoTabajara;
        private Conta _conta;
        private Cliente _cliente;
        private List<Movimentacao> _movimentacoes;
        private Movimentacao _movimentacao;

        [SetUp]
        public void IniciarCenario()
        {
            _contextoBancoTabajara = new ContextoBancoTabajara("BancoTabajara_Teste");
            Database.SetInitializer(new BaseSqlTeste());

            _contextoBancoTabajara.Database.Initialize(true);
            _contaRepositorio = new ContaRepositorioSQL(_contextoBancoTabajara);
            _conta = new Conta();
            _cliente = new Cliente();
            _movimentacoes = new List<Movimentacao>();
            _movimentacao = new Movimentacao();
        }

        [Test]
        public void Conta_InfraData_Adicionar_Sucesso()
        {
            _cliente.DataNascimento = DateTime.Now.AddYears(-10);
            _movimentacao = ObjectMother.ObterMovimentacaoSemDependencia();
            _movimentacoes.Add(_movimentacao);
            _conta = ObjectMother.ObterContaValidaComTodosOsDados(_cliente, _movimentacoes);
            Conta contaAdicionada = _contaRepositorio.Adicionar(_conta);

            int idInicialContaAdicionada = 1;
            contaAdicionada.Should().NotBeNull();
            contaAdicionada.Id.Should().BeGreaterOrEqualTo(idInicialContaAdicionada);
        }

        [Test]
        public void Conta_InfraData_Editar_Sucesso()
        {

        }

        [Test]
        public void Conta_InfraData_Excluir_Sucesso()
        {

        }

        [Test]
        public void Conta_InfraData_Buscar_Sucesso()
        {

        }

        [Test]
        public void Conta_InfraData_BuscarTodos_Sucesso()
        {

        }
    }
}
