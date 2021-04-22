using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Jobs.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Jobs.Queries;
using Hfttf.TaskManagement.Service.Services.Jobs.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Jobs.Handlers
{
    public class JobListWithUsersHandler : BaseJobHandler, IRequestHandler<JobListWithUsersQuery, Response>
    {
        public JobListWithUsersHandler(IJobRepository jobRepository) : base(jobRepository)
        {
        }

        public async Task<Response> Handle(JobListWithUsersQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _jobRepository.GetListWithUser();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<JobResponse>>(jobs);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
