using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Interfaces.Pedidos;
using projeto_pizzaria.Infra.Data.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Data.Funcionalidades.Pedidos
{
    public class PedidoRepositorioSQL : IPedidoRepositorio
    {
        private PizzariaContexto _pizzariaContexto;
        public PedidoRepositorioSQL(PizzariaContexto pizzariaContexto)
        {
            _pizzariaContexto = pizzariaContexto;
        }
        public long Adicionar(Pedido pedido)
        {
            _pizzariaContexto.Pedidos.Add(pedido);
            _pizzariaContexto.SaveChanges();

            return pedido.Id;
        }

        public void AtualizarStatus(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void Editar(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> BuscarTodos()
        {
            _pizzariaContexto.Pedidos.Include("TBSabor");
            _pizzariaContexto.Pedidos.Include("TBProdutoGenerico");
            _pizzariaContexto.Pedidos.Include("TBProdutoPedido");
            _pizzariaContexto.Pedidos.Include("TBCliente");
            _pizzariaContexto.Pedidos.Include("TBEndereco");
            _pizzariaContexto.Pedidos.Include("TBAdicional");

            var PedidosEncontrados = from TBPEDIDO in _pizzariaContexto.Pedidos
                                     select TBPEDIDO;

            return PedidosEncontrados;
        }
    }
}
