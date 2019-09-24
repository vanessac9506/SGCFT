using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Contratos.Servicos;
using SGCFT.Dominio.Entidades;
using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCFT.Dominio.Servicos
{
    public class VideoServico: IVideoServico
    {
        private IVideoRepositorio _videoRepositorio;
        public VideoServico(IVideoRepositorio videoRepositorio)
        {
            this._videoRepositorio = videoRepositorio;
        }

        public Retorno InserirVideo(Video video)
        {
            Retorno retorno = new Retorno();

            if (video == null)
            {
                retorno.AdicionarErro("Vídeo não informado");
                return retorno;
            }

            retorno = video.ValidarDominio();
            if (retorno.Sucesso)
                 _videoRepositorio.Inserir(video);

            return retorno;
        }

        public Retorno AlterarVideo(Video video)
        {
            Retorno retorno = new Retorno();
            if (video == null)
            {
                retorno.AdicionarErro("Vídeo não informado");
                return retorno;
            }
            retorno = video.ValidarDominio();
            if (retorno.Sucesso)
                _videoRepositorio.Alterar(video);

            return retorno;
        }
    }
}
