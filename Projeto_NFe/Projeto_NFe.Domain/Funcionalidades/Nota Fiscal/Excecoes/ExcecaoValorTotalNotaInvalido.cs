using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoValorTotalNotaInvalido : ExcecaoDeNegocio
    {
        public ExcecaoValorTotalNotaInvalido() : base("Não é possivel emitir uma nota fiscal com valor total da nota menor ou igual a 0.")
        {
        }
    }
}
