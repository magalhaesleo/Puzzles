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
        public static Cliente obterClienteValidoComReferenciaDeConta(Conta contaReferencia)
        {
            return new Cliente()
            {
                Id = 1,
                Conta = contaReferencia,
                ContaId = contaReferencia.Id,
                CPF = "085.544.649-82",
                Nome = "Joao",
                RG = "5.201-786",
                DataNascimento = DateTime.Now.AddDays(-6000)
            };
        }

        public static Cliente obterClienteValidoSemReferenciaDeConta(int idDeConta)
        {
            return new Cliente()
            {
                Id = 1,
                ContaId = idDeConta,
                CPF = "085.544.649-82",
                Nome = "Joana",
                RG = "5.201-777",
                DataNascimento = DateTime.Now.AddDays(-6000)
            };
        }
        
        public static Cliente obterClienteValidoSemReferenciaDeContaComContaIdDiferenteDaAnterior(int idDeContaDiferenteDaContaAnteriorDiferente)
        {
            return new Cliente()
            {
                Id = 1,
                ContaId = idDeContaDiferenteDaContaAnteriorDiferente,
                CPF = "085.544.649-82",
                Nome = "Joao",
                RG = "5.201-786",
                DataNascimento = DateTime.Now.AddDays(-6000)
            };
        }

    }
}
