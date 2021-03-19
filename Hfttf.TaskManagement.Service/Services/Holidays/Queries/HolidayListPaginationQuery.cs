using Hfttf.TaskManagement.Core.Models.Pagination;
using Hfttf.TaskManagement.Service.Services.Holidays.Responses;
using MediatR;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.Holidays.Queries
{
    public class HolidayListPaginationQuery : PaginationQuery, IRequest<PagedResponse<IEnumerable<HolidayResponse>>>
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
