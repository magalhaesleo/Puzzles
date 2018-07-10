using projeto_pizzaria.Domain.Funcionalidades.Adicionais;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Data.Funcionalidades.Adicionais
{
    public class AdicionalConfiguracao : EntityTypeConfiguration<Adicional>
    {
        public AdicionalConfiguracao()
        {
            ToTable("TBAdicional");
            HasKey(a => a.Id);
            Property(a => a.Descricao)
                .HasColumnName("Descricao")
                .IsRequired();
            Property(a => a.ValorGrande)
                .HasColumnName("ValorGrande")
                .IsRequired();
            Property(a => a.ValorMedia)
                .HasColumnName("ValorMedia")
                .IsRequired();
            Property(a => a.ValorPequena)
                .HasColumnName("ValorPequena")
                .IsRequired();
        }
    }
}
