using projeto_pizzaria.Applications.Interfaces;
using projeto_pizzaria.Domain.Funcionalidades.Adicionais;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos.Bebidas;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Applications.Funcionalidades.Pedidos.Interfaces
{
    public interface IPedidoServico : IServico<Pedido>
    {
        IEnumerable<Sabor> ObterSabores();
        IEnumerable<Sabor> ObterSaboresDePizza();
        IEnumerable<Sabor> ObterSaboresDeCalzone();

        IEnumerable<Adicional> ObterAdicionais();

        IEnumerable<ProdutoGenerico> ObterProdutosGenericos();

        IEnumerable<Bebida> ObterTodasBebidas();
    }
}
