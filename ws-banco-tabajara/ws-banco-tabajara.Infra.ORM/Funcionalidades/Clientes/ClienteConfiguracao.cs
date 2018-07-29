using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;

namespace ws_banco_tabajara.Infra.ORM.Funcionalidades.Clientes
{
    public class ClienteConfiguracao : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguracao()
        {
            ToTable("TBCLIENTE");

            HasKey(cliente => cliente.Id);

            Property(cliente => cliente.DataNascimento).HasColumnName("DATANASCIMENTO");

            Property(cliente => cliente.RG).HasColumnName("RG");

            Property(cliente => cliente.Nome).HasColumnName("NOME").IsRequired();

            Property(cliente => cliente.CPF).IsRequired();
        }
    }
}
