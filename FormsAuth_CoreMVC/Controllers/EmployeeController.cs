using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsAuth_CoreMVC.Controllers
{
    public class EmployeeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                 var userName = HttpContext.User.Claims.First().Value;

                ViewBag.user = userName;
            }
            return View();
        }
        [Authorize]
        public IActionResult Index2()
        { 
            return View();
        }
    }
}
