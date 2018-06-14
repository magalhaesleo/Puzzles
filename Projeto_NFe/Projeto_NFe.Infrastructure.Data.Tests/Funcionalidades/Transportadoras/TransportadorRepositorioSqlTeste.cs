using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades.Transportadoras;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Tests.Funcionalidades.Transportadoras
{
    [TestFixture]
    public class TransportadorRepositorioSqlTeste
    {
        private ITransportadorRepositorio transportadorRepositorio;
        private CPF _CPF;
        private CNPJ _CNPJ;
        private Endereco _endereco;

        [SetUp]
        public void IniciarCenario()
        {
            transportadorRepositorio = new TransportadorRepositorioSql();
            BaseSqlTeste.InicializarBancoDeDados();
            _endereco = new Endereco();
            _CPF = new CPF();
            _CNPJ = new CNPJ();
        }

        [Test]
        public void Transportador_InfraData_Adicionar_Sucesso()
        {
            long idDoEnderecoDaBaseSql = 3;
            _CPF.NumeroComPontuacao = "619.648.783-30";
            Transportador transportador = ObjectMother.PegarTransportadorValidoComCPF(_endereco, _CPF);
            transportador.Endereco.Id = idDoEnderecoDaBaseSql;
            Transportador transportadorAdicionado = transportadorRepositorio.Adicionar(transportador);

            transportadorAdicionado.Should().NotBeNull();

            Transportador transportadorBuscado = transportadorRepositorio.BuscarPorId(transportadorAdicionado.Id);

            transportadorBuscado.NomeRazaoSocial.Should().Be(transportadorAdicionado.NomeRazaoSocial);
            transportadorBuscado.Endereco.Id.Should().Be(transportadorAdicionado.Endereco.Id);
        }

        [Test]
        public void Transportador_InfraData_Atualizar_Sucesso()
        {
            _CNPJ.NumeroComPontuacao = "37.311.068/0001-00";
            long idDoEnderecoDaBaseSql = 3;
            Transportador transportador = ObjectMother.PegarTransportadorValidoComCNPJ(_endereco, _CNPJ);
            transportador.Id = 1;
            transportador.Endereco.Id = idDoEnderecoDaBaseSql;

            transportadorRepositorio.Atualizar(transportador);

            Transportador buscarTransportador = transportadorRepositorio.BuscarPorId(transportador.Id);

            buscarTransportador.NomeRazaoSocial.Should().Be(transportador.NomeRazaoSocial);
            buscarTransportador.InscricaoEstadual.Should().Be(transportador.InscricaoEstadual);
            buscarTransportador.ResponsabilidadeFrete.Should().Be(transportador.ResponsabilidadeFrete);
            buscarTransportador.Endereco.Id.Should().Be(transportador.Endereco.Id);
            buscarTransportador.Documento.NumeroComPontuacao.Should().Be(transportador.Documento.NumeroComPontuacao);
        }

        [Test]
        public void Transportador_InfraData_BuscarTodos_Sucesso()
        {
            long idDoEnderecoDaBaseSql = 3;
            _CPF.NumeroComPontuacao = "619.648.783-30";
            Transportador transportador = ObjectMother.PegarTransportadorValidoComCPF(_endereco, _CPF);
            transportador.Endereco.Id = idDoEnderecoDaBaseSql;
            Transportador transportadorAdicionado = transportadorRepositorio.Adicionar(transportador);

            IEnumerable<Transportador> transportadores = transportadorRepositorio.BuscarTodos();
            transportadores.Should().HaveCountGreaterOrEqualTo(2);
        }

        [Test]
        public void Transportador_InfraData_BuscarPorId_Sucesso()
        {
            long idDoEnderecoDaBaseSql = 3;
            _CPF.NumeroComPontuacao = "619.648.783-30";
            Transportador transportador = ObjectMother.PegarTransportadorValidoComCPF(_endereco, _CPF);

            transportador.Endereco = Common.Tests.Funcionalidades.Enderecos.ObjectMother.PegarEnderecoValido();
            transportador.Endereco.Id = idDoEnderecoDaBaseSql;
            
            transportador = transportadorRepositorio.Adicionar(transportador);

            Transportador transportadorBuscado = transportadorRepositorio.BuscarPorId(transportador.Id);

            transportadorBuscado.NomeRazaoSocial.Should().Be(transportador.NomeRazaoSocial);
            transportadorBuscado.InscricaoEstadual.Should().Be(transportador.InscricaoEstadual);
            transportadorBuscado.Documento.NumeroComPontuacao.Should().Be(transportador.Documento.NumeroComPontuacao);
            transportadorBuscado.ResponsabilidadeFrete.Should().Be(transportador.ResponsabilidadeFrete);
            transportadorBuscado.Endereco.Id.Should().Be(transportador.Endereco.Id);
            transportadorBuscado.Endereco.Estado.Should().Be(transportador.Endereco.Estado);
        }

        [Test]
        public void Transportador_InfraData_Excluir_Sucesso()
        {
            _CNPJ.NumeroComPontuacao = "37.311.068/0001-00";
            long idDoEnderecoDaBaseSql = 3;
            Transportador transportador = ObjectMother.PegarTransportadorValidoComCNPJ(_endereco, _CNPJ);
            transportador.Id = 1;
            transportador.Endereco.Id = idDoEnderecoDaBaseSql;

            transportadorRepositorio.Excluir(transportador);

            Transportador buscarTransportador = transportadorRepositorio.BuscarPorId(transportador.Id);

            buscarTransportador.Should().BeNull();
        }
    }
}
