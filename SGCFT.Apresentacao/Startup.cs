using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using SGCFT.Seguranca.Contexto;
using SGCFT.Seguranca.Manager;

[assembly: OwinStartup(typeof(SGCFT.Apresentacao.Startup))]
namespace SGCFT.Apresentacao
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Faço a inicialização dos recursos do AspnetIdentity
            app.CreatePerOwinContext(AspNetContext.Create);
            app.CreatePerOwinContext<UserAppManager>(UserAppManager.Create);
            app.CreatePerOwinContext<AppSignInManager>(AppSignInManager.Create);

            //Configurando o cookie, e em caso de não autenticado, redireciono para o a rota Login do controller Usuario;
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Usuario/Login"),
                CookieName = "Tractus",
                CookiePath = "/"
            });
        }
    }
}