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
    public class AlternativaController: Controller
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
    }
}