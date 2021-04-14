using Hfttf.TaskManagement.UI.Models.Holiday;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IHolidayService
    {
        Task<List<HolidayList>> GetAllAsync();
        Task<HolidayList> GetByIdAsync(int id);
        Task AddAsync(HolidayAdd model);
        Task UpdateAsync(HolidayUpdate model);
        Task DeleteAsync(int id);
    }
}
