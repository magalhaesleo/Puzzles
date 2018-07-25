using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Infra.ORM.Funcionalidades.Movimentacoes
{
    public class MovimentacaoConfiguracao : EntityTypeConfiguration<Movimentacao>
    {
        public MovimentacaoConfiguracao()
        {
            ToTable("TBMOVIMENTACAO");

            HasKey(m => m.Id);

            //Property(m => m.Data)
            //    .HasColumnName("Data")
            //    .HasColumnType("datetime")
            //    .IsRequired();

            //Property(m => m.TipoOperacao.ToString())
            //    .HasColumnName("TipoOperacao")
            //    .IsRequired();

            //Property(m => m.Descricao)
            //    .HasColumnName("Descricao")
            //    .HasColumnType("varchar")
            //    .HasMaxLength(100)
            //    .IsRequired();

            //Property(m => m.Valor)
            //    .HasColumnName("Valor")
            //    .HasColumnType("float")
            //    .IsRequired();

            //HasRequired(m => m.Conta);

            //HasOptional(m => m.ContaMovimentada);

        }
    }
}
