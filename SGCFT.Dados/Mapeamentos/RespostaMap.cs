using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dados.Mapeamentos
{
    public class RespostaMap : EntityTypeConfiguration<Resposta>
    {
        public RespostaMap()
        {
            this.ToTable("Resposta");
            this.HasKey(x => x.Id);
            this.Property(x => x.IdUsuario);
            this.HasRequired(x => x.Pergunta).WithMany().HasForeignKey(x => x.IdPergunta);
            this.HasRequired(x => x.Usuario).WithMany().HasForeignKey(x => x.IdUsuario);
            this.HasRequired(x => x.Alternativa).WithMany().HasForeignKey(x => x.IdAlternativaEscolhida);
        }
    }
}
