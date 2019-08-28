namespace SGCFT.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _04_Alternativa_Video_Acesso : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acesso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUsuario = c.Int(nullable: false),
                        IdModulo = c.Int(nullable: false),
                        IdVideo = c.Int(nullable: false),
                        DataAcesso = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PontoParada = c.String(maxLength: 200, unicode: false),
                        Visualizacao = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modulo", t => t.IdModulo, cascadeDelete: true)
                .ForeignKey("dbo.Video", t => t.IdVideo, cascadeDelete: true)
                .Index(t => t.IdModulo)
                .Index(t => t.IdVideo);
            
            CreateTable(
                "dbo.Video",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdModulo = c.Int(nullable: false),
                        Titulo = c.String(maxLength: 200, unicode: false),
                        Url = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Alternativa", "Texto", c => c.String(maxLength: 500, unicode: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Acesso", "IdVideo", "dbo.Video");
            DropForeignKey("dbo.Acesso", "IdModulo", "dbo.Modulo");
            DropIndex("dbo.Acesso", new[] { "IdVideo" });
            DropIndex("dbo.Acesso", new[] { "IdModulo" });
            AlterColumn("dbo.Alternativa", "Texto", c => c.String());
            DropTable("dbo.Video");
            DropTable("dbo.Acesso");
        }
    }
}
