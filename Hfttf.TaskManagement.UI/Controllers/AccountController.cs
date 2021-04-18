using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel signInViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.SignIn(signInViewModel))
                {
                    return RedirectToAction("Index", "ProfileInfo");
                }
                ModelState.AddModelError("", "kullanıcı adı veya şifre hatalı");
            }
            return View(signInViewModel);

        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
