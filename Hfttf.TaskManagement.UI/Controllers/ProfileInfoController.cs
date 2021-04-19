using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.CustomFilters;
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
        public ProfileInfoController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        //[JwtAuthorize(Roles = "Admin,User")]
        public async Task<IActionResult> Index()
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(int id)
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProfile()
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> EditBankInfo()
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditBankInfo(int id)
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBankInfo()
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBankInfo(int id)
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditEducationInfo()
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditEducationInfo(int id)
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEducationInfo()
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEducationInfo(int id)
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditEmergencyInfo()
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditEmergencyInfo(int id)
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmergencyInfo()
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmergencyInfo(int id)
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> EditExperience()
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditExperience(int id)
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteExperience()
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            //var data = await _addressService.GetAllAsync();
            return View();
        }


        public async Task<IActionResult> GetById(int id)
        {
            var data = await _addressService.GetByIdAsync(id);
            return View(data);
        }
    }
}
