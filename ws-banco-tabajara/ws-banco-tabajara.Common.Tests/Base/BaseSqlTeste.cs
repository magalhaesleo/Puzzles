using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Common.Tests.Funcionalidades;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;
using ws_banco_tabajara.Infra.ORM.Contextos;

namespace ws_banco_tabajara.Common.Tests.Base
{
    public class BaseSqlTeste : DropCreateDatabaseAlways<ContextoBancoTabajara>
    {
        protected override void Seed(ContextoBancoTabajara contexto)
        {

            //Conta conta = ObjectMother
            //Movimentacao movimentacao = ObjectMother.ObterMovimentacaoValida(conta, conta);

            contexto.Movimentacoes.Add(movimentacao);

        }
    }
}
