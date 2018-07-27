using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Excecoes;

namespace ws_banco_tabajara.Domain.Funcionalidades.Contas.Excecoes
{
    public class SaldoInsuficienteExcecao : ExcecaoDeNegocio
    {
        public SaldoInsuficienteExcecao() : base(CodigosDeErro.NotAllowed, "O saldo é insuficiente para realizar esta operação")
        {
        }
    }
}
