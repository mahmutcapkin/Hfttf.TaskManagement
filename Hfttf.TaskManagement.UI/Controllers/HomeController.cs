using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.CustomFilters;
using Hfttf.TaskManagement.UI.Extensions;
using Hfttf.TaskManagement.UI.Models;
using Hfttf.TaskManagement.UI.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.Controllers
{
    [JwtAuthorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserAssignmentService _userAssignmentService;

        public HomeController(ILogger<HomeController> logger, IUserAssignmentService userAssignmentService)
        {
            _logger = logger;
            _userAssignmentService = userAssignmentService;
        }

        public async Task<IActionResult> Index()
        {
            var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
            var assignment = await _userAssignmentService.GetListByUserId(activeUser.Id);
            return View(assignment);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
