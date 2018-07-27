namespace ws_banco_tabajara.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationsAdicionandoOnDeleteCascadeParaCliente : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TBCONTA", "Titular_Id", "dbo.TBCLIENTE");
            AddForeignKey("dbo.TBCONTA", "Titular_Id", "dbo.TBCLIENTE", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBCONTA", "Titular_Id", "dbo.TBCLIENTE");
            AddForeignKey("dbo.TBCONTA", "Titular_Id", "dbo.TBCLIENTE", "Id");
        }
    }
}
