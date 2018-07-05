using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Interfaces.Clientes;
using projeto_pizzaria.Infra.Data.Contextos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Data.Funcionalidades.Clientes
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        PizzariaContexto _pizzariaContexto;

        public ClienteRepositorio(PizzariaContexto pizzariaContexto)
        {
            _pizzariaContexto = pizzariaContexto;
        }
        public int Adicionar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> BuscarClientePorTelefone(string digitosInformados)
        {
            throw new NotImplementedException();
        }

;

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
