using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
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

            Cliente clienteParaAdicionar = ObjectMother.obterClienteValido();
            clienteParaAdicionar.Nome = "Adicionado agora";

            //Acao
            Cliente clienteAdicionado = _clienteRepositorioSQL.Adicionar(clienteParaAdicionar);

            //Verificacao
            clienteAdicionado.Id.Should().Be(idClienteAposAdicao);
        }
    }
}
