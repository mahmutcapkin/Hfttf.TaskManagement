﻿using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Core.Repositories
{
    public interface IJobRepository : IRepository<Job>
    {
        Task<IReadOnlyList<Job>> GetListWithUser();
        Task<Job> GetJobWithUsers(int id);
    }
}
