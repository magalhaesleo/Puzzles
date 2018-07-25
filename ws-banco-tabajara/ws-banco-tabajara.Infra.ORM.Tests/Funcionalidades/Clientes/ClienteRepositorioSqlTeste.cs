using NUnit.Framework;
using System.Data.Entity;
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

        }
    }
}
