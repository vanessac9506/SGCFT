using SGCFT.Apresentacao.Models;
using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Contratos.Servicos;
using SGCFT.Dominio.Entidades;
using SGCFT.Dominio.Servicos;
using SGCFT.Utilitario;
using System.Linq;
using System.Web.Mvc;

namespace SGCFT.Apresentacao.Controllers
{
    [Authorize]
    public class VideoController: BaseController
    {
        private readonly IVideoServico _servicoVideos;
        private readonly ITreinamentoRepositorio _treinamentoRepositorio;

        public VideoController()
        {
            _servicoVideos = new VideoServico(new VideoRepositorio());
            _treinamentoRepositorio = new TreinamentoRepositorio();
        }

        public ActionResult Index()
        {
            VideoViewModel videoViewModel = IniciarCadastro();
            return View(videoViewModel);
        }

        private VideoViewModel IniciarCadastro()
        {
            VideoViewModel videoViewModel = new VideoViewModel();
            var treinamentos = _treinamentoRepositorio.selecionarTreinamentosPorUsuario(base.IdUsuarioAutenticado);
            videoViewModel.Treinamentos = treinamentos.Select(x => new TreinamentoViewModel(x)).ToList();
            return videoViewModel;
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
            var videoViewModelNovo = IniciarCadastro();
            return View(videoViewModelNovo);
        }

    }
}