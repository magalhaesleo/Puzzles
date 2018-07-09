using projeto_pizzaria.Infra.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Common.Tests
{
    public static partial class ObjectMother
    {
        public static CPF ObterCPFValido()
        {
            return new CPF
            {
                NumeroComPontuacao = "111.444.777-35"
            };
        }
    }
}
