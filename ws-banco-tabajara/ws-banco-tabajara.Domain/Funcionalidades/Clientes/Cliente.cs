using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Base;

namespace ws_banco_tabajara.Domain.Funcionalidades.Clientes
{
    public class Cliente : Entidade
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public string RG { get; set; }
    }
}
