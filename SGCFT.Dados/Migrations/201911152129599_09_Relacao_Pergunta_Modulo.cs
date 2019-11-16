namespace SGCFT.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09_Relacao_Pergunta_Modulo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pergunta", "IdModulo", c => c.Int(nullable: false));
            CreateIndex("dbo.Pergunta", "IdModulo");
            AddForeignKey("dbo.Pergunta", "IdModulo", "dbo.Modulo", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pergunta", "IdModulo", "dbo.Modulo");
            DropIndex("dbo.Pergunta", new[] { "IdModulo" });
            DropColumn("dbo.Pergunta", "IdModulo");
        }
    }
}
