using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Excecoes;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

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
            return _clienteRepositorio.Buscar(id) ?? throw new RegistroNaoEncontradoExcecao();
        }

        public IQueryable<Cliente> BuscarListaPorQuantidadeDefinida(int quantidadeDesejada)
        {
            return _clienteRepositorio.BuscarListaPorQuantidadeDefinida(quantidadeDesejada);
        }

        public IQueryable<Cliente> BuscarTodos()
        {
            return _clienteRepositorio.BuscarTodos();
        }

        public bool Editar(Cliente clienteReferencia)
        {
            // Obtém a entidade Indexada pelo EF e valida
            Cliente clienteBuscadoNoBanco = _clienteRepositorio.Buscar(clienteReferencia.Id);

            // Mapeia para o objeto do banco
            clienteBuscadoNoBanco.Nome = clienteReferencia.Nome;
            clienteBuscadoNoBanco.RG = clienteReferencia.RG;
            clienteBuscadoNoBanco.DataNascimento = clienteReferencia.DataNascimento;
            clienteBuscadoNoBanco.CPF = clienteReferencia.CPF;
           
            // Realiza o update no objeto do banco
            return _clienteRepositorio.Editar(clienteBuscadoNoBanco);
        }

        public bool Excluir(long idCliente)
        {
            Cliente clienteBuscadoParaExclusao = _clienteRepositorio.Buscar(idCliente) ?? throw new RegistroNaoEncontradoExcecao();
           return _clienteRepositorio.Excluir(clienteBuscadoParaExclusao);
        }
    }
}
