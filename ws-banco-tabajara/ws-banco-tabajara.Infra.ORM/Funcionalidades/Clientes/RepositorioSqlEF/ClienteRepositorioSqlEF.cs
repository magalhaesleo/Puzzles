using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes.Interface;
using ws_banco_tabajara.Infra.ORM.Contextos;

namespace ws_banco_tabajara.Infra.ORM.Funcionalidades.Clientes.RepositorioSqlEF
{
    public class ClienteRepositorioSqlEF : IClienteRepositorio
    {
        private ContextoBancoTabajara _contextoBancoTabajara;

        public ClienteRepositorioSqlEF(ContextoBancoTabajara contextoBancoTabajara)
        {
            _contextoBancoTabajara = contextoBancoTabajara;
        }
        public Cliente Adicionar(Cliente cliente)
        {
            return _contextoBancoTabajara.Clientes.Add(cliente);
        }

        public Cliente Buscar(long id)
        {
            return _contextoBancoTabajara.Clientes.Find(id);
        }

        public IQueryable<Cliente> BuscarTodos()
        {
            var clientesEncontrados = from TBCLIENTE in _contextoBancoTabajara.Clientes
                                    select TBCLIENTE;

            return clientesEncontrados;

        }

        public void Editar(Cliente cliente)
        {
            _contextoBancoTabajara.SaveChanges();
        }

        public void Excluir(Cliente cliente)
        {
            _contextoBancoTabajara.Clientes.Remove(cliente);

            _contextoBancoTabajara.SaveChanges();
        }
    }
}
