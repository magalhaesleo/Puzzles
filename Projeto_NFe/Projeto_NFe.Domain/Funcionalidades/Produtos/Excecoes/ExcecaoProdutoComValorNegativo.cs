using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Produtos.Excecoes
{
    public class ExcecaoProdutoComValorNegativo : ExcecaoDeNegocio
    {
        public ExcecaoProdutoComValorNegativo() : base("O valor do produto não deve ser negativo")
        {
        }
    }
}
