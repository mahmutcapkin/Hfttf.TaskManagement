using Hfttf.TaskManagement.UI.Models.Job;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.ApiServices.Interfaces
{
    public interface IJobService
    {
        Task<List<JobList>> GetAllAsync();
        Task<JobList> GetByIdAsync(int id);
        Task AddAsync(JobAdd model);
        Task UpdateAsync(JobUpdate model);
        Task DeleteAsync(int id);
    }
}
