using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Common.Tests.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Conta ObterContaValida()
        {
            Conta conta = new Conta();

            conta.Numero = "32432443";
            conta.Saldo = 500;
            conta.Limite = 1000;

            return conta;
        }

        public static Conta ObterContaComCliente(Cliente cliente)
        {
            Conta conta = new Conta();

            conta.Numero = "32432443";
            conta.Saldo = 10;
            conta.Limite = 1000;
            conta.Titular = cliente;
            conta.Ativa = true;

            return conta;
        }

        public static Conta ObterContaValidaComTodosOsDados(Cliente cliente, List<Movimentacao> movimentacoes)
        {
            Conta conta = new Conta();

            conta.Titular = cliente;
            conta.Movimentacoes = movimentacoes;
            conta.Numero = "2313223";
            conta.Saldo = 1000;
            conta.Ativa = true;
            conta.Limite = 500;

            return conta;
        }
    }
}
