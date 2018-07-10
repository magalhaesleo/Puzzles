using projeto_pizzaria.Domain.Funcionalidades.Pedidos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Data.Funcionalidades.Pedidos
{
    public class PedidoConfiguracao : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguracao()
        {
            ToTable("TBPedido");

            HasKey(p => p.Id);
            HasRequired(p => p.Cliente);
            Property(p => p.Data)
                    .HasColumnName("Data")
                    .IsRequired();
            Property(p => p.Status)
                .HasColumnName("Status")
                .IsRequired();
            Property(p => p.ValorTotal)
                    .HasColumnName("ValorTotal")
                    .IsRequired();
            Property(p => p.FormaPagamento)
                    .HasColumnName("FormaPagamento")
                    .IsRequired();
            Property(p => p.Responsavel)
                    .HasColumnName("Responsavel")
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsOptional();
            Property(p => p.Departamento)
                    .HasColumnName("Departamento")
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsOptional();
        }
    }
}
