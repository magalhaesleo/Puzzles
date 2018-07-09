using FluentAssertions;
using NUnit.Framework;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Infra.Data.Contextos;
using projeto_pizzaria.Infra.Data.Funcionalidades.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.InfraData.Tests.Funcionalidades.Clientes
{
    [TestFixture]
    public class ClienteRepositorioSQLTeste
    {
        private ClienteRepositorioSQL _clienteRepositorio;
        private PizzariaContexto _pizzariaContexto;

        [SetUp]
        public void IniIniciarCenario()
        {
            _pizzariaContexto = new PizzariaContexto();
            _clienteRepositorio = new ClienteRepositorioSQL(_pizzariaContexto);
        }

        [Test]
        public void Cliente_InfraData_BuscarClientePorTelefone_Sucesso()
        {
            IEnumerable<Cliente> clientesEncontrados = new List<Cliente>();

            string nomeDoPrimeiroClienteAdicionadoPeloBaseSql = "Cliente";
            string numeroDoPrimeiroClienteAdicionadoPeloBaseSql = "99999999";

            clientesEncontrados = _clienteRepositorio.BuscarClientePorTelefone(numeroDoPrimeiroClienteAdicionadoPeloBaseSql);

            clientesEncontrados.First().Nome.Should().Be(nomeDoPrimeiroClienteAdicionadoPeloBaseSql);

        }
    }
}
