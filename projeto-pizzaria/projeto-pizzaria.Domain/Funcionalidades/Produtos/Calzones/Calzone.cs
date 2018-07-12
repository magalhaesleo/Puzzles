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
            string descricao;
            if (Quantidade == 1)
                descricao = "Calzone de " + Sabor1.Descricao;
            else
                descricao = Quantidade + " Calzones de " + Sabor1.Descricao;
            descricao += "; Valor: R$" + Valor;
            return descricao;
        }
    }
}
