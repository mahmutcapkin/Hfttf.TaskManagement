using Hfttf.TaskManagement.UI.Models.EducationInformation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IEducationInformationService
    {
        Task<List<EducationInformationResponse>> GetAllAsync();
        Task<EducationInformationResponse> GetByIdAsync(int id);
        Task AddAsync(EducationInformationAdd model);
        Task UpdateAsync(EducationInformationUpdate model);
        Task<bool> DeleteAsync(int id);
        Task<List<EducationInformationResponse>> GetListByUserId(string id);
    }
}
