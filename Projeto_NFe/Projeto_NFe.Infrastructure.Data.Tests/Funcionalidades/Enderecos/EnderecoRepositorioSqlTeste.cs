using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Enderecos;
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
        private IEnderecoRepositorio _repositorio;

        [SetUp]
        public void IniciarCenario()
        {
           _repositorio = new EnderecoRepositorioSql();

            BaseSqlTeste.InicializarBancoDeDados();
        }

        [Test]
        public void Endereco_InfraData_Adicionar_Sucesso()
        {
            Endereco endereco = ObjectMother.PegarEnderecoValido();
            endereco.Id = 0;

            Endereco resultado = _repositorio.Adicionar(endereco);

            resultado.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Endereco_InfraData_Atualizar_Sucesso()
        {
            Endereco endereco = ObjectMother.PegarEnderecoValido();
            endereco.Id = 1;

             _repositorio.Atualizar(endereco);

            Endereco resultado = _repositorio.BuscarPorId(endereco.Id);

            resultado.Pais.Should().Be(endereco.Pais);
        }
        
        [Test]
        public void Endereco_InfraData_Excluir_Sucesso()
        {
            Endereco enderecoParaAdicionar = ObjectMother.PegarEnderecoValido();

            Endereco enderecoAdicionado = _repositorio.Adicionar(enderecoParaAdicionar);

            Endereco enderecoParaDeletar = enderecoAdicionado;

            _repositorio.Excluir(enderecoParaDeletar);

            Endereco enderecoParaBuscar = _repositorio.BuscarPorId(enderecoParaDeletar.Id);

            enderecoParaBuscar.Should().BeNull();
        }

        [Test]
        public void Endereco_InfraData_Buscar_Sucesso()
        {
            Endereco enderecoParaAdicionar = ObjectMother.PegarEnderecoValido();

            Endereco enderecoAdicionado = _repositorio.Adicionar(enderecoParaAdicionar);

            Endereco enderecoParaBuscar = _repositorio.BuscarPorId(enderecoAdicionado.Id);

            enderecoParaBuscar.Should().NotBeNull();
            enderecoParaBuscar.Pais.Should().Be(enderecoAdicionado.Pais);
            enderecoParaBuscar.Numero.Should().Be(enderecoAdicionado.Numero);
            enderecoParaBuscar.Bairro.Should().Be(enderecoAdicionado.Bairro);
            enderecoParaBuscar.Estado.Should().Be(enderecoAdicionado.Estado);
            enderecoParaBuscar.Logradouro.Should().Be(enderecoAdicionado.Logradouro);
        }


        [Test]
        public void Endereco_InfraData_BuscarTodos_Sucesso()
        {
            
            IEnumerable<Endereco> enderecosBuscados = _repositorio.BuscarTodos();

            enderecosBuscados.Should().NotBeNull();
            enderecosBuscados.Should().HaveCountGreaterOrEqualTo(2);
        }

    }
}
