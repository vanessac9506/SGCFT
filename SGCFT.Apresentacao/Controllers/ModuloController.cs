using SGCFT.Apresentacao.Models;
using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Contratos.Repositorios;
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
    public class ModuloController: BaseController
    {
        private readonly IModuloServico _servicoModulos;
        private readonly ITreinamentoRepositorio _treinamentoRepositorio;
        private readonly IModuloRepositorio _moduloRepositorio;

        public ModuloController()
        {
            _servicoModulos = new ModuloServico(new ModuloRepositorio());
            _treinamentoRepositorio = new TreinamentoRepositorio();
            _moduloRepositorio = new ModuloRepositorio();
        }

        public ActionResult Index()
        {
            ModuloViewModel moduloViewModel = new ModuloViewModel();
            var treinamentos = _treinamentoRepositorio.selecionarTreinamentosPorUsuario(1);
            moduloViewModel.ListaTreinamentos = treinamentos.Select(x => new TreinamentoViewModel(x)).ToList();
            return View(moduloViewModel);
        }

        [HttpGet]
        [Route("Modulo/GetDropDown/{idTreinamento}")]
        public JsonResult GetDropDown(int idTreinamento)
        {
            var lista = _moduloRepositorio.SelecionarPorIdTreinamento(idTreinamento);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(ModuloViewModel moduloViewModel)
        {
            if (ModelState.IsValid)
            {
                Modulo modulo = moduloViewModel.ConverterParaDominio();
                Retorno retorno = _servicoModulos.InserirModulo(modulo);
                ViewBag.Sucesso = retorno.Sucesso;
                ViewBag.Mensagens = retorno.Mensagens;
            }

            var treinamentos = _treinamentoRepositorio.selecionarTreinamentosPorUsuario(1);
            moduloViewModel.ListaTreinamentos = treinamentos.Select(x => new TreinamentoViewModel(x)).ToList();

            return View(moduloViewModel);
        }
    }
}