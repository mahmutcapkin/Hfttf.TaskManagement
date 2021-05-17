using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Extensions;
using Hfttf.TaskManagement.UI.Models.Authentication;
using Hfttf.TaskManagement.UI.Models.Leader;
using Hfttf.TaskManagement.UI.Models.Project;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ILeaderService _leaderService;
        private readonly IUserService _userService;

        public ProjectController(IProjectService projectService, ILeaderService leaderService, IUserService userService)
        {
            _projectService = projectService;
            _leaderService = leaderService;
            _userService = userService;
        }

        public async Task<IActionResult> AllProjects()
        {
            var projects = await _projectService.GetAllAsync();
          return View(projects);
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> EditLeaderInProject(int id, ProjectAddUserViewModel model)
        //{
        //    ViewBag.Users = await _userService.GetListForDropdown();
        //    if (ModelState.IsValid)
        //    {
        //        model.Assign.Id = id;
        //        var role = await _projectService.ProjectDeleteUser(model.Assign);
        //        return RedirectToAction("AllProjects");
        //    }
        //    ModelState.AddModelError("", "Proje kullanıcı silme işlemi başarısız");
        //    return RedirectToAction("AllProjects");
        //}

        public async Task<IActionResult> DeleteLeaderInProject(int id)
        {

            var delete = await _leaderService.DeleteAsync(id);
            return RedirectToAction("AllProjects");
        }

    }
}
