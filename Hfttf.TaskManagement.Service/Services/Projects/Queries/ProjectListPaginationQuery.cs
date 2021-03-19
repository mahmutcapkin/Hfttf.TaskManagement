using Hfttf.TaskManagement.Core.Models.Pagination;
using Hfttf.TaskManagement.Service.Services.Projects.Responses;
using MediatR;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.Projects.Queries
{
    public class ProjectListPaginationQuery : PaginationQuery, IRequest<PagedResponse<IEnumerable<ProjectResponse>>>
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
