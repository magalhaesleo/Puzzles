using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Tests.Objetos_de_Valor
{
    [TestFixture]
    public class CPFTeste
    {

        [Test]
        public void CPF_Validar_Sucesso()
        {
            CPF cpf = new CPF();
            cpf.NumeroComPontuacao = "111.444.777-35";

            Action resultado = () => cpf.Validar();

            resultado.Should().NotThrow<Exception>();
            cpf.Numero.Should().Be("11144477735");
            cpf.NumeroComPontuacao.Should().Be("111.444.777-35");
        }

        [Test]
        public void CPF_Validar_NumeroZerado_ExcecaoNumeroCPFInvalido_Falha()
        {
            CPF cpf = new CPF();
            cpf.NumeroComPontuacao = "000.000.000-00";

            Action resultado = () => cpf.Validar();

            resultado.Should().Throw<ExcecaoNumeroCPFInvalido>();
        }

        [Test]
        public void CNPJ_Validar_NumeroPequeno_ExcecaoCPFNaoPossuiOnzeNumeros_Falha()
        {
            CPF cpf = new CPF();
            cpf.NumeroComPontuacao = "000.000-00";
            Action resultado = () => cpf.Validar();

            resultado.Should().Throw<ExcecaoCPFNaoPossuiOnzeNumeros>();
        }

        [Test]
        public void CNPJ_Validar_NumeroGrande_ExcecaoCPFNaoPossuiOnzeNumeros_Falha()
        {
            CPF cpf = new CPF();
            cpf.NumeroComPontuacao = "000.000.000.000-00";
            Action resultado = () => cpf.Validar();

            resultado.Should().Throw<ExcecaoCPFNaoPossuiOnzeNumeros>();
        }

    }
}
