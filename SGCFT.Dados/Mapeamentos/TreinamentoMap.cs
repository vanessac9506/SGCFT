using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.HasRequired(x => x.Autor).WithMany().HasForeignKey(x => x.IdAutor);          
        }
    }
}
