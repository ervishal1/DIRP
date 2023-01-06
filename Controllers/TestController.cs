using DIRP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIRP.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("Email", student.Email, cookie);
            ViewBag.Saved = "Cookie Saved";
            return View();
        }

        public IActionResult ReadCookies()
        {
            ViewBag.Email = Request.Cookies["Email"].ToString();
            return View("Create");
        }
    }
}
