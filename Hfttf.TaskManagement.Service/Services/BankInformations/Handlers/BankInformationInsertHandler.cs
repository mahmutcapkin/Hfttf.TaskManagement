﻿using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.BankInformations.Commands;
using Hfttf.TaskManagement.Service.Services.BankInformations.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.BankInformations.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.BankInformations.Handlers
{
    public class BankInformationInsertHandler : BaseBankInformationHandler, IRequestHandler<BankInformationInsertCommand, Response>
    {
        public BankInformationInsertHandler(IBankInformationRepository BankInformationRepository) : base(BankInformationRepository)
        {

        }
        public async Task<Response> Handle(BankInformationInsertCommand request, CancellationToken cancellationToken)
        {
            var bankInformation = TaskManagementMapper.Mapper.Map<BankInformation>(request);
            var response = await _bankInformationRepository.AddAsync(bankInformation);
            var bankInformationresponse = TaskManagementMapper.Mapper.Map<BankInformationResponse>(response);
            var result = Response.Success(bankInformationresponse, 200);
            return result;
        }
    }
}
