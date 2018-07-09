using projeto_pizzaria.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Clientes.Excecoes
{
    public class ClienteSemNomeExcecao : ExcecaoDeNegocio
    {
        public ClienteSemNomeExcecao() : base("Cliente deve possuir um nome.")
        {
        }
    }
}
