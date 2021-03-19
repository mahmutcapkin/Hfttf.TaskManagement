using Hfttf.TaskManagement.Core.Models.Pagination;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Responses;
using MediatR;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Queries
{
    public class UserSalaryListPaginationQuery : PaginationQuery, IRequest<PagedResponse<IEnumerable<UserSalaryResponse>>>
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

