using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dados.Mapeamentos
{
    public class AcessoMap: EntityTypeConfiguration<Acesso>
    {
        public AcessoMap()
        {
            this.ToTable("Acesso");
            this.HasKey(x => x.Id);
            this.Property(x => x.IdUsuario);
            this.HasRequired(x => x.Modulo).WithMany().HasForeignKey(x => x.IdModulo);
            this.HasRequired(x => x.Video).WithMany().HasForeignKey(x => x.IdVideo);
            this.Property(x => x.PontoParada).HasColumnType("VARCHAR").HasMaxLength(200);
            this.Property(x => x.Visualizacao).HasColumnType("VARCHAR").HasMaxLength(200);
        }
    }
}
