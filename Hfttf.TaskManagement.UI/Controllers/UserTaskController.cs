using Hfttf.TaskManagement.UI.CustomFilters;
using Microsoft.AspNetCore.Mvc;

namespace Hfttf.TaskManagement.UI.Controllers
{
    [JwtAuthorize]
    public class UserTaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
