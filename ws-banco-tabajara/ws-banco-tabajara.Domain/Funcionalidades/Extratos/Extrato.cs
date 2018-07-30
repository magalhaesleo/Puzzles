using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Domain.Funcionalidades.Extratos
{
    public class Extrato
    {
        public string NumeroConta { get; set; }
        public DateTime DataEmissao { get; set; }
        public string NomeCliente { get; set; }
        public List<Movimentacao> Movimentacoes { get; set; }
        public double Saldo { get; set; }
        public double Limite { get; set; }
    }
}
