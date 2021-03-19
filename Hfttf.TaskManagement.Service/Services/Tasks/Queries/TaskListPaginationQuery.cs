using Hfttf.TaskManagement.Core.Models.Pagination;
using MediatR;
using System.Collections.Generic;
using Hfttf.TaskManagement.Service.Services.Tasks.Responses;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Queries
{
    public class TaskListPaginationQuery : PaginationQuery, IRequest<PagedResponse<IEnumerable<TaskResponse>>>
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
