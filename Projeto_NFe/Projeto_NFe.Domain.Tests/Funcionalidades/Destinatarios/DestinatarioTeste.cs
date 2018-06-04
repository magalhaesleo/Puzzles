using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios.Excecoes;
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
        [SetUp]
        public void Inicializa()
        {

        }

        [Test]
        public void DestinatarioComCNPJ_Validar_Sucesso()
        {
            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioValidoComCNPJ();

           Action acaoQueNaoDeveRetornarExcecao = () => destinatarioParaValidar.Validar();

            acaoQueNaoDeveRetornarExcecao.Should().NotThrow<ExcecaoDeNegocio>();
        }

        [Test]
        public void DestinatarioComCPF_Validar_Sucesso()
        {
            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioValidoComCPF();

            Action acaoQueNaoDeveRetornarExcecao = () => destinatarioParaValidar.Validar();

            acaoQueNaoDeveRetornarExcecao.Should().NotThrow<ExcecaoDeNegocio>();
        }

        [Test]
        public void Destinatario_Validar_ExcecaoDestinatarioSemNome_Falha()
        {
            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioSemNome();

            Action acaoQueDeveRetornarExcecaoDestinatarioSemNome = () => destinatarioParaValidar.Validar();

            acaoQueDeveRetornarExcecaoDestinatarioSemNome.Should().Throw<ExcecaoDestinatarioSemNome>();
        }

        [Test]
        public void Destinatario_Validar_ExcecaoDestinatarioSemDocumento_Falha()
        {
            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioSemDocumento();

            Action acaoQueDeveRetornarExcecaoDestinatarioSemDocumento = () => destinatarioParaValidar.Validar();

            acaoQueDeveRetornarExcecaoDestinatarioSemDocumento.Should().Throw<ExcecaoDestinatarioSemDocumento>();
        }

        [Test]
        public void Destinatario_TipeDeDocumento_DeveRetornar_CNPJ_Sucesso()
        {
            Destinatario destinatarioParaObterOTipoDeDocumento = ObjectMother.PegarDestinatarioComCNPJ();

            string tipoDeDocumento = destinatarioParaObterOTipoDeDocumento.TipoDeDocumento;

            tipoDeDocumento.Should().Be("CNPJ");
        }

        [Test]
        public void Destinatario_Validar_ExecaoDestinatarioComInscricaoEstadualAcimaDoLimite_Falha()
        {
            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioComInscricaoEstadualAcimaDoPadrao();

            Action acaoQueDeveRetornarExecaoDestinatarioComInscricaoEstadualAcimaDoLimite = () => destinatarioParaValidar.Validar();

            acaoQueDeveRetornarExecaoDestinatarioComInscricaoEstadualAcimaDoLimite.Should().Throw<ExcecaoDestinatarioComInscricaoEstadualAcimaDoLimite>();
        }

        [Test]
        public void Destinatario_Validar_ExecaoDestinatarioComInscricaoEstadualAbaixoDoLimite_Falha()
        {
            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioComInscricaoEstadualAbaixoDoPadrao();

            Action acaoQueDeveRetornarExecaoDestinatarioComInscricaoEstadualAbaixoDoLimite = () => destinatarioParaValidar.Validar();

            acaoQueDeveRetornarExecaoDestinatarioComInscricaoEstadualAbaixoDoLimite.Should().Throw<ExcecaoDestinatarioComInscricaoEstadualAbaixoDoLimite>();
        }

        [Test]
        public void Destinatario_Validar_ExcecaoDestinatarioComInscricaoEstadualNula_Falha()
        {
            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioComCNPJSemInscricaoEstadual();

            Action acaoQueDeveRetornarExcecaoDestinatarioComInscricaoEstadualNula = () => destinatarioParaValidar.Validar();

            acaoQueDeveRetornarExcecaoDestinatarioComInscricaoEstadualNula.Should().Throw<ExcecaoDestinatarioComInscricaoEstadualNula>();
        }

        [Test]
        public void Destinatario_Validar_ExcecaoDestinatarioSemEndereco_Falha()
        {
            Destinatario destinatarioParaValidar = ObjectMother.PegarDestinatarioSemEndereco();

            Action acaoQueDeveRetornarExcecaoDestinatarioSemEndereco = () => destinatarioParaValidar.Validar();

            acaoQueDeveRetornarExcecaoDestinatarioSemEndereco.Should().Throw<ExcecaoDestinatarioSemEndereco>();
        }


    }
}
