using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Funcionalidades.Nota_Fiscal
{
    [TestFixture]
    public class NotaFiscalTeste
    {
        Mock<Transportador> transportadorMock;
        NotaFiscal _notaFiscal;
        [SetUp]
        public void IniciarCenario()
        {
            _notaFiscal = new NotaFiscal();
            transportadorMock = new Mock<Transportador>();
        }

        [Test]
        public void NotaFiscal_Validar_Sucesso()
        {
            _notaFiscal.Transportador = transportadorMock.Object;
            Action resultado = _notaFiscal.Validar;
            resultado.Should().NotThrow<ExcecaoDeNegocio>();
        }

        [Test]
        public void NotaFiscal_Validar_SemTransportador_Falha()
        {
            Action resultado = _notaFiscal.Validar;
            resultado.Should().Throw<ExcecaoTransportadorInvalido>();
        }
    }
}
