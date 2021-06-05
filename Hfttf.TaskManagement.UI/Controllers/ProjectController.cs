using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.CustomFilters;
using Hfttf.TaskManagement.UI.Extensions;
using Hfttf.TaskManagement.UI.Models.Authentication;
using Hfttf.TaskManagement.UI.Models.Leader;
using Hfttf.TaskManagement.UI.Models.Project;
using Hfttf.TaskManagement.UI.Models.Task;
using Hfttf.TaskManagement.UI.Models.TaskStatus;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.Controllers
{
    [JwtAuthorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ILeaderService _leaderService;
        private readonly IUserService _userService;
        private readonly ITaskStatusService _taskStatusService;
        private readonly ITaskService _taskService;
        private readonly IUserAssignmentService _userAssignmentService;

        public ProjectController(IProjectService projectService, ILeaderService leaderService, IUserService userService, ITaskStatusService taskStatusService, ITaskService taskService, IUserAssignmentService userAssignmentService)
        {
            _projectService = projectService;
            _leaderService = leaderService;
            _userService = userService;
            _taskStatusService = taskStatusService;
            _taskService = taskService;
            _userAssignmentService = userAssignmentService;
        }

        public async Task<IActionResult> AllProjects()
        {
            var projects = await _projectService.GetAllAsync();
          return View(projects);
        }
        public async Task<IActionResult> AllAssignments()
        {
            var userAssignments = await _userAssignmentService.GetAllAsync();
            return View(userAssignments);
        }

        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var delete = await _userAssignmentService.DeleteAsync(id);
            return RedirectToAction("AllAssignments");
        }

        public async Task<IActionResult> MyProjects()
        {
            var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
            var projects = await _projectService.GetListByUserId(activeUser.Id);
            return View(projects);
        }



        public async Task<IActionResult> ProjectDetails(int id)
        {
            var project = await _projectService.GetProjectWithUserandTaskById(id);
            ViewBag.Users = await _userService.GetListForDropdown();
            var projectAddUserViewModel = new ProjectAddUserViewModel
            {
                Project = project
            };
            return View(projectAddUserViewModel);
        }

        [HttpGet]
        public  IActionResult InsertProject()
        {
            return View(new ProjectAdd());
        }


        [HttpPost]
        public async Task<IActionResult> InsertProject(ProjectAdd projectAdd)
        {
            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
                projectAdd.CreateBy = activeUser.FirstName + " " + activeUser.LastName;
                var project = await _projectService.AddAsync(projectAdd);
                if (project)
                {
                    return RedirectToAction("AllProjects");
                }
            }
            ModelState.AddModelError("", "Proje Eklenemedi");
            return View(projectAdd);
        }

        [HttpGet]
        public async Task<IActionResult> EditProject(int id)
        {
            ViewBag.Leaders = await _leaderService.GetListForDropdown(id);
            var project = await _projectService.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project.Adapt<ProjectUpdate>());
        }


        [HttpPost]
        public async Task<IActionResult> EditProject(int id, ProjectUpdate projectUpdate)
        {
            ViewBag.Leaders = await _leaderService.GetListForDropdown(id);
            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
                projectUpdate.UpdateBy = activeUser.FirstName + " " + activeUser.LastName;
                var editProject = await _projectService.UpdateAsync(projectUpdate);
                if (editProject)
                {
                    return RedirectToAction("AllProjects");
                }
            }
            ModelState.AddModelError("", "Proje Güncellenemedi");
            return View(projectUpdate);
        }


        public async Task<IActionResult> DeleteProject(int id)
        {

            var delete = await _projectService.DeleteAsync(id);
            return RedirectToAction("AllProjects");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignProjectToUser(int id,ProjectAddUserViewModel model)
        {
            ViewBag.Users = await _userService.GetListForDropdown();
            if (ModelState.IsValid)
            {
                model.Assign.Id = id;
                var role = await _projectService.ProjectAddUser(model.Assign);
                return RedirectToAction("AllProjects");
            }
            ModelState.AddModelError("", "Proje kullanıcı atama işlemi başarısız");
            return RedirectToAction("AllProjects");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProjectToUser(int id, ProjectAddUserViewModel model)
        {
            ViewBag.Users = await _userService.GetListForDropdown();
            if (ModelState.IsValid)
            {
                model.Assign.Id = id;
                var role = await _projectService.ProjectDeleteUser(model.Assign);
                return RedirectToAction("AllProjects");
            }
            ModelState.AddModelError("", "Proje kullanıcı silme işlemi başarısız");
            return RedirectToAction("AllProjects");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertLeaderInProject(int id, ProjectAddUserViewModel model)
        {
            ViewBag.Users = await _userService.GetListForDropdown();
            if (ModelState.IsValid)
            {
                model.LeaderAssign.ProjectId = id;
                var Leader = model.LeaderAssign.Adapt<LeaderAdd>();
                var role = await _leaderService.AddAsync(Leader);
                return RedirectToAction("AllProjects");
            }
            ModelState.AddModelError("", "Proje lider ekleme işlemi başarısız");
            return RedirectToAction("AllProjects");
        }

        public async Task<IActionResult> DeleteLeaderInProject(int id)
        {

            var delete = await _leaderService.DeleteAsync(id);
            return RedirectToAction("AllProjects");
        }

        public async Task<IActionResult> GetTasksInProject(int id)
        {
            var tasks = await _taskStatusService.GetListWithTasks(id);

            var operation = new TaskStatusOperationModel
            {
                TaskStatusResponses = tasks,
                ProjectId=id
            };
            return View(operation);
        }

        public async Task<IActionResult> AddOrEditTask(int id = 0,int projectId=0)
        {
            if (id == 0)
                return View(new TaskOperationModel { 
                    ProjectId=projectId
                });
            else
            {
                var taskModel = await _taskService.GetByIdWithProjectandStatus(id);
                if (taskModel == null)
                {
                    return NotFound();
                }
                return View(taskModel.Adapt<TaskOperationModel>());
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditTask(int id, TaskOperationModel  taskOperationModel)
        {
            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");

                //Insert
                if (id == 0)
                {
                    taskOperationModel.CreateBy = activeUser.FirstName + " " + activeUser.LastName;
                    var taskAdd = taskOperationModel.Adapt<TaskAdd>();
                    await _taskService.AddAsync(taskAdd);
                }
                //Update
                else
                {
                    taskOperationModel.UpdateBy = activeUser.FirstName + " " + activeUser.LastName;
                    var taskUpdate = taskOperationModel.Adapt<TaskUpdate>();
                    await _taskService.UpdateAsync(taskUpdate);
                }
                var tasks = await _taskStatusService.GetListWithTasks((int)taskOperationModel.ProjectId);
                var operation = new TaskStatusOperationModel
                {
                    TaskStatusResponses = tasks,
                };
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllTasks", operation) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEditTask", taskOperationModel) });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            var projectId = task.ProjectId;
            var delete = await _taskService.DeleteAsync(id);
            var tasks = await _taskStatusService.GetListWithTasks((int)projectId);
            var operation = new TaskStatusOperationModel
            {
                TaskStatusResponses = tasks,
            };
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAllTasks", operation) });
        }


    }
}
