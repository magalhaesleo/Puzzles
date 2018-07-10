using projeto_pizzaria.Domain.Base;
using projeto_pizzaria.Domain.Funcionalidades.Produtos;
using projeto_pizzaria.Domain.Funcionalidades.Produtos.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Adicionais
{
    public class Adicional : Entidade
    {
        public string Descricao { get; set; }

        public virtual double ValorPequena { get; set; }

        public virtual double ValorMedia { get; set; }

        public virtual double ValorGrande { get; set; }

        public virtual double ObterValorAdicional(Pizza pizza)
        {
            switch (pizza.Tamanho)
            {
                case TamanhoPizza.GRANDE:
                    return ValorGrande;
                case TamanhoPizza.MEDIA:
                    return ValorMedia;
                default:
                    return ValorPequena;
            }
        }
    }
}
