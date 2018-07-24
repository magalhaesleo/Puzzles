using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws_banco_tabajara.Infra.ORM.Contextos
{
    public class ContextoBancoTabajara : DbContext
    {
        public ContextoBancoTabajara() : base("Puzzles_BancoTabajaraBD")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
