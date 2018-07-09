using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Enderecos;
using projeto_pizzaria.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Common.Tests.Funcionalidades.Clientes
{
    public static partial class ObjectMother
    {
        public static Cliente ObterClienteValido(Endereco endereco, IDocumento documento)
        {
            Cliente cliente = new Cliente();

            cliente.Nome = "Cliente";
            cliente.Telefone = "99999-9999";
            cliente.Endereco = endereco;
            cliente.DataNascimento = DateTime.Parse("2000-01-01");
            cliente.Documento = documento;

            return cliente;
        }
    }
}
