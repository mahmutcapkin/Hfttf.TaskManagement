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

        [JwtAuthorize(Roles = "Admin,User")]
        public async Task<IActionResult> Index()
        {
            var data = await _addressService.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> GetById(int id)
        {
            var data = await _addressService.GetByIdAsync(id);
            return View(data);
        }
    }
}
