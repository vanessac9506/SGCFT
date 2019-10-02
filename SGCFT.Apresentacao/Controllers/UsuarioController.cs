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
    public class UsuarioController: Controller
    {
        private readonly IUsuarioServico _servicoUsuarios;


        public UsuarioController()
        {
            _servicoUsuarios = new UsuarioServico(new UsuarioRepositorio());          
        }

        public ActionResult Index()
        {   
            return View();
        }

        [HttpPost]
        public ActionResult Index(UsuarioViewModel usuarioViewModel)
        {
           if(ModelState.IsValid)
            {
                Usuario usuario = usuarioViewModel.ConverterParaDominio();
                Retorno retorno = _servicoUsuarios.InserirUsuario(usuario);
                ViewBag.Sucesso = retorno.Sucesso;
                ViewBag.Mensagens = retorno.Mensagens;
            }
            return View();
        }

    }
}