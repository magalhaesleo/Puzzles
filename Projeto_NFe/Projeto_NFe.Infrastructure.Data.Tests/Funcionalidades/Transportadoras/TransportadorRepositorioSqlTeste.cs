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
        }

        [Test]
        public void TransportadorRepositorioSql_Adicionar_Sucesso()
        {
            long idDoEnderecoDaBaseSql = 3;
            _CPF.NumeroComPontuacao = "619.648.783-30";
            Transportador transportador = ObjectMother.PegarTransportadorValidoComCPF(_endereco, _CPF);
            transportador.Endereco.Id = idDoEnderecoDaBaseSql;
            Transportador transportadorAdicionado = transportadorRepositorio.Adicionar(transportador);

            transportadorAdicionado.Should().NotBeNull();
        }
    }
}
