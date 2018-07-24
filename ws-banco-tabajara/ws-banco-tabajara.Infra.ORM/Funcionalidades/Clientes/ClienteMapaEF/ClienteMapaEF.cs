using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;

namespace ws_banco_tabajara.Infra.ORM.Funcionalidades.Clientes.ClienteMapaEF
{
    public class ClienteMapaEF : EntityTypeConfiguration<Cliente>
    {
        public ClienteMapaEF()
        {
            ToTable("TBCLIENTE");

            HasKey(cliente => cliente.Id);

            Property(cliente => cliente.DataNascimento).HasColumnName("DATANASCIMENTO");

            Property(cliente => cliente.RG).HasColumnName("RG");

            Property(cliente => cliente.Nome).HasColumnName("NOME").IsRequired();

            Property(cliente => cliente.ContaId).HasColumnName("CONTAID");

            HasRequired(cliente => cliente.Conta)
           .WithMany().HasForeignKey(cliente => cliente.ContaId);



        }
    }
}
