using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Tests.Funcionalidades.Enderecos
{
    [TestFixture]
    public class EnderecoRepositorioSqlTeste
    {

        EnderecoRepositorioSql _repositorio;

        [SetUp]
        public void IniciarCenario()
        {
            _repositorio = new EnderecoRepositorioSql();

            BaseSqlTeste.InicializarBancoDeDados();
        }

        [Test]
        public void EnderecoRepositorioSql_Adicionar_Sucesso()
        {
            Endereco endereco = ObjectMother.PegarEnderecoValido();
            endereco.Id = 0;

            Endereco resultado = _repositorio.Adicionar(endereco);

            resultado.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void EnderecoRepositorioSql_Atualizar_Sucesso()
        {
            Endereco endereco = ObjectMother.PegarEnderecoValido();
            endereco.Pais = "Brasil";
            endereco.Id = 1;

            Endereco resultado = _repositorio.Atualizar(endereco);

            resultado.Pais.Should().Be("Brasil");
            resultado.Pais.Should().NotBe(ObjectMother.PegarEnderecoValido().Pais);
            resultado.Id.Should().Be(endereco.Id);
        }
        
        public void EnderecoRepositorioSql_Excluir_Sucesso()
        {

        }

    }
}
