using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.EntityLayer.Concrete;
using TeaShopApi.WebUI.Models;

namespace TeaShopApi.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)

            {
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }

            return View();
        }
    }
}
