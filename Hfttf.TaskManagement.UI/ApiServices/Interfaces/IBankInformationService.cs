using Hfttf.TaskManagement.UI.Models.BankInformation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IBankInformationService
    {
        Task<List<BankInformationList>> GetAllAsync();
        Task<BankInformationList> GetByIdAsync(int id);
        Task AddAsync(BankInformationAdd model);
        Task UpdateAsync(BankInformationUpdate model);
        Task DeleteAsync(int id);
        Task<List<BankInformationList>> GetListByUserId(string id);
    }
}
