using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SGCFT.Apresentacao.Models;
using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Contratos.Servicos;
using SGCFT.Dominio.Entidades;
using SGCFT.Dominio.Servicos;
using SGCFT.Seguranca.Contexto;
using SGCFT.Seguranca.Manager;
using SGCFT.Utilitario;
using System.Web;
using System.Web.Mvc;

namespace SGCFT.Apresentacao.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioServico _servicoUsuarios;

        public UsuarioController()
        {
            this._servicoUsuarios = new UsuarioServico(new UsuarioRepositorio());
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = usuarioViewModel.ConverterParaDominio();
                Retorno retorno = _servicoUsuarios.InserirUsuario(usuario);
                ViewBag.Sucesso = retorno.Sucesso;
                ViewBag.Mensagens = retorno.Mensagens;

                if(retorno.Sucesso)
                {
                    var login = new LoginViewModel()
                    {
                        Login = usuario.Email,
                        Senha = usuario.Senha
                    };

                    return Login(login);
                }
            }

            return Login();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserAppManager>();

            var user = userManager.Find(loginViewModel.Login, loginViewModel.Senha);

            if (user != null)
            {
                var appAsign = HttpContext.GetOwinContext().Get<AppSignInManager>();
                appAsign.SignIn(user, false, false);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensagem = "Usuário ou senha estão incorretos";
                return View(loginViewModel);
            }
        }

        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}