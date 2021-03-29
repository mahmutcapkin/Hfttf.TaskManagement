using Hfttf.TaskManagement.Core.Entities;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.API.Security.Token
{
    public interface ITokenHandler
    {
        Task<AccessToken> CreateAccessToken(ApplicationUser user);

        void RevokeRefreshToken(ApplicationUser user);
    }
}
