using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoValorTotalIPIInvalido: ExcecaoDeNegocio
    {
        public ExcecaoValorTotalIPIInvalido(): base("Não é possivel emitir uma nota com valor total IPI menor ou igual a 0.")
        {

        }
    }
}
