using Hfttf.TaskManagement.Core.Models.Pagination;
using Hfttf.TaskManagement.Service.Services.Departments.Responses;
using MediatR;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.Departments.Queries
{
    public class DepartmentListPaginationQuery : PaginationQuery, IRequest<PagedResponse<IEnumerable<DepartmentResponse>>>
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
