using projeto_pizzaria.Domain.Funcionalidades.Produtos.Pizzas;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
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
            HasRequired(p => p.Pedido);
            Property(p => p.Tamanho)
                .HasColumnName("TamanhoPizza")
                .IsOptional();
            HasRequired(p => p.Sabor1);
            HasRequired(p => p.Sabor2)
                .WithMany()
                .WillCascadeOnDelete(false);
            Property(p => p.ValorSaboresSemAdicional)
                .HasColumnName("ValorSabor")
                .IsOptional();
            HasOptional(p => p.Adicional)
                .WithMany()
                .WillCascadeOnDelete(false);
            Property(p => p.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();
            Property(p => p.Valor)
                .HasColumnName("ValorTotal")
                .IsRequired();
            Property(p => p.ValorAdicional)
                .HasColumnName("ValorAdicional")
                .IsOptional();
        }
    }
}
