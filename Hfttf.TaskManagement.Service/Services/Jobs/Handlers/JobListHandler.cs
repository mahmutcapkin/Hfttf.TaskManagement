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
    public class JobListHandler : BaseJobHandler, IRequestHandler<JobListQuery, Response>
    {
        public JobListHandler(IJobRepository jobRepository) : base(jobRepository)
        {
        }

        public async Task<Response> Handle(JobListQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _jobRepository.GetAllAsync();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<JobResponse>>(jobs);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
