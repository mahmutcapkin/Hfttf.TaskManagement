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
    public class JobUpdateHandler : BaseJobHandler, IRequestHandler<JobUpdateCommand, Response>
    {
        public JobUpdateHandler(IJobRepository JobsRepository) : base(JobsRepository)
        {
        }
        public async Task<Response> Handle(JobUpdateCommand request, CancellationToken cancellationToken)
        {
            var job = TaskManagementMapper.Mapper.Map<Job>(request);
            job.UpdatedDate = DateTime.Now;
            var jobGetById = await _jobRepository.GetByIdAsync(request.Id);
            job.CreatedDate = jobGetById.CreatedDate;
            job.CreateBy = jobGetById.CreateBy;
            var response = await _jobRepository.UpdateAsync(job);
            var jobResponse = TaskManagementMapper.Mapper.Map<JobResponse>(response);
            var result = Response.Success(jobResponse, 200);
            return result;
        }
    }
}
