using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Common.Tests
{
    public static partial class ObjectMother
    {
        public static Sabor ObterSaborValido()
        {
            Sabor sabor = new Sabor();
            sabor.ValorPequena = 30;
            sabor.ValorMedia = 50;
            sabor.ValorGrande = 70;

            return sabor;
        }
    }
}
