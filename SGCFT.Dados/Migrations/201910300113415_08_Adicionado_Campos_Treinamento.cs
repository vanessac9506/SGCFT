namespace SGCFT.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _08_Adicionado_Campos_Treinamento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Treinamento", "DataAtualizacao", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Treinamento", "Duracao", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Treinamento", "Duracao");
            DropColumn("dbo.Treinamento", "DataAtualizacao");
        }
    }
}
