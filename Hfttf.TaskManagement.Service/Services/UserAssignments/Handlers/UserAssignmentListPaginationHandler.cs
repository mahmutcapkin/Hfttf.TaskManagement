using Hfttf.TaskManagement.Core.Models.Pagination;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Queries;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers.Base;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers
{
    public class UserAssignmentListPaginationHandler : BaseUserAssignmentHandler, IRequestHandler<UserAssignmentListPaginationQuery, PagedResponse<IEnumerable<UserAssignmentResponse>>>
    {
        private readonly IUriService _uriService;

        public UserAssignmentListPaginationHandler(IUserAssignmentRepository UserAssignmentRepository, IUriService uriService) : base(UserAssignmentRepository)
        {
            _uriService = uriService;
        }

        public async Task<PagedResponse<IEnumerable<UserAssignmentResponse>>> Handle(UserAssignmentListPaginationQuery request, CancellationToken cancellationToken)
        {
            var validPageNumber = request.PageNumber < 1 ? 1 : request.PageNumber;
            var validPageSize = request.PageSize > 10 ? request.PageSize : 10;
            var pagedData = await _UserAssignmentRepository.GetAllPaginationAsync(validPageNumber, validPageSize);
            var pageDataResponses = TaskManagementMapper.Mapper.Map<IEnumerable<UserAssignmentResponse>>(pagedData);
            var totalRecords = await _UserAssignmentRepository.CountAsync();
            var response = new PagedResponse<IEnumerable<UserAssignmentResponse>>(pageDataResponses, validPageNumber, validPageSize);
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
