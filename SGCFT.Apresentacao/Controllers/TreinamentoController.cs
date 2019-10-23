using SGCFT.Apresentacao.Models;
using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Dominio.Contratos.Servicos;
using SGCFT.Dominio.Entidades;
using SGCFT.Dominio.Servicos;
using SGCFT.Utilitario;
using System.Web.Mvc;

namespace SGCFT.Apresentacao.Controllers
{
    [Authorize]
    public class TreinamentoController: BaseController
    {
        private readonly ITreinamentoServico _servicoTreinamentos;
        private readonly ITreinamentoRepositorio _repositorioTreinamentos;

        public TreinamentoController()
        {
            _servicoTreinamentos = new TreinamentoServico(new TreinamentoRepositorio());
            _repositorioTreinamentos = new TreinamentoRepositorio();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TreinamentoViewModel treinamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                Treinamento treinamento = treinamentoViewModel.ConverterParaDominio();
                treinamento.IdAutor = base.IdUsuarioAutenticado;
                Retorno retorno = _servicoTreinamentos.InserirTreinamento(treinamento);
                ViewBag.Sucesso = retorno.Sucesso;
                ViewBag.Mensagens = retorno.Mensagens;
            }
            return View();
        }

        public ActionResult Editar(int id)
        {
            TreinamentoViewModel treinamentoViewModel = new TreinamentoViewModel();
            var treinamento = _repositorioTreinamentos.ObterPorId(id);
            treinamentoViewModel.Tema = treinamento.Tema;
            treinamentoViewModel.TipoTreinamento = treinamento.TipoTreinamento;

            return View(treinamentoViewModel);
        }

    }
}