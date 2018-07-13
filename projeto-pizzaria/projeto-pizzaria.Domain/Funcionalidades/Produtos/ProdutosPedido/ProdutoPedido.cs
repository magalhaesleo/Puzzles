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
        public override double Valor
        {
            get
            {
                return Produto.Valor;
            }
        }

        public ProdutoGenerico Produto { get; set; }

        public override string ToString()
        {
            string descricao;
            descricao = Quantidade + "x " + Produto.Descricao;
            descricao += "; Valor: R$" + Valor;
            return descricao;
        }
    }
}
