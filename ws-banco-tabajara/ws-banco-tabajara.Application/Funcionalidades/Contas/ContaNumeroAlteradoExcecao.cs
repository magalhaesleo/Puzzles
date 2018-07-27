using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Excecoes;

namespace ws_banco_tabajara.Application.Funcionalidades.Contas
{
   public class ContaNumeroAlteradoExcecao : ExcecaoDeNegocio
    {
        public ContaNumeroAlteradoExcecao() : base(CodigosDeErro.NotAllowed, "Não é possivel alterar o numero de uma conta")
        {
        }
    }
}
