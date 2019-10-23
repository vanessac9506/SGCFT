using SGCFT.Apresentacao.Models;
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
    public class RespostaController: BaseController
    {
        private readonly IRespostaServico _servicoRespostas;

        public RespostaController()
        {
            _servicoRespostas = new RespostaServico(new RespostaRepositorio());
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}