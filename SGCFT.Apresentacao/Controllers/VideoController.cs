using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCFT.Apresentacao.Controllers
{
    public class VideoController
    {
        private VideoRepositorio _repositorioVideos;
        public VideoController()
        {
            _repositorioVideos = new VideoRepositorio();
        }

        public bool CadastrarVideo(Video video)
        {

            try //try e dois tabs já montam a estrutura do trycatch
            {
                _repositorioVideos.Inserir(video);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}