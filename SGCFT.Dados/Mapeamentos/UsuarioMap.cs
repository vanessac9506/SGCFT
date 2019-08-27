using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dados.Mapeamentos
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            this.ToTable("Usuario");
            this.HasKey(x => x.Id);
            this.Property(x => x.Cpf);
            this.Property(x => x.Cnpj);
            this.Property(x => x.Nome).HasColumnType("VARCHAR").HasMaxLength(200);
            this.Property(x => x.Senha).HasColumnType("VARCHAR").HasMaxLength(500);
            this.Property(x => x.Email).HasColumnType("VARCHAR").HasMaxLength(200);


        }
    }
}
