using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.CustomFilters;
using Hfttf.TaskManagement.UI.Extensions;
using Hfttf.TaskManagement.UI.Models.Authentication;
using Hfttf.TaskManagement.UI.Models.Task;
using Hfttf.TaskManagement.UI.Models.UserAssignment;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.Controllers
{
    [JwtAuthorize]
    public class UserTaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;
        private readonly IUserAssignmentService _userAssignmentService;
        private readonly IProjectService _projectService;

        public UserTaskController(ITaskService taskService, IUserService userService, IUserAssignmentService userAssignmentService, IProjectService projectService)
        {
            _taskService = taskService;
            _userService = userService;
            _userAssignmentService = userAssignmentService;
            _projectService = projectService;
        }

        public async Task<IActionResult> TaskDetails(int id)
        {
            var task = await _taskService.GetByIdWithProjectandStatus(id);
            ViewBag.Users = await _projectService.GetListForDropdown(task.ProjectId);
            var taskDetails = new TaskDetailAssignModel
            {
                Task = task,
                UserAssignment = new UserAssignmentModel
                {
                    TaskId = id
                }
            };

            return View(taskDetails);
        }

        [HttpPost]
        public async Task<IActionResult> UserAssignTask(int id, TaskDetailAssignModel taskDetailAssign)
        {
            var task = await _taskService.GetByIdAsync(taskDetailAssign.UserAssignment.TaskId);
            ViewBag.Users = await _projectService.GetListForDropdown(task.ProjectId);
            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");

                var userAssignmentAdd = taskDetailAssign.UserAssignment.Adapt<UserAssignmentAdd>();
                userAssignmentAdd.CreateBy = activeUser.FirstName + " " + activeUser.LastName;
                var add = await _userAssignmentService.AddAsync(userAssignmentAdd);
                return RedirectToAction("TaskDetails", "UserTask", new { id = id });
            }
            ModelState.AddModelError("", "Atama işlemi başarısız");
            return RedirectToAction("TaskDetails", "UserTask", new {id=id });
        }


        public async Task<IActionResult> UserAssignmentsForProject(int id)
        {
            var assignments = await _userAssignmentService.GetListByProjectId(id);
            return View(assignments);
        }

        //GET : ProfileInfo/AddOrEditAddress
        //GET : ProfileInfo/AddOrEditAddress/4
        public async Task<IActionResult> EditUserAssignment(int id)
        {
            var assignment = await _userAssignmentService.GetByIdWithUserAndTaskAsync(id);
            ViewBag.Users = await _projectService.GetListForDropdown(assignment.Task.ProjectId);
            var assignmentResponse = await _userAssignmentService.GetByIdAsync(id);
            if (assignmentResponse == null)
            {
                return NotFound();
            }
            return View(assignmentResponse.Adapt<UserAssignmentUpdate>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserAssignment(int id, UserAssignmentUpdate userAssignmentUpdate)
        {
            var assignment = await _userAssignmentService.GetByIdWithUserAndTaskAsync(id);
            ViewBag.Users = await _projectService.GetListForDropdown(assignment.Task.ProjectId);
            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
                var valid = await _userAssignmentService.UpdateAsync(userAssignmentUpdate);
                if(valid)
                {
                    var userAssignment = await _userAssignmentService.GetByIdWithUserAndTaskAsync(id);
                    var assignments = await _userAssignmentService.GetListByProjectId(userAssignment.Task.ProjectId);
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllUserAssignments", assignments) });
                }else
                {
                    return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "EditUserAssignment", userAssignmentUpdate) });
                }
               
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "EditUserAssignment", userAssignmentUpdate) });
        }

        public async Task<IActionResult> DeleteUserAssignment(int id)
        {
            var detail = await _userAssignmentService.GetByIdAsync(id);
            var task = await _taskService.GetByIdAsync(detail.TaskId);
            var delete = await _userAssignmentService.DeleteAsync(id);
            return RedirectToAction("UserAssignmentsForProject", "UserTask",new { id = task.ProjectId });
        }


    }
  
}

