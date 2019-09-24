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

        public void Dispose()
        {
            if (_contexto != null)
            {
                _contexto.Dispose();
            }
        }
    }
}
