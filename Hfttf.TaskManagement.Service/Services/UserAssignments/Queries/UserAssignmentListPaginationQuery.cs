using Hfttf.TaskManagement.Core.Models.Pagination;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Responses;
using MediatR;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Queries
{
    public class UserAssignmentListPaginationQuery : PaginationQuery, IRequest<PagedResponse<IEnumerable<UserAssignmentResponse>>>
    {
        private string Route { get; set; }

        public void SetRoute(string route)
        {
            Route = route;
        }
        public string GetRoute()
        {
            return Route;
        }
    }
}
