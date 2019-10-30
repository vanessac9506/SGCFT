using SGCFT.Dados.Contextos;
using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SGCFT.Dados.Repositorios
{
    public class TreinamentoRepositorio : ITreinamentoRepositorio
    {

        private readonly Contexto _contexto;

        public TreinamentoRepositorio()
        {
            _contexto = new Contexto();
        }

        public void Alterar(Treinamento treinamento)
        {
            _contexto.Entry<Treinamento>(treinamento).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Inserir(Treinamento treinamento)
        {
            _contexto.Treinamento.Add(treinamento);
            _contexto.SaveChanges();
        }
        public List<Treinamento> selecionarTreinamentosPorUsuario(int idAutor)
        {
            var query = _contexto.Treinamento.Where(x => x.IdAutor == idAutor);
            return query.ToList();
        }

        public Treinamento ObterPorId(int id)
        {
            return _contexto.Treinamento.SingleOrDefault(x => x.Id == id);
        }

        public List<Treinamento> SelecionarPrincipaisVideos()
        {
            var query = _contexto.Treinamento.Where(x => x.Modulos.Count > 0).AsQueryable().Include(x => x.Autor);
            var lista = query.OrderBy(x => x.Id).Skip(0).Take(3).ToList();
            return lista;
        }

        public Treinamento ObterParaExibicao(int id)
        {
            var query = _contexto.Treinamento.Where(x => x.Id == id).AsQueryable().Include(x => x.Modulos).Include(x => x.Autor);
            var treinamento = query.SingleOrDefault();
            return treinamento;
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
