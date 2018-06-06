using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Destinatarios;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Destinatarios;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integration.Tests.Funcionalidades.Destinatarios
{
    [TestFixture]
    public class DestinatarioIntegracaoDeSistemaSqlTeste
    {

        IDestinatarioServico _servicoDestinatario;
        IDestinatarioRepositorio _destinatarioRepositorio;
        IEnderecoRepositorio _enderecoRepositorio;

        [SetUp]
        public void IniciarCenario()
        {
            _enderecoRepositorio = new EnderecoRepositorioSql();
            _destinatarioRepositorio = new DestinatarioRepositorioSql();
            _servicoDestinatario = new DestinatarioServico(_enderecoRepositorio, _destinatarioRepositorio);

            BaseSqlTeste.InicializarBancoDeDados();
        }

        [Test]
        public void DestinatarioIntegracaoDeSistemaSqlTeste_Adicionar_Sucesso()
        {
            Destinatario destinatarioParaAdicionar = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();

            Destinatario destinatarioAdicionado = _servicoDestinatario.Adicionar(destinatarioParaAdicionar);

            Destinatario destinatarioBuscado = _servicoDestinatario.BuscarPorId(destinatarioParaAdicionar.Id);

            destinatarioBuscado.InscricaoEstadual.Should().Be(destinatarioAdicionado.InscricaoEstadual);
            destinatarioBuscado.NomeRazaoSocial.Should().Be(destinatarioAdicionado.NomeRazaoSocial);
            destinatarioBuscado.Endereco.Pais.Should().Be(destinatarioAdicionado.Endereco.Pais);
            destinatarioBuscado.Documento.NumeroComPontuacao.Should().Be(destinatarioAdicionado.Documento.NumeroComPontuacao);
        }

        [Test]
        public void DestinatarioIntegracaoDeSistemaSqlTeste_Excluir_Sucesso()
        {
            Destinatario destinatarioParaAdicionar = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();

            Destinatario destinatarioAdicionado = _servicoDestinatario.Adicionar(destinatarioParaAdicionar);

            _servicoDestinatario.Excluir(destinatarioAdicionado);

            Destinatario destinatarioBuscado = _servicoDestinatario.BuscarPorId(destinatarioAdicionado.Id);

            destinatarioBuscado.Should().BeNull();
        }

        [Test]
        public void DestinatarioIntegracaoDeSistemaSqlTeste_Excluir_ExcecaoIdentificadorIndefinido_Falha()
        {
            Destinatario destinatarioParaAdicionar = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();

            destinatarioParaAdicionar.Id = 0;

            Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoDestinatario.Excluir(destinatarioParaAdicionar);

            acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoIdentificadorIndefinido>();
        }

        [Test]
        public void DestinatarioIntegracaoDeSistemaSqlTeste_BuscarTodos_Sucesso()
        {
            int numeroDeRegistrosDeDestinatariosInseridos = 1;

            Destinatario destinatarioParaAdicionar = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();


            for (int i = 0; i < 5; i++)
            {
                var destinatario = _servicoDestinatario.Adicionar(destinatarioParaAdicionar);
                numeroDeRegistrosDeDestinatariosInseridos++;
            }

            IEnumerable<Destinatario> listaDeDestinatarios = _servicoDestinatario.BuscarTodos();

            listaDeDestinatarios.Count().Should().Be(numeroDeRegistrosDeDestinatariosInseridos);

        }


        [Test]
        public void DestinatarioIntegracaoDeSistemaSqlTeste_BuscarPorId_Sucesso()
        {
            Destinatario destinatarioParaAdicionar = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();

            Destinatario destinatarioAdicionado = _servicoDestinatario.Adicionar(destinatarioParaAdicionar);

            Destinatario destinatarioBuscado = _servicoDestinatario.BuscarPorId(destinatarioAdicionado.Id);

            destinatarioBuscado.InscricaoEstadual.Should().Be(destinatarioAdicionado.InscricaoEstadual);
            destinatarioBuscado.NomeRazaoSocial.Should().Be(destinatarioAdicionado.NomeRazaoSocial);
            destinatarioBuscado.Endereco.Pais.Should().Be(destinatarioAdicionado.Endereco.Pais);
            destinatarioBuscado.Documento.NumeroComPontuacao.Should().Be(destinatarioAdicionado.Documento.NumeroComPontuacao);
        }


        [Test]
        public void DestinatarioIntegracaoDeSistemaSqlTeste_BuscarPorId_ExcecaoIdentificadorIndefinido_Falha()
        {
            long idInvalido = 0;

            Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoDestinatario.BuscarPorId(idInvalido);

            acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoIdentificadorIndefinido>();
        }

        [Test]
        public void DestinatarioIntegracaoDeSistemaSqlTeste_Atualizar_Sucesso()
        {
            Destinatario destinatarioParaAdicionar = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();

            Destinatario destinatarioAdicionadoParaAtualizar = _servicoDestinatario.Adicionar(destinatarioParaAdicionar);

            destinatarioAdicionadoParaAtualizar.InscricaoEstadual = null;
            destinatarioAdicionadoParaAtualizar.Documento = new CPF
            {
                NumeroComPontuacao = "115.372.669-69"
            };

            Destinatario destinatarioAtualizado = _servicoDestinatario.Atualizar(destinatarioAdicionadoParaAtualizar);

            destinatarioAtualizado.Should().NotBeNull();
            destinatarioAtualizado.Id.Should().Be(destinatarioParaAdicionar.Id);
            destinatarioAtualizado.InscricaoEstadual.Should().BeNull();
            destinatarioAtualizado.Documento.ObterTipo().Should().Be("CPF");

        }

        [Test]
        public void DestinatarioIntegracaoDeSistemaSqlTeste_Atualizar_ExcecaoIdentificadorIndefinido_Falha()
        {
            long idInvalido = 0;

            Destinatario destinatarioParaAdicionar = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();

            Destinatario destinatarioAdicionadoParaAtualizar = _servicoDestinatario.Adicionar(destinatarioParaAdicionar);
            destinatarioAdicionadoParaAtualizar.Id = idInvalido;

            Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoDestinatario.Atualizar(destinatarioAdicionadoParaAtualizar);

            acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoIdentificadorIndefinido>();

        }
    }
}
