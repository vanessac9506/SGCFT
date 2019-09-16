﻿using SGCFT.Dados.Contextos;
using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dados.Repositorios
{
    public class AlternativaRepositorio: IAlternativaRepositorio
    {
        private readonly Contexto _contexto;

        public AlternativaRepositorio()
        {
            _contexto = new Contexto();
        }

        public void Inserir(Alternativa alternativa)
        {
            _contexto.Alternativa.Add(alternativa);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            if (_contexto != null)
            {
                _contexto.Dispose();
            }
        }
    }
}