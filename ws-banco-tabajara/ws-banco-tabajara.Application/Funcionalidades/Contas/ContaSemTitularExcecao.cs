using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws_banco_tabajara.Application.Funcionalidades.Contas
{
    public class ContaSemTitularExcecao : Exception
    {
        public ContaSemTitularExcecao() : base("A conta deve possuir um titular")
        {

        }
    }
}
