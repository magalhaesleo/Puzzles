using FluentAssertions;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests.Base;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Infra.Data.Contextos;
using projeto_pizzaria.Infra.Data.Funcionalidades.Clientes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public void IniciarCenario()
        {
            _pizzariaContexto = new PizzariaContexto();
            _clienteRepositorio = new ClienteRepositorioSQL(_pizzariaContexto);

            Database.SetInitializer(new BaseSQLTeste());

            _pizzariaContexto.Database.Initialize(true);
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
