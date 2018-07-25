using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes.Interface;

namespace ws_banco_tabajara.Application.Funcionalidades.Clientes
{
    public class ClienteServico : IClienteServico
    {
        IClienteRepositorio _clienteRepositorio;
        public ClienteServico()
        {

        }
        public Cliente Adicionar(Cliente entidade)
        {
            throw new NotImplementedException();
        }

        public Cliente Buscar(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Cliente> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Editar(Cliente entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Cliente entidade)
        {
            throw new NotImplementedException();
        }
    }
}
