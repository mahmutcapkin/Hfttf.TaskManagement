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
    public class LeaderListByUserIdHandler : BaseLeaderHandler, IRequestHandler<LeaderListByUserIdQuery, Response>
    {
        public LeaderListByUserIdHandler(ILeaderRepository LeaderRepository) : base(LeaderRepository)
        {
        }

        public async Task<Response> Handle(LeaderListByUserIdQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Leader> leader;
            if (request.UserId == null)
            {
                leader = await _leaderRepository.GetListWithUserAndProject();
            }
            else
            {
                leader = await _leaderRepository.GetListWithUserByUserId(request.UserId);
            }
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<LeaderResponse>>(leader);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
