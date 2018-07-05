using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Interfaces.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Data.Funcionalidades.Clientes
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public int Adicionar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> BuscarClientePorTelefone(string digitosInformados)
        {
            throw new NotImplementedException();
        }

        public void Editar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
