using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

namespace ws_banco_tabajara.Domain.Funcionalidades.Extratos
{
    public class Extrato
    {
        public Conta Conta { get; set; }

        public DateTime DataEmissao { get; set; }

        public Cliente Cliente { get; set; }
    }
}
