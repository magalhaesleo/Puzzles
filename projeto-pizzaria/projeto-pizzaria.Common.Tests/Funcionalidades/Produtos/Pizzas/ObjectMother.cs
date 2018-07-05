using projeto_pizzaria.Domain.Funcionalidades.Produtos.Pizzas;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Common.Tests.Funcionalidades.Produtos.Pizzas
{
    public static partial class ObjectMother
    {
        public static Pizza ObterPizzaComMaisDeUmSabor(Sabor sabor1, Sabor sabor2)
        {
            Pizza pizza = new Pizza();
            pizza.Sabor1 = sabor1;
            pizza.Sabor2 = sabor2;
            return pizza;
        }

        public static Pizza ObterPizzaComUmSabor(Sabor sabor)
        {
            Pizza pizza = new Pizza();
            pizza.Sabor1 = sabor;
            
            return pizza;
        }
    }
}
