using projeto_pizzaria.Domain.Funcionalidades.Produtos.Calzones;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Data.Funcionalidades.Produtos.Calzones
{
    public class CalzoneConfiguracao : EntityTypeConfiguration<Calzone>
    {
        public CalzoneConfiguracao()
        {
            ToTable("TBProdutoPedido");

            HasKey(p => p.Id);
            HasRequired(p => p.Pedido);
            HasRequired(p => p.Sabor);
            Property(p => p.Valor)
                .HasColumnName("ValorSabor")
                .IsOptional();
            Property(p => p.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();
            Property(p => p.Valor)
                .HasColumnName("ValorTotal")
                .IsRequired();
            Property(p => p.Tipo)
            .HasColumnName("TipoProduto")
            .HasColumnType("varchar")
            .HasMaxLength(50);
        }
    }
}
