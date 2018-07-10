using FluentAssertions;
using Moq;
using NUnit.Framework;
using projeto_pizzaria.Common.Tests;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Calzones;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Tests.Funcionalidades.Produtos.Calzones
{
    [TestFixture]
    public class CalzoneTeste
    {
        private Calzone _calzone;
        private Mock<Sabor> _saborMock;

        [SetUp]
        public void IniciarCenario()
        {
            _calzone = new Calzone();
            _saborMock = new Mock<Sabor>();
        }

        [Test]
        public static void Bebida_Dominio_Tipo_Sucesso()
        {
            Calzone calzone = new Calzone();
            calzone.Tipo.Should().Be("Calzone");
        }

        [Test]
        public void Calzone_Dominio_Valor_Sucesso()
        {
            double valorSaborParaCalzone = 50;

            _saborMock.Setup(sm => sm.ValorCalzone).Returns(valorSaborParaCalzone);
                
            _calzone = ObjectMother.ObterCalzoneComSabor(_saborMock.Object);
            _calzone.Valor.Should().Be(valorSaborParaCalzone);
        }
    }
}
