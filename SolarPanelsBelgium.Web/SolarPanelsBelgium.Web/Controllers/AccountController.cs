using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SolarPanelsBelgium.Core.Entitites;
using SolarPanelsBelgium.Web.ViewModels;

namespace SolarPanelsBelgium.Web.Controllers
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


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(await _userManager.FindByEmailAsync(model.Email) == null)
                {
                    var applicationUser = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        FirstName = model.Firstname,
                        LastName = model.Lastname,
                        Address = model.Address,
                    };

                    var result = await _userManager.CreateAsync(applicationUser, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email already in use.");
                }
            }
            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
