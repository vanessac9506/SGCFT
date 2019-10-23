using SGCFT.Apresentacao.Models;
using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Contratos.Servicos;
using SGCFT.Dominio.Entidades;
using SGCFT.Dominio.Servicos;
using SGCFT.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGCFT.Apresentacao.Controllers
{
    [Authorize]
    public class VideoController: BaseController
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

        [HttpPost]
        public ActionResult Index(VideoViewModel videoViewModel)
        {
            if (ModelState.IsValid)
            {
                Video video = videoViewModel.ConverterParaDominio();
                Retorno retorno = _servicoVideos.InserirVideo(video);
                ViewBag.Sucesso = retorno.Sucesso;
                ViewBag.Mensagens = retorno.Mensagens;
            }
            return View();
        }

    }
}