using projeto_pizzaria.Applications.Funcionalidades.Pedidos.Interfaces;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Interfaces.Pedidos;
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
        public PedidoServico(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
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

        public List<Pedido> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
