using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Data.Funcionalidades.Sabores
{
    class SaborConfiguracao : EntityTypeConfiguration<Sabor>
    {
        public SaborConfiguracao()
        {
            ToTable("TBSabor");
            Property(s => s.ValorPequena)
                .IsOptional();
            Property(s => s.ValorMedia)
                .IsOptional();
            Property(s => s.ValorGrande)
                .IsOptional();
            Property(s => s.ValorCalzone)
                .IsOptional();
        }
    }
}
