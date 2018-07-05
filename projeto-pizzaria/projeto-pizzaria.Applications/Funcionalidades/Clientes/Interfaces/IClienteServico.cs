using projeto_pizzaria.Applications.Interfaces;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Applications.Funcionalidades.Clientes.Interfaces
{
    public interface IClienteServico : IServico<Cliente>
    {
       IEnumerable<Cliente> BuscarClientePorTelefone(string digitosInformados);
    }
}
