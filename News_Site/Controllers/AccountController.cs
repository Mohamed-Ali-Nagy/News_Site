using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News_Site.Models;
using News_Site.ViewModels.AccountVMs;

namespace News_Site.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser? user = await _userManager.FindByEmailAsync(loginUser.Email);
                if (user == null)
                {
                    ModelState.AddModelError(String.Empty, "Invalid login attempt.");
                    return View(loginUser);

                }

                bool validPassword = await _userManager.CheckPasswordAsync(user, loginUser.Password);
                if (validPassword)
                {
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "News");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");

                }
            }
            return View(loginUser);
        }

    
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}

