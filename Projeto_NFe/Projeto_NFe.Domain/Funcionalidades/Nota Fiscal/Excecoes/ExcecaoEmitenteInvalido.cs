using Projeto_NFe.Domain.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoEmitenteInvalido : ExcecaoDeNegocio
    {
        public ExcecaoEmitenteInvalido() : base("Não é possivel adicionar uma nota fiscal sem emitente.")
        {
        }
    }
}
