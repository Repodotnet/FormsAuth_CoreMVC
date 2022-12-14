using FormsAuth_CoreMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FormsAuth_CoreMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.username.ToLower() == "admin" && viewModel.password == "123")
                {
                    var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name,viewModel.username),
                    new Claim(ClaimTypes.Role,"User")

                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal user = new ClaimsPrincipal(claimsIdentity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user, new AuthenticationProperties()
                    {
                        IsPersistent = false,
                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                        AllowRefresh = true
                    }
                        );
                  
                    return RedirectToAction("Index", "Employee");

                }
                ModelState.AddModelError(string.Empty, "Invalid username and password");
            }

            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
