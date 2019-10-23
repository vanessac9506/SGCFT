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
    public class PerguntaController: BaseController
    {
        private readonly IPerguntaServico _servicoPerguntas;

        public PerguntaController()
        {
            _servicoPerguntas = new PerguntaServico(new PerguntaRepositorio());
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PerguntaViewModel perguntaViewModel)
        {
            if (ModelState.IsValid)
            {
                Pergunta pergunta = perguntaViewModel.ConverterParaDominio();
                Retorno retorno = _servicoPerguntas.InserirPergunta(pergunta);
                ViewBag.Sucesso = retorno.Sucesso;
                ViewBag.Mensagens = retorno.Mensagens;
            }
            return View();
        }


    }
}