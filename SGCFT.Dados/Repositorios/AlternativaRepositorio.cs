using SGCFT.Dados.Contextos;
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

        public void Alterar(Alternativa alternativa)
        {
            _contexto.Entry<Alternativa>(alternativa).State = System.Data.Entity.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Inserir(Alternativa alternativa)
        {
            _contexto.Alternativa.Add(alternativa);
            _contexto.SaveChanges();
        }

        public Alternativa AlternativaCorreta(int idPergunta)
        {
            return _contexto.Alternativa.Where(x => x.IdPergunta == idPergunta && x.CertoErrado).Single();
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
