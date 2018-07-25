using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Application.Funcionalidades.Clientes.Interfaces;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes.Interface;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

namespace ws_banco_tabajara.Application.Funcionalidades.Clientes
{
    public class ClienteServico : IClienteServico
    {
        IClienteRepositorio _clienteRepositorio;
        IContaRepositorio _contaRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio, IContaRepositorio contaRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _contaRepositorio = contaRepositorio;
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

        public void Editar(Cliente clienteReferencia)
        {
            // Obtém a entidade Indexada pelo EF e valida
            Cliente clienteBuscadoNoBanco = _clienteRepositorio.Buscar(clienteReferencia.Id);

            // Mapeia para o objeto do banco
            clienteBuscadoNoBanco.Nome = clienteReferencia.Nome;
            clienteBuscadoNoBanco.RG = clienteReferencia.RG;
            clienteBuscadoNoBanco.DataNascimento = clienteReferencia.DataNascimento;
            clienteBuscadoNoBanco.CPF = clienteReferencia.CPF;
           
            // Realiza o update no objeto do banco
            _clienteRepositorio.Editar(clienteBuscadoNoBanco);
        }

        public void Excluir(Cliente cliente)
        {
            _clienteRepositorio.Excluir(cliente);
        }
    }
}
