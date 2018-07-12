using FluentAssertions;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests.Base;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using projeto_pizzaria.Infra.Data.Contextos;
using projeto_pizzaria.Infra.Data.Funcionalidades.Sabores;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.InfraData.Tests.Funcionalidades.Sabores
{
    [TestFixture]
    public class SaborRepositorioSQLTeste
    {
        private PizzariaContexto _pizzariaContexto;
        private SaborRepositorioSQL _saborRepositorio;

        [SetUp]
        public void IniciarCenario()
        {
            _pizzariaContexto = new PizzariaContexto();
            _saborRepositorio = new SaborRepositorioSQL(_pizzariaContexto);

            Database.SetInitializer(new BaseSQLTeste());

            _pizzariaContexto.Database.Initialize(true);
        }

        [Test]
        public void Sabor_InfraDados_BuscarTodos_Sucesso()
        {
            int quantidadeSaboresCadastradosPorBaseSQL = 2;

            IEnumerable<Sabor> saboresBuscados = new List<Sabor>();

            saboresBuscados = _saborRepositorio.BuscarTodos();

            saboresBuscados.Should().HaveCountGreaterOrEqualTo(quantidadeSaboresCadastradosPorBaseSQL);

        }

        [Test]
        public void Sabor_InfraDados_BuscarTodosSaboresPizza_Sucesso()
        {
            int quantidadeSaboresCadastradosPorBaseSQL = 3;

            IEnumerable<Sabor> saboresBuscados = new List<Sabor>();

            saboresBuscados = _saborRepositorio.BuscarTodosSaboresPizza();

            saboresBuscados.Should().HaveCount(quantidadeSaboresCadastradosPorBaseSQL);
        }

        [Test]
        public void Sabor_InfraDados_BuscarTodosSaboresCalzone_Sucesso()
        {
            int quantidadeSaboresCadastradosPorBaseSQL = 3;

            IEnumerable<Sabor> saboresBuscados = new List<Sabor>();

            saboresBuscados = _saborRepositorio.BuscarTodosSaboresCalzone();

            saboresBuscados.Should().HaveCount(quantidadeSaboresCadastradosPorBaseSQL);
        }
    }
}
