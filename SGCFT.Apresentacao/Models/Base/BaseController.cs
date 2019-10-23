using Microsoft.AspNet.Identity.Owin;
using SGCFT.Apresentacao.Models.Helpers;
using SGCFT.Dados.Repositorios;
using SGCFT.Dominio.Contratos.Repositorios;
using SGCFT.Seguranca.Manager;
using System.Web;
using System.Web.Mvc;

namespace SGCFT.Apresentacao.Models
{
    public abstract class BaseController : Controller
    {
        protected readonly IUsuarioRepositorio _usuarioRepositorio;

        public BaseController()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        public int IdUsuarioAutenticado
        {
            get
            {
                UserAppManager userManager = HttpContext.GetOwinContext().GetUserManager<UserAppManager>();
                var idUsuario = _usuarioRepositorio.ObterIdUsuarioPorEmail(userManager.ObterEmailUsuarioLogado());

                return idUsuario;
            }
        }
    }
}