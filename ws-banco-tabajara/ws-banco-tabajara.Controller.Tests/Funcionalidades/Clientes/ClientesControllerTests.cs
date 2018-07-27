using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.API.Controladores.Funcionalidades.Clientes;
using ws_banco_tabajara.Application.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;

namespace ws_banco_tabajara.Controller.Tests.Funcionalidades.Clientes
{
    [TestFixture]
    public class ClientesControllerTests
    {
        private ClientesController _clientesController;
        private Mock<IClienteServico> _clienteServiceMock;
        private Mock<Cliente> _cliente;
    }
}
