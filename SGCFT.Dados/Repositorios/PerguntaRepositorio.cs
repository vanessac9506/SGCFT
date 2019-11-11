using SGCFT.Dados.Contextos;
using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dados.Repositorios
{
    public class PerguntaRepositorio : IPerguntaRepositorio
    {
        private readonly Contexto _contexto;

        public PerguntaRepositorio()
        {
            _contexto = new Contexto();
        }

        public PerguntaRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Alterar(Pergunta pergunta)
        {
            _contexto.Entry<Pergunta>(pergunta).State = System.Data.Entity.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Inserir(Pergunta pergunta)
        {
            _contexto.Pergunta.Add(pergunta);
            _contexto.SaveChanges();
        }

        public List<Pergunta> SelecionarPorIdUsuario(int idUsuario)
        {
            var query = _contexto.Pergunta.Where(x => x.IdAutor == idUsuario).Include(x => x.Alternativas);
            return query.ToList();
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
