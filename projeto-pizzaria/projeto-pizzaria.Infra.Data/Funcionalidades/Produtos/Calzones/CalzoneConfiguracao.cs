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

            HasKey(c => c.Id);
            HasRequired(c => c.Pedido);
            HasRequired(c => c.Sabor1);
            Property(c => c.Valor)
                .HasColumnName("ValorSabor")
                .IsOptional();
            Property(c => c.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();
            Property(c => c.Valor)
                .HasColumnName("ValorTotal")
                .IsRequired();
        }
    }
}
