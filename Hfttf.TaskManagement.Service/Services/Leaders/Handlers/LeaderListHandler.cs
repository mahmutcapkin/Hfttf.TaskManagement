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
    public class LeaderListHandler : BaseLeaderHandler, IRequestHandler<LeaderListQuery, Response>
    {
        public LeaderListHandler(ILeaderRepository LeaderRepository) : base(LeaderRepository)
        {
        }

        public async Task<Response> Handle(LeaderListQuery request, CancellationToken cancellationToken)
        {
            var leader = await _leaderRepository.GetAllAsync();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<LeaderResponse>>(leader);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
