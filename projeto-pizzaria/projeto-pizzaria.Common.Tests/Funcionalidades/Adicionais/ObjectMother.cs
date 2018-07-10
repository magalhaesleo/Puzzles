using projeto_pizzaria.Domain.Funcionalidades.Adicionais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Common.Tests
{
    public static partial class ObjectMother
    {
        public static Adicional ObterAdicional_BordaCatupiry()
        {
            return new Adicional()
            {
                Descricao = "Borda de Catupiry",
                ValorPequena = 1.25,
                ValorMedia = 1.75,
                ValorGrande = 2.5
            };
        }

        public static Adicional ObterAdicional_BordaCheddar()
        {
            return new Adicional()
            {
                Descricao = "Borda de Cheddar",
                ValorPequena = 1,
                ValorMedia = 1.5,
                ValorGrande = 2
            };
        }
    }
}