using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoSemNaturezaOperacao : ExcecaoDeNegocio
    {
        public ExcecaoSemNaturezaOperacao() : base("Favor preencher a natureza da operação.")
        {
        }
    }
}
