﻿using projeto_pizzaria.Domain.Funcionalidades.Adicionais;
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
        public List<Sabor> Sabores { get; set; }
        public Adicional Adicional { get; set; }
        public virtual TamanhoPizza Tamanho { get; set; }


        public override string ObterTipo()
        {
            return "Pizza";
        }
    }
}
