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
        
        [HttpGet]
        [Route("Modulo/GetDropDown/{idTreinamento}")]
        public JsonResult GetDropDown(int idTreinamento)
        {
            var lista = _moduloRepositorio.SelecionarPorIdTreinamento(idTreinamento);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [Route("Modulo/{titulo}/{id}")]
        public ActionResult Exibicao(string titulo, int id)
        {
            var modulo = _moduloRepositorio.ObterModuloPorIdParaExibicao(id, base.IdUsuarioAutenticado);
            var exibicao = new ModuloExibicaoViewModel(modulo.Id, modulo.Titulo, modulo.Videos);
            return View(exibicao);
        }
    }
}