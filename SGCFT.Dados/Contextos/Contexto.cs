using SGCFT.Dados.Mapeamentos;
using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dados.Contextos
{
    public class Contexto: DbContext
    {
        public Contexto(): base("Name=SGCFTConnection")
        {
            // evitar fazer consultas desnecessarias no banco buscando somente os objetos solicitados
            // como exemplo quando buscar os treinamentos do autor os módulos não virão
            Configuration.LazyLoadingEnabled = false;
            // evitar que o Entity coloque tudo em memória deixando a aplicação lenta
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Treinamento> Treinamento { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Pergunta> Pergunta { get; set; }
       // public DbSet<Resposta> Resposta { get; set; }
        //public DbSet<Alternativa> Alternativa { get; set; }
        //public DbSet<Video> Video { get; set; }
        //public DbSet<Acesso> Acesso { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remover a convensão de pluralizar o nome das tabelas 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add(new ConvensaoSGCFT());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new TreinamentoMap());
            modelBuilder.Configurations.Add(new ModuloMap());
            modelBuilder.Configurations.Add(new PerguntaMap());
            //modelBuilder.Configurations.Add(new RespostaMap());

            //modelBuilder.Configurations.Add(new AlternativaMap());
            //modelBuilder.Configurations.Add(new VideoMap());
            //modelBuilder.Configurations.Add(new AcessoMap());
        }

        public int Salvar()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach(var ev in ex.EntityValidationErrors)
                {
                    foreach (var x in ev.ValidationErrors)
                    {
                        //este foreach serve para sabermos quando salvar o objeto, se der erro vamos saber qual propriedade está inválida
                    }
                }
                throw;
            }
        }

    }

    public class ConvensaoSGCFT: Convention
    {
        public ConvensaoSGCFT()
        {
            this.Properties<DateTime>().Configure(c => c.HasColumnType("DATETIME2"));
            this.Properties<byte[]>().Configure(c => c.HasColumnType("VARBINARY(MAX)"));
            this.Properties<long>().Configure(c => c.HasColumnType("BIGINT"));
            this.Properties<short>().Configure(c => c.HasColumnType("SMALLINT"));
        }

    }
}
