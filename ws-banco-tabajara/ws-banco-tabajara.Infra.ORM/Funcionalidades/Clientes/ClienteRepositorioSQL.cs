﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Infra.ORM.Contextos;

namespace ws_banco_tabajara.Infra.ORM.Funcionalidades.Clientes
{
    public class ClienteRepositorioSQL : IClienteRepositorio
    {
        private ContextoBancoTabajara _contextoBancoTabajara;

        public ClienteRepositorioSQL(ContextoBancoTabajara contextoBancoTabajara)
        {
            _contextoBancoTabajara = contextoBancoTabajara;
        }
        public Cliente Adicionar(Cliente cliente)
        {
             var clienteAdicionado = _contextoBancoTabajara.Clientes.Add(cliente);

            _contextoBancoTabajara.SaveChanges();

            return clienteAdicionado;
        }

        public Cliente Buscar(long id)
        {
            return _contextoBancoTabajara.Clientes.Where(cliente => cliente.Id == id).FirstOrDefault(); 
                                          
        }

        public IQueryable<Cliente> BuscarListaPorQuantidadeDefinida(int quantidadeDesejada)
        {
            var clientesEncontrados = from TBCLIENTE in _contextoBancoTabajara.Clientes.Take(quantidadeDesejada)
                                      select TBCLIENTE;

            return clientesEncontrados;
        }

        public IQueryable<Cliente> BuscarTodos()
        {
            return _contextoBancoTabajara.Clientes;

        }

        public bool Editar(Cliente cliente)
        {
            return _contextoBancoTabajara.SaveChanges() != 0;
        }

        public bool Excluir(Cliente cliente)
        {
            _contextoBancoTabajara.Clientes.Remove(cliente);

            return _contextoBancoTabajara.SaveChanges() != 0;
        }
    }
}
