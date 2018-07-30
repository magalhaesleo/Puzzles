using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Interfaces;

namespace ws_banco_tabajara.Domain.Funcionalidades.Clientes
{
    
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        IQueryable<Cliente> BuscarListaPorQuantidadeDefinida(int quantidadeDesejada);

      
    }
}
