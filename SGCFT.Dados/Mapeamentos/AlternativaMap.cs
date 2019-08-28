using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dados.Mapeamentos
{
    public class AlternativaMap:EntityTypeConfiguration<Alternativa>
    {
        public AlternativaMap()
        {
            this.ToTable("Alternativa");
            this.HasKey(x => x.Id);
            this.Property(x => x.Texto).HasColumnType("VARCHAR").HasMaxLength(500);
            this.Property(x => x.IdPergunta);
            this.Property(x => x.CertoErrado);
    }

    }
}
