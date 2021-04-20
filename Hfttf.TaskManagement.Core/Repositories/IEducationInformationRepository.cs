using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface IEducationInformationRepository : IRepository<EducationInformation>
    {
        Task<IReadOnlyList<EducationInformation>> GetListWithUser();
        Task<IReadOnlyList<EducationInformation>> GetListWithUserByUserId(string userId);
        Task<EducationInformation> GetEducationInformationWithUserById(int id);
    }
}
