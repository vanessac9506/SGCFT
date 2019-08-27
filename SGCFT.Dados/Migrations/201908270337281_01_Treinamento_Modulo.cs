namespace SGCFT.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01_Treinamento_Modulo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Modulo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTreinamento = c.Int(nullable: false),
                        Titulo = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Treinamento", t => t.IdTreinamento, cascadeDelete: true)
                .Index(t => t.IdTreinamento);
            
            CreateTable(
                "dbo.Treinamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tema = c.String(maxLength: 200, unicode: false),
                        IdAutor = c.Int(nullable: false),
                        TipoTreinamento = c.Int(nullable: false),
                        Senha = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.IdAutor, cascadeDelete: true)
                .Index(t => t.IdAutor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modulo", "IdTreinamento", "dbo.Treinamento");
            DropForeignKey("dbo.Treinamento", "IdAutor", "dbo.Usuario");
            DropIndex("dbo.Treinamento", new[] { "IdAutor" });
            DropIndex("dbo.Modulo", new[] { "IdTreinamento" });
            DropTable("dbo.Treinamento");
            DropTable("dbo.Modulo");
        }
    }
}
