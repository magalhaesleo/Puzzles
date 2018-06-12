using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Destinatarios;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Tests.Funcionalidades.Destinatarios
{
    [TestFixture]
    public class DestinatarioRepositorioSqlTeste
    {

        private IDestinatarioRepositorio _repositorio;
        private Mock<Endereco> _mockEndereco;


        [SetUp]
        public void IniciarCenario()
        {
            _repositorio = new DestinatarioRepositorioSql();

            _mockEndereco = new Mock<Endereco>();

            BaseSqlTeste.InicializarBancoDeDados();
        }

        [Test]
        public void Destinatario_InfraData_Adicionar_ComCPF_Sucesso()
        {
            long idDoEnderecoDaBaseSql = 2;

            Destinatario destinatarioValido = ObjectMother.PegarDestinatarioValidoComCPF();

            destinatarioValido.Id = 0;
            destinatarioValido.Endereco.Id = idDoEnderecoDaBaseSql;

            Destinatario destinatarioAdicionado = _repositorio.Adicionar(destinatarioValido);

            destinatarioAdicionado.Id.Should().BeGreaterThan(0);

            Destinatario destinatarioResultadoDoGet = _repositorio.BuscarPorId(destinatarioAdicionado.Id);

            destinatarioResultadoDoGet.NomeRazaoSocial.Should().Be(destinatarioAdicionado.NomeRazaoSocial);
            destinatarioResultadoDoGet.Endereco.Pais.Should().Be(destinatarioAdicionado.Endereco.Pais);
        }

        [Test]
        public void Destinatario_InfraData_Adicionar_ComCNPJ_Sucesso()
        {
            long idDoEnderecoDaBaseSql = 2;

            Destinatario destinatarioValido = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();

            destinatarioValido.Id = 0;
            destinatarioValido.Endereco.Id = idDoEnderecoDaBaseSql;

            Destinatario destinatarioAdicionado = _repositorio.Adicionar(destinatarioValido);

            destinatarioAdicionado.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Destinatario_InfraData_BuscarPorId_Sucesso()
        {
            long idDoEnderecoDaBaseSql = 2;

            Destinatario destinatarioValido = ObjectMother.PegarDestinatarioValidoComCPF();

            destinatarioValido.Endereco.Id = idDoEnderecoDaBaseSql;

            Destinatario destinatarioAdicionado = _repositorio.Adicionar(destinatarioValido);

            Destinatario destinatarioResultadoDoBuscar = _repositorio.BuscarPorId(destinatarioAdicionado.Id);

            destinatarioResultadoDoBuscar.NomeRazaoSocial.Should().Be(destinatarioAdicionado.NomeRazaoSocial);
            destinatarioResultadoDoBuscar.Endereco.Pais.Should().Be(destinatarioAdicionado.Endereco.Pais);
        }

        [Test]
        public void Destinatario_InfraData_BuscarPorId_DestinatarioDaBaseSql_Sucesso()
        {
            long idDoDestinatarioDaBaseSql = 1;

            Destinatario destinatarioDaBaseSql = _repositorio.BuscarPorId(idDoDestinatarioDaBaseSql);

            destinatarioDaBaseSql.Should().NotBeNull();
            destinatarioDaBaseSql.Documento.ObterTipo().Should().Be("CNPJ");
        }

        [Test]
        public void Destinatario_InfraData_BuscarTodos_Sucesso()
        {
            long idDoEnderecoDaBaseSql = 2;

            Destinatario destinatarioValido = ObjectMother.PegarDestinatarioValidoComCPF();

            destinatarioValido.Endereco.Id = idDoEnderecoDaBaseSql;

            //Adicionando varios destinatarios vinculados ao mesmo endereco (Só para teste)
            Destinatario destinatarioAdicionado1 = _repositorio.Adicionar(destinatarioValido);
            Destinatario destinatarioAdicionado2 = _repositorio.Adicionar(destinatarioValido);
            Destinatario destinatarioAdicionado3 = _repositorio.Adicionar(destinatarioValido);
            Destinatario destinatarioAdicionado4 = _repositorio.Adicionar(destinatarioValido);

            IEnumerable<Destinatario> destinatariosResultadoDoBuscarTodos = _repositorio.BuscarTodos();

            destinatariosResultadoDoBuscarTodos.Count().Should().Be(5);
            
        }

        [Test]
        public void Destinatario_InfraData_Atualizar_Sucesso()
        {
            long idDoDestinatarioDaBaseSql = 1;

            Destinatario destinatarioResultadoDoBuscarParaAtualizar = _repositorio.BuscarPorId(idDoDestinatarioDaBaseSql);

            destinatarioResultadoDoBuscarParaAtualizar.Documento = new CPF()
            {
                NumeroComPontuacao = "085.544.678-00"
            };

            destinatarioResultadoDoBuscarParaAtualizar.NomeRazaoSocial = "Alterado";
            destinatarioResultadoDoBuscarParaAtualizar.InscricaoEstadual = null;
           

            _repositorio.Atualizar(destinatarioResultadoDoBuscarParaAtualizar);

            Destinatario destinatarioResultadoAposAtualizacao = _repositorio.BuscarPorId(destinatarioResultadoDoBuscarParaAtualizar.Id);

            destinatarioResultadoAposAtualizacao.InscricaoEstadual.Should().Be(destinatarioResultadoDoBuscarParaAtualizar.InscricaoEstadual);
            destinatarioResultadoAposAtualizacao.NomeRazaoSocial.Should().Be(destinatarioResultadoDoBuscarParaAtualizar.NomeRazaoSocial);
            destinatarioResultadoAposAtualizacao.Documento.ObterTipo().Should().Be(destinatarioResultadoDoBuscarParaAtualizar.Documento.ObterTipo());
        }

        [Test]
        public void Destinatario_InfraData_Excluir_Sucesso()
        {
            long idDoDestinatarioDaBaseSql = 1;

            Destinatario destinatarioResultadoDoBuscar  = _repositorio.BuscarPorId(idDoDestinatarioDaBaseSql);

            _repositorio.Excluir(destinatarioResultadoDoBuscar);

            Destinatario destinatarioQueDeveSerNullo = _repositorio.BuscarPorId(destinatarioResultadoDoBuscar.Id);

            destinatarioQueDeveSerNullo.Should().BeNull();
        }

    }
}
