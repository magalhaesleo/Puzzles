using FluentAssertions;
using NUnit.Framework;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Bebidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Tests.Funcionalidades.Produtos.Bebidas
{
    [TestFixture]
    public class BebidaTeste
    {
        [Test]
        public static void Bebida_Dominio_Tipo_Sucesso()
        {
            Bebida bebida = new Bebida();
            bebida.Tipo.Should().Be("Bebida");
        }
    }
}
