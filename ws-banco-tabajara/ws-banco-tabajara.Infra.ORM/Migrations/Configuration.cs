namespace ws_banco_tabajara.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ws_banco_tabajara.Infra.ORM.Contextos.ContextoBancoTabajara>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ws_banco_tabajara.Infra.ORM.Contextos.ContextoBancoTabajara";
        }

        protected override void Seed(ws_banco_tabajara.Infra.ORM.Contextos.ContextoBancoTabajara context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
