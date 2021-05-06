using FluentValidation;
using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.CustomFilters;
using Hfttf.TaskManagement.UI.Extensions;
using Hfttf.TaskManagement.UI.Models;
using Hfttf.TaskManagement.UI.Models.Address;
using Hfttf.TaskManagement.UI.Models.Authentication;
using Hfttf.TaskManagement.UI.Models.BankInformation;
using Hfttf.TaskManagement.UI.Models.EducationInformation;
using Hfttf.TaskManagement.UI.Models.EmergencyContactInfo;
using Hfttf.TaskManagement.UI.Models.Experience;
using Hfttf.TaskManagement.UI.Models.User;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.Controllers
{
    [JwtAuthorize(Roles = "Admin,User")]
    public class ProfileInfoController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;
        private readonly IBankInformationService _bankInformationService;
        private readonly IExperienceService _experienceService;
        private readonly IEducationInformationService _educationInfoService;
        private readonly IEmergencyContactInfoService _emergencyContactInfoService;
        private readonly IDepartmentService _departmentService;
        private readonly IJobService _jobService;
        public ProfileInfoController(
            IAddressService addressService, 
            IUserService userService,
            IEmergencyContactInfoService emergencyContactInfoService,
            IEducationInformationService educationInfoService,
            IBankInformationService bankInformationService,
            IExperienceService experienceService,
            IDepartmentService departmentService,
            IJobService jobService)
        {
            _addressService = addressService;
            _userService = userService;
            _emergencyContactInfoService = emergencyContactInfoService;
            _bankInformationService = bankInformationService;
            _experienceService = experienceService;
            _educationInfoService = educationInfoService;
            _departmentService = departmentService;
            _jobService = jobService;
        }
        //protected AppUser CurrentUser => userManager.FindByNameAsync(User.Identity.Name).Result;

        [JwtAuthorize(Roles = "Admin,User")]
        public async Task<IActionResult> MyProfile()
        {
           //var token = HttpContext.Session.GetString("token");
            var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");

           
            var myProfile = await _userService.GetByIdWithInfo(activeUser.Id);
            return View(myProfile);
        }
        public async Task<IActionResult> UserProfile(string id)
        {
            if (id == null)
            {
                return RedirectToAction("AllDepartments", "Business");
            }

            var userProfile = await _userService.GetByIdWithInfo(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return View(userProfile);
        }
        



        //GET : ProfileInfo/AddOrEditEmergencyContact
        //GET : ProfileInfo/AddOrEditEmergencyContact/4
        public async Task<IActionResult> EditProfile(string id)
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(string id, UserUpdate   userUpdate)
        {
            ViewBag.Departments = await _departmentService.GetAllAsync();
            ViewBag.Jobs = await _jobService.GetAllAsync();

            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
                //Update
                if(!(await _userService.UpdateAsync(userUpdate)))
                {

                    ModelState.AddModelError("", "Profil Güncellenemedi");
                    return Json(new { isValid = false, adres = Helper.RenderRazorViewToString(this, "EditProfile", userUpdate) });
                }
                var myProfile = await _userService.GetByIdWithInfo(activeUser.Id);

                //return RedirectToAction("MyProfile");
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllUser", myProfile) });
            }
            return Json(new { isValid = false, adres = Helper.RenderRazorViewToString(this, "EditProfile", userUpdate) });
        }

        //GET : ProfileInfo/AddOrEditAddress
        //GET : ProfileInfo/AddOrEditAddress/4
        public async  Task<IActionResult> AddOrEditAddress(int id = 0)
        {
            if(id==0)
                return View(new AddressUpdate());
            else
            {
                var addressModel = await _addressService.GetByIdAsync(id);
                if (addressModel == null)
                {
                    return NotFound();
                }
                return View(addressModel.Adapt<AddressUpdate>());
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditAddress(int id, AddressUpdate addressUpdate)
        {
            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
                addressUpdate.ApplicationUserId = activeUser.Id;
                //Insert
                if (id == 0)
                {              
                    await _addressService.AddAsync(addressUpdate.Adapt<AddressAdd>());                
                }
                //Update
                else
                {              
                    await _addressService.UpdateAsync(addressUpdate);
                }
                var myProfile = await _userService.GetByIdWithInfo(activeUser.Id);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllAddress", myProfile) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEditAddress", addressUpdate) });
        }


        // GET: Transaction/Delete/5
        //public async Task<IActionResult> DeleteAddress(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var address =await _addressService.GetByIdAsync((int)id);
        //    if (address == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(address);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            var delete = await _addressService.DeleteAsync(address.Id);
            var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
            var myProfile = await _userService.GetByIdWithInfo(activeUser.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAllAddress", myProfile) });
        }


        //GET : ProfileInfo/AddOrEditEmergencyContact
        //GET : ProfileInfo/AddOrEditEmergencyContact/4
        public async Task<IActionResult> AddOrEditEmergencyContact(int id = 0)
        {
            if (id == 0)
                return View(new EmergencyContactInfoUpdate());
            else
            {
                var emergencyContact = await _emergencyContactInfoService.GetByIdAsync(id);
                if (emergencyContact == null)
                {
                    return NotFound();
                }
                return View(emergencyContact.Adapt<EmergencyContactInfoUpdate>());
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditEmergencyContact(int id, EmergencyContactInfoUpdate emergencyContactInfoUpdate)
        {
            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
                emergencyContactInfoUpdate.ApplicationUserId = activeUser.Id;
                //Insert
                if (id == 0)
                {
                    await _emergencyContactInfoService.AddAsync(emergencyContactInfoUpdate.Adapt<EmergencyContactInfoAdd>());
                }
                //Update
                else
                {
                    await _emergencyContactInfoService.UpdateAsync(emergencyContactInfoUpdate);
                }
                var myProfile = await _userService.GetByIdWithInfo(activeUser.Id);
               
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllEmergencyContact", myProfile) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEditEmergencyContact", emergencyContactInfoUpdate) });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEmergencyContact(int id)
        {
            var emergencyContactInfo = await _emergencyContactInfoService.GetByIdAsync(id);
            var delete = await _emergencyContactInfoService.DeleteAsync(emergencyContactInfo.Id);
            var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
            var myProfile = await _userService.GetByIdWithInfo(activeUser.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAllEmergencyContact", myProfile) });
        }


        //GET : ProfileInfo/AddOrEditEmergencyContact
        //GET : ProfileInfo/AddOrEditEmergencyContact/4
        public async Task<IActionResult> AddOrEditBankInformation(int id = 0)
        {
            if (id == 0)
                return View(new BankInformationUpdate());
            else
            {
                var bankInformation = await _bankInformationService.GetByIdAsync(id);
                if (bankInformation == null)
                {
                    return NotFound();
                }
                return View(bankInformation.Adapt<BankInformationUpdate>());
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditBankInformation(int id, BankInformationUpdate bankInformationUpdate )
        {
            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
                bankInformationUpdate.ApplicationUserId = activeUser.Id;
                //Insert
                if (id == 0)
                {
                    await _bankInformationService.AddAsync(bankInformationUpdate.Adapt<BankInformationAdd>());
                }
                //Update
                else
                {
                    await _bankInformationService.UpdateAsync(bankInformationUpdate);
                }
                var myProfile = await _userService.GetByIdWithInfo(activeUser.Id);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllBankInformation", myProfile) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEditBankInformation", bankInformationUpdate) });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBankInformation(int id)
        {
            var bankinformation = await _bankInformationService.GetByIdAsync(id);
            var delete = await _bankInformationService.DeleteAsync(bankinformation.Id);
            var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
            var myProfile = await _userService.GetByIdWithInfo(activeUser.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAllBankInformation", myProfile) });
        }

        //GET : ProfileInfo/AddOrEditEmergencyContact
        //GET : ProfileInfo/AddOrEditEmergencyContact/4
        public async Task<IActionResult> AddOrEditEducation(int id = 0)
        {
            if (id == 0)
                return View(new EducationInformationUpdate());
            else
            {
                var educationInformation = await _educationInfoService.GetByIdAsync(id);
                if (educationInformation == null)
                {
                    return NotFound();
                }
                return View(educationInformation.Adapt<EducationInformationUpdate>());
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditEducation(int id, EducationInformationUpdate educationInformation)
        {
            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
                educationInformation.ApplicationUserId = activeUser.Id;
                //Insert
                if (id == 0)
                {
                    await _educationInfoService.AddAsync(educationInformation.Adapt<EducationInformationAdd>());
                }
                //Update
                else
                {
                    await _educationInfoService.UpdateAsync(educationInformation);
                }
                var myProfile = await _userService.GetByIdWithInfo(activeUser.Id);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllEducation", myProfile) });
            }       
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEditEducation", educationInformation) });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var education = await _educationInfoService.GetByIdAsync(id);
            var delete = await _educationInfoService.DeleteAsync(education.Id);
            var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
            var myProfile = await _userService.GetByIdWithInfo(activeUser.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAllEducation", myProfile) });
        }

        //GET : ProfileInfo/AddOrEditEmergencyContact
        //GET : ProfileInfo/AddOrEditEmergencyContact/4
        public async Task<IActionResult> AddOrEditExperience(int id = 0)
        {
            if (id == 0)
                return View(new ExperienceUpdate());
            else
            {
                var experience = await _experienceService.GetByIdAsync(id);
                if (experience == null)
                {
                    return NotFound();
                }
                return View(experience.Adapt<ExperienceUpdate>());
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditExperience(int id, ExperienceUpdate  experienceUpdate)
        {
            if (ModelState.IsValid)
            {
                var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
                experienceUpdate.ApplicationUserId = activeUser.Id;
                //Insert
                if (id == 0)
                {
                    await _experienceService.AddAsync(experienceUpdate.Adapt<ExperienceAdd>());
                }
                //Update
                else
                {
                    await _experienceService.UpdateAsync(experienceUpdate);
                }
                var myProfile = await _userService.GetByIdWithInfo(activeUser.Id);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllExperience", myProfile) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEditExperience", experienceUpdate) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            var experience = await _experienceService.GetByIdAsync(id);
            var delete = await _experienceService.DeleteAsync(experience.Id);
            var activeUser = HttpContext.Session.GetObject<AppUser>("activeUser");
            var myProfile = await _userService.GetByIdWithInfo(activeUser.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAllExperience", myProfile) });
        }

        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0)
            {
                ModelState.AddModelError("", $"Id {id} eşit olamaz");
                return View();
            }
            var data = await _addressService.GetByIdAsync(id);         
            return View(data);           
        }
    }
}
