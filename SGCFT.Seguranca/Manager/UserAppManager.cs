using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SGCFT.Seguranca.Contexto;

namespace SGCFT.Seguranca.Manager
{
    public class UserAppManager : UserManager<IdentityUser>
    {
        public UserAppManager(IUserStore<IdentityUser> store) : base(store)
        {
        }

        public static UserAppManager Create(IdentityFactoryOptions<UserAppManager> options, IOwinContext context)
        {
            var appcontext = context.Get<AspNetContext>();

            var usuarioManager = new UserAppManager(new UserStore<IdentityUser>(appcontext));

            return usuarioManager;
        }
    }
}
