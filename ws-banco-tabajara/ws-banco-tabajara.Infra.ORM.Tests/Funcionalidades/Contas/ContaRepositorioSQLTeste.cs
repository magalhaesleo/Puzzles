using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ws_banco_tabajara.Common.Tests.Base;
using ws_banco_tabajara.Common.Tests.Funcionalidades;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;
using ws_banco_tabajara.Infra.ORM.Contextos;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Contas;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Movimentacoes;

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
        private MovimentacaoRepositorioSQL _movimentacaoRepositorioSQL;

        [SetUp]
        public void IniciarCenario()
        {
            _contextoBancoTabajara = new ContextoBancoTabajara("BancoTabajara_Teste");
            Database.SetInitializer(new BaseSqlTeste());

            _contextoBancoTabajara.Database.Initialize(true);
            _contaRepositorio = new ContaRepositorioSQL(_contextoBancoTabajara);
            _movimentacaoRepositorioSQL = new MovimentacaoRepositorioSQL(_contextoBancoTabajara);
            _conta = new Conta();
            _cliente = new Cliente();
            _movimentacoes = new List<Movimentacao>();
            _movimentacao = new Movimentacao();
        }

        [Test]
        public void Conta_InfraData_Adicionar_Sucesso()
        {
            _cliente = ObjectMother.ObterClienteValido();
            _movimentacao = ObjectMother.ObterMovimentacaoSemDependencia();
            _movimentacoes.Add(_movimentacao);
            _conta = ObjectMother.ObterContaValidaComTodosOsDados(_cliente, _movimentacoes);
            Conta contaAdicionada = _contaRepositorio.Adicionar(_conta);

            long idInicialContaAdicionada = 1;
            contaAdicionada.Should().NotBeNull();
            contaAdicionada.Id.Should().BeGreaterOrEqualTo(idInicialContaAdicionada);
        }

        [Test]
        public void Conta_InfraData_Editar_Sucesso()
        {
            long idContaAdicionadaBaseSql = 1;
            Conta contaAdicionadanoBaseSql = _contaRepositorio.Buscar(idContaAdicionadaBaseSql);

            bool novoStatusConta = false;
            double novoLimiteConta = 5000;
            string novoNumeroConta = "000000";
            double novoSaldoConta = 20;
            contaAdicionadanoBaseSql.Ativa = novoStatusConta;
            contaAdicionadanoBaseSql.Limite = novoLimiteConta;
            contaAdicionadanoBaseSql.Numero = novoNumeroConta;
            contaAdicionadanoBaseSql.Saldo = novoSaldoConta;

            _contaRepositorio.Editar(contaAdicionadanoBaseSql);

            Conta contaEditada = _contaRepositorio.Buscar(contaAdicionadanoBaseSql.Id);

            contaEditada.Ativa.Should().Be(novoStatusConta);
            contaEditada.Limite.Should().Be(novoLimiteConta);
            contaEditada.Numero.Should().Be(novoNumeroConta);
            contaEditada.Saldo.Should().Be(novoSaldoConta);
        }

        [Test]
        public void Conta_InfraData_Excluir_Sucesso()
        {
            long idContaAdicionadaBaseSql = 1;
            Conta contaAdicionadaBaseSql = _contaRepositorio.Buscar(idContaAdicionadaBaseSql);

            _contaRepositorio.Excluir(contaAdicionadaBaseSql);

            Conta contaBuscada = _contaRepositorio.Buscar(idContaAdicionadaBaseSql);

            contaBuscada.Should().BeNull();
        }

        [Test]
        public void Conta_InfraData_Buscar_Sucesso()
        {
            long idContaAdicionadaBaseSql = 1;

            Conta contaBuscada =_contaRepositorio.Buscar(idContaAdicionadaBaseSql);

            contaBuscada.Should().NotBeNull();
            contaBuscada.Id.Should().Be(idContaAdicionadaBaseSql);
        }

        [Test]
        public void Conta_InfraData_BuscarTodos_Sucesso()
        {
            _cliente = ObjectMother.ObterClienteValido();
            _movimentacao = ObjectMother.ObterMovimentacaoSemDependencia();
            _movimentacoes.Add(_movimentacao);
            _conta = ObjectMother.ObterContaValidaComTodosOsDados(_cliente, _movimentacoes);
            Conta contaAdicionada = _contaRepositorio.Adicionar(_conta);

            IQueryable<Conta> contasBuscadas= _contaRepositorio.BuscarTodos();

            int totalContasBaseSqlEAdicionadanoTeste = 2;
            contasBuscadas.Should().HaveCountGreaterOrEqualTo(totalContasBaseSqlEAdicionadanoTeste);
        }

        [Test]
        public void Conta_InfraData_ExcluirComFKDeMovimentacaoTransferencia_Sucesso()
        {
            _cliente = ObjectMother.ObterClienteValido();
            _conta = ObjectMother.ObterContaComCliente(_cliente);
            Conta contaAdicionada = _contaRepositorio.Adicionar(_conta);

            long idContaAdicionadaBaseSql = 1, idContaAdicionadaTeste = 2;
            Conta contaAdicionadaBaseSql = _contaRepositorio.Buscar(idContaAdicionadaBaseSql);
            Conta contaAdicionadaTeste = _contaRepositorio.Buscar(idContaAdicionadaTeste);

            Movimentacao movimentacaoEnviada = ObjectMother.ObterMovimentacaoTransferenciaEnviada(contaAdicionadaBaseSql, contaAdicionadaTeste);
            Movimentacao movimentacaoRecebida = ObjectMother.ObterMovimentacaoTransferenciaEnviada(contaAdicionadaTeste, contaAdicionadaBaseSql);

            _movimentacaoRepositorioSQL.Adicionar(movimentacaoEnviada);
            _movimentacaoRepositorioSQL.Adicionar(movimentacaoRecebida);

            _contaRepositorio.Excluir(contaAdicionadaBaseSql);

            Conta contaBuscadaBaseSQL = _contaRepositorio.Buscar(idContaAdicionadaBaseSql);
            Conta contaBuscadaTeste = _contaRepositorio.Buscar(idContaAdicionadaTeste);

            contaBuscadaBaseSQL.Should().BeNull();
            contaAdicionadaTeste.Should().NotBeNull();
        }

    }
}
