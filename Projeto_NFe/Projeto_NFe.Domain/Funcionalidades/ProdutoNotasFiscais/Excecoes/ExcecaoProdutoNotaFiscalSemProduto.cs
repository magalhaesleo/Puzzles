using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais.Excecoes
{
    public class ExcecaoProdutoNotaFiscalSemProduto : ExcecaoDeNegocio
    {
        public ExcecaoProdutoNotaFiscalSemProduto() : base("Para criar um produto nota fical é necessário vincular um produto")
        {
        }
    }
}
