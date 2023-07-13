using Business.Dtos.Users;
using Data.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ToysSalesWebIU.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,IPasswordHasher<AppUser> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
        }

        [AllowAnonymous]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost,AllowAnonymous,ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByNameAsync(model.UserName);
                if(user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Giriş Başarılı";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ModelState.AddModelError("", "Yanlış Giriş");
                }
                else
                    TempData["Error"] = "Kullanıcı adı veya  Şifre yanlış";
            }
            return View(model);
        }


        [HttpGet,AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost,AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid) 
            {
                AppUser user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                IdentityResult result=await _userManager.CreateAsync(user,model.Password);

                if (result.Succeeded) 
                {
                    TempData["Success"] = "Kayıt Başarılı";
                    return RedirectToAction("LogIn");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }

        [HttpGet,AllowAnonymous]
        public async Task<IActionResult> EditUser()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                EditUserProfileDTO model = new EditUserProfileDTO()
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    Password = user.PasswordHash
                };
                return View(model);
            }
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserProfileDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.UserName=model.UserName;
                user.Email=model.Email;

                if (model.Password != null)
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user,model.Password);
                }

                IdentityResult result = await _userManager.UpdateAsync(user);

                if (result.Succeeded) 
                {
                    TempData["Success"] = "Profil Güncellendi";
                }
                else
                    TempData["Error"] = "Profil Güncellenemedi";
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            TempData["Success"] = "Oturum Kapatıldı";
            return RedirectToAction("Index","Home");
        }
    }
}
