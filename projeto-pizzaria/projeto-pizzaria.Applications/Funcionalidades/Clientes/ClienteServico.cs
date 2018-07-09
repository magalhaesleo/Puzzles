using projeto_pizzaria.Applications.Funcionalidades.Clientes.Interfaces;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Interfaces.Clientes;
using projeto_pizzaria.Infra.Data.Funcionalidades.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Applications.Funcionalidades.Clientes
{
    public class ClienteServico : IClienteServico
    {
        IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        public int Adicionar(Cliente cliente)
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

        public List<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
