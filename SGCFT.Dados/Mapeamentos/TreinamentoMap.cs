using SGCFT.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SGCFT.Dados.Mapeamentos
{
    public class TreinamentoMap : EntityTypeConfiguration<Treinamento>
    {
        public TreinamentoMap()
        {
            this.ToTable("Treinamento");
            this.HasKey(x => x.Id);
            this.Property(x => x.Tema).HasColumnType("VARCHAR").HasMaxLength(200);
            this.Property(x => x.TipoTreinamento);
            this.Property(x => x.Senha).HasColumnType("VARCHAR").HasMaxLength(500);
            this.Property(x => x.DataAtualizacao).HasColumnType("DATETIME2").IsRequired();
            this.Property(x => x.Duracao).HasMaxLength(50).HasColumnType("VARCHAR");
            this.HasRequired(x => x.Autor).WithMany().HasForeignKey(x => x.IdAutor);          
        }
    }
}
