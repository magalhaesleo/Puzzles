using NUnit.Framework;
using ws_banco_tabajara.Infra.ORM.Contextos;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Contas;

namespace ws_banco_tabajara.Infra.ORM.Tests.Funcionalidades.Contas
{
    [TestFixture]
    public class ContaRepositorioSQLTeste
    {
        private ContaRepositorioSQL _contaRepositorio;
        private ContextoBancoTabajara _contextoBancoTabajara;

        [SetUp]
        public void IniciarCenario()
        {
            _contextoBancoTabajara = new ContextoBancoTabajara("BancoTabajara_Teste");
            _contaRepositorio = new ContaRepositorioSQL(_contextoBancoTabajara);
        }

        [Test]
        public void Conta_InfraData_Adicionar_Sucesso()
        {

        }

        [Test]
        public void Conta_InfraData_Editar_Sucesso()
        {

        }

        [Test]
        public void Conta_InfraData_Excluir_Sucesso()
        {

        }

        [Test]
        public void Conta_InfraData_Buscar_Sucesso()
        {

        }

        [Test]
        public void Conta_InfraData_BuscarTodos_Sucesso()
        {

        }
    }
}
