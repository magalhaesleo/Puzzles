using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoProdutoSemValor : ExcecaoDeNegocio
    {
        public ExcecaoProdutoSemValor() : base("Não é possivel emitir nota com produto de valor menor ou igual a 0")
        {
        }
    }
}
