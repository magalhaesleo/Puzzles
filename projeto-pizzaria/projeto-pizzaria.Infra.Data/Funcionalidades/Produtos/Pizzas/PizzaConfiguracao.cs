﻿using projeto_pizzaria.Domain.Funcionalidades.Produtos.Pizzas;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Data.Funcionalidades.Produtos.Pizzas
{
    public class PizzaConfiguracao : EntityTypeConfiguration<Pizza>
    {
        public PizzaConfiguracao()
        {
            ToTable("TBProdutoPedido");

            HasKey(p => p.Id);
            Property(p => p.Tamanho)
                .HasColumnName("TamanhoPizza")
                .IsOptional();
            HasRequired(p => p.Sabor1);
            HasRequired(p => p.Sabor2);
            Property(p => p.ObterValorSemAdicional())
                .HasColumnName("ValorSabor")
                .IsOptional();
            HasRequired(p => p.Adicional);
        }
    }
}
