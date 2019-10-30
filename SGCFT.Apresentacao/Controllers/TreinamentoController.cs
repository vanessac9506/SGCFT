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

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(TreinamentoViewModel treinamentoViewModel)
        {
            Retorno retorno = null;
            if (ModelState.IsValid)
            {
                Treinamento treinamento = treinamentoViewModel.ConverterParaDominio();
                treinamento.IdAutor = base.IdUsuarioAutenticado;

                treinamentoViewModel.Modulos.ForEach(x => treinamento.AdicionarModulo(x));

                retorno = _servicoTreinamentos.InserirTreinamento(treinamento);
            }
            return Json(retorno);
        }

        public ActionResult Editar(int id)
        {
            TreinamentoViewModel treinamentoViewModel = new TreinamentoViewModel();
            var treinamento = _repositorioTreinamentos.ObterPorId(id);
            treinamentoViewModel.Tema = treinamento.Tema;
            treinamentoViewModel.TipoTreinamento = treinamento.TipoTreinamento;

            return View(treinamentoViewModel);
        }

        [HttpGet]
        [Route("Treinamento/{tema}/{id}")]
        public ActionResult Exibicao(string tema, int id)
        {
            var treinamento = _repositorioTreinamentos.ObterParaExibicao(id);
            var exibicao = new TreinamentoExibicaoViewModel(treinamento.Id, treinamento.Tema, "", treinamento.Duracao, treinamento.Autor.Nome, treinamento.Modulos);
            return View(exibicao);
        }
    }
}