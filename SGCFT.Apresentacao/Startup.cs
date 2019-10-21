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
            app.CreatePerOwinContext(AspNetContext.Create);
            app.CreatePerOwinContext<UserAppManager>(UserAppManager.Create);
            app.CreatePerOwinContext<AppSignInManager>(AppSignInManager.Create);

            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
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