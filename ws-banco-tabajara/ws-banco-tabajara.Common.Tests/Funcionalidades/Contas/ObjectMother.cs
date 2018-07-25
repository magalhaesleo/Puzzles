using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

namespace ws_banco_tabajara.Common.Tests.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Conta ObterContaValida()
        {
            Conta conta = new Conta();

            conta.Saldo = 10;
            conta.Limite = 1000;

            return conta;
        }

        
    }
}
