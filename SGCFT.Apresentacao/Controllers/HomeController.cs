using SGCFT.Apresentacao.Models;
using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Contratos.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SGCFT.Apresentacao.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IVideoRepositorio _videoRepositorio;
        public HomeController()
        {
            _videoRepositorio = new VideoRepositorio();
        }

        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            var videos = _videoRepositorio.SelecionarVideosParaExibicao();

            if (videos != null)
                homeViewModel.ListaPrincipaisVideos = videos.Select(x => new VideoExibicaoViewModel(x.Id, x.Modulo.Treinamento.Tema, x.Modulo.Titulo, x.Titulo, x.IdModulo)).ToList();

            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}