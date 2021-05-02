using FluentValidation;
using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.CustomFilters;
using Hfttf.TaskManagement.UI.Extensions;
using Hfttf.TaskManagement.UI.Models;
using Hfttf.TaskManagement.UI.Models.Address;
using Hfttf.TaskManagement.UI.Models.Authentication;
using Hfttf.TaskManagement.UI.Models.EmergencyContactInfo;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.Controllers
{
    public class ProfileInfoController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;
        private readonly IBankInformationService _bankInformationService;
        private readonly IExperienceService _experienceService;
        private readonly IEducationInformationService _educationInfoService;
        private readonly IEmergencyContactInfoService _emergencyContactInfoService;
        public ProfileInfoController(
            IAddressService addressService, 
            IUserService userService,
            IEmergencyContactInfoService emergencyContactInfoService,
            IEducationInformationService educationInfoService,
            IBankInformationService bankInformationService,
            IExperienceService experienceService)
        {
            _addressService = addressService;
            _userService = userService;
            _emergencyContactInfoService = emergencyContactInfoService;
            _bankInformationService = bankInformationService;
            _experienceService = experienceService;
            _educationInfoService = educationInfoService;
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
