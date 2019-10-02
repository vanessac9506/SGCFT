using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Contratos.Servicos;
using SGCFT.Dominio.Entidades;
using SGCFT.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGCFT.Apresentacao.Controllers
{
    public class VideoController: Controller
    {
        private readonly IVideoServico _servicoVideos;

        public VideoController()
        {
            _servicoVideos = new VideoServico(new VideoRepositorio());
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}