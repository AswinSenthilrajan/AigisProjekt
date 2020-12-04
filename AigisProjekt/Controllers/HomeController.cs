using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AigisProjekt.Models;
using AigisProjekt.Data;

namespace AigisProjekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Database _context;

        public HomeController(Database context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult Index()
        {
            var data = _context.Student.ToList();
            return View(data);
        }


        public IActionResult EditStudent(int id) {
            var student = id == 0 ? new Student() { Id = 0 }:  _context.Student.Find(id);
            return View(student);
        }
        /// <summary>
        /// Updates Server
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveStudent(Student student)
        {
            if (student.Id == 0)
            {
                var serverStud = new Student();
                serverStud.Name = student.Name;
                serverStud.Prename = student.Prename;
                _context.Student.Add(serverStud);
                _context.SaveChanges();
            }
            else
            {
                var serverStud = _context.Student.Find(student.Id);
                serverStud.Name = student.Name;
                serverStud.Prename = student.Prename;
                _context.SaveChanges();
            }
            return RedirectToAction("Index","Home");
        }

        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Student.Find(id);
            _context.Student.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
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
