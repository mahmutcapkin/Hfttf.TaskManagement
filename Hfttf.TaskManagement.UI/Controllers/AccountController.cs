using Hfttf.TaskManagement.UI.ApiServices.Interfaces;
using Hfttf.TaskManagement.UI.Models.Authentication;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Login(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel signInViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.SignIn(signInViewModel))
                {
                    if (TempData["returnUrl"] != null)
                    {
                        return Redirect(TempData["returnUrl"].ToString());
                    }
                    var token = HttpContext.Session.GetString("token");
                    return RedirectToAction("MyProfile", "ProfileInfo");
                }
                ModelState.AddModelError("", "kullanıcı adı veya şifre hatalı");
            }
            return View(signInViewModel);

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Register(SignUpViewModel signUpViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.SignUp(signUpViewModel))
                {
                    if (TempData["returnUrl"] != null)
                    {
                        return Redirect(TempData["returnUrl"].ToString());
                    }
                    return RedirectToAction("Login", "Account");
                }
                ModelState.AddModelError("", "Kayıt olma işlemi başarısız");
            }
            return View(signUpViewModel);
        }
    }
}
