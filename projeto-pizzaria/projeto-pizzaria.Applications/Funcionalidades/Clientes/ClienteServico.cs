using projeto_pizzaria.Applications.Funcionalidades.Clientes.Interfaces;
using projeto_pizzaria.Applications.Interfaces;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Interfaces.Clientes;
using System;
using System.Collections.Generic;

namespace projeto_pizzaria.Applications.Funcionalidades.Clientes
{
    public class ClienteServico : IClienteServico
    {
        IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        public long Adicionar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> BuscarClientePorTelefone(string digitosInformados)
        {
            return _clienteRepositorio.BuscarClientePorTelefone(digitosInformados);
        }

        public void Editar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> BuscarTodos()
        {
            return _clienteRepositorio.BuscarTodos();
        }

       
    }
}
