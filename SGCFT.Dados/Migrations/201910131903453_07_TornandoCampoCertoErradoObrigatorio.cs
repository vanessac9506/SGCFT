namespace SGCFT.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _07_TornandoCampoCertoErradoObrigatorio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Alternativa", "CertoErrado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Alternativa", "CertoErrado", c => c.Boolean());
        }
    }
}
