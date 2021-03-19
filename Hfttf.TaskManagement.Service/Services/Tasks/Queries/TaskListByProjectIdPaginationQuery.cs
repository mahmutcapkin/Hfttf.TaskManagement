using Hfttf.TaskManagement.Core.Models.Pagination;
using Hfttf.TaskManagement.Service.Services.Tasks.Responses;
using MediatR;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Queries
{
    public class TaskListByProjectIdPaginationQuery : PaginationQuery, IRequest<PagedResponse<IEnumerable<TaskResponse>>>
    {
        private string Route { get; set; }
        public int ProjectId { get; set; }
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
