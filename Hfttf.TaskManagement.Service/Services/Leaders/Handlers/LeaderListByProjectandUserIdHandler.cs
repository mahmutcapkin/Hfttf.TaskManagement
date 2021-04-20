using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Leaders.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Leaders.Queries;
using Hfttf.TaskManagement.Service.Services.Leaders.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Handlers
{
    public class LeaderListByProjectandUserIdHandler : BaseLeaderHandler, IRequestHandler<LeaderListByProjectandUserIdQuery, Response>
    {
        public LeaderListByProjectandUserIdHandler(ILeaderRepository LeaderRepository) : base(LeaderRepository)
        {
        }

        public async Task<Response> Handle(LeaderListByProjectandUserIdQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Leader> leader;
            if (request.ProjectId == null)
            {
                leader = await _leaderRepository.GetListWithUserByUserId(request.UserId);
            }
            else if (request.UserId == null)
            {
                leader = await _leaderRepository.GetListByProjectId(request.ProjectId);
            }
            else if(request.ProjectId==null && request.UserId == null)
            {
                leader = await _leaderRepository.GetListWithUserAndProject();
            }
            else
            {
                leader = await _leaderRepository.GetListByUserIdandProjectId(request.UserId, request.ProjectId);
            }
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<LeaderResponse>>(leader);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
