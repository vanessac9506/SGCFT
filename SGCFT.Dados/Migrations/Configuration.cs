namespace SGCFT.Dados.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SGCFT.Dados.Contextos.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SGCFT.Dados.Contextos.Contexto context)
        {
            //context.Usuario.Add(new Dominio.Entidades.Usuario);
            //context.Salvar();
            
            
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}