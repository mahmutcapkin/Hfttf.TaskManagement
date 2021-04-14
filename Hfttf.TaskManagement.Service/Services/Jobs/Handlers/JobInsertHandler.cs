using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Jobs.Commands;
using Hfttf.TaskManagement.Service.Services.Jobs.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Jobs.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Jobs.Handlers
{
    public class JobInsertHandler : BaseJobHandler, IRequestHandler<JobInsertCommand, Response>
    {
        public JobInsertHandler(IJobRepository jobRepository) : base(jobRepository)
        {
        }
        public async Task<Response> Handle(JobInsertCommand request, CancellationToken cancellationToken)
        {
            var job = TaskManagementMapper.Mapper.Map<Job>(request);
            var response = await _jobRepository.AddAsync(job);
            var jobResponse = TaskManagementMapper.Mapper.Map<JobResponse>(response);
            var result = Response.Success(jobResponse, 200);
            return result;
        }
    }
}
