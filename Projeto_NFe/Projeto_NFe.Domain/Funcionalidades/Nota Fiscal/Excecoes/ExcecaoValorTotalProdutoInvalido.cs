using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoValorTotalProdutoInvalido : ExcecaoDeNegocio
    {
        public ExcecaoValorTotalProdutoInvalido():base("Não é possivel emitir uma nota com valor total do Produto menor ou igual a 0.")
        {             
        }
    }
}
