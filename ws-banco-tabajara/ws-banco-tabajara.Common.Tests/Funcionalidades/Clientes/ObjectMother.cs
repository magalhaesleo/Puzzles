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
       
        public static Cliente ObterClienteValido()
        {
            return new Cliente()
            {
                Id = 1,
                CPF = "085.544.649-82",
                Nome = "Joana",
                RG = "5.201-777",
                DataNascimento = DateTime.Now.AddDays(-6000)
            };
        }
        
        

    }
}
