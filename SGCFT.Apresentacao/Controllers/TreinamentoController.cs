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
    public class TreinamentoController: Controller
    {
        private readonly ITreinamentoServico _servicoTreinamentos;

        public TreinamentoController()
        {
            _servicoTreinamentos = new TreinamentoServico(new TreinamentoRepositorio());
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
                Retorno retorno = _servicoTreinamentos.InserirTreinamento(treinamento);
                ViewBag.Sucesso = retorno.Sucesso;
                ViewBag.Mensagens = retorno.Mensagens;
            }
            return View();
        }

    }
}