using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Interfaces.Clientes
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        IEnumerable<Cliente> BuscarClientePorTelefone(string digitosInformados);
    }
}
