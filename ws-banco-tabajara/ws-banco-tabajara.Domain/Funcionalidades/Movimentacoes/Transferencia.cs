using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

namespace ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes
{
    public class Transferencia : Movimentacao
    {
        public Conta ContaOrigem { get; set; }
        public Conta ContaDestino { get; set; }
    }
}
