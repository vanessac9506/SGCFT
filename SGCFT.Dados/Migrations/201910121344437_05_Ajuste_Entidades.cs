namespace SGCFT.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _05_Ajuste_Entidades : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Video", "IdModulo");
            CreateIndex("dbo.Alternativa", "IdPergunta");
            CreateIndex("dbo.Resposta", "IdUsuario");
            AddForeignKey("dbo.Video", "IdModulo", "dbo.Modulo", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Alternativa", "IdPergunta", "dbo.Pergunta", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Resposta", "IdUsuario", "dbo.Usuario", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resposta", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Alternativa", "IdPergunta", "dbo.Pergunta");
            DropForeignKey("dbo.Video", "IdModulo", "dbo.Modulo");
            DropIndex("dbo.Resposta", new[] { "IdUsuario" });
            DropIndex("dbo.Alternativa", new[] { "IdPergunta" });
            DropIndex("dbo.Video", new[] { "IdModulo" });
        }
    }
}
