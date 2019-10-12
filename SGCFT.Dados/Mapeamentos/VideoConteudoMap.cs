using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dados.Mapeamentos
{
    public class VideoConteudoMap: EntityTypeConfiguration<VideoConteudo>
    {

        public VideoConteudoMap()
        {
            this.ToTable("VideoConteudo");
            this.HasKey(x => x.Id);
        }
    }
}
