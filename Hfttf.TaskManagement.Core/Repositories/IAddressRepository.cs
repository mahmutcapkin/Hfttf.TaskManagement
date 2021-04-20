using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<IReadOnlyList<Address>> GetListWithUser();
        Task<IReadOnlyList<Address>> GetListWithUserByUserId(string userId);
        Task<Address> GetAddressWithUserById(int id);

    }
}
