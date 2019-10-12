namespace SGCFT.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06_Criacao_VideoConteudo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VideoConteudo",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Conteudo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Video", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoConteudo", "Id", "dbo.Video");
            DropIndex("dbo.VideoConteudo", new[] { "Id" });
            DropTable("dbo.VideoConteudo");
        }
    }
}
