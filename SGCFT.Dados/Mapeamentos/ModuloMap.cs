﻿using SGCFT.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SGCFT.Dados.Mapeamentos
{
    public class ModuloMap : EntityTypeConfiguration<Modulo>
    {
        public ModuloMap()
        {
            this.ToTable("Modulo");
            this.HasKey(x => x.Id);
            this.Property(x => x.Titulo).HasColumnType("VARCHAR").HasMaxLength(200);
            this.HasRequired(x => x.Treinamento).WithMany(x => x.Modulos).HasForeignKey(x => x.IdTreinamento);
        }
    }
}
