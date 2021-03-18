using System;

namespace Hfttf.TaskManagement.Core.Models.Pagination
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationQuery filter, string route);
    }
}
