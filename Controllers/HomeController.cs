using DIRP.Data;
using DIRP.Infrastructure;
using DIRP.Models;
using DIRP.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DIRP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepo _repo;

        public HomeController(ILogger<HomeController> logger,IStudentRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var item = _repo.GetAll();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var item = _repo.GetById(id);
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            var item = _repo.GetById(id);
            return View(item);
        }

        public IActionResult Delete(int id)
        {
            var item = _repo.GetById(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _repo.UpdateData(student);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            _repo.DeleteStudent(student);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _repo.Create(student);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
