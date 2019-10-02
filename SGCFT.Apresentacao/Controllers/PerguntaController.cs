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
    public class PerguntaController: Controller
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

    }
}