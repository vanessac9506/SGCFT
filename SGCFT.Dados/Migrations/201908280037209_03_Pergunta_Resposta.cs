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
                .ForeignKey("dbo.Alternativa", t => t.IdAlternativaEscolhida, cascadeDelete: true)
                .ForeignKey("dbo.Pergunta", t => t.IdPergunta, cascadeDelete: true)
                .Index(t => t.IdPergunta)
                .Index(t => t.IdAlternativaEscolhida);
            
            CreateTable(
                "dbo.Alternativa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPergunta = c.Int(nullable: false),
                        Texto = c.String(),
                        CertoErrado = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resposta", "IdPergunta", "dbo.Pergunta");
            DropForeignKey("dbo.Resposta", "IdAlternativaEscolhida", "dbo.Alternativa");
            DropForeignKey("dbo.Pergunta", "IdAutor", "dbo.Usuario");
            DropIndex("dbo.Resposta", new[] { "IdAlternativaEscolhida" });
            DropIndex("dbo.Resposta", new[] { "IdPergunta" });
            DropIndex("dbo.Pergunta", new[] { "IdAutor" });
            DropTable("dbo.Alternativa");
            DropTable("dbo.Resposta");
            DropTable("dbo.Pergunta");
        }
    }
}
