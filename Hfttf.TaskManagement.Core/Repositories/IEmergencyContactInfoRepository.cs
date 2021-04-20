using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface IEmergencyContactInfoRepository : IRepository<EmergencyContactInfo>
    {
        Task<IReadOnlyList<EmergencyContactInfo>> GetListWithUser();
        Task<IReadOnlyList<EmergencyContactInfo>> GetListWithUserByUserId(string userId);
        Task<EmergencyContactInfo> GetEmergencyContactInfoWithUserById(int id);
    }
}
