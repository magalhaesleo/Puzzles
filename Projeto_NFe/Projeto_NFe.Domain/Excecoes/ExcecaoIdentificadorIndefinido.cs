using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Excecoes
{
    public class ExcecaoIdentificadorIndefinido : Exception
    {
        public ExcecaoIdentificadorIndefinido() : base("O Id não pode ser vazio.")
        {
        }
    }
}
