using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Enderecos;
using projeto_pizzaria.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Common.Tests.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Cliente ObterClienteValido(Endereco endereco, IDocumento documento)
        {
            Cliente cliente = new Cliente();

            cliente.Nome = "Cliente";
            cliente.Telefone = "99999-9999";
            cliente.Endereco = endereco;
            cliente.DataNascimneto = DateTime.Parse("2000-01-01");
            cliente.Documento = documento;

            return cliente;
        }
        public static Cliente ObterClienteValidoSemDocumento(Endereco endereco)
        {
            Cliente cliente = new Cliente();

            cliente.Nome = "Cliente";
            cliente.Telefone = "99999-9999";
            cliente.Endereco = endereco;
            cliente.DataNascimneto = DateTime.Parse("2000-01-01");

            return cliente;
        }

        public static Cliente ObterClienteSemEnderecoNemDocumento()
        {
            Cliente cliente = new Cliente();

            cliente.Nome = "Cliente";
            cliente.Telefone = "99999-9999";
            cliente.DataNascimneto = DateTime.Parse("2000-01-01");

            return cliente;
        }

        public static Cliente ObterClienteSemDocumento(Endereco endereco)
        {
            Cliente cliente = new Cliente();

            cliente.Nome = "Cliente";
            cliente.Endereco = endereco;
            cliente.DataNascimneto = DateTime.Parse("2000-01-01");

            return cliente;
        }

        public static Cliente ObterClienteSemTelefoneNemDocumento(Endereco endereco)
        {
            Cliente cliente = new Cliente();

            cliente.Nome = "Cliente";
            cliente.Endereco = endereco;
            cliente.DataNascimneto = DateTime.Parse("2000-01-01");

            return cliente;
        }

        public static Cliente ObterClienteSemNomeNemDocumento(Endereco endereco)
        {
            Cliente cliente = new Cliente();

            cliente.Telefone = "99999-9999";
            cliente.Endereco = endereco;
            cliente.DataNascimneto = DateTime.Parse("2000-01-01");

            return cliente;
        }
    }
}
