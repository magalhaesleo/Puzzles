using projeto_pizzaria.Applications.Funcionalidades.Pedidos.Interfaces;
using projeto_pizzaria.Domain.Funcionalidades.Adicionais;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos.Bebidas;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using projeto_pizzaria.Domain.Interfaces.Adicionais;
using projeto_pizzaria.Domain.Interfaces.Pedidos;
using projeto_pizzaria.Domain.Interfaces.ProdutosGenericos;
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
        private IProdutoGenericoRepositorio _produtoGenericoRepositorio;

        public PedidoServico(IPedidoRepositorio pedidoRepositorio, ISaborRepositorio saborRepositorio, IAdicionalRepositorio adicionalRepositorio, IProdutoGenericoRepositorio produtoGenericoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _saborRepositorio = saborRepositorio;
            _adicionalRepositorio = adicionalRepositorio;
            _produtoGenericoRepositorio = produtoGenericoRepositorio;
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

        public IEnumerable<Pedido> BuscarTodos()
        {
           
            return _pedidoRepositorio.BuscarTodos();
        }

        public IEnumerable<Adicional> ObterAdicionais()
        {
            return _adicionalRepositorio.BuscarTodos();
        }

        public IEnumerable<Sabor> ObterSabores()
        {
            return _saborRepositorio.BuscarTodos();
        }

        public IEnumerable<Sabor> ObterSaboresDePizza()
        {
            return _saborRepositorio.BuscarTodosSaboresPizza();
        }

        public IEnumerable<Sabor> ObterSaboresDeCalzone()
        {
            return _saborRepositorio.BuscarTodosSaboresCalzone();
        }

        public IEnumerable<ProdutoGenerico> ObterProdutosGenericos()
        {
            return _produtoGenericoRepositorio.BuscarTodos();
        }

        public IEnumerable<Bebida> ObterTodasBebidas()
        {
            return _produtoGenericoRepositorio.BuscarTodos<Bebida>().Cast<Bebida>();
        }
    }
}
