using projeto_pizzaria.Applications.Funcionalidades.Pedidos.Interfaces;
using projeto_pizzaria.Domain.Funcionalidades.Adicionais;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using projeto_pizzaria.Domain.Interfaces.Adicionais;
using projeto_pizzaria.Domain.Interfaces.Pedidos;
using projeto_pizzaria.Domain.Interfaces.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Applications.Funcionalidades.Pedidos
{
    public class PedidoServico : IPedidoServico
    {
        private IPedidoRepositorio _pedidoRepositorio;
        private ISaborRepositorio _saborRepositorio;
        private IAdicionalRepositorio _adicionalRepositorio;

        public PedidoServico(IPedidoRepositorio pedidoRepositorio, ISaborRepositorio saborRepositorio, IAdicionalRepositorio adicionalRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _saborRepositorio = saborRepositorio;
            _adicionalRepositorio = adicionalRepositorio;
        }
        public long Adicionar(Pedido pedido)
        {
            return _pedidoRepositorio.Adicionar(pedido);
        }

        public void Editar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Adicional> ObterAdicionais()
        {
            return _adicionalRepositorio.BuscarTodos();
        }

        public IEnumerable<Sabor> ObterSabores()
        {
            return _saborRepositorio.BuscarTodos();
        }
    }
}
