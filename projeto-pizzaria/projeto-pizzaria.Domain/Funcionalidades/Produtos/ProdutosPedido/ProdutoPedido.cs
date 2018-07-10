using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Produtos.ProdutosPedido
{
    public class ProdutoPedido : Produto
    {
        public ProdutoGenerico Produto { get; set; }

        public override string Tipo
        {
            get
            {
                return Produto.Tipo;
            }
            set
            {
                Tipo = value;
            }
        }
    }
}
