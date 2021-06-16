using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.CustomFilters;
using Hfttf.TaskManagement.UI.Extensions;
using Hfttf.TaskManagement.UI.Models.Authentication;
using Hfttf.TaskManagement.UI.Models.Department;
using Hfttf.TaskManagement.UI.Models.Job;
using Hfttf.TaskManagement.UI.Models.Leave;
using Hfttf.TaskManagement.UI.Models.User;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.Controllers
{
    [JwtAuthorize(Roles = "Admin")]
    public class BusinessController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IJobService _jobService;
        private readonly IUserService _userService;
        private readonly ILeaveService _leaveService;     
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BusinessController(
            IDepartmentService departmentService,
            IJobService jobService,
            IUserService userService,
            ILeaveService leaveService,
            IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _departmentService = departmentService;
            _jobService = jobService;
            _leaveService = leaveService;
            _webHostEnvironment = webHostEnvironment;
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
            //List<UserDropdownList> list = new List<UserDropdownList>();
            //var users = await _userService.GetAllAsync();
            //foreach (var user in users)
            //{
            //    UserDropdownList userDropdownList = new UserDropdownList();
            //    userDropdownList.UserId = user.Id;
            //    userDropdownList.FullName = user.FirstName + " " + user.LastName;
            //    list.Add(userDropdownList);
            //}
            //ViewBag.Users = list;
            ViewBag.Users = await _userService.GetListForDropdown();
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
        public async Task<IActionResult> AddOrEditDepartment(int id, DepartmentUpdate departmentUpdate)
        {
            if (ModelState.IsValid)
            {
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
        public async Task<IActionResult> AddUserToDepartment(int id, DepartmentAddUserViewModel model)
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
            updateForDepartment.DepartmentId = null;

            var department = await _userService.UpdateForDepartmentAsync(updateForDepartment);
            return RedirectToAction("DepartmentWithUsers", model.UserUpdate.DepartmentId);
        }



        public async Task<IActionResult> AllJobs()
        {
            var jobs = await _jobService.GetAllAsync();

            return View(jobs);
        }

        public async Task<IActionResult> JobWithUsers(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("AllJobs");
            }
            var jobs = await _jobService.GetJobWithUsersById(id);
            if (jobs == null)
            {
                return NotFound();
            }
            //List<UserDropdownList> list = new List<UserDropdownList>();
            //var users = await _userService.GetAllAsync();
            //foreach (var user in users)
            //{
            //    UserDropdownList userDropdownList = new UserDropdownList();
            //    userDropdownList.UserId = user.Id;
            //    userDropdownList.FullName = user.FirstName + " " + user.LastName;
            //    list.Add(userDropdownList);
            //}
            //ViewBag.Users = list;
            ViewBag.Users = await _userService.GetListForDropdown();
            var jobAddUserViewModel = new JobAddUserViewModel
            {
                Job = jobs,
                UserUpdate = new UpdateForJob
                {
                    JobId = id,
                }
            };
            return View(jobAddUserViewModel);

        }



        [HttpGet]
        public async Task<IActionResult> AddOrEditJob(int id = 0)
        {
            if (id == 0)
                return View(new JobUpdate());
            else
            {
                var jobModel = await _jobService.GetByIdAsync(id);
                if (jobModel == null)
                {
                    return NotFound();
                }
                return View(jobModel.Adapt<JobUpdate>());
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditJob(int id, JobUpdate jobUpdate)
        {
            if (ModelState.IsValid)
            {            
                //Insert
                if (id == 0)
                {
                    await _jobService.AddAsync(jobUpdate.Adapt<JobAdd>());
                }
                //Update
                else
                {
                    await _jobService.UpdateAsync(jobUpdate);
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllJobs", _jobService.GetAllAsync()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEditJob", jobUpdate) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var job = await _jobService.GetByIdAsync(id);
            var delete = await _jobService.DeleteAsync(job.Id);
            var jobs = await _jobService.GetAllAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAllJobs", jobs) });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserToJob(int id, JobAddUserViewModel model)
        {
            ViewBag.Users = await _userService.GetAllAsync();
            if (ModelState.IsValid)
            {
                var job = await _userService.UpdateForJobAsync(model.UserUpdate);
                return RedirectToAction("JobWithUsers", id);
            }
            return RedirectToAction("JobWithUsers", id);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserToJob(string id, JobAddUserViewModel model)
        {
            UpdateForJob updateForjob = new UpdateForJob();
            updateForjob.UserId = id;
            updateForjob.JobId = null;

            var job = await _userService.UpdateForJobAsync(updateForjob);
            return RedirectToAction("JobWithUsers", model.UserUpdate.JobId);
        }


        public async Task<IActionResult> AllLeaveList()
        {
            var leaves = await _leaveService.GetAllAsync();
            return View(leaves);
        }

        public async Task<IActionResult> LeavesForUser(string id)
        {
            var leaves = await _leaveService.GetListByUserId(id);
            return View(leaves);
        }

        [HttpGet]
        public async Task<IActionResult> InsertLeave()
        {
            //List<UserDropdownList> list = new List<UserDropdownList>();
            //var users = await _userService.GetAllAsync();
            //foreach (var user in users)
            //{
            //    UserDropdownList userDropdownList = new UserDropdownList();
            //    userDropdownList.UserId = user.Id;
            //    userDropdownList.FullName = user.FirstName + " " + user.LastName;
            //    list.Add(userDropdownList);
            //}
            ViewBag.Users = await _userService.GetListForDropdown();
            return View(new LeaveAdd());
        }

        [HttpPost]
        public async Task<IActionResult> InsertLeave(LeaveAdd leaveAdd)
        {
            //List<UserDropdownList> list = new List<UserDropdownList>();
            //var users = await _userService.GetAllAsync();
            //foreach (var user in users)
            //{
            //    UserDropdownList userDropdownList = new UserDropdownList();
            //    userDropdownList.UserId = user.Id;
            //    userDropdownList.FullName = user.FirstName + " " + user.LastName;
            //    list.Add(userDropdownList);
            //}
            ViewBag.Users = await _userService.GetListForDropdown();
            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
                leaveAdd.CreateBy = activeUser.FirstName + " " + activeUser.LastName;
                var isUpdate = await _leaveService.AddAsync(leaveAdd);
                return RedirectToAction("LeavesForUser","Business", leaveAdd.ApplicationUserId);
            }
            return View(leaveAdd);
        }

        [HttpGet]
        public async Task<IActionResult> EditLeave(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _leaveService.GetByIdAsync((int)id);
            //List<UserDropdownList> list = new List<UserDropdownList>();
            //var users = await _userService.GetAllAsync();
            //foreach (var user in users)
            //{
            //    UserDropdownList userDropdownList = new UserDropdownList();
            //    userDropdownList.UserId = user.Id;
            //    userDropdownList.FullName = user.FirstName + " " + user.LastName;
            //    list.Add(userDropdownList);
            //}
            ViewBag.Users = await _userService.GetListForDropdown();
            if (model == null)
            {
                return NotFound();
            }

            return View(model.Adapt<LeaveUpdate>());
        }

        [HttpPost]
        public async Task<IActionResult> EditLeave(int id,LeaveUpdate leaveUpdate)
        {
            //List<UserDropdownList> list = new List<UserDropdownList>();
            //var users = await _userService.GetAllAsync();
            //foreach (var user in users)
            //{
            //    UserDropdownList userDropdownList = new UserDropdownList();
            //    userDropdownList.UserId = user.Id;
            //    userDropdownList.FullName = user.FirstName + " " + user.LastName;
            //    list.Add(userDropdownList);
            //}
            ViewBag.Users = await _userService.GetListForDropdown();

            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
                leaveUpdate.UpdateBy = activeUser.FirstName + " " + activeUser.LastName;
                var isUpdate = await _leaveService.UpdateAsync(leaveUpdate);
                return RedirectToAction("LeavesForUser", "Business", leaveUpdate.ApplicationUserId);

            }
            ModelState.AddModelError("", "İzin güncelleme işlemi gerçekleştirilemedi");
            return View(leaveUpdate);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteLeave(int id)
        {
            var entity = await _leaveService.DeleteAsync(id);
            return RedirectToAction("AllLeaveList");
        }



        public async Task<IActionResult> AllStaffs()
        {
            var users = await _userService.GetListWithInfo();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> InsertStaff()
        {
            ViewBag.Departments = await _departmentService.GetAllAsync();
            ViewBag.Jobs = await _jobService.GetAllAsync();
            return View(new UserAdd());
        }


        [HttpPost]
        public async Task<IActionResult> InsertStaff(UserAdd userAdd)
        {
            ViewBag.Departments = await _departmentService.GetAllAsync();
            ViewBag.Jobs = await _jobService.GetAllAsync();
            if (ModelState.IsValid)
            {
                if (userAdd.ProfilePicture != null)
                {
                    string folder = "userImage/user/";
                    folder += Guid.NewGuid().ToString() + "_" + userAdd.ProfilePicture.FileName;
                    userAdd.PictureUrl = "/" + folder;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await userAdd.ProfilePicture.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                var addPhoto = await _userService.AddAsync(userAdd);
                if (addPhoto)
                {
                    return RedirectToAction("AllStaffs");
                }
            }
            ModelState.AddModelError("", "Personel Eklenemedi");
            return View(userAdd);
        }

        [HttpGet]
        public async Task<IActionResult> EditStaff(string id)
        {
            ViewBag.Departments = await _departmentService.GetAllAsync();
            ViewBag.Jobs = await _jobService.GetAllAsync();
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user.Adapt<UserUpdate>());
        }


        [HttpPost]
        public async Task<IActionResult> EditStaff(string id, UserUpdate userUpdate)
        {
            ViewBag.Departments = await _departmentService.GetAllAsync();
            ViewBag.Jobs = await _jobService.GetAllAsync();
            if (ModelState.IsValid)
            {
                if (userUpdate.ProfilePicture != null)
                {
                    string folder = "userImage/user/";
                    folder += Guid.NewGuid().ToString() + "_" + userUpdate.ProfilePicture.FileName;
                    userUpdate.PictureUrl = "/" + folder;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await userUpdate.ProfilePicture.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                var addPhoto = await _userService.UpdateAsync(userUpdate);
                if (addPhoto)
                {
                    return RedirectToAction("AllStaffs");
                }
            }
            ModelState.AddModelError("", "Personel Güncellenemedi");
            return View(userUpdate);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStaff(string id)
        {
           
            var delete = await _userService.DeleteAsync(id);
            return RedirectToAction("AllStaffs");
        }



    }
}
