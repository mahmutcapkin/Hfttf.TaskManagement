using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Hfttf.TaskManagement.API.Security.Token
{
    public class SignHandler
    {
        public static SecurityKey GetSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
