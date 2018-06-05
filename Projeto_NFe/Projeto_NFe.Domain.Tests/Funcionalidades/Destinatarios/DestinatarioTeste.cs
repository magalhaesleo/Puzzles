using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Funcionalidades.Destinatarios;
using Projeto_NFe.Common.Tests.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Interfaces;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Funcionalidades.Destinatarios
{
    [TestFixture]
    public class DestinatarioTeste
    {
        Mock<CNPJ> _mockDocumentoCNPJ;
        Mock<CPF> _mockDocumentoCPF;
        Mock<Endereco> _mockEndereco;
        FakeCNPJ _fakeCNPJ;
        Mock<IDocumento> _mockDocumento;
        FakeCPF _fakeCPF;

        [SetUp]
        public void Inicializa()
        {
            _mockDocumentoCPF = new Mock<CPF>();
            _mockDocumentoCNPJ = new Mock<CNPJ>();
            _mockEndereco = new Mock<Endereco>();
            _fakeCNPJ = new FakeCNPJ();
            _fakeCPF = new FakeCPF();
            _mockDocumento = new Mock<IDocumento>();
        }

        [Test]
        public void DestinatarioComCNPJ_Validar_Sucesso()
        {
            _mockEndereco.Setup(me => me.Validar());
            _mockDocumentoCNPJ.Setup(mdc => mdc.Validar());

            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioValidoComDependencias(_mockEndereco.Object, _mockDocumentoCNPJ.Object);

            Action acaoQueNaoDeveRetornarExcecao = () => destinatarioParaValidar.Validar();

            acaoQueNaoDeveRetornarExcecao.Should().NotThrow<ExcecaoDeNegocio>();
            _mockDocumentoCNPJ.Verify(mdc => mdc.Validar());
            _mockEndereco.Verify(me => me.Validar());
        }

        [Test]
        public void DestinatarioComCPF_Validar_Sucesso()
        {
            _mockEndereco.Setup(me => me.Validar());
            _mockDocumentoCPF.Setup(mdc => mdc.Validar());

            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioValidoComDependencias(_mockEndereco.Object, _mockDocumentoCPF.Object);

            Action acaoQueNaoDeveRetornarExcecao = () => destinatarioParaValidar.Validar();

            acaoQueNaoDeveRetornarExcecao.Should().NotThrow<ExcecaoDeNegocio>();
            _mockDocumentoCPF.Verify(mdc => mdc.Validar());
            _mockEndereco.Verify(me => me.Validar());
        }

        [Test]
        public void Destinatario_Validar_ExcecaoDestinatarioSemNome_Falha()
        {
      
            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioSemNome(_mockEndereco.Object, _mockDocumentoCPF.Object);

            Action acaoQueDeveRetornarExcecaoDestinatarioSemNome = () => destinatarioParaValidar.Validar();

            acaoQueDeveRetornarExcecaoDestinatarioSemNome.Should().Throw<ExcecaoDestinatarioSemNome>();
        }

        [Test]
        public void Destinatario_Validar_ExcecaoDestinatarioSemDocumento_Falha()
        {
            _mockEndereco.Setup(me => me.Validar());

            object documentoNulo = null;

            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioSemDocumento(_mockEndereco.Object, (IDocumento)documentoNulo);

            Action acaoQueDeveRetornarExcecaoDestinatarioSemDocumento = () => destinatarioParaValidar.Validar();

            acaoQueDeveRetornarExcecaoDestinatarioSemDocumento.Should().Throw<ExcecaoDestinatarioSemDocumento>();

        }

        [Test]
        public void Destinatario_TipeDeDocumento_DeveRetornar_CNPJ_Sucesso()
        {
            
            Destinatario destinatarioParaValidarTipoDeDocumento = ObjectMother.PegarDestinatarioComCNPJ(_mockEndereco.Object, _fakeCNPJ);

            destinatarioParaValidarTipoDeDocumento.TipoDeDocumento.Should().Be("CNPJ");

        }

        [Test]
        public void Destinatario_TipeDeDocumento_DeveRetornar_CPF_Sucesso()
        {

            Destinatario destinatarioParaValidarTipoDeDocumento = ObjectMother.PegarDestinatarioComCNPJ(_mockEndereco.Object, _fakeCPF);

            destinatarioParaValidarTipoDeDocumento.TipoDeDocumento.Should().Be("CPF");

        }

        [Test]
        public void Destinatario_Validar_ExecaoDestinatarioComInscricaoEstadualAcimaDoLimite_Falha()
        {
            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioComInscricaoEstadualAcimaDoPadrao(_mockEndereco.Object, _fakeCNPJ);

            Action acaoQueDeveRetornarExecaoDestinatarioComInscricaoEstadualAcimaDoLimite = () => destinatarioParaValidar.Validar();

            acaoQueDeveRetornarExecaoDestinatarioComInscricaoEstadualAcimaDoLimite.Should().Throw<ExcecaoDestinatarioComInscricaoEstadualAcimaDoLimite>();

            _mockEndereco.VerifyNoOtherCalls();
            _mockDocumentoCNPJ.VerifyNoOtherCalls();
        }


        [Test]
        public void Destinatario_Validar_ExcecaoDestinatarioComInscricaoEstadualNula_Falha()
        {
            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioComCNPJSemInscricaoEstadual(_mockEndereco.Object,_fakeCNPJ);

            Action acaoQueDeveRetornarExcecaoDestinatarioComInscricaoEstadualNula = () => destinatarioParaValidar.Validar();

            acaoQueDeveRetornarExcecaoDestinatarioComInscricaoEstadualNula.Should().Throw<ExcecaoDestinatarioComInscricaoEstadualNula>();


            _mockEndereco.VerifyNoOtherCalls();
            _mockDocumentoCNPJ.VerifyNoOtherCalls();
        }

        [Test]
        public void Destinatario_Validar_ExcecaoDestinatarioSemEndereco_Falha()
        {
            object enderecoNulo = null;

            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioSemEndereco((Endereco)enderecoNulo, _fakeCNPJ);

            Action acaoQueDeveRetornarExcecaoDestinatarioSemEndereco = () => destinatarioParaValidar.Validar();

            acaoQueDeveRetornarExcecaoDestinatarioSemEndereco.Should().Throw<ExcecaoDestinatarioSemEndereco>();

            _mockDocumentoCNPJ.VerifyNoOtherCalls();
        }

        [Test]
        public void Destinatario_Validar_DeveChamarValidacaoDeDocumento_Sucesso()
        {
            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioValidoComCNPJ(_mockEndereco.Object, _mockDocumentoCNPJ.Object);
         
            _mockEndereco.Setup(me => me.Validar());
            _mockDocumentoCNPJ.Setup(mdc => mdc.Validar());

            Action acaoDeValidacao = () => destinatarioParaValidar.Validar();

            acaoDeValidacao.Should().NotThrow<ExcecaoDeNegocio>();

            _mockEndereco.Verify(me => me.Validar());
            _mockDocumentoCNPJ.Verify(mdc => mdc.Validar());
        }

    }
}
