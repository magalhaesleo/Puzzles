using FluentAssertions;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests.Base;
using projeto_pizzaria.Domain.Funcionalidades.Adicionais;
using projeto_pizzaria.Infra.Data.Contextos;
using projeto_pizzaria.Infra.Data.Funcionalidades.Adicionais;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.InfraData.Tests.Funcionalidades.Adicionais
{
    [TestFixture]
    public class AdicionalRepositorioSQLTeste
    {
        private AdicionalRepositorioSQL _adicionalRepositorio;
        private PizzariaContexto _pizzariaContexto;

        [SetUp]
        public void IniciarCenario()
        {
            _pizzariaContexto = new PizzariaContexto("PizzariaBD_Puzzles_Teste");
            _adicionalRepositorio = new AdicionalRepositorioSQL(_pizzariaContexto);

            Database.SetInitializer(new BaseSQLTeste());

            _pizzariaContexto.Database.Initialize(true);
        }

        [Test]
        public void Sabor_InfraDados_BuscarTodos_Sucesso()
        {
            int quantidadeAdicionaisCadastradosPorBaseSQL = 2;

            IEnumerable<Adicional> adicionaisBuscados = new List<Adicional>();

            adicionaisBuscados = _adicionalRepositorio.BuscarTodos();

            adicionaisBuscados.Count().Should().Be(quantidadeAdicionaisCadastradosPorBaseSQL);
        }
    }
}
