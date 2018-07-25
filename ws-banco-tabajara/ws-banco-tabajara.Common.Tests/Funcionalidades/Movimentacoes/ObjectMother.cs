using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Common.Tests.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Movimentacao ObterMovimentacaoValida(Conta conta, Conta contaMovimentada)
        {
            return new Movimentacao()
            {
                Data = DateTime.Now,
                Descricao = "Descricao",
                Valor = 4.50,
                TipoOperacao = TipoOperacaoMovimentacao.TRANSFERENCIA_ENVIADA,
                Conta = conta,
                ContaMovimentada = contaMovimentada
            };
        }

        public static Movimentacao ObterMovimentacaoValida(Conta conta)
        {
            return new Movimentacao()
            {
                Data = DateTime.Now,
                Descricao = "Descricao",
                Valor = 4.50,
                TipoOperacao = TipoOperacaoMovimentacao.CREDITO,
                Conta = conta
            };
        }

        public static Movimentacao ObterMovimentacaoSemDependencia()
        {
            return new Movimentacao()
            {
                Data = DateTime.Now,
                Descricao = "Descricao",
                Valor = 4.50,
                TipoOperacao = TipoOperacaoMovimentacao.CREDITO,             
            };
        }
    }
}
