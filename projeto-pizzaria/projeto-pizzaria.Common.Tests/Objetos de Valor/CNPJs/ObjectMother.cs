using projeto_pizzaria.Infra.Objetos_de_Valor.CNPJs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Common.Tests
{
    public static partial class ObjectMother
    {
        public static CNPJ ObterCNPJValido()
        {
            return new CNPJ
            {
                NumeroComPontuacao = "99.327.235/0001-50"
            };
        }
    }
}
