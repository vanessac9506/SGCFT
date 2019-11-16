using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dados.Mapeamentos
{
    public class PerguntaMap : EntityTypeConfiguration<Pergunta>
    {
        public PerguntaMap()
        {
            this.ToTable("Pergunta");
            this.HasKey(x => x.Id);
            this.Property(x => x.Texto).HasColumnType("VARCHAR").HasMaxLength(500);
            this.HasRequired(x => x.Autor).WithMany().HasForeignKey(x => x.IdAutor);
            this.HasMany(x => x.Alternativas).WithRequired(x => x.Pergunta).HasForeignKey(x => x.IdPergunta);
            this.HasRequired(x => x.Modulo).WithMany(x => x.Perguntas).HasForeignKey(x => x.IdModulo);
        }
    }
}
