using Hfttf.TaskManagement.UI.Models.EmergencyContactInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IEmergencyContactInfoService
    {
        Task<List<EmergencyContactInfoList>> GetAllAsync();
        Task<EmergencyContactInfoList> GetByIdAsync(int id);
        Task AddAsync(EmergencyContactInfoAdd model);
        Task UpdateAsync(EmergencyContactInfoUpdate model);
        Task DeleteAsync(int id);
    }
}
