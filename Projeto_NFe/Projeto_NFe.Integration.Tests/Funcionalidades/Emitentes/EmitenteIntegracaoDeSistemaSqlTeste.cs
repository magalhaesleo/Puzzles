using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Emitentes;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Emitentes;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integration.Tests.Funcionalidades.Emitentes
{
    [TestFixture]
    public class EmitenteIntegracaoDeSistemaSqlTeste
    {
        IEmitenteRepositorio _repositorio;
        IEnderecoRepositorio _enderecoRepositorio;
        IEmitenteServico _emitenteServico;
        Endereco endereco;

        [SetUp]
        public void IniciarCenario()
        {
            _repositorio = new EmitenteRepositorioSql();
            _enderecoRepositorio = new EnderecoRepositorioSql();
            _emitenteServico = new EmitenteServico(_repositorio, _enderecoRepositorio);
            BaseSqlTeste.InicializarBancoDeDados();

            endereco = new Endereco();

            endereco.Id = 1;
            endereco.Bairro = "Bela Vista";
            endereco.Estado = "SC";
            endereco.Logradouro = "Rua";
            endereco.Numero = 76;
            endereco.Municipio = "Lages";
            endereco.Pais = "BR";
        }

        [Test]
        public void EmitenteIntegracaoDeSistemaSqlTeste_Adicionar_Sucesso()
        {         
            CNPJ cnpj = new CNPJ();
            cnpj.NumeroComPontuacao = "99.327.235/0001-50";
            Emitente emitente = ObjectMother.PegarEmitenteValido(endereco, cnpj);

            emitente = _emitenteServico.Adicionar(emitente);

            Emitente buscarEmitente = _emitenteServico.BuscarPorId(emitente.Id);

            buscarEmitente.Should().NotBeNull();
            buscarEmitente.Id.Should().BeGreaterThan(0);
            buscarEmitente.NomeFantasia.Should().Be(emitente.NomeFantasia);
            buscarEmitente.RazaoSocial.Should().Be(emitente.RazaoSocial);
            buscarEmitente.InscricaoEstadual.Should().Be(emitente.InscricaoEstadual);
            buscarEmitente.InscricaoMunicipal.Should().Be(emitente.InscricaoMunicipal);
            buscarEmitente.CNPJ.NumeroComPontuacao.Should().Be(emitente.CNPJ.NumeroComPontuacao);
            buscarEmitente.Endereco.Id.Should().Be(emitente.Endereco.Id);
        }

        [Test]
        public void EmitenteIntegracaoDeSistemaSqlTeste_Atualizar_Sucesso()
        {
            CNPJ cnpj = new CNPJ();
            cnpj.NumeroComPontuacao = "99.327.235/0001-50";
            Emitente emitente = ObjectMother.PegarEmitenteValido(endereco, cnpj);
            emitente.Id = 1;
            
            _emitenteServico.Atualizar(emitente);

            Emitente emitenteAtualizado = _emitenteServico.BuscarPorId(emitente.Id);

            emitenteAtualizado.Should().NotBeNull();
            emitenteAtualizado.Id.Should().BeGreaterThan(0);
            emitenteAtualizado.NomeFantasia.Should().Be(emitente.NomeFantasia);
            emitenteAtualizado.RazaoSocial.Should().Be(emitente.RazaoSocial);
            emitenteAtualizado.InscricaoEstadual.Should().Be(emitente.InscricaoEstadual);
            emitenteAtualizado.InscricaoMunicipal.Should().Be(emitente.InscricaoMunicipal);
            emitenteAtualizado.CNPJ.NumeroComPontuacao.Should().Be(emitente.CNPJ.NumeroComPontuacao);
            emitenteAtualizado.Endereco.Id.Should().Be(emitente.Endereco.Id);
        }

        [Test]
        public void EmitenteIntegracaoDeSistemaSqlTeste_Atualizar_ExcecaoIdentificadorIndefinido_Falha()
        {
            CNPJ cnpj = new CNPJ();
            cnpj.NumeroComPontuacao = "99.327.235/0001-50";
            Emitente emitente = ObjectMother.PegarEmitenteValido(endereco, cnpj);
            emitente.Id = 0;

            Action acaoResultado = () => _emitenteServico.Atualizar(emitente);

            acaoResultado.Should().Throw<ExcecaoIdentificadorIndefinido>();
        }

        [Test]
        public void EmitenteIntegracaoDeSistemaSqlTeste_BuscarPorId_Sucesso()
        {
            CNPJ cnpj = new CNPJ();
            cnpj.NumeroComPontuacao = "99.327.235/0001-50";
            Emitente emitente = ObjectMother.PegarEmitenteValido(endereco, cnpj);

            Emitente emitenteAdicionado = _emitenteServico.Adicionar(emitente);
            Emitente emitenteBuscado = _emitenteServico.BuscarPorId(emitenteAdicionado.Id);

            emitenteBuscado.Should().NotBeNull();
            emitenteBuscado.Id.Should().Be(emitente.Id);
            emitenteBuscado.NomeFantasia.Should().Be(emitente.NomeFantasia);
            emitenteBuscado.RazaoSocial.Should().Be(emitente.RazaoSocial);
            emitenteBuscado.InscricaoEstadual.Should().Be(emitente.InscricaoEstadual);
            emitenteBuscado.InscricaoMunicipal.Should().Be(emitente.InscricaoMunicipal);
            emitenteBuscado.CNPJ.NumeroComPontuacao.Should().Be(emitente.CNPJ.NumeroComPontuacao);
            emitenteBuscado.Endereco.Id.Should().Be(emitente.Endereco.Id);
        }

        [Test]
        public void EmitenteIntegracaoDeSistemaSqlTeste_BuscarPorId_ExcecaoIdentificadorIndefinido_Falha()
        {
            CNPJ cnpj = new CNPJ();
            cnpj.NumeroComPontuacao = "99.327.235/0001-50";
            Emitente emitente = ObjectMother.PegarEmitenteValido(endereco, cnpj);
            emitente.Id = 0;

            Action acaoResultado = () => _emitenteServico.BuscarPorId(emitente.Id);

            acaoResultado.Should().Throw<ExcecaoIdentificadorIndefinido>();
        }

        [Test]
        public void EmitenteIntegracaoDeSistemaSqlTeste_Excluir_Sucesso()
        {
            CNPJ cnpj = new CNPJ();
            cnpj.NumeroComPontuacao = "99.327.235/0001-50";
            Emitente emitente = ObjectMother.PegarEmitenteValido(endereco, cnpj);

            Emitente emitenteAdicionado = _emitenteServico.Adicionar(emitente);
            _emitenteServico.Excluir(emitenteAdicionado);

            Emitente buscarEmitenteAposExclusao = _repositorio.BuscarPorId(emitente.Id);

            buscarEmitenteAposExclusao.Should().BeNull();            
        }

        [Test]
        public void EmitenteIntegracaoDeSistemaSqlTeste_Excluir_ExcecaoIdentificadorIndefinido_Falha()
        {
            CNPJ cnpj = new CNPJ();
            cnpj.NumeroComPontuacao = "99.327.235/0001-50";
            Emitente emitente = ObjectMother.PegarEmitenteValido(endereco, cnpj);
            emitente.Id = 0;

            Action acaoResultado = () => _emitenteServico.Excluir(emitente);

            acaoResultado.Should().Throw<ExcecaoIdentificadorIndefinido>();
        }

        [Test]
        public void EmitenteIntegracaoDeSistemSqlTeste_BuscarTodos_Sucesso()
        {
            CNPJ cnpj = new CNPJ();
            cnpj.NumeroComPontuacao = "99.327.235/0001-50";
            Emitente emitente = ObjectMother.PegarEmitenteValido(endereco, cnpj);

            emitente = _emitenteServico.Adicionar(emitente);

            IEnumerable<Emitente> listaEmitentes = _emitenteServico.BuscarTodos();

            listaEmitentes.Should().HaveCount(2);
        }
    }
}
