using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Common.Tests.Funcionalidades;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;
using ws_banco_tabajara.Infra.ORM.Contextos;

namespace ws_banco_tabajara.Common.Tests.Base
{
    public class BaseSqlTeste : DropCreateDatabaseAlways<ContextoBancoTabajara>
    {
        protected override void Seed(ContextoBancoTabajara contexto)
        {
            ///////////////////////CLIENTES///////////////////////
            Cliente cliente = ObjectMother.ObterClienteValido();

            contexto.Clientes.Add(cliente);
            contexto.SaveChanges();

            ///////////////////////CONTAS///////////////////////
            Conta conta = ObjectMother.ObterContaComCliente(cliente);
            contexto.Contas.Add(conta);
            contexto.SaveChanges();


            ///////////////////////MOVIMENTACAO///////////////////////
            Movimentacao movimentacao = ObjectMother.ObterMovimentacaoValida(conta);
            contexto.Movimentacoes.Add(movimentacao);
            contexto.SaveChanges();

            conta.Movimentacoes.Add(movimentacao);

            ///////////////////////INDEXANDO E SALVANDO ALTERACOES///////////////////////
            contexto.SaveChanges();

            base.Seed(contexto);
        }
    }
}
