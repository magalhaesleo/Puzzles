using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ws_banco_tabajara.Common.Tests.Base;
using ws_banco_tabajara.Common.Tests.Funcionalidades;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Infra.ORM.Contextos;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Clientes.RepositorioSqlEF;

namespace ws_banco_tabajara.Infra.ORM.Tests.Funcionalidades.Clientes
{
    [TestFixture]
    public class ClienteRepositorioSqlTeste
    {
        ContextoBancoTabajara _contextoBancoTabajara;
        ClienteRepositorioSqlEF _clienteRepositorioSQL;

        [SetUp]
        public void Inicializar()
        {
            _contextoBancoTabajara = new ContextoBancoTabajara();
            _clienteRepositorioSQL = new ClienteRepositorioSqlEF(_contextoBancoTabajara);

            Database.SetInitializer(new BaseSqlTeste());

            _contextoBancoTabajara.Database.Initialize(true);
        }

        [Test]
        public void Cliente_InfraDadosORM_Adicionar_Sucesso()
        {
            //Cenario
            byte idClienteAposAdicao = 2;

            Cliente clienteParaAdicionar = ObjectMother.ObterClienteValido();

            //Acao
            Cliente clienteAdicionado = _clienteRepositorioSQL.Adicionar(clienteParaAdicionar);

            //Verificacao
            clienteAdicionado.Id.Should().Be(idClienteAposAdicao);
        }

        [Test]
        public void Cliente_InfraDadosORM_Buscar_Sucesso()
        {
            //Cenario
            byte idClienteAdicionadoPeloBaseSql = 1;
            string nomeClienteAdicionadoPeloBaseSql = "Joana";

            //Acao
            Cliente clienteBuscado = _clienteRepositorioSQL.Buscar(idClienteAdicionadoPeloBaseSql);

            //Verificacao
            clienteBuscado.Nome.Should().Be(nomeClienteAdicionadoPeloBaseSql);
        }


        [Test]
        public void Cliente_InfraDadosORM_BuscarTodos_Sucesso()
        {
            //Cenario
            byte quantidadeDeClientesAdicionadosPeloBaseSql = 1;


            IQueryable<Cliente> listaDeClientes = new List<Cliente>().AsQueryable();


            //Acao
            listaDeClientes = _clienteRepositorioSQL.BuscarTodos();

            //Verificacao
            listaDeClientes.Count().Should().Be(quantidadeDeClientesAdicionadosPeloBaseSql);
        }


        [Test]
        public void Cliente_InfraDadosORM_Editar_Sucesso()
        {
            //Cenario
            byte idClienteAdicionadoPeloBaseSql = 1;
            string nomeQueSeraAlterado = "Alterado";

            Cliente clienteBuscadoDoBanco = _clienteRepositorioSQL.Buscar(idClienteAdicionadoPeloBaseSql);

            clienteBuscadoDoBanco.Nome = nomeQueSeraAlterado;

            //Acao

            _clienteRepositorioSQL.Editar(clienteBuscadoDoBanco);
            
            Cliente clienteBuscadoAposEdicao = _clienteRepositorioSQL.Buscar(idClienteAdicionadoPeloBaseSql);

            //Verificacao
            clienteBuscadoAposEdicao.Nome.Should().Be(nomeQueSeraAlterado);
        }

        [Test]
        public void Cliente_InfraDadosORM_Excluir_Sucesso()
        {
            //Cenario
            Cliente clienteParaAdicionar = ObjectMother.ObterClienteValido();

            Cliente clienteAdicionado = _clienteRepositorioSQL.Adicionar(clienteParaAdicionar);

            //Acao

            _clienteRepositorioSQL.Excluir(clienteAdicionado);

            Cliente clienteBuscadoAposExclusao = _clienteRepositorioSQL.Buscar(clienteAdicionado.Id);

            //Verificacao
            clienteBuscadoAposExclusao.Should().BeNull();
        }

        [Test]
        public void Cliente_InfraDadosORM_ExcluirClienteComContaVinculada_Sucesso()
        {
            //Cenario
            long idClienteComContaAdicionadoBaseSQL = 1;
            Cliente clienteComConta = _clienteRepositorioSQL.Buscar(idClienteComContaAdicionadoBaseSQL);

            //Acao

            _clienteRepositorioSQL.Excluir(clienteComConta);

            Cliente clienteBuscadoAposExclusao = _clienteRepositorioSQL.Buscar(idClienteComContaAdicionadoBaseSQL);

            //Verificacao
            clienteBuscadoAposExclusao.Should().BeNull();
        }
    }
}
