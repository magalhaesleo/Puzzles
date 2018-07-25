﻿using System;
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
            Conta conta = ObjectMother.ObterContaValida();
            //Conta contaMovimentada = ObjectMother.ObterContaValida();

            contexto.Contas.Add(conta);
            //contexto.Contas.Add(contaMovimentada);
            contexto.SaveChanges();

            Movimentacao movimentacao = ObjectMother.ObterMovimentacaoValida(conta);
            contexto.Movimentacoes.Add(movimentacao);
            contexto.SaveChanges();

            conta.Movimentacoes.Add(movimentacao);
            contexto.SaveChanges();

            base.Seed(contexto);
        }
    }
}