namespace SGCFT.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03_Pergunta_Resposta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pergunta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(maxLength: 500, unicode: false),
                        IdAutor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.IdAutor, cascadeDelete: true)
                .Index(t => t.IdAutor);
            
            CreateTable(
                "dbo.Resposta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUsuario = c.Int(nullable: false),
                        IdPergunta = c.Int(nullable: false),
                        IdAlternativaEscolhida = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pergunta", t => t.IdPergunta, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdUsuario)
                .Index(t => t.IdPergunta);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resposta", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Resposta", "IdPergunta", "dbo.Pergunta");
            DropForeignKey("dbo.Pergunta", "IdAutor", "dbo.Usuario");
            DropIndex("dbo.Resposta", new[] { "IdPergunta" });
            DropIndex("dbo.Resposta", new[] { "IdUsuario" });
            DropIndex("dbo.Pergunta", new[] { "IdAutor" });
            DropTable("dbo.Resposta");
            DropTable("dbo.Pergunta");
        }
    }
}
