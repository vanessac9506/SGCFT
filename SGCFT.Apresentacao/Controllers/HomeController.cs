using SGCFT.Apresentacao.Models;
using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Contratos.Repositorios;
using System.Linq;
using System.Web.Mvc;

namespace SGCFT.Apresentacao.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ITreinamentoRepositorio _treinamentoRepositorio;
        public HomeController()
        {
            _treinamentoRepositorio = new TreinamentoRepositorio();
        }

        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            var treinamentos = _treinamentoRepositorio.SelecionarPrincipaisVideos();

            if (treinamentos != null)
                homeViewModel.ListaPrincipaisTreinamentos = treinamentos.Select(x => new TreinamentoExibicaoViewModel(x.Id, x.Tema, x.Autor.Nome)).ToList();

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