using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Base;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Domain.Funcionalidades.Contas
{
    public class Conta : Entidade
    {
        public Conta()
        {
            Movimentacoes = new List<Movimentacao>();
        }

        public virtual Cliente Titular { get; set; }

        public virtual string Numero { get; set; }

        public bool Ativa { get; set; }

        public double Saldo { get; set; }

        public double Limite { get; set; }

        //SaldoTotal é composto por Saldo + Limite
        public double SaldoTotal
        {
            get
            {
                return Limite + Saldo;
            }
            set { }
        }

        public virtual ICollection<Movimentacao> Movimentacoes { get; set; }

        public void AlterarStatus()
        {
            this.Ativa = !this.Ativa;
        }

        public void Sacar(double valorSaque)
        {
            Movimentacao saque = new Movimentacao
            {
                Conta = this,
                Data = DateTime.Now,
                TipoOperacao = TipoOperacaoMovimentacao.DEBITO,
                Valor = valorSaque
            };
            this.Movimentacoes.Add(saque);
        }

        public void Depositar(double valorDeposito)
        {
            Movimentacao deposito = new Movimentacao
            {
                Conta = this,
                Data = DateTime.Now,
                TipoOperacao = TipoOperacaoMovimentacao.CREDITO,
                Valor = valorDeposito
            };
            this.Movimentacoes.Add(deposito);
        }

        public void Transferir(Conta contaMovimentada, double valorTransferencia)
        {
            Movimentacao transferenciaEnviada = new Movimentacao
            {
                Conta = this,
                ContaMovimentada = contaMovimentada,
                Data = DateTime.Now,
                TipoOperacao = TipoOperacaoMovimentacao.TRANSFERENCIA_ENVIADA,
                Valor = valorTransferencia
            };
            this.Movimentacoes.Add(transferenciaEnviada);

            Movimentacao transferenciaRecebida = new Movimentacao
            {
                Conta = contaMovimentada,
                ContaMovimentada = this,
                Data = DateTime.Now,
                TipoOperacao = TipoOperacaoMovimentacao.TRANSFERENCIA_RECEBIDA,
                Valor = valorTransferencia
            };
            contaMovimentada.Movimentacoes.Add(transferenciaRecebida);
        }
    }
}
