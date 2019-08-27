namespace SGCFT.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cpf = c.Long(),
                        Cnpj = c.Long(),
                        Nome = c.String(maxLength: 200, unicode: false),
                        Senha = c.String(maxLength: 500, unicode: false),
                        Email = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
        }
    }
}
