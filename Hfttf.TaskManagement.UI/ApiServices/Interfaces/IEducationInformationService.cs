using Hfttf.TaskManagement.UI.Models.EducationInformation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IEducationInformationService
    {
        Task<List<EducationInformationList>> GetAllAsync();
        Task<EducationInformationList> GetByIdAsync(int id);
        Task AddAsync(EducationInformationAdd model);
        Task UpdateAsync(EducationInformationUpdate model);
        Task DeleteAsync(int id);
        Task<List<EducationInformationList>> GetListByUserId(string id);
    }
}
