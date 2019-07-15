﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dados.Contextos
{
    public class Contexto: DbContext
    {
        public Contexto(): base("Name=SGCFTConnection")
        {
            // evitar fazer consultas desnecessarias no banco buscando somente os objetos solicitados
            // como exemplo quando buscar os treinamentos do autor os módulos não virão
            Configuration.LazyLoadingEnabled = false;
            // evitar que o Entity coloque tudo em memória deixando a aplicação lenta
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remover a convensão de pluralizar o nome das tabelas 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add(new ConvensaoSGCFT());
        }

        public int Salvar()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach(var ev in ex.EntityValidationErrors)
                {
                    foreach (var x in ev.ValidationErrors)
                    {
                        //este foreach serve para sabermos quando salvar o objeto, se der erro vamos saber qual propriedade está inválida
                    }
                }
                throw;
            }
        }

    }

    public class ConvensaoSGCFT: Convention
    {
        public ConvensaoSGCFT()
        {
            this.Properties<DateTime>().Configure(c => c.HasColumnType("DATETIME2"));
            this.Properties<byte[]>().Configure(c => c.HasColumnType("VARBINARY(MAX)"));
            this.Properties<long>().Configure(c => c.HasColumnType("BIGINT"));
            this.Properties<short>().Configure(c => c.HasColumnType("SMALLINT"));
        }

    }
}
