using projeto_pizzaria.Domain.Base;
using projeto_pizzaria.Domain.Funcionalidades.Adicionais;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using projeto_pizzaria.Domain.Funcionalidades.Produtos;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.ProdutosPedido
{
    public class ProdutoPedido : Entidade
    {
        public Produto Produto { get; set; }
        public Pedido Pedido { get; set; }
        public List<Sabor> Sabores { get; set; }

        public int Quantidade { get; set; }
        public double ValorTotal { get; set; }

        public void Validar()
        {

        }
    }
}
