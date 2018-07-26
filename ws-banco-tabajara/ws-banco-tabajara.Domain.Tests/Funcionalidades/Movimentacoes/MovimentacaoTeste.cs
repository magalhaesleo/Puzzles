using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Common.Tests.Funcionalidades;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Domain.Tests.Funcionalidades.Movimentacoes
{
    [TestFixture]
    public class MovimentacaoTeste
    {
        private Movimentacao _movimentacao;
        private Mock<Conta> _conta;
        private Mock<Conta> _contaMovimentada;
       // private Mock<Cliente>

        [SetUp]
        public void IniciarCenario()
        {
            _conta = new Mock<Conta>();
            _contaMovimentada = new Mock<Conta>();
            _movimentacao = ObjectMother.ObterMovimentacaoValida(_conta.Object, _contaMovimentada.Object);
            _contaMovimentada.Setup(cm => cm.Numero).Returns("12345");
        }

        [Test]
        public void Movimentacao_Dominio_ToString_Credito_Sucesso()
        {
            _movimentacao.TipoOperacao = TipoOperacaoMovimentacao.CREDITO;

            var resultado = _movimentacao.ToString();

            resultado.Should().Be("Crédito de R$4,5");
        }

        [Test]
        public void Movimentacao_Dominio_ToString_Debito_Sucesso()
        {
            _movimentacao.TipoOperacao = TipoOperacaoMovimentacao.DEBITO;

            var resultado = _movimentacao.ToString();

            resultado.Should().Be("Débito de R$4,5");
        }

        [Test]
        public void Movimentacao_Dominio_ToString_TransferenciaEnviada_Sucesso()
        {
            _movimentacao.TipoOperacao = TipoOperacaoMovimentacao.TRANSFERENCIA_ENVIADA;

            var resultado = _movimentacao.ToString();

            resultado.Should().Be("Transferência realizada para a conta 12345 no valor de R$4,5");
        }

        [Test]
        public void Movimentacao_Dominio_ToString_TransferenciaEnviadaComContaExcluida_Sucesso()
        {
            _movimentacao.ContaMovimentada = null;

            _movimentacao.TipoOperacao = TipoOperacaoMovimentacao.TRANSFERENCIA_ENVIADA;

            var resultado = _movimentacao.ToString();

            resultado.Should().Be("Transferência realizada para uma conta encerrada no valor de R$4,5");
        }

        [Test]
        public void Movimentacao_Dominio_ToString_TransferenciaRecebida_Sucesso()
        {
            _movimentacao.TipoOperacao = TipoOperacaoMovimentacao.TRANSFERENCIA_RECEBIDA;

            var resultado = _movimentacao.ToString();

            resultado.Should().Be("Transferência recebida da conta 12345 no valor de R$4,5");
        }

        [Test]
        public void Movimentacao_Dominio_ToString_TransferenciaRecebidaComContaExcluida_Sucesso()
        {
            _movimentacao.ContaMovimentada = null;

            _movimentacao.TipoOperacao = TipoOperacaoMovimentacao.TRANSFERENCIA_RECEBIDA;

            var resultado = _movimentacao.ToString();

            resultado.Should().Be("Transferência recebida de uma conta encerrada no valor de R$4,5");
        }
    }
}
