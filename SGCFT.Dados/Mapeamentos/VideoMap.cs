using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dados.Mapeamentos
{
    public class VideoMap: EntityTypeConfiguration<Video>
    {
        public VideoMap()
        {
            this.ToTable("Video");
            this.HasKey(x => x.Id);
            this.Property(x => x.Titulo).HasColumnType("VARCHAR").HasMaxLength(200);
            this.Property(x => x.Url).HasColumnType("VARCHAR").HasMaxLength(500);
            this.Property(x => x.IdModulo);
        }
    }
}
