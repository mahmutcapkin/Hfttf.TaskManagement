using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Leaders.Commands;
using Hfttf.TaskManagement.Service.Services.Leaders.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Leaders.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Handlers
{
    public class LeaderUpdateHandler : BaseLeaderHandler, IRequestHandler<LeaderUpdateCommand, Response>
    {
        public LeaderUpdateHandler(ILeaderRepository LeaderRepository) : base(LeaderRepository)
        {
        }

        public async Task<Response> Handle(LeaderUpdateCommand request, CancellationToken cancellationToken)
        {
            var leader = TaskManagementMapper.Mapper.Map<Leader>(request);
            var response = await _leaderRepository.UpdateAsync(leader);
            var leaderResponse = TaskManagementMapper.Mapper.Map<LeaderResponse>(response);
            var result = Response.Success(leaderResponse, 200);
            return result;
        }
    }
}
