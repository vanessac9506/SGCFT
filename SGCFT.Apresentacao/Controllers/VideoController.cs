using SGCFT.Apresentacao.Models;
using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Contratos.Servicos;
using SGCFT.Dominio.Entidades;
using SGCFT.Dominio.Servicos;
using SGCFT.Utilitario;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SGCFT.Apresentacao.Controllers
{
    [Authorize]
    public class VideoController: BaseController
    {
        private readonly IVideoServico _servicoVideos;
        private readonly ITreinamentoRepositorio _treinamentoRepositorio;
        private readonly IVideoRepositorio _videoRepositorio;

        public VideoController()
        {
            _servicoVideos = new VideoServico(new VideoRepositorio());
            _treinamentoRepositorio = new TreinamentoRepositorio();
            _videoRepositorio = new VideoRepositorio();
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

        [HttpGet]
        [Route("Video/modulo-{modulo}/{idModulo}")]
        public ActionResult Exibicao(string modulo, int idModulo)
        {
            var video = _videoRepositorio.ObterVideoPorIdModulo(idModulo);

            var retorno = new VideoExibicaoViewModel(video.Id, video.Modulo.Treinamento.Tema, video.Modulo.Titulo, video.Titulo, video.IdModulo);

            return View(retorno);
        }

        [HttpGet]
        [Route("Video/conteudo/{titulo}/{id}")]
        public FileResult ExibirConteudo(string titulo, int id)
        {
            var video = _videoRepositorio.ObterConteudoVideoPorId(id);
            return File(video, "video/mp4", $"{titulo}.mp4");
        }

    }
}