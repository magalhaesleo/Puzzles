using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Objetos_de_Valor.CNPJs
{
    public class ExcecaoNumeroCNPJInvalido : Exception
    {
        public ExcecaoNumeroCNPJInvalido() : base("CNPJ Inválido")
        {

        }
    }
}
