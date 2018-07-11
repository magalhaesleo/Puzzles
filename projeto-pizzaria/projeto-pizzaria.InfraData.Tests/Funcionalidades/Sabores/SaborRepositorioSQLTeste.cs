﻿using FluentAssertions;
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
        }

        [Test]
        public void Sabor_InfraDados_BuscarTodos_Sucesso()
        {
            int quantidadeSaboresCadastradosPorBaseSQL = 2;

            IEnumerable<Sabor> saboresBuscados = new List<Sabor>();

            saboresBuscados = _saborRepositorio.BuscarTodos();

            saboresBuscados.Count().Should().Be(quantidadeSaboresCadastradosPorBaseSQL);

        }
    }
}