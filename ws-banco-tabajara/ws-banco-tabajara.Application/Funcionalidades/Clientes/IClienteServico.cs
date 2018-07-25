using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Application.Interfaces;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;

namespace ws_banco_tabajara.Application.Funcionalidades.Clientes
{
    public interface IClienteServico : IServico<Cliente>
    {
    }
}
