using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Extratos;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Common.Tests.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Extrato ObterExtratoValido()
        {
            Extrato extrato = new Extrato();

            extrato.DataEmissao = DateTime.Now;
            extrato.Limite = 500;
            extrato.Saldo = 100;
            extrato.NumeroConta = "12345";
            extrato.NomeCliente = "cliente";

            return extrato;
        }

        
    }
}
