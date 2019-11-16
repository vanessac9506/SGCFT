﻿using SGCFT.Apresentacao.Models;
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
    public class PerguntaController: BaseController
    {
        private readonly IPerguntaServico _servicoPerguntas;
        private readonly IPerguntaRepositorio _perguntaRepositorio;
        private readonly ITreinamentoRepositorio _treinamentoRepositorio;
        public PerguntaController()
        {
            _perguntaRepositorio = new PerguntaRepositorio();
            _servicoPerguntas = new PerguntaServico(_perguntaRepositorio);
            _treinamentoRepositorio = new TreinamentoRepositorio();
        }

        public ActionResult Index()
        {
            PerguntaViewModel perguntaViewModel = IniciarCadastro();
            return View(perguntaViewModel);

        }

        [HttpPost]
        public ActionResult Index(PerguntaViewModel perguntaViewModel)
        {
            Retorno retorno = null;
            if (ModelState.IsValid)
            {
                Pergunta pergunta = perguntaViewModel.ConverterParaDominio();
                pergunta.IdAutor = base.IdUsuarioAutenticado;

                for (int i = 0; i < perguntaViewModel.Alternativas.Length; i++)
                {
                    pergunta.AdicionarAlternativa(perguntaViewModel.Alternativas[i], perguntaViewModel.Corretos[i]);
                }

                retorno = _servicoPerguntas.InserirPergunta(pergunta);
                ViewBag.Sucesso = retorno.Sucesso;
                ViewBag.Mensagens = retorno.Mensagens;
            }
            return Json(retorno);
        }

        public JsonResult ObterQuestionario(int idModulo)
        {
            var perguntas = _perguntaRepositorio.SelecionarPorIdModulo(idModulo);
            var questionarios = perguntas.Select(x => new QuestionarioViewModel(x)).ToList();
            return Json(questionarios, JsonRequestBehavior.AllowGet);
        }

        private PerguntaViewModel IniciarCadastro()
        {
            PerguntaViewModel perguntaViewModel = new PerguntaViewModel();
            var treinamentos = _treinamentoRepositorio.selecionarTreinamentosPorUsuario(base.IdUsuarioAutenticado);
            perguntaViewModel.Treinamentos = treinamentos.Select(x => new TreinamentoViewModel(x)).ToList();
            return perguntaViewModel;
        }
    }
}