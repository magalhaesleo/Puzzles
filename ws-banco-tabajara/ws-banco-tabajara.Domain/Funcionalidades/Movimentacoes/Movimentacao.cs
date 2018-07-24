using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Base;

namespace ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes
{
    public class Movimentacao : Entidade
    {
        public DateTime Data { get; set; }

        public TipoOperacaoMovimentacao TipoOperacao { get; set; }

        //Deve dizer se foi transferência, saque ou depósito
        public string Descricao { get; set; }

        public double Valor { get; set; }

    }
}
