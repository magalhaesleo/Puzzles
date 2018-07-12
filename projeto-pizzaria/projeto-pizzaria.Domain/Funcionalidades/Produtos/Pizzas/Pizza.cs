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
                return ObterValorTotal();
            }
        }
        public double ValorSaboresSemAdicional
        {
            get
            {
                return ObterValorSaboresSemAdicional();
            }
            set
            {
                ValorSaboresSemAdicional = value;
            }
        }
        public double ValorAdicional
        {
            get
            {
                return ObterValorAdicional();
            }
            set
            {
                ValorAdicional = value;
            }

        }
        public long? Sabor2Id { get; set; }
        public virtual Sabor Sabor2 { get; set; }
        public long? AdicionalId { get; set; }
        public virtual Adicional Adicional { get; set; }
        public virtual TamanhoPizza Tamanho { get; set; }
       
        public double ObterValorSaboresSemAdicional()
        {
            double valorSabor1 = Sabor1.ObterValorDoSabor(this);

            if (Sabor2 == null)
                return valorSabor1;

            double valorSabor2 = Sabor2.ObterValorDoSabor(this);

            return valorSabor1 > valorSabor2 ? valorSabor1 : valorSabor2;
        }

        public double ObterValorAdicional()
        {
            if (Adicional == null)
                return 0;

            return Adicional.ObterValorAdicional(this);
        }

        public double ObterValorTotal()
        {
            if (Adicional == null)
                return ObterValorSaboresSemAdicional();
            else
                return (ObterValorSaboresSemAdicional() + Adicional.ObterValorAdicional(this));
        }
    }
}
