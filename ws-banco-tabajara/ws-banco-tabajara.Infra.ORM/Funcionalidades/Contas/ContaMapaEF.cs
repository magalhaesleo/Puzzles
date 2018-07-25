using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

namespace ws_banco_tabajara.Infra.ORM.Funcionalidades.Contas
{
    public class ContaMapaEF: EntityTypeConfiguration<Conta>
    {
        public ContaMapaEF()
        {
            ToTable("TBCONTA");

            HasKey(conta => conta.Id);

            Property(conta => conta.Numero).HasColumnName("NUMERO").IsRequired();

            Property(conta => conta.Saldo).HasColumnName("SALDO").IsRequired();

            Property(conta => conta.Ativa).HasColumnName("ATIVA").IsRequired();

            Property(conta => conta.Limite).HasColumnName("LIMITE").IsRequired();

            Property(conta => conta.SaldoTotal).HasColumnName("SALDOTOTAL").IsRequired();

            HasRequired(conta => conta.Titular);

            HasRequired(conta => conta.Movimentacoes);
        }
    }
}
