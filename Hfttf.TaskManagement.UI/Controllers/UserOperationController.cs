using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.CustomFilters;
using Hfttf.TaskManagement.UI.Extensions;
using Hfttf.TaskManagement.UI.Models.Authentication;
using Hfttf.TaskManagement.UI.Models.Leave;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.Controllers
{
    [JwtAuthorize]
    public class UserOperationController : Controller
    {
        private readonly ILeaveService _leaveService;
        private readonly IUserSalaryService _userSalaryService;
        public UserOperationController(
            ILeaveService leaveService, 
            IUserSalaryService userSalaryService)
        {
            _leaveService = leaveService;
            _userSalaryService = userSalaryService;
        }

     
        public async Task<IActionResult> LeaveListForUser()
        {
            var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
            var leaves = await _leaveService.GetListByUserId(activeUser.Id);
            return View(leaves);
        }

        [HttpGet]
        public IActionResult LeaveInsertForUser(string id)
        {
            return View(new LeaveAdd
            {
                ApplicationUserId = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> LeaveInsertForUser(LeaveAdd leaveAdd)
        {
            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
                leaveAdd.CreateBy = activeUser.FirstName + " " + activeUser.LastName;
                leaveAdd.ApplicationUserId = activeUser.Id;
                var isUpdate = await _leaveService.AddAsync(leaveAdd);
                return RedirectToAction("LeaveListForUser");
            }
            return View(leaveAdd);
        }

        [HttpGet]
        public async Task<IActionResult> LeaveEditForUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model =await _leaveService.GetByIdAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model.Adapt<LeaveUpdate>());
        }

        [HttpPost]
        public async Task<IActionResult> LeaveEditForUser(LeaveUpdate leaveUpdate)
        {
            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
                leaveUpdate.UpdateBy = activeUser.FirstName + " " + activeUser.LastName;
                leaveUpdate.ApplicationUserId = activeUser.Id;
                var isUpdate = await _leaveService.UpdateAsync(leaveUpdate);
                return RedirectToAction("LeaveListForUser");
               
            }
            ModelState.AddModelError("", "İzin Güncelleme işlemi gerçekleştirilemedi");
            return View(leaveUpdate);

        }

        [HttpPost]
        public async Task<IActionResult> LeaveDeleteForUser(int id)
        {
            var entity = await _leaveService.DeleteAsync(id);          
            return RedirectToAction("LeaveListForUser");
        }
    }
}
