using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Leaders.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Leaders.Queries;
using Hfttf.TaskManagement.Service.Services.Leaders.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Handlers
{
    public class LeaderListByProjectIdHandler : BaseLeaderHandler, IRequestHandler<LeaderListByProjectIdQuery, Response>
    {
        public LeaderListByProjectIdHandler(ILeaderRepository LeaderRepository) : base(LeaderRepository)
        {
        }

        public async Task<Response> Handle(LeaderListByProjectIdQuery request, CancellationToken cancellationToken)
        {

            var leader = await _leaderRepository.GetListByProjectId(request.ProjectId);
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<LeaderResponse>>(leader);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
