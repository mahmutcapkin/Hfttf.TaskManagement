using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface IBankInformationRepository : IRepository<BankInformation>
    {
        Task<IReadOnlyList<BankInformation>> GetListWithUser();
        Task<IReadOnlyList<BankInformation>> GetListWithUserByUserId(string userId);
        Task<BankInformation> GetBankInformationWithUserById(int id);
    }
}
