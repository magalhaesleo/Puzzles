using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Produtos.Calzones
{
    public class Calzone : Produto
    {
        public override double Valor
        {
            get
            {
                return Sabor1.ValorCalzone;
            }
        }

        public override string ToString()
        {
            if(Quantidade == 1)
                return "Calzone de " + Sabor1.Descricao;

            return Quantidade + " Calzones de " + Sabor1.Descricao;
        }
    }
}
