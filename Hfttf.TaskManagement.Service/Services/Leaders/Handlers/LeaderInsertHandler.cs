using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Leaders.Commands;
using Hfttf.TaskManagement.Service.Services.Leaders.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Leaders.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Handlers
{
    public class LeaderInsertHandler : BaseLeaderHandler, IRequestHandler<LeaderInsertCommand, Response>
    {
        public LeaderInsertHandler(ILeaderRepository LeaderRepository) : base(LeaderRepository)
        {
        }
        public async Task<Response> Handle(LeaderInsertCommand request, CancellationToken cancellationToken)
        {
            var leader = TaskManagementMapper.Mapper.Map<Leader>(request);
            var response = await _leaderRepository.AddAsync(leader);
            //var leaderwithProjectandUser = await _leaderRepository.GetLeaderWithUserandProject(response.Id);          
            var leaderResponse = TaskManagementMapper.Mapper.Map<LeaderResponse>(response);
            var result = Response.Success(leaderResponse, 200);
            return result;
        }
    }
}
