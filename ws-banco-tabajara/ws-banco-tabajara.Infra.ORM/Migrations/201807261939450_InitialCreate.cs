namespace ws_banco_tabajara.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBCLIENTE",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NOME = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                        DATANASCIMENTO = c.DateTime(nullable: false),
                        RG = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBCONTA",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Numero = c.String(nullable: false),
                        Ativa = c.Boolean(nullable: false),
                        Saldo = c.Double(nullable: false),
                        Limite = c.Double(nullable: false),
                        SaldoTotal = c.Double(nullable: false),
                        Titular_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBCLIENTE", t => t.Titular_Id)
                .Index(t => t.Titular_Id);
            
            CreateTable(
                "dbo.TBMOVIMENTACAO",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        TipoOperacao = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        ContaMovimentada_Id = c.Long(),
                        Conta_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBCONTA", t => t.ContaMovimentada_Id)
                .ForeignKey("dbo.TBCONTA", t => t.Conta_Id, cascadeDelete: true)
                .Index(t => t.ContaMovimentada_Id)
                .Index(t => t.Conta_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBCONTA", "Titular_Id", "dbo.TBCLIENTE");
            DropForeignKey("dbo.TBMOVIMENTACAO", "Conta_Id", "dbo.TBCONTA");
            DropForeignKey("dbo.TBMOVIMENTACAO", "ContaMovimentada_Id", "dbo.TBCONTA");
            DropIndex("dbo.TBMOVIMENTACAO", new[] { "Conta_Id" });
            DropIndex("dbo.TBMOVIMENTACAO", new[] { "ContaMovimentada_Id" });
            DropIndex("dbo.TBCONTA", new[] { "Titular_Id" });
            DropTable("dbo.TBMOVIMENTACAO");
            DropTable("dbo.TBCONTA");
            DropTable("dbo.TBCLIENTE");
        }
    }
}
