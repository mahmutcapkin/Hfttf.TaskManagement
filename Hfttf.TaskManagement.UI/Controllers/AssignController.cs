using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.Role;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.Controllers
{
    public class AssignController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public AssignController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        public async Task<IActionResult> AllRoles()
        {
            var roles = await _roleService.GetAllAsync();
            return View(roles);
        }

        public async Task<IActionResult> RolesWithUsers()
        {
            var roles = await _roleService.GetAllAsync();
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEditRole(string id)
        {
            if (id == null)
                return View(new RoleUpdate());
            else
            {
                var roleModel = await _roleService.GetByIdAsync(id);
                if (roleModel == null)
                {
                    return NotFound();
                }
                return View(roleModel.Adapt<RoleUpdate>());
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditRole(string id, RoleUpdate roleUpdate)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == null)
                {
                    await _roleService.AddAsync(roleUpdate.Adapt<RoleAdd>());
                }
                //Update
                else
                {
                    await _roleService.UpdateAsync(roleUpdate);
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllRoles", _roleService.GetAllAsync()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEditRole", roleUpdate) });
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteRole(string id)
        //{
        //    var delete = await _roleService.DeleteAsync(id);
        //    var roles = await _roleService.GetAllAsync();
        //    return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAllDepartments", roles) });
        //}

        public async Task<IActionResult> DeleteRole(string id)
        {
            var delete = await _roleService.DeleteAsync(id);
            return RedirectToAction("AllRoles");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AssignRoleToUser(int id, JobAddUserViewModel model)
        //{
        //    ViewBag.Users = await _userService.GetAllAsync();
        //    if (ModelState.IsValid)
        //    {
        //        var job = await _userService.UpdateForJobAsync(model.UserUpdate);
        //        return RedirectToAction("JobWithUsers", id);
        //    }
        //    return RedirectToAction("JobWithUsers", id);

        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteRoleToUser(string id, JobAddUserViewModel model)
        //{
        //    UpdateForJob updateForjob = new UpdateForJob();
        //    updateForjob.UserId = id;
        //    updateForjob.JobId = null;

        //    var job = await _userService.UpdateForJobAsync(updateForjob);
        //    return RedirectToAction("JobWithUsers", model.UserUpdate.JobId);
        //}
    }
}
