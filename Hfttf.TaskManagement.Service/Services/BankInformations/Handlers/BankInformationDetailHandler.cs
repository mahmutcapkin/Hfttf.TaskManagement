using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.BankInformations.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.BankInformations.Queries;
using Hfttf.TaskManagement.Service.Services.BankInformations.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.BankInformations.Handlers
{
    public class BankInformationDetailHandler : BaseBankInformationHandler, IRequestHandler<BankInformationDetailQuery, Response>
    {
        public BankInformationDetailHandler(IBankInformationRepository BankInformationRepository) : base(BankInformationRepository)
        {

        }
        public async Task<Response> Handle(BankInformationDetailQuery request, CancellationToken cancellationToken)
        {
            var bankInformation = await _bankInformationRepository.GetBankInformationWithUserById(request.Id);
            var response = TaskManagementMapper.Mapper.Map<BankInformationResponse>(bankInformation);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
