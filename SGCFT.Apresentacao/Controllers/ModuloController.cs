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
    public class ModuloController: Controller
    {
        private readonly IModuloServico _servicoModulos;

        public ModuloController()
        {
            _servicoModulos = new ModuloServico(new ModuloRepositorio());
        }

        public ActionResult Index()
        {
            return View();
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
            return View();
        }
    }
}