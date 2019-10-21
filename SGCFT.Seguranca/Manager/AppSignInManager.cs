using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace SGCFT.Seguranca.Manager
{
    public class AppSignInManager : SignInManager<IdentityUser, string>
    {
        public AppSignInManager(UserAppManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {

        }

        public static AppSignInManager Create(IdentityFactoryOptions<AppSignInManager> option, IOwinContext context)
        {
            var manager = context.GetUserManager<UserAppManager>();

            var sign = new AppSignInManager(manager, context.Authentication);

            return sign;
        }
    }
}

