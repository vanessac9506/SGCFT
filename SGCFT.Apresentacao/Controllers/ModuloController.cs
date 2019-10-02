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
    }
}