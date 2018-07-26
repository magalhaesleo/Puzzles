using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Common.Tests.Funcionalidades;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

namespace ws_banco_tabajara.Domain.Tests.Funcionalidades.Contas
{
    [TestFixture]
    public class ContaTeste
    {
        [Test]
        public void Conta_Dominio_CalcularSaldoTotal_Sucesso()
        {
            Conta conta = ObjectMother.ObterContaValida();

            int valorSaldoTotalObjectMother = 1500;

            conta.SaldoTotal.Should().Be(valorSaldoTotalObjectMother);
        }
    }
}
