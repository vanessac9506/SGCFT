using SGCFT.Seguranca.Manager;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace SGCFT.Apresentacao.Models.Helpers
{
    public static class HelperClaim
    {
        public static string ObterEmailUsuarioLogado(this UserAppManager userAppManager)
        {
            string email = null;
            var identity = HttpContext.Current?.User?.Identity as ClaimsIdentity;
            var claims = identity?.Claims;
            if(claims != null)
            {
                email = claims.Single(x => x.Type == ClaimTypes.Name).Value;
            }
            return email;
        }
    }
}