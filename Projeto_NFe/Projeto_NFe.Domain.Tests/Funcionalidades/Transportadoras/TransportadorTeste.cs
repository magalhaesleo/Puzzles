using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Funcionalidades.Transportadoras;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras.Excecoes;
using Projeto_NFe.Infrastructure.Interfaces;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Funcionalidades.Transportadoras
{
    [TestFixture]
    public class TransportadorTeste
    {
        Mock<IDocumento> _mockDocumentoCNPJ;
        Mock<Endereco> _mockEndereco;
        Mock<CNPJ> _mockCNPJ;

        [SetUp]
        public void IniciarCenario()
        {
            _mockDocumentoCNPJ = new Mock<IDocumento>();
            _mockEndereco = new Mock<Endereco>();
        }

        [Test]
        public void TransportadorComCNPJ_Validar_Sucesso()
        {
            
            Transportador transportador = ObjectMother.PegarTransportadorValidoComCNPJ(_mockEndereco.Object, _mockCNPJ.Object);

            Action resultadoSemExcecao = () => transportador.Validar();

            resultadoSemExcecao.Should().NotThrow<ExcecaoDeNegocio>();
        }

        //[Test]
        //public void TransportadorComCPF_Validar_Sucesso()
        //{
        //    Transportador transportador = ObjectMother.PegarTransportadorValidoComCPF(_mockEndereco.Object, _mockDocumentoCNPJ.Object);

        //    Action resultadoSemExcecao = () => transportador.Validar();

        //    resultadoSemExcecao.Should().NotThrow<ExcecaoDeNegocio>();
        //}

        [Test]
        public void Transportador_Validar_ExcecaoTransportadorComInscricaoEstadualAcimaDoLimite_Falha()
        {
            Transportador transportador = ObjectMother.PegarTransportadorComInscricaoEstadualAcimaDoLimite(_mockEndereco.Object, _mockCNPJ.Object);

            Action resultadoComExcecao = () => transportador.Validar();

            resultadoComExcecao.Should().Throw<ExcecaoTransportadorComInscricaoEstadualAcimaDoLimite>();
        }

        [Test]
        public void Transportador_Validar_ExcecaoTransportadorComInscricaoEstadualAbaixoDoLimite_Falha()
        {
            Transportador transportador = ObjectMother.PegarTransportadorComInscricaoEstadualAbaixoDoLimite(_mockEndereco.Object, _mockCNPJ.Object);

            Action resultadoComExcecao = () => transportador.Validar();

            resultadoComExcecao.Should().Throw<ExcecaoTransportadorComInscricaoEstadualAbaixoDoLimite>();
        }

        [Test]
        public void Transportador_Validar_ExcecaoTransportadorSemNome_Falha()
        {
            _mockEndereco.Setup(en => en.Id).Returns(1);
            Transportador transportador = ObjectMother.PegarTransportadorSemNome(_mockEndereco.Object, _mockCNPJ.Object);

            Action resultadoComExcecao = () => transportador.Validar();

            resultadoComExcecao.Should().Throw<ExcecaoTransportadorSemNome>();
        }

        [Test]
        public void Transportador_Validar_ExcecaoTransportadorSemEndereco_Falha()
        {
            Transportador transportador = ObjectMother.PegarTransportadorSemEndereco(_mockCNPJ.Object);

            Action resultadoComExcecao = () => transportador.Validar();

            resultadoComExcecao.Should().Throw<ExcecaoTransportadorSemEndereco>();
        }

        [Test]
        public void Transportador_Validar_ExcecaoTransportadorComInscricaoEstadualNula_Falha()
        {
            _mockEndereco.Setup(en => en.Id).Returns(1);
            Transportador transportador = ObjectMother.PegarTransportadorComInscricaoEstadualNula(_mockEndereco.Object, _mockCNPJ.Object);

            Action resultadoComExcecao = () => transportador.Validar();

            resultadoComExcecao.Should().Throw<ExcecaoTransportadorComInscricaoEstadualNula>();
        }

        [Test]
        public void Transportador_Validar_ExcecaoTransportadorSemDocumento_Falha()
        {
            _mockEndereco.Setup(en => en.Id).Returns(1);
            Transportador transportador = ObjectMother.PegarTransportadorSemDocumento(_mockEndereco.Object);

            Action resultadoComExcecao = () => transportador.Validar();

            resultadoComExcecao.Should().Throw<ExcecaoTransportadorSemDocumento>();
        }
    }
}
