using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Extensions;
using Hfttf.TaskManagement.UI.Models.Authentication;
using Hfttf.TaskManagement.UI.Models.Department;
using Hfttf.TaskManagement.UI.Models.User;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.Controllers
{
    public class BusinessController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IJobService _jobService;
        private readonly IUserService _userService;
        public BusinessController(
            IDepartmentService departmentService,
            IJobService jobService,
            IUserService userService)
        {
            _userService = userService;
            _departmentService = departmentService;
            _jobService = jobService;
        }

        public async Task<IActionResult> AllDepartments()
        {
            var departments = await _departmentService.GetAllAsync();

            return View(departments);
        }

        public async Task<IActionResult> DepartmentWithUsers(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("AllDepartments");
            }
            var departments = await _departmentService.GetDepartmentWithUsersById(id);
            if (departments == null)
            {
                return NotFound();
            }
            List<UserDropdownList> list = new List<UserDropdownList>();
            var users = await _userService.GetAllAsync();
            foreach (var user in users)
            {
                UserDropdownList userDropdownList = new UserDropdownList();
                userDropdownList.UserId = user.Id;
                userDropdownList.FullName = user.FirstName + " " + user.LastName;
                list.Add(userDropdownList);
            }
            ViewBag.Users = list;
            var departmentViewModel = new DepartmentAddUserViewModel
            {
                Department = departments,
                UserUpdate = new UpdateForDepartment
                {
                    DepartmentId = id,
                }
            };
            return View(departmentViewModel);
        }



        //GET : ProfileInfo/AddOrEditAddress
        //GET : ProfileInfo/AddOrEditAddress/4
        [HttpGet]
        public async Task<IActionResult> AddOrEditDepartment(int id = 0)
        {
            if (id == 0)
                return View(new DepartmentUpdate());
            else
            {
                var departmentModel = await _departmentService.GetByIdAsync(id);
                if (departmentModel == null)
                {
                    return NotFound();
                }
                return View(departmentModel.Adapt<DepartmentUpdate>());
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditDepartment(int id, DepartmentUpdate  departmentUpdate)
        {
            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
                //Insert
                if (id == 0)
                {
                    await _departmentService.AddAsync(departmentUpdate.Adapt<DepartmentAdd>());
                }
                //Update
                else
                {
                    await _departmentService.UpdateAsync(departmentUpdate);
                }
                //var departments =;
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllDepartments", _departmentService.GetAllAsync()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEditDepartment", departmentUpdate) });
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);
            var delete = await _departmentService.DeleteAsync(department.Id);
            var departments = await _departmentService.GetAllAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAllDepartments", departments) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserToDepartment(int id ,DepartmentAddUserViewModel model)
        {
            ViewBag.Users = await _userService.GetAllAsync();
            if (ModelState.IsValid)
            {
                var department = await _userService.UpdateForDepartmentAsync(model.UserUpdate);
                return RedirectToAction("DepartmentWithUsers", id);
            }
            return RedirectToAction("DepartmentWithUsers", id);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserToDepartment(string id, DepartmentAddUserViewModel model)
        {
            UpdateForDepartment updateForDepartment = new UpdateForDepartment();
            updateForDepartment.UserId = id;
            updateForDepartment.DepartmentId =null;

            var department = await _userService.UpdateForDepartmentAsync(updateForDepartment); 
            return RedirectToAction("DepartmentWithUsers", model.UserUpdate.DepartmentId);
        }


    }
}
