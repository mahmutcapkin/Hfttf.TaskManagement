using Hfttf.TaskManagement.UI.Models.EmergencyContactInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IEmergencyContactInfoService
    {
        Task<List<EmergencyContactInfoResponse>> GetAllAsync();
        Task<EmergencyContactInfoResponse> GetByIdAsync(int id);
        Task AddAsync(EmergencyContactInfoAdd model);
        Task UpdateAsync(EmergencyContactInfoUpdate model);
        Task<bool> DeleteAsync(int id);
        Task<List<EmergencyContactInfoResponse>> GetListByUserId(string id);
    }
}
