using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Data.Funcionalidades.Clientes
{
    public class ClienteConfiguracao : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguracao()
        {
            ToTable("TBCliente");

            HasKey(cliente => cliente.Id);
            HasRequired(cliente => cliente.Endereco);
            Property(cliente => cliente.Nome)
                .HasColumnName("NOME")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(cliente => cliente.DataNascimento)
                .HasColumnName("DATANASCIMENTO")
                .HasColumnType("datetime")
                .IsRequired();

            Property(cliente => cliente.Telefone)
                .HasColumnName("TELEFONE")
                .HasColumnType("varchar")
                .HasMaxLength(11)
                .IsRequired();

            Property(cliente => cliente.TipoDeDocumento)
                .HasColumnName("TIPODOCUMENTO")
                .HasColumnType("varchar")
                .HasMaxLength(4)
                .IsRequired();

            Property(cliente => cliente.NumeroDocumento)
                .HasColumnName("NUMERODOCUMENTO")
                .HasColumnType("varchar")
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}
