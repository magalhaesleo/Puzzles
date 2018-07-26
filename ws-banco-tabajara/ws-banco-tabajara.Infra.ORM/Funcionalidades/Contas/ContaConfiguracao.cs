using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

namespace ws_banco_tabajara.Infra.ORM.Funcionalidades.Contas
{
    public class ContaConfiguracao : EntityTypeConfiguration<Conta>
    {
        public ContaConfiguracao()
        {
            ToTable("TBCONTA");

            HasKey(conta => conta.Id);

            Property(conta => conta.Numero).HasColumnName("Numero").IsRequired();

            Property(conta => conta.Saldo).HasColumnName("Saldo").IsRequired();

            Property(conta => conta.Ativa).HasColumnName("Ativa").IsRequired();

            Property(conta => conta.Limite).HasColumnName("Limite").IsRequired();

            Property(conta => conta.SaldoTotal).HasColumnName("SaldoTotal").IsRequired();
            
            HasRequired(conta => conta.Titular).WithMany().WillCascadeOnDelete(true);

            HasMany(conta => conta.Movimentacoes).WithRequired(movimentacao => movimentacao.Conta).WillCascadeOnDelete(true);
        }
    }
}
