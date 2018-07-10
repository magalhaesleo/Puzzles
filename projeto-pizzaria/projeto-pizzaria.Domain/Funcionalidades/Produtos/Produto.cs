﻿using projeto_pizzaria.Domain.Base;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Produtos
{
    public abstract class Produto : Entidade
    {
        public Pedido Pedido { get; set; }
        public virtual double Valor { get; set; }
        public int Quantidade { get; set; }
        public abstract string Tipo { get; set; }
    }
}
