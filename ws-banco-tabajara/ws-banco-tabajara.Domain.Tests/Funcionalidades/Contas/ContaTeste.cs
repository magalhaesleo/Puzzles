using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Common.Tests.Funcionalidades;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Contas.Excecoes;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Domain.Tests.Funcionalidades.Contas
{
    [TestFixture]
    public class ContaTeste
    {
        [Test]
        public void Conta_Dominio_CalcularSaldoTotal_Sucesso()
        {
            Conta conta = ObjectMother.ObterContaValida();

            int valorSaldoTotalObjectMother = 1500;

            conta.SaldoTotal.Should().Be(valorSaldoTotalObjectMother);
        }

        [Test]
        public void Conta_Dominio_Sacar_Sucesso()
        {
            double valor = 10;

            Conta conta = ObjectMother.ObterContaValida();
            double saldoAntigo = conta.Saldo;

            conta.Sacar(valor);

            conta.Movimentacoes.Count().Should().BeGreaterThan(0);
            conta.Movimentacoes.Last().TipoOperacao.Should().Be(TipoOperacaoMovimentacao.DEBITO);
            conta.Movimentacoes.Last().Valor.Should().Be(valor);
            conta.Saldo.Should().Be(saldoAntigo - valor);
        }

        [Test]
        public void Conta_Dominio_Depositar_Sucesso()
        {
            double valor = 10;

            Conta conta = ObjectMother.ObterContaValida();
            double saldoAntigo = conta.Saldo;

            conta.Depositar(valor);

            conta.Movimentacoes.Count().Should().BeGreaterThan(0);
            conta.Movimentacoes.Last().TipoOperacao.Should().Be(TipoOperacaoMovimentacao.CREDITO);
            conta.Movimentacoes.Last().Valor.Should().Be(valor);
            conta.Saldo.Should().Be(saldoAntigo + valor);
        }

        [Test]
        public void Conta_Dominio_Sacar_SaldoInsuficienteExcecao_Falha()
        {
            Conta conta = ObjectMother.ObterContaValida();
            double saldo = conta.Saldo;
            double limite = conta.Limite;

            double valor = saldo + limite + 1;

            Action acaoResultado = () => conta.Sacar(valor);

            acaoResultado.Should().Throw<SaldoInsuficienteExcecao>();
        }

        [Test]
        public void Conta_Dominio_Transferir_Sucesso()
        {
            double valor = 10;

            Conta contaMovimentada = ObjectMother.ObterContaValida();
            double saldoContaMovimentada = contaMovimentada.Saldo;

            Conta conta = ObjectMother.ObterContaValida();
            double saldoAntigo = conta.Saldo;

            conta.Transferir(contaMovimentada, valor);

            conta.Movimentacoes.Count().Should().BeGreaterThan(0);
            contaMovimentada.Movimentacoes.Count().Should().BeGreaterThan(0);
            conta.Movimentacoes.Last().TipoOperacao.Should().Be(TipoOperacaoMovimentacao.TRANSFERENCIA_ENVIADA);
            contaMovimentada.Movimentacoes.Last().TipoOperacao.Should().Be(TipoOperacaoMovimentacao.TRANSFERENCIA_RECEBIDA);
            conta.Movimentacoes.Last().Valor.Should().Be(valor);
            contaMovimentada.Movimentacoes.Last().Valor.Should().Be(valor);
            conta.Saldo.Should().Be(saldoAntigo - valor);
            contaMovimentada.Saldo.Should().Be(saldoContaMovimentada + valor);
        }

        [Test]
        public void Conta_Dominio_Transferir_SaldoInsuficienteExcecao_Falha()
        {
            Conta contaMovimentada = ObjectMother.ObterContaValida();

            Conta conta = ObjectMother.ObterContaValida();
            double saldo = conta.Saldo;
            double limite = conta.Limite;

            double valor = saldo + limite + 1;

            Action acaoResultado = () => conta.Transferir(contaMovimentada, valor);

            acaoResultado.Should().Throw<SaldoInsuficienteExcecao>();
        }

        [Test]
        public void Conta_Dominio_AlterarStatus_Sucesso()
        {
            Conta conta = ObjectMother.ObterContaValida();

            bool statusAntigo = conta.Ativa;

            conta.AlterarStatus();

            conta.Ativa.Should().Be(!statusAntigo);
        }
    }
}
