using Hfttf.TaskManagement.Core.Models.Pagination;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Leaves.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Leaves.Queries;
using Hfttf.TaskManagement.Service.Services.Leaves.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Leaves.Handlers
{
    public class LeaveListPaginationHandler : BaseLeaveHandler, IRequestHandler<LeaveListPaginationQuery, PagedResponse<IEnumerable<LeaveResponse>>>
    {
        private readonly IUriService _uriService;

        public LeaveListPaginationHandler(ILeaveRepository leaveRepository, IUriService uriService) : base(leaveRepository)
        {
            _uriService = uriService;
        }

        public async Task<PagedResponse<IEnumerable<LeaveResponse>>> Handle(LeaveListPaginationQuery request, CancellationToken cancellationToken)
        {
            var validPageNumber = request.PageNumber < 1 ? 1 : request.PageNumber;
            var validPageSize = request.PageSize > 10 ? request.PageSize : 10;
            var pagedData = await _leaveRepository.GetAllPaginationAsync(validPageNumber, validPageSize);
            var pageDataResponses = TaskManagementMapper.Mapper.Map<IEnumerable<LeaveResponse>>(pagedData);
            var totalRecords = await _leaveRepository.CountAsync();
            var response = new PagedResponse<IEnumerable<LeaveResponse>>(pageDataResponses, validPageNumber, validPageSize);
            var totalPages = ((double)totalRecords / (double)validPageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            response.NextPage =
                validPageNumber >= 1 && validPageNumber < roundedTotalPages
                    ? _uriService.GetPageUri(new PaginationQuery(validPageNumber + 1, validPageSize), request.GetRoute())
                    : null;
            response.PreviousPage =
                validPageNumber - 1 >= 1 && validPageNumber <= roundedTotalPages
                    ? _uriService.GetPageUri(new PaginationQuery(validPageNumber - 1, validPageSize), request.GetRoute())
                    : null;
            response.FirstPage = _uriService.GetPageUri(new PaginationQuery(1, validPageSize), request.GetRoute());
            response.LastPage = _uriService.GetPageUri(new PaginationQuery(roundedTotalPages, validPageSize), request.GetRoute());
            response.TotalPages = roundedTotalPages;
            response.TotalRecords = totalRecords;
            return response;
        }
    }
}
