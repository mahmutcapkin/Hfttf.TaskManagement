using Hfttf.TaskManagement.UI.Models.Address;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IAddressService
    {
        Task<List<AddressResponse>> GetAllAsync();
        Task<AddressForUserInfoResponse> GetByIdAsync(int id);
        Task AddAsync(AddressAdd model);
        Task UpdateAsync(AddressUpdate model);
        Task DeleteAsync(int id);
        Task<List<AddressResponse>> GetListByUserId(string id);

    }
}
