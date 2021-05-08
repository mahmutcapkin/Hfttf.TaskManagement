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
            ViewBag.Users = await _userService.GetListForDropdown();
            ViewBag.Roles = await _roleService.GetAllAsync();


            var roles = await _roleService.GetAllAsync();
            var roleAddViewModel = new RoleAddUserViewModel
            {
                Roles = roles,
            };

            return View(roleAddViewModel);
        }

        public async Task<IActionResult> RoleWithUsers(string id)
        {       
            if (id == null)
            {
                return RedirectToAction("AllRoles");
            }
            var roles = await _roleService.GetRoleWithUsersById(id);
            if (roles == null)
            {
                return NotFound();
            }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRoleToUser(RoleAddUserViewModel model)
        {
            ViewBag.Users = await _userService.GetListForDropdown();
            ViewBag.Roles = await _roleService.GetAllAsync();
            if (ModelState.IsValid)
            {
                var role = await _roleService.AssignRoleToUser(model.Assign);
                return RedirectToAction("AllRoles");
            }
            ModelState.AddModelError("", "Kullanıcı rol atama işlemi başarısız");
            return RedirectToAction("AllRoles");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRoleToUser(RoleAddUserViewModel model)
        {
            ViewBag.Users = await _userService.GetListForDropdown();
            ViewBag.Roles = await _roleService.GetAllAsync();
            if (ModelState.IsValid)
            {
                var role = await _roleService.DeleteRoleToUser(model.Assign);
                return RedirectToAction("AllRoles");
            }
            ModelState.AddModelError("", "Kullanıcı rol silme işlemi başarısız");
            return RedirectToAction("AllRoles");
        }
    }
}
