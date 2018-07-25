using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Clientes.ClienteMapaEF;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Infra.ORM.Contextos
{
    public class ContextoBancoTabajara : DbContext
    {
        public ContextoBancoTabajara() : base("Puzzles_BancoTabajaraBD")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Conta> Contas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ClienteMapaEF());
            modelBuilder.Configurations.Add(new MovimentacaoConfiguracao());
        }
    }
}
