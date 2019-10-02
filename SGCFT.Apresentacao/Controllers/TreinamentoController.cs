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


    }
}