using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Infrastructure.Objetos_de_Valor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Tests.Objetos_de_Valor
{
    [TestFixture]
    public class CNPJTeste
    {
        [Test]
        public void CNPJ_Validar_Sucesso()
        {
            CNPJ cnpj = new CNPJ();
            cnpj.Numero = "56956041000100";

            Action resultado = () => cnpj.Validar();

            resultado.Should().NotThrow<Exception>();
        }
    }
}
