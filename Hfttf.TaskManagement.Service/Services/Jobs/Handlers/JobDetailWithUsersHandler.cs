﻿using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Jobs.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Jobs.Queries;
using Hfttf.TaskManagement.Service.Services.Jobs.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Jobs.Handlers
{
    public class JobDetailWithUsersHandler : BaseJobHandler, IRequestHandler<JobDetailWithUsersQuery, Response>
    {
        public JobDetailWithUsersHandler(IJobRepository jobRepository) : base(jobRepository)
        {
        }
        public async Task<Response> Handle(JobDetailWithUsersQuery request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetJobWithUsers(request.Id);
            var jobResponse = TaskManagementMapper.Mapper.Map<JobResponse>(job);
            var response = Response.Success(jobResponse, 200);
            return response;
        }
    }
}
