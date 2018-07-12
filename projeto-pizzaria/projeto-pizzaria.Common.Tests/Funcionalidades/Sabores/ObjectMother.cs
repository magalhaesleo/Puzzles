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
        public static Sabor ObterSaborValido_Calabresa()
        {
            Sabor sabor = new Sabor();
            sabor.Descricao = "Calabresa";
            sabor.ValorPequena = 30;
            sabor.ValorMedia = 40;
            sabor.ValorGrande = 50;
            sabor.ValorCalzone = 45;

            return sabor;
        }
        public static Sabor ObterSaborValidoMaisCaro_Coracao()
        {
            Sabor sabor = new Sabor();
            sabor.Descricao = "Coração";
            sabor.ValorPequena = 40;
            sabor.ValorMedia = 50;
            sabor.ValorGrande = 60;
            sabor.ValorCalzone = 55;

            return sabor;
        }

        public static Sabor ObterSaborSomente_Calzone()
        {
            Sabor sabor = new Sabor();
            sabor.Descricao = "Coração";
            sabor.ValorCalzone = 55;

            return sabor;
        }

        public static Sabor ObterSaborSomente_Pizza()
        {
            Sabor sabor = new Sabor();
            sabor.Descricao = "Coração";
            sabor.ValorPequena = 55;
            sabor.ValorPequena = 65;
            sabor.ValorPequena = 75;

            return sabor;
        }
    }
}
