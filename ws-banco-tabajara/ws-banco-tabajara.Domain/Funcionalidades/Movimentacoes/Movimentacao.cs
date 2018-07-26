using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Base;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

namespace ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes
{
    public class Movimentacao : Entidade
    {
        public DateTime Data { get; set; }

        public TipoOperacaoMovimentacao TipoOperacao { get; set; }

        public double Valor { get; set; }

        public virtual Conta Conta { get; set; }
        public virtual Conta ContaMovimentada { get; set; }
        public override string ToString()
        {
            string descricao = "";

            switch (this.TipoOperacao)
            {
                case TipoOperacaoMovimentacao.CREDITO:
                    descricao += "Crédito de " + this.Valor;
                    break;
                case TipoOperacaoMovimentacao.DEBITO:
                    descricao += "Débito de " + this.Valor;
                    break;
                case TipoOperacaoMovimentacao.TRANSFERENCIA_ENVIADA:
                    descricao += "Transferência realizada para a conta " + this.ContaMovimentada.Numero + " no valor de " + this.Valor;
                    break;
                case TipoOperacaoMovimentacao.TRANSFERENCIA_RECEBIDA:
                    descricao += "Transferência recebida da conta " + this.ContaMovimentada.Numero + " no valor de " + this.Valor;
                    break;
            }

            return descricao;
        }
    }
}
