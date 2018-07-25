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
            Cliente cliente = new Cliente();
            cliente.DataNascimento = DateTime.Now.AddYears(-20);

            contexto.Clientes.Add(cliente);
            contexto.SaveChanges();

            Conta conta = ObjectMother.ObterContaComCliente(cliente);
            contexto.Contas.Add(conta);
            contexto.SaveChanges();

            Movimentacao movimentacao = ObjectMother.ObterMovimentacaoValida(conta);
            contexto.Movimentacoes.Add(movimentacao);
            contexto.SaveChanges();

            base.Seed(contexto);
        }
    }
}
