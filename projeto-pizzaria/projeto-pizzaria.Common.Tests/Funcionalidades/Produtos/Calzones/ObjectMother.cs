using projeto_pizzaria.Domain.Funcionalidades.Produtos.Calzones;
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
        public static Calzone ObterCalzoneComSabor(Sabor sabor)
        {
            Calzone calzone = new Calzone();
            calzone.Sabor = sabor;

            return calzone;
        }
    }
}
