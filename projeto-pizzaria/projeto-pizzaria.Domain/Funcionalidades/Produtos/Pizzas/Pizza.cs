using projeto_pizzaria.Domain.Funcionalidades.Adicionais;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Produtos.Pizzas
{
    public class Pizza : Produto
    {
        public override double Valor
        {
            get
            {
                return ObterValorSemAdicional() + Adicional.Valor;
            }
        }
        public Sabor Sabor1 { get; set; }
        public Sabor Sabor2 { get; set; }
        public Adicional Adicional { get; set; }
        public virtual TamanhoPizza Tamanho { get; set; }

        public override string ObterTipo()
        {
            return "Pizza";
        }

        public double ObterValorSemAdicional()
        {
            double valorSabor1 = Sabor1.ObterValorDoSabor(this);

            if (Sabor2 == null)
                return valorSabor1;

            double valorSabor2 = Sabor2.ObterValorDoSabor(this);

            return valorSabor1 > valorSabor2 ? valorSabor1 : valorSabor2;
        }
    }
}
