using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Destinatarios;
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

        //[Test]
        public void DestinatarioRepositorioSql_Adicionar_Sucesso()
        {
            long idDoEnderecoDaBaseSql = 2;

            Destinatario destinatarioValido = ObjectMother.PegarDestinatarioValidoComCPF();

            destinatarioValido.Id = 0;
            destinatarioValido.Endereco.Id = idDoEnderecoDaBaseSql;

            Destinatario destinatarioAdicionado = _repositorio.Adicionar(destinatarioValido);

            destinatarioAdicionado.Id.Should().BeGreaterThan(0);
        }
    }
}
