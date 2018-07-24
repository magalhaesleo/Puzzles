using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Application.Funcionalidades.Clientes.Interfaces;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes.Interface;

namespace ws_banco_tabajara.Application.Funcionalidades.Clientes
{
    public class ClienteServico : IClienteServico
    {
        IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        public Cliente Adicionar(Cliente cliente)
        {
            //Obtem a conta do banco
            var novoCliente = _clienteRepositorio.Adicionar(cliente);

            return novoCliente;
        }

        public Cliente Buscar(long id)
        {
            return _clienteRepositorio.Buscar(id);
        }

        public IQueryable<Cliente> BuscarTodos()
        {
            return _clienteRepositorio.BuscarTodos();
        }

        public void Editar(Cliente cliente)
        {
            // Obtém a entidade Indexada pelo EF e valida
            var clienteBuscadoNoBanco = _clienteRepositorio.Buscar(cliente.Id);

            if(cliente.ContaId != clienteBuscadoNoBanco.ContaId)
            
            // Mapeia para o objeto do banco
            clienteBuscadoNoBanco.Nome = cliente.Nome;
            clienteBuscadoNoBanco.RG = cliente.RG;
            clienteBuscadoNoBanco.DataNascimento = cliente.DataNascimento;
            clienteBuscadoNoBanco.CPF = cliente.CPF;
           
            if(cliente.Conta !=null)
            clienteBuscadoNoBanco.Conta = cliente.Conta;

            // Realiza o update no objeto do banco
            _clienteRepositorio.Editar(clienteBuscadoNoBanco);
        }

        public void Excluir(Cliente cliente)
        {
            _clienteRepositorio.Excluir(cliente);
        }
    }
}
