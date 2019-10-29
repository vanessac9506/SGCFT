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
    public class AlternativaController: BaseController
    {
        private readonly IAlternativaServico _servicoAlternativas;
        public AlternativaController()
        {
            _servicoAlternativas = new AlternativaServico(new AlternativaRepositorio());
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AlternativaViewModel alternativaViewModel)
        {
            if (ModelState.IsValid)
            {
                Alternativa alternativa = alternativaViewModel.ConverterParaDominio();
                Retorno retorno = _servicoAlternativas.InserirAlternativa(alternativa);
                ViewBag.Sucesso = retorno.Sucesso;
                ViewBag.Mensagens = retorno.Mensagens;
            }
            return View();
        }


    }
}