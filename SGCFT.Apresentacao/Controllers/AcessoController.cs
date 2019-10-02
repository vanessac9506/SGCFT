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
    public class AcessoController : Controller 
    {
        private readonly IAcessoServico _servicoAcessos;

        public AcessoController()
        {
            _servicoAcessos = new AcessoServico(new AcessoRepositorio());
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}