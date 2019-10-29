using SGCFT.Dados.Contextos;
using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SGCFT.Dados.Repositorios
{
    public class VideoRepositorio: IVideoRepositorio
    {
        private readonly Contexto _contexto;

        public VideoRepositorio()
        {
            _contexto = new Contexto();
        }

        public void Alterar(Video video)
        {
            _contexto.Entry<Video>(video).State = System.Data.Entity.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Inserir(Video video)
        {
            _contexto.Video.Add(video);
            _contexto.SaveChanges();
        }

        public List<Video> SelecionarVideosParaExibicao()
        {
            var query = _contexto.Video.AsQueryable().Include(x => x.Modulo).Include(x => x.Modulo.Treinamento);
            var lista = query.OrderBy(x => x.Id).Skip(0).Take(3).ToList();
            return lista;
        }

        public Video ObterVideoPorIdModulo(int idModulo)
        {
            var query = _contexto.Video.Where(x => x.IdModulo == idModulo).AsQueryable().Include(x => x.Modulo).Include(x => x.Modulo.Treinamento);
            var video = query.SingleOrDefault();
            return video;
        }

        public byte[] ObterConteudoVideoPorId(int id)
        {
            var query = _contexto.Video.Where(x => x.Id == id).AsQueryable().Include(x => x.VideoConteudo);
            var video = query.Select(x => x.VideoConteudo.Conteudo).SingleOrDefault();
            return video;
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
