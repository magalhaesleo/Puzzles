using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Funcionalidades.Documentos;
using Projeto_NFe.Common.Tests.Funcionalidades.Transportadoras;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras.Excecoes;
using Projeto_NFe.Infrastructure.Interfaces;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
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
        Mock<Endereco> _mockEndereco;
        Mock<CNPJ> _mockCNPJ;
        Mock<CPF> _mockCPF;
        FakeCNPJ _fakeCNPJ;
        FakeCPF _fakeCPF;

        [SetUp]
        public void IniciarCenario()
        {
            _mockCNPJ = new Mock<CNPJ>();
            _mockCPF = new Mock<CPF>();
            _fakeCNPJ = new FakeCNPJ();
            _fakeCPF = new FakeCPF();
            _mockEndereco = new Mock<Endereco>();
        }

        [Test]
        public void Transportador_Dominio_ComCNPJ_Validar_Sucesso()
        {
            _mockEndereco.Setup(me => me.Validar());
            _mockCNPJ.Setup(mdc => mdc.Validar());

            Transportador transportador = ObjectMother.PegarTransportadorValidoComDependencias(_mockEndereco.Object, _mockCNPJ.Object);

            Action resultadoSemExcecao = () => transportador.Validar();

            resultadoSemExcecao.Should().NotThrow<ExcecaoDeNegocio>();
            _mockCNPJ.Verify(mdc => mdc.Validar());
            _mockEndereco.Verify(me => me.Validar());
        }

        [Test]
        public void Transportador_Dominio_ComCPF_Validar_Sucesso()
        {
            Transportador transportador = ObjectMother.PegarTransportadorValidoComDependencias(_mockEndereco.Object, _mockCPF.Object);

            Action resultadoSemExcecao = () => transportador.Validar();

            resultadoSemExcecao.Should().NotThrow<ExcecaoDeNegocio>();
            _mockCPF.Verify(mdc => mdc.Validar());
            _mockEndereco.Verify(me => me.Validar());
        }

        [Test]
        public void Transportador_Dominio_Validar_ExcecaoTransportadorComInscricaoEstadualAcimaDoLimite_Falha()
        {
            Transportador transportador = ObjectMother.PegarTransportadorComInscricaoEstadualAcimaDoLimite(_mockEndereco.Object, _fakeCNPJ);

            Action resultadoComExcecao = () => transportador.Validar();

            resultadoComExcecao.Should().Throw<ExcecaoTransportadorComInscricaoEstadualAcimaDoLimite>();

            _mockEndereco.VerifyNoOtherCalls();
            _mockCNPJ.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Dominio_Validar_ExcecaoTransportadorSemNome_Falha()
        {
            Transportador transportador = ObjectMother.PegarTransportadorSemNome(_mockEndereco.Object, _mockCNPJ.Object);

            Action resultadoComExcecao = () => transportador.Validar();

            resultadoComExcecao.Should().Throw<ExcecaoTransportadorSemNome>();
        }

        [Test]
        public void Transportador_Dominio_Validar_ExcecaoTransportadorSemEndereco_Falha()
        {
            object enderecoNulo = null;

            Transportador transportador = ObjectMother.PegarTransportadorSemEndereco((Endereco)enderecoNulo, _fakeCNPJ);

            Action resultadoComExcecao = () => transportador.Validar();

            resultadoComExcecao.Should().Throw<ExcecaoTransportadorSemEndereco>();

            _mockCNPJ.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Dominio_Validar_ExcecaoTransportadorComInscricaoEstadualNula_Falha()
        {
            Transportador transportador = ObjectMother.PegarTransportadorComInscricaoEstadualNula(_mockEndereco.Object, _fakeCNPJ);

            Action resultadoComExcecao = () => transportador.Validar();

            resultadoComExcecao.Should().Throw<ExcecaoTransportadorComInscricaoEstadualNula>();

            _mockEndereco.VerifyNoOtherCalls();
            _mockCNPJ.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Dominio_Validar_ExcecaoTransportadorSemDocumento_Falha()
        {
            _mockEndereco.Setup(en => en.Validar());

            object documentoNulo = null;

            Transportador transportador = ObjectMother.PegarTransportadorSemDocumento(_mockEndereco.Object, (IDocumento)documentoNulo);

            Action resultadoComExcecao = () => transportador.Validar();

            resultadoComExcecao.Should().Throw<ExcecaoTransportadorSemDocumento>();
        }

        [Test]
        public void Transportador_Dominio_TipoDeDocumento_DeveRetornar_CNPJ_Sucesso()
        {
            Transportador transportador = ObjectMother.PegarTransportadorValidoComCNPJ(_mockEndereco.Object, _fakeCNPJ);

            transportador.Documento.ObterTipo().Should().Be("CNPJ");
        }

        [Test]
        public void Transportador_Dominio_TipoDeDocumento_DeveRetornar_CPF_Sucesso()
        {
            Transportador transportador = ObjectMother.PegarTransportadorValidoComCPF(_mockEndereco.Object, _fakeCPF);

            transportador.Documento.ObterTipo().Should().Be("CPF");
        }

        [Test]
        public void Transportador_Dominio_Validar_DeveChamarValidacaoDeDocumento_Sucesso()
        {
            Transportador transportador = ObjectMother.PegarTransportadorValidoComCNPJ(_mockEndereco.Object, _mockCNPJ.Object);

            _mockEndereco.Setup(en => en.Validar());
            _mockCNPJ.Setup(mdc => mdc.Validar());

            Action acaoDeValidao = () => transportador.Validar();

            acaoDeValidao.Should().NotThrow<ExcecaoDeNegocio>();

            _mockEndereco.Verify(me => me.Validar());
            _mockCNPJ.Verify(mdc => mdc.Validar());
        }
    }
}
